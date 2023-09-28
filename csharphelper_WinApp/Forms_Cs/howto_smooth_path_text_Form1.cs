using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_smooth_path_text_Form1:Form
  { 


        public howto_smooth_path_text_Form1()
        {
            InitializeComponent();
        }

        // Use a big font.
        private void howto_smooth_path_text_Form1_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Times New Roman", 30, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        // Draw text samples.
        private void howto_smooth_path_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            int y = 10;
            e.Graphics.DrawString("DrawString Normal", this.Font, Brushes.Blue, 10, y);
            y += this.Font.Height;

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString("DrawString Smooth", this.Font, Brushes.Blue, 10, y);
            y += this.Font.Height;

            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Near;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString("DrawPath Normal", this.Font.FontFamily,
                        (int)this.Font.Style, this.Font.Size, new Point(10, y),
                        string_format);
                    e.Graphics.FillPath(Brushes.Blue, path);
                    y += this.Font.Height;
                }

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString("DrawPath Smooth", this.Font.FontFamily,
                        (int)this.Font.Style, this.Font.Size, new Point(10, y),
                        string_format);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(Brushes.Blue, path);
                    y += this.Font.Height;
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
            // howto_smooth_path_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 161);
            this.Name = "howto_smooth_path_text_Form1";
            this.Text = "howto_smooth_path_text";
            this.Load += new System.EventHandler(this.howto_smooth_path_text_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_smooth_path_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

