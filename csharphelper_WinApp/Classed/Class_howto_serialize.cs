
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

  namespace  howto_serialize

 { 

// The class must be Serializable and public.
    [Serializable()]
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string Street;
        public string City;
        public string State;
        public string Zip;

        // Empty constructor required for serialization.
        public Person()
        {
        }

        // Initializing constructor.
        public Person(string first_name, string last_name,
            string street, string city, string state, string zip)
        {
            FirstName = first_name;
            LastName = last_name;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }
    }

}