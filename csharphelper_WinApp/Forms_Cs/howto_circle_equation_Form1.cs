using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_circle_equation_Form1:Form
  { 


        public howto_circle_equation_Form1()
        {
            InitializeComponent();
        }

        // A rectangle that define the circle.
        private bool GotCircle = false;
        private Rectangle Circle;

        // Used while drawing circles.
        private bool DrawingCircle = false;
        private int StartX, StartY, EndX, EndY;

        // The circle's equation.
        private float Dx, Dy, R;

        private void howto_circle_equation_Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        // Draw the circle.
        private void howto_circle_equation_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the circle if we have one.
            if (GotCircle)
            {
                // Fill the circle.
                e.Graphics.FillEllipse(Brushes.LightBlue, Circle);

                // Plot the circle's equation.
                List<PointF> points = new List<PointF>();
                for (float x = Dx - R; x <= Dx + R; x++)
                {
                    float radicand = x - Dx;
                    radicand = R * R - radicand * radicand;
                    if (radicand >= 0f)
                    {
                        points.Add(new PointF(
                            x, (float)(Dy + Math.Sqrt(radicand))));
                    }
                }
                for (float x = Dx + R; x >= Dx - R; x--)
                {
                    float radicand = x - Dx;
                    radicand = R * R - radicand * radicand;
                    if (radicand > 0f)
                    {
                        points.Add(new PointF(
                            x, (float)(Dy - Math.Sqrt(radicand))));
                    }
                }
                e.Graphics.DrawPolygon(Pens.Blue, points.ToArray());
            }

            // Draw the new circle if we are drawing one.
            if (DrawingCircle)
            {
                // Make it a circle.
                int diameter = Math.Max(
                    Math.Abs(StartX - EndX), Math.Abs(StartY - EndY));
                e.Graphics.DrawEllipse(Pens.Red,
                    Math.Min(StartX, EndX), Math.Min(StartY, EndY),
                    diameter, diameter);
            }
        }

        // Let the user click and drag to select a circle.
        private void howto_circle_equation_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DrawingCircle = true;
            GotCircle = false;

            StartX = e.X;
            StartY = e.Y;
            EndX = e.X;
            EndY = e.Y;
        }

        private void howto_circle_equation_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing if we are not drawing.
            if (!DrawingCircle) return;

            EndX = e.X;
            EndY = e.Y;

            // Redraw.
            this.Refresh();
        }

        private void howto_circle_equation_Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Do nothing if we are not drawing.
            if (!DrawingCircle) return;

            EndX = e.X;
            EndY = e.Y;

            // Make sure the circle has non-zero width and height.
            if ((StartX != EndX) && (StartY != EndY))
            {
                // Make it a circle.
                int circle_radius = Math.Max(
                    Math.Abs(StartX - EndX), Math.Abs(StartY - EndY));
                Circle = new Rectangle(
                    Math.Min(StartX, EndX), Math.Min(StartY, EndY),
                    circle_radius, circle_radius);
                GotCircle = true;

                // Find and display the circle's formula.
                GetCircleFormula(Circle, out Dx, out Dy, out R);

                lblX.Text = "(x - " + Dx.ToString("0.00") + ")";
                lblY.Text = "(y - " + Dy.ToString("0.00") + ")";
                lblR.Text = R.ToString("0.00");
                lblSq1.Left = lblX.Right;
                lblPlus.Left = lblSq1.Right;
                lblY.Left = lblPlus.Right;
                lblSq2.Left = lblY.Right;
                lblEqual.Left = lblSq2.Right;
                lblR.Left = lblEqual.Right;
                lblSq3.Left = lblR.Right;
            }
            else
            {
                lblX.Text = "";
                lblY.Text = "";
            }

            // We are no longer drawing a new circle.
            DrawingCircle = false;

            // Redraw.
            this.Refresh();
        }

        // Get the equation for this circle.
        private void GetCircleFormula(RectangleF rect, out float dx, out float dy, out float r)
        {
            dx = rect.X + rect.Width / 2f;
            dy = rect.Y + rect.Height / 2f;
            r = rect.Width / 2f;
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
            this.lblEqual = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblPlus = new System.Windows.Forms.Label();
            this.lblSq2 = new System.Windows.Forms.Label();
            this.lblSq1 = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblSq3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEqual
            // 
            this.lblEqual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEqual.AutoSize = true;
            this.lblEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEqual.Location = new System.Drawing.Point(226, 239);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(13, 13);
            this.lblEqual.TabIndex = 15;
            this.lblEqual.Text = "=";
            this.lblEqual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(124, 240);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 13);
            this.lblY.TabIndex = 12;
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX
            // 
            this.lblX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(12, 240);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 13);
            this.lblX.TabIndex = 10;
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlus
            // 
            this.lblPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlus.AutoSize = true;
            this.lblPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus.Location = new System.Drawing.Point(112, 239);
            this.lblPlus.Name = "lblPlus";
            this.lblPlus.Size = new System.Drawing.Size(13, 13);
            this.lblPlus.TabIndex = 14;
            this.lblPlus.Text = "+";
            this.lblPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSq2
            // 
            this.lblSq2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSq2.AutoSize = true;
            this.lblSq2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSq2.Location = new System.Drawing.Point(221, 229);
            this.lblSq2.Name = "lblSq2";
            this.lblSq2.Size = new System.Drawing.Size(13, 13);
            this.lblSq2.TabIndex = 17;
            this.lblSq2.Text = "2";
            this.lblSq2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSq1
            // 
            this.lblSq1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSq1.AutoSize = true;
            this.lblSq1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSq1.Location = new System.Drawing.Point(109, 229);
            this.lblSq1.Name = "lblSq1";
            this.lblSq1.Size = new System.Drawing.Size(13, 13);
            this.lblSq1.TabIndex = 16;
            this.lblSq1.Text = "2";
            this.lblSq1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblR
            // 
            this.lblR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(241, 240);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(0, 13);
            this.lblR.TabIndex = 18;
            this.lblR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSq3
            // 
            this.lblSq3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSq3.AutoSize = true;
            this.lblSq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSq3.Location = new System.Drawing.Point(338, 229);
            this.lblSq3.Name = "lblSq3";
            this.lblSq3.Size = new System.Drawing.Size(13, 13);
            this.lblSq3.TabIndex = 19;
            this.lblSq3.Text = "2";
            this.lblSq3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_circle_equation_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 264);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.lblSq3);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblSq2);
            this.Controls.Add(this.lblSq1);
            this.Controls.Add(this.lblEqual);
            this.Controls.Add(this.lblPlus);
            this.Name = "howto_circle_equation_Form1";
            this.Text = "howto_circle_equation";
            this.Load += new System.EventHandler(this.howto_circle_equation_Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.howto_circle_equation_Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_circle_equation_Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_circle_equation_Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_circle_equation_Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblPlus;
        private System.Windows.Forms.Label lblSq2;
        private System.Windows.Forms.Label lblSq1;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblSq3;
    }
}

