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
using System.Drawing.Imaging;
using System.IO;

 

using howto_image_gasket;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_image_gasket_Form1:Form
  { 


        public howto_image_gasket_Form1()
        {
            InitializeComponent();
        }

        // Various colors.
        private Color BitmapBackgroundColor = Color.Transparent;
        private Color CircleBackgroundColor = Color.Transparent;
        private Color CircleOutlineColor = Color.Transparent;

        // A pen for outlining circles.
        private Pen CirclePen = null;

        // Display the packing.
        private void howto_image_gasket_Form1_Load(object sender, EventArgs e)
        {
            Circle.GasketImage = Properties.Resources.cat;
        }

        private void MakeImage()
        {
            Cursor = Cursors.WaitCursor;
            int width = int.Parse(txtWidth.Text);
            int level = int.Parse(txtLevel.Text);
            picPacking.Image = FindApollonianPacking(width, level);

            int wid = Math.Max(ClientSize.Width, picPacking.Right + picPacking.Left);
            int hgt = Math.Max(ClientSize.Height, picPacking.Bottom + picPacking.Left);
            ClientSize = new Size(wid, hgt);

            Cursor = Cursors.Default;
        }

        // Find the Apollonian packing.
        private Bitmap FindApollonianPacking(int width, int level)
        {
            Bitmap bm = new Bitmap(width, width);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.InterpolationMode = InterpolationMode.High;
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(BitmapBackgroundColor);

                // Tell the circles where the image's center is.
                Circle.GasketCenter = new PointF(
                    width / 2f, width / 2f);

                // Create the three central tangent circles.
                float radius = width * 0.225f;
                float x = width / 2;
                float gasket_height = 2 * (float)(radius + 2 * radius / Math.Sqrt(3));
                float y = (width - gasket_height) / 2 + radius;
                Circle circle0 = new Circle(x, y, radius);

                // Draw a box around the gasket. (For debugging.)
                //gr.DrawRectangle(Pens.Orange,
                //    x - gasket_height / 2,
                //    y - radius,
                //    gasket_height,
                //    gasket_height);

                x -= radius;
                y += (float)(radius * Math.Sqrt(3));
                Circle circle1 = new Circle(x, y, radius);
                x += 2 * radius;
                Circle circle2 = new Circle(x, y, radius);

                // Fill the circle that contains
                // the central circles and fill it.
                Circle big_circle = FindApollonianCircle(circle0, circle1, circle2, -1, -1, -1);
                using (Brush brush = new SolidBrush(CircleBackgroundColor))
                {
                    gr.FillEllipse(brush, big_circle.GetBounds());
                }
                using (CirclePen = new Pen(CircleOutlineColor))
                {
                    gr.DrawEllipse(CirclePen, big_circle.GetBounds());

                    // Draw the three central circles.
                    circle0.Draw(gr, CirclePen);
                    circle1.Draw(gr, CirclePen);
                    circle2.Draw(gr, CirclePen);

                    // Find the central circle.
                    FindCircleOutsideAll(level, gr, circle0, circle1, circle2);

                    // Find circles tangent to the big circle.
                    FindCircleOutsideTwo(level, gr, circle0, circle1, big_circle);
                    FindCircleOutsideTwo(level, gr, circle1, circle2, big_circle);
                    FindCircleOutsideTwo(level, gr, circle2, circle0, big_circle);
                }
            }
            return bm;
        }

        // Draw a circle tangent to these three circles and that is outside all three.
        private void FindCircleOutsideAll(int level, Graphics gr, Circle circle0, Circle circle1, Circle circle2)
        {
            Circle new_circle = FindApollonianCircle(circle0, circle1, circle2, 1, 1, 1);
            if (new_circle == null) return;
            if (new_circle.Radius < 1) return;

            new_circle.Draw(gr, CirclePen);

            if (--level > 0)
            {
                FindCircleOutsideAll(level, gr, circle0, circle1, new_circle);
                FindCircleOutsideAll(level, gr, circle0, circle2, new_circle);
                FindCircleOutsideAll(level, gr, circle1, circle2, new_circle);
            }
        }

        // Draw a circle tangent to these three circles and that is outside two of them.
        private void FindCircleOutsideTwo(int level, Graphics gr, Circle circle0, Circle circle1, Circle circle_contains)
        {
            Circle new_circle = FindApollonianCircle(circle0, circle1, circle_contains, 1, 1, -1);
            if (new_circle == null) return;
            if (new_circle.Radius < 1) return;

            new_circle.Draw(gr, CirclePen);

            if (--level > 0)
            {
                FindCircleOutsideTwo(level, gr, new_circle, circle0, circle_contains);
                FindCircleOutsideTwo(level, gr, new_circle, circle1, circle_contains);
                FindCircleOutsideAll(level, gr, circle0, circle1, new_circle);
            }
        }

        // Find the circles that touch each of the three input circles.
        private Circle[] FindApollonianCircles(Circle[] given_circles)
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

            Debug.Assert(!float.IsNaN(rs) && !float.IsNaN(xs) && !float.IsNaN(ys),
                "Error finding Apollonian circle.");

            if ((Math.Abs(xs) < tiny) || (Math.Abs(ys) < tiny) || (Math.Abs(rs) < tiny)) return null;
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

        private void mnuFileOpenImage_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                Circle.GasketImage = LoadBitmapUnlocked(ofdImage.FileName);
            }
        }

        private void mnuFileSaveResult_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveImage(picPacking.Image, sfdResult.FileName);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        private void mnuColorBitmapBackground_Click(object sender, EventArgs e)
        {
            cdBackground.Color = BitmapBackgroundColor;
            if (cdBackground.ShowDialog() == DialogResult.OK)
            {
                BitmapBackgroundColor = cdBackground.Color;
            }
        }

        private void mnuColorCircleBackground_Click(object sender, EventArgs e)
        {
            cdBackground.Color = CircleBackgroundColor;
            if (cdBackground.ShowDialog() == DialogResult.OK)
            {
                CircleBackgroundColor = cdBackground.Color;
            }
        }

        private void mnuColorCircleOutlines_Click(object sender, EventArgs e)
        {
            cdBackground.Color = CircleOutlineColor;
            if (cdBackground.ShowDialog() == DialogResult.OK)
            {
                CircleOutlineColor = cdBackground.Color;
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            MakeImage();
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
            this.picPacking = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorBitmapBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorCircleBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColorCircleOutlines = new System.Windows.Forms.ToolStripMenuItem();
            this.cdBackground = new System.Windows.Forms.ColorDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPacking)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPacking
            // 
            this.picPacking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPacking.Location = new System.Drawing.Point(12, 56);
            this.picPacking.Name = "picPacking";
            this.picPacking.Size = new System.Drawing.Size(179, 171);
            this.picPacking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPacking.TabIndex = 2;
            this.picPacking.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.colorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpenImage,
            this.mnuFileSaveResult,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpenImage
            // 
            this.mnuFileOpenImage.Name = "mnuFileOpenImage";
            this.mnuFileOpenImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpenImage.Size = new System.Drawing.Size(191, 22);
            this.mnuFileOpenImage.Text = "&Open Image...";
            this.mnuFileOpenImage.Click += new System.EventHandler(this.mnuFileOpenImage_Click);
            // 
            // mnuFileSaveResult
            // 
            this.mnuFileSaveResult.Name = "mnuFileSaveResult";
            this.mnuFileSaveResult.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveResult.Size = new System.Drawing.Size(191, 22);
            this.mnuFileSaveResult.Text = "&Save Ressult...";
            this.mnuFileSaveResult.Click += new System.EventHandler(this.mnuFileSaveResult_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(191, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColorBitmapBackground,
            this.mnuColorCircleBackground,
            this.mnuColorCircleOutlines});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.colorsToolStripMenuItem.Text = "&Colors";
            // 
            // mnuColorBitmapBackground
            // 
            this.mnuColorBitmapBackground.Name = "mnuColorBitmapBackground";
            this.mnuColorBitmapBackground.Size = new System.Drawing.Size(188, 22);
            this.mnuColorBitmapBackground.Text = "&Bitmap Background...";
            this.mnuColorBitmapBackground.Click += new System.EventHandler(this.mnuColorBitmapBackground_Click);
            // 
            // mnuColorCircleBackground
            // 
            this.mnuColorCircleBackground.Name = "mnuColorCircleBackground";
            this.mnuColorCircleBackground.Size = new System.Drawing.Size(188, 22);
            this.mnuColorCircleBackground.Text = "&Circle Background...";
            this.mnuColorCircleBackground.Click += new System.EventHandler(this.mnuColorCircleBackground_Click);
            // 
            // mnuColorCircleOutlines
            // 
            this.mnuColorCircleOutlines.Name = "mnuColorCircleOutlines";
            this.mnuColorCircleOutlines.Size = new System.Drawing.Size(188, 22);
            this.mnuColorCircleOutlines.Text = "Circle &Outlines...";
            this.mnuColorCircleOutlines.Click += new System.EventHandler(this.mnuColorCircleOutlines_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.DefaultExt = "png";
            this.ofdImage.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // sfdResult
            // 
            this.sfdResult.DefaultExt = "png";
            this.sfdResult.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(56, 29);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(41, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.Text = "600";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(251, 27);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(170, 29);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(41, 20);
            this.txtLevel.TabIndex = 1;
            this.txtLevel.Text = "5";
            this.txtLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Level:";
            // 
            // howto_image_gasket_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 399);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picPacking);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_image_gasket_Form1";
            this.Text = "howto_image_gasket";
            this.Load += new System.EventHandler(this.howto_image_gasket_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPacking)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPacking;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenImage;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveResult;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ColorDialog cdBackground;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdResult;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuColorBitmapBackground;
        private System.Windows.Forms.ToolStripMenuItem mnuColorCircleBackground;
        private System.Windows.Forms.ToolStripMenuItem mnuColorCircleOutlines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label2;
    }
}

