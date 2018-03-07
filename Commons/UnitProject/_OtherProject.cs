using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;
using System.IO;
/*
 此单位工程的其他项目
 */
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _OtherProject:_BaseObject,IDataSerializable
    {


        //项目数据集
        private DataTable m_Source = null;

        [NonSerialized]
        private _Statistics m_Statistics;

        private string m_FileName;

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }
        public _Statistics Statistics
        {
            get { return m_Statistics; }
            set { m_Statistics = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string m_FilePath;
        /// <summary>
        /// 获取当前文件路径
        /// </summary>
        public string FilePath
        {
            get { return m_FilePath; }
           // set { m_FilePath = value; }
        }
        /// <summary>
        /// 项目数据集
        /// </summary>
        public DataTable Source
        {
            get
            {
                return this.m_Source;
            }
            set
            {
                this.m_Source = value;
            }
        }

        private _UnitProject m_Parent = null;
        private bool m_IsInit = true;
        /// <summary>
        /// 标识是否初始化过（添加默认模板）
        /// </summary>
        public bool IsInit
        {
            get { return m_IsInit; }
            set { m_IsInit = value; }
        }
        /// <summary>
        /// 父级对象(单位工程)
        /// </summary>
        public _UnitProject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }
        
 
        public _OtherProject()
        {
         
        }

        public _OtherProject(_UnitProject m_Parent)
        {

            this.m_Parent = m_Parent;
            //this.Activitie = m_Parent;
          //  this.m_Statistics = new _OtherProject_Statistics(this);
            this.m_Source = new DataTable();
            //this.init();
            // init();
        }

        public override _UnitProject Activitie
        {
            get
            {
                return this.Parent;
            }
        }
        public void init()
        {
            if (this.m_IsInit)
            {
                //this.m_Source = _Common.Application.Global.DataTamp.LoadOtherProject(this.m_Parent.Property.Basis.PGCDD, out m_FilePath).Copy();
                this.m_Source.PrimaryKey = new DataColumn[] { this.m_Source.Columns["ID"] };
                if (!this.m_Source.Columns.Contains("IsSys"))
                {
                    this.m_Source.Columns.Add("IsSys", typeof(bool));
                    foreach (DataRow item in this.m_Source.Rows)
                    {
                        item.BeginEdit();
                        item["IsSys"] = false;
                        item.EndEdit();
                    }
                }
                this.m_FileName = this.m_Source.TableName;
                //ChangeType();
                this.m_IsInit = false;
                //this.m_Source.WriteXml("D:\\1.xml");
            }
        }
        private void ChangeType()
        {
            string Cols = "Coefficient";
            foreach (string  item in Cols.Split(','))
            {
                this.m_Source.Columns.Remove(item);
                this.m_Source.Columns.Add(new DataColumn(item, typeof(decimal)));
            }
            
        }

        /// <summary>
        ///从指定文件初始化数据集
        /// </summary>
        public void Load(string Path)
        {
            if (this.m_Source != null)
            {
                object obj = CFiles.Deserialize(Path);
                this.m_Source = obj as DataTable;
                this.m_FilePath = Path;
                FileInfo info = new FileInfo(Path);
                this.m_FileName = info.Name.Replace(info.Extension, "");
            }
        }
        public void Save(string path)
        {
            CFiles.BinarySerialize(this.m_Source, path);
        }
        /// <summary>
        /// 用于完成初始化计算的方法
        /// </summary>
        public void Calculate()
        {
            //查看每个分析对象是否存在跟对象
            DataRow[] rows = this.m_Source.Select("ParentID = 0");
            foreach (DataRow row in rows)
            {
                calculateChilden(row);
            }
        }

        private void calculateChilden(DataRow row)
        {
            DataRow[] rows = this.m_Source.Select(string.Format("ParentID = {0}", row["ID"]));
            if (rows.Length == 0)
            {
               
                //直接计算
                string str = ToolKit.ExpressionReplace(row["Calculation"].ToString(), this.Parent.Property.Statistics.ResultVarable.DataSource);
                //完成统计
                //decimal d = ToolKit.Calculate(str);
                decimal d = 0;
                using (DataTable table = new DataTable())
                {
                    try
                    {
                        d = ToolKit.ParseDecimal(table.Compute(str, string.Empty));
                    }
                    catch
                    {
                        d = 0;
                    }
                }
                //decimal d = ToolKit.Expression(str);
                //费率若小于 0 大于 100 按照100计算
                decimal coe = ToolKit.ParseDecimal(row["Coefficient"]);
                if (coe < 0 || coe > 100)
                {
                    coe = 100;
                }
                d = d * coe * 0.01M;
                //结果赋值
                row.BeginEdit();
                row["Unitprice"] = d;
                row["Combinedprice"] = d * ToolKit.ParseDecimal(row["Quantities"]);
                row.EndEdit();
                //添加到结果集合(汇总分析此处修改添加列特项进入参数列表)
                //this.Parent.Statistics.ResultVarable.Set(row["Number"].ToString(), d, row["Remark"].ToString());

               
            }
            else
            {
                //继续计算(有孩子继续计算 并且统计当前节点)
                foreach (DataRow r in rows)
                {
                    this.calculateChilden(r);
                    //SetCurrentParent(r);
                }
                //计算完成后统计当前节点
                this.SetCurrent(row);

              }
        }

        private void SetCurrent(DataRow row)
        {
            int id = ToolKit.ParseInt(row["ID"]);
            DataRow r = this.m_Source.Rows.Find(id);
            decimal d = 0m;
            DataRow[] rows = this.m_Source.Select(string.Format(" ParentID = {0}", id));
            foreach (DataRow item in rows)
            {
                d += ToolKit.ParseDecimal(item["Combinedprice"]);
            }
               
               // ToolKit.ParseDecimal(this.m_Source.Compute("SUM(Combinedprice)", string.Format(" ParentID = {0}", id)));
            r.BeginEdit();
            r["Combinedprice"] = d;
            r.EndEdit();
        }

        /// <summary>
        /// 统计当前的父行计算结果
        /// </summary>
        /// <param name="row"></param>
        public void SetCurrentParent(DataRow row)
        {
            //1.当前父节点是否为0
            //2.若不是0统计所有当前父节点的数据求和
            //3.赋值给父节点
            int id = ToolKit.ParseInt(row["ParentID"]);
            if (id != 0)
            {
                decimal d = 0m;
                decimal d1 = 0m;
                DataRow[] rows = this.m_Source.Select(string.Format(" ParentID = {0}", id));
                foreach (DataRow item in rows)
                {
                    if (!string.IsNullOrEmpty(item["Combinedprice"].ToString()))
                    {
                        d += ToolKit.ParseDecimal(item["Combinedprice"]);
                    }
                    if (!string.IsNullOrEmpty(item["cjhj"].ToString()))
                    {
                        d1 += ToolKit.ParseDecimal(item["cjhj"]);
                    }
                }

                DataRow r = this.m_Source.Rows.Find(id);
                r.BeginEdit();
                r["Combinedprice"] = d;
                r["cjhj"] = d1;
                r.EndEdit();
                SetCurrentParent(r);
            }
        }
        public string GetName()
        {
            string name = "F";
            object count = this.Source.Compute("Count(ID)", " ParentID = 0 ");
            return name + ((int)count + 1);
        }

        public DataRow Add()
        {
            DataTable dv = this.Source as DataTable;
            DataRow row = dv.NewRow();
            row.BeginEdit();
            row["Number"] = GetName();
            row["ParentID"] = 0;
            row.EndEdit();
            dv.Rows.Add(row);
            return row;
        }
        public DataRow Add_Child(DataRow p_row)
        {
            //DataRow drv = this.bindingSource1.Current as DataRowView;
            if (p_row != null)
            {
               
                DataRow row = this.Source.NewRow();
                row.BeginEdit();
                row["Number"] = GetChdName(p_row);
                row["ParentID"] = p_row["ID"];
                row.EndEdit();
                this.Source.Rows.Add(row);
                return row;
            }
            return null;
        }
        private string GetChdName(DataRow p_row)
        {
            DataRow drv = p_row;
            string name = string.Empty;
            if (drv != null)
            {
                int id = ToolKit.ParseInt(drv["ID"]);
                name = drv["Number"].ToString();
                object count =this.Source.Compute("Count(ID)", string.Format(" ParentID = {0} ", id));
                return string.Format("{0}.{1}", name, (int)count + 1);
            }
            return string.Empty;
        }
        public void Begin()
        {
            this.m_Statistics.Begin();
            this.Parent.Property.Statistics.Begin();
        }

        #region IDataSerializable 成员

        public void OutSerializable()
        {
            
        }

        public void InSerializable(object e)
        {
            //this.Statistics = new _OtherProject_Statistics(this);
        }

        #endregion
    }
}
