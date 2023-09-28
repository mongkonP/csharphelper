
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

  namespace  howto_clip_image_to_polygon

 { 

public class PolygonEventArgs
    {
        public List<Point> Points;
        public PolygonEventArgs(List<Point> points)
        {
            Points = points;
        }
    }











    public class PolygonSelector
    {
        // The control on which the polygon will be selected.
        private Control Host;

        // The pen used while selecting the polygon.
        private Pen PolygonPen;

        // The points in the polygon.
        private List<Point> PolygonPoints;

        public PolygonSelector(Control host, Pen pen)
        {
            Host = host;
            PolygonPen = pen;

            // Install a MouseDown event handler.
            Host.MouseDown += Host_MouseDown;
        }

        // On left mouse down, start selecting a polygon.
        private void Host_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            // Uninstall picCanvas_MouseDown.
            Host.MouseDown -= Host_MouseDown;

            // Add the first point and a copy to be the last point.
            PolygonPoints = new List<Point>();
            PolygonPoints.Add(e.Location);
            PolygonPoints.Add(e.Location);

            // Install an event handler to catch clicks.
            Host.Paint += Host_Paint;
            Host.MouseMove += Host_MouseMove;
            Host.MouseClick += Host_MouseClick;
        }

        // Draw the polygon so far.
        private void Host_Paint(object sender, PaintEventArgs e)
        {
            if (PolygonPoints.Count > 1)
            {
                e.Graphics.DrawLines(PolygonPen,
                    PolygonPoints.ToArray());
            }
        }

        // Update the last point's position and redraw.
        private void Host_MouseMove(object sender, MouseEventArgs e)
        {
            PolygonPoints[PolygonPoints.Count - 1] = e.Location;
            Host.Refresh();
        }

        // Add a point to the polygon or end the polygon.
        private void Host_MouseClick(object sender, MouseEventArgs e)
        {
            int num_points = PolygonPoints.Count;

            // See which button was clicked.
            if (e.Button == MouseButtons.Right)
            {
                // Right button. End the polygon.
                // Remove the last point.
                PolygonPoints.RemoveAt(num_points - 1);

                // Uninstall our event handlers.
                Host.Paint -= Host_Paint;
                Host.MouseMove -= Host_MouseMove;
                Host.MouseClick -= Host_MouseClick;

                // Raise the PolygonSelected event.
                OnPolygonSelected();

                // Reinstall the MouseDown event handler.
                Host.MouseDown += Host_MouseDown;
            }
            else
            {
                // Make the last point permanent.
                // If the last point is different from the
                // one before, add a new last point.
                if (PolygonPoints[num_points - 1] != PolygonPoints[num_points - 2])
                {
                    PolygonPoints.Add(e.Location);
                    Host.Refresh();
                }
            }
        }

        // Event to raise when a polygon is selected.
        public delegate void PolygonSelectedEventHandler(
            object sender, PolygonEventArgs args);
        public event PolygonSelectedEventHandler PolygonSelected;

        // Raise the event.
        protected virtual void OnPolygonSelected()
        {
            if ((PolygonSelected == null) ||
                (PolygonPoints.Count < 3))
            {
                Host.Refresh();
            }
            else
            {
                PolygonEventArgs args =
                    new PolygonEventArgs(PolygonPoints);
                PolygonSelected(this, args);
            }
        }

        // Enable or disable the selector.
        private bool IsEnabled = true;
        public bool Enabled
        {
            get
            {
                return IsEnabled;
            }
            set
            {
                if (value == IsEnabled) return;

                IsEnabled = value;
                if (IsEnabled)
                {
                    Host.MouseDown += Host_MouseDown;
                }
                else
                {
                    Host.MouseDown -= Host_MouseDown;
                    Host.MouseMove -= Host_MouseMove;
                    Host.MouseClick -= Host_MouseClick;
                    Host.Paint -= Host_Paint;
                }
            }
        }
    }

}