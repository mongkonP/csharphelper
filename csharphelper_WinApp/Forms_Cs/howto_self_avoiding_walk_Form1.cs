using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_self_avoiding_walk_Form1:Form
  { 


        public howto_self_avoiding_walk_Form1()
        {
            InitializeComponent();
        }

        private List<List<Point>> Walks = null;
        private int WalkWidth, WalkHeight;

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lblResults.Text = "Working...";
            lblWalkNum.Text = "";
            btnGenerate.Enabled = false;
            trkWalk.Visible = false;
            picCanvas.Image = null;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Find the walks.
            WalkWidth = int.Parse(txtWidth.Text);
            WalkHeight = int.Parse(txtHeight.Text);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Walks = FindWalks(WalkWidth, WalkHeight);
            watch.Stop();

            string noun = (Walks.Count == 1 ? " walk " : " walks ");
            lblResults.Text = "Found " +
                Walks.Count.ToString() + noun + "in " +
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " seconds";

            // Display the first walk.
            if (Walks.Count > 0)
            {
                DisplayWalk(0);
                if (Walks.Count > 1)
                {
                    trkWalk.Maximum = Walks.Count - 1;
                    trkWalk.Value = 0;
                    trkWalk.Visible = true;
                }
            }

            btnGenerate.Enabled = true;
            Cursor = Cursors.Default;
        }

        // Generate all self-avoiding walks.
        private List<List<Point>> FindWalks(int width, int height)
        {
            List<List<Point>> walks = new List<List<Point>>();

            // Make an array to show where we have been.
            bool[,] visited = new bool[width + 1, height + 1];

            // Get the number of points we need to visit.
            int num_points = (width + 1) * (height + 1);

            // Start the walk at (0, 0).
            Stack<Point> current_walk = new Stack<Point>();
            current_walk.Push(new Point(0, 0));
            visited[0, 0] = true;

            // Search for walks.
            FindWalks(num_points, walks, current_walk,
                0, 0, width, height, visited);
            return walks;
        }

        // Extend the walk that is at (current_x, current_y).
        private void FindWalks(int num_points,
            List<List<Point>> walks, Stack<Point> current_walk,
            int current_x, int current_y,
            int width, int height, bool[,] visited)
        {
            // If we have visited every position,
            // then this is a complete walk.
            if (current_walk.Count == num_points)
            {
                walks.Add(current_walk.ToList());

                if (walks.Count % 1000 == 0)
                {
                    lblResults.Text = "... " +
                        walks.Count.ToString() + " ...";
                    Application.DoEvents();
                }
            }
            else
            {
                // Try the possible moves.
                Point[] next_points = new Point[]
                {
                    new Point(current_x - 1, current_y),
                    new Point(current_x + 1, current_y),
                    new Point(current_x, current_y - 1),
                    new Point(current_x, current_y + 1),
                };
                foreach (Point point in next_points)
                {
                    if (point.X < 0) continue;
                    if (point.X > width) continue;
                    if (point.Y < 0) continue;
                    if (point.Y > height) continue;
                    if (visited[point.X, point.Y]) continue;

                    // Try visiting this point.
                    visited[point.X, point.Y] = true;
                    current_walk.Push(point);

                    FindWalks(num_points, walks, current_walk,
                        point.X, point.Y, width, height, visited);

                    // We're done visiting this point.
                    visited[point.X, point.Y] = false;
                    current_walk.Pop();
                }
            }
        }

        // Display the selected walk.
        private void trkWalk_Scroll(object sender, EventArgs e)
        {
            DisplayWalk(trkWalk.Value);
        }
        private void DisplayWalk(int walk_num)
        {
            lblWalkNum.Text = "Walk " + walk_num.ToString();
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                Bitmap bm = DrawWalk(Walks[walk_num],
                    WalkWidth, WalkHeight,
                    picCanvas.ClientSize.Width,
                    picCanvas.ClientSize.Height,
                    Color.White, Brushes.Green, pen);
                picCanvas.Image = bm;
            }
        }

        // Draw a walk.
        private Bitmap DrawWalk(List<Point> walk,
            int width, int height, int bm_width, int bm_height,
            Color bg_color, Brush dot_brush, Pen pen)
        {
            Bitmap bm = new Bitmap(bm_width, bm_height);

            // See how big to make each row and column.
            float scale_x = bm_width / (width + 2);
            float scale_y = bm_height / (height + 2);
            float scale = Math.Min(scale_x, scale_y);
            float offset_x = (bm_width - scale * width) / 2;
            float offset_y = (bm_height - scale * height) / 2;
            float dot_r = scale_x * 0.1f;
            float dot_w = 2 * dot_r;

            // Draw the walk.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(bg_color);

                // Draw a grid of dots.
                for (int x = 0; x <= width; x++)
                {
                    for (int y = 0; y <= height; y++)
                    {
                        gr.FillEllipse(dot_brush,
                            offset_x + x * scale - dot_r,
                            offset_y + y * scale - dot_r,
                            dot_w, dot_w);
                    }
                }

                // Draw the walk.
                if (walk.Count > 1)
                {
                    List<PointF> points = new List<PointF>();
                    foreach (Point point in walk.ToArray())
                    {
                        points.Add(new PointF(
                            offset_x + point.X * scale,
                            offset_y + point.Y * scale));
                    }
                    gr.DrawLines(pen, points.ToArray());
                }
            }

            return bm;
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.trkWalk = new System.Windows.Forms.TrackBar();
            this.lblWalkNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkWalk)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(222, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(220, 220);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(56, 12);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(42, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "4";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(167, 12);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(42, 20);
            this.txtHeight.TabIndex = 4;
            this.txtHeight.Text = "4";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(72, 38);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 83);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(0, 13);
            this.lblResults.TabIndex = 6;
            // 
            // trkWalk
            // 
            this.trkWalk.Location = new System.Drawing.Point(12, 108);
            this.trkWalk.Name = "trkWalk";
            this.trkWalk.Size = new System.Drawing.Size(204, 45);
            this.trkWalk.TabIndex = 7;
            this.trkWalk.Visible = false;
            this.trkWalk.Scroll += new System.EventHandler(this.trkWalk_Scroll);
            // 
            // lblWalkNum
            // 
            this.lblWalkNum.AutoSize = true;
            this.lblWalkNum.Location = new System.Drawing.Point(12, 160);
            this.lblWalkNum.Name = "lblWalkNum";
            this.lblWalkNum.Size = new System.Drawing.Size(0, 13);
            this.lblWalkNum.TabIndex = 8;
            // 
            // howto_self_avoiding_walk_Form1
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 241);
            this.Controls.Add(this.lblWalkNum);
            this.Controls.Add(this.trkWalk);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_self_avoiding_walk_Form1";
            this.Text = "howto_self_avoiding_walk";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkWalk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.TrackBar trkWalk;
        private System.Windows.Forms.Label lblWalkNum;
    }
}

