
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  namespace  howto_named_parameters

 { 

class Person
    {
        public string Name, Address, Email, SmsPhone, VoicePhone, Fax;

        public Person(string name, string address = "", string email = "",
            string sms_phone = "", string voice_phone = "", string fax = "")
        {
            Name = name;
            Address = address;
            Email = email;
            SmsPhone = sms_phone;
            VoicePhone = voice_phone;
            Fax = fax;
        }
    }

}