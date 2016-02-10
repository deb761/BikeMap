using Gpx;
using GPX;
using System;
using System.Collections.Generic;
using System.IO;

namespace BikeMap
{
    public class Graph
    {
        public List<WayPoint> Vertices { get; protected set; }
        public List<Vertex> Waypoints { get; protected set; }
        public List<Track> Tracks { get; protected set; }

        public Edge[,] edges;
        public Graph(string gpx)
        {
            Vertices = new List<WayPoint>();
            Tracks = new List<Track>();
            Waypoints = new List<Vertex>();

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
                                Waypoints.Add(new Vertex(reader.WayPoint));
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

            // Find out how many points we have (total waypoints and trackpoints)
            int sum = Waypoints.Count;
            Vertices.AddRange(Waypoints);

            foreach (Track track in Tracks)
            {
                var points = track.ToWayPoints();
                sum += points.Count;
                foreach (WayPoint point in points)
                {
                    Vertices.Add(point);
                }
            }

            // We finally know how many vertices we have so we can construct the matrix
            FillMatrix(Waypoints, Tracks, sum);

        }

        public const double MinDist = 0.020; // 20 m in units of km
        private void FillMatrix(List<Vertex> waypoints, List<Track> tracks, int nvertices)
        {
            edges = new Edge[nvertices, nvertices];

            // Now fill in the Edge matrix.  Points along the various tracks only connect to each other
            // Waypoints connect if they are with minDist meters of a point.
            int idx = waypoints.Count;
            foreach (Track track in tracks)
            {
                var points = track.ToWayPoints();
                for (int ip = 0; ip < points.Count; idx++, ip++)
                {
                    WayPoint point1 = points[ip];
                    if (ip < points.Count - 1)
                    {
                        WayPoint point2 = points[ip + 1];
                        edges[idx, idx + 1] = new Edge(point1, point2);
                        edges[idx + 1, idx] = edges[idx - 1, idx];
                    }

                    // See if any of the waypoints are close enough to say they are connected
                    for (int iwpt = 0; iwpt < waypoints.Count; iwpt++)
                    {
                        Edge edge = new Edge(point1, waypoints[iwpt]);
                        if (edge.Weight < MinDist)
                        {
                            edges[iwpt, idx - 1] = edge;
                            edges[idx - 1, iwpt] = edge;
                        }
                    }
                }
                foreach (Vertex wp in waypoints)
                {
                    wp.FindEdges(track, points);
                }
            }
            double trigger = 0;
            Vertex furthest = null;
            foreach (Vertex wp in waypoints)
            {
                if (wp.ShortestEdge.Weight > trigger)
                {
                    trigger = wp.ShortestEdge.Weight;
                    furthest = wp;
                }
                Track track = null;
                foreach (Vertex.ConnectInfo info in wp.Connections)
                {
                    if ((track != null) && (info.track.Equals(track)))
                    {
                        Console.WriteLine("Waypoint {0} is connected to {1} at {2} and {3}",
                            wp.Name, track.Name, info.point.ToString());
                    }
                    track = info.track;
                }
            }
        }

    }
}
