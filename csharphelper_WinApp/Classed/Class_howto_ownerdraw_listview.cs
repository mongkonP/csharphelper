
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_ownerdraw_listview

 { 

class ServerStatus
    {
        public string ServerName;
        public Image Logo;
        public Color StatusColor;

        public ServerStatus(string serverName, Image logo, Color statusColor)
        {
            ServerName = serverName;
            Logo = logo;
            StatusColor = statusColor;
        }
    }

}