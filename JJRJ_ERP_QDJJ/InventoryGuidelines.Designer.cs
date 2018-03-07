namespace GOLDSOFT.QDJJ.UI
{
    partial class InventoryGuidelines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryGuidelines));
            this.sButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl4 = new DevExpress.XtraEditors.SplitContainerControl();
            this.listGallery1 = new GOLDSOFT.QDJJ.CTRL.ListGallery();
            this.comboxTreelist1 = new GOLDSOFT.QDJJ.CTRL.TreeListEx();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).BeginInit();
            this.splitContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboxTreelist1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // sButtonOK
            // 
            this.sButtonOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sButtonOK.Location = new System.Drawing.Point(597, 5);
            this.sButtonOK.Name = "sButtonOK";
            this.sButtonOK.Size = new System.Drawing.Size(98, 23);
            this.sButtonOK.TabIndex = 0;
            this.sButtonOK.Tag = "0";
            this.sButtonOK.Text = "插入定额";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.splitContainerControl4);
            this.panelControl1.Location = new System.Drawing.Point(-1, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(801, 523);
            this.panelControl1.TabIndex = 1;
            // 
            // splitContainerControl4
            // 
            this.splitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl4.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl4.Name = "splitContainerControl4";
            this.splitContainerControl4.Panel1.Controls.Add(this.listGallery1);
            this.splitContainerControl4.Panel1.Text = "Panel1";
            this.splitContainerControl4.Panel2.Controls.Add(this.comboxTreelist1);
            this.splitContainerControl4.Panel2.Text = "Panel2";
            this.splitContainerControl4.Size = new System.Drawing.Size(797, 519);
            this.splitContainerControl4.SplitterPosition = 220;
            this.splitContainerControl4.TabIndex = 0;
            this.splitContainerControl4.Text = "splitContainerControl4";
            // 
            // listGallery1
            // 
            this.listGallery1.Activitie = null;
            this.listGallery1.BackColor = System.Drawing.Color.Transparent;
            this.listGallery1.CurrentBusiness = null;
            this.listGallery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGallery1.IsChange = false;
            this.listGallery1.Location = new System.Drawing.Point(0, 0);
            this.listGallery1.Name = "listGallery1";
            this.listGallery1.Size = new System.Drawing.Size(220, 519);
            this.listGallery1.TabIndex = 0;
            // 
            // comboxTreelist1
            // 
            this.comboxTreelist1.AllowDoubleEdit = false;
            this.comboxTreelist1.AllowSort = false;
            this.comboxTreelist1.CheckNodes = ((System.Collections.ArrayList)(resources.GetObject("comboxTreelist1.CheckNodes")));
            this.comboxTreelist1.ClickCount = 0;
            this.comboxTreelist1.ColumnColor = null;
            this.comboxTreelist1.ColumnLayout = null;
            this.comboxTreelist1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.comboxTreelist1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboxTreelist1.Location = new System.Drawing.Point(0, 0);
            this.comboxTreelist1.ModelName = "";
            this.comboxTreelist1.Name = "comboxTreelist1";
            this.comboxTreelist1.OptionsBehavior.Editable = false;
            this.comboxTreelist1.OptionsBehavior.ImmediateEditor = false;
            this.comboxTreelist1.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.comboxTreelist1.OptionsView.ShowCheckBoxes = true;
            this.comboxTreelist1.SchemeColor = null;
            this.comboxTreelist1.Size = new System.Drawing.Size(571, 519);
            this.comboxTreelist1.TabIndex = 1;
            this.comboxTreelist1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.comboxTreelist1_MouseDoubleClick);
            this.comboxTreelist1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.comboxTreelist1_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "定额号";
            this.treeListColumn1.FieldName = "DINGEH";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 86;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "定额名称";
            this.treeListColumn2.FieldName = "DINGEMC";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 372;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "定额单位";
            this.treeListColumn3.FieldName = "DINGEDW";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 92;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.simpleButton3);
            this.panelControl2.Controls.Add(this.sButtonOK);
            this.panelControl2.Location = new System.Drawing.Point(1, 529);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(797, 32);
            this.panelControl2.TabIndex = 2;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton3.Location = new System.Drawing.Point(711, 5);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "关闭";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // InventoryGuidelines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 566);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "InventoryGuidelines";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清单指引";
            this.Load += new System.EventHandler(this.InventoryGuidelines_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).EndInit();
            this.splitContainerControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboxTreelist1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton sButtonOK;
        public GOLDSOFT.QDJJ.CTRL.ListGallery listGallery1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl4;
        public GOLDSOFT.QDJJ.CTRL.TreeListEx comboxTreelist1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;


    }
}