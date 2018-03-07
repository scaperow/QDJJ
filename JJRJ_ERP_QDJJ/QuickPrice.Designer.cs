namespace GOLDSOFT.QDJJ.UI
{
    partial class QuickPrice
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.TabTY = new DevExpress.XtraTab.XtraTabControl();
            this.TYQFTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.YYH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TBJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BDJSJC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TabGJ = new DevExpress.XtraTab.XtraTabPage();
            this.TabDZ = new DevExpress.XtraTab.XtraTabPage();
            this.TabZJ = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabTY)).BeginInit();
            this.TabTY.SuspendLayout();
            this.TYQFTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.TabTY);
            this.panelControl1.Location = new System.Drawing.Point(4, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(549, 407);
            this.panelControl1.TabIndex = 0;
            // 
            // TabTY
            // 
            this.TabTY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabTY.Location = new System.Drawing.Point(2, 2);
            this.TabTY.Name = "TabTY";
            this.TabTY.SelectedTabPage = this.TYQFTabPage;
            this.TabTY.Size = new System.Drawing.Size(545, 403);
            this.TabTY.TabIndex = 1;
            this.TabTY.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TYQFTabPage,
            this.TabGJ,
            this.TabDZ,
            this.TabZJ});
            // 
            // TYQFTabPage
            // 
            this.TYQFTabPage.Controls.Add(this.groupControl1);
            this.TYQFTabPage.Controls.Add(this.panelControl3);
            this.TYQFTabPage.Name = "TYQFTabPage";
            this.TYQFTabPage.Size = new System.Drawing.Size(538, 373);
            this.TYQFTabPage.Text = "统一设置取费";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.radioGroup1);
            this.groupControl1.Location = new System.Drawing.Point(6, 302);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(531, 63);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "设置范围";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(2, 23);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "当前工程"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "分部分项"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "当前清单"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "当前子目"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "措施项目")});
            this.radioGroup1.Size = new System.Drawing.Size(527, 38);
            this.radioGroup1.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.gridControl1);
            this.panelControl3.Location = new System.Drawing.Point(4, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(533, 293);
            this.panelControl3.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(529, 289);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.YYH,
            this.MC,
            this.TBJSJC,
            this.BDJSJC,
            this.FL,
            this.BZ});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // YYH
            // 
            this.YYH.AppearanceHeader.Options.UseTextOptions = true;
            this.YYH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YYH.Caption = "引用号";
            this.YYH.FieldName = "YYH";
            this.YYH.Name = "YYH";
            this.YYH.OptionsColumn.AllowEdit = false;
            this.YYH.OptionsFilter.AllowFilter = false;
            this.YYH.Visible = true;
            this.YYH.VisibleIndex = 0;
            this.YYH.Width = 64;
            // 
            // MC
            // 
            this.MC.AppearanceHeader.Options.UseTextOptions = true;
            this.MC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MC.Caption = "名称";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.OptionsFilter.AllowFilter = false;
            this.MC.Visible = true;
            this.MC.VisibleIndex = 1;
            this.MC.Width = 66;
            // 
            // TBJSJC
            // 
            this.TBJSJC.AppearanceHeader.Options.UseTextOptions = true;
            this.TBJSJC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TBJSJC.Caption = "市场价计算基础";
            this.TBJSJC.FieldName = "TBJSJC";
            this.TBJSJC.Name = "TBJSJC";
            this.TBJSJC.OptionsFilter.AllowFilter = false;
            this.TBJSJC.Visible = true;
            this.TBJSJC.VisibleIndex = 2;
            this.TBJSJC.Width = 109;
            // 
            // BDJSJC
            // 
            this.BDJSJC.AppearanceHeader.Options.UseTextOptions = true;
            this.BDJSJC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BDJSJC.Caption = "定额计算基础";
            this.BDJSJC.FieldName = "BDJSJC";
            this.BDJSJC.Name = "BDJSJC";
            this.BDJSJC.OptionsFilter.AllowFilter = false;
            this.BDJSJC.Visible = true;
            this.BDJSJC.VisibleIndex = 3;
            this.BDJSJC.Width = 117;
            // 
            // FL
            // 
            this.FL.AppearanceCell.Options.UseTextOptions = true;
            this.FL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FL.AppearanceHeader.Options.UseTextOptions = true;
            this.FL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FL.Caption = "费率";
            this.FL.FieldName = "FL";
            this.FL.Name = "FL";
            this.FL.OptionsFilter.AllowFilter = false;
            this.FL.Visible = true;
            this.FL.VisibleIndex = 4;
            this.FL.Width = 70;
            // 
            // BZ
            // 
            this.BZ.AppearanceHeader.Options.UseTextOptions = true;
            this.BZ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BZ.Caption = "备注";
            this.BZ.FieldName = "BZ";
            this.BZ.Name = "BZ";
            this.BZ.OptionsFilter.AllowFilter = false;
            this.BZ.Visible = true;
            this.BZ.VisibleIndex = 5;
            this.BZ.Width = 82;
            // 
            // TabGJ
            // 
            this.TabGJ.Name = "TabGJ";
            this.TabGJ.PageVisible = false;
            this.TabGJ.Size = new System.Drawing.Size(538, 373);
            this.TabGJ.Text = "高级设置";
            // 
            // TabDZ
            // 
            this.TabDZ.Name = "TabDZ";
            this.TabDZ.PageVisible = false;
            this.TabDZ.Size = new System.Drawing.Size(538, 373);
            this.TabDZ.Text = "定值调整";
            // 
            // TabZJ
            // 
            this.TabZJ.Name = "TabZJ";
            this.TabZJ.PageVisible = false;
            this.TabZJ.Size = new System.Drawing.Size(538, 373);
            this.TabZJ.Text = "造价还原";
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.simpleButton2);
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Location = new System.Drawing.Point(4, 416);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(547, 41);
            this.panelControl2.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(430, 11);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(314, 11);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // QuickPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 465);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "QuickPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快速调价";
            this.Load += new System.EventHandler(this.QuickPrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabTY)).EndInit();
            this.TabTY.ResumeLayout(false);
            this.TYQFTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl TabTY;
        private DevExpress.XtraTab.XtraTabPage TYQFTabPage;
        private DevExpress.XtraTab.XtraTabPage TabGJ;
        private DevExpress.XtraTab.XtraTabPage TabDZ;
        private DevExpress.XtraTab.XtraTabPage TabZJ;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn YYH;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn TBJSJC;
        private DevExpress.XtraGrid.Columns.GridColumn BDJSJC;
        private DevExpress.XtraGrid.Columns.GridColumn FL;
        private DevExpress.XtraGrid.Columns.GridColumn BZ;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;

    }
}