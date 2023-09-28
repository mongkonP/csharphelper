
using System;
using System.Text.RegularExpressions;

  namespace  howto_timespan_tostring

 { 

public static class TimeSpanExtensions
    {
        // Add a ToString method to TimeSpan that accepts a format string.
        public static string ToString(this TimeSpan ts, string format)
        {
            string result = "";

            // Split the format string into
            // alphabetic and non-alphabetic pieces.
            Regex reg_exp = new Regex("[a-z]+|[^a-z]+");
            MatchCollection matches = reg_exp.Matches(format.ToLower());

            // Process the pieces.
            foreach (Match piece in matches)
            {
                // Make a format for the value.
                string piece_format = new string('0', piece.Value.Length);

                // Examine the piece's first character.
                switch (piece.Value[0])
                {
                    case 'd':       // Days.
                        result += ts.Days.ToString(piece_format);
                        break;
                    case 'h':       // Hours.
                        result += ts.Hours.ToString(piece_format);
                        break;
                    case 'm':       // Minutes.
                        result += ts.Minutes.ToString(piece_format);
                        break;
                    case 's':       // Seconds.
                        result += ts.Seconds.ToString(piece_format);
                        break;
                    case 'f':       // Fractional seconds.
                        // Get just the fractional seconds.
                        double fraction = ts.TotalSeconds - (int)ts.TotalSeconds;
                        // Move the needed digits to the left of the decimal point.
                        fraction *= Math.Pow(10, piece.Value.Length);
                        result += fraction.ToString(piece_format);
                        break;
                    default:        // A non-alphabetic piece. Use it as is.
                        result += piece.Value;
                        break;
                }
            }

            return result;
        }
    }

}