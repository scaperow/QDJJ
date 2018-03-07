using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class MQForm : BaseMC
    {
        public MQForm()
        {
            InitializeComponent();
        }
        public MQForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void MQForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
        }

        public override object Parm
        {
            //验证必填项
            get
            {
                return base.Parm;
            }
            set
            {
                this.gridView1.Columns["BZ"].Visible = APP.SHOW_BZ;//隐藏备注列
                base.Parm = value;
                this.ArrCheckMess = new string[] { "分类", "类型", "洞宽", "洞高" };
                this.ArrCheckColl = new string[] { "FL","LX", "DK", "DG" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.MQBindingSource.DataSource = this.MCQDDEbindingSource;
            this.bindingSource1.DataSource = InfTable.MQ;///幕墙
            this.InfTable.MQ.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//幕墙
            MCLXBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗类型"];
            popControl1.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["门窗分类"];
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
                    //从界面获取MQFL（幕墙分类分类）
                    string strQDWhere = string.Format("MCLB = '{0}' and (MCFL is null or MCFL like '%,{1},%')", "幕墙", toString(drCurrent["FL"]));
                    DataRow dr = this.GetMCQD(strQDWhere, strTJ, ToolKit.ParseDecimal(drCurrent["SWGCL"]));
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();


                    //幕墙确定定额
                    this.MQBindingSource.Filter = string.Format("MCLB = '{0}' and (MCLX is null or MCLX = '{1}')", "幕墙", toString(drCurrent["LX"]));
                    foreach (DataRowView item in this.MQBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        decimal gclxs = subDivide(item["GCLXS"]);
                        if (gclxs != -1)
                        {
                            row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / gclxs;
                        }
                        else
                        {
                            row["XS"] = item["GCLXS"];
                        }
                        row["GCL"] = ToolKit.ParseDecimal(dr["GCL"]) * ToolKit.ParseDecimal(row["XS"]);
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
            if (!string.IsNullOrEmpty(drCurrent["MQBH"].ToString()) || !string.IsNullOrEmpty(drCurrent["FL"].ToString()) || !string.IsNullOrEmpty(drCurrent["LX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".幕墙编号：" + drCurrent["FL"].ToString() + "　" + drCurrent["LX"].ToString() + "　" + drCurrent["MQBH"].ToString();
            }
            if (!string.IsNullOrEmpty(drCurrent["DK"].ToString()) && !string.IsNullOrEmpty(drCurrent["DG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".幕墙尺寸：" + drCurrent["DK"] + "*" + drCurrent["DG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".所在部位：" + drCurrent["SZBW"];
            }
            this.InformationForm.SetFixedName(strKey, strContent);
        }
        #endregion


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
                case "FL":

                    popControl1.DataSource = this.MCFLbindingSource;
                    this.MCFLbindingSource.Filter = " MCLB = '幕墙' and MCFL is not null";
                    popControl1.ColName = new string[] { "分类|MCFL|FL" };

                    //清空类型数据
                    popControl1.RemoveDefaultColName = new string[] { "LX" };
                    popControl1.bind();
                    break;
                case "LX":
                    popControl1.DataSource = this.MCLXBindingSource;
                    this.MCLXBindingSource.Filter = string.Format(" MCLB = '幕墙' and  MCFL= '{0}' and MCLX is not null",currRow["FL"]);
                    popControl1.ColName = new string[] { "类型|MCLX|LX" };
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