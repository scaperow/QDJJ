using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class TJForm : BaseUI
    {
        public TJForm()
        {
            InitializeComponent();
        }
        public TJForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void TJForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "面层种类" };
                this.ArrCheckColl = new string[] { "MCZL" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.LDMFLQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["楼地面分类确定清单"];
            this.MCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["面层确定定额"];
            this.bindingSource1.DataSource = InfTable.TJ;///踢脚
            this.InfTable.TJ.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//踢脚
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
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }
            base.btnScreenQDBH_Click(sender, e);
            this.MCQDDEbindingSource.Filter = "FL='踢脚' and MCZL='" + currRow["MCZL"] + "' and MCCL is not null";
            if (MCQDDEbindingSource.Count > 0)
            {
                CheckNull("NTFS", "粘贴方式");
            }
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
                    string strQDWhere = string.Format("FL = '{0}' and MCZL= '{1}'", "踢脚", toString(drCurrent["MCZL"]));
                    this.LDMFLQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.LDMFLQDQDbindingSource.Count)
                    {
                        DataRowView view = this.LDMFLQDQDbindingSource[0] as DataRowView;
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

                    #region 面层确定定额
                    this.MCQDDEbindingSource.Filter = string.Format("FL = '{0}' and MCZL='{1}' and (MCCL is null or MCCL ='{2}') and (JCCL is null or JCCL like '%,{3},%')"
                        , "踢脚"
                        , toString(drCurrent["MCZL"])
                        , toString(drCurrent["NTFS"])
                        , toString(drCurrent["JCCL"]));
                    foreach (DataRowView item in this.MCQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        string strXS = toString(item["GCLXS"]).Replace("GCL", ToolKit.ParseDecimal(drCurrent["SWGCL"]).ToString());
                        row["XS"] = ToolKit.Calculate(strXS);
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                    }
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
                    #endregion
                    #endregion
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
            if (!string.IsNullOrEmpty(drCurrent["MCZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".面层材料：" + drCurrent["MCZL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["NTFS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".粘帖方式：" + drCurrent["NTFS"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JCCL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".基层材料：" + drCurrent["JCCL"];
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
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "MCZL":
                    popControl1.DataSource = this.LDMFLQDQDbindingSource;
                    this.LDMFLQDQDbindingSource.Filter = " FL = '踢脚'";
                    popControl1.ColName = new string[] { "面层种类|MCZL|MCZL" };
                    popControl1.RemoveDefaultColName = new string[] { "NTFS", "JCCL" };
                    popControl1.bind();
                    break;
                case "NTFS":
                    this.MCQDDEbindingSource.Filter = "FL='踢脚' and MCZL='" + currRow["MCZL"] + "'";
                    popControl1.DataSource = (this.MCQDDEbindingSource.DataSource as DataTable).DefaultView.ToTable(true, "MCCL");
                    popControl1.ColName = new string[] { "粘帖方式|MCCL|NTFS" };
                    popControl1.RemoveDefaultColName = new string[] { "JCCL" };
                    popControl1.bind();
                    break;
                case "JCCL":
                    popControl1.DataSource = ReturnDtJCCL(currRow);
                    popControl1.ColName = new string[] { "基层材料|JCCL|JCCL" };
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
                    foreach (string item in this.SZBWrepositoryItemComboBox1.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.SZBWrepositoryItemComboBox1.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }
            if (this.gridView1.FocusedColumn.FieldName == "NTFS")
            {
                DataTable dtTemp = ReturnDtJCCL(currRow);
                if (dtTemp.Rows.Count == 1)
                {
                    currRow["JCCL"] = dtTemp.Rows[0]["JCCL"];
                }
            }
        }
        /// <summary>
        /// 返回处理后的基层材料表
        /// </summary>
        /// <param name="currRow"></param>
        /// <returns></returns>
        private DataTable ReturnDtJCCL(DataRowView currRow)
        {
            this.MCQDDEbindingSource.Filter = "FL='踢脚' and MCZL='" + currRow["MCZL"] + "' and MCCL='" + currRow["NTFS"] + "' and JCCL is not null";
            DataTable dtTemp = new DataTable();
            foreach (DataRowView item in MCQDDEbindingSource)
            {
                this.strToTable(dtTemp, toString(item["JCCL"]), "JCCL");
            }
            this.RemoveRepeat(dtTemp, "JCCL");
            return dtTemp;
        }
    }
}
