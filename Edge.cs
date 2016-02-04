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
        public WayPoint P1 { get; protected set; }
        public WayPoint P2 { get; protected set; }
        public Edge(WayPoint v1, WayPoint v2)
        {
            Weight = v1.GetDistanceFrom(v2);
            P1 = v1;
            P2 = v2;
        }
    }
}
