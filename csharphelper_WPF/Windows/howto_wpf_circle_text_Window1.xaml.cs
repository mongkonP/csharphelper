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

// For the program's basic structure, see:
// Zoom on a graph in WPF and C#
// http://csharphelper.com/blog/2014/09/zoom-on-a-graph-wpf-c/
//
// For information on rotated text, see:
// Draw a graph with rotated text in WPF and C#
// http://csharphelper.com/blog/2014/09/draw-a-graph-with-rotated-text-wpf-c/

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_circle_text_Window1.xaml
    /// </summary>
    public partial class howto_wpf_circle_text_Window1 : Window
    {
        public howto_wpf_circle_text_Window1()
        {
            InitializeComponent();
        }

        // Draw some circles and text.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the Canvas geometry.
            double wid = canGraph.ActualWidth;
            double hgt = canGraph.ActualHeight;
            double cx = wid / 2;
            double cy = hgt / 2;

            // Make some centered circles.
            for (int radius = 200; radius > 0; radius -= 50)
            {
                byte b = (byte)(radius / 2 + 155);
                byte r = (byte)(b / 2);
                byte g = (byte)(b / 2);

                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(
                    Color.FromArgb(255, r, g, b));
                ellipse.Stroke = Brushes.Black;
                ellipse.StrokeThickness = 3;
                Canvas.SetLeft(ellipse, cx - radius);
                Canvas.SetTop(ellipse, cy - radius);
                ellipse.Width = 2 * radius;
                ellipse.Height = 2 * radius;
                canGraph.Children.Add(ellipse);
            }

            // Make some rotated text.
            double font_size = 10;
            for (int radius = 25; radius < 200; radius += 50)
            {
                const double num_angles = 6;
                double dtheta = 360 / num_angles;
                double theta = dtheta / 2;
                for (int i = 0; i < num_angles; i++)
                {
                    // Convert into a counterclocckwise angle
                    // where 0 is to the right.
                    double angle = 90 - theta;

                    // Math.Sin and Math.Cos use radians.
                    double radians = (angle - 90) / 180 * Math.PI;
                    double x = cx + radius * Math.Cos(radians);
                    double y = cy + radius * Math.Sin(radians);

                    // Use theta for the text, not angle.
                    string text = ((int)theta).ToString();

                    // Draw the text.
                    DrawText(canGraph, text,
                        new Point(x, y), angle, font_size,
                        HorizontalAlignment.Center,
                        VerticalAlignment.Center);

                    theta += dtheta;
                }
                font_size += 3;
            }
        }

        // Zoom.
        private double Zoom = 1;
        private void sliZoom_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            // Make sure the control's are all ready.
            if (!IsInitialized) return;

            // Display the zoom factor as a percentage.
            lblZoom.Content = sliZoom.Value + "%";

            // Get the scale factor as a fraction 0.25 - 2.00.
            double scale = (double)(sliZoom.Value / 100.0);

            // Scale the graph.
            canGraph.LayoutTransform = new ScaleTransform(scale, scale);
        }

        // Position a label at the indicated point.
        private void DrawText(Canvas can, string text,
            Point location, double angle, double font_size,
            HorizontalAlignment halign, VerticalAlignment valign)
        {
            // Make the label.
            Label label = new Label();
            label.Content = text;
            label.FontSize = font_size;
            can.Children.Add(label);

            // Rotate if desired.
            if (angle != 0)
                label.LayoutTransform = new RotateTransform(angle);

            // Position the label.
            label.Measure(new Size(double.MaxValue, double.MaxValue));

            double x = location.X;
            if (halign == HorizontalAlignment.Center)
                x -= label.DesiredSize.Width / 2;
            else if (halign == HorizontalAlignment.Right)
                x -= label.DesiredSize.Width;
            Canvas.SetLeft(label, x);

            double y = location.Y;
            if (valign == VerticalAlignment.Center)
                y -= label.DesiredSize.Height / 2;
            else if (valign == VerticalAlignment.Bottom)
                y -= label.DesiredSize.Height;
            Canvas.SetTop(label, y);

            // Uncomment the following code to see
            // the Label's bounding rectangle.
            //Rectangle rect = new Rectangle();
            //rect.Width = label.DesiredSize.Width;
            //rect.Height = label.DesiredSize.Height;
            //rect.StrokeThickness = 1;
            //rect.Stroke = Brushes.Red;
            //can.Children.Add(rect);
            //Canvas.SetLeft(rect, x);
            //Canvas.SetTop(rect, y);
        }
    }
}
