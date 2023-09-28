using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharphelper.Class
{
  public   class FileReplace
    {
        public string oldString;
        public string newString;

        public FileReplace(string o, string n)
        {
            oldString = o;newString = n;
        }
    }
}
