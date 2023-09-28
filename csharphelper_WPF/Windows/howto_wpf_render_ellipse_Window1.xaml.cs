using System.Windows;
using System.Windows.Media;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_render_ellipse_Window1.xaml
    /// </summary>
    public partial class howto_wpf_render_ellipse_Window1 : Window
    {
        public howto_wpf_render_ellipse_Window1()
        {
            InitializeComponent();
        }

        // At design time:
        //      Set the window's Background to Transparent.
        //      Name the content control grdMain.
        // Draw an ellipse.
        protected override void OnRender(DrawingContext drawingContext)
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
