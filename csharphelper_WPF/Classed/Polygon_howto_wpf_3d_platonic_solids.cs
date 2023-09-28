using System.Collections.Generic;

using System.Windows.Media.Media3D;

namespace howto_wpf_3d_platonic_solids
{
    // A 3D polygon.
    // Assumes the points are coplanar.
    public class Polygon
    {
        public Point3D[] Points;
        public Polygon(params Point3D[] points)
        {
            Points = points;
        }
    }
}
