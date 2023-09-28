
using System;
using System.Collections.Generic;

  namespace  howto_send_sms

 { 

public class CarrierInfo
    {
        public string CarrierAbbreviation, CarrierName;
        public List<string> Emails = new List<string>();

        public override string ToString()
        {
            return CarrierName;
        }
    }






    public class CountryInfo
    {
        public string CountryAbbreviation, CountryName;
        public List<CarrierInfo> Carriers = new List<CarrierInfo>();

        public override string ToString()
        {
            return CountryName;
        }
    }

}