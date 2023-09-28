//#define SURFACE2

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Media3D;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_WPF_3D_axes_Window1.xaml
    /// </summary>
    public partial class howto_WPF_3D_axes_Window1 : Window
    {
        public howto_WPF_3D_axes_Window1()
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
#if SURFACE2
        private double CameraR = 3.0;
#else
        private double CameraR = 13.0;
#endif

        // The change in CameraPhi when you press the up and down arrows.
        private const double CameraDPhi = 0.1;

        // The change in CameraTheta when you press the left and right arrows.
        private const double CameraDTheta = 0.1;

        // The change in CameraR when you press + or -.
        private const double CameraDR = 0.1;

        // The models.
        private GeometryModel3D
            SurfaceModel, WireframeModel, NormalsModel, VertexNormalsModel,
            XArrow, YArrow, ZArrow,
            XAxis, YAxis, ZAxis;

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

            // Display the main visual in the viewportt.
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
            // Make a mesh to hold the surface.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Make the surface's points and triangles.
#if SURFACE2
            const double xmin = -1.5;
            const double xmax = 1.5;
            const double dx = 0.3;
            const double zmin = -1.5;
            const double zmax = 1.5;
            const double dz = 0.3;
#else
            const double xmin = -5;
            const double xmax = 5;
            const double dx = 1;
            const double zmin = -5;
            const double zmax = 5;
            const double dz = 1;
#endif
            for (double x = xmin; x <= xmax - dx; x += dx)
            {
                for (double z = zmin; z <= zmax - dz; z += dx)
                {
                    // Make points at the corners of the surface
                    // over (x, z) - (x + dx, z + dz).
                    Point3D p00 = new Point3D(x, F(x, z), z);
                    Point3D p10 = new Point3D(x + dx, F(x + dx, z), z);
                    Point3D p01 = new Point3D(x, F(x, z + dz), z + dz);
                    Point3D p11 = new Point3D(x + dx, F(x + dx, z + dz), z + dz);

                    // Add the triangles.
                    AddTriangle(mesh, p00, p01, p11);
                    AddTriangle(mesh, p00, p11, p10);
                }
            }
            Console.WriteLine("Surface: ");
            Console.WriteLine("    " + mesh.Positions.Count + " points");
            Console.WriteLine("    " + mesh.TriangleIndices.Count / 3 + " triangles");
            Console.WriteLine();

            // Make the surface's material using a solid green brush.
            DiffuseMaterial surface_material = new DiffuseMaterial(Brushes.LightGreen);

            // Make the surface's model.
            SurfaceModel = new GeometryModel3D(mesh, surface_material);

            // Make the surface visible from both sides.
            SurfaceModel.BackMaterial = surface_material;

            // Add the model to the model groups.
            model_group.Children.Add(SurfaceModel);

#if SURFACE2
            const double thickness = 0.01;
            const double normal_length = 0.25;
#else
            const double thickness = 0.03;
            const double normal_length = 0.5;
#endif
            // Make a wireframe.
            MeshGeometry3D wireframe = mesh.ToWireframe(thickness);
            DiffuseMaterial wireframe_material = new DiffuseMaterial(Brushes.Red);
            WireframeModel = new GeometryModel3D(wireframe, wireframe_material);
            model_group.Children.Add(WireframeModel);
            Console.WriteLine("Wireframe: ");
            Console.WriteLine("    " + wireframe.Positions.Count + " points");
            Console.WriteLine("    " + wireframe.TriangleIndices.Count / 3 + " triangles");
            Console.WriteLine();

            // Make the triangle normals.
            MeshGeometry3D normals = mesh.ToTriangleNormals(normal_length, thickness);
            DiffuseMaterial normals_material = new DiffuseMaterial(Brushes.Blue);
            NormalsModel = new GeometryModel3D(normals, normals_material);
            model_group.Children.Add(NormalsModel);
            Console.WriteLine("Normals: ");
            Console.WriteLine("    " + normals.Positions.Count + " points");
            Console.WriteLine("    " + normals.TriangleIndices.Count / 3 + " triangles");
            Console.WriteLine();

            // Make the vertex normals.
            MeshGeometry3D vnormals = mesh.ToVertexNormals(normal_length, thickness);
            DiffuseMaterial vnormals_material = new DiffuseMaterial(Brushes.Black);
            VertexNormalsModel = new GeometryModel3D(vnormals, vnormals_material);
            model_group.Children.Add(VertexNormalsModel);
            Console.WriteLine("Vertex Normals: ");
            Console.WriteLine("    " + vnormals.Positions.Count + " points");
            Console.WriteLine("    " + vnormals.TriangleIndices.Count / 3 + " triangles");
            Console.WriteLine();

            // Make the arrows.
#if SURFACE2
            const double axis_length = 1;
            const double arrowhead_length = 0.25;
#else
            const double axis_length = 6;
            const double arrowhead_length = 1;
#endif
            Point3D origin = new Point3D(0, 0, 0);

            // X = Red.
            MeshGeometry3D x_arrow_mesh = new MeshGeometry3D();
            x_arrow_mesh.AddArrow(origin, new Point3D(axis_length, 0, 0),
                new Vector3D(0, 1, 0), arrowhead_length);
            DiffuseMaterial x_arrow_material = new DiffuseMaterial(Brushes.Red);
            XArrow = new GeometryModel3D(x_arrow_mesh, x_arrow_material);
            model_group.Children.Add(XArrow);

            // Y = Green.
            MeshGeometry3D y_arrow_mesh = new MeshGeometry3D();
            y_arrow_mesh.AddArrow(origin, new Point3D(0, axis_length - 1, 0),
                new Vector3D(1, 0, 0), arrowhead_length);
            DiffuseMaterial y_arrow_material = new DiffuseMaterial(Brushes.Green);
            YArrow = new GeometryModel3D(y_arrow_mesh, y_arrow_material);
            model_group.Children.Add(YArrow);

            // Z = Blue.
            MeshGeometry3D z_arrow_mesh = new MeshGeometry3D();
            z_arrow_mesh.AddArrow(origin, new Point3D(0, 0, axis_length),
                new Vector3D(0, 1, 0), arrowhead_length);
            DiffuseMaterial z_arrow_material = new DiffuseMaterial(Brushes.Blue);
            ZArrow = new GeometryModel3D(z_arrow_mesh, z_arrow_material);
            model_group.Children.Add(ZArrow);

            // Make the axes.
            const double tic_diameter = 0.2;
            // X = Red.
            MeshGeometry3D x_axis_mesh = new MeshGeometry3D();
            x_axis_mesh.AddAxis(origin, new Point3D(axis_length, 0, 0),
                new Vector3D(0, 1, 0), tic_diameter, 1.0);
            DiffuseMaterial x_axis_material = new DiffuseMaterial(Brushes.Red);
            XAxis = new GeometryModel3D(x_axis_mesh, x_axis_material);
            model_group.Children.Add(XAxis);

            // Y = Green.
            MeshGeometry3D y_axis_mesh = new MeshGeometry3D();
            y_axis_mesh.AddAxis(origin, new Point3D(0, axis_length - 1, 0),
                new Vector3D(1, 0, 0), tic_diameter, 1.0);
            DiffuseMaterial y_axis_material = new DiffuseMaterial(Brushes.Green);
            YAxis = new GeometryModel3D(y_axis_mesh, y_axis_material);
            model_group.Children.Add(YAxis);

            // Z = Blue.
            MeshGeometry3D z_axis_mesh = new MeshGeometry3D();
            z_axis_mesh.AddAxis(origin, new Point3D(0, 0, axis_length),
                new Vector3D(0, 1, 0), tic_diameter, 1.0);
            DiffuseMaterial z_axis_material = new DiffuseMaterial(Brushes.Blue);
            ZAxis = new GeometryModel3D(z_axis_mesh, z_axis_material);
            model_group.Children.Add(ZAxis);
        }

        // The function that defines the surface we are drawing.
        private double F(double x, double z)
        {
#if SURFACE2
            const double two_pi = 2 * 3.14159265;
            double r2 = x * x + z * z;
            double r = Math.Sqrt(r2);
            double theta = Math.Atan2(z, x);
            return Math.Exp(-r2) * Math.Sin(two_pi * r) * Math.Cos(3 * theta);
#else
            double r2 = x * x + z * z;
            return 8 * Math.Cos(r2 / 2) / (2 + r2) - 1;
#endif
        }

        // Add a triangle to the indicated mesh.
        // If the triangle's points already exist, reuse them.
        private void AddTriangle(MeshGeometry3D mesh, Point3D point1, Point3D point2, Point3D point3)
        {
            // Get the points' indices.
            int index1 = AddPoint(mesh.Positions, point1);
            int index2 = AddPoint(mesh.Positions, point2);
            int index3 = AddPoint(mesh.Positions, point3);

            // Create the triangle.
            mesh.TriangleIndices.Add(index1);
            mesh.TriangleIndices.Add(index2);
            mesh.TriangleIndices.Add(index3);
        }

        // A dictionary to hold points for fast lookup.
        private Dictionary<Point3D, int> PointDictionary =
            new Dictionary<Point3D, int>();

        // If the point already exists, return its index.
        // Otherwise create the point and return its new index.
        private int AddPoint(Point3DCollection points, Point3D point)
        {
            // If the point is in the point dictionary,
            // return its saved index.
            if (PointDictionary.ContainsKey(point))
                return PointDictionary[point];

            // We didn't find the point. Create it.
            points.Add(point);
            PointDictionary.Add(point, points.Count - 1);
            return points.Count - 1;
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

        // Show and hide the appropriate GeometryModel3Ds.
        private void chkContents_Click(object sender, RoutedEventArgs e)
        {
            // Remove the GeometryModel3Ds.
            for (int i = MainModel3Dgroup.Children.Count - 1; i >= 0; i--)
            {
                if (MainModel3Dgroup.Children[i] is GeometryModel3D)
                    MainModel3Dgroup.Children.RemoveAt(i);
            }

            // Add the selected GeometryModel3Ds.
            if ((SurfaceModel != null) && ((bool)chkSurface.IsChecked))
                MainModel3Dgroup.Children.Add(SurfaceModel);
            if ((WireframeModel != null) && ((bool)chkWireframe.IsChecked))
                MainModel3Dgroup.Children.Add(WireframeModel);
            if ((NormalsModel != null) && ((bool)chkNormals.IsChecked))
                MainModel3Dgroup.Children.Add(NormalsModel);
            if ((VertexNormalsModel != null) && ((bool)chkVertexNormals.IsChecked))
                MainModel3Dgroup.Children.Add(VertexNormalsModel);
            if ((XArrow != null) && ((bool)chkArrows.IsChecked))
            {
                MainModel3Dgroup.Children.Add(XArrow);
                MainModel3Dgroup.Children.Add(YArrow);
                MainModel3Dgroup.Children.Add(ZArrow);
            }
            if ((XAxis != null) && ((bool)chkAxes.IsChecked))
            {
                MainModel3Dgroup.Children.Add(XAxis);
                MainModel3Dgroup.Children.Add(YAxis);
                MainModel3Dgroup.Children.Add(ZAxis);
            }
        }
    }
}
