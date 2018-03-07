namespace GOLDSOFT.QDJJ.CTRL
{
    partial class UnitProjectInfo
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
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.RI_Requirements = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RI_Strength = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RI_Position = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RI_Pebble = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RI_Cement = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RI_Sand = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RI_FromHigh = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.RI_SectionShape = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Requirements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Strength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Pebble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Cement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Sand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_FromHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_SectionShape)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.ImageIndexFieldName = "";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "ID";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RI_Requirements,
            this.RI_Strength,
            this.RI_Position,
            this.RI_Pebble,
            this.RI_Cement,
            this.RI_Sand,
            this.RI_FromHigh,
            this.RI_SectionShape});
            this.treeList1.Size = new System.Drawing.Size(285, 340);
            this.treeList1.TabIndex = 2;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "内容";
            this.treeListColumn2.FieldName = "Value";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // RI_Requirements
            // 
            this.RI_Requirements.AutoHeight = false;
            this.RI_Requirements.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_Requirements.Items.AddRange(new object[] {
            "现浇混凝土",
            "商品混凝土",
            "泵送混凝土",
            "泵送抗渗砼,P6",
            "泵送抗渗砼,P8"});
            this.RI_Requirements.Name = "RI_Requirements";
            this.RI_Requirements.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RI_Strength
            // 
            this.RI_Strength.AutoHeight = false;
            this.RI_Strength.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_Strength.Items.AddRange(new object[] {
            "C10",
            "C15",
            "C20",
            "C25",
            "C30",
            "C35",
            "C40",
            "C45"});
            this.RI_Strength.Name = "RI_Strength";
            this.RI_Strength.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RI_Position
            // 
            this.RI_Position.AutoHeight = false;
            this.RI_Position.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_Position.Items.AddRange(new object[] {
            "±0以上",
            "±0以下",
            "主楼",
            "群房",
            "塔楼",
            "厨房",
            "卫生间",
            "餐厅",
            "楼梯间"});
            this.RI_Position.Name = "RI_Position";
            this.RI_Position.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RI_Pebble
            // 
            this.RI_Pebble.AutoHeight = false;
            this.RI_Pebble.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_Pebble.Items.AddRange(new object[] {
            "砾石(综合)",
            "砾石5-10mm",
            "砾石5-15mm",
            "砾石10-30mm",
            "砾石20-40mm",
            "砾石30-70mm",
            "砾石40mm",
            "砾石(填料)30-70mm",
            "碎石(综合)",
            "",
            "",
            ""});
            this.RI_Pebble.Name = "RI_Pebble";
            this.RI_Pebble.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RI_Cement
            // 
            this.RI_Cement.AutoHeight = false;
            this.RI_Cement.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_Cement.Items.AddRange(new object[] {
            "水泥 (综合)",
            "水泥 (32.5)",
            "水泥 (42.5)",
            "水泥 (52.5)",
            "硅酸盐水泥 (32.5R)",
            "硅酸盐水泥 (42.5R)",
            "矿渣水泥 (32.5)",
            "白水泥",
            ""});
            this.RI_Cement.Name = "RI_Cement";
            this.RI_Cement.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RI_Sand
            // 
            this.RI_Sand.AutoHeight = false;
            this.RI_Sand.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_Sand.Items.AddRange(new object[] {
            "天然砂石",
            "粒砂",
            "净砂",
            "中砂",
            "天然砂(粗砂)",
            "天然砂",
            "中(粗)砂",
            "粗砂"});
            this.RI_Sand.Name = "RI_Sand";
            this.RI_Sand.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RI_FromHigh
            // 
            this.RI_FromHigh.AutoHeight = false;
            this.RI_FromHigh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_FromHigh.Items.AddRange(new object[] {
            "3.6米以内",
            "3.6米以上"});
            this.RI_FromHigh.Name = "RI_FromHigh";
            this.RI_FromHigh.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RI_SectionShape
            // 
            this.RI_SectionShape.AutoHeight = false;
            this.RI_SectionShape.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RI_SectionShape.Name = "RI_SectionShape";
            this.RI_SectionShape.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // UnitProjectInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Name = "UnitProjectInfo";
            this.Size = new System.Drawing.Size(285, 340);
            this.Load += new System.EventHandler(this.UnitProjectInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Requirements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Strength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Pebble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Cement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_Sand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_FromHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RI_SectionShape)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_Requirements;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_Strength;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_Position;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_Pebble;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_Cement;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_Sand;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_FromHigh;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RI_SectionShape;
    }
}
