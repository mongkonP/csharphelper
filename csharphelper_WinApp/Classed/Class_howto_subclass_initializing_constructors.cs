
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_subclass_initializing_constructors

 { 

public class Employee : Person
    {
        public string MailStop;

        // Initializing constructor.
        public Employee(string firstName, string lastName,
            string street, string city, string state,
            string zip, string mailStop)
            : base(firstName, lastName, street, city, state, zip)
        {
            MailStop = mailStop;
        }
    }








    public class Person
    {
        public string FirstName, LastName, Street, City, State, Zip;

        // Initializing constructor.
        public Person(string firstName, string lastName,
            string street, string city, string state, string zip)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }
    }

}