/*
 基础变量显示窗体
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.CTRL;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class SelectVariableForm : CBaseForm
    {

        /// <summary>
        /// 获取计算公式
        /// </summary>
        public string GetValue
        {
            get
            {
                return this.textEdit1.Text.Trim();
            }
            set
            {
                this.textEdit1.Text = value.Trim();
            }
        }

        /// <summary>
        /// 说明
        /// </summary>
        public string GetRemarkValue
        {
            get
            {
                return this.memoEdit1.Text.Trim();
            }
        }


        public SelectVariableForm()
        {
            InitializeComponent();
        }
        private _VariableSource m_DataSource;

        public _VariableSource DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }
        private void variableList1_Load(object sender, EventArgs e)
        {
            //添加双击处理事件
            this.variableList1.DoubleClick += new EventHandler(variableList1_DoubleClick);
            this.variableList1.DataSource =this. m_DataSource;
            this.variableList1.DataBind();
        }
        public void Filter(int p_ID,int p_SSLB)
        {
            this.variableList1.bindingSource1.Filter = string.Format("ID={0} and type={1} and ISDE = 'False'", p_ID, p_SSLB);
        }

        /// <summary>
        /// 双击的时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void variableList1_DoubleClick(object sender, EventArgs e)
        {
            //双击的时候显示当前选择的对象默认为相加

            if (this.variableList1.Current != null)
            {
                if (this.textEdit1.Text == string.Empty)
                {
                    this.textEdit1.Text += this.variableList1.Current["Key"].ToString();
                }
                else
                {
                    this.textEdit1.Text += "+" + this.variableList1.Current["Key"].ToString();
                }
            }            
        }

        public string Change(string p_source,string p_Field)
        {
            if(p_source != string.Empty)
            p_source = ToolKit.ExpressionReplace(p_source, p_Field, this.m_DataSource   ).ToString();
            return p_source;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string str = this.textEdit1.Text.Trim();
            this.memoEdit1.Text = this.Change(str,"Remark");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}