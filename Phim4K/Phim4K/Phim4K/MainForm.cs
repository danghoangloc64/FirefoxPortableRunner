using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phim4K
{
    public partial class MainForm : Form
    {
        private List<HardDrive> hardDrives = new List<HardDrive>();
        private bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public MainForm()
        {
            hardDrives = HardDriveFunction.GetAllDiskDrives();

            if (ReadRegisterKey.CheckValidKey("Phim4K", hardDrives) == false)
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
                    txtSerialNo.Text = CryptorEngine.Encrypt(hardDrives[0].SerialNo);
                }
            }
            else
            {
                string[] files = System.IO.Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Data"), "*.exe");
                foreach (var file in files)
                {
                    if (!Path.GetFileName(file).Contains("Phim4K.exe"))
                    {

                        FileSecurity fs = File.GetAccessControl(file);

                        // add the new rule to the existing settings
                        fs.RemoveAccessRule(new FileSystemAccessRule(
                            Environment.UserName,
                            FileSystemRights.FullControl,
                            AccessControlType.Deny));
                        File.SetAccessControl(file, fs);

                        fs = File.GetAccessControl(file);
                        // add the new rule to the existing settings
                        fs.AddAccessRule(new FileSystemAccessRule(
                            Environment.UserName,
                            FileSystemRights.FullControl,
                            AccessControlType.Allow));
                        File.SetAccessControl(file, fs);

                        fs = File.GetAccessControl(file);
                        // add the new rule to the existing settings
                        fs.RemoveAccessRule(new FileSystemAccessRule(
                            Environment.UserName,
                            FileSystemRights.Read,
                            AccessControlType.Deny));
                        File.SetAccessControl(file, fs);


                        //    fs.RemoveAccessRule(new FileSystemAccessRule(
                        //Environment.UserName,
                        //FileSystemRights.Delete,
                        //AccessControlType.Deny));

                        // set the updated access controls

                        System.Diagnostics.Process.Start(file);

                        Thread.Sleep(15000);

                        fs = File.GetAccessControl(file);
                        // add the new rule to the existing settings
                        fs.AddAccessRule(new FileSystemAccessRule(
                            Environment.UserName,
                            FileSystemRights.Read,
                            AccessControlType.Deny));
                        File.SetAccessControl(file, fs);


                        //fs.RemoveAccessRule(new FileSystemAccessRule(
                        //Environment.UserName,
                        //FileSystemRights.Delete,
                        //AccessControlType.Deny));

                        // set the updated access controls

                    }
                }
                ExitApp();
            }
        }

        private void ExitApp()
        {
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //hardDrives = HardDriveFunction.GetAllDiskDrives();
            //if (hardDrives.Count == 0)
            //{
            //    MessageBox.Show("Có lỗi xảy ra.\r\nVui lòng thử lại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    ExitApp();
            //}
            //else
            //{
            //    txtSerialNo.Text = CryptorEngine.Encrypt(hardDrives[0].SerialNo);
            //}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strKey = CryptorEngine.Decrypt(txtKey.Text.Trim());
            if (string.IsNullOrEmpty(strKey))
            {
                MessageBox.Show("Mã đăng ký không đúng.\r\nXin vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strSerialNo = strKey.Substring(0, strKey.Length - 8);

            if (hardDrives.FirstOrDefault(x => x.SerialNo == strSerialNo) == null)
            {
                MessageBox.Show("Mã đăng ký không đúng.\r\nXin vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.TryParseExact(strKey.Replace(strSerialNo, ""), "ddMMyyyy", CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out DateTime dt) == false)
            {
                MessageBox.Show("Mã đăng ký không đúng.\r\nXin vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReadRegisterKey.AddRegisterByKey("Phim4K", txtKey.Text.Trim());
            MessageBox.Show("Đăng ký thành công.\r\nXin vui lòng khởi động lại chương trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExitApp();
        }
    }
}
