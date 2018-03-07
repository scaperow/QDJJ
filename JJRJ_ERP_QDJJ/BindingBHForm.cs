using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BindingBHForm : BaseForm
    {
        public string bh = string.Empty;

        /// <summary>
        /// 设置：批量设置的数据源
        /// </summary>
        public IEnumerable<_ObjectQuantityUnitInfo> DataSource
        {
            set
            {
                this.bindingSource1.DataSource = (from info in value.Cast<_ObjectQuantityUnitInfo>()
                                                  where info.YTLB == string.Empty
                                                 select info).ToArray();
            }
        }

        public BindingBHForm()
        {
            InitializeComponent();
        }

        private void BindingBHForm_Load(object sender, EventArgs e)
        {
            this.gridControlYTLB.DataSource = this.bindingSource1;
            this.LostFocus += new EventHandler(shutdown);

        }

        private void bandedGridViewYTLB_DoubleClick(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                //bh = (this.bindingSource1.Current as _ObjectQuantityUnitInfo).BH;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void shutdown(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            //MessageBox.Show("shutdown");
        }


        //bool isFirst = true;
        private void BindingBHForm_Deactivate(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.No;
            //this.Close();
            //MessageBox.Show("BindingBHForm_Deactivate");
            /*if (isFirst)
            {
                isFirst = false;
            }
            else
            {
                this.Close();
            }*/
        }

        private void gridControlYTLB_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("gridControlYTLB_Leave");
            this.DialogResult = DialogResult.No;
        }

        private void BindingBHForm_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}