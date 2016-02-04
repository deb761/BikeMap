using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeMap
{
    public class Settings
    {
        public string MapFile { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }

        public Settings()
        {
            MapFile = "bikeroutes.gpx";
        }
    }
}
