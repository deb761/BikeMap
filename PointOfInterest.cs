using GPX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    public class PointOfInterest : Vertex
    {
        public List<ConnectInfo> Connections { get; protected set; }
        public Track ClosestTrack { get; protected set; }
        public Edge ShortestEdge { get; protected set; }

        public PointOfInterest(WayPoint pt, int idx) : base(pt, idx)
        {
            Connections = new List<ConnectInfo>();
        }
        public void FindEdges(Track track, List<Vertex> points, int trackStart)
        {
            for (int idx = trackStart; idx < points.Count; idx++)
            {
                Vertex point = points[idx];
                Edge edge = new Edge(this, point);
                if ((ShortestEdge == null) || (edge.Weight < ShortestEdge.Weight))
                {
                    ShortestEdge = edge;
                    ClosestTrack = track;
                }
                if (edge.Weight < Graph.MinDist)
                {
                    Connections.Add(new ConnectInfo(track, point));
                }
            }
            Edges.Add(ShortestEdge);
        }
        public class ConnectInfo
        {
            public Track track;
            public Vertex point;

            public ConnectInfo(Track track, Vertex point)
            {
                this.track = track;
                this.point = point;
            }
        }
    }
}
