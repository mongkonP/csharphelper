
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

  namespace  howto_graph_currency_rates

 { 

class PriceData
    {
        public DateTime Date;
        public decimal Price;
        public PriceData(DateTime date, decimal price)
        {
            Date = date;
            Price = price;
        }

        public override string ToString()
        {
            return Date.ToShortDateString() + ": " + Price.ToString();
        }
    }







// Add a reference to System.Web.



    static class StringExtensions
    {
        // Extension to replace spaces with &nbsp;
        public static string SpaceToNbsp(this string s)
        {
            return s.Replace(" ", "&nbsp;");
        }

        // Url encode an ASCII string.
        public static string UrlEncode(this string s)
        {
            return HttpUtility.UrlEncode(s);
        }

        // Url decode an ASCII string.
        public static string UrlDecode(this string s)
        {
            return HttpUtility.UrlDecode(s);
        }
    }

}