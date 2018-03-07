using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class PeggingForm : BaseForm
    {
        public PeggingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 分部分项数据
        /// </summary>
        private DataTable m_fbfx = null;
        /// <summary>
        /// 措施项目数据
        /// </summary>
        private DataTable m_csxm = null;

        /// <summary>
        /// 当前选中项
        /// </summary>
        private DataRow m_Current = null;

        /// <summary>
        /// 获取或设置:当前选中项
        /// </summary>
        public DataRow Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

        private int m_GetID = -1;

        public int GetID
        {
            get { return m_GetID; }
        }

        private void PeggingForm_Load(object sender, EventArgs e)
        {
            if (m_Current != null)
            {
                GetDataTable();
                this.bindingSourceFBFX.DataSource = this.Fill("0", this.m_fbfx);
                this.bindingSourceCSXM.DataSource = this.Fill("1", this.m_csxm);
                this.treeListFBFX.ExpandAll();
                this.treeListCSXM.ExpandAll();
            }
        }

        private void GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("PID", typeof(int));
            dt.Columns.Add("XMBM", typeof(string));
            dt.Columns.Add("XMMC", typeof(string));
            dt.Columns.Add("DW", typeof(string));
            dt.Columns.Add("GCL", typeof(decimal));
            dt.Columns.Add("XHL", typeof(decimal));
            m_csxm = dt.Clone();
            m_fbfx = dt.Clone();
        }

        /// <summary>
        /// 填充措施项目数据
        /// </summary>
        private DataTable Fill(string p_SSLB, DataTable p_dt)
        {
            string m_QDID = string.Empty;
            string m_ZMID = string.Empty;
            DataRow[] drs_glj = this.Activitie.StructSource.ModelQuantity.Select(string.Format("BH='{0}' AND SSLB = {1}", this.m_Current["BH"], p_SSLB));
            foreach (DataRow item in drs_glj)
            {
                if (!m_QDID.Contains(item["QDID"].ToString() + ","))
                {
                    m_QDID += item["QDID"].ToString() + ",";
                }
                if (!m_ZMID.Contains(item["ZMID"].ToString() + ","))
                {
                    m_ZMID += item["ZMID"].ToString() + ",";
                }
            }
            if (m_QDID != string.Empty && m_ZMID != string.Empty)
            {
                m_QDID = m_QDID.Substring(0, m_QDID.Length - 1);
                m_ZMID = m_ZMID.Substring(0, m_ZMID.Length - 1);
                DataRow[] drs = null;
                if (p_SSLB.Equals("0"))
                {
                    drs = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("ID in({0}) OR ID in ({1})", m_QDID, m_ZMID));
                }
                else
                {
                    drs = this.Activitie.StructSource.ModelMeasures.Select(string.Format("ID in({0}) OR ID in ({1})", m_QDID, m_ZMID));
                }
                foreach (DataRow items in drs)
                {
                    DataRow dr = p_dt.NewRow();
                    dr["ID"] = items["ID"];
                    dr["PID"] = items["PID"];
                    dr["XMBM"] = items["XMBM"];
                    dr["XMMC"] = items["XMMC"];
                    dr["DW"] = items["DW"];
                    dr["GCL"] = items["GCL"];
                    if (items["LB"].Equals("清单"))
                    {
                        dr["XHL"] = drs_glj.Where(p => p["QDID"].Equals(items["ID"])).Sum(p => ToolKit.ParseDecimal(p["XHL"]));
                    }
                    else
                    {
                        dr["XHL"] = drs_glj.Where(p => p["ZMID"].Equals(items["ID"])).Sum(p => ToolKit.ParseDecimal(p["XHL"]));
                    }
                    p_dt.Rows.Add(dr);
                }
            }
            return p_dt;
        }

        /// <summary>
        /// 双击跳转事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_DoubleClick(object sender, EventArgs e)
        {
            TreeList m_TreeList = sender as TreeList;
            if (m_TreeList != null)
            {
                if (m_TreeList.Name == "treeListFBFX")
                {
                    //只有双击子目对象有效其它不处理
                    DataRowView drv = this.bindingSourceFBFX.Current as DataRowView;
                    if (drv != null)
                    {
                        //选中双击子目对应在分部分项上的子目
                        this.m_GetID = ToolKit.ParseInt(drv["ID"]);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    DataRowView drv = this.bindingSourceCSXM.Current as DataRowView;
                    if (drv != null)
                    {
                        this.m_GetID = ToolKit.ParseInt(drv["ID"]);
                        this.DialogResult = DialogResult.Yes;
                    }
                }
            }
        }

        private void treeListFBFX_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "GCL":
                    case "XHL":
                        decimal d = ToolKit.ParseDecimal(e.CellValue);
                        if (d.Equals(0m))
                        {
                            e.CellText = string.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}