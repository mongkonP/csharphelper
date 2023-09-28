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

using System.IO;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_download_button_Window1.xaml
    /// </summary>
    public partial class howto_download_button_Window1 : Window
    {
        public howto_download_button_Window1()
        {
            InitializeComponent();
        }

        // Save an image of the grid.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Render the grid.
            RenderTargetBitmap bm = new RenderTargetBitmap(
                (int)grdMain.ActualWidth, (int)grdMain.ActualHeight,
                96, 96, PixelFormats.Default);
            bm.Render(grdMain);

            // Save the result into a file.
            using (var fileStream = new FileStream("Download.png", FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bm));
                encoder.Save(fileStream);
            }
        }
    }
}
