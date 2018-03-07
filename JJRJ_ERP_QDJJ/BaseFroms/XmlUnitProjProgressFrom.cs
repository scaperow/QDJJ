using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    
    public partial class XmlUnitProjProgressFrom : DevExpress.XtraEditors.XtraForm
    {
        BackgroundWorker BW = null;
        /// <summary>
        /// 设置最大单位工程个数
        /// </summary>
        public int MaxCount
        {
            set
            {
                this.progressBarControl1.Properties.Maximum = value;
            }
        }

        private int CurrCount = 1;

        public XmlUnitProjProgressFrom()
        {
            InitializeComponent();
        }

        public XmlUnitProjProgressFrom(BackgroundWorker bw)
        {
            InitializeComponent();
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            BW = bw;
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                SetLabCountText((++CurrCount).ToString());
                //为 -1的时候认为是某个单位工程中的操作
                SetText(e.UserState.ToString());

            }
            else
            {
                XmlUnitWorker obj = e.UserState as XmlUnitWorker;
                if (obj != null)
                {
                    this.progressBarControl1.Position = e.ProgressPercentage;
                }
            }
            
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

       
        delegate void SetTextCallback(string text);
        delegate void SetLabCountTextCallback(string text);


        private void SetLabCountText(string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.labelControl3.InvokeRequired)
            {
                SetLabCountTextCallback d = new SetLabCountTextCallback(SetLabCountText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelControl3.Text = text;
            }
        }

        private void SetText(string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.labelControl2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelControl2.Text = text;
            }
        }


    }
}