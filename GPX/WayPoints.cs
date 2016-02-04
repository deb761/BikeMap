using System;
using System.Collections.Generic;
using System.Text;

namespace GPX
{
    public class WayPoints
    {
        private List<WayPoint> _WayPoints;

        public WayPoints()
        {
            _WayPoints = new List<WayPoint>();
        }

        public WayPoints(List<WayPoint> wayPoints)
        {
            _WayPoints = wayPoints;
        }

        public void Reconnect()
        {
            WayPoint previousWaypoint = null;
            foreach (WayPoint wp in _WayPoints)
            {
                wp.PreviousWaypoint = previousWaypoint;
                wp.Recalculate();
            }
        }
    }
}
