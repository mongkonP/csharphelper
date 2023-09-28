using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace wpf_drawing_extensions
{
    public static class DrawingExtensions
    {
        // Add a Rectangle to a Canvas.
        public static Rectangle DrawRectangle(
            this Canvas canvas, Brush fill, Brush stroke,
            double stroke_thickness, Rect rect)
        {
            return canvas.DrawRectangle(fill, stroke,
                stroke_thickness, rect.Left, rect.Top,
                rect.Width, rect.Height);
        }
        public static Rectangle DrawRectangle(
            this Canvas canvas, Brush fill, Brush stroke,
            double stroke_thickness, double left,
            double top, double width, double height)
        {
            Rectangle rectangle = new Rectangle();
            Canvas.SetLeft(rectangle, left);
            Canvas.SetTop(rectangle, top);
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Fill = fill;
            rectangle.Stroke = stroke;
            rectangle.StrokeThickness = stroke_thickness;
            canvas.Children.Add(rectangle);
            return rectangle;
        }

        // Add an Ellipse to a Canvas.
        public static Ellipse DrawEllipse(
            this Canvas canvas, Brush fill, Brush stroke,
            double stroke_thickness, Rect rect)
        {
            return canvas.DrawEllipse(fill, stroke,
                stroke_thickness, rect.Left, rect.Top,
                rect.Width, rect.Height);
        }
        public static Ellipse DrawEllipse(
            this Canvas canvas, Brush fill, Brush stroke,
            double stroke_thickness, double left, double top,
            double width, double height)
        {
            Ellipse ellipse = new Ellipse();
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse, top);
            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.Fill = fill;
            ellipse.Stroke = stroke;
            ellipse.StrokeThickness = stroke_thickness;
            canvas.Children.Add(ellipse);
            return ellipse;
        }

        // Add a line to a Canvas.
        public static Line DrawLine(
            this Canvas canvas, Brush stroke,
            double stroke_thickness, double x1, double y1,
            double x2, double y2)
        {
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = stroke;
            line.StrokeThickness = stroke_thickness;
            canvas.Children.Add(line);
            return line;
        }

        // Add a polyline to a Canvas.
        public static Polyline DrawPolyline(
            this Canvas canvas, Brush stroke,
            double stroke_thickness,
            IEnumerable<Point> points)
        {
            Polyline polyline = new Polyline();
            polyline.Points = new PointCollection(points);
            polyline.Stroke = stroke;
            polyline.StrokeThickness = stroke_thickness;
            canvas.Children.Add(polyline);
            return polyline;
        }
    }
}
