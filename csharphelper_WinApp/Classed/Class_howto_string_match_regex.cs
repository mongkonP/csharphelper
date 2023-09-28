
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

  namespace  howto_string_match_regex

 { 

// Extension methods must be defined in a non-generic static class.




    static class StringExtensions
    {
        // Extension to add a Matches method to the string class.
        public static bool Matches(this string the_string, string pattern)
        {
            Regex reg_exp = new Regex(pattern);
            return reg_exp.IsMatch(the_string);
        }
    }

}