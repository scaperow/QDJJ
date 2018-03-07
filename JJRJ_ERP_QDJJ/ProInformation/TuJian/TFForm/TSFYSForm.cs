using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class TSFYSForm : BaseBindingSource
    {
        public TSFYSForm()
        {
            InitializeComponent();
        }
        public TSFYSForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }
        private void TSFYSForm_Load(object sender, EventArgs e)
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
                this.ArrCheckMess = new string[] { "土(石)方运输方式" };
                this.ArrCheckColl = new string[] { "TSFYSFS" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.TSFYSQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["土石方运输确定定额"];
            this.bindingSource1.DataSource = InfTable.TSFYS;///土石方运输
            this.InfTable.TSFYS.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//土石方运输
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
                    string strQDWhere = string.Format("TFLX = '{0}' and (LX is null or LX like '%,{1},%') ", "土石方运输", toString(drCurrent["TSFYSFS"]));
                    DataRow dr = this.GetTFQD(strQDWhere, strTJ, CDataConvert.ConToValue<float>(drCurrent["SWGCL"]));
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    this.GCYQCSbindingSource.Filter = " LX = '" + toString(drCurrent["TSFYSFS"]) + "'";
                    this.TSFYSQDDEbindingSource.Filter = string.Format("YSFS = '{0}' and (YTJL is null or YTJL = '{1}' )", toString(drCurrent["TSFYSFS"]), getGCYCCS(drCurrent["YTJL"], BHTYPE.全部包含));
                    foreach (DataRowView item in this.TSFYSQDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DW"];
                        row["XS"] = item["GCLSX"];
                        row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], item["GCLSX"], "", ""));
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
            if (!string.IsNullOrEmpty(drCurrent["TSFYSFS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".土(石)方运输方式：" + drCurrent["TSFYSFS"];
            }

            if (!string.IsNullOrEmpty(drCurrent["YTJL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".运土距离：" + drCurrent["YTJL"] + "(M)";
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

        #region  pop相关
        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "TSFYSFS":
                    popControl1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    popControl1.DataSource = this.LXSZbindingSource;
                    this.LXSZbindingSource.Filter = " LXFL = '土(石)方运输方式'";
                    popControl1.ColName = new string[] { "土(石)方运输方式|LXMC|TSFYSFS" };
                    popControl1.RemoveDefaultColName = new string[] { "YTJL" };
                    popControl1.bind();
                    break;
                case "YTJL":
                    popControl1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    popControl1.DataSource = this.GCYQCSbindingSource;
                    this.GCYQCSbindingSource.Filter = " LX = '" + toString(currRow["TSFYSFS"]) + "'";
                    popControl1.ColName = new string[] { "运土距离|YQ|YTJL" };
                    popControl1.bind();
                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
        }

        /// <summary>
        /// 录入字符限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void popControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// 失去焦点验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "YTJL")
            {
                DataRowView currRow = bindingSource1.Current as DataRowView;
                if (null == currRow) { return; }
                this.LXSZbindingSource.Filter = " LXFL = '土(石)方运输方式' and LXMC='" + toString(currRow["TSFYSFS"]) + "'";
                DataRowView currFiler = this.LXSZbindingSource.Current as DataRowView;
                if (null == currFiler) { return; }
                string[] dFW = toString(currFiler["FW"]).Split('～');
                if (dFW.Length == 2 && (
                       ToolKit.ParseDecimal(currRow["YTJL"]) < ToolKit.ParseDecimal(dFW[0])
                    || ToolKit.ParseDecimal(currRow["YTJL"]) > ToolKit.ParseDecimal(dFW[1])))
                {
                    currRow["YTJL"] = "";
                }
            }
            DataRowView cRow = this.bindingSource1.Current as DataRowView;
            if (null == cRow) { return; }
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
        #endregion
    }
}
