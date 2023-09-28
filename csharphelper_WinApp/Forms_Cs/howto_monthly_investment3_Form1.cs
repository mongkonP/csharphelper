using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_monthly_investment3_Form1:Form
  { 


        public howto_monthly_investment3_Form1()
        {
            InitializeComponent();
        }

        // The drawing transformation.
        private Matrix Transform, InverseTransform;

        // The data points.
        private List<PointF> Balance = new List<PointF>();
        private List<PointF> Contributions = new List<PointF>();

        // The X coordinate of the mouse position.
        private int MouseX = -1;

        // Display some initial data.
        private void howto_monthly_investment3_Form1_Load(object sender, EventArgs e)
        {
            PerformCalculations();
        }

        // Calculate the interest compounded monthly.
        private void btnGo_Click(object sender, EventArgs e)
        {
            PerformCalculations();
        }

        // Perform the calculations.
        private void PerformCalculations()
        {
            // Get the parameters.
            decimal monthly_contribution = decimal.Parse(
                txtMonthlyContribution.Text, NumberStyles.Any);
            int num_months = int.Parse(txtNumMonths.Text);
            decimal interest_rate = decimal.Parse(
                txtInterestRate.Text.Replace("%", "")) / 100;
            interest_rate /= 12;

            // Start at 0.
            Balance = new List<PointF>();
            Contributions = new List<PointF>();
            decimal contributions = 0;
            decimal interest = 0;
            decimal balance = 0;

            // Calculate.
            for (int i = 0; i <= num_months; i++)
            {
                // Save the contributions and balance.
                Contributions.Add(new PointF(i, (float)contributions));
                Balance.Add(new PointF(i, (float)balance));

                // Calculate the values for next month.
                contributions += monthly_contribution;
                decimal new_interest = balance * interest_rate;
                interest += new_interest;
                balance += monthly_contribution + new_interest;
            }

            // Add points to close the polygons.
            Contributions.Add(new PointF(num_months, 0));
            Balance.Add(new PointF(num_months, 0));

            // Redraw.
            picGraph.Refresh();
        }

        // Draw the graph.
        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picGraph.BackColor);
            if (Balance.Count < 2) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Scale to make the data fit.
            float xmin = -1;
            float xmax = Contributions.Count + 1;
            float ymax = Balance.Max(pt => pt.Y);
            float ymin = -ymax * 0.05f;
            RectangleF rect = new RectangleF(xmin, ymin, xmax - xmin, ymax - ymin);
            PointF[] pts =
            {
                new PointF(0, picGraph.ClientSize.Height),
                new PointF(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                new PointF(0, 0),
            };
            Transform = new Matrix(rect, pts);
            e.Graphics.Transform = Transform;
            InverseTransform = Transform.Clone();
            InverseTransform.Invert();

            // Draw the curves.
            e.Graphics.FillPolygon(Brushes.Pink, Balance.ToArray());
            e.Graphics.FillPolygon(Brushes.LightGreen, Contributions.ToArray());
            e.Graphics.DrawPolygon(Pens.Red, Balance.ToArray());
            e.Graphics.DrawPolygon(Pens.Green, Contributions.ToArray());

            // Draw the mouse's X position.
            if (MouseX >= 0)
            {
                e.Graphics.ResetTransform();
                e.Graphics.DrawLine(Pens.Blue,
                    MouseX, 0,
                    MouseX, picGraph.ClientSize.Height);
            }
        }

        // Display the nearest month's values.
        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (Transform == null) return;
            if (Balance.Count < 3) return;

            // Find the month closest to the mouse.
            PointF[] points = { new PointF(e.X, 0) };
            InverseTransform.TransformPoints(points);
            int month = (int)Math.Round(points[0].X);

            string tip = "";
            if ((month >= 0) && (month < Balance.Count - 1))
            {
                float interest = Balance[month].Y - Contributions[month].Y;
                tip = "Month: " + month.ToString() +
                    "\nContributions: " + Contributions[month].Y.ToString("C") +
                    "\nInterest: " + interest.ToString("C") +
                    "\nTotal: " + Balance[month].Y.ToString("C");
                MouseX = e.X;
            }
            else
            {
                MouseX = -1;
            }

            // Display the new tool tip.
            if (tip != tipAmount.GetToolTip(picGraph))
            {
                tipAmount.SetToolTip(picGraph, tip);
                Console.WriteLine("[" + tip + "]");
                picGraph.Refresh();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumMonths = new System.Windows.Forms.TextBox();
            this.tipAmount = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonthlyContribution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Pink;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(446, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Interest:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGreen;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(446, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Contributions:";
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 90);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(469, 284);
            this.picGraph.TabIndex = 35;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(248, 36);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 34;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(124, 64);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(78, 20);
            this.txtInterestRate.TabIndex = 33;
            this.txtInterestRate.Text = "7.00%";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Interest Rate:";
            // 
            // txtNumMonths
            // 
            this.txtNumMonths.Location = new System.Drawing.Point(124, 38);
            this.txtNumMonths.Name = "txtNumMonths";
            this.txtNumMonths.Size = new System.Drawing.Size(78, 20);
            this.txtNumMonths.TabIndex = 31;
            this.txtNumMonths.Text = "120";
            this.txtNumMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "# Months:";
            // 
            // txtMonthlyContribution
            // 
            this.txtMonthlyContribution.Location = new System.Drawing.Point(124, 12);
            this.txtMonthlyContribution.Name = "txtMonthlyContribution";
            this.txtMonthlyContribution.Size = new System.Drawing.Size(78, 20);
            this.txtMonthlyContribution.TabIndex = 29;
            this.txtMonthlyContribution.Text = "$100.00";
            this.txtMonthlyContribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Monthly Contribution:";
            // 
            // howto_monthly_investment3_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 386);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumMonths);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMonthlyContribution);
            this.Controls.Add(this.label1);
            this.Name = "howto_monthly_investment3_Form1";
            this.Text = "howto_monthly_investment3";
            this.Load += new System.EventHandler(this.howto_monthly_investment3_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumMonths;
        private System.Windows.Forms.ToolTip tipAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonthlyContribution;
        private System.Windows.Forms.Label label1;
    }
}

