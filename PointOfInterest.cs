using GPX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    /// <summary>
    /// A special vertex that the user can select as a start point or destination.
    /// This vertex type figures out which tracks it can be considered connected to.
    /// </summary>
    public class PointOfInterest : Vertex
    {
        /// <summary>
        /// Connections
        /// </summary>
        public List<ConnectInfo> Connections { get; protected set; }
        /// <summary>
        /// The track it is closest to
        /// </summary>
        public Track ClosestTrack { get; protected set; }
        public int ClosestTrackIndex { get; protected set; }
        /// <summary>
        /// The shortest edge between this POI and the closest track
        /// </summary>
        public Edge ShortestEdge { get; protected set; }
        /// <summary>
        /// Construct the POI from a waypoint
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="idx"></param>
        public PointOfInterest(WayPoint pt, int idx) : base(pt, idx)
        {
            Connections = new List<ConnectInfo>();
        }
        /// <summary>
        /// Find the edges that connect this POI to a track
        /// </summary>
        /// <param name="track">track</param>
        /// <param name="points">points on the track</param>
        /// <param name="trackStart">first vertex on the track</param>
        public void FindEdges(Edge track, List<Vertex> points)
        {
            ConnectInfo ci = null;
            for (int idx = 0; idx < points.Count; idx++)
            {
                Vertex point = points[idx];
                Edge edge = new Edge(this, point);
                if ((ShortestEdge == null) || (edge.Weight < ShortestEdge.Weight))
                {
                    ShortestEdge = edge;
                    ClosestTrackIndex = idx;
                    ClosestTrack = track.Track;
                }
                if (edge.Weight < Graph.MinDist)
                {
                    if (ci == null || ci.dist > edge.Weight)
                        ci = new ConnectInfo(track, point, idx, edge.Weight);
                }
            }
            // Add the connection if it was found
            if (ci != null)
            {
                Connections.Add(ci);
                Edges.Add(ci.track);
                track.AddPoint(this, ci.index);
            }
        }
        /// <summary>
        /// A class for information about how close a POI is to a track
        /// </summary>
        public class ConnectInfo
        {
            /// <summary>
            /// The edge along a track
            /// </summary>
            public Edge track;
            /// <summary>
            /// The closest vertex
            /// </summary>
            public Vertex point;
            /// <summary>
            /// The index of the closest point in the track
            /// </summary>
            public int index;
            /// <summary>
            /// The distance from the connection to the waypoint
            /// </summary>
            public double dist;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="track">track</param>
            /// <param name="point">point</param>
            public ConnectInfo(Edge track, Vertex point, int idx, double dist)
            {
                this.track = track;
                this.point = point;
                this.index = idx;
                this.dist = dist;
            }
        }
    }
}
