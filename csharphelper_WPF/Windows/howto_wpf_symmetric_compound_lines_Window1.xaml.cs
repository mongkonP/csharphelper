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
    /// Interaction logic for howto_wpf_symmetric_compound_lines_Window1.xaml
    /// </summary>
    public partial class howto_wpf_symmetric_compound_lines_Window1 : Window
    {
        public howto_wpf_symmetric_compound_lines_Window1()
        {
            InitializeComponent();
        }

        // Draw the star.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Make the star points.
            double wid = Math.Min(
                grdMain.ActualWidth - 60,
                grdMain.ActualHeight - 40);
            Rect rect = new Rect(30, 40, wid, wid);
            Point[] points = MakeStarPoints(-Math.PI / 2, 5, 2, rect);

            // Polygon stroke thicknesses and colors.
            double[] thicknesses = { 15, 10, 6 };
            Brush[] brushes = { Brushes.Blue, Brushes.White, Brushes.Blue };

            // Create polygons.
            for (int i = 0; i < thicknesses.Length; i++)
            {
                // Make a polygon with thickness i and color i.
                Polygon polygon = new Polygon();
                polygon.Points = new PointCollection(points);
                polygon.StrokeThickness = thicknesses[i];
                polygon.Stroke = brushes[i];
                grdMain.Children.Add(polygon);
            }
        }

        // Generate the points for a star.
        private Point[] MakeStarPoints(double start_theta, int num_points, int skip, Rect rect)
        {
            double theta, dtheta;
            Point[] result;
            double rx = rect.Width / 2f;
            double ry = rect.Height / 2f;
            double cx = rect.X + rx;
            double cy = rect.Y + ry;

            // If this is a polygon, don't bother with concave points.
            if (skip == 1)
            {
                result = new Point[num_points];
                theta = start_theta;
                dtheta = 2 * Math.PI / num_points;
                for (int i = 0; i < num_points; i++)
                {
                    result[i] = new Point(
                        (double)(cx + rx * Math.Cos(theta)),
                        (double)(cy + ry * Math.Sin(theta)));
                    theta += dtheta;
                }
                return result;
            }

            // Find the radius for the concave vertices.
            double concave_radius = CalculateConcaveRadius(num_points, skip);

            // Make the points.
            result = new Point[2 * num_points];
            theta = start_theta;
            dtheta = Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                result[2 * i] = new Point(
                    (double)(cx + rx * Math.Cos(theta)),
                    (double)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
                result[2 * i + 1] = new Point(
                    (double)(cx + rx * Math.Cos(theta) * concave_radius),
                    (double)(cy + ry * Math.Sin(theta) * concave_radius));
                theta += dtheta;
            }
            return result;
        }

        // Calculate the inner star radius.
        private double CalculateConcaveRadius(int num_points, int skip)
        {
            // For really small numbers of points.
            if (num_points < 5) return 0.33f;

            // Calculate angles to key points.
            double dtheta = 2 * Math.PI / num_points;
            double theta00 = -Math.PI / 2;
            double theta01 = theta00 + dtheta * skip;
            double theta10 = theta00 + dtheta;
            double theta11 = theta10 - dtheta * skip;

            // Find the key points.
            Point pt00 = new Point(
                (double)Math.Cos(theta00),
                (double)Math.Sin(theta00));
            Point pt01 = new Point(
                (double)Math.Cos(theta01),
                (double)Math.Sin(theta01));
            Point pt10 = new Point(
                (double)Math.Cos(theta10),
                (double)Math.Sin(theta10));
            Point pt11 = new Point(
                (double)Math.Cos(theta11),
                (double)Math.Sin(theta11));

            // See where the segments connecting the points intersect.
            bool lines_intersect, segments_intersect;
            Point intersection, close_p1, close_p2;
            FindIntersection(pt00, pt01, pt10, pt11,
                out lines_intersect, out segments_intersect,
                out intersection, out close_p1, out close_p2);

            // Calculate the distance between the
            // point of intersection and the center.
            return Math.Sqrt(
                intersection.X * intersection.X +
                intersection.Y * intersection.Y);
        }

        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        private void FindIntersection(
            Point p1, Point p2, Point p3, Point p4,
            out bool lines_intersect, out bool segments_intersect,
            out Point intersection,
            out Point close_p1, out Point close_p2)
        {
            // Get the segments' parameters.
            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            double denominator = (dy12 * dx34 - dx12 * dy34);

            double t1 =
                ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)
                    / denominator;
            if (double.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new Point(double.NaN, double.NaN);
                close_p1 = new Point(double.NaN, double.NaN);
                close_p2 = new Point(double.NaN, double.NaN);
                return;
            }
            lines_intersect = true;

            double t2 =
                ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)
                    / -denominator;

            // Find the point of intersection.
            intersection = new Point(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect =
                ((t1 >= 0) && (t1 <= 1) &&
                 (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            close_p1 = new Point(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new Point(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }
    }
}
