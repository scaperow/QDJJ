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
    public partial class ProjProgressAction : DevExpress.XtraEditors.XtraForm
    {

        BackgroundWorker BW = null;

        public ProjProgressAction()
        {
            InitializeComponent();
        }

        public ProjProgressAction(BackgroundWorker p_BW)
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

        private int m_ObjCount = 0;
        void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _COBJECTS obj = e.UserState as _COBJECTS;
            if (obj != null)
            {
                if (obj is _Projects)
                {
                   // m_ObjCount = this.progressBarControl1.Properties.Maximum = (obj as _Projects).ObjectCount;

                    this.labelControl2.Text = string.Format("{0}\\{1}", e.ProgressPercentage, m_ObjCount);
                    this.labelControl3.Text = string.Format("项目信息-{0}", obj.Property.Name);
                }
                if (obj is _Engineering)
                {
                    this.labelControl2.Text = string.Format("{0}\\{1}", e.ProgressPercentage, m_ObjCount);
                    this.labelControl3.Text = string.Format("单项工程-{0}", obj.Property.Name);
                }
                if (obj is _UnitProject)
                {
                    this.labelControl2.Text = string.Format("{0}\\{1}", e.ProgressPercentage, m_ObjCount);
                    this.labelControl3.Text = string.Format("单位工程-{0}", obj.Property.Name);
                }

            }
            
            this.progressBarControl1.Position = e.ProgressPercentage;
        }
    }
}