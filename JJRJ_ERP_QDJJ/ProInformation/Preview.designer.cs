namespace GOLDSOFT.QDJJ.UI
{
    partial class Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.treeListEx1 = new GOLDSOFT.QDJJ.CTRL.TreeListEx();
            this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn14 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.selectAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.treeListEx1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(705, 382);
            this.panelControl3.TabIndex = 0;
            // 
            // treeListEx1
            // 
            this.treeListEx1.AllowDoubleEdit = false;
            this.treeListEx1.AllowSort = false;
            this.treeListEx1.CheckNodes = ((System.Collections.ArrayList)(resources.GetObject("treeListEx1.CheckNodes")));
            this.treeListEx1.ClickCount = 0;
            this.treeListEx1.ColumnColor = null;
            this.treeListEx1.ColumnLayout = null;
            this.treeListEx1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn13,
            this.treeListColumn14,
            this.treeListColumn15,
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn5,
            this.treeListColumn6});
            this.treeListEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListEx1.Location = new System.Drawing.Point(2, 2);
            this.treeListEx1.ModelName = "";
            this.treeListEx1.Name = "treeListEx1";
            this.treeListEx1.OptionsBehavior.ImmediateEditor = false;
            this.treeListEx1.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.treeListEx1.OptionsView.ShowIndicator = false;
            this.treeListEx1.SchemeColor = null;
            this.treeListEx1.Size = new System.Drawing.Size(701, 378);
            this.treeListEx1.TabIndex = 0;
            // 
            // treeListColumn13
            // 
            this.treeListColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn13.Caption = "选择";
            this.treeListColumn13.FieldName = "Check";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.OptionsColumn.AllowSort = false;
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 0;
            this.treeListColumn13.Width = 51;
            // 
            // treeListColumn14
            // 
            this.treeListColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn14.Caption = "已生成";
            this.treeListColumn14.FieldName = "IsFresh";
            this.treeListColumn14.Name = "treeListColumn14";
            this.treeListColumn14.OptionsColumn.AllowEdit = false;
            this.treeListColumn14.OptionsColumn.AllowSort = false;
            this.treeListColumn14.Visible = true;
            this.treeListColumn14.VisibleIndex = 1;
            this.treeListColumn14.Width = 50;

            // 
            // treeListColumn15
            // 
            this.treeListColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn15.Caption = "序号";
            this.treeListColumn15.FieldName = "ID";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.OptionsColumn.AllowEdit = false;
            this.treeListColumn15.OptionsColumn.AllowSort = false;
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 1;
            this.treeListColumn15.Width = 50;

            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "清单编号";
            this.treeListColumn1.FieldName = "QDBH";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 2;
            this.treeListColumn1.Width = 109;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "清单名称";
            this.treeListColumn2.FieldName = "QDMC";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 3;
            this.treeListColumn2.Width = 227;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "单位";
            this.treeListColumn3.FieldName = "DW";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 4;
            this.treeListColumn3.Width = 81;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "工程量";
            this.treeListColumn5.FieldName = "GCL";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowEdit = false;
            this.treeListColumn5.OptionsColumn.AllowSort = false;
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 5;
            this.treeListColumn5.Width = 82;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn6.Caption = "来源";
            this.treeListColumn6.FieldName = "TJ";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowEdit = false;
            this.treeListColumn6.OptionsColumn.AllowSort = false;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 6;
            this.treeListColumn6.Width = 97;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.selectAll);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 387);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(705, 41);
            this.panelControl1.TabIndex = 7;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simpleButton2.Location = new System.Drawing.Point(570, 9);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(92, 27);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simpleButton1.Location = new System.Drawing.Point(437, 9);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(117, 27);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "刷新到当前单位工程";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // selectAll
            // 
            this.selectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectAll.Location = new System.Drawing.Point(12, 9);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(92, 27);
            this.selectAll.TabIndex = 1;
            this.selectAll.Text = "全选";
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 428);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "Preview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清单预览";
            this.Load += new System.EventHandler(this.Preview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private GOLDSOFT.QDJJ.CTRL.TreeListEx treeListEx1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn13;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn14;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn15;
        public DevExpress.XtraEditors.SimpleButton selectAll;
    }
}