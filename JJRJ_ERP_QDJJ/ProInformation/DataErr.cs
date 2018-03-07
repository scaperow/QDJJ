using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class DataErr : DevExpress.XtraEditors.XtraForm
    {
        public DataErr()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击的Form名称
        /// </summary>
        private string _strFormName;
        /// <summary>
        /// 点击的Form名称
        /// </summary>
        public string StrFormName
        {
            get { return _strFormName; }
            set { _strFormName = value; }
        }
        /// <summary>
        /// 每一列录入的值
        /// </summary>
        private string _strColNameVal;
        /// <summary>
        /// 每一列录入的值
        /// </summary>
        public string StrColNameVal
        {
            get { return _strColNameVal; }
            set { _strColNameVal = value; }
        }
        /// <summary>
        /// 提交数据到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtContents.Text.Trim()))
            {
                MessageBox.Show("您没有填写任何错误信息！");
                return;
            }

            string wb_web = CSystem.GetAppConfig("wb");
            CEntityGCXXErrData GCXXErrData = new CEntityGCXXErrData();
            GCXXErrData.AddTime = DateTime.Now.ToString();
            GCXXErrData.ColContrnts = this._strColNameVal;
            GCXXErrData.Contents = this.txtContents.Text.Trim();
            GCXXErrData.IsLOCK = 0;
            GCXXErrData.JDName = _strFormName;
            GCXXErrData.Results = "";
            GCXXErrData.ResultsState = 0;
            GCXXErrData.InterLock = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
            bool sige = GCXXErrDataBLL.insertGCXXErr(wb_web, GCXXErrData);
            if (sige)
            {
                this.Close();
            }
            else 
            {
                MessageBox.Show("提交失败，稍后尝试！");
            }
        }
    }
}