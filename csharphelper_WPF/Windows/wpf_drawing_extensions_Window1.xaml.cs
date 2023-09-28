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
    /// Interaction logic for wpf_drawing_extensions_Window1.xaml
    /// </summary>
    public partial class wpf_drawing_extensions_Window1 : Window
    {
        public wpf_drawing_extensions_Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Make an ellipse.
            Rect rect = new Rect(75, 80, 150, 150);
            canDrawing.DrawEllipse(Brushes.Yellow,
                Brushes.Black, 5, rect);

            // Build a rectangle the hard way.
            Rectangle rectangle = new Rectangle();
            Canvas.SetLeft(rectangle, 100);
            Canvas.SetTop(rectangle, 30);
            rectangle.Width = 100;
            rectangle.Height = 70;
            rectangle.Fill = Brushes.LightGreen;
            rectangle.Stroke = Brushes.Green;
            rectangle.StrokeThickness = 5;
            canDrawing.Children.Add(rectangle);

            // Use the DrawRectangle extension method.
            rect = new Rect(50, 80, 200, 20);
            rectangle = canDrawing.DrawRectangle(Brushes.Pink,
                Brushes.Red, 5, rect);
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;

            // Left eye.
            rect = new Rect(100, 110, 40, 50);
            canDrawing.DrawEllipse(Brushes.White,
                Brushes.Black, 5, rect);

            // Left pupil.
            rect = new Rect(120, 120, 20, 30);
            canDrawing.DrawEllipse(Brushes.Black,
                Brushes.Black, 5, rect);

            // Right eye.
            rect = new Rect(160, 110, 40, 50);
            canDrawing.DrawEllipse(Brushes.White,
                Brushes.Black, 5, rect);

            // Right pupil.
            rect = new Rect(180, 120, 20, 30);
            canDrawing.DrawEllipse(Brushes.Black,
                Brushes.Black, 5, rect);

            // Nose.
            rect = new Rect(130, 150, 40, 30);
            canDrawing.DrawEllipse(Brushes.Pink,
                Brushes.Black, 5, rect);

            // Mouth. Use three lines.
            canDrawing.DrawLine(Brushes.Blue, 5,
                120, 200, 130, 210);
            canDrawing.DrawLine(Brushes.Blue, 5,
                130, 210, 170, 210);
            canDrawing.DrawLine(Brushes.Blue, 5,
                170, 210, 180, 200);

            // Moustache using a Polyline.
            const int num_points = 10;
            double xmin = 130;
            double xmax = 170;
            double dx = (xmax - xmin) / (num_points - 1);
            double ymin = 185;
            double ymax = 195;
            double ymid = (ymax + ymin) / 2;
            double dy = (ymax - ymin) / 2;
            double thetamin = -1.75 * Math.PI;
            double thetamax = 0.75 * Math.PI;
            double dtheta = (thetamax - thetamin) / (num_points - 1);
            Point[] points = new Point[num_points];
            double theta = thetamin;
            double x = xmin;
            for (int i = 0; i < num_points; i++)
            {
                double y = ymid + dy * Math.Sin(theta);
                points[i] = new Point(x, y);
                x += dx;
                theta += dtheta;
            }
            canDrawing.DrawPolyline(Brushes.Black,
                6, points);
        }
    }
}
