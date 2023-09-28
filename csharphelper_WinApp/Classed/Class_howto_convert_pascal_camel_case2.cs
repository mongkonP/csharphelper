
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

  namespace  howto_convert_pascal_camel_case2

 { 

public static class StringExtensions
    {
        // Convert the string to Pascal case.
        public static string ToPascalCase(this string the_string)
        {
            TextInfo info = Thread.CurrentThread.CurrentCulture.TextInfo;
            the_string = info.ToTitleCase(the_string);
            string[] parts = the_string.Split(new char[] {},
                StringSplitOptions.RemoveEmptyEntries);
            string result = String.Join(String.Empty, parts);
            return result;
        }

        // Convert the string to camel case.
        public static string ToCamelCase(this string the_string)
        {
            the_string = the_string.ToPascalCase();
            return the_string.Substring(0, 1).ToLower() + the_string.Substring(1);
        }

        // Capitalize the first character and add a space before
        // each capitalized letter (except the first character).
        public static string ToProperCase(this string the_string)
        {
            const string pattern = @"(?<=\w)(?=[A-Z])";
            //const string pattern = @"(?<=[^A-Z])(?=[A-Z])";
            string result = Regex.Replace(the_string, pattern, " ", RegexOptions.None);
            return result.Substring(0, 1).ToUpper() + result.Substring(1);
        }
    }

}