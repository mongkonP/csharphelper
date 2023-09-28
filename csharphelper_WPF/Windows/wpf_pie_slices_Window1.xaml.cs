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
    /// Interaction logic for wpf_pie_slices_Window1.xaml
    /// </summary>
    public partial class wpf_pie_slices_Window1 : Window
    {
        public wpf_pie_slices_Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Rect rect = new Rect(25, 70, 240, 140);

            // Draw a pie slice.
            Point point1, point2;
            Path pie_slice1 = canDrawing.DrawPieSlice(
                Brushes.Yellow, Brushes.Orange,
                5, rect, 0, 0.15 * Math.PI, false,
                SweepDirection.Clockwise,
                out point1, out point2);
            pie_slice1.StrokeLineJoin = PenLineJoin.Round;

            // Draw a pie slice.
            Path pie_slice2 = canDrawing.DrawPieSlice(
                Brushes.Pink, Brushes.Red,
                5, rect, 0.15 * Math.PI, 0.6 * Math.PI, false,
                SweepDirection.Clockwise,
                out point1, out point2);
            pie_slice2.StrokeLineJoin = PenLineJoin.Round;

            // Draw a pie slice.
            Path pie_slice3 = canDrawing.DrawPieSlice(
                Brushes.LightBlue, Brushes.Blue,
                5, rect, 0.6 * Math.PI, 1.25 * Math.PI, false,
                SweepDirection.Clockwise,
                out point1, out point2);
            pie_slice3.StrokeLineJoin = PenLineJoin.Round;

            // Draw a pie slice.
            Path pie_slice4 = canDrawing.DrawPieSlice(
                Brushes.LightGreen, Brushes.Green,
                5, rect, 1.25 * Math.PI, 1.6 * Math.PI, false,
                SweepDirection.Clockwise,
                out point1, out point2);
            pie_slice4.StrokeLineJoin = PenLineJoin.Round;

            // Draw a pie slice.
            Path pie_slice5 = canDrawing.DrawPieSlice(
                Brushes.Fuchsia, Brushes.Purple,
                5, rect, 1.6 * Math.PI, 2 * Math.PI, false,
                SweepDirection.Clockwise,
                out point1, out point2);
            pie_slice5.StrokeLineJoin = PenLineJoin.Round;

            // Draw the ellipse.
            //Ellipse ellipse = canDrawing.DrawEllipse(
            //    null, Brushes.Black, 2, rect);
            //ellipse.StrokeDashArray =
            //    new DoubleCollection(new double[] {5, 5});
        }
    }
}
