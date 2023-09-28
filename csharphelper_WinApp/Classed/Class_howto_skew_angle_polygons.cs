
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_skew_angle_polygons

 { 

public static class Extensions
    {
        public static void DrawDashedLine(this Graphics gr,
            Color color1, Color color2, float thickness,
            float[] dash_pattern,
            PointF point1, PointF point2)
        {
            using (Pen pen = new Pen(color1, thickness))
            {
                gr.DrawLine(pen, point1, point2);
                pen.Color = color2;
                pen.DashPattern = dash_pattern;
                gr.DrawLine(pen, point1, point2);
            }
        }

        public static void DrawDot(this Graphics gr,
            Pen pen, PointF point, float radius)
        {
            gr.DrawEllipse(pen,
                point.X - radius / 2,
                point.Y - radius / 2,
                radius,
                radius);
        }
    }

}