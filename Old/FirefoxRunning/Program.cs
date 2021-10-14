using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefoxRunning
{
    static class Program
    {
        private static List<HardDrive> hardDrives = new List<HardDrive>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GetAllDiskDrives();

            if (ReadRegisterKey.CheckValidKey("FirefoxRunning", hardDrives) == false)
            {
                Application.Run(new RegisterApplication());
            }
            else
            {
                Application.Run(new SplashScreen());
            }
        }


        private static void GetAllDiskDrives()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

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
        }
    }
}
