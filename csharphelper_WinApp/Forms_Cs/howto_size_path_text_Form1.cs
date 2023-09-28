using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_size_path_text_Form1:Form
  { 


        public howto_size_path_text_Form1()
        {
            InitializeComponent();
        }

        // Draw text samples.
        private void howto_size_path_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            const string txt = "Sample Text";

            int y = 10;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.DrawString(txt, this.Font, Brushes.Green, 10, y);
            y += this.Font.Height;

            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Near;

                // Get the form's font size in pixels no matter
                // what unit was used to create the font.
                float size_in_pixels = this.Font.SizeInPoints / 72 * e.Graphics.DpiX;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(txt, this.Font.FontFamily,
                        (int)this.Font.Style, size_in_pixels, new Point(10, y),
                        string_format);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(Brushes.Green, path);
                }
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
            this.SuspendLayout();
            // 
            // howto_size_path_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.Name = "howto_size_path_text_Form1";
            this.Text = "howto_size_path_text";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_size_path_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

