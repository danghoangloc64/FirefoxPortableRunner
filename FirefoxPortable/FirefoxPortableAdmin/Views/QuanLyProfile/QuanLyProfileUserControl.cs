using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using FirefoxPortableDatabase.BLL;
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
    public partial class QuanLyProfileUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private LinkDownloadProfileBLL m_objLinkDownloadProfileBLL;
        private QuanLyProfileCreateUpdateForm m_objQuanLyProfileCreateUpdateForm;
        public QuanLyProfileUserControl()
        {
            InitializeComponent();
        }

        private void QuanLyTaiKhoanUserControl_Load(object sender, EventArgs e)
        {
            m_objLinkDownloadProfileBLL = new LinkDownloadProfileBLL();

            gridControl.DataSource = m_objLinkDownloadProfileBLL.GetListLinkDownloadProfileViewModel();

            foreach (GridColumn objCol in gridView.Columns)
            {
                objCol.AppearanceHeader.BackColor = Color.FromArgb(50, 196, 255);
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.FontStyleDelta = FontStyle.Bold;
                if (objCol.Name == "colSTT")
                {
                    objCol.OptionsColumn.FixedWidth = true;
                    objCol.Width = 70;
                }
                else if (objCol.Name == "colTenLinkDownloadProfile")
                {
                    objCol.OptionsColumn.FixedWidth = true;
                    objCol.Width = 150;
                }
            }
            gridView.Columns[0].Visible = false;
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_objQuanLyProfileCreateUpdateForm = new QuanLyProfileCreateUpdateForm();
            m_objQuanLyProfileCreateUpdateForm.ButtonSaveClickEvent += ReceivedButtonSaveClickEvent;
            m_objQuanLyProfileCreateUpdateForm.ShowDialog();
        }

        void ReceivedButtonSaveClickEvent(object sender, EventArgs e)
        {
            gridControl.DataSource = m_objLinkDownloadProfileBLL.GetListLinkDownloadProfileViewModel();
        }

        private string GetSelectedId()
        {
            var arraySelectedRows = gridView.GetSelectedRows();
            if (arraySelectedRows == null || arraySelectedRows.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                int iSelectedRows = arraySelectedRows[0];
                return gridView.GetRowCellValue(iSelectedRows, "Id").ToString();
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strId = GetSelectedId();
            if (!string.IsNullOrWhiteSpace(strId))
            {
                m_objQuanLyProfileCreateUpdateForm = new QuanLyProfileCreateUpdateForm(strId);
                m_objQuanLyProfileCreateUpdateForm.ButtonSaveClickEvent += ReceivedButtonSaveClickEvent;
                m_objQuanLyProfileCreateUpdateForm.ShowDialog();
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strId = GetSelectedId();
            if (!string.IsNullOrWhiteSpace(strId))
            {
                if (XtraMessageBox.Show($"Dữ liệu sẽ bị xóa khỏi hệ thống. Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    if (m_objLinkDownloadProfileBLL.Delete(strId) == false)
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra.\r\nVui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        gridView.DeleteSelectedRows();
                    }
                }
            }
        }
    }
}
