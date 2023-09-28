
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

  namespace  howto_show_locale_dates

 { 

// A class to store cultre data.
    public class CultureData
    {
        // The CultureInfo.
        public CultureInfo Info;

        // Initializing constructor.
        public CultureData(CultureInfo info)
        {
            Info = info;
        }

        // Return the name.
        public override string ToString()
        {
            return Info.EnglishName + "\t" + Info.NativeName;
        }
    }

}