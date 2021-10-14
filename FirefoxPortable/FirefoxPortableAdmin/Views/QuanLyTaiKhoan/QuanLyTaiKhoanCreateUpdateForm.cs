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

namespace FirefoxPortableAdmin.Views.QuanLyTaiKhoan
{
    public partial class QuanLyTaiKhoanCreateUpdateForm : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bIsEditing;
        private TaiKhoanCreateModel m_objTaiKhoanCreateModel;
        private LinkDownloadProfileBLL m_objLinkDownloadProfileBLL;
        private TaiKhoanBLL m_objTaiKhoanBLL;
        private List<LinkDownloadProfileSearchModel> m_objLinkDownloadProfileSearchModel;
        public QuanLyTaiKhoanCreateUpdateForm()
        {
            InitializeComponent();

            m_objLinkDownloadProfileBLL = new LinkDownloadProfileBLL();
            m_objLinkDownloadProfileSearchModel = m_objLinkDownloadProfileBLL.GetListSearchModel();
            linkDownloadProfileSearchModelBindingSource.DataSource = m_objLinkDownloadProfileSearchModel;

            m_bIsEditing = false;
            m_objTaiKhoanBLL = new TaiKhoanBLL();
            m_objTaiKhoanCreateModel = new TaiKhoanCreateModel();
            taiKhoanCreateModelBindingSource.DataSource = m_objTaiKhoanCreateModel;

        }
        public QuanLyTaiKhoanCreateUpdateForm(string strId)
        {
            InitializeComponent();

            m_objLinkDownloadProfileBLL = new LinkDownloadProfileBLL();
            m_objLinkDownloadProfileSearchModel = m_objLinkDownloadProfileBLL.GetListSearchModel();
            linkDownloadProfileSearchModelBindingSource.DataSource = m_objLinkDownloadProfileSearchModel;

            m_bIsEditing = true;
            m_objTaiKhoanBLL = new TaiKhoanBLL();
            m_objTaiKhoanCreateModel = m_objTaiKhoanBLL.GetTaiKhoanCreateModelById(strId);
            taiKhoanCreateModelBindingSource.DataSource = m_objTaiKhoanCreateModel;

        }
        public event EventHandler ButtonSaveClickEvent;

        private void QuanLyTaiKhoanCreateUpdateForm_Load(object sender, EventArgs e)
        {
         
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(m_objTaiKhoanCreateModel.Key))
            {
                XtraMessageBox.Show("Vui lòng nhập key.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(m_objTaiKhoanCreateModel.TenLinkDownloadProfile))
            {
                XtraMessageBox.Show("Vui lòng nhập profile.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string strUpdateResult;
            if (m_bIsEditing == false)
            {
                strUpdateResult = m_objTaiKhoanBLL.Create(m_objTaiKhoanCreateModel);
            }
            else
            {
                strUpdateResult = m_objTaiKhoanBLL.Edit(m_objTaiKhoanCreateModel);
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

        private void TenLinkDownloadProfileSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TenLinkDownloadProfileSearchLookUpEdit.Text))
            {
                LinkLinkDownloadProfileTextEdit.Text = m_objLinkDownloadProfileSearchModel.FirstOrDefault(x => x.TenLinkDownloadProfile == TenLinkDownloadProfileSearchLookUpEdit.Text).LinkLinkDownloadProfile;
                m_objTaiKhoanCreateModel.LinkLinkDownloadProfile = LinkLinkDownloadProfileTextEdit.Text;
            }
            else
            {
                LinkLinkDownloadProfileTextEdit.Text = "";
                m_objTaiKhoanCreateModel.LinkLinkDownloadProfile = LinkLinkDownloadProfileTextEdit.Text;
            }
        }
    }
}