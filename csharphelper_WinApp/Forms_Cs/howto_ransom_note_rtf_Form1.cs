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
     public partial class howto_ransom_note_rtf_Form1:Form
  { 


        public howto_ransom_note_rtf_Form1()
        {
            InitializeComponent();
        }

        // Font names we may use.
        private string[] FontNames =
        {
            "Times New Roman",
            "Courier New",
            "Comic Sans MS",
            "Arial",
            "News Gothic MT",
            "AvantGarde Md BT",
            "Benguiat Bk BT",
            "Bookman Old Style",
            "Bremen Bd BT",
            "Century Gothic",
            "Dauphin",
            "Curlz MT",
            "GoudyHandtooled BT",
        };

        // Colors we may use.
        private Color[] FontColors =
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Orange,
            Color.Brown,
            Color.Magenta,
            Color.Purple,
            Color.BurlyWood,
            Color.HotPink,
        };

        // The random number generator we will use.
        private Random Rand = new Random();

        // Display the initial text.
        private void howto_ransom_note_rtf_Form1_Load(object sender, EventArgs e)
        {
            DrawText();
        }

        // Draw the text.
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            DrawText();
        }

        // Draw the text in the PictureBox.
        private void DrawText()
        {
            rchText.Text = "";
            foreach (char ch in txtText.Text)
            {
                DrawCharacter(ch);
            }
        }

        // Draw a character in a random font.
        private void DrawCharacter(char ch)
        {
            const float min_size = 25;
            const float max_size = 35;

            // Pick the random font characteristics.
            string font_name = FontNames[Rand.Next(0, FontNames.Length)];
            float font_size = (float)(min_size + Rand.NextDouble() * (max_size - min_size));
            FontStyle font_style = FontStyle.Regular;
            if (Rand.Next(0, 2) == 1) font_style |= FontStyle.Bold;
            if (Rand.Next(0, 2) == 1) font_style |= FontStyle.Italic;
            //if (Rand.Next(0,2) == 1) font_style |= FontStyle.Strikeout;
            //if (Rand.Next(0,2) == 1) font_style |= FontStyle.Underline;

            rchText.SelectionFont = new Font(font_name, font_size, font_style);
            rchText.SelectionColor = FontColors[Rand.Next(0, FontColors.Length)];
            rchText.AppendText(ch.ToString());
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
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rchText
            // 
            this.rchText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchText.Location = new System.Drawing.Point(12, 38);
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(310, 261);
            this.rchText.TabIndex = 4;
            this.rchText.Text = "";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(12, 12);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(310, 20);
            this.txtText.TabIndex = 3;
            this.txtText.Text = "When in worry or in doubt, run in circles scream and shout";
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // howto_ransom_note_rtf_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.rchText);
            this.Controls.Add(this.txtText);
            this.Name = "howto_ransom_note_rtf_Form1";
            this.Text = "howto_ransom_note_rtf";
            this.Load += new System.EventHandler(this.howto_ransom_note_rtf_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchText;
        private System.Windows.Forms.TextBox txtText;
    }
}

