using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class TLYQForm : BaseUI
    {
        public TLYQForm()
        {
            InitializeComponent();
        }
        public TLYQForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void TLYQForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.TLYQ;
            this.InfTable.TLYQ.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.YQFLBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["油漆分类"];
            this.QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["油漆确定定额"];
            this.QDQDBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["油漆确定清单"];
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

            //必填项验证
            checkeArr();
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
                    //（室外工程清单）
                    string strQDWhere = string.Format("FL1 = '{0}'and FL2 like '%,{1},%' and (MC is null or MC like '%,{2},%')"
                                                        , toString(drCurrent["FL1"]), toString(drCurrent["FL2"]), toString(drCurrent["MC"]));

                    this.QDQDBindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.QDQDBindingSource.Count)
                    {
                        DataRowView view = this.QDQDBindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["TJ"] = strTJ;
                        if (CDataConvert.ConToValue<string>(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = CDataConvert.ConToValue<string>(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    this.QDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();


                    //室外工程确定定额
                    string strDEWhere = "1=1 ";

                    if (!string.IsNullOrEmpty(toString(drCurrent["FL1"])))
                    {
                        strDEWhere += string.Format("and FL1='{0}'", toString(drCurrent["FL1"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["FL2"])))
                    {
                        strDEWhere += string.Format("and FL2 like '%,{0},%'", toString(drCurrent["FL2"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["MC"])))
                    {
                        strDEWhere += string.Format("and MC like '%,{0},%'", toString(drCurrent["MC"]));
                    }


                    string[] yqpzsqbs = new string[] { toString(drCurrent["YQPZSQBS1"]), toString(drCurrent["YQPZSQBS2"]) };
                    foreach (string strYqpz in yqpzsqbs)
                    {
                        if (strYqpz != null && !string.IsNullOrEmpty(strYqpz))
                        {
                            this.QDDEBindingSource.Filter = strDEWhere + string.Format(" and YQPZ = '{0}'", strYqpz);

                            foreach (DataRowView item in this.QDDEBindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                if (toString(drCurrent["FL2"]).Equals("钢门")
                                || toString(drCurrent["FL2"]).Equals("钢窗")
                                || toString(drCurrent["FL2"]).Equals("木门")
                                || toString(drCurrent["FL2"]).Equals("木窗"))
                                {
                                    row["XS"] = ToolKit.ParseDecimal(drCurrent["DK"]) * ToolKit.ParseDecimal(drCurrent["DG"]) / 100000000;
                                }
                                else
                                {
                                    row["XS"] = item["GCLXS"];
                                }
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                row["WZLX"] = WZLX.分部分项;
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
            if (!string.IsNullOrEmpty(drCurrent["FL1"].ToString()) || !string.IsNullOrEmpty(drCurrent["FL2"].ToString()) || !string.IsNullOrEmpty(drCurrent["MC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".分类：" + drCurrent["FL2"] + "　" + drCurrent["MC"];
            }
            if (!string.IsNullOrEmpty(drCurrent["YQPZSQBS1"].ToString()) || !string.IsNullOrEmpty(drCurrent["YQPZSQBS2"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".油漆品种、刷漆遍数：" + drCurrent["YQPZSQBS1"] + "　" + drCurrent["YQPZSQBS2"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DK"].ToString()) || !string.IsNullOrEmpty(drCurrent["DG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".洞口尺寸：" + drCurrent["DK"] + "*" + drCurrent["DG"]+"(mm)";
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
                case "FL1":

                    popControl1.DataSource = this.YQFLBindingSource;
                    YQFLBindingSource.Filter = "";

                    popControl1.ColName = new string[] { "分类1|FL1|FL1" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "FL2", "MC", "YQPZSQBS1", "YQPZSQBS2" };
                    popControl1.bind();
                    break;
                case "FL2":

                    this.YQFLBindingSource.Filter = string.Format(" FL1 = '{0}' and FL2 is not null ", toString(currRow["FL1"]));

                    //字符串截断 并去重复
                    popControl1.DataSource = this.RemoveRepeat(this.strToTable(YQFLBindingSource, "FL2", ','), "FL2");


                    popControl1.ColName = new string[] { "分类2|FL2|FL2" };
                    popControl1.RemoveDefaultColName = new string[] { "YQPZSQBS1", "YQPZSQBS2", "MC","DK","DG"};
                    popControl1.bind();
                    break;
                case "MC":

                    this.QDQDBindingSource.Filter = string.Format(" FL1 = '{0}'  and (FL2 is null or FL2 like '%,{1},%') and MC is not null", toString(currRow["FL1"]), toString(currRow["FL2"]));


                    //字符串截断   并去重复
                    popControl1.DataSource = this.RemoveRepeat(this.strToTable(QDQDBindingSource, "MC", ','), "MC");

                    popControl1.ColName = new string[] { "名称|MC|MC" };
                    popControl1.bind();
                    break;
                case "YQPZSQBS1":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" FL1 = '{0}' and (FL2 is null or FL2 like '%,{1},%') ", toString(currRow["FL1"]), toString(currRow["FL2"]));

                    popControl1.ColName = new string[] { "油漆品种、刷漆遍数|YQPZ|YQPZSQBS1" };
                    popControl1.bind();
                    break;
                case "YQPZSQBS2":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" FL1 = '{0}' and (FL2 is null or FL2 like '%,{1},%')", toString(currRow["FL1"]), toString(currRow["FL2"]));

                    popControl1.ColName = new string[] { "油漆品种、刷漆遍数|YQPZ|YQPZSQBS2" };
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
            
            DataRowView drCurrent = bindingSource1.Current as DataRowView;

            //分类二为 下列四个选择的时候  允许输入洞宽洞高  否则 禁止输入
            if (drCurrent["FL2"] != null && (
                "钢门".Equals(toString(drCurrent["FL2"]))
                || "钢窗".Equals(toString(drCurrent["FL2"]))
                || "木门".Equals(toString(drCurrent["FL2"]))
                || "木窗".Equals(toString(drCurrent["FL2"]))
                ))
            {
                this.gridView1.Columns["DK"].OptionsColumn.AllowEdit = true;
                this.gridView1.Columns["DG"].OptionsColumn.AllowEdit = true;
            }
            else
            {
                this.gridView1.Columns["DK"].OptionsColumn.AllowEdit = false;
                this.gridView1.Columns["DG"].OptionsColumn.AllowEdit = false;
            }
            //当可以确定唯一清单时   修正当前行单位
            string strQDWhere = string.Format("FL1 = '{0}'and FL2 like '%,{1},%' and (MC is null or MC like '%,{2},%')"
                                                , toString(drCurrent["FL1"]), toString(drCurrent["FL2"]), toString(drCurrent["MC"]));
            this.QDQDBindingSource.Filter = strQDWhere;
            if (0 < QDQDBindingSource.Count)
            {
                DataRowView view = this.QDQDBindingSource[0] as DataRowView;
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
                checkMess.Add("分类1");
                CheckColl.Add("FL1");
                //点击确定清单前   判断必填项
                this.YQFLBindingSource.Filter = string.Format(" FL1 = '{0}'", toString(currRow["FL1"]));
                if (0 < YQFLBindingSource.Count)
                {
                    this.YQFLBindingSource.Filter = string.Format(" FL1 = '{0}' and FL2 is null ", toString(currRow["FL1"]));
                    if (1 > YQFLBindingSource.Count)
                    {
                        checkMess.Add("分类2");
                        CheckColl.Add("FL2");
                    }
                }
                this.QDQDBindingSource.Filter = string.Format(" FL1 = '{0}' and FL2 like '%,{1},%'", toString(currRow["FL1"]), toString(currRow["FL2"]));
                if (0 < QDQDBindingSource.Count)
                {
                    this.QDQDBindingSource.Filter = string.Format(" FL1 = '{0}' and FL2 like '%,{1},%'and MC is null", toString(currRow["FL1"]), toString(currRow["FL2"]));
                    if (1 > QDQDBindingSource.Count)
                    {
                        checkMess.Add("名称");
                        CheckColl.Add("MC");
                    } 
                }
                this.QDDEBindingSource.Filter = string.Format(" FL1 = '{0}' and FL2 like '%,{1},%'", toString(currRow["FL1"]), toString(currRow["FL2"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format(" FL1 = '{0}' and FL2 like '%,{1},%' and  YQPZ is null", toString(currRow["FL1"]), toString(currRow["FL2"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("油漆品种刷漆遍数1");
                        CheckColl.Add("YQPZSQBS1");
                    }
                }
                if (currRow["FL2"] != null
                    && ( toString(currRow["FL2"]).Equals("钢门")
                    || toString(currRow["FL2"]).Equals("钢窗")
                    || toString(currRow["FL2"]).Equals("木门")
                    || toString(currRow["FL2"]).Equals("木窗")
                    ))
                {
                    checkMess.Add("洞宽");
                    CheckColl.Add("DK");
                    checkMess.Add("洞高");
                    CheckColl.Add("DG");
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}
