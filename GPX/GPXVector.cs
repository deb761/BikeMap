using System;
using System.Collections.Generic;
using System.Text;

namespace GPX
{
    public class GPXVector
    {
        private double _DeltaLatitude;
        /// <summary>
        /// Change of Latitude in Northern direction (in degrees)
        /// </summary>
        public double DeltaLatitude
        {
            get { return _DeltaLatitude; }
            set { _DeltaLatitude = value; }
        }

        private double _DeltaLongitude;
        /// <summary>
        /// Change of Longitude in Eastern direction (in degrees)
        /// </summary>
        public double DeltaLongitude
        {
            get { return _DeltaLongitude; }
            set { _DeltaLongitude = value; }
        }

        private double _DeltaElevation;
        /// <summary>
        /// Change in Elevation in upwards direction (in meters)
        /// </summary>
        public double DeltaElevation
        {
            get { return _DeltaElevation; }
            set { _DeltaElevation = value; }
        }

        public GPXVector()
        {
            _DeltaElevation = 0;
            _DeltaLatitude = 0;
            _DeltaLongitude = 0;
        }

        public GPXVector(double deltaLatitude, double deltaLongitude, double deltaElevation)
        {
            _DeltaElevation = deltaElevation;
            _DeltaLatitude = deltaLatitude;
            _DeltaLongitude = deltaLongitude;
        }

        public static GPXVector operator +(GPXVector g1, GPXVector g2)
        {
            double ele = g1._DeltaElevation + g2._DeltaElevation;
            double lat = g1._DeltaLatitude + g2._DeltaLatitude;
            double lon = g1._DeltaLongitude + g2._DeltaLongitude;
            return new GPXVector(lat, lon, ele);
        }

        public static GPXVector operator -(GPXVector g1, GPXVector g2)
        {
            double ele = g1._DeltaElevation - g2._DeltaElevation;
            double lat = g1._DeltaLatitude - g2._DeltaLatitude;
            double lon = g1._DeltaLongitude - g2._DeltaLongitude;
            return new GPXVector(lat, lon, ele);
        }

        public static GPXVector operator *(GPXVector g1, double d)
        {
            double ele = g1._DeltaElevation * d;
            double lat = g1._DeltaLatitude * d;
            double lon = g1._DeltaLongitude * d;
            return new GPXVector(lat, lon, ele);
        }

        public static GPXVector operator /(GPXVector g1, double d)
        {
            double ele = g1._DeltaElevation / d;
            double lat = g1._DeltaLatitude / d;
            double lon = g1._DeltaLongitude / d;
            return new GPXVector(lat, lon, ele);
        }

        /// <summary>
        /// Returns the length of the vector in meter.
        /// </summary>
        public double GetLength(Decimal latitude)
        {
            return Math.Sqrt(_DeltaElevation * _DeltaElevation + _DeltaLatitude * _DeltaLatitude * GPXUtils.KmPerDegree * GPXUtils.KmPerDegree * 1000000.0 + _DeltaLongitude * _DeltaLongitude * Math.Pow(GPXUtils.KmPerDegreeAtLatitude(latitude), 2) * 1000000.0);
            //you can ignore elevation - since elevation measurements are generally low quality, it's even better to ignore that
            //return Math.Sqrt(_DeltaLatitude * _DeltaLatitude * GPXUtils.KmPerDegree * GPXUtils.KmPerDegree * 1000000.0 + _DeltaLongitude * _DeltaLongitude * Math.Pow(GPXUtils.KmPerDegreeAtLatitude(latitude), 2) * 1000000.0);
        }
    }
}
