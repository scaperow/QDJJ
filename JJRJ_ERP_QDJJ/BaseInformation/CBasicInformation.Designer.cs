namespace GOLDSOFT.QDJJ.UI
{
    partial class CBasicInformation
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.biddingInformation1 = new GOLDSOFT.QDJJ.CTRL.Information.BiddingInformation();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.ctrlBaseInfo1 = new GOLDSOFT.QDJJ.CTRL.Information.CtrlBaseInfo();
            this.tenderInformation1 = new GOLDSOFT.QDJJ.CTRL.Information.TenderInformation();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(778, 426);
            this.splitContainerControl1.SplitterPosition = 134;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.Red;
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Gray;
            this.treeList1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Gray;
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "Key";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "基本信息"}, -1);
            this.treeList1.AppendNode(new object[] {
            "招标信息"}, 0);
            this.treeList1.AppendNode(new object[] {
            "投标信息"}, 0);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "ParentFieldName";
            this.treeList1.Size = new System.Drawing.Size(134, 426);
            this.treeList1.TabIndex = 2;
            this.treeList1.DoubleClick += new System.EventHandler(this.treeList1_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 38;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(638, 426);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.biddingInformation1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(631, 419);
            this.xtraTabPage2.Text = "招标信息";
            // 
            // biddingInformation1
            // 
            this.biddingInformation1.Activitie = null;
            this.biddingInformation1.BackColor = System.Drawing.Color.Transparent;
            this.biddingInformation1.CurrentBusiness = null;
            this.biddingInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biddingInformation1.Location = new System.Drawing.Point(0, 0);
            this.biddingInformation1.Name = "biddingInformation1";
            this.biddingInformation1.Projects = null;
            this.biddingInformation1.Size = new System.Drawing.Size(631, 419);
            this.biddingInformation1.TabIndex = 0;
            this.biddingInformation1.Load += new System.EventHandler(this.biddingInformation1_Load);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.ctrlBaseInfo1);
            this.xtraTabPage3.Controls.Add(this.tenderInformation1);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(631, 419);
            this.xtraTabPage3.Text = "投标信息";
            // 
            // ctrlBaseInfo1
            // 
            this.ctrlBaseInfo1.Activitie = null;
            this.ctrlBaseInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlBaseInfo1.CurrentBusiness = null;
            this.ctrlBaseInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlBaseInfo1.Location = new System.Drawing.Point(0, 322);
            this.ctrlBaseInfo1.Name = "ctrlBaseInfo1";
            this.ctrlBaseInfo1.Size = new System.Drawing.Size(631, 97);
            this.ctrlBaseInfo1.TabIndex = 1;
            // 
            // tenderInformation1
            // 
            this.tenderInformation1.Activitie = null;
            this.tenderInformation1.BackColor = System.Drawing.Color.Transparent;
            this.tenderInformation1.CurrentBusiness = null;
            this.tenderInformation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenderInformation1.Location = new System.Drawing.Point(0, 0);
            this.tenderInformation1.Name = "tenderInformation1";
            this.tenderInformation1.Projects = null;
            this.tenderInformation1.Size = new System.Drawing.Size(631, 419);
            this.tenderInformation1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 432);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(778, 25);
            this.panelControl1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Image = global::GOLDSOFT.QDJJ.UI.Properties.Resources.确定;
            this.simpleButton1.Location = new System.Drawing.Point(689, 1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(85, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "变更";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // CBasicInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 457);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "CBasicInformation";
            this.Tag = "项目信息";
            this.Text = "项目信息";
            this.Load += new System.EventHandler(this.CBasicInformation_Load);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.functionList1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        public DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private GOLDSOFT.QDJJ.CTRL.Information.CtrlBaseInfo ctrlBaseInfo1;
        private GOLDSOFT.QDJJ.CTRL.Information.TenderInformation tenderInformation1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private GOLDSOFT.QDJJ.CTRL.Information.BiddingInformation biddingInformation1;

    }
}