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

// Add a reference to ReachFramework.
using System.Windows.Xps.Packaging;
using System.IO;

// The project includes file Test.xps. That file's
// "Copy to Output Directory" property is set to
// "Copy if Newer" so it will be in the executable's directory.

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_xps_to_png_Window1.xaml
    /// </summary>
    public partial class howto_wpf_xps_to_png_Window1 : Window
    {
        public howto_wpf_xps_to_png_Window1()
        {
            InitializeComponent();
        }

        // The current scale.
        private double ImageScale = 1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtXpsFile.Text =
                System.AppDomain.CurrentDomain.BaseDirectory +
                "Test.xps";
        }

        // Convert the XPS pages into png files.
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            tabResults.Visibility = Visibility.Hidden;

            // Process the file.
            int num_pages = XpsToPng(txtXpsFile.Text);

            // Display the results.
            DisplayPngFiles(txtXpsFile.Text, num_pages);

            // Set the appropriate image sizes.
            SizeImages();

            tabResults.Visibility = Visibility.Visible;
            Cursor = null;
        }

        // Convert an XPS file into a PNG file.
        public int XpsToPng(string xps_file)
        {
            // Make sure this is an xps file.
            if (!xps_file.ToLower().EndsWith(".xps"))
                throw new ArgumentException(
                    "Method XpsToPng only works for .xps files.");

            // Get the file's name without the .xps on the end.
            string file_prefix = xps_file.Substring(0, xps_file.Length - 4);

            // Load the XPS document.
            XpsDocument xps_doc =
                new XpsDocument(xps_file, FileAccess.Read);

            // Get a fixed paginator for the document.
            IDocumentPaginatorSource page_source =
                xps_doc.GetFixedDocumentSequence();
            DocumentPaginator paginator =
                page_source.DocumentPaginator;

            // Process the document's pages.
            int num_pages = paginator.PageCount;
            for (int i = 0; i < num_pages; i++)
            {
                using (DocumentPage page = paginator.GetPage(i))
                {
                    // Render the page into the memory stream.
                    int width = (int)page.Size.Width;
                    int height = (int)page.Size.Height;
                    RenderTargetBitmap bitmap =
                        new RenderTargetBitmap(
                            width, height, 96, 96,
                            PixelFormats.Default);
                    bitmap.Render(page.Visual);

                    // Save the PNG file.
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmap));

                    using (MemoryStream stream = new MemoryStream())
                    {
                        encoder.Save(stream);

                        using (FileStream file = new FileStream(
                            file_prefix + (i + 1).ToString() + ".png",
                            FileMode.Create))
                        {
                            file.Write(stream.GetBuffer(), 0, (int)stream.Length);
                            file.Close();
                        }
                    }
                }
            }
            return num_pages;
        }

        // Display the converted png files in the TabControl.
        private void DisplayPngFiles(string xps_file, int num_pages)
        {
            string file_prefix = xps_file.Substring(0, xps_file.Length - 4);

            tabResults.Items.Clear();
            for (int i = 1; i <= num_pages; i++)
            {
                // Load the png file into an Image control.
                Image image = new Image();
                image.Source = new BitmapImage(
                    new Uri(file_prefix + i.ToString() + ".png",
                        UriKind.Absolute));

                // Load the Image into a ScrollViewer.
                ScrollViewer viewer = new ScrollViewer();
                viewer.Background = Brushes.Black;
                viewer.Content = image;
                viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                viewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

                // Make a TabItem to display the ScrollViewer.
                TabItem tab_item = new TabItem();
                tabResults.Items.Add(tab_item);
                tab_item.Header = "Page " + i.ToString();
                tab_item.Content = viewer;
            }
        }

        // Select a new scale.
        private void cboScale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = cboScale.SelectedItem as ComboBoxItem;
            string scale_text = item.Content.ToString();
            scale_text = scale_text.Replace("%", "");
            ImageScale = double.Parse(scale_text) / 100.0;

            // Set the appropriate image sizes.
            SizeImages();
        }

        // Set the appropriate image sizes.
        private void SizeImages()
        {
            if (tabResults == null) return;

            foreach (TabItem tab_item in tabResults.Items)
            {
                ScrollViewer viewer = tab_item.Content as ScrollViewer;
                Image image = viewer.Content as Image;
                image.Width = image.Source.Width * ImageScale;
                image.Height = image.Source.Height * ImageScale;
            }
        }
    }
}
