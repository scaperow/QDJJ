/*
    客户信息提交窗体
 *  两种模式 首次应用 变更申请
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GoldSoft.QD_api;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.UI.Client;
using GOLDSOFT.SERVICES.IServicesObject;
using GoldSoft.CICM.UI;
using ZiboSoft.Commons.Common;
using System.Reflection;

namespace GOLDSOFT.QDJJ.UI.BaseInformation
{
    public partial class BBMessageForm : DevExpress.XtraEditors.XtraForm
    {

        public BBMessageForm()
        {
            InitializeComponent();
        }

        private void ContactUsForm_Load(object sender, EventArgs e)
        {
            this.lblBBmessage.Text= Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}