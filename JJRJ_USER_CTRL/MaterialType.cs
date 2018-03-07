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

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class MaterialType : BaseControl
    {
        public MaterialType()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 原始数据源
        /// </summary>
        private IEnumerable<_Entity_QuantityUnit> m_YDataSource = new _List().Cast<_Entity_QuantityUnit>();

        /// <summary>
        /// 查询后数据源
        /// </summary>
        private IEnumerable<_Entity_QuantityUnit> m_SDataSource = new _List().Cast<_Entity_QuantityUnit>();

        /// <summary>
        /// 获取查询后数据源
        /// </summary>
        public IEnumerable<_Entity_QuantityUnit> DataSource
        {
            get { return m_SDataSource; }
            set
            {
                m_YDataSource = value;
                m_SDataSource = value;
            }
        }


        private void MaterialType_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("PID", typeof(int));
            dt.Columns.Add("ValueMember", typeof(string));
            DataRow drqb = dt.NewRow();
            drqb["ID"] = 1;
            drqb["PID"] = -1;
            drqb["ValueMember"] = "全部";
            dt.Rows.Add(drqb);
            DataRow drzc = dt.NewRow();
            drzc["ID"] = 2;
            drzc["PID"] = 1;
            drzc["ValueMember"] = "主材";
            dt.Rows.Add(drzc);
            DataRow drcl = dt.NewRow();
            drcl["ID"] = 3;
            drcl["PID"] = 1;
            drcl["ValueMember"] = "材料";
            dt.Rows.Add(drcl);
            DataRow drrg = dt.NewRow();
            drrg["ID"] = 4;
            drrg["PID"] = 1;
            drrg["ValueMember"] = "人工";
            dt.Rows.Add(drrg);
            DataRow drjx = dt.NewRow();
            drjx["ID"] = 5;
            drjx["PID"] = 1;
            drjx["ValueMember"] = "机械";
            dt.Rows.Add(drjx);
            DataRow drsb = dt.NewRow();
            drsb["ID"] = 6;
            drsb["PID"] = 1;
            drsb["ValueMember"] = "设备";
            dt.Rows.Add(drsb);
            this.bindingSource1.DataSource = dt;
            this.treeList1.ExpandAll();
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            DataRowView drv = this.bindingSource1.Current as DataRowView;
            if (drv != null)
            {
                switch (drv["ValueMember"].ToString())
                {
                    case "全部":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             select info;
                        break;
                    case "主材":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.zc.Contains("'" + info.LB + "'")
                                             select info;
                        break;
                    case "材料":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.cl.Contains("'" + info.LB + "'")
                                             select info;
                        break;
                    case "人工":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.rg.Contains("'" + info.LB + "'")
                                             select info;
                        break;
                    case "机械":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.jx.Contains("'" + info.LB + "'")
                                             select info;
                        break;
                    case "设备":
                        this.m_SDataSource = from info in this.m_YDataSource
                                             where _Constant.sb.Contains("'" + info.LB + "'")
                                             select info;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}