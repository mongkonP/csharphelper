using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Diagnostics;

 

using howto_apollonius_problem2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_apollonius_problem2_Form1:Form
  { 


        public howto_apollonius_problem2_Form1()
        {
            InitializeComponent();
        }

        // The given circles.
        private List<Circle> GivenCircles = new List<Circle>();

        // The solutions.
        private Circle[] SolutionCircles;

        // CheckBoxes that control which circles are displayed.
        private CheckBox[] CheckBoxes;

        private Pen[] SolutionPens =
        {
            Pens.Red, Pens.Green, Pens.Blue, Pens.Orange,
            Pens.Lime, Pens.DeepSkyBlue, Pens.Pink, Pens.Purple,
        };

        // Solve an example problem and display the result.
        private void howto_apollonius_problem2_Form1_Load(object sender, EventArgs e)
        {
            CheckBoxes = new CheckBox[] { chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8 };
            DoubleBuffered = true;

            SolutionCircles = new Circle[] { };
        }

        // Draw the circles.
        private void howto_apollonius_problem2_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the solution circles.
            for (int i = 0; i < SolutionCircles.Length; i++)
            {
                if (CheckBoxes[i].Checked)
                {
                    Circle solution_circle = SolutionCircles[i];

                    if (chkFilled.Checked)
                    {
                        Color clr = Color.FromArgb(128,
                            SolutionPens[i].Color.R,
                            SolutionPens[i].Color.G,
                            SolutionPens[i].Color.B);
                        using (Brush circle_brush = new SolidBrush(clr))
                        {
                            solution_circle.Draw(e.Graphics, circle_brush);
                        }
                    }

                    solution_circle.Draw(e.Graphics, SolutionPens[i]);
                }
            }

            // Draw the given circles.
            foreach (Circle given_circle in GivenCircles)
            {
                Color clr = Color.FromArgb(128, 0, 0, 0);
                using (Brush brush = new SolidBrush(clr))
                {
                    given_circle.Draw(e.Graphics, brush);
                }
                given_circle.Draw(e.Graphics, Pens.Black);
            }

            // Draw the enw circle if any.
            if (NewCircle != null)
            {
                using (Pen dashed_pen = new Pen(Color.Red))
                {
                    dashed_pen.DashStyle = DashStyle.Dash;
                    NewCircle.Draw(e.Graphics, dashed_pen);
                }
            }
        }

        // Find the circles that touch each of the three input circles.
        private Circle[] FindApollonianCircles(List<Circle> given_circles)
        {
            // Make a list for results.
            List<Circle> solution_circles = new List<Circle>();

            // Loop over all of the signs.
            foreach (int s0 in new int[] { -1, 1 })
            {
                foreach (int s1 in new int[] { -1, 1 })
                {
                    foreach (int s2 in new int[] { -1, 1 })
                    {
                        Circle new_circle = FindApollonianCircle(
                            given_circles[0], given_circles[1], given_circles[2],
                            s0, s1, s2);
                        if (new_circle != null) solution_circles.Add(new_circle);
                    }
                }
            }

            // Return the results.
            return solution_circles.ToArray();
        }

        // Find a solution to Apollonius' problem.
        // For discussion and method, see:
        //    http://mathworld.wolfram.com/ApolloniusProblem.html
        //    http://en.wikipedia.org/wiki/Problem_of_Apollonius#Algebraic_solutions
        // For most of a Java code implementation, see:
        //    http://www.diku.dk/hjemmesider/ansatte/rfonseca/implementations/apollonius.html
        private Circle FindApollonianCircle(Circle c1, Circle c2, Circle c3, int s1, int s2, int s3)
        {
            // Make sure c2 doesn't have the same X or Y coordinate as the others.
            const float tiny = 0.0001f;
            if ((Math.Abs(c2.Center.X - c1.Center.X) < tiny) ||
                (Math.Abs(c2.Center.Y - c1.Center.Y) < tiny))
            {
                Circle temp_circle = c2;
                c2 = c3;
                c3 = temp_circle;
                int temp_s = s2;
                s2 = s3;
                s3 = temp_s;
            }
            if ((Math.Abs(c2.Center.X - c3.Center.X) < tiny) ||
                (Math.Abs(c2.Center.Y - c3.Center.Y) < tiny))
            {
                Circle temp_circle = c2;
                c2 = c1;
                c1 = temp_circle;
                int temp_s = s2;
                s2 = s1;
                s1 = temp_s;
            }
            Debug.Assert(
                (c2.Center.X != c1.Center.X) && (c2.Center.Y != c1.Center.Y) &&
                (c2.Center.X != c3.Center.X) && (c2.Center.Y != c3.Center.Y),
                "Cannot find points without matching coordinates.");

            float x1 = c1.Center.X;
            float y1 = c1.Center.Y;
            float r1 = c1.Radius;
            float x2 = c2.Center.X;
            float y2 = c2.Center.Y;
            float r2 = c2.Radius;
            float x3 = c3.Center.X;
            float y3 = c3.Center.Y;
            float r3 = c3.Radius;

            float v11 = 2 * x2 - 2 * x1;
            float v12 = 2 * y2 - 2 * y1;
            float v13 = x1 * x1 - x2 * x2 + y1 * y1 - y2 * y2 - r1 * r1 + r2 * r2;
            float v14 = 2 * s2 * r2 - 2 * s1 * r1;

            float v21 = 2 * x3 - 2 * x2;
            float v22 = 2 * y3 - 2 * y2;
            float v23 = x2 * x2 - x3 * x3 + y2 * y2 - y3 * y3 - r2 * r2 + r3 * r3;
            float v24 = 2 * s3 * r3 - 2 * s2 * r2;

            float w12 = v12 / v11;
            float w13 = v13 / v11;
            float w14 = v14 / v11;

            float w22 = v22 / v21 - w12;
            float w23 = v23 / v21 - w13;
            float w24 = v24 / v21 - w14;

            float P = -w23 / w22;
            float Q = w24 / w22;
            float M = -w12 * P - w13;
            float N = w14 - w12 * Q;

            float a = N * N + Q * Q - 1;
            float b = 2 * M * N - 2 * N * x1 + 2 * P * Q - 2 * Q * y1 + 2 * s1 * r1;
            float c = x1 * x1 + M * M - 2 * M * x1 + P * P + y1 * y1 - 2 * P * y1 - r1 * r1;

            // Find roots of a quadratic equation
            double[] solutions = QuadraticSolutions(a, b, c);
            if (solutions.Length < 1) return null;
            float rs = (float)solutions[0];
            float xs = M + N * rs;
            float ys = P + Q * rs;

            return new Circle(xs, ys, rs);
        }

        // Return solutions to a quadratic equation.
        private double[] QuadraticSolutions(double a, double b, double c)
        {
            const double tiny = 0.000001;
            double discriminant = b * b - 4 * a * c;

            // See if there are no real solutions.
            if (discriminant < 0)
            {
                return new double[] { };
            }

            // See if there is one solution.
            if (discriminant < tiny)
            {
                return new double[] { -b / (2 * a) };
            }

            // There are two solutions.
            return new double[]
            {
                (-b + Math.Sqrt(discriminant)) / (2 * a),
                (-b - Math.Sqrt(discriminant)) / (2 * a),
            };
        }

        // Refresh.
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (!IgnoreRefresh) Refresh();
        }

        // Check or uncheck all CheckBoxes.
        private bool IgnoreRefresh = false;
        private void btnAllOrNone_Click(object sender, EventArgs e)
        {
            IgnoreRefresh = true;

            Button btn = sender as Button;
            bool is_checked = (btn.Text == "All");
            foreach (CheckBox chk in CheckBoxes)
            {
                chk.Checked = is_checked;
            }

            IgnoreRefresh = false;
            Refresh();
        }

        // Let the user draw a circle.
        private Circle NewCircle = null;
        private void howto_apollonius_problem2_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (GivenCircles.Count == 3) GivenCircles = new List<Circle>();
            SolutionCircles = new Circle[] { };
            NewCircle = new Circle(e.X, e.Y, 1);
            Refresh();
        }
        private void howto_apollonius_problem2_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewCircle == null) return;

            float dx = e.Location.X - NewCircle.Center.X;
            float dy = e.Location.Y - NewCircle.Center.Y;
            NewCircle.Radius = (float)Math.Sqrt(dx * dx + dy * dy);
            Refresh();
        }
        private void howto_apollonius_problem2_Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (NewCircle == null) return;

            GivenCircles.Add(NewCircle);
            NewCircle = null;
            if (GivenCircles.Count == 3) SolutionCircles = FindApollonianCircles(GivenCircles);
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
            this.chkFilled = new System.Windows.Forms.CheckBox();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.chk8 = new System.Windows.Forms.CheckBox();
            this.chk7 = new System.Windows.Forms.CheckBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkFilled
            // 
            this.chkFilled.AutoSize = true;
            this.chkFilled.BackColor = System.Drawing.Color.Transparent;
            this.chkFilled.Checked = true;
            this.chkFilled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilled.Location = new System.Drawing.Point(9, 39);
            this.chkFilled.Name = "chkFilled";
            this.chkFilled.Size = new System.Drawing.Size(50, 17);
            this.chkFilled.TabIndex = 43;
            this.chkFilled.Text = "Filled";
            this.chkFilled.UseVisualStyleBackColor = false;
            this.chkFilled.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(373, 12);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(54, 23);
            this.btnNone.TabIndex = 42;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnAllOrNone_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(313, 12);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(54, 23);
            this.btnAll.TabIndex = 41;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAllOrNone_Click);
            // 
            // chk8
            // 
            this.chk8.AutoSize = true;
            this.chk8.BackColor = System.Drawing.Color.Transparent;
            this.chk8.Checked = true;
            this.chk8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk8.Location = new System.Drawing.Point(275, 16);
            this.chk8.Name = "chk8";
            this.chk8.Size = new System.Drawing.Size(32, 17);
            this.chk8.TabIndex = 40;
            this.chk8.Text = "8";
            this.chk8.UseVisualStyleBackColor = false;
            this.chk8.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chk7
            // 
            this.chk7.AutoSize = true;
            this.chk7.BackColor = System.Drawing.Color.Transparent;
            this.chk7.Checked = true;
            this.chk7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk7.Location = new System.Drawing.Point(237, 16);
            this.chk7.Name = "chk7";
            this.chk7.Size = new System.Drawing.Size(32, 17);
            this.chk7.TabIndex = 39;
            this.chk7.Text = "7";
            this.chk7.UseVisualStyleBackColor = false;
            this.chk7.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.BackColor = System.Drawing.Color.Transparent;
            this.chk6.Checked = true;
            this.chk6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk6.Location = new System.Drawing.Point(199, 16);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(32, 17);
            this.chk6.TabIndex = 38;
            this.chk6.Text = "6";
            this.chk6.UseVisualStyleBackColor = false;
            this.chk6.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.BackColor = System.Drawing.Color.Transparent;
            this.chk5.Checked = true;
            this.chk5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk5.Location = new System.Drawing.Point(161, 16);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(32, 17);
            this.chk5.TabIndex = 37;
            this.chk5.Text = "5";
            this.chk5.UseVisualStyleBackColor = false;
            this.chk5.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.BackColor = System.Drawing.Color.Transparent;
            this.chk4.Checked = true;
            this.chk4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk4.Location = new System.Drawing.Point(123, 16);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(32, 17);
            this.chk4.TabIndex = 36;
            this.chk4.Text = "4";
            this.chk4.UseVisualStyleBackColor = false;
            this.chk4.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.BackColor = System.Drawing.Color.Transparent;
            this.chk3.Checked = true;
            this.chk3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk3.Location = new System.Drawing.Point(85, 16);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(32, 17);
            this.chk3.TabIndex = 35;
            this.chk3.Text = "3";
            this.chk3.UseVisualStyleBackColor = false;
            this.chk3.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            this.chk2.Checked = true;
            this.chk2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2.Location = new System.Drawing.Point(47, 16);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(32, 17);
            this.chk2.TabIndex = 34;
            this.chk2.Text = "2";
            this.chk2.UseVisualStyleBackColor = false;
            this.chk2.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.Location = new System.Drawing.Point(9, 16);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(32, 17);
            this.chk1.TabIndex = 33;
            this.chk1.Text = "1";
            this.chk1.UseVisualStyleBackColor = false;
            this.chk1.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // howto_apollonius_problem2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 364);
            this.Controls.Add(this.chkFilled);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.chk8);
            this.Controls.Add(this.chk7);
            this.Controls.Add(this.chk6);
            this.Controls.Add(this.chk5);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk1);
            this.Name = "howto_apollonius_problem2_Form1";
            this.Text = "howto_apollonius_problem2";
            this.Load += new System.EventHandler(this.howto_apollonius_problem2_Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.howto_apollonius_problem2_Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_apollonius_problem2_Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_apollonius_problem2_Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_apollonius_problem2_Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFilled;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.CheckBox chk8;
        private System.Windows.Forms.CheckBox chk7;
        private System.Windows.Forms.CheckBox chk6;
        private System.Windows.Forms.CheckBox chk5;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk1;
    }
}

