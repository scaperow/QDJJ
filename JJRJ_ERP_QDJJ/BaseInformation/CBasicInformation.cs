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
    public partial class CBasicInformation : ABaseForm
    {
        public CBasicInformation()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 单位工程对象
        /// </summary>
        private _Projects m_Projects = null;
        /// <summary>
        /// 获取或设置当前单位工程
        /// </summary>
        public _Projects Projects
        {
            get {
                return m_Projects;
            }
            set {
                this.m_Projects = value;
                /*this.publicInformation1 = m_UnitProject;*/
                this.tenderInformation1.Projects = m_Projects;
                this.biddingInformation1.Projects = m_Projects;
                this.ctrlBaseInfo1.tenderInfoSourceBindingSource.DataSource = this.m_Projects.StructSource.TenderInfoSource;
            }
        }

        private void CBasicInformation_Load(object sender, EventArgs e)
        {
            doLoadData();
            this.treeList1.ExpandAll();
        }

        private void doLoadData()
        {
            //this.UnitProject = 
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            //双击的时候切换事件
            if (this.treeList1.Selection[0] != null)
            {
                string str = this.treeList1.Selection[0].GetDisplayText(0);
                switch (str)
                {
                    case "投标信息":
                        this.xtraTabControl1.SelectedTabPageIndex = 1;
                        break;
                    case "招标信息":
                        this.xtraTabControl1.SelectedTabPageIndex = 0;
                        break;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ////this.publicInformation1.Commit();
            //this.tenderInformation1.Commit();
            //this.biddingInformation1.Commit();
            //this.ctrlBaseInfo1.Commit();
            //this.Projects.BeginEdit(null);
            //MsgBox.Alert("信息修改成功！");

        }

        private void biddingInformation1_Load(object sender, EventArgs e)
        {

        }
    }
}