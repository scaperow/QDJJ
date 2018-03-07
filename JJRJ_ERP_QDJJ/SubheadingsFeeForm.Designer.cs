using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class SubheadingsFeeForm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new GOLDSOFT.QDJJ.CTRL.GridViewEx();
            this.YYH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TBJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.FL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditTwo();
            this.TBJE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FYLB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemButtonEditFL = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.graphAnalysis1 = new GOLDSOFT.QDJJ.CTRL.GraphAnalysis();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditFL)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.MinSize = 60;
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraScrollableControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(719, 266);
            this.splitContainerControl1.SplitterPosition = 523;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemButtonEditFL,
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(523, 266);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnColor = null;
            this.gridView1.ColumnLayout = null;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.YYH,
            this.MC,
            this.TBJSJC,
            this.FL,
            this.TBJE,
            this.FYLB});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.ModelName = "";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SchemeColor = null;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            // 
            // YYH
            // 
            this.YYH.AppearanceHeader.Options.UseTextOptions = true;
            this.YYH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YYH.Caption = "引用号";
            this.YYH.FieldName = "YYH";
            this.YYH.Name = "YYH";
            this.YYH.OptionsColumn.AllowEdit = false;
            this.YYH.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.YYH.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.YYH.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.YYH.OptionsFilter.AllowFilter = false;
            this.YYH.Visible = true;
            this.YYH.VisibleIndex = 0;
            this.YYH.Width = 58;
            // 
            // MC
            // 
            this.MC.AppearanceHeader.Options.UseTextOptions = true;
            this.MC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MC.Caption = "名称";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.OptionsColumn.AllowEdit = false;
            this.MC.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.MC.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.MC.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.MC.OptionsFilter.AllowFilter = false;
            this.MC.Visible = true;
            this.MC.VisibleIndex = 1;
            this.MC.Width = 68;
            // 
            // TBJSJC
            // 
            this.TBJSJC.AppearanceHeader.Options.UseTextOptions = true;
            this.TBJSJC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TBJSJC.Caption = "计算基础";
            this.TBJSJC.ColumnEdit = this.repositoryItemButtonEdit1;
            this.TBJSJC.FieldName = "TBJSJC";
            this.TBJSJC.Name = "TBJSJC";
            this.TBJSJC.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TBJSJC.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TBJSJC.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.TBJSJC.OptionsFilter.AllowFilter = false;
            this.TBJSJC.Visible = true;
            this.TBJSJC.VisibleIndex = 2;
            this.TBJSJC.Width = 130;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.MaxLength = 255;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // FL
            // 
            this.FL.AppearanceHeader.Options.UseTextOptions = true;
            this.FL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FL.Caption = "费率";
            this.FL.ColumnEdit = this.repositoryItemCalcEdit1;
            this.FL.FieldName = "FL";
            this.FL.Name = "FL";
            this.FL.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.FL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.FL.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.FL.OptionsFilter.AllowFilter = false;
            this.FL.Visible = true;
            this.FL.VisibleIndex = 3;
            this.FL.Width = 81;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemCalcEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemCalcEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemCalcEdit1.DisplayFormat.FormatString = "############0.##";
            this.repositoryItemCalcEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEdit1.Mask.EditMask = "############0.##";
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            this.repositoryItemCalcEdit1.NullText = "0";
            // 
            // TBJE
            // 
            this.TBJE.AppearanceHeader.Options.UseTextOptions = true;
            this.TBJE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TBJE.Caption = "金额";
            this.TBJE.ColumnEdit = this.repositoryItemCalcEdit1;
            this.TBJE.FieldName = "BDJE";
            this.TBJE.Name = "BDJE";
            this.TBJE.OptionsColumn.AllowEdit = false;
            this.TBJE.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.TBJE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.TBJE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.TBJE.OptionsFilter.AllowFilter = false;
            this.TBJE.Visible = true;
            this.TBJE.VisibleIndex = 4;
            this.TBJE.Width = 74;
            // 
            // FYLB
            // 
            this.FYLB.AppearanceHeader.Options.UseTextOptions = true;
            this.FYLB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FYLB.Caption = "费用代号";
            this.FYLB.ColumnEdit = this.repositoryItemComboBox1;
            this.FYLB.FieldName = "FYLB";
            this.FYLB.Name = "FYLB";
            this.FYLB.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.FYLB.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.FYLB.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.FYLB.OptionsFilter.AllowFilter = false;
            this.FYLB.Visible = true;
            this.FYLB.VisibleIndex = 5;
            this.FYLB.Width = 91;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            " "});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBox1.ValidateOnEnterKey = true;
            // 
            // repositoryItemButtonEditFL
            // 
            this.repositoryItemButtonEditFL.Appearance.Options.UseTextOptions = true;
            this.repositoryItemButtonEditFL.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemButtonEditFL.AutoHeight = false;
            this.repositoryItemButtonEditFL.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEditFL.DisplayFormat.FormatString = "############0.##";
            this.repositoryItemButtonEditFL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemButtonEditFL.Mask.EditMask = "############0.##";
            this.repositoryItemButtonEditFL.Name = "repositoryItemButtonEditFL";
            this.repositoryItemButtonEditFL.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditCostSelect_ButtonClick);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControl1.Controls.Add(this.graphAnalysis1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(190, 266);
            this.xtraScrollableControl1.TabIndex = 1;
            // 
            // graphAnalysis1
            // 
            this.graphAnalysis1.BackColor = System.Drawing.Color.Transparent;
            this.graphAnalysis1.DataSource = null;
            this.graphAnalysis1.Dock = System.Windows.Forms.DockStyle.Left;
            this.graphAnalysis1.Location = new System.Drawing.Point(0, 0);
            this.graphAnalysis1.Name = "graphAnalysis1";
            this.graphAnalysis1.ShowName = null;
            this.graphAnalysis1.Size = new System.Drawing.Size(1080, 249);
            this.graphAnalysis1.TabIndex = 0;
            this.graphAnalysis1.ValueName = "";
            // 
            // SubheadingsFeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 266);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "SubheadingsFeeForm";
            this.Text = "SubheadingsFeeForm";
            this.Load += new System.EventHandler(this.SubheadingsFeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditFL)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private GOLDSOFT.QDJJ.CTRL.GraphAnalysis graphAnalysis1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private GridViewEx gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn YYH;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn TBJSJC;
        private DevExpress.XtraGrid.Columns.GridColumn FL;
        private DevExpress.XtraGrid.Columns.GridColumn TBJE;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn FYLB;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditFL;
        private RepositoryItemCalcEditTwo repositoryItemCalcEdit1;


    }
}