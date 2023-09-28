using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Media3D;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_3D_hit_test_Window1.xaml
    /// </summary>
    public partial class howto_3D_hit_test_Window1 : Window
    {
        public howto_3D_hit_test_Window1()
        {
            InitializeComponent();
        }

        // The main object model group.
        private Model3DGroup MainModel3Dgroup = new Model3DGroup();

        // The camera.
        private PerspectiveCamera TheCamera;

        // The camera's current location.
        private double CameraPhi = Math.PI / 6.0;       // 30 degrees
        private double CameraTheta = Math.PI / 6.0;     // 30 degrees
        private double CameraR = 4.0;

        // The change in CameraPhi when you press the up and down arrows.
        private const double CameraDPhi = 0.1;

        // The change in CameraTheta when you press the left and right arrows.
        private const double CameraDTheta = 0.1;

        // The change in CameraR when you press + or -.
        private const double CameraDR = 0.1;

        // A record of the 3D models we build.
        private Dictionary<Model3D, string> Models =
            new Dictionary<Model3D, string>();

        // Create the scene.
        // MainViewport is the Viewport3D defined
        // in the XAML code that displays everything.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Give the camera its initial position.
            TheCamera = new PerspectiveCamera();
            TheCamera.FieldOfView = 60;
            MainViewport.Camera = TheCamera;
            PositionCamera();

            // Define lights.
            DefineLights();

            // Create the model.
            DefineModel(MainModel3Dgroup);

            // Add the group of models to a ModelVisual3D.
            ModelVisual3D model_visual = new ModelVisual3D();
            model_visual.Content = MainModel3Dgroup;

            // Display the main visual to the viewportt.
            MainViewport.Children.Add(model_visual);
        }

        // Define the lights.
        private void DefineLights()
        {
            AmbientLight ambient_light = new AmbientLight(Colors.Gray);
            DirectionalLight directional_light =
                new DirectionalLight(Colors.Gray, new Vector3D(-1.0, -3.0, -2.0));
            MainModel3Dgroup.Children.Add(ambient_light);
            MainModel3Dgroup.Children.Add(directional_light);
        }

        // Add the model to the Model3DGroup.
        private void DefineModel(Model3DGroup model_group)
        {
            // Create the first tetrahedron.
            MeshGeometry3D mesh1 = new MeshGeometry3D();
            AddTriangle(mesh1,
                new Point3D(1, 1, 1),
                new Point3D(-1, -1, 1),
                new Point3D(1, -1, -1));
            AddTriangle(mesh1,
                new Point3D(1, 1, 1),
                new Point3D(-1, 1, -1),
                new Point3D(-1, -1, 1));
            AddTriangle(mesh1,
                new Point3D(1, 1, 1),
                new Point3D(1, -1, -1),
                new Point3D(-1, 1, -1));
            AddTriangle(mesh1,
                new Point3D(-1, -1, 1),
                new Point3D(-1, 1, -1),
                new Point3D(1, -1, -1));
            SolidColorBrush brush1 = Brushes.LightGreen;
            DiffuseMaterial material1 = new DiffuseMaterial(brush1);
            GeometryModel3D model1 = new GeometryModel3D(mesh1, material1);
            model_group.Children.Add(model1);
            Models.Add(model1, "Green model");  // Save the model.

            // Create the second tetrahedron.
            MeshGeometry3D mesh2 = new MeshGeometry3D();
            AddTriangle(mesh2,
                new Point3D(-1, -1, -1),
                new Point3D(-1, 1, 1),
                new Point3D(1, 1, -1));
            AddTriangle(mesh2,
                new Point3D(-1, -1, -1),
                new Point3D(1, -1, 1),
                new Point3D(-1, 1, 1));
            AddTriangle(mesh2,
                new Point3D(-1, -1, -1),
                new Point3D(1, 1, -1),
                new Point3D(1, -1, 1));
            AddTriangle(mesh2,
                new Point3D(1, -1, 1),
                new Point3D(1, 1, -1),
                new Point3D(-1, 1, 1));
            SolidColorBrush brush2 = Brushes.LightBlue;
            DiffuseMaterial material2 = new DiffuseMaterial(brush2);
            GeometryModel3D model2 = new GeometryModel3D(mesh2, material2);
            model_group.Children.Add(model2);
            Models.Add(model2, "Blue model");   // Save the model.

            // Create the cage.
            MeshGeometry3D mesh3 = new MeshGeometry3D();
            AddCage(mesh3);
            SolidColorBrush brush3 = Brushes.Red;
            DiffuseMaterial material3 = new DiffuseMaterial(brush3);
            GeometryModel3D model3 = new GeometryModel3D(mesh3, material3);
            model_group.Children.Add(model3);
            Models.Add(model3, "Cage");         // Save the model.

            Console.WriteLine(
                mesh1.Positions.Count +
                mesh2.Positions.Count +
                mesh3.Positions.Count +
                " points");
            Console.WriteLine(
                (mesh1.TriangleIndices.Count +
                 mesh2.TriangleIndices.Count +
                 mesh3.TriangleIndices.Count) / 3 + " triangles");
            Console.WriteLine();
        }

        // Add a triangle to the indicated mesh.
        // Do not reuse points so triangles don't share normals.
        private void AddTriangle(MeshGeometry3D mesh, Point3D point1, Point3D point2, Point3D point3)
        {
            // Create the points.
            int index1 = mesh.Positions.Count;
            mesh.Positions.Add(point1);
            mesh.Positions.Add(point2);
            mesh.Positions.Add(point3);

            // Create the triangle.
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1++);
            mesh.TriangleIndices.Add(index1);
        }

        // Make a thin rectangular prism between the two points.
        // If extend is true, extend the segment by half the
        // thickness so segments with the same end points meet nicely.
        // If up is missing, create a perpendicular vector to use.
        public void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, double thickness, bool extend)
        {
            // Find an up vector that is not colinear with the segment.
            // Start with a vector parallel to the Y axis.
            Vector3D up = new Vector3D(0, 1, 0);

            // If the segment and up vector point in more or less the
            // same direction, use an up vector parallel to the X axis.
            Vector3D segment = point2 - point1;
            segment.Normalize();
            if (Math.Abs(Vector3D.DotProduct(up, segment)) > 0.9)
                up = new Vector3D(1, 0, 0);

            // Add the segment.
            AddSegment(mesh, point1, point2, up, thickness, extend);
        }
        public void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, double thickness)
        {
            AddSegment(mesh, point1, point2, thickness, false);
        }
        public void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, Vector3D up, double thickness)
        {
            AddSegment(mesh, point1, point2, up, thickness, false);
        }
        public void AddSegment(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, Vector3D up, double thickness,
            bool extend)
        {
            // Get the segment's vector.
            Vector3D v = point2 - point1;

            if (extend)
            {
                // Increase the segment's length on both ends by thickness / 2.
                Vector3D n = ScaleVector(v, thickness / 2.0);
                point1 -= n;
                point2 += n;
            }

            // Get the scaled up vector.
            Vector3D n1 = ScaleVector(up, thickness / 2.0);

            // Get another scaled perpendicular vector.
            Vector3D n2 = Vector3D.CrossProduct(v, n1);
            n2 = ScaleVector(n2, thickness / 2.0);

            // Make a skinny box.
            // p1pm means point1 PLUS n1 MINUS n2.
            Point3D p1pp = point1 + n1 + n2;
            Point3D p1mp = point1 - n1 + n2;
            Point3D p1pm = point1 + n1 - n2;
            Point3D p1mm = point1 - n1 - n2;
            Point3D p2pp = point2 + n1 + n2;
            Point3D p2mp = point2 - n1 + n2;
            Point3D p2pm = point2 + n1 - n2;
            Point3D p2mm = point2 - n1 - n2;

            // Sides.
            AddTriangle(mesh, p1pp, p1mp, p2mp);
            AddTriangle(mesh, p1pp, p2mp, p2pp);

            AddTriangle(mesh, p1pp, p2pp, p2pm);
            AddTriangle(mesh, p1pp, p2pm, p1pm);

            AddTriangle(mesh, p1pm, p2pm, p2mm);
            AddTriangle(mesh, p1pm, p2mm, p1mm);

            AddTriangle(mesh, p1mm, p2mm, p2mp);
            AddTriangle(mesh, p1mm, p2mp, p1mp);

            // Ends.
            AddTriangle(mesh, p1pp, p1pm, p1mm);
            AddTriangle(mesh, p1pp, p1mm, p1mp);

            AddTriangle(mesh, p2pp, p2mp, p2mm);
            AddTriangle(mesh, p2pp, p2mm, p2pm);
        }

        // Add a cage.
        private void AddCage(MeshGeometry3D mesh)
        {
            // Top.
            Vector3D up = new Vector3D(0, 1, 0);
            AddSegment(mesh, new Point3D(1, 1, 1), new Point3D(1, 1, -1), up, 0.05, true);
            AddSegment(mesh, new Point3D(1, 1, -1), new Point3D(-1, 1, -1), up, 0.05, true);
            AddSegment(mesh, new Point3D(-1, 1, -1), new Point3D(-1, 1, 1), up, 0.05, true);
            AddSegment(mesh, new Point3D(-1, 1, 1), new Point3D(1, 1, 1), up, 0.05, true);

            // Bottom.
            AddSegment(mesh, new Point3D(1, -1, 1), new Point3D(1, -1, -1), up, 0.05, true);
            AddSegment(mesh, new Point3D(1, -1, -1), new Point3D(-1, -1, -1), up, 0.05, true);
            AddSegment(mesh, new Point3D(-1, -1, -1), new Point3D(-1, -1, 1), up, 0.05, true);
            AddSegment(mesh, new Point3D(-1, -1, 1), new Point3D(1, -1, 1), up, 0.05, true);

            // Sides.
            Vector3D right = new Vector3D(1, 0, 0);
            AddSegment(mesh, new Point3D(1, -1, 1), new Point3D(1, 1, 1), right, 0.05, true);
            AddSegment(mesh, new Point3D(1, -1, -1), new Point3D(1, 1, -1), right, 0.05, true);
            AddSegment(mesh, new Point3D(-1, -1, 1), new Point3D(-1, 1, 1), right, 0.05, true);
            AddSegment(mesh, new Point3D(-1, -1, -1), new Point3D(-1, 1, -1), right, 0.05, true);
        }

        // Set the vector's length.
        private Vector3D ScaleVector(Vector3D vector, double length)
        {
            double scale = length / vector.Length;
            return new Vector3D(
                vector.X * scale,
                vector.Y * scale,
                vector.Z * scale);
        }

        // Adjust the camera's position.
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    CameraPhi += CameraDPhi;
                    if (CameraPhi > Math.PI / 2.0) CameraPhi = Math.PI / 2.0;
                    break;
                case Key.Down:
                    CameraPhi -= CameraDPhi;
                    if (CameraPhi < -Math.PI / 2.0) CameraPhi = -Math.PI / 2.0;
                    break;
                case Key.Left:
                    CameraTheta += CameraDTheta;
                    break;
                case Key.Right:
                    CameraTheta -= CameraDTheta;
                    break;
                case Key.Add:
                case Key.OemPlus:
                    CameraR -= CameraDR;
                    if (CameraR < CameraDR) CameraR = CameraDR;
                    break;
                case Key.Subtract:
                case Key.OemMinus:
                    CameraR += CameraDR;
                    break;
            }

            // Update the camera's position.
            PositionCamera();
        }

        // Position the camera.
        private void PositionCamera()
        {
            // Calculate the camera's position in Cartesian coordinates.
            double y = CameraR * Math.Sin(CameraPhi);
            double hyp = CameraR * Math.Cos(CameraPhi);
            double x = hyp * Math.Cos(CameraTheta);
            double z = hyp * Math.Sin(CameraTheta);
            TheCamera.Position = new Point3D(x, y, z);

            // Look toward the origin.
            TheCamera.LookDirection = new Vector3D(-x, -y, -z);

            // Set the Up direction.
            TheCamera.UpDirection = new Vector3D(0, 1, 0);

            // Console.WriteLine("Camera.Position: (" + x + ", " + y + ", " + z + ")");
        }

#region Hit Testing Code

        // See what was clicked.
        private void MainViewport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the mouse's position relative to the viewport.
            Point mouse_pos = e.GetPosition(MainViewport);

            // Perform the hit test.
            HitTestResult result =
                VisualTreeHelper.HitTest(MainViewport, mouse_pos);

            // Display information about the hit.
            RayMeshGeometry3DHitTestResult mesh_result =
                result as RayMeshGeometry3DHitTestResult;
            if (mesh_result == null) this.Title = "";
            else
            {
                // Display the name of the model.
                this.Title = Models[mesh_result.ModelHit];

                // Display more detail about the hit.
                Console.WriteLine("Distance: " +
                    mesh_result.DistanceToRayOrigin);
                Console.WriteLine("Point hit: (" +
                    mesh_result.PointHit.ToString() + ")");

                Console.WriteLine("Triangle:");
                MeshGeometry3D mesh = mesh_result.MeshHit;
                Console.WriteLine("    (" +
                    mesh.Positions[mesh_result.VertexIndex1].ToString() + ")");
                Console.WriteLine("    (" +
                    mesh.Positions[mesh_result.VertexIndex2].ToString() + ")");
                Console.WriteLine("    (" +
                    mesh.Positions[mesh_result.VertexIndex3].ToString() + ")");
            }
        }

#endregion Hit Testing Code

    }
}
