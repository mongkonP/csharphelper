
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_randomly_colored_trominoes

 { 

public class Chair
    {
        public static Brush[] BgBrushes =
        {
            Brushes.Red, Brushes.Orange, Brushes.Yellow,
            Brushes.Lime, Brushes.Blue, Brushes.Cyan,
            Brushes.Magenta,
        };

        public int Number;
        public int BgBrushNum = 0;
        public Pen FgPen = Pens.Blue;
        public List<Point> Squares = new List<Point>();
        public PointF[] Points;
        public List<Chair> Neighbors;

        // Draw the polygon.
        public void Draw(Graphics gr)
        {
            if (Points == null) return;
            gr.FillPolygon(BgBrushes[BgBrushNum], Points);
            gr.DrawPolygon(FgPen, Points);
        }

        // Return true if the two Chairs are neighbors.
        public bool IsNeighbor(Chair other)
        {
            foreach (Point p1 in Squares)
                foreach (Point p2 in other.Squares)
                    if (AreNeighbors(p1, p2)) return true;
            return false;
        }

        // Return true if the two squares are neighbors.
        public static bool AreNeighbors(Point p1, Point p2)
        {
            if ((p1.X == p2.X) && (Math.Abs(p1.Y - p2.Y) == 1)) return true;
            if ((p1.Y == p2.Y) && (Math.Abs(p1.X - p2.X) == 1)) return true;
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

        // Print the Neighbors lists.
        public void PrintNeighbors()
        {
            Console.Write(Number + ": ");
            Console.WriteLine(
            string.Join(", ",
                Neighbors.ConvertAll(
                    chair => chair.Number.ToString()).ToArray()));
        }
    }








    public static class RandomExtensions
    {
        private static Random Rand = new Random();

        // Randomize an array.
        public static void Randomize<T>(this T[] items)
        {
            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = Rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }

}