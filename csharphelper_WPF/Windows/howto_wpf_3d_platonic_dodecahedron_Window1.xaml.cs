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
    /// Interaction logic for howto_wpf_3d_platonic_dodecahedron_Window1.xaml
    /// </summary>
    public partial class howto_wpf_3d_platonic_dodecahedron_Window1 : Window
    {
        public howto_wpf_3d_platonic_dodecahedron_Window1()
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
        private double CameraPhi = Math.PI / 6.0 - 0 * CameraDPhi;
        private double CameraTheta = Math.PI / 6.0 + 1.5 * CameraDTheta;
        private double CameraR = 4.0;

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
            Color color64 = Color.FromArgb(255, 128, 128, 64);
            Color color128 = Color.FromArgb(255, 255, 255, 128);
            Lights.Add(new AmbientLight(color64));
            Lights.Add(new DirectionalLight(color128,
                new Vector3D(-1.0, -2.0, -3.0)));
            Lights.Add(new DirectionalLight(color128,
                new Vector3D(1.0, 2.0, 3.0)));

            foreach (Light light in Lights)
                MainModelGroup.Children.Add(light);
        }

        // Return the vertices for an dodecahedron.
        private Point3D[] MakeVertices(double side_length)
        {
            // Value t1 is actually never used.
            double s = side_length;
            //double t1 = 2.0 * Math.PI / 5.0;
            double t2 = Math.PI / 10.0;
            double t3 = 3.0 * Math.PI / 10.0;
            double t4 = Math.PI / 5.0;
            double d1 = s / 2.0 / Math.Sin(t4);
            double d2 = d1 * Math.Cos(t4);
            double d3 = d1 * Math.Cos(t2);
            double d4 = d1 * Math.Sin(t2);
            double Fx =
                (s * s - (2.0 * d3) * (2.0 * d3) - (d1 * d1 - d3 * d3 - d4 * d4)) /
                (2.0 * (d4 - d1));
            double d5 = Math.Sqrt(0.5 *
                (s * s + (2.0 * d3) * (2.0 * d3) -
                    (d1 - Fx) * (d1 - Fx) -
                        (d4 - Fx) * (d4 - Fx) - d3 * d3));
            double Fy = (Fx * Fx - d1 * d1 - d5 * d5) / (2.0 * d5);
            double Ay = d5 + Fy;

            Point3D A = new Point3D(d1, Ay, 0);
            Point3D B = new Point3D(d4, Ay, d3);
            Point3D C = new Point3D(-d2, Ay, s / 2);
            Point3D D = new Point3D(-d2, Ay, -s / 2);
            Point3D E = new Point3D(d4, Ay, -d3);
            Point3D F = new Point3D(Fx, Fy, 0);
            Point3D G = new Point3D(Fx * Math.Sin(t2), Fy, Fx * Math.Cos(t2));
            Point3D H = new Point3D(-Fx * Math.Sin(t3), Fy, Fx * Math.Cos(t3));
            Point3D I = new Point3D(-Fx * Math.Sin(t3), Fy, -Fx * Math.Cos(t3));
            Point3D J = new Point3D(Fx * Math.Sin(t2), Fy, -Fx * Math.Cos(t2));
            Point3D K = new Point3D(Fx * Math.Sin(t3), -Fy, Fx * Math.Cos(t3));
            Point3D L = new Point3D(-Fx * Math.Sin(t2), -Fy, Fx * Math.Cos(t2));
            Point3D M = new Point3D(-Fx, -Fy, 0);
            Point3D N = new Point3D(-Fx * Math.Sin(t2), -Fy, -Fx * Math.Cos(t2));
            Point3D O = new Point3D(Fx * Math.Sin(t3), -Fy, -Fx * Math.Cos(t3));
            Point3D P = new Point3D(d2, -Ay, s / 2);
            Point3D Q = new Point3D(-d4, -Ay, d3);
            Point3D R = new Point3D(-d1, -Ay, 0);
            Point3D S = new Point3D(-d4, -Ay, -d3);
            Point3D T = new Point3D(d2, -Ay, -s / 2);

            List<Point3D> points = new List<Point3D>();
            points.Add(A);
            points.Add(B);
            points.Add(C);
            points.Add(D);
            points.Add(E);
            points.Add(F);
            points.Add(G);
            points.Add(H);
            points.Add(I);
            points.Add(J);
            points.Add(K);
            points.Add(L);
            points.Add(M);
            points.Add(N);
            points.Add(O);
            points.Add(P);
            points.Add(Q);
            points.Add(R);
            points.Add(S);
            points.Add(T);

            return points.ToArray();
        }

        // Verify that the edges have the same length.
        private void VerifyEdgeLengths(double length, Point3D[] points)
        {
            for (int i = 1; i < 6; i++)
                VerifyEdgeLength(length, points[0], points[i]);
            for (int i = 1; i < 6; i++)
            {
                int pt2 = i + 1;
                if (pt2 > 5) pt2 = 1;
                VerifyEdgeLength(length, points[i], points[pt2]);
            }
            VerifyEdgeLength(length, points[1], points[8]);
            VerifyEdgeLength(length, points[1], points[9]);
            VerifyEdgeLength(length, points[2], points[9]);
            VerifyEdgeLength(length, points[2], points[10]);
            VerifyEdgeLength(length, points[3], points[10]);
            VerifyEdgeLength(length, points[3], points[6]);
            VerifyEdgeLength(length, points[4], points[6]);
            VerifyEdgeLength(length, points[4], points[7]);
            VerifyEdgeLength(length, points[5], points[7]);
            VerifyEdgeLength(length, points[5], points[8]);
            for (int i = 6; i < 11; i++)
            {
                int pt2 = i + 1;
                if (pt2 > 10) pt2 = 6;
                VerifyEdgeLength(length, points[i], points[pt2]);
            }
            for (int i = 6; i < 11; i++)
                VerifyEdgeLength(length, points[11], points[i]);
        }

        private void VerifyEdgeLength(double length, Point3D p0, Point3D p1)
        {
            Vector3D vector = p1 - p0;
            Debug.Assert(Math.Abs(length - vector.Length) < 0.00001,
                "Edge " + p0.ToString() + " --> " + p1.ToString() +
                " does not have length " + length);
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
            Point3D xmax = new Point3D(1.5, 0, 0);
            Point3D ymax = new Point3D(0, 1.5, 0);
            Point3D zmax = new Point3D(0, 0, 1.5);
            AddSegment(axes_mesh, origin, xmax, new Vector3D(0, 1, 0));
            AddSegment(axes_mesh, origin, zmax, new Vector3D(0, 1, 0));
            AddSegment(axes_mesh, origin, ymax, new Vector3D(1, 0, 0));

            SolidColorBrush axes_brush = Brushes.Red;
            DiffuseMaterial axes_material = new DiffuseMaterial(axes_brush);
            axes_model = new GeometryModel3D(axes_mesh, axes_material);

            // Get the dodecahedron's points.
            Point3D[] points = MakeVertices(1);

            // Create the solid dodecahedron.
            MeshGeometry3D solid_mesh = new MeshGeometry3D();
            AddPolygon(solid_mesh, "EDCBA", points);
            AddPolygon(solid_mesh, "ABGKF", points);
            AddPolygon(solid_mesh, "AFOJE", points);
            AddPolygon(solid_mesh, "EJNID", points);
            AddPolygon(solid_mesh, "DIMHC", points);
            AddPolygon(solid_mesh, "CHLGB", points);
            AddPolygon(solid_mesh, "KPTOF", points);
            AddPolygon(solid_mesh, "OTSNJ", points);
            AddPolygon(solid_mesh, "NSRMI", points);
            AddPolygon(solid_mesh, "MRQLH", points);
            AddPolygon(solid_mesh, "LQPKG", points);
            AddPolygon(solid_mesh, "PQRST", points);

            SolidColorBrush solid_brush = Brushes.Orange;
            DiffuseMaterial solid_material = new DiffuseMaterial(solid_brush);
            solid_model = new GeometryModel3D(solid_mesh, solid_material);

            // Create the skeleton.
            MeshGeometry3D skeleton_mesh = new MeshGeometry3D();
            Vector3D upy = new Vector3D(0, 1, 0);
            AddPolygonSegments(skeleton_mesh, "EDCBA", points, upy);
            AddPolygonSegments(skeleton_mesh, "ABGKF", points, upy);
            AddPolygonSegments(skeleton_mesh, "AFOJE", points, upy);
            AddPolygonSegments(skeleton_mesh, "EJNID", points, upy);
            AddPolygonSegments(skeleton_mesh, "DIMHC", points, upy);
            AddPolygonSegments(skeleton_mesh, "CHLGB", points, upy);
            AddPolygonSegments(skeleton_mesh, "KPTOF", points, upy);
            AddPolygonSegments(skeleton_mesh, "OTSNJ", points, upy);
            AddPolygonSegments(skeleton_mesh, "NSRMI", points, upy);
            AddPolygonSegments(skeleton_mesh, "MRQLH", points, upy);
            AddPolygonSegments(skeleton_mesh, "LQPKG", points, upy);
            AddPolygonSegments(skeleton_mesh, "PQRST", points, upy);

            SolidColorBrush skeleton_brush = Brushes.Brown;
            DiffuseMaterial skeleton_material = new DiffuseMaterial(skeleton_brush);
            skeleton_model = new GeometryModel3D(skeleton_mesh, skeleton_material);
        }

        // Add a polygon by using the point names A, B, C, etc.
        private void AddPolygon(MeshGeometry3D mesh, string point_names, Point3D[] points)
        {
            Point3D[] polygon_points = new Point3D[point_names.Length];
            for (int i = 0; i < point_names.Length; i++)
            {
                polygon_points[i] = points[ToIndex(point_names[i])];
            }
            AddPolygon(mesh, polygon_points);
        }

        // Find a point's index from its letter.
        private int ToIndex(char ch)
        {
            return ch - 'A';
        }

        // Add a polygon to the indicated mesh.
        // Do not reuse old points but reuse these points.
        private void AddPolygon(MeshGeometry3D mesh, params Point3D[] points)
        {
            // Create the points.
            int index1 = mesh.Positions.Count;
            foreach (Point3D point in points)
                mesh.Positions.Add(point);

            // Create the triangles.
            for (int i = 1; i < points.Length - 1; i++)
            {
                mesh.TriangleIndices.Add(index1);
                mesh.TriangleIndices.Add(index1 + i);
                mesh.TriangleIndices.Add(index1 + i + 1);
            }
        }

        // Add a rectangle to the indicated mesh.
        // Do not reuse existing points but reuse these points
        // so new rectangles don't share normals with old ones.
        private void AddRectangle(MeshGeometry3D mesh,
            Point3D point1, Point3D point2, Point3D point3, Point3D point4)
        {
            // Create the points.
            int index1 = mesh.Positions.Count;
            mesh.Positions.Add(point1);
            mesh.Positions.Add(point2);
            mesh.Positions.Add(point3);
            mesh.Positions.Add(point4);

            // Create the triangles.
            mesh.TriangleIndices.Add(index1);
            mesh.TriangleIndices.Add(index1 + 1);
            mesh.TriangleIndices.Add(index1 + 2);

            mesh.TriangleIndices.Add(index1);
            mesh.TriangleIndices.Add(index1 + 2);
            mesh.TriangleIndices.Add(index1 + 3);
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

        private void AddPolygonSegments(MeshGeometry3D mesh,
            string point_names, Point3D[] points, Vector3D up)
        {
            for (int i = 0; i < point_names.Length; i++)
            {
                char ch1 = point_names[i];
                char ch2 = point_names[(i + 1) % point_names.Length];
                AddSegment(mesh, points, ch1, ch2, up);
            }
        }
        private void AddSegment(MeshGeometry3D mesh, Point3D[] points,
            char name1, char name2, Vector3D up)
        {
            Point3D point1 = points[ToIndex(name1)];
            Point3D point2 = points[ToIndex(name2)];
            VerifyEdgeLength(1, point1, point2);

            AddSegment(mesh, point1, point2, up);
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
