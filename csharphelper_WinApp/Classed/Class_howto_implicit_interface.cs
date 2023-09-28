
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_implicit_interface

 { 

public class Person : IComparable<Person>
    {
        public string FirstName, LastName;
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        #region IComparable<Person> Members

        public int CompareTo(Person other)
        {
            return ToString().CompareTo(other.ToString());
            //throw new NotImplementedException();
        }

        #endregion
    }

}