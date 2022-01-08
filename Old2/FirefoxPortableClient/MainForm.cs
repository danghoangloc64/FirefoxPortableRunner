using FirefoxPortableDatabase.BLL;
using FirefoxPortableDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace FirefoxPortableClient
{
    public partial class MainForm : Form
    {
        private TaiKhoanBLL m_objTaiKhoanBLL;
        private List<HardDrive> m_objHardDrives = new List<HardDrive>();

        public MainForm(List<HardDrive> hardDrives)
        {
            m_objHardDrives = hardDrives;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ClientInformationModel clientInformationModel = m_objTaiKhoanBLL.GetClientInformationModel(txtKey.Text, m_objHardDrives[0].SerialNo);
            if (clientInformationModel == null)
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng liên hệ nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                    DownloadForm downloadForm = new DownloadForm(clientInformationModel, true);
                    this.Hide();
                    downloadForm.Show();
                }
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_objTaiKhoanBLL = new TaiKhoanBLL();
        }
    }
}
