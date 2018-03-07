namespace GOLDSOFT.QDJJ.UI
{
    partial class QueryForm
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
            this.bindingSource5 = new GOLDSOFT.QDJJ.UI.Controls.BindingSourceEx(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.清单索引 = new DevExpress.XtraTab.XtraTabPage();
            this.定额库 = new DevExpress.XtraTab.XtraTabPage();
            this.图集库 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.清单索引;
            this.xtraTabControl1.Size = new System.Drawing.Size(792, 566);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.清单索引,
            this.定额库,
            this.图集库});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // 清单索引
            // 
            this.清单索引.Enabled = true;
            this.清单索引.Name = "清单索引";
            this.清单索引.Size = new System.Drawing.Size(785, 536);
            this.清单索引.Text = "清单指引";
            // 
            // 定额库
            // 
            this.定额库.Enabled = true;
            this.定额库.Name = "定额库";
            this.定额库.Size = new System.Drawing.Size(785, 536);
            this.定额库.Text = "定 额 库";
            // 
            // 图集库
            // 
            this.图集库.Enabled = true;
            this.图集库.Name = "图集库";
            this.图集库.Size = new System.Drawing.Size(785, 536);
            this.图集库.Text = "图 集 库";
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "QueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询窗口";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueryForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

     

        #endregion

        public GOLDSOFT.QDJJ.UI.Controls.BindingSourceEx bindingSource5;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage 清单索引;
        private DevExpress.XtraTab.XtraTabPage 定额库;
        private DevExpress.XtraTab.XtraTabPage 图集库;
    }
}