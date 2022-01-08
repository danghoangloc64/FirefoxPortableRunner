using FirefoxPortableDatabase;
using FirefoxPortableDatabase.BLL;
using FirefoxPortableDatabase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefoxPortableClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
            //    var chromeDriverProcesses = Process.GetProcesses().Where(pr => pr.ProcessName.ToLower().Contains("firefoxportable"));
            //    foreach (var process in chromeDriverProcesses)
            //    {
            //        process.Kill();
            //    }
            //}
            //catch
            //{

            //}


            List<HardDrive> hardDrives = ExtensionMethod.GetAllDiskDrives();
            TaiKhoanBLL objTaiKhoanBLL = new TaiKhoanBLL();
            ClientInformationModel clientInformationModel = objTaiKhoanBLL.GetClientInformationModelBySerialNo(hardDrives[0].SerialNo);
            if (clientInformationModel == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(hardDrives));
            }
            else
            {
                if (string.IsNullOrWhiteSpace(clientInformationModel.LinkLinkDownloadProfile))
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng liên hệ nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new DownloadForm(clientInformationModel));
                }
            }
        }
    }
}
