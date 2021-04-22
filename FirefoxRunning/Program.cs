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
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                hd.Model = wmi_HD["Model"].ToString();
                hd.InterfaceType = wmi_HD["InterfaceType"].ToString();
                hd.Caption = wmi_HD["Caption"].ToString();

                hd.SerialNo = wmi_HD.GetPropertyValue("SerialNumber").ToString();//get the serailNumber of diskdrive

                hardDrives.Add(hd);
            }

        }
    }
}
