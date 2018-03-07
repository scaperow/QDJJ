using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QuickPrice : BaseForm
    {
        public QuickPrice()
        {
            InitializeComponent();
        }
        public SubSegmentForm sform = null;
        private void QuickPrice_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            this.gridControl1.DataSource = this.Activitie.StructSource.ModelPSubheadingsFee;
            this.radioGroup1.SelectedIndex = 0;
        }
        _YSSubheadingsFeeList list = null;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            list = this.gridControl1.DataSource as _YSSubheadingsFeeList;
         /* BackgroundWorker ProjWorker = new BackgroundWorker();
            ProjWorker.WorkerReportsProgress = true;
            ProjWorker.DoWork += new DoWorkEventHandler(ProjWorker_DoWork);
            ProjWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ProjWorker_RunWorkerCompleted);
            ProjWorker.RunWorkerAsync();
            ProgressFrom form = new ProgressFrom(ProjWorker);
            form.ShowDialog();*/
           ProjWorker_DoWork(null, null);
           MsgBox.Show("处理完成", MessageBoxButtons.OK);
           this.Close();
        }
        void ProjWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MsgBox.Show("处理完成", MessageBoxButtons.OK);
            this.Close();
        }
        void ProjWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (this.TabTY.SelectedTabPage.Name)
            {
                case "TYQFTabPage":
                    TY();
                    break;
                default:
                    break;
            }
          
        }

        private void SetSubheadingsFee(DataRow info)
        {
            lock (info.Table)
            {
                foreach (DataRow item in this.Activitie.StructSource.ModelPSubheadingsFee.Rows)
                {
                    if (item["YYH"].Equals(info["YYH"]))
                    {
                        if (!string.IsNullOrEmpty(item["TBJSJC"].ToString()))
                        {
                            info["TBJSJC"] = item["TBJSJC"];
                        }
                        if (!string.IsNullOrEmpty(item["BDJSJC"].ToString()))
                        {
                            info["BDJSJC"] = item["BDJSJC"];
                        }
                        if (ToolKit.ParseDecimal(item["FL"]) > 0)
                        {
                            info["FL"] = item["FL"];
                        }
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 统一设置取费
        /// </summary>
        private void TY()
        {
            DataRow[] rows = null;
            switch (this.radioGroup1.SelectedIndex)
            {
                case 0://当前工程
                    foreach (DataRow item in  this.Activitie.StructSource.ModelSubheadingsFee.Rows)
                    {
                        SetSubheadingsFee(item);
                    }
                    break;
                case 1://分部分项
                     rows = this.Activitie.StructSource.ModelSubheadingsFee.Select("SSLB=0");
                    foreach (DataRow info in rows)
                    {
                        SetSubheadingsFee(info);
                    }
                    break;
                case 2://清单调价

                case 3://当前子目
                    if (this.sform != null)
                    {
                        DataRowView v = this.sform.subSegmentListData1.treeList1.Current as DataRowView;
                        if (v != null)
                        {
                            string str = string.Empty;
                            if (this.radioGroup1.SelectedIndex == 2)
                            {
                                if (v["LB"].Equals("清单"))
                                {
                                    str = string.Format("QDID={0} and SSLB={1}", v["ID"], v["SSLB"]);
                                }
                            }
                            else
                            {
                                if (v["LB"].ToString().Contains("子目"))
                                {
                                    str = string.Format("ZMID={0} and SSLB={1}", v["ID"], v["SSLB"]);
                                }
                            }
                            if (!string.IsNullOrEmpty(str))
                            {
                                rows = this.Activitie.StructSource.ModelSubheadingsFee.Select(str);
                                foreach (DataRow info in rows)
                                {
                                    SetSubheadingsFee(info);
                                }
                            }
                        }
                    }
                    break;
                case 4://措施项目
                    rows = this.Activitie.StructSource.ModelSubheadingsFee.Select("SSLB=1");
                    foreach (DataRow info in rows)
                    {
                        SetSubheadingsFee(info);
                    }
                    break;
                default:
                    break;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
