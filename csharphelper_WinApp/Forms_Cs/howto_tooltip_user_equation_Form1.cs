using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.CodeDom.Compiler;
using System.Reflection;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_tooltip_user_equation_Form1:Form
  { 


        public howto_tooltip_user_equation_Form1()
        {
            InitializeComponent();
        }

        // Draw the graph.
        private void howto_tooltip_user_equation_Form1_Load(object sender, EventArgs e)
        {
            MakeGraph();
        }
        private void howto_tooltip_user_equation_Form1_Resize(object sender, EventArgs e)
        {
            MakeGraph();
        }
        private void btnGraph_Click(object sender, EventArgs e)
        {
            MakeGraph();
        }

        // The transformation and inverse.
        private Matrix Transform = null, Inverse = null;

        // The compiled function.
        private MethodInfo Function = null;

        // Make the graph.
        private void MakeGraph()
        {
            // Get the bounds.
            float xmin = float.Parse(txtXmin.Text);
            float xmax = float.Parse(txtXmax.Text);
            float ymin = float.Parse(txtYmin.Text);
            float ymax = float.Parse(txtYmax.Text);

            // Make the Bitmap.
            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Transform to map the graph bounds to the Bitmap.
                RectangleF rect = new RectangleF(xmin, ymin, xmax - xmin, ymax - ymin);
                PointF[] pts = 
                {
                    new PointF(0, hgt),
                    new PointF(wid, hgt),
                    new PointF(0, 0),
                };
                gr.Transform = new Matrix(rect, pts);

                // Draw the graph.
                using (Pen graph_pen = new Pen(Color.Blue, 0))
                {
                    // Draw the axes.
                    gr.DrawLine(graph_pen, xmin, 0, xmax, 0);
                    gr.DrawLine(graph_pen, 0, ymin, 0, ymax);
                    graph_pen.Color = Color.Red;

                    // See how big 1 pixel is horizontally.
                    Transform = gr.Transform;
                    Inverse = gr.Transform;
                    Inverse.Invert();
                    PointF[] pixel_pts =
                    {
                        new PointF(0, 0),
                        new PointF(1, 0)
                    };
                    Inverse.TransformPoints(pixel_pts);
                    float dx = pixel_pts[1].X - pixel_pts[0].X;
                    dx /= 2;

                    // Compile the function.
                    Function = null;
                    try
                    {
                        Function = CompileFunction(txtEquation.Text);
                    }
                    catch (Exception ex)
                    {
                        // If we couldn't compile the code, give up.
                        Function = null;
                        MessageBox.Show(ex.Message, "Expression Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Loop over x values to generate points.
                    List<PointF> points = new List<PointF>();
                    for (float x = xmin; x <= xmax; x += dx)
                    {
                        bool valid_point = false;
                        try
                        {
                            // Get the next point.
                            float y = F(Function, x);

                            // If the slope is reasonable, this is a valid point.
                            if (points.Count == 0) valid_point = true;
                            else
                            {
                                float dy = y - points[points.Count - 1].Y;
                                if (Math.Abs(dy / dx) < 1000) valid_point = true;
                            }
                            if (valid_point)
                                points.Add(new PointF(x, y));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error evaluating function.\n" + ex.Message,
                                "Error Evaluating Function", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                        // If the new point is invalid, draw
                        // the points in the latest batch.
                        if (!valid_point)
                        {
                            if (points.Count > 1) gr.DrawLines(graph_pen, points.ToArray());
                            points.Clear();
                        }
                    }

                    // Draw the last batch of points.
                    if (points.Count > 1) gr.DrawLines(graph_pen, points.ToArray());
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // The function to graph.
        private float F(MethodInfo function, float x)
        {
            double result = (double)function.Invoke(null, new object[] { x });
            return (float)result;
        }

        // Compile the function and return a MethodInfo to execute it.
        private MethodInfo CompileFunction(string equation_text)
        {
            // Turn the equation into a function.
            string function_text =
                "using System;" +
                "public static class Evaluator" +
                "{" +
                "    public static double Evaluate(double x)" +
                "    {" +
                "        return " + equation_text + ";" +
                "    }" +
                "}";

            // Compile the function.
            CodeDomProvider code_provider = CodeDomProvider.CreateProvider("C#");

            // Generate a non-executable assembly in memory.
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            // Compile the code.
            CompilerResults results =
                code_provider.CompileAssemblyFromSource(parameters, function_text);

            // If there are errors, display them.
            if (results.Errors.Count > 0)
            {
                string msg = "Error compiling the expression.";
                foreach (CompilerError compiler_error in results.Errors)
                {
                    msg += "\n" + compiler_error.ErrorText;
                }
                throw new InvalidProgramException(msg);
            }
            else
            {
                // Get the Evaluator class type.
                Type evaluator_type = results.CompiledAssembly.GetType("Evaluator");

                // Get a MethodInfo object describing the Evaluate method.
                return evaluator_type.GetMethod("Evaluate");
            }
        }

        // If the mouse is over the curve,
        // display a tooltip showing the curve's value.
        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the tooltip that we should display.
            string tooltip = GetGraphToolTip(e.Location);

            // See if the tooltip has changed.
            string old_tooltip = tipPoint.GetToolTip(picGraph);
            if (old_tooltip == tooltip) return;

            // Display the new tooltip.
            tipPoint.SetToolTip(picGraph, tooltip);
        }

        // Get the tooltip for the point in device coordinates.
        // Return null if the point isn't on the curve.
        private string GetGraphToolTip(Point point)
        {
            if (Function == null) return null;

            // Convert the mouse's location into world coordinates.
            PointF[] world_points = { point };
            Inverse.TransformPoints(world_points);

            // Find the Y coordinate in device coordinates.
            float x = world_points[0].X;
            float y = F(Function, x);
            PointF[] device_points = { new PointF(x, y) };
            Transform.TransformPoints(device_points);

            // See if the mouse's position is within
            // five pixels of this point's location.
            if (Math.Abs(point.Y - device_points[0].Y) > 10) return null;

            // Compose the tooltip.
            return "(" + x.ToString("0.00") +
                ", " + y.ToString("0.00") + ")";
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
            this.btnGraph = new System.Windows.Forms.Button();
            this.txtYmax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYmin = new System.Windows.Forms.TextBox();
            this.txtXmax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXmin = new System.Windows.Forms.TextBox();
            this.txtEquation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.tipPoint = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(234, 50);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 30;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // txtYmax
            // 
            this.txtYmax.Location = new System.Drawing.Point(131, 64);
            this.txtYmax.Name = "txtYmax";
            this.txtYmax.Size = new System.Drawing.Size(63, 20);
            this.txtYmax.TabIndex = 29;
            this.txtYmax.Text = "12";
            this.txtYmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "<= y <=";
            // 
            // txtYmin
            // 
            this.txtYmin.Location = new System.Drawing.Point(14, 64);
            this.txtYmin.Name = "txtYmin";
            this.txtYmin.Size = new System.Drawing.Size(63, 20);
            this.txtYmin.TabIndex = 27;
            this.txtYmin.Text = "-5";
            this.txtYmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtXmax
            // 
            this.txtXmax.Location = new System.Drawing.Point(131, 38);
            this.txtXmax.Name = "txtXmax";
            this.txtXmax.Size = new System.Drawing.Size(63, 20);
            this.txtXmax.TabIndex = 26;
            this.txtXmax.Text = "20";
            this.txtXmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "<= x <=";
            // 
            // txtXmin
            // 
            this.txtXmin.Location = new System.Drawing.Point(14, 38);
            this.txtXmin.Name = "txtXmin";
            this.txtXmin.Size = new System.Drawing.Size(63, 20);
            this.txtXmin.TabIndex = 24;
            this.txtXmin.Text = "-20";
            this.txtXmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEquation
            // 
            this.txtEquation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquation.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquation.Location = new System.Drawing.Point(72, 12);
            this.txtEquation.Name = "txtEquation";
            this.txtEquation.Size = new System.Drawing.Size(302, 20);
            this.txtEquation.TabIndex = 23;
            this.txtEquation.Text = "10 * Math.Sin(x) / x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Equation:";
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(14, 90);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(360, 259);
            this.picGraph.TabIndex = 21;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            // 
            // howto_tooltip_user_equation_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.txtYmax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYmin);
            this.Controls.Add(this.txtXmax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtXmin);
            this.Controls.Add(this.txtEquation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_tooltip_user_equation_Form1";
            this.Text = "howto_tooltip_user_equation";
            this.Load += new System.EventHandler(this.howto_tooltip_user_equation_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_tooltip_user_equation_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.TextBox txtYmax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYmin;
        private System.Windows.Forms.TextBox txtXmax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXmin;
        private System.Windows.Forms.TextBox txtEquation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.ToolTip tipPoint;
    }
}

