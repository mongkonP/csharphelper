
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_sort_arrays

 { 

class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        // Compare two Person's names.
        public int CompareTo(Person person)
        {
            return ToString().CompareTo(person.ToString());
        }
    }








    class PersonComparer : IComparer<Person>
    {
        // Compare two Persons.
        public int Compare(Person person1, Person person2)
        {
            string name1 = person1.LastName + "," + person1.FirstName;
            string name2 = person2.LastName + "," + person2.FirstName;
            return name1.CompareTo(name2);
        }
    }

}