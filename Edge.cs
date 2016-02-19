using GPX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    public class Edge
    {
        public double Weight { get; set; }
        public Vertex P1 { get; protected set; }
        public Vertex P2 { get; protected set; }
        protected Edge() { }
        public Edge(Vertex v1, Vertex v2)
        {
            Weight = v1.Point.GetDistanceFrom(v2.Point);
            P1 = v1;
            P2 = v2;
        }
    }
}
