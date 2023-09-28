
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

  namespace  howto_bitarray_extensions

 { 

static class BitArrayExtensions
    {
        // Return the number of true values in the BitArray.
        static public int NumTrue(this BitArray bits)
        {
            int count = 0;
            foreach (bool value in bits) if (value) count++;
            return count;
        }
        static public int NumFalse(this BitArray bits)
        {
            return bits.Count - bits.NumTrue();
        }

        // Return the logical And of all of the entries in the array.
        static public bool AndAll(this BitArray bits)
        {
            foreach (bool value in bits) if (!value) return false;
            return true;
        }

        // Return the logical Or of all of the entries in the array.
        static public bool OrAll(this BitArray bits)
        {
            foreach (bool value in bits) if (value) return true;
            return false;
        }

        // Return a string showing the BitArray's values.
        static public string ToString(this BitArray bits, string true_value, string false_value, string separator, int group_size, string group_separator)
        {
            string result = "";
            for (int i = 0; i < bits.Length; i++)
            {
                // Add the value and separator.
                if (bits[i]) result += separator + true_value;
                else result += separator + false_value;

                // Add the group separator if appropriate.
                if ((i + 1) % group_size == 0) result += group_separator;
            }

            // Remove the initial separator.
            if (result.Length > 0) result = result.Substring(separator.Length);
            return result;
        }
        static public string ToString(this BitArray bits, string true_value, string false_value, string separator)
        {
            return ToString(bits, true_value, false_value, separator, int.MaxValue, "");
        }
        static public string ToString(this BitArray bits, string true_value, string false_value)
        {
            return ToString(bits, true_value, false_value, "");
        }
    }

}