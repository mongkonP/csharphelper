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
     public partial class howto_easy_rtf_subscripts_Form1:Form
  { 


        public howto_easy_rtf_subscripts_Form1()
        {
            InitializeComponent();
        }

        private void howto_easy_rtf_subscripts_Form1_Load(object sender, EventArgs e)
        {
            // Make the subscript/superscript font and offset.
            float font_size = rchEquation.Font.Size;
            Font small_font = new Font(
                rchEquation.Font.FontFamily,
                font_size * 0.75f);
            int offset = (int)(font_size * 0.5);
 
            // Assign the text.
            MakeRtfSubsSupers(rchEquation,
                "2H-2 ++ O-2 = 2H-2O\n5+2 -- 4+2 = 3+2",
                small_font, offset);

            // Center.
            rchEquation.Select(0, rchEquation.Text.Length);
            rchEquation.SelectionAlignment = HorizontalAlignment.Center;

            rchEquation.Select(0, 0);
        }

        // Make subscripts and superscripts in the control
        // for characters following - and +. To make - or +,
        // use -- and ++.
        private void MakeRtfSubsSupers(RichTextBox rch,
            string text, Font small_font, int offset)
        {
            // Find the subscript and superscript positions.
            List<int> subs = new List<int>();
            List<int> supers = new List<int>();
            string new_text = "";
            int pos = 0;
            while (pos < text.Length)
            {
                // See if this character is - or  +.
                char ch = text[pos];
                if (ch == '-')
                {
                    // Add the next character to the new text.
                    pos++;
                    new_text += text[pos];

                    // See if this is a subscript.
                    if (text[pos] != '-') subs.Add(new_text.Length - 1);
                }
                else if (ch == '+')
                {
                    // Add the next character to the new text.
                    pos++;
                    new_text += text[pos];

                    // See if this is a superscript.
                    if (text[pos] != '+') supers.Add(new_text.Length - 1);
                }
                else new_text += ch;

                // Move to the next character.
                pos++;
            }

            // Format the subscripts and superscripts.
            rch.Text = new_text;
            foreach (int position in subs)
            {
                rch.Select(position, 1);
                rch.SelectionCharOffset = -offset;
                rch.SelectionFont = small_font;
            }
            foreach (int position in supers)
            {
                rch.Select(position, 1);
                rch.SelectionCharOffset = offset;
                rch.SelectionFont = small_font;
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
            this.rchEquation = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchEquation
            // 
            this.rchEquation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchEquation.Location = new System.Drawing.Point(12, 12);
            this.rchEquation.Name = "rchEquation";
            this.rchEquation.Size = new System.Drawing.Size(270, 87);
            this.rchEquation.TabIndex = 1;
            this.rchEquation.Text = "";
            // 
            // howto_easy_rtf_subscripts_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 111);
            this.Controls.Add(this.rchEquation);
            this.Name = "howto_easy_rtf_subscripts_Form1";
            this.Text = "howto_easy_rtf_subscripts";
            this.Load += new System.EventHandler(this.howto_easy_rtf_subscripts_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchEquation;
    }
}

