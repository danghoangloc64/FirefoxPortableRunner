using DevExpress.XtraEditors;
using FirefoxPortableDatabase.BLL;
using FirefoxPortableDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefoxPortableAdmin.Views.QuanLyProfile
{
    public partial class QuanLyProfileCreateUpdateForm : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bIsEditing;
        private LinkDownloadProfileBLL m_objLinkDownloadProfileBLL;
        private LinkDownloadProfileCreateModel m_objLinkDownloadProfileCreateModel;
        public QuanLyProfileCreateUpdateForm()
        {
            InitializeComponent();
            m_bIsEditing = false;
            m_objLinkDownloadProfileBLL = new LinkDownloadProfileBLL();
            m_objLinkDownloadProfileCreateModel = new LinkDownloadProfileCreateModel();
            linkDownloadProfileCreateModelBindingSource.DataSource = m_objLinkDownloadProfileCreateModel;
        }

        public QuanLyProfileCreateUpdateForm(string strId)
        {
            InitializeComponent();
            m_bIsEditing = true;
            m_objLinkDownloadProfileBLL = new LinkDownloadProfileBLL();
            m_objLinkDownloadProfileCreateModel = m_objLinkDownloadProfileBLL.GetLinkDownloadProfileCreateModelById(strId);
            linkDownloadProfileCreateModelBindingSource.DataSource = m_objLinkDownloadProfileCreateModel;
        }

        public event EventHandler ButtonSaveClickEvent;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (m_objLinkDownloadProfileCreateModel.CheckValid() == false)
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string strUpdateResult;
            if (m_bIsEditing == false)
            {
                strUpdateResult = m_objLinkDownloadProfileBLL.Create(m_objLinkDownloadProfileCreateModel);
            }
            else
            {
                strUpdateResult = m_objLinkDownloadProfileBLL.Edit(m_objLinkDownloadProfileCreateModel);
            }

            if (string.IsNullOrWhiteSpace(strUpdateResult))
            {
                ButtonSaveClickEvent?.Invoke(null, null);
                Close();
            }
            else
            {
                XtraMessageBox.Show(strUpdateResult, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void QuanLyProfileCreateUpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}