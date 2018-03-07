namespace GOLDSOFT.QDJJ.UI
{
    partial class AlertForm
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
            this.CanceButton = new DevExpress.XtraEditors.SimpleButton();
            this.NoButton = new DevExpress.XtraEditors.SimpleButton();
            this.YesButton = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Content = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CanceButton
            // 
            this.CanceButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CanceButton.Location = new System.Drawing.Point(242, 94);
            this.CanceButton.Name = "CanceButton";
            this.CanceButton.Size = new System.Drawing.Size(71, 23);
            this.CanceButton.TabIndex = 2;
            this.CanceButton.Text = "取消";
            this.CanceButton.Click += new System.EventHandler(this.CanceButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NoButton.Location = new System.Drawing.Point(54, 94);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(71, 23);
            this.NoButton.TabIndex = 0;
            this.NoButton.Text = "追加";
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // YesButton
            // 
            this.YesButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.YesButton.Location = new System.Drawing.Point(148, 94);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(71, 23);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "替换";
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.Content);
            this.panelControl2.Location = new System.Drawing.Point(1, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(365, 88);
            this.panelControl2.TabIndex = 8;
            // 
            // Content
            // 
            this.Content.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Content.Appearance.Options.UseFont = true;
            this.Content.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.Content.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(0, 0);
            this.Content.Name = "Content";
            this.Content.Padding = new System.Windows.Forms.Padding(10);
            this.Content.Size = new System.Drawing.Size(365, 34);
            this.Content.TabIndex = 24;
            this.Content.Text = "项目名称：项目名称：";
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 123);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.CanceButton);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.SimpleButton CanceButton;
        public DevExpress.XtraEditors.SimpleButton NoButton;
        public DevExpress.XtraEditors.SimpleButton YesButton;
        public DevExpress.XtraEditors.LabelControl Content;
    }
}
