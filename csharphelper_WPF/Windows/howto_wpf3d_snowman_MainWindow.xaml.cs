using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for howto_wpf3d_snowman_MainWindow.xaml
    /// </summary>
    public partial class howto_wpf3d_snowman_MainWindow : Window
    {
        public howto_wpf3d_snowman_MainWindow()
        {
            InitializeComponent();
        }

        // The camera.
        private PerspectiveCamera TheCamera = null;

        // The camera controller.
        private SphericalCameraController CameraController = null;

        // The main model group.
        private Model3DGroup MainGroup;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Define WPF objects.
            ModelVisual3D visual3d = new ModelVisual3D();
            MainGroup = new Model3DGroup();
            visual3d.Content = MainGroup;
            mainViewport.Children.Add(visual3d);

            // Define the camera, lights, and model.
            DefineCamera(mainViewport);

            // Define the lights and model.
            DefineScene();
        }

        // Define the lights and model.
        private void DefineScene()
        {
            Cursor = Cursors.Wait;
            MainGroup.Children.Clear();
            DefineLights(MainGroup);
            DefineModel();
            Cursor = null;
        }

        // Define the camera.
        private void DefineCamera(Viewport3D viewport)
        {
            TheCamera = new PerspectiveCamera();
            TheCamera.FieldOfView = 60;
            CameraController = new SphericalCameraController
                (TheCamera, viewport, this, MainGrid, MainGrid);
        }

        // Define the lights.
        private void DefineLights(Model3DGroup group)
        {
            Color darker = Color.FromArgb(255, 64, 64, 64);
            Color dark = Color.FromArgb(255, 96, 96, 96);

            group.Children.Add(new AmbientLight(darker));

            group.Children.Add(new DirectionalLight(dark, new Vector3D(0, -1, 0)));
            group.Children.Add(new DirectionalLight(dark, new Vector3D(1, -3, -2)));
            group.Children.Add(new DirectionalLight(dark, new Vector3D(-1, 3, 2)));
        }

        // Define the model.
        private void DefineModel()
        {
            // Show the axes.
            // MeshExtensions.AddAxes(MainGroup);

            // Make the snowman's body.
            const double bodyR = 2;
            const double headR = 1.25;
            MeshGeometry3D bodyMesh = new MeshGeometry3D();
            double headY = 0.8 * (headR + bodyR) - 1;
            MeshExtensions.AddSphere(bodyMesh,
                new Point3D(0, headY, 0),
                headR, 40, 20, true);
            MeshExtensions.AddSphere(bodyMesh,
                new Point3D(0, -1, 0),
                bodyR, 40, 20, true);
            MainGroup.Children.Add(bodyMesh.MakeModel(Brushes.White));

            // Nose.
            const double noseR = 0.2;
            MeshGeometry3D noseMesh = new MeshGeometry3D();
            MeshExtensions.AddSphere(noseMesh,
                new Point3D(0, headY, 0),
                noseR, 20, 10, true);
            MainGroup.Children.Add(noseMesh.MakeModel(Brushes.Orange));
            noseMesh.ApplyTransformation(new ScaleTransform3D(1, 1, 3));
            noseMesh.ApplyTransformation(new TranslateTransform3D(0, 0, headR));

            // Eyes.
            const double eyeR = 0.15;
            MeshGeometry3D eyeMesh = new MeshGeometry3D();
            MeshExtensions.AddSphere(eyeMesh,
                new Point3D(0.4, 0.4, -0.15),
                eyeR, 7, 3, false);
            MeshExtensions.AddSphere(eyeMesh,
                new Point3D(-0.4, 0.4, -0.15),
                eyeR, 6, 3, false);
            MainGroup.Children.Add(eyeMesh.MakeModel(Brushes.Black));
            eyeMesh.ApplyTransformation(
                new TranslateTransform3D(0, headY, headR));

            // Buttons.
            const double buttonR = 0.17;
            MeshGeometry3D button1Mesh = new MeshGeometry3D();
            MeshExtensions.AddSphere(button1Mesh,
                new Point3D(0, 0, bodyR),
                buttonR, 7, 3, false);
            button1Mesh.ApplyTransformation(new TranslateTransform3D(0, -1, 0));
            MainGroup.Children.Add(button1Mesh.MakeModel(Brushes.DarkBlue));

            MeshGeometry3D button2Mesh = new MeshGeometry3D();
            MeshExtensions.AddSphere(button2Mesh,
                new Point3D(0, 0, bodyR),
                buttonR, 6, 3, false);
            Rotation3D rotation2 =
                new AxisAngleRotation3D(new Vector3D(1, 0, 0), -23);
            button2Mesh.ApplyTransformation(
                new RotateTransform3D(rotation2, new Point3D()));
            button2Mesh.ApplyTransformation(new TranslateTransform3D(0, -1, 0));
            MainGroup.Children.Add(button2Mesh.MakeModel(Brushes.DarkBlue));

            MeshGeometry3D button3Mesh = new MeshGeometry3D();
            MeshExtensions.AddSphere(button3Mesh,
                new Point3D(0, 0, bodyR),
                buttonR, 7, 3, false);
            Rotation3D rotation3 =
                new AxisAngleRotation3D(new Vector3D(1, 0, 0), -46);
            button3Mesh.ApplyTransformation(
                new RotateTransform3D(rotation3, new Point3D()));
            button3Mesh.ApplyTransformation(new TranslateTransform3D(0, -1, 0));
            MainGroup.Children.Add(button3Mesh.MakeModel(Brushes.DarkBlue));

            // Hat.
            MeshGeometry3D hatMesh = new MeshGeometry3D();
            const double hatR = 0.8;
            const double hatL = 1.65;
            Point3D[] polygon = G3.MakePolygonPoints(20, new Point3D(),
                new Vector3D(hatR, 0, 0), new Vector3D(0, 0, hatR));
            MeshExtensions.AddConeFrustum(hatMesh, new Point3D(0, headY, 0),
                polygon, new Vector3D(0, -3 * hatL, 0), hatL);

            // Brim.
            const double brimR = 1.5 * hatR;
            Point3D[] brimPolygon = G3.MakePolygonPoints(20,
                new Point3D(0, -hatL / 2, 0),
                new Vector3D(brimR, 0, 0), new Vector3D(0, 0, brimR));
            MeshExtensions.AddCylinder(hatMesh, brimPolygon,
                new Vector3D(0, -0.2, 0), true);

            Rotation3D hatRotation =
                new AxisAngleRotation3D(new Vector3D(0, 0, 1), -10);
            hatMesh.ApplyTransformation(
                new RotateTransform3D(hatRotation, new Point3D()));
            hatMesh.ApplyTransformation(new TranslateTransform3D(0.5, headY + 2, 0));
            MainGroup.Children.Add(hatMesh.MakeModel(Brushes.Green));
        }
    }
}
