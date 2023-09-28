
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_override_tostring

 { 

// A simple Person class.
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }








    // A Person class that overrides ToString.
    public class Person2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        // Override ToString to return the Person's name.
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

}