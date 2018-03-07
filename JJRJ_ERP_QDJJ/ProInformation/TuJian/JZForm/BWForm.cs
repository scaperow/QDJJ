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
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BWForm : BaseBindingSource
    {
        public BWForm()
        {
            InitializeComponent();
        }
        public BWForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void BWForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "保温部位", "保温材料" };
                this.ArrCheckColl = new string[] { "BWBW", "BWCL" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.BWBWbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["保温部位并确定清单"];
            this.BWCLbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["保温材料表"];
            this.BWBWCLbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["保温部位材料确定定额"];
            this.bindingSource1.DataSource = InfTable.Warm;///保温
            this.InfTable.Warm.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//保温
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
                    string strQDWhere = string.Format("BWBWMC = '{0}'", drCurrent["BWBW"]);
                    this.BWBWbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.BWBWbindingSource.Count)
                    {
                        DataRowView view = this.BWBWbindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = 1;
                        dr["GCL"] = 1 * CDataConvert.ConToValue<float>(drCurrent["SWGCL"]);
                        dr["TJ"] = strTJ;
                        if (CDataConvert.ConToValue<string>(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = CDataConvert.ConToValue<string>(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    this.BWBWbindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    string[] strArrBWCL = { CDataConvert.ConToValue<string>(drCurrent["BWCL"]), 
                                            CDataConvert.ConToValue<string>(drCurrent["BWCL2"]),
                                            CDataConvert.ConToValue<string>(drCurrent["BWCL3"])};
                    foreach (string stringBWCL in strArrBWCL)
                    {
                        if (!string.IsNullOrEmpty(stringBWCL))
                        {
                            this.BWBWCLbindingSource.Filter = string.Format("BWBWMC = '{0}' and BWCL = '{1}'", drCurrent["BWBW"], stringBWCL);
                            foreach (DataRowView item in this.BWBWCLbindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];

                                string[] strTemp = toString(item["GCLXS"]).Split('/');
                                if (strTemp.Length == 2)
                                {
                                    row["XS"] = ToolKit.ParseDecimal(drCurrent["HD"]) / ToolKit.ParseDecimal(strTemp[1]);
                                }
                                else
                                {
                                    row["XS"] = item["GCLXS"];
                                }
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                            }
                        }
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
            if (!string.IsNullOrEmpty(drCurrent["BWBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温隔热部位：" + drCurrent["BWBW"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWCL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温隔热材料：" + drCurrent["BWCL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWCL2"].ToString()))
            {
                strContent +="；" + drCurrent["BWCL2"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWCL3"].ToString()))
            {
                strContent +="；" + drCurrent["BWCL3"];
            }
            if (!string.IsNullOrEmpty(drCurrent["HD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温层厚度：" + drCurrent["HD"];
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
                case "BWBW":
                    popControl1.DataSource = this.BWBWbindingSource;
                    popControl1.ColName = new string[] { "保温部位|BWBWMC|BWBW" };
                    popControl1.RemoveDefaultColName = new string[] { "BWCL", "BWCL2", "BWCL3" };
                    popControl1.bind();
                    break;
                case "BWCL":
                    this.BWCLbindingSource.Filter = "BWMC='" + CDataConvert.ConToValue<string>(currRow["BWBW"]).Trim() + "'";
                    this.bindingSource1.ResetBindings(false);
                    popControl1.DataSource = this.BWCLbindingSource;
                    popControl1.ColName = new string[] { "保温材料|BWCLMC|BWCL" };
                    popControl1.bind();
                    break;
                case "BWCL2":
                    this.BWCLbindingSource.Filter = "BWMC='" + CDataConvert.ConToValue<string>(currRow["BWBW"]).Trim() + "'";
                    this.bindingSource1.ResetBindings(false);
                    popControl1.DataSource = this.BWCLbindingSource;
                    popControl1.ColName = new string[] { "保温材料|BWCLMC|BWCL2" };
                    popControl1.bind();
                    break;
                case "BWCL3":
                    this.BWCLbindingSource.Filter = "BWMC='" + CDataConvert.ConToValue<string>(currRow["BWBW"]).Trim() + "'";
                    this.bindingSource1.ResetBindings(false);
                    popControl1.DataSource = this.BWCLbindingSource;
                    popControl1.ColName = new string[] { "保温材料|BWCLMC|BWCL3" };
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
        }
    }

}