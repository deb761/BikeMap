using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GPX
{
    /// <summary>
    /// This represents a track - an ordered list of points describing a path.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class Track
    {
        #region Variables
        private string nameField;

        private string cmtField;

        private string descField;

        private string srcField;

        //private linkType[] linkField;
        private List<Link> linkField;

        private string numberField;

        private string typeField;

        private Extensions extensionsField;

        //private TrackSegment[] trksegField;
        private List<TrackSegment> trksegField;
        #endregion Variables

        public Track()
        {
            trksegField = new List<TrackSegment>();
        }
        /// <summary>
        /// GPS name of track.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <summary>
        /// GPS comment for track.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("cmt")]
        public string Comment
        {
            get
            {
                return this.cmtField;
            }
            set
            {
                this.cmtField = value;
            }
        }

        /// <summary>
        /// User description of track.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("desc")]
        public string Description
        {
            get
            {
                return this.descField;
            }
            set
            {
                this.descField = value;
            }
        }

        /// <summary>
        /// Source of data. Included to give user some idea of reliability and accuracy of data.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("src")]
        public string Source
        {
            get
            {
                return this.srcField;
            }
            set
            {
                this.srcField = value;
            }
        }

        /// <summary>
        /// Links to external information about track.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("link")]
        public List<Link> Link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <summary>
        /// GPS track number.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger", ElementName="number")]
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <summary>
        /// Type (classification) of track.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public string Classification
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <summary>
        /// You can add extend GPX by adding your own elements from another schema here.
        /// </summary>
        public Extensions extensions
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
        /// A Track Segment holds a list of Track Points which are logically connected in order.
        /// </summary>
        /// <remarks>To represent a single GPS track where GPS reception was lost, or the GPS receiver was turned off, start a new Track Segment for each continuous span of track data.</remarks>
        /// <example>A more modern use of this element may be for the representation of river branches or the creation of trail networks.</example>
        [System.Xml.Serialization.XmlElementAttribute("trkseg")]
        public List<TrackSegment> TrackSegments
        {
            get
            {
                return this.trksegField;
            }
            set
            {
                this.trksegField = value;
            }
        }
        /// <summary>
        /// Debbie: get all the waypoints from the track.
        /// </summary>
        /// <returns>list of waypoints</returns>
        public List<WayPoint> ToWayPoints()
        {
            List<WayPoint> points = new List<WayPoint>();
            foreach (TrackSegment seg in trksegField)
            {
                points.AddRange(seg.WayPoints);
            }
            return points;
        }

        public Track(Gpx.GpxTrack oldtrk)
        {
            Comment = oldtrk.Comment;
            Description = oldtrk.Description;
            Name = oldtrk.Name;
            number = oldtrk.Number.ToString();
            srcField = oldtrk.Source;
            TrackSegments = new List<TrackSegment>();
            foreach (Gpx.GpxTrackSegment oldseg in oldtrk.Segments)
            {
                TrackSegment seg = new TrackSegment();
                foreach (Gpx.GpxPoint pt in oldseg.TrackPoints)
                {
                    seg.WayPoints.Add(new WayPoint(pt));
                }
                TrackSegments.Add(seg);
            }
        }
        #region Extensions
        private BoundsEx _boundsField;
        [System.Xml.Serialization.XmlIgnore()]
        public BoundsEx TrackBounds
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
            _boundsField = trksegField[0].TrackBounds;
            for (int i = 1; i < trksegField.Count; i++)
            {
                BoundsEx bounds = trksegField[i].TrackBounds;
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

        private double _TrackLength;
        public double GetTrackLength()
        {
            return _TrackLength;
        }

        private double _MaximumSpeed;
        public double GetMaximumSpeed()
        {
            return _MaximumSpeed;
        }

        private TimeSpan _Duration;
        public TimeSpan GetDuration()
        {
            return _Duration;
        }
        
        public void Recalculate()
        {
            _TrackLength = 0;
            _MaximumSpeed = 0;
            _Duration = new TimeSpan(0);
            _boundsField = null;

            foreach (TrackSegment seg in trksegField)
            {
                seg.Recalculate();
                _TrackLength += seg.GetSegmentLength();
                _Duration += seg.GetDuration();
                if (_MaximumSpeed < seg.GetMaximumSpeed())
                    _MaximumSpeed = seg.GetMaximumSpeed();

            }
        }

        public static Track FromRoute(Route route)
        {
            Track retVal = new Track();
            retVal.Classification = route.Classification;
            retVal.Comment = route.Comment;
            retVal.Description = route.Description;
            retVal.Link = route.Link;
            retVal.Name = route.Name;
            retVal.number = route.Number;
            retVal.Source = route.src;

            retVal.TrackSegments = new List<TrackSegment>();
            TrackSegment segment = new TrackSegment();
            segment.WayPoints = new List<WayPoint>();
            foreach (WayPoint wp in route.rtept)
            {
                segment.WayPoints.Add(wp);
            }
            retVal.TrackSegments.Add(segment);
            return retVal;
        }
        #endregion Extensions
    }
}
