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
    /// Interaction logic for howto_wpf_render_polygon_Window1.xaml
    /// </summary>
    public partial class howto_wpf_render_polygon_Window1 : Window
    {
        public howto_wpf_render_polygon_Window1()
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
            Rect bg_rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
            drawingContext.DrawRectangle(Brushes.White, null, bg_rect);

            // Define polygon points.
            const double line_thickness = 20;
            double center_x = grdMain.ActualWidth / 2;
            double center_y = grdMain.ActualHeight / 2;
            double radius_x = center_x - 2 * line_thickness;
            double radius_y = center_y - 2 * line_thickness;
            double theta = -Math.PI / 2;
            const double dtheta = Math.PI * 4 / 5;
            Point[] points = new Point[5];
            for (int i = 0; i < 5; i++)
            {
                points[i] = new Point(
                    center_x + radius_x * Math.Cos(theta),
                    center_y + radius_y * Math.Sin(theta));
                theta += dtheta;
            }

            // Draw the polygon.
            Pen pen = new Pen(Brushes.Green, line_thickness);
            pen.LineJoin = PenLineJoin.Round;
            drawingContext.DrawPolygon(Brushes.LightGreen,
                pen, points, FillRule.EvenOdd);

            // Make polyline points.
            theta = Math.PI / 2;
            radius_x *= 0.75;
            radius_y *= 0.75;
            for (int i = 0; i < 5; i++)
            {
                points[i] = new Point(
                    center_x + radius_x * Math.Cos(theta),
                    center_y + radius_y * Math.Sin(theta));
                theta += dtheta;
            }

            // Draw the polyline.
            pen = new Pen(Brushes.Blue, line_thickness / 2);
            drawingContext.DrawPolyline(null, pen,
                points, FillRule.EvenOdd);
        }
    }
}
