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
    /// Interaction logic for wpf_draw_gradient_Window1.xaml
    /// </summary>
    public partial class wpf_draw_gradient_Window1 : Window
    {
        public wpf_draw_gradient_Window1()
        {
            InitializeComponent();
        }

        // Draw an ellipse with a LinearGradient fill and outline.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Make the ellipse and add it to the Canvas.
            Ellipse ellipse = new Ellipse();
            canDrawing.Children.Add(ellipse);

            // Set the size and position.
            ellipse.Width = 240;
            ellipse.Height = 100;
            Canvas.SetTop(ellipse, 140);
            Canvas.SetLeft(ellipse, 20);

            // Define the fill.
            GradientStop[] fill_stops =
            {
                new GradientStop(Colors.Brown, 0.0),
                new GradientStop(Colors.Yellow, 1.0),
            };
            GradientStopCollection fill_stop_collection =
                new GradientStopCollection(fill_stops);
            LinearGradientBrush fill_brush =
                new LinearGradientBrush(fill_stop_collection,
                    new Point(0.0, 0.0), new Point(0.0, 1.0));
            ellipse.Fill = fill_brush;

            // Define the outline.
            ellipse.StrokeThickness = 15;
            GradientStop[] outline_stops =
            {
                new GradientStop(Colors.Yellow, 0.0),
                new GradientStop(Colors.Brown, 1.0),
            };
            GradientStopCollection outline_stop_collection =
                new GradientStopCollection(outline_stops);
            LinearGradientBrush outline_brush =
                new LinearGradientBrush(outline_stop_collection,
                    new Point(0.0, 0.0), new Point(0.0, 1.0));
            ellipse.Stroke = outline_brush;
        }
    }
}
