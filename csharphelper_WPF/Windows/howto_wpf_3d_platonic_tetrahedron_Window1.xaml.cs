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

using System.Diagnostics;
using System.Windows.Media.Media3D;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_3d_platonic_tetrahedron_Window1.xaml
    /// </summary>
    public partial class howto_wpf_3d_platonic_tetrahedron_Window1 : Window
    {
        public howto_wpf_3d_platonic_tetrahedron_Window1()
        {
            InitializeComponent();
        }

        // The main object model group.
        private Model3DGroup MainModelGroup = new Model3DGroup();

        // Lights.
        private List<Light> Lights = new List<Light>();

        // The solid and skeleton models, and the axes model.
        private GeometryModel3D FacesModel, EdgesModel, AxesModel;

        // The camera.
        private PerspectiveCamera TheCamera;

        // The camera's current location.
        private double CameraPhi = Math.PI / 6.0 - 4 * CameraDPhi;
        private double CameraTheta = Math.PI / 6.0 + 13 * CameraDTheta;
        private double CameraR = 2.0;

        // The change in CameraPhi when you press the up and down arrows.
        private const double CameraDPhi = 0.1;

        // The change in CameraTheta when you press the left and right arrows.
        private const double CameraDTheta = 0.1;

        // The change in CameraR when you press + or -.
        private const double CameraDR = 0.1;

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

            // Define the models.
            DefineModels(out FacesModel, out EdgesModel, out AxesModel);
            MainModelGroup.Children.Add(AxesModel);
            MainModelGroup.Children.Add(FacesModel);
            MainModelGroup.Children.Add(EdgesModel);

            // Add the group of models to a ModelVisual3D.
            ModelVisual3D model_visual = new ModelVisual3D();
            model_visual.Content = MainModelGroup;

            // Display the main visual to the viewportt.
            MainViewport.Children.Add(model_visual);
        }

        // Define the lights.
        private void DefineLights()
        {
            Lights.Add(new AmbientLight(Colors.Gray));
            Lights.Add(new DirectionalLight(Colors.Gray,
                new Vector3D(-1.0, 0.0, 0.5)));
            Lights.Add(new DirectionalLight(Colors.Gray,
                new Vector3D(1.0, -1.0, 1.0)));

            foreach (Light light in Lights)
                MainModelGroup.Children.Add(light);
        }

        // Return the vertices for a tetrahedron.
        private Point3D[] MakeVertices()
        {
            List<Point3D> points = new List<Point3D>();
            points.Add(new Point3D(0, Math.Sqrt(2.0 / 3.0), 0));
            points.Add(new Point3D(1 / Math.Sqrt(3.0), 0, 0));
            points.Add(new Point3D(-1.0 / (2.0 * Math.Sqrt(3)), 0, -0.5));
            points.Add(new Point3D(-1.0 / (2.0 * Math.Sqrt(3)), 0, 0.5));

            // Move down by 1 / (2 * Sqrt(3)) to center.
            Vector3D offset = new Vector3D(0, -1.0 / 2.0 / Math.Sqrt(3.0), 0);
            for (int i = 0; i < points.Count; i++)
                points[i] = points[i] + offset;

            // Verify that the points are all 1 unit apart.
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    Vector3D vector = points[i] - points[j];
                    Debug.Assert(Math.Abs(1 - vector.Length) < 0.00001,
                        "Points " + i + " and " + j + " are not 1 unit apart");
                }
            }

            return points.ToArray();
        }

        // Create the solid and skeleton models.
        private void DefineModels(
            out GeometryModel3D solid_model,
            out GeometryModel3D skeleton_model,
            out GeometryModel3D axes_model)
        {
            // Make the axes model.
            MeshGeometry3D axes_mesh = new MeshGeometry3D();
            Point3D origin = new Point3D(0, 0, 0);
            Point3D xmax = new Point3D(0.75, 0, 0);
            Point3D ymax = new Point3D(0, 0.75, 0);
            Point3D zmax = new Point3D(0, 0, 0.75);
            AddSegment(axes_mesh, origin, xmax, new Vector3D(0, 1, 0));
            AddSegment(axes_mesh, origin, zmax, new Vector3D(0, 1, 0));
            AddSegment(axes_mesh, origin, ymax, new Vector3D(1, 0, 0));

            SolidColorBrush axes_brush = Brushes.Red;
            DiffuseMaterial axes_material = new DiffuseMaterial(axes_brush);
            axes_model = new GeometryModel3D(axes_mesh, axes_material);

            // Get the tetrahedron's points.
            Point3D[] points = MakeVertices();

            // Create the solid tetrahedron.
            MeshGeometry3D solid_mesh = new MeshGeometry3D();
            AddTriangle(solid_mesh, points[0], points[1], points[2]);
            AddTriangle(solid_mesh, points[0], points[2], points[3]);
            AddTriangle(solid_mesh, points[0], points[3], points[1]);
            AddTriangle(solid_mesh, points[3], points[2], points[1]);

            SolidColorBrush solid_brush = Brushes.LightBlue;
            DiffuseMaterial solid_material = new DiffuseMaterial(solid_brush);
            solid_model = new GeometryModel3D(solid_mesh, solid_material);

            // Create the skeleton.
            MeshGeometry3D skeleton_mesh = new MeshGeometry3D();
            Vector3D up = new Vector3D(0, 1, 0);
            AddSegment(skeleton_mesh, points[0], points[1], up);
            AddSegment(skeleton_mesh, points[0], points[2], up);
            AddSegment(skeleton_mesh, points[0], points[3], up);
            AddSegment(skeleton_mesh, points[1], points[2], up);
            AddSegment(skeleton_mesh, points[2], points[3], up);
            AddSegment(skeleton_mesh, points[3], points[1], up);

            SolidColorBrush skeleton_brush = Brushes.Blue;
            DiffuseMaterial skeleton_material = new DiffuseMaterial(skeleton_brush);
            skeleton_model = new GeometryModel3D(skeleton_mesh, skeleton_material);
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
        private void AddSegment(MeshGeometry3D mesh, Point3D point1, Point3D point2, Vector3D up)
        {
            const double thickness = 0.01;

            // Get the segment's vector.
            Vector3D v = point2 - point1;

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
            AddSegment(mesh, new Point3D(1, 1, 1), new Point3D(1, 1, -1), up);
            AddSegment(mesh, new Point3D(1, 1, -1), new Point3D(-1, 1, -1), up);
            AddSegment(mesh, new Point3D(-1, 1, -1), new Point3D(-1, 1, 1), up);
            AddSegment(mesh, new Point3D(-1, 1, 1), new Point3D(1, 1, 1), up);

            // Bottom.
            AddSegment(mesh, new Point3D(1, -1, 1), new Point3D(1, -1, -1), up);
            AddSegment(mesh, new Point3D(1, -1, -1), new Point3D(-1, -1, -1), up);
            AddSegment(mesh, new Point3D(-1, -1, -1), new Point3D(-1, -1, 1), up);
            AddSegment(mesh, new Point3D(-1, -1, 1), new Point3D(1, -1, 1), up);

            // Sides.
            Vector3D right = new Vector3D(1, 0, 0);
            AddSegment(mesh, new Point3D(1, -1, 1), new Point3D(1, 1, 1), right);
            AddSegment(mesh, new Point3D(1, -1, -1), new Point3D(1, 1, -1), right);
            AddSegment(mesh, new Point3D(-1, -1, 1), new Point3D(-1, 1, 1), right);
            AddSegment(mesh, new Point3D(-1, -1, -1), new Point3D(-1, 1, -1), right);
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
        }

        // Show the selected models.
        private void chkItem_Click(object sender, RoutedEventArgs e)
        {
            MainModelGroup.Children.Clear();

            foreach (Light light in Lights)
                MainModelGroup.Children.Add(light);

            if (chkAxes.IsChecked.Value)
                MainModelGroup.Children.Add(AxesModel);
            if (chkFaces.IsChecked.Value)
                MainModelGroup.Children.Add(FacesModel);
            if (chkEdges.IsChecked.Value)
                MainModelGroup.Children.Add(EdgesModel);
        }
    }
}
