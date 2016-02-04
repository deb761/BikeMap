using System;
using System.Xml.Serialization;
using System.Xml;

namespace GPX
{
    /// <summary>
    ///This represents a waypoint, point of interest, or named feature on a map.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/1")]
    public class WayPoint
    {
        #region Variables
        private decimal eleField;
        private bool eleFieldSpecified;
        private const int _EleDecimals = 2;

        private System.DateTime timeField;

        private bool timeFieldSpecified;

        private decimal magvarField;

        private bool magvarFieldSpecified;

        private decimal geoidheightField;

        private bool geoidheightFieldSpecified;

        private string nameField;

        private string cmtField;

        private string descField;

        private string srcField;

        private Link[] linkField;

        private string symField;

        private string typeField;

        private Fix fixField;

        private bool fixFieldSpecified;

        private string satField;

        private decimal hdopField;

        private bool hdopFieldSpecified;

        private decimal vdopField;

        private bool vdopFieldSpecified;

        private decimal pdopField;

        private bool pdopFieldSpecified;

        private decimal ageofdgpsdataField;

        private bool ageofdgpsdataFieldSpecified;

        private string dgpsidField;

        private Extensions extensionsField;

        private decimal latField;
        private decimal lonField;
        private int _LatLonDecimals = 6;
        #endregion Variables

        public WayPoint() { }
        /// <summary>
        /// Elevation (in meters) of the point.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ele")]
        public decimal Elevation
        {
            get
            {
                return this.eleField;
            }
            set
            {
                this.eleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool eleSpecified
        {
            get
            {
                return this.eleFieldSpecified;
            }
            set
            {
                this.eleFieldSpecified = value;
            }
        }

        /// <summary>
        /// Creation/modification timestamp for element.
        /// </summary>
        /// <remarks>Date and time in are in Univeral Coordinated Time (UTC), not local time! Conforms to ISO 8601 specification for date/time representation. Fractional seconds are allowed for millisecond timing in tracklogs.</remarks>
        [System.Xml.Serialization.XmlElementAttribute("time")]
        public System.DateTime Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool timeSpecified
        {
            get
            {
                return this.timeFieldSpecified;
            }
            set
            {
                this.timeFieldSpecified = value;
            }
        }

        /// <summary>
        /// Magnetic variation (in degrees) at the point.
        /// </summary>
        /// <remarks>For writing the XML file, magvar property is used.</remarks>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public decimal MagneticVariation
        {
            get
            {
                return this.magvarField;
            }
            set
            {
                this.magvarField = value;
            }
        }

        /// <summary>
        /// Is MagneticVariation property.
        /// </summary>
        public decimal magvar
        {
            get
            {
                return this.magvarField;
            }
            set
            {
                this.magvarField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool magvarSpecified
        {
            get
            {
                return this.magvarFieldSpecified;
            }
            set
            {
                this.magvarFieldSpecified = value;
            }
        }

        /// <summary>
        /// Height (in meters) of geoid (mean sea level) above WGS84 earth ellipsoid. As defined in NMEA GGA message.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("geoidheight")]
        public decimal geoidheight
        {
            get
            {
                return this.geoidheightField;
            }
            set
            {
                this.geoidheightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool geoidheightSpecified
        {
            get
            {
                return this.geoidheightFieldSpecified;
            }
            set
            {
                this.geoidheightFieldSpecified = value;
            }
        }

        /// <summary>
        /// The GPS name of the waypoint.
        /// </summary>
        /// <remarks>This field will be transferred to and from the GPS. GPX does not place restrictions on the length of this field or the characters contained in it. It is up to the receiving application to validate the field before sending it to the GPS.</remarks>
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
        /// GPS waypoint comment. Sent to GPS as comment.
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
        /// A text description of the element. Holds additional information about the element intended for the user, not the GPS.
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
        /// <example>"Garmin eTrex", "USGS quad Boston North"</example>
        [System.Xml.Serialization.XmlElementAttribute("src")]
        public string SourceOfData
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
        /// Link to additional information about the waypoint.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("link")]
        public Link[] Link
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
        /// Text of GPS symbol name. For interchange with other programs, use the exact spelling of the symbol as displayed on the GPS. If the GPS abbreviates words, spell them out.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("sym")]
        public string Symbol
        {
            get
            {
                return this.symField;
            }
            set
            {
                this.symField = value;
            }
        }

        /// <summary>
        /// Type (classification) of the waypoint.
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
        /// Type of GPX fix.
        /// </summary>
        public Fix fix
        {
            get
            {
                return this.fixField;
            }
            set
            {
                this.fixField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fixSpecified
        {
            get
            {
                return this.fixFieldSpecified;
            }
            set
            {
                this.fixFieldSpecified = value;
            }
        }

        /// <summary>
        /// Number of satellites used to calculate the GPX fix.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "sat", DataType = "nonNegativeInteger")]
        public string NumberOfSatellites
        {
            get
            {
                return this.satField;
            }
            set
            {
                this.satField = value;
            }
        }

        /// <summary>
        /// Horizontal dilution of precision.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("hdop")]
        public decimal hdop
        {
            get
            {
                return this.hdopField;
            }
            set
            {
                this.hdopField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hdopSpecified
        {
            get
            {
                return this.hdopFieldSpecified;
            }
            set
            {
                this.hdopFieldSpecified = value;
            }
        }

        /// <summary>
        /// Vertical dilution of precision.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("vdop")]
        public decimal vdop
        {
            get
            {
                return this.vdopField;
            }
            set
            {
                this.vdopField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool vdopSpecified
        {
            get
            {
                return this.vdopFieldSpecified;
            }
            set
            {
                this.vdopFieldSpecified = value;
            }
        }

        /// <summary>
        /// Position dilution of precision.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("pdop")]
        public decimal pdop
        {
            get
            {
                return this.pdopField;
            }
            set
            {
                this.pdopField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pdopSpecified
        {
            get
            {
                return this.pdopFieldSpecified;
            }
            set
            {
                this.pdopFieldSpecified = value;
            }
        }

        /// <summary>
        /// Number of seconds since last DGPS update.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ageofdgpsdata")]
        public decimal ageofdgpsdata
        {
            get
            {
                return this.ageofdgpsdataField;
            }
            set
            {
                this.ageofdgpsdataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ageofdgpsdataSpecified
        {
            get
            {
                return this.ageofdgpsdataFieldSpecified;
            }
            set
            {
                this.ageofdgpsdataFieldSpecified = value;
            }
        }

        /// <summary>
        /// ID of DGPS station used in differential correction.
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "dgpsid", DataType = "integer")]
        public string dgpsid
        {
            get
            {
                return this.dgpsidField;
            }
            set
            {
                this.dgpsidField = value;
            }
        }

        /// <summary>
        /// You can add extend GPX by adding your own elements from another schema here.
        /// </summary>
        //[System.Xml.Serialization.XmlAttributeAttribute("extensions")]
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
        /// The latitude of the point. Decimal degrees, WGS84 datum.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("lat")]
        public decimal Latitude
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
                TransformCoordinates();
            }
        }

        /// <summary>
        /// The longitude of the point. Decimal degrees, WGS84 datum.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("lon")]
        public decimal Longitude
        {
            get
            {
                return this.lonField;
            }
            set
            {
                this.lonField = value;
                TransformCoordinates();
            }
        }

        private double _Temperature;
        [XmlIgnoreAttribute()]
        public double Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }

        private double _WaterTemperature;
        [XmlIgnoreAttribute()]
        public double WaterTemperature
        {
            get { return _WaterTemperature; }
            set { _WaterTemperature = value; }
        }

        private double _Depth;
        [XmlIgnoreAttribute()]
        public double Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }

        private int _Heartrate;
        [XmlIgnoreAttribute()]
        public int Heartreate
        {
            get { return _Heartrate; }
            set { _Heartrate = value; }
        }

        private int _Cadence;
        [XmlIgnoreAttribute()]
        public int Cadence
        {
            get { return _Cadence; }
            set { _Cadence = value; }
        }

        #region Extensions
        public void SetLongitudeLatitude(decimal longitude, decimal latitude)
        {
            this.lonField = longitude;
            this.latField = latitude;
            TransformCoordinates();
        }

        private double _LatitudeKm;
        private double _LongitudeKm;
        private void TransformCoordinates()
        {
            _LatitudeKm = GPXUtils.KmPerDegree * Convert.ToDouble(this.latField);
            _LongitudeKm = GPXUtils.KmPerDegreeAtLatitude(this.latField) * Convert.ToDouble(this.lonField);
        }

        /// <summary>
        /// Latitude converted to km.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public double LatitudeKm
        {
            get { return _LatitudeKm; }
        }
        //public double GetLatitudeKm()
        //{
        //    return GPXUtils.KmPerDegree * Convert.ToDouble(this.latField);
        //}

        /// <summary>
        /// Longitude converted to km.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public double LongitudeKm
        {
            get { return _LongitudeKm; }
        }
        //public double GetLongitudeKm()
        //{
        //    return GPXUtils.KmPerDegreeAtLatitude(this.latField) * Convert.ToDouble(this.lonField);
        //}

        private WayPoint _PreviousWaypoint;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public WayPoint PreviousWaypoint
        {
            get { return _PreviousWaypoint; }
            internal set { _PreviousWaypoint = value; }
        }

        private WayPoint _NextWaypoint;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public WayPoint NextWaypoint
        {
            get { return _NextWaypoint; }
            internal set { _NextWaypoint = value; }
        }

        private GPXVector _SpeedVector;
        /// <summary>
        /// Speed differentiated per direction
        /// </summary>
        public GPXVector GetSpeedVector()
        {
            return _SpeedVector * _SpeedUnitFactor;
        }

        private static double _SpeedUnitFactor = 1.0;
        public static double GetSpeedUnitFactor()
        {
            return _SpeedUnitFactor;
        }
        public static void SetSpeedUnitFactor(double value)
        {
            _SpeedUnitFactor = value;
        }

        private double _Speed;
        /// <summary>
        /// Speed in meter per second * unit factor
        /// </summary>
        public double GetSpeed()
        {
            return _Speed * _SpeedUnitFactor;
        }

        private GPXVector _DistanceVector;
        /// <summary>
        /// Distance from Previos WayPoint differntiated per direction
        /// </summary>
        public GPXVector GetDistanceVector()
        {
            return _DistanceVector;
        }

        private double _Distance;
        /// <summary>
        /// Absolute Distance from Previous WayPoint in meter.
        /// </summary>
        public double GetDistance()
        {
            return _Distance;
        }

        private GPXVector _DirectionVector;
        /// <summary>
        /// Indicates the direction from Previous WayPoint.
        /// </summary>
        /// <remarks>Caculated by dividing the <see cref="GetDistanceVector()">DistanceVector</see> by the <see cref="GetDistance()">Distance</see>.</remarks>
        public GPXVector GetDirectionVector()
        {
            return _DirectionVector;
        }

        /// <summary>
        /// Returns the change in direction at this WayPoint.
        /// </summary>
        /// <remarks>Calculated by Subtracting the <see cref="GetDirectionVector()">DirectionVector</see> of this WayPoint from the DirectionVector of the next WayPoint.</remarks>
        public GPXVector GetDirectionChange()
        {
            if ((_PreviousWaypoint == null) || (_NextWaypoint == null))
                return new GPXVector();
            else
                return _NextWaypoint.GetDirectionVector() - this.GetDirectionVector();
        }

        public double GetAscent()
        {
            if (_PreviousWaypoint == null)
                return 0.0;
            else
                return Convert.ToDouble(this.Elevation - _PreviousWaypoint.Elevation) / GetDistance();
        }

        /// <summary>
        /// Returns the Distance of two WayPoints (differentiated by direction).
        /// </summary>
        public static GPXVector operator -(WayPoint wp1, WayPoint wp2)
        {
            double deltaLat = Convert.ToDouble(wp1.latField - wp2.latField);
            double deltaLong = Convert.ToDouble(wp1.lonField - wp2.lonField);
            double deltaEle = 0;
            //if ((wp1.eleFieldSpecified)&&(wp2.eleFieldSpecified))
            deltaEle = Convert.ToDouble(wp1.eleField - wp2.eleField);
            return new GPXVector(deltaLat, deltaLong, deltaEle);
        }

        private GPXVector _DistanceFromStart;
        /// <summary>
        /// Returns the distance from the segment start differentiated by direction.
        /// </summary>
        public GPXVector GetDistanceFromStart()
        {
            return _DistanceFromStart;
        }

        public double GetDistanceFrom(WayPoint pt)
        {
            return (this - pt).GetLength(Latitude);
        }
        private TimeSpan _TimeSinceStart;
        /// <summary>
        /// Returns the time since segment start.
        /// </summary>
        public TimeSpan GetTimeSinceStart()
        {
            return _TimeSinceStart;
        }

        /// <summary>
        /// Returns the time since segment start in seconds.
        /// </summary>
        public double GetTimeSinceStartSeconds()
        {
            return _TimeSinceStart.Ticks / GPXUtils.TicksPerSecond;
        }

        private double _TrackDistanceFromStart;
        /// <summary>
        /// Returns the distance from start along the track.
        /// </summary>
        public double GetTrackDistanceFromStart()
        {
            return _TrackDistanceFromStart;
        }

        private int _Index;
        /// <summary>
        /// Index of the point in this track segment.
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public int Index
        {
            get { return _Index; }
            internal set { _Index = value; }
        }

        internal void RelateToStartPoint(ref WayPoint start) //, out GPXVector distanceVector, out double time)
        {
            _DistanceFromStart = this - start;
            _TimeSinceStart = this.Time.Subtract(start.Time);
        }

        internal void Recalculate()
        {
            TransformCoordinates();
            _SpeedVector = new GPXVector();
            _Speed = 0;
            _DirectionVector = new GPXVector();

            if (_PreviousWaypoint == null)
            {
                _DistanceVector = new GPXVector();
                _Distance = 0;
                _TrackDistanceFromStart = 0;
            }
            else
            {
                _DistanceVector = this - _PreviousWaypoint;
                _Distance = _DistanceVector.GetLength(this.latField);
                _TrackDistanceFromStart = _PreviousWaypoint.GetTrackDistanceFromStart() + _Distance;

                if (_Distance > 0.01)
                    _DirectionVector = _DistanceVector / _Distance;
                else
                    _DirectionVector = new GPXVector();

                //if ((this.timeFieldSpecified) && (_PreviousWaypoint.timeFieldSpecified))
                //{
                TimeSpan ts = this.Time.Subtract(_PreviousWaypoint.Time);
                double timeDiff = ts.Ticks / 10000000;
                if (timeDiff != 0)
                {
                    _SpeedVector = _DistanceVector / timeDiff;
                    _Speed = _SpeedVector.GetLength(this.latField);
                }
                //}
            }
        }

        public void AdjustPoint(double deltaLongitude, double deltaLatitude, double deltaElevation)
        {
            eleField = Convert.ToDecimal(Math.Round(Convert.ToDouble(eleField) + deltaElevation, _EleDecimals));
            latField = Convert.ToDecimal(Math.Round(Convert.ToDouble(latField) + deltaLatitude, _LatLonDecimals));
            lonField = Convert.ToDecimal(Math.Round(Convert.ToDouble(lonField) + deltaLongitude, _LatLonDecimals));
            TransformCoordinates();
        }

        public void AdjustPoint(GPXVector vector)
        {
            AdjustPoint(vector.DeltaLongitude, vector.DeltaLatitude, vector.DeltaElevation);
        }

        public WayPoint (Gpx.GpxPoint pt)
        {
            ageofdgpsdata = (pt.AgeOfData != null) ? (decimal)pt.AgeOfData : 0;
            ageofdgpsdataSpecified = pt.AgeOfData != null;
            Comment = pt.Comment;
            Description = pt.Description;
            dgpsid = pt.DgpsId.ToString();
            Elevation = (pt.Elevation != null) ? (decimal)pt.Elevation : 0;
            fix = (pt.FixType != null) ? (Fix)Enum.Parse(typeof(Fix), pt.FixType) : Fix.none;
            geoidheight = (pt.GeoidHeight != null) ? (decimal)pt.GeoidHeight : 0;
            hdop = (pt.Hdop != null) ? (decimal)pt.Hdop : 0;
            Latitude = (decimal)pt.Latitude;
            Longitude = (decimal)pt.Longitude;
            MagneticVariation = (pt.MagneticVar != null) ? (decimal)pt.MagneticVar: 0;
            Name = pt.Name;
            pdop = (pt.Pdop != null) ? (decimal)pt.Pdop : 0;
            NumberOfSatellites = pt.Satelites.ToString();
            SourceOfData = pt.Source;
            Symbol = pt.Symbol;
            Time = (pt.Time != null) ? (DateTime)pt.Time : DateTime.Now;
            Classification = pt.Type;
        }

        public WayPoint Copy()
        {
            WayPoint retVal = new WayPoint();
            retVal.ageofdgpsdata = this.ageofdgpsdata;
            retVal.ageofdgpsdataSpecified = this.ageofdgpsdataSpecified;
            retVal.Comment = this.Comment;
            retVal.Description = this.descField;
            retVal.dgpsid = this.dgpsid;
            retVal.Elevation = this.eleField;
            retVal.fix = (Fix)this.fix;
            retVal.geoidheight = this.geoidheight;
            retVal.hdop = this.hdop;
            //retVal.Latitude = this.lat;
            //retVal.Longitude = this.lon;
            retVal.SetLongitudeLatitude(this.lonField, this.latField);
            retVal.MagneticVariation = this.magvar;
            retVal.Name = this.nameField;
            retVal.pdop = this.pdop;
            retVal.NumberOfSatellites = this.satField;
            retVal.SourceOfData = this.srcField;
            retVal.Symbol = this.symField;
            retVal.Time = this.timeField;
            retVal.Classification = this.typeField;
            return retVal;
        }
        #endregion Extensions

        internal void CleanupExtension()
        {
            if (this.extensions != null)
            {
                XmlElement[] any = this.extensions.Any;
                foreach (XmlElement element in any)
                {
                    try
                    {
                        XmlNode inner = element.FirstChild;

                        string name = inner.LocalName;
                        string val = inner.InnerText;

                        switch (name)
                        {
                            case "hr":
                                this.Heartreate = Convert.ToInt32(val);
                                break;
                            case "cad":
                                this.Cadence = Convert.ToInt32(val);
                                break;
                            case "atemp":
                                this.Temperature = Convert.ToDouble(val);
                                break;
                            case "wtemp":
                                this.WaterTemperature = Convert.ToDouble(val);
                                break;
                            case "depth":
                                this.Depth = Convert.ToDouble(val);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        //hmpf.
                    }
                }
            }
        }
    }
}
