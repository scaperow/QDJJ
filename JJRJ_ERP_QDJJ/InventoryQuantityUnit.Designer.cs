using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class InventoryQuantityUnit
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new GOLDSOFT.QDJJ.CTRL.GridViewEx();
            this.BH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SLH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SCDJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SCHJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEDJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEHJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YTLB = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(829, 160);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnLayout = null;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BH,
            this.MC,
            this.LB,
            this.DW,
            this.SLH,
            this.SCDJ,
            this.SCHJ,
            this.DEDJ,
            this.DEHJ,
            this.YTLB});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.ModelName = "";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SchemeColor = null;
            this.gridView1.SetRowColorChange += new GOLDSOFT.QDJJ.COMMONS.SetRowColorHandler(this.gridView1_SetRowColorChange);
            // 
            // BH
            // 
            this.BH.Caption = "工料机编号";
            this.BH.FieldName = "BH";
            this.BH.Name = "BH";
            this.BH.OptionsColumn.AllowEdit = false;
            this.BH.OptionsFilter.AllowAutoFilter = false;
            this.BH.Visible = true;
            this.BH.VisibleIndex = 0;
            // 
            // MC
            // 
            this.MC.Caption = "名称";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.OptionsColumn.AllowEdit = false;
            this.MC.OptionsFilter.AllowAutoFilter = false;
            this.MC.Visible = true;
            this.MC.VisibleIndex = 1;
            // 
            // LB
            // 
            this.LB.Caption = "类别";
            this.LB.FieldName = "LB";
            this.LB.Name = "LB";
            this.LB.OptionsColumn.AllowEdit = false;
            this.LB.OptionsFilter.AllowAutoFilter = false;
            this.LB.Visible = true;
            this.LB.VisibleIndex = 2;
            // 
            // DW
            // 
            this.DW.Caption = "单位";
            this.DW.FieldName = "DW";
            this.DW.Name = "DW";
            this.DW.OptionsColumn.AllowEdit = false;
            this.DW.OptionsFilter.AllowAutoFilter = false;
            this.DW.Visible = true;
            this.DW.VisibleIndex = 3;
            // 
            // SLH
            // 
            this.SLH.Caption = "数量";
            this.SLH.DisplayFormat.FormatString = "0.0000";
            this.SLH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SLH.FieldName = "SLH";
            this.SLH.Name = "SLH";
            this.SLH.OptionsColumn.AllowEdit = false;
            this.SLH.OptionsFilter.AllowAutoFilter = false;
            this.SLH.Visible = true;
            this.SLH.VisibleIndex = 4;
            // 
            // SCDJ
            // 
            this.SCDJ.Caption = "市场单价";
            this.SCDJ.DisplayFormat.FormatString = "0.00";
            this.SCDJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SCDJ.FieldName = "SCDJ";
            this.SCDJ.Name = "SCDJ";
            this.SCDJ.OptionsColumn.AllowEdit = false;
            this.SCDJ.OptionsFilter.AllowAutoFilter = false;
            this.SCDJ.Visible = true;
            this.SCDJ.VisibleIndex = 5;
            // 
            // SCHJ
            // 
            this.SCHJ.Caption = "市场合价";
            this.SCHJ.DisplayFormat.FormatString = "0.00";
            this.SCHJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SCHJ.FieldName = "SLSCHJ";
            this.SCHJ.Name = "SCHJ";
            this.SCHJ.OptionsColumn.AllowEdit = false;
            this.SCHJ.Visible = true;
            this.SCHJ.VisibleIndex = 6;
            // 
            // DEDJ
            // 
            this.DEDJ.Caption = "定额单价";
            this.DEDJ.DisplayFormat.FormatString = "0.00";
            this.DEDJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DEDJ.FieldName = "DEDJ";
            this.DEDJ.Name = "DEDJ";
            this.DEDJ.OptionsColumn.AllowEdit = false;
            this.DEDJ.Visible = true;
            this.DEDJ.VisibleIndex = 7;
            // 
            // DEHJ
            // 
            this.DEHJ.Caption = "定额合价";
            this.DEHJ.DisplayFormat.FormatString = "0.00";
            this.DEHJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DEHJ.FieldName = "SLDEHJ";
            this.DEHJ.Name = "DEHJ";
            // 
            // YTLB
            // 
            this.YTLB.Caption = "用途类别";
            this.YTLB.FieldName = "YTLB";
            this.YTLB.Name = "YTLB";
            this.YTLB.OptionsColumn.AllowEdit = false;
            this.YTLB.OptionsFilter.AllowAutoFilter = false;
            this.YTLB.Visible = true;
            this.YTLB.VisibleIndex = 8;
            // 
            // InventoryQuantityUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 160);
            this.Controls.Add(this.gridControl1);
            this.Name = "InventoryQuantityUnit";
            this.Text = "InventoryQuantityUnit";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private GridViewEx gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn BH;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn LB;
        private DevExpress.XtraGrid.Columns.GridColumn DW;
        private DevExpress.XtraGrid.Columns.GridColumn SCDJ;
        private DevExpress.XtraGrid.Columns.GridColumn SLH;
        private DevExpress.XtraGrid.Columns.GridColumn YTLB;
        private DevExpress.XtraGrid.Columns.GridColumn DEDJ;
        private DevExpress.XtraGrid.Columns.GridColumn SCHJ;
        private DevExpress.XtraGrid.Columns.GridColumn DEHJ;


    }
}