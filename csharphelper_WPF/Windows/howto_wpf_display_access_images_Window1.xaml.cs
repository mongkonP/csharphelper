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
using System.IO;

// Add the database to the project and set its
// "Copy to Output Directory" property
// to "Copy if Newer."

// IMPORTANT: Do not open the database in Access or it
// may erase all of the image data.

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_display_access_images_Window1.xaml
    /// </summary>
    public partial class howto_wpf_display_access_images_Window1 : Window
    {
        public howto_wpf_display_access_images_Window1()
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
                lstTitles.Items.Add(reader.GetValue(0));
            reader.Close();
            Conn.Close();
        }

        // Display information about the selected title.
        private void lstTitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTitles.SelectedIndex < 0) return;

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
                imgCover.Source = null;
            else
                imgCover.Source =
                    BytesToImage((byte[])reader.GetValue(6));

            // Clean up.
            reader.Close();
            Conn.Close();
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
    }
}
