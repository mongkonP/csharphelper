
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_rounded_polygon

 { 

public class ArcInfo
    {
        public RectangleF Rect;
        public float StartAngle, SweepAngle;
        public ArcInfo(RectangleF rect, float start_angle, float sweep_angle)
        {
            Rect = rect;
            StartAngle = start_angle;
            SweepAngle = sweep_angle;
        }
    }










    public static class Arcs
    {
        // Find a circular arc connecting the segments.
        // Return false if we cannot find the arc, presumably
        // because one of the segments' end points are the same.
        //
        // Return the arc's parameters. Also return new points
        // to define the segments so you can draw
        // s1_far -> s1_close -> arc -> s2_close -> s2_far.
        // Three of those points will be original segment points.
        public static bool FindArcWithRadius(
            PointF s1p1, PointF s1p2,
            PointF s2p1, PointF s2p2,
            float radius,
            out RectangleF rect,
            out float start_angle, out float sweep_angle,
            out PointF s1_far, out PointF s1_close,
            out PointF s2_far, out PointF s2_close)
        {
            rect = new RectangleF(0, 0, 0, 0);
            start_angle = float.NaN;
            sweep_angle = float.NaN;
            s1_far = new PointF();
            s1_close = new PointF();
            s2_far = new PointF();
            s2_close = new PointF();

            // See where the segments' lines intersect.
            PointF poi;
            bool lines_intersect, segments_intersect;
            PointF close1, close2;
            if (!FindIntersection(s1p1, s1p2, s2p1, s2p2,
                out lines_intersect, out segments_intersect,
                out poi, out close1, out close2))
                    return false;

            // Move back by distance radius from that point.
            float dist1 = s1p1.Distance(poi) - radius;
            s1p2 = PointAtDistance(s1p1, poi, dist1);
            float dist2 = s2p1.Distance(poi) - radius;
            s2p2 = PointAtDistance(s2p1, poi, dist2);

            // Find the circular arc.
            return FindArcFromSegments(
                s1p1, s1p2,
                s2p1, s2p2,
                out rect,
                out start_angle, out sweep_angle,
                out s1_far, out s1_close,
                out s2_far, out s2_close);
        }

        // Find a circular arc connecting the segments.
        // Return the arc's parameters. Also return new points
        // to define the segments so you can draw
        // s1_far -> s1_close -> arc -> s2_close -> s2_far.
        // Three os those points will be original segments points.
        public static bool FindArcFromSegments(
            PointF s1p1, PointF s1p2,
            PointF s2p1, PointF s2p2,
            out RectangleF rect,
            out float start_angle, out float sweep_angle,
            out PointF s1_far, out PointF s1_close,
            out PointF s2_far, out PointF s2_close)
        {
            rect = new RectangleF(0, 0, 0, 0);
            start_angle = float.NaN;
            sweep_angle = float.NaN;
            s1_far = new PointF();
            s1_close = new PointF();
            s2_far = new PointF();
            s2_close = new PointF();

            // See where the segments intersect.
            PointF poi;
            bool lines_intersect, segments_intersect;
            PointF close1, close2;
            if (!FindIntersection(s1p1, s1p2, s2p1, s2p2,
                out lines_intersect, out segments_intersect,
                out poi, out close1, out close2))
                    return false;
#if TEST
            LinesPoi = poi;
#endif

            // See if the lines intersect.
            if (!lines_intersect)
            {
                // The lines are parallel. Find the 180 degree arc.
                throw new NotImplementedException("The segments are parallel.");
            }

            // Find the point on each segment that is closest to the poi.
            float close_dist1, close_dist2, far_dist1, far_dist2;

            // Make s1_close be the closer of the points.
            if (s1p1.Distance(poi) < s1p2.Distance(poi))
            {
                s1_close = s1p1;
                s1_far = s1p2;
                close_dist1 = s1p1.Distance(poi);
                far_dist1 = s1p2.Distance(poi);
            }
            else
            {
                s1_close = s1p2;
                s1_far = s1p1;
                close_dist1 = s1p2.Distance(poi);
                far_dist1 = s1p1.Distance(poi);
            }

            // Make s2_close be the closer of the points.
            if (s2p1.Distance(poi) < s2p2.Distance(poi))
            {
                s2_close = s2p1;
                s2_far = s2p2;
                close_dist2 = s2p1.Distance(poi);
                far_dist2 = s1p2.Distance(poi);
            }
            else
            {
                s2_close = s2p2;
                s2_far = s2p1;
                close_dist2 = s2p2.Distance(poi);
                far_dist2 = s1p1.Distance(poi);
            }

            // See which of the close points is closer to the poi.
            if (close_dist1 < close_dist2)
            {
                // s1_close is closer to the poi than s2_close.
                // Find the point on seg2 that is distance
                // close_dist1 from the poi.
                s2_close = PointAtDistance(poi, s2_far, close_dist1);
                close_dist2 = close_dist1;
            }
            else
            {
                // s2_close is closer to the poi than s1_close.
                // Find the point on seg1 that is distance
                // close_dist2 from the poi.
                s1_close = PointAtDistance(poi, s1_far, close_dist2);
                close_dist1 = close_dist2;
            }

            // Find the arc.
            FindArcFromTangents(
                s1_close, s1_far,
                s2_close, s2_far,
                out rect, out start_angle, out sweep_angle);

            return true;
        }

        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        //
        // Return false if we cannot find an intersection,
        // either because one of the segments has two
        // identical end points or because the segments
        // are parallel.
        private static bool FindIntersection(
            PointF p1, PointF p2, PointF p3, PointF p4,
            out bool lines_intersect, out bool segments_intersect,
            out PointF intersection,
            out PointF close_p1, out PointF close_p2)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 =
                ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)
                    / denominator;
            if (float.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                close_p1 = new PointF(float.NaN, float.NaN);
                close_p2 = new PointF(float.NaN, float.NaN);
                return false;
            }
            lines_intersect = true;

            float t2 =
                ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)
                    / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect =
                ((t1 >= 0) && (t1 <= 1) &&
                 (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            close_p1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);

            return true;
        }

        // Find a point on the line p1 --> p2 that
        // is distance dist from point p1.
        private static PointF PointAtDistance(PointF p1, PointF p2, float dist)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float p1p2_dist = (float)Math.Sqrt(dx * dx + dy * dy);
            return new PointF(
                p1.X + dx / p1p2_dist * dist,
                p1.Y + dy / p1p2_dist * dist);
        }

        // Find the arc that connects points s1p2 and s2p2.
        private static void FindArcFromTangents(
            PointF s1_close, PointF s1_far,
            PointF s2_close, PointF s2_far,
            out RectangleF rect,
            out float start_angle, out float sweep_angle)
        {
            // Find the perpendicular lines.
            PointF perp_point1, perp_point2;

            float dx1 = s1_close.X - s1_far.X;
            float dy1 = s1_close.Y - s1_far.Y;
            perp_point1 = new PointF(
                s1_close.X - dy1,
                s1_close.Y + dx1);
#if TEST
            PerpPoint1 = perp_point1;
#endif

            float dx2 = s2_close.X - s2_far.X;
            float dy2 = s2_close.Y - s2_far.Y;
            perp_point2 = new PointF(
                s2_close.X + dy2,
                s2_close.Y - dx2);
#if TEST
            PerpPoint2 = perp_point2;
#endif

            // Find the point of intersection between segments
            // s1_close --> perp_point1 and
            // s2_close --> perp_point2.
            bool lines_intersect, segments_intersect;
            PointF poi, close_p1, close_p2;
            FindIntersection(
                s1_close, perp_point1,
                s2_close, perp_point2,
                out lines_intersect, out segments_intersect,
                out poi, out close_p1, out close_p2);
#if TEST
            PerpPoi = poi;
#endif

            // Find the radius.
            float dx = s1_close.X - poi.X;
            float dy = s1_close.Y - poi.Y;
            float radius = (float)Math.Sqrt(dx * dx + dy * dy);

            // Create the rectangle.
            rect = new RectangleF(
                poi.X - radius,
                poi.Y - radius,
                2 * radius, 2 * radius);

            // Find the start, end, and sweep angles.
            start_angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
            dx = s2_close.X - poi.X;
            dy = s2_close.Y - poi.Y;
            float end_angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);

            // Make the angle less than 180 degrees.
            sweep_angle = end_angle - start_angle;
            if (sweep_angle > 180)
                sweep_angle = sweep_angle - 360;
            if (sweep_angle < -180)
                sweep_angle = 360 + sweep_angle;
        }
    }










    public static class Extensions
    {
        // Return the distance between two points.
        public static float Distance(this PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Fill a RectangleF.
        public static void FillRectangle(this Graphics gr,
            Brush brush, RectangleF rect)
        {
            gr.FillRectangle(brush, rect.X, rect.Y,
                rect.Width, rect.Height);
        }

        // Draw a RectangleF.
        public static void DrawRectangle(this Graphics gr,
            Pen pen, RectangleF rect)
        {
            gr.DrawRectangle(pen, rect.X, rect.Y,
                rect.Width, rect.Height);
        }

        // Fill a circle at a PointF.
        public static void FillPoint(this Graphics gr,
            Brush brush, PointF point, float radius)
        {
            gr.FillEllipse(brush,
                point.X - radius,
                point.Y - radius,
                2 * radius, 2 * radius);
        }

        // Draw a circle at a PointF.
        public static void DrawPoint(this Graphics gr,
            Pen pen, PointF point, float radius)
        {
            gr.DrawEllipse(pen,
                point.X - radius,
                point.Y - radius,
                2 * radius, 2 * radius);
        }
    }










    public class SegmentInfo
    {
        public PointF StartPoint, EndPoint;
        public SegmentInfo(PointF start_point, PointF end_point)
        {
            StartPoint = start_point;
            EndPoint = end_point;
        }
    }

}