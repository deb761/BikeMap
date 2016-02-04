using System;
using System.Collections.Generic;
using System.Text;

namespace GPX
{
    public class WayPointSelectedEventArgs : EventArgs
    {
        private WayPoint _SelectedWaypoint;
        public WayPoint SelectedWaypoint
        {
            get { return _SelectedWaypoint; }
        }

        public WayPointSelectedEventArgs(WayPoint wp)
            : base()
        {
            _SelectedWaypoint = wp;
        }
    }
}
