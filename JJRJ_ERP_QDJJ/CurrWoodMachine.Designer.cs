using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
namespace GOLDSOFT.QDJJ.UI
{
    partial class CurrWoodMachine
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.quantityUnitTypeTreeList1 = new GOLDSOFT.QDJJ.CTRL.QuantityUnitTypeTreeList();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEDJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SCDJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GGXH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.quantityUnitTypeTreeList1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl2.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(892, 446);
            this.splitContainerControl2.SplitterPosition = 160;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // quantityUnitTypeTreeList1
            // 
            this.quantityUnitTypeTreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantityUnitTypeTreeList1.Location = new System.Drawing.Point(0, 0);
            this.quantityUnitTypeTreeList1.Name = "quantityUnitTypeTreeList1";
            this.quantityUnitTypeTreeList1.Size = new System.Drawing.Size(160, 446);
            this.quantityUnitTypeTreeList1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 35);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(726, 410);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BH,
            this.MC,
            this.DW,
            this.SL,
            this.DEDJ,
            this.SCDJ,
            this.GGXH,
            this.CTIME});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // BH
            // 
            this.BH.Caption = "编码";
            this.BH.DisplayFormat.FormatString = "0.0000";
            this.BH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.BH.FieldName = "BH";
            this.BH.Name = "BH";
            this.BH.OptionsColumn.AllowEdit = false;
            this.BH.Visible = true;
            this.BH.VisibleIndex = 0;
            this.BH.Width = 80;
            // 
            // MC
            // 
            this.MC.Caption = "名称";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.OptionsColumn.AllowEdit = false;
            this.MC.Visible = true;
            this.MC.VisibleIndex = 1;
            this.MC.Width = 120;
            // 
            // DW
            // 
            this.DW.Caption = "单位";
            this.DW.FieldName = "DW";
            this.DW.Name = "DW";
            this.DW.OptionsColumn.AllowEdit = false;
            this.DW.Visible = true;
            this.DW.VisibleIndex = 2;
            this.DW.Width = 90;
            // 
            // SL
            // 
            this.SL.Caption = "数量";
            this.SL.DisplayFormat.FormatString = "0.0000";
            this.SL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SL.FieldName = "SL";
            this.SL.Name = "SL";
            this.SL.OptionsColumn.AllowEdit = false;
            this.SL.Visible = true;
            this.SL.VisibleIndex = 3;
            this.SL.Width = 70;
            // 
            // DEDJ
            // 
            this.DEDJ.Caption = "定额价";
            this.DEDJ.DisplayFormat.FormatString = "0.00";
            this.DEDJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DEDJ.FieldName = "DEDJ";
            this.DEDJ.Name = "DEDJ";
            this.DEDJ.OptionsColumn.AllowEdit = false;
            this.DEDJ.Visible = true;
            this.DEDJ.VisibleIndex = 4;
            this.DEDJ.Width = 70;
            // 
            // SCDJ
            // 
            this.SCDJ.Caption = "市场价";
            this.SCDJ.DisplayFormat.FormatString = "0.00";
            this.SCDJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SCDJ.FieldName = "SCDJ";
            this.SCDJ.Name = "SCDJ";
            this.SCDJ.OptionsColumn.AllowEdit = false;
            this.SCDJ.Visible = true;
            this.SCDJ.VisibleIndex = 5;
            this.SCDJ.Width = 70;
            // 
            // GGXH
            // 
            this.GGXH.Caption = "规格";
            this.GGXH.FieldName = "GGXH";
            this.GGXH.Name = "GGXH";
            this.GGXH.OptionsColumn.AllowEdit = false;
            this.GGXH.Visible = true;
            this.GGXH.VisibleIndex = 6;
            this.GGXH.Width = 100;
            // 
            // CTIME
            // 
            this.CTIME.Caption = "存档日期";
            this.CTIME.DisplayFormat.FormatString = "yyyy-MM-DD";
            this.CTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CTIME.FieldName = "CTIME";
            this.CTIME.Name = "CTIME";
            this.CTIME.OptionsColumn.AllowEdit = false;
            this.CTIME.Visible = true;
            this.CTIME.VisibleIndex = 7;
            this.CTIME.Width = 100;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(215, 5);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(120, 21);
            this.textEdit2.TabIndex = 2;
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(383, 5);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new System.Drawing.Size(120, 21);
            this.comboBoxEdit2.TabIndex = 3;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(47, 5);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(120, 21);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "编号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(341, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "单位：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(173, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "名称：";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.comboBoxEdit2);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(720, 31);
            this.panelControl1.TabIndex = 9;
            // 
            // CurrWoodMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 446);
            this.Controls.Add(this.splitContainerControl2);
            this.Name = "CurrWoodMachine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "当前工料机库";
            this.Load += new System.EventHandler(this.CurrWoodMachine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

      
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn BH;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn GGXH;
        private DevExpress.XtraGrid.Columns.GridColumn DW;
        private DevExpress.XtraGrid.Columns.GridColumn DEDJ;
        private DevExpress.XtraGrid.Columns.GridColumn SCDJ;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private GOLDSOFT.QDJJ.CTRL.QuantityUnitTypeTreeList quantityUnitTypeTreeList1;
        private DevExpress.XtraGrid.Columns.GridColumn SL;
        private DevExpress.XtraGrid.Columns.GridColumn CTIME;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}