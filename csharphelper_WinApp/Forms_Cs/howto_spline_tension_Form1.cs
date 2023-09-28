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
     public partial class howto_spline_tension_Form1:Form
  { 


        public howto_spline_tension_Form1()
        {
            InitializeComponent();
        }

        // The points selected by the user.
        private List<Point> Points = new List<Point>();

        // The tension for the curve.
        private float Tension = 0.5f;

        private void howto_spline_tension_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the points.
            foreach (Point point in Points)
                e.Graphics.FillEllipse(Brushes.Black,
                    point.X - 3, point.Y - 3, 5, 5);
            if (Points.Count < 2) return;

            // Draw the curve.
            e.Graphics.DrawCurve(Pens.Red, Points.ToArray(), Tension);
        }

        // Select a point.
        private void howto_spline_tension_Form1_MouseClick(object sender, MouseEventArgs e)
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

        // Change the tension.
        private void trkTension_Scroll(object sender, EventArgs e)
        {
            Tension = trkTension.Value / 10f;
            txtTension.Text = Tension.ToString("0.0");
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
            this.label1 = new System.Windows.Forms.Label();
            this.trkTension = new System.Windows.Forms.TrackBar();
            this.txtTension = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkTension)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tension:";
            // 
            // trkTension
            // 
            this.trkTension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trkTension.Location = new System.Drawing.Point(66, 27);
            this.trkTension.Maximum = 50;
            this.trkTension.Name = "trkTension";
            this.trkTension.Size = new System.Drawing.Size(155, 45);
            this.trkTension.TabIndex = 2;
            this.trkTension.Value = 5;
            this.trkTension.Scroll += new System.EventHandler(this.trkTension_Scroll);
            // 
            // txtTension
            // 
            this.txtTension.Location = new System.Drawing.Point(227, 27);
            this.txtTension.Name = "txtTension";
            this.txtTension.ReadOnly = true;
            this.txtTension.Size = new System.Drawing.Size(45, 20);
            this.txtTension.TabIndex = 3;
            this.txtTension.Text = "0,5";
            this.txtTension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_spline_tension_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtTension);
            this.Controls.Add(this.trkTension);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_spline_tension_Form1";
            this.Text = "howto_spline_tension";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_spline_tension_Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_spline_tension_Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkTension)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSplineNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkTension;
        private System.Windows.Forms.TextBox txtTension;
    }
}

