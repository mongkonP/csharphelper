
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_list_set_operations

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

        // The Intersect method seems to use the hash code.
        // IEquatable doesn't require you to override
        // GetHashCode but you must to make Intersect work.
        public override int GetHashCode()
        {
            int hashcode1 = (FirstName == null) ? 0 : FirstName.GetHashCode();
            int hashcode2 = (LastName == null) ? 0 : LastName.GetHashCode();
            return hashcode1 ^ ~hashcode2;
        }
    }

}