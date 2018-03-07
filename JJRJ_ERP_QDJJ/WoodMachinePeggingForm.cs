using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class WoodMachinePeggingForm : BaseForm
    {
        public WoodMachinePeggingForm()
        {
            InitializeComponent();
        }

        public WoodMachinePeggingForm( string _QID)
        {
            InitializeComponent();
            if(_QID!="")
            {
               this.Pid = _QID;
               DataBing();
            }
        }

        /// <summary>
        /// 分部分项数据绑定
        /// </summary>
        private void DataBing()
        {
           // this.bindingSource1.DataSource = list;
            this.WoodMachineTreeLst.DataSource = this.bindingSource1;
            this.WoodMachineTreeLst.ExpandAll();
        }

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void WoodMachineTreeLst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SubSegmentForm subSegmentfrm = new SubSegmentForm();
            subSegmentfrm.ShowDialog();
        }

        private string _pid = "";
        public string Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
    }
}
