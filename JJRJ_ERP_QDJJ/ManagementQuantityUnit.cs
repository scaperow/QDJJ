using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ManagementQuantityUnit : CBaseForm
    {
        public ManagementQuantityUnit()
        {
            InitializeComponent();
        }

        private void ManagementQuantityUnit_Load(object sender, EventArgs e)
        {
            initUserQuantityUnit();
            initRepairQuantityUnit();
        }


        /// <summary>
        /// 用户材机库
        /// </summary>
        private void initUserQuantityUnit()
        {
            UserPriceLibraryManagement form = new UserPriceLibraryManagement();
            form.Text = "用户材机库";
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = true;
            xtraTabPage1.Controls.Add(form);
        }

        /// <summary>
        /// 补充人材机
        /// </summary>
        private void initRepairQuantityUnit()
        {
            RepairQuantityUnitManagement form = new RepairQuantityUnitManagement();
            form.Text = "补充人材机";
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Visible = true;
            xtraTabPage2.Controls.Add(form);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            switch (this.xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    UserPriceLibraryManagement u_form = this.xtraTabControl1.SelectedTabPage.Controls[0] as UserPriceLibraryManagement;
                    u_form.Remove();
                    break;
                case 1:
                    RepairQuantityUnitManagement r_form = this.xtraTabControl1.SelectedTabPage.Controls[0] as RepairQuantityUnitManagement;
                    r_form.Remove();
                    break;
                default:
                    break;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            BatchCalculate();
            this.RefreshData();
            MsgBox.Alert("同步结束");
        }

        /// <summary>
        /// 刷新
        /// </summary>
        private void RefreshData()
        {
            this.xtraTabPage1.Controls.Clear();
            this.xtraTabPage2.Controls.Clear();
            initUserQuantityUnit();
            initRepairQuantityUnit();
        }

        /// <summary>
        /// 加载本地价格
        /// </summary>
        private void TableLoad()
        {
            if (APP.UserPriceLibrary.UserPriceLibrarySource.Rows.Count == 0)
            {
                APP.UserPriceLibrary.Load();
            }
            if (APP.RepairQuantityUnit.RepairQuantitySource.Rows.Count == 0)
            {
                APP.RepairQuantityUnit.Load();
            }
        }

        /// <summary>
        /// 合并缓存价格
        /// </summary>
        /// <returns></returns>
        private DataSet GetDataSet()
        {
            DataSet m_DataSet = new DataSet();
            m_DataSet.Tables.Add(APP.UserPriceLibrary.UserPriceLibrarySource.Copy());
            m_DataSet.Tables.Add(APP.RepairQuantityUnit.RepairQuantitySource.Copy());
            return m_DataSet;
        }



        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals(string.Empty)) return;
        }

        private void BatchCalculate()
        {
            APP.GoldSoftClient.GlodSoftNetWork.Completed();
            if (APP.GoldSoftClient.ClientResult.IsUseNet && APP.GoldSoftClient.ClientResult.IsLoginSucess && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals(string.Empty) && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals("-1"))
            {
                BackgroundWorker ObjWorker = new BackgroundWorker();
                ObjWorker.WorkerReportsProgress = true;
                ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork);
                ObjWorker.RunWorkerAsync();
                ProgressFrom form = new ProgressFrom(ObjWorker);
                form.ShowDialog();
            }
        }

        /// <summary>
        /// 共享开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.TableLoad();
            DataSet m_DataSet = this.GetDataSet();

            ServiceReference1.WebSuoSoapClient m_WebService = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
            DataSet new_DataSet = m_WebService.SynchronousData(m_DataSet, APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
            if (new_DataSet != null)
            {
                DataTable m_YHJGK = new_DataSet.Tables["YHJGK"];
                if (m_YHJGK != null)
                {
                    APP.UserPriceLibrary.UserPriceLibrarySource.Clear();
                    APP.UserPriceLibrary.UserPriceLibrarySource.Merge(m_YHJGK);
                    APP.UserPriceLibrary.Save();
                }
                DataTable m_BCRCJ = new_DataSet.Tables["BCRCJ"];
                if (m_BCRCJ != null)
                {
                    APP.RepairQuantityUnit.RepairQuantitySource.Clear();
                    APP.RepairQuantityUnit.RepairQuantitySource.Merge(m_BCRCJ);
                    APP.RepairQuantityUnit.Save();
                }
            }
            
        }

        public void saveBCRCJ()
        {
            this.TableLoad();
            DataSet m_DataSet = this.GetDataSet();

            //ServiceReference1.WebSuoSoapClient m_WebService = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
            //DataSet new_DataSet = m_WebService.SynchronousData(m_DataSet, APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
            //if (new_DataSet != null)
            //{
                DataTable m_YHJGK = m_DataSet.Tables["YHJGK"];
                if (m_YHJGK != null)
                {
                    APP.UserPriceLibrary.UserPriceLibrarySource.Clear();
                    APP.UserPriceLibrary.UserPriceLibrarySource.Merge(m_YHJGK);
                    APP.UserPriceLibrary.Save();
                }
                DataTable m_BCRCJ = m_DataSet.Tables["BCRCJ"];
                if (m_BCRCJ != null)
                {
                    APP.RepairQuantityUnit.RepairQuantitySource.Clear();
                    APP.RepairQuantityUnit.RepairQuantitySource.Merge(m_BCRCJ);
                    APP.RepairQuantityUnit.Save();
                }
            //}
        }
    }
}