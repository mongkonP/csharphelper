using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_draw_text_to_bitmap_Window1.xaml
    /// </summary>
    public partial class howto_wpf_draw_text_to_bitmap_Window1 : Window
    {
        public howto_wpf_draw_text_to_bitmap_Window1()
        {
            InitializeComponent();
        }

        // Make some images containing text.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const string font_name = "Times New Roman";
            const double em_size = 40;

            // Use a colorful brush.
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Orange, 1.0 / 6.0));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 2.0 / 6.0));
            brush.GradientStops.Add(new GradientStop(Colors.Lime, 3.0 / 6.0));
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 4.0 / 6.0));
            brush.GradientStops.Add(new GradientStop(Colors.Indigo, 5.0 / 6.0));
            brush.GradientStops.Add(new GradientStop(Colors.Violet, 1.0));
            Pen rect_pen = new Pen(brush, 20);
            Brush bg_brush = new SolidColorBrush(Color.FromArgb(255, 240, 240, 240));

            RenderTargetBitmap bm1 =
                DrawingContextExtensions.RenderTextOntoBitmap("Left\nJustified",
                    96, 96, font_name, em_size, TextAlignment.Left,
                    bg_brush, rect_pen, brush, new Thickness(0));
            img1.Source = bm1;

            RenderTargetBitmap bm2 =
                DrawingContextExtensions.RenderTextOntoBitmap("Center\nJustified",
                    96, 96, font_name, em_size, TextAlignment.Center,
                    bg_brush, rect_pen, brush, new Thickness(0));
            img2.Source = bm2;

            RenderTargetBitmap bm3 =
                DrawingContextExtensions.RenderTextOntoBitmap("Right\nJustified",
                    96, 96, font_name, em_size, TextAlignment.Right,
                    bg_brush, rect_pen, brush, new Thickness(0));
            img3.Source = bm3;

            RenderTargetBitmap bm4 =
                DrawingContextExtensions.RenderTextOntoBitmap("Margin\n(20)",
                    96, 96, font_name, em_size, TextAlignment.Center,
                    bg_brush, rect_pen, brush, new Thickness(20));
            img4.Source = bm4;

            RenderTargetBitmap bm5 =
                DrawingContextExtensions.RenderTextOntoBitmap("Margin\n(20,0,0,20)",
                    96, 96, font_name, em_size, TextAlignment.Center,
                    bg_brush, rect_pen, brush, new Thickness(20,0,0,20));
            img5.Source = bm5;

            RenderTargetBitmap bm6 =
                DrawingContextExtensions.RenderTextOntoBitmap("Margin\n(0,20,20,0)",
                    96, 96, font_name, em_size, TextAlignment.Center,
                    bg_brush, rect_pen, brush, new Thickness(0, 20, 20, 0));
            img6.Source = bm6;            
        }
    }
}
