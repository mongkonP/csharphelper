
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_explicit_interface

 { 

public class Person : IComparable<Person>
    {
        public string FirstName, LastName;
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        #region IComparable<Person> Members

        int IComparable<Person>.CompareTo(Person other)
        {
            return ToString().CompareTo(other.ToString());
            //throw new NotImplementedException();
        }

        #endregion
    }

}