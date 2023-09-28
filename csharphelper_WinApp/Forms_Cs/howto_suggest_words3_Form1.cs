// #define USE_LINQ

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_suggest_words3_Form1:Form
  { 


        public howto_suggest_words3_Form1()
        {
            InitializeComponent();
        }

        // The dictionary.
        private List<string>[] Words;

        // Load the dictionary.
        private void howto_suggest_words3_Form1_Load(object sender, EventArgs e)
        {
            // Get the words from the dictionary file.
            string[] lines = File.ReadAllLines("Words.txt");

            // Group the words by first letter.
            Words = new List<string>[26];
            for (int i = 0; i < 26; i++)
                Words[i] = new List<string>();

#if USE_LINQ
            // LINQ method.
            var word_groups =
                from string line in lines
                group line by line.ToUpper()[0] into g
                select new { Letter = g.Key, Words = g };
            foreach (var g in word_groups)
            {
                int index = (int)g.Letter - (int)'A';
                Words[index] = g.Words.ToList();
            }
#else
            // Non-LINQ method.
            foreach (string line in lines)
            {
                if (line.Length > 1)
                {
                    // Get the first letter.
                    int index = (int)line.ToUpper()[0] - (int)'A';
                    Words[index].Add(line);
                }
            }
#endif

            txtWord.Text = "absi";
        }

        // Find good guesses for this word.
        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            lstGuesses.DataSource = null;
            string word = txtWord.Text;
            if (word.Length == 0) return;

            // Find the best matches.
            lstGuesses.DataSource = FindBestMatches(word, 100);
        }

        private enum Direction
        {
            FromAbove,
            FromLeft,
            FromDiagonal
        }

        private struct Node
        {
            public int distance;
            public Direction direction;
        }

        // Fill in the edit graph for two strings.
        private Node[,] MakeEditGraph(string string1, string string2)
        {
            // Make the edit graph array.
            int num_cols = string1.Length + 1;
            int num_rows = string2.Length + 1;
            Node[,] nodes = new Node[num_rows, num_cols];

            // Initialize the leftmost column.
            for (int r = 0; r < num_rows; r++)
            {
                nodes[r, 0].distance = r;
                nodes[r, 0].direction = Direction.FromAbove;
            }

            // Initialize the top row.
            for (int c = 0; c < num_cols; c++)
            {
                nodes[0, c].distance = c;
                nodes[0, c].direction = Direction.FromLeft;
            }

            // Fill in the rest of the array.
            char[] chars1 = string1.ToCharArray();
            char[] chars2 = string2.ToCharArray();
            for (int c = 1; c < num_cols; c++)
            {
                // Fill in column c.
                for (int r = 1; r < num_rows; r++)
                {
                    // Fill in entry [r, c].
                    // Check the three possible paths to here.
                    int distance1 = nodes[r - 1, c].distance + 1;
                    int distance2 = nodes[r, c - 1].distance + 1;
                    int distance3 = int.MaxValue;
                    if (chars1[c - 1] == chars2[r - 1])
                    {
                        // There is a diagonal link.
                        distance3 = nodes[r - 1, c - 1].distance;
                    }

                    // See which is cheapest.
                    if ((distance1 <= distance2) && (distance1 <= distance3))
                    {
                        // Come from above.
                        nodes[r, c].distance = distance1;
                        nodes[r, c].direction = Direction.FromAbove;
                    }
                    else if (distance2 <= distance3)
                    {
                        // Come from the left.
                        nodes[r, c].distance = distance2;
                        nodes[r, c].direction = Direction.FromLeft;
                    }
                    else
                    {
                        // Come from the diagonal.
                        nodes[r, c].distance = distance3;
                        nodes[r, c].direction = Direction.FromDiagonal;
                    }
                }
            }

            // Display the graph's nodes (for debugging).
            //DumpArray(nodes);

            return nodes;
        }

        // Return the edit distance from target_word to test_word.
        private int GetEditDistance(string target_word, string test_word)
        {
            // Make test_word the same length as target_word.
            int max_length = Math.Min(test_word.Length, target_word.Length);
            test_word = test_word.Substring(0, max_length);

            // Build the edit graph.
            Node[,] nodes = MakeEditGraph(target_word, test_word);

            // Return the distance.
            int x = nodes.GetUpperBound(0);
            int y = nodes.GetUpperBound(1);
            return nodes[x, y].distance;
        }

        // Display the graph's nodes (for debugging).
        private void DumpArray(Node[,] nodes)
        {
            int num_rows = nodes.GetUpperBound(0) + 1;
            int num_cols = nodes.GetUpperBound(1) + 1;

            Console.WriteLine("**********");
            // Fill in column c.
            for (int r = 0; r < num_rows; r++)
            {
                for (int c = 0; c < num_cols; c++)
                {
                    string txt = "";
                    switch (nodes[r, c].direction)
                    {
                        case Direction.FromAbove:
                            txt = "v";
                            break;
                        case Direction.FromLeft:
                            txt = "-";
                            break;
                        case Direction.FromDiagonal:
                            txt = "\\";
                            break;
                    }
                    txt += nodes[r, c].distance.ToString();
                    Console.Write(string.Format("{0,3}", txt));
                }
                Console.WriteLine();
            }
            Console.WriteLine("**********");
        }

        // Display the best path (for debugging).
        private void DumpPath(Stack<int> row, Stack<int> col)
        {
            Console.WriteLine("**********");
            int[] rows = row.ToArray();
            int[] cols = col.ToArray();
            for (int i = 0; i < row.Count; i++)
            {
                Console.Write("(" + rows[i] + ", " + cols[i] + ") ");
            }
            Console.WriteLine();
            Console.WriteLine("**********");
        }

        // Find the best matches for the typed word.
        private string[] FindBestMatches(string target_word, int num_matches)
        {
            // Get the word list for the word's first letter.
            int index = (int)target_word.ToUpper()[0] - (int)'A';

            // Use LINQ to select the test words' edit distance.
            var word_distance_query =
                from string test_word in Words[index]
                orderby GetEditDistance(target_word, test_word)
                select GetEditDistance(target_word, test_word) + " " + test_word;

            // Return up to the desired number of matches.
            return word_distance_query.Take(num_matches).ToArray();
        }
    

/// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstGuesses = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstGuesses
            // 
            this.lstGuesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGuesses.FormattingEnabled = true;
            this.lstGuesses.Location = new System.Drawing.Point(15, 38);
            this.lstGuesses.Name = "lstGuesses";
            this.lstGuesses.Size = new System.Drawing.Size(277, 108);
            this.lstGuesses.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Word:";
            // 
            // txtWord
            // 
            this.txtWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWord.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWord.Location = new System.Drawing.Point(54, 12);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(238, 20);
            this.txtWord.TabIndex = 15;
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            // 
            // howto_suggest_words3_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 161);
            this.Controls.Add(this.lstGuesses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWord);
            this.Name = "howto_suggest_words3_Form1";
            this.Text = "howto_suggest_words3";
            this.Load += new System.EventHandler(this.howto_suggest_words3_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstGuesses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWord;
    }
}

