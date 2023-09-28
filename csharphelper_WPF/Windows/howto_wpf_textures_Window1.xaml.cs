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
    /// Interaction logic for howto_wpf_textures_Window1.xaml
    /// </summary>
    public partial class howto_wpf_textures_Window1 : Window
    {
        public howto_wpf_textures_Window1()
        {
            InitializeComponent();
        }

        // The main object model group.
        private Model3DGroup MainModel3Dgroup = new Model3DGroup();

        // The camera.
        private PerspectiveCamera TheCamera;

        // The camera's current location.
        private double CameraPhi = Math.PI / 6.0;       // 30 degrees
        private double CameraTheta = Math.PI / 3.0;     // 60 degrees
        private double CameraR = 5.0;

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
            MakeMesh1(model_group);
            MakeMesh2(model_group);
            MakeMesh3(model_group);
        }

        // Make a triangle that uses the lower left half of the texture.
        private void MakeMesh1(Model3DGroup model_group)
        {
            // Make a mesh to hold the surface.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Set the triangle's points.
            mesh.Positions.Add(new Point3D(-2, 1, 0));
            mesh.Positions.Add(new Point3D(-2, 0, 0));
            mesh.Positions.Add(new Point3D(-1, 0, 0));

            // Set the points' texture coordinates.
            mesh.TextureCoordinates.Add(new Point(0, 0));
            mesh.TextureCoordinates.Add(new Point(0, 1));
            mesh.TextureCoordinates.Add(new Point(1, 1));

            // Create the triangle.
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            // Make the surface's material using an image brush.
            ImageBrush colors_brush = new ImageBrush();
            colors_brush.ImageSource =
                new BitmapImage(new Uri("Colors.png", UriKind.Relative));
            DiffuseMaterial colors_material = new DiffuseMaterial(colors_brush);

            // Make the mesh's model.
            GeometryModel3D surface_model = new GeometryModel3D(mesh, colors_material);

            // Make the surface visible from both sides.
            surface_model.BackMaterial = colors_material;

            // Add the model to the model groups.
            model_group.Children.Add(surface_model);
        }

        // Make a triangle that uses the lower left quarter of the texture.
        private void MakeMesh2(Model3DGroup model_group)
        {
            // Make a mesh to hold the surface.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Set the triangle's points.
            mesh.Positions.Add(new Point3D(-1, 1, 0));
            mesh.Positions.Add(new Point3D(-1, 0, 0));
            mesh.Positions.Add(new Point3D(0, 0, 0));

            // Set the points' texture coordinates.
            mesh.TextureCoordinates.Add(new Point(0, 0.5));
            mesh.TextureCoordinates.Add(new Point(0, 1));
            mesh.TextureCoordinates.Add(new Point(0.5, 1));

            // Create the triangle.
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            // Make the surface's material using an image brush.
            ImageBrush colors_brush = new ImageBrush();
            colors_brush.ImageSource =
                new BitmapImage(new Uri("Colors.png", UriKind.Relative));
            DiffuseMaterial colors_material = new DiffuseMaterial(colors_brush);

            // Make the mesh's model.
            GeometryModel3D surface_model = new GeometryModel3D(mesh, colors_material);

            // Make the surface visible from both sides.
            surface_model.BackMaterial = colors_material;

            // Add the model to the model groups.
            model_group.Children.Add(surface_model);
        }

        // Make two triangles, one that uses the lower left quarter of the texture
        // and one that uses the upper right quarter of the texture.
        private void MakeMesh3(Model3DGroup model_group)
        {
            // Make a mesh to hold the surface.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Triangle 1.
            // Set the triangle's points.
            mesh.Positions.Add(new Point3D(0, 1, 0));
            mesh.Positions.Add(new Point3D(0, 0, 0));
            mesh.Positions.Add(new Point3D(1, 0, 0));

            // Set the points' texture coordinates.
            mesh.TextureCoordinates.Add(new Point(0, 0.5));
            mesh.TextureCoordinates.Add(new Point(0, 1));
            mesh.TextureCoordinates.Add(new Point(0.5, 1));

            // Create the triangle.
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            // Triangle 2.
            // Set the triangle's points.
            mesh.Positions.Add(new Point3D(0, 2, 0));
            mesh.Positions.Add(new Point3D(1, 1, 0));
            mesh.Positions.Add(new Point3D(1, 2, 0));

            // Set the points' texture coordinates.
            mesh.TextureCoordinates.Add(new Point(0.5, 0));
            mesh.TextureCoordinates.Add(new Point(1, 0.5));
            mesh.TextureCoordinates.Add(new Point(1, 0));

            // Create the triangle.
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(5);

            // Make the surface's material using an image brush.
            ImageBrush colors_brush = new ImageBrush();
            colors_brush.ImageSource =
                new BitmapImage(new Uri("Colors.png", UriKind.Relative));
            DiffuseMaterial colors_material = new DiffuseMaterial(colors_brush);

            // Make the mesh's model.
            GeometryModel3D surface_model = new GeometryModel3D(mesh, colors_material);

            // Make the surface visible from both sides.
            surface_model.BackMaterial = colors_material;

            // Add the model to the model groups.
            model_group.Children.Add(surface_model);
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
    }
}
