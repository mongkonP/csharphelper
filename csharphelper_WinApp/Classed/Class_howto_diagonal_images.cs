
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_diagonal_images

 { 

class Cell
    {
        public RectangleF Bounds;
        public Bitmap Picture = null;
        public Cell(RectangleF bounds)
        {
            Bounds = bounds;
        }

        // Draw the cell.
        public void Draw(Graphics gr, Pen pen, float cell_width, float cell_height)
        {
            // Draw the cell's picture.
            if (Picture != null)
            {
                // Find the part of the picture that we will draw.
                float pic_wid = Picture.Width;
                float pic_hgt = Picture.Height;
                float cx = pic_wid / 2f;
                float cy = pic_hgt / 2f;
                if (pic_wid / pic_hgt > Bounds.Width / Bounds.Height)
                {
                    // The picture is too short and wide. Make it narrower.
                    pic_wid = Bounds.Width / Bounds.Height * pic_hgt;
                }
                else
                {
                    // The picture is too tall and thin. Make it shorter.
                    pic_hgt = pic_wid / (Bounds.Width / Bounds.Height);
                }
                RectangleF src_rect = new RectangleF(
                    cx - pic_wid / 2f, cy - pic_hgt / 2f, pic_wid, pic_hgt);

                // Draw the picture.
                PointF[] dest_points =
                {
                    new PointF(Bounds.Left, Bounds.Top),
                    new PointF(Bounds.Right, Bounds.Top),
                    new PointF(Bounds.Left, Bounds.Bottom),
                };
                gr.DrawImage(Picture, dest_points, src_rect, GraphicsUnit.Pixel);
            }

            // Outline the cell.
            GraphicsPath path = MakeRoundedRect(Bounds,
                2 * pen.Width, 2 * pen.Width, true, true, true, true);
            gr.DrawPath(pen, path);
        }

        // Return true if the cell contains the point.
        public bool ContainsPoint(PointF point)
        {
            return Bounds.Contains(point);
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
        }
    }

}