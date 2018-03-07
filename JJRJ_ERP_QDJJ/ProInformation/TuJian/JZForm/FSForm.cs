using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class FSForm : BaseBindingSource
    {
        public FSForm()
        {
            InitializeComponent();
        }
        public FSForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void FSForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "防水材料品种" };
                this.ArrCheckColl = new string[] { "FSCLPZ" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.FSCLFLbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["防水材料分类表"];
            this.FSBWbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["防水部位表"];
            this.FSQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["防水确定清单"];
            this.FSQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["防水确定定额"];
            this.SZBWbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["所在部位"];
            this.bindingSource1.DataSource = InfTable.WaterProof;///防水
            this.InfTable.WaterProof.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//防水
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
                    string strQDWhere = string.Format(" FSBW like'%,{0},%' and FSCLFL = '{1}'", drCurrent["FSBW"], drCurrent["FSCLFL"]);
                    this.FSQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.FSQDQDbindingSource.Count)
                    {
                        DataRowView view = this.FSQDQDbindingSource[0] as DataRowView;
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
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    string[] strArrFSCL = { CDataConvert.ConToValue<string>(drCurrent["FSCLPZ"]), 
                                            CDataConvert.ConToValue<string>(drCurrent["FSCLPZ2"]),
                                            CDataConvert.ConToValue<string>(drCurrent["FSCLPZ3"])};
                    foreach (string stringFSCL in strArrFSCL)
                    {
                        if (!string.IsNullOrEmpty(stringFSCL))
                        {
                            this.FSQDDEbindingSource.Filter = string.Format("(FSFL IS NULL OR FSFL ='{0}') AND (FSBW is null or FSBW like '%,{1},%') and FSCL = '{2}'", drCurrent["FSCLFL"], drCurrent["FSBW"], stringFSCL);
                            foreach (DataRowView item in this.FSQDDEbindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                row["XS"] = item["GCLXS"];
                                row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
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
            if (!string.IsNullOrEmpty(drCurrent["FSCLFL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防水材料分类：" + drCurrent["FSCLFL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FSBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防水部位：" + drCurrent["FSBW"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FSCLPZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防水材料品种、规格、做法：" + drCurrent["FSCLPZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FSCLPZ2"].ToString()))
            {
                strContent += "；" + drCurrent["FSCLPZ2"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FSCLPZ3"].ToString()))
            {
                strContent += "；" + drCurrent["FSCLPZ3"];
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
                case "FSCLFL":
                    popControl1.DataSource = this.FSCLFLbindingSource;
                    popControl1.ColName = new string[] { "防水材料分类|FSCLFL|FSCLFL" };
                    popControl1.RemoveDefaultColName = new string[] { "FSBW", "FSCLPZ", "FSCLPZ2", "FSCLPZ3" };
                    popControl1.bind();
                    break;
                case "FSBW":
                    this.FSBWbindingSource.Filter = " FSFL is null or FSFL like '%," + toString(currRow["FSCLFL"]).Trim() + ",%'";
                    popControl1.DataSource = this.FSBWbindingSource;
                    popControl1.ColName = new string[] { "防水部位|FSBWMC|FSBW" };
                    popControl1.RemoveDefaultColName = new string[] { "FSCLPZ", "FSCLPZ2", "FSCLPZ3" };
                    popControl1.bind();
                    break;
                case "FSCLPZ":
                    this.FSQDDEbindingSource.Filter = "(FSFL is null or FSFL = '" + toString(currRow["FSCLFL"]).Trim() + "') and (FSBW is null or FSBW like '%," + toString(currRow["FSBW"]).Trim() + ",%')";
                    popControl1.DataSource = this.FSQDDEbindingSource;
                    popControl1.ColName = new string[] { "防水材料品种|FSCL|FSCLPZ" };
                    popControl1.bind();
                    break;
                case "FSCLPZ2":
                    this.FSQDDEbindingSource.Filter = "(FSFL is null or FSFL = '" + toString(currRow["FSCLFL"]).Trim() + "') and (FSBW is null or FSBW like '%," + toString(currRow["FSBW"]).Trim() + ",%')";
                    popControl1.DataSource = this.FSQDDEbindingSource;
                    popControl1.ColName = new string[] { "防水材料品种|FSCL|FSCLPZ2" };
                    popControl1.bind();
                    break;
                case "FSCLPZ3":
                    this.FSQDDEbindingSource.Filter = "(FSFL is null or FSFL = '" + toString(currRow["FSCLFL"]).Trim() + "') and (FSBW is null or FSBW like '%," + toString(currRow["FSBW"]).Trim() + ",%')";
                    popControl1.DataSource = this.FSQDDEbindingSource;
                    popControl1.ColName = new string[] { "防水材料品种|FSCL|FSCLPZ3" };
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
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
            if (drCurrent == null) { return; }
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            if (this.gridView1.FocusedColumn.FieldName == "FSBW")
            {
                string strQDWhere = string.Format(" FSBW like'%,{0},%' and FSCLFL = '{1}'", drCurrent["FSBW"], drCurrent["FSCLFL"]);
                this.FSQDQDbindingSource.Filter = strQDWhere;
                foreach (DataRowView item in FSQDQDbindingSource)
                {
                    drCurrent["DW"] = item["QDDW"];
                }
            }
        }
    }

}