using Gpx;
using GPX;
using System;
using System.Collections.Generic;
using System.IO;

namespace BikeMap
{
    public class Graph
    {
        /// <summary>
        /// The vertices in the graph
        /// </summary>
        public List<Vertex> Vertices { get; protected set; }
        /// <summary>
        /// The points of interest in the gpx file
        /// </summary>
        public List<WayPoint> Waypoints { get; protected set; }
        /// <summary>
        /// The tracks in the gpx file
        /// </summary>
        public List<Track> Tracks { get; protected set; }

        public Edge[,] edges;
        protected Graph()
        {
            Vertices = new List<Vertex>();
            Tracks = new List<Track>();
            Waypoints = new List<WayPoint>();
        }
        public Graph(string gpx) : this()
        {
            // Read in the GPX file
            try
            {
                GPXType map = GPXType.FromFile(gpx);
                Tracks = map.Tracks;
            }
            catch (InvalidOperationException)
            {
                //Version 2.0
                using (GpxReader reader = new GpxReader(new FileStream(gpx, FileMode.Open)))
                {
                    while (reader.Read())
                    {
                        switch (reader.ObjectType)
                        {
                            case GpxObjectType.Metadata:
                                break;
                            case GpxObjectType.WayPoint:
                                Waypoints.Add(new WayPoint(reader.WayPoint));
                                break;
                            case GpxObjectType.Route:
                                break;
                            case GpxObjectType.Track:
                                Tracks.Add(new Track(reader.Track));
                                break;
                        }
                    }
                }
            }

            // We finally know how many vertices we have so we can construct the matrix
            CreateEdges(Tracks);

            FloydWarshall();
        }

        public const double MinDist = 0.020; // 20 m in units of km
        private void CreateEdges(List<Track> tracks)
        {
             int idx = 0;
            foreach (WayPoint pt in Waypoints)
            {
                Vertices.Add(new Vertex(pt, idx++));
            }

            // Now fill in the Edge matrix.  Points along the various tracks only connect to each other
            // Waypoints connect if they are with minDist meters of a point.
            foreach (Track track in tracks)
            {
                var points = track.ToWayPoints();
                int trackStart = idx;
                Vertex v1 = new Vertex(points[0], idx++);
                Vertices.Add(v1);
                for (int ip = 1; ip < points.Count; idx++, ip++)
                {
                    Vertex v2 = new Vertex(points[ip], idx);
                    Edge edge = new Edge(v1, v2);
                    v1.Edges.Add(edge);
                    v2.Edges.Add(edge);

                    // See if any of the waypoints are close enough to say they are connected
                    for (int iwpt = 0; iwpt < Waypoints.Count; iwpt++)
                    {
                        edge = new Edge(v1, Vertices[iwpt]);
                        if (edge.Weight < MinDist)
                        {
                            Vertices[iwpt].Edges.Add(edge);
                            v1.Edges.Add(edge);
                        }
                    }
                }
                for (int iwp = 0; iwp < Waypoints.Count; iwp++)
                {
                    ((PointOfInterest)Vertices[iwp]).FindEdges(track, Vertices, trackStart);
                }
            }
            double trigger = 0;
            PointOfInterest furthest = null;
            for (int iwp = 0; iwp < Waypoints.Count; iwp++)
            {
                PointOfInterest poi = (PointOfInterest)Vertices[iwp];
                if (poi.ShortestEdge.Weight > trigger)
                {
                    trigger = poi.ShortestEdge.Weight;
                    furthest = poi;
                }
                Track track = null;
                foreach (PointOfInterest.ConnectInfo info in poi.Connections)
                {
                    if ((track != null) && (info.track.Equals(track)))
                    {
                        Console.WriteLine("Waypoint {0} is connected to {1} at {2} and {3}",
                            poi.Point.Name, track.Name, info.point.ToString());
                    }
                    track = info.track;
                }
            }
        }
        /*
        let dist be a |V| × |V| array of minimum distances initialized to ∞ (infinity)
        let next be a |V| × |V| array of vertex indices initialized to null

        procedure FloydWarshallWithPathReconstruction ()
           for each edge (u,v)
              dist[u][v] ← w(u,v)  // the weight of the edge (u,v)
              next[u][v] ← v
           for k from 1 to |V| // standard Floyd-Warshall implementation
              for i from 1 to |V|
                 for j from 1 to |V|
                    if dist[i][k] + dist[k][j] < dist[i][j] then
                       dist[i][j] ← dist[i][k] + dist[k][j]
                       next[i][j] ← next[i][k]
                       */
        protected double[,] dist;
        protected int?[,] next;
        public void FloydWarshall()
        {
            // define and initialize dist and next matrices
            InitializeMatrices();

            // see if going through node ipass will shorten distance from idx to jdx
            for (int ipass = 0; ipass < Vertices.Count; ipass++)
            {
                for (int idx = 0; idx < Vertices.Count; idx++)
                {
                    // check to see if ipass is the same node as the start or if there is no
                    // edge between idx and ipass
                    if ((idx == ipass) || (dist[idx, ipass] == double.PositiveInfinity))
                        continue;
                    for (int jdx = 0; jdx < Vertices.Count; jdx++)
                    {
                        if (jdx == ipass) continue; // save an addition
                        double newdist = dist[idx, ipass] + dist[ipass, jdx];
                        if (newdist < dist[idx, jdx])
                        {
                            dist[idx, jdx] = newdist;
                            next[idx, jdx] = next[idx, ipass];
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Set up the dist and next matrices to use in the Floyd-Warshall algorithm
        /// </summary>
        private void InitializeMatrices()
        {
            dist = new double[Vertices.Count, Vertices.Count];
            next = new int?[Vertices.Count, Vertices.Count];

            for (int idx = 0; idx < Vertices.Count; idx++)
            {
                for (int jdx = 0; jdx < Vertices.Count; jdx++)
                {
                    dist[idx, jdx] = double.PositiveInfinity;
                }
            }
            foreach (Vertex vertex in Vertices)
            {
                dist[vertex.Index, vertex.Index] = 0;
                foreach (Edge edge in vertex.Edges)
                {
                    dist[edge.P1.Index, edge.P2.Index] = edge.Weight;
                    next[edge.P1.Index, edge.P2.Index] = edge.P2.Index;
                }
            }
        }
        /// <summary>
        /// Find the path from the vertex at index idx to the vertex at index jdx using
        /// the results of the Floyd-Warshall algorithm.
        /// </summary>
        /// <param name="idx">index of starting vertex</param>
        /// <param name="jdx">index of ending vertex</param>
        /// <returns>path from vertex at idx to vertex at jdx</returns>
        private List<Vertex> Path(int idx, int jdx)
        {
            if (next[idx, jdx] == null)
                return null;
            List<Vertex> points = new List<Vertex>();
            points.Add(Vertices[idx]);
            int? udx = (int?)idx;
            while (udx != jdx)
            {
                udx = next[(int)udx, jdx];
                points.Add(Vertices[(int)udx]);
            }
            return points;
        }
        /// <summary>
        /// Find a shortest path from p1 to p2 using the results of the Floyd-Warshall algorithm.
        /// </summary>
        /// <param name="p1">point 1</param>
        /// <param name="p2">point 2</param>
        /// <returns>A list of the vertices on a shortest path from p1 to p2</returns>
        public List<Vertex> Path(Vertex p1, Vertex p2)
        {
            return Path(idx: p1.Index, jdx: p2.Index);
        }
        /// <summary>
        /// Retrieve the distance between the two nodes as calculated by the Floyd-Warshall algorithm.
        /// </summary>
        /// <param name="p1">Vertex 1</param>
        /// <param name="p2">Vertex 2</param>
        /// <returns>Distance in km</returns>
        public double Distance(Vertex p1, Vertex p2)
        {
            return dist[p1.Index, p2.Index];
        }
    }
}
