using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Threading;

namespace FirefoxRunning
{
    public partial class RegisterApplication : Form
    {
        private const int SW_HIDE = 0;
        private string Key = "gPWoX4BZ";
        private List<HardDrive> hardDrives = new List<HardDrive>();

        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        private bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        public RegisterApplication()
        {
            GetAllDiskDrives();

            if (ReadRegisterKey.CheckValidKey("FirefoxRunning", hardDrives) == false)
            {

                if (!IsRunAsAdmin())
                {
                    {
                        ProcessStartInfo processStartInfo = new ProcessStartInfo();
                        processStartInfo.UseShellExecute = true;
                        processStartInfo.WorkingDirectory = Environment.CurrentDirectory;
                        processStartInfo.FileName = Assembly.GetEntryAssembly().CodeBase;
                        processStartInfo.Verb = "runas";
                        Process.Start(processStartInfo);
                        this.Close();
                    }
                }
                else
                {
                    InitializeComponent();
                    txtS.Text = CryptorEngine.Encrypt(hardDrives[0].SerialNo);
                }
            }
            else
            {
                string strTempPath = Path.GetTempPath();
                string folderFFTemp = Path.Combine(strTempPath, "xYcxw87zCL");
                //if (File.Exists(Path.Combine(folderFFTemp, "FirefoxPortable.exe")))
                //{
                //    string[] fileArray = Directory.GetFiles(folderFFTemp, "FirefoxPortable.exe", SearchOption.AllDirectories);
                //    if (fileArray.Length == 1)
                //    {
                //        System.Diagnostics.Process.Start(fileArray[0]);
                //    }
                //    Environment.Exit(0);
                //}

                if (File.Exists(Path.Combine("data", "leducchinh")))
                {
                    try
                    {
                        foreach (var process in Process.GetProcessesByName("firefox"))
                        {
                            process.Kill();
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        foreach (var process in Process.GetProcessesByName("FirefoxPortable"))
                        {
                            process.Kill();
                        }
                    }
                    catch
                    {

                    }

                    if (Directory.Exists(folderFFTemp))
                    {
                        DeleteDirectory(folderFFTemp);
                    }

                    Directory.CreateDirectory(folderFFTemp);

                    CopyFilesRecursively(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "data"), folderFFTemp);

                    DecryptFile(Path.Combine(folderFFTemp, "leducchinh"), Path.Combine(folderFFTemp, "FirefoxPortable.exe"));
                    File.Delete(Path.Combine(folderFFTemp, "leducchinh"));

                    string[] fileArray = Directory.GetFiles(folderFFTemp, "FirefoxPortable.exe", SearchOption.AllDirectories);
                    if (fileArray.Length == 1)
                    {
                        System.Diagnostics.Process.Start(fileArray[0]);
                    }
                    Environment.Exit(0);
                }
                Environment.Exit(0);
            }
        }

        private static void DeleteDirectory(string target_dir)
        {
            try
            {
                string[] files = Directory.GetFiles(target_dir);
                string[] dirs = Directory.GetDirectories(target_dir);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir);
                }

                Directory.Delete(target_dir, false);
            }
            catch
            {

            }
        }

        private void DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(Key);

                using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                {
                    RijndaelManaged RMCrypto = new RijndaelManaged();
                    using (CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read))
                    {

                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {

                            int data;
                            while ((data = cs.ReadByte()) != -1)
                            {
                                fsOut.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strKey = CryptorEngine.Decrypt(txtKey.Text.Trim());
            if (string.IsNullOrEmpty(strKey))
            {
                MessageBox.Show("Mã đăng ký không đúng. Xin vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strSerialNo = strKey.Substring(0, strKey.Length - 8);

            if (hardDrives.FirstOrDefault(x => x.SerialNo == strSerialNo) == null)
            {
                MessageBox.Show("Mã đăng ký không đúng. Xin vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.TryParseExact(strKey.Replace(strSerialNo, ""), "ddMMyyyy", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime dt) == false)
            {
                MessageBox.Show("Mã đăng ký không đúng. Xin vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReadRegisterKey.AddRegisterByKey("FirefoxRunning", txtKey.Text.Trim());
            MessageBox.Show("Đăng ký thành công. Xin vui lòng khởi động lại chương trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        private void GetAllDiskDrives()
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
