using System.Windows.Media.Media3D;

namespace howto_wpf_3d_platonic_solids
{
    public static class TransformExtensions
    {
        public static void Transform(this Transform3D transform, Triangle triangle)
        {
            transform.Transform(triangle.Points);
        }
    }
}
