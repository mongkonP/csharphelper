
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_random_extensions

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

}