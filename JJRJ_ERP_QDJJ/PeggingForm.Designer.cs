using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class PeggingForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.treeListFBFX = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSourceFBFX = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemCalcEdit1 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditFour();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.treeListCSXM = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSourceCSXM = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemCalcEdit2 = new RepositoryItemCalcEditFour();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFBFX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFBFX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListCSXM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCSXM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(642, 366);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.treeListFBFX);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(635, 336);
            this.xtraTabPage1.Text = "分部分项";
            // 
            // treeListFBFX
            // 
            this.treeListFBFX.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5});
            this.treeListFBFX.CustomizationFormBounds = new System.Drawing.Rectangle(475, 353, 208, 177);
            this.treeListFBFX.DataSource = this.bindingSourceFBFX;
            this.treeListFBFX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListFBFX.Location = new System.Drawing.Point(0, 0);
            this.treeListFBFX.Name = "treeListFBFX";
            this.treeListFBFX.OptionsBehavior.PopulateServiceColumns = true;
            this.treeListFBFX.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListFBFX.ParentFieldName = "PID";
            this.treeListFBFX.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.treeListFBFX.Size = new System.Drawing.Size(635, 336);
            this.treeListFBFX.TabIndex = 0;
            this.treeListFBFX.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeListFBFX_CustomDrawNodeCell);
            this.treeListFBFX.DoubleClick += new System.EventHandler(this.treeList_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "编码";
            this.treeListColumn1.FieldName = "XMBM";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 104;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn2.AppearanceCell.Options.UseFont = true;
            this.treeListColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn2.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "名称";
            this.treeListColumn2.FieldName = "XMMC";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 195;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn3.AppearanceCell.Options.UseFont = true;
            this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn3.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "单位";
            this.treeListColumn3.FieldName = "DW";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 106;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn4.AppearanceCell.Options.UseFont = true;
            this.treeListColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn4.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.Caption = "工程量";
            this.treeListColumn4.ColumnEdit = this.repositoryItemCalcEdit1;
            this.treeListColumn4.FieldName = "GCL";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 106;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn5.AppearanceCell.Options.UseFont = true;
            this.treeListColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn5.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "消耗量";
            this.treeListColumn5.ColumnEdit = this.repositoryItemCalcEdit1;
            this.treeListColumn5.FieldName = "XHL";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowEdit = false;
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 103;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemCalcEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemCalcEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemCalcEdit1.DisplayFormat.FormatString = "############0.####";
            this.repositoryItemCalcEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEdit1.Mask.EditMask = "############0.####";
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.treeListCSXM);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(635, 336);
            this.xtraTabPage2.Text = "措施项目";
            // 
            // treeListCSXM
            // 
            this.treeListCSXM.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8,
            this.treeListColumn9,
            this.treeListColumn10});
            this.treeListCSXM.DataSource = this.bindingSourceCSXM;
            this.treeListCSXM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListCSXM.Location = new System.Drawing.Point(0, 0);
            this.treeListCSXM.Name = "treeListCSXM";
            this.treeListCSXM.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeListCSXM.ParentFieldName = "PID";
            this.treeListCSXM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit2});
            this.treeListCSXM.Size = new System.Drawing.Size(635, 336);
            this.treeListCSXM.TabIndex = 1;
            this.treeListCSXM.DoubleClick += new System.EventHandler(this.treeList_DoubleClick);
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn6.AppearanceCell.Options.UseFont = true;
            this.treeListColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn6.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn6.Caption = "编码";
            this.treeListColumn6.FieldName = "XMBM";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowEdit = false;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 0;
            this.treeListColumn6.Width = 104;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn7.AppearanceCell.Options.UseFont = true;
            this.treeListColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn7.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn7.Caption = "名称";
            this.treeListColumn7.FieldName = "XMMC";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.OptionsColumn.AllowEdit = false;
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 1;
            this.treeListColumn7.Width = 195;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn8.AppearanceCell.Options.UseFont = true;
            this.treeListColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn8.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn8.Caption = "单位";
            this.treeListColumn8.FieldName = "DW";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.OptionsColumn.AllowEdit = false;
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 2;
            this.treeListColumn8.Width = 106;
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn9.AppearanceCell.Options.UseFont = true;
            this.treeListColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn9.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn9.Caption = "工程量";
            this.treeListColumn9.ColumnEdit = this.repositoryItemCalcEdit2;
            this.treeListColumn9.FieldName = "GCL";
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.OptionsColumn.AllowEdit = false;
            this.treeListColumn9.Visible = true;
            this.treeListColumn9.VisibleIndex = 3;
            this.treeListColumn9.Width = 106;
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn10.AppearanceCell.Options.UseFont = true;
            this.treeListColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.treeListColumn10.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn10.Caption = "消耗量";
            this.treeListColumn10.ColumnEdit = this.repositoryItemCalcEdit2;
            this.treeListColumn10.FieldName = "XHL";
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.OptionsColumn.AllowEdit = false;
            this.treeListColumn10.Visible = true;
            this.treeListColumn10.VisibleIndex = 4;
            this.treeListColumn10.Width = 103;
            // 
            // repositoryItemCalcEdit2
            // 
            this.repositoryItemCalcEdit2.AutoHeight = false;
            this.repositoryItemCalcEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit2.Name = "repositoryItemCalcEdit2";
            // 
            // PeggingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 366);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PeggingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "材机反查";
            this.Load += new System.EventHandler(this.PeggingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFBFX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFBFX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListCSXM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCSXM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.BindingSource bindingSourceFBFX;
        private System.Windows.Forms.BindingSource bindingSourceCSXM;
        private DevExpress.XtraTreeList.TreeList treeListFBFX;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.TreeList treeListCSXM;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private RepositoryItemCalcEditFour repositoryItemCalcEdit1;
        private RepositoryItemCalcEditFour repositoryItemCalcEdit2;
    }
}