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
using DevExpress.XtraTreeList;
using DevExpress.Utils.Drawing;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProSubSegmentForm : ABaseForm
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

        public DataView MyViewSource = null;

        public const string ModelName = "项目_分部分项";

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

        public ProSubSegmentForm()
        {
            InitializeComponent();
        }

        ///
        private string[] QueryModel = new string[]{ "整个项目","单项工程", "单位工程","分部-专业" ,"分部-章", "分部-节","清单" ,"子目"}; 

        /// <summary>
        /// 加载数据时候执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProSubSegmentForm_Load(object sender, EventArgs e)
        {
            //单项工程
            this.Init();
            this.treeListEx1.Expand(4);
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
            //this.bindingSource1.SuspendBinding();
            //this.bindingSource1.DataSource = null; 
        }

        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            CWellComeProject wcForm = (this.BusContainer as CWellComeProject);
            wcForm.AfterStatisticaled -= new AfterStatisticaledHandler(HuiZongProjectForm_DoStatistical);
            wcForm.BeforeStatistical -= new BeforeStatisticalHandler(wcForm_BeforeStatistical);
        }
       

        
       

        void HuiZongProjectForm_DoStatistical(object sender, object args)
        {
            this.DoLoadData();
            //this.bindingSource1 = new BindingSource();
            //this.bindingSource1.DataSource = this.DataSource;
            //统计后刷新
            //DoLoadData();
            

        }
        
        /// <summary>
        /// 当前清单子目的列表类型(默认为Default)
        /// </summary>
        private EListType m_ListType = EListType.Default;

        private void SetSort()
        {
            DataRow[] rows = this.CurrentBusiness.Current.StructSource.ModelProject.Select("DEEP = 2");
            foreach (DataRow row in rows)
            {
                DataRow[] rs = this.CurrentBusiness.Current.StructSource.ModelSubSegments.Select(string.Format(" PID = 0 and UnID = {0} ", row["ID"]));
                if (rs.Length > 0)
                {
                    rs[0]["Sort"] = row["Sort"];
                }
            }
        }

        /// <summary>
        /// 默认的数据加载绑定
        /// </summary>
        private void DoLoadData()
        {
            this.treeListEx1.Invoke(new MethodInvoker(delegate()
            {
                SetSort();
                this.DataSource = this.CurrentBusiness.Current.StructSource.ModelSubSegments;
                MyViewSource = this.DataSource.DefaultView;
                MyViewSource.RowFilter = " Key <> 0";
                MyViewSource.Sort = " Sort asc";
                this.treeListEx1.DataSource = MyViewSource;
                SetCount();
                this.treeListEx1.OptionsBehavior.Editable = false;
                radioGroup2_SelectedIndexChanged(this.radioGroup2, null);
            }));

           
        }

        private void SetCount()
        {
            this.lbl_QCount.Text = this.DataSource.AsEnumerable().Count(info => info["LB"].Equals("清单")).ToString();
            this.lbl_ZCount.Text = this.DataSource.AsEnumerable().Count(info => info["LB"].Equals("子目")).ToString();
            //仅显示到清单
        }

        /// <summary>
        /// 查询后被调用
        /// </summary>
        /// <param name="list">查询后的结果集</param>
        public void Bind(DataTable list)
        {
            //设置查询结果
            //this.bindingSource1.DataSource = list;
            //this.QuerySource = list;
            //调用查询后分类
            radioGroup1_SelectedIndexChanged(null, null);           
        }

        private string IsExistQuery()
        {
            //循环当前的选择模式 判断该类别字符串是否在字符串中
            int begin = this.radioGroup1.SelectedIndex;
            //是否查询子目
            int end = this.radioGroup2.SelectedIndex == 0 ? this.QueryModel.Length : this.QueryModel.Length-1;
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
            //仅显示到清单
            /*IEnumerable<DataRow> infos = from i in this.CurrentSource.Rows.Cast<DataRow>()
                                             where Query(i) //orderby i.Sort ascending
                                             select i;
            //最终的数据绑定
            this.bindingSource1.DataSource = infos.ToArray();*/

            /*this.bindingSource1.Filter = string.Format("LB in ({0})",IsExistQuery());
            this.treeListEx1.DataSource = this.bindingSource1;*/
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //取消查询(还原原始数据)
            this.QuerySource = null;
            radioGroup1_SelectedIndexChanged(null, null);
        }

        private void treeListEx1_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            /*TreeList tree = sender as DevExpress.XtraTreeList.TreeList;

            IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;

            args.DisplayText = (tree.GetVisibleIndexByNode(e.Node) + 1).ToString();*/

            
        }

        private void treeListEx1_GetNodeDisplayValue(object sender, GetNodeDisplayValueEventArgs e)
        {
            
            /*if (e.Node != null)
            {
                if (e.Column.FieldName == "ProName")
                {
                    DataRowView row = e.Node.TreeList.GetDataRecordByNode(e.Node) as DataRowView;
                    if (row == null) return;

                    DataRow r = this.CurrentBusiness.Current.StructSource.ModelProject.GetRowByOther(row);
                   if (r != null)
                   {
                       e.Value = r["Name"];
                   }
                }
            }*/
        }

        
        private void treeListEx1_NodesReloaded(object sender, EventArgs e)
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

            //特殊处理显示模式 仅清单 和 列表模式
            if (this.m_DisplayType == 0)
            {
                //所有结构处理
                this.dispalyAll(e);
            }
            else
            {
                dispalyOnlyQD(e);
            }
                
        }

        private void dispalyOnlyQD(CustomDrawNodeCellEventArgs e)
        {
            if (e.Node != null)
            {
                //获取编号深度
                DataRowView row = e.Node.TreeList.GetDataRecordByNode(e.Node) as DataRowView;
                if (row == null) return;
                int id;
                int deep = ToolKit.ParseInt(row["DEEP"]);
                //id = deep > 1 ? id = row["UnID"] : id = row["ID"];
                id = ToolKit.ParseInt(row["UnID"]);
               
                ///所有的逻辑都这样走
                switch (e.Column.FieldName)
                {
                    case "ProName":
                        e.CellText = GetFiledValue(id.ToString(), "Name").ToString();
                        break;
                    case "XMBM":
                        if (deep <= 2)
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

        //所有模式
        private void dispalyAll(CustomDrawNodeCellEventArgs e)
        {
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
                {//项目
                    id = 0;
                    level = -3;
                    //if (e.Column.FieldName == "ZHHJ")
                    {
                        //e.CellText = this.GetData(id, "FBFXHJ", level).ToString();
                        e.CellText = TJByXM(id, e.Column.FieldName, level);
                    }
                }
                if (e.Node.Level == 1)
                {//单项
                    level = -2;
                    //if (e.Column.FieldName == "ZHHJ")
                    {
                        //e.CellText = this.GetData(id, "FBFXHJ", level).ToString();
                        e.CellText = TJByXM(id, e.Column.FieldName, level);
                    }
                }

                ///所有的逻辑都这样走
                switch (e.Column.FieldName)
                {
                    case "ProName":
                        //名称根据选择判断
                        if (radioGroup2.SelectedIndex == 0)
                        {
                            if (e.Node.Level == 0)
                            {
                                e.CellText = GetFiledValue("1", "Name").ToString();
                            }
                            else if (e.Node.Level < 3)
                            {
                                e.CellText = GetFiledValue(id.ToString(), "Name").ToString();
                            }
                        }
                        else
                        {
                            //全部要名字
                            e.CellText = GetFiledValue(id.ToString(), "Name").ToString();
                        }
                        break;
                    case "XMBM":
                        if (radioGroup2.SelectedIndex == 0)
                        {
                            if (e.Node.Level == 0)
                            {
                                e.CellText = GetFiledValue("1", "Code").ToString();
                            }
                            else if (e.Node.Level < 3)
                            {
                                e.CellText = GetFiledValue(id.ToString(), "Code").ToString();
                            }
                        }
                        else
                        {
                            if (deep <= 2)
                            {
                                e.CellText = GetFiledValue(id.ToString(), "Code").ToString();
                            }
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
        private string TJByXM(int p_ID, string p_FileName, int p_Level)
        {
            switch (p_FileName)
            {
                case "ZHHJ":
                    return this.GetData(p_ID, "FBFXHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXHJ", p_Level).ToString("############0.##");
                case "ZJFHJ":
                    return this.GetData(p_ID, "FBFXZJFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXZJFHJ", p_Level).ToString("############0.##");
                case "RGFHJ":
                    return this.GetData(p_ID, "FBFXRGFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXRGFHJ", p_Level).ToString("############0.##");
                case "CLFHJ":
                    return this.GetData(p_ID, "FBFXCLFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXCLFHJ", p_Level).ToString("############0.##");
                case "JXFHJ":
                    return this.GetData(p_ID, "FBFXJXFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXJXFHJ", p_Level).ToString("############0.##");
                case "ZCFHJ":
                    return this.GetData(p_ID, "FBFXZCFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXZCFHJ", p_Level).ToString("############0.##");
                case "SBFHJ":
                    return this.GetData(p_ID, "FBFXSBFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXSBFHJ", p_Level).ToString("############0.##");
                case "GLFHJ":
                    return this.GetData(p_ID, "FBFXGLFHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXGLFHJ", p_Level).ToString("############0.##");
                case "LRHJ":
                    return this.GetData(p_ID, "FBFXLRHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXLRHJ", p_Level).ToString("############0.##");
                case "FXHJ":
                    return this.GetData(p_ID, "FBFXFXHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXFXHJ", p_Level).ToString("############0.##");
                case "JCHJ":
                    return this.GetData(p_ID, "FBFXJCHJ", p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, "FBFXJCHJ", p_Level).ToString("############0.##");
                case CEntitySubSegment.FILED_CJHJ:
                    return this.GetData(p_ID, p_FileName, p_Level).Equals(0m) ? string.Empty : this.GetData(p_ID, p_FileName, p_Level).ToString("############0.##");
            }

            return string.Empty;
        }

        private string GetFiledValue(string p_ID,string p_FiledName)
        {
            DataRow r = this.CurrentBusiness.Current.StructSource.ModelProject.GetRowByOther(p_ID.ToString());
            if (r != null)
            {
                return r[p_FiledName].ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 项目模式
        /// </summary>
        private int m_DisplayType = 0;

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup2.SelectedIndex == 0)
            {
                //this.treeListEx1.KeyFieldName = "Key";
                //this.treeListEx1.ParentFieldName = "PKey";
                //子目
                m_DisplayType = 0;
                MyViewSource.RowFilter = string.Empty;
                //this.treeListEx1.Expand(4);
            }
            else
            {
                //清单
                MyViewSource.RowFilter = string.Format("LB  in ('{0}')", "清单");
                m_DisplayType = 1;
                //this.treeListEx1.KeyFieldName = string.Empty;
                //this.treeListEx1.ParentFieldName = string.Empty;
                //this.treeListEx1.Expand(3);

            }
        }

        private void RaiseColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.treeListEx1);
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

    }
}