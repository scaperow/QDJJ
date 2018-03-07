using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.UI.BaseFroms
{
    public partial class ProgressAction : DevExpress.XtraEditors.XtraForm
    {

        BackgroundWorker BW = null;

        public ProgressAction()
        {
            InitializeComponent();
        }

        public ProgressAction(BackgroundWorker p_BW)
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
            
            this.progressBarControl1.Position = e.ProgressPercentage;
        }
    }
}