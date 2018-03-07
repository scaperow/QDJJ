using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList;
namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProOtherForm : ABaseForm
    {

        /// <summary>
        /// 获取参数表中的值
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_key"></param>
        /// <returns></returns>
        private decimal GetData(int p_ID, string p_key)
        {
            return this.CurrentBusiness.Current.StructSource.ModelProjVariable.GetDecimal(p_ID, -1, p_key);
        }

        /// <summary>
        /// 获取参数表中的值
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_key"></param>
        /// <returns></returns>
        private decimal GetData(int p_ID, string p_key, int p_Level)
        {
            return this.CurrentBusiness.Current.StructSource.ModelProjVariable.GetDecimal(p_ID, p_Level, p_key);
        }

        public ProOtherForm()
        {
            InitializeComponent();
        }
        private DataTable m_Table;
        private int m;
        private void ProOtherForm_Load(object sender, EventArgs e)
        {
            init();
            initForm();
        }
        public override void MustInit()
        {
            base.MustInit();
            init();
        }
        private void initForm()
        {
           
        }

        /// <summary>
        /// 全局配色方案改变时候
        /// </summary>
        public override void GlobalStyleChange()
        {
            this.treeListEx1.ModelName = "项目_其他项目";
            //第一次加载样式
            this.treeListEx1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
           // this.treeListEx1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
        }

        private void SetSort()
        {
            DataRow[] rows = this.CurrentBusiness.Current.StructSource.ModelProject.Select("DEEP = 2");
            foreach (DataRow row in rows)
            {
                DataRow[] rs = this.CurrentBusiness.Current.StructSource.ModelOtherProject.Select(string.Format(" ParentID = 0 and UnID = {0} ", row["ID"]));
                if (rs.Length > 0)
                {
                    rs[0]["Sort"] = row["Sort"];
                }
            }
        }

        private void init()
        {

            this.SetSort();
            DataView view = this.CurrentBusiness.Current.StructSource.ModelOtherProject.DefaultView;
            view.Sort = " Sort asc";
            //Build();
            //m = 0;
            //BuildRow(this.CurrentBusiness.Current, 0,null);
            //SetParentHJ();//计算合计
            //this.bindingSource1.DataSource = this.CurrentBusiness.Current.StructSource.ModelOtherProject.DefaultView;
            this.treeListEx1.DataSource = null;
            this.treeListEx1.DataSource = view;
            //this.treeListEx1.KeyFieldName = "ID";
            //this.treeListEx1.ParentFieldName = "PID";
            this.treeListEx1.Expand(2);
            this.treeListEx1.OptionsBehavior.Editable = false;

        }

        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.BeforeStatistical -= new BeforeStatisticalHandler(wcForm_BeforeStatistical);
            wcForm.AfterStatisticaled -= new AfterStatisticaledHandler(wcForm_AfterStatisticaled);
        }

        public override void OnInitForm()
        {
            base.OnInitForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.BeforeStatistical += new BeforeStatisticalHandler(wcForm_BeforeStatistical);
            wcForm.AfterStatisticaled += new AfterStatisticaledHandler(wcForm_AfterStatisticaled);
        }

        void wcForm_AfterStatisticaled(object sender, object args)
        {
            this.init();
        }

        void wcForm_BeforeStatistical(object sender, object args)
        {
            this.treeListEx1.DataSource = null;
        }

        /// <summary>
        /// 计算合计
        /// </summary>
        private void SetParentHJ()
        {
            DataRow[] rows = this.m_Table.Select("XH='F1'");
            foreach (DataRow item in rows)
            {
                SetParentHJ(item);
            }

            
        }
        private void SetParentHJ(DataRow row)
        {
            DataRow[] rows = this.m_Table.Select(string.Format("ID='{0}'",row["PID"]));
            if (rows.Length>0)
            {
                rows[0]["HJ"] = this.m_Table.Compute(String.Format("Sum({0})", "HJ"), string.Format("PID={0}",rows[0]["ID"]));
                rows[0]["CJHJ"] = this.m_Table.Compute(String.Format("Sum({0})", "CJHJ"), string.Format("PID={0}", rows[0]["ID"]));
                SetParentHJ(rows[0]);
            }
        }

        /// <summary>
        /// 创建列
        /// </summary>
        private void Build()
        {
            if (m_Table == null)
            {
                m_Table = new DataTable();
                m_Table.Columns.Add("ID", typeof(int));
                m_Table.Columns.Add("PID", typeof(int));
                m_Table.Columns.Add("XH");
                m_Table.Columns.Add("XMMC");
                m_Table.Columns.Add("DW");
                m_Table.Columns.Add("GCL");
                m_Table.Columns.Add("JSJC");
                m_Table.Columns.Add("FL");
                m_Table.Columns.Add("ZHDJ");
                m_Table.Columns.Add("HJ",typeof(decimal));
                m_Table.Columns.Add("BZ");
                m_Table.Columns.Add("JSDJ", typeof(decimal));
                m_Table.Columns.Add("CJDJ", typeof(decimal));
                m_Table.Columns.Add("CJHJ", typeof(decimal));
            }
            else
            {
                this.m_Table.Rows.Clear();
            }
            
        }
        /// <summary>
        /// 循环添加数据
        /// </summary>
        /// <param name="o"></param>
        /// <param name="Pid"></param>
        private void BuildRow(_COBJECTS o, int Pid, _Engineering P_ID)
        {
            DataRow row = this.m_Table.NewRow();
            switch (o.ObjectType)
            {
                case EObjectType.Default:

                    break;
                case EObjectType.PROJECT:
                    row["ID"] = ++m;
                    row["PID"] = Pid;
                    row["XH"] = "整个项目";
                    row["XMMC"] =o.Property.Basis.Name;
                    this.m_Table.Rows.Add(row);
                    DataRow[] EnRows = this.CurrentBusiness.Current.StructSource.ModelProject.Select("PID = 1");
                    foreach (DataRow r in EnRows)
                    {
                        _Engineering einfo = this.CurrentBusiness.Current.Create() as _Engineering;
                        _ObjectSource.GetObject(einfo, r);
                        BuildRow(einfo, ToolKit.ParseInt(row["ID"]), einfo);
                    }
                    break;
                case EObjectType.Engineering:
                    row["ID"] = ++m;
                    row["PID"] = Pid;
                    row["XH"] = "单项工程";
                    row["XMMC"] = o.Property.Basis.Name;
                    this.m_Table.Rows.Add(row);
                    _UnitProject pinfo = null;
                    DataRow[] UnRows = this.CurrentBusiness.Current.StructSource.ModelProject.Select(string.Format("PID = {0}", P_ID.ID));
                    foreach (DataRow r in UnRows)
                    {
                        pinfo = r["UnitProject"] as _UnitProject;
                        if (pinfo == null)
                        {
                            //反序列化
                            pinfo = (this.CurrentBusiness as _Pr_Business).GetObject(r["OBJECT"]) as _UnitProject;
                            //回写到表中
                            pinfo.InSerializable(P_ID);
                             _ObjectSource.GetObject(pinfo, r);
                            this.CurrentBusiness.Current.StructSource.ModelProject.AppendUnit(pinfo);
                            //pinfo.Property = new _Un_Property(pinfo);
                            //pinfo.Reveal = new
                           
                        }
                        BuildRow(pinfo, ToolKit.ParseInt(row["ID"]), null);
                    }
                    break;
                case EObjectType.UnitProject:
                    row["ID"] = ++m;
                    row["PID"] = Pid;
                    row["XH"] = "单位工程";
                    row["XMMC"] = o.Property.Basis.Name;
                    this.m_Table.Rows.Add(row);
                    SetCUnitProjectOther(o, ToolKit.ParseInt(row["ID"]));
                    break;
                default:
                    break;
            }

        }
        private void SetCUnitProjectOther(_COBJECTS o, int pid)
        {
            _UnitProject u = o as _UnitProject;
            if (u == null) return;
            if (u.Property.OtherProject.Source.Columns.Count < 1) return;
            DataRow[] rows=u.Property.OtherProject.Source.Select("ParentID=0");
            foreach (DataRow item in rows)
            {
                SetRow(item, pid); 
            }
        }
        private void SetRow(DataRow row ,int pid)
        {
            DataRow r = this.m_Table.NewRow();
            r["ID"] = ++m;
            r["PID"] = pid;
            r["XH"] = row["Number"];
            r["XMMC"] = row["Name"];
            r["DW"] = row["Unit"];
            r["GCL"] = row["Quantities"];
            r["JSJC"] = row["Calculation"];
            r["FL"] = row["Coefficient"];
            r["ZHDJ"] = row["Unitprice"];
            r["HJ"] = row["Combinedprice"];
            r["BZ"] = row["Remark"];

            r["JSDJ"] = row["jsdj"];
            r["CJDJ"] = row["cjdj"];
            r["CJHJ"] = row["cjhj"];
            this.m_Table.Rows.Add(r);
            DataRow[] rows = row.Table.Select(string.Format("ParentID={0}",row["ID"]));
            foreach (DataRow item in rows)
            {
                SetRow(item, ToolKit.ParseInt(r["ID"]));
            }
        }

        private void treeListEx1_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node != null)
            {
                //获取编号深度
                DataRowView row = e.Node.TreeList.GetDataRecordByNode(e.Node) as DataRowView;
                if (row == null) return;
                int id;
                
                
                id = ToolKit.ParseInt(row["UnID"]);
                int level = 0;
                if (e.Node.Level == 2) //单位工程取值
                {
                    level = -1;
                    if (e.Column.FieldName == "Combinedprice")
                    {
                        e.CellText = this.GetData(id, "QTXMHJ", level).ToString();
                    }
                    if (e.Column.FieldName == "Number")
                    {
                        e.CellText = GetFiledValue(id.ToString(), "Name").ToString();
                    }
                }
                if (e.Node.Level == 0)
                {//项目
                    id = 0;
                    level = -3;
                    if (e.Column.FieldName == "Combinedprice")
                    {
                        e.CellText = this.GetData(id, "QTXMHJ", level).ToString();
                    }
                }
                if (e.Node.Level == 1)
                {//单项
                    level = -2;
                    if (e.Column.FieldName == "Combinedprice")
                    {
                        e.CellText = this.GetData(id, "QTXMHJ", level).ToString();
                    }
                }
                if(e.Column.ColumnType.Equals(typeof(decimal)))
                {
                    decimal m_value = ToolKit.ParseDecimal(e.CellValue); 
                    if(m_value.Equals(0m))
                    {
                        e.CellText = string.Empty;
                    }
                }
            }
        }

        private string GetFiledValue(string p_ID, string p_FiledName)
        {
            DataRow r = this.CurrentBusiness.Current.StructSource.ModelProject.GetRowByOther(p_ID.ToString());
            if (r != null)
            {
                return r[p_FiledName].ToString();
            }
            return string.Empty;
        }

        private void RaiseColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.treeListEx1);
        }

        private void treeListEx1_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList gv = sender as TreeList;
            TreeListHitInfo hi = gv.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                gv.FocusedNode = hi.Node;
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        
    }
}
