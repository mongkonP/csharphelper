using System;
using System.Collections.Generic;

using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace howto_wpf_3d_truncated_dodecahedron
{
    public static class ArchimedeanSolids
    {
        // Precision for point comparison.
        private const double Precision = 0.0001;

        // Return two meshes, one holding truncated
        // corners and one holding modified faces.
        // The frac parameter tells how far along
        // each edge the corners should be truncated and
        // should be between 0.0 and 0.5
        public static void TruncateSolid(List<Point3D> vertices,
            List<Polygon> faces, double frac,
            out MeshGeometry3D corner_mesh, out MeshGeometry3D face_mesh)
        {
            // Make the corner mesh.
            corner_mesh = MakeTruncatedSolidCornerMesh(vertices, faces, frac);

            // Make the face mesh.
            face_mesh = MakeTruncatedSolidFaceMesh(vertices, faces, frac);
        }

        // Make a mesh for the corner faces of a truncated solid.
        private static MeshGeometry3D MakeTruncatedSolidCornerMesh(
            List<Point3D> vertices,
            List<Polygon> faces, double frac)
        {
            // Make a list to hold the new polygons.
            List<Polygon> corner_polygons = new List<Polygon>();

            // Consider each vertex.
            foreach (Point3D vertex in vertices)
            {
                // Find the faces containing this vertex.
                // Make a list of edges across those faces.
                List<Edge> edges = new List<Edge>();
                foreach (Polygon face in faces)
                {
                    // See if the vertex is in this face.
                    int i1 = PointIndex(face.Points, vertex, Precision);
                    if (i1 >= 0)
                    {
                        // This face contains the vertex.
                        // Find the indices of the points
                        // that are adjacent to the vertex.
                        int i0 = i1 - 1;
                        if (i0 < 0) i0 += face.Points.Length;
                        int i2 = (i1 + 1) % face.Points.Length;

                        // Calculate the edge end points.
                        Vector3D v10 = face.Points[i0] - face.Points[i1];
                        Point3D p0 = face.Points[i1] + frac * v10;
                        Vector3D v12 = face.Points[i2] - face.Points[i1];
                        Point3D p2 = face.Points[i1] + frac * v12;

                        edges.Add(new Edge(p0, p2));
                    } // End finding faces that contain this vertex.
                }

                // Order the edges so they form a polygon.
                Polygon polygon = EdgesToPolygon(edges);

                // Orient the polygon's points outwardly
                // with respect to the vertex.
                OrientPolygon(polygon.Points, vertex);

                // Add the polygon to the list of corner polygons.
                corner_polygons.Add(polygon);
            } // End examining each vertex.

            // Make the corner mesh.
            MeshGeometry3D corner_mesh = new MeshGeometry3D();
            foreach (Polygon polygon in corner_polygons)
                corner_mesh.AddPolygon(polygon.Points);

            return corner_mesh;
        }

        // Order the edges so they form a non-intersecting
        // polygon around the vertex.
        private static Polygon EdgesToPolygon(List<Edge> edges)
        {
            // Make the result point list.
            List<Point3D> points = new List<Point3D>();

            // Add the first edge to the new list.
            Edge edge = edges[0];
            Point3D last_point = edge.Point2;
            points.Add(last_point);
            edges.RemoveAt(0);

            // Save the last point.

            // Add the other edges.
            while (edges.Count > 0)
            {
                bool found_edge = false;
                for (int i = 0; i < edges.Count; i++)
                {
                    // Check this edge.
                    edge = edges[i];

                    // See if the edge's first point matches
                    // the last point in the polygon.
                    if (PointEquals(last_point, edge.Point1, Precision))
                    {
                        // Add edge.Point2 to the polygon.
                        last_point = edge.Point2;
                        points.Add(last_point);
                        edges.RemoveAt(i);
                        found_edge = true;
                        break;
                    }

                    // See if the edge's second point matches
                    // the last point in the polygon.
                    if (PointEquals(last_point, edge.Point2, Precision))
                    {
                        // Add edge.Point1 to the polygon.
                        last_point = edge.Point1;
                        points.Add(last_point);
                        edges.RemoveAt(i);
                        found_edge = true;
                        break;
                    }

                    // Continue looking for the next edge.                
                }

                // Make sure we found an edge.
                if (!found_edge)
                    throw new Exception("Could not find a next edge for the polygon.");
            }

            // Return the polygon.
            return new Polygon(points.ToArray());
        }

        // Orient the points so the polygon is outwardly
        // oriented with respect to the given point.
        private static void OrientPolygon(Point3D[] points, Point3D outside)
        {
            // See if the points are already correctly oriented.
            Vector3D v01 = points[1] - points[0];
            Vector3D v12 = points[2] - points[1];
            Vector3D cross = Vector3D.CrossProduct(v01, v12);

            Vector3D vOutside = outside - points[0];
            if (Vector3D.DotProduct(vOutside, cross) < 0)
            {
                // The points are inwardly oriented.
                // Reverse their order.
                Array.Reverse(points);
            }
        }

        // Return the index of a point within an array.
        private static int PointIndex(Point3D[] points, Point3D target, double precision)
        {
            for (int i = 0; i < points.Length; i++)
                if (PointEquals(target, points[i], precision))
                    return i;
            return -1;
        }

        // Return true if the points are the same.
        private static bool PointEquals(Point3D point1, Point3D point2, double precision)
        {
            Vector3D v = point1 - point2;
            return (v.Length <= precision);
        }

        // Make a mesh for the faces of a truncated solid.
        private static MeshGeometry3D MakeTruncatedSolidFaceMesh(
            List<Point3D> vertices,
            List<Polygon> faces, double frac)
        {
            // Make the output mesh.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Consider each of the original faces.
            foreach (Polygon face in faces)
            {
                // Make a list to hold the new polygon's points.
                List<Point3D> points = new List<Point3D>();

                // Consider each edge in the polygon.
                for (int i0 = 0; i0 < face.Points.Length; i0++)
                {
                    // Consider the edge from point i0 to
                    // point i1 = i + 1.
                    int i1 = (i0 + 1) % face.Points.Length;
                    Vector3D v = face.Points[i1] - face.Points[i0];

                    // Add the points along the edge.
                    points.Add(face.Points[i0] + v * frac);
                    if (frac < 0.5)
                        points.Add(face.Points[i0] + v * (1 - frac));
                }

                // Make the new points into a
                // polygon and add it to the mesh.
                mesh.AddPolygon(points.ToArray());
            } // End looping through the faces.

            // Return the mesh.
            return mesh;
        }

        #region Truncated Tetrahedron

        // Make a truncated tetrahedron.
        public static void MakeTruncatedTetrahedron(
            double side_length, double frac, Transform3D transform,
            out MeshGeometry3D corner_mesh, out MeshGeometry3D face_mesh)
        {
            // Get the vertices.
            List<Point3D> vertices = PlatonicSolids.TetrahedronVertices(side_length);

            // Transform the points if desired.
            if (transform != null)
            {
                Point3D[] point_array = vertices.ToArray();
                transform.Transform(point_array);
                vertices = new List<Point3D>(point_array);
            }

            // Make the faces.
            List<Polygon> faces = new List<Polygon>();
            faces.Add(new Polygon(vertices[0], vertices[1], vertices[2]));
            faces.Add(new Polygon(vertices[0], vertices[2], vertices[3]));
            faces.Add(new Polygon(vertices[0], vertices[3], vertices[1]));
            faces.Add(new Polygon(vertices[3], vertices[2], vertices[1]));

            ArchimedeanSolids.TruncateSolid(
                vertices, faces, frac,
                out corner_mesh, out face_mesh);
        }

        #endregion Truncated Tetrahedron

        #region Truncated Cube

        // Make a truncated cube.
        public static void MakeTruncatedCube(
            double side_length, double frac, Transform3D transform,
            out MeshGeometry3D corner_mesh, out MeshGeometry3D face_mesh)
        {
            // Get the vertices.
            List<Point3D> vertices = PlatonicSolids.CubeVertices(side_length);

            // Transform the points if desired.
            if (transform != null)
            {
                Point3D[] point_array = vertices.ToArray();
                transform.Transform(point_array);
                vertices = new List<Point3D>(point_array);
            }

            // Make the faces.
            List<Polygon> faces = new List<Polygon>();
            faces.Add(new Polygon(vertices[0], vertices[1], vertices[2], vertices[3]));
            faces.Add(new Polygon(vertices[0], vertices[4], vertices[5], vertices[1]));
            faces.Add(new Polygon(vertices[1], vertices[5], vertices[6], vertices[2]));
            faces.Add(new Polygon(vertices[2], vertices[6], vertices[7], vertices[3]));
            faces.Add(new Polygon(vertices[3], vertices[7], vertices[4], vertices[0]));
            faces.Add(new Polygon(vertices[7], vertices[6], vertices[5], vertices[4]));

            ArchimedeanSolids.TruncateSolid(
                vertices, faces, frac,
                out corner_mesh, out face_mesh);
        }

        #endregion Truncated Cube

        #region Truncated Octahedron

        // Make a truncated octahedron.
        public static void MakeTruncatedOctahedron(
            double side_length, double frac, Transform3D transform,
            out MeshGeometry3D corner_mesh, out MeshGeometry3D face_mesh)
        {
            // Get the vertices.
            List<Point3D> vertices = PlatonicSolids.OctahedronVertices(side_length);

            // Transform the points if desired.
            if (transform != null)
            {
                Point3D[] point_array = vertices.ToArray();
                transform.Transform(point_array);
                vertices = new List<Point3D>(point_array);
            }

            // Make the faces.
            List<Polygon> faces = new List<Polygon>();
            faces.Add(new Polygon(vertices[0], vertices[1], vertices[2]));
            faces.Add(new Polygon(vertices[0], vertices[2], vertices[3]));
            faces.Add(new Polygon(vertices[0], vertices[3], vertices[4]));
            faces.Add(new Polygon(vertices[0], vertices[4], vertices[1]));
            faces.Add(new Polygon(vertices[5], vertices[4], vertices[3]));
            faces.Add(new Polygon(vertices[5], vertices[3], vertices[2]));
            faces.Add(new Polygon(vertices[5], vertices[2], vertices[1]));
            faces.Add(new Polygon(vertices[5], vertices[1], vertices[4]));

            ArchimedeanSolids.TruncateSolid(
                vertices, faces, frac,
                out corner_mesh, out face_mesh);
        }

        #endregion Truncated Octahedron

        #region Truncated Dodecahedron

        // Make a truncated dodecahedron.
        public static void MakeTruncatedDodecahedron(
            double side_length, double frac, Transform3D transform,
            out MeshGeometry3D corner_mesh, out MeshGeometry3D face_mesh)
        {
            // Get the vertices.
            List<Point3D> vertices = PlatonicSolids.DodecahedronVertices(side_length);

            // Transform the points if desired.
            if (transform != null)
            {
                Point3D[] point_array = vertices.ToArray();
                transform.Transform(point_array);
                vertices = new List<Point3D>(point_array);
            }

            // Make the faces.
            List<Polygon> faces = new List<Polygon>();
            faces.Add(new Polygon("EDCBA", vertices));
            faces.Add(new Polygon("ABGKF", vertices));
            faces.Add(new Polygon("AFOJE", vertices));
            faces.Add(new Polygon("EJNID", vertices));
            faces.Add(new Polygon("DIMHC", vertices));
            faces.Add(new Polygon("CHLGB", vertices));
            faces.Add(new Polygon("KPTOF", vertices));
            faces.Add(new Polygon("OTSNJ", vertices));
            faces.Add(new Polygon("NSRMI", vertices));
            faces.Add(new Polygon("MRQLH", vertices));
            faces.Add(new Polygon("LQPKG", vertices));
            faces.Add(new Polygon("PQRST", vertices));

            ArchimedeanSolids.TruncateSolid(
                vertices, faces, frac,
                out corner_mesh, out face_mesh);
        }

        #endregion Truncated Dodecahedron

        #region Truncated Octahedron

        // Make a truncated icosahedron.
        public static void MakeTruncatedIcosahedron(
            double side_length, double frac, Transform3D transform,
            out MeshGeometry3D corner_mesh, out MeshGeometry3D face_mesh)
        {
            // Get the vertices.
            List<Point3D> vertices = PlatonicSolids.IcosahedronVertices(side_length);

            // Transform the points if desired.
            if (transform != null)
            {
                Point3D[] point_array = vertices.ToArray();
                transform.Transform(point_array);
                vertices = new List<Point3D>(point_array);
            }

            // Make the faces.
            List<Polygon> faces = new List<Polygon>();
            faces.Add(new Polygon(vertices[0], vertices[2], vertices[1]));
            faces.Add(new Polygon(vertices[0], vertices[3], vertices[2]));
            faces.Add(new Polygon(vertices[0], vertices[4], vertices[3]));
            faces.Add(new Polygon(vertices[0], vertices[5], vertices[4]));
            faces.Add(new Polygon(vertices[0], vertices[1], vertices[5]));

            faces.Add(new Polygon(vertices[1], vertices[2], vertices[9]));
            faces.Add(new Polygon(vertices[2], vertices[3], vertices[10]));
            faces.Add(new Polygon(vertices[3], vertices[4], vertices[6]));
            faces.Add(new Polygon(vertices[4], vertices[5], vertices[7]));
            faces.Add(new Polygon(vertices[5], vertices[1], vertices[8]));

            faces.Add(new Polygon(vertices[6], vertices[4], vertices[7]));
            faces.Add(new Polygon(vertices[7], vertices[5], vertices[8]));
            faces.Add(new Polygon(vertices[8], vertices[1], vertices[9]));
            faces.Add(new Polygon(vertices[9], vertices[2], vertices[10]));
            faces.Add(new Polygon(vertices[10], vertices[3], vertices[6]));

            faces.Add(new Polygon(vertices[11], vertices[6], vertices[7]));
            faces.Add(new Polygon(vertices[11], vertices[7], vertices[8]));
            faces.Add(new Polygon(vertices[11], vertices[8], vertices[9]));
            faces.Add(new Polygon(vertices[11], vertices[9], vertices[10]));
            faces.Add(new Polygon(vertices[11], vertices[10], vertices[6]));


            ArchimedeanSolids.TruncateSolid(
                vertices, faces, frac,
                out corner_mesh, out face_mesh);
        }

        #endregion Truncated Icosahedron
    }
}
