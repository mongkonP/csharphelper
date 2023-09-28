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
    /// Interaction logic for howto_wpf_load_pixelmaker_Window1.xaml
    /// </summary>
    public partial class howto_wpf_load_pixelmaker_Window1 : Window
    {
        public howto_wpf_load_pixelmaker_Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Make the BitmapPixelMaker.
            Uri uri = new Uri("Smiley.png", UriKind.Relative);
            BitmapPixelMaker bm_maker = new BitmapPixelMaker(uri);

            // Brighten and darken the image's pixels.
            int wid = bm_maker.Width / 4;
            int hgt = bm_maker.Height/ 4;
            int num_c = bm_maker.Width / wid;
            int num_r = bm_maker.Height / hgt;
            for (int row = 0; row < num_r; row++)
            {
                for (int col = 0; col < num_c; col++)
                {
                    for (int i = 0; i < wid; i++)
                    {
                        for (int j = 0; j < hgt; j++)
                        {
                            int x = col * wid + j;
                            int y = row * hgt + i;
                            if ((x < bm_maker.Width) && (y < bm_maker.Height))
                            {
                                byte r, g, b, a;
                                bm_maker.GetPixel(x, y, out r, out g, out b, out a);
                                if ((col + row) % 2 == 0)
                                {
                                    // Lighten the pixel.
                                    r = (byte)(255 - (255 - r) * 0.75);
                                    g = (byte)(255 - (255 - g) * 0.75);
                                    b = (byte)(255 - (255 - b) * 0.75);
                                }
                                else
                                {
                                    // Darken the pixel.
                                    r = (byte)(r * 0.75);
                                    g = (byte)(g * 0.75);
                                    b = (byte)(b * 0.75);
                                }
                                bm_maker.SetPixel(x, y, r, g, b, a);
                            }
                        }
                    }
                }
            }

            // Convert the pixel data into a WriteableBitmap.
            WriteableBitmap new_wbitmap = bm_maker.MakeBitmap(96, 96);

            // Display the result.
            imgResult.Source = new_wbitmap;
        }
    }
}
