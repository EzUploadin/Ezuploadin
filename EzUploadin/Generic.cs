using System;
using System.IO;

namespace EzUploadin
{
    internal class Settings
    {
        internal static string URL = "http://sys.ezupload.in";
        internal static string ServerName = "EzUploadin";
    }
    internal class Generic
    {
        internal static string CurDir = Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location);

        internal static string DatFile = CurDir + Path.DirectorySeparatorChar + "ezupload.dat";

        internal static string LogFile = CurDir + Path.DirectorySeparatorChar + "ezupload.log";

        internal static bool DataFileExists
        {
            get
            {
                return File.Exists(DatFile);
            }
            set{}
        }

    }

    internal class URLs
    {
        internal static string AUTH = "/auth.php";
    }

    class Info
    {
        public static string version = "0.1";
    }
}
