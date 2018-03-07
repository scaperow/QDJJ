namespace GOLDSOFT.QDJJ.UI
{
    partial class BindingBHForm
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
            this.gridControlYTLB = new DevExpress.XtraGrid.GridControl();
            this.bandedGridViewYTLB = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn20 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn22 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn23 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn24 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn25 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn26 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn27 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn28 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand16 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn29 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn30 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlYTLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewYTLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlYTLB
            // 
            this.gridControlYTLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlYTLB.Location = new System.Drawing.Point(0, 0);
            this.gridControlYTLB.MainView = this.bandedGridViewYTLB;
            this.gridControlYTLB.Name = "gridControlYTLB";
            this.gridControlYTLB.Size = new System.Drawing.Size(571, 267);
            this.gridControlYTLB.TabIndex = 11;
            this.gridControlYTLB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridViewYTLB});
            this.gridControlYTLB.Leave += new System.EventHandler(this.gridControlYTLB_Leave);
            // 
            // bandedGridViewYTLB
            // 
            this.bandedGridViewYTLB.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand13,
            this.gridBand14,
            this.gridBand15,
            this.gridBand16});
            this.bandedGridViewYTLB.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn20,
            this.bandedGridColumn22,
            this.bandedGridColumn23,
            this.bandedGridColumn24,
            this.bandedGridColumn25,
            this.bandedGridColumn26,
            this.bandedGridColumn27,
            this.bandedGridColumn28,
            this.bandedGridColumn29,
            this.bandedGridColumn30});
            this.bandedGridViewYTLB.GridControl = this.gridControlYTLB;
            this.bandedGridViewYTLB.Name = "bandedGridViewYTLB";
            this.bandedGridViewYTLB.OptionsView.ColumnAutoWidth = false;
            this.bandedGridViewYTLB.OptionsView.ShowGroupPanel = false;
            this.bandedGridViewYTLB.DoubleClick += new System.EventHandler(this.bandedGridViewYTLB_DoubleClick);
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "基本信息";
            this.gridBand13.Columns.Add(this.bandedGridColumn20);
            this.gridBand13.Columns.Add(this.bandedGridColumn22);
            this.gridBand13.Columns.Add(this.bandedGridColumn23);
            this.gridBand13.Columns.Add(this.bandedGridColumn24);
            this.gridBand13.MinWidth = 20;
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.Width = 400;
            // 
            // bandedGridColumn20
            // 
            this.bandedGridColumn20.Caption = "编号";
            this.bandedGridColumn20.FieldName = "BH";
            this.bandedGridColumn20.Name = "bandedGridColumn20";
            this.bandedGridColumn20.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn20.Visible = true;
            this.bandedGridColumn20.Width = 82;
            // 
            // bandedGridColumn22
            // 
            this.bandedGridColumn22.Caption = "名称";
            this.bandedGridColumn22.FieldName = "MC";
            this.bandedGridColumn22.Name = "bandedGridColumn22";
            this.bandedGridColumn22.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn22.Visible = true;
            this.bandedGridColumn22.Width = 138;
            // 
            // bandedGridColumn23
            // 
            this.bandedGridColumn23.Caption = "单位";
            this.bandedGridColumn23.FieldName = "DW";
            this.bandedGridColumn23.Name = "bandedGridColumn23";
            this.bandedGridColumn23.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn23.Visible = true;
            this.bandedGridColumn23.Width = 98;
            // 
            // bandedGridColumn24
            // 
            this.bandedGridColumn24.Caption = "消耗量";
            this.bandedGridColumn24.DisplayFormat.FormatString = "0.0000";
            this.bandedGridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn24.FieldName = "SLH";
            this.bandedGridColumn24.Name = "bandedGridColumn24";
            this.bandedGridColumn24.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn24.Visible = true;
            this.bandedGridColumn24.Width = 82;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.Caption = "单价";
            this.gridBand14.Columns.Add(this.bandedGridColumn25);
            this.gridBand14.Columns.Add(this.bandedGridColumn26);
            this.gridBand14.MinWidth = 20;
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.Width = 150;
            // 
            // bandedGridColumn25
            // 
            this.bandedGridColumn25.Caption = "定额价";
            this.bandedGridColumn25.DisplayFormat.FormatString = "0.00";
            this.bandedGridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn25.FieldName = "DEDJ";
            this.bandedGridColumn25.Name = "bandedGridColumn25";
            this.bandedGridColumn25.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn25.Visible = true;
            // 
            // bandedGridColumn26
            // 
            this.bandedGridColumn26.Caption = "市场价";
            this.bandedGridColumn26.DisplayFormat.FormatString = "0.00";
            this.bandedGridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn26.FieldName = "SCDJ";
            this.bandedGridColumn26.Name = "bandedGridColumn26";
            this.bandedGridColumn26.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn26.Visible = true;
            // 
            // gridBand15
            // 
            this.gridBand15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand15.Caption = "合价";
            this.gridBand15.Columns.Add(this.bandedGridColumn27);
            this.gridBand15.Columns.Add(this.bandedGridColumn28);
            this.gridBand15.MinWidth = 20;
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.Width = 150;
            // 
            // bandedGridColumn27
            // 
            this.bandedGridColumn27.Caption = "定额价";
            this.bandedGridColumn27.DisplayFormat.FormatString = "0.00";
            this.bandedGridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn27.FieldName = "DEHJ";
            this.bandedGridColumn27.Name = "bandedGridColumn27";
            this.bandedGridColumn27.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn27.Visible = true;
            // 
            // bandedGridColumn28
            // 
            this.bandedGridColumn28.Caption = "市场价";
            this.bandedGridColumn28.DisplayFormat.FormatString = "0.00";
            this.bandedGridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn28.FieldName = "SCHJ";
            this.bandedGridColumn28.Name = "bandedGridColumn28";
            this.bandedGridColumn28.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn28.Visible = true;
            // 
            // gridBand16
            // 
            this.gridBand16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand16.Caption = "价差";
            this.gridBand16.Columns.Add(this.bandedGridColumn29);
            this.gridBand16.Columns.Add(this.bandedGridColumn30);
            this.gridBand16.MinWidth = 20;
            this.gridBand16.Name = "gridBand16";
            this.gridBand16.Width = 150;
            // 
            // bandedGridColumn29
            // 
            this.bandedGridColumn29.Caption = "单价";
            this.bandedGridColumn29.DisplayFormat.FormatString = "0.00";
            this.bandedGridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn29.FieldName = "JC";
            this.bandedGridColumn29.Name = "bandedGridColumn29";
            this.bandedGridColumn29.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn29.Visible = true;
            // 
            // bandedGridColumn30
            // 
            this.bandedGridColumn30.Caption = "合价";
            this.bandedGridColumn30.DisplayFormat.FormatString = "0.00";
            this.bandedGridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn30.FieldName = "HJC";
            this.bandedGridColumn30.Name = "bandedGridColumn30";
            this.bandedGridColumn30.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn30.Visible = true;
            // 
            // BindingBHForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 267);
            this.Controls.Add(this.gridControlYTLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BindingBHForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BindingBHForm";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.BindingBHForm_Deactivate);
            this.Load += new System.EventHandler(this.BindingBHForm_Load);
            this.Leave += new System.EventHandler(this.BindingBHForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlYTLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewYTLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlYTLB;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridViewYTLB;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn20;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn22;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn23;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn24;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn25;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn26;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn27;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn28;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn29;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn30;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}