using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Media3D;

namespace howto_wpf3d_snowman
{
    public static class VectorExtensions
    {
        // Return the vector scaled.
        public static Vector3D Scale(this Vector3D vector, double length)
        {
            return vector * length / vector.Length;
        }
    }
}
