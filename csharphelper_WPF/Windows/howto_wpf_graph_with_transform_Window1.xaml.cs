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
    /// Interaction logic for howto_wpf_graph_with_transform_Window1.xaml
    /// </summary>
    public partial class howto_wpf_graph_with_transform_Window1 : Window
    {
        public howto_wpf_graph_with_transform_Window1()
        {
            InitializeComponent();
        }

        // Draw a simple graph.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const double wxmin = -10;
            const double wxmax = 110;
            const double wymin = -1;
            const double wymax = 11;
            const double xstep = 10;
            const double ystep = 1;
            const double xtic = 5;
            const double ytic = 0.5;

            const double dmargin = 10;
            double dxmin = dmargin;
            double dxmax = canGraph.Width - dmargin;
            double dymin = dmargin;
            double dymax = canGraph.Height - dmargin;

            // Prepare the transformation matrices.
            PrepareTransformations(
                wxmin, wxmax, wymin, wymax,
                dxmin, dxmax, dymax, dymin);

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            Point p0 = new Point(wxmin, 0);
            Point p1 = new Point(wxmax, 0);
            xaxis_geom.Children.Add(new LineGeometry(WtoD(p0), WtoD(p1)));

            for (double x = xstep; x <= wxmax - xstep; x += xstep)
            {
                Point tic0 = new Point(x, -ytic);
                Point tic1 = new Point(x, ytic);
                xaxis_geom.Children.Add(new LineGeometry(WtoD(tic0), WtoD(tic1)));
            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            canGraph.Children.Add(xaxis_path);

            // Make the Y axis.
            GeometryGroup yaxis_geom = new GeometryGroup();
            p0 = new Point(0, wymin);
            p1 = new Point(0, wymax);
            xaxis_geom.Children.Add(new LineGeometry(WtoD(p0), WtoD(p1)));

            for (double y = ystep; y <= wymax - ystep; y += ystep)
            {
                Point tic0 = new Point(-xtic, y);
                Point tic1 = new Point(xtic, y);
                xaxis_geom.Children.Add(new LineGeometry(WtoD(tic0), WtoD(tic1)));
            }

            Path yaxis_path = new Path();
            yaxis_path.StrokeThickness = 1;
            yaxis_path.Stroke = Brushes.Black;
            yaxis_path.Data = yaxis_geom;

            canGraph.Children.Add(yaxis_path);

            // Make some data sets.
            Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue };
            Random rand = new Random();
            for (int data_set = 0; data_set < 3; data_set++)
            {
                double last_y = rand.Next(3, 7);

                PointCollection points = new PointCollection();
                for (double x = 0; x <= 100; x += 10)
                {
                    last_y += rand.Next(-10, 10) / 10.0;
                    if (last_y < 0) last_y = 0;
                    if (last_y > 10) last_y = 10;
                    Point p = new Point(x, last_y);
                    points.Add(WtoD(p));
                }

                Polyline polyline = new Polyline();
                polyline.StrokeThickness = 1;
                polyline.Stroke = brushes[data_set];
                polyline.Points = points;

                canGraph.Children.Add(polyline);
            }
        }

        // Prepare values for perform transformations.
        private Matrix WtoDMatrix, DtoWMatrix;
        private void PrepareTransformations(
            double wxmin, double wxmax, double wymin, double wymax,
            double dxmin, double dxmax, double dymin, double dymax)
        {
            // Make WtoD.
            WtoDMatrix = Matrix.Identity;
            WtoDMatrix.Translate(-wxmin, -wymin);

            double xscale = (dxmax - dxmin) / (wxmax - wxmin);
            double yscale = (dymax - dymin) / (wymax - wymin);
            WtoDMatrix.Scale(xscale, yscale);

            WtoDMatrix.Translate(dxmin, dymin);

            // Make DtoW.
            DtoWMatrix = WtoDMatrix;
            DtoWMatrix.Invert();
        }

        // Transform a point from world to device coordinates.
        private Point WtoD(Point point)
        {
            return WtoDMatrix.Transform(point);
        }

        // Transform a point from device to world coordinates.
        private Point DtoW(Point point)
        {
            return DtoWMatrix.Transform(point);
        }
    }
}
