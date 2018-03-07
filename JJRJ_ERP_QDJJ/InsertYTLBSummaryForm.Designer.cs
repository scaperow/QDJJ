namespace GOLDSOFT.QDJJ.UI
{
    partial class InsertYTLBSummaryForm
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditBH = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditMC = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditDW = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.calcEditSCDJ = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditSCDJ.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Location = new System.Drawing.Point(0, 64);
            this.panelControl1.Size = new System.Drawing.Size(334, 29);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(254, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "取消";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(173, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "确定";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "编号：";
            // 
            // textEditBH
            // 
            this.textEditBH.Location = new System.Drawing.Point(54, 9);
            this.textEditBH.Name = "textEditBH";
            this.textEditBH.Properties.MaxLength = 255;
            this.textEditBH.Size = new System.Drawing.Size(100, 21);
            this.textEditBH.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(180, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "名称：";
            // 
            // textEditMC
            // 
            this.textEditMC.Location = new System.Drawing.Point(222, 9);
            this.textEditMC.Name = "textEditMC";
            this.textEditMC.Properties.MaxLength = 255;
            this.textEditMC.Size = new System.Drawing.Size(100, 21);
            this.textEditMC.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "单位：";
            // 
            // textEditDW
            // 
            this.textEditDW.Location = new System.Drawing.Point(54, 36);
            this.textEditDW.Name = "textEditDW";
            this.textEditDW.Properties.MaxLength = 255;
            this.textEditDW.Size = new System.Drawing.Size(100, 21);
            this.textEditDW.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(168, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "市场价：";
            // 
            // calcEditSCDJ
            // 
            this.calcEditSCDJ.Location = new System.Drawing.Point(222, 36);
            this.calcEditSCDJ.Name = "calcEditSCDJ";
            this.calcEditSCDJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEditSCDJ.Properties.DisplayFormat.FormatString = "############0.##";
            this.calcEditSCDJ.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.calcEditSCDJ.Properties.Mask.EditMask = "############0.##";
            this.calcEditSCDJ.Size = new System.Drawing.Size(100, 21);
            this.calcEditSCDJ.TabIndex = 10;
            // 
            // InsertYTLBSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 93);
            this.Controls.Add(this.calcEditSCDJ);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.textEditDW);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEditMC);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEditBH);
            this.isBotton = true;
            this.Name = "InsertYTLBSummaryForm";
            this.Text = "添加用途材料";
            this.Controls.SetChildIndex(this.textEditBH, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.textEditMC, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.textEditDW, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.calcEditSCDJ, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditBH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditSCDJ.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditBH;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditMC;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditDW;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CalcEdit calcEditSCDJ;
    }
}