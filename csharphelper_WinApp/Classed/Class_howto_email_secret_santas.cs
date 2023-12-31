
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_email_secret_santas

 { 

public static class RandomizationExtensions
    {
        private static Random Rand = new Random();

        // Randomize an array.
        public static void Randomize<T>(this T[] items)
        {
            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = Rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        // Randomize a list.
        public static void Randomize<T>(this List<T> items)
        {
            // Convert into an array.
            T[] item_array = items.ToArray();

            // Randomize.
            item_array.Randomize();

            // Copy the items back into the list.
            items.Clear();
            items.AddRange(item_array);
        }
    }

}