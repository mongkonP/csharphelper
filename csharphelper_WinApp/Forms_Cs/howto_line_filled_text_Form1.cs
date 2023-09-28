using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_line_filled_text_Form1:Form
  { 


        public howto_line_filled_text_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_line_filled_text_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw the lined-filled text.
        private void howto_line_filled_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            const string TXT = "C# Helper";

            // Make the result smoother.
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.Clear(this.BackColor);

            // Make a font.
            using (Font the_font = new Font("Times New Roman", 150,
                FontStyle.Bold, GraphicsUnit.Pixel))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    using (StringFormat string_format = new StringFormat())
                    {
                        string_format.Alignment = StringAlignment.Center;
                        string_format.LineAlignment = StringAlignment.Center;
                        int cx = ClientSize.Width / 2;
                        int cy = ClientSize.Height / 2;
                        path.AddString(TXT, the_font.FontFamily,
                            (int)the_font.Style, the_font.Size,
                            new Point(cx, cy), string_format);
                    }

                    // Restrict drawing to the path.
                    using (Region clip_region = new Region(path))
                    {
                        e.Graphics.Clip = clip_region;

                        // Fill the path with lines.
                        Random rand = new Random();
                        int x0, y0, x1, y1;
                        x0 = 0;
                        x1 = ClientSize.Width;
                        for (int i = 1; i < 75; i++)
                        {
                            y0 = rand.Next(0, ClientSize.Height);
                            y1 = rand.Next(0, ClientSize.Height);
                            e.Graphics.DrawLine(Pens.Black, x0, y0, x1, y1);
                        }
                        y0 = 0;
                        y1 = ClientSize.Height;
                        for (int i = 1; i < 75; i++)
                        {
                            x0 = rand.Next(0, ClientSize.Width);
                            x1 = rand.Next(0, ClientSize.Width);
                            e.Graphics.DrawLine(Pens.Black, x0, y0, x1, y1);
                        }

                        // Reset the clipping region.
                        e.Graphics.ResetClip();
                    }
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
            // howto_line_filled_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 194);
            this.Name = "howto_line_filled_text_Form1";
            this.Text = "howto_line_filled_text";
            this.Load += new System.EventHandler(this.howto_line_filled_text_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_line_filled_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

