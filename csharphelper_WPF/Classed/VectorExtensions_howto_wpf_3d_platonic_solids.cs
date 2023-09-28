using System.Windows.Media.Media3D;

namespace howto_wpf_3d_platonic_solids
{
    public static class VectorExtensions
    {
        public static Vector3D Scale(this Vector3D vector, double length)
        {
            double scale = length / vector.Length;
            return vector * scale;
        }
    }
}
