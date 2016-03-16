using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    /// <summary>
    /// A vertex on the Graph
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// GPX point the vertex is based on
        /// </summary>
        public GPX.WayPoint Point { get; set; }
        /// <summary>
        /// Index the vertex is at in the list
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Edges connected to this vertex
        /// </summary>
        public List<Edge> Edges { get; set; }
        /// <summary>
        /// The name of the point
        /// </summary>
        public string Name { get { return Point.Name; } }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Vertex()
        {
            Edges = new List<Edge>();
        }
        /// <summary>
        /// Construct the vertex from a GPX point
        /// </summary>
        /// <param name="pt">point</param>
        /// <param name="idx">index of the point</param>
        public Vertex(GPX.WayPoint pt, int idx) : this()
        {
            Point = pt;
            Index = idx;
        }
    }
}
