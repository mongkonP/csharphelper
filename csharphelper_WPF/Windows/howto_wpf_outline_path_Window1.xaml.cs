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
    /// Interaction logic for howto_wpf_outline_path_Window1.xaml
    /// </summary>
    public partial class howto_wpf_outline_path_Window1 : Window
    {
        public howto_wpf_outline_path_Window1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            // Get the outline path.
            PathGeometry flat = scribbleGeometry.GetFlattenedPathGeometry();
            double thickness = scribblePath.StrokeThickness;

            // Get polygons representing the path's outlines.
            List<Polygon> polygons = GetPathOutlinePolygons(flat, thickness);

            // Add the polygons to the main Grid.
            foreach (Polygon polygon in polygons)
            {
                polygon.Stroke = Brushes.Red;
                polygon.StrokeThickness = 1;
                grdMain.Children.Add(polygon);
            }

            // Disable the Go button.
            btnGo.IsEnabled = false;
            btnGo.Opacity = 0.5;
        }

        // Return Polygons or Polylines that make stripes within the PathGeometry.
        private List<Shape> GetPathStripeShapes(PathGeometry path_geo,
            double thickness, double[] thicknesses, Brush[] brushes)
        {
            List<Shape> shapes = new List<Shape>();
            foreach (PathFigure figure in path_geo.Figures)
            {
                shapes.AddRange(GetFigureStripes(
                    figure, thickness, thicknesses, brushes));
            }
            return shapes;
        }

        // Get Shapes representing a PathFigure's stripes.
        // To cover the whole line and nothing more,
        // Sum(thicknesses) should equal 1.
        private List<Shape> GetFigureStripes(PathFigure figure,
            double thickness, double[] thicknesses, Brush[] brushes)
        {
            List<Shape> shapes = new List<Shape>();

            // Get the figure's left and right edge points.
            List<Point> lpoints, rpoints;
            GetFigureLRPoints(figure, thickness,
                out lpoints, out rpoints);

            // Create the stripe shapes.
            double start = 0;
            for (int i = 0; i < thicknesses.Length; i++)
            {
                // Get points for a stripe with width
                // thickness * thicknesses[i] with edge at start.
                double stripe_width = thicknesses[i];
                double half = stripe_width / 2;
                List<Point> points = new List<Point>();
                for (int node = 0; node < lpoints.Count; node++)
                {
                    double x1 = lpoints[node].X;
                    double y1 = lpoints[node].Y;
                    double x2 = rpoints[node].X;
                    double y2 = rpoints[node].Y;
                    double dx = x2 - x1;
                    double dy = y2 - y1;
                    Point point = new Point(
                        x1 + dx * (start + half),
                        y1 + dy * (start + half));
                    points.Add(point);
                }

                // Convert the points into a Shape.
                if (figure.IsClosed)
                {
                    Polygon polygon = new Polygon();
                    polygon.Points = new PointCollection(points);
                    polygon.StrokeThickness = stripe_width * thickness;
                    polygon.Stroke = brushes[i];
                    shapes.Add(polygon);
                }
                else
                {
                    Polyline polyline = new Polyline();
                    polyline.Points = new PointCollection(points);
                    polyline.StrokeThickness = stripe_width * thickness;
                    polyline.Stroke = brushes[i];
                    shapes.Add(polyline);
                }

                start += stripe_width;
            }

            return shapes;
        }

        // Get the left and right points for a PathFigure.
        private void GetFigureLRPoints(PathFigure figure,
            double thickness,
            out List<Point> lpoints,
            out List<Point> rpoints)
        {
            // Get the figure's flattened points.
            List<Point> points = GetFlattenedFigurePoints(figure);

            // Make the lists of left and right points.
            lpoints = new List<Point>();
            rpoints = new List<Point>();

            Point lpoint, rpoint, ignore1, ignore2;

            // See if this is a closed figure.
            if (figure.IsClosed)
            {
                // Add the second point again to round the first corner.
                points.Add(points[1]);
            }
            else
            {
                // Add the start points.
                GetLREdgePoints(points[0], points[1], thickness,
                    out lpoint, out ignore1,
                    out rpoint, out ignore2);
                lpoints.Add(lpoint);
                rpoints.Add(rpoint);
            }

            // Get the intermediate left and right points.
            for (int i = 1; i <= points.Count - 2; i++)
            {
                // Get the left and right points at the corner
                // points[i - 1] --> points[i] --> points[i + 1].
                FindLRIntersections(points[i - 1], points[i], points[i + 1],
                    thickness, out lpoint, out rpoint);
                lpoints.Add(lpoint);
                rpoints.Add(rpoint);
            }

            // Add the end points.
            if (!figure.IsClosed)
            {
                GetLREdgePoints(
                    points[points.Count - 2],
                    points[points.Count - 1], thickness,
                    out ignore1, out lpoint,
                    out ignore2, out rpoint);
                lpoints.Add(lpoint);
                rpoints.Add(rpoint);
            }
        }

        // Return Polygons that outline the pieces of the PathGeometry.
        private List<Polygon> GetPathOutlinePolygons(PathGeometry path_geo, double thickness)
        {
            List<Polygon> polygons = new List<Polygon>();
            foreach (PathFigure figure in path_geo.Figures)
            {
                List<List<Point>> points_list =
                    GetFigureOutlinePoints(figure, thickness);
                foreach (List<Point> points in points_list)
                {
                    Polygon polygon = new Polygon();
                    polygon.Points = new PointCollection(points);
                    polygons.Add(polygon);
                }
            }
            return polygons;
        }

        // Get points that outline a PathFigure.
        private List<List<Point>> GetFigureOutlinePoints(PathFigure figure, double thickness)
        {
            // Get the figure's flattened points.
            List<Point> points = GetFlattenedFigurePoints(figure);

            // Make the lists of left and right points.
            List<Point> lpoints = new List<Point>();
            List<Point> rpoints = new List<Point>();
            Point lpoint, rpoint, ignore1, ignore2;

            // See if this is a closed figure.
            if (figure.IsClosed)
            {
                // Add the second point again to round the first corner.
                points.Add(points[1]);
            }
            else
            {
                // Add the start points.
                GetLREdgePoints(points[0], points[1], thickness,
                    out lpoint, out ignore1,
                    out rpoint, out ignore2);
                lpoints.Add(lpoint);
                rpoints.Add(rpoint);
            }

            // Get the intermediate left and right points.
            for (int i = 1; i <= points.Count - 2; i++)
            {
                // Get the left and right points at the corner
                // points[i - 1] --> points[i] --> points[i + 1].
                FindLRIntersections(points[i - 1], points[i], points[i + 1],
                    thickness, out lpoint, out rpoint);
                lpoints.Add(lpoint);
                rpoints.Add(rpoint);
            }

            // Add the end points.
            GetLREdgePoints(
                points[points.Count - 2],
                points[points.Count - 1], thickness,
                out ignore1, out lpoint,
                out ignore2, out rpoint);

            List<List<Point>> result = new List<List<Point>>();
            if (figure.IsClosed)
            {
                result.Add(lpoints);
                result.Add(rpoints);
            }
            else
            {
                lpoints.Add(lpoint);
                rpoints.Add(rpoint);

                // Reverse the right points and add them to the left points.
                rpoints.Reverse();
                lpoints.AddRange(rpoints);

                result.Add(lpoints);
            }

            return result;
        }

        // Return the points that make up a flattened figure.
        private List<Point> GetFlattenedFigurePoints(PathFigure figure)
        {
            List<Point> points = new List<Point>();
            points.Add(figure.StartPoint);
            foreach (PathSegment segment in figure.Segments)
            {
                if (segment is LineSegment)
                {
                    LineSegment line_segment = segment as LineSegment;
                    points.Add(line_segment.Point);
                }
                else if (segment is PolyLineSegment)
                {
                    PolyLineSegment poly_segment = segment as PolyLineSegment;
                    foreach (Point point in poly_segment.Points)
                        points.Add(point);
                }
                else
                {
                    throw new Exception("Unknown flattened path segment type " +
                        segment.GetType().Name);
                }
            }

            return points;
        }

        // Find the left and right points of intersection between
        // the lines p1 --> p2 and p2 --> p3.
        private void FindLRIntersections(
            Point p1, Point p2, Point p3,
            double thickness,
            out Point left_point,
            out Point right_point)
        {
            Point close1, close2;
            bool lines_intersect, segments_intersect;

            // Get the lines' edge points.
            Point l11, l12, l21, l22, r11, r12, r21, r22;
            GetLREdgePoints(p1, p2, thickness,
                out l11, out l12, out r11, out r12);
            GetLREdgePoints(p2, p3, thickness,
                out l21, out l22, out r21, out r22);

            // Find the left intersection.
            FindIntersection(l11, l12, l21, l22,
                out lines_intersect, out segments_intersect,
                out left_point, out close1, out close2);

            // Find the right intersection.
            FindIntersection(r11, r12, r21, r22,
                out lines_intersect, out segments_intersect,
                out right_point, out close1, out close2);
        }

        // Find the left and right edge points for the segment.
        private void GetLREdgePoints(
            Point p1, Point p2, double thickness,
            out Point left1, out Point left2,
            out Point right1, out Point right2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double length = Math.Sqrt(dx * dx + dy * dy);
            double nx = dx / length;
            double ny = dy / length;

            left1 = new Point(
                p1.X - ny * thickness / 2.0,
                p1.Y + nx * thickness / 2.0);
            left2 = new Point(
                p2.X - ny * thickness / 2.0,
                p2.Y + nx * thickness / 2.0);
            right1 = new Point(
                p1.X + ny * thickness / 2.0,
                p1.Y - nx * thickness / 2.0);
            right2 = new Point(
                p2.X + ny * thickness / 2.0,
                p2.Y - nx * thickness / 2.0);
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
            if (t1 < 0) t1 = 0;
            else if (t1 > 1) t1 = 1;

            if (t2 < 0) t2 = 0;
            else if (t2 > 1) t2 = 1;

            close_p1 = new Point(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new Point(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }
    }
}
