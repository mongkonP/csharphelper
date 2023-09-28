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
     public partial class howto_biggest_font_label_Form1:Form
  { 


        public howto_biggest_font_label_Form1()
        {
            InitializeComponent();
        }

        private void txtSample_TextChanged(object sender, EventArgs e)
        {
            ShowSample();
        }
        private void lblSample_Resize(object sender, EventArgs e)
        {
            ShowSample();
        }

        // Display the sample text as large as possible.
        private void ShowSample()
        {
            string text = txtSample.Text;
            if (text.Length == 0) return;

            float font_size = GetFontSize(
                lblSample, text, 10, 1, 1000);
            lblFontSize.Text = font_size.ToString("0.0");
            lblSample.Font = new Font(lblSample.Font.FontFamily, font_size);
            lblSample.Text = text;
        }

        // Return the largest font size that lets the text fit in the Label.
        private float GetFontSize(Label label, string text,
            int margin, float min_size, float max_size)
        {
            // Only bother if there's text.
            if (text.Length == 0) return min_size;

            // See how much room we have, allowing a bit
            // for the Label's internal margin.
            int wid = label.DisplayRectangle.Width - margin;
            int hgt = label.DisplayRectangle.Height - margin;

            // Make a Graphics object to measure the text.
            using (Graphics gr = label.CreateGraphics())
            {
                while (max_size - min_size > 0.1f)
                {
                    float pt = (min_size + max_size) / 2f;
                    using (Font test_font = new Font(label.Font.FontFamily, pt))
                    {
                        // See if this font is too big.
                        SizeF text_size = gr.MeasureString(text, test_font);
                        if ((text_size.Width > wid) || (text_size.Height > hgt))
                            max_size = pt;
                        else
                            min_size = pt;
                    }
                }
                return min_size;
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
            this.txtSample = new System.Windows.Forms.TextBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSample
            // 
            this.txtSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSample.Location = new System.Drawing.Point(8, 140);
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(196, 20);
            this.txtSample.TabIndex = 7;
            this.txtSample.TextChanged += new System.EventHandler(this.txtSample_TextChanged);
            // 
            // lblSample
            // 
            this.lblSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSample.Location = new System.Drawing.Point(8, 8);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(312, 124);
            this.lblSample.TabIndex = 6;
            this.lblSample.Resize += new System.EventHandler(this.lblSample_Resize);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Font Size:";
            // 
            // lblFontSize
            // 
            this.lblFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFontSize.Location = new System.Drawing.Point(270, 140);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(47, 20);
            this.lblFontSize.TabIndex = 9;
            this.lblFontSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // howto_biggest_font_label_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 169);
            this.Controls.Add(this.lblFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSample);
            this.Controls.Add(this.lblSample);
            this.Name = "howto_biggest_font_label_Form1";
            this.Text = "howto_biggest_font_label";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtSample;
        internal System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFontSize;
    }
}

