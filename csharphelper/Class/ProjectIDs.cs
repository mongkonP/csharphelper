using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharphelper.Class
{
    public static class ProjectIDs
    {
        public static List<string> _ProjectIDs = new List<string>();
        public static string GetProjectID()
        {
            Thread.Sleep(100);
            string codeID = new ProjectID().ToHex();
            // "C6449F7E-FC74-4F9C-82B6-853F7A4C2634"
            if (_ProjectIDs.Contains(codeID))
            {
                return GetProjectID();

            }
            else
            {
                return codeID;
                _ProjectIDs.Add(codeID);
            }
        }

    }
}
