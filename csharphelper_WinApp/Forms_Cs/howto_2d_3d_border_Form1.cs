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
     public partial class howto_2d_3d_border_Form1:Form
  { 


        public howto_2d_3d_border_Form1()
        {
            InitializeComponent();
        }

        // Draw some borders.
        private void howto_2d_3d_border_Form1_Paint(object sender, PaintEventArgs e)
        {
            const int gap = 8;
            const int num_rows = 4;
            int wid = this.DisplayRectangle.Width / num_rows;
            int hgt = this.DisplayRectangle.Height / num_rows;

            for (int x = 0; x < num_rows; x++)
            {
                for (int y = 0; y < num_rows; y++)
                {
                    DrawBorder(e.Graphics,
                        new Rectangle(
                            x * wid + gap / 2,
                            y * hgt + gap / 2,
                            wid - gap, hgt - gap),
                        BorderStyle.Fixed3D,
                        y == x);
                }
            }
            DrawBorder(e.Graphics, this.DisplayRectangle, BorderStyle.Fixed3D);
        }

        // Draw a border inside this rectangle.
        private void DrawBorder(Graphics gr, Rectangle rect, BorderStyle border_style)
        {
            DrawBorder(gr, rect, border_style, true);
        }
        private void DrawBorder(Graphics gr, Rectangle rect, BorderStyle border_style, bool sunken)
        {
            if (border_style == BorderStyle.FixedSingle)
            {
                rect.Width -= 1;
                rect.Height -= 1;
                gr.DrawRectangle(Pens.Black, rect);
            }
            else if (border_style == BorderStyle.Fixed3D)
            {
                Color[] colors;
                if (sunken)
                {
                    colors = new Color[]
                    {
                        SystemColors.ControlDark,
                        SystemColors.ControlDarkDark,
                        SystemColors.ControlLightLight,
                        SystemColors.ControlLight
                    };
                }
                else
                {
                    colors = new Color[]
                    {
                        SystemColors.ControlLightLight,
                        SystemColors.ControlLight,
                        SystemColors.ControlDark,
                        SystemColors.ControlDarkDark
                    };
                }
                using (Pen p = new Pen(colors[0]))
                {
                    gr.DrawLine(p, rect.X, rect.Bottom - 1, rect.X, rect.Y);
                    gr.DrawLine(p, rect.X, rect.Y, rect.Right - 1, rect.Y);
                }
                using (Pen p = new Pen(colors[1]))
                {
                    gr.DrawLine(p, rect.X + 1, rect.Bottom - 2, rect.X + 1, rect.Y + 1);
                    gr.DrawLine(p, rect.X + 1, rect.Y + 1, rect.Right - 2, rect.Y + 1);
                }
                using (Pen p = new Pen(colors[2]))
                {
                    gr.DrawLine(p, rect.X, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                    gr.DrawLine(p, rect.Right - 1, rect.Bottom - 1, rect.Right - 1, rect.Y);
                }
                using (Pen p = new Pen(colors[3]))
                {
                    gr.DrawLine(p, rect.X + 1, rect.Bottom - 2, rect.Right - 2, rect.Bottom - 2);
                    gr.DrawLine(p, rect.Right - 2, rect.Bottom - 2, rect.Right - 2, rect.Y + 1);
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
            // howto_2d_3d_border_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Name = "howto_2d_3d_border_Form1";
            this.Text = "howto_2d_3d_border";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_2d_3d_border_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

