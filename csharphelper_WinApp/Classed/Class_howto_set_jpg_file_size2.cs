
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

  namespace  howto_set_jpg_file_size2

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
            // We check levels that are multiples of 5.
            const int delta = 5;

            // le_level <= the correct level.
            // Start with delta. This will be used if no level works.
            int le_level = delta;

            // gt_level > the correct level.
            // Start with the first multiple of delta greater than 100.
            int gt_level = (100 / delta) * delta + delta;

            // Loop until there are no possibilities between le_level and gt_level.
            for (; ; )
            {
                // Pick a test level in the middle.
                int test_level = (le_level + gt_level) / 2;

                // Make it a multiple of delta.
                test_level = (test_level / delta) * delta;

                // If test_level == le_level, then le_level is the winner.
                if (test_level == le_level) break;

                // Try saving at this compression level.                
                SaveJpg(image, file_name, test_level);

                // See if the size is greater than or less than the target size.
                if (GetFileSize(file_name) > max_size)
                {
                    // The file is too big. Restrict to smaller sizes.
                    gt_level = test_level;
                }
                else
                {
                    // The file is small enough. Consider larger sizes.
                    le_level = test_level;
                }
            }

            // Save at the final size.
            SaveJpg(image, file_name, le_level);

            // Return the size.
            return le_level;
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