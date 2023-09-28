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
     public partial class howto_find_richtextbox_word_Form1:Form
  { 


        public howto_find_richtextbox_word_Form1()
        {
            InitializeComponent();
        }

        // Return the word under the mouse.
        private string WordUnderMouse(RichTextBox rch, int x, int y)
        {
            // Get the character's position.
            int pos = rch.GetCharIndexFromPosition(new Point(x, y));
            if (pos <= 0) return "";

            // Find the start of the word.
            string txt = rch.Text;

            int start_pos;
            for (start_pos = pos; start_pos >= 0; start_pos--)
            {
                // Allow digits, letters, and underscores
                // as part of the word.
                char ch = txt[start_pos];
                if (!char.IsLetterOrDigit(ch) && !(ch == '_')) break;
            }
            start_pos++;

            // Find the end of the word.
            int end_pos;
            for (end_pos = pos; end_pos < txt.Length; end_pos++)
            {
                char ch = txt[end_pos];
                if (!char.IsLetterOrDigit(ch) && !(ch == '_')) break;
            }
            end_pos--;

            // Return the result.
            if (start_pos > end_pos) return "";
            return txt.Substring(start_pos, end_pos - start_pos + 1);
        }

        // Display the word under the mouse.
        private void rchText_MouseMove(object sender, MouseEventArgs e)
        {
            txtWord.Text = WordUnderMouse(rchText, e.X, e.Y);
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
            this.txtWord = new System.Windows.Forms.TextBox();
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtWord
            // 
            this.txtWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWord.Location = new System.Drawing.Point(12, 84);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(310, 20);
            this.txtWord.TabIndex = 3;
            // 
            // rchText
            // 
            this.rchText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchText.Location = new System.Drawing.Point(12, 12);
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(310, 66);
            this.rchText.TabIndex = 2;
            this.rchText.Text = "Outside of a dog, a book is man\'s best friend. Inside of a dog it\'s too dark to r" +
                "ead. -- Groucho Marx";
            this.rchText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rchText_MouseMove);
            // 
            // howto_find_richtextbox_word_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 116);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.rchText);
            this.Name = "howto_find_richtextbox_word_Form1";
            this.Text = "howto_find_richtextbox_word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.RichTextBox rchText;
    }
}

