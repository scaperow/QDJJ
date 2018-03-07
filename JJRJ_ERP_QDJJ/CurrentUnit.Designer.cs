using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class CurrentUnit
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
            this.gridControlBDGLJ = new DevExpress.XtraGrid.GridControl();
            this.bandedGridViewBDGLJ = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.基础信息 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn32 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn39 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn41 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn43 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn45 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn47 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn48 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn49 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCalcEdit1 = new RepositoryItemCalcEditTwo();
            this.repositoryItemCalcEdit2 = new RepositoryItemCalcEditFour();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBDGLJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewBDGLJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlBDGLJ
            // 
            this.gridControlBDGLJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlBDGLJ.Location = new System.Drawing.Point(0, 0);
            this.gridControlBDGLJ.MainView = this.bandedGridViewBDGLJ;
            this.gridControlBDGLJ.Name = "gridControlBDGLJ";
            this.gridControlBDGLJ.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemCalcEdit2});
            this.gridControlBDGLJ.ShowOnlyPredefinedDetails = true;
            this.gridControlBDGLJ.Size = new System.Drawing.Size(692, 366);
            this.gridControlBDGLJ.TabIndex = 1;
            this.gridControlBDGLJ.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridViewBDGLJ});
            // 
            // bandedGridViewBDGLJ
            // 
            this.bandedGridViewBDGLJ.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.基础信息,
            this.gridBand12,
            this.gridBand13,
            this.gridBand14});
            this.bandedGridViewBDGLJ.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn32,
            this.bandedGridColumn39,
            this.bandedGridColumn40,
            this.bandedGridColumn41,
            this.bandedGridColumn42,
            this.bandedGridColumn43,
            this.bandedGridColumn44,
            this.bandedGridColumn45,
            this.bandedGridColumn46,
            this.bandedGridColumn47,
            this.bandedGridColumn48,
            this.bandedGridColumn49});
            this.bandedGridViewBDGLJ.GridControl = this.gridControlBDGLJ;
            this.bandedGridViewBDGLJ.Name = "bandedGridViewBDGLJ";
            this.bandedGridViewBDGLJ.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bandedGridViewBDGLJ.OptionsView.ColumnAutoWidth = false;
            this.bandedGridViewBDGLJ.OptionsView.EnableAppearanceEvenRow = true;
            this.bandedGridViewBDGLJ.OptionsView.EnableAppearanceOddRow = true;
            this.bandedGridViewBDGLJ.OptionsView.ShowGroupPanel = false;
            this.bandedGridViewBDGLJ.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            // 
            // 基础信息
            // 
            this.基础信息.AppearanceHeader.Options.UseTextOptions = true;
            this.基础信息.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.基础信息.Caption = "基础信息";
            this.基础信息.Columns.Add(this.bandedGridColumn32);
            this.基础信息.Columns.Add(this.bandedGridColumn39);
            this.基础信息.Columns.Add(this.bandedGridColumn40);
            this.基础信息.Columns.Add(this.bandedGridColumn41);
            this.基础信息.Columns.Add(this.bandedGridColumn42);
            this.基础信息.Columns.Add(this.bandedGridColumn43);
            this.基础信息.Name = "基础信息";
            this.基础信息.Width = 499;
            // 
            // bandedGridColumn32
            // 
            this.bandedGridColumn32.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn32.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bandedGridColumn32.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn32.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn32.Caption = "编号";
            this.bandedGridColumn32.FieldName = "BH";
            this.bandedGridColumn32.Name = "bandedGridColumn32";
            this.bandedGridColumn32.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn32.Visible = true;
            this.bandedGridColumn32.Width = 84;
            // 
            // bandedGridColumn39
            // 
            this.bandedGridColumn39.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn39.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bandedGridColumn39.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn39.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn39.Caption = "名称";
            this.bandedGridColumn39.FieldName = "MC";
            this.bandedGridColumn39.Name = "bandedGridColumn39";
            this.bandedGridColumn39.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn39.Visible = true;
            this.bandedGridColumn39.Width = 159;
            // 
            // bandedGridColumn40
            // 
            this.bandedGridColumn40.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn40.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn40.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn40.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn40.Caption = "类别";
            this.bandedGridColumn40.FieldName = "LB";
            this.bandedGridColumn40.Name = "bandedGridColumn40";
            this.bandedGridColumn40.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn40.Visible = true;
            this.bandedGridColumn40.Width = 84;
            // 
            // bandedGridColumn41
            // 
            this.bandedGridColumn41.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn41.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn41.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn41.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn41.Caption = "单位";
            this.bandedGridColumn41.FieldName = "DW";
            this.bandedGridColumn41.Name = "bandedGridColumn41";
            this.bandedGridColumn41.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn41.Visible = true;
            this.bandedGridColumn41.Width = 84;
            // 
            // bandedGridColumn42
            // 
            this.bandedGridColumn42.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn42.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn42.Caption = "数量";
            this.bandedGridColumn42.ColumnEdit = this.repositoryItemCalcEdit2;
            this.bandedGridColumn42.FieldName = "SL";
            this.bandedGridColumn42.Name = "bandedGridColumn42";
            this.bandedGridColumn42.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn42.Visible = true;
            this.bandedGridColumn42.Width = 88;
            // 
            // bandedGridColumn43
            // 
            this.bandedGridColumn43.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bandedGridColumn43.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn43.Caption = "规格型号";
            this.bandedGridColumn43.FieldName = "GGXH";
            this.bandedGridColumn43.Name = "bandedGridColumn43";
            this.bandedGridColumn43.OptionsColumn.AllowEdit = false;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "单价";
            this.gridBand12.Columns.Add(this.bandedGridColumn44);
            this.gridBand12.Columns.Add(this.bandedGridColumn45);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.Width = 150;
            // 
            // bandedGridColumn44
            // 
            this.bandedGridColumn44.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn44.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn44.Caption = "市场单价";
            this.bandedGridColumn44.ColumnEdit = this.repositoryItemCalcEdit1;
            this.bandedGridColumn44.FieldName = "SCDJ";
            this.bandedGridColumn44.Name = "bandedGridColumn44";
            this.bandedGridColumn44.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn44.Visible = true;
            // 
            // bandedGridColumn45
            // 
            this.bandedGridColumn45.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn45.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn45.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn45.Caption = "定额单价";
            this.bandedGridColumn45.ColumnEdit = this.repositoryItemCalcEdit1;
            this.bandedGridColumn45.FieldName = "DEDJ";
            this.bandedGridColumn45.Name = "bandedGridColumn45";
            this.bandedGridColumn45.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn45.Visible = true;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "合价";
            this.gridBand13.Columns.Add(this.bandedGridColumn46);
            this.gridBand13.Columns.Add(this.bandedGridColumn47);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.Width = 150;
            // 
            // bandedGridColumn46
            // 
            this.bandedGridColumn46.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn46.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn46.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn46.Caption = "市场合价";
            this.bandedGridColumn46.ColumnEdit = this.repositoryItemCalcEdit1;
            this.bandedGridColumn46.FieldName = "SCHJ";
            this.bandedGridColumn46.Name = "bandedGridColumn46";
            this.bandedGridColumn46.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn46.Visible = true;
            // 
            // bandedGridColumn47
            // 
            this.bandedGridColumn47.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn47.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn47.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn47.Caption = "定额合价";
            this.bandedGridColumn47.ColumnEdit = this.repositoryItemCalcEdit1;
            this.bandedGridColumn47.FieldName = "DEHJ";
            this.bandedGridColumn47.Name = "bandedGridColumn47";
            this.bandedGridColumn47.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn47.Visible = true;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.Caption = "价差";
            this.gridBand14.Columns.Add(this.bandedGridColumn48);
            this.gridBand14.Columns.Add(this.bandedGridColumn49);
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.Width = 150;
            // 
            // bandedGridColumn48
            // 
            this.bandedGridColumn48.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn48.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn48.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn48.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn48.Caption = "单价差";
            this.bandedGridColumn48.ColumnEdit = this.repositoryItemCalcEdit1;
            this.bandedGridColumn48.FieldName = "DJC";
            this.bandedGridColumn48.Name = "bandedGridColumn48";
            this.bandedGridColumn48.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn48.Visible = true;
            // 
            // bandedGridColumn49
            // 
            this.bandedGridColumn49.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn49.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.bandedGridColumn49.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn49.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn49.Caption = "合价差";
            this.bandedGridColumn49.ColumnEdit = this.repositoryItemCalcEdit1;
            this.bandedGridColumn49.FieldName = "HJC";
            this.bandedGridColumn49.Name = "bandedGridColumn49";
            this.bandedGridColumn49.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn49.Visible = true;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // repositoryItemCalcEdit2
            // 
            this.repositoryItemCalcEdit2.AutoHeight = false;
            this.repositoryItemCalcEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit2.Name = "repositoryItemCalcEdit2";
            // 
            // CurrentUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 366);
            this.Controls.Add(this.gridControlBDGLJ);
            this.Name = "CurrentUnit";
            this.Text = "CurrentUnit";
            this.Load += new System.EventHandler(this.CurrentUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBDGLJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewBDGLJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlBDGLJ;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand 基础信息;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn32;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn39;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn40;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn41;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn42;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn43;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn44;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn45;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn46;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn47;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn48;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn49;
        public DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridViewBDGLJ;
        private RepositoryItemCalcEditTwo repositoryItemCalcEdit1;
        private RepositoryItemCalcEditFour repositoryItemCalcEdit2;
    }
}