using System;
using System.Resources;

namespace GPX
{
    public class GPXAppResourceManager
    {
        private static ResourceManager _ResourceManager;
        public static ResourceManager ResourceManager
        {
            get
            {
                if (_ResourceManager == null)
                {
                    _ResourceManager = new ResourceManager("GPX.Properties.Resources",
                        System.Reflection.Assembly.GetAssembly(typeof(GPXAppResourceManager)));
                }
                return _ResourceManager;
            }
        }
    }
}
