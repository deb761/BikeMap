﻿
namespace GMap.NET.Internals
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using GMap.NET.Projections;
    using System.IO;

#if PocketPC
   using Semaphore=OpenNETCF.Threading.Semaphore;
#endif

    /// <summary>
    /// internal map control core
    /// </summary>
    public class Core
    {
        public PointLatLng currentPosition;
        public Point currentPositionPixel;

        public Point renderOffset;
        public Point centerTileXYLocation;
        public Point centerTileXYLocationLast;
        public Point dragPoint;

        public Point mouseDown;
        public Point mouseCurrent;
        public Point mouseLastZoom;

        public MouseWheelZoomType MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;

        public PointLatLng? LastLocationInBounds = null;

        public Size sizeOfMapArea;
        public Size minOfTiles;
        public Size maxOfTiles;

        public Rectangle tileRect;
        public Point tilePoint;

        public Rectangle CurrentRegion;

        public readonly TileMatrix Matrix = new TileMatrix();
        readonly System.Threading.EventWaitHandle waitOnEmptyTasks = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.AutoReset);
        //public List<Point> tileDrawingList = new List<Point>();
        public PointListEx tileDrawingList = new PointListEx();
        public readonly Queue<LoadTask> tileLoadQueue = new Queue<LoadTask>(128);
        readonly WaitCallback ProcessLoadTaskCallback;

        public readonly string googleCopyright = string.Format("©{0} Google - Map data ©{0} Tele Atlas, Imagery ©{0} TerraMetrics", DateTime.Today.Year);
        public readonly string openStreetMapCopyright = string.Format("© OpenStreetMap - Map data ©{0} OpenStreetMap", DateTime.Today.Year);
        public readonly string yahooMapCopyright = string.Format("© Yahoo! Inc. - Map data & Imagery ©{0} NAVTEQ", DateTime.Today.Year);
        public readonly string virtualEarthCopyright = string.Format("©{0} Microsoft Corporation, ©{0} NAVTEQ, ©{0} Image courtesy of NASA", DateTime.Today.Year);
        public readonly string arcGisCopyright = string.Format("©{0} ESRI - Map data ©{0} ArcGIS", DateTime.Today.Year);

        internal bool started = false;
        int zoom;
        internal int Width;
        internal int Height;

        internal int pxRes100m;  // 100 meters
        internal int pxRes1000m;  // 1km  
        internal int pxRes10km; // 10km
        internal int pxRes100km; // 100km
        internal int pxRes1000km; // 1000km
        internal int pxRes5000km; // 5000km

        PureProjection projection;

        /// <summary>
        /// current projection
        /// </summary>
        public PureProjection Projection
        {
            get
            {
                return projection;
            }
            set
            {
                projection = value;
                tileRect = new Rectangle(new Point(0, 0), value.TileSize);
            }
        }

        /// <summary>
        /// is user dragging map
        /// </summary>
        public bool IsDragging = false;

        /// <summary>
        /// map zoom
        /// </summary>
        public int Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                if (zoom != value && !IsDragging)
                {
                    zoom = value;

                    minOfTiles = Projection.GetTileMatrixMinXY(value);
                    maxOfTiles = Projection.GetTileMatrixMaxXY(value);

                    CurrentPositionGPixel = Projection.FromLatLngToPixel(CurrentPosition, value);

                    if (started)
                    {
                        lock (tileLoadQueue)
                        {
                            tileLoadQueue.Clear();
                            tileLoadQueue.TrimExcess();
                        }
                        Matrix.Clear();

                        GoToCurrentPositionOnZoom();
                        UpdateBaunds();

                        if (OnNeedInvalidation != null)
                        {
                            OnNeedInvalidation();
                        }

                        if (OnMapDrag != null)
                        {
                            OnMapDrag();
                        }

                        if (OnMapZoomChanged != null)
                            OnMapZoomChanged();

                        if (OnCurrentPositionChanged != null)
                            OnCurrentPositionChanged(currentPosition);
                    }
                }
            }
        }

        /// <summary>
        /// current marker position in pixel coordinates
        /// </summary>
        public Point CurrentPositionGPixel
        {
            get
            {
                return currentPositionPixel;
            }
            internal set
            {
                currentPositionPixel = value;
            }
        }

        /// <summary>
        /// current marker position
        /// </summary>
        public PointLatLng CurrentPosition
        {
            get
            {

                return currentPosition;
            }
            set
            {
                if (!IsDragging)
                {
                    currentPosition = value;
                    CurrentPositionGPixel = Projection.FromLatLngToPixel(value, Zoom);

                    if (started)
                    {
                        GoToCurrentPosition();

                        if (OnCurrentPositionChanged != null)
                            OnCurrentPositionChanged(currentPosition);
                    }
                }
                else
                {
                    currentPosition = value;
                    CurrentPositionGPixel = Projection.FromLatLngToPixel(value, Zoom);

                    if (started)
                    {
                        if (OnCurrentPositionChanged != null)
                            OnCurrentPositionChanged(currentPosition);
                    }
                }
            }
        }

        /// <summary>
        /// for tooltip text padding
        /// </summary>
        public Size TooltipTextPadding = new Size(10, 10);

        MapType mapType;
        public MapType MapType
        {
            get
            {
                return mapType;
            }
            set
            {
                if (value != MapType)
                {
                    mapType = value;

                    switch (value)
                    {
#if TESTpjbcoetzer
                  case MapType.ArcGIS_TestPjbcoetzer:
                  {
                     if(false == (Projection is PlateCarreeProjection2))
                     {
                        Projection = new PlateCarreeProjection2();
                     }
                  }
                  break;
#endif

                        case MapType.ArcGIS_Map:
                        case MapType.ArcGIS_Satellite:
                        case MapType.ArcGIS_ShadedRelief:
                        case MapType.ArcGIS_Terrain:
                            {
                                if (false == (Projection is PlateCarreeProjection))
                                {
                                    Projection = new PlateCarreeProjection();
                                }
                            }
                            break;

                        case MapType.ArcGIS_MapsLT_Map_Hybrid:
                        case MapType.ArcGIS_MapsLT_Map_Labels:
                        case MapType.ArcGIS_MapsLT_Map:
                        case MapType.ArcGIS_MapsLT_OrtoFoto:
                            {
                                if (false == (Projection is LKS94Projection))
                                {
                                    Projection = new LKS94Projection();
                                }
                            }
                            break;

                        case MapType.PergoTurkeyMap:
                            {
                                if (false == (Projection is PlateCarreeProjectionPergo))
                                {
                                    Projection = new PlateCarreeProjectionPergo();
                                }
                            }
                            break;

                        default:
                            {
                                if (false == (Projection is MercatorProjection))
                                {
                                    Projection = new MercatorProjection();
                                }
                            }
                            break;
                    }

                    minOfTiles = Projection.GetTileMatrixMinXY(Zoom);
                    maxOfTiles = Projection.GetTileMatrixMaxXY(Zoom);
                    CurrentPositionGPixel = Projection.FromLatLngToPixel(CurrentPosition, Zoom);

                    if (started)
                    {
                        CancelAsyncTasks();
                        OnMapSizeChanged(Width, Height);
                        GoToCurrentPosition();
                        ReloadMap();

                        if (OnMapTypeChanged != null)
                        {
                            OnMapTypeChanged(value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// is routes enabled
        /// </summary>
        public bool RoutesEnabled = true;

        /// <summary>
        /// is markers enabled
        /// </summary>
        public bool MarkersEnabled = true;

        /// <summary>
        /// can user drag map
        /// </summary>
        public bool CanDragMap = true;

        /// <summary>
        /// map render mode
        /// </summary>
        public RenderMode RenderMode = RenderMode.GDI_PLUS;

        /// <summary>
        /// occurs when current position is changed
        /// </summary>
        public event CurrentPositionChanged OnCurrentPositionChanged;

        /// <summary>
        /// occurs when tile set load is complete
        /// </summary>
        public event TileLoadComplete OnTileLoadComplete;

        /// <summary>
        /// occurs when tile set is starting to load
        /// </summary>
        public event TileLoadStart OnTileLoadStart;

        /// <summary>
        /// occurs on tile loaded
        /// </summary>
        public event NeedInvalidation OnNeedInvalidation;

        /// <summary>
        /// occurs on map drag
        /// </summary>
        public event MapDrag OnMapDrag;

        /// <summary>
        /// occurs on map zoom changed
        /// </summary>
        public event MapZoomChanged OnMapZoomChanged;

        /// <summary>
        /// occurs on map type changed
        /// </summary>
        public event MapTypeChanged OnMapTypeChanged;

        private Core()
        {
            ProcessLoadTaskCallback = new WaitCallback(ProcessLoadTask);
        }
        private static Core _Instance;
        public static Core Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Core();
                }
                return _Instance;
            }
        }


        /// <summary>
        /// starts core system
        /// </summary>
        public void StartSystem()
        {
            if (!started)
            {
                started = true;

                ReloadMap();
                //GoToCurrentPosition();
            }
        }

        private bool _WasStarted;
        public void BeginUpdate()
        {
            _WasStarted = started;
            started = false;
        }
        public void EndUpdate()
        {
            started = _WasStarted;
            centerTileXYLocation = projection.FromPixelToTileXY(projection.FromLatLngToPixel(currentPosition, zoom));
            if (started)
            {
                ReloadMap();
                //Update Render Offset
                System.Drawing.Point topLeft = System.Drawing.Point.Empty;
                System.Drawing.Point bottomRight = System.Drawing.Point.Empty;
                tileDrawingList.GetExtension(ref topLeft, ref bottomRight);
                renderOffset.X = -topLeft.X * projection.TileSize.Width;
                renderOffset.Y = -topLeft.Y * projection.TileSize.Height;
            }
        }

        public void UpdateCenterTileXYLocation()
        {
            PointLatLng center = FromLocalToLatLng(Width / 2, Height / 2);
            GMap.NET.Point centerPixel = Projection.FromLatLngToPixel(center, Zoom);
            centerTileXYLocation = Projection.FromPixelToTileXY(centerPixel);
        }

        public void OnMapSizeChanged(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            sizeOfMapArea.Width = 1 + (Width / Projection.TileSize.Width) / 2;
            sizeOfMapArea.Height = 1 + (Height / Projection.TileSize.Height) / 2;

            UpdateCenterTileXYLocation();

            if (started)
            {
                UpdateBaunds();

                if (OnCurrentPositionChanged != null)
                    OnCurrentPositionChanged(currentPosition);
            }
        }

        public void OnMapClose()
        {
            if (waitOnEmptyTasks != null)
            {
                try
                {
                    waitOnEmptyTasks.Set();
                    waitOnEmptyTasks.Close();
                }
                catch
                {
                }
            }

            CancelAsyncTasks();
        }

        /// <summary>
        /// sets current position by geocoding
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public GeoCoderStatusCode SetCurrentPositionByKeywords(string keys)
        {
            GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;
            PointLatLng? pos = GMaps.Instance.GetLatLngFromGeocoder(keys, out status);
            if (pos.HasValue && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                CurrentPosition = pos.Value;
            }

            return status;
        }

        /// <summary>
        /// gets current map view top/left coordinate, width in Lng, height in Lat
        /// </summary>
        /// <returns></returns>
        public RectLatLng CurrentViewArea
        {
            get
            {
                PointLatLng p = Projection.FromPixelToLatLng(-renderOffset.X, -renderOffset.Y, Zoom);
                double rlng = Projection.FromPixelToLatLng(-renderOffset.X + Width, -renderOffset.Y, Zoom).Lng;
                double blat = Projection.FromPixelToLatLng(-renderOffset.X, -renderOffset.Y + Height, Zoom).Lat;

                return RectLatLng.FromLTRB(p.Lng, p.Lat, rlng, blat);
            }
        }

        /// <summary>
        /// gets lat/lng from local control coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PointLatLng FromLocalToLatLng(int x, int y)
        {
            return Projection.FromPixelToLatLng(new Point(x - renderOffset.X, y - renderOffset.Y), Zoom);
        }

        /// <summary>
        /// return local coordinates from lat/lng
        /// </summary>
        /// <param name="latlng"></param>
        /// <returns></returns>
        public Point FromLatLngToLocal(PointLatLng latlng)
        {
            Point pLocal = Projection.FromLatLngToPixel(latlng, Zoom);
            pLocal.Offset(renderOffset);
            return pLocal;
        }

        /// <summary>
        /// gets max zoom level to fit rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public int GetMaxZoomToFitRect(RectLatLng rect)
        {
            int zoom = 0;

            for (int i = 1; i <= GMaps.Instance.MaxZoom; i++)
            {
                Point p1 = Projection.FromLatLngToPixel(rect.LocationTopLeft, i);
                Point p2 = Projection.FromLatLngToPixel(rect.Bottom, rect.Right, i);

                if (((p2.X - p1.X) <= Width + 10) && (p2.Y - p1.Y) <= Height + 10)
                {
                    zoom = i;
                }
                else
                {
                    break;
                }
            }

            return zoom;
        }

        /// <summary>
        /// initiates map dragging
        /// </summary>
        /// <param name="pt"></param>
        public void BeginDrag(Point pt)
        {
            dragPoint.X = pt.X - renderOffset.X;
            dragPoint.Y = pt.Y - renderOffset.Y;
            IsDragging = true;
        }

        /// <summary>
        /// ends map dragging
        /// </summary>
        public void EndDrag()
        {
            IsDragging = false;
            if (OnNeedInvalidation != null)
            {
                OnNeedInvalidation();
            }
        }

        /// <summary>
        /// reloads map
        /// </summary>
        public void ReloadMap()
        {
            if (started)
            {
                Debug.WriteLine("------------------");

                lock (tileLoadQueue)
                {
                    tileLoadQueue.Clear();
                    tileLoadQueue.TrimExcess();
                }

                Matrix.Clear();

                if (OnNeedInvalidation != null)
                {
                    OnNeedInvalidation();
                }

                UpdateBaunds();
            }
        }

        /// <summary>
        /// moves current position into map center
        /// </summary>
        public void GoToCurrentPosition()
        {
            // reset stuff
            renderOffset = Point.Empty;
            centerTileXYLocationLast = Point.Empty;
            dragPoint = Point.Empty;

            // goto location
            this.Drag(new Point(-(CurrentPositionGPixel.X - Width / 2), -(CurrentPositionGPixel.Y - Height / 2)));
        }

        public bool MouseWheelZooming = false;

        /// <summary>
        /// moves current position into map center
        /// </summary>
        internal void GoToCurrentPositionOnZoom()
        {
            // reset stuff
            renderOffset = Point.Empty;
            centerTileXYLocationLast = Point.Empty;
            dragPoint = Point.Empty;

            // goto location and centering
            if (MouseWheelZooming)
            {
                if (MouseWheelZoomType != MouseWheelZoomType.MousePositionWithoutCenter)
                {
                    Point pt = new Point(-(CurrentPositionGPixel.X - Width / 2), -(CurrentPositionGPixel.Y - Height / 2));
                    renderOffset.X = pt.X - dragPoint.X;
                    renderOffset.Y = pt.Y - dragPoint.Y;
                }
                else // without centering
                {
                    renderOffset.X = -CurrentPositionGPixel.X - dragPoint.X;
                    renderOffset.Y = -CurrentPositionGPixel.Y - dragPoint.Y;
                    renderOffset.Offset(mouseLastZoom);
                }
            }
            else // use current map center
            {
                mouseLastZoom = Point.Empty;

                Point pt = new Point(-(CurrentPositionGPixel.X - Width / 2), -(CurrentPositionGPixel.Y - Height / 2));
                renderOffset.X = pt.X - dragPoint.X;
                renderOffset.Y = pt.Y - dragPoint.Y;
            }

            UpdateCenterTileXYLocation();
        }

        /// <summary>
        /// drag map
        /// </summary>
        /// <param name="pt"></param>
        public void Drag(Point pt)
        {
            renderOffset.X = pt.X - dragPoint.X;
            renderOffset.Y = pt.Y - dragPoint.Y;

            UpdateCenterTileXYLocation();

            if (centerTileXYLocation != centerTileXYLocationLast)
            {
                centerTileXYLocationLast = centerTileXYLocation;
                UpdateBaunds();
            }

            if (IsDragging)
            {
                LastLocationInBounds = CurrentPosition;
                CurrentPosition = FromLocalToLatLng((int)Width / 2, (int)Height / 2);
            }

            if (OnNeedInvalidation != null)
            {
                OnNeedInvalidation();
            }

            if (OnMapDrag != null)
            {
                OnMapDrag();
            }
        }

        /// <summary>
        /// cancels tile loaders and bounds checker
        /// </summary>
        public void CancelAsyncTasks()
        {
            if (started)
            {
                lock (tileLoadQueue)
                {
                    tileLoadQueue.Clear();
                    tileLoadQueue.TrimExcess();
                }
            }
        }

#if PocketPC
        Semaphore loaderLimit = new Semaphore(2, 2);
#else
        Semaphore loaderLimit = new Semaphore(2, 2);
#endif

#if DEBUG
        Stopwatch timer = new Stopwatch();
#endif
        public void StartProcessLoadTasks()
        {
            bool queued = ThreadPool.QueueUserWorkItem(ProcessLoadTaskCallback);
        }

        public void ProcessLoadTask(object obj)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} Thread={1} _Core.ProcessLoadTask: top of function.", DateTime.Now, Thread.CurrentThread.ManagedThreadId));
            if (loaderLimit.WaitOne(GMaps.Instance.Timeout, true))
            {
                bool process = true;
                bool last = false;

                LoadTask task = new LoadTask();

                lock (tileLoadQueue)
                {
                    if (tileLoadQueue.Count > 0)
                    {
                        task = tileLoadQueue.Dequeue();
                        //tileLoadQueue.TrimExcess();
                        {
                            last = tileLoadQueue.Count == 0;
                            System.Diagnostics.Debug.WriteLine(string.Format("{0} Thread={1} _Core.ProcessLoadTask: TileLoadQueue={2}.", DateTime.Now, Thread.CurrentThread.ManagedThreadId, tileLoadQueue.Count));
                            //Debug.WriteLine("TileLoadQueue: " + tileLoadQueue.Count);
                        }
                    }
                    else
                    {
                        process = false;
                    }
                }

                System.Diagnostics.Debug.WriteLine(string.Format("{0} Thread={1} _Core.ProcessLoadTask: after WaitOne.", DateTime.Now, Thread.CurrentThread.ManagedThreadId));
                if (process)
                {
                    try
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("{0} Thread={1} _Core.ProcessLoadTask: ProcessLoadTask={2}.", DateTime.Now, Thread.CurrentThread.ManagedThreadId, task));
                        //Debug.WriteLine("ProcessLoadTask: " + task);

                        Tile t = new Tile(task.Zoom, task.Pos);
                        {
                            MapType[] layers = GMaps.Instance.GetAllLayersOfType(MapType);
                            int retry = 0;

                            // try get it few times
                            do
                            {
                                lock (t.Overlays)
                                {
                                    t.Overlays.Clear();
                                }

                                foreach (MapType tl in layers)
                                {
                                    PureImage img;

                                    // tile number inversion(BottomLeft -> TopLeft) for pergo maps
                                    if (tl == MapType.PergoTurkeyMap)
                                    {
                                        img = GMaps.Instance.GetImageFrom(tl, new Point(task.Pos.X, maxOfTiles.Height - task.Pos.Y), task.Zoom);
                                    }
                                    else // ok
                                    {
                                        Debug.WriteLine(string.Format("{3:dd.MM.yyyy HH:mm:ss.ffff}, Thread={4} Core.ProcessLoadTask  calling GetImageFrom(type={0}, pos={1}, zoom={2}", tl, task.Pos, task.Zoom, DateTime.Now, Thread.CurrentThread.ManagedThreadId));
                                        img = GMaps.Instance.GetImageFrom(tl, task.Pos, task.Zoom);
                                    }

                                    if (img != null)
                                    {
                                        lock (t.Overlays)
                                        {
                                            t.Overlays.Add(img);
                                        }
                                        retry = 0;
                                    }
                                    else
                                    {
                                        Debug.WriteLine("ProcessLoadTask: " + task + " -> empty tile, retry " + retry);

                                        if (retry++ > 0)
                                        {
                                            Thread.Sleep(1111);
                                        }
                                        break;
                                    }
                                }
                            }
                            while (retry != 0 && retry < GMaps.Instance.RetryLoadTile);

                            Matrix[task.Pos] = t;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("ProcessLoadTask: " + ex.ToString());
                    }
                    finally
                    {
                        // last buddy cleans stuff ;}
                        if (last)
                        {
                            GMaps.Instance.kiberCacheLock.AcquireWriterLock(-1);
                            try
                            {
                                GMaps.Instance.TilesInMemory.RemoveMemoryOverload();
                            }
                            finally
                            {
                                GMaps.Instance.kiberCacheLock.ReleaseWriterLock();
                            }

                            lock (tileDrawingList)
                            {
                                Matrix.ClearPointsNotIn(ref tileDrawingList);
                            }

                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.Collect();

#if DEBUG
                            lock (tileLoadQueue)
                            {
                                timer.Stop();
                            }

                            Debug.WriteLine("OnTileLoadComplete: " + timer.ElapsedMilliseconds + "ms, MemoryCacheSize: " + GMaps.Instance.MemoryCacheSize + "MB");
                            Debug.Flush();
#endif
                            if (OnTileLoadComplete != null)
                            {
                                OnTileLoadComplete();
                            }
                        }

                        if (OnNeedInvalidation != null)
                        {
                            OnNeedInvalidation();
                        }
                    }
                }
                int previousCount = loaderLimit.Release();
                Debug.WriteLine(string.Format("{0:dd.MM.yyyy HH:mm:ss.ffff}, Thread={1} Core.ProcessLoadTask  called loaderLimit.Release(), previousCount = {2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, previousCount));
            }
        }

        /// <summary>
        /// updates map bounds
        /// </summary>
        void UpdateBaunds()
        {
            Debug.WriteLine(string.Format("{0:dd.MM.yyyy HH:mm:ss.ffff}, Thread={1} Core.UpdateBaunds()", DateTime.Now, Thread.CurrentThread.ManagedThreadId));
            lock (tileDrawingList)
            {
                FindTilesAround(ref tileDrawingList);

                Debug.WriteLine("OnTileLoadStart: " + tileDrawingList.Count + " tiles to load at zoom " + Zoom + ", time: " + DateTime.Now.TimeOfDay);

                if (OnTileLoadStart != null)
                {
                    OnTileLoadStart();
                }

#if DEBUG
                lock (tileLoadQueue)
                {
                    timer.Reset();
                    timer.Start();
                }
#endif

                foreach (Point p in tileDrawingList)
                {
                    LoadTask task = new LoadTask(p, Zoom);
                    {
                        Thread.Sleep(10);
                        lock (tileLoadQueue)
                        {
                            if (!tileLoadQueue.Contains(task))
                            {
                                //int workerThreads;
                                //int completionPortThreads;
                                //ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                                //Debug.WriteLine(string.Format("{0:dd.MM.yyyy HH:mm:ss.ffff}, Thread={1} Core.UpdateBaunds is adding task {2}; Available Threads={3}/{4}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, task, workerThreads, completionPortThreads));
                                Debug.WriteLine(string.Format("{0:dd.MM.yyyy HH:mm:ss.ffff}, Thread={1} Core.UpdateBaunds is adding task {2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, task));
                                tileLoadQueue.Enqueue(task);
                                bool queued = ThreadPool.QueueUserWorkItem(ProcessLoadTaskCallback);
                                if (!queued)
                                    throw new ApplicationException("Task could not be queued!");
                            }
                        }
                    }
                }
            }

            UpdateGroundResolution();
        }

        /// <summary>
        /// find tiles around to fill screen
        /// </summary>
        /// <param name="list"></param>
        void FindTilesAround(ref PointListEx list)
        {
            list.Clear();
            for (int i = -sizeOfMapArea.Width; i <= sizeOfMapArea.Width; i++)
            {
                for (int j = -sizeOfMapArea.Height; j <= sizeOfMapArea.Height; j++)
                {
                    Point p = centerTileXYLocation;
                    p.X += i;
                    p.Y += j;

                    //if(p.X < minOfTiles.Width)
                    //{
                    //   p.X += (maxOfTiles.Width + 1);
                    //}

                    //if(p.X > maxOfTiles.Width)
                    //{
                    //   p.X -= (maxOfTiles.Width + 1);
                    //}

                    if (p.X >= minOfTiles.Width && p.Y >= minOfTiles.Height && p.X <= maxOfTiles.Width && p.Y <= maxOfTiles.Height)
                    {
                        if (!list.Contains(p))
                        {
                            list.Add(p);
                        }
                    }
                }
            }

            if (GMaps.Instance.ShuffleTilesOnLoad)
            {
                Stuff.Shuffle<Point>(list);
            }
        }

        /// <summary>
        /// updates ground resolution info
        /// </summary>
        void UpdateGroundResolution()
        {
            double rez = Projection.GetGroundResolution(Zoom, CurrentPosition.Lat);
            pxRes100m = (int)(100.0 / rez); // 100 meters
            pxRes1000m = (int)(1000.0 / rez); // 1km  
            pxRes10km = (int)(10000.0 / rez); // 10km
            pxRes100km = (int)(100000.0 / rez); // 100km
            pxRes1000km = (int)(1000000.0 / rez); // 1000km
            pxRes5000km = (int)(5000000.0 / rez); // 5000km
        }

        public void ClearTilesCache()
        {
            GMaps.Instance.TilesInMemory.Clear();
        }
    }
}
