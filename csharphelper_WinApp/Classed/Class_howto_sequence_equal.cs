
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_sequence_equal

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

        // IEquatable<Person>
        public bool Equals(Person other)
        {
            // If other is null, we're not equal.
            if (Object.ReferenceEquals(other, null)) return false;

            // If the references are the same, we are equal.
            if (Object.ReferenceEquals(this, other)) return true;

            // We're equal if the names are equal.
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }
    }

}