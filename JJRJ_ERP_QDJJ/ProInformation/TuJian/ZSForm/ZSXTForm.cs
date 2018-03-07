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
    public partial class ZSXTForm : BaseUI
    {
        public ZSXTForm()
        {
            InitializeComponent();
        }
        public ZSXTForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void ZSXTForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.ZSXT;
            this.InfTable.ZSXT.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.ZSXTFLBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["装饰线条分类"];
            this.ZSXTNTFSBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["装饰线条粘贴方式"];
            this.QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["装饰线条确定定额"];
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
                    string strQDWhere = string.Format("XTFL like '%,{0},%' ", toString(drCurrent["FL"]));
                    this.ZSXTFLBindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.ZSXTFLBindingSource.Count)
                    {
                        DataRowView view = this.ZSXTFLBindingSource[0] as DataRowView;
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
                    this.ZSXTFLBindingSource.Filter = "";///清单取完以后  条件置回空；
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();


                    //室外工程确定定额

                    string strDEWhere = "1=1 ";

                    if (!string.IsNullOrEmpty(toString(drCurrent["FL"])))
                    {
                        strDEWhere += string.Format("and XTFL='{0}'", toString(drCurrent["FL"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["NTFS"])))
                    {
                        strDEWhere += string.Format("and NTFS='{0}'", toString(drCurrent["NTFS"]));
                    }
                    else
                    {
                        strDEWhere += " and NTFS is Null ";
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["GGCC"])))
                    {
                        strDEWhere += string.Format(" and GGCC='{0}'", toString(drCurrent["GGCC"]));
                    }

                    this.QDDEBindingSource.Filter = strDEWhere;

                    foreach (DataRowView item in this.QDDEBindingSource)
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
                        sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], item["GCLXS"], "", ""));
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
            if (!string.IsNullOrEmpty(drCurrent["FL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".线条分类：" + drCurrent["FL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["NTFS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".粘贴方式：" + drCurrent["NTFS"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GGCC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".规格尺寸：" + drCurrent["GGCC"];
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

                    popControl1.DataSource = this.ZSXTFLBindingSource;
                    ZSXTFLBindingSource.Filter = "";

                    //截断字符串 并 去重复
                    popControl1.DataSource = this.RemoveRepeat(this.strToTable(ZSXTFLBindingSource, "XTFL",','), "XTFL");
                    popControl1.ColName = new string[] { "分类|XTFL|FL" };

                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "NTFS", "GGCC" };
                    popControl1.bind();
                    break;
                case "NTFS":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" XTFL = '{0}' and NTFS is not null", toString(currRow["FL"]));

                    //去重复
                    DataTable dt = this.QDDEBindingSource.DataSource as DataTable;
                    popControl1.DataSource = this.RemoveRepeat(dt, "NTFS");
                    popControl1.ColName = new string[] { "粘贴类型|NTFS|NTFS" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GGCC" };
                    popControl1.bind();
                    break;
                case "GGCC":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" XTFL = '{0}' and ( NTFS is null or NTFS = '{1}') and GGCC is not null", toString(currRow["FL"]), toString(currRow["NTFS"]));
                    popControl1.ColName = new string[] { "规格尺寸|GGCC|GGCC" };

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
                checkMess.Add("分类");
                CheckColl.Add("FL");
                //点击确定清单前   判断必填项
                this.QDDEBindingSource.Filter = string.Format(" XTFL = '{0}'", toString(currRow["FL"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format(" XTFL = '{0}' and NTFS is null", toString(currRow["FL"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("粘贴方式");
                        CheckColl.Add("NTFS");
                    }
                }
                this.QDDEBindingSource.Filter = string.Format("XTFL = '{0}' and (NTFS is null or NTFS ='{1}')", toString(currRow["FL"]), toString(currRow["NTFS"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format("XTFL = '{0}' and (NTFS is null or NTFS ='{1}')  and GGCC is null", toString(currRow["FL"]), toString(currRow["NTFS"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("规格尺寸");
                        CheckColl.Add("GGCC");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}
