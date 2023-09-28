
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_great_circle_distance

 { 

public class LatLon
    {
        public string Name, Lat, Lon;
        public LatLon(string name, string lat, string lon)
        {
            Name = name;
            Lat = lat;
            Lon = lon;
        }
        public override string ToString()
        {
            return Name;
        }
    }

}