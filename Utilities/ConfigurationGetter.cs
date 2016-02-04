using System;

namespace Utilities
{
    public class ConfigurationGetter
    {
        public static string GetString(string name)
        {
            string retVal = System.Configuration.ConfigurationManager.AppSettings[name];
            return retVal;
        }
        public static string GetString(string name, string defaultValue)
        {
            string retVal = GetString(name);
            if (retVal == null)
            {
                retVal = defaultValue;
            }
            return retVal;
        }

        public static Enum GetEnum(Type enumType, string name, Enum defaultValue)
        {
            string val = GetString(name);
            Enum retVal = defaultValue;
            if (!string.IsNullOrEmpty(val))
            {
                retVal = EnumDescConverter.GetEnumValue(enumType, val);
            }
            return retVal;
        }

        public static bool GetBool(string name, bool defaultValue)
        {
            string val = GetString(name);
            bool retVal = defaultValue;
            if (!string.IsNullOrEmpty(val))
            {
                retVal = bool.Parse(val);
            }
            return retVal;
        }

        public static int GetInt(string name, int defaultValue)
        {
            string val = GetString(name);
            int retVal = defaultValue;
            if (!string.IsNullOrEmpty(val))
            {
                retVal = int.Parse(val);
            }
            return retVal;
        }
    }
}
