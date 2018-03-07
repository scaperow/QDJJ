using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class RepairQuantityUnitSelect
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit2 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditFour();
            this.SCDJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditTwo();
            this.CTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SSDWGC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditLB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditSSDWGC = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditBH = new DevExpress.XtraEditors.TextEdit();
            this.textEditMC = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSSDWGC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 31);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemCalcEdit2});
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(642, 335);
            this.gridControl1.TabIndex = 13;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BH,
            this.MC,
            this.DW,
            this.gridColumn1,
            this.SL,
            this.SCDJ,
            this.CTIME,
            this.SSDWGC});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            // 
            // BH
            // 
            this.BH.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.BH.AppearanceCell.Options.UseFont = true;
            this.BH.AppearanceCell.Options.UseTextOptions = true;
            this.BH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.BH.AppearanceHeader.Options.UseFont = true;
            this.BH.AppearanceHeader.Options.UseTextOptions = true;
            this.BH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BH.Caption = "编码";
            this.BH.FieldName = "BH";
            this.BH.Name = "BH";
            this.BH.OptionsColumn.AllowEdit = false;
            this.BH.Visible = true;
            this.BH.VisibleIndex = 0;
            this.BH.Width = 90;
            // 
            // MC
            // 
            this.MC.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.MC.AppearanceCell.Options.UseFont = true;
            this.MC.AppearanceCell.Options.UseTextOptions = true;
            this.MC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.MC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.MC.AppearanceHeader.Options.UseFont = true;
            this.MC.AppearanceHeader.Options.UseTextOptions = true;
            this.MC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MC.Caption = "名称";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.OptionsColumn.AllowEdit = false;
            this.MC.Visible = true;
            this.MC.VisibleIndex = 1;
            this.MC.Width = 150;
            // 
            // DW
            // 
            this.DW.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DW.AppearanceCell.Options.UseFont = true;
            this.DW.AppearanceCell.Options.UseTextOptions = true;
            this.DW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DW.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DW.AppearanceHeader.Options.UseFont = true;
            this.DW.AppearanceHeader.Options.UseTextOptions = true;
            this.DW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DW.Caption = "单位";
            this.DW.FieldName = "DW";
            this.DW.Name = "DW";
            this.DW.OptionsColumn.AllowEdit = false;
            this.DW.Visible = true;
            this.DW.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "类别";
            this.gridColumn1.FieldName = "LB";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // SL
            // 
            this.SL.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.SL.AppearanceCell.Options.UseFont = true;
            this.SL.AppearanceCell.Options.UseTextOptions = true;
            this.SL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.SL.AppearanceHeader.Options.UseFont = true;
            this.SL.AppearanceHeader.Options.UseTextOptions = true;
            this.SL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SL.Caption = "数量";
            this.SL.ColumnEdit = this.repositoryItemCalcEdit2;
            this.SL.FieldName = "SL";
            this.SL.Name = "SL";
            this.SL.OptionsColumn.AllowEdit = false;
            this.SL.Width = 100;
            // 
            // repositoryItemCalcEdit2
            // 
            this.repositoryItemCalcEdit2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemCalcEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemCalcEdit2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemCalcEdit2.AutoHeight = false;
            this.repositoryItemCalcEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemCalcEdit2.DisplayFormat.FormatString = "############0.####";
            this.repositoryItemCalcEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEdit2.Mask.EditMask = "############0.####";
            this.repositoryItemCalcEdit2.Name = "repositoryItemCalcEdit2";
            this.repositoryItemCalcEdit2.NullText = "0";
            // 
            // SCDJ
            // 
            this.SCDJ.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.SCDJ.AppearanceCell.Options.UseFont = true;
            this.SCDJ.AppearanceCell.Options.UseTextOptions = true;
            this.SCDJ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SCDJ.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.SCDJ.AppearanceHeader.Options.UseFont = true;
            this.SCDJ.AppearanceHeader.Options.UseTextOptions = true;
            this.SCDJ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SCDJ.Caption = "市场价";
            this.SCDJ.ColumnEdit = this.repositoryItemCalcEdit1;
            this.SCDJ.FieldName = "SCDJ";
            this.SCDJ.Name = "SCDJ";
            this.SCDJ.OptionsColumn.AllowEdit = false;
            this.SCDJ.Visible = true;
            this.SCDJ.VisibleIndex = 4;
            this.SCDJ.Width = 100;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemCalcEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemCalcEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemCalcEdit1.DisplayFormat.FormatString = "############0.##";
            this.repositoryItemCalcEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEdit1.Mask.EditMask = "############0.##";
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            this.repositoryItemCalcEdit1.NullText = "0";
            // 
            // CTIME
            // 
            this.CTIME.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CTIME.AppearanceCell.Options.UseFont = true;
            this.CTIME.AppearanceCell.Options.UseTextOptions = true;
            this.CTIME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CTIME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CTIME.AppearanceHeader.Options.UseFont = true;
            this.CTIME.AppearanceHeader.Options.UseTextOptions = true;
            this.CTIME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CTIME.Caption = "存档日期";
            this.CTIME.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.CTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CTIME.FieldName = "CTIME";
            this.CTIME.Name = "CTIME";
            this.CTIME.OptionsColumn.AllowEdit = false;
            this.CTIME.Visible = true;
            this.CTIME.VisibleIndex = 5;
            this.CTIME.Width = 100;
            // 
            // SSDWGC
            // 
            this.SSDWGC.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F);
            this.SSDWGC.AppearanceCell.Options.UseFont = true;
            this.SSDWGC.AppearanceCell.Options.UseTextOptions = true;
            this.SSDWGC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SSDWGC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F);
            this.SSDWGC.AppearanceHeader.Options.UseFont = true;
            this.SSDWGC.AppearanceHeader.Options.UseTextOptions = true;
            this.SSDWGC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SSDWGC.Caption = "所属单位工程";
            this.SSDWGC.FieldName = "SSDWGC";
            this.SSDWGC.Name = "SSDWGC";
            this.SSDWGC.OptionsColumn.AllowEdit = false;
            this.SSDWGC.Visible = true;
            this.SSDWGC.VisibleIndex = 6;
            this.SSDWGC.Width = 150;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxEditLB);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.comboBoxEditSSDWGC);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.textEditBH);
            this.panelControl1.Controls.Add(this.textEditMC);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(642, 31);
            this.panelControl1.TabIndex = 14;
            // 
            // comboBoxEditLB
            // 
            this.comboBoxEditLB.EditValue = "查看全部";
            this.comboBoxEditLB.Location = new System.Drawing.Point(78, 5);
            this.comboBoxEditLB.Name = "comboBoxEditLB";
            this.comboBoxEditLB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLB.Properties.Items.AddRange(new object[] {
            "查看全部",
            "主材",
            "材料",
            "人工",
            "机械",
            "设备",
            ""});
            this.comboBoxEditLB.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
            this.comboBoxEditLB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditLB.Size = new System.Drawing.Size(80, 21);
            this.comboBoxEditLB.TabIndex = 19;
            this.comboBoxEditLB.EditValueChanged += new System.EventHandler(this.Filter_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "材料类别：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(164, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "单位工程：";
            // 
            // comboBoxEditSSDWGC
            // 
            this.comboBoxEditSSDWGC.Location = new System.Drawing.Point(230, 5);
            this.comboBoxEditSSDWGC.Name = "comboBoxEditSSDWGC";
            this.comboBoxEditSSDWGC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSSDWGC.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
            this.comboBoxEditSSDWGC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSSDWGC.Size = new System.Drawing.Size(80, 21);
            this.comboBoxEditSSDWGC.TabIndex = 20;
            this.comboBoxEditSSDWGC.EditValueChanged += new System.EventHandler(this.Filter_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(444, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "名称：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(316, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "编号：";
            // 
            // textEditBH
            // 
            this.textEditBH.Location = new System.Drawing.Point(358, 5);
            this.textEditBH.Name = "textEditBH";
            this.textEditBH.Properties.MaxLength = 255;
            this.textEditBH.Size = new System.Drawing.Size(80, 21);
            this.textEditBH.TabIndex = 22;
            this.textEditBH.EditValueChanged += new System.EventHandler(this.Filter_EditValueChanged);
            // 
            // textEditMC
            // 
            this.textEditMC.Location = new System.Drawing.Point(486, 5);
            this.textEditMC.Name = "textEditMC";
            this.textEditMC.Properties.MaxLength = 255;
            this.textEditMC.Size = new System.Drawing.Size(80, 21);
            this.textEditMC.TabIndex = 21;
            this.textEditMC.EditValueChanged += new System.EventHandler(this.Filter_EditValueChanged);
            // 
            // RepairQuantityUnitSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 366);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepairQuantityUnitSelect";
            this.Text = "补充材机库";
            this.Load += new System.EventHandler(this.RepairQuantityUnitSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSSDWGC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn BH;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn DW;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn SL;
        private DevExpress.XtraGrid.Columns.GridColumn SCDJ;
        private DevExpress.XtraGrid.Columns.GridColumn CTIME;
        private DevExpress.XtraGrid.Columns.GridColumn SSDWGC;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLB;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSSDWGC;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditBH;
        private DevExpress.XtraEditors.TextEdit textEditMC;
        private RepositoryItemCalcEditFour repositoryItemCalcEdit2;
        private RepositoryItemCalcEditTwo repositoryItemCalcEdit1;
    }
}