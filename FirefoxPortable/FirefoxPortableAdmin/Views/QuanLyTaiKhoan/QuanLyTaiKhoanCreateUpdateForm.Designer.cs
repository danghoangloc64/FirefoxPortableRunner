
namespace FirefoxPortableAdmin.Views.QuanLyTaiKhoan
{
    partial class QuanLyTaiKhoanCreateUpdateForm
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
            this.KeyTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ActivedCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.NgayHetHanDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.TenLinkDownloadProfileSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LinkLinkDownloadProfileTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForKey = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNgayHetHan = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTenLinkDownloadProfile = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLinkLinkDownloadProfile = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForActived = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.taiKhoanCreateModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.linkDownloadProfileSearchModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivedCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayHetHanDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayHetHanDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenLinkDownloadProfileSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkLinkDownloadProfileTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNgayHetHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTenLinkDownloadProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLinkLinkDownloadProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanCreateModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDownloadProfileSearchModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnThoat);
            this.dataLayoutControl1.Controls.Add(this.btnLuu);
            this.dataLayoutControl1.Controls.Add(this.KeyTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ActivedCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.NgayHetHanDateEdit);
            this.dataLayoutControl1.Controls.Add(this.TenLinkDownloadProfileSearchLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.LinkLinkDownloadProfileTextEdit);
            this.dataLayoutControl1.DataSource = this.taiKhoanCreateModelBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(380, 194);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // KeyTextEdit
            // 
            this.KeyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taiKhoanCreateModelBindingSource, "Key", true));
            this.KeyTextEdit.Location = new System.Drawing.Point(89, 12);
            this.KeyTextEdit.Name = "KeyTextEdit";
            this.KeyTextEdit.Size = new System.Drawing.Size(139, 20);
            this.KeyTextEdit.StyleController = this.dataLayoutControl1;
            this.KeyTextEdit.TabIndex = 4;
            // 
            // ActivedCheckEdit
            // 
            this.ActivedCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taiKhoanCreateModelBindingSource, "Actived", true));
            this.ActivedCheckEdit.Location = new System.Drawing.Point(232, 12);
            this.ActivedCheckEdit.Name = "ActivedCheckEdit";
            this.ActivedCheckEdit.Properties.Caption = "Kích hoạt";
            this.ActivedCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.ActivedCheckEdit.Size = new System.Drawing.Size(136, 20);
            this.ActivedCheckEdit.StyleController = this.dataLayoutControl1;
            this.ActivedCheckEdit.TabIndex = 5;
            // 
            // NgayHetHanDateEdit
            // 
            this.NgayHetHanDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taiKhoanCreateModelBindingSource, "NgayHetHan", true));
            this.NgayHetHanDateEdit.EditValue = null;
            this.NgayHetHanDateEdit.Location = new System.Drawing.Point(89, 36);
            this.NgayHetHanDateEdit.Name = "NgayHetHanDateEdit";
            this.NgayHetHanDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.NgayHetHanDateEdit.Properties.BeepOnError = false;
            this.NgayHetHanDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayHetHanDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayHetHanDateEdit.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.NgayHetHanDateEdit.Properties.UseMaskAsDisplayFormat = true;
            this.NgayHetHanDateEdit.Size = new System.Drawing.Size(139, 20);
            this.NgayHetHanDateEdit.StyleController = this.dataLayoutControl1;
            this.NgayHetHanDateEdit.TabIndex = 6;
            // 
            // TenLinkDownloadProfileSearchLookUpEdit
            // 
            this.TenLinkDownloadProfileSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taiKhoanCreateModelBindingSource, "TenLinkDownloadProfile", true));
            this.TenLinkDownloadProfileSearchLookUpEdit.Location = new System.Drawing.Point(89, 60);
            this.TenLinkDownloadProfileSearchLookUpEdit.Name = "TenLinkDownloadProfileSearchLookUpEdit";
            this.TenLinkDownloadProfileSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TenLinkDownloadProfileSearchLookUpEdit.Properties.DataSource = this.linkDownloadProfileSearchModelBindingSource;
            this.TenLinkDownloadProfileSearchLookUpEdit.Properties.DisplayMember = "TenLinkDownloadProfile";
            this.TenLinkDownloadProfileSearchLookUpEdit.Properties.NullText = "";
            this.TenLinkDownloadProfileSearchLookUpEdit.Properties.PopupView = this.searchLookUpEdit1View;
            this.TenLinkDownloadProfileSearchLookUpEdit.Properties.ValueMember = "TenLinkDownloadProfile";
            this.TenLinkDownloadProfileSearchLookUpEdit.Size = new System.Drawing.Size(279, 20);
            this.TenLinkDownloadProfileSearchLookUpEdit.StyleController = this.dataLayoutControl1;
            this.TenLinkDownloadProfileSearchLookUpEdit.TabIndex = 7;
            this.TenLinkDownloadProfileSearchLookUpEdit.EditValueChanged += new System.EventHandler(this.TenLinkDownloadProfileSearchLookUpEdit_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // LinkLinkDownloadProfileTextEdit
            // 
            this.LinkLinkDownloadProfileTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.taiKhoanCreateModelBindingSource, "LinkLinkDownloadProfile", true));
            this.LinkLinkDownloadProfileTextEdit.Location = new System.Drawing.Point(89, 84);
            this.LinkLinkDownloadProfileTextEdit.Name = "LinkLinkDownloadProfileTextEdit";
            this.LinkLinkDownloadProfileTextEdit.Properties.ReadOnly = true;
            this.LinkLinkDownloadProfileTextEdit.Size = new System.Drawing.Size(279, 20);
            this.LinkLinkDownloadProfileTextEdit.StyleController = this.dataLayoutControl1;
            this.LinkLinkDownloadProfileTextEdit.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(380, 194);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForKey,
            this.ItemForNgayHetHan,
            this.ItemForTenLinkDownloadProfile,
            this.ItemForLinkLinkDownloadProfile,
            this.ItemForActived,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(360, 174);
            // 
            // ItemForKey
            // 
            this.ItemForKey.Control = this.KeyTextEdit;
            this.ItemForKey.Location = new System.Drawing.Point(0, 0);
            this.ItemForKey.Name = "ItemForKey";
            this.ItemForKey.Size = new System.Drawing.Size(220, 24);
            this.ItemForKey.Text = "Key";
            this.ItemForKey.TextSize = new System.Drawing.Size(65, 13);
            // 
            // ItemForNgayHetHan
            // 
            this.ItemForNgayHetHan.Control = this.NgayHetHanDateEdit;
            this.ItemForNgayHetHan.Location = new System.Drawing.Point(0, 24);
            this.ItemForNgayHetHan.Name = "ItemForNgayHetHan";
            this.ItemForNgayHetHan.Size = new System.Drawing.Size(220, 24);
            this.ItemForNgayHetHan.Text = "Ngày hết hạn";
            this.ItemForNgayHetHan.TextSize = new System.Drawing.Size(65, 13);
            // 
            // ItemForTenLinkDownloadProfile
            // 
            this.ItemForTenLinkDownloadProfile.Control = this.TenLinkDownloadProfileSearchLookUpEdit;
            this.ItemForTenLinkDownloadProfile.Location = new System.Drawing.Point(0, 48);
            this.ItemForTenLinkDownloadProfile.Name = "ItemForTenLinkDownloadProfile";
            this.ItemForTenLinkDownloadProfile.Size = new System.Drawing.Size(360, 24);
            this.ItemForTenLinkDownloadProfile.Text = "Tên profile";
            this.ItemForTenLinkDownloadProfile.TextSize = new System.Drawing.Size(65, 13);
            // 
            // ItemForLinkLinkDownloadProfile
            // 
            this.ItemForLinkLinkDownloadProfile.Control = this.LinkLinkDownloadProfileTextEdit;
            this.ItemForLinkLinkDownloadProfile.Location = new System.Drawing.Point(0, 72);
            this.ItemForLinkLinkDownloadProfile.Name = "ItemForLinkLinkDownloadProfile";
            this.ItemForLinkLinkDownloadProfile.Size = new System.Drawing.Size(360, 24);
            this.ItemForLinkLinkDownloadProfile.Text = "Link profile";
            this.ItemForLinkLinkDownloadProfile.TextSize = new System.Drawing.Size(65, 13);
            // 
            // ItemForActived
            // 
            this.ItemForActived.Control = this.ActivedCheckEdit;
            this.ItemForActived.Location = new System.Drawing.Point(220, 0);
            this.ItemForActived.Name = "ItemForActived";
            this.ItemForActived.Size = new System.Drawing.Size(140, 24);
            this.ItemForActived.Text = "Kích hoạt";
            this.ItemForActived.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForActived.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(360, 52);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(216, 160);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(74, 22);
            this.btnLuu.StyleController = this.dataLayoutControl1;
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnLuu;
            this.layoutControlItem1.Location = new System.Drawing.Point(204, 148);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(294, 160);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(74, 22);
            this.btnThoat.StyleController = this.dataLayoutControl1;
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnThoat;
            this.layoutControlItem2.Location = new System.Drawing.Point(282, 148);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 148);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(204, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(220, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(140, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // taiKhoanCreateModelBindingSource
            // 
            this.taiKhoanCreateModelBindingSource.DataSource = typeof(FirefoxPortableDatabase.Models.TaiKhoanCreateModel);
            // 
            // linkDownloadProfileSearchModelBindingSource
            // 
            this.linkDownloadProfileSearchModelBindingSource.DataSource = typeof(FirefoxPortableDatabase.Models.LinkDownloadProfileSearchModel);
            // 
            // QuanLyTaiKhoanCreateUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 194);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuanLyTaiKhoanCreateUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thên/Sửa tài khoản";
            this.Load += new System.EventHandler(this.QuanLyTaiKhoanCreateUpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KeyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivedCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayHetHanDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayHetHanDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenLinkDownloadProfileSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LinkLinkDownloadProfileTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNgayHetHan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTenLinkDownloadProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLinkLinkDownloadProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanCreateModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDownloadProfileSearchModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit KeyTextEdit;
        private System.Windows.Forms.BindingSource taiKhoanCreateModelBindingSource;
        private DevExpress.XtraEditors.CheckEdit ActivedCheckEdit;
        private DevExpress.XtraEditors.DateEdit NgayHetHanDateEdit;
        private DevExpress.XtraEditors.SearchLookUpEdit TenLinkDownloadProfileSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.TextEdit LinkLinkDownloadProfileTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKey;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActived;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNgayHetHan;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTenLinkDownloadProfile;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLinkLinkDownloadProfile;
        private System.Windows.Forms.BindingSource linkDownloadProfileSearchModelBindingSource;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}