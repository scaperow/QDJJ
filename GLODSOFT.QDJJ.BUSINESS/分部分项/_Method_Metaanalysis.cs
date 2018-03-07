/*
 汇总分析方法
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Method_Metaanalysis : _Methods
    {
        private _UnitProject m_Unit = null;
        /// <summary>
        /// 当前单位工程对象
        /// </summary> 
        public _UnitProject Unit
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }

        public _Method_Metaanalysis(_UnitProject p_Unit)
        {
            this.m_Unit = p_Unit;
        }

        /// <summary>
        /// 单位工程完成后调用初始化方法(单位工程完成创建的时候此方法被调用)
        /// </summary>
        public void Init()
        {
            //如果是人工按照市场价的 加载2009的模板

            if (this.Unit.TemplateType == "0")
            {

                this.LoadFirstA();
            }
            else
            {
                this.LoadFirstB();
            }
        }

        /// <summary>
        /// 普通的模板加载 2012
        /// </summary>
        private void LoadFirstA()
        {
            //默认加载模板2012的
            switch (this.Unit.PJFCX)
            {
                case 0:
                    this.LoadDefault(APP.Application.Global.DataTamp.Metaanalysis.Tables["2012扣劳保"].Copy());
                    break;
                case 1:
                    this.LoadDefault(APP.Application.Global.DataTamp.Metaanalysis.Tables["2012不扣劳保"].Copy());
                    break;
            }
        }

        /// <summary>
        /// 普通的模板加载 2009
        /// </summary>
        private void LoadFirstB()
        {
            //默认加载模板2012的
            switch (this.Unit.PJFCX)
            {
                case 0:
                    this.LoadDefault(APP.Application.Global.DataTamp.Metaanalysis.Tables["2009扣劳保"].Copy());
                    break;
                case 1:
                    this.LoadDefault(APP.Application.Global.DataTamp.Metaanalysis.Tables["2009不扣劳保"].Copy());
                    break;
            }
        }

        /// <summary>
        /// 加载默认模板
        /// </summary>
        /// <param name="table"></param>
        private void LoadDefault(DataTable table)
        {
            ChangeType(table);
            this.Unit.StructSource.ModelMetaanalysis.RowChanged += new DataRowChangeEventHandler(ModelMetaanalysis_RowChanged);
            this.Unit.StructSource.ModelMetaanalysis.Merge(table);
            this.Unit.StructSource.ModelMetaanalysis.RowChanged -= new DataRowChangeEventHandler(ModelMetaanalysis_RowChanged);
        }

        /// <summary>
        /// 更换不可用的列类型
        /// </summary>
        /// <param name="table"></param>
        private void ChangeType(DataTable table)
        {

            table.Columns.Remove("Price");
            table.Columns.Add("Price", typeof(decimal));
            table.AcceptChanges();

        }

        void ModelMetaanalysis_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add)
            {
                if (e.Row.RowState != DataRowState.Added)
                {
                    e.Row.SetAdded();
                }
                
                
                //同步编号
                e.Row["UnID"] = this.Unit.ID;
                e.Row["EnID"] = this.Unit.PID;
                //if (e.Row["Feature"].Equals("SJ"))
                //{
                //    //默认初始化税金
                //    switch (this.Unit.PNSDD)
                //    {
                //        case "市区"://3.48
                //            e.Row["Coefficient"] = 3.48M;
                //            e.Row["Remark"] = "市区：3.48%；县、城镇：3.41%；非县城镇：3.28%";
                //            break;
                //        case "县、城镇"://3.41
                //            e.Row["Coefficient"] = 3.41M;
                //            e.Row["Remark"] = "市区：3.48%；县、城镇：3.41%；非县城镇：3.28%";
                //            break;
                //        case "非县、城镇"://3.28
                //            e.Row["Coefficient"] = 3.28M;
                //            e.Row["Remark"] = "市区：3.48%；县、城镇：3.41%；非县城镇：3.28%";

                //            break;
                //    }
                //}
            }
        }

        /// <summary>
        /// 设置税率 
        /// </summary>
        /// <param name="p_NewSJ"></param>
        private void SetSJ(decimal p_NewSJ)
        {
            //找到特想是SJ
            if (this.Unit.StructSource.ModelMetaanalysis != null)
            {
                DataRow[] row = this.Unit.StructSource.ModelMetaanalysis.Select(string.Format("Feature = 'SJ' and UnID = {0}", this.Unit.ID));
                if (row.Length == 1)
                {
                    row[0].BeginEdit();
                    row[0]["Coefficient"] = p_NewSJ;
                    row[0].EndEdit();
                }
            }
        }


        /// <summary>
        /// 用于完成初始化计算的方法（每次需要用到汇总分析变量时候调用此方法）
        /// </summary>
        public override void Calculate()
        {
            //查看每个分析对象是否存在跟对象
            DataRow[] rows = this.Unit.StructSource.ModelMetaanalysis.Select(string.Format("ParentID = 0 and UnID = {0}",this.Unit.ID));
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
            DataRow[] rows = this.Unit.StructSource.ModelMetaanalysis.Select(string.Format("ParentID = {0} and UnID = {1}", row["ID"],this.Unit.ID));
            if (rows.Length == 0)
            {
                if (row["Feature"].ToString() == "ZZJ")
                {
                    int i = 0;
                }
                //直接计算
                string str = ToolKit.ExpressionReplace(row["Calculation"].ToString(), this.Unit.StructSource.ModelProjVariable);
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
                row["Price"] = d.ToString("N2");
                row.EndEdit();
                //添加到结果集合(汇总分析此处修改添加列特项进入参数列表)

                this.Unit.StructSource.ModelProjVariable.Set(this.Unit.PID,this.Unit.ID, -1, row["Feature"].ToString(), d, row["Name"].ToString());
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
            DataRow[] rows = this.Unit.StructSource.ModelMetaanalysis.Select(string.Format("ParentID = {0} and UnID = {1}", row["ID"],this.Unit.ID));
            if (rows.Length > 0)
            {
                foreach (DataRow r in rows)
                {
                    SetRate(r);
                }

                if (IsEdit)
                {
                    int id = ToolKit.ParseInt(row["ID"]);
                    DataRow r = this.Unit.StructSource.ModelMetaanalysis.Rows.Find(id);
                    decimal d = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMetaanalysis.Compute("SUM(Coefficient)", string.Format(" ParentID = {0} and UnID = {1}", id,this.Unit.ID)));
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
            DataRow r = this.Unit.StructSource.ModelMetaanalysis.Rows.Find(id);
            decimal d = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMetaanalysis.Compute("SUM(Price)", string.Format(" ParentID = {0} and UnID = {1}", id,this.Unit.ID)));
            r.BeginEdit();
            r["Price"] = d;
            r.EndEdit();
            
            this.Unit.StructSource.ModelProjVariable.Set(this.Unit.PID,this.Unit.ID,-1,row["Feature"].ToString(), d, row["Name"].ToString());
            


        }


        /// <summary>
        /// 读取模板文件
        /// </summary>
        /// <param name="p_FileName"></param>
        public void Load(string p_FileName)
        {
           //更换模板
            DataTable table = CFiles.Deserialize(p_FileName) as DataTable;
            this.Unit.DataTemp.MSDataTemp.FileName = p_FileName;
            //this.Unit.DataTemp.MSDataTemp.IsChange = true;
            //删除当前模板 
            this.Unit.StructSource.ModelMetaanalysis.RemoveAll();
            this.LoadDefault(table);
            this.Calculate();
        }

        /// <summary>
        /// 保存模板文件
        /// </summary>
        /// <param name="p_FileName"></param>
        public void Save(string p_FileName)
        {
            //保存模板的时候重新设置列
            DataTable table = this.Unit.StructSource.ModelMetaanalysis.Copy();
            table.AcceptChanges();
            CFiles.BinarySerialize(table, p_FileName);
        }
    }
}
