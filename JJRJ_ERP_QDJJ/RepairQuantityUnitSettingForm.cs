using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class RepairQuantityUnitSettingForm : BaseForm
    {
       /// <summary>
        /// 当前选中行
        /// </summary>
        private DataRow m_Current = null;

        /// <summary>
        /// 获取或设置当前选中行
        /// </summary>
        public DataRow Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

        public RepairQuantityUnitSettingForm()
        {
            InitializeComponent();
        }

        private void RepairQuantityUnitSettingForm_Load(object sender, EventArgs e)
        {
            if (this.Current != null)
            {
                this.lblBH.Text += this.Current["BH"].ToString();
                this.spinEditSCDJ.EditValue = this.Current["SCDJ"];
                this.bindingSource1.DataSource = APP.RepairQuantityUnit.RepairQuantitySource;
                InfoComBoxEdit();
            }
        }

        /// <summary>
        /// 加载筛选下拉框数据与绑定事件
        /// </summary>
        private void InfoComBoxEdit()
        {
            foreach (DataRow item in APP.RepairQuantityUnit.RepairQuantitySource.Rows)
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
        /// 选择变更时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "XZ")
            {
                this.gridView1.UpdateCurrentRow();
                DataRow[] xz = APP.RepairQuantityUnit.RepairQuantitySource.Select("XZ='True'");
                if (xz.Count() != 0)
                {
                    this.lblCount.Text = "当前材机条数：" + xz.Count() + "条";
                    this.spinEditSCDJ.EditValue = (xz.Sum(p => Convert.ToDecimal(p["SCDJ"])) / xz.Count()).ToString("N2");
                }
                else
                {
                    this.spinEditSCDJ.EditValue = this.Current["SCDJ"];
                }
            }
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

        /// <summary>
        /// 提取选中项修改对应项的值
        /// </summary>
        public bool UpdateInfo()
        {
            if (this.spinEditSCDJ.Value.Equals(this.Current["SCDJ"]))
            {
                return false;
            }
            else
            {
                APP.UserPriceLibrary.AllQuantityUnit = this.Activitie.StructSource.ModelQuantity;
                APP.UserPriceLibrary.UnName = this.Activitie.Name;
                APP.UserPriceLibrary.Range = 0;
                this.Current.BeginEdit();
                this.Current["SCDJ"] = this.spinEditSCDJ.Value;
                APP.UserPriceLibrary.Update("SCDJ", this.Current["SCDJ", DataRowVersion.Current], this.Current);
                this.Current.EndEdit();
                return true;
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