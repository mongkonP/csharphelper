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
     public partial class howto_rtf_subscripts2_Form1:Form
  { 


        public howto_rtf_subscripts2_Form1()
        {
            InitializeComponent();
        }

        private void howto_rtf_subscripts2_Form1_Load(object sender, EventArgs e)
        {
            ShowText();
        }
        // Display the new RTF text.
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            ShowText();
        }
        private void ShowText()
        {
            // Make the subscript/superscript font and offset.
            float font_size = rchEquation.Font.Size;
            Font small_font = new Font(
                rchEquation.Font.FontFamily,
                font_size * 0.75f);
            int offset = (int)(font_size * 0.5);

            // Assign the text.
            MakeRtfSubsSupers(rchEquation, txtText.Text, small_font, offset);

            // Center.
            rchEquation.Select(0, rchEquation.Text.Length);
            rchEquation.SelectionAlignment = HorizontalAlignment.Center;
            rchEquation.Select(0, 0);
        }

        // Make subscripts and superscripts in the control
        // for characters following - and +. To make - or +,
        // use /- and /+.
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
                char ch = text[pos];

                // Check for special characters.
                if ((ch == '/') || (ch == '-') || (ch == '+'))
                {
                    // Add the next character to the new text.
                    if (++pos >= text.Length) return;
                    new_text += text[pos];

                    // Mark as a subscript or superscript if necessary.
                    if (ch == '-') subs.Add(new_text.Length - 1);
                    if (ch == '+') supers.Add(new_text.Length - 1);
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
                //rch.SelectionBackColor = Color.Pink;
            }
            foreach (int position in supers)
            {
                rch.Select(position, 1);
                rch.SelectionCharOffset = offset;
                rch.SelectionFont = small_font;
                //rch.SelectionBackColor = Color.LightGreen;
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
            this.txtText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rchEquation
            // 
            this.rchEquation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchEquation.Location = new System.Drawing.Point(12, 87);
            this.rchEquation.Name = "rchEquation";
            this.rchEquation.Size = new System.Drawing.Size(270, 45);
            this.rchEquation.TabIndex = 2;
            this.rchEquation.Text = "";
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(12, 25);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(270, 26);
            this.txtText.TabIndex = 3;
            this.txtText.Text = "A-+-1-/---2 /+///- B+++3+/+-+4";
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "RTF:";
            // 
            // howto_rtf_subscripts2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 144);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.rchEquation);
            this.Name = "howto_rtf_subscripts2_Form1";
            this.Text = "howto_rtf_subscripts2";
            this.Load += new System.EventHandler(this.howto_rtf_subscripts2_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchEquation;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

