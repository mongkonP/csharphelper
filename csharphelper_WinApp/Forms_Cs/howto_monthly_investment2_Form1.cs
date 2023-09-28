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
     public partial class howto_monthly_investment2_Form1:Form
  { 


        public howto_monthly_investment2_Form1()
        {
            InitializeComponent();
        }

        // The drawing transformation.
        private Matrix Transform;

        // The data points.
        private List<PointF> Contributions = new List<PointF>();
        private List<PointF> Interest = new List<PointF>();
        private List<PointF> Balance = new List<PointF>();

        // Display some initial data.
        private void howto_monthly_investment2_Form1_Load(object sender, EventArgs e)
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
            Contributions = new List<PointF>();
            Interest = new List<PointF>();
            Balance = new List<PointF>();
            decimal contributions = 0;
            decimal interest = 0;
            decimal balance = 0;

            // Calculate.
            for (int i = 0; i <= num_months; i++)
            {
                // Save the contributions, interest, and balance.
                Contributions.Add(new PointF(i, (float)contributions));
                Interest.Add(new PointF(i, (float)interest));
                Balance.Add(new PointF(i, (float)balance));

                // Calculate the values for next month.
                contributions += monthly_contribution;
                decimal new_interest = balance * interest_rate;
                interest += new_interest;
                balance += monthly_contribution + new_interest;
            }

            // Add points to close the polygons.
            Contributions.Add(new PointF(num_months, 0));
            Interest.Add(new PointF(num_months, 0));
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

            // Draw the curves.
            e.Graphics.FillPolygon(Brushes.LightGreen, Balance.ToArray());
            e.Graphics.FillPolygon(Brushes.LightBlue, Contributions.ToArray());
            e.Graphics.FillPolygon(Brushes.Pink, Interest.ToArray());
            e.Graphics.DrawPolygon(Pens.Green, Balance.ToArray());
            e.Graphics.DrawPolygon(Pens.Blue, Contributions.ToArray());
            e.Graphics.DrawPolygon(Pens.Red, Interest.ToArray());
        }

        // Display the nearest data point's values.
        private const float max_dx = 5;

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (Transform == null) return;
            if (Balance.Count < 3) return;

            // Find the data point closest to the mouse.
            string tip = "";
            if (tip == "") tip = GetDataTooltip(Balance, e.Location, "Balance");
            if (tip == "") tip = GetDataTooltip(Contributions, e.Location, "Contributions");
            if (tip == "") tip = GetDataTooltip(Interest, e.Location, "Interest");

            // Display the new tool tip.
            if (tip != tipAmount.GetToolTip(picGraph))
            {
                tipAmount.SetToolTip(picGraph, tip);
                Console.WriteLine("[" + tip + "]");
            }
        }

        // Find a tooltip for the given data points.
        private string GetDataTooltip(List<PointF> point_list, Point location, string type_name)
        {
            const float max_dist = 6;

            // Convert the points to screen coordinates.
            PointF[] points = point_list.ToArray();
            Transform.TransformPoints(points);

            // See if any of the points is close to the location,
            // skipping the last point that was used to close the polygon.
            for (int i = 0; i < point_list.Count - 1; i++)
            {
                // See if this point is close enough to the mouse.
                float dist =
                    Math.Abs(points[i].X - location.X) +
                    Math.Abs(points[i].Y - location.Y);
                if (dist < max_dist)
                {
                    return "Month: " + point_list[i].X.ToString() +
                        "\n" + type_name + ": " + point_list[i].Y.ToString("C");
                }
            }

            return "";
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
            this.tipAmount = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumMonths = new System.Windows.Forms.TextBox();
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
            this.label8.Location = new System.Drawing.Point(446, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Interest:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(446, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Contributions:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGreen;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(446, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Balance:";
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
            this.picGraph.TabIndex = 21;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(248, 36);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 20;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(124, 64);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(78, 20);
            this.txtInterestRate.TabIndex = 19;
            this.txtInterestRate.Text = "7.00%";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Interest Rate:";
            // 
            // txtNumMonths
            // 
            this.txtNumMonths.Location = new System.Drawing.Point(124, 38);
            this.txtNumMonths.Name = "txtNumMonths";
            this.txtNumMonths.Size = new System.Drawing.Size(78, 20);
            this.txtNumMonths.TabIndex = 17;
            this.txtNumMonths.Text = "120";
            this.txtNumMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "# Months:";
            // 
            // txtMonthlyContribution
            // 
            this.txtMonthlyContribution.Location = new System.Drawing.Point(124, 12);
            this.txtMonthlyContribution.Name = "txtMonthlyContribution";
            this.txtMonthlyContribution.Size = new System.Drawing.Size(78, 20);
            this.txtMonthlyContribution.TabIndex = 15;
            this.txtMonthlyContribution.Text = "$100.00";
            this.txtMonthlyContribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Monthly Contribution:";
            // 
            // howto_monthly_investment2_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 386);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumMonths);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMonthlyContribution);
            this.Controls.Add(this.label1);
            this.Name = "howto_monthly_investment2_Form1";
            this.Text = "howto_monthly_investment2";
            this.Load += new System.EventHandler(this.howto_monthly_investment2_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip tipAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumMonths;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonthlyContribution;
        private System.Windows.Forms.Label label1;
    }
}

