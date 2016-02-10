using System.Collections.Generic;

namespace GPX
{
    internal class TrackOnMap
    {
        public List<WayPointOnMap> WayPoints { get; set; }
        public TrackOnMap()
        {
            WayPoints = new List<WayPointOnMap>();
        }
    }
}
