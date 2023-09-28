using System.Windows;
using System.Windows.Media;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_drawstring_Window1.xaml
    /// </summary>
    public partial class howto_wpf_drawstring_Window1 : Window
    {
        public howto_wpf_drawstring_Window1()
        {
            InitializeComponent();
        }

        // At design time:
        //      Set the window's Background to Transparent.
        //      Name the content control grdMain.
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Clear the background.
            Rect bg_rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
            drawingContext.DrawRectangle(Brushes.White, null, bg_rect);

            // Draw some text.
            const string font_name = "Times New Roman";
            const double em_size = 14;
            Pen pen = new Pen(Brushes.Green, 1);
            Brush brush = Brushes.Lime;
            Point point;

            point = new Point(10, 10);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("TOP\nLEFT", font_name, em_size,
                Brushes.Black, point, VertAlignment.Top, TextAlignment.Left);

            point = new Point(170, 10);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("TOP\nCENTER", font_name, em_size,
                Brushes.Black, point, VertAlignment.Top, TextAlignment.Center);

            point = new Point(330, 10);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("TOP\nRIGHT", font_name, em_size,
                Brushes.Black, point, VertAlignment.Top, TextAlignment.Right);

            point = new Point(10, 130);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("MIDDLE\nLEFT", font_name, em_size,
                Brushes.Black, point, VertAlignment.Middle, TextAlignment.Left);

            point = new Point(170, 130);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("MIDDLE\nCENTER", font_name, em_size,
                Brushes.Black, point, VertAlignment.Middle, TextAlignment.Center);

            point = new Point(330, 130);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("MIDDLE\nRIGHT", font_name, em_size,
                Brushes.Black, point, VertAlignment.Middle, TextAlignment.Right);

            point = new Point(10, 250);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("BOTTOM\nLEFT", font_name, em_size,
                Brushes.Black, point, VertAlignment.Bottom, TextAlignment.Left);

            point = new Point(170, 250);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("BOTTOM\nCENTER", font_name, em_size,
                Brushes.Black, point, VertAlignment.Bottom, TextAlignment.Center);

            point = new Point(330, 250);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawString("BOTTOM\nRIGHT", font_name, em_size,
                Brushes.Black, point, VertAlignment.Bottom, TextAlignment.Right);
        }
    }
}
