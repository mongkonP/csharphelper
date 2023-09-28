
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_subarray_extensions

 { 

public static class ArrayExtensions
    {
        // Copy the indicated entries from an array into a new array.
        public static T[] SubArray<T>(this T[] values, int start_index, int end_index)
        {
            int num_items = end_index - start_index + 1;
            T[] result = new T[num_items];
            Array.Copy(values, start_index, result, 0, num_items);
            return result;
        }

        // Copy the indicated entries from a two-dimensional array into a new array.
        public static T[,] SubArray<T>(this T[,] values, int row_min, int row_max, int col_min, int col_max)
        {
            // Allocate the result array.
            int num_rows = row_max - row_min + 1;
            int num_cols = col_max - col_min + 1;
            T[,] result = new T[num_rows, num_cols];

            // Get the number of columns in the values array.
            int total_cols = values.GetUpperBound(1) + 1;
            int from_index = row_min * total_cols + col_min;
            int to_index = 0;
            for (int row = 0; row <= num_rows - 1; row++)
            {
                Array.Copy(values, from_index, result, to_index, num_cols);
                from_index += total_cols;
                to_index += num_cols;
            }

            return result;
        }

        // Copy the indicated entries from one two-dimensional
        // array into another two-dimensional array.
        public static void CopyTo<T>(this T[,] from_array, T[,] to_array,
            int from_row_min, int from_row_max, int from_col_min, int from_col_max,
            int to_row_min, int to_col_min)
        {
            // Get the number of columns in each array.
            int from_num_cols = from_array.GetUpperBound(1) + 1;
            int to_num_cols = to_array.GetUpperBound(1) + 1;

            // Get the number of rows and columns we will copy.
            int num_rows = from_row_max - from_row_min + 1;
            int num_cols = from_col_max - from_col_min + 1;

            // Initialize the indices for copying.
            int from_index = from_row_min * from_num_cols + from_col_min;
            int to_index = to_row_min * to_num_cols + to_col_min;

            // Copy.
            for (int row = 0; row <= num_rows - 1; row++)
            {
                Array.Copy(from_array, from_index, to_array, to_index, num_cols);
                from_index += from_num_cols;
                to_index += to_num_cols;
            }
        }
    }

}