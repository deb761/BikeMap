using System;
using System.Configuration;

namespace Utilities
{
    public class Defaults
    {
        public static System.Drawing.Font Font
        {
            //get { return new System.Drawing.Font("Bitstream Vera Sans", 9); }
            get { return new System.Drawing.Font("Verdana", 9); }
        }

        public static string TempDir
        {
            get { return ConfigurationManager.AppSettings["TempDir"]; }
        }
    }
}
