namespace GOLDSOFT.QDJJ.UI
{
    partial class CImportOut
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioProject = new DevExpress.XtraEditors.RadioGroup();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioOther = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txt_Sum = new DevExpress.XtraEditors.LabelControl();
            this.Prve = new DevExpress.XtraEditors.SimpleButton();
            this.Next = new DevExpress.XtraEditors.SimpleButton();
            this.ctrlAttributes1 = new GOLDSOFT.QDJJ.CTRL.CtrlAttributes();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bWorker_SaveAs = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioOther.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(0, 337);
            this.panelControl1.Size = new System.Drawing.Size(542, 29);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.radioProject);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.radioOther);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.buttonEdit1);
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(538, 124);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "导出配置";
            // 
            // radioProject
            // 
            this.radioProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radioProject.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.radioProject.Location = new System.Drawing.Point(77, 85);
            this.radioProject.Name = "radioProject";
            this.radioProject.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioProject.Properties.Appearance.Options.UseBackColor = true;
            this.radioProject.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}), "项目文件(.jxmx)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            1,
                            0,
                            0,
                            0}), "TBS文件(.tbs)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            2,
                            0,
                            0,
                            0}), "ZBS文件(.zbs)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "BD文件(.BD)")});
            this.radioProject.Size = new System.Drawing.Size(455, 34);
            this.radioProject.TabIndex = 5;
            this.radioProject.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.Location = new System.Drawing.Point(77, 58);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(455, 21);
            this.textEdit1.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "文件名称：";
            // 
            // radioOther
            // 
            this.radioOther.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.radioOther.Location = new System.Drawing.Point(77, 90);
            this.radioOther.Name = "radioOther";
            this.radioOther.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}), "工程文件(.jgcx)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            1,
                            0,
                            0,
                            0}), "Access文件(.mdb)", false),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(new decimal(new int[] {
                            2,
                            0,
                            0,
                            0}), "Xml文件(.xml)", false)});
            this.radioOther.Size = new System.Drawing.Size(455, 22);
            this.radioOther.TabIndex = 2;
            this.radioOther.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "导出路径：";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit1.Location = new System.Drawing.Point(77, 32);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(455, 21);
            this.buttonEdit1.TabIndex = 0;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.txt_Sum);
            this.groupControl2.Controls.Add(this.Prve);
            this.groupControl2.Controls.Add(this.Next);
            this.groupControl2.Controls.Add(this.ctrlAttributes1);
            this.groupControl2.Location = new System.Drawing.Point(2, 131);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(538, 202);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "工程信息";
            // 
            // txt_Sum
            // 
            this.txt_Sum.Location = new System.Drawing.Point(77, 6);
            this.txt_Sum.Name = "txt_Sum";
            this.txt_Sum.Size = new System.Drawing.Size(47, 14);
            this.txt_Sum.TabIndex = 3;
            this.txt_Sum.Text = "txt_Sum";
            // 
            // Prve
            // 
            this.Prve.Location = new System.Drawing.Point(461, 2);
            this.Prve.Name = "Prve";
            this.Prve.Size = new System.Drawing.Size(24, 19);
            this.Prve.TabIndex = 2;
            this.Prve.Text = "<-";
            this.Prve.Click += new System.EventHandler(this.Prve_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(500, 1);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(26, 20);
            this.Next.TabIndex = 1;
            this.Next.Text = "->";
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // ctrlAttributes1
            // 
            this.ctrlAttributes1.Activitie = null;
            this.ctrlAttributes1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlAttributes1.CurrentBusiness = null;
            this.ctrlAttributes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAttributes1.IDataSource = null;
            this.ctrlAttributes1.IsEdit = false;
            this.ctrlAttributes1.Location = new System.Drawing.Point(2, 23);
            this.ctrlAttributes1.Name = "ctrlAttributes1";
            this.ctrlAttributes1.Size = new System.Drawing.Size(534, 177);
            this.ctrlAttributes1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(463, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "取消";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(382, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);

            //// 
            //// bWorker_SaveAs
            //// 
            //this.bWorker_SaveAs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWorker_SaveAs_DoWork);
            //this.bWorker_SaveAs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWorker_SaveAs_RunWorkerCompleted);
            //this.bWorker_SaveAs.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bWorker_SaveAs_ProgressChanged);

            // 
            // CImportOut
            // 
            this.AcceptButton = this.simpleButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.simpleButton2;
            this.ClientSize = new System.Drawing.Size(542, 366);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.isBotton = true;
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "CImportOut";
            this.Text = "导出向导(单位工程)";
            this.Load += new System.EventHandler(this.CImportOut_Load);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioOther.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.RadioGroup radioOther;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private GOLDSOFT.QDJJ.CTRL.CtrlAttributes ctrlAttributes1;
        private DevExpress.XtraEditors.RadioGroup radioProject;
        private System.ComponentModel.BackgroundWorker bWorker_SaveAs;
        private DevExpress.XtraEditors.LabelControl txt_Sum;
        private DevExpress.XtraEditors.SimpleButton Prve;
        private DevExpress.XtraEditors.SimpleButton Next;
    }
}