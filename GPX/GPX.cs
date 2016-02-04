using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace GPX
{
    /// <summary>
    /// GPX is the root element in the XML file.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    [System.Xml.Serialization.XmlRootAttribute("gpx", Namespace = "http://www.topografix.com/GPX/1/1", IsNullable = false)]
    public class GPXType
    {
        #region Variables
        private Metadata metadataField;

        //private WayPoint[] wptField;
        private List<WayPoint> wptField;

        //private rteType[] rteField;
        private List<Route> rteField;

        //private Track[] trkField;
        private List<Track> trkField;

        private Extensions extensionsField;

        private string versionField;

        private string creatorField;
        #endregion Variables

        public GPXType()
        {
            this.versionField = "1.1";
            wptField = new List<WayPoint>();
            rteField = new List<Route>();
            trkField = new List<Track>();
        }

        /// <summary>
        /// Metadata about the file.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("metadata")]
        public Metadata Metadata
        {
            get
            {
                return this.metadataField;
            }
            set
            {
                this.metadataField = value;
            }
        }

        /// <summary>
        /// A list of waypoints.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("wpt")]
        public List<WayPoint> WayPoints
        {
            get
            {
                return this.wptField;
            }
            set
            {
                this.wptField = value;
            }
        }

        /// <summary>
        /// A list of routes.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("rte")]
        public List<Route> Routes
        {
            get
            {
                return this.rteField;
            }
            set
            {
                this.rteField = value;
            }
        }

        /// <summary>
        /// A list of tracks.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("trk")]
        public List<Track> Tracks
        {
            get
            {
                return this.trkField;
            }
            set
            {
                this.trkField = value;
            }
        }

        /// <summary>
        /// You can add extend GPX by adding your own elements from another schema here.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("extensions")]
        public Extensions Extensions
        {
            get
            {
                return this.extensionsField;
            }
            set
            {
                this.extensionsField = value;
            }
        }

        /// <summary>
        /// You must include the version number in your GPX document.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("version")]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                if (value != "1.1")
                    throw new ArgumentException("Only version 1.1 is allowed.");
                this.versionField = value;
            }
        }

        /// <summary>
        /// You must include the name or URL of the software that created your GPX document. This allows others to inform the creator of a GPX instance document that fails to validate.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("creator")]
        public string Creator
        {
            get
            {
                return this.creatorField;
            }
            set
            {
                this.creatorField = value;
            }
        }


        #region Extensions
        private BoundsEx _boundsField;
        [System.Xml.Serialization.XmlIgnore()]
        public BoundsEx GPXBounds
        {
            get
            {
                if (_boundsField == null)
                {
                    CalculateBounds();
                }
                return _boundsField;
            }
        }

        public void CalculateBounds()
        {
            _boundsField = trkField[0].TrackBounds;
            for (int i = 1; i < trkField.Count; i++)
            {
                BoundsEx bounds = trkField[i].TrackBounds;
                if (_boundsField.ElevationMaximum < bounds.ElevationMaximum)
                    _boundsField.ElevationMaximum = bounds.ElevationMaximum;
                if (_boundsField.ElevationMinimum > bounds.ElevationMinimum)
                    _boundsField.ElevationMinimum = bounds.ElevationMinimum;
                if (_boundsField.EndTime < bounds.EndTime)
                    _boundsField.EndTime = bounds.EndTime;
                if (_boundsField.LatitudeMaximum < bounds.LatitudeMaximum)
                    _boundsField.LatitudeMaximum = bounds.LatitudeMaximum;
                if (_boundsField.LatitudeMinimum > bounds.LatitudeMinimum)
                    _boundsField.LatitudeMinimum = bounds.LatitudeMinimum;
                if (_boundsField.LongitudeMaximum < bounds.LongitudeMaximum)
                    _boundsField.LongitudeMaximum = bounds.LongitudeMaximum;
                if (_boundsField.LongitudeMinimum > bounds.LongitudeMinimum)
                    _boundsField.LongitudeMinimum = bounds.LongitudeMinimum;
                if (_boundsField.StartTime > bounds.StartTime)
                    _boundsField.StartTime = bounds.StartTime;
            }
        }

        //public static GPXType FromVersion_1_0(GPX_1_0.gpx oldData)
        //{
        //    GPXType retVal = new GPXType();

        //    if (retVal.Routes == null)
        //        retVal.Routes = new List<Route>();
        //    if (oldData.rte != null)
        //    {
        //        foreach (GPX_1_0.gpxRte oldRte in oldData.rte)
        //        {
        //            Route route = Route.FromVersion_1_0(oldRte);
        //            retVal.Routes.Add(route);
        //        }
        //    }
        //    retVal.trkField = new List<Track>();
        //    if (oldData.trk != null)
        //    {
        //        foreach (GPX_1_0.gpxTrk oldseg in oldData.trk)
        //        {
        //            TrackSegment seg = new TrackSegment();
        //            foreach (GPX_1_0.gpxWpt oldpt in oldseg.trkseg.)
        //            seg.WayPoints.Add()
        //        }
        //        Track track = Track.F
        //    return retVal;
        //    }

        public static GPXType FromFile(string fileName)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(GPXType));
                GPXType retVal = (GPXType)xs.Deserialize(fs);
                retVal.CleanupTrackpointExtension();
                return retVal;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        private void CleanupTrackpointExtension()
        {
            foreach (Track track in this.Tracks)
            {
                foreach (TrackSegment segment in track.TrackSegments)
                {
                    foreach (WayPoint wpt in segment.WayPoints)
                    {
                        if (wpt.extensions != null)
                        {
                            wpt.CleanupExtension();
                        }
                    }
                }
            }
        }

        public void ToFile(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(GPXType));
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            xmlWriterSettings.Indent = false;
            xmlWriterSettings.NewLineOnAttributes = false;
            System.Xml.XmlWriter xmlWriter = System.Xml.XmlWriter.Create(fs, xmlWriterSettings);
            xs.Serialize(xmlWriter, this);
            fs.Close();
            //xmlWriter.Close();
            fs.Dispose();
        }
        #endregion Extensions

        public void ExportHeartrate(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                using (TextWriter writer = new StreamWriter(fs))
                {
                    foreach (Track track in this.Tracks)
                    {
                        foreach (TrackSegment segment in track.TrackSegments)
                        {
                            foreach (WayPoint wpt in segment.WayPoints)
                            {
                                if (wpt.Heartreate != 0)
                                {
                                    string line = string.Format("{0:yyyy-MM-dd HH:mm:ss} {1}", wpt.Time, wpt.Heartreate);
                                    writer.WriteLine(line);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
