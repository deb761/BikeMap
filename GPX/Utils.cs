using System;

namespace GPX
{
    public class GPXUtils
    {
        public const long TicksPerSecond = 10000000;
        public const double KmPerDegree = 111.3195;
        //source: http://en.wikipedia.org/wiki/Earth_radius
        public const double EquatorialRadius = 6378.1370;
        public const double PolarRadius = 6356.7523;
        public static double RadiusAtLatitude(Decimal latitude)
        {
            Double lat = Convert.ToDouble(latitude) * Math.PI / 180;
            Double numerator = (EquatorialRadius * EquatorialRadius * Math.Cos(lat)) * (EquatorialRadius * EquatorialRadius * Math.Cos(lat)) + (PolarRadius * PolarRadius * Math.Sin(lat)) * (PolarRadius * PolarRadius * Math.Sin(lat));
            Double denominator = (EquatorialRadius * Math.Cos(lat)) * (EquatorialRadius * Math.Cos(lat)) + (PolarRadius * Math.Sin(lat)) * (PolarRadius * Math.Sin(lat));
            Double retVal = Math.Sqrt(numerator / denominator);
            return retVal;
        }

        public static double KmPerDegreeAtLatitude(Decimal latitude)
        {
            double cos = Math.Cos(Convert.ToDouble(latitude) * Math.PI / 180.0);
            //double kmPerDegree = RadiusAtLatitude(latitude) * Math.PI / 180;
            double retVal = KmPerDegree * cos;
            return retVal;
        }

        public static double KmPerDegreeAtLatitude(Degree latitude)
        {
            double cos = Math.Cos(latitude * Math.PI / 180.0);
            //double kmPerDegree = RadiusAtLatitude(latitude) * Math.PI / 180;
            double retVal = KmPerDegree * cos;
            return retVal;
        }
    }
}