using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_one_self_avoiding_walk;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_one_self_avoiding_walk_Form1:Form
  { 


        public howto_one_self_avoiding_walk_Form1()
        {
            InitializeComponent();
        }

        // The lattice size.
        private int WalkWidth, WalkHeight;

        // Used to pick a random starting vertex.
        private Random Rand = new Random();

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (btnGenerate.Text == "Generate")
            {
                // Start generating walks.
                btnGenerate.Text = "Stop";
                picCanvas.Image = null;

                WalkWidth = int.Parse(txtWidth.Text);
                WalkHeight = int.Parse(txtHeight.Text);

                tmrShowWalk.Enabled = true;
            }
            else
            {
                // Stop generating walks.
                btnGenerate.Text = "Generate";
                tmrShowWalk.Enabled = false;
            }
        }

        // Find one random self-avoiding walk.
        private List<Point> FindOneWalk(int width, int height)
        {
            // Make an array to show where we have been.
            bool[,] visited = new bool[width + 1, height + 1];

            // Get the number of points we need to visit.
            int num_points = (width + 1) * (height + 1);

            // Start at a random vertex.
            int x = Rand.Next(0, width + 1);
            int y = Rand.Next(0, height + 1);

            // Start the walk at (0, 0).
            Stack<Point> current_walk = new Stack<Point>();
            current_walk.Push(new Point(x, y));
            visited[x, y] = true;

            // Search for walks.
            List<Point> walk = FindOneWalk(num_points, current_walk,
                x, y, width, height, visited);
            if (walk != null) return walk;
            return current_walk.ToList();
        }

        // Extend the walk that is at (current_x, current_y).
        private List<Point> FindOneWalk(int num_points,
            Stack<Point> current_walk,
            int current_x, int current_y,
            int width, int height, bool[,] visited)
        {
            // If we have visited every position, and the
            // last point is in the lower right corner,
            // then this is a complete walk.
            if (current_walk.Count == num_points)
            {
                return current_walk.ToList();
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

                // Randomize the moves to try.
                next_points.Randomize();

                // Try the moves.
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

                    List<Point> walk = FindOneWalk(num_points, current_walk,
                        point.X, point.Y, width, height, visited);
                    if (walk != null) return walk;

                    // We're done visiting this point.
                    visited[point.X, point.Y] = false;
                    current_walk.Pop();
                }
                return null;
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
                if (walk.Count == 1)
                {
                    RectangleF rect = new RectangleF(
                        offset_x + walk[0].X * scale - 2 * dot_r,
                        offset_y + walk[0].Y * scale - 2 * dot_r,
                        4 * dot_r, 4 * dot_r);
                    gr.DrawEllipse(pen, rect);                            
                }
                else
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

        // Generate and display the next walk.
        private void tmrShowWalk_Tick(object sender, EventArgs e)
        {
            List<Point> walk = FindOneWalk(WalkWidth, WalkHeight);
            if (walk == null)
                picCanvas.Image = null;
            else
            {
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    Bitmap bm = DrawWalk(walk,
                        WalkWidth, WalkHeight,
                        picCanvas.ClientSize.Width,
                        picCanvas.ClientSize.Height,
                        Color.White, Brushes.Green, pen);
                    picCanvas.Image = bm;
                }
            }
        }

        private void scrSpeed_Scroll(object sender, ScrollEventArgs e)
        {
            tmrShowWalk.Interval = 1000 / scrSpeed.Value;
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
            this.scrSpeed = new System.Windows.Forms.HScrollBar();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.tmrShowWalk = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // scrSpeed
            // 
            this.scrSpeed.LargeChange = 1;
            this.scrSpeed.Location = new System.Drawing.Point(9, 215);
            this.scrSpeed.Minimum = 1;
            this.scrSpeed.Name = "scrSpeed";
            this.scrSpeed.Size = new System.Drawing.Size(210, 17);
            this.scrSpeed.TabIndex = 30;
            this.scrSpeed.Value = 2;
            this.scrSpeed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrSpeed_Scroll);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(66, 32);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 29;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(161, 6);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(42, 20);
            this.txtHeight.TabIndex = 28;
            this.txtHeight.Text = "4";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tmrShowWalk
            // 
            this.tmrShowWalk.Interval = 500;
            this.tmrShowWalk.Tick += new System.EventHandler(this.tmrShowWalk_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Height:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(50, 6);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(42, 20);
            this.txtWidth.TabIndex = 26;
            this.txtWidth.Text = "4";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Width:";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(222, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(220, 220);
            this.picCanvas.TabIndex = 24;
            this.picCanvas.TabStop = false;
            // 
            // howto_one_self_avoiding_walk_Form1
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 241);
            this.Controls.Add(this.scrSpeed);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_one_self_avoiding_walk_Form1";
            this.Text = "howto_one_self_avoiding_walk";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar scrSpeed;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Timer tmrShowWalk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}

