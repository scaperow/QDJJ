namespace GOLDSOFT.QDJJ.UI
{
    partial class MsgBox
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
            this.p_OK_Cencel = new DevExpress.XtraEditors.PanelControl();
            this.p_OK_Cencel_Cencel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.P_YES_NO = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.P_OK = new DevExpress.XtraEditors.PanelControl();
            this.P_OK_OK = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_Text = new DevExpress.XtraEditors.LabelControl();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.p_OK_Cencel)).BeginInit();
            this.p_OK_Cencel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P_YES_NO)).BeginInit();
            this.P_YES_NO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P_OK)).BeginInit();
            this.P_OK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_OK_Cencel
            // 
            this.p_OK_Cencel.Controls.Add(this.p_OK_Cencel_Cencel);
            this.p_OK_Cencel.Controls.Add(this.simpleButton1);
            this.p_OK_Cencel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_OK_Cencel.Location = new System.Drawing.Point(0, 28);
            this.p_OK_Cencel.Name = "p_OK_Cencel";
            this.p_OK_Cencel.Size = new System.Drawing.Size(254, 30);
            this.p_OK_Cencel.TabIndex = 0;
            // 
            // p_OK_Cencel_Cencel
            // 
            this.p_OK_Cencel_Cencel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.p_OK_Cencel_Cencel.Image = global::GOLDSOFT.QDJJ.UI.Properties.Resources.取消;
            this.p_OK_Cencel_Cencel.Location = new System.Drawing.Point(181, 4);
            this.p_OK_Cencel_Cencel.Name = "p_OK_Cencel_Cencel";
            this.p_OK_Cencel_Cencel.Size = new System.Drawing.Size(68, 23);
            this.p_OK_Cencel_Cencel.TabIndex = 1;
            this.p_OK_Cencel_Cencel.Text = "取消";
            this.p_OK_Cencel_Cencel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Image = global::GOLDSOFT.QDJJ.UI.Properties.Resources.确定;
            this.simpleButton1.Location = new System.Drawing.Point(107, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(68, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.P_OK_OK_Click);
            // 
            // P_YES_NO
            // 
            this.P_YES_NO.Controls.Add(this.Btn_Cancel);
            this.P_YES_NO.Controls.Add(this.simpleButton3);
            this.P_YES_NO.Controls.Add(this.simpleButton4);
            this.P_YES_NO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_YES_NO.Location = new System.Drawing.Point(0, -2);
            this.P_YES_NO.Name = "P_YES_NO";
            this.P_YES_NO.Size = new System.Drawing.Size(254, 30);
            this.P_YES_NO.TabIndex = 1;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cancel.Image = global::GOLDSOFT.QDJJ.UI.Properties.Resources.取消;
            this.Btn_Cancel.Location = new System.Drawing.Point(181, 4);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(68, 23);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "取消";
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Location = new System.Drawing.Point(107, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(68, 23);
            this.simpleButton3.TabIndex = 1;
            this.simpleButton3.Text = "否";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Image = global::GOLDSOFT.QDJJ.UI.Properties.Resources.确定;
            this.simpleButton4.Location = new System.Drawing.Point(33, 4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(68, 23);
            this.simpleButton4.TabIndex = 0;
            this.simpleButton4.Text = "是";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // P_OK
            // 
            this.P_OK.Controls.Add(this.P_OK_OK);
            this.P_OK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_OK.Location = new System.Drawing.Point(0, -32);
            this.P_OK.Name = "P_OK";
            this.P_OK.Size = new System.Drawing.Size(254, 30);
            this.P_OK.TabIndex = 2;
            // 
            // P_OK_OK
            // 
            this.P_OK_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.P_OK_OK.Image = global::GOLDSOFT.QDJJ.UI.Properties.Resources.确定;
            this.P_OK_OK.Location = new System.Drawing.Point(181, 4);
            this.P_OK_OK.Name = "P_OK_OK";
            this.P_OK_OK.Size = new System.Drawing.Size(68, 23);
            this.P_OK_OK.TabIndex = 0;
            this.P_OK_OK.Text = "确定";
            this.P_OK_OK.Click += new System.EventHandler(this.P_OK_OK_Click_1);
            // 
            // lbl_Text
            // 
            this.lbl_Text.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_Text.Appearance.Options.UseFont = true;
            this.lbl_Text.Appearance.Options.UseTextOptions = true;
            this.lbl_Text.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_Text.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Text.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Text.Location = new System.Drawing.Point(0, 0);
            this.lbl_Text.MinimumSize = new System.Drawing.Size(108, 0);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(254, 35);
            this.lbl_Text.TabIndex = 3;
            this.lbl_Text.Text = "提示提示提示赶紧紧";
            this.lbl_Text.SizeChanged += new System.EventHandler(this.lbl_Text_SizeChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lbl_Text);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, -67);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(254, 35);
            this.panelControl1.TabIndex = 4;
            // 
            // MsgBox
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(254, 58);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.P_OK);
            this.Controls.Add(this.P_YES_NO);
            this.Controls.Add(this.p_OK_Cencel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBox";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.SizeChanged += new System.EventHandler(this.MsgBox_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.MsgBox_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.p_OK_Cencel)).EndInit();
            this.p_OK_Cencel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.P_YES_NO)).EndInit();
            this.P_YES_NO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.P_OK)).EndInit();
            this.P_OK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl p_OK_Cencel;
        private DevExpress.XtraEditors.SimpleButton p_OK_Cencel_Cencel;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl P_YES_NO;
        private DevExpress.XtraEditors.SimpleButton Btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.PanelControl P_OK;
        private DevExpress.XtraEditors.SimpleButton P_OK_OK;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_Text;
    }
}