using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharphelper.Class
{
  public   class FileClass: Component
    {
        private  string file;
        public string code;
        public FileClass(string f)
        {
            file = f;
            if (!File.Exists(f)) return;
           
            
            using (StreamReader reader = new StreamReader(f))
            {
                code = reader.ReadToEnd();

                reader.Dispose();
                reader.Close();
            }
        }
        public void Save()
        {
            using (StreamWriter writer = (!File.Exists(file)) ? new StreamWriter(File.Create(file)) : new StreamWriter(file))
            {
                writer.Write(code);
                System.Threading.Thread.Sleep(500);
            }

        }
        public void SaveAs(string f)
        {
            try
            {
                using (StreamWriter writer = (!File.Exists(f)) ? new StreamWriter(File.Create(f)) : new StreamWriter(f))
                {
                    writer.Write(code);
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch { }

        }

        public void NewNamespace(string _NewNamespace)
        {
            code = new Regex(@"(namespace[\n\s\w\._]{0,}){", RegexOptions.None).Replace(code, " \n\nnamespace "+_NewNamespace+" \n    {\n ");

        }
        public void AddUsing(string _using)
        {
            int i = code.IndexOf("namespace");
            code = code.Insert(i, _using + "\n");
        }
        
    }
}
