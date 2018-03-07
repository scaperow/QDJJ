using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI.BaseFroms
{
    public partial class XmlProjProgressAction : DevExpress.XtraEditors.XtraForm
    {
        public string Message1
        {
            set
            {
                this.labelControl1.Text = value;
            }
        }



        BackgroundWorker BW = null;

        public XmlProjProgressAction()
        {
            InitializeComponent();
        }

        public XmlProjProgressAction(BackgroundWorker p_BW)
        {
            InitializeComponent();
            this.BW = p_BW;
            BW.ProgressChanged += new ProgressChangedEventHandler(BW_ProgressChanged);
            BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_RunWorkerCompleted);
        }

        void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object[] param = e.UserState as object[];
            bool flag = (bool)param[0];
            if (flag)
            {
                //第一次
                this.labelControl1.Text = "正在初始化项目";
                this.progressBarControl1.Properties.Maximum = Convert.ToInt32(param[1]);
            }
            else
            {
                _COBJECTS obj = param[1] as _COBJECTS;
                this.labelControl1.Text = string.Format("正在处理 - {0}", obj.Property.Name);
                this.progressBarControl1.Position = e.ProgressPercentage;
                this.labelControl2.Text = string.Format("{0}/{1}", e.ProgressPercentage, this.progressBarControl1.Properties.Maximum);
            }
        }
    }
}