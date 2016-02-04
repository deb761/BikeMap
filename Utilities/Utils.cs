using System;
using System.IO;
using System.Windows.Forms;

namespace Utilities
{
    public class Utils
    {
        public static void HandleException(Exception exc)
        {
            LogException(exc);
            string message = string.Empty;
            while (exc != null)
            {
                message += exc.Message + "\r\n";
                message += exc.StackTrace + "\r\n";
                message += "====================================================\r\n";

                exc = exc.InnerException;
            }
            MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void LogException(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToLongTimeString() + " \t " + ex.ToString());
        }

        private static string Alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string GetExcelCellName(int Row, int Column)
        {
            string result = null;
            if (Column > 26)
            {
                int i = Column / 26;
                int j = Column - 26 * i;
                result = Alphabet[i].ToString();
                result += Alphabet[j];
            }
            else
            {
                result = Alphabet[Column].ToString();
            }

            result += Row.ToString();

            return result;
        }

        public static void SetFileDate(string filename, DateTime date)
        {
            FileInfo fi = new FileInfo(filename);
            fi.CreationTimeUtc = date;
            fi.LastAccessTimeUtc = date;
            fi.LastWriteTimeUtc = date;
        }
    }
}
