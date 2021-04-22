﻿using System;
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


        public RegisterApplication()
        {
            GetAllDiskDrives();

            if (ReadRegisterKey.CheckValidKey("FirefoxRunning", hardDrives) == false)
            {

                if (!IsRunAsAdmin())
                {
                    DialogResult messageBoxResult = MessageBox.Show("Phần mềm chưa được đăng ký. Vui lòng đăng ký trước khi sử dụng.", "Thông báo", MessageBoxButtons.YesNo);
                    if (messageBoxResult == DialogResult.Yes)
                    {
                        ProcessStartInfo processStartInfo = new ProcessStartInfo();
                        processStartInfo.UseShellExecute = true;
                        processStartInfo.WorkingDirectory = Environment.CurrentDirectory;
                        processStartInfo.FileName = Assembly.GetEntryAssembly().CodeBase;
                        processStartInfo.Verb = "runas";
                        Process.Start(processStartInfo);
                        this.Close();
                    }
                    else
                    {
                        Close();
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
                if (File.Exists(Path.Combine("data", "leducchinh")))
                {
                    foreach (var process in Process.GetProcessesByName("firefox"))
                    {
                        process.Kill();
                    }

                    string strTempPath = Path.GetTempPath();
                    string encryptFile = Path.Combine(strTempPath, "leducchinh");
                    if (File.Exists(encryptFile))
                    {
                        File.Delete(encryptFile);
                    }
                    DecryptFile(Path.Combine("data", "leducchinh"), encryptFile);

                    string exePath = Path.Combine(strTempPath, "7ZtjAiWg");

                    if (Directory.Exists(exePath))
                    {
                        DeleteDirectory(exePath);
                    }

                    ZipFile.ExtractToDirectory(encryptFile, exePath);
                    string[] fileArray = Directory.GetFiles(exePath, "FirefoxPortable.exe", SearchOption.AllDirectories);
                    if (fileArray.Length == 1)
                    {
                        System.Diagnostics.Process.Start(fileArray[0]);
                    }
                }
                Environment.Exit(0);
            }
        }

        private static void DeleteDirectory(string target_dir)
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