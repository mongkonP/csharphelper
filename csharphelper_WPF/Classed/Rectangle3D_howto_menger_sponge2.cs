using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media.Media3D;

namespace howto_menger_sponge2
{
    // A class to represent approximate points.
    public class ApproxPoint : IComparable<ApproxPoint>
    {
        public double X, Y, Z;
        public ApproxPoint(double x, double y, double z)
        {
            X = Math.Round(x, 3);
            Y = Math.Round(y, 3);
            Z = Math.Round(z, 3);
        }
        public ApproxPoint(Point3D point)
            : this(point.X, point.Y, point.Z) { }

        public bool Equals(ApproxPoint point)
        {
            return ((X == point.X) && (Y == point.Y) && (Z == point.Z));
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is ApproxPoint)) return false;
            return this.Equals(obj as ApproxPoint);
        }

        public static bool operator ==(ApproxPoint point1, ApproxPoint point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(ApproxPoint point1, ApproxPoint point2)
        {
            return !point1.Equals(point2);
        }

        public override int GetHashCode()
        {
            int hashx = X.GetHashCode() << 3;
            int hashy = Y.GetHashCode() << 5;
            int hashz = Z.GetHashCode();
            int result = hashx ^ hashy ^ hashz;
            return result;
        }
        public int CompareTo(ApproxPoint other)
        {
            if (X < other.X) return -1;
            if (X > other.X) return 1;
            if (Y < other.Y) return -1;
            if (Y > other.Y) return 1;
            if (Z < other.Z) return -1;
            if (Z > other.Z) return 1;
            return 0;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }
    }


    public class Rectangle3D
    {
        // The rectangle's approximate points.
        public ApproxPoint[] APoints;

        // The rectangle's approximate points.
        public Point3D[] Points;

        // Initializing constructor.
        public Rectangle3D(Point3D point1, Point3D point2, Point3D point3, Point3D point4)
        {
            // Save the points.
            Points = new Point3D[]
            {
                point1,
                point2,
                point3,
                point4,
            };

            // Save the approximate points.
            APoints = new ApproxPoint[]
            {
                new ApproxPoint(point1),
                new ApproxPoint(point2),
                new ApproxPoint(point3),
                new ApproxPoint(point4),
            };

            // Sort the approximate points.
            Array.Sort(APoints);
        }

        // Return true if the rectangles
        // contain roughly the same points.
        public bool Equals(Rectangle3D other)
        {
            // Return true if the ApproxPoints are equal.
            for (int i = 0; i < 4; i++)
                if (APoints[i] != other.APoints[i]) return false;
            return true;
        }

        public override bool Equals(Object obj)
        {
            // If parameter is null, return false.
            if (obj == null) return false;

            // If parameter cannot be cast into a Rectangle3D, return false.
            if (!(obj is Rectangle3D)) return false;

            // Invoke the previous version of Equals.
            return this.Equals(obj as Rectangle3D);
        }

        public static bool operator ==(Rectangle3D rect1, Rectangle3D rect2)
        {
            return rect1.Equals(rect2);
        }

        public static bool operator !=(Rectangle3D rect1, Rectangle3D rect2)
        {
            return !rect1.Equals(rect2);
        }

        // Return a hash code.
        public override int GetHashCode()
        {
            int hash0 = APoints[0].GetHashCode() << 3;
            int hash1 = APoints[1].GetHashCode() << 5;
            int hash2 = APoints[2].GetHashCode() << 7;
            int hash3 = APoints[3].GetHashCode();
            int result = hash0 ^ hash1 ^ hash2 ^ hash3;
            return result;
        }
    }


}
