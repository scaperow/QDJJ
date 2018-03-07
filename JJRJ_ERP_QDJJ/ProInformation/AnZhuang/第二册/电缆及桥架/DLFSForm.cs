using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class DLFSForm : BaseUI
    {
        public DLFSForm()
        {
            InitializeComponent();
        }

        private void DLFSForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();
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
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.电缆敷设;
            this.InfTable.电缆敷设.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.DQQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["电气确定定额"];
            this.AZQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["安装确定清单"];
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
            checkeArr();
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
                StringBuilder strString = null;
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

                    strString = new StringBuilder(" ZY = '电气' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and MC is null" : string.Format(" and MC like '%,{0},%'", drCurrent["DLFL"]));

                    this.AZQDQDBindingSource.Filter = strString.ToString();
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.AZQDQDBindingSource.Count)
                    {
                        DataRowView view = this.AZQDQDBindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["TJ"] = strTJ;
                        if (toString(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    this.AZQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    #region 电气确定定额

                    string[] strFilter = new string[7];



                    strString = new StringBuilder("  LB = '电缆敷设' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", drCurrent["DLFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["GGXH"])) ? " and GGXH is null" : string.Format(" and GGXH like '%,{0},%'", drCurrent["GGXH"]));
                    strFilter[0] = strString.ToString();

                    strString = new StringBuilder("  LB = '揭（盖）盖板' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", drCurrent["DLFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["JGGB"])) ? " and GGXH is null" : string.Format(" and GGXH like '%,{0},%'", drCurrent["JGGB"]));
                    strFilter[1] = strString.ToString();

                    strString = new StringBuilder("  LB = '电缆终端头' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", drCurrent["DLFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["DLZDTGGXH"])) ? " and GGXH is null" : string.Format(" and GGXH like '%,{0},%'", drCurrent["DLZDTGGXH"]));
                    strFilter[2] = strString.ToString();

                    strString = new StringBuilder("  LB = '电缆中间头' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", drCurrent["DLFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["DLZJTGGXH"])) ? " and GGXH is null" : string.Format(" and GGXH like '%,{0},%'", drCurrent["DLZJTGGXH"]));
                    strFilter[3] = strString.ToString();

                    strString = new StringBuilder("  LB = '电缆保护管' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", drCurrent["DLFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["DLBHG"])) ? " and GGXH is null" : string.Format(" and GGXH like '%,{0},%'", drCurrent["DLBHG"]));
                    strFilter[4] = strString.ToString();

                    strString = new StringBuilder("  LB = '防火阻燃' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", drCurrent["DLFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["FHZR"])) ? " and GGXH is null" : string.Format(" and GGXH like '%,{0},%'", drCurrent["FHZR"]));
                    strFilter[5] = strString.ToString();

                    strString = new StringBuilder("  LB = '电缆防护' ");
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", drCurrent["DLFL"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["DLFH"])) ? " and GGXH is null" : string.Format(" and GGXH like '%,{0},%'", drCurrent["DLFH"]));
                    strFilter[6] = strString.ToString();

                    for (int i = 0; i < strFilter.Length; i++)
                    {
                        this.DQQDDEBindingSource.Filter = strFilter[i];
                        int y = 0;
                        foreach (DataRowView item in this.DQQDDEBindingSource)
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
                    }

                    #endregion
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
            if (!string.IsNullOrEmpty(drCurrent["DLFL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".电缆分类：" + drCurrent["DLFL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GGXH"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".规格型号：" + drCurrent["GGXH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JGGB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".揭（盖）盖板：" + drCurrent["JGGB"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DLZDTGGXH"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".电缆终端头规格型号：" + drCurrent["DLZDTGGXH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DLZJTGGXH"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".电缆中间头规格型号：" + drCurrent["DLZJTGGXH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DLBHG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".电缆保护管：" + drCurrent["DLBHG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FHZR"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防火阻燃：" + drCurrent["FHZR"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DLFH"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".电缆防护：" + drCurrent["DLFH"];
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
            StringBuilder strString = null;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "DLFL":

                    this.DQQDDEBindingSource.Filter = " LB = '电缆敷设' and FL is not null";
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "FL", ','), "FL");

                    popControl1.ColName = new string[] { "电缆分类|FL|DLFL" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GGXH", "JGGB", "DLZDTGGXH", "DLZJTGGXH", "DLBHG", "FHZR", "DLFH" };
                    popControl1.bind();
                    break;
                case "GGXH":

                    strString = new StringBuilder("  LB = '电缆敷设'");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", currRow["DLFL"]))
                             .Append(" and GGXH is not null");

                    this.DQQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "GGXH", ','), "GGXH");

                    popControl1.ColName = new string[] { "规格型号|GGXH|GGXH" };
                    popControl1.bind();
                    break;
                case "JGGB":

                    strString = new StringBuilder("  LB = '揭（盖）盖板' ");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", currRow["DLFL"]))
                             .Append(" and GGXH is not null");

                    this.DQQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "GGXH", ','), "GGXH");

                    popControl1.ColName = new string[] { "揭（盖）盖板|GGXH|JGGB" };
                    popControl1.bind();
                    break;
                case "DLZDTGGXH":

                    strString = new StringBuilder("  LB = '电缆终端头' ");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", currRow["DLFL"]))
                             .Append(" and GGXH is not null");

                    this.DQQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "GGXH", ','), "GGXH");

                    popControl1.ColName = new string[] { "电缆终端头规格型号|GGXH|DLZDTGGXH" };
                    popControl1.bind();
                    break;
                case "DLZJTGGXH":

                    strString = new StringBuilder("  LB = '电缆中间头' ");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", currRow["DLFL"]))
                             .Append(" and GGXH is not null");

                    this.DQQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "GGXH", ','), "GGXH");

                    popControl1.ColName = new string[] { "电缆中间头规格型号|GGXH|DLZJTGGXH" };
                    popControl1.bind();
                    break;
                case "DLBHG":

                    strString = new StringBuilder("  LB = '电缆保护管' ");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", currRow["DLFL"]))
                             .Append(" and GGXH is not null");

                    this.DQQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "GGXH", ','), "GGXH");

                    popControl1.ColName = new string[] { "电缆保护管|GGXH|DLBHG" };
                    popControl1.bind();
                    break;
                case "FHZR":

                    strString = new StringBuilder("  LB = '防火阻燃' ");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", currRow["DLFL"]))
                             .Append(" and GGXH is not null");

                    this.DQQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "GGXH", ','), "GGXH");

                    popControl1.ColName = new string[] { "防火阻燃|GGXH|FHZR" };
                    popControl1.bind();
                    break;
                case "DLFH":

                    strString = new StringBuilder("  LB = '电缆防护' ");
                    strString.Append(string.IsNullOrEmpty(toString(currRow["DLFL"])) ? " and FL is null" : string.Format(" and FL like '%,{0},%'", currRow["DLFL"]))
                             .Append(" and GGXH is not null");

                    this.DQQDDEBindingSource.Filter = strString.ToString();
                    popControl1.DataSource = RemoveRepeat(strToTable(DQQDDEBindingSource, "GGXH", ','), "GGXH");

                    popControl1.ColName = new string[] { "电缆防护|GGXH|DLFH" };
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
                    foreach (string item in this.SZBWrepositoryItemPopupContainerEdit.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.SZBWrepositoryItemPopupContainerEdit.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;

            //当可以确定唯一清单时   修正当前行单位
            StringBuilder strString = new StringBuilder(" ZY = '电气' ");
            strString.Append(string.IsNullOrEmpty(toString(drCurrent["DLFL"])) ? " and MC is null" : string.Format(" and MC like '%,{0},%'", drCurrent["DLFL"]));

            this.AZQDQDBindingSource.Filter = strString.ToString();
            if (0 < AZQDQDBindingSource.Count)
            {
                DataRowView view = this.AZQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        //必填项验证
        private void checkeArr()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            //判断是否已添加数据行
            if (currRow != null)
            {
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                //点击确定清单前   判断必填项 
                this.DQQDDEBindingSource.Filter = " LB = '电缆敷设'";
                if (0 < DQQDDEBindingSource.Count)
                {
                    this.DQQDDEBindingSource.Filter = " LB = '电缆敷设' and FL is null";
                    if (1 > DQQDDEBindingSource.Count)
                    {
                        checkMess.Add("电缆分类");
                        CheckColl.Add("DLFL");
                    }
                }
                checkMess.Add("规格型号");
                CheckColl.Add("GGXH");
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}