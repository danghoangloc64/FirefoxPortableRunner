using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using FirefoxPortableAdmin.Views.QuanLyProfile;
using FirefoxPortableAdmin.Views.QuanLyTaiKhoan;
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

namespace FirefoxPortableAdmin
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private TaiKhoanBLL m_objTaiKhoanBLL;
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddTab(string x_strTabName, UserControl x_objUserControl)
        {
            foreach (DevExpress.XtraTab.XtraTabPage objTab in xtraTabControl.TabPages)
            {
                if (objTab.Text == x_strTabName)
                {
                    xtraTabControl.SelectedTabPage = objTab;
                    return;
                }
            }

            DevExpress.XtraTab.XtraTabPage objNewTab = new DevExpress.XtraTab.XtraTabPage();
            objNewTab.Name = x_strTabName;
            objNewTab.Text = x_strTabName;
            objNewTab.Controls.Add(x_objUserControl);
            x_objUserControl.Dock = DockStyle.Fill;
            xtraTabControl.TabPages.Add(objNewTab);
            xtraTabControl.SelectedTabPage = objNewTab;
        }

        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl.TabPages.RemoveAt(xtraTabControl.SelectedTabPageIndex);
        }

        private void btnTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(ProgressForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            AddTab("Quản lý tài khoản", new QuanLyTaiKhoanUserControl());
            SplashScreenManager.CloseForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_objTaiKhoanBLL = new TaiKhoanBLL();
            m_objTaiKhoanBLL.FirstLoadFirefoxPortableDatabaseContext();
        }

        private void btnProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
    SplashScreenManager.ShowForm(this, typeof(ProgressForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Xin vui lòng chờ...");
            AddTab("Quản lý profile", new QuanLyProfileUserControl());
            SplashScreenManager.CloseForm();
        }
    }
}