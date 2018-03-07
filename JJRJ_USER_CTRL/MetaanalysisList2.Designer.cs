namespace GOLDSOFT.QDJJ.CTRL
{
    partial class MetaanalysisList2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.id = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.name = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.zongMoney = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.fbfxf = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.csxmf = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.qtxmf = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.guifei = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.shuijin = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.laobao = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.aqwmsgf = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bl = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.PositionChanged += new System.EventHandler(this.bindingSource1_PositionChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(529, 325);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3,
            this.gridBand5,
            this.gridBand1,
            this.gridBand4});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.id,
            this.name,
            this.zongMoney,
            this.fbfxf,
            this.csxmf,
            this.qtxmf,
            this.guifei,
            this.shuijin,
            this.laobao,
            this.aqwmsgf,
            this.bl});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            // 
            // gridBand2
            // 
            this.gridBand2.Columns.Add(this.id);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 77;
            // 
            // id
            // 
            this.id.Caption = "序号";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowEdit = false;
            this.id.Visible = true;
            this.id.Width = 77;
            // 
            // gridBand3
            // 
            this.gridBand3.AutoFillDown = false;
            this.gridBand3.Columns.Add(this.name);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 119;
            // 
            // name
            // 
            this.name.Caption = "名称";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.OptionsColumn.AllowEdit = false;
            this.name.Visible = true;
            this.name.Width = 119;
            // 
            // gridBand5
            // 
            this.gridBand5.Columns.Add(this.zongMoney);
            this.gridBand5.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 77;
            // 
            // zongMoney
            // 
            this.zongMoney.Caption = "金额";
            this.zongMoney.FieldName = "zongMoney";
            this.zongMoney.Name = "zongMoney";
            this.zongMoney.OptionsColumn.AllowEdit = false;
            this.zongMoney.Visible = true;
            this.zongMoney.Width = 77;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "                                                 其中";
            this.gridBand1.Columns.Add(this.fbfxf);
            this.gridBand1.Columns.Add(this.csxmf);
            this.gridBand1.Columns.Add(this.qtxmf);
            this.gridBand1.Columns.Add(this.guifei);
            this.gridBand1.Columns.Add(this.shuijin);
            this.gridBand1.Columns.Add(this.laobao);
            this.gridBand1.Columns.Add(this.aqwmsgf);
            this.gridBand1.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 542;
            // 
            // fbfxf
            // 
            this.fbfxf.Caption = "分部分项费";
            this.fbfxf.FieldName = "fbfxf";
            this.fbfxf.Name = "fbfxf";
            this.fbfxf.OptionsColumn.AllowEdit = false;
            this.fbfxf.Visible = true;
            this.fbfxf.Width = 77;
            // 
            // csxmf
            // 
            this.csxmf.Caption = "措施项目费";
            this.csxmf.FieldName = "csxmf";
            this.csxmf.Name = "csxmf";
            this.csxmf.OptionsColumn.AllowEdit = false;
            this.csxmf.Visible = true;
            this.csxmf.Width = 77;
            // 
            // qtxmf
            // 
            this.qtxmf.Caption = "其他项目费";
            this.qtxmf.FieldName = "qtxmf";
            this.qtxmf.Name = "qtxmf";
            this.qtxmf.OptionsColumn.AllowEdit = false;
            this.qtxmf.Visible = true;
            this.qtxmf.Width = 77;
            // 
            // guifei
            // 
            this.guifei.Caption = "规费";
            this.guifei.FieldName = "guifei";
            this.guifei.Name = "guifei";
            this.guifei.OptionsColumn.AllowEdit = false;
            this.guifei.Visible = true;
            this.guifei.Width = 77;
            // 
            // shuijin
            // 
            this.shuijin.Caption = "税金";
            this.shuijin.FieldName = "shuijin";
            this.shuijin.Name = "shuijin";
            this.shuijin.OptionsColumn.AllowEdit = false;
            this.shuijin.Visible = true;
            this.shuijin.Width = 77;
            // 
            // laobao
            // 
            this.laobao.Caption = "劳保费用";
            this.laobao.FieldName = "laobao";
            this.laobao.Name = "laobao";
            this.laobao.OptionsColumn.AllowEdit = false;
            this.laobao.Visible = true;
            this.laobao.Width = 77;
            // 
            // aqwmsgf
            // 
            this.aqwmsgf.Caption = "安全文明施工费";
            this.aqwmsgf.FieldName = "aqwmsgf";
            this.aqwmsgf.Name = "aqwmsgf";
            this.aqwmsgf.OptionsColumn.AllowEdit = false;
            this.aqwmsgf.Visible = true;
            this.aqwmsgf.Width = 80;
            // 
            // gridBand4
            // 
            this.gridBand4.Columns.Add(this.bl);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 75;
            // 
            // bl
            // 
            this.bl.Caption = "占造价比例(%)";
            this.bl.FieldName = "bl";
            this.bl.Name = "bl";
            this.bl.OptionsColumn.AllowEdit = false;
            this.bl.Visible = true;
            // 
            // MetaanalysisList2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "MetaanalysisList2";
            this.Size = new System.Drawing.Size(529, 325);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn id;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn name;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn zongMoney;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn fbfxf;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn csxmf;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn qtxmf;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn guifei;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn shuijin;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn laobao;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn aqwmsgf;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bl;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
    }
}
