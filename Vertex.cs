using GPX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    public class Vertex : WayPoint
    {
        public List<ConnectInfo> Connections { get; protected set; }
        public Track ClosestTrack { get; protected set; }
        public Edge ShortestEdge { get; protected set; }

        public Vertex(Gpx.GpxPoint pt) : base(pt)
        {
            //PropertyInfo[] properties = typeof(WayPoint).GetProperties();
            //foreach (PropertyInfo bp in properties)
            //{
            //    // get derived matching property
            //    PropertyInfo dp = typeof(WayPoint).GetProperty(bp.Name, bp.PropertyType);

            //    // this property must not be index property
            //    if (
            //        (dp != null)
            //        && (dp.GetSetMethod() != null)
            //        && (bp.GetIndexParameters().Length == 0)
            //        && (dp.GetIndexParameters().Length == 0)
            //    )
            //        dp.SetValue(this, dp.GetValue(pt, null), null);
            //}
            Connections = new List<ConnectInfo>();
        }
        public void FindEdges(Track track, ICollection<WayPoint> points)
        {
            foreach (WayPoint point in points)
            {
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
        }
        public class ConnectInfo
        {
            public Track track;
            public WayPoint point;

            public ConnectInfo(Track track, WayPoint point)
            {
                this.track = track;
                this.point = point;
            }
        }
    }
}
