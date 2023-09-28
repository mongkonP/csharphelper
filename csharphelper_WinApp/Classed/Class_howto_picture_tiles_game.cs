
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_picture_tiles_game

 { 

class Piece
    {
        public Bitmap Picture;
        public Rectangle HomeLocation, CurrentLocation;

        public Piece(Bitmap new_picture, Rectangle home_location)
        {
            Picture = new_picture;
            HomeLocation = home_location;
        }

        // Return true if the piece is in its home position.
        public bool IsHome()
        {
            return HomeLocation.Equals(CurrentLocation);
        }

        // Return true if this position is within
        // the piece's current location.
        public bool Contains(Point pt)
        {
            return CurrentLocation.Contains(pt);
        }

        // If the piece is close to its
        // home position, move it there.
        public bool SnapToHome()
        {
            if ((Math.Abs(CurrentLocation.X - HomeLocation.X) < 20) &&
                (Math.Abs(CurrentLocation.Y - HomeLocation.Y) < 20))
            {
                CurrentLocation = HomeLocation;
                return true;
            }
            return false;
        }
    }

}