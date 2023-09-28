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
    /// Interaction logic for howto_wpf_3d_truncated_dodecahedron_Window1.xaml
    /// </summary>
    public partial class howto_wpf_3d_truncated_dodecahedron_Window1 : Window
    {
        public howto_wpf_3d_truncated_dodecahedron_Window1()
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

            // Truncated solids with frac = 1/3.
            double frac = 1.0 / (2 * Math.Cos(36.0 / 180.0 * Math.PI) + 2);
            double[] fracs = { 0, frac, 0.5 };
            double[] zs = { 3, 0, -3 };
            for (int i = 0; i < fracs.Length; i++)
            {
                // Dodecahedron.
                MeshGeometry3D dod_corner_mesh, dod_face_mesh;
                ArchimedeanSolids.MakeTruncatedDodecahedron(1.0, fracs[i],
                    new TranslateTransform3D(0, 0, zs[i]),
                    out dod_corner_mesh, out dod_face_mesh);
                GeometryModel3D dod_corner_model = dod_corner_mesh.MakeModel(Colors.Green);
                GeometryModel3D dod_face_model = dod_face_mesh.MakeModel(Colors.Yellow);
                SolidModels.Add(dod_corner_model);
                SolidModels.Add(dod_face_model);
            }

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
