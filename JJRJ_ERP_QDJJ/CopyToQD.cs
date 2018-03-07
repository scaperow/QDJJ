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
    public partial class CopyToQD : BaseForm
    {
        public CopyToQD()
        {
            InitializeComponent();
        }
        private string Filter;
        private _Entity_SubInfo m_Info;
        /// <summary>
        /// 当前清单
        /// 
        /// </summary>
        public _Entity_SubInfo Info
        {
            get { return m_Info; }
            set { m_Info = value; }
        }

        private void CopyToQD_Load(object sender, EventArgs e)
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
            this.treeList1.CheckNodes.Clear();
            this.checkEdit1.Checked = false;
        }
        private void GetFilter()
        {
            //此处判断为了防止防止补充定额不够9位报错
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

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

            DevExpress.XtraEditors.CheckEdit editer = sender as DevExpress.XtraEditors.CheckEdit;
            foreach (TreeListNode item in this.treeList1.Nodes)
            {
                item.Checked = editer.Checked;
                treeList1_AfterCheckNode(this.treeList1, new DevExpress.XtraTreeList.NodeEventArgs(item));
            }
        }

     

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (this.treeList1.CheckNodes.Count > 0)
            {

              /*  BackgroundWorker ProjWorker = new BackgroundWorker();
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
            MsgBox.Show("设置完成", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;

        }
        void ProjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (DataRowView item in this.treeList1.CheckNodes)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                CopyTo(info);

                GLODSOFT.QDJJ.BUSINESS._Methods calculateMethod = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.CurrentBusiness, this.Activitie, info);
                calculateMethod.Begin(null);
            }
        }

        private void CopyTo(_Entity_SubInfo toInfo)
        {
            switch (this.radioGroup2.EditValue.ToString())
            {
                case "0"://替换子目
                    CreateZm(0,toInfo);
                    break;
                case "1"://添加子目
                    CreateZm(1,toInfo);
                    break;
                default:
                    break;
            }
           
        }

        private void CreateZm(int IsTh,_Entity_SubInfo toInfo)
        {
            _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness,this.Activitie, this.m_Info);
                switch (this.radioGroup3.EditValue.ToString())
                {
                    case "0"://复用含量
                        fix.CopySubhendingToFix(IsTh,0, toInfo);
                        break;
                    case "1"://复用工程量
                        fix.CopySubhendingToFix(IsTh,1, toInfo);
                        break;
                    default:
                        break;
                }
       
        }
        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node!=null)
            {
                if (e.Node.Checked)
                {
                    if (!this.treeList1.CheckNodes.Contains(GetValueByNode(e.Node)))
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
            this.DataBind();
        }
    }
}
