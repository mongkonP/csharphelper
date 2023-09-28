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

using System.Globalization;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_image_filled_text_Window1.xaml
    /// </summary>
    public partial class howto_wpf_image_filled_text_Window1 : Window
    {
        public howto_wpf_image_filled_text_Window1()
        {
            InitializeComponent();
        }

        // At design time:
        //      Set the window's Background to Transparent.
        //      Name the content control grdMain.
        //      Set the Flowers.jpg file's "Build Action" property to Content.
        //      Set the Flowers.jpg file's "Copy to Output Directory"
        //          property to "Copy if newer."
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Clear the background.
            Rect bg_rect = new Rect(0, 0, ActualWidth, ActualHeight);
            drawingContext.DrawRectangle(Brushes.White, null, bg_rect);

            // Create the FormattedText.
            const double fontsize = 90;
            FontFamily font_family = new FontFamily("Verdana");
            Typeface typeface = new Typeface("Verdana");
            FormattedText formatted_text = new FormattedText("Flowers",
                CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                typeface, fontsize, Brushes.Black);
            formatted_text.SetFontWeight(FontWeights.Bold);

            // Center horizontally.
            formatted_text.TextAlignment = TextAlignment.Center;

            // Pick an origin to center the text.
            Point origin = new Point(
                grdMain.ActualWidth / 2,
                (grdMain.ActualHeight - formatted_text.Height) / 2);

            // Convert the text into geometry.
            Geometry geometry = formatted_text.BuildGeometry(origin);

            // Make an image brush.
            ImageSource flowers_source = new BitmapImage(
                new Uri("Flowers.jpg", UriKind.Relative));
            ImageBrush flowers_brush = new ImageBrush(flowers_source);
            flowers_brush.Stretch = Stretch.UniformToFill;

            // Draw the geometry.
            Pen pen = new Pen(Brushes.Green, 2);
            drawingContext.DrawGeometry(flowers_brush, pen, geometry);
        }
    }
}
