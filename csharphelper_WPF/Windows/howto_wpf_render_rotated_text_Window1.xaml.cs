using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_render_rotated_text_Window1.xaml
    /// </summary>
    public partial class howto_wpf_render_rotated_text_Window1 : Window
    {
        public howto_wpf_render_rotated_text_Window1()
        {
            InitializeComponent();
        }

        // At design time:
        //      Set the window's Background to Transparent.
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Clear the background.
            Rect bg_rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
            drawingContext.DrawRectangle(Brushes.White, null, bg_rect);

            // Get the parameters.
            // Make sure wee have a valid angle.
            double angle;
            if (!double.TryParse(txtAngle.Text, out angle)) return;

            TextAlignment text_align;
            if (cboTextAlign.Text == "Left") text_align = TextAlignment.Left;
            else if (cboTextAlign.Text == "Right") text_align = TextAlignment.Right;
            else if (cboTextAlign.Text == "Center") text_align = TextAlignment.Center;
            else text_align = TextAlignment.Justify;

            // Draw some text.
            const string font_name = "Times New Roman";
            const double em_size = 14;
            Pen pen = new Pen(Brushes.Green, 1);
            Brush brush = Brushes.Lime;
            Point point;

            const double x0 = 50;
            const double y0 = 50;
            const double dy = 110;
            const double dx = 110;
            double x, y;

            y = y0;
            x = x0;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("TOP\nLEFT", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Top, TextAlignment.Left);

            x += dx;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("TOP\nCENTER", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Top, TextAlignment.Center);

            x += dx;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("TOP\nRIGHT", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Top, TextAlignment.Right);

            y += dy;
            x = x0;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("MIDDLE\nLEFT", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Middle, TextAlignment.Left);

            x += dx;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("MIDDLE\nCENTER", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Middle, TextAlignment.Center);

            x += dx;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("MIDDLE\nRIGHT", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Middle, TextAlignment.Right);

            y += dy;
            x = x0;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("BOTTOM\nLEFT", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Bottom, TextAlignment.Left);

            x += dx;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("BOTTOM\nCENTER", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Bottom, TextAlignment.Center);

            x += dx;
            point = new Point(x, y);
            drawingContext.DrawEllipse(brush, pen, point, 3, 3);
            drawingContext.DrawRotatedString("BOTTOM\nRIGHT", angle,
                font_name, em_size,
                Brushes.Black, point, text_align,
                VertAlignment.Bottom, TextAlignment.Right);
        }

        // Force a redraw.
        private void cboTextAlign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InvalidateVisual();
        }
        private void txtAngle_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.InvalidateVisual();
        }
    }
}
