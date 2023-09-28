
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_cast_arrays

 { 

class Employee : Person
    {
        public int EmployeeId;
        public Employee(string first_name, string last_name, int id)
            : base(first_name, last_name)
        {
            EmployeeId = id;
        }
        public string GetName()
        {
            return base.GetName() + " [" + EmployeeId.ToString() + "]";
        }
    }








    class Person
    {
        public string FirstName, LastName;
        public Person(string first_name, string last_name)
        {
            FirstName = first_name;
            LastName = last_name;
        }
        public string GetName()
        {
            return FirstName + " " + LastName;
        }
    }

}