using System;
using System.Text;
using System.Management;
using System.Security.Cryptography;

namespace EzUploadin
{
    class Security
    {
        internal static string HashPassword(string plain)
        {
            byte[] bytes1 = Encoding.Default.GetBytes(plain);
            byte[] bround1 = new SHA512CryptoServiceProvider().ComputeHash(bytes1);
            string round1 = Encoding.Default.GetString(bround1);
            byte[] bytes2 = Encoding.Default.GetBytes(round1+round1);
            byte[] bround2 = new SHA512CryptoServiceProvider().ComputeHash(bytes2);
            return ByteArrayToString(bround2);
        }

        internal static string CPUinfo()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
}
