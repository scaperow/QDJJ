using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using DevExpress.XtraTreeList;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class MetaanalysisList : BaseControl
    {

        /// <summary>
        /// 获取或设置配色方案
        /// </summary>
        //private _SchemeColor m_SchemeColor = null;

        /// <summary>
        /// 获取或设置配色方案
        /// </summary>
        public _SchemeColor SchemeColor
        {
            get
            {
                return this.treeList1.SchemeColor;
            }
            set
            {
                this.treeList1.SchemeColor = value;
            }
        }



        /// <summary>
        /// 当前汇总分析的数据源
        /// </summary>
        private _MetaanalysisSource m_DataSource = null;

        /// <summary>
        /// 获取或设置汇总分析的数据源
        /// </summary>
        public _MetaanalysisSource DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;
            }
        }

        public MetaanalysisList()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 绑定当前数据源对象
        /// </summary>
        public void Bind()
        {
            this.bindingSource1.DataSource = this.m_DataSource.DefaultView;
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.ExpandAll();
        }

        private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {

        }

        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            //单元格改变之后的重新

        }

        private string GetName()
        {
            string name = "F";
            object count = this.m_DataSource.Compute("Count(ID)", " ParentID = 0 ");
            return name + ((int)count + 1);
        }

        private string GetChdName()
        {
            DataRowView drv = this.bindingSource1.Current as DataRowView;
            string name = string.Empty;
            if (drv != null)
            {
                int id = ToolKit.ParseInt(drv["ID"]);
                name = drv["Number"].ToString();
                object count = this.m_DataSource.Compute("Count(ID)", string.Format(" ParentID = {0} ", id));
                return string.Format("{0}.{1}", name, (int)count + 1);
            }
            return string.Empty;
        }

        /// <summary>
        /// 添加新的项目
        /// </summary>
        public void Add()
        {

            DataView dv = this.bindingSource1.List as DataView;
            DataRowView row = dv.AddNew();
            row.BeginEdit();
            row["Number"] = GetName();
            row["ParentID"] = 0;
            row["UnID"] = this.Activitie.ID;
            row["Coefficient"] = 100;
            row.EndEdit();
        }

        /// <summary>
        /// 为当前项目添加子项目
        /// </summary>
        public void AddChd()
        {
            DataRowView drv = this.bindingSource1.Current as DataRowView;
            if (drv != null)
            {
                DataView dv = this.bindingSource1.List as DataView;
                DataRowView row = dv.AddNew();
                row.BeginEdit();
                row["Number"] = GetChdName();
                row["ParentID"] = drv["ID"];
                row["UnID"] = this.Activitie.ID;
                row["Coefficient"] = 100;
                row.EndEdit();
            }
        }

        /// <summary>
        /// 删除当前选择项目
        /// </summary>
        public void Delete()
        {
            //删除当前选择项下的所有项目

            DataRowView drv = this.bindingSource1.Current as DataRowView;
            if (drv != null)
            {
                string id = drv["ID"].ToString();
                this.doDelete(drv.Row);
                //this.m_DataSource.Source.AcceptChanges();
            }
        }

        /// <summary>
        /// 新添加的选择项目
        /// </summary>
        /// <param name="view"></param>
        public void Edit(DataRowView view)
        {
            DataRowView rv = this.bindingSource1.Current as DataRowView;
            if (rv != null)
            {
                rv.BeginEdit();
                rv["Feature"] = view["Code"];
                rv["Name"] = view["Name"];
                rv.EndEdit();
            }
        }

        /// <summary>
        /// 递归删除指定的编号
        /// </summary>
        /// <param name="p_id"></param>
        private void doDelete(DataRow row)
        {
            //查找是否拥有子项
            DataRow[] rows = this.m_DataSource.Select(string.Format(" ParentID ={0}", row["ID"]));
            if (rows.Length == 0)
            {
                row.Delete();
            }
            else
            {
                foreach (DataRow r in rows)
                {
                    this.doDelete(r);
                }
                row.Delete();
            }
        }

        /// <summary>
        ///设置是否允许编辑
        /// </summary>
        public void AllowEdit(bool bl)
        {
            if (!bl)
            {
                this.treeList1.Columns[1].OptionsColumn.AllowEdit = false;
                this.treeList1.Columns[2].OptionsColumn.AllowEdit = false;
                this.treeList1.Columns[3].OptionsColumn.AllowEdit = false;
                this.treeList1.Columns[4].OptionsColumn.AllowEdit = false;
                this.treeList1.Columns[5].OptionsColumn.AllowEdit = false;
                this.treeList1.Columns[6].OptionsColumn.AllowEdit = false;
            }
        }

        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            /*DevExpress.Utils.AppearanceDefault def = new DevExpress.Utils.AppearanceDefault();
            def.ForeColor = Color.Red;
            e.Appearance.Assign(def);*/
        }

        private void MetaanalysisList_Load(object sender, EventArgs e)
        {
            this.treeList1.ModelName = "汇总分析";

        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            {
                TreeListHitInfo hi = this.treeList1.CalcHitInfo(new Point(e.X, e.Y));
                if (hi.Node == null) return;
                if (hi.Node != null) this.treeList1.FocusedNode = hi.Node;
                DataRowView info = this.treeList1.GetDataRecordByNode(this.treeList1.FocusedNode) as DataRowView;
                if (info != null)
                {
                    this.BTN_IN.Enabled = true;
                    if (this.CurrentBusiness.Current.IsDZBS && !APP.Jzbx_pwd)
                    {
                        this.BTN_ADD_ROOT.Enabled = false;
                        this.BTN_ADD.Enabled = false;
                        this.BTN_DELETE.Enabled = false;
                    }
                    else
                    {
                        this.BTN_ADD_ROOT.Enabled = true;
                        this.BTN_ADD.Enabled = true;
                        this.BTN_DELETE.Enabled = true;
                    }
                }
                this.Pop_Met.ShowPopup(this.treeList1.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void BTN_ADD_ROOT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Add();
        }

        private void BTN_IN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTN_OUT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTN_ADD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AddChd();
        }

        private void BTN_DELETE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Delete();
        }

        private void treeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            //金额转换
            /*if (e.Column.FieldName == "Price")
            {
                
                e.CellText = ToolKit.ParseDecimal(e.CellValue).ToString("f2");
            }*/
            //如果费率大于等于100 全部是空
            if (e.Column.FieldName == "Coefficient")
            {
                decimal coe = ToolKit.ParseDecimal(e.CellValue);
                if (coe >= 100 || coe < 0)
                {
                    e.CellText = string.Empty;
                }
                else
                {

                    e.CellText = string.Format("{0}", e.CellValue);
                }
            }
        }

    }
}
