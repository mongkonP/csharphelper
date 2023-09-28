using System.Windows.Media.Media3D;

namespace howto_wpf_3d_truncated_cube
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
