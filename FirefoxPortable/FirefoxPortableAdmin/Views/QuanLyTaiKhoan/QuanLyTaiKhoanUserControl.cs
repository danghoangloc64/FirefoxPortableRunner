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

            RepositoryItemDateEdit repositoryItemDateTimeEdit = new RepositoryItemDateEdit();
            repositoryItemDateTimeEdit.NullDate = DateTime.MinValue;
            repositoryItemDateTimeEdit.NullText = string.Empty;
            repositoryItemDateTimeEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            repositoryItemDateTimeEdit.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            repositoryItemDateTimeEdit.Mask.UseMaskAsDisplayFormat = true;

            foreach (GridColumn objCol in gridView.Columns)
            {
                objCol.AppearanceHeader.BackColor = Color.FromArgb(50, 196, 255);
                objCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                objCol.AppearanceHeader.FontStyleDelta = FontStyle.Bold;

                if (objCol.Name.Contains("Date"))
                {
                    objCol.Width = 60;
                    objCol.ColumnEdit = repositoryItemDateEdit;
                    objCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                else if (objCol.Name.Contains("Ngay"))
                {
                    objCol.Width = 60;
                    objCol.ColumnEdit = repositoryItemDateTimeEdit;
                    objCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }
        }
    }
}
