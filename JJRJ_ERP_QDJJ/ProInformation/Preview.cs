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

namespace GOLDSOFT.QDJJ.UI
{
    public partial class Preview : BaseForm
    {
        private bool checkStatus = true;
        public Preview()
        {
            InitializeComponent();
        }
        public Preview(_UnitProject p_CUnitProject, _Business p_CurrentBusiness)
        {
            this.Activitie = p_CUnitProject;
            this.CurrentBusiness = p_CurrentBusiness;
            InitializeComponent();
        }
        private DataTable m_Source;
        //private DataTable m_DESource;
        private void Preview_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            this.treeListEx1.Columns["TJ"].Visible = APP.SHOW_BZ;//隐藏来源列
            this.m_Source = APP.UnInformation.QDTable;
            this.bindingSource1.Filter = "";
            this.bindingSource1.DataSource = this.m_Source;
            this.treeListEx1.DataSource = this.bindingSource1;

            ///重新排列序号
            for (int i = this.bindingSource1.Count; i > 0; i--)
            {
                (this.bindingSource1[i - 1] as DataRowView)["ID"] = i;
            }
            ///刷新
            this.bindingSource1.ResetBindings(false);

            if (this.checkStatus)
            {
                foreach (DataRow r in APP.UnInformation.QDTable.Rows)
                {
                    r["Check"] = true;
                }
                this.selectAll.Text = "反选";
            }
            else
            {
                this.selectAll.Text = "全选";
            }
        }

     
        /// <summary>
        /// 刷新数据到分部分项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.Activitie == null || this.CurrentBusiness == null)
            {
                MsgBox.Alert("请打开单位工程再刷新数据！");
                return;
            }
            //_Methods_Infomation infomation = new _Methods_Infomation(this.Activitie, this.CurrentBusiness);
            //AlertForm form = new AlertForm();
            //form.Text = "自动生成分部分项";
            //form.Content.Text = "当清单数据已经自动生成过（不含手动添加的数据），“追加”则直接新增一条新的清单；“替换”只替换自动生成的清单编码中编码最大的一条清单；“取消”则取消当前操作";
            ////form.Content.Text = "当清单数据已经自动生成过（不含手动添加的数据），“追加”则直接新增一条新的清单；“取消”则取消当前操作";
            //DialogResult d = form.ShowDialog();
            //if (d == DialogResult.Yes)
            //{

            //BackgroundWorker OpenUnitWorker = new BackgroundWorker();
            //OpenUnitWorker.WorkerReportsProgress = false;
            //OpenUnitWorker.DoWork += new DoWorkEventHandler(OpenUnitWorker_DoWork);
            //OpenUnitWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OpenUnitWorker_RunWorkerCompleted);
            //OpenUnitWorker.RunWorkerAsync();
            //ProgressFrom pform = new ProgressFrom(OpenUnitWorker);
            //pform.ShowDialog();

            _Methods_Infomation infomation = new _Methods_Infomation(this.Activitie, this.CurrentBusiness);
            infomation.CreatAll(true);
            MsgBox.Alert("处理成功");
            this.Close();

            //    //this.Activitie.Property.SubSegments.IsZDSC = true;
                //infomation.CreatAll(true);
            //}
            //if (d == DialogResult.No)
            //{
            //    BackgroundWorker OpenUnitWorker1 = new BackgroundWorker();
            //    OpenUnitWorker1.WorkerReportsProgress = false;
            //    OpenUnitWorker1.DoWork += new DoWorkEventHandler(OpenUnitWorker1_DoWork);
            //    OpenUnitWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OpenUnitWorker1_RunWorkerCompleted);
            //    OpenUnitWorker1.RunWorkerAsync();
            //    ProgressFrom pform1 = new ProgressFrom(OpenUnitWorker1);
            //    pform1.ShowDialog();


            //   // this.Activitie.Property.SubSegments.IsZDSC = true;
            //    //infomation.CreatAll(false);
            //}
        }

        /// <summary>
        /// 打开进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenUnitWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _Methods_Infomation infomation = new _Methods_Infomation(this.Activitie, this.CurrentBusiness);
            infomation.CreatAll(true);
        }

        /// <summary>
        /// 打开进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OpenUnitWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MsgBox.Alert("处理成功");
            this.Close();

        }

        ///// <summary>
        ///// 打开进度
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void OpenUnitWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    _Methods_Infomation infomation = new _Methods_Infomation(this.Activitie, this.CurrentBusiness);
        //    infomation.CreatAll(false);
        //}

        ///// <summary>
        ///// 打开进度
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void OpenUnitWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    MsgBox.Alert("追加成功");
        //    this.Close();
        //}


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void selectAll_Click(object sender, EventArgs e)
        {
            if (this.checkStatus)
            {
                foreach (DataRow r in APP.UnInformation.QDTable.Rows)
                {
                    r["Check"] = false;
                }
                ///刷新
                this.bindingSource1.ResetBindings(false);

                this.checkStatus = false;
                this.selectAll.Text = "全选";
            }
            else
            {
                foreach (DataRow r in APP.UnInformation.QDTable.Rows)
                {
                    r["Check"] = true;
                }
                ///刷新
                this.bindingSource1.ResetBindings(false);

                this.checkStatus = true;
                this.selectAll.Text = "反选";
            }
        }
    }
}
