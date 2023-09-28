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
    /// Interaction logic for howto_wpf_save_bm_extension_Window1.xaml
    /// </summary>
    public partial class howto_wpf_save_bm_extension_Window1 : Window
    {
        public howto_wpf_save_bm_extension_Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const int width = 240;
            const int height = 240;

            // Make the BitmapPixelMaker.
            BitmapPixelMaker bm_maker = new BitmapPixelMaker(width, height);

            // Clear to black.
            bm_maker.SetColor(0, 0, 0);

            // Blue.
            for (int y = 0; y < 80; y++)
            {
                for (int x = 0; x <= y; x++)
                {
                    bm_maker.SetBlue(x, y, 255);
                }
            }

            // Green.
            for (int x = 0; x < 80; x++)
            {
                for (int y = 80; y < 160; y++)
                {
                    bm_maker.SetGreen(x, y, 255);
                }
            }

            // Red.
            for (int x = 0; x < 80; x++)
            {
                for (int y = 160; y < 240; y++)
                {
                    bm_maker.SetRed(x, y, 255);
                }
            }

            // Shades of red, green, and blue.
            for (int x = 80; x < 160; x++)
            {
                byte color = (byte)((x - 80f) / 80f * 255f);
                for (int y = 0; y < 80; y++)
                {
                    bm_maker.SetPixel(x, y, color, 0, 0, 255);
                }
                for (int y = 80; y < 160; y++)
                {
                    bm_maker.SetPixel(x, y, 0, color, 0, 255);
                }
                for (int y = 160; y < 240; y++)
                {
                    bm_maker.SetPixel(x, y, 0, 0, color, 255);
                }
            }

            // Secondary colors.
            for (int x = 160; x < 240; x++)
            {
                for (int y = 0; y < 80; y++)
                {
                    bm_maker.SetPixel(x, y, 255, 255, 0, 255);
                }
                for (int y = 80; y < 160; y++)
                {
                    bm_maker.SetPixel(x, y, 0, 255, 255, 255);
                }
                for (int y = 160; y < 240; y++)
                {
                    bm_maker.SetPixel(x, y, 255, 0, 255, 255);
                }
            }

            // Convert the pixel data into a WriteableBitmap.
            WriteableBitmap wbitmap = bm_maker.MakeBitmap(96, 96);

            // Create an Image to display the bitmap.
            Image image = new Image();
            image.Stretch = Stretch.None;
            image.Margin = new Thickness(0);

            grdMain.Children.Add(image);

            // Set the Image source.
            image.Source = wbitmap;

            // Save the bitmap into a file.
            wbitmap.Save("ColorSamples.png");
        }
    }
}
