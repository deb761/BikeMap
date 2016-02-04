using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Utilities
{
    public class Localizer
    {
        public static void LocalizeControl(Control control, ResourceManager resourceManager)
        {
            if ((resourceManager == null) || (control == null))
                return;

            string text = null;
            //Text of Control proper
            try
            {
                text = resourceManager.GetString(control.GetType().Namespace.Replace(".", "_") + "_" + control.GetType().Name + "_Text");
                if (!string.IsNullOrEmpty(text))
                    control.Text = text;
            }
            catch (System.Resources.MissingManifestResourceException)
            {
                //just ignore
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error when localizing: " + control.Name + ":\r\n" + ex.ToString());
            }

            //the Controls owned by this control
            FieldInfo[] fis = control.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo fi in fis)
            {
                LocalizeField(control, resourceManager, fi, "Text");
                LocalizeField(control, resourceManager, fi, "Caption");
            }
        }

        private static void LocalizeField(Control control, ResourceManager resourceManager, FieldInfo fi, string propertyName)
        {
            MemberInfo[] mia = fi.FieldType.GetMember(propertyName);
            if (mia.GetLength(0) > 0)
            {
                try
                {
                    string resourceName = control.GetType().Namespace.Replace(".", "_") + "_" + control.GetType().Name + "_" + fi.Name + "_" + propertyName;
                    string localizedText = resourceManager.GetString(resourceName);
                    if (localizedText == null)
                    {
                    }
                    else if (!string.IsNullOrEmpty(localizedText))
                    {
                        Object o = fi.GetValue(control);
                        if (o != null)
                        {
                            PropertyInfo pi = o.GetType().GetProperty(propertyName);
                            if (pi != null)
                            {
                                pi.SetValue(o, localizedText, null);
                            }
                        }
                    }
                }
                catch (System.Resources.MissingManifestResourceException)
                {
                    //just ignore
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error when localizing: " + fi.Name + ":\r\n" + ex.ToString());
                }
            }
        }

        public static bool SetCulture()
        {
            return SetCulture(null, System.Threading.Thread.CurrentThread);
        }

        public static bool SetCulture(string uiOption)
        {
            return SetCulture(uiOption, System.Threading.Thread.CurrentThread);
        }

        public static bool SetCulture(string uiOption, System.Threading.Thread thread)
        {
            bool cultureSet = false;
            //try the value given in uiOption first
            if (!string.IsNullOrEmpty(uiOption))
            {
                if (uiOption.Trim() != string.Empty)
                {
                    try
                    {
                        thread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(uiOption);
                        cultureSet = true;
                    }
                    catch (Exception) { }
                }
            }

            //then try a value from the .exe.config
            if (!cultureSet)
            {
                try
                {
                    string uiLanguage = System.Configuration.ConfigurationManager.AppSettings["UILanguage"];
                    if (!string.IsNullOrEmpty(uiLanguage))
                    {
                        thread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(uiLanguage);
                        cultureSet = true;
                    }
                }
                catch (Exception) { }
            }

            return cultureSet;
        }
    }
}
