using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace csharphelper._Class
{
 public    class classGenerate
    {
        string _file;
       public  string code_cs, ClassName, name_space;
        public Dictionary<string, string> Methods = new Dictionary<string, string>();
        public string MethodinFile;

        public classGenerate(string f)
        {
            _file = f;
            using (StreamReader reader = new StreamReader(_file))
            {
                code_cs = reader.ReadToEnd().Trim();
                ClassName = new Regex(@"class(.*?)\n", RegexOptions.None).Matches(code_cs)[0].Groups[1].Value.Trim();
                name_space = new Regex(@"namespace(.*?)\n", RegexOptions.None).Matches(code_cs)[0].Groups[1].Value.Trim();
                reader.Dispose();
                reader.Close();
            }
            MethodinFile = new Regex(@"(using[\w\W]{0,}[\n\s]{0,}namespace.*?[\n\s]{0,}{[\n\s]{0,}.*?class.*?[\n\s]{0,}{)", RegexOptions.None)
                        .Replace(code_cs, "")
                        .Trim().TrimEnd('}').Trim().TrimEnd('}');

            int a = 0, b = 0, c = 0,d=1 ;
            string method_name,ss;
            for (int i = 1; i < MethodinFile.Length - 1; i++)
            {
                if (MethodinFile.Substring(i,1) == "{")
                    a++;
                else if (MethodinFile.Substring(i, 1) == "}")
                    b++;


                if (a == b && !(a==0|| b==0))
                {
                    ss = MethodinFile.Substring(c, i - c) + "\n }";
                    method_name = GetMethodName(ss);
                   Methods.Add(method_name, ss);
                    c = i+1;
                    a = 0; b = 0;
                    d++;
                }



            }
        }

        string GetMethodName(string _m)
        {

            string r = "";
            foreach (Match myMatch in new Regex(@"(.*?)\(", RegexOptions.None).Matches(_m))
            {
                if (myMatch.Groups[1].Value.Trim().IndexOf("public")>=0 ||
                    myMatch.Groups[1].Value.Trim().IndexOf("void") >=0 ||
                    myMatch.Groups[1].Value.Trim().IndexOf("private") >=0)
                {

                    r= myMatch.Groups[1].Value.Trim();
                   // MessageBox.Show( _m + "\n\n\n\n" + r + "\n Have");
                    return r;
                }
            }

            MessageBox.Show(_m + "\n\n\n\n" + r + "\n No Have");
            return r;
        }
    }
}
