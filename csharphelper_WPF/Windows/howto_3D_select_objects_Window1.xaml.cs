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
    /// Interaction logic for howto_3D_select_objects_Window1.xaml
    /// </summary>
    public partial class howto_3D_select_objects_Window1 : Window
    {
        public howto_3D_select_objects_Window1()
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
        private double CameraR = 15.0;

        // The change in CameraPhi when you press the up and down arrows.
        private const double CameraDPhi = 0.1;

        // The change in CameraTheta when you press the left and right arrows.
        private const double CameraDTheta = 0.1;

        // The change in CameraR when you press + or -.
        private const double CameraDR = 0.1;

        // The currently selected model.
        private GeometryModel3D SelectedModel = null;

        // Materials used for normal and selected models.
        private Material NormalMaterial, SelectedMaterial;

        // The list of selectable models.
        private List<GeometryModel3D> SelectableModels =
            new List<GeometryModel3D>();

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
            DefineLights(MainModel3Dgroup);

            // Create the model.
            DefineModel(MainModel3Dgroup);

            // Add the group of models to a ModelVisual3D.
            ModelVisual3D model_visual = new ModelVisual3D();
            model_visual.Content = MainModel3Dgroup;

            // Display the main visual to the viewportt.
            MainViewport.Children.Add(model_visual);
        }

        // Define the lights.
        private void DefineLights(Model3DGroup model_group)
        {
            model_group.Children.Add(new AmbientLight(Colors.DarkSlateGray));
            model_group.Children.Add(
                new DirectionalLight(Colors.Gray,
                    new Vector3D(3.0, -2.0, 1.0)));
            model_group.Children.Add(
                new DirectionalLight(Colors.DarkGray,
                    new Vector3D(-3.0, -2.0, -1.0)));
        }

        // Add the model to the Model3DGroup.
        private void DefineModel(Model3DGroup model_group)
        {
            // Make the normal and selected materials.
            NormalMaterial = new DiffuseMaterial(Brushes.LightGreen);
            SelectedMaterial = new DiffuseMaterial(Brushes.Red);

            // Create some cubes.
            for (int x = -5; x <= 3; x += 4)
            {
                for (int y = -5; y <= 3; y += 4)
                {
                    for (int z = -5; z <= 3; z += 4)
                    {
                        // Make a cube with lower left corner (x, y, z).
                        MeshGeometry3D mesh = new MeshGeometry3D();
                        mesh.AddBox(x, y, z, 2, 2, 2);
                        GeometryModel3D model = new GeometryModel3D(mesh, NormalMaterial);
                        model_group.Children.Add(model);

                        // Remember that this model is selectable.
                        SelectableModels.Add(model);
                    }
                }
            }

            // X axis.
            MeshGeometry3D mesh_x = MeshExtensions.XAxisArrow(6);
            model_group.Children.Add(mesh_x.SetMaterial(Brushes.Red, false));

            // Y axis.
            MeshGeometry3D mesh_y = MeshExtensions.YAxisArrow(6);
            model_group.Children.Add(mesh_y.SetMaterial(Brushes.Green, false));

            // Z axis.
            MeshGeometry3D mesh_z = MeshExtensions.ZAxisArrow(6);
            model_group.Children.Add(mesh_z.SetMaterial(Brushes.Blue, false));
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
            // Deselect the prevously selected model.
            if (SelectedModel != null)
            {
                SelectedModel.Material = NormalMaterial;
                SelectedModel = null;
            }

            // Get the mouse's position relative to the viewport.
            Point mouse_pos = e.GetPosition(MainViewport);

            // Perform the hit test.
            HitTestResult result =
                VisualTreeHelper.HitTest(MainViewport, mouse_pos);

            // See if we hit a model.
            RayMeshGeometry3DHitTestResult mesh_result =
                result as RayMeshGeometry3DHitTestResult;
            if (mesh_result != null)
            {
                GeometryModel3D model = (GeometryModel3D)mesh_result.ModelHit;
                if (SelectableModels.Contains(model))
                {
                    SelectedModel = model;
                    SelectedModel.Material = SelectedMaterial;
                }
            }
        }

        #endregion Hit Testing Code

    }
}
