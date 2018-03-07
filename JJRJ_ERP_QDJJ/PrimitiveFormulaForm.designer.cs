namespace GOLDSOFT.QDJJ.UI
{
    partial class PrimitiveFormulaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimitiveFormulaForm));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cmboxPrivmitiveName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.imgLstBxControl = new DevExpress.XtraEditors.ImageListBoxControl();
            this.PrimitiveFormulaCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButtonFormula = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmboxPrivmitiveName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLstBxControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimitiveFormulaCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonFormula);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Location = new System.Drawing.Point(0, 502);
            this.panelControl1.Size = new System.Drawing.Size(661, 29);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cmboxPrivmitiveName);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.imgLstBxControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(661, 499);
            this.splitContainerControl1.SplitterPosition = 185;
            this.splitContainerControl1.TabIndex = 11;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cmboxPrivmitiveName
            // 
            this.cmboxPrivmitiveName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboxPrivmitiveName.EditValue = "面积公式";
            this.cmboxPrivmitiveName.Location = new System.Drawing.Point(61, 3);
            this.cmboxPrivmitiveName.Name = "cmboxPrivmitiveName";
            this.cmboxPrivmitiveName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboxPrivmitiveName.Properties.Items.AddRange(new object[] {
            "面积公式",
            "体积公式",
            "周长公式",
            "送电线路计算公式"});
            this.cmboxPrivmitiveName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboxPrivmitiveName.Size = new System.Drawing.Size(123, 21);
            this.cmboxPrivmitiveName.TabIndex = 6;
            this.cmboxPrivmitiveName.SelectedIndexChanged += new System.EventHandler(this.cmboxPrivmitiveName_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "公式类别:";
            // 
            // imgLstBxControl
            // 
            this.imgLstBxControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLstBxControl.DisplayMember = "ValueMember";
            this.imgLstBxControl.ImageIndexMember = "ImageIndex";
            this.imgLstBxControl.ImageList = this.PrimitiveFormulaCollection;
            this.imgLstBxControl.ItemHeight = 128;
            this.imgLstBxControl.Location = new System.Drawing.Point(3, 26);
            this.imgLstBxControl.Name = "imgLstBxControl";
            this.imgLstBxControl.Size = new System.Drawing.Size(181, 473);
            this.imgLstBxControl.TabIndex = 8;
            this.imgLstBxControl.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.imgLstBxControl_DrawItem);
            this.imgLstBxControl.SelectedIndexChanged += new System.EventHandler(this.imgLstBxControl_SelectedIndexChanged);
            // 
            // PrimitiveFormulaCollection
            // 
            this.PrimitiveFormulaCollection.ImageSize = new System.Drawing.Size(128, 128);
            this.PrimitiveFormulaCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("PrimitiveFormulaCollection.ImageStream")));
            this.PrimitiveFormulaCollection.Images.SetKeyName(0, "0矩形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(1, "1任意三角形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(2, "2任意三角形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(3, "3平行四边形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(4, "4梯形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(5, "5任意四边形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(6, "6平底四边形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(7, "7缺圆环面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(8, "8圆面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(9, "9圆环面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(10, "10椭圆面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(11, "11扇形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(12, "12正多边形面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(13, "13断面面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(14, "14断面面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(15, "15断面面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(16, "16正方体侧面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(17, "17长方体侧面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(18, "18长方体的全面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(19, "19正方体表面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(20, "20条形基础.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(21, "21管道防腐面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(22, "22阀门防腐面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(23, "23法兰防腐面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(24, "24钢管刷油面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(25, "25阀门刷油面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(26, "26法兰刷油面积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(27, "27单管伴热刷油.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(28, "28双管伴热刷油.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(29, "29管道伴热刷油.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(30, "30正方体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(31, "31长方体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(32, "32棱柱体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(33, "33棱锥体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(34, "34棱台体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(35, "35圆锥体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(36, "36圆台体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(37, "37四棱台体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(38, "38圆柱体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(39, "39斜切圆柱体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(40, "40圆环体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(41, "41球体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(42, "42球缺体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(43, "43球带体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(44, "44交叉圆柱体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(45, "45桶状体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(46, "46楔形体体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(47, "47圆环体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(48, "48四棱锥台形基础.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(49, "49杯形基础.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(50, "50独立柱基础.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(51, "51切头方锥形基础.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(52, "52钢管绝热体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(53, "53阀门绝热体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(54, "54法兰绝热体积.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(55, "55单管伴热绝热.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(56, "56双管伴热绝热.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(57, "57管道伴热绝热.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(58, "58圆形的周长.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(59, "59椭圆的周长.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(60, "60扇形的弧长.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(61, "61正方体对角线.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(62, "62长方体对角线长.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(63, "63送电线路.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(64, "64送电线路.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(65, "65送电线路.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(66, "66塔位立于山坡的施工基础.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(67, "67塔位立于山脊上的施工基础.png");
            this.PrimitiveFormulaCollection.Images.SetKeyName(68, "68施工排水沟.png");
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.memoEdit1);
            this.groupControl3.Location = new System.Drawing.Point(2, 304);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(465, 93);
            this.groupControl3.TabIndex = 12;
            this.groupControl3.Text = "计算公式";
            // 
            // memoEdit1
            // 
            this.memoEdit1.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.memoEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = "";
            this.memoEdit1.Location = new System.Drawing.Point(2, 23);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.memoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(461, 68);
            this.memoEdit1.TabIndex = 7;
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.Controls.Add(this.memoEdit2);
            this.groupControl4.Location = new System.Drawing.Point(2, 403);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(465, 93);
            this.groupControl4.TabIndex = 11;
            this.groupControl4.Text = "计算公式表达式预览";
            // 
            // memoEdit2
            // 
            this.memoEdit2.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.memoEdit2.Cursor = System.Windows.Forms.Cursors.Default;
            this.memoEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit2.EditValue = "";
            this.memoEdit2.Location = new System.Drawing.Point(2, 23);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.memoEdit2.Properties.Appearance.Options.UseFont = true;
            this.memoEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.memoEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEdit2.Properties.ReadOnly = true;
            this.memoEdit2.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit2.Size = new System.Drawing.Size(461, 68);
            this.memoEdit2.TabIndex = 7;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(465, 296);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "参数";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(461, 271);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MC,
            this.SZ,
            this.FH});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // MC
            // 
            this.MC.Caption = "参数";
            this.MC.FieldName = "MC";
            this.MC.Name = "MC";
            this.MC.OptionsColumn.AllowEdit = false;
            this.MC.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.MC.OptionsFilter.AllowAutoFilter = false;
            this.MC.Visible = true;
            this.MC.VisibleIndex = 0;
            // 
            // SZ
            // 
            this.SZ.Caption = "值";
            this.SZ.DisplayFormat.FormatString = "0.00";
            this.SZ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SZ.FieldName = "SZ";
            this.SZ.Name = "SZ";
            this.SZ.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.SZ.OptionsFilter.AllowAutoFilter = false;
            this.SZ.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.SZ.Visible = true;
            this.SZ.VisibleIndex = 1;
            // 
            // FH
            // 
            this.FH.Caption = "符号";
            this.FH.FieldName = "FH";
            this.FH.Name = "FH";
            this.FH.OptionsColumn.AllowEdit = false;
            this.FH.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.FH.OptionsFilter.AllowAutoFilter = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Location = new System.Drawing.Point(581, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOk.Location = new System.Drawing.Point(500, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "提取公式";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // simpleButtonFormula
            // 
            this.simpleButtonFormula.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonFormula.Location = new System.Drawing.Point(419, 3);
            this.simpleButtonFormula.Name = "simpleButtonFormula";
            this.simpleButtonFormula.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonFormula.TabIndex = 11;
            this.simpleButtonFormula.Text = "提取结果";
            this.simpleButtonFormula.Click += new System.EventHandler(this.simpleButtonFormula_Click);
            // 
            // PrimitiveFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 531);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.isBotton = true;
            this.Name = "PrimitiveFormulaForm";
            this.Text = "图元公式";
            this.Load += new System.EventHandler(this.PrimitiveFormulaForm_Load);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmboxPrivmitiveName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLstBxControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimitiveFormulaCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmboxPrivmitiveName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.ImageListBoxControl imgLstBxControl;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.Utils.ImageCollection PrimitiveFormulaCollection;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MC;
        private DevExpress.XtraGrid.Columns.GridColumn SZ;
        private DevExpress.XtraGrid.Columns.GridColumn FH;
        private System.Windows.Forms.BindingSource bindingSource2;
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.SimpleButton simpleButtonFormula;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;

    }
}