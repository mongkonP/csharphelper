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

namespace howto_wpf_render_polygon
{
    public static class DrawingContextExtensions
    {
        // Draw a polygon.
        public static void DrawPolygon(this DrawingContext drawingContext,
            Brush brush, Pen pen, Point[] points, FillRule fill_rule)
        {
            drawingContext.DrawPolygonOrPolyline(brush, pen, points, fill_rule, true);
        }

        // Draw a polyline.
        public static void DrawPolyline(this DrawingContext drawingContext,
            Brush brush, Pen pen, Point[] points, FillRule fill_rule)
        {
            drawingContext.DrawPolygonOrPolyline(brush, pen, points, fill_rule, false);
        }

        // Draw a polygon or polyline.
        private static void DrawPolygonOrPolyline(
            this DrawingContext drawingContext,
            Brush brush, Pen pen, Point[] points, FillRule fill_rule,
            bool draw_polygon)
        {
            // Make a StreamGeometry to hold the drawing objects.
            StreamGeometry geo = new StreamGeometry();
            geo.FillRule = fill_rule;

            // Open the context to use for drawing.
            using (StreamGeometryContext context = geo.Open())
            {
                // Start at the first point.
                context.BeginFigure(points[0], true, draw_polygon);
                
                // Add the points after the first one.
                context.PolyLineTo(points.Skip(1).ToArray(), true, false);
            }

            // Draw.
            drawingContext.DrawGeometry(brush, pen, geo);
        }
    }
}
