using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.UI;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraCharts;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class InventoryGraphAnalysis : BaseForm
    {
        /// <summary>
        /// 当前正在操作的子目
        /// </summary>
        private _Methods_Subheadings m_Methods_Subheadings = null;

        public InventoryGraphAnalysis()
        {
            InitializeComponent();
        }

        public InventoryGraphAnalysis(_Business p_Business, _UnitProject p_Activitie, ABaseForm p_AParentForm)
        {
            this.CurrentBusiness = p_Business;
            this.Activitie = p_Activitie;
            this.AParentForm = p_AParentForm;
            m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
            InitializeComponent();
        }

        private void InventoryGraphAnalysis_Load(object sender, EventArgs e)
        {
            XYDiagram se = this.graphAnalysis1.chartControl1.Diagram as XYDiagram;
            if (se != null)
            {
                se.AxisX.Label.Staggered = true;
            }
        }

        /// <summary>
        /// 根据清单子目选择
        /// </summary>
        /// <param name="q_id">子目编号</param>
        public void DoFilter(_Entity_SubInfo p_info)
        {
            m_Methods_Subheadings.Current = p_info;
            this.graphAnalysis1.DataSource = null;
            this.graphAnalysis1.ShowName = "MC";
            this.graphAnalysis1.ValueName = "DJ";
            DataTable dt = new DataTable();
            dt.Columns.Add("MC", typeof(string));
            dt.Columns.Add("DJ", typeof(decimal));
            DataRow drzhdj = dt.NewRow();
            drzhdj["MC"] = "综合单价";
            drzhdj["DJ"] = m_Methods_Subheadings.Current.ZHDJ;
            dt.Rows.Add(drzhdj);
            DataRow drrg = dt.NewRow();
            drrg["MC"] = "人工费";
            drrg["DJ"] = m_Methods_Subheadings.Current.RGFDJ;
            dt.Rows.Add(drrg);
            DataRow drcl = dt.NewRow();
            drcl["MC"] = "材料费";
            drcl["DJ"] = m_Methods_Subheadings.Current.CLFDJ;
            dt.Rows.Add(drcl);
            DataRow drzc = dt.NewRow();
            drzc["MC"] = "主材费";
            drzc["DJ"] = m_Methods_Subheadings.Current.ZCFDJ;
            dt.Rows.Add(drzc);
            DataRow drjx = dt.NewRow();
            drjx["MC"] = "机械费";
            drjx["DJ"] = m_Methods_Subheadings.Current.JXFDJ;
            dt.Rows.Add(drjx);
            DataRow drsb = dt.NewRow();
            //drsb["MC"] = "设备费单价";
            //drsb["DJ"] = m_Methods_Subheadings.Current.SBFDJ;
            //dt.Rows.Add(drsb);
            DataRow drgl = dt.NewRow();
            drgl["MC"] = "管理费";
            drgl["DJ"] = m_Methods_Subheadings.Current.GLFDJ;
            dt.Rows.Add(drgl);
            DataRow drlr = dt.NewRow();
            drlr["MC"] = "利润";
            drlr["DJ"] = m_Methods_Subheadings.Current.LRDJ;
            dt.Rows.Add(drlr);
            //DataRow drfx = dt.NewRow();
            //drfx["MC"] = "风险";
            //drfx["DJ"] = m_Methods_Subheadings.Current.FXDJ;
            //dt.Rows.Add(drfx);
            DataRow drzj = dt.NewRow();
            drzj["MC"] = "人工调增";
            drzj["DJ"] = m_Methods_Subheadings.Current.RGFJC;
            dt.Rows.Add(drzj);
            //DataRow drgf = dt.NewRow();
            //drgf["MC"] = "规费单价";
            //drgf["DJ"] = m_Methods_Subheadings.Current.GFDJ;
            //dt.Rows.Add(drgf);
            //DataRow drsj = dt.NewRow();
            //drsj["MC"] = "税金单价";
            //drsj["DJ"] = m_Methods_Subheadings.Current.SJDJ;
            //dt.Rows.Add(drsj);
            this.graphAnalysis1.DataSource = dt;

        }

        /// <summary>
        /// 根据清单子目选择
        /// </summary>
        /// <param name="q_id">子目编号</param>
        public void DoFilter(_Entity_SubInfo p_info, bool ifhj)
        {
            m_Methods_Subheadings.Current = p_info;
            this.graphAnalysis1.DataSource = null;
            this.graphAnalysis1.ShowName = "MC";
            this.graphAnalysis1.ValueName = "HJ";
            DataTable dt = new DataTable();
            dt.Columns.Add("MC", typeof(string));
            dt.Columns.Add("HJ", typeof(decimal));
            DataRow drzhdj = dt.NewRow();
            drzhdj["MC"] = "综合合价";
            drzhdj["HJ"] = m_Methods_Subheadings.Current.ZHHJ;
            dt.Rows.Add(drzhdj);
            DataRow drrg = dt.NewRow();
            drrg["MC"] = "人工费";
            drrg["HJ"] = m_Methods_Subheadings.Current.RGFHJ;
            dt.Rows.Add(drrg);
            DataRow drcl = dt.NewRow();
            drcl["MC"] = "材料费";
            drcl["HJ"] = m_Methods_Subheadings.Current.CLFHJ;
            dt.Rows.Add(drcl);
            DataRow drzc = dt.NewRow();
            drzc["MC"] = "主材费";
            drzc["HJ"] = m_Methods_Subheadings.Current.ZCFHJ;
            dt.Rows.Add(drzc);
            DataRow drjx = dt.NewRow();
            drjx["MC"] = "机械费";
            drjx["HJ"] = m_Methods_Subheadings.Current.JXFHJ;
            dt.Rows.Add(drjx);
            DataRow drsb = dt.NewRow();
            drsb["MC"] = "设备费";
            drsb["HJ"] = m_Methods_Subheadings.Current.SBFHJ;
            dt.Rows.Add(drsb);
            DataRow drgl = dt.NewRow();
            drgl["MC"] = "管理费";
            drgl["HJ"] = m_Methods_Subheadings.Current.GLFHJ;
            dt.Rows.Add(drgl);
            DataRow drlr = dt.NewRow();
            drlr["MC"] = "利润";
            drlr["HJ"] = m_Methods_Subheadings.Current.LRHJ;
            dt.Rows.Add(drlr);
            //DataRow drfx = dt.NewRow();
            //drfx["MC"] = "风险";
            //drfx["HJ"] = m_Methods_Subheadings.Current.FXHJ;
            //dt.Rows.Add(drfx);
            DataRow drzj = dt.NewRow();
            drzj["MC"] = "人工调增";
            drzj["HJ"] = m_Methods_Subheadings.Current.RGFJC;
            dt.Rows.Add(drzj);
            //DataRow drgf = dt.NewRow();
            //drgf["MC"] = "规费合价";
            //drgf["HJ"] = m_Methods_Subheadings.Current.GFHJ;
            //dt.Rows.Add(drgf);
            //DataRow drsj = dt.NewRow();
            //drsj["MC"] = "税金合价";
            //drsj["HJ"] = m_Methods_Subheadings.Current.SJHJ;
            //dt.Rows.Add(drsj);
            this.graphAnalysis1.DataSource = dt;
        }
    }
}