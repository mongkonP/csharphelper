using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.OleDb;
using IO = System.IO;
using System.IO;
using Microsoft.Win32;
using System.Data;

// Add the database and the cover images to the project
// and set their "Copy to Output Directory" properties
// to "Copy if Newer."

// IMPORTANT: Do not open the database in Access or it
// may erase all of the image data.

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_save_image_in_db_Window1.xaml
    /// </summary>
    public partial class howto_wpf_save_image_in_db_Window1 : Window
    {
        public howto_wpf_save_image_in_db_Window1()
        {
            InitializeComponent();
        }

        // The database connection.
        private OleDbConnection Conn;

        // Display a list of titles.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Compose the database file name.
            // This assumes it's in the executable's directory.
            string db_name =
                Directory.GetCurrentDirectory() +
                "\\Books.mdb";

            // Connect to the database
            Conn = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + db_name + ";" +
                "Mode=Share Deny None");

            // Get the titles.
            OleDbCommand cmd = new OleDbCommand(
                "SELECT Title FROM Books ORDER BY Title",
                Conn);
            Conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lstTitles.Items.Add(reader.GetValue(0));
            }
            reader.Close();
            Conn.Close();
        }

        // Display information about the selected title.
        private void lstTitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayValues();
        }

        private void DisplayValues()
        {
            if (lstTitles.SelectedIndex < 0) return;
            btnSetImage.IsEnabled = true;

            // Make a command object to get information about the title.
            string title = lstTitles.SelectedItem.ToString().Replace("'", "''");
            OleDbCommand cmd = new OleDbCommand(
                "SELECT * FROM Books WHERE Title='" +
                title + "'",
                Conn);

            // Execute the command.
            cmd.Connection = Conn;
            Conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();

            // Display the text data.
            txtUrl.Text = reader[1].ToString();
            txtYear.Text = reader[2].ToString();
            txtIsbn.Text = reader[3].ToString();
            txtPages.Text = reader[4].ToString();

            // Display the cover image.
            if (reader.IsDBNull(6))
            {
                imgCover.Source = null;
            }
            else
            {
                BitmapImage bm =
                    BytesToImage((byte[])reader.GetValue(6));
                imgCover.Source = bm;
            }

            // Clean up.
            reader.Close();
            Conn.Close();
        }

        // Set the image for this title.
        private void btnSetImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            dlg.FilterIndex = 1;

            if (dlg.ShowDialog() == true)
            {
                try
                {
                    // Display the image.
                    BitmapImage bm =
                        new BitmapImage(new Uri(dlg.FileName));
                    imgCover.Source = bm;

                    // Set the image in the database.
                    // The CoverImage field has type OLE Object.
                    string title = lstTitles.SelectedItem.ToString().Replace("'", "''");
                    OleDbCommand cmd = new OleDbCommand(
                        "UPDATE Books SET CoverImage=@Image WHERE Title='" +
                        title + "'",
                        Conn);

                    // Create a byte array holding the image.
                    byte[] image_bytes = ImageToBytes(bm);

                    // Add the image as a parameter.
                    OleDbParameter param = new OleDbParameter();
                    param.OleDbType = OleDbType.Binary;
                    param.ParameterName = "Image";
                    param.Value = image_bytes;
                    cmd.Parameters.Add(param);

                    // Execute the command (with no return value).
                    cmd.Connection = Conn;
                    Conn.Open();
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (Conn.State != ConnectionState.Closed) Conn.Close();
                }
            }
        }

        // Convert a byte array into a BitmapImage.
        private static BitmapImage BytesToImage(byte[] bytes)
        {
            var bm = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                stream.Position = 0;
                bm.BeginInit();
                bm.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bm.CacheOption = BitmapCacheOption.OnLoad;
                bm.UriSource = null;
                bm.StreamSource = stream;
                bm.EndInit();
            }
            return bm;
        }

        // Convert a BitmapImage into a byte array.
        private static byte[] ImageToBytes(BitmapImage image)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        // Load images for all of the records.
        // This shows how to load pictures in code but
        // is really just to load the data quickly.
        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            string[] titles =
            {
                "Advanced Visual Basic Techniques",
                "Beginning Database Design Solutions",
                "Beginning Software Engineering",
                "Bug Proofing Visual Basic",
                "C# 5.0 Programmer's Reference",
                "Custom Controls Library",
                "Essential Algorithms: A Practical Approach to Computer Algorithms",
                "MCSD Certification Toolkit (Exam 70-483): Programming in C#",
                "Microsoft Office Programming: A Guide for Experienced Developers",
                "Prototyping with Visual Basic",
                "Ready-to-Run Delphi Algorithms",
                "Ready-to-Run Visual Basic Algorithms, Second Edition",
                "Ready-to-Run Visual Basic Code Library",
                "Stephens' C# Programming with Visual Studio 2010 24-Hour Trainer",
                "Stephens' Visual Basic Programming 24-Hour Trainer",
                "Visual Basic .NET and XML",
                "Visual Basic .NET Database Programming",
                "Visual Basic 2005 Programmer's Reference",
                "Visual Basic 2010 Programmer's Reference",
                "Visual Basic Graphics Programming, Second Edition",
                "WPF Programmer's Reference",
            };
            string[] filenames =
            {
                @"Images\avbts.jpg",
                @"Images\db_design_s.jpg",
                @"Images\sw_eng.jpg",
                @"Images\errs.jpg",
                @"Images\cs_prog_ref.jpg",
                @"Images\ccls.jpg",
                @"Images\algs.png",
                @"Images\cs_cert.jpg",
                @"Images\offices.jpg",
                @"Images\protos.jpg",
                @"Images\das.jpg",
                @"Images\vbas.jpg",
                @"Images\vbcls.jpg",
                @"Images\24hour_t.jpg",
                @"Images\24hourvbs.jpg",
                @"Images\xmls.jpg",
                @"Images\vbdbs.jpg",
                @"Images\vb_prog_ref_1e_s.jpg",
                @"Images\vb_prog_ref_4e_s.png",
                @"Images\vbgp_1es.jpg",
                @"Images\wpf_prog_ref_t.png",
            };

            this.Cursor = Cursors.Wait;

            string image_dir = IO.Path.GetFullPath(
                IO.Path.Combine(
                    Directory.GetCurrentDirectory(), "..\\..")) + "\\";

            // Load the images.
            for (int i = 0; i < titles.Length; i++)
                LoadRecordImage(titles[i], image_dir + filenames[i]);

            // Redisplay the current title's data.
            DisplayValues();

            this.Cursor = null;
            MessageBox.Show("Loaded " + titles.Length + " images.");
        }

        // Load one record's picture.
        private void LoadRecordImage(string title, string filename)
        {
            try
            {
                // Get the image.
                BitmapImage bm = new BitmapImage(new Uri(filename));

                // Set the image in the database.
                title = title.Replace("'", "''");
                OleDbCommand cmd = new OleDbCommand(
                    "UPDATE Books SET CoverImage=@Image WHERE Title='" +
                    title + "'",
                    Conn);

                // Create a byte array holding the image.
                byte[] image_bytes = ImageToBytes(bm);

                // Add the image as a parameter.
                OleDbParameter param = new OleDbParameter();
                param.OleDbType = OleDbType.Binary;
                param.ParameterName = "Image";
                param.Value = image_bytes;
                cmd.Parameters.Add(param);

                // Execute the command (with no return value).
                cmd.Connection = Conn;
                Conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        // Remove all book images.
        private void btnRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Remove the images.
                OleDbCommand cmd = new OleDbCommand(
                    "UPDATE Books SET CoverImage=null", Conn);

                // Execute the command (with no return value).
                cmd.Connection = Conn;
                Conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }

            // Redisplay the current title's data.
            DisplayValues();
        }
    }
}
