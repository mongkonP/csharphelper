
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_unique_list

 { 

public class Person : IEquatable<Person>
    {
        public string FirstName, LastName;
        public Person(string first_name, string last_name)
        {
            FirstName = first_name;
            LastName = last_name;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public bool Equals(Person other)
        {
            if (other == null) return false;
            if (FirstName != other.FirstName) return false;
            if (LastName != other.LastName) return false;
            return true;
        }
    }

}