
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_pick_random_object

 { 

public static class RandomTools
    {
        // The Random object this method uses.
        private static Random Rand = null;

        // Return a random value.
        public static T PickRandom<T>(this T[] values)
        {
            // Create the Random object if it doesn't exist.
            if (Rand == null) Rand = new Random();

            // Pick an item and return it.
            return values[Rand.Next(0, values.Length)];
        }
    }

}