using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class UserPriceLibraryManagement : BaseForm
    {
        public UserPriceLibraryManagement()
        {
            InitializeComponent();
        }

        private void UserPriceLibraryManagement_Load(object sender, EventArgs e)
        {
            InfoComBoxEdit();
            this.bindingSource1.DataSource = APP.UserPriceLibrary.UserPriceLibrarySource;
            this.bindingSource1.Filter = "Status <> 'delete' or Status is null";
        }

        /// <summary>
        /// 加载筛选下拉框数据与绑定事件
        /// </summary>
        private void InfoComBoxEdit()
        {
            foreach (DataRow item in APP.UserPriceLibrary.UserPriceLibrarySource.Rows)
            {
                item["XZ"] = false;
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.gridView1.UpdateCurrentRow();
        }

        /// <summary>
        /// 删除选中行
        /// </summary>
        public void Remove()
        {
            if (bindingSource1.Count > 0)
            {
                DialogResult dr = MsgBox.Show("确认删除？", MessageBoxButtons.YesNo);
                foreach (DataRowView item in bindingSource1)
                {
                    if (item["XZ"].Equals(true))
                    {
                        if (item["ID"].Equals(DBNull.Value))
                        {
                            item.Delete();
                        }
                        else
                        {
                            item["Status"] = "delete";
                        }
                    }

                }
            }
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