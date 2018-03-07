namespace GOLDSOFT.QDJJ.UI
{
    partial class BeginAnalyze
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
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoLow = new System.Windows.Forms.RadioButton();
            this.rdoZH = new System.Windows.Forms.RadioButton();
            this.txtQGQD = new System.Windows.Forms.TextBox();
            this.txtMyCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCuoShi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOtherCount = new System.Windows.Forms.TextBox();
            this.txtLimitPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(0, 316);
            this.panelControl1.Size = new System.Drawing.Size(574, 0);
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.simpleButton2);
            this.panelControl6.Controls.Add(this.simpleButton1);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(0, 316);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(574, 48);
            this.panelControl6.TabIndex = 35;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Location = new System.Drawing.Point(493, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(80, 31);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "不同意";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(406, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 31);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "同意";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "上限控制价:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoLow);
            this.groupBox1.Controls.Add(this.rdoZH);
            this.groupBox1.Controls.Add(this.txtQGQD);
            this.groupBox1.Controls.Add(this.txtMyCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCuoShi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOtherCount);
            this.groupBox1.Controls.Add(this.txtLimitPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 155);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本情况设定";
            // 
            // rdoLow
            // 
            this.rdoLow.AutoSize = true;
            this.rdoLow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.rdoLow.ForeColor = System.Drawing.Color.Red;
            this.rdoLow.Location = new System.Drawing.Point(195, 112);
            this.rdoLow.Name = "rdoLow";
            this.rdoLow.Size = new System.Drawing.Size(85, 18);
            this.rdoLow.TabIndex = 38;
            this.rdoLow.Text = "合理低价法";
            this.rdoLow.UseVisualStyleBackColor = true;
            this.rdoLow.CheckedChanged += new System.EventHandler(this.rdoLow_CheckedChanged);
            // 
            // rdoZH
            // 
            this.rdoZH.AutoSize = true;
            this.rdoZH.Checked = true;
            this.rdoZH.Font = new System.Drawing.Font("Tahoma", 9F);
            this.rdoZH.ForeColor = System.Drawing.Color.Red;
            this.rdoZH.Location = new System.Drawing.Point(104, 111);
            this.rdoZH.Name = "rdoZH";
            this.rdoZH.Size = new System.Drawing.Size(85, 18);
            this.rdoZH.TabIndex = 38;
            this.rdoZH.TabStop = true;
            this.rdoZH.Text = "综合评估法";
            this.rdoZH.UseVisualStyleBackColor = true;
            // 
            // txtQGQD
            // 
            this.txtQGQD.Location = new System.Drawing.Point(383, 85);
            this.txtQGQD.Name = "txtQGQD";
            this.txtQGQD.Size = new System.Drawing.Size(163, 22);
            this.txtQGQD.TabIndex = 37;
            this.txtQGQD.Leave += new System.EventHandler(this.txtQGQD_Leave);
            // 
            // txtMyCount
            // 
            this.txtMyCount.Location = new System.Drawing.Point(383, 53);
            this.txtMyCount.Name = "txtMyCount";
            this.txtMyCount.ReadOnly = true;
            this.txtMyCount.Size = new System.Drawing.Size(163, 22);
            this.txtMyCount.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(316, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 36;
            this.label4.Text = "我方家数:";
            // 
            // txtCuoShi
            // 
            this.txtCuoShi.Location = new System.Drawing.Point(383, 20);
            this.txtCuoShi.Name = "txtCuoShi";
            this.txtCuoShi.Size = new System.Drawing.Size(163, 22);
            this.txtCuoShi.TabIndex = 37;
            this.txtCuoShi.Leave += new System.EventHandler(this.txtCuoShi_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(316, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 36;
            this.label2.Text = "措施上限:";
            // 
            // txtOtherCount
            // 
            this.txtOtherCount.Location = new System.Drawing.Point(104, 53);
            this.txtOtherCount.Name = "txtOtherCount";
            this.txtOtherCount.ReadOnly = true;
            this.txtOtherCount.Size = new System.Drawing.Size(162, 22);
            this.txtOtherCount.TabIndex = 37;
            // 
            // txtLimitPrice
            // 
            this.txtLimitPrice.Location = new System.Drawing.Point(104, 20);
            this.txtLimitPrice.Name = "txtLimitPrice";
            this.txtLimitPrice.Size = new System.Drawing.Size(162, 22);
            this.txtLimitPrice.TabIndex = 37;
            this.txtLimitPrice.TextChanged += new System.EventHandler(this.txtLimitPrice_TextChanged);
            this.txtLimitPrice.Leave += new System.EventHandler(this.txtLimitPrice_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(29, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 14);
            this.label5.TabIndex = 36;
            this.label5.Text = "投标单位大于多少家时基准单位需要去高去低:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(39, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 14);
            this.label6.TabIndex = 36;
            this.label6.Text = "评标办法:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(39, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "对方家数:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(0, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 164);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 14);
            this.label8.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(10, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "后果，均由操作者自负。";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(12, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(499, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "户提供一个参考性的意见，若在正式投标行为中直接使用此功能分析出的数据所造成一切不良";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(12, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(507, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "        投标平台将以当前文件为标准，模拟竞争对手的报价或其他场景进行预测性分析，仅为用";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "告知:";
            // 
            // BeginAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 364);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelControl6);
            this.isBotton = true;
            this.Name = "BeginAnalyze";
            this.Text = "基本情况设定";
            this.Load += new System.EventHandler(this.BeginAnalyze_Load);
            this.Controls.SetChildIndex(this.panelControl6, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl6;
        public DevExpress.XtraEditors.SimpleButton simpleButton2;
        public DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCuoShi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLimitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQGQD;
        private System.Windows.Forms.TextBox txtMyCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOtherCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdoLow;
        private System.Windows.Forms.RadioButton rdoZH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;

    }
}