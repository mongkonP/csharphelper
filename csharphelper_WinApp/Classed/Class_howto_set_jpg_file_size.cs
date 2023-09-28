
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

  namespace  howto_set_jpg_file_size

 { 

static class ImageStuff
    {
        // Return an ImageCodecInfo object for this mime type.
        private static ImageCodecInfo GetEncoderInfo(string mime_type)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i <= encoders.Length; i++)
            {
                if (encoders[i].MimeType == mime_type) return encoders[i];
            }
            return null;
        }

        // Save the file with a specific compression level.
        public static void SaveJpg(Image image, string file_name, int level)
        {
            try
            {
                EncoderParameters encoder_params = new EncoderParameters(1);
                encoder_params.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, level);

                ImageCodecInfo image_codec_info = GetEncoderInfo("image/jpeg");
                File.Delete(file_name);
                image.Save(file_name, image_codec_info, encoder_params);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file '" + file_name +
                    "'\nTry a different file name.\n" + ex.Message,
                    "Save Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Save the file with the indicated maximum file size.
        // Return the compression level used.
        public static int SaveJpgAtFileSize(Image image, string file_name, long max_size)
        {
            for (int level = 100; level > 5; level -= 5)
            {
                // Try saving at this compression level.                
                SaveJpg(image, file_name, level);

                // If the file is small enough, we're done.
                if (GetFileSize(file_name) <= max_size) return level;
            }

            // Stay with level 5.
            return 5;
        }

        // Return the file's size.
        public static long GetFileSize(string file_name)
        {
            return new FileInfo(file_name).Length;
        }

        // Load the image without leaving the file locked.
        public static Bitmap LoadBitmap(string file_name)
        {
            Bitmap result;
            using (Bitmap bm = new Bitmap(file_name))
            {
                result = new Bitmap(bm.Width, bm.Height);
                using (Graphics gr = Graphics.FromImage(result))
                {
                    Rectangle rect = new Rectangle(0, 0, bm.Width, bm.Height);
                    gr.DrawImage(bm, rect, rect, GraphicsUnit.Pixel);
                }
            }
            return result;
        }
    }










    public static class MyExtensions
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern Int32 StrFormatByteSize(
            long fileSize,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
            int bufferSize);

        // Return a file size created by the StrFormatByteSize API function.
        public static string ToFileSizeApi(this long file_size)
        {
            StringBuilder sb = new StringBuilder(20);
            StrFormatByteSize(file_size, sb, 20);
            return sb.ToString();
        }
    }

}