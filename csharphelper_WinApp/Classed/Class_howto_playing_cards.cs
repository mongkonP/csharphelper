
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_playing_cards

 { 

public class Card
    {
        public int Rank, Suit;
        public Bitmap Picture;

        public Card(int rank, int suit, Bitmap picture)
        {
            Rank = rank;
            Suit = suit;
            Picture = picture;
        }
    }

}