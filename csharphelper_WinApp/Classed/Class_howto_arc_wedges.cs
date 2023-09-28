
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_arc_wedges

 { 

public static class Extensions
    {
        // Draw arc wedges.
        public static void DrawArcWedges(this Graphics gr,
            Brush brush, Pen pen,
            Point center, float inner_radius, float outer_radius,
            float start_angle, int num_wedges,
            float draw_degrees, float skip_degrees)
        {
            double theta = DegToRad(start_angle);
            double draw_rad = DegToRad(draw_degrees);
            double skip_rad = DegToRad(skip_degrees);
            for (int i = 0; i < num_wedges; i++)
            {
                PointF[] points =
                {
                    new PointF(
                        (float)(center.X + inner_radius * Math.Cos(theta)),
                        (float)(center.Y + inner_radius * Math.Sin(theta))),
                    new PointF(
                        (float)(center.X + outer_radius * Math.Cos(theta)),
                        (float)(center.Y + outer_radius * Math.Sin(theta))),
                    new PointF(
                        (float)(center.X + outer_radius * Math.Cos(theta + draw_rad)),
                        (float)(center.Y + outer_radius * Math.Sin(theta + draw_rad))),
                    new PointF(
                        (float)(center.X + inner_radius * Math.Cos(theta + draw_rad)),
                        (float)(center.Y + inner_radius * Math.Sin(theta + draw_rad))),
                };
                if (brush != null) gr.FillPolygon(brush, points);
                if (pen != null) gr.DrawPolygon(pen, points);

                theta += draw_rad + skip_rad;
            }
        }

        // Draw tic marks around an arc.
        public static void DrawArcTics(this Graphics gr,
            Pen arc_pen, Pen tic_pen,
            Point center, float radius, float tic_length,
            float start_angle, float sweep_angle, float skip_degrees,
            int num_skip_start_tics, int num_skip_end_tics)
        {
            if (arc_pen != null)
            {
                RectangleF rect =new RectangleF(
                    center.X - radius,
                    center.Y - radius,
                    2 * radius, 2 * radius);
                gr.DrawArc(arc_pen, rect, start_angle, sweep_angle);
            }
            if (tic_pen == null) return;

            int num_tics = (int)(sweep_angle / skip_degrees) + 1;
            double theta = DegToRad(start_angle);
            double skip_rad = DegToRad(skip_degrees);

            theta += skip_rad * num_skip_start_tics;
            num_tics -= num_skip_start_tics;

            num_tics -= num_skip_end_tics;

            float inner_radius = radius - tic_length / 2f;
            float outer_radius = radius + tic_length / 2f;

            for (int i = 0; i < num_tics; i++)
            {
                PointF p1 =
                    new PointF(
                        (float)(center.X + inner_radius * Math.Cos(theta)),
                        (float)(center.Y + inner_radius * Math.Sin(theta)));
                PointF p2 =
                    new PointF(
                        (float)(center.X + outer_radius * Math.Cos(theta)),
                        (float)(center.Y + outer_radius * Math.Sin(theta)));
                gr.DrawLine(tic_pen, p1, p2);

                theta += skip_rad;
            }
        }

        // Convert degrees into radians.
        private static double DegToRad(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        // Draw a lines segment with optional tic marks and arrowheads.
        public static void DrawSegment(this Graphics gr,
            PointF start_point, PointF end_point,
            Pen line_pen,
            Pen tic_pen, float tic_length, float tic_spacing,
            int num_skip_start_tics, int num_skip_end_tics,
            ArrowheadTypes start_arrowhead_type,
            Brush start_arrowhead_brush, float start_arrowhead_radius,
            ArrowheadTypes end_arrowhead_type,
            Brush end_arrowhead_brush, float end_arrowhead_radius)
        {
            // Draw the line.
            if (line_pen != null)
                gr.DrawLine(line_pen, start_point, end_point);

            // Draw the tic marks.
            if (tic_pen != null)
            {
                // Get unit vectors in the directions
                // of the segment and perpendicular.
                float dx = end_point.X - start_point.X;
                float dy = end_point.Y - start_point.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;
                float nx = dy;
                float ny = -dx;

                // Convert to the desired lengths.
                dx *= tic_spacing;
                dy *= tic_spacing;
                nx *= tic_length / 2f;
                ny *= tic_length / 2f;

                // Prepare if we should skip the first tic mark.
                PointF point = start_point;
                int num_tics = (int)(length / tic_spacing) + 1;

                // Skip starting tics if desired.
                num_tics -= num_skip_start_tics;
                point.X += num_skip_start_tics * dx;
                point.Y += num_skip_start_tics * dy;

                // Skip ending tics if desired.
                num_tics -= num_skip_end_tics;

                // Draw the tic marks.
                for (int i = 0; i < num_tics; i++)
                {
                    PointF p1 = new PointF(
                        point.X + nx,
                        point.Y + ny);
                    PointF p2 = new PointF(
                        point.X - nx,
                        point.Y - ny);
                    gr.DrawLine(tic_pen, p1, p2);

                    point.X += dx;
                    point.Y += dy;
                }
            }

            // Draw the arowheads.
            DrawArrowhead(gr, start_arrowhead_brush,
                end_point, start_point, start_arrowhead_radius,
                start_arrowhead_type);
            DrawArrowhead(gr, end_arrowhead_brush,
                start_point, end_point, end_arrowhead_radius,
                end_arrowhead_type);
        }

        // Arrowhead types.
        public enum ArrowheadTypes
        {
            None,
            TriangleHead,
            TriangleTail,
            VHead,
            VTail,
            Broadhead,
            Broadtail,
        };

        // Draw an arrowhead at the indicated point.
        public static void DrawArrowhead(this Graphics gr, Brush brush,
            PointF from_point, PointF to_point, float radius,
            ArrowheadTypes arrowhead_type)
        {
            if (arrowhead_type == ArrowheadTypes.None) return;

            // Get the vectors that we need.
            float dx = to_point.X - from_point.X;
            float dy = to_point.Y - from_point.Y;
            float length = (float)Math.Sqrt(dx * dx + dy * dy);
            float ux = dx / length; // Unit distance along the arrow.
            float uy = dy / length;
            float rx = uy;      // Unit distance perpendicular
            float ry = -ux;     // to the arrow on the right.

            // Generate the arrowhead's points.
            PointF[] points = null;
            switch (arrowhead_type)
            {
                case ArrowheadTypes.Broadhead:
                    points = new PointF[]
                    {
                        new PointF(to_point.X, to_point.Y),
                        new PointF(
                            to_point.X - radius * ux + radius * rx,
                            to_point.Y - radius * uy + radius * ry),
                        new PointF(
                            to_point.X - 2 * radius * ux + radius * rx,
                            to_point.Y - 2 * radius * uy + radius * ry),
                        new PointF(
                            to_point.X - radius * ux,
                            to_point.Y - radius * uy),
                        new PointF(
                            to_point.X - 2 * radius * ux - radius * rx,
                            to_point.Y - 2 * radius * uy - radius * ry),
                        new PointF(
                            to_point.X - radius * ux - radius * rx,
                            to_point.Y - radius * uy - radius * ry),
                    };
                    break;
                case ArrowheadTypes.Broadtail:
                    points = new PointF[]
                    {
                        new PointF(to_point.X, to_point.Y),
                        new PointF(
                            to_point.X + radius * ux + radius * rx,
                            to_point.Y + radius * uy + radius * ry),
                        new PointF(
                            to_point.X + radius * rx,
                            to_point.Y + radius * ry),
                        new PointF(
                            to_point.X - radius * ux,
                            to_point.Y - radius * uy),
                        new PointF(
                            to_point.X - radius * rx,
                            to_point.Y - radius * ry),
                        new PointF(
                            to_point.X + radius * ux - radius * rx,
                            to_point.Y + radius * uy - radius * ry),
                    };
                    break;
                case ArrowheadTypes.TriangleHead:
                    points = new PointF[]
                    {
                        new PointF(to_point.X, to_point.Y),
                        new PointF(
                            to_point.X - radius * ux + radius * rx,
                            to_point.Y - radius * uy + radius * ry),
                        new PointF(
                            to_point.X - radius * ux - radius * rx,
                            to_point.Y - radius * uy - radius * ry),
                    };
                    break;
                case ArrowheadTypes.TriangleTail:
                    points = new PointF[]
                    {
                        new PointF(
                            to_point.X - radius * ux,
                            to_point.Y - radius * uy),
                        new PointF(
                            to_point.X + radius * rx,
                            to_point.Y + radius * ry),
                        new PointF(
                            to_point.X - radius * rx,
                            to_point.Y - radius * ry),
                    };
                    break;
                case ArrowheadTypes.VHead:
                    points = new PointF[]
                    {
                        new PointF(to_point.X, to_point.Y),
                        new PointF(
                            to_point.X - 2 * radius * ux + radius * rx,
                            to_point.Y - 2 * radius * uy + radius * ry),
                        new PointF(
                            to_point.X - radius * ux,
                            to_point.Y - radius * uy),
                        new PointF(
                            to_point.X - 2 * radius * ux - radius * rx,
                            to_point.Y - 2 * radius * uy - radius * ry),
                    };
                    break;

                case ArrowheadTypes.VTail:
                    points = new PointF[]
                    {
                        new PointF(to_point.X, to_point.Y),
                        new PointF(
                            to_point.X + radius * ux + radius * rx,
                            to_point.Y + radius * uy + radius * ry),
                        new PointF(
                            to_point.X - radius * ux,
                            to_point.Y - radius * uy),
                        new PointF(
                            to_point.X + radius * ux - radius * rx,
                            to_point.Y + radius * uy - radius * ry),
                    };
                    break;
            }

            gr.FillPolygon(brush, points);
        }
    }

}