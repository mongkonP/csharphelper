
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_make_random_polygon

 { 

public static class RandomExtensions
    {
        // Return a random value between 0 inclusive and max exclusive.
        public static double NextDouble(this Random rand, double max)
        {
            return rand.NextDouble() * max;
        }

        // Return a random value between min inclusive and max exclusive.
        public static double NextDouble(this Random rand, double min, double max)
        {
            return min + (rand.NextDouble() * (max - min));
        }
    }










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

        public static float MidX(this RectangleF rect)
        {
            return rect.Left + rect.Width / 2;
        }
        public static float MidY(this RectangleF rect)
        {
            return rect.Top + rect.Height / 2;
        }
    }

}