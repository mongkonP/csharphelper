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
     public partial class howto_eyes_no_flicker_Form1:Form
  { 


        public howto_eyes_no_flicker_Form1()
        {
            InitializeComponent();
        }

        // The previous mouse location.
        private Point OldMousePos = new Point(-1, -1);

        // A thick pen.
        private Pen ThickPen = new Pen(Color.Black, 3);

        // See if the mouse has moved.
        private void tmrTick_Tick(object sender, EventArgs e)
        {
            // See if the cursor has moved.
            Point new_pos = Control.MousePosition;
            if (new_pos.Equals(OldMousePos)) return;
            OldMousePos = new_pos;

            // Redraw.
            Refresh();
        }

        private void howto_eyes_no_flicker_Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawEyes(e.Graphics);
        }

        // Draw the eyes.
        private void DrawEyes(Graphics gr)
        {
            // Convert the cursor position into form units.
            Point local_pos = this.PointToClient(OldMousePos);

            // Calculate the size of the eye.
            int hgt = (int)(this.ClientSize.Height * 0.9);
            int wid = (int)(this.ClientSize.Width * 0.45);

            // Find the positions of the eyes.
            int y = (this.ClientSize.Height - hgt) / 2;
            int x1 = (int)((this.ClientSize.Width - wid * 2) / 3);
            int x2 = wid + 2 * x1;

            // Create a Bitmap on which to draw.
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.Clear(this.BackColor);

            // Draw the eyes.
            DrawEye(gr, local_pos, x1, y, wid, hgt);
            DrawEye(gr, local_pos, x2, y, wid, hgt);
        }

        // Draw an eye here.
        private void DrawEye(Graphics gr, Point local_pos, int x1, int y1, int wid, int hgt)
        {
            // Draw the outside.
            gr.FillEllipse(Brushes.White, x1, y1, wid, hgt);
            gr.DrawEllipse(ThickPen, x1, y1, wid, hgt);

            // Find the center of the eye.
            int cx = x1 + wid / 2;
            int cy = y1 + hgt / 2;

            // Get the unit vector pointing towards the mouse position.
            double dx = local_pos.X - cx;
            double dy = local_pos.Y - cy;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            dx /= dist;
            dy /= dist;

            // This point is 1/4 of the way
            // from the center to the edge of the eye.
            double px = cx + dx * wid / 4;
            double py = cy + dy * hgt / 4;

            // Draw an ellipse 1/2 the size of the eye
            // centered at (px, py).
            gr.FillEllipse(Brushes.Blue, (int)(px - wid / 4),
                (int)(py - hgt / 4), wid / 2, hgt / 2);
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
            this.components = new System.ComponentModel.Container();
            this.tmrTick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrTick
            // 
            this.tmrTick.Enabled = true;
            this.tmrTick.Tick += new System.EventHandler(this.tmrTick_Tick);
            // 
            // howto_eyes_no_flicker_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "howto_eyes_no_flicker_Form1";
            this.Text = "howto_eyes_no_flicker";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_eyes_no_flicker_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrTick;
    }
}

