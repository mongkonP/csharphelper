using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_clip_image_to_polygon;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_clip_image_to_polygon_Form1:Form
  { 


        public howto_clip_image_to_polygon_Form1()
        {
            InitializeComponent();
        }

        // The polygon selector.
        private PolygonSelector Selector;
        private PointF[] Polygon = null;

        // Prepare the selector.
        private void howto_clip_image_to_polygon_Form1_Load(object sender, EventArgs e)
        {
            Selector = new PolygonSelector(picCanvas, new Pen(Color.Red, 3));
            Selector.PolygonSelected += Selector_PolygonSelected;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(picCanvas.BackColor);

            if (Polygon != null)
            {
                DrawImageInPolygon(e.Graphics,
                    Polygon, Properties.Resources.Smiley_with_bg);
                using (Pen pen = new Pen(Color.Green, 3))
                {
                    e.Graphics.DrawPolygon(pen, Polygon.ToArray());
                }
            }
        }

        // The user has selected a polygon. Save it.
        void Selector_PolygonSelected(object sender, PolygonEventArgs args)
        {
            Polygon = PointsToPointFs(args.Points);
            picCanvas.Refresh();
        }

        // Convert Point data into a PointF array.
        private PointF[] PointsToPointFs(IEnumerable<Point> points)
        {
            var query = from Point point in points select (PointF)point;
            return query.ToArray();
        }

        // Draw an image so it fills the polygon.
        public static void DrawImageInPolygon(Graphics gr,
            PointF[] points, Image image)
        {
            // Get the polygon's bounds and center.
            float xmin, xmax, ymin, ymax;
            GetPolygonBounds(points, out xmin, out xmax, out ymin, out ymax);
            float wid = xmax - xmin;
            float hgt = ymax - ymin;
            float cx = (xmin + xmax) / 2f;
            float cy = (ymin + ymax) / 2f;

            // Calculate the scale needed to make
            // the image fill the polygon's bounds.
            float xscale = wid / image.Width;
            float yscale = hgt / image.Height;
            float scale = Math.Max(xscale, yscale);

            // Calculate the image's scaled size.
            float width = image.Width * scale;
            float height = image.Height * scale;
            float rx = width / 2f;
            float ry = height / 2f;

            // Find the source rectangle and destination points.
            RectangleF src_rect = new RectangleF(0, 0,
                image.Width, image.Height);
            PointF[] dest_points =
            {
                new PointF(cx - rx,  cy - ry),
                new PointF(cx + rx,  cy - ry),
                new PointF(cx - rx,  cy + ry),
            };

            // Clip the drawing area to the polygon and draw the image.
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(points);
            GraphicsState state = gr.Save();
            gr.SetClip(path);   // Comment out to not clip.
            gr.DrawImage(image, dest_points, src_rect, GraphicsUnit.Pixel);
            gr.Restore(state);
        }

        // Return a polygon's bounds.
        public static void GetPolygonBounds(PointF[] points,
            out float xmin, out float xmax, out float ymin, out float ymax)
        {
            xmin = points[0].X;
            xmax = xmin;
            ymin = points[0].Y;
            ymax = ymin;
            foreach (PointF point in points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }
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
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 237);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_clip_image_to_polygon_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_clip_image_to_polygon_Form1";
            this.Text = "howto_clip_image_to_polygon";
            this.Load += new System.EventHandler(this.howto_clip_image_to_polygon_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

