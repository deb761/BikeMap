using System;
using System.Collections.Generic;
using System.Text;

namespace GPX
{
    public enum Direction
    {
        Latitude,
        Longitude
    }
    public class Degree
    {
        private double _Value;

        private Direction _Direction;
        public Direction Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }

        public Degree()
        {
            _Value = 0;
            _Direction = Direction.Latitude;
        }
        public Degree(Direction dir)
        {
            _Value = 0;
            _Direction = dir;
        }
        public Degree(double value)
        {
            _Value = value;
            _Direction = Direction.Latitude;
            CalculateDMS();
        }
        public Degree(double value, Direction dir)
        {
            _Value = value;
            _Direction = dir;
            CalculateDMS();
        }

        public Degree(int degrees, int minutes, float seconds, Direction dir)
        {
            _Degrees = degrees;
            _Minutes = minutes;
            _Seconds = seconds;
            double tmp = (double)minutes / 60.0 + (double)seconds / 3600.0;
            if (degrees < 0)
            {
                _Value = (double)(-(tmp - degrees));
            }
            else
            {
                _Value = (double)(tmp + degrees);
            }
            _Direction = dir;
        }

        public static implicit operator double(Degree deg)
        {
            return deg._Value;
        }
        public static implicit operator Degree(double d)
        {
            return new Degree(d);
        }
        public static implicit operator Degree(decimal d)
        {
            return new Degree((double)d);
        }
        public static bool operator >(Degree x, Degree y)
        {
            return x._Value > y._Value;
        }
        public static bool operator <(Degree x, Degree y)
        {
            return x._Value < y._Value;
        }
        public static bool operator >(Degree x, int y)
        {
            return x._Value > (double)y;
        }
        public static bool operator <(Degree x, int y)
        {
            return x._Value < (double)y;
        }
        public static bool operator ==(Degree x, Degree y)
        {
            return x._Value == y._Value;
        }
        public static bool operator !=(Degree x, Degree y)
        {
            return x._Value != y._Value;
        }
        public override bool Equals(object obj)
        {
            Degree y = obj as Degree;
            return this._Value == y._Value;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //public static Degree operator =(double d)
        //{
        //    return new Degree(d);
        //}

        //public static implicit operator decimal(Degree deg)
        //{
        //    return Convert.ToDecimal(deg._Value);
        //}

        public override string ToString()
        {
            return ToString("CDD°MM'SS\"");
        }
        public string ToString(string format)
        {
            if (format.StartsWith("C"))
            {
                string retVal = format.Substring(1);
                double tempVal = Math.Abs(_Value);
                retVal = retVal.Replace("DD", ((int)tempVal).ToString("D2"));
                tempVal = (tempVal - (int)tempVal) * 60;
                retVal = retVal.Replace("MM", ((int)tempVal).ToString("D2"));
                tempVal = (tempVal - (int)tempVal) * 60;
                retVal = retVal.Replace("SS", (tempVal).ToString("00.00"));
                if (_Value < 0)
                {
                    if (_Direction == Direction.Latitude)
                        retVal = retVal + " S";
                    else
                        retVal = retVal + " W";
                }
                else
                {
                    if (_Direction == Direction.Latitude)
                        retVal = retVal + " N";
                    else
                        retVal = retVal + " E";
                }
                return retVal;
            }
            else
            {
                //Double-Format
                return _Value.ToString(format);
            }
        }

        private void CalculateDMS()
        {
            double tmp = Math.Abs(_Value);
            _Degrees = (int)Math.Floor(tmp) * Math.Sign(_Value);
            tmp -= (double)Math.Floor(tmp);
            tmp *= 60.0;
            _Minutes = (int)Math.Floor(tmp);
            tmp -= (double)Math.Floor(tmp);
            _Seconds = (float)(60.0 * tmp);
        }

        private int _Degrees;
        private int _Minutes;
        private float _Seconds;
        public int Degrees
        {
            get { return _Degrees; }
        }

        public int Minutes
        {
            get { return _Minutes; }
        }

        public float Seconds
        {
            get { return _Seconds; }
        }
    }
}
