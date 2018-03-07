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
    public partial class WSQJForm : BaseUI
    {
        public WSQJForm()
        {
            InitializeComponent();
        }

        private void WSQJForm_Load(object sender, EventArgs e)
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
                ArrCheckMess = new string[] { "分类" };
                ArrCheckColl = new string[] { "FL" };
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.给排水卫生器具;
            this.InfTable.给排水卫生器具.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.QJQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["器具确定定额"];
            this.GDSZBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["高度设置"];
            this.GPSQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["给排水确定清单"];
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
            if (null == currRow) return;
            base.btnScreenQDBH_Click(sender, e);

            this.QJQDDEBindingSource.Filter = string.Format(" LB = '卫生器具' and FL='{0}' ", toString(currRow["FL"]));
            int iCount = this.QJQDDEBindingSource.Count;
            if (iCount > 0)
            {
                this.QJQDDEBindingSource.Filter = string.Format(" LB = '卫生器具' and FL='{0}' and GGXH is not null", toString(currRow["FL"]));
                if (iCount == this.QJQDDEBindingSource.Count)
                {
                    this.CheckNull("ZZXSGGXH", this.gridView1.Columns["ZZXSGGXH"].Caption);
                }
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
                    string strQDWhere = string.Format("FL like '%,{0},%'", toString(drCurrent["FL"]));
                    this.GPSQDQDBindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.GPSQDQDBindingSource.Count)
                    {
                        DataRowView view = this.GPSQDQDBindingSource[0] as DataRowView;
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
                    this.GPSQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();


                    #region 器具确定定额

                    string strDEWhere = string.Format(" LB='卫生器具' and FL='{0}' and GGXH='{1}' ", drCurrent["FL"], drCurrent["ZZXSGGXH"]);

                    this.QJQDDEBindingSource.Filter = strDEWhere;

                    foreach (DataRowView item in this.QJQDDEBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();

                        this.GDSZBindingSource.Filter = string.Format(" BTMS ='操作高度'and GD='{0}'", drCurrent["AZGD"]);
                        DataRowView drv = GDSZBindingSource.Current as DataRowView;

                        if (drv != null && !string.IsNullOrEmpty(toString(drv["XS"])))
                        {
                            row["DEBH"] = toString(item["DEBH"]) + " " + toString(drv["XS"]);
                        }
                        else
                        {
                            row["DEBH"] = item["DEBH"];
                        }
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
            if (!string.IsNullOrEmpty(drCurrent["FL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".卫生器具分类：" + drCurrent["FL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZZXSGGXH"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".组装形式、规格、型号：" + drCurrent["ZZXSGGXH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["AZGD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".安装高度：" + drCurrent["AZGD"];
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

                    QJQDDEBindingSource.Filter = " LB='卫生器具' ";
                    DataRowView qjqdde = QJQDDEBindingSource.Current as DataRowView;
                    popControl1.DataSource = RemoveRepeat(qjqdde.DataView.Table, "FL");

                    popControl1.ColName = new string[] { "分类|FL|FL" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "ZZXSGGXH" };
                    popControl1.bind();
                    break;
                case "ZZXSGGXH":

                    popControl1.DataSource = this.QJQDDEBindingSource;
                    this.QJQDDEBindingSource.Filter = string.Format(" LB = '卫生器具' and FL='{0}' ", toString(currRow["FL"]));

                    popControl1.ColName = new string[] { "分类|GGXH|ZZXSGGXH" };
                    popControl1.bind();
                    break;
                case "AZGD":

                    popControl1.DataSource = this.GDSZBindingSource;
                    this.GDSZBindingSource.Filter = " SYFW = '给排水' and BTMS ='操作高度'";

                    popControl1.ColName = new string[] { "安装高度|GD|AZGD" };
                    popControl1.bind();
                    break;
            }
        }

        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;

            //当可以确定唯一清单时   修正当前行单位
            string strQDWhere = string.Format("FL like '%,{0},%'", toString(drCurrent["FL"]));
            this.GPSQDQDBindingSource.Filter = strQDWhere;
            if (0 < GPSQDQDBindingSource.Count)
            {
                DataRowView view = this.GPSQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
    }
}
