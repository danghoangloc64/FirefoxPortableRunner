using System.Collections.Generic;
using System.Management;

namespace Phim4K
{
    public class HardDrive
    {
        public string Model { get; set; }
        public string InterfaceType { get; set; }
        public string Caption { get; set; }
        public string SerialNo { get; set; }
    }

    public static class HardDriveFunction
    {
        public static List<HardDrive> GetAllDiskDrives()
        {
            List<HardDrive> hardDrives = new List<HardDrive>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
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
