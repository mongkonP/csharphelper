
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

  namespace  howto_clone_with_serialization

 { 

public static class CloneStuff
    {
        // Return a deep clone of an object of type T.
        public static T DeepClone<T>(this T obj)
        {
            using (MemoryStream memory_stream = new MemoryStream())
            {
                // Serialize the object into the memory stream.
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memory_stream, obj);

                // Rewind the stream and use it to create a new object.
                memory_stream.Position = 0;
                return (T)formatter.Deserialize(memory_stream);
            }
        }
    }










    [Serializable()]
    class Person : ICloneable
    {
        private string _FirstName;
        [Description("The person's first or given name")]
        [Category("Name")]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        private string _LastName;
        [Description("The person's last or family name")]
        [Category("Name")]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        private StreetAddress _Address;
        [Description("The person's street address")]
        [Category("Contact Info")]
        public StreetAddress Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        private string _Email;
        [Description("The person's primary email address")]
        [Category("Contact Info")]
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        private string _Phone;
        [Description("The person's business phone number")]
        [Category("Contact Info")]
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }

        // Return the Person as a string for display purposes.
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        // Types of clones.
        public enum CloneType
        {
            Shallow,
            Deep
        }

        // Make a clone of the person.
        public Person Clone(CloneType clone_type)
        {
            // Make a shallow clone.
            Person new_person = (Person)MemberwiseClone();

            // If this should be a deep clone, make a new Address object.
            if (clone_type == CloneType.Deep)
            {
                new_person.Address = (StreetAddress)Address.Clone();
            }

            // Return the new Person.
            return new_person;
        }

        #region ICloneable Members

        // Make a deep clone of the person.
        public object Clone()
        {
            return Clone(CloneType.Deep);
        }

        #endregion
    }










    [TypeConverter(typeof(StreetAddressConverter))]
    [Serializable()]
    class StreetAddress : ICloneable
    {
        private string _Street;
        [Description("The street number, name, apartment number, etc. as in '123 N. Elm Ave Suite 21'")]
        public string Street
        {
            get
            {
                return _Street;
            }
            set
            {
                _Street = value;
            }
        }

        private string _City;
        [Description("The mailing address city")]
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        private string _State;
        [Description("The two-letter state abbreviation")]
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        private string _Zip;
        [Description("The postal ZIP or ZIP+4 code")]
        public string Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                _Zip = value;
            }
        }

        // Return as a comma-delimited string.
        public override string ToString()
        {
            return Street + "," + City + "," + State + "," + Zip;
        }

        #region ICloneable Members

        // This class has no reference type properties
        // so a shallow clone is the same as a deep clone.
        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }










    class StreetAddressConverter : TypeConverter
    {
        // Return true if we need to convert from a string.
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        // Return true if we need to convert into a string.
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(String)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        // Convert from a string.
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                // Split the string separated by commas.
                string txt = (string)(value);
                string[] fields = txt.Split(new char[] { ',' });

                try
                {
                    return new StreetAddress() { Street = fields[0], City = fields[1], State = fields[2], Zip = fields[3] };
                }
                catch
                {
                    throw new InvalidCastException(
                        "Cannot convert the string '" +
                        value.ToString() + "' into a StreetAddress");
                }
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }

        // Convert the StreetAddress to a string.
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string)) return value.ToString();
            return base.ConvertTo(context, culture, value, destinationType);
        }

        // Return true to indicate that the object supports properties.
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        // Return a property description collection.
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }
    }

}