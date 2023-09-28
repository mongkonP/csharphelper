
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

  namespace  howto_use_json

 { 

// Add a reference to System.Runtime.Serialization.


// Add a reference to System.ServiceModel.Web.





    [Serializable]
    public class Customer
    {
        [DataMember]
        public string Name = "";

        [DataMember]
        public string Street = "";

        [DataMember]
        public string City = "";

        [DataMember]
        public string State = "";

        [DataMember]
        public string Zip = "";

        [DataMember]
        public Dictionary<string, string> PhoneNumbers = new Dictionary<string, string>();

        [DataMember]
        public List<string> EmailAddresses = new List<string>();

        [DataMember]
        public Order[] Orders = null;

        // Return the JSON serialization of the object.
        public string ToJson()
        {
            // Make a stream to serialize into.
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                // Serialize into the stream.
                DataContractJsonSerializer serializer
                    = new DataContractJsonSerializer(typeof(Customer));
                serializer.WriteObject(stream, this);
                stream.Flush();

                // Get the result as text.
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        // Create a new Customer from a JSON serialization.
        public static Customer FromJson(string json)
        {
            // Make a stream to read from.
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;

            // Deserialize from the stream.
            DataContractJsonSerializer serializer
                = new DataContractJsonSerializer(typeof(Customer));
            Customer cust = (Customer)serializer.ReadObject(stream);

            // Return the result.
            return cust;
        }

        // Return a newline separated text representation.
        public override string ToString()
        {
            // Display the basic information.
            string result = "Customer" + Environment.NewLine;
            result += "    " + Name + Environment.NewLine;
            result += "    " + Street + Environment.NewLine;
            result += "    " + City + " " + State + " " + Zip + Environment.NewLine;

            // Display phone numbers.
            result += "    Phone Numbers:" + Environment.NewLine;
            foreach (KeyValuePair<string, string> pair in PhoneNumbers)
            {
                result += "        " + pair.Key + ": " + pair.Value + Environment.NewLine;
            }

            // Display email addresses.
            result += "    Email Addresses:" + Environment.NewLine;
            foreach (string address in EmailAddresses)
            {
                result += "        " + address + Environment.NewLine;
            }

            // Display orders.
            result += "    Orders:" + Environment.NewLine;
            foreach (Order order in Orders)
            {
                result += "        " + order.ToString() + Environment.NewLine;
            }

            return result;
        }
    }





// Add a reference to System.Runtime.Serialization.



    [Serializable]
    public class Order
    {
        [DataMember]
        public string Description;

        [DataMember]
        public int Quantity;

        [DataMember]
        public decimal Price;

        // Return a textual representation of the order.
        public override string ToString()
        {
            decimal total = Quantity * Price;
            return Description + ": " +
                Quantity.ToString() + " @ " +
                Price.ToString("C") + " = " +
                total.ToString("C");
        }
    }

}