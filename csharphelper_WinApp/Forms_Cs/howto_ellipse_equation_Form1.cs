using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_ellipse_equation_Form1:Form
  { 


        public howto_ellipse_equation_Form1()
        {
            InitializeComponent();
        }

        // A rectangle that define the ellipse.
        private bool GotEllipse = false;
        private Rectangle Ellipse;

        // Used while drawing ellipses.
        private bool DrawingEllipse = false;
        private int StartX, StartY, EndX, EndY;

        // Ellipse equations.
        private float Dx, Dy, Rx, Ry;
        private float A, B, C, D, E, F;

        private void howto_ellipse_equation_Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        // Draw the ellipses.
        private void howto_ellipse_equation_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the first ellipse.
            if (GotEllipse)
            {
                // Fill the ellipse.
                e.Graphics.FillEllipse(Brushes.LightBlue, Ellipse);

                // Plot the ellipse's equation.
                List<PointF> points = new List<PointF>();
                for (float x = Dx - Rx; x <= Dx + Rx; x++)
                {
                    float radicand = (x - Dx) / Rx;
                    radicand = 1 - radicand * radicand;
                    if (radicand >= 0f)
                    {
                        points.Add(new PointF(
                            x, (float)(Dy + Ry * Math.Sqrt(radicand))));
                    }
                }
                for (float x = Dx + Rx; x >= Dx - Rx; x--)
                {
                    float radicand = (x - Dx) / Rx;
                    radicand = 1 - radicand * radicand;
                    if (radicand > 0f)
                    {
                        points.Add(new PointF(
                            x, (float)(Dy - Ry * Math.Sqrt(radicand))));
                    }
                }
                e.Graphics.DrawPolygon(Pens.Blue, points.ToArray());
            }

            // Draw the new ellipse if we are drawing one.
            if (DrawingEllipse)
            {
                e.Graphics.DrawEllipse(Pens.Red,
                    Math.Min(StartX, EndX), Math.Min(StartY, EndY),
                    Math.Abs(StartX - EndX), Math.Abs(StartY - EndY));
            }

            // Draw lines between the parts of the fractions.
            e.Graphics.DrawLine(Pens.Black,
                lblXDenominator.Left, lblXDenominator.Top - 1,
                lblXDenominator.Right, lblXDenominator.Top - 1);
            e.Graphics.DrawLine(Pens.Black,
                lblYDenominator.Left, lblYDenominator.Top - 1,
                lblYDenominator.Right, lblYDenominator.Top - 1);
        }

        // Let the user click and drag to select ellipses.
        private void howto_ellipse_equation_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DrawingEllipse = true;
            GotEllipse = false;

            StartX = e.X;
            StartY = e.Y;
            EndX = e.X;
            EndY = e.Y;
        }

        private void howto_ellipse_equation_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing if we are not drawing.
            if (!DrawingEllipse) return;

            EndX = e.X;
            EndY = e.Y;

            // Redraw.
            this.Refresh();
        }

        private void howto_ellipse_equation_Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Do nothing if we are not drawing.
            if (!DrawingEllipse) return;

            EndX = e.X;
            EndY = e.Y;

            // Make sure the ellipse has non-zero width and height.
            lstParameters.Items.Clear();
            if ((StartX != EndX) && (StartY != EndY))
            {
                Ellipse = new Rectangle(
                    Math.Min(StartX, EndX), Math.Min(StartY, EndY),
                    Math.Abs(StartX - EndX), Math.Abs(StartY - EndY));
                GotEllipse = true;

                // Find and display the ellipse's formula.
                GetEllipseFormula(Ellipse, out Dx, out Dy, out Rx, out Ry,
                    out A, out B, out C, out D, out E, out F);

                lblXNumerator.Text = "x - " + Dx.ToString();
                lblXDenominator.Text = Rx.ToString();
                lblYNumerator.Text = "y - " + Dy.ToString();
                lblYDenominator.Text = Ry.ToString();

                lstParameters.Items.Add("A = " + A.ToString());
                lstParameters.Items.Add("B = " + B.ToString());
                lstParameters.Items.Add("C = " + C.ToString());
                lstParameters.Items.Add("D = " + D.ToString());
                lstParameters.Items.Add("E = " + E.ToString());
                lstParameters.Items.Add("F = " + F.ToString());
            }
            else
            {
                lblXNumerator.Text = "";
                lblXDenominator.Text = "";
                lblYNumerator.Text = "";
                lblYDenominator.Text = "";
            }

            // We are no longer drawing a new ellipse.
            DrawingEllipse = false;

            // Redraw.
            this.Refresh();
        }

        // Get the equation for this ellipse.
        private void GetEllipseFormula(RectangleF rect,
            out float Dx, out float Dy, out float Rx, out float Ry,
            out float A, out float B, out float C, out float D,
            out float E, out float F)
        {
            Dx = rect.X + rect.Width / 2f;
            Dy = rect.Y + rect.Height / 2f;
            Rx = rect.Width / 2f;
            Ry = rect.Height / 2f;

            A = 1f / Rx / Rx;
            B = 1f / Ry / Ry;
            C = 0;
            D = -2f * Dx / Rx / Rx;
            E = -2f * Dy / Ry / Ry;
            F = Dx * Dx / Rx / Rx + Dy * Dy / Ry / Ry - 1;

            // Verify the parameters.
            Console.WriteLine();
            float xmid = rect.Left + rect.Width / 2f;
            float ymid = rect.Top + rect.Height / 2f;
            VerifyEquation(A, B, C, D, E, F, rect.Left, ymid);
            VerifyEquation(A, B, C, D, E, F, rect.Right, ymid);
            VerifyEquation(A, B, C, D, E, F, xmid, rect.Top);
            VerifyEquation(A, B, C, D, E, F, xmid, rect.Bottom);
        }

        // Verify that the equation gives a value
        // close to 0 for the given point (x, y).
        private void VerifyEquation(float A, float B, float C, float D, float E, float F, float x, float y)
        {
            float total = A * x * x + B * y * y + C * x * y + D * x + E * y + F;
            Console.WriteLine("VerifyEquation (" + x + ", " + y + ") = " + total);
            Debug.Assert(Math.Abs(total) < 0.001f);
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
            this.lblXNumerator = new System.Windows.Forms.Label();
            this.lblXDenominator = new System.Windows.Forms.Label();
            this.lblYNumerator = new System.Windows.Forms.Label();
            this.lblYDenominator = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstParameters = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblXNumerator
            // 
            this.lblXNumerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblXNumerator.Location = new System.Drawing.Point(8, 220);
            this.lblXNumerator.Name = "lblXNumerator";
            this.lblXNumerator.Size = new System.Drawing.Size(100, 15);
            this.lblXNumerator.TabIndex = 0;
            this.lblXNumerator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblXDenominator
            // 
            this.lblXDenominator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblXDenominator.Location = new System.Drawing.Point(8, 236);
            this.lblXDenominator.Name = "lblXDenominator";
            this.lblXDenominator.Size = new System.Drawing.Size(100, 15);
            this.lblXDenominator.TabIndex = 1;
            this.lblXDenominator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYNumerator
            // 
            this.lblYNumerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYNumerator.Location = new System.Drawing.Point(120, 220);
            this.lblYNumerator.Name = "lblYNumerator";
            this.lblYNumerator.Size = new System.Drawing.Size(100, 15);
            this.lblYNumerator.TabIndex = 3;
            this.lblYNumerator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYDenominator
            // 
            this.lblYDenominator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblYDenominator.Location = new System.Drawing.Point(120, 236);
            this.lblYDenominator.Name = "lblYDenominator";
            this.lblYDenominator.Size = new System.Drawing.Size(100, 15);
            this.lblYDenominator.TabIndex = 4;
            this.lblYDenominator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(108, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "+";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "= 1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstParameters
            // 
            this.lstParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstParameters.FormattingEnabled = true;
            this.lstParameters.Items.AddRange(new object[] {
            "A =",
            "B =",
            "C =",
            "D =",
            "E =",
            "F ="});
            this.lstParameters.Location = new System.Drawing.Point(285, 169);
            this.lstParameters.Name = "lstParameters";
            this.lstParameters.Size = new System.Drawing.Size(120, 82);
            this.lstParameters.TabIndex = 10;
            // 
            // howto_ellipse_equation_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 264);
            this.Controls.Add(this.lstParameters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblYNumerator);
            this.Controls.Add(this.lblYDenominator);
            this.Controls.Add(this.lblXNumerator);
            this.Controls.Add(this.lblXDenominator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "howto_ellipse_equation_Form1";
            this.Text = "howto_ellipse_equation";
            this.Load += new System.EventHandler(this.howto_ellipse_equation_Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.howto_ellipse_equation_Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_ellipse_equation_Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_ellipse_equation_Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_ellipse_equation_Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXNumerator;
        private System.Windows.Forms.Label lblXDenominator;
        private System.Windows.Forms.Label lblYNumerator;
        private System.Windows.Forms.Label lblYDenominator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstParameters;
    }
}

