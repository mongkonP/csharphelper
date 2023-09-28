
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_rectangle_extensions

 { 

public static class RectangleExtensions
    {
        public static int MidX(this Rectangle rect)
        {
            return rect.Left + rect.Width / 2;
        }
        public static int MidY(this Rectangle rect)
        {
            return rect.Top + rect.Height / 2;
        }
        public static Point Center(this Rectangle rect)
        {
            return new Point(rect.MidX(), rect.MidY());
        }

        public static float MidX(this RectangleF rect)
        {
            return rect.Left + rect.Width / 2;
        }
        public static float MidY(this RectangleF rect)
        {
            return rect.Top + rect.Height / 2;
        }
        public static PointF Center(this RectangleF rect)
        {
            return new PointF(rect.MidX(), rect.MidY());
        }
    }

}