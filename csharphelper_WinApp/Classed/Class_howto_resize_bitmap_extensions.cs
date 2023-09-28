
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

  namespace  howto_resize_bitmap_extensions

 { 

public static class Extensions
    {
        // Return a resized version of the bitmap.
        public static Bitmap Resize(this Bitmap bm,
            int new_width, int new_height)
        {
            // Make rectangles representing the original and new dimensions.
            Rectangle src_rect = new Rectangle(0, 0, bm.Width, bm.Height);
            Rectangle dest_rect = new Rectangle(0, 0, new_width, new_height);

            // Make the new bitmap.
            Bitmap bm2 = new Bitmap(new_width, new_height);
            using (Graphics gr = Graphics.FromImage(bm2))
            {
                gr.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;
                gr.DrawImage(bm, dest_rect, src_rect,
                    GraphicsUnit.Pixel);
            }

            return bm2;
        }

        // Resize the image, scaling uniformly if
        // set_width and set_height are not both true.
        public static Bitmap Resize(this Bitmap bm,
            bool set_width, bool set_height, int new_width, int new_height)
        {
            // Calculate the new width and height.
            if (!set_width) new_width = bm.Width * new_height / bm.Height;
            if (!set_height) new_height = bm.Height * new_width / bm.Width;

            // Resize and return the image.
            return bm.Resize(new_width, new_height);
        }

        // Save the file with the appropriate format.
        public static void SaveImage(this Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        // Load a bitmap without locking its file.
        public static Bitmap LoadBitmap(string filename)
        {
            using (Bitmap bm = new Bitmap(filename))
            {
                return new Bitmap(bm);
            }
        }
    }

}