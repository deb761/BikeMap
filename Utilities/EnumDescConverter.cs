//Source:
//http://www.codeproject.com/KB/cs/enumdescconverter.aspx

/*****************************************************************
 * Module: EnumDescConverter.cs
 * Type: C# Source Code
 * Version: 1.0
 * Description: Enum Converter using Description Attributes
 * 
 * Revisions
 * ------------------------------------------------
 * [F] 24/02/2004, Jcl - Shaping up
 * [B] 25/02/2004, Jcl - Made it much easier :-)
 * Bernhard Hiller, somewhen in 2009: integrated use of resx files
 *****************************************************************/
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Utilities
{
    /// <summary>
    /// EnumConverter supporting System.ComponentModel.DescriptionAttribute
    /// </summary>
    public class EnumDescConverter : System.ComponentModel.EnumConverter
    {
        protected System.Type myVal;

        /// <summary>
        /// Gets Enum Value's Description Attribute
        /// </summary>
        /// <param name="value">The value you want the description attribute for</param>
        /// <returns>The description, if any, else it's .ToString()</returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes(
              typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static string GetEnumDescription(ResourceManager rm, CultureInfo ci, Enum value)
        {
            if (rm == null)
                return GetEnumDescription(value);
            if (ci == null)
                ci = System.Threading.Thread.CurrentThread.CurrentUICulture;

            string resName = CreateResourceName(value);
            string retVal = rm.GetString(resName, ci);
            if (string.IsNullOrEmpty(retVal))
                retVal = GetEnumDescription(value);
            return retVal;
        }

        private static string CreateResourceName(Enum value)
        {
            Type enumType = value.GetType();
            string key = enumType.Namespace.Replace(".", "_") + "_" + enumType.Name + "_" + value.ToString();
            return key;
        }

        /// <summary>
        /// Gets the description for certaing named value in an Enumeration
        /// </summary>
        /// <param name="value">The type of the Enumeration</param>
        /// <param name="name">The name of the Enumeration value</param>
        /// <returns>The description, if any, else the passed name</returns>
        public static string GetEnumDescription(System.Type value, string name)
        {
            FieldInfo fi = value.GetField(name);
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes(
              typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : name;
        }

        /// <summary>
        /// Gets the value of an Enum, based on it's Description Attribute or named value
        /// </summary>
        /// <param name="value">The Enum type</param>
        /// <param name="description">The description or name of the element</param>
        /// <returns>The value, or the passed in description, if it was not found</returns>
        public static Enum GetEnumValue(Type enumType, string description)
        {
            FieldInfo[] fis = enumType.GetFields();
            foreach (FieldInfo fi in fis)
            {
                DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    if (attributes[0].Description == description)
                    {
                        return (Enum)fi.GetValue(fi.Name);
                    }
                }
                if (fi.Name == description)
                {
                    return (Enum)fi.GetValue(fi.Name);
                }
            }
            throw new InvalidEnumArgumentException(description, -1, enumType);
        }

        public static Enum GetEnumValue(ResourceManager rm, CultureInfo ci, Type enumType, string description)
        {
            if (rm == null)
                return GetEnumValue(enumType, description);

            if (ci == null)
                ci = System.Threading.Thread.CurrentThread.CurrentUICulture;


            foreach (Enum val in Enum.GetValues(enumType))
            {
                string tmp = GetEnumDescription(rm, ci, val);
                if (tmp == description)
                    return val;
            }

            //found nothing => without resx
            return GetEnumValue(enumType, description);
        }

        public EnumDescConverter(System.Type type)
            : base(type.GetType())
        {
            myVal = type;
        }
    }
}