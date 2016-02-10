using BikeMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace GPX
{
    public partial class TrackControl : UserControl
    {
        #region Variables and Properties
        private GMap.NET.Internals.Core _Core;
        private DateTime _LastDrawTime;
        private bool _DrawPending;
        private Timer timer1;
        bool _UseOffset;
        private int _LeftOffset;
        private int _TopOffset;

        //for stupid Windows 7 (flickering of tooltips)
        private int _LastMouseX;
        private int _LastMouseY;

        private List<Track> _Tracks;
        public List<Track> Tracks
        {
            get { return _Tracks; }
            set
            {
                _Tracks = value;
                CreateWaypointsList();
            }
        }

        private List<WayPointOnMap> _PointsOfInterest;
        public void SetPointsOfInterest(List<WayPoint> inputList)
        {
            if (inputList == null)
            {
                _PointsOfInterest = null;
            }
            else
            {
                _PointsOfInterest = new List<WayPointOnMap>();
                foreach (WayPoint wp in inputList)
                {
                    _PointsOfInterest.Add(new WayPointOnMap(wp));
                }
            }
        }

        private DrawCategory _XCategory;
        public DrawCategory XCategory
        {
            get { return _XCategory; }
            set { _XCategory = value; }
        }

        private DrawCategory _YCategory;
        public DrawCategory YCategory
        {
            get { return _YCategory; }
            set { _YCategory = value; }
        }

        private bool _UseEqualScale;
        public bool UseEqualScale
        {
            get { return _UseEqualScale; }
            set { _UseEqualScale = value; }
        }

        private float _Zoom;
        public float Zoom
        {
            get { return _Zoom; }
            set { _Zoom = value; }
        }

        private bool _DrawWaypoints;
        public bool DrawWaypoints
        {
            get { return _DrawWaypoints; }
            set { _DrawWaypoints = value; }
        }

        private bool _DrawTrackLine;
        public bool DrawTrackLine
        {
            get { return _DrawTrackLine; }
            set { _DrawTrackLine = value; }
        }

        private WaypointsStyle _StyleForWaypoints;
        public WaypointsStyle StyleForWaypoints
        {
            get { return _StyleForWaypoints; }
            set { _StyleForWaypoints = value; }
        }

        private WaypointsStyle _StyleForPoI;
        public WaypointsStyle StyleForPoI
        {
            get { return _StyleForPoI; }
            set { _StyleForPoI = value; }
        }

        private bool _ShowAllPointsOfSegment;
        public bool ShowAllPointsOfSegment
        {
            get { return _ShowAllPointsOfSegment; }
            set { _ShowAllPointsOfSegment = value; }
        }

        private int _IndexOfFirstPointShown;
        public int IndexOfFirstPointShown
        {
            get { return _IndexOfFirstPointShown; }
            set { _IndexOfFirstPointShown = value; }
        }

        private int _IndexOfLastPointShown;
        public int IndexOfLastPointShown
        {
            get { return _IndexOfLastPointShown; }
            set { _IndexOfLastPointShown = value; }
        }

        private bool _ShowMap;
        public bool ShowMap
        {
            get { return _ShowMap; }
            set { _ShowMap = value; }
        }

        private GMap.NET.MapType _MapType;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GMap.NET.MapType MapType
        {
            get { return _MapType; }
            set { _MapType = value; }
        }

        private Color _WayPointsColor = Color.BlanchedAlmond;
        public Color WayPointsColor
        {
            get { return _WayPointsColor; }
            set { _WayPointsColor = value; }
        }

        private Color _WayPointsHighlight = Color.Gold;
        public Color WayPointsHighlight
        {
            get { return _WayPointsHighlight; }
            set { _WayPointsHighlight = value; }
        }

        private Color _PoIColor = Color.DarkGreen;
        public Color PoIColor
        {
            get { return _PoIColor; }
            set { _PoIColor = value; }
        }

        private Color _TrackColor = Color.Red;
        public Color TrackColor
        {
            get { return _TrackColor; }
            set { _TrackColor = value; }
        }

        private Color _TrackColorHighlight = Color.Goldenrod;
        public Color TrackColorHighlight
        {
            get { return _TrackColorHighlight; }
            set { _TrackColorHighlight = value; }
        }

        private float _TrackThickness = 3.0f;
        public float TrackThickness
        {
            get { return _TrackThickness; }
            set { _TrackThickness = value; }
        }

        private WayPointOnMap _SelectedWayPointOnMap;
        private List<WayPointOnMap> _SelectedWayPointsOnMap;
        private static Color _PhotoFrameColor = Color.Aqua;
        public static Color PhotoFrameColor
        {
            get { return _PhotoFrameColor; }
            set { _PhotoFrameColor = value; }
        }

        private static Color _PhotoFrameColorHighLight = Color.OrangeRed;
        public static Color PhotoFrameColorHighLight
        {
            get { return _PhotoFrameColorHighLight; }
            set { _PhotoFrameColorHighLight = value; }
        }

        private DateTime _CacheDate;
        public DateTime CacheDate
        {
            get { return _CacheDate; }
            set { _CacheDate = value; }
        }

        private List<WayPointOnMap> _WayPointsOnMap;
        private int _LeftMargin = 40;
        private int _LowerMargin = 12;
        private int _TopMargin = 5;
        private Bitmap _Bitmap;

        private Point _SelectionStart;
        private Point _SelectionEnd;
        private bool _Selecting;

        private double _XMax;
        private double _YMax;
        private double _XMin;
        private double _YMin;
        private double _XFactor;
        private double _YFactor;

        private bool _DrawPointsOfInterest;
        public bool DrawPointsOfInterest
        {
            get { return _DrawPointsOfInterest; }
            set { _DrawPointsOfInterest = value; }
        }

        #endregion Variables and Properties

        #region Events
        public delegate void WayPointSelectedEventHandler(object sender, WayPointSelectedEventArgs wpArgs);
        public event WayPointSelectedEventHandler WayPointSelected;
        #endregion Events

        private System.Resources.ResourceManager ResourceManager
        {
            get { return GPXAppResourceManager.ResourceManager; }
        }

        public TrackControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            _Bitmap = null;
            _Zoom = 1;
            _XCategory = DrawCategory.LongitudeKm;
            _YCategory = DrawCategory.LatitudeKm;
            _UseEqualScale = false;
            _Selecting = false;
            _DrawWaypoints = false;
            _DrawTrackLine = false;
            _ShowAllPointsOfSegment = true;
            _IndexOfFirstPointShown = 1;
            _IndexOfLastPointShown = 100000;

            //For maps
            {
                timer1 = new Timer(this.components);
                timer1.Interval = 2500;
                timer1.Tick += new System.EventHandler(this.timer1_Tick);

                GMap.NET.CacheProviders.FilePureImageCache imageCache = new GMap.NET.CacheProviders.FilePureImageCache();
                string cacheLocation = Defaults.GMapsFileCacheLocation;
                imageCache.CacheLocation = cacheLocation;
                GMap.NET.Internals.Cache.Instance.ImageCache = imageCache;

                GMap.NET.GMaps.Instance.ImageProxy = new GMap.NET.WindowsForms.WindowsFormsImageProxy();
                GMap.NET.GMaps.Instance.UseGeocoderCache = true;
                GMap.NET.GMaps.Instance.UseMemoryCache = true;
                GMap.NET.GMaps.Instance.UsePlacemarkCache = true;

                _Core = GMap.NET.Internals.Core.Instance;
                _Core.MapType = GMap.NET.MapType.GoogleSatellite;
                _Core.Projection = new GMap.NET.Projections.MercatorProjection();

                _Core.OnNeedInvalidation += new GMap.NET.NeedInvalidation(Core_OnNeedInvalidation);
                _Core.StartSystem();
            }
        }
        private List<TrackOnMap> _TracksOnMap;
        private void CreateWaypointsList()
        {
            if (_Tracks == null)
            {
                _WayPointsOnMap = null;
                _TracksOnMap = null;
            }
            else
            {
                _WayPointsOnMap = new List<WayPointOnMap>();
                _TracksOnMap = new List<TrackOnMap>();
                foreach (Track track in _Tracks)
                {
                    TrackOnMap tom = new TrackOnMap();
                    _TracksOnMap.Add(tom);
                    foreach (TrackSegment seg in track.TrackSegments)
                    {
                        foreach (WayPoint wp in seg.WayPoints)
                        {
                            WayPointOnMap wop = new WayPointOnMap(wp);
                            _WayPointsOnMap.Add(wop);
                            tom.WayPoints.Add(wop);
                        }
                    }
                }
            }
        }

        public void Draw()
        {
            if ((_Tracks == null) || (_Tracks.Count == 0))
            {
                //GPX_TrackControl_Draw0=The TrackSegment to be drawn was either not set or is empty.
                throw new ApplicationException(ResourceManager.GetString("GPX_TrackControl_Draw0"));
            }

            if ((_WayPointsOnMap == null) || (_TracksOnMap.Count != _Tracks.Count))
                CreateWaypointsList();

            //determine applicable values
            //get maximum and minimum for x and y values each
            _XMax = double.MinValue;
            _YMax = double.MinValue;
            _XMin = double.MaxValue;
            _YMin = double.MaxValue;

            foreach (WayPointOnMap wpm in _WayPointsOnMap)
            {
                //Selected value: latitude, longitude, elevation, time, what ever....
                wpm.XValue = GetSelectedValueFromWaypoint(wpm.WayPoint, _XCategory);
                wpm.YValue = GetSelectedValueFromWaypoint(wpm.WayPoint, _YCategory);
                _XMax = (_XMax < wpm.XValue) ? wpm.XValue : _XMax;
                _YMax = (_YMax < wpm.YValue) ? wpm.YValue : _YMax;
                _XMin = (_XMin > wpm.XValue) ? wpm.XValue : _XMin;
                _YMin = (_YMin > wpm.YValue) ? wpm.YValue : _YMin;
            }

            //get the size of control for drawing, reserve space for axes
            pnlImage.Width = Convert.ToInt32(this.ClientSize.Width * _Zoom);
            pnlImage.Height = Convert.ToInt32(this.ClientSize.Height * _Zoom);
            int drawWidth = pnlImage.Width - _LeftMargin - _TopMargin;
            int drawHeight = pnlImage.Height - _LowerMargin - _TopMargin;

            //now differentiate between external maps and internal graphs
            if (_ShowMap)
            {
                _UseOffset = true;
                _Core.BeginUpdate();
                GMap.NET.CacheProviders.FilePureImageCache.CacheDate = _CacheDate;

                //center: that's the center point for the _Core object
                GMap.NET.PointLatLng center = new GMap.NET.PointLatLng((_YMax + _YMin) / 2,
                     (_XMax + _XMin) / 2);
                _Core.CurrentPosition = center;
                _Core.MapType = _MapType;

                //top left and bottom right: for calculating zoom
                GMap.NET.PointLatLng topLeft = new GMap.NET.PointLatLng(_YMax, _XMin);
                GMap.NET.PointLatLng bottomRight = new GMap.NET.PointLatLng(_YMin, _XMax);

                //number of tiles fitting into the image
                int tilesX = drawWidth / _Core.Projection.TileSize.Width;
                int tilesY = drawHeight / _Core.Projection.TileSize.Height;

                //calculating zoom: when more tiles are required in one direction than fitting into the image
                //the zoom has been exceeded by 1.
                for (int zoomTmp = 0; zoomTmp <= 25; zoomTmp++)
                {
                    GMap.NET.Point pixelTopLeft = _Core.Projection.FromLatLngToPixel(topLeft, zoomTmp);
                    GMap.NET.Point tileTopLeft = _Core.Projection.FromPixelToTileXY(pixelTopLeft);
                    GMap.NET.Point pixelBottomRight = _Core.Projection.FromLatLngToPixel(bottomRight, zoomTmp);
                    GMap.NET.Point tileBottomRight = _Core.Projection.FromPixelToTileXY(pixelBottomRight);

                    if ((tileBottomRight.X - tileTopLeft.X > tilesX)
                        || (tileBottomRight.Y - tileTopLeft.Y > tilesY))
                    {
                        _Core.Zoom = zoomTmp - 1;
                        break;
                    }
                }
                //set size
                _Core.OnMapSizeChanged(drawWidth - _Core.Projection.TileSize.Width,
                    drawHeight - _Core.Projection.TileSize.Height);
                //get the MAP images
                _Core.EndUpdate();

            }
            else
            {
                _UseOffset = false;
                DetermineOffset(); //sets offset values to 0

                //scale for internal representation
                _XFactor = (_XMax - _XMin) / drawWidth;
                _YFactor = (_YMax - _YMin) / drawHeight;
                if (_UseEqualScale)
                {
                    _XFactor = (_XFactor > _YFactor) ? _XFactor : _YFactor;
                    _YFactor = _XFactor;
                }
            }

            //calculate position for each point
            foreach (WayPointOnMap wpm in _WayPointsOnMap)
            {
                if (!wpm.IsHidden)
                {
                    int xPixel, yPixel;
                    ValueToPixel((double)wpm.XValue, (double)wpm.YValue, out xPixel, out yPixel);
                    wpm.XPixels = xPixel;
                    wpm.YPixels = yPixel;
                }
                else
                {
                    wpm.XPixels = -1;
                    wpm.YPixels = -1;
                }
            }

            //Points of Interest
            foreach (WayPointOnMap poi in _PointsOfInterest)
            {
                //Selected value: latitude, longitude, elevation, time, what ever....
                poi.XValue = GetSelectedValueFromWaypoint(poi.WayPoint, _XCategory);
                poi.YValue = GetSelectedValueFromWaypoint(poi.WayPoint, _YCategory);
                int xPixel, yPixel;
                ValueToPixel((double)poi.XValue, (double)poi.YValue, out xPixel, out yPixel);
                poi.XPixels = xPixel;
                poi.YPixels = yPixel;
            }


            //and now draw it!
            _Bitmap = new Bitmap(pnlImage.Width, pnlImage.Height);

            DrawTracks();
            if (_ShowMap)
            {
                DrawGridForMap();
            }
            else
            {
                DrawGrid();
            }
            DrawPoI();

            _Bitmap.Save(Defaults.TrackControl_BitmapPath, System.Drawing.Imaging.ImageFormat.Bmp); //@"C:\temp\bitmap.bmp"
            this.Refresh();
        }

        private void DrawPoI()
        {
            if (_DrawPointsOfInterest)
            {
                Graphics graphics = Graphics.FromImage(_Bitmap);
                Pen pointsPen = new Pen(_PoIColor, _TrackThickness);

                foreach (WayPointOnMap wpm in _PointsOfInterest)
                {
                    Point point = new Point(wpm.XPixels, wpm.YPixels);
                    point.Offset(-_LeftOffset, -_TopOffset);

                    switch (_StyleForPoI)
                    {
                        case WaypointsStyle.SmallPlus:
                            graphics.DrawLine(pointsPen, point.X - 2, point.Y, point.X + 2, point.Y);
                            graphics.DrawLine(pointsPen, point.X, point.Y - 2, point.X, point.Y + 2);
                            break;
                        case WaypointsStyle.BigPlus:
                            graphics.DrawLine(pointsPen, point.X - 4, point.Y, point.X + 4, point.Y);
                            graphics.DrawLine(pointsPen, point.X, point.Y - 4, point.X, point.Y + 4);
                            break;
                        case WaypointsStyle.SmallCircle:
                            graphics.DrawEllipse(pointsPen, point.X - 2, point.Y - 2, 4, 4);
                            break;
                        case WaypointsStyle.BigCircle:
                            graphics.DrawEllipse(pointsPen, point.X - 4, point.Y - 4, 8, 8);
                            break;
                        case WaypointsStyle.SmallX:
                            graphics.DrawLine(pointsPen, point.X - 2, point.Y - 2, point.X + 2, point.Y + 2);
                            graphics.DrawLine(pointsPen, point.X - 2, point.Y + 2, point.X + 2, point.Y - 2);
                            break;
                        case WaypointsStyle.BigX:
                            graphics.DrawLine(pointsPen, point.X - 4, point.Y - 4, point.X + 4, point.Y + 4);
                            graphics.DrawLine(pointsPen, point.X - 4, point.Y + 4, point.X + 4, point.Y - 4);
                            break;
                        case WaypointsStyle.SmallSquare:
                            graphics.DrawRectangle(pointsPen, point.X - 2, point.Y - 2, 4, 4);
                            break;
                        case WaypointsStyle.BigSquare:
                            graphics.DrawRectangle(pointsPen, point.X - 4, point.Y - 4, 8, 8);
                            break;
                    }
                }
            }
        }

        private void DrawTracks()
        {
            Graphics graphics = Graphics.FromImage(_Bitmap);
            foreach (TrackOnMap tom in _TracksOnMap)
            {
                DrawTrack(graphics, tom);
            }
            graphics.Dispose();
        }

        private void DrawTrack(Graphics graphics, TrackOnMap track)
        {
            Point previous = new Point();
            Point nullPoint = new Point();
            foreach (WayPointOnMap wpm in track.WayPoints)
            {
                if (wpm.IsHidden)
                {
                    previous = nullPoint;
                }
                else
                {
                    Point p1;
                    if (previous != nullPoint)
                        p1 = previous;
                    else
                    {
                        p1 = new Point(wpm.XPixels, wpm.YPixels);
                        p1.Offset(-_LeftOffset, -_TopOffset);
                    }
                    Point p2 = new Point(wpm.XPixels, wpm.YPixels);
                    p2.Offset(-_LeftOffset, -_TopOffset);

                    DrawWaypoint(graphics, p2, p1, wpm.IsHighlighted);

                    previous = p2;
                }
            }
        }

        private void DrawWaypoint(Graphics graphics, Point point, Point previousPoint, bool highLighted)
        {
            Pen pen;
            Pen penStandard = new Pen(_TrackColor, _TrackThickness);
            Pen penHighlight = new Pen(_TrackColorHighlight, _TrackThickness);
            Pen pointsPen;
            Pen pointsPenStandard = new Pen(_WayPointsColor, _TrackThickness);
            Pen pointsPenHighlight = new Pen(_WayPointsHighlight, _TrackThickness);
            if (_DrawTrackLine)
            {
                pen = (highLighted) ? penHighlight : penStandard;
                graphics.DrawLine(pen, previousPoint, point);
            }
            if (_DrawWaypoints)
            {
                pointsPen = (highLighted) ? pointsPenHighlight : pointsPenStandard;
                switch (_StyleForWaypoints)
                {
                    case WaypointsStyle.SmallPlus:
                        graphics.DrawLine(pointsPen, point.X - 2, point.Y, point.X + 2, point.Y);
                        graphics.DrawLine(pointsPen, point.X, point.Y - 2, point.X, point.Y + 2);
                        break;
                    case WaypointsStyle.BigPlus:
                        graphics.DrawLine(pointsPen, point.X - 4, point.Y, point.X + 4, point.Y);
                        graphics.DrawLine(pointsPen, point.X, point.Y - 4, point.X, point.Y + 4);
                        break;
                    case WaypointsStyle.SmallCircle:
                        graphics.DrawEllipse(pointsPen, point.X - 2, point.Y - 2, 4, 4);
                        break;
                    case WaypointsStyle.BigCircle:
                        graphics.DrawEllipse(pointsPen, point.X - 4, point.Y - 4, 8, 8);
                        break;
                    case WaypointsStyle.SmallX:
                        graphics.DrawLine(pointsPen, point.X - 2, point.Y - 2, point.X + 2, point.Y + 2);
                        graphics.DrawLine(pointsPen, point.X - 2, point.Y + 2, point.X + 2, point.Y - 2);
                        break;
                    case WaypointsStyle.BigX:
                        graphics.DrawLine(pointsPen, point.X - 4, point.Y - 4, point.X + 4, point.Y + 4);
                        graphics.DrawLine(pointsPen, point.X - 4, point.Y + 4, point.X + 4, point.Y - 4);
                        break;
                    case WaypointsStyle.SmallSquare:
                        graphics.DrawRectangle(pointsPen, point.X - 2, point.Y - 2, 4, 4);
                        break;
                    case WaypointsStyle.BigSquare:
                        graphics.DrawRectangle(pointsPen, point.X - 4, point.Y - 4, 8, 8);
                        break;
                }
            }
        }

        public List<WayPoint> GetSelection()
        {
            List<WayPoint> retVal = new List<WayPoint>();
            if (_SelectedWayPointsOnMap != null)
            {
                foreach (WayPointOnMap wpm in _SelectedWayPointsOnMap)
                    retVal.Add(wpm.WayPoint);
            }
            return retVal;
        }

        private void DrawGrid()
        {
            Pen penLine = new Pen(Color.Wheat);
            Brush brushValue = Brushes.White;
            Font font = new Font("Arial", 8.0f);
            Graphics g = Graphics.FromImage(_Bitmap);

            //Y Axis
            double pot = 0.0;
            double dY = (_YMax - _YMin) / 10;
            int decimals = 0;
            int log = Convert.ToInt32(Math.Floor(Math.Log10(dY)));
            if (log >= 0)
            {
                pot = Convert.ToInt32(Math.Pow(10, log));
                decimals = 0;
            }
            else
            {
                pot = 1.0 / Math.Pow(10, -log);
                decimals = -log;
            }
            dY = pot * Math.Round(dY / pot, 0);
            double yStart = 0.0;
            if (Math.Abs(_YMin) > 0.0001)
            {
                yStart = Convert.ToInt32(_YMin / dY) * dY;
            }
            while (yStart <= _YMax)
            {
                int yPos = _TopMargin + Convert.ToInt32((_YMax - yStart) / _YFactor);
                g.DrawLine(penLine, 0, yPos, _Bitmap.Width, yPos);
                string str = yStart.ToString("F" + decimals.ToString());
                g.DrawString(str, font, brushValue, 0.0f, (float)yPos);
                yStart = Math.Round(yStart + dY, decimals);
            }

            //x axis
            double dX = (_XMax - _XMin) / 10;
            log = Convert.ToInt32(Math.Floor(Math.Log10(dX)));
            if (log >= 0)
            {
                pot = Convert.ToInt32(Math.Pow(10, log));
                decimals = 0;
            }
            else
            {
                pot = 1.0 / Math.Pow(10, -log);
                decimals = -log;
            }
            dX = pot * Math.Round(dX / pot, 0);
            double xStart = 0.0;
            if (Math.Abs(_XMin) > 0.0001)
            {
                xStart = Convert.ToInt32(_XMin / dX) * dX;
            }
            while (xStart <= _XMax)
            {
                int xPos = _LeftMargin + Convert.ToInt32((xStart - _XMin) / _XFactor);
                g.DrawLine(penLine, xPos, 0, xPos, _Bitmap.Height);
                string str = xStart.ToString("F" + decimals.ToString());
                g.DrawString(str, font, brushValue, (float)xPos, (float)(_Bitmap.Height - _LowerMargin));
                xStart = Math.Round(xStart + dX, decimals);
            }

            penLine.Dispose();
            g.Dispose();
        }

        private void DrawGridForMap()
        {
            System.Drawing.Point topLeftReceived = new System.Drawing.Point();
            System.Drawing.Point bottomRightReceived = new System.Drawing.Point();

            if (_Core.tileDrawingList.GetExtension(ref topLeftReceived, ref bottomRightReceived))
            {
                topLeftReceived = new System.Drawing.Point(topLeftReceived.X * _Core.Projection.TileSize.Width, topLeftReceived.Y * _Core.Projection.TileSize.Height);
                bottomRightReceived = new System.Drawing.Point((bottomRightReceived.X + 1) * _Core.Projection.TileSize.Width, (bottomRightReceived.Y + 1) * _Core.Projection.TileSize.Height);
                int zoom = _Core.Zoom;

                GMap.NET.PointLatLng topLeft = _Core.Projection.FromPixelToLatLng(topLeftReceived.X, topLeftReceived.Y, zoom);
                GMap.NET.PointLatLng bottomRight = _Core.Projection.FromPixelToLatLng(bottomRightReceived.X, bottomRightReceived.Y, zoom);

                //center: das wird als Mittelpunkt übergeben
                GMap.NET.PointLatLng center = new GMap.NET.PointLatLng((_YMax + _YMin) / 2,
                     (_XMax + _XMin) / 2);

                Pen penLine = new Pen(Color.Wheat);
                Brush brushValue = Brushes.White;
                Font font = new Font("Arial", 8.0f);
                Graphics g = Graphics.FromImage(_Bitmap);

                try
                {
                    //Y Axis
                    double pot = 0.0;
                    double dY = (topLeft.Lat - bottomRight.Lat) / 10;
                    int decimals = 0;
                    int log = Convert.ToInt32(Math.Floor(Math.Log10(dY)));
                    if (log >= 0)
                    {
                        pot = Convert.ToInt32(Math.Pow(10, log));
                        decimals = 0;
                    }
                    else
                    {
                        pot = 1.0 / Math.Pow(10, -log);
                        decimals = -log;
                    }
                    dY = pot * Math.Round(dY / pot, 0);
                    double yStart = 0.0;
                    if (Math.Abs(bottomRight.Lat) > 0.0001)
                    {
                        yStart = Convert.ToInt32(bottomRight.Lat / dY) * dY;
                    }
                    while (yStart <= topLeft.Lat)
                    {
                        GMap.NET.Point yPoint = _Core.Projection.FromLatLngToPixel(new GMap.NET.PointLatLng(yStart, center.Lng), zoom);
                        int yPos = yPoint.Y - topLeftReceived.Y - _TopOffset + _TopMargin;
                        //int yPos = Convert.ToInt32((topLeft.Lat - yStart) / _YFactor) - _TopOffset;
                        g.DrawLine(penLine, 0, yPos, _Bitmap.Width, yPos);
                        string str = yStart.ToString("F" + decimals.ToString());
                        g.DrawString(str, font, brushValue, 0.0f, (float)yPos);
                        yStart = Math.Round(yStart + dY, decimals);
                    }

                    //x axis
                    double dX = (bottomRight.Lng - topLeft.Lng) / 10;
                    log = Convert.ToInt32(Math.Floor(Math.Log10(dX)));
                    if (log >= 0)
                    {
                        pot = Convert.ToInt32(Math.Pow(10, log));
                        decimals = 0;
                    }
                    else
                    {
                        pot = 1.0 / Math.Pow(10, -log);
                        decimals = -log;
                    }
                    dX = pot * Math.Round(dX / pot, 0);
                    double xStart = 0.0;
                    if (Math.Abs(topLeft.Lng) > 0.0001)
                    {
                        xStart = Convert.ToInt32(topLeft.Lng / dX) * dX;
                    }
                    while (xStart <= bottomRight.Lng)
                    {
                        GMap.NET.Point xPoint = _Core.Projection.FromLatLngToPixel(new GMap.NET.PointLatLng(center.Lat, xStart), zoom);
                        int xPos = xPoint.X - topLeftReceived.X - _LeftOffset + _LeftMargin;
                        //int xPos = Convert.ToInt32((xStart - topLeft.Lng) / _XFactor) - _TopOffset;
                        g.DrawLine(penLine, xPos, 0, xPos, _Bitmap.Height);
                        string str = xStart.ToString("F" + decimals.ToString());
                        g.DrawString(str, font, brushValue, (float)xPos, (float)pnlImage.ClientSize.Height - 12);
                        xStart = Math.Round(xStart + dX, decimals);
                    }
                }
                catch
                {
                }
                finally
                {
                    penLine.Dispose();
                    g.Dispose();
                }
            }
        }

        private double GetSelectedValueFromWaypoint(WayPoint wp, DrawCategory drawCategory)
        {
            double retVal = 0;
            switch (drawCategory)
            {
                case DrawCategory.DistanceFromStart:
                    retVal = wp.GetDistanceFromStart().GetLength(wp.Latitude);
                    break;
                case DrawCategory.Elevation:
                    retVal = Convert.ToDouble(wp.Elevation);
                    break;
                case DrawCategory.Latitude:
                    retVal = Convert.ToDouble(wp.Latitude);
                    break;
                case DrawCategory.LatitudeKm:
                    retVal = wp.LatitudeKm;
                    break;
                case DrawCategory.Longitude:
                    retVal = Convert.ToDouble(wp.Longitude);
                    break;
                case DrawCategory.LongitudeKm:
                    retVal = wp.LongitudeKm;
                    break;
                case DrawCategory.Speed:
                    retVal = wp.GetSpeed();
                    break;
                case DrawCategory.SpeedvectorEast:
                    retVal = wp.GetSpeedVector().DeltaLongitude;
                    break;
                case DrawCategory.SpeedvectorElevation:
                    retVal = wp.GetSpeedVector().DeltaElevation;
                    break;
                case DrawCategory.SpeedvectorNorth:
                    retVal = wp.GetSpeedVector().DeltaLatitude;
                    break;
                case DrawCategory.Time:
                    retVal = wp.GetTimeSinceStartSeconds();
                    break;
                case DrawCategory.TrackDistanceFromStart:
                    retVal = wp.GetTrackDistanceFromStart();
                    break;
                case DrawCategory.DirectionEast:
                    retVal = wp.GetDirectionVector().DeltaLongitude;
                    break;
                case DrawCategory.DirectionNorth:
                    retVal = wp.GetDirectionVector().DeltaLatitude;
                    break;
                case DrawCategory.DirectionVertical:
                    retVal = wp.GetDirectionVector().DeltaElevation;
                    break;
                case DrawCategory.PercrentAscent:
                    retVal = wp.GetAscent();
                    break;
                case DrawCategory.Heartrate:
                    retVal = wp.Heartreate;
                    break;
                case DrawCategory.Cadence:
                    retVal = wp.Cadence;
                    break;
                case DrawCategory.Depth:
                    retVal = wp.Depth;
                    break;
                case DrawCategory.Temperature:
                    retVal = wp.Temperature;
                    break;
                case DrawCategory.Watertemperature:
                    retVal = wp.WaterTemperature;
                    break;
                default:
                    //GPX_TrackControl_GetSelectedValueFromWaypoint0=Unknown category for drawing
                    throw new ArgumentException(ResourceManager.GetString("GPX_TrackControl_GetSelectedValueFromWaypoint0"));
            }

            return retVal;
        }

        private void SetWaypointValueForCoordinates(WayPoint wp, int x, int y)
        {
            if (_ShowMap)
            {
                GMap.NET.PointLatLng pos = _Core.FromLocalToLatLng(x, y);
                wp.Latitude = Convert.ToDecimal(pos.Lat);
                wp.Longitude = Convert.ToDecimal(pos.Lng);
            }
            else
            {
                switch (_XCategory)
                {
                    case DrawCategory.Elevation:
                        wp.Elevation = Convert.ToDecimal(_XMin + _XFactor * x); //_XMin + _XFactor * (x - _LeftMargin)
                        break;
                    case DrawCategory.Latitude:
                        wp.Latitude = Convert.ToDecimal(_XMin + _XFactor * x);
                        break;
                    case DrawCategory.LatitudeKm:
                        double latitudeKm = _XMin + _XFactor * x;
                        wp.Latitude = Convert.ToDecimal(latitudeKm / GPXUtils.KmPerDegree);
                        break;
                    case DrawCategory.Longitude:
                        wp.Longitude = Convert.ToDecimal(_XMin + _XFactor * x);
                        break;
                    case DrawCategory.LongitudeKm:
                        double longitudeKm = _XMin + _XFactor * x;
                        wp.Longitude = Convert.ToDecimal(longitudeKm / GPXUtils.KmPerDegreeAtLatitude(wp.Latitude));
                        break;
                    default:
                        //GPX_TrackControl_SetWaypointValueForCoordinates0=X Category not valid for editing
                        throw new ArgumentException(ResourceManager.GetString("GPX_TrackControl_SetWaypointValueForCoordinates0"));
                }

                switch (_YCategory)
                {
                    case DrawCategory.Elevation:
                        wp.Elevation = Convert.ToDecimal(_YMax - _YFactor * y); //_YMax - _YFactor * (y - _GeneralMargin)
                        break;
                    case DrawCategory.Latitude:
                        wp.Latitude = Convert.ToDecimal(_YMax - _YFactor * y);
                        break;
                    case DrawCategory.LatitudeKm:
                        double latitudeKm = _YMax - _YFactor * y;
                        wp.Latitude = Convert.ToDecimal(latitudeKm / GPXUtils.KmPerDegree);
                        break;
                    case DrawCategory.Longitude:
                        wp.Longitude = Convert.ToDecimal(_YMax - _YFactor * y);
                        break;
                    case DrawCategory.LongitudeKm:
                        double longitudeKm = _YMax - _YFactor * y;
                        wp.Longitude = Convert.ToDecimal(longitudeKm / GPXUtils.KmPerDegreeAtLatitude(wp.Latitude));
                        break;
                    default:
                        //GPX_TrackControl_SetWaypointValueForCoordinates1=Y Category not valid for editing
                        throw new ArgumentException(ResourceManager.GetString("GPX_TrackControl_SetWaypointValueForCoordinates1"));
                }
            }
        }

        private void ResetHighlight()
        {
            //Utils.DebugStackTrace();
            if (_WayPointsOnMap != null)
            {
                foreach (WayPointOnMap wpm in _WayPointsOnMap)
                    wpm.IsHighlighted = false;
            }
        }

        private void pnlImage_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (_Bitmap != null)
                {
                    e.Graphics.DrawImageUnscaled(_Bitmap, 0, 0);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("pnlImage_Paint: " + ex.ToString());
            }
        }

        private void pnlImage_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        _Selecting = true;
                        _SelectionStart = e.Location;
                        _SelectedWayPointsOnMap = null;
                        ResetHighlight();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        //is it a waypoint?
                        _SelectedWayPointOnMap = GetWaypointFromPosition(e.X, e.Y);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("pnlImage_MouseDown: " + ex.ToString());
            }
        }

        private void pnlImage_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    //prevent flickering in Windows 7
                    if (e.X == _LastMouseX && e.Y == _LastMouseY)
                    {
                        return;
                    }
                    _LastMouseX = e.X;
                    _LastMouseY = e.Y;

                    if (_Selecting)
                    {
                        this.Refresh();
                        Graphics g = pnlImage.CreateGraphics();
                        Pen pen = new Pen(Color.Blue);
                        int top = Math.Min(_SelectionStart.Y, e.Y);
                        int left = Math.Min(_SelectionStart.X, e.X);
                        int width = Math.Max(_SelectionStart.X, e.X) - left;
                        int height = Math.Max(_SelectionStart.Y, e.Y) - top;
                        g.DrawRectangle(pen, new Rectangle(left, top, width, height));
                        g.Dispose();
                    }
                    else if (_SelectedWayPointOnMap != null)
                    {
                        if (_ShowMap)
                        {
                            _SelectedWayPointOnMap.XPixels = e.X + _LeftOffset;
                            _SelectedWayPointOnMap.YPixels = e.Y + _TopOffset;
                        }
                        else
                        {
                            _SelectedWayPointOnMap.XPixels = e.X;
                            _SelectedWayPointOnMap.YPixels = e.Y;
                        }
                        DrawTracks();
                    }
                    else
                    {
                        WayPointOnMap poi = GetPointofInterestFromPosition(e.X, e.Y);
                        if (poi != null)
                        {
                            string poInfoBase = ResourceManager.GetString("GPX_TrackControl_PoIInfo");
                            string poInfo = string.Format(poInfoBase, poi.WayPoint.Name);
                            toolTip1.SetToolTip(pnlImage, poInfo);
                        }
                        else
                        {
                            WayPointOnMap wpm = GetWaypointFromPosition(e.X, e.Y);
                            if (wpm != null)
                            {
                                //System.Diagnostics.Debug.WriteLine(string.Format("Waypoint detetcted at {0},{1}: {2},{3}", e.X, e.Y, wpm.XPixels, wpm.YPixels));
                                StringBuilder toolTip = new StringBuilder();
                                string info = Defaults.TrackControl_WayPointInfo;
                                string[] lines = info.Split("|".ToCharArray());
                                foreach (string line in lines)
                                {
                                    string[] vals = line.Split(",".ToCharArray());
                                    string prop = vals[1];
                                    string format = vals[2];
                                    object retVal = null;
                                    try
                                    {
                                        PropertyInfo pi = wpm.WayPoint.GetType().GetProperty(prop);
                                        if (pi != null)
                                        {
                                            retVal = pi.GetValue(wpm.WayPoint, null);
                                        }
                                        else
                                        {
                                            MethodInfo mi = wpm.WayPoint.GetType().GetMethod(prop);
                                            retVal = mi.Invoke(wpm.WayPoint, null);
                                        }
                                        string dataLine = vals[0] + ":\t" + string.Format(format, retVal);
                                        toolTip.AppendLine(dataLine);
                                    }
                                    catch (Exception) { }
                                }
                                toolTip.Remove(toolTip.Length - 2, 2);
                                toolTip1.SetToolTip(pnlImage, toolTip.ToString());
                            }
                            else
                            {
                                if (_ShowMap)
                                {
                                    //Tooltip shows position
                                    GMap.NET.PointLatLng pos = _Core.FromLocalToLatLng(e.X + _LeftOffset - _LeftMargin, e.Y + _TopOffset - _TopMargin);
                                    //GPX_TrackControl_pnlImage_MouseMove0=Position:\r\nLatitude \t= {0:F4}\r\nLongitude\t= {1:F4}
                                    string msg = string.Format(ResourceManager.GetString("GPX_TrackControl_pnlImage_MouseMove0"), pos.Lat, pos.Lng);
                                    toolTip1.SetToolTip(pnlImage, msg);
                                }
                                else
                                {
                                    toolTip1.RemoveAll();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("pnlImage_MouseMove: " + ex.ToString());
            }
        }

        private void pnlImage_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (_Selecting)
                    {
                        Point p1 = new Point(e.X < _SelectionStart.X ? e.X : _SelectionStart.X, e.Y < _SelectionStart.Y ? e.Y : _SelectionStart.Y);
                        _SelectionEnd = new Point(e.X > _SelectionStart.X ? e.X : _SelectionStart.X, e.Y > _SelectionStart.Y ? e.Y : _SelectionStart.Y);
                        _SelectionStart = p1;
                        _Selecting = false;
                        Graphics g = this.CreateGraphics();
                        Pen pen = new Pen(Color.Blue);
                        g.DrawRectangle(pen, new Rectangle(_SelectionStart.X, _SelectionStart.Y, _SelectionEnd.X - _SelectionStart.X, _SelectionEnd.Y - _SelectionStart.Y));
                        g.Dispose();
                        //calculate the selection
                        _SelectedWayPointsOnMap = new List<WayPointOnMap>();
                        foreach (WayPointOnMap wpm in _WayPointsOnMap)
                        {
                            if (wpm.IsInBounds(_SelectionStart.X, _SelectionStart.Y, _SelectionEnd.X, _SelectionEnd.Y))
                            {
                                wpm.IsHighlighted = true;
                                _SelectedWayPointsOnMap.Add(wpm);
                            }
                        }
                        Draw();
                    }
                    else if (_SelectedWayPointOnMap != null)
                    {
                        //calculate x and y values for the point
                        int x = e.X + _LeftOffset - _LeftMargin;
                        int y = e.Y + _TopOffset - _TopMargin;
                        SetWaypointValueForCoordinates(_SelectedWayPointOnMap.WayPoint, x, y);
                        _SelectedWayPointOnMap = null;
                        foreach (Track track in _Tracks)
                            track.Recalculate();
                        Draw();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("pnlImage_MouseUp: " + ex.ToString());
            }
        }

        private void pnlImage_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    WayPointOnMap wpm = GetWaypointFromPosition(e.X, e.Y);
                    if (wpm != null)
                    {
                        if (WayPointSelected != null)
                            this.WayPointSelected(this, new WayPointSelectedEventArgs(wpm.WayPoint));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("pnlImage_MouseClick: " + ex.ToString());
            }
        }

        private void pnlImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private WayPointOnMap GetWaypointFromPosition(int X, int Y)
        {
            WayPointOnMap wpm = null;
            int delta = 3;
            foreach (WayPointOnMap wp in _WayPointsOnMap)
            {
                if (wp.IsInBounds(X + _LeftOffset - delta, Y + _TopOffset - delta, X + _LeftOffset + delta, Y + _TopOffset + delta))
                {
                    wpm = wp;
                    break;
                }
            }
            return wpm;
        }

        private WayPointOnMap GetPointofInterestFromPosition(int X, int Y)
        {
            WayPointOnMap wpm = null;
            int delta = 3;
            foreach (WayPointOnMap wp in _PointsOfInterest)
            {
                if (wp.IsInBounds(X + _LeftOffset - delta, Y + _TopOffset - delta, X + _LeftOffset + delta, Y + _TopOffset + delta))
                {
                    wpm = wp;
                    break;
                }
            }
            return wpm;
        }

        #region DragDrop

        private class TrackControlDataObject : DataObject
        {
            private Control _Source;
            public Control Source
            {
                get { return _Source; }
                set { _Source = value; }
            }

            public TrackControlDataObject(string format, object data, Control source)
                : base(format, data)
            {
                _Source = source;
            }
        }
        #endregion DragDrop

        #region Drawing of Maps
        private void Core_OnNeedInvalidation()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(Core_OnNeedInvalidation));
                return;
            }

            System.Diagnostics.Debug.WriteLine(string.Format("{0} TrackControl._Core_OnNeedInvalidation", DateTime.Now));
            if (DateTime.Now - _LastDrawTime < new TimeSpan((long)2e+7))
            {
                _DrawPending = true;
                return;
            }

            timer1.Stop();
            DrawImage();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_DrawPending)
                DrawImage();
        }

        private void DrawImage()
        {
            if (_Bitmap == null || !_ShowMap)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(DrawImage));
                return;
            }

            _DrawPending = false;
            System.Drawing.Point topLeft = new System.Drawing.Point();
            System.Drawing.Point bottomRight = new System.Drawing.Point();
            if (_Core.tileDrawingList.GetExtension(ref topLeft, ref bottomRight))
            {
                _LastDrawTime = DateTime.Now;
                System.Diagnostics.Debug.WriteLine(string.Format("{0} TrackControl.DrawImage: TopLeft={1}, BottomRight={2}", DateTime.Now, topLeft, bottomRight));
                Graphics graphics = Graphics.FromImage(_Bitmap);
                DetermineOffset();

                for (int x = topLeft.X; x <= bottomRight.X; x++)
                {
                    for (int y = topLeft.Y; y <= bottomRight.Y; y++)
                    {
                        int xOffset = (x - topLeft.X) * _Core.Projection.TileSize.Width - _LeftOffset + _LeftMargin;
                        int yOffset = (y - topLeft.Y) * _Core.Projection.TileSize.Height - _TopOffset + _TopMargin;
                        System.Drawing.Point location = new System.Drawing.Point(xOffset, yOffset);

                        GMap.NET.Internals.Tile tile = _Core.Matrix[new GMap.NET.Point(x, y)];
                        if (tile != null)
                        {
                            foreach (GMap.NET.PureImage img in tile.Overlays)
                            {
                                if (img is GMap.NET.WindowsForms.WindowsFormsImage)
                                {
                                    System.IO.MemoryStream ms = img.Data;
                                    Image image = (img as GMap.NET.WindowsForms.WindowsFormsImage).Img;
                                    if (image != null)
                                    {
                                        graphics.DrawImage(image, location);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //draw empty image
                            Brush brush = Brushes.Bisque;
                            graphics.FillRectangle(brush, xOffset, yOffset, _Core.Projection.TileSize.Width, _Core.Projection.TileSize.Height);
                        }
                    }
                }

                DrawTracks();
                DrawGridForMap();
                DrawPoI();

                graphics.Dispose();
                GC.WaitForPendingFinalizers();
                GC.Collect(1, GCCollectionMode.Optimized);
                _LastDrawTime = DateTime.Now;

                try
                {
                    _Bitmap.Save(Defaults.TrackControl_BitmapPath, System.Drawing.Imaging.ImageFormat.Bmp); //@"C:\temp\bitmap.bmp"
                }
                catch
                {
                    //swallow
                }
                this.Refresh();

                //sometimes not all tiles are downloaded!
                if (_Core.tileLoadQueue.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("{0} TrackControl.DrawImage - Restarting Tile Load", DateTime.Now));
                    _Core.StartProcessLoadTasks();
                }
            }
        }
        private void DetermineOffset()
        {
            if (_UseOffset)
            {
                System.Drawing.Point topLeftReceived = new System.Drawing.Point();
                System.Drawing.Point bottomRightReceived = new System.Drawing.Point();

                if (_Core.tileDrawingList.GetExtension(ref topLeftReceived, ref bottomRightReceived))
                {
                    topLeftReceived = new System.Drawing.Point(topLeftReceived.X * _Core.Projection.TileSize.Width, topLeftReceived.Y * _Core.Projection.TileSize.Height);
                    int zoom = _Core.Zoom;
                    GMap.NET.PointLatLng topLeft = new GMap.NET.PointLatLng(_YMax, _XMin);
                    GMap.NET.PointLatLng bottomRight = new GMap.NET.PointLatLng(_YMin, _XMax);
                    //wo liegen der unterste und der rechteste Punkt
                    GMap.NET.Point bottomRightPixel = _Core.Projection.FromLatLngToPixel(bottomRight, zoom);
                    if (bottomRightPixel.X - topLeftReceived.X > pnlImage.ClientSize.Width)
                    {
                        _LeftOffset = bottomRightPixel.X - topLeftReceived.X - pnlImage.ClientSize.Width + 5;
                    }
                    else
                    {
                        _LeftOffset = 0;
                    }
                    if (bottomRightPixel.Y - topLeftReceived.Y > pnlImage.ClientSize.Height)
                    {
                        _TopOffset = bottomRightPixel.Y - topLeftReceived.Y - pnlImage.ClientSize.Height + 5;
                    }
                    else
                    {
                        _TopOffset = 0;
                    }
                }
                else
                {
                    _LeftOffset = 0;
                    _TopOffset = 0;
                }
            }
            else
            {
                _LeftOffset = 0;
                _TopOffset = 0;
            }
        }
        #endregion Drawing of Maps

        private void ValueToPixel(double xValue, double yValue, out int xPixel, out int yPixel)
        {
            if (_ShowMap)
            {
                System.Drawing.Point present =
                    _Core.FromLatLngToLocal(new GMap.NET.PointLatLng(yValue, xValue)).ToDrawingPoint();
                xPixel = _LeftMargin + present.X;
                yPixel = _TopMargin + present.Y;
            }
            else
            {
                xPixel = _LeftMargin + Convert.ToInt32((xValue - _XMin) / _XFactor);
                yPixel = _TopMargin + Convert.ToInt32((_YMax - yValue) / _YFactor);
            }
        }

        private void PixelToValue(int xPixel, int yPixel, out double xValue, out double yValue)
        {
            xValue = 0.0;
            yValue = 0.0;
        }

        internal void ClearTilesCache()
        {
            if (_Core != null)
            {
                _Core.ClearTilesCache();
            }
        }
    }
}
