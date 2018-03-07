using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CParams_Metaanalysis : BaseForm
    {
        /// <summary>
        /// 获取当前选中项目
        /// </summary>
        public DataRowView Current
        {
            get
            {
                return this.bindingSource1.Current as DataRowView;
            }
        }

        /// <summary>
        /// 需要筛选的参数集合
        /// </summary>
        public string Filter = string.Empty;

        /// <summary>
        /// 需要加入的参数集合
        /// </summary>
        public DataTable DataSource = null;

        public CParams_Metaanalysis()
        {
            InitializeComponent();
        }

        private void CParams_Metaanalysis_Load(object sender, EventArgs e)
        {
            initFom();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void initFom()
        {
            if (this.DataSource != null)
            {
                this.bindingSource1.DataSource = DataSource;
                this.gridControl1.DataSource = this.bindingSource1;
                if (this.Filter != string.Empty)
                {
                    this.bindingSource1.Filter = string.Format("Code not in ({0})", Filter);
                }
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}