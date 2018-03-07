/*
    用于完成属性的接口
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 用于属性展示的接口实现 您需要对需要显示为属性的任何数据源做转换准备操作
    /// 1.首先创建层次设置工作(树形结构的所有根结点加载 实现 CreatRoot方法)
    /// </summary>
    public interface IAttributes
    {

        /// <summary>
        /// 获取当前属性转换的源数据
        /// </summary>
        object Source { get; set; }

        /// <summary>
        /// 属性转换方法
        /// </summary>
        /// <param name="p_Table">已经初始化的基础数据表</param>
        void ConvertToDisplay(CAttributes p_Table);

        /// <summary>
        /// 当属性值发生变化的时候如何回写属性值
        /// </summary>
        /// <param name="p_Table"></param>
        /// <param name="e"></param>
        void ChangeValue(CAttributes p_Table, DataRowChangeEventArgs e);

    }

    /// <summary>
    /// 为属性定义的
    /// </summary>
    public class CAttributes : DataTable
    {
        /// <summary>
        /// 属性类构造函数
        /// </summary>
        public CAttributes()
            : base("属性表")
        {
            this.init();
        }

        /// <summary>
        /// (每次构造的时候会调用此方法创建基础表结构)为属性控件构造显示的数据表
        /// </summary>
        /// <returns></returns>
        private void init()
        {
            //此结构为基础表的结构
            DataColumn dc = this.Columns.Add("ID", typeof(int));//唯一表示            
            this.Columns.Add("ParentID", typeof(int));//如果存在节点此处设置父ID
            this.Columns.Add("Name", typeof(string));//属性名称(显示的名称)
            this.Columns.Add("Value", typeof(object));//属性值
            this.Columns.Add("FiledName", typeof(string));//(源字段)名称
            this.Columns.Add("EditType", typeof(object));//编辑类型
            this.Columns.Add("IsEdit", typeof(bool)).DefaultValue = false;//是否为分类属性(分类属性不可编辑)
            this.Columns.Add("Source", typeof(object)).DefaultValue = false;//当前属性的来源(属性绑定使用)
            this.Columns.Add("Type", typeof(object)).DefaultValue = false;//当前属性的源类型
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;
            dc.AutoIncrementStep = 1;
        }

        /// <summary>
        /// 为当前的属性数据源添加节点
        /// </summary>
        /// <param name="p_name">显示的属性名称</param>
        /// <param name="p_value">显示的属性值</param>
        /// <param name="m_FiledName">源字段名称</param>
        /// <returns>当前添加的节点的编号</returns>
        public int Add(int p_ParentID,string p_name,object p_value,string p_FiledName,object p_Source)
        {
            DataRow row = this.NewRow();
            row.BeginEdit();
            row["ParentID"]     = p_ParentID; //父类编号
            row["Name"]         = p_name;     //显示名称
            row["Value"]        = p_value;    //显示的值
            row["FiledName"]    = p_FiledName;//源字段名称(表是字段名称/对象为对象的属性名称)
            row["Source"]       = p_Source;//属性来源
            row["Type"]         = p_value.GetType();//保存Type的原类型
            row["IsEdit"]       = false;//源字段名称
            row.EndEdit();
            this.Rows.Add(row);
            return Convert.ToInt32(row["ID"]);
        }

        /// <summary>
        /// 为当前的属性数据源添加节点
        /// </summary>
        /// <param name="p_name">显示的属性名称</param>
        /// <param name="p_value">显示的属性值</param>
        /// <param name="m_FiledName">源字段名称</param>
        /// <returns>当前添加的节点的编号</returns>
        public int Add(int p_ParentID, string p_name, object p_value, string p_FiledName, object p_Source,bool p_isEdit)
        {
            DataRow row = this.NewRow();
            row.BeginEdit();
            row["ParentID"] = p_ParentID; //父类编号
            row["Name"] = p_name;     //显示名称
            row["Value"] = p_value;    //显示的值
            row["FiledName"] = p_FiledName;//源字段名称(表是字段名称/对象为对象的属性名称)
            row["Source"] = p_Source;//属性来源
            row["Type"] = p_value.GetType();//保存Type的原类型
            row["IsEdit"] = p_isEdit;//源字段名称
            row.EndEdit();
            this.Rows.Add(row);
            return Convert.ToInt32(row["ID"]);
        }

        /// <summary>
        ///  仅仅为显示提供的添加方法
        /// </summary>
        /// <param name="p_name">显示的属性名称</param>
        /// <param name="p_value">显示的属性值</param>
        /// <param name="m_FiledName">源字段名称</param>
        /// <returns>当前添加的节点的编号</returns>
        public int Add(int p_ParentID, string p_name, object p_value)
        {
            DataRow row = this.NewRow();
            row.BeginEdit();
            row["ParentID"] = p_ParentID; //父类编号
            row["Name"] = p_name;     //显示名称
            row["Value"] = p_value;    //显示的值
            row["IsEdit"] = false;//源字段名称
            row.EndEdit();
            this.Rows.Add(row);
            return Convert.ToInt32(row["ID"]);
        }

        /// <summary>
        ///  为属性添加分类索引
        /// </summary>
        /// <param name="p_ParentID">分类的父类编号</param>
        /// <param name="p_name">分类名称</param>
        /// <returns>当前添加的节点的编号</returns>
        public int Add(int p_ParentID, string p_name)
        {
            DataRow row = this.NewRow();
            row.BeginEdit();
            row["ParentID"] = p_ParentID; //父类编号
            row["Name"] = p_name;     //显示名称
            row["Value"] = string.Empty;    //显示的值
            row["IsEdit"] = false;//源字段名称
            row.EndEdit();
            this.Rows.Add(row);
            return Convert.ToInt32(row["ID"]);
        }       
    }
}
