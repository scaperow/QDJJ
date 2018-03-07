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
    public partial class ZCPGBCForm : BaseUI
    {
        public ZCPGBCForm()
        {
            InitializeComponent();
        }

        private void ZCPGBCForm_Load(object sender, EventArgs e)
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
                ArrCheckMess = new string[] { "凿槽类别", "结构类别", "槽沟尺寸宽×深" };
                ArrCheckColl = new string[] { "ZCLB", "JGLB","CGCCKS" };
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.凿槽刨沟补槽;
            this.InfTable.凿槽刨沟补槽.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.ZCPGBCBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["凿槽_刨沟_补槽"];
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


                    #region 凿槽、刨沟、补槽

                    string strDEWhere = string.Format("FL='{0}' and ZCLB='{1}' and JGLB='{2}' and CGCC='{3}' "
                                                    , drCurrent["FL"], drCurrent["ZCLB"], drCurrent["JGLB"], drCurrent["CGCCKS"]);

                    this.ZCPGBCBindingSource.Filter = strDEWhere;

                    foreach (DataRowView item in this.ZCPGBCBindingSource)
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
            string strKey = "项目特征,工程内容";
            string strContent = "【项目特征】";
            int i = 0;
            if (!string.IsNullOrEmpty(drCurrent["ZCLB"].ToString()))
            {
                strContent += "\r\n" + (++i) + "凿槽类别：" + drCurrent["ZCLB"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JGLB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".结构类型：" + drCurrent["JGLB"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CGCCKS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".槽沟尺寸宽×深：" + drCurrent["CGCCKS"]+"mm";
            }
            strContent += "\r\n" + "【工程内容】";
            strContent += "\r\n" + "量尺寸、放线、凿槽、刨沟、补填砂浆";
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
                case "ZCLB":

                    this.ZCPGBCBindingSource.Filter = string.Format("FL ='{0}'", currRow["FL"]);
                    popControl1.DataSource = RemoveRepeat(ZCPGBCBindingSource, "ZCLB");

                    popControl1.ColName = new string[] { "分类|ZCLB|ZCLB" };
                    popControl1.RemoveDefaultColName = new string[] { "JGLB","CGCCKS" };
                    popControl1.bind();
                    break;
                case "JGLB":

                    this.ZCPGBCBindingSource.Filter = string.Format("FL ='{0}' and ZCLB ='{1}'", currRow["FL"], currRow["ZCLB"]);
                    popControl1.DataSource = RemoveRepeat(ZCPGBCBindingSource, "JGLB");

                    popControl1.ColName = new string[] { "分类|JGLB|JGLB" };
                    popControl1.RemoveDefaultColName = new string[] {"CGCCKS" };
                    popControl1.bind();
                    break;
                case "CGCCKS":

                    this.ZCPGBCBindingSource.Filter = string.Format("FL ='{0}' and ZCLB ='{1}' and JGLB='{2}'", currRow["FL"], currRow["ZCLB"], currRow["JGLB"]);
                    popControl1.DataSource = RemoveRepeat(ZCPGBCBindingSource, "CGCC");

                    popControl1.ColName = new string[] { "分类|CGCC|CGCCKS" };
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
            string strQDWhere = string.Format("FL  like '%,{0},%'", toString(drCurrent["FL"]));
            this.GPSQDQDBindingSource.Filter = strQDWhere;
            if (0 < GPSQDQDBindingSource.Count)
            {
                DataRowView view = this.GPSQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
    }
}