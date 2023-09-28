
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

  namespace  howto_validate_ssn_extension

 { 

public static class StringExtensions
    {
        public static bool Matches(this string value, string expression)
        {
            return Regex.IsMatch(value, expression);
        }

        public static bool IsValidSsnWithDashes(this string value)
        {
            return value.Matches(@"^\d{3}-\d{2}-\d{4}$");
        }

        public static bool IsValidSsnWithoutDashes(this string value)
        {
            return Regex.IsMatch(value, @"^\d{9}$");
        }

        public static bool IsValidSsn(this string value)
        {
            return value.Matches(@"^(?:\d{9}|\d{3}-\d{2}-\d{4})$");
        }
    }

}