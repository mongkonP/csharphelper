using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_drawn_cursor_Form1:Form
  { 


        public howto_make_drawn_cursor_Form1()
        {
            InitializeComponent();
        }

        private void howto_make_drawn_cursor_Form1_Load(object sender, EventArgs e)
        {
            // Fit the background image.
            this.ClientSize = this.BackgroundImage.Size;

            // Draw the cursor image.
            const int wid = 63;
            const int hgt = 63;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Transparent);

                int cx = wid / 2;
                int cy = hgt / 2;
                Point[] outer_points =
                {
                    new Point(cx, 0),
                    new Point(2 * cx, cy),
                    new Point(cx, 2 * cy),
                    new Point(0, cy),
                };
                using (SolidBrush br =
                    new SolidBrush(Color.FromArgb(128, 255, 255, 0)))
                {
                    gr.FillPolygon(br, outer_points);
                }
                gr.DrawPolygon(Pens.Red, outer_points);

                Point[] inner_points =
                {
                    new Point(cx, cy - 6),
                    new Point(cx + 6, cy),
                    new Point(cx, cy + 6),
                    new Point(cx - 6, cy),
                };
                gr.FillPolygon(Brushes.LightBlue, inner_points);
                gr.DrawPolygon(Pens.Blue, inner_points);
            }

            // Turn the bitmap into a cursor.
            this.Cursor = new Cursor(bm.GetHicon());
        }

        private void howto_make_drawn_cursor_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Text = "(" + e.X.ToString() + ", " + e.Y.ToString() + ")";
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
            // howto_make_drawn_cursor_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Properties.Resources.JackOLanterns;
            this.ClientSize = new System.Drawing.Size(306, 405);
            this.Name = "howto_make_drawn_cursor_Form1";
            this.Text = "howto_make_drawn_cursor";
            this.Load += new System.EventHandler(this.howto_make_drawn_cursor_Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_make_drawn_cursor_Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

