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
    /// Interaction logic for howto_wpf_line_editor_Window1.xaml
    /// </summary>
    public partial class howto_wpf_line_editor_Window1 : Window
    {
        public howto_wpf_line_editor_Window1()
        {
            InitializeComponent();
        }

        // The "size" of an object for mouse over purposes.
        private const int object_radius = 3;

        // We're over an object if the distance squared
        // between the mouse and the object is less than this.
        private const int over_dist_squared = object_radius * object_radius;

        // The line we're drawing or moving.
        private Line SelectedLine;

        // True if we're moving the line's first starting end point.
        private bool MovingStartEndPoint = false;

        // The offset from the mouse to the object being moved.
        private double OffsetX, OffsetY;

        // Save the trash can dimensions.
        private double TrashWidth, TrashHeight;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TrashWidth = imgTrash.ActualWidth;
            TrashHeight = imgTrash.ActualHeight;

            // The Canvas must have a non-transparent background
            // to make it receive mouse events.
            canDrawing.Background = Brushes.White;
        }

        // The mouse is up. See whether we're over an end point or segment.
        private void canDrawing_MouseMove_NotDown(object sender, MouseEventArgs e)
        {
            Cursor new_cursor = Cursors.Cross;

            // See what we're over.
            Point location = e.MouseDevice.GetPosition(canDrawing);
            if (MouseIsOverEndpoint(location, out SelectedLine, out MovingStartEndPoint))
                new_cursor = Cursors.Arrow;
            else if (MouseIsOverLine(location, out SelectedLine))
                new_cursor = Cursors.Hand;

            // Set the new cursor.
            if (canDrawing.Cursor != new_cursor)
                canDrawing.Cursor = new_cursor;
        }

        // See what we're over and start doing whatever is appropriate.
        private void canDrawing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // See what we're over.
            Point location = e.MouseDevice.GetPosition(canDrawing);
            if (MouseIsOverEndpoint(location, out SelectedLine, out MovingStartEndPoint))
            {
                // Start moving this end point.
                canDrawing.MouseMove -= canDrawing_MouseMove_NotDown;
                canDrawing.MouseMove += canDrawing_MouseMove_MovingEndPoint;
                canDrawing.MouseUp += canDrawing_MouseUp_MovingEndPoint;

                // Remember the offset from the mouse to the point.
                Point hit_point;
                if (MovingStartEndPoint)
                    hit_point = new Point(SelectedLine.X1, SelectedLine.Y1);
                else
                    hit_point = new Point(SelectedLine.X2, SelectedLine.Y2);
                OffsetX = hit_point.X - location.X;
                OffsetY = hit_point.Y - location.Y;
            }
            else if (MouseIsOverLine(location, out SelectedLine))
            {
                // Start moving this segment.
                canDrawing.MouseMove -= canDrawing_MouseMove_NotDown;
                canDrawing.MouseMove += canDrawing_MouseMove_MovingSegment;
                canDrawing.MouseUp += canDrawing_MouseUp_MovingSegment;

                // Remember the offset from the mouse
                // to the segment's first end point.
                OffsetX = SelectedLine.X1 - location.X;
                OffsetY = SelectedLine.Y1 - location.Y;
            }
            else
            {
                // Start drawing a new segment.
                canDrawing.MouseMove -= canDrawing_MouseMove_NotDown;
                canDrawing.MouseMove += canDrawing_MouseMove_Drawing;
                canDrawing.MouseUp += canDrawing_MouseUp_Drawing;

                SelectedLine = new Line();
                SelectedLine.Stroke = Brushes.Red;
                SelectedLine.X1 = location.X;
                SelectedLine.Y1 = location.Y;
                SelectedLine.X2 = location.X;
                SelectedLine.Y2 = location.Y;
                canDrawing.Children.Add(SelectedLine);
            }
        }

#region Distance Methods

        // See if the mouse is over an end point.
        private bool MouseIsOverEndpoint(Point mouse_pt, out Line hit_line, out bool start_endpoint)
        {
            foreach (object obj in canDrawing.Children)
            {
                // Only process Lines.
                if (obj is Line)
                {
                    Line line = obj as Line;

                    // Check the starting point.
                    Point point = new Point(line.X1, line.Y1);
                    if (FindDistanceToPointSquared(mouse_pt, point) < over_dist_squared)
                    {
                        // We're over this point.
                        hit_line = line;
                        start_endpoint = true;
                        return true;
                    }

                    // Check the end point.
                    point = new Point(line.X2, line.Y2);
                    if (FindDistanceToPointSquared(mouse_pt, point) < over_dist_squared)
                    {
                        // We're over this point.
                        hit_line = line;
                        start_endpoint = false;
                        return true;
                    }
                }
            }

            hit_line = null;
            start_endpoint = false;
            return false;
        }

        // See if the mouse is over a line segment.
        private bool MouseIsOverLine(Point mouse_pt, out Line hit_line)
        {
            foreach (object obj in canDrawing.Children)
            {
                // Only process Lines.
                if (obj is Line)
                {
                    Line line = obj as Line;

                    // See if we're over this line.
                    Point closest;
                    Point pt1 = new Point(line.X1, line.Y1);
                    Point pt2 = new Point(line.X2, line.Y2);
                    if (FindDistanceToSegmentSquared(
                        mouse_pt, pt1, pt2, out closest)
                            < over_dist_squared)
                    {
                        // We're over this segment.
                        hit_line = line;
                        return true;
                    }
                }
            }

            hit_line = null;
            return false;
        }

        // Calculate the distance squared between two points.
        private double FindDistanceToPointSquared(Point pt1, Point pt2)
        {
            double dx = pt1.X - pt2.X;
            double dy = pt1.Y - pt2.Y;
            return dx * dx + dy * dy;
        }

        // Calculate the distance squared between
        // point pt and the segment p1 --> p2.
        private double FindDistanceToSegmentSquared(Point pt, Point p1, Point p2, out Point closest)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return dx * dx + dy * dy;
            }

            // Calculate the t that minimizes the distance.
            double t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new Point(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new Point(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new Point(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return dx * dx + dy * dy;
        }

#endregion Distance Methods

#region Moving End Point

        // We're moving an end point.
        private void canDrawing_MouseMove_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Move the point to its new location.
            Point location = e.MouseDevice.GetPosition(canDrawing);
            if (MovingStartEndPoint)
            {
                SelectedLine.X1 = location.X + OffsetX;
                SelectedLine.Y1 = location.Y + OffsetY;
            }
            else
            {
                SelectedLine.X2 = location.X + OffsetX;
                SelectedLine.Y2 = location.Y + OffsetY;
            }
        }

        // Stop moving the end point.
        private void canDrawing_MouseUp_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            canDrawing.MouseMove += canDrawing_MouseMove_NotDown;
            canDrawing.MouseMove -= canDrawing_MouseMove_MovingEndPoint;
            canDrawing.MouseUp -= canDrawing_MouseUp_MovingEndPoint;
        }

#endregion Moving End Point

#region Drawing

        // We're drawing a new segment.
        private void canDrawing_MouseMove_Drawing(object sender, MouseEventArgs e)
        {
            // Update the new line's end point.
            Point location = e.MouseDevice.GetPosition(canDrawing);
            SelectedLine.X2 = location.X;
            SelectedLine.Y2 = location.Y;
        }

        // Stop drawing.
        private void canDrawing_MouseUp_Drawing(object sender, MouseEventArgs e)
        {
            SelectedLine.Stroke = Brushes.Black;

            // Reset the event handlers.
            canDrawing.MouseMove -= canDrawing_MouseMove_Drawing;
            canDrawing.MouseMove += canDrawing_MouseMove_NotDown;
            canDrawing.MouseUp -= canDrawing_MouseUp_Drawing;

            // If the new segment has no length, delete it.
            if ((SelectedLine.X1 == SelectedLine.X2) && (SelectedLine.Y1 == SelectedLine.Y2))
                canDrawing.Children.Remove(SelectedLine);
        }

#endregion Drawing

#region "Moving Segment"

        // We're moving a segment.
        private void canDrawing_MouseMove_MovingSegment(object sender, MouseEventArgs e)
        {
            // Find the new location for the first end point.
            Point location = e.MouseDevice.GetPosition(canDrawing);
            double new_x1 = location.X + OffsetX;
            double new_y1 = location.Y + OffsetY;

            // See how far we are moving that point.
            double dx = new_x1 - SelectedLine.X1;
            double dy = new_y1 - SelectedLine.Y1;

            // Move the line.
            SelectedLine.X1 = new_x1;
            SelectedLine.Y1 = new_y1;
            SelectedLine.X2 += dx;
            SelectedLine.Y2 += dy;
        }

        // Stop moving the segment.
        private void canDrawing_MouseUp_MovingSegment(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            canDrawing.MouseMove += canDrawing_MouseMove_NotDown;
            canDrawing.MouseMove -= canDrawing_MouseMove_MovingSegment;
            canDrawing.MouseUp -= canDrawing_MouseUp_MovingSegment;

            // See if the mouse is over the trash can.
            Point location = e.MouseDevice.GetPosition(canDrawing);
            if ((location.X >= 0) && (location.X < TrashWidth) &&
                (location.Y >= 0) && (location.Y < TrashHeight))
            {
                if (MessageBox.Show("Delete this segment?",
                    "Delete Segment?", MessageBoxButton.YesNo)
                        == MessageBoxResult.Yes)
                {
                    // Delete the segment.
                    canDrawing.Children.Remove(SelectedLine);
                }
            }
        }

#endregion // Moving End Point

    }
}
