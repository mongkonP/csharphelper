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
    /// Interaction logic for wpf_arc_extension_Window1.xaml
    /// </summary>
    public partial class wpf_arc_extension_Window1 : Window
    {
        public wpf_arc_extension_Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Rect rect = new Rect(60, 30, 180, 140);

            // Draw an ellipse.
            canDrawing.DrawEllipse(null, Brushes.Yellow, 10, rect);

            // Outline the ellipse's rectangle.
            Rectangle rectangle = canDrawing.DrawRectangle(
                null, Brushes.Green, 2, rect);
            rectangle.StrokeDashArray =
                new DoubleCollection(new double[] { 5, 5 });

            // Draw the arc.
            Point point1, point2;
            canDrawing.DrawArc(
                null, Brushes.Red, 2, rect,
                0.25 * Math.PI, Math.PI, true,
                SweepDirection.Counterclockwise,
                out point1, out point2);

            canDrawing.DrawArc(
                null, Brushes.Blue, 2, rect,
                0.25 * Math.PI, Math.PI, false,
                SweepDirection.Clockwise,
                out point1, out point2);

            Path path1 = canDrawing.DrawArc(
                null, Brushes.Red, 2, rect,
                0.25 * Math.PI, Math.PI, false,
                SweepDirection.Counterclockwise,
                out point1, out point2);
            path1.StrokeDashArray = new DoubleCollection(
                new double[] { 5, 5 });

            Path path2 = canDrawing.DrawArc(
                null, Brushes.Blue, 2, rect,
                0.25 * Math.PI, Math.PI, true,
                SweepDirection.Clockwise,
                out point1, out point2);
            path2.StrokeDashArray = new DoubleCollection(
                new double[] { 5, 5 });

            // Draw the arc's end points.
            canDrawing.DrawPoint(Brushes.White, Brushes.Black,
                1, point1, 6);
            canDrawing.DrawPoint(Brushes.White, Brushes.Black,
                1, point2, 6);
        }
    }
}
