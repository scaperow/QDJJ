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
    public partial class SWGCForm : BaseUI
    {
        /// <summary>
        /// 
        /// </summary>
        public SWGCForm()
        {
            InitializeComponent();
        }
        public SWGCForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }


        private void SWGCForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.SWGC;
            this.InfTable.SWGC.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.SWGCFLBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["室外工程分类"];
            this.QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["室外工程确定定额"];
            this.QDQDBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["室外工程清单"];
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
                    string strQDWhere = string.Format("GCFL = '{0}' and (GCCL is null or GCCL like '%,{1},%')", toString(drCurrent["FL"]), toString(drCurrent["CLMCZL"]));
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

                    if (!string.IsNullOrEmpty(toString(drCurrent["FL"])))
                    {
                        strDEWhere += string.Format("and GCFL='{0}'", toString(drCurrent["FL"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["CLMCZL"])))
                    {
                        strDEWhere += string.Format("and CLFL='{0}'", toString(drCurrent["CLMCZL"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["HDLJFS"])))
                    {
                        strDEWhere += string.Format("and HD='{0}'", toString(drCurrent["HDLJFS"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["GJ"])))
                    {
                        strDEWhere += string.Format("and GJ='{0}'", toString(drCurrent["GJ"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["DCZL"])))
                    {
                        strDEWhere += string.Format("and DC='{0}'", toString(drCurrent["DCZL"]));
                    }

                    QDDEBindingSource.Filter = strDEWhere;

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
            if (!string.IsNullOrEmpty(drCurrent["FL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".室外工程分类：" + drCurrent["FL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CLMCZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".材料名称种类：" + drCurrent["CLMCZL"] ;
            }
            if (!string.IsNullOrEmpty(drCurrent["HDLJFS"].ToString()) )
            {
                strContent += "\r\n" + (++i) + ".厚度：" + drCurrent["HDLJFS"] +"cm" ;
            }
            if (!string.IsNullOrEmpty(drCurrent["GJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".管径："+ drCurrent["GJ"] +"mm";
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

                    SWGCFLBindingSource.Filter = "";
                    popControl1.DataSource = this.SWGCFLBindingSource;

                    popControl1.ColName = new string[] { "分类|GCFL|FL" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "CLMCZL", "HDLJFS", "GJ", "DCZL" };
                    popControl1.bind();
                    break;
                case "CLMCZL":

                    this.SWGCFLBindingSource.Filter = string.Format(" GCFL = '{0}' and CLFL is not null ", toString(currRow["FL"]));

                    DataRowView dataRowView = SWGCFLBindingSource.Current as DataRowView;
                    //去重复
                    popControl1.DataSource = strToTable(SWGCFLBindingSource, "CLFL",',');
                    popControl1.ColName = new string[] { "材料名称种类|CLFL|CLMCZL" };


                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "HDLJFS", "GJ" };
                    popControl1.bind();
                    break;
                case "HDLJFS":

                    this.QDDEBindingSource.Filter = string.Format(" (CLFL is null or CLFL = '{0}') and HD is not null", toString(currRow["CLMCZL"]));
                    //去重复
                    DataTable dt = QDDEBindingSource.DataSource as DataTable;
                    dt = dt.DefaultView.ToTable(true, "HD");
                    popControl1.DataSource = dt;

                    popControl1.ColName = new string[] { "厚度（cm）、连接方式|HD|HDLJFS" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GJ" };
                    popControl1.bind();
                    break;
                case "GJ":

                    this.QDDEBindingSource.Filter = string.Format(" (CLFL is null or CLFL = '{0}') and (HD is null or HD ='{1}')  and GJ is not null", toString(currRow["CLMCZL"]), toString(currRow["HDLJFS"]));
                    popControl1.DataSource = this.QDDEBindingSource;
                    popControl1.ColName = new string[] { "管径（mm）|GJ|GJ" };
                    popControl1.bind();
                    break;
                case "DCZL":

                    this.QDDEBindingSource.Filter = string.Format(" GCFL = '{0}' and DC is not null ", toString(currRow["FL"]));
                    popControl1.DataSource = this.QDDEBindingSource;
                    popControl1.ColName = new string[] { "垫层种类|DC|DCZL" };
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

            //当可以确定唯一清单时   修正当前行单位
            DataRowView drCurrent = bindingSource1.Current as DataRowView;
            this.QDQDBindingSource.Filter = string.Format("GCFL = '{0}' and (GCCL is null or GCCL like '%,{1},%')", toString(drCurrent["FL"]), toString(drCurrent["CLMCZL"]));
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
                checkMess.Add("分类");
                CheckColl.Add("FL");
                //点击确定清单前   判断必填项
                this.SWGCFLBindingSource.Filter = string.Format(" GCFL = '{0}'", toString(currRow["FL"]));
                if (0 < SWGCFLBindingSource.Count)
                {
                    this.SWGCFLBindingSource.Filter = string.Format(" GCFL = '{0}' and CLFL is  null ", toString(currRow["FL"]));
                    if (0 == SWGCFLBindingSource.Count)
                    {
                        checkMess.Add("材料名称种类");
                        CheckColl.Add("CLMCZL");
                    }
                }
                this.QDDEBindingSource.Filter = string.Format("GCFL ='{0}' and CLFL is null or CLFL = '{1}'", toString(currRow["FL"]), toString(currRow["CLMCZL"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format("GCFL ='{0}' and CLFL is null or CLFL = '{1}' and HD is null", toString(currRow["FL"]), toString(currRow["CLMCZL"]));
                    if (0 == QDDEBindingSource.Count)
                    {
                        checkMess.Add("厚度（cm）、连接方式");
                        CheckColl.Add("HDLJFS");
                    }
                }
                this.QDDEBindingSource.Filter = string.Format("GCFL ='{0}' and  (CLFL is null or CLFL = '{1}') and (HD is null or HD ='{2}')", toString(currRow["FL"]), toString(currRow["CLMCZL"]), toString(currRow["HDLJFS"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format("GCFL ='{0}' and  (CLFL is null or CLFL = '{1}') and (HD is null or HD ='{2}')  and GJ is  null", toString(currRow["FL"]), toString(currRow["CLMCZL"]), toString(currRow["HDLJFS"]));
                    if (0 == QDDEBindingSource.Count)
                    {
                        checkMess.Add("管径(mm)");
                        CheckColl.Add("GJ");
                    }
                }
                this.QDDEBindingSource.Filter = string.Format(" GCFL = '{0}'  ", toString(currRow["FL"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format(" GCFL = '{0}' and DC is  null ", toString(currRow["FL"]));
                    if (0 == QDDEBindingSource.Count)
                    {
                        checkMess.Add("垫层种类");
                        CheckColl.Add("DCZL");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}
