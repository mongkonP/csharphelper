
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

  namespace  howto_remove_non_ascii

 { 

public static class StringStuff
    {
        public static string TrimNonAscii(this string value)
        {
            string pattern = "[^ -~]+";
            Regex reg_exp = new Regex(pattern);
            return reg_exp.Replace(value, "");
        }
    }

}