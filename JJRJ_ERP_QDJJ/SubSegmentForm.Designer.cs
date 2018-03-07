namespace GOLDSOFT.QDJJ.UI
{
    partial class SubSegmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubSegmentForm));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.subSegmentListData1 = new GOLDSOFT.QDJJ.CTRL.SubSegmentListData();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage8 = new DevExpress.XtraTab.XtraTabPage();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.subSegmentListData1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1010, 667);
            this.splitContainerControl1.SplitterPosition = 152;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // subSegmentListData1
            // 
            this.subSegmentListData1.Activitie = null;
            this.subSegmentListData1.AutoScroll = true;
            this.subSegmentListData1.BackColor = System.Drawing.Color.Transparent;
            this.subSegmentListData1.Columns = null;
            this.subSegmentListData1.CurrentBusiness = null;
            this.subSegmentListData1.DataSource = null;
            this.subSegmentListData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subSegmentListData1.EListType = GOLDSOFT.QDJJ.COMMONS.EListType.Default;
            this.subSegmentListData1.Location = new System.Drawing.Point(0, 0);
            this.subSegmentListData1.Name = "subSegmentListData1";
            this.subSegmentListData1.SchemeColor = null;
            this.subSegmentListData1.Size = new System.Drawing.Size(1010, 509);
            this.subSegmentListData1.TabIndex = 0;
            
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Images = this.imageCollection1;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1010, 152);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7,
            this.xtraTabPage8});
            this.xtraTabControl1.DoubleClick += new System.EventHandler(this.xtraTabControl1_DoubleClick);
            this.xtraTabControl1.Click += new System.EventHandler(this.xtraTabControl1_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "子目工料机.png");
            this.imageCollection1.Images.SetKeyName(1, "子目取费.png");
            this.imageCollection1.Images.SetKeyName(2, "标准换算.png");
            this.imageCollection1.Images.SetKeyName(3, "安装增加费.png");
            this.imageCollection1.Images.SetKeyName(4, "清单工料机.png");
            this.imageCollection1.Images.SetKeyName(5, "图形分析.png");
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.ImageIndex = 0;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.PageVisible = false;
            this.xtraTabPage1.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage1.Text = "子目工料机";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.ImageIndex = 1;
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage2.Text = "子目取费";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.ImageIndex = 2;
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.PageVisible = false;
            this.xtraTabPage3.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage3.Text = "标准换算";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.ImageIndex = 3;
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.PageVisible = false;
            this.xtraTabPage4.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage4.Text = "安装增加费";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.ImageIndex = 4;
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.PageVisible = false;
            this.xtraTabPage5.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage5.Text = "清单工料机";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.ImageIndex = 5;
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.PageVisible = false;
            this.xtraTabPage6.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage6.Text = "图形分析";
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage7.Text = "项目特征";
            // 
            // xtraTabPage8
            // 
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.Size = new System.Drawing.Size(1003, 121);
            this.xtraTabPage8.Text = "工程内容";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(702, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SubSegmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 667);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "SubSegmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "分部分项";
            this.Text = "分部分项";
            this.Load += new System.EventHandler(this.SubSegmentForm_Load);
            this.Controls.SetChildIndex(this.functionList1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        public GOLDSOFT.QDJJ.CTRL.SubSegmentListData subSegmentListData1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage8;
        private System.Windows.Forms.Button button1;
    }
}