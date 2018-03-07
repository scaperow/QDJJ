using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using System.Linq;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class InformationSelect : BaseForm
    {
        public InformationSelect()
        {
            InitializeComponent();
        }

        private void InformationSelect_Load(object sender, EventArgs e)
        {
            APP.GoldSoftClient.GlodSoftNetWork.Completed();
            if (APP.GoldSoftClient.ClientResult.IsUseNet && APP.GoldSoftClient.ClientResult.IsLoginSucess && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals(string.Empty) && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals("-1"))
            {
                ServiceReference1.WebSuoSoapClient m_WebService = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
                //APP.GXKG = m_WebService.GetSharingWwitch(APP.GoldSoftClient.GlodSoftDiscern.CurrNo);
            }
            else
            {
                APP.GXKG = false;
            }
            GetInfo();
        }
        
        /// <summary>
        /// 获取基本信息
        /// </summary>
        private void GetInfo()
        {
            this.lblCount.Text = APP.InformationPriceLibrary.InformationPriceLibrarySource.Rows.Count.ToString();
            this.lblUpdateTime.Text = Convert.ToDateTime(APP.InformationPriceLibrary.InformationPriceLibrarySource.TableName).ToString("yyyy年MM月dd日");
            this.checkEdit1.CheckedChanged -= new EventHandler(checkEdit1_CheckedChanged);
            this.checkEdit1.Checked = APP.GXKG;
            this.checkEdit1.CheckedChanged += new EventHandler(checkEdit1_CheckedChanged);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            BatchCalculate("更新");
            MsgBox.Alert("更新结束");
            GetInfo();
        }

        /// <summary>
        /// 修复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BatchCalculate("修复");
            MsgBox.Alert("修复结束");
            GetInfo();
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            BatchCalculate("设置");
            MsgBox.Alert("设置结束");
            GetInfo();
        }

        private void BatchCalculate(string p_xz)
        {
            APP.GoldSoftClient.GlodSoftNetWork.Completed();
            if (APP.GoldSoftClient.ClientResult.IsUseNet && APP.GoldSoftClient.ClientResult.IsLoginSucess && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals(string.Empty) && !APP.GoldSoftClient.GlodSoftDiscern.CurrNo.Equals("-1"))
            {
                BackgroundWorker ObjWorker = new BackgroundWorker();
                ObjWorker.WorkerReportsProgress = true;
                switch (p_xz)
                {
                    case "更新":
                        ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork_GX);
                        break;
                    case "修复":
                        ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork_XF);
                        break;
                    case "设置":
                        ObjWorker.DoWork += new DoWorkEventHandler(ObjWorker_DoWork_SZ);
                        break;
                    default:
                        return;
                }
                ObjWorker.RunWorkerAsync();
                ProgressFrom form = new ProgressFrom(ObjWorker);
                form.ShowDialog();
            }
            else
            {
                MsgBox.Alert("请检查网络连接是否畅通");
            }
        }

        /// <summary>
        /// 共享开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjWorker_DoWork_SZ(object sender, DoWorkEventArgs e)
        {
            ServiceReference1.WebSuoSoapClient m_WebService = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
            bool m_jg = m_WebService.SharingWwitch(APP.GoldSoftClient.GlodSoftDiscern.CurrNo, this.checkEdit1.Checked);
            if (m_jg)
            {
                APP.GXKG = this.checkEdit1.Checked;
            }
        }

        /// <summary>
        /// 修复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjWorker_DoWork_XF(object sender, DoWorkEventArgs e)
        {
            ServiceReference1.WebSuoSoapClient m_WebService = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
            DataTable m_dt = m_WebService.GetInformationPrice();
            if (m_dt != null)
            {
                DataRow dr = m_dt.Select(string.Empty, "UpdateTime DESC").FirstOrDefault();
                if (dr != null)
                {
                    APP.InformationPriceLibrary.InformationPriceLibrarySource.TableName = dr["UpdateTime"].ToString();
                }
                APP.InformationPriceLibrary.InformationPriceLibrarySource.Clear();
                APP.InformationPriceLibrary.InformationPriceLibrarySource.Merge(m_dt);
                APP.InformationPriceLibrary.Save();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjWorker_DoWork_GX(object sender, DoWorkEventArgs e)
        {
            ServiceReference1.WebSuoSoapClient m_WebService = new GOLDSOFT.QDJJ.UI.ServiceReference1.WebSuoSoapClient();
            DataTable dt = m_WebService.UpdateInformationPrice(Convert.ToDateTime(APP.InformationPriceLibrary.InformationPriceLibrarySource.TableName));
            if (dt != null)
            {
                APP.InformationPriceLibrary.UpdateData(dt);
            }
        }
    }
}