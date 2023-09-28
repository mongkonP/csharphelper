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
    /// Interaction logic for howto_wpf_video_buttons_Window1.xaml
    /// </summary>
    public partial class howto_wpf_video_buttons_Window1 : Window
    {
        public howto_wpf_video_buttons_Window1()
        {
            InitializeComponent();
        }

        // Save images of the buttons.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Button[] buttons = new Button[]
            {
                btnPlay, btnFaster, btnNext, btnStop, btnPause,
                btnRestart, btnBack, btnSlower, btnPrevious, btnTest
            };
            foreach (Button btn in buttons)
            {
                string filename = btn.Name.Replace("btn", "").ToLower() + ".png";
                SaveControlImage(btn, filename);
            }
        }

        // Save a control's image.
        private void SaveControlImage(FrameworkElement control, string filename)
        {
            // Get the size of the Visual and its descendants.
            Rect rect = VisualTreeHelper.GetDescendantBounds(control);

            // Make a DrawingVisual to make a screen
            // representation of the control.
            DrawingVisual dv = new DrawingVisual();

            // Fill a rectangle the same size as the control
            // with a brush containing images of the control.
            using (DrawingContext ctx = dv.RenderOpen())
            {
                VisualBrush brush = new VisualBrush(control);
                ctx.DrawRectangle(brush, null, new Rect(rect.Size));
            }

            // Make a bitmap and draw on it.
            int width = (int)control.ActualWidth;
            int height = (int)control.ActualHeight;
            RenderTargetBitmap rtb = new RenderTargetBitmap(
                width, height, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(dv);

            // Make a PNG encoder.
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            // Save the file.
            using (FileStream fs = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                encoder.Save(fs);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Name);
        }
    }
}
