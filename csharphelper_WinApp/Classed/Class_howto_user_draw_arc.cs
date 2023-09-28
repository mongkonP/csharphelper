
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_user_draw_arc

 { 

class Arc
    {
        // Geometry.
        private RectangleF _Bounds;
        private float _StartAngle, _SweepAngle;
        public RectangleF Bounds
        {
            get { return _Bounds; }
            set
            {
                _Bounds = value;
                SetArcEndPoints();
            }
        }
        public float StartAngle
        {
            get { return _StartAngle; }
            set
            {
                _StartAngle = value;
                SetArcEndPoints();
            }
        }
        public float SweepAngle
        {
            get { return _SweepAngle; }
            set
            {
                _SweepAngle = value;
                SetArcEndPoints();
            }
        }
        public float EndAngle
        {
            get { return _StartAngle + _SweepAngle; }
        }
        public PointF Center
        {
            get
            {
                return new PointF(
                    Bounds.X + Bounds.Width / 2,
                    Bounds.Y + Bounds.Height / 2);
            }
        }

        // Calculated when the geometry parameters change.
        public PointF[] EndPoints = null;

        public Arc(RectangleF bounds, float start_angle, float sweep_angle)
        {
            _Bounds = bounds;
            _StartAngle = start_angle;
            _SweepAngle = sweep_angle;

            // Make the sweep angle positive.
            if (_SweepAngle < 0)
            {
                _StartAngle += _SweepAngle;
                _SweepAngle = -_SweepAngle;
            }

            // Make StartAngle between 0 and 360.
            while (_StartAngle < 0) _StartAngle += 360;
            while (_StartAngle > 360) _StartAngle -= 360;

            // Find the end points.
            SetArcEndPoints();
        }

        public void Draw(Graphics gr, Brush brush, Pen pen)
        {
            // If the bounding rectangle has
            // zero height or width, do nothing.
            if ((Bounds.Width == 0) || (Bounds.Height == 0))
                return;

            // Fill and draw as appropriate.
            if (brush != null)
                gr.FillPie(brush,
                    Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height,
                    StartAngle, SweepAngle);
            if (pen != null)
                gr.DrawArc(pen,
                    Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height,
                    StartAngle, SweepAngle);
        }

        // Draw boxes at the arc's end points.
        public void DrawEndPoints(Graphics gr,
            Brush brush, Pen pen, float radius)
        {
            for (int i = 0; i < 2; i++)
            {
                // Fill and draw as appropriate.
                RectangleF rect = new RectangleF(
                    EndPoints[i].X - radius,
                    EndPoints[i].Y - radius,
                    2 * radius, 2 * radius);
                if (brush != null) gr.FillRectangle(brush, rect);
                if (pen != null)
                    gr.DrawRectangle(pen,
                        rect.X, rect.Y, rect.Width, rect.Height);
            }
        }

#region Arc Parts

        // Pieces of the arc that the mouse might be over.
        public enum Part
        {
            None,
            StartPoint,
            EndPoint,
            Body,
        }

        // Return the part of the arc that is at the given point.
        public Part ArcPartAtPoint(Point target, float radius)
        {
            // See if the mouse is at the start or end point.
            if (Distance(target, EndPoints[0]) < radius)
                return Part.StartPoint;
            if (Distance(target, EndPoints[1]) < radius)
                return Part.EndPoint;

            // Find the angle from the ellipse's center to the point.
            PointF center = Center;
            float dx = target.X - center.X;
            float dy = target.Y - center.Y;
            float radians = (float)Math.Atan2(dy, dx);
            float degrees = (float)(radians * 180 / Math.PI);
            while (degrees < 0) degrees += 360;

            // See if the angle is within the ellipse's sweep.
            if ((degrees < StartAngle) ||
                (degrees > StartAngle + SweepAngle))
                return Part.None;

            // Find the point on the ellipse at this angle.
            PointF[] intersections =
                FindEllipseSegmentIntersections(
                    Bounds, center, target, false);
            for (int i = 0; i < intersections.Length; i++)
                if (Distance(target, intersections[i]) < radius)
                    return Part.Body;

            // It's not on the arc.
            return Part.None;
        }

        // Return the distance between two points.
        private float Distance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Find the points of intersection between
        // an ellipse and a line segment.
        private static PointF[] FindEllipseSegmentIntersections(
            RectangleF rect, PointF pt1, PointF pt2, bool segment_only)
        {
            // If the ellipse or line segment are empty, return no intersections.
            if ((rect.Width == 0) || (rect.Height == 0) ||
                ((pt1.X == pt2.X) && (pt1.Y == pt2.Y)))
                return new PointF[] { };

            // Make sure the rectangle has non-negative width and height.
            if (rect.Width < 0)
            {
                rect.X = rect.Right;
                rect.Width = -rect.Width;
            }
            if (rect.Height < 0)
            {
                rect.Y = rect.Bottom;
                rect.Height = -rect.Height;
            }

            // Translate so the ellipse is centered at the origin.
            float cx = rect.Left + rect.Width / 2f;
            float cy = rect.Top + rect.Height / 2f;
            rect.X -= cx;
            rect.Y -= cy;
            pt1.X -= cx;
            pt1.Y -= cy;
            pt2.X -= cx;
            pt2.Y -= cy;

            // Get the semimajor and semiminor axes.
            float a = rect.Width / 2;
            float b = rect.Height / 2;

            // Calculate the quadratic parameters.
            float A = (pt2.X - pt1.X) * (pt2.X - pt1.X) / a / a +
                       (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) / b / b;
            float B = 2 * pt1.X * (pt2.X - pt1.X) / a / a +
                       2 * pt1.Y * (pt2.Y - pt1.Y) / b / b;
            float C = pt1.X * pt1.X / a / a + pt1.Y * pt1.Y / b / b - 1;

            // Make a list of t values.
            List<float> t_values = new List<float>();

            // Calculate the discriminant.
            float discriminant = B * B - 4 * A * C;
            if (discriminant == 0)
            {
                // One real solution.
                t_values.Add(-B / 2 / A);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                t_values.Add((float)((-B + Math.Sqrt(discriminant)) / 2 / A));
                t_values.Add((float)((-B - Math.Sqrt(discriminant)) / 2 / A));
            }

            // Convert the t values into points.
            List<PointF> points = new List<PointF>();
            foreach (float t in t_values)
            {
                // If the points are on the segment (or we
                // don't care if they are), add them to the list.
                if (!segment_only || ((t >= 0f) && (t <= 1f)))
                {
                    float x = pt1.X + (pt2.X - pt1.X) * t + cx;
                    float y = pt1.Y + (pt2.Y - pt1.Y) * t + cy;
                    points.Add(new PointF(x, y));
                }
            }

            // Return the points.
            return points.ToArray();
        }

        // Find the points on an ellipse
        // at the indicated angles from is center.
        private void SetArcEndPoints()
        {
            // Find the ellipse's center.
            PointF center = new PointF(
                Bounds.X + Bounds.Width / 2f,
                Bounds.Y + Bounds.Height / 2f);

            // If the bounding rectangle has zero
            // height or width, use the center point
            // for both end points.
            if ((Bounds.Width == 0) ||
                (Bounds.Height == 0))
            {
                EndPoints = new PointF[] { center, center };
                return;
            }

            // Find the start and end angles in radians.
            double start_radians = StartAngle * Math.PI / 180;
            double end_radians = EndAngle * Math.PI / 180;

            // Find segments from the center in the
            // desired directions and long enough to
            // cut the ellipse.
            float dist = Bounds.Width + Bounds.Height;
            PointF pt1 = new PointF(
                (float)(center.X + dist * Math.Cos(start_radians)),
                (float)(center.Y + dist * Math.Sin(start_radians)));
            PointF pt2 = new PointF(
                (float)(center.X + dist * Math.Cos(end_radians)),
                (float)(center.Y + dist * Math.Sin(end_radians)));

            // Find the points of intersection.
            PointF[] intersections1 =
                FindEllipseSegmentIntersections(
                    Bounds, center, pt1, true);
            PointF[] intersections2 =
                FindEllipseSegmentIntersections(
                    Bounds, center, pt2, true);
            EndPoints = new PointF[]
                {
                    intersections1[0],
                    intersections2[0]
                };
        }

#endregion Arc Parts

        // Move the Arc.
        public void Move(int dx, int dy)
        {
            Bounds = new RectangleF(
                Bounds.X + dx,
                Bounds.Y + dy,
                Bounds.Width, Bounds.Height);
        }

        // Move the start point.
        public void MoveStartPoint(PointF point)
        {
            // Fond the angle the point makes with the center.
            PointF center = Center;
            float dx = point.X - center.X;
            float dy = point.Y - center.Y;

            // If the point is at the center, do nothing.
            if ((dx == 0) && (dy == 0)) return;

            float start_angle =
                (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
            if (start_angle < 0) start_angle += 360;

            // Calculate the end angle.
            float end_angle = StartAngle + SweepAngle;

            // Make sure
            // start_angle <= end_angle <= start_angle + 360
            while (end_angle < start_angle)
                end_angle += 360;
            while (end_angle > start_angle + 360)
                end_angle -= 360;

            // Calculate the sweep angle needed to
            // get to the ending point.
            float sweep_angle = end_angle - start_angle;

            StartAngle = start_angle;
            SweepAngle = sweep_angle;
        }

        // Move the end point.
        public void MoveEndPoint(PointF point)
        {
            // Fond the angle the point makes with the center.
            PointF center = Center;
            float dx = point.X - center.X;
            float dy = point.Y - center.Y;

            // If the point is at the center, do nothing.
            if ((dx == 0) && (dy == 0)) return;

            // Calculate the end angle.
            float end_angle =
                (float)(Math.Atan2(dy, dx) * 180 / Math.PI);

            // Make sure
            // start_angle <= end_angle <= start_angle + 360
            while (end_angle < StartAngle)
                end_angle += 360;
            while (end_angle > StartAngle + 360)
                end_angle -= 360;

            // Calculate the sweep angle.
            SweepAngle = end_angle - StartAngle;
        }
    }

}