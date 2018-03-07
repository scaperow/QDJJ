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

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class MetaanalysisList2 : BaseControl
    {
        /// <summary>
        /// 当前项目和单项工程的汇总分析的数据源
        /// </summary>
        private DataTable m_DataSource = null;

        /// <summary>
        /// 获取或设置汇总分析的数据源
        /// </summary>
        public DataTable DataSource
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

        public MetaanalysisList2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定当前数据源对象
        /// </summary>
        public void Bind()
        {
            this.bindingSource1.DataSource = this.m_DataSource;
            this.gridControl1.DataSource = this.bindingSource1;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
            DevExpress.XtraGrid.GridControl send = sender as  DevExpress.XtraGrid.GridControl;
            DevExpress.Utils.DXMouseEventArgs ee = e as DevExpress.Utils.DXMouseEventArgs;
            //e.
            //(send.DataSource as DataTable)
        }

        public DataTable dt_Source = null;

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            //dt_Source = new  DataSource();
            //dt_Source.Rows.Add((((sender as System.Windows.Forms.BindingSource).Current as System.Data.DataRowView).Row as System.Data.DataRow));
        }

        


       
        //private void treeList1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        //{
        //    if (e.Column.FieldName == "Price")
        //    {
        //        e.Value = ToolKit.ParseDecimal(e.Value).ToString("f2");
        //    }
        //}

        //private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        //{
        //    //单元格改变之后的重新
           
        //}

        //private string GetName()
        //{
        //    string name = "F";
        //    object count = this.m_DataSource.Source.Compute("Count(ID)", " ParentID = 0 ");
        //    return name + ((int)count + 1);
        //}

        //private string GetChdName()
        //{
        //    DataRowView drv = this.bindingSource1.Current as DataRowView;
        //    string name = string.Empty;
        //    if (drv != null)
        //    {
        //        int id = ToolKit.ParseInt(drv["ID"]);
        //        name = drv["Number"].ToString();
        //        object count = this.m_DataSource.Source.Compute("Count(ID)", string.Format(" ParentID = {0} ",id));
        //        return string.Format("{0}.{1}", name, (int)count + 1);
        //    }
        //    return string.Empty;
        //}

        /// <summary>
        /// 添加新的项目
        /// </summary>
        //public void Add()
        //{
            
        //    DataView dv =this.bindingSource1.List as DataView;
        //    DataRowView row = dv.AddNew();
        //    row.BeginEdit();
        //    row["Number"] = GetName();
        //    row["ParentID"] = 0;
        //    row.EndEdit();
        //}

        /// <summary>
        /// 为当前项目添加子项目
        /// </summary>
        //public void AddChd()
        //{
        //    DataRowView drv = this.bindingSource1.Current as DataRowView;
        //    if (drv != null)
        //    {
        //        DataView dv = this.bindingSource1.List as DataView;
        //        DataRowView row = dv.AddNew();
        //        row.BeginEdit();
        //        row["Number"] = GetChdName();
        //        row["ParentID"] = drv["ID"];
        //        row.EndEdit();
        //    }
        //}

        /// <summary>
        /// 删除当前选择项目
        /// </summary>
        //public void Delete()
        //{
        //    //删除当前选择项下的所有项目

        //    DataRowView drv = this.bindingSource1.Current as DataRowView;
        //    if (drv != null)
        //    {
        //        string id = drv["ID"].ToString();
        //        this.doDelete(drv.Row);
        //        this.m_DataSource.Source.AcceptChanges();
        //    }
        //}

        /// <summary>
        /// 递归删除指定的编号
        /// </summary>
        /// <param name="p_id"></param>
        //private void doDelete(DataRow row)
        //{
        //    //查找是否拥有子项
        //    DataRow[] rows = this.m_DataSource.Source.Select(string.Format(" ParentID ={0}", row["ID"]));
        //    if (rows.Length == 0)
        //    {
        //        row.Delete();
        //    }
        //    else
        //    {
        //        foreach (DataRow r in rows)
        //        {
        //            this.doDelete(r);
        //        }
        //        row.Delete();
        //    }
        //}

        
    }
}
