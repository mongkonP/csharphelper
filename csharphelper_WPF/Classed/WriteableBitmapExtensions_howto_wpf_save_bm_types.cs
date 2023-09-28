using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Media.Imaging;

namespace howto_wpf_save_bm_types
{
    public static class WriteableBitmapExtensions
    {
        // The available types.
        public enum ImageFormats
        {
            Bmp, Gif, Jpg, Png, Tif, Wmp
        }

        // Save the WriteableBitmap into a graphic file of a given type.
        public static void Save(this WriteableBitmap wbitmap,
            string filename, ImageFormats image_format)
        {
            // Save the bitmap into a file.
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                BitmapEncoder encoder = null;
                switch (image_format)
                {
                    case ImageFormats.Bmp:
                        encoder = new BmpBitmapEncoder();
                        break;
                    case ImageFormats.Gif:
                        encoder = new GifBitmapEncoder();
                        break;
                    case ImageFormats.Jpg:
                        encoder = new JpegBitmapEncoder();
                        break;
                    case ImageFormats.Png:
                        encoder = new PngBitmapEncoder();
                        break;
                    case ImageFormats.Tif:
                        encoder = new TiffBitmapEncoder();
                        break;
                    case ImageFormats.Wmp:
                        encoder = new WmpBitmapEncoder();
                        break;
                }
                encoder.Frames.Add(BitmapFrame.Create(wbitmap));
                encoder.Save(stream);
            }
        }

        // Save the WriteableBitmap into a PNG file.
        public static void Save(this WriteableBitmap wbitmap, string filename)
        {
            FileInfo file_info = new FileInfo(filename);
            switch (file_info.Extension.ToLower())
            {
                case ".bmp":
                    wbitmap.Save(filename, ImageFormats.Bmp);
                    break;
                case ".gif":
                    wbitmap.Save(filename, ImageFormats.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    wbitmap.Save(filename, ImageFormats.Jpg);
                    break;
                case ".png":
                    wbitmap.Save(filename, ImageFormats.Png);
                    break;
                case ".tif":
                case ".tiff":
                    wbitmap.Save(filename, ImageFormats.Tif);
                    break;
                case ".wmp":
                    wbitmap.Save(filename, ImageFormats.Wmp);
                    break;
            }
        }
    }
}
