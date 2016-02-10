using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
