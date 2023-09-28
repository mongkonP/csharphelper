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

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_draw_pixels_Window1.xaml
    /// </summary>
    public partial class howto_wpf_draw_pixels_Window1 : Window
    {
        public howto_wpf_draw_pixels_Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const int width = 240;
            const int height = 240;

            WriteableBitmap wbitmap = new WriteableBitmap(
                width, height, 96, 96, PixelFormats.Bgra32, null);
            byte[, ,] pixels = new byte[height, width, 4];

            // Clear to black.
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    for (int i = 0; i < 3; i++)
                        pixels[row, col, i] = 0;
                    pixels[row, col, 3] = 255;
                }
            }

            // Blue.
            for (int row = 0; row < 80; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    pixels[row, col, 0] = 255;
                }
            }

            // Green.
            for (int row = 80; row < 160; row++)
            {
                for (int col = 0; col < 80; col++)
                {
                    pixels[row, col, 1] = 255;
                }
            }

            // Red.
            for (int row = 160; row < 240; row++)
            {
                for (int col = 0; col < 80; col++)
                {
                    pixels[row, col, 2] = 255;
                }
            }

            // Copy the data into a one-dimensional array.
            byte[] pixels1d = new byte[height * width * 4];
            int index = 0;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    for (int i = 0; i < 4; i++)
                        pixels1d[index++]= pixels[row, col, i];
                }
            }

            // Update writeable bitmap with the colorArray to the image.
            Int32Rect rect = new Int32Rect(0, 0, width, height);
            int stride = 4 * width;
            wbitmap.WritePixels(rect, pixels1d, stride, 0);

            // Create an Image to display the bitmap.
            Image image = new Image();
            image.Stretch = Stretch.None;
            image.Margin = new Thickness(0);

            grdMain.Children.Add(image);

            //Set the Image source.
            image.Source = wbitmap;
        }
    }
}
