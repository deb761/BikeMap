using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    public class Vertex
    {
        public GPX.WayPoint Point { get; set; }
        public int Index { get; set; }
        public List<Edge> Edges { get; set; }
        public Vertex()
        {
            Edges = new List<Edge>();
        }
        public Vertex(GPX.WayPoint pt, int idx)
        {
            Point = pt;
            Index = idx;
        }
    }
}
