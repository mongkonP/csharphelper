using System.Windows;
using System.Windows.Media;

using System.Globalization;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_measure_formattedtext_Window1.xaml
    /// </summary>
    public partial class howto_wpf_measure_formattedtext_Window1 : Window
    {
        public howto_wpf_measure_formattedtext_Window1()
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

            // Create the FormattedText.
            double em_size = 200;
            FontFamily font_family = new FontFamily("Times New Roman");
            Typeface typeface = new Typeface("Times New Roman Bold");
            FormattedText formatted_text = new FormattedText("MgfSj",
                new CultureInfo("en-us"), FlowDirection.LeftToRight,
                typeface, em_size, Brushes.Black);

            // Change the alignment. (For testing purposes.)
            //formatted_text.TextAlignment = TextAlignment.Right;

            // Draw the text.
            Point origin = new Point(100, 20);
            drawingContext.DrawText(formatted_text, origin);

            // Draw an ellipse at the drawing origin.
            drawingContext.DrawEllipse(Brushes.Yellow, new Pen(Brushes.Black, 1), origin, 4, 4);
            
            // Get text metrics.
            double y_top, y_baseline, y_caps, y_lowercase,
                y_descent, y_bottom, x_origin, x_start, x_end, x_right;
            GetTextMetrics(origin.X, origin.Y, formatted_text, typeface, em_size,
                out y_top, out y_baseline, out y_caps, out y_lowercase,
                out y_descent, out y_bottom, out x_origin, out x_start,
                out x_end, out x_right);

            // Set font parameters for line labels.
            const string font_name = "Times New Roman Bold";
            em_size = 14;

            // Draw horizontal lines.
            Pen horz_pen = new Pen(Brushes.Red, 1);
            horz_pen.DashStyle = new DashStyle(new double[] { 5, 5 }, 0);
            double xmin = 10;
            double xmax = grdMain.ActualWidth - 10;
            double[] y_values = { y_top, y_caps, y_lowercase, y_baseline, y_descent, y_bottom };
            string[] y_labels = { "y_top", "y_caps", "y_lowercase", "y_baseline", "y_descent", "" };
            const double gap = 3;
            for (int i = 0; i < y_values.Length; i++)
            {
                drawingContext.DrawLine(horz_pen,
                    new Point(xmin, y_values[i]), new Point(xmax, y_values[i]));
                drawingContext.DrawString(y_labels[i], font_name, em_size,
                    Brushes.Black, new Point(xmin, y_values[i] - gap),
                    VertAlignment.Bottom, TextAlignment.Left);
            }

            // Label y_bottom below its line.
            DrawText(drawingContext, typeface, TextAlignment.Left,
                VertAlignment.Top, 14, Brushes.Black,
                "y_bottom", xmin, y_bottom);

            // Draw vertical lines.
            Pen vert_pen = new Pen(Brushes.Green, 1);
            vert_pen.DashStyle = new DashStyle(new double[] { 5, 5 }, 0);
            double ymin = 10;
            double ymax = grdMain.ActualHeight - 10;
            double[] x_values = { x_origin, x_start, x_end, x_right };
            foreach (double x in x_values)
            {
                drawingContext.DrawLine(vert_pen,
                    new Point(x, ymin), new Point(x, ymax));
            }

            // Label the vertical lines.
            drawingContext.DrawRotatedString("x_origin", -90,
                font_name, em_size, Brushes.Black,
                new Point(x_origin - gap, ymax), TextAlignment.Left,
                VertAlignment.Bottom, TextAlignment.Right);
            drawingContext.DrawRotatedString("x_start", -90,
                font_name, em_size, Brushes.Black,
                new Point(x_start, ymax), TextAlignment.Left,
                VertAlignment.Bottom, TextAlignment.Left);
            drawingContext.DrawRotatedString("x_end", -90,
                font_name, em_size, Brushes.Black,
                new Point(x_end - gap, ymax), TextAlignment.Left,
                VertAlignment.Bottom, TextAlignment.Right);
            drawingContext.DrawRotatedString("x_right", -90,
                font_name, em_size, Brushes.Black,
                new Point(x_right, ymax), TextAlignment.Left,
                VertAlignment.Bottom, TextAlignment.Left);
        }

        // Get information about the text's dimensions.
        private void GetTextMetrics(double x, double y,
            FormattedText formatted_text, Typeface typeface, double em_size,
            out double y_top, out double y_baseline, out double y_caps,
            out double y_lowercase, out double y_descent, out double y_bottom,
            out double x_origin, out double x_start, out double x_end,
            out double x_right)
        {
            y_top = y;
            y_bottom = y_top + formatted_text.Height;
            y_baseline = y_top + formatted_text.Baseline;
            y_caps = y_baseline - typeface.CapsHeight * em_size;
            y_lowercase = y_baseline - typeface.XHeight * em_size;
            y_descent = y_bottom + formatted_text.OverhangAfter;

            x_origin = x;
            x_start = x_origin + formatted_text.OverhangLeading;
            x_right = x_origin + formatted_text.Width;
            x_end = x_right - formatted_text.OverhangTrailing;
        }

        // Draw text.
        private void DrawText(DrawingContext drawingContext, Typeface typeface,
            TextAlignment halign, VertAlignment valign,
            double em_size, Brush brush, string text, double x, double y)
        {
            // Prepare the FormattedText and set its horizontal alignment.
            FormattedText formatted_text = new FormattedText(
                text, CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight, typeface, em_size, brush);
            formatted_text.TextAlignment = halign;

            // Create an origin to set the vertical alignment.
            Point origin = new Point(x, y);
            if (valign == VertAlignment.Middle)
                origin.Y -= formatted_text.Height / 2;
            else if (valign == VertAlignment.Bottom)
                origin.Y -= formatted_text.Height;

            // Draw.
            drawingContext.DrawText(formatted_text, origin);
        }
    }
}
