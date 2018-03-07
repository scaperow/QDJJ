/*
 其他项目业务类
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
    public class _Method_OtherProject : _Methods
    {

        private _Business _CurrentBusiness = null;

        public _Business CurrentBusiness
        {
            get
            {
                return this._CurrentBusiness;
            }
            set
            {
                this._CurrentBusiness = value;
            }
        }

        private _UnitProject m_Unit = null;
        /// <summary>
        /// 当前单位工程对象
        /// </summary>
        public _UnitProject Unit
        {
            get { return m_Unit; }
            set { m_Unit = value; }
        }

        public _Method_OtherProject(_Business p_Bus, _UnitProject p_Unit)
        {
            this.m_Unit = p_Unit;
            this._CurrentBusiness = p_Bus;
        }

        /// <summary>
        /// 单位工程完成后调用初始化方法(单位工程完成创建的时候此方法被调用)
        /// </summary>
        public void Init()
        {

            DataTable table = APP.Application.Global.DataTamp.LoadOtherProject(this.Unit.PGCDD);
            this.LoadDefault(table);

        }

        /// <summary>
        /// 加载默认模板
        /// </summary>
        /// <param name="table"></param>
        private void LoadDefault(DataTable table)
        {
            //this.Unit.StructSource.ModelOtherProject.RowChanged += new DataRowChangeEventHandler(ModelOtherProject_RowChanged);
            ChangeType(table);
            this.LoadTable(table);
            //this.Unit.StructSource.ModelOtherProject.RowChanged -= new DataRowChangeEventHandler(ModelOtherProject_RowChanged);
        }

        private void LoadTable(DataTable table)
        {
            //查看每个分析对象是否存在跟对象
            this.SetAutoIncrement(this.m_Unit.StructSource.ModelOtherProject, false, 0);
            DataRow[] rows = table.Select("ParentID = 0");
            foreach (DataRow row in rows)
            {
                if (row["ParentID"].Equals(0))
                {
                    LoadRow(row, table, this.Unit.PKey);
                }
                else
                {
                    LoadRow(row, table, this.Unit.Key);
                }
            }
            int m = ToolKit.ParseInt(table.Compute("Max(ID)", ""));
            this.SetAutoIncrement(this.m_Unit.StructSource.ModelOtherProject, true, m + 1);
        }

        public void SetAutoIncrement(DataTable table, bool P_false, int AutoIncrementSeed)
        {
            table.Columns[0].AutoIncrement = P_false;
            table.Columns[0].AutoIncrementSeed = AutoIncrementSeed;
            table.Columns[0].AutoIncrementStep = 1;
        }
        private void LoadRow(DataRow row, DataTable table, int p_Pk)
        {
            DataRow r = this.Unit.StructSource.ModelOtherProject.Add(row);
            r.BeginEdit();
            r["UnID"] = this.Unit.ID;
            r["EnID"] = this.Unit.PID;
            r["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
            r["PKey"] = p_Pk;
            r.EndEdit();

            DataRow[] rows = table.Select(string.Format("ParentID = {0}", r["ID"]));
            foreach (DataRow rr in rows)
            {
                LoadRow(rr, table, ToolKit.ParseInt(r["Key"]));
            }

        }

        private void ChangeType(DataTable table)
        {

            table.Columns.Remove("Unitprice");
            table.Columns.Remove("Combinedprice");
            table.Columns.Add("Unitprice", typeof(decimal));
            table.Columns.Add("Combinedprice", typeof(decimal));
            table.AcceptChanges();

        }

        void ModelOtherProject_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            /*if (e.Action == DataRowAction.Add)
            {
                if (e.Row.RowState != DataRowState.Added)
                {
                    e.Row.SetAdded();
                }
                //同步编号 还要同步Key PKey
                e.Row["UnID"] = this.Unit.ID;
                e.Row["EnID"] = this.Unit.PID;
                e.Row["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
                e.Row["PKey"] = this.Unit.Key;
            }*/

        }

        /// <summary>
        /// 用于完成初始化计算的方法
        /// </summary>
        public override void Calculate()
        {
            //查看每个分析对象是否存在跟对象
            DataRow[] rows = this.m_Unit.StructSource.ModelOtherProject.Select("ParentID = 0");
            foreach (DataRow row in rows)
            {
                calculateChilden(row);
            }
            this.Begin();
        }

        private void calculateChilden(DataRow row)
        {
            DataRow[] rows = this.m_Unit.StructSource.ModelOtherProject.Select(string.Format("ParentID = {0}", row["ID"]));
            if (rows.Length == 0)
            {

                //直接计算
                string str = ToolKit.ExpressionReplace(row["Calculation"].ToString(), this.m_Unit.StructSource.ModelProjVariable);
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
            DataRow r = this.m_Unit.StructSource.ModelOtherProject.Rows.Find(id);
            decimal d = 0m;
            DataRow[] rows = this.m_Unit.StructSource.ModelOtherProject.Select(string.Format(" ParentID = {0}", id));
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
                DataRow[] rows = this.m_Unit.StructSource.ModelOtherProject.Select(string.Format(" ParentID = {0}", id));
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

                DataRow r = this.m_Unit.StructSource.ModelOtherProject.Rows.Find(id);
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
            object count = this.m_Unit.StructSource.ModelOtherProject.Compute("Count(ID)", " ParentID = 0 ");
            return name + ((int)count + 1);
        }

        public DataRow Add()
        {
            DataTable dv = this.m_Unit.StructSource.ModelOtherProject as DataTable;
            DataRow row = dv.NewRow();
            row.BeginEdit();
            row["Number"] = GetName();
            row["ParentID"] = 0;
            //
            row["EnID"] = this.Unit.PID;
            row["UnID"] = this.Unit.ID;
            row["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
            row.EndEdit();
            dv.Rows.Add(row);
            return row;
        }
        public DataRow Add_Child(DataRow p_row)
        {
            //DataRow drv = this.bindingSource1.Current as DataRowView;
            if (p_row != null)
            {

                DataRow row = this.m_Unit.StructSource.ModelOtherProject.NewRow();
                row.BeginEdit();
                row["Number"] = GetChdName(p_row);
                row["ParentID"] = p_row["ID"];
                row["EnID"] = this.Unit.PID;
                row["UnID"] = this.Unit.ID;
                row["Key"] = ++this.CurrentBusiness.Current.ObjectKey;
                row.EndEdit();
                this.m_Unit.StructSource.ModelOtherProject.Rows.Add(row);
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
                object count = this.m_Unit.StructSource.ModelOtherProject.Compute("Count(ID)", string.Format(" ParentID = {0} ", id));
                return string.Format("{0}.{1}", name, (int)count + 1);
            }
            return string.Empty;
        }
        /// <summary>
        /// 其他项目计算方法
        /// </summary>
        public virtual void Begin()
        {
            this.Unit.IsCalculated = true;

            _OtherProject_Statistics sta = new _OtherProject_Statistics(this.Unit);
            sta.Begin();
            /*this.m_Statistics.Begin();
            this.Parent.Property.Statistics.Begin();

            _Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;

            _FixedList_Statistics sta = new _FixedList_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();

            //计算子目所属节
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelSubSegments.GetRowByOther(this.Current.PID.ToString());
            _ObjectSource.GetObject(info, row);
            met = new _Method_Fest(this.Unit, info);
            met.Begin();*/
        }


        /// <summary>
        ///从指定文件初始化数据集
        /// </summary>
        public void Load(string p_FileName)
        {
            //更换模板
            DataTable table = CFiles.Deserialize(p_FileName) as DataTable;
            this.Unit.DataTemp.ODataTemp.FileName = p_FileName;
            this.Unit.DataTemp.ODataTemp.IsChange = true;
            //删除当前模板 
            this.Unit.StructSource.ModelOtherProject.Clear();
            this.Unit.StructSource.ModelOtherProject.AcceptChanges();
            this.LoadDefault(table);
            this.Calculate();
            this.FastCalculate();
        }

        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="p_FileName"></param>
        public void Save(string p_FileName)
        {
            //CFiles.BinarySerialize(this.m_Source, path);
            DataTable table = this.Unit.StructSource.ModelOtherProject.Copy();
            table.AcceptChanges();
            CFiles.BinarySerialize(table, p_FileName);
        }

        internal void FastCalculate()
        {
            using (var calculator = new Calculator(this.CurrentBusiness, this.Unit))
            {
                var table = this.Unit.StructSource.ModelOtherProject.GetChanges();
                if (table != null)
                {
                    calculator.Rows.AddRange(table.Select());
                }
            }

            //Unit.StructSource.ModelOtherProject.AcceptChanges();
        }
    }
}
