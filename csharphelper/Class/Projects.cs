using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharphelper.Class
{
    public class Projects
    {
        public string projectID { get; set; }
        public string projectName { get; set; }
        public string projectPath { get; set; }
        public Projects(string name, string path, string id)
        {
            projectID = id;
            projectName = name;
            projectPath = path;
        }
        public void SetNewID()
        {
            projectID =ProjectIDs.GetProjectID();
        }
    }
}
