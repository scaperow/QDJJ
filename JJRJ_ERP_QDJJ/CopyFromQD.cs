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
using DevExpress.XtraTreeList.Nodes;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CopyFromQD : BaseForm
    {
        public CopyFromQD()
        {
            InitializeComponent();
        }

        private string Filter;
        private _Entity_SubInfo m_Info;
        /// <summary>
        /// 当前清单
        /// </summary>
        public _Entity_SubInfo Info
        {
            get { return m_Info; }
            set { m_Info = value; }
        }

        private void CopyFromQD_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// 数据绑定 
        /// </summary>
        private void DataBind()
        {
            GetFilter();
            DataRow[] rows = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("LB='清单' and XMBM like '%{0}%' and ID<>{1}", this.Filter, this.Info.ID));
            if (rows.Length > 0)
                this.bindingSource1.DataSource = rows.CopyToDataTable();
            else
                this.bindingSource1.DataSource = null;
            this.treeList1.DataSource = null;
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.ExpandAll();
            this.treeList1.CheckNodes.Clear();
        }
        private bool Getwhere(_ObjectInfo info)
        {
            bool flag = false;
            _FSubheadingsInfo sinfo = info as _FSubheadingsInfo;
            if (info.XMBM.Contains(this.Filter) && info.GetType() == typeof(_FFixedListInfo) && info.XMBM!=this.Info.XMBM)
            {
                flag = true;
            }
            if (sinfo!=null)
            {
                if (sinfo.Parent.XMBM.Contains(this.Filter) && info.GetType() == typeof(_FSubheadingsInfo)&& sinfo.Parent.XMBM!=this.Info.XMBM)
                {
                      flag = true;
                }
            }
            return  flag;
        }
        private void GetFilter()
        {
            if (this.Info.OLDXMBM != "")
            {
                if (this.Info.OLDXMBM.Length > 8)
                {
                    switch (this.radioGroup1.EditValue.ToString())
                    {
                        case "0":
                            this.Filter = this.Info.OLDXMBM.Substring(0, 4);
                            break;

                        case "1":
                            this.Filter = this.Info.OLDXMBM.Substring(0, 9);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    this.Filter = this.Info.OLDXMBM;
                }
            }
            else
            {
                this.Filter = "";
            }
        }
        /// <summary>
        /// 确定之后要做的事
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.treeList1.CheckNodes.Count > 0)
            {

               /* BackgroundWorker ProjWorker = new BackgroundWorker();
                ProjWorker.WorkerReportsProgress = true;
                ProjWorker.DoWork += new DoWorkEventHandler(ProjWorker_DoWork);
                ProjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProjWorker_RunWorkerCompleted);
                ProjWorker.RunWorkerAsync();
                ProgressFrom form = new ProgressFrom(ProjWorker);
                form.ShowDialog();*/
                this.ProjWorker_DoWork(null, null);
                MsgBox.Show("处理完成", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Alert("请选择要处理的清单！");
            }
        }
        void ProjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MsgBox.Show("处理完成", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;

        }
        void ProjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (DataRowView item in this.treeList1.CheckNodes)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);

                CopyTo(info);
            }
        }
        private void CopyTo(_Entity_SubInfo fromInfo)
        {
            switch (this.radioGroup2.EditValue.ToString())
            {
                case "0"://替换子目
                    //_SubheadingsInfo[] infos = Info.SubheadingsList.Cast<_SubheadingsInfo>().ToArray();
                    //foreach (_SubheadingsInfo item in infos)
                    //{
                    //    item.Parent.Remove(item);
                    //}
                    CreateZm(0,fromInfo);
                    break;
                case "1"://添加子目
                    CreateZm(1,fromInfo);
                    break;
                default:
                    break;
            }

        }

        private void CreateZm(int ISth, _Entity_SubInfo fromInfo)
        {
            _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness,this.Activitie, this.m_Info);
                switch (this.radioGroup3.EditValue.ToString())
                {
                    case "0"://复用含量
                        fix.FromSubhendingToFix(ISth,0, fromInfo);
                       // info.HL = item.HL;
                        break;
                    case "1"://复用工程量
                        fix.FromSubhendingToFix(ISth,1, fromInfo);
                        break;
                    default:
                        break;
                }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeList1_CustomDrawNodeCheckBox(object sender, DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs e)
        {
            if (e.Node!=null)
            {
              _FSubheadingsInfo info=  (GetValueByNode(e.Node)) as _FSubheadingsInfo;
                if (info!=null)
                {
		            e.Handled = true; 
                }
               
            }
        }

        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Checked)
                {
                    foreach (TreeListNode item in this.treeList1.Nodes)
                    {
                        if (item!=e.Node)
                        {
                            if (item.Checked) item.CheckState = CheckState.Unchecked;
                          
                            
                        }
                    }
                    this.treeList1.CheckNodes.Clear();
                    this.treeList1.CheckNodes.Add(GetValueByNode(e.Node));
                }
                else
                {
                    this.treeList1.CheckNodes.Remove(GetValueByNode(e.Node));
                }
            }
        }

        private object GetValueByNode(TreeListNode node)
        {
            object obj = this.bindingSource1[node.Id];
            return obj;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}
