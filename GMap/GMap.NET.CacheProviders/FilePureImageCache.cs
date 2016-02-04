using System;
using System.Drawing;
using System.IO;

using GMap.NET;
using GMap.NET.WindowsForms;

namespace GMap.NET.CacheProviders
{
    public class FilePureImageCache : PureImageCache
    {
        private string _CacheLocation;
        public string CacheLocation
        {
            get
            {
                if (string.IsNullOrEmpty(_CacheLocation))
                {
                    return GMap.NET.Internals.Cache.Instance.CacheLocation;
                }
                else
                {
                    return _CacheLocation;
                }
            }
            set
            {
                _CacheLocation = value;
                Directory.CreateDirectory(_CacheLocation);
            }
        }

        private static DateTime _CacheDate;
        public static DateTime CacheDate
        {
            get { return _CacheDate; }
            set { _CacheDate = value; }
        }

        public FilePureImageCache()
        {
            _CacheDate = new DateTime(2000, 1, 1);
        }

        public bool PutImageToCache(MemoryStream tile, MapType type, Point pos, int zoom)
        {
            FileStream fs = null;
            try
            {
                string fileName = GetFilename(type, pos, zoom, true);
                fs = new FileStream(fileName, FileMode.Create);
                tile.WriteTo(fs);
                tile.Flush();
                fs.Close();
                fs.Dispose();
                tile.Seek(0, SeekOrigin.Begin);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in FilePureImageCache.PutImageToCache:\r\n" + ex.ToString());
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                return false;
            }
        }

        public PureImage GetImageFromCache(MapType type, Point pos, int zoom)
        {
            try
            {
                string fileName = GetFilename(type, pos, zoom, false);
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists && fi.LastWriteTimeUtc > _CacheDate)
                {
                    Image image = Image.FromFile(fileName);
                    WindowsFormsImage img = new WindowsFormsImage();
                    img.Img = image;
                    img.Data = new MemoryStream();
                    image.Save(img.Data, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.Debug.WriteLine(string.Format("{0} FilePureImageCache.GetImageFromCache(type={1}, pos={2}, zoom={3}, file date={4}) succeeded.", DateTime.Now, type, pos, zoom, fi.LastWriteTimeUtc));
                    return img;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("{0} FilePureImageCache.GetImageFromCache(type={1}, pos={2}, zoom={3}) NOT IN CACHE.", DateTime.Now, type, pos, zoom));
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in FilePureImageCache.GetImageFromCache:\r\n" + ex.ToString());
                return null;
            }
        }

        private string GetFilename(MapType type, Point pos, int zoom, bool createDirectory)
        {
            string path = Path.Combine(CacheLocation, type.ToString());
            path = Path.Combine(path, string.Format("Zoom{0:D2}", zoom));
            int x0 = pos.X / 100000;
            int x1 = pos.X / 100;
            path = Path.Combine(path, string.Format("X{0:D2}0000\\X{1:D4}00", x0, x1));
            int y0 = pos.Y / 100000;
            int y1 = pos.Y / 100;
            path = Path.Combine(path, string.Format("Y{0:D2}0000\\Y{1:D4}00", y0, y1));

            if (createDirectory)
                Directory.CreateDirectory(path);

            path = Path.Combine(path, string.Format("Tile_{0}_{1}.dat", pos.X, pos.Y));

            return path;
        }
    }
}
