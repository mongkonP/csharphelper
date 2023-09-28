
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

  namespace  howto_use_serialization_attributes

 { 

[Serializable()]
    public class Person
    {
        [XmlAttributeAttribute("GivenName")]
        public string FirstName;
        [XmlAttributeAttribute("FamilyName")]
        public string LastName;
        [XmlElement("StreetAddress")]
        public string Street;

        public enum ContactMethods
        {
            [XmlEnum("SnailMail")]
            Post,
            [XmlEnum("Telephone")]
            Phone,
            [XmlEnum("Email")]
            Email
        }

        [XmlElement("ContactMethod")]
        public ContactMethods PreferredMethod;

        public string City;
        public string State;

        [XmlIgnore()]
        public string Zip;

        [XmlArray("PhoneNumbers"), XmlArrayItem("PhoneNum")]
        public string[] Phones = new string[1];

        [XmlArray("EmailAddresses")]
        public string[] Emails = new string[1];

        // Empty constructor required for serialization.
        public Person()
        {
        }

        // Initializing constructor.
        public Person(string first_name, string last_name, string street, string city, string state, string zip, string phone1, string phone2, string email1, string email2, ContactMethods contact_method)
        {
            FirstName = first_name;
            LastName = last_name;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Phones = new string[] { phone1, phone2 };
            Emails = new string[] { email1, email2 };
            PreferredMethod = contact_method;
        }
    }

}