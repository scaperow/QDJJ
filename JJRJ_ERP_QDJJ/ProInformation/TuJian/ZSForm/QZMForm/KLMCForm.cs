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
    public partial class KLMCForm : BaseUI
    {
        public KLMCForm()
        {
            InitializeComponent();
        }
        public KLMCForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void KLMCForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.KLMC;
            this.InfTable.KLMC.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["块料面层确定定额"];
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
                    string strQDWhere = string.Format("QZMLB = '块料面层' and FL like '%,{0},%' and CL like '%,{1},%'", toString(drCurrent["MCCLPZ"]), toString(drCurrent["QTCL"]));
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

                    if (!string.IsNullOrEmpty(toString(drCurrent["MCCLPZ"])))
                    {
                        strDEWhere += string.Format("and MCPZ='{0}'", toString(drCurrent["MCCLPZ"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["KLMCGG"])))
                    {
                        strDEWhere += string.Format("and KLGG='{0}'", toString(drCurrent["KLMCGG"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["QTCL"])))
                    {
                        strDEWhere += string.Format("and QTCL='{0}'", toString(drCurrent["QTCL"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["YWJC"])))
                    {
                        strDEWhere += string.Format("and JC='{0}'", toString(drCurrent["YWJC"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["GNTFS"])))
                    {
                        strDEWhere += string.Format("and FS='{0}'", toString(drCurrent["GNTFS"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["TJCHDCLZL"])))
                    {
                        strDEWhere += string.Format("and CLZL ='{0}'", toString(drCurrent["TJCHDCLZL"]));
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
            if (!string.IsNullOrEmpty(drCurrent["MCCLPZ"].ToString()) || !string.IsNullOrEmpty(drCurrent["KLMCGG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".面层材料品种、规格：" + drCurrent["MCCLPZ"] + "　" + drCurrent["KLMCGG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["QTCL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".墙体材料：" + drCurrent["QTCL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["YWJC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".有无基层：" + drCurrent["YWJC"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GNTFS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".挂、粘贴方式：" + drCurrent["GNTFS"];
            }
            if (!string.IsNullOrEmpty(drCurrent["TJCHDCLZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".粘贴厚度、材料种类：" + drCurrent["TJCHDCLZL"];
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
                case "MCCLPZ":

                    popControl1.DataSource = this.QDDEBindingSource;
                    QDDEBindingSource.Filter = "";


                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "MCPZ");
                    popControl1.ColName = new string[] { "面层材料品种|MCPZ|MCCLPZ" };

                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "KLMCGG", "QTCL", "YWJC", "GNTFS", "TJCHDCLZL" };
                    popControl1.bind();
                    break;

                case "KLMCGG":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and KLGG is not null ", toString(currRow["MCCLPZ"]));

                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "KLGG");
                    popControl1.ColName = new string[] { "块料面层规格|KLGG|KLMCGG" };


                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "QTCL", "YWJC", "GNTFS", "TJCHDCLZL" };
                    popControl1.bind();
                    break;
                case "QTCL":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' )  and QTCL is not null"
                                                            , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]));

                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "QTCL");
                    popControl1.ColName = new string[] { "墙体材料|QTCL|QTCL" };


                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "YWJC", "GNTFS", "TJCHDCLZL" };
                    popControl1.bind();
                    break;
                case "YWJC":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' )  and QTCL='{2}' and JC is not null"
                                                            , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]), toString(currRow["QTCL"]));

                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "JC");
                    popControl1.ColName = new string[] { "基层|JC|YWJC" };


                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GNTFS", "TJCHDCLZL" };
                    popControl1.bind();
                    break;
                case "GNTFS":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' ) and QTCL='{2}' and JC ='{3}' and FS is not null"
                        , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]), toString(currRow["QTCL"]), toString(currRow["YWJC"]));

                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "FS");
                    popControl1.ColName = new string[] { "挂、粘贴方式|FS|GNTFS" };


                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "TJCHDCLZL" };
                    popControl1.bind();
                    break;
                case "TJCHDCLZL":

                    popControl1.DataSource = this.QDDEBindingSource;
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' )  and QTCL='{2}' and JC ='{3}' and (FS is null or FS='{4}') and CLZL is not null"
                        , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]), toString(currRow["QTCL"]), toString(currRow["YWJC"]), toString(currRow["GNTFS"]));


                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "CLZL");
                    popControl1.ColName = new string[] { "贴结层厚度、材料种类|CLZL|TJCHDCLZL" };

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

            //当可以确定唯一  粘接层厚度、材料种类 时  自动显示
            this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' )  and QTCL='{2}' and JC ='{3}' and (FS is null or FS='{4}') and CLZL is not null"
                , toString(drCurrent["MCCLPZ"]), toString(drCurrent["KLMCGG"]), toString(drCurrent["QTCL"]), toString(drCurrent["YWJC"]), toString(drCurrent["GNTFS"]));
            if (QDDEBindingSource.Count==1)
            {
                drCurrent.Row["TJCHDCLZL"] = (QDDEBindingSource.Current as DataRowView).Row["CLZL"];
            }



            //当可以确定唯一清单时   修正当前行单位
            string strQDWhere = string.Format("QZMLB = '块料面层' and FL like '%,{0},%' and CL like '%,{1},%'", toString(drCurrent["MCCLPZ"]), toString(drCurrent["QTCL"]));
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
            //块料面层规格

            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            //判断是否已添加数据行
            if (currRow != null)
            {
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                checkMess.Add("面层材料品种");
                CheckColl.Add("MCCLPZ");
                //点击确定清单前   判断必填项
                this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}'", toString(currRow["MCCLPZ"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and KLGG is  null ", toString(currRow["MCCLPZ"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("块料面层规格");
                        CheckColl.Add("KLMCGG");
                    }
                }

                //验证顺序为  列表顺序
                checkMess.Add("墙体材料");
                CheckColl.Add("QTCL");
                checkMess.Add("有无基层");
                CheckColl.Add("YWJC");


                this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' ) and QTCL='{2}' and JC ='{3}'"
                    , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]), toString(currRow["QTCL"]), toString(currRow["YWJC"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' ) and QTCL='{2}' and JC ='{3}' and FS is  null"
                        , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]), toString(currRow["QTCL"]), toString(currRow["YWJC"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("挂、粘贴方式");
                        CheckColl.Add("GNTFS");
                    }
                }
                this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' )  and QTCL='{2}' and JC ='{3}' and FS='{4}'"
                    , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]), toString(currRow["QTCL"]), toString(currRow["YWJC"]), toString(currRow["GNTFS"]));
                if (0 < QDDEBindingSource.Count)
                {
                    this.QDDEBindingSource.Filter = string.Format(" MCPZ = '{0}' and (KLGG is null or KLGG ='{1}' )  and QTCL='{2}' and JC ='{3}' and FS='{4}' and CLZL is null"
                        , toString(currRow["MCCLPZ"]), toString(currRow["KLMCGG"]), toString(currRow["QTCL"]), toString(currRow["YWJC"]), toString(currRow["GNTFS"]));
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("贴结层厚度、材料种类");
                        CheckColl.Add("TJCHDCLZL");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}
