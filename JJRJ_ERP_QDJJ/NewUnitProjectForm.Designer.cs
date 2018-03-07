namespace GOLDSOFT.QDJJ.UI
{
    partial class NewUnitProjectForm
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
            this.txtPrjName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrjNo = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbx_TemplateType = new GOLDSOFT.QDJJ.CTRL.LibCombox();
            this.cbx_nsdd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.rg_jfcx = new DevExpress.XtraEditors.RadioGroup();
            this.cbx_gcdd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbx_qdgz = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbx_degz = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.cmboxProType = new GOLDSOFT.QDJJ.CTRL.LibCombox();
            this.cmboxFixedLibrary = new GOLDSOFT.QDJJ.CTRL.LibCombox();
            this.cmboxListGallery = new GOLDSOFT.QDJJ.CTRL.LibCombox();
            this.cmboxAtlasGallery = new GOLDSOFT.QDJJ.CTRL.LibCombox();
            this.cmboxPrfType = new GOLDSOFT.QDJJ.CTRL.LibCombox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrjName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrjNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_TemplateType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_nsdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_jfcx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_gcdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_qdgz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_degz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxProType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxFixedLibrary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxListGallery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxAtlasGallery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxPrfType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(0, 291);
            this.panelControl1.Size = new System.Drawing.Size(544, 30);
            this.panelControl1.TabIndex = 2;
            // 
            // txtPrjName
            // 
            this.txtPrjName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrjName.Location = new System.Drawing.Point(85, 32);
            this.txtPrjName.Name = "txtPrjName";
            this.txtPrjName.Properties.MaxLength = 255;
            this.txtPrjName.Size = new System.Drawing.Size(435, 21);
            this.txtPrjName.TabIndex = 0;
            this.txtPrjName.Validating += new System.ComponentModel.CancelEventHandler(this.cmboxListGallery_Validating);
            this.txtPrjName.TextChanged += new System.EventHandler(this.cmboxListGallery_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(36, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "清单库：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(297, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "定额库：";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(19, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 14);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = " 工程编号：";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Location = new System.Drawing.Point(24, 114);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 30;
            this.labelControl7.Text = "标准图集：";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(285, 89);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 31;
            this.labelControl8.Text = "专业类别：";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl9.Location = new System.Drawing.Point(23, 35);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 14);
            this.labelControl9.TabIndex = 32;
            this.labelControl9.Text = "工程名称：";
            // 
            // txtPrjNo
            // 
            this.txtPrjNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrjNo.Location = new System.Drawing.Point(85, 60);
            this.txtPrjNo.Name = "txtPrjNo";
            this.txtPrjNo.Properties.MaxLength = 255;
            this.txtPrjNo.Size = new System.Drawing.Size(435, 21);
            this.txtPrjNo.TabIndex = 1;
            this.txtPrjNo.Validating += new System.ComponentModel.CancelEventHandler(this.cmboxListGallery_Validating);
            this.txtPrjNo.EditValueChanged += new System.EventHandler(this.txtPrjNo_EditValueChanged);
            this.txtPrjNo.TextChanged += new System.EventHandler(this.cmboxListGallery_TextChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.txtPrjName);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.txtPrjNo);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(542, 92);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "单位工程信息";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(381, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(464, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.cbx_TemplateType);
            this.groupControl2.Controls.Add(this.cbx_nsdd);
            this.groupControl2.Controls.Add(this.labelControl16);
            this.groupControl2.Controls.Add(this.rg_jfcx);
            this.groupControl2.Controls.Add(this.cbx_gcdd);
            this.groupControl2.Controls.Add(this.cbx_qdgz);
            this.groupControl2.Controls.Add(this.cbx_degz);
            this.groupControl2.Controls.Add(this.labelControl17);
            this.groupControl2.Controls.Add(this.labelControl19);
            this.groupControl2.Controls.Add(this.labelControl20);
            this.groupControl2.Controls.Add(this.labelControl21);
            this.groupControl2.Controls.Add(this.labelControl12);
            this.groupControl2.Controls.Add(this.cmboxProType);
            this.groupControl2.Controls.Add(this.cmboxFixedLibrary);
            this.groupControl2.Controls.Add(this.cmboxListGallery);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.cmboxAtlasGallery);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.cmboxPrfType);
            this.groupControl2.Location = new System.Drawing.Point(-1, 94);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(542, 194);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "规则说明";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(24, 169);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 78;
            this.labelControl4.Text = "模板类别：";
            // 
            // cbx_TemplateType
            // 
            this.cbx_TemplateType.EditValue = "人工费调整计入差价";
            this.cbx_TemplateType.Location = new System.Drawing.Point(90, 166);
            this.cbx_TemplateType.Name = "cbx_TemplateType";
            this.cbx_TemplateType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_TemplateType.Properties.Items.AddRange(new object[] {
            "人工费调整计入差价",
            "人工费按市场价取费",
            "人工费按定额价取费"});
            this.cbx_TemplateType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_TemplateType.Size = new System.Drawing.Size(180, 21);
            this.cbx_TemplateType.TabIndex = 12;
            // 
            // cbx_nsdd
            // 
            this.cbx_nsdd.EditValue = "市区";
            this.cbx_nsdd.Location = new System.Drawing.Point(90, 139);
            this.cbx_nsdd.Name = "cbx_nsdd";
            this.cbx_nsdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_nsdd.Properties.Items.AddRange(new object[] {
            "市区",
            "县、城镇",
            "非县、城镇"});
            this.cbx_nsdd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_nsdd.Size = new System.Drawing.Size(180, 21);
            this.cbx_nsdd.TabIndex = 10;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(24, 141);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(60, 14);
            this.labelControl16.TabIndex = 75;
            this.labelControl16.Text = "纳税地点：";
            // 
            // rg_jfcx
            // 
            this.rg_jfcx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rg_jfcx.EditValue = "扣劳保";
            this.rg_jfcx.Location = new System.Drawing.Point(351, 111);
            this.rg_jfcx.Name = "rg_jfcx";
            this.rg_jfcx.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rg_jfcx.Properties.Appearance.Options.UseBackColor = true;
            this.rg_jfcx.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("扣劳保", "扣劳保"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("不扣劳保", "不扣劳保")});
            this.rg_jfcx.Size = new System.Drawing.Size(180, 22);
            this.rg_jfcx.TabIndex = 9;
            // 
            // cbx_gcdd
            // 
            this.cbx_gcdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_gcdd.EditValue = "其他";
            this.cbx_gcdd.Location = new System.Drawing.Point(351, 138);
            this.cbx_gcdd.Name = "cbx_gcdd";
            this.cbx_gcdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_gcdd.Properties.Items.AddRange(new object[] {
            "其他",
            "汉中"});
            this.cbx_gcdd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_gcdd.Size = new System.Drawing.Size(180, 21);
            this.cbx_gcdd.TabIndex = 11;
            // 
            // cbx_qdgz
            // 
            this.cbx_qdgz.EditValue = "2009";
            this.cbx_qdgz.Location = new System.Drawing.Point(90, 31);
            this.cbx_qdgz.Name = "cbx_qdgz";
            this.cbx_qdgz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_qdgz.Properties.Items.AddRange(new object[] {
            "2009",
            "2004"});
            this.cbx_qdgz.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_qdgz.Size = new System.Drawing.Size(180, 21);
            this.cbx_qdgz.TabIndex = 2;
            // 
            // cbx_degz
            // 
            this.cbx_degz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_degz.EditValue = "2009";
            this.cbx_degz.Location = new System.Drawing.Point(351, 31);
            this.cbx_degz.Name = "cbx_degz";
            this.cbx_degz.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbx_degz.Properties.Items.AddRange(new object[] {
            "2009",
            "2006"});
            this.cbx_degz.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbx_degz.Size = new System.Drawing.Size(180, 21);
            this.cbx_degz.TabIndex = 3;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(285, 114);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(60, 14);
            this.labelControl17.TabIndex = 69;
            this.labelControl17.Text = "计费程序：";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(285, 34);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(60, 14);
            this.labelControl19.TabIndex = 68;
            this.labelControl19.Text = "定额规则：";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(285, 141);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(60, 14);
            this.labelControl20.TabIndex = 66;
            this.labelControl20.Text = "工程地点：";
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(24, 34);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(60, 14);
            this.labelControl21.TabIndex = 67;
            this.labelControl21.Text = "清单规则：";
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl12.Location = new System.Drawing.Point(24, 89);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(60, 14);
            this.labelControl12.TabIndex = 61;
            this.labelControl12.Text = "工程类别：";
            // 
            // cmboxProType
            // 
            this.cmboxProType.Location = new System.Drawing.Point(90, 85);
            this.cmboxProType.Name = "cmboxProType";
            this.cmboxProType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxProType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboxProType.Size = new System.Drawing.Size(180, 21);
            this.cmboxProType.TabIndex = 6;
            this.cmboxProType.SelectedIndexChanged += new System.EventHandler(this.cmboxProType_SelectedIndexChanged);
            // 
            // cmboxFixedLibrary
            // 
            this.cmboxFixedLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboxFixedLibrary.Location = new System.Drawing.Point(351, 58);
            this.cmboxFixedLibrary.Name = "cmboxFixedLibrary";
            this.cmboxFixedLibrary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxFixedLibrary.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboxFixedLibrary.Size = new System.Drawing.Size(180, 21);
            this.cmboxFixedLibrary.TabIndex = 5;
            this.cmboxFixedLibrary.SelectedIndexChanged += new System.EventHandler(this.cmboxFixedLibrary_SelectedIndexChanged);
            // 
            // cmboxListGallery
            // 
            this.cmboxListGallery.Location = new System.Drawing.Point(90, 58);
            this.cmboxListGallery.Name = "cmboxListGallery";
            this.cmboxListGallery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxListGallery.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboxListGallery.Size = new System.Drawing.Size(180, 21);
            this.cmboxListGallery.TabIndex = 4;
            this.cmboxListGallery.SelectedIndexChanged += new System.EventHandler(this.cmboxListGallery_SelectedIndexChanged);
            // 
            // cmboxAtlasGallery
            // 
            this.cmboxAtlasGallery.Location = new System.Drawing.Point(90, 112);
            this.cmboxAtlasGallery.Name = "cmboxAtlasGallery";
            this.cmboxAtlasGallery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxAtlasGallery.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboxAtlasGallery.Size = new System.Drawing.Size(180, 21);
            this.cmboxAtlasGallery.TabIndex = 8;
            this.cmboxAtlasGallery.Validating += new System.ComponentModel.CancelEventHandler(this.cmboxListGallery_Validating);
            this.cmboxAtlasGallery.TextChanged += new System.EventHandler(this.cmboxListGallery_TextChanged);
            // 
            // cmboxPrfType
            // 
            this.cmboxPrfType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboxPrfType.Location = new System.Drawing.Point(351, 86);
            this.cmboxPrfType.Name = "cmboxPrfType";
            this.cmboxPrfType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxPrfType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboxPrfType.Size = new System.Drawing.Size(180, 21);
            this.cmboxPrfType.TabIndex = 7;
            // 
            // NewUnitProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 321);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.isBotton = true;
            this.Name = "NewUnitProjectForm";
            this.Text = "单位工程信息";
            this.Load += new System.EventHandler(this.NewUnitProjectForm_Load);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrjName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrjNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_TemplateType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_nsdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rg_jfcx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_gcdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_qdgz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbx_degz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxProType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxFixedLibrary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxListGallery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxAtlasGallery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxPrfType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtPrjName;
        private DevExpress.XtraEditors.TextEdit txtPrjNo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GOLDSOFT.QDJJ.CTRL.LibCombox cmboxAtlasGallery;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private GOLDSOFT.QDJJ.CTRL.LibCombox cmboxPrfType;
        private GOLDSOFT.QDJJ.CTRL.LibCombox cmboxFixedLibrary;
        private GOLDSOFT.QDJJ.CTRL.LibCombox cmboxListGallery;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private GOLDSOFT.QDJJ.CTRL.LibCombox cmboxProType;
        private DevExpress.XtraEditors.ComboBoxEdit cbx_nsdd;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.RadioGroup rg_jfcx;
        private DevExpress.XtraEditors.ComboBoxEdit cbx_gcdd;
        private DevExpress.XtraEditors.ComboBoxEdit cbx_qdgz;
        private DevExpress.XtraEditors.ComboBoxEdit cbx_degz;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private GOLDSOFT.QDJJ.CTRL.LibCombox cbx_TemplateType;


    }
}