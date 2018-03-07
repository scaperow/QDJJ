namespace GOLDSOFT.QDJJ.UI
{
    partial class QueryGallery
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
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.listGalleryIndex1 = new GOLDSOFT.QDJJ.CTRL.ListGalleryIndex();
            this.galleryGridList1 = new GOLDSOFT.QDJJ.CTRL.GalleryGridList();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.sButtonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.splitContainerControl2);
            this.panelControl1.Location = new System.Drawing.Point(1, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(818, 416);
            this.panelControl1.TabIndex = 1;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.listGalleryIndex1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.galleryGridList1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(814, 412);
            this.splitContainerControl2.SplitterPosition = 241;
            this.splitContainerControl2.TabIndex = 12;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // listGalleryIndex1
            // 
            this.listGalleryIndex1.Activitie = null;
            this.listGalleryIndex1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listGalleryIndex1.BackColor = System.Drawing.Color.Transparent;
            this.listGalleryIndex1.CurrentBusiness = null;
            this.listGalleryIndex1.Location = new System.Drawing.Point(0, 0);
            this.listGalleryIndex1.Name = "listGalleryIndex1";
            this.listGalleryIndex1.Size = new System.Drawing.Size(241, 412);
            this.listGalleryIndex1.TabIndex = 0;
            // 
            // galleryGridList1
            // 
            this.galleryGridList1.Activitie = null;
            this.galleryGridList1.BackColor = System.Drawing.Color.Transparent;
            this.galleryGridList1.CurrentBusiness = null;
            this.galleryGridList1.DataSource = null;
            this.galleryGridList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.galleryGridList1.Location = new System.Drawing.Point(0, 0);
            this.galleryGridList1.Name = "galleryGridList1";
            this.galleryGridList1.Size = new System.Drawing.Size(567, 412);
            this.galleryGridList1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.simpleButton3);
            this.panelControl2.Controls.Add(this.sButtonOK);
            this.panelControl2.Location = new System.Drawing.Point(1, 423);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(818, 33);
            this.panelControl2.TabIndex = 1;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButton3.Location = new System.Drawing.Point(735, 7);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "关闭";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // sButtonOK
            // 
            this.sButtonOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.sButtonOK.Location = new System.Drawing.Point(652, 7);
            this.sButtonOK.Name = "sButtonOK";
            this.sButtonOK.Size = new System.Drawing.Size(75, 23);
            this.sButtonOK.TabIndex = 1;
            this.sButtonOK.Text = "插入清单";
            // 
            // QueryGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 460);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "QueryGallery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清单库";
            this.Load += new System.EventHandler(this.QueryGallery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private GOLDSOFT.QDJJ.CTRL.ListGalleryIndex listGalleryIndex1;
        public GOLDSOFT.QDJJ.CTRL.GalleryGridList galleryGridList1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton sButtonOK;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;






    }
}