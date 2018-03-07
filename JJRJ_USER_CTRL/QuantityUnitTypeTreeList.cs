using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using System.IO;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.CTRL
{
    /// <summary>
    /// 工料机类别筛选用户控件
    /// </summary>
    public partial class QuantityUnitTypeTreeList : BaseControl
    {
        public QuantityUnitTypeTreeList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 原始数据源
        /// </summary>
        private IEnumerable<DataRow> m_YDataSource = new ArrayList().Cast<DataRow>();

        /// <summary>
        /// 查询后数据源
        /// </summary>
        private IEnumerable<DataRow> m_SDataSource = new ArrayList().Cast<DataRow>();

        /// <summary>
        /// 获取查询后数据源
        /// </summary>
        public IEnumerable<DataRow> DataSource
        {
            get { return m_SDataSource; }
            set
            {
                m_YDataSource = value;
                m_SDataSource = value;
            }
        }

        private void QuantityUnitTypeTreeList_Load(object sender, EventArgs e)
        {
            if (APP.Application != null)
            {
                this.treeList1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["WoodMachineIndex"].Copy();
                this.treeList1.ExpandAll();
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeListNode tn = this.treeList1.FocusedNode;
            if (tn != null && this.m_YDataSource != null)
            {
                switch (tn.GetValue("ValueMember").ToString().Trim())
                {
                    case "自主报价":
                        break;
                    case "全部人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             select info;
                        break;
                    case "全部人工":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.rg.Contains("'" + info["LB"].ToString() + "'")
                                             select info;
                        break;
                    case "全部材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.cl.Contains("'" + info["LB"].ToString() + "'")
                                             select info;
                        break;
                    case "主要材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["LB"].Equals("材料") || info["LB"].Equals("主材") || info["LB"].Equals("设备") 
                                             select info;
                        break;
                    case "配合比材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["LB"].ToString().Contains("配合比")
                                             select info;
                        break;
                    case "全部机械":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.jx.Contains("'" + info["LB"].ToString() + "'")
                                             select info;
                        break;
                    case "可分解机械台班":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["LB"].ToString().Contains("台班")
                                             select info;
                        break;
                    case "不可分解机械":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["LB"].Equals("机械") || info["LB"].Equals("吊装机械")
                                             select info;
                        break;
                    case "主材":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.zc.Contains("'" + info["LB"].ToString() + "'")
                                             select info;
                        break;
                    case "设备":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.sb.Contains("'" + info["LB"].ToString() + "'")
                                             select info;
                        break;
                    case "分部分项人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["SSLB"].ToString() == "0"
                                             select info;
                        break;
                    case "措施项目人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["SSLB"].ToString() == "1"
                                             select info;
                        break;
                    case "锁定市场价人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where ToolKit.ParseBoolen(info["IFSDSCDJ"])
                                             select info;
                        break;
                    case "存在结算价差人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where CDataConvert.ConToValue<System.Decimal>(info["JSDJC"]) != 0
                                             select info;
                        break;
                    case "计算风险人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where ToolKit.ParseBoolen(info["IFFX"])
                                             select info;
                        break;
                    case "存在价差人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where CDataConvert.ConToValue<System.Decimal>(info["DJC"]) != 0m
                                             select info;
                        break;
                    case "补充人材机":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["BH"].ToString().StartsWith("补") || info["BH"].ToString().StartsWith("BC")
                                             select info;
                        break;
                    case "甲供材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["YTLB"].ToString() == UseType.甲供材料.ToString()
                                             select info;
                        break;
                    case "甲定乙供材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["YTLB"].ToString() == UseType.甲定乙供材料.ToString()
                                             select info;
                        break;
                    case "评标指定材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["YTLB"].ToString() == UseType.评标指定材料.ToString()
                                             select info;
                        break;
                    case "暂定价材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["YTLB"].ToString() == UseType.暂定价材料.ToString()
                                             select info;
                        break;
                    case "三大材汇总":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where info["SDCLB"].ToString() != string.Empty
                                             select info;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
