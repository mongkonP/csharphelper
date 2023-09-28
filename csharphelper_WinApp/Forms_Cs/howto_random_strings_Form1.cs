using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_random_strings_Form1:Form
  { 


        public howto_random_strings_Form1()
        {
            InitializeComponent();
        }

        // Make the random words.
        private void btnGo_Click(object sender, EventArgs e)
        {
            lstWords.Items.Clear();

            // Get the number of words and letters per word.
            int num_letters = int.Parse(txtNumLetters.Text);
            int num_words = int.Parse(txtNumWords.Text);

            // Make an array of the letters we will use.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Make a random number generator.
            Random rand = new Random();

            // Make the words.
            for (int i = 1; i <= num_words; i++)
            {
                // Make a word.
                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    // Pick a random number between 0 and 25
                    // to select a letter from the letters array.
                    int letter_num = rand.Next(0, letters.Length - 1);

                    // Append the letter.
                    word += letters[letter_num];
                }

                // Add the word to the list.
                lstWords.Items.Add(word);
            }
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumLetters = new System.Windows.Forms.TextBox();
            this.txtNumWords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Letters:";
            // 
            // txtNumLetters
            // 
            this.txtNumLetters.Location = new System.Drawing.Point(69, 12);
            this.txtNumLetters.Name = "txtNumLetters";
            this.txtNumLetters.Size = new System.Drawing.Size(52, 20);
            this.txtNumLetters.TabIndex = 1;
            this.txtNumLetters.Text = "10";
            this.txtNumLetters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumWords
            // 
            this.txtNumWords.Location = new System.Drawing.Point(69, 38);
            this.txtNumWords.Name = "txtNumWords";
            this.txtNumWords.Size = new System.Drawing.Size(52, 20);
            this.txtNumWords.TabIndex = 3;
            this.txtNumWords.Text = "100";
            this.txtNumWords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Words:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(154, 25);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lstWords
            // 
            this.lstWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWords.FormattingEnabled = true;
            this.lstWords.Location = new System.Drawing.Point(12, 64);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(260, 186);
            this.lstWords.TabIndex = 5;
            // 
            // howto_random_strings_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumLetters);
            this.Controls.Add(this.label1);
            this.Name = "howto_random_strings_Form1";
            this.Text = "howto_random_strings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumLetters;
        private System.Windows.Forms.TextBox txtNumWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lstWords;
    }
}

