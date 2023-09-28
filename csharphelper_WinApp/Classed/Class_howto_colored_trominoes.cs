
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_colored_trominoes

 { 

public class Chair
    {
        public static Brush[] BgBrushes =
        {
            Brushes.Red, Brushes.Blue, Brushes.Yellow,
        };

        public int Number;
        public int BgBrushNum = 0;
        public List<Point> Squares = new List<Point>();
        public PointF[] Points;
        public List<Chair> Neighbors;

        // Draw the polygon.
        public void Draw(Graphics gr, bool label)
        {
            if (Points == null) return;
            gr.FillPolygon(BgBrushes[BgBrushNum], Points);
            gr.DrawPolygon(Pens.Black, Points);

            // Draw the chair's number if desired.
            if (label)
            {
                using (Font font = new Font("Times New Roman", 10))
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;

                        gr.DrawString(Number.ToString(), font,
                            Brushes.Black, Center(), sf);
                    }
                }
            }
        }

        // Return a point near the chair's bend.
        private PointF Center()
        {
            float x = 0;
            float y = 0;
            foreach (PointF point in Points)
            {
                x += point.X;
                y += point.Y;
            }
            return new PointF(x / Points.Length, y / Points.Length);
        }

        // Return true if the two squares are neighbors.
        public static bool AreNeighbors(Point p1, Point p2)
        {
            if ((p1.X == p2.X) && (Math.Abs(p1.Y - p2.Y) == 1)) return true;
            if ((p1.Y == p2.Y) && (Math.Abs(p1.X - p2.X) == 1)) return true;
            return false;
        }

        // Return true if the two Chairs are neighbors.
        public bool IsNeighbor(Chair other)
        {
            foreach (Point p1 in Squares)
                foreach (Point p2 in other.Squares)
                    if (AreNeighbors(p1, p2)) return true;
            return false;
        }

        // Return true if this Chair could have this color number.
        public bool ColorAllowed(int color_num)
        {
            foreach (Chair chair in Neighbors)
                if (chair.BgBrushNum == color_num)
                    return false;
            return true;
        }

        // Print the Neighbors lists. (For debugging.)
        public void PrintNeighbors()
        {
            Console.Write(Number + ": ");
            Console.WriteLine(
            string.Join(", ",
                Neighbors.ConvertAll(
                    chair => chair.Number.ToString()).ToArray()));
        }
    }

}