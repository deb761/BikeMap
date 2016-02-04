using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GPX
{
    /// <summary>
    /// A Track Segment holds a list of Track Points which are logically connected in order.
    /// </summary>
    /// <remarks>To represent a single GPS track where GPS reception was lost, or the GPS receiver was turned off, start a new Track Segment for each continuous span of track data.</remarks>
    /// <example>May be used for e.g. river branches or the creation of trail networks.</example>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class TrackSegment
    {
        #region Variables and Properties
        //private WayPoint[] trkptField;
        private List<WayPoint> trkptField;

        private Extensions extensionsField;
        /// <summary>
        /// A list of track points.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("trkpt")]
        public List<WayPoint> WayPoints
        {
            get
            {
                return this.trkptField;
            }
            set
            {
                this.trkptField = value;
            }
        }

        private bool _Updating;
        #endregion Variables and Properties

        public TrackSegment()
        {
            WayPoints = new List<WayPoint>();
        }
        public TrackSegment(bool createWaypointsList)
        {
            if (createWaypointsList)
                trkptField = new List<WayPoint>();
        }

        /// <summary>
        /// You add extend GPX by adding your own elements from another schema here.
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
            _boundsField = new BoundsEx();
            WayPoint wpt = trkptField[0];
            _boundsField.ElevationMaximum = _boundsField.ElevationMinimum = wpt.Elevation;
            _boundsField.EndTime = _boundsField.StartTime = wpt.Time;
            _boundsField.SetLatitudeMaximum(wpt.Latitude);
            _boundsField.SetLatitudeMinimum(wpt.Latitude);
            _boundsField.SetLongitudeMaximum(wpt.Longitude);
            _boundsField.SetLongitudeMinimum(wpt.Longitude);

            for (int i = 1; i < trkptField.Count; i++)
            {
                wpt = trkptField[i];
                if (_boundsField.ElevationMaximum < wpt.Elevation)
                    _boundsField.ElevationMaximum = wpt.Elevation;
                if (_boundsField.ElevationMinimum > wpt.Elevation)
                    _boundsField.ElevationMinimum = wpt.Elevation;
                if (_boundsField.EndTime < wpt.Time)
                    _boundsField.EndTime = wpt.Time;
                if (_boundsField.LatitudeMaximum < wpt.Latitude)
                    _boundsField.SetLatitudeMaximum(wpt.Latitude);
                if (_boundsField.LatitudeMinimum > wpt.Latitude)
                    _boundsField.SetLatitudeMinimum(wpt.Latitude);
                if (_boundsField.LongitudeMaximum < wpt.Longitude)
                    _boundsField.SetLongitudeMaximum(wpt.Longitude);
                if (_boundsField.LongitudeMinimum > wpt.Longitude)
                    _boundsField.SetLongitudeMinimum(wpt.Longitude);
                if (_boundsField.StartTime > wpt.Time)
                    _boundsField.StartTime = wpt.Time;
            }
        }

        private WayPoint _FirstWayPoint;
        public WayPoint FirstWayPoint
        {
            get { return _FirstWayPoint; }
        }
        private WayPoint _LastWayPoint;
        public WayPoint LastWayPoint
        {
            get { return _LastWayPoint; }
        }

        /// <summary>
        /// Connect the WayPoints to their neighbours.
        /// </summary>
        public void ConnectWayPoints()
        {
            if (trkptField.Count > 0)
                _FirstWayPoint = trkptField[0];
            else
            {
                _FirstWayPoint = null;
                _LastWayPoint = null;
            }

            int index = 0;
            WayPoint previousWayPoint = null;
            foreach (WayPoint wp in trkptField)
            {
                index++;
                wp.Index = index;
                wp.PreviousWaypoint = previousWayPoint;
                if (previousWayPoint != null)
                    previousWayPoint.NextWaypoint = wp;
                wp.NextWaypoint = null;
                previousWayPoint = wp;
                _LastWayPoint = wp;
            }
        }

        public void CreateListFromPoints()
        {
            List<WayPoint> points = new List<WayPoint>();
            WayPoint point = _FirstWayPoint;
            while (point != null)
            {
                points.Add(point);
                point = point.NextWaypoint;
            }
            trkptField = points;
        }

        private double _SegmentLength;
        public double GetSegmentLength()
        {
            return _SegmentLength;
        }

        private double _MaximumSpeed;
        public double GetMaximumSpeed()
        {
            return _MaximumSpeed;
        }

        private double _TotalAscent;
        /// <summary>
        /// Total ascent in meters
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public double TotalAscent
        {
            get { return _TotalAscent; }
        }

        private double _TotalDescent;
        /// <summary>
        /// Total descent in meters
        /// </summary>
        [System.Xml.Serialization.XmlIgnore()]
        public double TotalDescent
        {
            get { return _TotalDescent; }
        }
        

        /// <summary>
        /// Returns the duration of the segment.
        /// </summary>
        public TimeSpan GetDuration()
        {
            if ((_LastWayPoint != null) /*&& (_LastWayPoint.timeSpecified)*/
                && (_FirstWayPoint != null) /*&& (_FirstWayPoint.timeSpecified)*/)
                return _LastWayPoint.Time.Subtract(_FirstWayPoint.Time);
            else
                return new TimeSpan(0);
        }

        public WayPoint GetWayPointByIndex(int index)
        {
            WayPoint retVal = null;
            foreach (WayPoint wp in trkptField)
            {
                if (wp.Index == index)
                {
                    retVal = wp;
                    break;
                }
            }
            return retVal;
        }

        ///// <summary>
        ///// Returns the duration of the segment in seconds.
        ///// </summary>
        //public int GetDurationSeconds()
        //{
        //    if ((_LastWayPoint != null) /*&& (_LastWayPoint.timeSpecified)*/
        //        && (_FirstWayPoint != null) /*&& (_FirstWayPoint.timeSpecified)*/)
        //    {
        //        TimeSpan ts =_LastWayPoint.Time.Subtract(_FirstWayPoint.Time);
        //        return Convert.ToInt32(ts.Ticks / Utils.TicksPerSecond);
        //    }
        //    else
        //        return 0;
        //}

        public void Recalculate()
        {
            bool throwTimeTravelException = false;
            string setting = System.Configuration.ConfigurationManager.AppSettings["ThrowTimeTravelException"];
            bool.TryParse(setting, out throwTimeTravelException);

            _boundsField = null;
            ConnectWayPoints();

            _SegmentLength = 0;
            _MaximumSpeed = 0;
            _TotalAscent = 0;
            _TotalDescent = 0;
            //helper for ascent and descent
            decimal eMax = _FirstWayPoint.Elevation;
            decimal eMin = _FirstWayPoint.Elevation;
            decimal eLast = _FirstWayPoint.Elevation;
            decimal threashold = 2.5M;
            DateTime lastDateTime = _FirstWayPoint.Time;

            foreach (WayPoint wp in trkptField)
            {
                wp.Recalculate();
                wp.RelateToStartPoint(ref _FirstWayPoint);
                _SegmentLength += wp.GetDistance();
                if (_MaximumSpeed < wp.GetSpeed())
                    _MaximumSpeed = wp.GetSpeed();

                if (eLast > wp.Elevation + threashold)
                {
                    _TotalDescent = _TotalDescent + Convert.ToDouble(eLast - wp.Elevation);
                    eLast = wp.Elevation;
                }
                else if (eLast < wp.Elevation - threashold)
                {
                    _TotalAscent = _TotalAscent + Convert.ToDouble(wp.Elevation - eLast);
                    eLast = wp.Elevation;
                }

                if (throwTimeTravelException && (wp.Time < lastDateTime))
                {
                    throw new ApplicationException(string.Format("You are a time traveller, aren't you?\r\n{0}>{1}", lastDateTime, wp.Time));
                }
                lastDateTime = wp.Time;
            }
        }

        public void BeginUpdate()
        {
            _Updating = true;
        }

        public void EndUpdate()
        {
            CreateListFromPoints();
            Recalculate();
            _Updating = false;
        }

        public void DeleteWaypoint(WayPoint wp)
        {
            if (wp.PreviousWaypoint != null)
                wp.PreviousWaypoint.NextWaypoint = wp.NextWaypoint;
            else
                _FirstWayPoint = wp.NextWaypoint;

            if (wp.NextWaypoint != null)
                wp.NextWaypoint.PreviousWaypoint = wp.PreviousWaypoint;
            else
                _LastWayPoint = wp.PreviousWaypoint;

            if (!_Updating)
                CreateListFromPoints();
        }

        public TrackSegment Compress(double neighbourDistance, double lineDistance, double angle)
        {
            TrackSegment retVal = new TrackSegment(true);
            TrackSegment original = this;

            double neighbourDistanceSquare = neighbourDistance * neighbourDistance;
            double lineDistanceSquare = lineDistance * lineDistance;
            double angleRad = angle * Math.PI / 180.0;
            double angleSine = Math.Sin(angleRad);
            double angleSineSquare = angleSine * angleSine;

            int numRemoved = 0;
            do
            {
                numRemoved = 0;
                bool previousDeleted = false;
                foreach (WayPoint wp in original.WayPoints)
                {
                    WayPoint previous = wp.PreviousWaypoint;
                    if (previousDeleted)
                    {
                        previousDeleted = false;
                        //skip this point and 
                        //add it to the new track segment
                        WayPoint copy = wp.Copy();
                        retVal.WayPoints.Add(copy);
                        continue; 
                    }
                    if (CanDelete(wp, previous, neighbourDistanceSquare, lineDistanceSquare, angleSineSquare))
                    {
                        previousDeleted = true;
                        numRemoved++;
                    }
                    else
                    {
                        previousDeleted = false;
                        //add to the new track segment
                        WayPoint copy = wp.Copy();
                        retVal.WayPoints.Add(copy);
                    }
                }
                if (numRemoved > 0)
                {
                    original = retVal;
                    original.Recalculate();
                    retVal = new TrackSegment(true);
                }
            }
            while (numRemoved > 0);
            return retVal;
        }

        private bool CanDelete(WayPoint wp, WayPoint previous, double neighbourDistanceSquare, double lineDistanceSquare, double angleSineSquare)
        {
            //we cannot delete the first or last point
            if (previous == null)
                return false;
            if (wp.NextWaypoint == null)
                return false;

            //calculate distances (actually their squares)
            double distancePreviousThis = 1000000* (wp.LatitudeKm - previous.LatitudeKm) * (wp.LatitudeKm - previous.LatitudeKm) + (wp.LongitudeKm - previous.LongitudeKm) * (wp.LongitudeKm - previous.LongitudeKm);
            double distancePreviousNext = 1000000 * (wp.NextWaypoint.LatitudeKm - previous.LatitudeKm) * (wp.NextWaypoint.LatitudeKm - previous.LatitudeKm) + (wp.NextWaypoint.LongitudeKm - previous.LongitudeKm) * (wp.NextWaypoint.LongitudeKm - previous.LongitudeKm);
            double distanceThisNext = 1000000 * (wp.LatitudeKm - wp.NextWaypoint.LatitudeKm) * (wp.LatitudeKm - wp.NextWaypoint.LatitudeKm) + (wp.LongitudeKm - wp.NextWaypoint.LongitudeKm) * (wp.LongitudeKm - wp.NextWaypoint.LongitudeKm);

            //if the point is close to a neighbor, remove it
            if (distancePreviousThis < neighbourDistanceSquare)
                return true;
            if (distanceThisNext < neighbourDistanceSquare)
                return true;

            //calculate distance of this point to the direct line from previous to next point (actually square)
            double distanceFromLine = 1000000 *( distancePreviousThis - (distancePreviousThis - distanceThisNext + distancePreviousNext) * (distancePreviousThis - distanceThisNext + distancePreviousNext) / (4 * distancePreviousNext));

            //keep the point if the distance from line is bigger than a threshold
            if (distanceFromLine > lineDistanceSquare)
                return false;

            //keep the point if the angle at it is smaller than 90 degrees (easy to calculate, and removes problems in later steps)
            if (distancePreviousNext - distancePreviousThis - distanceThisNext < 0)
                return false;

            //calculate the angles at previos and next point (actually square of sine)
            double anglePrevious = distanceFromLine / distancePreviousThis;
            if (anglePrevious > angleSineSquare)
                return false;
            double angleNext = distanceFromLine / distanceThisNext;
            if (angleNext > angleSineSquare)
                return false;

            //in all other cases, we delete it
            return true;
        }
        #endregion Extensions
    }
}
