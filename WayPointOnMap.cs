using System;
using System.Collections.Generic;
using System.Text;

namespace GPX
{
    internal class WayPointOnMap
    {
        #region Variables and Properties
        private WayPoint _WayPoint;
        public WayPoint WayPoint
        {
            get { return _WayPoint; }
            set { _WayPoint = value; }
        }

        private double _XValue;
        public double XValue
        {
            get { return _XValue; }
            set { _XValue = value; }
        }

        private double _YValue;
        public double YValue
        {
            get { return _YValue; }
            set { _YValue = value; }
        }

        private int _XPixels;
        public int XPixels
        {
            get { return _XPixels; }
            set { _XPixels = value; }
        }

        private int _YPixels;
        public int YPixels
        {
            get { return _YPixels; }
            set { _YPixels = value; }
        }

        private bool _IsHighlighted;
        public bool IsHighlighted
        {
            get { return _IsHighlighted; }
            set { _IsHighlighted = value; }
        }

        private bool _IsHidden;
        public bool IsHidden
        {
            get { return _IsHidden; }
            set { _IsHidden = value; }
        }
        #endregion Variables and Properties

        public WayPointOnMap(WayPoint wp)
        {
            _WayPoint = wp;
            _IsHidden = false;
            _IsHighlighted = false;
        }

        public bool IsInBounds(int XMin, int YMin, int XMax, int YMax)
        {
            if (_XPixels >= XMin)
                if (_XPixels <= XMax)
                    if (_YPixels >= YMin)
                        if (_YPixels <= YMax)
                            return true;
            return false;
        }
    }
}
