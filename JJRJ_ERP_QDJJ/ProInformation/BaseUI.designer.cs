namespace GOLDSOFT.QDJJ.UI
{
    partial class BaseUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseUI));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshGCL = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefreshQDMC = new DevExpress.XtraEditors.SimpleButton();
            this.btnScreenQDBH = new DevExpress.XtraEditors.SimpleButton();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAddRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnPasteRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataErr = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoveUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoveDown = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Location = new System.Drawing.Point(-1, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(916, 396);
            this.panelControl2.TabIndex = 9;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnUp);
            this.panelControl1.Controls.Add(this.btnDown);
            this.panelControl1.Controls.Add(this.btnRefreshGCL);
            this.panelControl1.Controls.Add(this.btnRefreshQDMC);
            this.panelControl1.Controls.Add(this.btnScreenQDBH);
            this.panelControl1.Controls.Add(this.barDockControlLeft);
            this.panelControl1.Controls.Add(this.barDockControlRight);
            this.panelControl1.Controls.Add(this.barDockControlBottom);
            this.panelControl1.Controls.Add(this.barDockControlTop);
            this.panelControl1.Location = new System.Drawing.Point(-1, 396);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(916, 44);
            this.panelControl1.TabIndex = 8;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Location = new System.Drawing.Point(336, 9);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(88, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "上移";
            this.btnUp.Click += new System.EventHandler(this.btnMoveUp_ItemClick);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Location = new System.Drawing.Point(444, 9);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(88, 23);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "下移";
            this.btnDown.Click += new System.EventHandler(this.btnMoveDown_ItemClick);
            // 
            // btnRefreshGCL
            // 
            this.btnRefreshGCL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshGCL.Location = new System.Drawing.Point(228, 9);
            this.btnRefreshGCL.Name = "btnRefreshGCL";
            this.btnRefreshGCL.Size = new System.Drawing.Size(88, 23);
            this.btnRefreshGCL.TabIndex = 4;
            this.btnRefreshGCL.Text = "刷新数量";
            this.btnRefreshGCL.Click += new System.EventHandler(this.btnRefreshGCL_Click);
            // 
            // btnRefreshQDMC
            // 
            this.btnRefreshQDMC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshQDMC.Location = new System.Drawing.Point(120, 9);
            this.btnRefreshQDMC.Name = "btnRefreshQDMC";
            this.btnRefreshQDMC.Size = new System.Drawing.Size(88, 23);
            this.btnRefreshQDMC.TabIndex = 4;
            this.btnRefreshQDMC.Text = "刷新描述";
            this.btnRefreshQDMC.Click += new System.EventHandler(this.btnRefreshQDMC_Click);
            // 
            // btnScreenQDBH
            // 
            this.btnScreenQDBH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScreenQDBH.Location = new System.Drawing.Point(12, 9);
            this.btnScreenQDBH.Name = "btnScreenQDBH";
            this.btnScreenQDBH.Size = new System.Drawing.Size(88, 23);
            this.btnScreenQDBH.TabIndex = 4;
            this.btnScreenQDBH.Text = "刷新全部";
            this.btnScreenQDBH.Click += new System.EventHandler(this.btnScreenQDBH_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopyRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPasteRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataErr)
            //new DevExpress.XtraBars.LinkPersistInfo(this.btnMoveUp),
            //new DevExpress.XtraBars.LinkPersistInfo(this.btnMoveDown)
            });
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Caption = "添加";
            this.btnAddRow.Id = 0;
            this.btnAddRow.ImageIndex = 0;
            this.btnAddRow.LargeImageIndex = 0;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddRow_ItemClick);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Caption = "删除所选项";
            this.btnDelRow.Id = 1;
            this.btnDelRow.ImageIndex = 2;
            this.btnDelRow.LargeImageIndex = 2;
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelRow_ItemClick);
            // 
            // btnCopyRow
            // 
            this.btnCopyRow.Caption = "复制";
            this.btnCopyRow.Id = 2;
            this.btnCopyRow.ImageIndex = 1;
            this.btnCopyRow.LargeImageIndex = 1;
            this.btnCopyRow.Name = "btnCopyRow";
            this.btnCopyRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyRow_ItemClick);
            // 
            // btnPasteRow
            // 
            this.btnPasteRow.Caption = "粘贴";
            this.btnPasteRow.Id = 3;
            this.btnPasteRow.ImageIndex = 3;
            this.btnPasteRow.LargeImageIndex = 3;
            this.btnPasteRow.Name = "btnPasteRow";
            this.btnPasteRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPasteRow_ItemClick);
            // 
            // btnDataErr
            // 
            this.btnDataErr.Caption = "错误信息上报";
            this.btnDataErr.Id = 6;
            this.btnDataErr.Name = "btnDataErr";
            this.btnDataErr.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataErr_ItemClick);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Caption = "上移";
            this.btnMoveUp.Id = 4;
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoveUp_ItemClick);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Caption = "下移";
            this.btnMoveDown.Id = 5;
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoveDown_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this.panelControl1;
            this.barManager1.Images = this.imageCollection;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddRow,
            this.btnDelRow,
            this.btnCopyRow,
            this.btnPasteRow,
            this.btnDataErr,
            this.btnMoveUp,
            this.btnMoveDown});
            this.barManager1.LargeImages = this.imageCollection;
            this.barManager1.MaxItemId = 7;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "添加.png");
            this.imageCollection.Images.SetKeyName(1, "复制.png");
            this.imageCollection.Images.SetKeyName(2, "删除.png");
            this.imageCollection.Images.SetKeyName(3, "粘贴.png");
            // 
            // BaseUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 440);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "BaseUI";
            this.Text = "BaseUI";
            this.Controls.SetChildIndex(this.functionList1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panelControl2;
        protected DevExpress.XtraEditors.PanelControl panelControl1;
        protected DevExpress.XtraEditors.SimpleButton btnRefreshQDMC;
        protected DevExpress.XtraEditors.SimpleButton btnScreenQDBH;
        protected System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.PopupMenu popupMenu1;
        protected DevExpress.XtraBars.BarButtonItem btnAddRow;
        protected DevExpress.XtraBars.BarButtonItem btnDelRow;
        protected DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem btnCopyRow;
        private DevExpress.XtraBars.BarButtonItem btnPasteRow;
        protected DevExpress.XtraEditors.SimpleButton btnRefreshGCL;
        private DevExpress.XtraBars.BarButtonItem btnDataErr;

        private DevExpress.XtraBars.BarButtonItem btnMoveUp;
        private DevExpress.XtraBars.BarButtonItem btnMoveDown;

        protected DevExpress.XtraEditors.SimpleButton btnUp;
        protected DevExpress.XtraEditors.SimpleButton btnDown;

    }
}