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
    /// Interaction logic for howto_wpf_3d_platonic_solids_Window1.xaml
    /// </summary>
    public partial class howto_wpf_3d_platonic_solids_Window1 : Window
    {
        public howto_wpf_3d_platonic_solids_Window1()
        {
            InitializeComponent();
        }

        // The main object model group.
        private Model3DGroup MainModelGroup = new Model3DGroup();

        // Lights.
        private List<Light> Lights = new List<Light>();

        // The models.
        private GeometryModel3D AxesModel, WireframesModel, NormalsModel, VerticesModel;
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
            Color color64 = Color.FromArgb(255, 128, 128, 64);
            Color color128 = Color.FromArgb(255, 255, 255, 128);
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

            // Normal length.
            const double normal_length = 0.3;

            // Width of vertex boxes.
            const double vertex_width = 0.1;

            // Make the axes model.
            MeshGeometry3D axes_mesh = new MeshGeometry3D();
            axes_mesh.AddAxes(3.25, line_thickness, false, true, 2, 8);
            AxesModel = axes_mesh.MakeModel(Colors.Red);

            // Shared models.
            // Wireframe.
            MeshGeometry3D wireframe_mesh = new MeshGeometry3D();
            WireframesModel = wireframe_mesh.MakeModel(Colors.Black);

            // Normals.
            MeshGeometry3D normal_mesh = new MeshGeometry3D();
            NormalsModel = normal_mesh.MakeModel(Colors.Blue);

            // Vertices.
            MeshGeometry3D vertices_mesh = new MeshGeometry3D();
            SolidColorBrush vertices_brush = Brushes.Red;
            DiffuseMaterial vertices_material = new DiffuseMaterial(vertices_brush);
            VerticesModel = vertices_mesh.MakeModel(Colors.Red);

            // Make the list to hold the solid models.
            SolidModels = new List<GeometryModel3D>();

            // Tetrahedron.
            MeshGeometry3D tetrahedron_mesh = new MeshGeometry3D();
            tetrahedron_mesh.AddTetrahedron(1, null);
            SolidModels.Add(tetrahedron_mesh.MakeModel(Colors.Red));

            wireframe_mesh.MergeWith(tetrahedron_mesh.ToWireframe(line_thickness));
            normal_mesh.MergeWith(tetrahedron_mesh.ToTriangleNormals(normal_length, line_thickness));
            vertices_mesh.MergeWith(tetrahedron_mesh.ToVertexBoxes(vertex_width));

            // Cube.
            MeshGeometry3D cube_mesh = new MeshGeometry3D();
            cube_mesh.AddCube(1,
                new TranslateTransform3D(0, 0, 2));
            SolidModels.Add(cube_mesh.MakeModel(Colors.Green));

            wireframe_mesh.AddCubeWireframe(1, line_thickness,
                new TranslateTransform3D(0, 0, 2));
            normal_mesh.AddCubeNormals(1, normal_length, line_thickness,
                new TranslateTransform3D(0, 0, 2));
            vertices_mesh.MergeWith(cube_mesh.ToVertexBoxes(vertex_width));

            // Octahedron.
            MeshGeometry3D octahedron_mesh = new MeshGeometry3D();
            octahedron_mesh.AddOctahedron(1,
                new TranslateTransform3D(-2, 0, 0));
            SolidModels.Add(octahedron_mesh.MakeModel(Colors.Pink));

            wireframe_mesh.MergeWith(octahedron_mesh.ToWireframe(line_thickness));
            normal_mesh.MergeWith(octahedron_mesh.ToTriangleNormals(normal_length, line_thickness));
            vertices_mesh.MergeWith(octahedron_mesh.ToVertexBoxes(vertex_width));

            // Dodecahedron.
            MeshGeometry3D dodecahedron_mesh = new MeshGeometry3D();
            dodecahedron_mesh.AddDodecahedron(1,
                new TranslateTransform3D(0, 0, -2));
            SolidModels.Add(dodecahedron_mesh.MakeModel(Colors.Yellow));

            wireframe_mesh.AddDodecahedronWireframe(1, line_thickness,
                new TranslateTransform3D(0, 0, -2));
            normal_mesh.AddDodecahedronNormals(1, normal_length, line_thickness,
                new TranslateTransform3D(0, 0, -2));
            vertices_mesh.MergeWith(dodecahedron_mesh.ToVertexBoxes(vertex_width));

            // Icosahedron.
            MeshGeometry3D icosahedron_mesh = new MeshGeometry3D();
            icosahedron_mesh.AddIcosahedron(1,
                new TranslateTransform3D(2, 0, 0));
            SolidModels.Add(icosahedron_mesh.MakeModel(Colors.Orange));

            wireframe_mesh.MergeWith(icosahedron_mesh.ToWireframe(line_thickness));
            normal_mesh.MergeWith(icosahedron_mesh.ToTriangleNormals(normal_length, line_thickness));
            vertices_mesh.MergeWith(icosahedron_mesh.ToVertexBoxes(vertex_width));

            // Geodesic sphere.
            MeshGeometry3D sphere_mesh = new MeshGeometry3D();
            sphere_mesh.AddGeodesicSphere(1, 1,
                new TranslateTransform3D(0, -2, 0));
            SolidModels.Add(sphere_mesh.MakeModel(Colors.Cyan));

            wireframe_mesh.MergeWith(sphere_mesh.ToWireframe(line_thickness));
            normal_mesh.MergeWith(sphere_mesh.ToTriangleNormals(normal_length, line_thickness));
            vertices_mesh.MergeWith(sphere_mesh.ToVertexBoxes(vertex_width));

            // Stellate sphere.
            MeshGeometry3D stellate_mesh = new MeshGeometry3D();
            stellate_mesh.AddStellateSphere(1, 1, 0.96,
                new TranslateTransform3D(0, 2, 0));
            SolidModels.Add(stellate_mesh.MakeModel(Colors.White));

            wireframe_mesh.MergeWith(stellate_mesh.ToWireframe(line_thickness));
            normal_mesh.MergeWith(stellate_mesh.ToTriangleNormals(normal_length, line_thickness));
            vertices_mesh.MergeWith(stellate_mesh.ToVertexBoxes(vertex_width));

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
            if (chkWireframe.IsChecked.Value)
                MainModelGroup.Children.Add(WireframesModel);
            if (chkNormals.IsChecked.Value)
                MainModelGroup.Children.Add(NormalsModel);
            if (chkVertices.IsChecked.Value)
                MainModelGroup.Children.Add(VerticesModel);
        }
    }
}
