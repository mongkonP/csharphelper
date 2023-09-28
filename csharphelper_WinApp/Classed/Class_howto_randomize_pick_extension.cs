
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_randomize_pick_extension

 { 

public static class ArrayExtensions
    {
        // The random number generator.
        private static Random Rand = new Random();

        // Return a random item from an array.
        public static T RandomElement<T>(this T[] items)
        {
            // Return a random item.
            return items[Rand.Next(0, items.Length)];
        }

        // Return a random item from a list.
        public static T RandomElement<T>(this List<T> items)
        {
            // Return a random item.
            return items[Rand.Next(0, items.Count)];
        }
    }

}