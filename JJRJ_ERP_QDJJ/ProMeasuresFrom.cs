using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProMeasuresFrom : ABaseForm
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

        public const string ModelName = "项目_措施项目";

        /// <summary>
        /// 最终数据源
        /// </summary>
        public DataView MyViewSource = null;

        /// <summary>
        /// 需要显示的源数据
        /// </summary>
        public DataTable DataSource = null;

        /// <summary>
        /// 最后一次查询的结果
        /// </summary>
        private DataTable QuerySource = null;

        /// <summary>
        /// 获取当前操作的数据集合(根据条件判断获取所有数据集合还是筛选后的数据集合)
        /// </summary>
        private DataTable CurrentSource
        {
            get
            {
                if (this.QuerySource == null)
                {
                    return this.DataSource;
                }
                return this.QuerySource;
            }
        }

        public ProMeasuresFrom()
        {
            InitializeComponent();
        }

        ///
        private string[] QueryModel = new string[]{ "整个项目","单项工程", "单位工程",string.Empty,"清单" ,"子目"}; 

        /// <summary>
        /// 加载数据时候执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProSubSegmentForm_Load(object sender, EventArgs e)
        {       
            //单项工程
            this.Init();
            //获取列对象
           // this.treeListEx1.Columns.AddRange(CommonData.GetColumns_Segment());
        }

        public override void Init()
        {
            base.Init();
            this.DoLoadData();
        }

       

        /// <summary>
        /// 全局配色方案改变时候
        /// </summary>
        public override void GlobalStyleChange()
        {
            this.treeListEx1.ModelName = ModelName;
            //第一次加载样式
            this.treeListEx1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.treeListEx1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
            this.treeListEx1.ColumnColor = APP.DataObjects.GColor.ColumnColor;
        }

        public override void MustInit()
        {
            
            
        }

        private void SetSort()
        {
            DataRow[] rows = this.CurrentBusiness.Current.StructSource.ModelProject.Select("DEEP = 2");
            foreach (DataRow row in rows)
            {
                DataRow[] rs = this.CurrentBusiness.Current.StructSource.ModelMeasures.Select(string.Format(" PID = 0 and UnID = {0} ", row["ID"]));
                if (rs.Length > 0)
                {
                    rs[0].BeginEdit();
                    rs[0]["Sort"] = row["Sort"];
                    rs[0].EndEdit();
                }
            }
        }

        /// <summary>
        /// 默认的数据加载绑定
        /// </summary>
        private void DoLoadData()
        {
            //if (DataSource == null)
            {
                //如果通用对象为空创建新的数据源
                //DataSource = this.CurrentBusiness.Current.Reveal.Get(ERevealType.措施项目);
                /*int seed = 0;
                this.CurrentBusiness.Current.Reveal.ProMeasures.Fill(DataSource, ref seed);*/
                SetSort();
                MyViewSource = this.CurrentBusiness.Current.StructSource.ModelMeasures.DefaultView;
                MyViewSource.Sort = "Sort asc";
                this.treeListEx1.DataSource = null;
                this.treeListEx1.DataSource = this.MyViewSource;
                //this.treeListEx1.RefreshDataSource();
                SetCount();
                this.treeListEx1.OptionsBehavior.Editable = false;
            }
        }


        public override void OnInitForm()
        {
            base.OnInitForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.BeforeStatistical += new BeforeStatisticalHandler(wcForm_BeforeStatistical);
            wcForm.AfterStatisticaled += new AfterStatisticaledHandler(HuiZongProjectForm_DoStatistical);
        }

        void wcForm_BeforeStatistical(object sender, object args)
        {
            this.treeListEx1.DataSource = null;
            
        }

        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.BeforeStatistical -= new BeforeStatisticalHandler(wcForm_BeforeStatistical);
            wcForm.AfterStatisticaled -= new AfterStatisticaledHandler(HuiZongProjectForm_DoStatistical);
        }

        void HuiZongProjectForm_DoStatistical(object sender, object args)
        {
            //统计后刷新
            DoLoadData();
        }

        private void SetCount()
        {
             //this.lbl_QCount.Text = this.DataSource.Cast<ISubSegment>().Count(info => info.LB == "清单").ToString();
             //this.lbl_ZCount.Text = this.DataSource.Cast<ISubSegment>().Count(info => info.LB == "子目").ToString();
            //仅显示到清单
        }

        /// <summary>
        /// 查询后被调用
        /// </summary>
        /// <param name="list">查询后的结果集</param>
        public void Bind(DataTable list)
        {
            //设置查询结果
            
            //this.QuerySource = list;
            //调用查询后分类
            radioGroup1_SelectedIndexChanged(null, null);
        }


       /* private bool Query(ISubSegment info)
        {
            //筛选级别控制
            //清单必须返回
            return IsExistQuery(info.LB);            
        }*/

        /*private bool IsExistQuery(string p_str)
        {
            //循环当前的选择模式 判断该类别字符串是否在字符串中
            int begin = this.radioGroup1.SelectedIndex;
            //是否查询子目
            int end = this.radioGroup2.SelectedIndex == 0 ? this.QueryModel.Length : this.QueryModel.Length-1;
            for (int i = begin; i < end; i++)
            {
                if (p_str == this.QueryModel[i])
                {
                    return true;
                }
            }

            return false;
        }*/

        private string IsExistQuery()
        {
            //循环当前的选择模式 判断该类别字符串是否在字符串中
            int begin = this.radioGroup1.SelectedIndex;
            //是否查询子目
            int end = this.radioGroup2.SelectedIndex == 0 ? this.QueryModel.Length : this.QueryModel.Length - 1;
            string queryStr = string.Empty; ;
            for (int i = begin; i < end; i++)
            {
                if (i != end - 1)
                {
                    queryStr += string.Format("'{0}',", this.QueryModel[i]);
                }
                else
                {
                    queryStr += string.Format("'{0}'", this.QueryModel[i]);
                }

            }
            return queryStr;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.MyViewSource.RowFilter = string.Format("LB in ({0})", IsExistQuery());
            //this.treeListEx1.DataSource = this.bindingSource1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //取消查询(还原原始数据)
            this.QuerySource = null;
            radioGroup1_SelectedIndexChanged(null, null);
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

            if (e.Node != null)
            {
                //获取编号深度
                DataRowView row = e.Node.TreeList.GetDataRecordByNode(e.Node) as DataRowView;
                if (row == null) return;
                int id;
                int deep = ToolKit.ParseInt(row["DEEP"]);
                //id = deep > 1 ? id = row["UnID"] : id = row["ID"];
                id = ToolKit.ParseInt(row["UnID"]);


                int level = 0;
                if (e.Node.Level == 2) //单位工程取值
                {
                    level = -1;
                }
                if (e.Node.Level == 0)
                {//项目 统计
                    id = 0;
                    level = -3;
                    //if (e.Column.FieldName == "ZHHJ")
                    {
                        //e.CellText = this.GetData(id, "CSXMHJ", level).ToString();
                        e.CellText = TJByXM(id, e.Column.FieldName, level);
                    }
                }
                if (e.Node.Level == 1)
                {//单项 统计
                    level = -2;
                    //if (e.Column.FieldName == "ZHHJ")
                    {
                        //e.CellText = this.GetData(id, "CSXMHJ", level).ToString();
                        e.CellText = TJByXM(id, e.Column.FieldName, level);
                    }
                }

                switch (e.Column.FieldName)
                {
                    case "ProName":
                        if (e.Node.Level > 2)
                        { e.CellText = string.Empty; }
                        else if (e.Node.Level == 0)
                        {
                            e.CellText = GetFiledValue("1", "Name").ToString();
                        }
                        else
                        {
                            e.CellText = GetFiledValue(id.ToString(), "Name").ToString();
                        }
                        break;
                    case "XMBM":
                        if (deep < 2)
                        {
                            e.CellText = GetFiledValue(id.ToString(), "Code").ToString();
                        }
                        break;
                    case "XH":
                        if (e.CellValue.Equals(0))
                        {
                            e.CellText = string.Empty;
                        }
                        break;

                }
            }
        }

        /// <summary>
        /// 项目统计的结果
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_FileName"></param>
        /// <param name="p_Level"></param>
        /// <returns></returns>
        private string TJByXM(int p_ID,string p_FileName,int p_Level)
        {
            switch (p_FileName)
            {
                case "ZHHJ":
                    return this.GetData(p_ID, "CSXMHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMHJ", p_Level).ToString();
                case "ZJFHJ":
                    return this.GetData(p_ID, "CSXMZJFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMZJFHJ", p_Level).ToString();
                case "RGFHJ":
                    return this.GetData(p_ID, "CSXMRGFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMRGFHJ", p_Level).ToString();
                case "CLFHJ":
                    return this.GetData(p_ID, "CSXMCLFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMCLFHJ", p_Level).ToString();
                case "JXFHJ":
                    return this.GetData(p_ID, "CSXMJXFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMJXFHJ", p_Level).ToString();
                case "ZCFHJ":
                    return this.GetData(p_ID, "CSXMZCFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMZCFHJ", p_Level).ToString();
                case "SBFHJ":
                    return this.GetData(p_ID, "CSXMSBFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMSBFHJ", p_Level).ToString();
                case "GLFHJ":
                    return this.GetData(p_ID, "CSXMGLFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMGLFHJ", p_Level).ToString();
                case "LRHJ":
                    return this.GetData(p_ID, "CSXMLRHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMLRHJ", p_Level).ToString();
                case "FXHJ":
                    return this.GetData(p_ID, "CSXMFXHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMFXHJ", p_Level).ToString();
                case "JCHJ":
                    return this.GetData(p_ID, "CSXMJCHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "CSXMJCHJ", p_Level).ToString();
                case CEntitySubSegment.FILED_CJHJ:
                    return this.GetData(p_ID, p_FileName, p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, p_FileName, p_Level).ToString();
            }

            return string.Empty;
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

        private void RaiseColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.treeListEx1);
        }

    }
}