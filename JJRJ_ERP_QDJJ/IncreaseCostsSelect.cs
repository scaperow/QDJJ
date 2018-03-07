using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class IncreaseCostsSelect : BaseForm
    {
        public IncreaseCostsSelect()
        {
            InitializeComponent();
            
        }
        private object m_DataSource;
        /// <summary>
        /// 所需的数据源
        /// </summary>
        public object DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }
        private _Entity_SubInfo m_CurObj;
        /// <summary>
        /// 当前的子目对象
        /// </summary>
        public _Entity_SubInfo CurObj
        {
            get { return m_CurObj; }
            set { m_CurObj = value; }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IncreaseCostsSelect_Load(object sender, EventArgs e)
        {
            init();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void init()
        {
            this.bindingSource1.DataSource = this.m_DataSource;
            this.treeListEx1.DataSource = this.bindingSource1;
            this.bindingSource1.Filter = GetFilter();
        }
        private string GetFilter()
        {
            string str = string.Empty;
            string names = string.Empty;

            DataRow[] infos = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("PID={0} and SSLB={1} and UnID={2} and LB='子目-增加费'", this.m_CurObj.PID, this.m_CurObj.SSLB, this.m_CurObj.UnID));
            foreach (DataRow item in infos)
            {
                str += "'" + item["XMBM"] + "',";
                names += "'" + item["XMMC"] + "',";
            }
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
                names = names.Substring(0, names.Length - 1);
                str = "(" + str + ")";
                names = "(" + names + ")";
                string filter = "Code in" + str + " and Name in" + names + " and ParentID>0";
                return filter;
            }
            else
            {
                str = "1<>1";
                return str;
            }
           
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void treeListEx1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            DevExpress.XtraTreeList.TreeList gv = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.XtraTreeList.TreeListHitInfo hi = gv.CalcHitInfo(e.Location);
            if (hi.Node!=null)
            {
                object obj = this.treeListEx1.GetDataRecordByNode(hi.Node);
                  if (!this.treeListEx1.CheckNodes.Contains(obj)) this.treeListEx1.CheckNodes.Add(obj);
                  this.DialogResult = DialogResult.OK;
            }
        }

        private void treeListEx1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
               
                    object obj = this.treeListEx1.GetDataRecordByNode(e.Node);
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
}
