using System.Windows;
using System.Windows.Media;

using System.Globalization;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_render_text_Window1.xaml
    /// </summary>
    public partial class howto_wpf_render_text_Window1 : Window
    {
        public howto_wpf_render_text_Window1()
        {
            InitializeComponent();
        }

        // At design time:
        //      Set the window's Background to Transparent.
        //      Name the content control grdMain.
        // Draw an ellipse.
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Clear the background and draw an ellipse.
            DrawEllipse(drawingContext);

            // Make the FormattedText object.
            Typeface typeface = new Typeface("Times New Roman");
            double em_size = 50;
            FormattedText formatted_text = new FormattedText(
                "C# Helper", CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,
                typeface, em_size, Brushes.Red);

            // Center the text horizontally.
            formatted_text.TextAlignment = TextAlignment.Center;

            // Find the center of the client area.
            double xmid = grdMain.ActualWidth / 2;
            double ymid = grdMain.ActualHeight / 2;
            Point center = new Point(xmid, ymid - formatted_text.Height / 2);

            // Draw the text.
            drawingContext.DrawText(formatted_text, center);

            // Draw an ellipse at the text's drawing point.
            drawingContext.DrawEllipse(Brushes.Green, null, center, 3, 3);
        }

        // Clear the background and draw an ellipse.
        private void DrawEllipse(DrawingContext drawingContext)
        {
            // Clear the background.
            Rect bg_rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
            drawingContext.DrawRectangle(Brushes.White, null, bg_rect);

            // Make the pen to outline the ellipse.
            const double pen_width = 5;
            Pen pen = new Pen(Brushes.Blue, pen_width);

            // Get the center of the content Grid control.
            double center_x = grdMain.ActualWidth / 2;
            double center_y = grdMain.ActualHeight / 2;
            Point center = new Point(center_x, center_y);

            // Subtract half the width of the pen from
            // the center to get radius_x and radius_y
            // so the ellipse just touches the sides of the form.
            double radius_x = center_x - pen_width / 2;
            double radius_y = center_y - pen_width / 2;

            // Draw the ellipse.
            drawingContext.DrawEllipse(Brushes.LightBlue,
                pen, center, radius_x, radius_y);
        }
    }
}
