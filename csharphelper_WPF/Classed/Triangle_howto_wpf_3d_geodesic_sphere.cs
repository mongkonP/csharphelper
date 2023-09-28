using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media.Media3D;

namespace howto_wpf_3d_geodesic_sphere
{
    class Triangle
    {
        public Point3D[] Points;
        public Triangle(params Point3D[] points)
        {
            Points = points;
        }

        // Subdivide this triangle and put the
        // new triangles in the list triangles.
        public void Subdivide(List<Triangle> triangles, Point3D center, double radius)
        {
            // Find the dividing points.
            Vector3D v01 = Points[1] - Points[0];
            Vector3D v02 = Points[2] - Points[0];
            Vector3D v12 = Points[2] - Points[1];
            Point3D A = Points[0] + v01 * 1.0 / 3.0;
            Point3D B = Points[0] + v02 * 1.0 / 3.0;
            Point3D C = Points[0] + v01 * 2.0 / 3.0;
            Point3D D = Points[0] + v01 * 2.0 / 3.0 + v12 * 1.0 / 3.0;
            Point3D E = Points[0] + v02 * 2.0 / 3.0;
            Point3D F = Points[1] + v12 * 1.0 / 3.0;
            Point3D G = Points[1] + v12 * 2.0 / 3.0;

            // Normalize the points.
            NormalizePoint(ref A, center, radius);
            NormalizePoint(ref B, center, radius);
            NormalizePoint(ref C, center, radius);
            NormalizePoint(ref D, center, radius);
            NormalizePoint(ref E, center, radius);
            NormalizePoint(ref F, center, radius);
            NormalizePoint(ref G, center, radius);

            // Make the triangles.
            triangles.Add(new Triangle(Points[0], A, B));
            triangles.Add(new Triangle(A, C, D));
            triangles.Add(new Triangle(A, D, B));
            triangles.Add(new Triangle(B, D, E));
            triangles.Add(new Triangle(C, Points[1], F));
            triangles.Add(new Triangle(C, F, D));
            triangles.Add(new Triangle(D, F, G));
            triangles.Add(new Triangle(D, G, E));
            triangles.Add(new Triangle(E, G, Points[2]));
        }

        // Make the point the indicated distance away from the center.
        private void NormalizePoint(ref Point3D point, Point3D center, double distance)
        {
            Vector3D vector = point - center;
            point = center + vector / vector.Length * distance;
        }

        // Return the triangle's angles.
        public double[] Angles()
        {
            Vector3D v01 = Points[1] - Points[0];
            Vector3D v12 = Points[2] - Points[1];
            Vector3D v20 = Points[0] - Points[2];
            v01.Normalize();
            v12.Normalize();
            v20.Normalize();
            double angle0 = Math.Acos(Vector3D.DotProduct(v01, -v20)) * 180.0 / Math.PI;
            double angle1 = Math.Acos(Vector3D.DotProduct(v12, -v01)) * 180.0 / Math.PI;
            double angle2 = Math.Acos(Vector3D.DotProduct(v20, -v12)) * 180.0 / Math.PI;

            double[] angles = new double[] { angle0, angle1, angle2 };
            Array.Sort(angles);
            return angles;
        }
    }
}
