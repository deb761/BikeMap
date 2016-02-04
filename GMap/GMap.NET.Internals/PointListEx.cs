using System;
using System.Collections.Generic;

namespace GMap.NET.Internals
{
    public class PointListEx : List<GMap.NET.Point>, IList<GMap.NET.Point>
    {
        public bool GetExtension(ref System.Drawing.Point TopLeft, ref System.Drawing.Point BottomRight)
        {
            if (this.Count == 0)
            {
                return false;
            }

            //how do I get the first key in a KeyCollection?
            foreach (Point p in this)
            {
                TopLeft = BottomRight = new System.Drawing.Point(p.X, p.Y);
                break;
            }
            foreach (Point p in this)
            {
                if (p.X < TopLeft.X)
                    TopLeft.X = p.X;
                if (p.X > BottomRight.X)
                    BottomRight.X = p.X;
                if (p.Y < TopLeft.Y)
                    TopLeft.Y = p.Y;
                if (p.Y > BottomRight.Y)
                    BottomRight.Y = p.Y;
            }
            return true;
        }
    }
}
