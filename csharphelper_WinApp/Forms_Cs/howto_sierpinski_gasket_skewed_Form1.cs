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
     public partial class howto_sierpinski_gasket_skewed_Form1:Form
  { 


        public howto_sierpinski_gasket_skewed_Form1()
        {
            InitializeComponent();
        }

        // The selected points.
        private List<Point> Corners = new List<Point>();
        private Point LastPoint ;
        private int RADIUS = 2;

        private void howto_sierpinski_gasket_skewed_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tmrDraw.Enabled)
            {
                // Stop running.
                tmrDraw.Enabled = false;
                Corners = new List<Point>();
            }
            else
            {
                // Left or right button?
                if (e.Button == MouseButtons.Right)
                {
                    // Start running.
                    if (Corners.Count < 2)
                    {
                        // We need more points.
                        MessageBox.Show(
                            "Left-click at least two points before right-clicking.",
                            "Need More Points", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Start at the first point.
                        LastPoint = Corners[0];

                        // Start.
                        tmrDraw.Enabled = true;
                    }
                }
                else // Left button.
                {
                    // Save the point.
                    Corners.Add(new Point(e.X, e.Y));

                    // Draw the new point.
                    using (Graphics gr = this.CreateGraphics())
                    {
                        if (Corners.Count == 1) gr.Clear(this.BackColor);
                        gr.DrawEllipse(Pens.Blue,
                            e.X - RADIUS, e.Y - RADIUS,
                            2 * RADIUS, 2 * RADIUS);
                    }
                }
            }
        }

        // Draw 1,000 points.
        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            // Draw points.
            Random rand = new Random();
            using (Graphics gr = this.CreateGraphics())
            {
                // Draw the corners.
                foreach (PointF pt in Corners)
                {
                    gr.FillEllipse(Brushes.White, pt.X - RADIUS, pt.Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
                    gr.DrawEllipse(Pens.Blue, pt.X - RADIUS, pt.Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
                }

                // Draw 1000 points.
                for (int i = 1; i <= 1000; i++)
                {
                    int j = rand.Next(0, Corners.Count);
                    LastPoint = new Point(
                        (LastPoint.X + Corners[j].X) / 2,
                        (LastPoint.Y + Corners[j].Y) / 2);
                    gr.DrawLine(Pens.Blue, LastPoint.X, LastPoint.Y,
                        LastPoint.X + 1, LastPoint.Y + 1);
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
            this.components = new System.ComponentModel.Container();
            this.tmrDraw = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrDraw
            // 
            this.tmrDraw.Tick += new System.EventHandler(this.tmrDraw_Tick);
            // 
            // howto_sierpinski_gasket_skewed_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 357);
            this.Name = "howto_sierpinski_gasket_skewed_Form1";
            this.Text = "howto_sierpinski_gasket_skewed";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_sierpinski_gasket_skewed_Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrDraw;
    }
}

