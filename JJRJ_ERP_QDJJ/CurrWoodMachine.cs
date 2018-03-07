using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraTreeList.Nodes;
using System.Web.UI.WebControls;
using DevExpress.XtraRichEdit.API.Word;
using DevExpress.XtraEditors.Controls;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CurrWoodMachine : BaseForm
    {
        /// <summary>
        /// 原始数据源
        /// </summary>
        private IEnumerable<_Entity_QuantityUnit> m_DataSource = null;

        /// <summary>
        /// 设置原始数据源
        /// </summary>
        public IEnumerable<_Entity_QuantityUnit> DataSource
        {
            set { m_DataSource = value; }
        }

        public CurrWoodMachine()
        {
            InitializeComponent();
        }

        private void CurrWoodMachine_Load(object sender, EventArgs e)
        {
            init();
            InfoComBoxEdit();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void init()
        {
            this.bindingSource1.DataSource = this.m_DataSource;
            //this.quantityUnitTypeTreeList1.Activitie = this.Activitie;
            //this.quantityUnitTypeTreeList1.DataSource = this.m_DataSource;
            this.gridControl1.DataSource = this.bindingSource1;

            comboBoxEdit2.SelectedIndexChanged += new EventHandler(comboBoxEdit_SelectedIndexChanged);
            textEdit1.EditValueChanging += new ChangingEventHandler(textEdit_EditValueChanging);
            textEdit2.EditValueChanging += new ChangingEventHandler(textEdit_EditValueChanging);
            this.quantityUnitTypeTreeList1.treeList1.Click += new EventHandler(treeList1_Click);
        }

        /// <summary>
        /// 加载筛选下拉框数据与绑定事件
        /// </summary>
        private void InfoComBoxEdit()
        {
            IEnumerable<_Entity_QuantityUnit> listDW = this.m_DataSource.Cast<_Entity_QuantityUnit>().Distinct(new MergerDW());
            foreach (_Entity_QuantityUnit item in listDW)
            {
                if (item.DW.Length > 0)
                {
                    this.comboBoxEdit2.Properties.Items.Add(item.DW);
                }
            }
            this.comboBoxEdit2.Properties.Items.Insert(0, "请选择");
            this.comboBoxEdit2.SelectedIndex = 0;
        }

        private void comboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoFilter();
        }

        private void textEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            DoFilter();
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            DoFilter();
        }

        /// <summary>
        /// 根据条件筛选内容
        /// </summary>
        /// <param name="where">查询条件</param>
        private void DoFilter()
        {
            string dw = this.comboBoxEdit2.Text;
            string bh = this.textEdit1.Text.Trim();
            string mc = this.textEdit2.Text.Trim();
            IEnumerable<_Entity_QuantityUnit> list = from info in this.quantityUnitTypeTreeList1.DataSource.Cast<_Entity_QuantityUnit>()
                                                        where (dw == "请选择" ? true : info.DW == dw) &&
                                                              (bh == "" ? true : info.BH.Contains(bh)) &&
                                                              (mc == "" ? true : info.MC.Contains(mc))
                                                        select info;

            this.bindingSource1.DataSource = list.ToArray();
            this.bindingSource1.ResetBindings(false);
        }
    }
}