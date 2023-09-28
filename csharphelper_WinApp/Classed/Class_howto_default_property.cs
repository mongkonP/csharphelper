
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_default_property

 { 

// A collection holding a class's grades.


    public class GradeCollection
    {
        // A Dictionary to hold student grades.
        private Dictionary<string, int> Grades = new Dictionary<string, int>();

        // The default indexer property.
        // Get or set a student's grade.
        public int this[string student]
        {
            get
            {
                return Grades[student];
            }
            set
            {
                Grades[student] = value;
            }
        }

        // A default indexer property.
        // Return a list students with this grade.
        public List<string> this[int score]
        {
            get
            {
                List<string> students = new List<string>();
                foreach (string name in Grades.Keys)
                {
                    if (Grades[name] == score) students.Add(name);
                }
                return students;
            }
        }
    }

}