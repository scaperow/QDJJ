using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class PX : BaseUI
    {
        public PX()
        {
            InitializeComponent();
        }
        private void PX_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
        }
        public override object Parm
        {
            get
            {
                return base.Parm;
            }
            set
            {
                                this.gridView1.Columns["BZ"].Visible = APP.SHOW_BZ;//隐藏备注列
                base.Parm = value;
                this.ArrCheckMess = new string[] { "分类" };
                this.ArrCheckColl = new string[] { "FL" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        /// <summary>
        /// 当前项
        /// </summary>
        private DataRowView CurrRow
        {
            get
            {
                return this.bindingSource1.Current as DataRowView;
            }
        }
        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.PXQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["配线确定定额"];
            this.DQQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["安装确定清单"];
            this.bindingSource1.DataSource = InfTable.配线;
            this.InfTable.配线.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
        }
        #endregion

        #region 操作

        #region 确认清单编号
        /// <summary>
        /// 选择发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ScreenWDBH(false);///添加筛选清单
        }
        /// <summary>
        /// 确认清单编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnScreenQDBH_Click(object sender, EventArgs e)
        {
            if (null == this.bindingSource1.Current) return;
            base.btnScreenQDBH_Click(sender, e);

            this.PXQDDEbindingSource.Filter = string.Format("FL='{0}'", CurrRow["FL"]);
            int iCount = this.PXQDDEbindingSource.Count;
            if (iCount > 0)
            {
                this.PXQDDEbindingSource.Filter = string.Format("FL='{0}' and PXFS is not null", CurrRow["FL"]);
                if (iCount == this.PXQDDEbindingSource.Count)
                {
                    this.CheckNull("PXFS", "配线方式");
                }
            }

            this.PXQDDEbindingSource.Filter = string.Format("FL='{0}' and (PXFS is null or PXFS='{1}')", CurrRow["FL"], CurrRow["PXFS"]);
            iCount = this.PXQDDEbindingSource.Count;
            if (iCount > 0)
            {
                this.PXQDDEbindingSource.Filter = string.Format("FL='{0}' and (PXFS is null or PXFS='{1}') and PXCZ is not null", CurrRow["FL"], CurrRow["PXFS"]);
                if (iCount == this.PXQDDEbindingSource.Count)
                {
                    this.CheckNull("CZ", "材质");
                }
            }
            this.CheckNull("GG", "导线截面");
            if (this.CheckResult)
            {
                return;
            }
            ScreenWDBH(true);
            btnRefreshQDMC_Click(sender, e);

        }

        #region 添加筛选清单
        /// <summary>
        /// 添加筛选清单
        /// </summary>
        /// <param name="isAdd">是否添加</param>
        private void ScreenWDBH(bool isAdd)
        {
            try
            {
                if (null == this.bindingSource1.Current)
                {
                    this.InformationForm.Fiter(" 1<>1 ");
                    return;
                }
                DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
                //string strTJ = string.Format("{0}[{1}]", drCurrent["FormMC"], drCurrent["ID"]);//条件  清单、子目标识
                string strTJ = "";
                if (string.IsNullOrEmpty(drCurrent["BZ"].ToString()))
                {
                    strTJ = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                    drCurrent["BZ"] = strTJ;
                }
                else
                {
                    strTJ = drCurrent["BZ"].ToString();
                }

                if (isAdd)
                {
                    #region 确定清单
                    string strQDWhere = string.Format("ZY='电气' and MC like '%,配线,%'");
                    this.DQQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.DQQDQDbindingSource.Count)
                    {
                        DataRowView view = this.DQQDQDbindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(dr["XS"]) * ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["WZLX"] = WZLX.分部分项;
                        dr["TJ"] = strTJ;
                        if (toString(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    this.PXQDDEbindingSource.Filter = string.Format("FL='{0}' and (PXFS is null or PXFS='{1}') and (PXCZ is null or PXCZ='{2}') and GG='{3}'",
                        CurrRow["FL"], CurrRow["PXFS"], CurrRow["CZ"], CurrRow["GG"]);
                    foreach (DataRowView item in this.PXQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                    }

                    #endregion
                    //dr["BZ"] = sb.ToString() + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                    if (string.IsNullOrEmpty(dr["TJ"].ToString()))
                    {
                        dr["BZ"] = sb.ToString() + strTJ;
                        dr["TJ"] = strTJ;
                    }
                    else
                    {
                        dr["BZ"] = sb.ToString() + dr["TJ"].ToString();
                    }
                    this.InformationForm.Remove(strTJ);
                    this.InformationForm.Add(dr, rows);
                }
                else
                {
                    //this.InformationForm.Fiter(string.Format("TJ='{0}[{1}]'", drCurrent["FormMC"], drCurrent["ID"]));///添加筛选清单
                    this.InformationForm.Fiter(string.Format("TJ='{0}'", strTJ));///添加筛选清单
                }
            }
            catch (Exception ex)
            {
                DebugErr(ex.Message);
            }
        }
        #endregion
        #endregion

        #region 刷新清单名称
        /// <summary>
        /// 刷新清单名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnRefreshQDMC_Click(object sender, EventArgs e)
        {
            if (null == this.bindingSource1.Current) return;
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
            string strKey = "项目特征";
            string strContent = "【项目特征】";
            int i = 0;
            if (!string.IsNullOrEmpty(drCurrent["FL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".配线分类：" + drCurrent["FL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["PXFS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".配线方式：" + drCurrent["PXFS"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".配线材质：" + drCurrent["CZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".规格：" + drCurrent["GG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".所在部位：" + drCurrent["SZBW"];
            }

            this.InformationForm.SetFixedName(strKey, strContent);
        }
        #endregion

        #region 鼠标点击【右键处理】
        /// <summary>
        /// 鼠标点击【右键处理】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlEx1_MouseUp(object sender, MouseEventArgs e)
        {
            SetPopBar(sender as GridControl, e);
        }
        #endregion

        #endregion

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (null == CurrRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "FL":
                    this.PXQDDEbindingSource.Filter = "";
                    popControl1.DataSource = this.RemoveRepeat(this.PXQDDEbindingSource, "FL");
                    popControl1.ColName = new string[] { "分类|FL|FL" };
                    popControl1.RemoveDefaultColName = new string[] { "PXFS", "CZ", "GG" };
                    popControl1.bind();
                    break;
                case "PXFS":
                    this.PXQDDEbindingSource.Filter = string.Format("FL='{0}'", CurrRow["FL"]);
                    popControl1.DataSource = this.RemoveRepeat(this.PXQDDEbindingSource, "PXFS");
                    popControl1.ColName = new string[] { "配线方式|PXFS|PXFS" };
                    popControl1.RemoveDefaultColName = new string[] { "CZ", "GG" };
                    popControl1.bind();
                    break;
                case "CZ":
                    this.PXQDDEbindingSource.Filter = string.Format("FL='{0}' and (PXFS is null or PXFS ='{1}')", CurrRow["FL"], CurrRow["PXFS"]);
                    popControl1.DataSource = this.RemoveRepeat(this.PXQDDEbindingSource, "PXCZ");
                    popControl1.ColName = new string[] { "材质|PXCZ|CZ" };
                    popControl1.RemoveDefaultColName = new string[] { "GG" };
                    popControl1.bind();
                    break;
                case "GG":
                    this.PXQDDEbindingSource.Filter = string.Format("FL='{0}' and (PXFS is null or PXFS ='{1}') and (PXCZ is null or PXCZ='{2}')",
                        CurrRow["FL"], CurrRow["PXFS"], CurrRow["CZ"]);
                    popControl1.DataSource = this.RemoveRepeat(this.PXQDDEbindingSource, "GG");
                    popControl1.ColName = new string[] { "导线截面|GG|GG" };
                    popControl1.bind();
                    break;
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "SZBW":
                    string val = e.Value.ToString();
                    foreach (string item in this.repositoryItemComboBox1.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.repositoryItemComboBox1.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            if (this.CurrRow == null) return;
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();

            this.DQQDQDbindingSource.Filter = string.Format("ZY='电气' and MC like '%,配线,%'");
            DataRowView currRow = this.DQQDQDbindingSource.Current as DataRowView;
            if (currRow != null)
                CurrRow["DW"] = currRow["QDDW"];
        }
    }
}