
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

  namespace  howto_calculate_earth_distances

 { 

class CityData
    {
        public string Name;
        public double Latitude, Longitude;

        // Constructors.
        public CityData(string name,
            int lat_degrees, int lat_minutes, int lat_seconds,
            int long_degrees, int long_minutes, int long_seconds)
        {
            Latitude = lat_degrees + lat_minutes / 60 + lat_seconds / 3600;
            Longitude = long_degrees + long_minutes / 60 + long_seconds / 3600;
        }
        public CityData(string name,
            int lat_degrees, int lat_minutes,
            int long_degrees, int long_minutes)
            : this(name,
                lat_degrees, lat_minutes, 0,
                long_degrees, long_minutes, 0)
        {
        }
        // Initialize with data of the form: "Delhi 	28°40?N 77°14?E"
        // Data in this format is available at:
        // http://en.wikipedia.org/wiki/Latitude_and_longitude_of_cities
        public CityData(string data)
        {
            // Find the first digit.
            Regex reg_exp = new Regex(@"\d");
            Match match = reg_exp.Match(data);
            int pos = match.Index;

            // Assign the name.
            Name = data.Substring(0, pos - 1).Trim();

            // Parse the latitude.
            data = data.Substring(pos);
            pos = data.IndexOf('°');
            double lat_degrees = double.Parse(data.Substring(0, pos));
            data = data.Substring(pos + 1);

            pos = data.IndexOf('′');
            double lat_minutes = double.Parse(data.Substring(0, pos));
            data = data.Substring(pos + 1);
            Latitude = lat_degrees + lat_minutes / 60;

            if (data.Substring(0, 1).ToUpper() == "S") Latitude = -Latitude;
            data = data.Substring(1).Trim();

            // Parse the latitude.
            pos = data.IndexOf('°');
            double long_degrees = double.Parse(data.Substring(0, pos));
            data = data.Substring(pos + 1);

            pos = data.IndexOf('′');
            double long_minutes = double.Parse(data.Substring(0, pos));
            data = data.Substring(pos + 1);
            Longitude = long_degrees + long_minutes / 60;
            if (data.Substring(0, 1).ToUpper() == "E") Longitude = -Longitude;
        }
    }

}