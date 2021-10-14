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

namespace FirefoxPortableAdmin.Views.QuanLyTaiKhoan
{
    public partial class QuanLyTaiKhoanUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyTaiKhoanCreateUpdateForm m_objQuanLyTaiKhoanCreateUpdateForm;
        private TaiKhoanBLL m_objTaiKhoanBLL;
        public QuanLyTaiKhoanUserControl()
        {
            InitializeComponent();
        }

        private void QuanLyTaiKhoanUserControl_Load(object sender, EventArgs e)
        {
            m_objTaiKhoanBLL = new TaiKhoanBLL();

            gridControl.DataSource = m_objTaiKhoanBLL.GetListTaiKhoanViewModel();

            RepositoryItemDateEdit repositoryItemDateEdit = new RepositoryItemDateEdit();
            repositoryItemDateEdit.NullDate = DateTime.MinValue;
            repositoryItemDateEdit.NullText = string.Empty;
            repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateEdit.Mask.EditMask = "dd/MM/yyyy";
            repositoryItemDateEdit.Mask.UseMaskAsDisplayFormat = true;

            foreach (GridColumn objCol in gridView.Columns)
            {
                objCol.AppearanceHeader.BackColor = Color.FromArgb(50, 196, 255);
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.FontStyleDelta = FontStyle.Bold;

                if (objCol.Name.Contains("Date") || objCol.Name.Contains("Ngay"))
                {
                    objCol.OptionsColumn.FixedWidth = true;
                    objCol.Width = 100;
                    objCol.ColumnEdit = repositoryItemDateEdit;
                    objCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                else if (objCol.Name == "colSTT")
                {
                    objCol.OptionsColumn.FixedWidth = true;
                    objCol.Width = 70;
                }
                else if (objCol.Name.Contains("Actived"))
                {
                    objCol.OptionsColumn.FixedWidth = true;
                    objCol.Width = 100;
                }
                else if (objCol.Name.Contains("TenLinkDownloadProfile"))
                {
                    objCol.OptionsColumn.FixedWidth = true;
                    objCol.Width = 300;
                }
                gridView.Columns[0].Visible = false;
                gridView.Columns[5].Visible = false;
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_objQuanLyTaiKhoanCreateUpdateForm = new QuanLyTaiKhoanCreateUpdateForm();
            m_objQuanLyTaiKhoanCreateUpdateForm.ButtonSaveClickEvent += ReceivedButtonSaveClickEvent;
            m_objQuanLyTaiKhoanCreateUpdateForm.ShowDialog();
        }

        void ReceivedButtonSaveClickEvent(object sender, EventArgs e)
        {
            gridControl.DataSource = m_objTaiKhoanBLL.GetListTaiKhoanViewModel();
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
                m_objQuanLyTaiKhoanCreateUpdateForm = new QuanLyTaiKhoanCreateUpdateForm(strId);
                m_objQuanLyTaiKhoanCreateUpdateForm.ButtonSaveClickEvent += ReceivedButtonSaveClickEvent;
                m_objQuanLyTaiKhoanCreateUpdateForm.ShowDialog();
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strId = GetSelectedId();
            if (!string.IsNullOrWhiteSpace(strId))
            {
                if (XtraMessageBox.Show($"Dữ liệu sẽ bị xóa khỏi hệ thống. Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    if (m_objTaiKhoanBLL.Delete(strId) == false)
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
