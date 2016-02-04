using System;
using System.ComponentModel;

namespace GPX
{
    public enum WaypointsStyle
    {
        [Description("Small circle")]
        SmallCircle,

        [Description("Big circle")]
        BigCircle,

        [Description("Small X")]
        SmallX,

        [Description("Big X")]
        BigX,

        [Description("Small +")]
        SmallPlus,

        [Description("Big +")]
        BigPlus,

        [Description("Small Square")]
        SmallSquare,

        [Description("Big Square")]
        BigSquare,
    }

    public enum DrawCategory
    {
        [Description("Time since Start (in s)")]
        Time,

        [Description("Distance from Start along the Track")]
        TrackDistanceFromStart,

        [Description("Elevation")]
        Elevation,

        [Description("Latitude (in degrees)")]
        Latitude,

        [Description("Latitude (converted to km)")]
        LatitudeKm,

        [Description("Longitude (in degrees)")]
        Longitude,

        [Description("Longitude (converted to km)")]
        LongitudeKm,

        [Description("Shortest Distance from Start")]
        DistanceFromStart,

        [Description("Speed ( absolute, in m/s)")]
        Speed,

        [Description("Vertical Speed (in m/s)")]
        SpeedvectorElevation,

        [Description("Speed in Northern Direction (in degress/s)")]
        SpeedvectorNorth,

        [Description("Speed in Eastern Direction (in degress/s)")]
        SpeedvectorEast,

        [Description("Direction, North")]
        DirectionNorth,

        [Description("Direction, East")]
        DirectionEast,

        [Description("Direction, Vertical")]
        DirectionVertical,

        [Description("% Ascent")]
        PercrentAscent,

        Heartrate,
        Cadence,
        Temperature,
        Depth,
        Watertemperature,
    }

}
