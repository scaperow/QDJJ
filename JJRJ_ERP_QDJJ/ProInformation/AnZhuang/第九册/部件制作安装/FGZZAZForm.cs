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
    public partial class FGZZAZForm : BaseUI
    {
        public FGZZAZForm()
        {
            InitializeComponent();
        }

        private void FGZZAZForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.风管制作安装;
            this.InfTable.风管制作安装.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.FGQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["风管确定定额"];
            this.AZQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["安装确定清单"];
            this.GDSZBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["高度设置"];
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
            //必填性验证
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
                    string strQDWhere = string.Format("MC like '%{0}%'", drCurrent["CZ"]);
                    this.AZQDQDBindingSource.Filter = strQDWhere;
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
                    StringBuilder strString = new StringBuilder(string.Format(" CZ = '{0}'", drCurrent["CZ"]));
                    strString.Append(string.IsNullOrEmpty(toString(drCurrent["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", drCurrent["XZ"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["JKXS"])) ? " and JKXS is null" : string.Format(" and JKXS='{0}'", drCurrent["JKXS"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["BWTGSJYQ"])) ? " and SJYQ is null" : string.Format(" and SJYQ='{0}'", drCurrent["BWTGSJYQ"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["BCHD"])) ? " and BCHD is null" : string.Format(" and BCHD='{0}'", drCurrent["BCHD"]))
                             .Append(string.IsNullOrEmpty(toString(drCurrent["ZCHZJ"])) ? " and ZCZJ is null" : string.Format(" and ZCZJ='{0}'", drCurrent["ZCHZJ"]));

                    this.FGQDDEBindingSource.Filter = strString.ToString();

                    foreach (DataRowView item in this.FGQDDEBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        this.GDSZBindingSource.Filter = " SYFW = '通风空调' and BTMS='距楼地面'";
                        DataRowView drvGdsz = GDSZBindingSource.Current as DataRowView;
                        row["DEBH"] = drvGdsz == null ? item["DEBH"] : toString(item["DEBH"]) + " " + toString(drvGdsz["XS"]);
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
            if (!string.IsNullOrEmpty(drCurrent["CZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".风管材质：" + drCurrent["CZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["XZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".形状：" + drCurrent["XZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JKXS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".接口形式：" + drCurrent["JKXS"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWTGSJYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温套管设计要求：" + drCurrent["BWTGSJYQ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BCHD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".板材厚度：" + drCurrent["BCHD"] + "mm";
            }
            if (!string.IsNullOrEmpty(drCurrent["ZCHZJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".周长或直径：" + drCurrent["ZCHZJ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZGD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".操作高度：" + drCurrent["CZGD"];
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
            StringBuilder strString = null;
            switch (e.Column.FieldName)
            {
                case "CZ":
                    this.FGQDDEBindingSource.Filter = "CZ is not null";
                    popControl1.DataSource = RemoveRepeat(FGQDDEBindingSource, "CZ");

                    popControl1.ColName = new string[] { "材质|CZ|CZ" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "XZ", "JKXS", "BWTGSJYQ", "BCHD", "ZCHZJ" };
                    popControl1.bind();
                    break;
                case "XZ":
                    this.FGQDDEBindingSource.Filter = string.Format(" CZ = '{0}' and XZ is not null", currRow["CZ"]);
                    popControl1.DataSource = RemoveRepeat(FGQDDEBindingSource, "XZ");

                    popControl1.ColName = new string[] { "形状|XZ|XZ" };
                    //清除依赖项数据  
                    popControl1.RemoveDefaultColName = new string[] { "JKXS", "BWTGSJYQ", "BCHD", "ZCHZJ" };
                    popControl1.bind();
                    break;
                case "JKXS":
                    strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                    strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]))
                        .Append(" and JKXS is not null");
                    this.FGQDDEBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(FGQDDEBindingSource, "JKXS");

                    popControl1.ColName = new string[] { "接口形式|JKXS|JKXS" };
                    //清除依赖项数据  
                    popControl1.RemoveDefaultColName = new string[] {  "BWTGSJYQ", "BCHD", "ZCHZJ" };
                    popControl1.bind();
                    break;
                case "BWTGSJYQ":
                    strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                    strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["JKXS"])) ? " and JKXS is null" : string.Format(" and JKXS='{0}'", currRow["JKXS"]))
                             .Append(" and SJYQ is not null");
                    this.FGQDDEBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(FGQDDEBindingSource, "SJYQ");

                    popControl1.ColName = new string[] { "保温套管设计要求|SJYQ|BWTGSJYQ" };
                    //清除依赖项数据  
                    popControl1.RemoveDefaultColName = new string[] { "BCHD", "ZCHZJ" };
                    popControl1.bind();
                    break;
                case "BCHD":
                    strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                    strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["JKXS"])) ? " and JKXS is null" : string.Format(" and JKXS='{0}'", currRow["JKXS"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["BWTGSJYQ"])) ? " and SJYQ is null" : string.Format(" and SJYQ='{0}'", currRow["BWTGSJYQ"]))
                             .Append(" and BCHD is not null");
                    this.FGQDDEBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(FGQDDEBindingSource, "BCHD");

                    popControl1.ColName = new string[] { "板材厚度（mm）|BCHD|BCHD" };
                    //清除依赖项数据  
                    popControl1.RemoveDefaultColName = new string[] { "ZCHZJ" };
                    popControl1.bind();
                    break;
                case "ZCHZJ":
                    strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                    strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["JKXS"])) ? " and JKXS is null" : string.Format(" and JKXS='{0}'", currRow["JKXS"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["BWTGSJYQ"])) ? " and SJYQ is null" : string.Format(" and SJYQ='{0}'", currRow["BWTGSJYQ"]))
                             .Append(string.IsNullOrEmpty(toString(currRow["BCHD"])) ? " and BCHD is null" : string.Format(" and BCHD='{0}'", currRow["BCHD"]))
                             .Append(" and ZCZJ is not null");
                    this.FGQDDEBindingSource.Filter = strString.ToString();

                    popControl1.DataSource = RemoveRepeat(FGQDDEBindingSource, "ZCZJ");

                    popControl1.ColName = new string[] { "周长或直径（mm）|ZCZJ|ZCHZJ" };
                    popControl1.bind();
                    break;
                case "CZGD":
                    this.GDSZBindingSource.Filter = " SYFW = '通风空调' and BTMS='距楼地面' and GD is not null";
                    popControl1.DataSource = RemoveRepeat(GDSZBindingSource, "GD");

                    popControl1.ColName = new string[] { "操作高度|GD|CZGD" };
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
            string strQDWhere = string.Format("MC like '%{0}%'", drCurrent["CZ"]);
            this.AZQDQDBindingSource.Filter = strQDWhere;
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
                StringBuilder strString = null;
                checkMess.Add("材质");
                CheckColl.Add("CZ");
                //点击确定清单前   判断必填项
                this.FGQDDEBindingSource.Filter = string.Format(" CZ = '{0}'", currRow["CZ"]);
                if (0 < FGQDDEBindingSource.Count)
                {
                    this.FGQDDEBindingSource.Filter = string.Format(" CZ = '{0}' and XZ is null", currRow["CZ"]);
                    if (1 > FGQDDEBindingSource.Count)
                    {
                        checkMess.Add("形状");
                        CheckColl.Add("XZ");
                    }
                }
                strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]));
                FGQDDEBindingSource.Filter = strString.ToString();
                if (0 < FGQDDEBindingSource.Count)
                {
                    strString.Append(" and JKXS is null");
                    FGQDDEBindingSource.Filter = strString.ToString();
                    if (1 > FGQDDEBindingSource.Count)
                    {
                        checkMess.Add("接口形式");
                        CheckColl.Add("JKXS");
                    }
                }
                strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["JKXS"])) ? " and JKXS is null" : string.Format(" and JKXS='{0}'", currRow["JKXS"]));
                FGQDDEBindingSource.Filter = strString.ToString();
                if (0 < FGQDDEBindingSource.Count)
                {
                    strString.Append(" and SJYQ is null");
                    FGQDDEBindingSource.Filter = strString.ToString();
                    if (1 > FGQDDEBindingSource.Count)
                    {
                        checkMess.Add("保温套管设计要求");
                        CheckColl.Add("BWTGSJYQ");
                    }
                }
                strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["JKXS"])) ? " and JKXS is null" : string.Format(" and JKXS='{0}'", currRow["JKXS"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["BWTGSJYQ"])) ? " and SJYQ is null" : string.Format(" and SJYQ='{0}'", currRow["BWTGSJYQ"]));
                FGQDDEBindingSource.Filter = strString.ToString();
                if (0 < FGQDDEBindingSource.Count)
                {
                    strString.Append(" and BCHD is null");
                    FGQDDEBindingSource.Filter = strString.ToString();
                    if (1 > FGQDDEBindingSource.Count)
                    {
                        checkMess.Add("板材厚度");
                        CheckColl.Add("BCHD");
                    }
                }
                strString = new StringBuilder(string.Format(" CZ = '{0}'", currRow["CZ"]));
                strString.Append(string.IsNullOrEmpty(toString(currRow["XZ"])) ? " and XZ is null" : string.Format(" and XZ='{0}'", currRow["XZ"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["JKXS"])) ? " and JKXS is null" : string.Format(" and JKXS='{0}'", currRow["JKXS"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["BWTGSJYQ"])) ? " and SJYQ is null" : string.Format(" and SJYQ='{0}'", currRow["BWTGSJYQ"]))
                         .Append(string.IsNullOrEmpty(toString(currRow["BCHD"])) ? " and BCHD is null" : string.Format(" and BCHD='{0}'", currRow["BCHD"]));
                FGQDDEBindingSource.Filter = strString.ToString();
                if (0 < FGQDDEBindingSource.Count)
                {
                    strString.Append(" and ZCZJ is null");
                    FGQDDEBindingSource.Filter = strString.ToString();
                    if (1 > FGQDDEBindingSource.Count)
                    {
                        checkMess.Add("周长或直径");
                        CheckColl.Add("ZCHZJ");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}