using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BaseMC : BaseUI
    {
        public BaseMC()
        {
            InitializeComponent();
        }
        public BaseMC(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.InitDataSouse();
            base.OnLoad(e);
        }

        /// <summary>
        /// 初始化数据源
        /// </summary>
        private void InitDataSouse()
        {
            if (APP.Application == null) return;
            if (null == MCFLbindingSource.DataSource)
            {
                this.MCFLbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗分类"];
            }
            if (null == MCQDQDbindingSource.DataSource)
            {
                this.MCQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗确定清单"];
            }
            if (null == MCQDDEbindingSource.DataSource)
            {
                this.MCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗确定定额"];
            }
        }

        /// <summary>
        /// 门窗  筛选 返回 清单
        /// </summary>
        /// <param name="_strQDWhere">筛选条件</param>
        /// <param name="strTJ">条件</param>
        /// <param name="SWGCL">实物工程量</param>
        /// <returns></returns>
        protected DataRow GetMCQD(string _strQDWhere, string strTJ, decimal SWGCL)
        {
            this.MCQDQDbindingSource.Filter = _strQDWhere;
            DataRow dr = APP.UnInformation.QDTable.NewRow();
            if (0 < this.MCQDQDbindingSource.Count)
            {
                DataRowView view = this.MCQDQDbindingSource[0] as DataRowView;
                dr["QDBH"] = view["QDBH"];
                dr["QDMC"] = view["QDMC"];
                dr["DW"] = view["QDDW"];
                dr["XS"] = view["GCLXS"];
                dr["GCL"] = ToolKit.ParseDecimal(dr["XS"]) * SWGCL;
                dr["WZLX"] = WZLX.分部分项;
                dr["TJ"] = strTJ;
                if (toString(view["QDBH"]).Length > 5)
                {
                    dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                }
            }
            return dr;
        }

        /// <summary>
        /// 门窗  筛选 返回 定额
        /// </summary>
        /// <param name="rows">rows 定额</param>
        /// <param name="row">row 清单</param>
        /// <param name="_strDEWhere">筛选条件</param>
        /// <param name="strTJ">条件</param>
        /// <param name="DK">洞宽</param>
        /// <param name="DG">洞高</param>
        /// <returns></returns>
        protected void GetMCDE(List<DataRow> rows, DataRow dr, string _strDEWhere, string strTJ, int DK, int DG)
        {
            this.MCQDDEbindingSource.Filter = _strDEWhere;
            StringBuilder sb = new StringBuilder();

            foreach (DataRowView item in this.MCQDDEbindingSource)
            {
                DataRow row = APP.UnInformation.DETable.NewRow();
                row["DEBH"] = item["DEBH"];
                row["DEMC"] = item["DEMC"];
                row["DW"] = item["DEDW"];
                decimal gclxs = subDivide(item["GCLXS"]);
                if (gclxs != -1)
                {
                    row["XS"] = DK * DG / gclxs;
                }
                else
                {
                    row["XS"] = item["GCLXS"];
                }
                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                row["QDBH"] = dr["QDBH"];
                row["TJ"] = strTJ;
                row["WZLX"] = WZLX.分部分项;
                rows.Add(row);
                sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
            }

            //dr["BZ"] = sb.ToString() + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
            if (string.IsNullOrEmpty(dr["TJ"].ToString()))
            {
                dr["BZ"] = sb.ToString() + strTJ;
                dr["TJ"] = strTJ;
            }
            else
            {
                dr["BZ"] = sb.ToString() + dr["TJ"].ToString();
            }

        }

        //获取截断字符串算法参数
        public decimal subDivide(object obj)
        {
            if(!string.IsNullOrEmpty(toString(obj)))
            {
                    string[] strDivide = obj.ToString().Split('/');

                    if (strDivide.Length > 1)
                    {
                        return ToolKit.ParseDecimal(strDivide[strDivide.Length - 1]);
                    }
                    //string divide=obj.ToString();
                    //int startIndex = divide.LastIndexOf("/")+1;
                    //int endLength = divide.Length-startIndex;
                    //divide = divide.Substring(startIndex, endLength);
                    //return ToolKit.ParseDecimal(divide);
                
            }
            return -1;
        }


        private void BaseMC_Load(object sender, EventArgs e)
        {

        }
    }
}
