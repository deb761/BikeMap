
namespace GMap.NET.Internals
{
    using System.Collections.Generic;

    /// <summary>
    /// matrix for tiles
    /// </summary>
    public class TileMatrix
    {
        readonly Dictionary<Point, Tile> matrix = new Dictionary<Point, Tile>(55);
        readonly List<Point> removals = new List<Point>();

        ////public bool GetExtension(ref System.Drawing.Rectangle rect)
        //public bool GetExtension(ref System.Drawing.Point TopLeft, ref System.Drawing.Point BottomRight) 
        //{
        //    if (matrix.Count == 0)
        //    {
        //        return false;
        //    }

        //    //how do I get the first key in a KeyCollection?
        //    foreach (Point p in matrix.Keys)
        //    {
        //        TopLeft = BottomRight = new System.Drawing.Point(p.X, p.Y);
        //        break;
        //    }
        //    foreach (Point p in matrix.Keys)
        //    {
        //        if (p.X < TopLeft.X)
        //            TopLeft.X = p.X;
        //        if (p.X > BottomRight.X)
        //            BottomRight.X = p.X;
        //        if (p.Y < TopLeft.Y)
        //            TopLeft.Y = p.Y;
        //        if (p.Y > BottomRight.Y)
        //            BottomRight.Y = p.Y;
        //    }
        //    return true;
        //}

        public void Clear()
        {
            lock (matrix)
            {
                foreach (Tile t in matrix.Values)
                {
                    t.Clear();
                }
                matrix.Clear();
            }
        }

        public void ClearPointsNotIn(ref PointListEx list)
        {
            removals.Clear();
            lock (matrix)
            {
                foreach (Point p in matrix.Keys)
                {
                    if (!list.Contains(p))
                    {
                        removals.Add(p);
                    }
                }
            }

            foreach (Point p in removals)
            {
                Tile t = this[p];
                if (t != null)
                {
                    lock (matrix)
                    {
                        t.Clear();
                        t = null;

                        matrix.Remove(p);
                    }
                }
            }
            removals.Clear();
        }

        public Tile this[Point p]
        {
            get
            {
                lock (matrix)
                {
                    Tile ret = null;
                    if (matrix.TryGetValue(p, out ret))
                    {
                        return ret;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            set
            {
                lock (matrix)
                {
                    matrix[p] = value;
                }
            }
        }
    }
}
