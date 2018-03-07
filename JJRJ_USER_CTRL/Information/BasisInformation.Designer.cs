namespace GOLDSOFT.QDJJ.CTRL.Information
{
    partial class BasisInformation
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
            this.cbx_nsdd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.rg_jfcx = new DevExpress.XtraEditors.RadioGroup();
            this.cbx_gcdd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbx_qdgz = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbx_degz = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_xmmc = new DevExpress.XtraEditors.TextEdit();
            this.txt_xmbh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbx_nsdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_jfcx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_gcdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_qdgz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_degz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_xmmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_xmbh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_nsdd
            // 
            this.cbx_nsdd.EditValue = "市区";
            this.cbx_nsdd.EnterMoveNextControl = true;
            this.cbx_nsdd.Location = new System.Drawing.Point(303, 56);
            this.cbx_nsdd.Name = "cbx_nsdd";
            this.cbx_nsdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_nsdd.Properties.Items.AddRange(new object[] {
            "市区",
            "县、城镇",
            "非县、城镇"});
            this.cbx_nsdd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_nsdd.Size = new System.Drawing.Size(145, 21);
            this.cbx_nsdd.TabIndex = 4;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(241, 59);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "纳税地点：";
            // 
            // rg_jfcx
            // 
            this.rg_jfcx.EditValue = "扣劳保";
            this.rg_jfcx.Location = new System.Drawing.Point(303, 30);
            this.rg_jfcx.Name = "rg_jfcx";
            this.rg_jfcx.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rg_jfcx.Properties.Appearance.Options.UseBackColor = true;
            this.rg_jfcx.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("扣劳保", "扣劳保"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("不扣劳保", "不扣劳保")});
            this.rg_jfcx.Size = new System.Drawing.Size(145, 22);
            this.rg_jfcx.TabIndex = 2;
            // 
            // cbx_gcdd
            // 
            this.cbx_gcdd.EditValue = "其他";
            this.cbx_gcdd.EnterMoveNextControl = true;
            this.cbx_gcdd.Location = new System.Drawing.Point(303, 81);
            this.cbx_gcdd.Name = "cbx_gcdd";
            this.cbx_gcdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_gcdd.Properties.Items.AddRange(new object[] {
            "其他",
            "汉中"});
            this.cbx_gcdd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_gcdd.Size = new System.Drawing.Size(145, 21);
            this.cbx_gcdd.TabIndex = 6;
            // 
            // cbx_qdgz
            // 
            this.cbx_qdgz.EditValue = "2009";
            this.cbx_qdgz.EnterMoveNextControl = true;
            this.cbx_qdgz.Location = new System.Drawing.Point(70, 56);
            this.cbx_qdgz.Name = "cbx_qdgz";
            this.cbx_qdgz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_qdgz.Properties.Items.AddRange(new object[] {
            "2009",
            "2004"});
            this.cbx_qdgz.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_qdgz.Size = new System.Drawing.Size(145, 21);
            this.cbx_qdgz.TabIndex = 3;
            // 
            // cbx_degz
            // 
            this.cbx_degz.EditValue = "2009";
            this.cbx_degz.EnterMoveNextControl = true;
            this.cbx_degz.Location = new System.Drawing.Point(70, 81);
            this.cbx_degz.Name = "cbx_degz";
            this.cbx_degz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_degz.Properties.Items.AddRange(new object[] {
            "2009",
            "2006"});
            this.cbx_degz.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_degz.Size = new System.Drawing.Size(145, 21);
            this.cbx_degz.TabIndex = 5;
            // 
            // txt_xmmc
            // 
            this.txt_xmmc.EnterMoveNextControl = true;
            this.txt_xmmc.Location = new System.Drawing.Point(70, 7);
            this.txt_xmmc.Name = "txt_xmmc";
            this.txt_xmmc.Properties.MaxLength = 255;
            this.txt_xmmc.Size = new System.Drawing.Size(378, 21);
            this.txt_xmmc.TabIndex = 0;
            // 
            // txt_xmbh
            // 
            this.txt_xmbh.EnterMoveNextControl = true;
            this.txt_xmbh.Location = new System.Drawing.Point(70, 31);
            this.txt_xmbh.Name = "txt_xmbh";
            this.txt_xmbh.Properties.MaxLength = 255;
            this.txt_xmbh.Size = new System.Drawing.Size(145, 21);
            this.txt_xmbh.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "项目名称：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(241, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 20;
            this.labelControl6.Text = "计费程序：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "项目编号：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(8, 84);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "定额规则：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(241, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "工程地点：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 59);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "清单规则：";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BasisInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbx_nsdd);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.rg_jfcx);
            this.Controls.Add(this.cbx_gcdd);
            this.Controls.Add(this.cbx_qdgz);
            this.Controls.Add(this.cbx_degz);
            this.Controls.Add(this.txt_xmmc);
            this.Controls.Add(this.txt_xmbh);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Name = "BasisInformation";
            this.Size = new System.Drawing.Size(458, 110);
            ((System.ComponentModel.ISupportInitialize)(this.cbx_nsdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_jfcx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_gcdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_qdgz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_degz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_xmmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_xmbh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbx_nsdd;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.RadioGroup rg_jfcx;
        private DevExpress.XtraEditors.ComboBoxEdit cbx_gcdd;
        private DevExpress.XtraEditors.ComboBoxEdit cbx_qdgz;
        private DevExpress.XtraEditors.ComboBoxEdit cbx_degz;
        private DevExpress.XtraEditors.TextEdit txt_xmmc;
        private DevExpress.XtraEditors.TextEdit txt_xmbh;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}
