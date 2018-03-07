using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using DevExpress.XtraCharts;
using GOLDSOFT.QDJJ.UI.BaseFroms;
using System.Threading;
using DevExpress.XtraTreeList;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class HuiZongProjectForm : ABaseForm
    {

        /// <summary>
        /// 获取参数表中的值
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_key"></param>
        /// <returns></returns>
        private decimal GetData(int p_ID,string p_key)
        {
            return this.CurrentBusiness.Current.StructSource.ModelProjVariable.GetDecimal(p_ID, -1, p_key);
        }

        /// <summary>
        /// 获取参数表中的值
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_key"></param>
        /// <returns></returns>
        private decimal GetData(int p_ID, string p_key,int p_Level)
        {
            return this.CurrentBusiness.Current.StructSource.ModelProjVariable.GetDecimal(p_ID, p_Level, p_key);
        }

        /// <summary>
        /// 招标面积
        /// </summary>
        public decimal JSMJ
        {
            get
            {
                if (this.CurrentBusiness.Current.StructSource.BiddingInfoSource.Rows.Count < 1)
                {
                    return 0;
                }
                return ToolKit.ParseDecimal(this.CurrentBusiness.Current.StructSource.BiddingInfoSource.Rows[0]["ZBMJ"]);
            }
        }

        /// <summary>
        /// 需要显示的源数据
        /// </summary>
        public DataTable DataSource = null;

        public HuiZongProjectForm()
        {
            InitializeComponent();
            
        }

        private void HuiZongProjectForm_Load(object sender, EventArgs e)
        {
            initEvent();
            this.Init();
        }

        private void initEvent()
        {
            //(this.CurrentBusiness as _Pr_Business).ListChange += new ListChangeEventHandler(HuiZongProjectForm_ListChange);
            
        }

        /// <summary>
        /// 全局配色方案改变时候
        /// </summary>
        public override void GlobalStyleChange()
        {
            this.treeListEx1.ModelName = "项目-汇总分析";
            this.treeListEx1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.treeListEx1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.treeListEx1.ColumnColor = APP.DataObjects.GColor.ColumnColor;
        }

        void HuiZongProjectForm_ListChange()
        {
            this.init();
        }

        public override void MustInit()
        {
            ////提示重新计算
            //DialogResult r = MessageBox.Show(_Prompt.汇总分析重新计算, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (r == DialogResult.Yes)
            //{
            //    this.init();
            //}
        }
        
        private void init()
        {
            //设置参数
            this.DoLoadData();
        }
        public void DoLoadData()
        {
           /* if (this.CurrentBusiness.Current.Reveal == null) return;
           _List list = this.CurrentBusiness.Current.Reveal.Get(ERevealType.汇总分析);
           IEnumerable<_ObjMetaanalysis> infos = from i in list.Cast<_ObjMetaanalysis>()
                                                  orderby i.Parent.Sort ascending
                                                  select i;
           this.bindingSource1.DataSource = infos.ToArray();
           this.treeListEx1.DataSource = this.bindingSource1;*/
            DataSource = this.CurrentBusiness.Current.StructSource.ModelProject;
            //this.bindingSource1.DataSource = DataSource;
            //this.bindingSource1.Sort = "Sort";
            DataSource.DefaultView.Sort = "Sort";
            this.treeListEx1.DataSource = DataSource.DefaultView;
            this.treeListEx1.ExpandAll();
        }

        public override void OnInitForm()
        {
            base.OnInitForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.AfterStatisticaled += new AfterStatisticaledHandler(HuiZongProjectForm_DoStatistical);
            wcForm.BeforeStatistical += new BeforeStatisticalHandler(wcForm_BeforeStatistical);
            DataSource.RowChanged += new DataRowChangeEventHandler(DataSource_RowChanged);
        }

        void DataSource_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //this.treeListEx1.ExpandAll();
        }

        /// <summary>
        /// 统计前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void wcForm_BeforeStatistical(object sender, object args)
        {
             //取消当前绑定
            //this.bindingSource1.DataSource = null;
            //this.bindingSource1.SuspendBinding();
        }

        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.AfterStatisticaled -= new AfterStatisticaledHandler(HuiZongProjectForm_DoStatistical);
            wcForm.BeforeStatistical -= new BeforeStatisticalHandler(wcForm_BeforeStatistical);
            DataSource.RowChanged -= new DataRowChangeEventHandler(DataSource_RowChanged);
        }

        void HuiZongProjectForm_DoStatistical(object sender, object args)
        {
            //统计后刷新
            //DoLoadData();
            this.treeListEx1.RefreshDataSource();
            //this.bindingSource1.ResumeBinding();
        }
        /// <summary>
        /// 初始化汇总分析的默认数据结构
        /// </summary>
        private void InitHuiZong()
        { 
            
        }



        private void SetChart(DataRowView p_info,int level)
        {
            int mID = 0;
            if (level != -3)
            {
                mID = ToolKit.ParseInt(p_info["ID"]);
            }
            chartControl1.Series[0].Points.Clear();
            chartControl2.Series[0].Points.Clear();
            //饼状图
            decimal FGCF = this.GetData(mID, "FGCF", level);
            decimal CSXMF = this.GetData(mID, "CSXMF", level);
            decimal QTXMF = this.GetData(mID, "QTXMF", level);
            decimal GF = this.GetData(mID, "GF", level);
            decimal SJ = this.GetData(mID, "SJ", level);
            decimal LBTC = this.GetData(mID, "LBTC", level);
            decimal AQWM = this.GetData(mID, "AQWM", level);


            chartControl2.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("分部分项合计", FGCF));
            chartControl2.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("措施项目合计", CSXMF));
            chartControl2.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("其他项目合计", QTXMF));
            chartControl2.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("规费", GF));
            chartControl2.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("税金", SJ));
            chartControl2.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("安全文明施工费", AQWM));
            chartControl2.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("劳保费用", LBTC));
            //柱状图
            chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("分部分项合计", FGCF));
            chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("措施项目合计", CSXMF));
            chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("其他项目合计", QTXMF));
            chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("规费", GF));
            chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("税金", SJ));
            chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("安全文明施工费", AQWM));
            chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint("劳保费用", LBTC));
        }

        public override void Init()
        {
            this.DoLoadData();
            treeListEx1_FocusedNodeChanged(this.treeListEx1, null);
        }

        private void treeListEx1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

            if (this.treeListEx1.Current != null)
            {
                DataRowView info = this.treeListEx1.Current as DataRowView;

                int level = 0;
                if (this.treeListEx1.FocusedNode != null)
                {
                    if (this.treeListEx1.FocusedNode.Level == 2) //单位工程取值
                    {
                        level = -1;
                    }
                    if (this.treeListEx1.FocusedNode.Level == 0)
                    {
                        level = -3;
                    }
                    if (this.treeListEx1.FocusedNode.Level == 1)
                    {
                        level = -2;
                    }

                }

                this.SetChart(info, level);
            }
        }
       

        private void treeListEx1_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e)
        {
            
        }

        private void treeListEx1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Column.ColumnType.Name == "Decimal")
            {

                decimal d = ToolKit.ParseDecimal(e.CellValue);

                if (d == 0)
                {
                    e.CellText = string.Empty;
                }
                else
                {
                    e.CellText = d.ToString("N2");
                }
            }


            int mID = ToolKit.ParseInt(e.Node["ID"]);
            int level = 0; 
            if (e.Node.Level == 2) //单位工程取值
            {
                level = -1;

                if (e.Column.FieldName == "单位造价")
                {
                    if (JSMJ > 0)
                    {
                        
                        e.CellText = (this.GetData(mID, "ZZJ", level) / JSMJ).ToString("N2");
                    }
                    else
                    {
                        e.CellText = string.Empty;
                    }
                    
                }

                if (e.Column.FieldName == "占总价比（%）")
                {
                    decimal xmzzj = this.GetData(0, "ZZJ", -3);
                    //decimal xmzzj = this.GetData(this.CurrentBusiness.Current.ID, "ZZJ", -3);
                    decimal dwzzj = this.GetData(mID, "ZZJ", level);
                    if (xmzzj > 0)
                    {
                        e.CellText = string.Format("{0}%", ((dwzzj / xmzzj) * 100).ToString("N2"));
                    }
                    else
                    {
                        e.CellText = string.Empty;
                    }

                    
                }
                
            }
            if (e.Node.Level == 0)
            {
                mID = 0;
                level = -3;
                if (e.Column.FieldName == "建筑面积")
                {
                    e.CellText = JSMJ.Equals(0m) ? string.Empty : JSMJ.ToString("############0.##");
                }
            }
            if (e.Node.Level == 1)
            {
                level = -2;
            }

            switch (e.Column.FieldName)
            {
                case "分部分项工程费":
                    e.CellText = this.GetData(mID, "FGCF", level).Equals(0m) ? string.Empty : this.GetData(mID, "FGCF", level).ToString("############0.##");
                    break;
                case "措施项目费":
                    e.CellText = this.GetData(mID, "CSXMF", level).Equals(0m) ? string.Empty : this.GetData(mID, "CSXMF", level).ToString("############0.##");
                    break;
                case "其他项目费":
                    e.CellText = this.GetData(mID, "QTXMF", level).Equals(0m) ? string.Empty : this.GetData(mID, "QTXMF", level).ToString("############0.##");
                    break;
                case "规费":
                    e.CellText = this.GetData(mID, "GF", level).Equals(0m) ? string.Empty : this.GetData(mID, "GF", level).ToString("############0.##");
                    break;
                case "税金":
                    e.CellText = this.GetData(mID, "SJ", level).Equals(0m) ? string.Empty : this.GetData(mID, "SJ", level).ToString("############0.##");
                    break;
                case "工程总造价":
                    e.CellText = this.GetData(mID, "ZZJ", level).Equals(0m) ? string.Empty : this.GetData(mID, "ZZJ", level).ToString("############0.##");
                    break;
                case "安全文明施工费":
                    e.CellText = this.GetData(mID, "AQWM", level).Equals(0m) ? string.Empty : this.GetData(mID, "AQWM", level).ToString("############0.##");
                    break;
            }
           

            if (e.Node != null)
            {
                /*DataRowView row = e.Node.TreeList.GetDataRecordByNode(e.Node) as DataRowView;
                if (row == null) return;
                DataRow r = this.CurrentBusiness.Current.StructSource.ModelProject.GetRowByOther(row["PID"].ToString());
                if (r == null) return;
                if (e.Column.FieldName == "Name")
                {
                    
                        //工程名称 工程代号 专业
                        e.CellText = r["Name"].ToString();
                    
                }

                if (e.Column.FieldName == "Code")
                {
                    
                        //工程名称 工程代号 专业
                        e.CellText = r["CODE"].ToString();
                    
                }
                if (e.Column.FieldName == "PrfType")
                {
                    //工程名称 工程代号 专业
                    e.CellText = r["PrfType"].ToString();
                }*/
            }

        }

        private void HuiZongProjectForm_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void treeListEx1_KeyPress(object sender, KeyPressEventArgs e)
        {
 
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

        private void RasieColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.treeListEx1);
        }

       

     }
}
