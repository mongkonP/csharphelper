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
     public partial class howto_graph_probabilities_Form1:Form
  { 


        public howto_graph_probabilities_Form1()
        {
            InitializeComponent();
        }

        // The probability data.
        private PointF[] Points = { };

        // Calculate and display probabilities.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Make room for the probabilities.
            int num_events = int.Parse(txtMaxNumberEvents.Text);
            Points = new PointF[num_events + 1];

            // Get the event probability.
            double event_prob = double.Parse(txtEventProb.Text.Replace("%", ""));
            if (txtEventProb.Text.Contains("%")) event_prob /= 100.0;

            // Get the probability of the event not happening.
            double non_prob = 1.0 - event_prob;

            for (int i = 0; i <= num_events; i++)
            {
                Points[i].X = i;
                Points[i].Y = 100 * (float)(1.0 - Math.Pow(non_prob, i));
            }

            // Redraw.
            picGraph.Refresh();
        }

        // Draw the data.
        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            // Clear.
            e.Graphics.Clear(picGraph.BackColor);
            if (Points.Length < 2) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Transform from world coordinates to screen coordinates.
            RectangleF rect = new RectangleF(0, 0, Points.Length + 1, 100);
            PointF[] pts =
            {
                new PointF(0, picGraph.ClientSize.Height),
                new PointF(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                new PointF(0, 0)
            };
            Matrix transform = new Matrix(rect, pts);

            using (Pen pen = new Pen(Color.Gray, 0))
            {
                // Draw the axes.
                using (StringFormat sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    for (int i = 0; i <= 100; i += 10)
                    {
                        // See where this should be.
                        pts = new PointF[]
                        {
                            new PointF(0, i),
                            new PointF(Points.Length, i),
                        };
                        transform.TransformPoints(pts);
                        e.Graphics.DrawLine(pen, pts[0], pts[1]);
                        e.Graphics.DrawString(i.ToString(), this.Font,
                            Brushes.Green, pts[0], sf);
                    }

                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Far;
                    int skip = (int)(Points.Length / 10);
                    skip = 5 * (int)(skip / 5);
                    if (skip < 1) skip = 1;
                    for (int i = 0; i < Points.Length; i += skip)
                    {
                        // See where this should be.
                        pts = new PointF[]
                        {
                            new PointF(i, 0),
                            new PointF(i, 5),
                        };
                        transform.TransformPoints(pts);
                        e.Graphics.DrawLine(pen, pts[0], pts[1]);
                        e.Graphics.DrawString(i.ToString(), this.Font,
                            Brushes.Green, pts[0], sf);
                    }
                }

                // Draw the graph.
                pen.Color = Color.Blue;
                e.Graphics.Transform = transform;
                e.Graphics.DrawLines(pen, Points);
            }
        }

        private void picGraph_Resize(object sender, EventArgs e)
        {
            picGraph.Refresh();
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.txtMaxNumberEvents = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtEventProb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 65);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(300, 183);
            this.picGraph.TabIndex = 13;
            this.picGraph.TabStop = false;
            this.picGraph.Resize += new System.EventHandler(this.picGraph_Resize);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // txtMaxNumberEvents
            // 
            this.txtMaxNumberEvents.Location = new System.Drawing.Point(107, 39);
            this.txtMaxNumberEvents.Name = "txtMaxNumberEvents";
            this.txtMaxNumberEvents.Size = new System.Drawing.Size(60, 20);
            this.txtMaxNumberEvents.TabIndex = 9;
            this.txtMaxNumberEvents.Text = "100";
            this.txtMaxNumberEvents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Max # Events:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(237, 25);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtEventProb
            // 
            this.txtEventProb.Location = new System.Drawing.Point(107, 13);
            this.txtEventProb.Name = "txtEventProb";
            this.txtEventProb.Size = new System.Drawing.Size(60, 20);
            this.txtEventProb.TabIndex = 8;
            this.txtEventProb.Text = "0.01";
            this.txtEventProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Event Probability:";
            // 
            // howto_graph_probabilities_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.txtMaxNumberEvents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtEventProb);
            this.Controls.Add(this.label1);
            this.Name = "howto_graph_probabilities_Form1";
            this.Text = "howto_graph_probabilities";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.TextBox txtMaxNumberEvents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtEventProb;
        private System.Windows.Forms.Label label1;
    }
}

