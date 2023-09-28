using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_hyperbola_parabola_intersection_Form1:Form
  { 


        public howto_hyperbola_parabola_intersection_Form1()
        {
            InitializeComponent();
        }

        private const float small = 0.1f;

        // Equations that define the conic sections.
        private float A2, B2, C2, D2, E2, F2;
        private float A1, B1, C1, D1, E1, F1;

        // The X coordinate of the middle of the hyperbola.
        private float HyperbolaXmid = 100;

        // The points of intersection.
        private List<PointF> Roots = new List<PointF>();
        private List<float> RootSign1 = new List<float>();
        private List<float> RootSign2 = new List<float>();
        private List<PointF> PointsOfIntersection = new List<PointF>();

        // Difference function tangent lines.
        private float TangentX = 0;
        private List<PointF> TangentCenters = null;
        private List<PointF> TangentP1 = null;
        private List<PointF> TangentP2 = null;
        private List<Pen> TangentPens = null;

        private void howto_hyperbola_parabola_intersection_Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            TangentX = 88;

            // A parabola.
            float dx = 50;
            float dy = 100;
            float sx = 10;
            float sy = 1;

            A1 = 0;
            B1 = 0;
            C1 = -sy * sy;
            D1 = sx;
            E1 = 2 * sy * dy;
            F1 = -sx * dx - dy * dy;

            // A hyperbola.
            dx = HyperbolaXmid;
            dy = 70;
            float a2 = 50;
            float b2 = 150;
            A2 = 1 / a2;
            B2 = 0;
            C2 = -1 / b2;
            D2 = -2 * dx / a2;
            E2 = 2 * dy / b2;
            F2 = (dx * dx / a2) - (dy * dy / b2) - 1;

            // Perform the calculations.
            PerformCalculations();
        }

        // Draw the conic sections.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the parabola.
            List<PointF> points = new List<PointF>();
            for (int x = 0; x < picCanvas.Width; x++)
            {
                float y = G1(x, A1, B1, C1, D1, E1, F1, -1f);
                if (IsNumber(y)) points.Add(new PointF(x, y));
            }
            for (int x = picCanvas.Width - 1; x >= 0; x--)
            {
                float y = G1(x, A1, B1, C1, D1, E1, F1, +1f);
                if (IsNumber(y)) points.Add(new PointF(x, y));
            }
            if (points.Count > 1)
                e.Graphics.DrawLines(Pens.Black, points.ToArray());

            // Draw the hyperbola.
            points = new List<PointF>();
            for (float x = 0; x < HyperbolaXmid; x++)
            {
                float y = G1(x, A2, B2, C2, D2, E2, F2, -1f);
                if (IsNumber(y)) points.Add(new PointF(x, y));
            }
            for (float x = HyperbolaXmid - 1; x >= 0; x--)
            {
                float y = G1(x, A2, B2, C2, D2, E2, F2, +1f);
                if (IsNumber(y)) points.Add(new PointF(x, y));
            }
            if (points.Count > 1)
                e.Graphics.DrawLines(Pens.Black, points.ToArray());

            points = new List<PointF>();
            for (float x = picCanvas.Width; x >= HyperbolaXmid; x--)
            {
                float y = G1(x, A2, B2, C2, D2, E2, F2, +1f);
                if (IsNumber(y)) points.Add(new PointF(x, y));
            }
            for (float x = HyperbolaXmid; x < picCanvas.Width; x++)
            {
                float y = G1(x, A2, B2, C2, D2, E2, F2, -1f);
                if (IsNumber(y)) points.Add(new PointF(x, y));
            }
            if (points.Count > 1)
                e.Graphics.DrawLines(Pens.Black, points.ToArray());

            // Draw the points of intersection.
            const int radius = 4;
            foreach (PointF pt in PointsOfIntersection)
            {
                RectangleF rect = new RectangleF(
                    pt.X - radius, pt.Y - radius,
                    2 * radius, 2 * radius);
                e.Graphics.DrawEllipse(Pens.Green, rect);
            }
        }

        // Perform the calculations that require two conic sections.
        private void PerformCalculations()
        {
            // Display the parameters for the parabola.
            lstParameters1.Items.Clear();
            lstParameters1.Items.Add("A = " + A1.ToString());
            lstParameters1.Items.Add("B = " + B1.ToString());
            lstParameters1.Items.Add("C = " + C1.ToString());
            lstParameters1.Items.Add("D = " + D1.ToString());
            lstParameters1.Items.Add("E = " + E1.ToString());
            lstParameters1.Items.Add("F = " + F1.ToString());

            // Display the parameters for the hyperbola.
            lstParameters2.Items.Clear();
            lstParameters2.Items.Add("A = " + A2.ToString());
            lstParameters2.Items.Add("B = " + B2.ToString());
            lstParameters2.Items.Add("C = " + C2.ToString());
            lstParameters2.Items.Add("D = " + D2.ToString());
            lstParameters2.Items.Add("E = " + E2.ToString());
            lstParameters2.Items.Add("F = " + F2.ToString());

            // Find the difference tangents.
            FindDifferenceTangents();

            // Find the roots of the difference equations
            // and thus the points of intersection.
            float xmin = 0;
            float xmax = picCanvas.Width;
            FindPointsOfIntersection(xmin, xmax);
        }

        // Find tangents to the difference functions.
        private void FindDifferenceTangents()
        {
            TangentCenters = new List<PointF>();
            TangentP1 = new List<PointF>();
            TangentP2 = new List<PointF>();
            TangentPens = new List<Pen>();

            const float tangent_length = 100;

            //++
            float tangent_y = G(TangentX,
                A1, B1, C1, D1, E1, F1, +1f,
                A2, B2, C2, D2, E2, F2, +1f);
            if (IsNumber(tangent_y))
            {
                float slope =
                    G1Prime(TangentX, A1, B1, C1, D1, E1, F1, +1f) -
                    G1Prime(TangentX, A2, B2, C2, D2, E2, F2, +1f);
                if (IsNumber(slope))
                {
                    float delta_x = (float)Math.Sqrt(
                        tangent_length * tangent_length / (1 + slope * slope)) / 2;
                    TangentCenters.Add(new PointF(TangentX, tangent_y));
                    TangentP1.Add(new PointF(TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add(new PointF(TangentX + delta_x, tangent_y + slope * delta_x));
                    TangentPens.Add(Pens.Red);
                }
            }

            //+-
            tangent_y = G(TangentX,
                A1, B1, C1, D1, E1, F1, +1f,
                A2, B2, C2, D2, E2, F2, -1f);
            if (IsNumber(tangent_y))
            {
                float slope =
                    G1Prime(TangentX, A1, B1, C1, D1, E1, F1, +1f) -
                    G1Prime(TangentX, A2, B2, C2, D2, E2, F2, -1f);
                if (IsNumber(slope))
                {
                    float delta_x = (float)Math.Sqrt(
                        tangent_length * tangent_length / (1 + slope * slope)) / 2;
                    TangentCenters.Add(new PointF(TangentX, tangent_y));
                    TangentP1.Add(new PointF(TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add(new PointF(TangentX + delta_x, tangent_y + slope * delta_x));
                    TangentPens.Add(Pens.Green);
                }
            }

            //-+
            tangent_y = G(TangentX,
                A1, B1, C1, D1, E1, F1, -1f,
                A2, B2, C2, D2, E2, F2, +1f);
            if (IsNumber(tangent_y))
            {
                float slope =
                    G1Prime(TangentX, A1, B1, C1, D1, E1, F1, -1f) -
                    G1Prime(TangentX, A2, B2, C2, D2, E2, F2, +1f);
                if (IsNumber(slope))
                {
                    float delta_x = (float)Math.Sqrt(
                        tangent_length * tangent_length / (1 + slope * slope)) / 2;
                    TangentCenters.Add(new PointF(TangentX, tangent_y));
                    TangentP1.Add(new PointF(TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add(new PointF(TangentX + delta_x, tangent_y + slope * delta_x));
                    TangentPens.Add(Pens.Blue);
                }
            }

            //--
            tangent_y = G(TangentX,
                A1, B1, C1, D1, E1, F1, -1f,
                A2, B2, C2, D2, E2, F2, -1f);
            if (IsNumber(tangent_y))
            {
                float slope =
                    G1Prime(TangentX, A1, B1, C1, D1, E1, F1, -1f) -
                    G1Prime(TangentX, A2, B2, C2, D2, E2, F2, -1f);
                if (IsNumber(slope))
                {
                    float delta_x = (float)Math.Sqrt(
                        tangent_length * tangent_length / (1 + slope * slope)) / 2;
                    TangentCenters.Add(new PointF(TangentX, tangent_y));
                    TangentP1.Add(new PointF(TangentX - delta_x, tangent_y - slope * delta_x));
                    TangentP2.Add(new PointF(TangentX + delta_x, tangent_y + slope * delta_x));
                    TangentPens.Add(Pens.Orange);
                }
            }
        }

        // Calculate G1(x).
        // root_sign is -1 or 1.
        private float G1(float x, float A, float B, float C, float D, float E, float F, float root_sign)
        {
            float result = B * x + E;
            result = result * result;
            result = result - 4 * C * (A * x * x + D * x + F);
            result = root_sign * (float)Math.Sqrt(result);
            result = -(B * x + E) + result;
            result = result / 2 / C;

            return result;
        }

        // Calculate G1'(x).
        // root_sign is -1 or 1.
        private float G1Prime(float x, float A, float B, float C, float D, float E, float F, float root_sign)
        {
            float numerator = 2 * (B * x + E) * B -
                4 * C * (2 * A * x + D);
            float denominator = 2 * (float)Math.Sqrt(
                (B * x + E) * (B * x + E) -
                4 * C * (A * x * x + D * x + F));
            float result = -B + root_sign * numerator / denominator;
            result = result / 2 / C;

            return result;
        }

        // Calculate G(x).
        private float G(float x,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            return
                G1(x, A1, B1, C1, D1, E1, F1, sign1) -
                G1(x, A2, B2, C2, D2, E2, F2, sign2);
        }

        // Calculate G'(x).
        private float GPrime(float x,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            return
                G1Prime(x, A1, B1, C1, D1, E1, F1, sign1) -
                G1Prime(x, A2, B2, C2, D2, E2, F2, sign2);
        }

        // Draw the equations.
        private void picEquation_Resize(object sender, EventArgs e)
        {
            picEquation.Refresh();
        }
        private void picEquation_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picEquation.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the difference equations.
            float dy = picEquation.ClientSize.Height / 2f;
            e.Graphics.TranslateTransform(0, dy);
            e.Graphics.DrawLine(Pens.Black, 0, 0, picEquation.ClientSize.Width, 0);

            float xmin = 0;
            float xmax = picCanvas.Width;

            // Draw the difference curves.
            DrawDifferenceCurves(e.Graphics, xmin, xmax);

            // Draw tangents.
            DrawTangents(e.Graphics);

            // Draw the roots.
            foreach (PointF point in Roots)
            {
                const float radius = 4;
                e.Graphics.DrawEllipse(Pens.Red,
                    point.X - radius, point.Y - radius,
                    2 * radius, 2 * radius);
            }
        }

        // Draw the difference curves.
        private void DrawDifferenceCurves(Graphics gr, float xmin, float xmax)
        {
            const float dx = 0.01f;
            using (Pen thick_pen = new Pen(Color.Red, 3))
            {
                // ++
                List<PointF> points = new List<PointF>();
                for (float x = xmin; x <= xmax; x += dx)
                {
                    float y1 = G1(x, A1, B1, C1, D1, E1, F1, +1f);
                    if (IsNumber(y1))
                    {
                        float y2 = G1(x, A2, B2, C2, D2, E2, F2, +1f);
                        if (IsNumber(y2)) points.Add(new PointF(x, y1 - y2));
                    }
                }
                if (points.Count > 1)
                {
                    thick_pen.Color = Color.Red;
                    gr.DrawLines(thick_pen, points.ToArray());
                }

                // +-
                points = new List<PointF>();
                for (float x = xmax; x >= xmin; x -= dx)
                {
                    float y1 = G1(x, A1, B1, C1, D1, E1, F1, +1f);
                    if (IsNumber(y1))
                    {
                        float y2 = G1(x, A2, B2, C2, D2, E2, F2, -1f);
                        if (IsNumber(y2)) points.Add(new PointF(x, y1 - y2));
                    }
                }
                if (points.Count > 1)
                {
                    thick_pen.Color = Color.Green;
                    gr.DrawLines(thick_pen, points.ToArray());
                }

                // -+
                points = new List<PointF>();
                for (float x = xmin; x <= xmax; x += dx)
                {
                    float y1 = G1(x, A1, B1, C1, D1, E1, F1, -1f);
                    if (IsNumber(y1))
                    {
                        float y2 = G1(x, A2, B2, C2, D2, E2, F2, +1f);
                        if (IsNumber(y2)) points.Add(new PointF(x, y1 - y2));
                    }
                }
                if (points.Count > 1)
                {
                    thick_pen.Color = Color.Blue;
                    gr.DrawLines(thick_pen, points.ToArray());
                }

                // --
                points = new List<PointF>();
                for (float x = xmax; x >= xmin; x -= dx)
                {
                    float y1 = G1(x, A1, B1, C1, D1, E1, F1, -1f);
                    if (IsNumber(y1))
                    {
                        float y2 = G1(x, A2, B2, C2, D2, E2, F2, -1f);
                        if (IsNumber(y2)) points.Add(new PointF(x, y1 - y2));
                    }
                }
                if (points.Count > 1)
                {
                    thick_pen.Color = Color.Orange;
                    gr.DrawLines(thick_pen, points.ToArray());
                }
            }
        }

        // Draw difference curve tangents.
        private void DrawTangents(Graphics gr)
        {
            for (int i = 0; i < TangentP1.Count; i++)
            {
                const float radius = 3;
                gr.FillEllipse(Brushes.Black,
                    TangentCenters[i].X - radius,
                    TangentCenters[i].Y - radius,
                    2 * radius, 2 * radius);
                gr.DrawLine(TangentPens[i], TangentP1[i], TangentP2[i]);
            }
        }

        // Find the points of intersection.
        private void FindPointsOfIntersection(float xmin, float xmax)
        {
            Roots = new List<PointF>();
            RootSign1 = new List<float>();
            RootSign2 = new List<float>();

            // Find roots for each of the difference equations.
            float[] signs = { +1f, -1f };
            foreach (float sign1 in signs)
            {
                foreach (float sign2 in signs)
                {
                    List<PointF> points = FindRootsUsingBinaryDivision(
                        xmin, xmax,
                        A1, B1, C1, D1, E1, F1, sign1,
                        A2, B2, C2, D2, E2, F2, sign2);
                    if (points.Count > 0)
                    {
                        Roots.AddRange(points);
                        for (int i = 0; i < points.Count; i++)
                        {
                            RootSign1.Add(sign1);
                            RootSign2.Add(sign2);
                        }
                    }
                }
            }

            // Find corresponding points of intersection.
            PointsOfIntersection = new List<PointF>();
            for (int i = 0; i < Roots.Count; i++)
            {
                float y1 = G1(Roots[i].X, A1, B1, C1, D1, E1, F1, RootSign1[i]);
                float y2 = G1(Roots[i].X, A2, B2, C2, D2, E2, F2, RootSign2[i]);
                PointsOfIntersection.Add(new PointF(Roots[i].X, y1));

                // Validation.
                Debug.Assert(Math.Abs(y1 - y2) < small);
            }
        }

        // Find roots by using binary division.
        private List<PointF> FindRootsUsingBinaryDivision(float xmin, float xmax,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            List<PointF> roots = new List<PointF>();
            const int num_tests = 100;
            float delta_x = (xmax - xmin) / (num_tests - 1);

            // Loop over the possible x values looking for roots.
            float x0 = xmin;
            float x, y;
            for (int i = 0; i < num_tests; i++)
            {
                // Try to find a root in this range.
                UseBinaryDivision(x0, delta_x, out x, out y,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);

                // See if we have already found this root.
                if (IsNumber(y))
                {
                    bool is_new = true;
                    foreach (PointF pt in roots)
                    {
                        if (Math.Abs(pt.X - x) < small)
                        {
                            is_new = false;
                            break;
                        }
                    }

                    // If this is a new point, save it.
                    if (is_new)
                    {
                        roots.Add(new PointF(x, y));

                        // If we've found two roots, we won't find any more.
                        if (roots.Count > 1) return roots;
                    }
                }

                x0 += delta_x;
            }

            return roots;
        }

        // Find a root by using binary division.
        private void UseBinaryDivision(float x0, float delta_x,
            out float x, out float y,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            const int num_trials = 200;
            const int sgn_nan = -2;

            // Get G(x) for the bounds.
            float xmin = x0;
            float g_xmin = G(xmin,
                A1, B1, C1, D1, E1, F1, sign1,
                A2, B2, C2, D2, E2, F2, sign2);
            if (Math.Abs(g_xmin) < small)
            {
                x = xmin;
                y = g_xmin;
                return;
            }

            float xmax = xmin + delta_x;
            float g_xmax = G(xmax,
                A1, B1, C1, D1, E1, F1, sign1,
                A2, B2, C2, D2, E2, F2, sign2);
            if (Math.Abs(g_xmax) < small)
            {
                x = xmax;
                y = g_xmax;
                return;
            }

            // Get the sign of the values.
            int sgn_min, sgn_max;
            if (IsNumber(g_xmin)) sgn_min = Math.Sign(g_xmin);
            else sgn_min = sgn_nan;
            if (IsNumber(g_xmax)) sgn_max = Math.Sign(g_xmax);
            else sgn_max = sgn_nan;

            // If the two values have the same sign,
            // then there is no root here.
            if (sgn_min == sgn_max)
            {
                x = 1;
                y = float.NaN;
                return;
            }

            // Use binary division to find the point of intersection.
            float xmid = 0, g_xmid = 0;
            int sgn_mid = 0;
            for (int i = 0; i < num_trials; i++)
            {
                // Get values for the midpoint.
                xmid = (xmin + xmax) / 2;
                g_xmid = G(xmid,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);
                if (IsNumber(g_xmid)) sgn_mid = Math.Sign(g_xmid);
                else sgn_mid = sgn_nan;

                // If sgn_mid is 0, gxmid is 0 so this is the root.
                if (sgn_mid == 0) break;

                // See which half contains the root.
                if (sgn_mid == sgn_min)
                {
                    // The min and mid values have the same sign.
                    // Search the right half.
                    xmin = xmid;
                    g_xmin = g_xmid;
                }
                else if (sgn_mid == sgn_max)
                {
                    // The max and mid values have the same sign.
                    // Search the left half.
                    xmax = xmid;
                    g_xmax = g_xmid;
                }
                else
                {
                    // The three values have different signs.
                    // Assume min or max is NaN.
                    if (sgn_min == sgn_nan)
                    {
                        // Value g_xmin is NaN. Use the right half.
                        xmin = xmid;
                        g_xmin = g_xmid;
                    }
                    else if (sgn_max == sgn_nan)
                    {
                        // Value g_xmax is NaN. Use the right half.
                        xmax = xmid;
                        g_xmax = g_xmid;
                    }
                    else
                    {
                        // This is a weird case. Just trap it.
                        throw new InvalidOperationException(
                            "Unexpected difference curve. " +
                            "Cannot find a root between X = " +
                            xmin + " and X = " + xmax);
                    }
                }
            }

            if (IsNumber(g_xmid) && (Math.Abs(g_xmid) < small))
            {
                x = xmid;
                y = g_xmid;
            }
            else if (IsNumber(g_xmin) && (Math.Abs(g_xmin) < small))
            {
                x = xmin;
                y = g_xmin;
            }
            else if (IsNumber(g_xmax) && (Math.Abs(g_xmax) < small))
            {
                x = xmax;
                y = g_xmax;
            }
            else
            {
                x = xmid;
                y = float.NaN;
            }
        }

        // Get points representing the difference between the two conic sections' equations.
        private List<List<PointF>> GetDifferencePoints(
            float xmin1, float xmax1,
            float xmin2, float xmax2,
            float A1, float B1, float C1, float D1, float E1, float F1,
            float A2, float B2, float C2, float D2, float E2, float F2)
        {
            float xmin = Math.Min(xmin1, xmin2);
            float xmax = Math.Max(xmax1, xmax2);
            List<List<PointF>> result = new List<List<PointF>>();

            float[] signs = { -1f, +1f };
            foreach (float sign1 in signs)
            {
                foreach (float sign2 in signs)
                {
                    List<PointF> points = new List<PointF>();
                    result.Add(points);
                    for (float x = xmin; x <= xmax; x++)
                    {
                        float y1 = G1(A1, B1, C1, D1, E1, F1, x, sign1);
                        if (IsNumber(y1))
                        {
                            float y2 = G1(A2, B2, C2, D2, E2, F2, x, sign2);
                            if (IsNumber(y2)) points.Add(new PointF(x, y1 - y2));
                        }
                    }
                }
            }

            return result;
        }

        // Select an X coordinate for drawing tangent lines.
        private void picEquation_MouseClick(object sender, MouseEventArgs e)
        {
            TangentX = e.X;

            // Find the difference tangents.
            FindDifferenceTangents();

            // Refresh.
            picEquation.Refresh();
        }

        // Return true if the number is not infinity or NaN.
        private bool IsNumber(float number)
        {
            return !(float.IsNaN(number) || float.IsInfinity(number));
        }
    

/// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstParameters1 = new System.Windows.Forms.ListBox();
            this.lstParameters2 = new System.Windows.Forms.ListBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.picEquation = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEquation)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstParameters1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstParameters2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picCanvas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picEquation, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 440);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lstParameters1
            // 
            this.lstParameters1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstParameters1.FormattingEnabled = true;
            this.lstParameters1.Items.AddRange(new object[] {
            "A =",
            "B =",
            "C =",
            "D =",
            "E =",
            "F ="});
            this.lstParameters1.Location = new System.Drawing.Point(3, 178);
            this.lstParameters1.Name = "lstParameters1";
            this.lstParameters1.Size = new System.Drawing.Size(189, 82);
            this.lstParameters1.TabIndex = 0;
            // 
            // lstParameters2
            // 
            this.lstParameters2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstParameters2.FormattingEnabled = true;
            this.lstParameters2.Items.AddRange(new object[] {
            "A =",
            "B =",
            "C =",
            "D =",
            "E =",
            "F ="});
            this.lstParameters2.Location = new System.Drawing.Point(198, 178);
            this.lstParameters2.Name = "lstParameters2";
            this.lstParameters2.Size = new System.Drawing.Size(190, 82);
            this.lstParameters2.TabIndex = 1;
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.picCanvas, 2);
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(3, 3);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(385, 169);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // picEquation
            // 
            this.picEquation.BackColor = System.Drawing.SystemColors.Control;
            this.picEquation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.picEquation, 2);
            this.picEquation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEquation.Location = new System.Drawing.Point(3, 268);
            this.picEquation.Name = "picEquation";
            this.picEquation.Size = new System.Drawing.Size(385, 169);
            this.picEquation.TabIndex = 3;
            this.picEquation.TabStop = false;
            this.picEquation.Resize += new System.EventHandler(this.picEquation_Resize);
            this.picEquation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picEquation_MouseClick);
            this.picEquation.Paint += new System.Windows.Forms.PaintEventHandler(this.picEquation_Paint);
            // 
            // howto_hyperbola_parabola_intersection_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_hyperbola_parabola_intersection_Form1";
            this.Text = "howto_hyperbola_parabola_intersection";
            this.Load += new System.EventHandler(this.howto_hyperbola_parabola_intersection_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEquation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstParameters1;
        private System.Windows.Forms.ListBox lstParameters2;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.PictureBox picEquation;
    }
}

