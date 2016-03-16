using GPX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    /// <summary>
    /// An edge in the graph connecting two vertices
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Track associated with this edge, from which weight is determined
        /// </summary>
        public Track Track { get; set; }
        /// <summary>
        /// Distance in meters along the edge
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Vertex at the start of the edge
        /// </summary>
        public Vertex P1 { get; protected set; }
        /// <summary>
        /// Vertex at the end of the edge
        /// </summary>
        public Vertex P2 { get; protected set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        protected Edge() { }
        /// <summary>
        /// Constructor using two vertices
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public Edge(Vertex v1, Vertex v2)
        {
            Weight = v1.Point.GetDistanceFrom(v2.Point);
            P1 = v1;
            P2 = v2;
        }
        /// <summary>
        /// Constructor using a GPX track
        /// </summary>
        /// <param name="track">track</param>
        public Edge(Track track)
        {
            Track = track;
            track.Recalculate();
            Weight = track.GetTrackLength();
        }
        /// <summary>
        /// Add a point to the edge
        /// </summary>
        /// <param name="vertex">Vertex</param>
        /// <param name="index">Index of the closest point</param>
        public void AddPoint(Vertex vertex, int index)
        {
            if (index == 0)
                P1 = vertex;
            else if (index == Track.TrackSegments.First().WayPoints.Count - 1)
                P2 = vertex;
            else // this is used to figure out where to split a track into 2
                throw new Exception(string.Format("Need to split track at {0}", index));
        }
    }
}
