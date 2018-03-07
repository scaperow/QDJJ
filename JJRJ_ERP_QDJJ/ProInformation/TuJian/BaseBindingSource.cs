using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BaseBindingSource : BaseUI
    {
        public BaseBindingSource()
        {
            InitializeComponent();
        }
        public BaseBindingSource(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 窗体加载时候激发
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.InitDataSouse();
            base.OnLoad(e);
        }
        #endregion

        #region 初始化数据源
        /// <summary>
        /// 初始化数据源
        /// </summary>
        private void InitDataSouse()
        {
            if (APP.Application == null) return;
            if (APP.Application.Global.DataTamp.工程信息表 == null) return;
            if (null == QDbindingSource.DataSource)
            {
                QDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["确定清单"];
            }
            if (null == MBZMbindingSource.DataSource)
            {
                MBZMbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["确定模板子目"];
            }
            if (null == JGGJMCbindingSource.DataSource)
            {
                JGGJMCbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["结构构件名称"];
            }
            if (null == JMXZbindingSource.DataSource)
            {
                JMXZbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["截面形状"];
            }
            if (null == HNTYQbindingSource.DataSource)
            {
                HNTYQbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["混凝土要求及确定子目"];
            }
            if (null == HNTQDbindingSource.DataSource)
            {
                HNTQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["混凝土强度等级"];
            }
            if (null == JMCCbindingSource.DataSource)
            {
                JMCCbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["截面尺寸"];
            }
            if (null == CGSDbindingSource.DataSource)
            {
                CGSDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["超高设定"];
            }
            if (null == JGFLbindingSource.DataSource)
            {
                JGFLbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["结构分类及确定超高子目"];
            }
            if (null == LXSZbindingSource.DataSource)
            {
                LXSZbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["类型设置"];
            }
            if (null == TFQRQDbindingSource.DataSource)
            {
                TFQRQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["土方确定清单"];
            }
            if (null == GCYQCSbindingSource.DataSource)
            {
                GCYQCSbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["工程要求参数"];
            }
        }
        #endregion

        #region 筛选 返回 清单
        /// <summary>
        /// 结构  筛选 返回 清单
        /// </summary>
        /// <param name="_strQDWhere">筛选条件</param>
        /// <param name="strTJ">条件</param>
        /// <param name="SWGCL">实物工程量</param>
        /// <returns></returns>
        protected DataRow GetQD(string _strQDWhere, string strTJ, float SWGCL)
        {
            QDbindingSource.Filter = _strQDWhere;
            DataRow r = APP.UnInformation.QDTable.NewRow();
            if (0 < QDbindingSource.Count)
            {
                DataRowView view = QDbindingSource[0] as DataRowView;
                r["QDBH"] = view["QDBH"];
                r["QDMC"] = view["QDMC"];
                r["DW"] = view["DW"];
                r["XS"] = 1;
                r["GCL"] = 1 * SWGCL;
                r["TJ"] = strTJ;
                r["WZLX"] = WZLX.分部分项;
                if (CDataConvert.ConToValue<string>(view["QDBH"]).Length > 5)
                {
                    r["ZJ"] = CDataConvert.ConToValue<string>(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                }

            }
            return r;
        }

        /// <summary>
        /// 土方  筛选 返回 清单
        /// </summary>
        /// <param name="_strQDWhere">筛选条件</param>
        /// <param name="strTJ">条件</param>
        /// <param name="SWGCL">实物工程量</param>
        /// <returns></returns>
        protected DataRow GetTFQD(string _strQDWhere, string strTJ, float SWGCL)
        {
            TFQRQDbindingSource.Filter = _strQDWhere;
            if (!APP.UnInformation.QDTable.Columns.Contains("BZ"))
                APP.UnInformation.QDTable.Columns.Add("BZ");
            DataRow dr = APP.UnInformation.QDTable.NewRow();
            if (0 < this.TFQRQDbindingSource.Count)
            {
                DataRowView view = this.TFQRQDbindingSource[0] as DataRowView;
                dr["QDBH"] = view["QDBH"];
                dr["QDMC"] = view["QDMC"];
                dr["DW"] = view["DW"];
                dr["XS"] = view["GCLXS"];
                dr["GCL"] = CDataConvert.ConToValue<float>(dr["XS"]) * SWGCL;
                dr["WZLX"] = view["WZ"];
                dr["TJ"] = strTJ;
                dr["BZ"] = "";
                if (CDataConvert.ConToValue<string>(view["QDBH"]).Length > 5)
                {
                    dr["ZJ"] = CDataConvert.ConToValue<string>(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                }
            }
            return dr;
        }
        #endregion

        #region 【土方】获取相应的工程要求参数
        /// <summary>
        /// 【土方】获取相应的工程要求参数
        /// </summary>
        /// <param name="oYQCS">用户录入的值</param>
        /// <returns>库中的工程要求参数</returns>
        protected string getGCYCCS(object oYQCS, BHTYPE eBHTYPE)
        {
            DataTable dt = (this.GCYQCSbindingSource.DataSource as DataTable).DefaultView.ToTable();
            return this.GetFWBySZ(oYQCS, eBHTYPE, dt, "YQ");
            //if (toString(oYQCS).Split('～').Length != 2)
            //{
            //    decimal dYQCS = ToolKit.ParseDecimal(oYQCS);
            //    foreach (DataRowView item in this.GCYQCSbindingSource.List)
            //    {
            //        string[] arrStr = toString(item["YQ"]).Split('～');
            //        if (arrStr.Length != 2) { continue; }

            //        switch (eBHTYPE)
            //        {
            //            case BHTYPE.全部包含:
            //                if (dYQCS >= ToolKit.ParseDecimal(arrStr[0]) && dYQCS <= ToolKit.ParseDecimal(arrStr[1]))
            //                {
            //                    return toString(item["YQ"]);
            //                }
            //                break;
            //            case BHTYPE.只包含前项:
            //                if (dYQCS >= ToolKit.ParseDecimal(arrStr[0]) && dYQCS < ToolKit.ParseDecimal(arrStr[1]))
            //                {
            //                    return toString(item["YQ"]);
            //                }
            //                break;
            //        }
            //    }
            //}
            //return toString(oYQCS);
        }
        #endregion

        #region 混凝土拌合料要求 选择改变   重新绑定 混凝土强度等级的数据源
        /// <summary>
        /// 混凝土拌合料要求 选择改变   重新绑定 混凝土强度等级的数据源
        /// </summary>
        /// <param name="strText"></param>
        protected void LookUpEditSelectChage(string strText)
        {
            this.HNTQDbindingSource.Filter = "BHLYQ='" + strText + "'";
            this.bindingSource1.ResetBindings(false);
        }
        #endregion

    }
}