
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_to_from_ragged

 { 

public static class ArrayExtensions
    {
        // Convert T[,] to T[][].
        public static T[][] ToRagged<T>(this T[,] values)
        {
            // Get the number of rows and columns.
            int num_rows = values.GetUpperBound(0) + 1;
            int num_cols = values.GetUpperBound(1) + 1;

            // Make the ragged array.
            T[][] result = new T[num_rows][];

            // Copy values into the ragged array.
            for (int r = 0; r < num_rows; r++)
            {
                result[r] = new T[num_cols];
                for (int c = 0; c < num_cols; c++)
                    result[r][c] = values[r, c];
            }

            return result;
        }

        // Convert T[][] to T[,].
        public static T[,] To2DArray<T>(this T[][] values)
        {
            // Get the number of rows.
            int num_rows = values.GetUpperBound(0) + 1;

            // Get the maximum number of columns in any row.
            int num_cols = 0;
            for (int r = 0; r < num_rows; r++)
                if (num_cols < values[r].Length)
                    num_cols = values[r].Length;

            // Make the two-dimensional array.
            T[,] result = new T[num_rows, num_cols];

            // Copy values into the ragged array.
            for (int r = 0; r < num_rows; r++)
            {
                for (int c = 0; c < values[r].Length; c++)
                    result[r, c] = values[r][c];
            }

            return result;
        }

        // Dump a ragged array into a string.
        public static string Dump<T>(this T[,] values,
            string col_separator, string row_separator)
        {
            int num_rows = values.GetUpperBound(0) + 1;
            int num_cols = values.GetUpperBound(1) + 1;
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < num_rows; r++)
            {
                for (int c = 0; c < num_cols; c++)
                {
                    sb.Append(values[r, c]);
                    if (c < num_cols - 1) sb.Append(col_separator);
                }
                sb.Append(row_separator);
            }
            return sb.ToString();
        }

        // Dump a ragged array into a string.
        public static string Dump<T>(this T[][] values,
            string col_separator, string row_separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (T[] row in values)
            {
                int num_rows = row.Length;
                for (int c = 0; c < num_rows; c++)
                {
                    sb.Append(row[c]);
                    if (c < num_rows - 1) sb.Append(col_separator);
                }
                sb.Append(row_separator);
            }
            return sb.ToString();
        }
    }

}