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
     public partial class howto_spline_tensions_Form1:Form
  { 


        public howto_spline_tensions_Form1()
        {
            InitializeComponent();
        }

        // The points selected by the user.
        private List<Point> Points = new List<Point>();

        private void howto_spline_tensions_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the points.
            foreach (Point point in Points)
                e.Graphics.FillEllipse(Brushes.Black,
                    point.X - 3, point.Y - 3, 5, 5);
            if (Points.Count < 2) return;

            // Draw the curve.
            using (Pen pen = new Pen(Color.Red))
            {
                for (int t = 0; t <= 20; t += 2)
                {
                    pen.Color = Color.FromArgb(255 * t / 20, 0, 255 - 255 * t / 20);
                    e.Graphics.DrawCurve(pen, Points.ToArray(), t / 10f);
                }
            }
        }

        // Select a point.
        private void howto_spline_tensions_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Points.Add(e.Location);
            Refresh();
        }

        // Start a new point list.
        private void mnuSplineNew_Click(object sender, EventArgs e)
        {
            Points = new List<Point>();
            Refresh();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplineNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSplineNew});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dataToolStripMenuItem.Text = "&Spline";
            // 
            // mnuSplineNew
            // 
            this.mnuSplineNew.Name = "mnuSplineNew";
            this.mnuSplineNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuSplineNew.Size = new System.Drawing.Size(141, 22);
            this.mnuSplineNew.Text = "&New";
            this.mnuSplineNew.Click += new System.EventHandler(this.mnuSplineNew_Click);
            // 
            // howto_spline_tensions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_spline_tensions_Form1";
            this.Text = "howto_spline_tensions";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_spline_tensions_Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_spline_tensions_Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSplineNew;
    }
}

