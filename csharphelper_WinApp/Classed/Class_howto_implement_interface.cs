
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_implement_interface

 { 

public class SortablePerson : IComparable
    {
        public string FirstName, LastName;

        public override string ToString()
        {
            return LastName + ", " + FirstName;
        }

        public int CompareTo(object obj)
        {
            SortablePerson other = obj as SortablePerson;
            return this.ToString().CompareTo(other.ToString());
        }
    }

}