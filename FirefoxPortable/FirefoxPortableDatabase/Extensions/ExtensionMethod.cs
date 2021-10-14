using FirefoxPortableDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase
{
    public static class ExtensionMethod
    {
        private static Random random = new Random();
        public static string RandomString(int length = 32)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static List<HardDrive> GetAllDiskDrives()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            List<HardDrive> hardDrives = new List<HardDrive>();
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] != null)
                {
                    HardDrive hd = new HardDrive();
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                    hardDrives.Add(hd);
                }
            }
            return hardDrives;
        }
    }
}
