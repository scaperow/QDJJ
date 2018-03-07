using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class ParameterSettings
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceQF = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.YYH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TBJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SCJJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BDJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditTwo();
            this.FYLB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceGC = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GCLB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEHFW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GLFFL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit2 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditTwo();
            this.LRFL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FXTBFL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GLFTBJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LRFTBJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FXFTBJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(0, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(833, 222);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "子目取费";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSourceQF;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(829, 197);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.YYH,
            this.MC,
            this.TBJSJC,
            this.SCJJC,
            this.BDJSJC,
            this.FL,
            this.FYLB,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            // 
            // YYH
            // 
            this.YYH.Caption = "引用号";
            this.YYH.FieldName = "YYH";
            this.YYH.Name = "YYH";
            this.YYH.OptionsColumn.AllowEdit = false;
            this.YYH.Visible = true;
            this.YYH.VisibleIndex = 0;
            this.YYH.Width = 64;
            // 
            // MC
            // 
            this.MC.Caption = "名称";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.Visible = true;
            this.MC.VisibleIndex = 1;
            this.MC.Width = 92;
            // 
            // TBJSJC
            // 
            this.TBJSJC.Caption = "人工费调整计入差价";
            this.TBJSJC.FieldName = "TBJSJC";
            this.TBJSJC.Name = "TBJSJC";
            this.TBJSJC.Visible = true;
            this.TBJSJC.VisibleIndex = 2;
            this.TBJSJC.Width = 130;
            // 
            // SCJJC
            // 
            this.SCJJC.Caption = "人工费按市场价取费";
            this.SCJJC.FieldName = "SCJJC";
            this.SCJJC.Name = "SCJJC";
            this.SCJJC.Visible = true;
            this.SCJJC.VisibleIndex = 3;
            this.SCJJC.Width = 130;
            // 
            // BDJSJC
            // 
            this.BDJSJC.Caption = "人工费按定额价取费";
            this.BDJSJC.FieldName = "BDJSJC";
            this.BDJSJC.Name = "BDJSJC";
            this.BDJSJC.Visible = true;
            this.BDJSJC.VisibleIndex = 4;
            this.BDJSJC.Width = 130;
            // 
            // FL
            // 
            this.FL.Caption = "费率";
            this.FL.ColumnEdit = this.repositoryItemCalcEdit1;
            this.FL.FieldName = "FL";
            this.FL.Name = "FL";
            this.FL.Visible = true;
            this.FL.VisibleIndex = 5;
            this.FL.Width = 86;
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
            // FYLB
            // 
            this.FYLB.Caption = "费用类别";
            this.FYLB.ColumnEdit = this.repositoryItemComboBox1;
            this.FYLB.FieldName = "FYLB";
            this.FYLB.Name = "FYLB";
            this.FYLB.Visible = true;
            this.FYLB.VisibleIndex = 7;
            this.FYLB.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "备注";
            this.gridColumn1.FieldName = "BZ";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.gridControl2);
            this.groupControl3.Location = new System.Drawing.Point(0, 35);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(833, 180);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "工程取费";
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.bindingSourceGC;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 23);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit2});
            this.gridControl2.Size = new System.Drawing.Size(829, 155);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GCLB,
            this.DEHFW,
            this.GLFFL,
            this.LRFL,
            this.FXTBFL,
            this.GLFTBJSJC,
            this.LRFTBJSJC,
            this.FXFTBJSJC});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // GCLB
            // 
            this.GCLB.Caption = "工程类别";
            this.GCLB.FieldName = "GCLB";
            this.GCLB.Name = "GCLB";
            this.GCLB.OptionsColumn.AllowEdit = false;
            this.GCLB.Visible = true;
            this.GCLB.VisibleIndex = 0;
            this.GCLB.Width = 98;
            // 
            // DEHFW
            // 
            this.DEHFW.Caption = "定额范围";
            this.DEHFW.FieldName = "DEHFW";
            this.DEHFW.Name = "DEHFW";
            this.DEHFW.Visible = true;
            this.DEHFW.VisibleIndex = 1;
            this.DEHFW.Width = 146;
            // 
            // GLFFL
            // 
            this.GLFFL.Caption = "管理费率";
            this.GLFFL.ColumnEdit = this.repositoryItemCalcEdit2;
            this.GLFFL.FieldName = "GLFFL";
            this.GLFFL.Name = "GLFFL";
            this.GLFFL.Visible = true;
            this.GLFFL.VisibleIndex = 2;
            this.GLFFL.Width = 68;
            // 
            // repositoryItemCalcEdit2
            // 
            this.repositoryItemCalcEdit2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemCalcEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemCalcEdit2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemCalcEdit2.AutoHeight = false;
            this.repositoryItemCalcEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemCalcEdit2.DisplayFormat.FormatString = "############0.##";
            this.repositoryItemCalcEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemCalcEdit2.Mask.EditMask = "############0.##";
            this.repositoryItemCalcEdit2.Name = "repositoryItemCalcEdit2";
            this.repositoryItemCalcEdit2.NullText = "0";
            // 
            // LRFL
            // 
            this.LRFL.Caption = "利润费率";
            this.LRFL.ColumnEdit = this.repositoryItemCalcEdit2;
            this.LRFL.FieldName = "LRFL";
            this.LRFL.Name = "LRFL";
            this.LRFL.Visible = true;
            this.LRFL.VisibleIndex = 3;
            this.LRFL.Width = 68;
            // 
            // FXTBFL
            // 
            this.FXTBFL.Caption = "风险费率";
            this.FXTBFL.ColumnEdit = this.repositoryItemCalcEdit2;
            this.FXTBFL.FieldName = "FXTBFL";
            this.FXTBFL.Name = "FXTBFL";
            this.FXTBFL.Visible = true;
            this.FXTBFL.VisibleIndex = 4;
            this.FXTBFL.Width = 68;
            // 
            // GLFTBJSJC
            // 
            this.GLFTBJSJC.Caption = "管理费基础";
            this.GLFTBJSJC.FieldName = "GLFTBJSJC";
            this.GLFTBJSJC.Name = "GLFTBJSJC";
            this.GLFTBJSJC.Visible = true;
            this.GLFTBJSJC.VisibleIndex = 5;
            this.GLFTBJSJC.Width = 110;
            // 
            // LRFTBJSJC
            // 
            this.LRFTBJSJC.Caption = "利润费基础";
            this.LRFTBJSJC.FieldName = "LRFTBJSJC";
            this.LRFTBJSJC.Name = "LRFTBJSJC";
            this.LRFTBJSJC.Visible = true;
            this.LRFTBJSJC.VisibleIndex = 6;
            this.LRFTBJSJC.Width = 110;
            // 
            // FXFTBJSJC
            // 
            this.FXFTBJSJC.Caption = "风险费基础";
            this.FXFTBJSJC.FieldName = "FXFTBJSJC";
            this.FXFTBJSJC.Name = "FXFTBJSJC";
            this.FXFTBJSJC.Visible = true;
            this.FXFTBJSJC.VisibleIndex = 7;
            this.FXFTBJSJC.Width = 110;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(78, 8);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(183, 21);
            this.comboBoxEdit1.TabIndex = 0;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "工程类别：";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.simpleButton1);
            this.splitContainerControl1.Panel1.Controls.Add(this.radioGroup1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.comboBoxEdit1);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(833, 483);
            this.splitContainerControl1.SplitterPosition = 262;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(742, 9);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(88, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "刷新所有子目";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(80, 7);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Appearance.Options.UseForeColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "人工费调整计入差价"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "人工费按市场价取费"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "人工费按定额价取费")});
            this.radioGroup1.Size = new System.Drawing.Size(452, 27);
            this.radioGroup1.TabIndex = 4;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "取费设置：";
            // 
            // ParameterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 483);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ParameterSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "参数设置";
            this.Text = "单价构成";
            this.Load += new System.EventHandler(this.ParameterSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn YYH;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn SCJJC;
        private DevExpress.XtraGrid.Columns.GridColumn TBJSJC;
        private DevExpress.XtraGrid.Columns.GridColumn FL;
        private DevExpress.XtraGrid.Columns.GridColumn GCLB;
        private DevExpress.XtraGrid.Columns.GridColumn DEHFW;
        private DevExpress.XtraGrid.Columns.GridColumn GLFFL;
        private DevExpress.XtraGrid.Columns.GridColumn LRFL;
        private DevExpress.XtraGrid.Columns.GridColumn FXTBFL;
        private DevExpress.XtraGrid.Columns.GridColumn GLFTBJSJC;
        private DevExpress.XtraGrid.Columns.GridColumn LRFTBJSJC;
        private DevExpress.XtraGrid.Columns.GridColumn FXFTBJSJC;
        private System.Windows.Forms.BindingSource bindingSourceQF;
        private DevExpress.XtraGrid.Columns.GridColumn FYLB;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.Windows.Forms.BindingSource bindingSourceGC;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn BDJSJC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private RepositoryItemCalcEditTwo repositoryItemCalcEdit1;
        private RepositoryItemCalcEditTwo repositoryItemCalcEdit2;
    }
}