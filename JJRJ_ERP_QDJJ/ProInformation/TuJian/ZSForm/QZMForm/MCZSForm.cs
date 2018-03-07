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
    public partial class MCZSForm : BaseUI
    {
        public MCZSForm()
        {
            InitializeComponent();
        }
        public MCZSForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void MCZSForm_Load(object sender, EventArgs e)
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
                ArrCheckColl = new string[] { "bl" };
                ArrCheckMess = new string[] { "筛选规格！" };
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.bindingSource1.DataSource = InfTable.MCZS;
            this.InfTable.MCZS.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["天棚面层确定定额"];
            this.QDQDBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["墙柱面确定清单"];
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
            ScreenWDBH(checkInsert());
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
                    string checkToInsert = checkCanInsert();

                    #region 确定清单
                    //（室外工程清单）

                    string qd_fl = "1<>1";
                    switch (checkToInsert)
                    {
                        case "1":
                            qd_fl ="龙骨";
                            break;
                        case "2":
                            qd_fl ="隔断";
                            break;
                        case "3":
                            qd_fl ="柱龙骨及饰面";
                            break;
                    }
                    string strQDWhere = string.Format("QZMLB = '面层装饰' and FL like '%,{0},%'", qd_fl);
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
                    string strDEWhere = " ";

                    switch (checkToInsert)
                    {
                        case "1":
                            if (drCurrent["LGCLPZGG"]!=null&&!string.IsNullOrEmpty(drCurrent["LGCLPZGG"].ToString()))
                            {
                                strDEWhere = string.Format("TPLB ='面层装饰' and TPFL ='龙骨' and GGCZ ='{0}'", drCurrent["LGCLPZGG"].ToString());
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
                            }
                            if (drCurrent["JCCLPZGG"] != null && !string.IsNullOrEmpty(drCurrent["JCCLPZGG"].ToString()))
                            {
                                strDEWhere = string.Format(" TPLB ='面层装饰' and TPFL ='基层' and GGCZ ='{0}'", drCurrent["JCCLPZGG"].ToString());
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
                            }
                            if (drCurrent["MCCLPZGG"] != null && !string.IsNullOrEmpty(drCurrent["MCCLPZGG"].ToString()))
                            {
                                strDEWhere = string.Format("TPLB ='面层装饰' and TPFL ='面层' and GGCZ ='{0}'", drCurrent["MCCLPZGG"].ToString());
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
                            }
                            break;

                        case "2":

                            if (drCurrent["GDCLPZGG"] != null && !string.IsNullOrEmpty(drCurrent["GDCLPZGG"].ToString()))
                            {
                                strDEWhere = string.Format("TPLB ='面层装饰' and TPFL ='隔断' and GGCZ ='{0}'", drCurrent["GDCLPZGG"].ToString());
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
                            }
                            break;

                        case "3":

                            if (drCurrent["ZLGJSMPZGG"] != null && !string.IsNullOrEmpty(drCurrent["ZLGJSMPZGG"].ToString()))
                            {
                                strDEWhere = string.Format("TPLB ='面层装饰' and TPFL ='柱龙骨及饰面' and GGCZ ='{0}'", drCurrent["ZLGJSMPZGG"].ToString());
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
                            }
                            break;
                    }
                    //清空筛选条件
                    this.QDDEBindingSource.Filter = "";


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
            if (!string.IsNullOrEmpty(drCurrent["LGCLPZGG"].ToString()) )
            {
                strContent += "\r\n" + (++i) + ".龙骨材料品种、规格：" + drCurrent["LGCLPZGG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JCCLPZGG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".基层材料品种、规格：" + drCurrent["JCCLPZGG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["MCCLPZGG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".面层材料品种、规格：" + drCurrent["MCCLPZGG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GDCLPZGG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".隔断材料品种、规格：" + drCurrent["GDCLPZGG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZLGJSMPZGG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".柱龙骨及饰面品种、规格：" + drCurrent["ZLGJSMPZGG"];
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
            DataTable dt = QDDEBindingSource.DataSource as DataTable;
            switch (e.Column.FieldName)
            {
                case "LGCLPZGG":

                        popControl1.DataSource = this.QDDEBindingSource;
                        QDDEBindingSource.Filter = "TPLB='面层装饰'  and TPFL = '龙骨'";

                        //去重复
                        popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                        popControl1.ColName = new string[] { "龙骨材料品种、规格|GGCZ|LGCLPZGG" };

                        popControl1.RemoveDefaultColName = new string[] { "GDCLPZGG", "ZLGJSMPZGG" };
                        popControl1.bind();
                    
                    break;

                case "JCCLPZGG":
                    
                        popControl1.DataSource = this.QDDEBindingSource;
                        QDDEBindingSource.Filter = "TPLB='面层装饰'  and TPFL = '基层'";

                        //去重复
                        popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                        popControl1.ColName = new string[] { "基层材料品种、规格|GGCZ|JCCLPZGG" };

                        popControl1.RemoveDefaultColName = new string[] { "GDCLPZGG", "ZLGJSMPZGG" };
                        popControl1.bind();
                    
                    break;
                case "MCCLPZGG":
           
                        popControl1.DataSource = this.QDDEBindingSource;
                        QDDEBindingSource.Filter = "TPLB='面层装饰'  and TPFL = '面层'";

                        //去重复
                        popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                        popControl1.ColName = new string[] { "面层材料品种、规格|GGCZ|MCCLPZGG" };

                        popControl1.RemoveDefaultColName = new string[] { "GDCLPZGG", "ZLGJSMPZGG" };
                        popControl1.bind();
                    
                    break;
                case "GDCLPZGG":
                
                        popControl1.DataSource = this.QDDEBindingSource;
                        QDDEBindingSource.Filter = "TPLB='面层装饰'  and TPFL = '隔断'";

                        //去重复
                        popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                        popControl1.ColName = new string[] { "隔断材料品种、规格|GGCZ|GDCLPZGG" };

                        popControl1.RemoveDefaultColName = new string[] { "LGCLPZGG", "JCCLPZGG", "MCCLPZGG", "ZLGJSMPZGG" };
                        popControl1.bind();
                    
                    break;
                case "ZLGJSMPZGG":
                   
                        popControl1.DataSource = this.QDDEBindingSource;
                        QDDEBindingSource.Filter = "TPLB='面层装饰'  and TPFL = '柱龙骨及饰面'";


                        //去重复
                        popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                        popControl1.ColName = new string[] { "柱龙骨及饰面|GGCZ|ZLGJSMPZGG" };

                        popControl1.RemoveDefaultColName = new string[] { "LGCLPZGG", "JCCLPZGG", "MCCLPZGG", "GDCLPZGG" };
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
            checkNull();
        }

        private string checkCanInsert()
        {
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
            if (drCurrent["LGCLPZGG"] != null && !string.IsNullOrEmpty(drCurrent["LGCLPZGG"].ToString())
               || drCurrent["JCCLPZGG"] != null && !string.IsNullOrEmpty(drCurrent["JCCLPZGG"].ToString())
               || drCurrent["MCCLPZGG"] != null && !string.IsNullOrEmpty(drCurrent["MCCLPZGG"].ToString()))
            {
                return "1";
            }
            else if(drCurrent["GDCLPZGG"] != null && !string.IsNullOrEmpty(drCurrent["GDCLPZGG"].ToString()))
            {
                return "2";
            }
            else if (drCurrent["ZLGJSMPZGG"] != null && !string.IsNullOrEmpty(drCurrent["ZLGJSMPZGG"].ToString()))
            {
                return "3";
            }
            else
            {
                return "0";
            }
        }
        private bool checkInsert()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if ((currRow["LGCLPZGG"] != null && !string.IsNullOrEmpty(currRow["LGCLPZGG"].ToString()))
                || (currRow["JCCLPZGG"] != null && !string.IsNullOrEmpty(currRow["JCCLPZGG"].ToString()))
                || (currRow["MCCLPZGG"] != null && !string.IsNullOrEmpty(currRow["MCCLPZGG"].ToString()))
                || (currRow["GDCLPZGG"] != null && !string.IsNullOrEmpty(currRow["GDCLPZGG"].ToString()))
                || (currRow["ZLGJSMPZGG"] != null && !string.IsNullOrEmpty(currRow["ZLGJSMPZGG"].ToString())))
            {
                return true;
            }
            return false;
        }
        private void checkNull()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (checkInsert())
            {
                currRow["bl"] = "ok";
            }
            else
            {
                currRow["bl"] = null;
            }

        }
    }
}
