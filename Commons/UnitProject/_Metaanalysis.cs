/*
 为此单位工程提供的汇总分析类（此类别在单位工程完成创建初始化后调用）
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Metaanalysis
    {
        //汇总分析的结果数据集
        private DataTable m_Source = null;

        /// <summary>
        /// 获取或设置当前汇总分析的结果数据集
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

        private bool m_IsInit = false;
        /// <summary>
        /// 标识是否初始化过（添加默认模板）
        /// </summary>
        public bool IsInit
        {
            get { return m_IsInit; }
            set { m_IsInit = value; }
        }
        /// <summary>
        /// 获取所属的单位工程对象
        /// </summary>
        private _UnitProject m_Parent = null;

        /// <summary>
        /// 获取所属的单位工程对象
        /// </summary>
        public _UnitProject Parent
        {
            get { return this.m_Parent; }
        }

        /// <summary>
        /// 读取模板文件
        /// </summary>
        /// <param name="p_FileName"></param>
        public void Load(string p_FileName)
        {
            //if (this.IsInit)
            {
                this.m_Source = CFiles.Deserialize(p_FileName) as DataTable;
                //this.Calculate();
                this.m_Parent.BeginEdit(this);
                //this.m_IsInit = false;
            }
        }

        /// <summary>
        /// 保存模板文件
        /// </summary>
        /// <param name="p_FileName"></param>
        public void Save(string p_FileName)
        {
            //保存模板的时候重新设置列
            
            
                //this.m_Source.Columns.Remove(this.m_Source.Columns["Price"]);
                //this.m_Source.Columns.Add("Price", typeof(decimal));
                
            CFiles.BinarySerialize(this.m_Source, p_FileName);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public _Metaanalysis(_UnitProject p_Parent)
        {
            this.m_Parent = p_Parent;
            //this.builder();
        }

        

        /// <summary>
        /// 单位工程完成后调用初始化方法(单位工程完成创建的时候此方法被调用)
        /// </summary>
        public void Init()
        {
            if (!this.m_IsInit)
            {
                switch (this.m_Parent.PJFCX)
                {
                    case 0:
                        this.m_Source = _Common.Application.Global.DataTamp.Metaanalysis.Tables["扣劳保"].Copy();
                        break;
                    case 1:
                        this.m_Source = _Common.Application.Global.DataTamp.Metaanalysis.Tables["不扣劳保"].Copy();
                        break;
                }
                //默认初始化税金
                switch (this.m_Parent.PNSDD)
                {
                    case "市区"://3.48
                        SetSJ(3.48M);
                        break;
                    case "县、城镇"://3.41
                        SetSJ(3.41M);
                        break;
                    case "非县、城镇"://3.28
                        SetSJ(3.28M);
                    break;
                }
                this.m_IsInit = true;
            }
            //添加主键
            //this.m_Source.PrimaryKey = new DataColumn[] { this.m_Source.Columns["ID"] };
        }

        private void SetSJ(decimal p_NewSJ)
        {
            //找到特想是SJ
            if (this.m_Source != null)
            {
                DataRow[] row = this.m_Source.Select("Feature = 'SJ'");
                if (row.Length == 1)
                {
                    row[0].BeginEdit();
                    row[0]["Coefficient"] = p_NewSJ;
                    row[0].EndEdit();
                }
            }
        }

        private void initSource()
        {

        }

        /// <summary>
        /// 用于完成初始化计算的方法（每次需要用到汇总分析变量时候调用此方法）
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
        /// <summary>
        /// 统计并计算子节点
        /// </summary>
        private void calculateChilden(DataRow row)
        {
            DataRow[] rows = this.m_Source.Select(string.Format("ParentID = {0}", row["ID"]));
            if (rows.Length == 0)
            {
                if (row["Feature"].ToString() == "ZZJ")
                {
                    int i = 0;
                }
                //直接计算
                string str = ToolKit.ExpressionReplace(row["Calculation"].ToString(), this.Parent.Property.Statistics.ResultVarable.DataSource);
                //完成统计
                //decimal d = ToolKit.Calculate(str);
                decimal d = 0;
                using(DataTable table = new DataTable())
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
                d = d * coe *0.01M;
                
                //结果赋值
                row.BeginEdit();
                row["Price"] = d;
                row.EndEdit();
                //添加到结果集合(汇总分析此处修改添加列特项进入参数列表)
                //this.Parent.Statistics.ResultVarable.Set(row["Number"].ToString(), d, row["Remark"].ToString());
               
                this.Parent.Property.Statistics.ResultVarable.Set(row["Feature"].ToString(), d, row["Remark"].ToString());
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
                this.SetCurrentParent(row);

                if (isRate(row))
                {
                    this.SetRate(row);
                }
            }
        }

        private bool isRate(DataRow row)
        {
            string[] Accumulative = new string[] { "GF" };
           string str = row["Feature"].ToString();

           IEnumerable<string> a = from temp in Accumulative
                                   where temp == str
                                   select temp;
           if (a.Count() > 0)
           {
               return true;
           }
           return false;
        }

        public bool IsEdit = true;

        /// <summary>
        /// 费率统计计算
        /// </summary>
        /// <param name="row"></param>
        public void SetRate(DataRow row)
        {
            DataRow[] rows = this.m_Source.Select(string.Format("ParentID = {0}", row["ID"]));
            if (rows.Length > 0)
            {
                foreach (DataRow r in rows)
                {
                    SetRate(r);
                }

                if (IsEdit)
                {
                    int id = ToolKit.ParseInt(row["ID"]);
                    DataRow r = this.m_Source.Rows.Find(id);
                    decimal d = ToolKit.ParseDecimal(this.m_Source.Compute("SUM(Coefficient)", string.Format(" ParentID = {0}", id)));
                    IsEdit = false;
                    r.BeginEdit();
                    r["Coefficient"] = d;
                    r.EndEdit();
                    IsEdit = true;
                }
            }
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
            int id = ToolKit.ParseInt(row["ID"]);
            DataRow r = this.m_Source.Rows.Find(id);
            decimal d = ToolKit.ParseDecimal(this.m_Source.Compute("SUM(Price)", string.Format(" ParentID = {0}", id)));
            r.BeginEdit();
            r["Price"] = d;
            r.EndEdit();
            //this.Parent.Statistics.ResultVarable.Set(r["Number"].ToString(), d, r["Remark"].ToString());
            this.Parent.Property.Statistics.ResultVarable.Set(row["Feature"].ToString(), d, row["Remark"].ToString());
            //SetCurrentParent(r);

            
        }
    }
}
