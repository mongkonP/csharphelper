
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

  namespace  howto_interlocked_circles

 { 

class Circle
    {
        public PointF Center;
        public float Radius, CircleThickness, OutlineThickness;
        public Color FillColor, OutlineColor;
        public List<Poi> Pois = new List<Poi>();
        public List<float> Angles = new List<float>();
        public int NumAssigned = 0;

        public Circle(PointF center, float radius,
            float circle_thickness, float outline_thickness,
            Color fill_color, Color outline_color)
        {
            Center = center;
            Radius = radius;
            CircleThickness = circle_thickness;
            OutlineThickness = outline_thickness;
            FillColor = fill_color;
            OutlineColor = outline_color;

        }

        // Return the circle's center.
        public override string ToString()
        {
            return string.Format("{0}, {1}", Center.X, Center.Y);
        }

        // Draw the circle.
        public void Draw(Graphics gr)
        {
            using (Pen fill_pen = new Pen(FillColor, CircleThickness))
            {
                using (Pen outline_pen = new Pen(OutlineColor, OutlineThickness))
                {
                    gr.DrawThickArc(Center, Radius, 0, 360, fill_pen, outline_pen);
                }
            }
        }

        // Draw the POIs where this circle is on top.
        public void DrawPois(Graphics gr)
        {
            using (Pen fill_pen = new Pen(FillColor, CircleThickness))
            {
                using (Pen outline_pen = new Pen(OutlineColor, OutlineThickness))
                {
                    for (int i = 0; i < Pois.Count; i++)
                    {
                        if (Pois[i].CircleOnTop == this)
                        {
                            const float sweep_angle = 30;
                            float start_angle = Angles[i] - sweep_angle / 2f;
                            gr.DrawThickArc(Center, Radius,
                                start_angle, sweep_angle, fill_pen, outline_pen);

                            // Uncomment to draw lines showing the angle.
                            //double angle, x, y;
                            //angle = start_angle * Math.PI / 180.0;
                            //x = Center.X + 1.25 * Radius * Math.Cos(angle);
                            //y = Center.Y + 1.25 * Radius * Math.Sin(angle);
                            //gr.DrawLine(Pens.Black, Center.X, Center.Y, (float)x, (float)y);
                            //start_angle += sweep_angle;
                            //angle = start_angle * Math.PI / 180.0;
                            //x = Center.X + 1.25 * Radius * Math.Cos(angle);
                            //y = Center.Y + 1.25 * Radius * Math.Sin(angle);
                            //gr.DrawLine(Pens.Red, Center.X, Center.Y, (float)x, (float)y);
                        }
                    }
                }
            }
        }

        // Find the circles' POIs in sorted order.
        public static void FindPois(Circle[] circles)
        {
            // Find the POIs.
            for (int i = 0; i < circles.Length; i++)
            {
                for (int j = i + 1; j < circles.Length; j++)
                {
                    PointF p1, p2;
                    FindCircleCircleIntersections(
                        circles[i].Center.X, circles[i].Center.Y, circles[i].Radius,
                        circles[j].Center.X, circles[j].Center.Y, circles[j].Radius,
                        out p1, out p2);
                    if (!float.IsNaN(p1.X))
                    {
                        Poi poi = new Poi(p1, circles[i], circles[j]);
                        circles[i].Pois.Add(poi);
                        circles[j].Pois.Add(poi);
                    }
                    if (!float.IsNaN(p2.X))
                    {
                        Poi poi = new Poi(p2, circles[i], circles[j]);
                        circles[i].Pois.Add(poi);
                        circles[j].Pois.Add(poi);
                    }
                }
            }

            // Sort the POIs.
            foreach (Circle circle in circles)
            {
                circle.SortPois();
            }

            // Initially none of the circles has its POIs assigned.
            List<Circle> unfinished = new List<Circle>(circles);

            // Repeat until all circles are completely assigned.
            while (unfinished.Count > 0)
            {
                // At this point, all unfinished circles have no assignments.

                // Make a list to hold circles that are partially assigned.
                List<Circle> partially_assigned = new List<Circle>();

                // Add the first unfinished circle to the
                // partially_assigned list.
                // Arbitrarily make it on top in its first POI.
                Circle circle = unfinished[0];
                unfinished.RemoveAt(0);
                partially_assigned.Add(circle);
                if (circle.Pois.Count > 0)
                    circle.Pois[0].CircleOnTop = circle;

                // Process circles in the partially_assigned
                // list until it is empty.
                while (partially_assigned.Count > 0)
                {
                    // Remove the first circle from the list.
                    circle = partially_assigned[0];
                    partially_assigned.RemoveAt(0);

                    // Assign the remaining entries for this circle.
                    circle.Assign(unfinished, partially_assigned);
                }
                // When we reach this point, partially_assigned
                // is empty and the most recent connected
                // component has been assigned.
            }
            // When we reach this point, unfinished is
            // empty and all Circles have been assigned.
        }

        // Sort this circle's POIs.
        private void SortPois()
        {
            // Calculate the POIs' angles.
            Angles = new List<float>();
            foreach (Poi poi in Pois)
            {
                float dx = poi.Location.X - Center.X;
                float dy = poi.Location.Y - Center.Y;
                double radians = Math.Atan2(dy, dx);
                Angles.Add((float)(radians / Math.PI * 180));
            }

            // Sort the POIs by angle.
            Poi[] poi_array = Pois.ToArray();
            float[] angle_array = Angles.ToArray();
            Array.Sort(angle_array, poi_array);

            // Save the POIs and angles.
            Pois = new List<Poi>(poi_array);
            Angles = new List<float>(angle_array);
        }

        // Find the points where the two circles intersect.
        private static int FindCircleCircleIntersections(
            float cx0, float cy0, float radius0,
            float cx1, float cy1, float radius1,
            out PointF intersection1, out PointF intersection2)
        {
            // Find the distance between the centers.
            float dx = cx0 - cx1;
            float dy = cy0 - cy1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = cx0 + a * (cx1 - cx0) / dist;
                double cy2 = cy0 + a * (cy1 - cy0) / dist;

                // Get the points P3.
                intersection1 = new PointF(
                    (float)(cx2 + h * (cy1 - cy0) / dist),
                    (float)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new PointF(
                    (float)(cx2 - h * (cy1 - cy0) / dist),
                    (float)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }

        // Assign POIs for this circle alternating
        // top/bottom with index first_on_top on top.
        // Add other circles that share this one's POIs
        // to the partially_assigned list and remove
        // them from the unfinished list.
        private void Assign(List<Circle> unfinished,
            List<Circle> partially_assigned)
        {
            // If this circle has no Pois or if all of its Pois
            // are assigned, remove it from the list and return.
            if ((Pois.Count == 0) || AllPoisAreAssigned())
            {
                partially_assigned.Remove(this);
                return;
            }

            // Find the first POI that is assigned.
            int first_assigned = -1;
            for (int i = 0; i < Pois.Count; i++)
            {
                if (Pois[i].CircleOnTop != null)
                {
                    first_assigned = i;
                    break;
                }
            }

            // See whether the first assigned Poi is this Circle.
            bool last_was_this = (Pois[first_assigned].CircleOnTop == this);

            // Assign the other Pois.
            for (int i = 1; i < Pois.Count; i++)
            {
                int index = (first_assigned + i) % Pois.Count;
                if (Pois[index].CircleOnTop == null)
                {
                    // Find the other Circle at this Poi.
                    Circle other = Pois[index].OtherCircle(this);

                    // Place the correct Circle on top.
                    if (last_was_this)
                        Pois[index].CircleOnTop = other;
                    else
                        Pois[index].CircleOnTop = this;

                    // If the other circle is not completely assigned and
                    // is not aleady on the partially_assigned list, add it.
                    if (!other.AllPoisAreAssigned() &&
                        !partially_assigned.Contains(other))
                        partially_assigned.Add(other);

                    // Remove the other Circle from the unfinished list.
                    if (unfinished.Contains(other))
                        unfinished.Remove(other);

                    NumAssigned++;
                }

                // Remember whether this Poi has this Circle on top.
                last_was_this = !last_was_this;
            }
        }

        // Return true if all of the POIs have been assigned.
        public bool AllPoisAreAssigned()
        {
            return NumAssigned == Pois.Count;
        }
    }










    public static class Extensions
    {
        // Draw a thick arc with different inside and outside pens.
        public static void DrawThickArc(this Graphics gr, PointF center, float radius,
            float start_angle, float sweep_angle,
            Pen fill_pen, Pen outline_pen)
        {
            // Draw the main arc.
            gr.DrawArc(fill_pen,
                center.X - radius,
                center.Y - radius,
                2 * radius, 2 * radius,
                start_angle, sweep_angle);

            // Draw the outer outline.
            float r1 = radius + fill_pen.Width / 2f + outline_pen.Width / 2f;
            gr.DrawArc(outline_pen,
                center.X - r1,
                center.Y - r1,
                2 * r1, 2 * r1,
                start_angle, sweep_angle);

            // Draw the inner outline.
            float r2 = radius - fill_pen.Width / 2f - outline_pen.Width / 2f;
            gr.DrawArc(outline_pen,
                center.X - r2,
                center.Y - r2,
                2 * r2, 2 * r2,
                start_angle, sweep_angle);
        }
    }










    class Poi
    {
        public PointF Location;
        public Circle[] Circles = null;
        public Circle CircleOnTop = null;

        public Poi(PointF location, Circle circle1, Circle circle2)
        {
            Location = location;
            Circles = new Circle[] { circle1, circle2 };
        }

        public override string ToString()
        {
            return string.Format("({0}/{1}", Circles[0], Circles[1]);
        }

        // Return the other circle.
        public Circle OtherCircle(Circle this_circle)
        {
            if (Circles[0] != this_circle) return Circles[0];
            return Circles[1];
        }

        // Return the circle on the bottom, if the top circle is assigned.
        public Circle CircleOnBottom()
        {
            if (CircleOnTop == null) return null;
            return OtherCircle(CircleOnTop);
        }
    }

}