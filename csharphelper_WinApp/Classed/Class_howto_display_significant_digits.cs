
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_display_significant_digits

 { 

public static class DoubleStuff             // No, not Oreos! Stuff to do with doubles.
    {
        // Format the value with the indicated number of significant digits.
        public static string ToSignificantDigits(this double value, int significant_digits)
        {
            // Use G format to get significant digits.
            // Then convert to double and use F format.
            string format1 = "{0:G" + significant_digits.ToString() + "}";
            string result = Convert.ToDouble(String.Format(format1, value)).ToString("F99");

            // Remove trailing 0s.
            result = result.TrimEnd('0');

            // Remove the decimal point and leading 0s,
            // leaving just the digits.
            string test = result.Replace(".", "").TrimStart('0');

            // See if we have enough significant digits.
            if (significant_digits > test.Length)
            {
                // Add trailing 0s.
                result += new string('0', significant_digits - test.Length);
            }
            else
            {
                // See if we should remove the trailing decimal point.
                if ((significant_digits < test.Length) && result.EndsWith("."))
                        result = result.Substring(0, result.Length - 1);
            }

            return result;
        }
    }

}