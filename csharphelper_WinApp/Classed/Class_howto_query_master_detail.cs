
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_query_master_detail

 { 

public class Student
    {
        public long StudentId;
        public string FirstName, LastName;

        public Student(long student_id, string first_name, string last_name)
        {
            StudentId = student_id;
            FirstName = first_name;
            LastName = last_name;
        }

        // Help the ComboBox display the student's name.
        public override string ToString()
        {
            return LastName + ", " + FirstName;
        }
    }

}