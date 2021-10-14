
namespace FirefoxPortableAdmin.Views.QuanLyProfile
{
    partial class QuanLyProfileCreateUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.TenLinkDownloadProfileTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForTenLinkDownloadProfile = new DevExpress.XtraLayout.LayoutControlItem();
            this.LinkLinkDownloadProfileTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForLinkLinkDownloadProfile = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.linkDownloadProfileCreateModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenLinkDownloadProfileTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTenLinkDownloadProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkLinkDownloadProfileTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLinkLinkDownloadProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDownloadProfileCreateModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnClose);
            this.dataLayoutControl1.Controls.Add(this.btnLuu);
            this.dataLayoutControl1.Controls.Add(this.TenLinkDownloadProfileTextEdit);
            this.dataLayoutControl1.Controls.Add(this.LinkLinkDownloadProfileTextEdit);
            this.dataLayoutControl1.DataSource = this.linkDownloadProfileCreateModelBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(469, 108);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(469, 108);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTenLinkDownloadProfile,
            this.ItemForLinkLinkDownloadProfile,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(449, 88);
            // 
            // TenLinkDownloadProfileTextEdit
            // 
            this.TenLinkDownloadProfileTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.linkDownloadProfileCreateModelBindingSource, "TenLinkDownloadProfile", true));
            this.TenLinkDownloadProfileTextEdit.Location = new System.Drawing.Point(75, 12);
            this.TenLinkDownloadProfileTextEdit.Name = "TenLinkDownloadProfileTextEdit";
            this.TenLinkDownloadProfileTextEdit.Size = new System.Drawing.Size(382, 20);
            this.TenLinkDownloadProfileTextEdit.StyleController = this.dataLayoutControl1;
            this.TenLinkDownloadProfileTextEdit.TabIndex = 4;
            // 
            // ItemForTenLinkDownloadProfile
            // 
            this.ItemForTenLinkDownloadProfile.Control = this.TenLinkDownloadProfileTextEdit;
            this.ItemForTenLinkDownloadProfile.Location = new System.Drawing.Point(0, 0);
            this.ItemForTenLinkDownloadProfile.Name = "ItemForTenLinkDownloadProfile";
            this.ItemForTenLinkDownloadProfile.Size = new System.Drawing.Size(449, 24);
            this.ItemForTenLinkDownloadProfile.Text = "Tên profile";
            this.ItemForTenLinkDownloadProfile.TextSize = new System.Drawing.Size(51, 13);
            // 
            // LinkLinkDownloadProfileTextEdit
            // 
            this.LinkLinkDownloadProfileTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.linkDownloadProfileCreateModelBindingSource, "LinkLinkDownloadProfile", true));
            this.LinkLinkDownloadProfileTextEdit.Location = new System.Drawing.Point(75, 36);
            this.LinkLinkDownloadProfileTextEdit.Name = "LinkLinkDownloadProfileTextEdit";
            this.LinkLinkDownloadProfileTextEdit.Size = new System.Drawing.Size(382, 20);
            this.LinkLinkDownloadProfileTextEdit.StyleController = this.dataLayoutControl1;
            this.LinkLinkDownloadProfileTextEdit.TabIndex = 5;
            // 
            // ItemForLinkLinkDownloadProfile
            // 
            this.ItemForLinkLinkDownloadProfile.Control = this.LinkLinkDownloadProfileTextEdit;
            this.ItemForLinkLinkDownloadProfile.Location = new System.Drawing.Point(0, 24);
            this.ItemForLinkLinkDownloadProfile.Name = "ItemForLinkLinkDownloadProfile";
            this.ItemForLinkLinkDownloadProfile.Size = new System.Drawing.Size(449, 24);
            this.ItemForLinkLinkDownloadProfile.Text = "Link profile";
            this.ItemForLinkLinkDownloadProfile.TextSize = new System.Drawing.Size(51, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(449, 14);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(272, 74);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(91, 22);
            this.btnLuu.StyleController = this.dataLayoutControl1;
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnLuu;
            this.layoutControlItem1.Location = new System.Drawing.Point(260, 62);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(95, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(367, 74);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 22);
            this.btnClose.StyleController = this.dataLayoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Thoát";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnClose;
            this.layoutControlItem2.Location = new System.Drawing.Point(355, 62);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 62);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(260, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // linkDownloadProfileCreateModelBindingSource
            // 
            this.linkDownloadProfileCreateModelBindingSource.DataSource = typeof(FirefoxPortableDatabase.Models.LinkDownloadProfileCreateModel);
            // 
            // QuanLyProfileCreateUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 108);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuanLyProfileCreateUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm/Sửa profile";
            this.Load += new System.EventHandler(this.QuanLyProfileCreateUpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenLinkDownloadProfileTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTenLinkDownloadProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkLinkDownloadProfileTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLinkLinkDownloadProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDownloadProfileCreateModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit TenLinkDownloadProfileTextEdit;
        private System.Windows.Forms.BindingSource linkDownloadProfileCreateModelBindingSource;
        private DevExpress.XtraEditors.TextEdit LinkLinkDownloadProfileTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTenLinkDownloadProfile;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLinkLinkDownloadProfile;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}