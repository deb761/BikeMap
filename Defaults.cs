using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace GPX
{
    class Defaults
    {
        internal static string GPXCreator
        {
            get
            {
                string tmp = ConfigurationManager.AppSettings["GPXCreator"];
                if (string.IsNullOrEmpty(tmp))
                    tmp = "Bernie's GPX Tool";
                return tmp;
            }
        }
        internal static string GPXSnippetLocation
        {
            get
            {
                string tmp = ConfigurationManager.AppSettings["GPXSnippetLocation"];
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                if (string.IsNullOrEmpty(tmp))
                    tmp = Path.Combine(desktop, "Temp.gpx");
                else if (!Path.IsPathRooted(tmp))
                    tmp = Path.Combine(desktop, Path.GetFileName(tmp));
                return tmp;
            }
        }
        internal static string TrackControl_BitmapPath
        {
            get
            {
                string tmp = ConfigurationManager.AppSettings["TrackControl_BitmapPath"];
                if (string.IsNullOrEmpty(tmp))
                    tmp = Path.Combine(Path.GetTempPath(), "Bitmap.bmp");
                else if (!Path.IsPathRooted(tmp))
                    tmp = Path.Combine(Path.GetTempPath(), Path.GetFileName(tmp));
                return tmp;
            }
        }
        internal static string GMapsFileCacheLocation
        {
            get
            {
                string tmp = ConfigurationManager.AppSettings["GMapsFileCacheLocation"];
                if (string.IsNullOrEmpty(tmp))
                    tmp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "GMap.Net.Cache");
                else if (!Path.IsPathRooted(tmp))
                    tmp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Path.GetFileName(tmp));
                Directory.CreateDirectory(tmp);
                return tmp;
            }
        }
        internal static DrawCategory TrackControl_X_Axis
        {
            get
            {
                DrawCategory retVal = DrawCategory.LongitudeKm;
                string tmp = ConfigurationManager.AppSettings["TrackControl_X_Axis"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = (DrawCategory)Enum.Parse(typeof(DrawCategory), tmp, true);
                }
                return retVal;
            }
        }
        internal static DrawCategory TrackControl_Y_Axis
        {
            get
            {
                DrawCategory retVal = DrawCategory.LatitudeKm;
                string tmp = ConfigurationManager.AppSettings["TrackControl_Y_Axis"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = (DrawCategory)Enum.Parse(typeof(DrawCategory), tmp, true);
                }
                return retVal;
            }
        }
        internal static WaypointsStyle TrackControl_WaypointsStyle
        {
            get
            {
                WaypointsStyle retVal = WaypointsStyle.SmallCircle;
                string tmp = ConfigurationManager.AppSettings["TrackControl_WaypointsStyle"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = (WaypointsStyle)Enum.Parse(typeof(WaypointsStyle), tmp, true);
                }
                return retVal;
            }
        }
        internal static WaypointsStyle TrackControl_PointsOfInterestStyle
        {
            get
            {
                WaypointsStyle retVal = WaypointsStyle.BigX;
                string tmp = ConfigurationManager.AppSettings["TrackControl_PointsOfInterestStyle"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = (WaypointsStyle)Enum.Parse(typeof(WaypointsStyle), tmp, true);
                }
                return retVal;
            }
        }
        internal static bool TrackForm_Maximized
        {
            get
            {
                bool retVal = false;
                string tmp = ConfigurationManager.AppSettings["TrackForm_Maximized"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = bool.Parse(tmp);
                }
                return retVal;
            }
        }
        internal static bool TrackForm_AutoDraw
        {
            get
            {
                bool retVal = false;
                string tmp = ConfigurationManager.AppSettings["TrackForm_AutoDraw"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = bool.Parse(tmp);
                }
                return retVal;
            }
        }
        internal static bool TrackForm_EqualScales
        {
            get
            {
                bool retVal = false;
                string tmp = ConfigurationManager.AppSettings["TrackForm_EqualScales"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = bool.Parse(tmp);
                }
                return retVal;
            }
        }
        internal static string TrackControl_WayPointInfo
        {
            get
            {
                string tmp = ConfigurationManager.AppSettings["TrackControl_WayPointInfo"];
                if (string.IsNullOrEmpty(tmp))
                    tmp = "Index,Index,#{0:F0}|Time,Time,{0:dd.MM.yyyy hh:mm:ss} GMT";
                return tmp;
            }
        }
        internal static double GPX_SpeedUnitFactor
        {
            get
            {
                string tmp = ConfigurationManager.AppSettings["GPX_SpeedUnitFactor"];
                double retVal;
                if (!double.TryParse(tmp, NumberStyles.Float, CultureInfo.InvariantCulture, out retVal))
                    retVal = 1.0;
                return retVal;
            }
        }

        internal static bool AutoViewTrack
        {
            get
            {
                bool retVal = false;
                string tmp = ConfigurationManager.AppSettings["AutoViewTrack"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = bool.Parse(tmp);
                }
                return retVal;
            }
        }
        internal static bool TrackControl_ShowMap
        {
            get
            {
                bool retVal = false;
                string tmp = ConfigurationManager.AppSettings["TrackControl_ShowMap"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = bool.Parse(tmp);
                }
                return retVal;
            }
        }
        internal static GMap.NET.MapType TrackControl_MapType
        {
            get
            {
                GMap.NET.MapType retVal = GMap.NET.MapType.GoogleSatellite;
                string tmp = ConfigurationManager.AppSettings["TrackControl_MapType"];
                if (!string.IsNullOrEmpty(tmp))
                {
                    retVal = (GMap.NET.MapType)Enum.Parse(typeof(GMap.NET.MapType), tmp, true);
                }
                return retVal;
            }
        }

    }
}
