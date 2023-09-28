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
     public partial class howto_animate_atom_Form1:Form
  { 


        public howto_animate_atom_Form1()
        {
            InitializeComponent();
        }

        private void howto_animate_atom_Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }

        // Redraw.
        private void tmrAtom_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private double Theta = 0;
        private const double Dtheta = Math.PI / 5;

        // Draw the atom.
        private void howto_animate_atom_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Theta += Dtheta;

            const int radius = 3;
            int cx = 50, cy = 50, rx = 45, ry = 15;
            Rectangle rect = new Rectangle(-rx, -ry, 2 * rx, 2 * ry);
            double x, y;
            e.Graphics.RotateTransform(60, MatrixOrder.Append);
            e.Graphics.TranslateTransform(cx, cy, MatrixOrder.Append);
            e.Graphics.DrawEllipse(Pens.Red, rect);
            x = rx * Math.Cos(Theta);
            y = ry * Math.Sin(Theta);
            e.Graphics.FillEllipse(Brushes.Red,
                (int)(x - radius), (int)(y - radius),
                2 * radius, 2 * radius);

            e.Graphics.ResetTransform();
            e.Graphics.RotateTransform(-60, MatrixOrder.Append);
            e.Graphics.TranslateTransform(cx, cy, MatrixOrder.Append);
            e.Graphics.DrawEllipse(Pens.Red, rect);
            x = rx * Math.Cos(-Theta * 0.9);
            y = ry * Math.Sin(-Theta * 0.9);
            e.Graphics.FillEllipse(Brushes.Green,
                (int)(x - radius), (int)(y - radius),
                2 * radius, 2 * radius);

            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(cx, cy, MatrixOrder.Append);
            e.Graphics.DrawEllipse(Pens.Red, rect);
            x = rx * Math.Cos(Theta * 0.8);
            y = ry * Math.Sin(Theta * 0.8);
            e.Graphics.FillEllipse(Brushes.Blue,
                (int)(x - radius), (int)(y - radius),
                2 * radius, 2 * radius);

            e.Graphics.ResetTransform();
            e.Graphics.FillEllipse(Brushes.Black,
                cx - radius, cy - radius,
                2 * radius, 2 * radius);
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
            this.tmrAtom = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrAtom
            // 
            this.tmrAtom.Enabled = true;
            this.tmrAtom.Tick += new System.EventHandler(this.tmrAtom_Tick);
            // 
            // howto_animate_atom_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Name = "howto_animate_atom_Form1";
            this.Text = "howto_animate_atom";
            this.Load += new System.EventHandler(this.howto_animate_atom_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_animate_atom_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Timer tmrAtom;
    }
}

