using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProgressFrom : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker BW = null;

        /// <summary>
        /// 设置进度条提示内容
        /// </summary>
        public string ProgressText
        {
            get {return this.marqueeProgressBarControl1.Text; }
            set { this.marqueeProgressBarControl1.Text=value; }
        }


        public ProgressFrom()
        {
            InitializeComponent();
        }

        public ProgressFrom(BackgroundWorker bw)
        {
            InitializeComponent();
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            BW = bw;
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*end = DateTime.Now;

            TimeSpan span = end - begin;
            if (span.Seconds < 3)
            {
                this.timer1.Start();
            }
            else
            {

                this.Close();
            }*/
            this.Close();
        }

        //DateTime begin,end;
        private void ProgressFrom_Load(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProgressFrom_Shown(object sender, EventArgs e)
        {
            //begin = DateTime.Now;
            //this.BW.RunWorkerAsync();
        }
    }
}