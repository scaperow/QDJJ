/*
 单位工程的工程信息表处理信息结构
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{

    /// <summary>
    /// 工程信息表
    /// </summary>
    [Serializable]
    public class _CInformations
    {
        /// <summary>
        /// 工程信息是否完成初始化
        /// </summary>
        private bool m_isInit = false;

        /// <summary>
        /// 工程信息是否完成初始化
        /// </summary>
        public bool IsInit 
        {
            get
            {
                return this.m_isInit;
            }
        }

        /// <summary>
        /// 基础构件配置
        /// </summary>
        private DataTable m_Components = null;

        /// <summary>
        /// 属性数据集
        /// </summary>
        private DataSet m_Attributes = null;

        /// <summary>
        /// 获取或设置属性数据集
        /// </summary>
        public DataSet Attributes
        {
            get
            {
                return this.m_Attributes;
            }
            set
            {
                this.m_Attributes = value;
            }
        }

        /// <summary>
        /// 基础构件配置
        /// </summary>
        public DataTable Components
        {
            get
            {
                return this.m_Components;
            }
            set
            {
                this.m_Components = value;
            }
        }

        /// <summary>
        /// 需要根据基础构件配置初始化后才允许使用
        /// </summary>
        /// <param name="table"></param>
        public void Init(DataTable table)
        {
            //第一次初始化获取默认结构
            this.m_Components = table.Copy();
            
            //构造属性数据集
            m_Attributes = new DataSet("属性数据集");
            //初始化基础属性表
            DataTable dt = this.BuiderBaseAttribute(true);
            dt.RowChanged += new DataRowChangeEventHandler(dt_RowChanged);
            m_Attributes.Tables.Add(dt);
            //初始化属性空表
            m_Attributes.Tables.Add(this.BuiderAttribute());
            this.m_Components.RowChanged += new DataRowChangeEventHandler(m_Components_RowChanged);
            this.m_Components.RowDeleting += new DataRowChangeEventHandler(m_Components_RowDeleting);
            //初始化完成
            this.m_isInit = true;
        }


        /// <summary>
        /// 当基础属性发生变化时(如果已经存在属性表则同步)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Change)
            {
                DataTable table = this.m_Attributes.Tables["属性表"];
                DataView view = table.DefaultView;
                //主表组件视图
                DataView v = this.m_Components.Copy().DefaultView;
                v.RowFilter = string.Format("ParentID = '{0}'", e.Row["BaseID"]);
                string str = string.Empty;
                int i = 0;
                object[] obj = new object[v.Count];
                foreach (DataRowView row in v)
                {

                    obj[i] = row["ID"];

                    if (i == v.Count-1)
                    {
                        str += string.Format("'{0}'", row["ID"]);
                    }
                    else
                    {
                        str += string.Format("'{0}',", row["ID"]);
                    }

                    i++;
                }

                if (str != string.Empty)
                {
                    view.RowFilter = string.Format("BaseID in ({0})", str);

                    ///循环同步所有
                    foreach (DataRowView dv in view)
                    {
                        dv.BeginEdit();
                        dv["Requirements"] = e.Row["Requirements"];
                        dv["Strength"] = e.Row["Strength"];
                        dv["Position"] = e.Row["Position"];
                        dv.EndEdit();
                    }
                }
                view.RowFilter = v.RowFilter = string.Empty;
                
            }
        }

        /// <summary>
        /// 当基础结构数据源发生变化时候为属性表 创建 (属性表)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_Components_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            switch (e.Action)
            {
                case DataRowAction.Add://新增行的时候
                    addAttribute(e.Row);
                    break;
            }
        }
        /// <summary>
        /// 当基础结构数据源发生变化时候为属性表删除 (属性表)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_Components_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            switch (e.Action)
            {
                case DataRowAction.Delete:
                    string key = e.Row["ID"].ToString();
                    DataTable table = this.m_Attributes.Tables["属性表"];
                    string sql = string.Format("BaseID = '{0}'",key);
                    DataRow[] rows = table.Select(sql);
                    foreach (DataRow row in rows)
                    {
                        row.Delete();
                    }
                    break;
            }
        }

        /// <summary>
        /// 增加一条属性记录
        /// </summary>
        private void addAttribute(DataRow p_row)
        {
            //属性表
            DataTable table = this.m_Attributes.Tables["属性表"];
            DataTable t = this.m_Attributes.Tables["基础属性表"];
            //父类编号
            string p_id = p_row["ParentID"].ToString();
            //查找基础表中的信息
            DataRow dr = t.Rows.Find(p_id);
            if (dr != null)
            {
                //基础属性表
                DataRow row = table.NewRow();
                row.BeginEdit();
                row["BaseID"] = p_row["ID"];
                row["Requirements"] = dr["Requirements"];
                row["Strength"] = dr["Strength"];
                row["Position"] = dr["Position"];
                row["Type"] = dr["Type"];
                row["Name"] = p_row["Name"];
                row.EndEdit();
                table.Rows.Add(row);
                table.AcceptChanges();
            }
        }

        /// <summary>
        /// 添加新的信息结构
        /// </summary>
        public void Add(int parentKey,string name)
        {
            DataRow row = this.Components.NewRow();
            row.BeginEdit();
            row["ParentID"] = parentKey;
            row["Name"] = name;
            row.EndEdit();
            this.Components.Rows.Add(row);
            this.Components.AcceptChanges();
        }

        /// <summary>
        /// 创建并初始化属性表
        /// </summary>
        /// <returns></returns>
        private DataTable BuiderAttribute()
        {
            DataTable table = this.BuiderBaseAttribute(false);
            table.TableName = "属性表";
            //扩展列
            table.Columns.Add("Name", typeof(string)).Caption = "名称";
            table.Columns.Add("FromHigh", typeof(string)).Caption = "超高(m)";
            //table.Columns.Add("Type", typeof(string)).Caption = "类别";
            table.Columns.Add("SectionShape", typeof(string)).Caption = "截面形状";
            table.Columns.Add("Cutwidth", typeof(string)).Caption = "截宽(mm)";
            table.Columns.Add("CutHigh", typeof(string)).Caption = "截高(mm)";
            table.Columns.Add("Diameter", typeof(string)).Caption = "直径(mm)";
            table.Columns.Add("ColumnHeight", typeof(string)).Caption = "柱高度(mm)";
            DataColumn dc = table.Columns.Add("Unit", typeof(string));//单位
            table.Columns.Add("Quantities", typeof(string)).Caption = "工程量";
            table.Columns.Add("Pebble", typeof(string)).Caption = "石子";
            table.Columns.Add("Cement", typeof(string)).Caption = "水泥";
            table.Columns.Add("Sand", typeof(string)).Caption = "沙";

            dc.Caption = "单位";
            dc.DefaultValue = "M3";
            return table;
        }

        /// <summary>
        /// 构造并初始化基础属性表
        /// </summary>
        /// <returns></returns>
        private DataTable BuiderBaseAttribute(bool p_isInit)
        {
            DataTable table = new DataTable("基础属性表");
            //此结构为基础表的结构
            DataColumn dc = table.Columns.Add("ID", typeof(int));//唯一表示            
            DataColumn dc1 = table.Columns.Add("BaseID", typeof(int));
            table.Columns.Add("Requirements", typeof(string)).Caption  = "混凝土拌合料要求";//属性名称
            table.Columns.Add("Strength", typeof(string)).Caption = "混凝土强度等级" ;//属性名称
            table.Columns.Add("Type", typeof(string)).Caption = "类别";
            table.Columns.Add("Position", typeof(string)).Caption = "部位";
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;
            dc.AutoIncrementStep = 1;

            table.PrimaryKey = new DataColumn[]{dc1};

            if (p_isInit)
            {
                //为基础表初始化行（根据基础组件初始化表）
                foreach (DataRow row in this.m_Components.Rows)
                {
                    DataRow r = table.NewRow();
                    r["BaseID"] = row["ID"];
                    r["Type"] = row["Type"];
                    table.Rows.Add(r);
                }
            }
            return table;
        }
    }
}
