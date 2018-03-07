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
    public partial class TPMHForm : BaseUI
    {
        public TPMHForm()
        {
            InitializeComponent();
        }
        public TPMHForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void TPMHForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.TPMH;
            this.InfTable.TPMH.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["天棚抹灰确定定额"];
            this.QDQDBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["天棚类型确定清单"];
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
                    string strQDWhere = string.Format("TPLB = '天棚抹灰' ");
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

                    if (!string.IsNullOrEmpty(toString(drCurrent["SJLX"])))
                    {
                        strDEWhere += string.Format("and SJLX='{0}'", toString(drCurrent["SJLX"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["JC"])))
                    {
                        strDEWhere += string.Format("and JC='{0}'", toString(drCurrent["JC"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["PHBSJZL"])))
                    {
                        strDEWhere += string.Format("and SJ='{0}'", toString(drCurrent["PHBSJZL"]));
                    }

                    this.QDDEBindingSource.Filter = strDEWhere;

                    foreach (DataRowView item in this.QDDEBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        row["DEBH"] = item["DEBH"];
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        if (item["GCLXS"].Equals("K*H/100000000"))
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
            if (!string.IsNullOrEmpty(drCurrent["SJLX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".砂浆类型：" + drCurrent["SJLX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".基层：" + drCurrent["JC"];
            }
            if (!string.IsNullOrEmpty(drCurrent["PHBSJZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".配合比、砂浆种类：" + drCurrent["PHBSJZL"];
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
                case "SJLX":

                    popControl1.DataSource = this.QDDEBindingSource;
                    QDDEBindingSource.Filter = "";

                    //截断字符串 并 去重复
                    popControl1.DataSource = this.RemoveRepeat(this.strToTable(QDDEBindingSource, "SJLX", ','), "SJLX");
                    popControl1.ColName = new string[] { "砂浆类型|SJLX|SJLX" };

                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "JC", "PHBSJZL" };
                    popControl1.bind();
                    break;
                case "JC":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" SJLX = '{0}' and JC is not null", toString(currRow["SJLX"]));
                    popControl1.ColName = new string[] { "基层|JC|JC" };


                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "PHBSJZL" };
                    popControl1.bind();
                    break;
                case "PHBSJZL":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format("SJLX = '{0}' and ( JC is null or JC = '{1}') and SJ is not null", toString(currRow["SJLX"]), toString(currRow["JC"]));
                    popControl1.ColName = new string[] { "配合比、砂浆种类|SJ|PHBSJZL" };

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
                    foreach (string item in this.SZBWrepositoryItemComboBox.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.SZBWrepositoryItemComboBox.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            this.QDDEBindingSource.Filter = string.Format("SJLX = '{0}' and ( JC is null or JC = '{1}') and SJ is not null"
                                                        , toString(currRow["SJLX"]), toString(currRow["JC"]));

            //当可以确定唯一配合比、砂浆种类时  自动显示
            if (QDDEBindingSource.Count==1)
            {
                currRow.Row["PHBSJZL"] = (QDDEBindingSource.Current as DataRowView).Row["SJ"];
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
                checkMess.Add("砂浆类型");
                CheckColl.Add("SJLX");
                //点击确定清单前   判断必填项
                this.QDDEBindingSource.Filter = string.Format(" SJLX = '{0}'", toString(currRow["SJLX"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format(" SJLX = '{0}' and JC is  null", toString(currRow["SJLX"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("基层");
                        CheckColl.Add("JC");
                    }
                }
                this.QDDEBindingSource.Filter = string.Format("SJLX = '{0}' and ( JC is null or JC = '{1}')", toString(currRow["SJLX"]), toString(currRow["JC"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format("SJLX = '{0}' and ( JC is null or JC = '{1}') and SJ is null", toString(currRow["SJLX"]), toString(currRow["JC"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("配合比、砂浆种类");
                        CheckColl.Add("PHBSJZL");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}
