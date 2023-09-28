
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_watermark_directory

 { 

class Progress
    {
        public Bitmap Image;
        public string Filename;

        public Progress(Bitmap image, string filename)
        {
            Image = image;
            Filename = filename;
        }
    }

}