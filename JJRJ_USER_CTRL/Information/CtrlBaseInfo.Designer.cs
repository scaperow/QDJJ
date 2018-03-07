namespace GOLDSOFT.QDJJ.CTRL.Information
{
    partial class CtrlBaseInfo
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_ReviewDate = new DevExpress.XtraEditors.DateEdit();
            this.txt_PlaitNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_PlaitName = new DevExpress.XtraEditors.TextEdit();
            this.txt_PlaitDate = new DevExpress.XtraEditors.DateEdit();
            this.txt_ReviewName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tenderInfoSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReviewDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReviewDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReviewName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenderInfoSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_ReviewDate);
            this.layoutControl1.Controls.Add(this.txt_PlaitNo);
            this.layoutControl1.Controls.Add(this.txt_PlaitName);
            this.layoutControl1.Controls.Add(this.txt_PlaitDate);
            this.layoutControl1.Controls.Add(this.txt_ReviewName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(476, 100);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_ReviewDate
            // 
            this.txt_ReviewDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ReviewDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tenderInfoSourceBindingSource, "ReviewDate", true));
            this.txt_ReviewDate.EditValue = null;
            this.txt_ReviewDate.Location = new System.Drawing.Point(339, 62);
            this.txt_ReviewDate.Name = "txt_ReviewDate";
            this.txt_ReviewDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_ReviewDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_ReviewDate.Size = new System.Drawing.Size(125, 21);
            this.txt_ReviewDate.StyleController = this.layoutControl1;
            this.txt_ReviewDate.TabIndex = 49;
            // 
            // txt_PlaitNo
            // 
            this.txt_PlaitNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tenderInfoSourceBindingSource, "PlaitNo", true));
            this.txt_PlaitNo.Location = new System.Drawing.Point(112, 37);
            this.txt_PlaitNo.Name = "txt_PlaitNo";
            this.txt_PlaitNo.Size = new System.Drawing.Size(123, 21);
            this.txt_PlaitNo.StyleController = this.layoutControl1;
            this.txt_PlaitNo.TabIndex = 5;
            // 
            // txt_PlaitName
            // 
            this.txt_PlaitName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tenderInfoSourceBindingSource, "PlaitName", true));
            this.txt_PlaitName.Location = new System.Drawing.Point(112, 12);
            this.txt_PlaitName.Name = "txt_PlaitName";
            this.txt_PlaitName.Size = new System.Drawing.Size(352, 21);
            this.txt_PlaitName.StyleController = this.layoutControl1;
            this.txt_PlaitName.TabIndex = 4;
            // 
            // txt_PlaitDate
            // 
            this.txt_PlaitDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PlaitDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.tenderInfoSourceBindingSource, "PlaitDate", true));
            this.txt_PlaitDate.EditValue = null;
            this.txt_PlaitDate.Location = new System.Drawing.Point(339, 37);
            this.txt_PlaitDate.Name = "txt_PlaitDate";
            this.txt_PlaitDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_PlaitDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_PlaitDate.Size = new System.Drawing.Size(125, 21);
            this.txt_PlaitDate.StyleController = this.layoutControl1;
            this.txt_PlaitDate.TabIndex = 48;
            // 
            // txt_ReviewName
            // 
            this.txt_ReviewName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tenderInfoSourceBindingSource, "ReviewName", true));
            this.txt_ReviewName.Location = new System.Drawing.Point(112, 62);
            this.txt_ReviewName.Name = "txt_ReviewName";
            this.txt_ReviewName.Size = new System.Drawing.Size(123, 21);
            this.txt_ReviewName.StyleController = this.layoutControl1;
            this.txt_ReviewName.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(476, 100);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_PlaitName;
            this.layoutControlItem1.CustomizationFormText = "编制人：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(456, 25);
            this.layoutControlItem1.Text = "编制人：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_PlaitNo;
            this.layoutControlItem2.CustomizationFormText = "编制人资格证号：";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(227, 25);
            this.layoutControlItem2.Text = "编制人资格证号：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_PlaitDate;
            this.layoutControlItem3.CustomizationFormText = "编制日期：";
            this.layoutControlItem3.Location = new System.Drawing.Point(227, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(229, 25);
            this.layoutControlItem3.Text = "编制日期：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_ReviewName;
            this.layoutControlItem4.CustomizationFormText = "复核人：";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(227, 30);
            this.layoutControlItem4.Text = "复核人：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txt_ReviewDate;
            this.layoutControlItem5.CustomizationFormText = "复核日期：";
            this.layoutControlItem5.Location = new System.Drawing.Point(227, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(229, 30);
            this.layoutControlItem5.Text = "复核日期：";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(96, 14);
            // 
            // tenderInfoSourceBindingSource
            // 
            this.tenderInfoSourceBindingSource.DataSource = typeof(GOLDSOFT.QDJJ.COMMONS._TenderInfoSource);
            // 
            // CtrlBaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "CtrlBaseInfo";
            this.Size = new System.Drawing.Size(476, 100);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReviewDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReviewDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PlaitDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ReviewName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenderInfoSourceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txt_PlaitNo;
        private DevExpress.XtraEditors.TextEdit txt_PlaitName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit txt_ReviewDate;
        private DevExpress.XtraEditors.DateEdit txt_PlaitDate;
        private DevExpress.XtraEditors.TextEdit txt_ReviewName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        public System.Windows.Forms.BindingSource tenderInfoSourceBindingSource;
    }
}
