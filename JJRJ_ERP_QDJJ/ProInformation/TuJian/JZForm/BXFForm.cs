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
    public partial class BXFForm : BaseUI
    {
        public BXFForm()
        {
            InitializeComponent();
        }
        public BXFForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void BXFForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();
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
                this.ArrCheckMess = new string[] { "变形缝部位", "材料种类" };
                this.ArrCheckColl = new string[] { "BXFBW", "CLZL" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.BXFQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["变形缝确定清单"];
            this.BXFQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["变形缝确定定额"];
            this.BXFBWBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["变形缝部位"];
            this.bindingSource1.DataSource = InfTable.BXF;///变形缝
            this.InfTable.BXF.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//变形缝
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
                    string strQDWhere = string.Format("BWMC like '%,{0},%'", drCurrent["BXFBW"]);

                    this.BXFQDQDBindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.BXFQDQDBindingSource.Count)
                    {
                        DataRowView view = this.BXFQDQDBindingSource[0] as DataRowView;
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
                    this.BXFQDQDBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    if (isAdd)
                    {
                        this.BXFQDDEBindingSource.Filter = string.Format("BWMC like '%,{0},%' and CLZL = '{1}'", drCurrent["BXFBW"], drCurrent["CLZL"]);
                        foreach (DataRowView item in this.BXFQDDEBindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            row["XS"] = item["GCLXS"];
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
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
            if (!string.IsNullOrEmpty(drCurrent["BXFBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".变形缝部位：" + drCurrent["BXFBW"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CLZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".材料种类：" + drCurrent["CLZL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FK"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".缝宽：" + drCurrent["FK"] + "(mm)";
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
            if (e.Column.FieldName.Equals("BXFBW"))
            {
                popControl1.DataSource = BXFBWBindingSource;

                popControl1.ColName = new string[] { "变形缝部位|BWMC|BXFBW" };

                //清空材料种类 数据
                popControl1.RemoveDefaultColName = new string[] { "CLZL" };
                popControl1.bind();
            }
            if(e.Column.FieldName.Equals("CLZL"))
            {
                popControl1.DataSource = BXFQDDEBindingSource;
                this.BXFQDDEBindingSource.Filter = string.Format(" BWMC like '%,{0},%' and CLZL is not null", currRow["BXFBW"]);
                popControl1.ColName = new string[] { "材料种类|CLZL|CLZL" };
                popControl1.bind();
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