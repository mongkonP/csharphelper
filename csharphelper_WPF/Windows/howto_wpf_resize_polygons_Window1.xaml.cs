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

// Notes:
//  - The Canvas must have a non-null background to make it generate mouse events.

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_resize_polygons_Window1.xaml
    /// </summary>
    public partial class howto_wpf_resize_polygons_Window1 : Window
    {
        public howto_wpf_resize_polygons_Window1()
        {
            InitializeComponent();
        }

        // The part of the shape the mouse is over.
        private enum HitType
        {
            None, Body, UL, UR, LR, LL, L, R, T, B
        };

        // True if a drag is in progress.
        private bool DragInProgress = false;

        // The drag's last point.
        private Point LastPoint;

        // The part of the shape under the mouse.
        private HitType MouseHitType = HitType.None;

        // The shape that was hit.
        private Shape HitShape = null;

        // The shapes that the user can move and resize.
        private List<Shape> Shapes;

        // Make a list of the shapes that the user can move.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Shapes = new List<Shape>();
            foreach (UIElement child in canvas1.Children)
            {
                if (child is Shape)
                    Shapes.Add(child as Shape);
            }

            // Reverse the list so the shapes on top come first.
            Shapes.Reverse();
        }

        // If the point is over any shape,
        // return the shape and the hit type.
        private void FindHit(Point point)
        {
            HitShape = null;
            MouseHitType = HitType.None;

            foreach (Shape shape in Shapes)
            {
                MouseHitType = SetHitType(shape, point);
                if (MouseHitType != HitType.None)
                {
                    HitShape = shape;
                    return;
                }
            }

            // We didn't find a hit.
            return;
        }

        // Return a HitType value to indicate what is at the point.
        private HitType SetHitType(Shape shape, Point point)
        {
            double left, right, top, bottom;
            GetLRTB(shape, out left, out right, out top, out bottom);

            if (point.X < left) return HitType.None;
            if (point.X > right) return HitType.None;
            if (point.Y < top) return HitType.None;
            if (point.Y > bottom) return HitType.None;

            const double GAP = 10;
            if (point.X - left < GAP)
            {
                // Left edge.
                if (point.Y - top < GAP) return HitType.UL;
                if (bottom - point.Y < GAP) return HitType.LL;
                return HitType.L;
            }
            if (right - point.X < GAP)
            {
                // Right edge.
                if (point.Y - top < GAP) return HitType.UR;
                if (bottom - point.Y < GAP) return HitType.LR;
                return HitType.R;
            }
            if (point.Y - top < GAP) return HitType.T;
            if (bottom - point.Y < GAP) return HitType.B;
            return HitType.Body;
        }

        // Return the shape's left, right, top, and bottom.
        private void GetLRTB(Shape shape,
            out double left, out double right,
            out double top, out double bottom)
        {
            if (!(shape is Polygon))
            {
                left = Canvas.GetLeft(shape);
                top = Canvas.GetTop(shape);
                right = left + shape.ActualWidth;
                bottom = top + shape.ActualHeight;
                return;
            }

            // Handle polygons separately.
            Polygon polygon = shape as Polygon;
            left = polygon.Points[0].X;
            right = left;
            top = polygon.Points[0].Y;
            bottom = top;
            foreach (Point point in polygon.Points)
            {
                if (left > point.X) left = point.X;
                if (right < point.X) right = point.X;
                if (top > point.Y) top = point.Y;
                if (bottom < point.Y) bottom = point.Y;
            }
        }

        // Set a mouse cursor appropriate for the current hit type.
        private void SetMouseCursor()
        {
            // See what cursor we should display.
            Cursor desired_cursor = Cursors.Arrow;
            switch (MouseHitType)
            {
                case HitType.None:
                    desired_cursor = Cursors.Arrow;
                    break;
                case HitType.Body:
                    desired_cursor = Cursors.ScrollAll;
                    break;
                case HitType.UL:
                case HitType.LR:
                    desired_cursor = Cursors.SizeNWSE;
                    break;
                case HitType.LL:
                case HitType.UR:
                    desired_cursor = Cursors.SizeNESW;
                    break;
                case HitType.T:
                case HitType.B:
                    desired_cursor = Cursors.SizeNS;
                    break;
                case HitType.L:
                case HitType.R:
                    desired_cursor = Cursors.SizeWE;
                    break;
            }

            // Display the desired cursor.
            if (Cursor != desired_cursor) Cursor = desired_cursor;
        }

        // Start dragging.
        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FindHit(Mouse.GetPosition(canvas1));
            SetMouseCursor();
            if (MouseHitType == HitType.None) return;

            LastPoint = Mouse.GetPosition(canvas1);
            DragInProgress = true;
        }

        // If a drag is in progress, continue the drag.
        // Otherwise display the correct cursor.
        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DragInProgress)
            {
                FindHit(Mouse.GetPosition(canvas1));
                SetMouseCursor();
            }
            else
            {
                ResizeShape();
            }
        }

        // Stop dragging.
        private void canvas1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DragInProgress = false;
        }

        private void ResizeShape()
        {
            // See how much the mouse has moved.
            Point point = Mouse.GetPosition(canvas1);
            double offset_x = point.X - LastPoint.X;
            double offset_y = point.Y - LastPoint.Y;

            // Get the shape's current position.
            double left, right, top, bottom;
            GetLRTB(HitShape, out left, out right, out top, out bottom);

            double new_x = left;
            double new_y = top;
            double new_width = right - left;
            double new_height = bottom - top;

            // Update the shape.
            switch (MouseHitType)
            {
                case HitType.Body:
                    new_x += offset_x;
                    new_y += offset_y;
                    break;
                case HitType.UL:
                    new_x += offset_x;
                    new_y += offset_y;
                    new_width -= offset_x;
                    new_height -= offset_y;
                    break;
                case HitType.UR:
                    new_y += offset_y;
                    new_width += offset_x;
                    new_height -= offset_y;
                    break;
                case HitType.LR:
                    new_width += offset_x;
                    new_height += offset_y;
                    break;
                case HitType.LL:
                    new_x += offset_x;
                    new_width -= offset_x;
                    new_height += offset_y;
                    break;
                case HitType.L:
                    new_x += offset_x;
                    new_width -= offset_x;
                    break;
                case HitType.R:
                    new_width += offset_x;
                    break;
                case HitType.B:
                    new_height += offset_y;
                    break;
                case HitType.T:
                    new_y += offset_y;
                    new_height -= offset_y;
                    break;
            }

            // If the new width or height is not positive, do nothing.
            if ((new_width <= 0) || (new_height <= 0)) return;

            // Update the shape.
            if (HitShape is Polygon)
            {
                // Update a polygon.
                UpdatePolygon(left, right, top, bottom,
                    new_x, new_y, new_width, new_height);
            }
            else
            {
                // Update a non-polygon.
                Canvas.SetLeft(HitShape, new_x);
                Canvas.SetTop(HitShape, new_y);
                HitShape.Width = new_width;
                HitShape.Height = new_height;
            }

            // Save the mouse's new location.
            LastPoint = point;
        }

        // Update the polygon's size and position.
        private void UpdatePolygon(
            double left, double right, double top, double bottom,
            double new_x, double new_y, double new_width, double new_height)
        {
            // Get scale factors to give the polygon its new size.
            double x_scale = new_width / (right - left);
            double y_scale = new_height / (bottom - top);
            
            // Loop through the points and adjust them.
            Polygon polygon = HitShape as Polygon;
            List<Point> new_points = new List<Point>();
            foreach(Point point in polygon.Points)
            {
                double x = new_x + x_scale * (point.X - left);
                double y = new_y + y_scale * (point.Y - top);
                new_points.Add(new Point(x, y));
            }
            polygon.Points = new PointCollection(new_points);
        }
    }
}
