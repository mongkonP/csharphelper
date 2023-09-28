using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// See Eric W. Weisstein's article "Newton's Method."
// From MathWorld--A Wolfram Web Resource. 
// http://mathworld.wolfram.com/NewtonsMethod.html 

 

using howto_newtons_method_fractal;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_newtons_method_fractal_Form1:Form
  { 


        public howto_newtons_method_fractal_Form1()
        {
            InitializeComponent();
        }

#region "Variables"

        // Drawing variables.
        private Bitmap Bm;

        // World coordinates.
        private const double Gxmin = -1.5;
        private const double Gxmax = 1.5;
        private const double Gymin = -1.5;
        private const double Gymax = 1.5;
        private double Wxmin = Gxmin;
        private double Wxmax = Gxmax;
        private double Wymin = Gymin;
        private double Wymax = Gymax;

        // Colors for up to 8 roots.
        // Black = exceeded MAX_ITER iterations.
        // White = unknown root.
        private Color[] Colors = {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Yellow,
            Color.Orange,
            Color.Cyan,
            Color.Magenta,
            Color.Lime
        };

#endregion // Variables

#region "Functions"
        private int NumRoots = 8;
        private Complex[] Roots;

        // F(x) = x ^ NumRoots - 1.
        private Complex F(Complex x)
        {
            return (x ^ NumRoots) - 1;
        }

        // dFdx(x) = NumRoots * x ^ (NumRoots - 1).
        private Complex dFdx(Complex x)
        {
            return NumRoots * (x ^ (NumRoots - 1));
        }

#endregion // Functions

        // Draw the initial picture.
        private void howto_newtons_method_fractal_Form1_Load(object sender, EventArgs e)
        {
            // Display the form.
            this.Show();

            // Use a crosshair cursor.
            picCanvas.Cursor = Cursors.Cross;

            // Set the initial number of roots.
            SetRoots(NumRoots);
        }

        // Return to full scale.
        private void mnuToolsFullScale_Click(object sender, EventArgs e)
        {
            DrawFractal(Gxmin, Gxmax, Gymin, Gymax);
        }

        // Redraw at the current scale. (Useful after resizing.)
        private void mnuToolsRedraw_Click(object sender, EventArgs e)
        {
            DrawFractal(Wxmin, Wxmax, Wymin, Wymax);
        }

        // Set the number of roots.
        private void mnuToolsSetRoots_Click(object sender, EventArgs e)
        {
            howto_newtons_method_fractal_RootsForm dlg = new  howto_newtons_method_fractal_RootsForm();
            dlg.Roots = NumRoots;
            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Save the new power.
                    SetRoots(dlg.Roots);
                }
            }
            catch
            {
            }
        }

#region "Drawing"

        // Set the number of roots.
        private void SetRoots(int num_roots)
        {
            // Initialize the roots.
            NumRoots = num_roots;
            Roots = new Complex[NumRoots];
            for (int i = 0; i < NumRoots; i++)
            {
                Roots[i] = new Complex(
                    Math.Cos(2 * i * Math.PI / NumRoots),
                    Math.Sin(2 * i * Math.PI / NumRoots));
            }

            // Redraw.
            this.Text = "Roots: " + NumRoots;
            Bm = null;
            DrawFractal(Wxmin, Wxmax, Wymin, Wymax);
        }

        // Adjust the aspect ratio of the selected
        // coordinates so they fit the window properly.
        private void AdjustAspect()
        {
            double want_aspect = (Wymax - Wymin) / (Wxmax - Wxmin);
            double pic_aspect = (double)picCanvas.ClientSize.Height / picCanvas.ClientSize.Width;

            double hgt, wid, mid;
            if (want_aspect > pic_aspect)
            {
                // The selected area is too tall and thin.
                // Make it wider.
                wid = (Wymax - Wymin) / pic_aspect;
                mid = (Wxmin + Wxmax) / 2;
                Wxmin = mid - wid / 2;
                Wxmax = mid + wid / 2;
            } 
            else
            {
                // The selected area is too short and wide.
                // Make it taller.
                hgt = (Wxmax - Wxmin) * pic_aspect;
                mid = (Wymin + Wymax) / 2;
                Wymin = mid - hgt / 2;
                Wymax = mid + hgt / 2;
            }
        }

        // Methods for setting the color.
        private enum ColorMethods
        {
            ClosestRoot,
            NumIterations
        }

        // Draw the fractal.
        private void DrawFractal(double xmin, double xmax, double ymin, double ymax)
        {
            // Make sure we have executed howto_newtons_method_fractal_Form1_Load.
            if (Roots == null) return;

            // Get the PictureBox's dimensions.
            int wid = picCanvas.ClientSize.Width;
            int hgt = picCanvas.ClientSize.Height;
            if ((wid < 1) || (hgt < 1)) return;

            // Do nothing if neither the PictureBox nor the
            // world coordinates have changed since last time.
            if (Bm != null &&
                (Wxmin == xmin) && (Wxmax == xmax) &&
                (Wymin == ymin) && (Wymax == ymax) &&
                (wid == Bm.Width) && (hgt == Bm.Height))
                    return;

            // Save the new world coordinates.
            Wxmin = xmin;
            Wxmax = xmax;
            Wymin = ymin;
            Wymax = ymax;

            // Make a new Bitmap if necessary.
            if ((Bm == null) || (Bm.Width != wid) || (Bm.Height != hgt))
            {
                picCanvas.Image = null;
                if (Bm != null) Bm.Dispose();
                Bm = new Bitmap(wid, hgt);
                Console.WriteLine("Bitmap(" + wid + ", " + hgt + ")");
            }

            // Make a Graphics object to draw on.
            Graphics gr = Graphics.FromImage(Bm);

            // Clear the bitmap.
            gr.Clear(picCanvas.BackColor);
            picCanvas.Image = Bm;
            picCanvas.Invalidate();
            picCanvas.Refresh();
            this.Invalidate();
            this.Refresh();

            // Work until the epsilon squared < this.
            const double cutoff = 0.00000000001;

            // Adjust the coordinate bounds to fit picCanvas.
            AdjustAspect();

            // dx and dy are the changes in the real 
            // and imaginary parts across pixels.
            double dx = (Wxmax - Wxmin) / (wid - 1);
            double dy = (Wymax - Wymin) / (hgt - 1);

            // Calculate the values.
            Complex x0 = new Complex(Wxmin, 0);
            for (int i = 0; i < wid; i++)
            {
                x0.Im = Wymin;
                for (int j = 0; j < hgt; j++)
                {
                    Complex x = x0;
                    Complex epsilon;
                    const int max_iter = 400;
                    int iter = 0;
                    do
                    {
                        if (++iter > max_iter) break;
                        epsilon = -(F(x) / dFdx(x));
                        x += epsilon;
                    } while (epsilon.MagnitudeSquared() > cutoff);

                    // Set the color.
                    int clr = 0;
                    if (iter <= max_iter)
                    {
                        // Find the closest root.
                        for (int r = 0; r <= Roots.GetUpperBound(0); r++)
                        {
                            if (x.IsCloseTo(Roots[r]))
                            {
                                // Set the pixel's color.
                                clr = r % Colors.Length;
                                break;
                            }
                        }
                    }
                    Bm.SetPixel(i, j, Colors[clr]);

                    // Move to the next point.
                    x0.Im += dy;
                } // For j
                x0.Re += dx;

                // Let the user know we're not dead.
                if (i % 10 == 0) picCanvas.Refresh();
            } // For i

            // Update the image.
            picCanvas.Refresh();

            Console.WriteLine("(" +
                Wxmin + ", " +
                Wymin + ")-(" +
                Wxmax + ", " +
                Wymax + ")");
        }
        
#endregion // Drawing"

#region "Rubberbanding Methods"

        // Variables for rubberband drawing.
        private bool DrawingBox = false;
        private int X1, Y1, X2, Y2;
        private Bitmap ZoomingBitmap;
        private Graphics ZoomingGraphics;

        // Start rubberbanding.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            DrawingBox = true;
            X1 = e.X;
            Y1 = e.Y;
            X2 = X1;
            Y2 = Y1;

            // Make a copy of the current image to draw on.
            ZoomingBitmap = new Bitmap(Bm);
            ZoomingGraphics = Graphics.FromImage(ZoomingBitmap);

            // Display the copy.
            picCanvas.Image = ZoomingBitmap;
        }

        // Continue rubberbanding.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DrawingBox) return;

            // Save the new corner.
            X2 = e.X;
            Y2 = e.Y;

            // Draw the new box.
            Rectangle rect = new Rectangle();
            rect.X = Math.Min(X1, X2);
            rect.Y = Math.Min(Y1, Y2);
            rect.Width = Math.Abs(X2 - X1);
            rect.Height = Math.Abs(Y2 - Y1);

            ZoomingGraphics.DrawImage(Bm, 0, 0);
            using (Pen rubber_pen = new Pen(Color.Black, 0))
            {
                rubber_pen.DashPattern = new float[] { 5, 5 };
                ZoomingGraphics.DrawRectangle(rubber_pen, rect);
            }
            picCanvas.Refresh();
        }

        // Finish rubberbanding.
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!DrawingBox) return;
            DrawingBox = false;

            // Dispose of the zooming Bitmap and Graphics.
            picCanvas.Image = null;
            ZoomingGraphics.Dispose();
            ZoomingGraphics = null;
            ZoomingBitmap.Dispose();
            ZoomingBitmap = null;

            // Save the new corner.
            X2 = e.X;
            Y2 = e.Y;

            // Put the selected coordinates in order.
            double x1 = Math.Min(X1, X2);
            double x2 = Math.Max(X1, X2);
            double y1 = Math.Min(Y1, Y2);
            double y2 = Math.Max(Y1, Y2);

            // Convert screen coords into drawing coords.
            double factor = (Wxmax - Wxmin) / picCanvas.ClientSize.Width;
            double xmax = Wxmin + x2 * factor;
            double xmin = Wxmin + x1 * factor;

            factor = (Wymax - Wymin) / picCanvas.ClientSize.Height;
            double ymax = Wymin + y2 * factor;
            double ymin = Wymin + y1 * factor;

            // Draw the new fractal.
            DrawFractal(xmin, xmax, ymin, ymax);
        }

#endregion // Rubberbanding Methods

    

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
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuToolsSetRoots = new System.Windows.Forms.MenuItem();
            this.mnuToolsRedraw = new System.Windows.Forms.MenuItem();
            this.mnuToolsFullScale = new System.Windows.Forms.MenuItem();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuToolsSetRoots,
            this.mnuToolsRedraw,
            this.mnuToolsFullScale});
            this.MenuItem1.Text = "&Tools";
            // 
            // mnuToolsSetRoots
            // 
            this.mnuToolsSetRoots.Index = 0;
            this.mnuToolsSetRoots.Text = "&Set Roots";
            this.mnuToolsSetRoots.Click += new System.EventHandler(this.mnuToolsSetRoots_Click);
            // 
            // mnuToolsRedraw
            // 
            this.mnuToolsRedraw.Index = 1;
            this.mnuToolsRedraw.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.mnuToolsRedraw.Text = "&Redraw";
            this.mnuToolsRedraw.Click += new System.EventHandler(this.mnuToolsRedraw_Click);
            // 
            // mnuToolsFullScale
            // 
            this.mnuToolsFullScale.Index = 2;
            this.mnuToolsFullScale.Text = "&Full Scale";
            this.mnuToolsFullScale.Click += new System.EventHandler(this.mnuToolsFullScale_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Black;
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(310, 310);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // howto_newtons_method_fractal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 310);
            this.Controls.Add(this.picCanvas);
            this.Menu = this.MainMenu1;
            this.Name = "howto_newtons_method_fractal_Form1";
            this.Text = "howto_newtons_method_fractal";
            this.Load += new System.EventHandler(this.howto_newtons_method_fractal_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.MainMenu MainMenu1;
        internal System.Windows.Forms.MenuItem MenuItem1;
        internal System.Windows.Forms.MenuItem mnuToolsFullScale;
        internal System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.MenuItem mnuToolsRedraw;
        private System.Windows.Forms.MenuItem mnuToolsSetRoots;
    }
}

