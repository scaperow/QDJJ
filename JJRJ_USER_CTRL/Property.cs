using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class Property : BaseControl
    {
        //定义新的委托
        public delegate void ChangeNameHandler(DataRow row);

        private event ChangeNameHandler m_ChangeName;

        public event ChangeNameHandler ChangeName
        {
            add
            {
                m_ChangeName +=new ChangeNameHandler(value);
            }
            remove
            {
                m_ChangeName -= new ChangeNameHandler(value);
            }
        }

        private string m_key = string.Empty;

        /// <summary>
        /// 临时存放当前的类型
        /// </summary>
        private string m_currType = string.Empty;

        /// <summary>
        /// 获取或设置数据集的DataMember
        /// </summary>
        public string DataMember
        {
            set
            {
                
                this.bindingSource1.DataMember = value;
            }
            get
            {
                return this.bindingSource1.DataMember;
            }
        }
            

        /// <summary>
        /// 获取或设置当前要显示的属性表的父类编号
        /// </summary>
        public string Key
        {
            get
            {
                return this.m_key;
            }
            set
            {
                this.m_key = value;
            }
    
        }

        private DataSet m_DataSource = null;

        /// <summary>
        /// 获取或设置当前属性列表的数据源
        /// </summary>
        public DataSet DataSource
        {
            set
            {
                this.bindingSource1.DataSource = value;
            }
        }
      

        public Property()
        {
            InitializeComponent();
        }

        private void Property_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void DataBind()
        {
            ChangeTreeBind();
        }

        private void bindingSource1_DataMemberChanged(object sender, EventArgs e)
        {
            //当设置了 DataMember 发生变化时此事件激发
            
        }

        /// <summary>
        /// 改变树的改变
        /// </summary>
        private void ChangeTreeBind()
        {
            this.bindingSource1.Filter = string.Format("BaseID = '{0}'", this.m_key);
            DataView view = this.bindingSource1.List as DataView;
            DataTable table = this.Buider();
            //初始化表数据（行循环）
            foreach (DataRowView row in view)
            {
                //列循环
                foreach (DataColumn col in view.Table.Columns)
                {
                    DataRow r;

                    switch (col.ColumnName)
                    {
                        case "ID":
                        case "BaseID":
                            break;
                        case "Type":
                            m_currType = row[col.ColumnName].ToString();
                            break;
                        case "Diameter":
                            if (m_currType == "柱")
                            {
                                 r = table.NewRow();
                                r.BeginEdit();
                                r["OtherID"] = row["ID"];
                                r["Name"] = col.Caption;
                                r["Value"] = row[col.ColumnName];
                                r["FiledName"] = col.ColumnName;
                                r.EndEdit();
                                table.Rows.Add(r);
                            }
                            break;
                        default://默认全部加入
                                 r = table.NewRow();
                                r.BeginEdit();
                                r["OtherID"] = row["ID"];
                                r["Name"] = col.Caption;
                                r["Value"] = row[col.ColumnName];
                                r["FiledName"] = col.ColumnName;
                                r.EndEdit();
                                table.Rows.Add(r);
                            break;
                    }


                    /*if (col.ColumnName != "ID" && col.ColumnName != "BaseID")
                    {
                        
                        //初始化构造时候转换列
                        if (col.ColumnName == "Diameter")
                        {
                            if (m_currType == "柱")
                            {
 
                            }
                        }
                        DataRow r = table.NewRow();
                        r.BeginEdit();
                        r["OtherID"] = row["ID"];
                        r["Name"] = col.Caption;
                        r["Value"] = row[col.ColumnName];
                        r["FiledName"] = col.ColumnName;
                        r.EndEdit();
                        table.Rows.Add(r);
                    }*/
                }
            }
            table.RowChanged += new DataRowChangeEventHandler(table_RowChanged);
            this.bindingSource2.DataSource = table;
            this.treeList1.DataSource = this.bindingSource2;
        }

        /// <summary>
        /// 当行数据发生变化时候修改源数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Change)
            {
                DataRowView row = this.bindingSource1.Current as DataRowView;
                row.BeginEdit();
                string fieldName = e.Row["FiledName"].ToString();
                if (fieldName == "Name")
                {
                    //如果变换的是名称需要同步修改节点名称
                    if (this.m_ChangeName != null)
                    {
                        m_ChangeName(e.Row);
                    }
                }
                row[fieldName] = e.Row["Value"].ToString();
                row.EndEdit();
            }
        }

        /// <summary>
        /// 构造并初始化基础属性表
        /// </summary>
        /// <returns></returns>
        private DataTable Buider()
        {
            DataTable table = new DataTable("临时表");
            //此结构为基础表的结构
            DataColumn dc = table.Columns.Add("ID", typeof(int));//唯一表示            
            table.Columns.Add("OtherID", typeof(int));//在父表中的位置
            table.Columns.Add("Name", typeof(string));//属性名称
            table.Columns.Add("Value", typeof(string));//属性值
            table.Columns.Add("FiledName", typeof(string));//字段名称
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;
            dc.AutoIncrementStep = 1;
            return table;
        }

        private void treeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            
            
        }

        private void treeList1_ShownEditor(object sender, EventArgs e)
        {
            
        }

        private void treeList1_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            string str = e.Node.GetValue("FiledName").ToString();
            switch (str)
            {
                case "Requirements":
                    e.RepositoryItem = this.RI_Requirements;
                    break;
                case  "Strength":
                    e.RepositoryItem = this.RI_Strength;
                    break;
                case "Position":
                    e.RepositoryItem = this.RI_Position;
                    break;
                case "Cement":
                    e.RepositoryItem = this.RI_Cement;
                    break;
                case "Pebble":
                    e.RepositoryItem = this.RI_Pebble;
                    break;
                case "Sand":
                    e.RepositoryItem = this.RI_Sand;
                    break;
                case "SectionShape"://形状需要特殊处理
                    doLoadEdit_SectionShape(e);
                    break;
                case "Cutwidth"://截宽
                    doLoadEdit_Cutwidth(e);
                    break;
                case "CutHigh"://截高
                    doLoadEdit_CutHigh(e);
                    break;
                case "Diameter":

                    break;
            }
        }

        /// <summary>
        /// 为性形状初始化编辑控件
        /// </summary>
        /// <param name="e"></param>
        private void doLoadEdit_SectionShape(DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            //根据不同的类别处理
            //e.Node.GetValue
            string[] items;
            switch (this.m_currType)
            {
                case "柱" :
                    items = new string[] { "矩形","圆形","L形","T形","十字形","Z形","工字形","H形" };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
                case "梁":
                    items = new string[] { "矩形", "弧形", "拱形", "L形", "T形", "十字形", "凸形", "花篮形" };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
                case "墙":
                    items = new string[] { "直形","弧形","毛石" };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
            }
        }

        /// <summary>
        /// 为截宽初始化编辑控件
        /// </summary>
        /// <param name="e"></param>
        private void doLoadEdit_Cutwidth(DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            //根据不同的类别处理
            //e.Node.GetValue
            object[] items;
            switch (this.m_currType)
            {
                case "柱":
                    items = new object[] { 53, 100, 120, 150, 160, 180, 190, 200, 240, 250, 300, 350, 300, 365, 370, 400, 450, 490, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000 };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
                case "梁":
                    items = new object[] { 53,100,120,150,160,180,190,200,240,250,300,350,300,365,370,400,450,490,500,550,600,650,700,750,800,850,900,950,1000 };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
                case "墙":
                    items = new object[] { 100,120,150,180,200,240,250,300,350,400,450,500,550,600 };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
            }
        }

        /// <summary>
        /// 为截高初始化编辑控件
        /// </summary>
        /// <param name="e"></param>
        private void doLoadEdit_CutHigh(DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            //根据不同的类别处理
            //e.Node.GetValue
            object[] items;
            switch (this.m_currType)
            {
                case "柱":
                    items = new object[] { 53,100,120,150,160,180,190,200,240,250,300,350,300,365,370,400,450,490,500,550,600,650,700,750,800,850,900,950,1000 };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
                case "梁":
                    items = new object[] { 53,100,120,150,160,180,190,200,240,250,300,350,300,365,370,400,450,490,500,550,600,650,700,750,800,850,900,950,1000 };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
                case "墙":
                    items = new object[] { "单面支模","双面支模" };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
            }
        }

        /// <summary>
        /// 为直径初始化编辑控件
        /// </summary>
        /// <param name="e"></param>
        private void doLoadEdit_CutDiameter(DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            //根据不同的类别处理
            //e.Node.GetValue
            object[] items;
            switch (this.m_currType)
            {
                case "柱":
                    items = new object[] { 250,300,350,400,450,500,600,800,1000 };
                    e.RepositoryItem = new XtrRepositoryItemComboBoxEx(items);
                    break;
            }
        }


        /// <summary>
        /// 此处设置列不可修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            string str = e.Node.GetValue("Name").ToString();

            switch (str)
            {
                case "类别":
                case "单位":
                    this.treeList1.Columns[1].OptionsColumn.AllowEdit = false;
                    break;
                default:
                    this.treeList1.Columns[1].OptionsColumn.AllowEdit = true;
                    break;
            }
        }

    }
}
