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
     public partial class howto_fibonacci_word_fractal_Form1:Form
  { 


        public howto_fibonacci_word_fractal_Form1()
        {
            InitializeComponent();
        }

        // Directions. Oriented so adding 1 turns right.
        private enum Directions
        {
            Up,
            Right,
            Down,
            Left,
        };

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the desired length.
            int term_num = int.Parse(txtNumTerms.Text);
            if (term_num > 30)
            {
                if (MessageBox.Show(
                    "This may take a long time. Continue anyway?",
                    "Continue?", MessageBoxButtons.YesNo)
                        == DialogResult.No)
                            return;
            }

            // Get the Fibonacci word.
            string word = FiboWord(term_num);
            char[] chars = word.ToCharArray();

            // Calculate the points.
            Point[] points = new Point[word.Length + 1];
            points[0] = new Point(0, 0);
            Directions dir = Directions.Up;
            for (int i = 0; i < word.Length; i++)
            {
                AddPoint(chars, points, i, ref dir);
            }
            Console.WriteLine("# Chars: " + chars.Length);
            Console.WriteLine("# Points: " + points.Length);

            // Find the points' bounds.
            Rectangle rect = GetBounds(points);

            // Draw.
            int wid = picDrawing.ClientSize.Width;
            int hgt = picDrawing.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Scale to fit.
                RectangleF target_rect = new RectangleF(5, 5, wid - 10, hgt - 10);
                MapDrawing(gr, rect, target_rect, false);

                // Draw.
                gr.DrawLines(Pens.Black, points);
            }

            // Display the result.
            picDrawing.Image = bm;
        }

        // Calculate the nth Fibonacci word.
        private string FiboWord(int n)
        {
            // See how long it should be.
            int length = Fibo(n);
            //string s2 = "0";        // s - 2
            //string s1 = "01";       // s - 1 
            string s2 = "0";        // s - 2
            string s1 = "1";        // s - 1 
            string s0 = "010";      // s (Initially s = 2.)
            while (s0.Length < length)
            {
                s0 = s1 + s2;
                s2 = s1;
                s1 = s0;
            }
            return s0.Substring(0, length);
        }

        // Return the nth Fibonacci number.
        private int Fibo(int n)
        {
            if (n <= 1) return n;
            int n2 = 0;         // n - 2
            int n1 = 1;         // n - 1
            int n0 = n1 + n2;   // n (Initially n = 2.)
            for (int i = 2; i < n; i++)
            {
                n2 = n1;
                n1 = n0;
                n0 = n1 + n2;
            }
            return n0;
        }

        // Add the next point in the indicated direction.
        private void AddPoint(char[] chars, Point[] points, int i, ref Directions dir)
        {
            // If the character is odd, turn 90 degrees.
            if (chars[i] == '1')
            {
                if (i % 2 == 0)
                    dir = (Directions)(((int)dir + 1) % 4);
                else
                    dir = (Directions)(((int)dir + 3) % 4);
            }

            // Find the next point.
            const int dist = 5;
            int x = points[i].X;
            int y = points[i].Y;
            if (dir == Directions.Up) y -= dist;
            else if (dir == Directions.Down) y += dist;
            else if (dir == Directions.Left) x -= dist;
            else if (dir == Directions.Right) x += dist;
            points[i + 1] = new Point(x, y);
        }

        // Find the bounds of the points.
        private Rectangle GetBounds(Point[] points)
        {
            int xmin = points[0].X;
            int xmax = xmin;
            int ymin = points[0].Y;
            int ymax = ymin;
            foreach (Point point in points)
            {
                if (point.X < xmin) xmin = point.X;
                if (point.X > xmax) xmax = point.X;
                if (point.Y < ymin) ymin = point.Y;
                if (point.Y > ymax) ymax = point.Y;
            }
            return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }

        // Map a drawing coordinate rectangle to
        // a graphics object rectangle.
        private void MapDrawing(Graphics gr, RectangleF drawing_rect,
            RectangleF target_rect, bool stretch)
        {
            gr.ResetTransform();

            // Center the drawing area at the origin.
            float drawing_cx = (drawing_rect.Left + drawing_rect.Right) / 2;
            float drawing_cy = (drawing_rect.Top + drawing_rect.Bottom) / 2;
            gr.TranslateTransform(-drawing_cx, -drawing_cy);

            // Scale.
            // Get scale factors for both directions.
            float scale_x = target_rect.Width / drawing_rect.Width;
            float scale_y = target_rect.Height / drawing_rect.Height;
            if (!stretch)
            {
                // To preserve the aspect ratio,
                // use the smaller scale factor.
                scale_x = Math.Min(scale_x, scale_y);
                scale_y = scale_x;
            }
            gr.ScaleTransform(scale_x, scale_y, MatrixOrder.Append);

            // Translate to center over the drawing area.
            float graphics_cx = (target_rect.Left + target_rect.Right) / 2;
            float graphics_cy = (target_rect.Top + target_rect.Bottom) / 2;
            gr.TranslateTransform(graphics_cx, graphics_cy, MatrixOrder.Append);
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
            this.picDrawing = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumTerms = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // picDrawing
            // 
            this.picDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picDrawing.BackColor = System.Drawing.Color.White;
            this.picDrawing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDrawing.Location = new System.Drawing.Point(6, 33);
            this.picDrawing.Name = "picDrawing";
            this.picDrawing.Size = new System.Drawing.Size(324, 275);
            this.picDrawing.TabIndex = 7;
            this.picDrawing.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(255, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumTerms
            // 
            this.txtNumTerms.Location = new System.Drawing.Point(55, 6);
            this.txtNumTerms.Name = "txtNumTerms";
            this.txtNumTerms.Size = new System.Drawing.Size(67, 20);
            this.txtNumTerms.TabIndex = 5;
            this.txtNumTerms.Text = "10";
            this.txtNumTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Word #:";
            // 
            // howto_fibonacci_word_fractal_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.picDrawing);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTerms);
            this.Controls.Add(this.label1);
            this.Name = "howto_fibonacci_word_fractal_Form1";
            this.Text = "howto_fibonacci_word_fractal";
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDrawing;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumTerms;
        private System.Windows.Forms.Label label1;
    }
}

