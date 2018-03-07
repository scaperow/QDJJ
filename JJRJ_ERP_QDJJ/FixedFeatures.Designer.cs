using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class FixedFeatures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FixedFeatures));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new GOLDSOFT.QDJJ.CTRL.GridViewEx();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.treeListEx1 = new GOLDSOFT.QDJJ.CTRL.TreeListEx();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn52 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonQXSX = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSXMC1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonSXMC2 = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(452, 394);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnColor = null;
            this.gridView1.ColumnLayout = null;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.ModelName = "";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SchemeColor = null;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "特征名称";
            this.gridColumn1.FieldName = "TEZMC";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 139;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "特征值";
            this.gridColumn2.FieldName = "xmtz";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 140;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "显示值";
            this.gridColumn3.FieldName = "Remark";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 160;
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
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn52});
            this.treeListEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListEx1.Location = new System.Drawing.Point(0, 0);
            this.treeListEx1.ModelName = "";
            this.treeListEx1.Name = "treeListEx1";
            this.treeListEx1.OptionsBehavior.ImmediateEditor = false;
            this.treeListEx1.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.treeListEx1.OptionsView.ShowCheckBoxes = true;
            this.treeListEx1.SchemeColor = null;
            this.treeListEx1.Size = new System.Drawing.Size(569, 394);
            this.treeListEx1.TabIndex = 0;
            this.treeListEx1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeListEx1_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "定额号";
            this.treeListColumn1.FieldName = "TZDEH";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 99;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "名称";
            this.treeListColumn2.FieldName = "DEMC";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 187;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "单位";
            this.treeListColumn3.FieldName = "DEDW";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 52;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "系数";
            this.treeListColumn4.FieldName = "XS";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 45;
            // 
            // treeListColumn52
            // 
            this.treeListColumn52.Caption = "特征名称";
            this.treeListColumn52.FieldName = "TZMC";
            this.treeListColumn52.Name = "treeListColumn52";
            this.treeListColumn52.OptionsColumn.AllowEdit = false;
            this.treeListColumn52.OptionsColumn.AllowSort = false;
            this.treeListColumn52.Visible = true;
            this.treeListColumn52.VisibleIndex = 4;
            this.treeListColumn52.Width = 146;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonQXSX);
            this.panelControl1.Controls.Add(this.simpleButtonSXMC1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 394);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(452, 34);
            this.panelControl1.TabIndex = 3;
            // 
            // simpleButtonQXSX
            // 
            this.simpleButtonQXSX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonQXSX.Location = new System.Drawing.Point(291, 6);
            this.simpleButtonQXSX.Name = "simpleButtonQXSX";
            this.simpleButtonQXSX.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonQXSX.TabIndex = 1;
            this.simpleButtonQXSX.Text = "取消刷新";
            this.simpleButtonQXSX.Visible = false;
            this.simpleButtonQXSX.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButtonSXMC1
            // 
            this.simpleButtonSXMC1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonSXMC1.Location = new System.Drawing.Point(372, 6);
            this.simpleButtonSXMC1.Name = "simpleButtonSXMC1";
            this.simpleButtonSXMC1.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSXMC1.TabIndex = 0;
            this.simpleButtonSXMC1.Text = "刷新名称";
            this.simpleButtonSXMC1.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.checkEdit1);
            this.panelControl2.Controls.Add(this.simpleButtonSXMC2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 394);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(569, 34);
            this.panelControl2.TabIndex = 3;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(5, 8);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "全选";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 1;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // simpleButtonSXMC2
            // 
            this.simpleButtonSXMC2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonSXMC2.Location = new System.Drawing.Point(489, 6);
            this.simpleButtonSXMC2.Name = "simpleButtonSXMC2";
            this.simpleButtonSXMC2.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSXMC2.TabIndex = 0;
            this.simpleButtonSXMC2.Text = "刷新定额";
            this.simpleButtonSXMC2.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.treeListEx1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1027, 428);
            this.splitContainerControl1.SplitterPosition = 452;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // FixedFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 428);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FixedFeatures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目特征";
            this.Load += new System.EventHandler(this.FixedFeatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private GridViewEx gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSXMC2;
        private TreeListEx treeListEx1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSXMC1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn52;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQXSX;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;

    }
}