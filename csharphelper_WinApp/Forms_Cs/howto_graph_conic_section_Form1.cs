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
     public partial class howto_graph_conic_section_Form1:Form
  { 


        public howto_graph_conic_section_Form1()
        {
            InitializeComponent();
        }

        private void howto_graph_conic_section_Form1_Load(object sender, EventArgs e)
        {
            // A sample hyperbola.
            txtA.Text = "-0.002936807";
            txtB.Text = "-0.001556237";
            txtC.Text = "0.008451099";
            txtD.Text = "0.9999999";
            txtE.Text = "-1.415946";
            txtF.Text = "-0.3586201";
        }

        // Draw the graph.
        private void btnGraph_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Draw the graph.
        private void DrawGraph()
        {
            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picGraph.BackColor);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Get the parameters.
                float A, B, C, D, E, F;
                try
                {
                    A = float.Parse(txtA.Text);
                    B = float.Parse(txtB.Text);
                    C = float.Parse(txtC.Text);
                    D = float.Parse(txtD.Text);
                    E = float.Parse(txtE.Text);
                    F = float.Parse(txtF.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading parameters.\n" + ex.Message);
                    return;
                }

                DrawConicSection(gr, A, B, C, D, E, F);
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw the conic section.
        private void DrawConicSection(Graphics gr,
            float A, float B, float C, float D, float E, float F)
        {
            // Get the X coordinate bounds.
            float xmin = 0;
            float xmax = xmin + picGraph.ClientSize.Width;

            // Find the smallest X coordinate with a real value.
            for (float x = xmin; x < xmax; x++)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (IsNumber(y))
                {
                    xmin = x;
                    break;
                }
            }

            // Find the largest X coordinate with a real value.
            for (float x = xmax; x > xmin; x--)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (IsNumber(y))
                {
                    xmax = x;
                    break;
                }
            }

            // Get points for the negative root on the left.
            List<PointF> ln_points = new List<PointF>();
            float xmid1 = xmax;
            for (float x = xmin; x < xmax; x++)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (!IsNumber(y))
                {
                    xmid1 = x - 1;
                    break;
                }
                ln_points.Add(new PointF(x, y));
            }

            // Get points for the positive root on the left.
            List<PointF> lp_points = new List<PointF>();
            for (float x = xmid1; x >= xmin; x--)
            {
                float y = G1(x, A, B, C, D, E, F, +1f);
                if (IsNumber(y)) lp_points.Add(new PointF(x, y));
            }

            // Make the curves on the right if needed.
            List<PointF> rp_points = new List<PointF>();
            List<PointF> rn_points = new List<PointF>();
            float xmid2 = xmax;
            if (xmid1 < xmax)
            {
                // Get points for the positive root on the right.
                for (float x = xmax; x > xmid1; x--)
                {
                    float y = G1(x, A, B, C, D, E, F, +1f);
                    if (!IsNumber(y))
                    {
                        xmid2 = x + 1;
                        break;
                    }
                    rp_points.Add(new PointF(x, y));
                }

                // Get points for the negative root on the right.
                for (float x = xmid2; x <= xmax; x++)
                {
                    float y = G1(x, A, B, C, D, E, F, -1f);
                    if (IsNumber(y)) rn_points.Add(new PointF(x, y));
                }
            }

            // Connect curves if appropriate.
            // Connect the left curves on the left.
            if (xmin > 0) lp_points.Add(ln_points[0]);

            // Connect the left curves on the right.
            if (xmid1 < picGraph.ClientSize.Width) ln_points.Add(lp_points[0]);

            // Make sure we have the right curves.
            if (rp_points.Count > 0)
            {
                // Connect the right curves on the left.
                rp_points.Add(rn_points[0]);

                // Connect the right curves on the right.
                if (xmax < picGraph.ClientSize.Width) rn_points.Add(rp_points[0]);
            }

            // Draw the curves.
            using (Pen thick_pen = new Pen(Color.Red, 2))
            {
                thick_pen.Color = Color.Red;
                if (ln_points.Count > 1)
                    gr.DrawLines(thick_pen, ln_points.ToArray());

                thick_pen.Color = Color.Green;
                if (lp_points.Count > 1)
                    gr.DrawLines(thick_pen, lp_points.ToArray());

                thick_pen.Color = Color.Blue;
                if (rp_points.Count > 1)
                    gr.DrawLines(thick_pen, rp_points.ToArray());

                thick_pen.Color = Color.Orange;
                if (rn_points.Count > 1)
                    gr.DrawLines(thick_pen, rn_points.ToArray());
            }
        }

        // Calculate G1(x).
        // root_sign is -1 or 1.
        private float G1(float x, float A, float B, float C, float D, float E, float F, float root_sign)
        {
            float result = B * x + E;
            result = result * result;
            result = result - 4 * C * (A * x * x + D * x + F);
            result = root_sign * (float)Math.Sqrt(result);
            result = -(B * x + E) + result;
            result = result / 2 / C;

            return result;
        }

        // Return true if the number is not infinity or NaN.
        private bool IsNumber(float number)
        {
            return !(float.IsNaN(number) || float.IsInfinity(number));
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.btnGraph = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(35, 12);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(159, 20);
            this.txtA.TabIndex = 1;
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(74, 168);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 2;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(35, 38);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(159, 20);
            this.txtB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "B:";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(35, 90);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(159, 20);
            this.txtD.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "D:";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(35, 64);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(159, 20);
            this.txtC.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "C:";
            // 
            // txtF
            // 
            this.txtF.Location = new System.Drawing.Point(35, 142);
            this.txtF.Name = "txtF";
            this.txtF.Size = new System.Drawing.Size(159, 20);
            this.txtF.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "F:";
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(35, 116);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(159, 20);
            this.txtE.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "E:";
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(200, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(250, 240);
            this.picGraph.TabIndex = 13;
            this.picGraph.TabStop = false;
            // 
            // howto_graph_conic_section_Form1
            // 
            this.AcceptButton = this.btnGraph;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 264);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.txtF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label1);
            this.Name = "howto_graph_conic_section_Form1";
            this.Text = "howto_graph_conic_section";
            this.Load += new System.EventHandler(this.howto_graph_conic_section_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

