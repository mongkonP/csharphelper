
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

  namespace  howto_image_slices

 { 

class FileData
    {
        public FileInfo FileInfo = null;
        public Bitmap Picture = null;

        public FileData(string filename)
        {
            FileInfo = new FileInfo(filename);
            Picture = new Bitmap(filename);
        }

        public override string ToString()
        {
            return FileInfo.Name;
        }
    }

}