using System;
using System.Collections.Generic;
using System.Text;

namespace GPX
{
    public class BoundsEx
    {
        private DateTime _StartTime;
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        
        private DateTime _EndTime;
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        
        private Decimal _ElevationMinimum;
        public Decimal ElevationMinimum
        {
            get { return _ElevationMinimum; }
            set { _ElevationMinimum = value; }
        }

        private Decimal _ElevationMaximum;
        public Decimal ElevationMaximum
        {
            get { return _ElevationMaximum; }
            set { _ElevationMaximum = value; }
        }

        private Degree _LatitudeMaximum;
        public Degree LatitudeMaximum
        {
            get { return _LatitudeMaximum; }
            set { _LatitudeMaximum = value; }
        }
        public void SetLatitudeMaximum(decimal value)
        {
            _LatitudeMaximum = new Degree((double)value, Direction.Latitude);
        }
        public void SetLatitudeMaximum(double value)
        {
            _LatitudeMaximum = new Degree(value, Direction.Latitude);
        }

        private Degree _LatitudeMinimum;
        public Degree LatitudeMinimum
        {
            get { return _LatitudeMinimum; }
            set { _LatitudeMinimum = value; }
        }
        public void SetLatitudeMinimum(decimal value)
        {
            _LatitudeMinimum = new Degree((double)value, Direction.Latitude);
        }
        public void SetLatitudeMinimum(double value)
        {
            _LatitudeMinimum = new Degree(value, Direction.Latitude);
        }

        private Degree _LongitudeMinimum;
        public Degree LongitudeMinimum
        {
            get { return _LongitudeMinimum; }
            set { _LongitudeMinimum = value; }
        }
        public void SetLongitudeMinimum(decimal value)
        {
            _LongitudeMinimum = new Degree((double)value, Direction.Longitude);
        }
        public void SetLongitudeMinimum(double value)
        {
            _LongitudeMinimum = new Degree(value, Direction.Longitude);
        }

        private Degree _LongitudeMaximum;
        public Degree LongitudeMaximum
        {
            get { return _LongitudeMaximum; }
            set { _LongitudeMaximum = value; }
        }
        public void SetLongitudeMaximum(decimal value)
        {
            _LongitudeMaximum = new Degree((double)value, Direction.Longitude);
        }
        public void SetLongitudeMaximum(double value)
        {
            _LongitudeMaximum = new Degree(value, Direction.Longitude);
        }

        //private Double _LatitudeKmMaximum;
        public double GetLatitudeKmMaximum()
        {
            double retVal = Convert.ToDouble(_LatitudeMaximum) * GPXUtils.KmPerDegree;
            return retVal;
        }
        //private Double _LatitudeKmMinimum;
        public double GetLatitudeKmMinimum()
        {
            double retVal = Convert.ToDouble(_LatitudeMinimum) * GPXUtils.KmPerDegree;
            return retVal;
        }
        //private Double _LongitudeKmMinimum;
        //not really exact...
        public double GetLongitudeKmMaximum()
        {
            double retVal;
            if ((_LatitudeMaximum > 0) && (_LatitudeMinimum > 0)) //north of the equator => minimum is closest
                retVal = Convert.ToDouble(_LongitudeMaximum) * GPXUtils.KmPerDegreeAtLatitude(_LatitudeMinimum);
            else if ((_LatitudeMaximum < 0) && (_LatitudeMinimum < 0)) //south of the equator => maximum is closest
                retVal = Convert.ToDouble(_LongitudeMaximum) * GPXUtils.KmPerDegreeAtLatitude(_LatitudeMaximum);
            else //on both sides of the equator => equatorial distance
                retVal = Convert.ToDouble(_LongitudeMaximum) * GPXUtils.KmPerDegree;
            return retVal;
        }
        //private Double _LongitudeKmMaximum;
        //not really exact...
        public double GetLongitudeKmMinimum()
        {
            double retVal;
            if ((_LatitudeMaximum > 0) && (_LatitudeMinimum > 0))
                retVal = Convert.ToDouble(_LongitudeMaximum) * GPXUtils.KmPerDegreeAtLatitude(_LatitudeMinimum);
            else if ((_LatitudeMaximum < 0) && (_LatitudeMinimum < 0)) //south of the equator => maximum is closest
                retVal = Convert.ToDouble(_LongitudeMaximum) * GPXUtils.KmPerDegreeAtLatitude(_LatitudeMaximum);
            else //on both sides of the equator => equatorial distance
                retVal = Convert.ToDouble(_LongitudeMaximum) * GPXUtils.KmPerDegree;
            return retVal;
        }

        public double GetLatitudeDistance()
        {
            double retVal = _LatitudeMaximum - _LatitudeMinimum;
            return retVal;
        }

        public double GetLatitudeKmDistance()
        {
            //double retVal = GetLatitudeKmMaximum() - GetLatitudeKmMinimum();
            double retVal = GetLatitudeDistance() * GPXUtils.KmPerDegree;
            return retVal;
        }

        public double GetLongitudeDistance()
        {
            double retVal = _LongitudeMaximum - _LongitudeMinimum;
            return retVal;
        }

        public double GetLongitudeKmDistance()
        {
            //double retVal = GetLongitudeKmMaximum() - GetLongitudeKmMinimum();
            double retVal = GetLongitudeDistance();
            if ((_LatitudeMaximum > 0) && (_LatitudeMinimum > 0)) //north of the equator => minimum is closest
                retVal *= GPXUtils.KmPerDegreeAtLatitude(_LatitudeMinimum);
            else if ((_LatitudeMaximum < 0) && (_LatitudeMinimum < 0)) //south of the equator => maximum is closest
                retVal *= GPXUtils.KmPerDegreeAtLatitude(_LatitudeMaximum);
            else //on both sides of the equator => equatorial distance
                retVal *= GPXUtils.KmPerDegree;

            return retVal;
        }

        public TimeSpan GetTimeSpan()
        {
            return new TimeSpan(_EndTime.Ticks - StartTime.Ticks);
        }

        public double GetElevationDifference()
        {
            double retVal = Convert.ToDouble(_ElevationMaximum) - Convert.ToDouble(_ElevationMinimum);
            return retVal;
        }
    }
}
