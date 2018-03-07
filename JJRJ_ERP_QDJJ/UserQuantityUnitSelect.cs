using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraEditors.Controls;
using System.Linq;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 用户价格库人材机
    /// </summary>
    public partial class UserQuantityUnitSelect : BaseForm
    {
        public UserQuantityUnitSelect()
        {
            InitializeComponent();
        }

        private void UserQuantityUnit_Load(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = APP.UserPriceLibrary.UserPriceLibrarySource;
            InfoComBoxEdit();
        }

        /// <summary>
        /// 加载筛选下拉框数据与绑定事件
        /// </summary>
        private void InfoComBoxEdit()
        {
            foreach (DataRow item in APP.UserPriceLibrary.UserPriceLibrarySource.Rows)
            {
                if (!item["SSDWGC"].Equals(string.Empty))
                {
                    if (!this.comboBoxEditSSDWGC.Properties.Items.Contains(item["SSDWGC"]))
                    {
                        this.comboBoxEditSSDWGC.Properties.Items.Add(item["SSDWGC"]);
                    }
                }
            }
            this.comboBoxEditSSDWGC.Properties.Items.Insert(0, "查看全部");
            this.comboBoxEditSSDWGC.SelectedIndex = 0;
        }

        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_EditValueChanged(object sender, EventArgs e)
        {
            DoFilter();
        }

        /// <summary>
        /// 根据条件筛选内容
        /// </summary>
        /// <param name="where">查询条件</param>
        private void DoFilter()
        {
            string lb = this.comboBoxEditLB.Text;
            string ssdwgc = this.comboBoxEditSSDWGC.Text;
            string bh = this.textEditBH.Text.Trim();
            string mc = this.textEditMC.Text.Trim();
            string str = "1=1";
            if (!lb.Equals("查看全部"))
            {
                str += string.Format(" AND LB ='{0}'", lb); 
            }
            if (!ssdwgc.Equals("查看全部"))
            {
                str += string.Format(" AND SSDWGC ='{0}'", ssdwgc);
            }
            if (!bh.Equals(string.Empty))
            {
                str += string.Format(" AND BH LIKE'%{0}%'", bh);
            }
            if (!mc.Equals(string.Empty))
            {
                str += string.Format(" AND MC LIKE'%{0}%'", mc);
            }
            this.bindingSource1.Filter = str;
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "SCDJ":
                        decimal d = ToolKit.ParseDecimal(e.CellValue);
                        if (d.Equals(0m))
                        {
                            e.DisplayText = string.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}