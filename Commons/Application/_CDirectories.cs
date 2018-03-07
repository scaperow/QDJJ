/*
    用于处理项目清单表格
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    //项目清单类
    [Serializable]
    public class _CDirectories
    {
        /// <summary>
        /// 接收变更方式
        /// </summary>
        public enum EAcceptType
        {
            /// <summary>
            /// 新增方式
            /// </summary>
            New  = 0,
            /// <summary>
            /// 编辑方式
            /// </summary>
            Edit = 1

        }

        public _CDirectories this[int p_key]
        {
            get 
            {
                if (this.m_Directories != null)
                {
                    if (this.m_Directories.Rows.Contains(p_key))
                    {
                        DataRow row = this.m_Directories.Rows.Find(p_key);
                        if (row != null)
                        {
                            _CDirectories info = new _CDirectories();
                            info.m_ParentFieldName =  Convert.ToInt32(row["ParentFieldName"]);
                            info.m_NodeName = row["NodeName"].ToString();
                            info.m_ImageIndex = Convert.ToInt32(row["ImageIndex"]);
                            info.m_Path = row["Path"].ToString();
                            info.TypeName = Convert.ToInt32(row["TypeName"]);
                            info.m_Key = Convert.ToInt32(row["Key"]);
                            return info;
                        }
                    }
                }
                return null;
            }

        }

        private DataTable m_Directories = null;

        /// <summary>
        /// 用于处理项目清单的DataTable
        /// </summary>
        public DataTable Directories
        {
            get
            {
                return this.m_Directories;
            }
            set
            {
                this.m_Directories = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public _CDirectories()
        {
           m_Directories = CommonData.GetDirectoryList("Directory");
        }

        private int m_Key = -1;
        //private string m_KeyFieldName;
        private int m_ParentFieldName;
        private string m_NodeName = string.Empty;
        private int m_ImageIndex;
        private string m_Path = string.Empty;
        private int m_TypeName;
        private int m_Sort;
        public int Key { get { return this.m_Key; } set { this.m_Key = value; } }
        //public string KeyFieldName { get { return this.m_KeyFieldName; } set { this.m_KeyFieldName = value; } }
        public int ParentFieldName { get { return this.m_ParentFieldName; } set { this.m_ParentFieldName = value; } }
        public string NodeName { get { return this.m_NodeName; } set { this.m_NodeName = value; } }
        public int ImageIndex { get { return this.m_ImageIndex; } set { this.m_ImageIndex = value; } }
        public string Path { get { return this.m_Path; } set { this.m_Path = value; } }
        public int TypeName { get { return this.m_TypeName; } set { this.m_TypeName = value; } }
        public int Sort { get { return this.m_Sort; } set { this.m_Sort = value; } }

        /// <summary>
        /// 删除指定的字典
        /// </summary>
        /// <param name="info"></param>
        public void Remove(_CDirectories info)
        {
            DataRow row = this.m_Directories.Rows.Find(info.Key);
            row.Delete();
            row.AcceptChanges();
            this.m_Directories.AcceptChanges();
        }

        /// <summary>
        /// 删除指定的字典(递归删除子项)
        /// </summary>
        /// <param name="info"></param>
        public void Remove(int p_key)
        {
            //查找当前key是否有父类key
            DataRow[] rows = this.m_Directories.Select(string.Format("ParentFieldName = {0}", p_key));
            DataRow row = this.m_Directories.Rows.Find(p_key);
            if (rows.Length > 0)
            {
                //找到当前行记录
                foreach (DataRow r in rows)
                {
                    int k = Convert.ToInt32(r["Key"]);
                    this.Remove(k);
                } 
                
            }
            row.Delete();
            row.AcceptChanges();
            this.m_Directories.AcceptChanges();
        }

        /// <summary>
        /// 字典中是否存在指定的对象名称
        /// </summary>
        /// <param name="p_Name"></param>
        /// <returns></returns>
        public int IsExist(string p_Name, string p_TypeName)
        {
            DataRow[] rows = this.m_Directories.Select(string.Format("NodeName = '{0}' and TypeName in ({1})", p_Name, p_TypeName));
            return rows.Length;
            /*if (rows.Length > 0) return true;
            return false;*/
        }
        
        /// <summary>
        /// 确定接收变更（默认为添加的方式）(调用此方法会把所有属性添加到清单表格中)
        /// </summary>
        public void AcceptChanges()
        {
            DataRow row = this.m_Directories.NewRow();
            row.BeginEdit();
            row["ParentFieldName"] = this.m_ParentFieldName;
            row["NodeName"] = this.m_NodeName;
            row["ImageIndex"] = this.m_ImageIndex;
            row["Path"] = this.m_Path;
            row["TypeName"] = this.TypeName;
            row["Sort"] = this.Sort;
            row.EndEdit();
            this.m_Directories.Rows.Add(row);
            this.m_Directories.AcceptChanges();
            //取最后一行的编号作为当前的key返回给对象
            this.Key = (int)this.m_Directories.Rows[this.m_Directories.Rows.Count - 1]["Key"];
        }

        /// <summary>
        /// 根据操作类型 添加还是编辑
        /// </summary>
        /// <param name="p_AccType"></param>
        public void AcceptChanges(EAcceptType p_AccType)
        {
            switch (p_AccType)
            {
                case EAcceptType.New:
                        this.AcceptChanges();
                    break;
                case EAcceptType.Edit:
                        DataRow row = this.m_Directories.Rows.Find(this.Key);
                        row.BeginEdit();
                        row["ParentFieldName"] = this.m_ParentFieldName;
                        row["NodeName"] = this.m_NodeName;
                        row["ImageIndex"] = this.m_ImageIndex;
                        row["Path"] = this.m_Path;
                        row["TypeName"] = this.TypeName;
                        row["Sort"] = this.Sort;
                        row.EndEdit();
                        this.m_Directories.AcceptChanges();
                    break;
            }
        }

        /// <summary>
        /// 确定接收变更（以添加的方式）(调用此方法会把所有属性添加到清单表格中)
        /// </summary>
        public void AcceptChanges(_CDirectories info)
        {
            DataRow row = this.m_Directories.NewRow();
            row.BeginEdit();
            row["ParentFieldName"] = info.m_ParentFieldName;
            row["NodeName"] = info.m_NodeName;
            row["ImageIndex"] = info.m_ImageIndex;
            row["Path"] = info.m_Path;
            row["TypeName"] = info.TypeName;
            row["Sort"] = info.Sort;
            row.EndEdit();
            this.m_Directories.Rows.Add(row);
            this.m_Directories.AcceptChanges();
            //取最后一行的编号作为当前的key返回给对象
            info.Key = (int)this.m_Directories.Rows[this.m_Directories.Rows.Count - 1]["Key"];
        }

        /// <summary>
        /// 根据操作类型 添加还是编辑
        /// </summary>
        /// <param name="p_AccType"></param>
        public void AcceptChanges(EAcceptType p_AccType, _CDirectories info)
        {
            switch (p_AccType)
            {
                case EAcceptType.New:
                    this.AcceptChanges(info);
                    break;
                case EAcceptType.Edit:
                    DataRow row = this.m_Directories.Rows.Find(info.Key);
                    row.BeginEdit();
                    row["ParentFieldName"] = info.m_ParentFieldName;
                    row["NodeName"] = info.m_NodeName;
                    row["ImageIndex"] = info.m_ImageIndex;
                    row["Path"] = info.m_Path;
                    row["TypeName"] = info.TypeName;
                    row["Sort"] = info.Sort;
                    row.EndEdit();
                    this.m_Directories.AcceptChanges();
                    break;
            }
        }

        public DataTable GetFilter()
        {
            DataTable table = this.m_Directories.Copy();
            DataView view = table.DefaultView;
            view.RowFilter = string.Format("TypeName <> {0} ",操作类型.单位工程);
            return view.ToTable();
        }

        /// <summary>
        /// 获取指定类型的结果
        /// </summary>
        /// <param name="类型"></param>
        /// <returns></returns>
        public DataTable GetByType(int p_type)
        {
            DataTable table = this.m_Directories.Copy();
            DataView view = table.DefaultView;
            view.RowFilter = string.Format("TypeName = {0} ", p_type);
            return view.ToTable();
        }

        /// <summary>
        /// 批量增加单位工程时候使用的
        /// </summary>
        /// <returns></returns>
        public _CDirectories Clone()
        {
            _CDirectories info = new _CDirectories();
            info.m_Directories = this.GetFilter();
            info.m_Directories.PrimaryKey = new DataColumn[] { info.m_Directories.Columns["Key"] };
            return info;
        }

        /// <summary>
        /// 获取指定类型的个数
        /// </summary>
        /// <param name="p_type"></param>
        /// <returns></returns>
        public int GetCount(int p_type)
        {
            DataView view = this.m_Directories.DefaultView;
            view.RowFilter = string.Format("TypeName = {0} ", p_type);
            int count = view.Count;
            view.RowFilter = string.Empty;
            return count;
        }
    }
}
