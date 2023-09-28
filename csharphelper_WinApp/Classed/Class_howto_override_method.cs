
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

  namespace  howto_override_method

 { 

public class Employee : Person
    {
        public string MailStop;

        // Initializing constructor.
        public Employee(string firstName, string lastName, string street,
            string city, string state, string zip, string mailStop)
            : base(firstName, lastName, street, city, state, zip)
        {
            MailStop = mailStop;
        }

        // Display the employee's address.
        public override void ShowAddress()
        {
            string txt = FirstName + " " + LastName + '\n' +
                Street + '\n' +
                City + "  " + State + "  " + Zip + '\n' +
                MailStop;
            MessageBox.Show(txt, "Employee Address",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }










    public class Person
    {
        public string FirstName, LastName, Street, City, State, Zip;

        // Initializing constructor.
        public Person(string firstName, string lastName, string street,
            string city, string state, string zip)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

        // Display the person's address.
        public virtual void ShowAddress()
        {
            string txt = FirstName + " " + LastName + '\n' +
                Street + '\n' +
                City + "  " + State + "  " + Zip;
            MessageBox.Show(txt, "Person Address",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }

}