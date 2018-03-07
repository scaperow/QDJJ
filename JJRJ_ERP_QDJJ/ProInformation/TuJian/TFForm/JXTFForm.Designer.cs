namespace GOLDSOFT.QDJJ.UI
{
    partial class JXTFForm
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
            this.gridControlEx1 = new GOLDSOFT.QDJJ.UI.Controls.GridControlEx();
            this.gridView1 = new GOLDSOFT.QDJJ.UI.InfoGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popControl1 = new GOLDSOFT.QDJJ.UI.popControl();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SZBWrepositoryItemComboBox1 = new GOLDSOFT.QDJJ.UI.ComBoxBW();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.JXTFQDDEbindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.JGGJMCbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JMXZbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QDbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MBZMbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HNTYQbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HNTQDbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JMCCbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGSDbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JGFLbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TFQRQDbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LXSZbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCYQCSbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SZBWrepositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JXTFQDDEbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControlEx1);
            // 
            // gridControlEx1
            // 
            this.gridControlEx1.DataSource = this.bindingSource1;
            this.gridControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlEx1.Location = new System.Drawing.Point(2, 2);
            this.gridControlEx1.MainView = this.gridView1;
            this.gridControlEx1.Name = "gridControlEx1";
            this.gridControlEx1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.popControl1,
            this.SZBWrepositoryItemComboBox1});
            this.gridControlEx1.Size = new System.Drawing.Size(912, 392);
            this.gridControlEx1.TabIndex = 0;
            this.gridControlEx1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridControlEx1_MouseUp);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControlEx1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "序号";
            this.gridColumn1.FieldName = "XH";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "机械类型";
            this.gridColumn2.ColumnEdit = this.popControl1;
            this.gridColumn2.FieldName = "JXLX";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // popControl1
            // 
            this.popControl1.Appearance.Options.UseTextOptions = true;
            this.popControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.popControl1.AppearanceDisabled.Options.UseTextOptions = true;
            this.popControl1.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.popControl1.AppearanceDropDown.Options.UseTextOptions = true;
            this.popControl1.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.popControl1.AutoHeight = false;
            this.popControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popControl1.ColName = null;
            this.popControl1.Name = "popControl1";
            this.popControl1.PopupFormMinSize = new System.Drawing.Size(0, 200);
            this.popControl1.RemoveDefaultColName = null;
            this.popControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.popControl1_KeyPress);
            this.popControl1.onCurrentChanged += new GOLDSOFT.QDJJ.UI.popControl.CurrentChangedHanld(this.popControl1_onCurrentChanged);
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "推铲运距离（m）";
            this.gridColumn3.ColumnEdit = this.popControl1;
            this.gridColumn3.FieldName = "TCYJL";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 117;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "单位";
            this.gridColumn4.FieldName = "DW";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "实物工程量";
            this.gridColumn5.FieldName = "SWGCL";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "所在部位";
            this.gridColumn6.ColumnEdit = this.SZBWrepositoryItemComboBox1;
            this.gridColumn6.FieldName = "SZBW";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // SZBWrepositoryItemComboBox1
            // 
            this.SZBWrepositoryItemComboBox1.AutoHeight = false;
            this.SZBWrepositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SZBWrepositoryItemComboBox1.Name = "SZBWrepositoryItemComboBox1";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "备注";
            this.gridColumn7.FieldName = "BZ";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // JXTFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 440);
            this.Name = "JXTFForm";
            this.Text = "JXTFForm";
            this.Load += new System.EventHandler(this.JXTFForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JGGJMCbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JMXZbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QDbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MBZMbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HNTYQbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HNTQDbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JMCCbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CGSDbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JGFLbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TFQRQDbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LXSZbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCYQCSbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SZBWrepositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JXTFQDDEbindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GOLDSOFT.QDJJ.UI.Controls.GridControlEx gridControlEx1;
        private InfoGridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private ComBoxBW SZBWrepositoryItemComboBox1;
        private popControl popControl1;
        protected System.Windows.Forms.BindingSource JXTFQDDEbindingSource;
    }
}