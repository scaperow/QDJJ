using GOLDSOFT.QDJJ.CTRL;
namespace GOLDSOFT.QDJJ.UI
{
    partial class AreaQuantityUnit
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new GOLDSOFT.QDJJ.CTRL.GridViewEx();
            this.BH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SLH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit2 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditFour();
            this.SCDJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new GOLDSOFT.QDJJ.CTRL.RepositoryItemCalcEditTwo();
            this.DEDJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YTLB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.RaiseColumns = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemCalcEdit2});
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(671, 155);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseUp);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridView1.ColumnColor = null;
            this.gridView1.ColumnLayout = null;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BH,
            this.MC,
            this.LB,
            this.DW,
            this.SLH,
            this.SCDJ,
            this.DEDJ,
            this.YTLB});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.ModelName = "";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SchemeColor = null;
            this.gridView1.SetRowColorChange += new GOLDSOFT.QDJJ.COMMONS.SetRowColorHandler(this.gridView1_SetRowColorChange);
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseUp);
            // 
            // BH
            // 
            this.BH.AppearanceCell.Options.UseTextOptions = true;
            this.BH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BH.AppearanceHeader.Options.UseTextOptions = true;
            this.BH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BH.Caption = "工料机编号";
            this.BH.FieldName = "BH";
            this.BH.Name = "BH";
            this.BH.OptionsColumn.AllowEdit = false;
            this.BH.Visible = true;
            this.BH.VisibleIndex = 0;
            this.BH.Width = 81;
            // 
            // MC
            // 
            this.MC.AppearanceCell.Options.UseTextOptions = true;
            this.MC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.MC.AppearanceHeader.Options.UseTextOptions = true;
            this.MC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MC.Caption = "名称";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.OptionsColumn.AllowEdit = false;
            this.MC.Visible = true;
            this.MC.VisibleIndex = 1;
            this.MC.Width = 168;
            // 
            // LB
            // 
            this.LB.AppearanceCell.Options.UseTextOptions = true;
            this.LB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LB.AppearanceHeader.Options.UseTextOptions = true;
            this.LB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LB.Caption = "类别";
            this.LB.FieldName = "LB";
            this.LB.Name = "LB";
            this.LB.OptionsColumn.AllowEdit = false;
            this.LB.Visible = true;
            this.LB.VisibleIndex = 2;
            this.LB.Width = 66;
            // 
            // DW
            // 
            this.DW.AppearanceCell.Options.UseTextOptions = true;
            this.DW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DW.AppearanceHeader.Options.UseTextOptions = true;
            this.DW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DW.Caption = "单位";
            this.DW.FieldName = "DW";
            this.DW.Name = "DW";
            this.DW.OptionsColumn.AllowEdit = false;
            this.DW.Visible = true;
            this.DW.VisibleIndex = 3;
            this.DW.Width = 66;
            // 
            // SLH
            // 
            this.SLH.AppearanceCell.Options.UseTextOptions = true;
            this.SLH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SLH.AppearanceHeader.Options.UseTextOptions = true;
            this.SLH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SLH.Caption = "数量";
            this.SLH.ColumnEdit = this.repositoryItemCalcEdit2;
            this.SLH.FieldName = "SL";
            this.SLH.Name = "SLH";
            this.SLH.OptionsColumn.AllowEdit = false;
            this.SLH.Visible = true;
            this.SLH.VisibleIndex = 4;
            this.SLH.Width = 66;
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
            // 
            // SCDJ
            // 
            this.SCDJ.AppearanceCell.Options.UseTextOptions = true;
            this.SCDJ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SCDJ.AppearanceHeader.Options.UseTextOptions = true;
            this.SCDJ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SCDJ.Caption = "市场单价";
            this.SCDJ.ColumnEdit = this.repositoryItemCalcEdit1;
            this.SCDJ.FieldName = "SCDJ";
            this.SCDJ.Name = "SCDJ";
            this.SCDJ.OptionsColumn.AllowEdit = false;
            this.SCDJ.Visible = true;
            this.SCDJ.VisibleIndex = 5;
            this.SCDJ.Width = 66;
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
            // 
            // DEDJ
            // 
            this.DEDJ.AppearanceCell.Options.UseTextOptions = true;
            this.DEDJ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.DEDJ.AppearanceHeader.Options.UseTextOptions = true;
            this.DEDJ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DEDJ.Caption = "定额单价";
            this.DEDJ.ColumnEdit = this.repositoryItemCalcEdit1;
            this.DEDJ.FieldName = "DEDJ";
            this.DEDJ.Name = "DEDJ";
            this.DEDJ.OptionsColumn.AllowEdit = false;
            this.DEDJ.Visible = true;
            this.DEDJ.VisibleIndex = 6;
            this.DEDJ.Width = 66;
            // 
            // YTLB
            // 
            this.YTLB.AppearanceCell.Options.UseTextOptions = true;
            this.YTLB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YTLB.AppearanceHeader.Options.UseTextOptions = true;
            this.YTLB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YTLB.Caption = "用途类别";
            this.YTLB.FieldName = "YTLB";
            this.YTLB.Name = "YTLB";
            this.YTLB.OptionsColumn.AllowEdit = false;
            this.YTLB.Visible = true;
            this.YTLB.VisibleIndex = 7;
            this.YTLB.Width = 71;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.RaiseColumns});
            this.barManager1.MaxItemId = 1;
            // 
            // RaiseColumns
            // 
            this.RaiseColumns.Caption = "显示/隐藏列";
            this.RaiseColumns.Id = 0;
            this.RaiseColumns.Name = "RaiseColumns";
            this.RaiseColumns.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RaiseColumns_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.RaiseColumns)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // AreaQuantityUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 155);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "AreaQuantityUnit";
            this.Text = "AreaQuantityUnit";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private GridViewEx gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn BH;
        private DevExpress.XtraGrid.Columns.GridColumn LB;
        private DevExpress.XtraGrid.Columns.GridColumn DW;
        private DevExpress.XtraGrid.Columns.GridColumn SCDJ;
        private DevExpress.XtraGrid.Columns.GridColumn YTLB;
        private DevExpress.XtraGrid.Columns.GridColumn SLH;
        private DevExpress.XtraGrid.Columns.GridColumn DEDJ;
        private RepositoryItemCalcEditTwo repositoryItemCalcEdit1;
        private RepositoryItemCalcEditFour repositoryItemCalcEdit2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem RaiseColumns;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}