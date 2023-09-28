
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_image_gasket

 { 

// Represents a circle.
    class Circle
    {
        private static Bitmap _GasketImage = null;
        private static Rectangle SourceRect;
        public static Bitmap GasketImage
        {
            set
            {
                _GasketImage = value;
                SourceRect = new Rectangle(0, 0,
                    _GasketImage.Width,
                    _GasketImage.Height);
            }
        }
        public static PointF GasketCenter;

        public PointF Center;
        public float Radius;
        public Circle(float new_x, float new_y, float new_radius)
        {
            Center = new PointF(new_x, new_y);
            Radius = Math.Abs(new_radius);
        }

        // Return the circle's bounds.
        public RectangleF GetBounds()
        {
            return new RectangleF(
                Center.X - Radius, Center.Y - Radius,
                2 * Radius, 2 * Radius);
        }

        // Draw the circle.
        public void Draw(Graphics gr, Pen pen)
        {
            if (Radius < 1) return;
            if (_GasketImage != null)
            {
                GraphicsState state = gr.Save();
                gr.ResetTransform();
                float dx = Center.X - GasketCenter.X;
                float dy = Center.Y - GasketCenter.Y;
                float angle = 0;
                if ((dx != 0) || (dy != 0))
                {
                    angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
                    angle += 90;
                }
                gr.RotateTransform(angle);
                gr.TranslateTransform(Center.X, Center.Y, MatrixOrder.Append);

                PointF[] dest_points =
                    {
                        new PointF(-Radius, -Radius),
                        new PointF(+Radius, -Radius),
                        new PointF(-Radius, +Radius),
                    };
                gr.DrawImage(_GasketImage,
                    dest_points, SourceRect, GraphicsUnit.Pixel);
                gr.Restore(state);
            }
            gr.DrawEllipse(pen, GetBounds());
        }

        // Return a textual representation.
        public override string ToString()
        {
            return String.Format("({0}, {1}), {2}", Center.X, Center.Y, Radius);
        }
    }

}