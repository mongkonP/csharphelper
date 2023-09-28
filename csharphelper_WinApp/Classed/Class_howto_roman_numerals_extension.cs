
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_roman_numerals_extension

 { 

public static class RomanNumerals
    {
        // Convert Arabic to Roman.
        public static string ToRoman(this int arabic)
        {
            return ArabicToRoman(arabic);
        }

        // Convert Roman to Arabic.
        public static int ToArabic(this string roman)
        {
            return RomanToArabic(roman);
        }

        // Maps letters to numbers.
        private static Dictionary<char, int> CharValues = null;

        // Convert Roman numerals to an integer.
        private static int RomanToArabic(string roman)
        {
            // Initialize the letter map.
            if (CharValues == null)
            {
                CharValues = new Dictionary<char, int>();
                CharValues.Add('I', 1);
                CharValues.Add('V', 5);
                CharValues.Add('X', 10);
                CharValues.Add('L', 50);
                CharValues.Add('C', 100);
                CharValues.Add('D', 500);
                CharValues.Add('M', 1000);
            }

            if (roman.Length == 0) return 0;
            roman = roman.ToUpper();

            // See if the number begins with (.
            if (roman[0] == '(')
            {
                // Find the closing parenthesis.
                int pos = roman.LastIndexOf(')');

                // Get the value inside the parentheses.
                string part1 = roman.Substring(1, pos - 1);
                string part2 = roman.Substring(pos + 1);
                return 1000 * RomanToArabic(part1) + RomanToArabic(part2);
            }

            // The number doesn't begin with (.
            // Convert the letters' values.
            int total = 0;
            int last_value = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int new_value = CharValues[roman[i]];

                // See if we should add or subtract.
                if (new_value < last_value)
                    total -= new_value;
                else
                {
                    total += new_value;
                    last_value = new_value;
                }
            }

            // Return the result.
            return total;
        }

        // Map digits to letters.
        private static string[] ThouLetters = { "", "M", "MM", "MMM" };
        private static string[] HundLetters = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static string[] TensLetters = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static string[] OnesLetters = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        // Convert Roman numerals to an integer.
        private static string ArabicToRoman(int arabic)
        {
            // See if it's >= 4000.
            if (arabic >= 4000)
            {
                // Use parentheses.
                int thou = arabic / 1000;
                arabic %= 1000;
                return "(" + ArabicToRoman(thou) + ")" + ArabicToRoman(arabic);
            }

            // Otherwise process the letters.
            string result = "";

            // Pull out thousands.
            int num;
            num = arabic / 1000;
            result += ThouLetters[num];
            arabic %= 1000;

            // Handle hundreds.
            num = arabic / 100;
            result += HundLetters[num];
            arabic %= 100;

            // Handle tens.
            num = arabic / 10;
            result += TensLetters[num];
            arabic %= 10;

            // Handle ones.
            result += OnesLetters[arabic];

            return result;
        }
    }

}