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
    /// Interaction logic for howto_wpf_3d_truncated_cube_Window1.xaml
    /// </summary>
    public partial class howto_wpf_3d_truncated_cube_Window1 : Window
    {
        public howto_wpf_3d_truncated_cube_Window1()
        {
            InitializeComponent();
        }

        // The main object model group.
        private Model3DGroup MainModelGroup = new Model3DGroup();

        // Lights.
        private List<Light> Lights = new List<Light>();

        // The models.
        private GeometryModel3D AxesModel;
        private List<GeometryModel3D> SolidModels = new List<GeometryModel3D>();

        // The camera.
        private PerspectiveCamera TheCamera;

        // The camera's current location.
        private double CameraPhi, CameraTheta, CameraR;

        // Create the scene.
        // MainViewport is the Viewport3D defined
        // in the XAML code that displays everything.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Give the camera its initial position.
            TheCamera = new PerspectiveCamera();
            TheCamera.FieldOfView = 60;
            MainViewport.Camera = TheCamera;
            CameraTheta = scrTheta.Value * Math.PI / 180.0;
            CameraPhi = scrPhi.Value * Math.PI / 180.0;
            CameraR = double.Parse(lblDistance.Content.ToString());
            PositionCamera();

            // Define lights.
            DefineLights();

            // Define the models.
            DefineModels();

            // Add the group of models to a ModelVisual3D.
            ModelVisual3D model_visual = new ModelVisual3D();
            model_visual.Content = MainModelGroup;

            // Display the main visual to the viewportt.
            MainViewport.Children.Add(model_visual);

            // Display the selected models.
            DisplaySelectedModels();
        }

        // Define the lights.
        private void DefineLights()
        {
            Color color64 = Color.FromArgb(255, 128, 128, 128);
            Color color128 = Color.FromArgb(255, 255, 255, 255);
            Lights.Add(new AmbientLight(color64));
            Lights.Add(new DirectionalLight(color64,
                new Vector3D(-1.0, -2.0, -3.0)));
            Lights.Add(new DirectionalLight(color64,
                new Vector3D(1.0, 2.0, 3.0)));
        }

        // Create the models.
        private void DefineModels()
        {
            Cursor = Cursors.Wait;

            // Line thickness.
            const double line_thickness = 0.01;

            // Make the axes model.
            MeshGeometry3D axes_mesh = new MeshGeometry3D();
            axes_mesh.AddAxes(3.25, line_thickness, false, true, 2, 8);
            AxesModel = axes_mesh.MakeModel(Colors.Red);

            // Make a truncated cube with frac = 0.20.
            MeshGeometry3D cube20_corner_mesh, cube20_face_mesh;
            ArchimedeanSolids.MakeTruncatedCube(1.0, 0.2,
                new TranslateTransform3D(-2, 0, 0),
                out cube20_corner_mesh, out cube20_face_mesh);
            GeometryModel3D cube20_corner_model = cube20_corner_mesh.MakeModel(Colors.LightBlue);
            GeometryModel3D cube20_face_model = cube20_face_mesh.MakeModel(Colors.LightGreen);
            SolidModels.Add(cube20_corner_model);
            SolidModels.Add(cube20_face_model);

            // Make a truncated cube with frac = 1/(2+Sqrt(2)).
            MeshGeometry3D cubeeven_corner_mesh, cubeeven_face_mesh;
            double frac = 1 / (2 + Math.Sqrt(2));
            ArchimedeanSolids.MakeTruncatedCube(1.0, frac,
                new TranslateTransform3D(0, 0, -2),
                out cubeeven_corner_mesh, out cubeeven_face_mesh);
            GeometryModel3D cubeeven_corner_model = cubeeven_corner_mesh.MakeModel(Colors.LightBlue);
            GeometryModel3D cubeeven_face_model = cubeeven_face_mesh.MakeModel(Colors.LightGreen);
            SolidModels.Add(cubeeven_corner_model);
            SolidModels.Add(cubeeven_face_model);

            // Verify that lengths of the sides in the
            // triangles and squares are the same.
            Vector3D v1 =
                cubeeven_corner_mesh.Positions[0] -
                cubeeven_corner_mesh.Positions[1];
            Vector3D v2 =
                cubeeven_face_mesh.Positions[0] -
                cubeeven_face_mesh.Positions[1];
            if (Math.Abs(v1.Length - v2.Length) < 0.0001)
                Console.WriteLine("Side lengths are equal");
            else
                Console.WriteLine("Side lengths " + v1.Length + " != " + v2.Length);
            
            // Make a truncated cube with frac = 0.5.
            MeshGeometry3D cube50_corner_mesh, cube50_face_mesh;
            ArchimedeanSolids.MakeTruncatedCube(1.0, 0.50,
                new TranslateTransform3D(2, 0, 0),
                out cube50_corner_mesh, out cube50_face_mesh);
            GeometryModel3D cube50_corner_model = cube50_corner_mesh.MakeModel(Colors.LightBlue);
            GeometryModel3D cube50_face_model = cube50_face_mesh.MakeModel(Colors.LightGreen);
            SolidModels.Add(cube50_corner_model);
            SolidModels.Add(cube50_face_model);

            Cursor = null;
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

        // Change the camera's phi value.
        private void scrPhi_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            CameraPhi = scrPhi.Value * Math.PI / 180.0;
            PositionCamera();
        }

        // Change the camera's theta value.
        private void scrTheta_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            CameraTheta = scrTheta.Value * Math.PI / 180.0;
            PositionCamera();
        }

        private void scrDistance_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            CameraR = scrDistance.Value;
            PositionCamera();
        }

        private void chkItem_Click(object sender, RoutedEventArgs e)
        {
            DisplaySelectedModels();
        }

        // Display the selected models.
        private void DisplaySelectedModels()
        {
            MainModelGroup.Children.Clear();

            foreach (Light light in Lights)
                MainModelGroup.Children.Add(light);

            if (chkAxes.IsChecked.Value)
                MainModelGroup.Children.Add(AxesModel);
            if (chkFaces.IsChecked.Value)
                foreach (GeometryModel3D model in SolidModels)
                    MainModelGroup.Children.Add(model);
        }
    }
}
