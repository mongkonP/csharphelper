
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_treeview_tooltips

 { 

public class FactoryData
    {
        public string Name = "";

        // Initializing constructor.
        public FactoryData(string new_name)
        {
            Name = new_name;
        }
    }








    public class GroupData
    {
        public string Name = "";
        public List<string> Projects = new List<string>();

        // Initializing constructor.
        public GroupData(string new_name, params string[] project_names)
        {
            Name = new_name;
            for (int i = 0; i <= project_names.GetUpperBound(0); i++)
            {
                Projects.Add(project_names[i]);
            }
        }
    }








    public class PersonData
    {
        public string Name = "";
        public List<string> Projects = new List<string>();

        // Initializing constructor.
        public PersonData(string new_name, params string[] project_names)
        {
            Name = new_name;
            for (int i = 0; i <= project_names.GetUpperBound(0); i++)
            {
                Projects.Add(project_names[i]);
            }
        }
    }

}