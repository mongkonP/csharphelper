
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_colored_sierpinski_pentagon

 { 

class Pentagon
    {
        public PointF[] Points = null;
        public Color FillColor = Color.Black;

        // Constructor.
        public Pentagon(PointF[] points, Color fill_color)
        {
            Points = points;
            FillColor = fill_color;
        }

        // Draw.
        public void Draw(Graphics gr)
        {
            using (Brush brush = new SolidBrush(FillColor))
            {
                gr.FillPolygon(brush, Points);
            }
        }

        // Return true if the pentagon inclides this point.
        public bool Contains(PointF point)
        {
            return PointInPolygon(point);
        }

        #region PointInPolygon Code
        // See http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/

        // Return true if the point is in the polygon.
        private bool PointInPolygon(PointF  point)
        {
            // Get the angle between the point and the
            // first and last vertices.
            int max_point = Points.Length - 1;
            float total_angle = GetAngle(
                Points[max_point].X, Points[max_point].Y,
                point.X, point.Y,
                Points[0].X, Points[0].Y);

            // Add the angles from the point
            // to each other pair of vertices.
            for (int i = 0; i < max_point; i++)
            {
                total_angle += GetAngle(
                    Points[i].X, Points[i].Y,
                    point.X, point.Y,
                    Points[i + 1].X, Points[i + 1].Y);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            return (Math.Abs(total_angle) > 0.000001);
        }

        // Return the angle ABC between PI and -PI.
        private static float GetAngle(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the dot product.
            float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

            // Get the cross product.
            float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

            // Calculate the angle.
            return (float)Math.Atan2(cross_product, dot_product);
        }

        // Return the dot product AB · BC.
        private static float DotProduct(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the dot product.
            return (BAx * BCx + BAy * BCy);
        }

        // Return the length of the cross product AB x BC.
        private static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        #endregion PointInPolygon Code
    }

}