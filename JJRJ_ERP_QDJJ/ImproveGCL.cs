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
using DevExpress.XtraTreeList.Nodes;
using ZiboSoft.Commons.Common;
using System.Collections;
using DevExpress.Data;
namespace GOLDSOFT.QDJJ.UI
{
    public partial class ImproveGCL : BaseForm
    {
        public ImproveGCL()
        {
            InitializeComponent();
            
        }
        private  DataTable  m_Table;
        public SubSegmentForm pform;
        bool flag;
        decimal m;
        ArrayList arr; 
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 确定调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            m= ToolKit.ParseDecimal(this.spinEdit1.EditValue);
            if (m<=0)
            {
                m = 1m;
            }
            this.Activitie.Property.SubSegments.Refesh = false;
            flag = this.radioGroup1.SelectedIndex == 1 ? true : false;
            arr = this.treeListEx1.CheckNodes;
            if (arr.Count<1)
            {
                Alert("请选择要调整的范围！");
                return;
            }
//            this.Activitie.Property.SubSegments.DataSource.
            this.backgroundWorker1.RunWorkerAsync();
            ProgressFrom from = new ProgressFrom(this.backgroundWorker1);
            from.ProgressText = "调整中，请稍等。。。";
            from.ShowDialog();
            
          
        }
        /// <summary>
        /// 计算差值
        /// </summary>
        private void CalcCZ()
        {
            this.Activitie.Property.Statistics.Begin();
            this.Activitie.Property.Metaanalysis.Calculate();
            DataTable dt = this.Activitie.Property.Metaanalysis.Source;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_Table.Rows[i]["TZH"] = dt.Rows[i]["Price"];
                this.m_Table.Rows[i]["CZ"] = ToolKit.ParseDecimal(this.m_Table.Rows[i]["TZH"]) - ToolKit.ParseDecimal(this.m_Table.Rows[i]["Price"]);
            }

        }
        private void ImproveGCL_Load(object sender, EventArgs e)
        {
            init();
        }
        /// <summary>
        /// 界面初始化需要准备工作
        /// </summary>
        private void init()
        {
            this.treeListEx1.KeyFieldName = _ObjectInfo.FILED_ID;
            this.treeListEx1.ParentFieldName = _ObjectInfo.FILED_PPARENTID;
            this.treeListEx1.DataSource = GetTZFW();
            this.treeListEx1.ExpandAll();
           
            /*****************工程造价部分*************************/
            GetGCZJ();
            this.bindingSource1.DataSource = m_Table;
            this.treeListEx2.DataSource = this.bindingSource1;
            this.bindingSource1.Filter = "ParentID=0";
            CurrencyDataController.DisableThreadingProblemsDetection = true;

        }
        public override void MustInit()
        {
            init();
        }
        /// <summary>
        ///获取调整范围的数据源
        /// </summary>
        /// <returns></returns>
        private object GetTZFW()
        {
            IEnumerable<_ObjectInfo> obj = from info in this.Activitie.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                         where info.GetType() ==typeof(_ProfessionalInfo) || info.GetType() == typeof(_SubSegments)
                         select info;
            return obj.ToArray();
        }
        private void GetGCZJ()
        {
            this.Activitie.Property.Statistics.Begin();
            this.Activitie.Property.Metaanalysis.Calculate();
            m_Table = this.Activitie.Property.Metaanalysis.Source.Copy();
            if (!m_Table.Columns.Contains("TZH"))
            {
                m_Table.Columns.Add("TZH", typeof(decimal));
            }
            if (!m_Table.Columns.Contains("CZ"))
            {
                m_Table.Columns.Add("CZ",typeof(decimal));
            }
        }
        private void treeListEx1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                object obj = this.treeListEx1.GetDataRecordByNode(e.Node);

                if (obj.GetType() == typeof(_SubSegments))
                {
                    foreach (TreeListNode item in e.Node.Nodes)
                    {
                        item.Checked = e.Node.Checked;
                        treeListEx1_AfterCheckNode(sender, new DevExpress.XtraTreeList.NodeEventArgs(item));
                    }
                }
                else
                {
                  
                    if (e.Node.Checked)
                    {
                        if (!this.treeListEx1.CheckNodes.Contains(obj)) this.treeListEx1.CheckNodes.Add(obj);
                    }
                    else
                    {
                        this.treeListEx1.CheckNodes.Remove(obj);
                    }
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (_ObjectInfo item in arr)
            {
                IEnumerable<_ObjectInfo> infos = from info in this.Activitie.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                                                 where info.GetType() == typeof(_FFixedListInfo) && info.ZJWZ.Substring(0, 2) == item.XMBM
                                                 select info;

                _ObjectInfo[] infoarr = infos.ToArray();
                foreach (_FixedListInfo item1 in infoarr)
                {
                    if (flag)//调整子目工程量
                    {
                        foreach (_SubheadingsInfo item2 in item1.SubheadingsList)
                        {
                            item2.GCL = item2.GCL * m;

                        }
                    }
                    else
                    {
                        item1.SetGCL1(item1.GCL * m);
                    }
                }

            }
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CalcCZ();
            this.pform.subSegmentListData1_OnChildRefresh();
            this.pform.subSegmentListData1.DataBind();
            this.Activitie.BeginEdit(this);
            
        }
    }
}