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
    public partial class DDDYForm : BaseUI
    {
        public DDDYForm()
        {
            InitializeComponent();
        }

        private void DDDYForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.打堵洞眼;
            this.InfTable.打堵洞眼.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.QTGPSQDDEBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["其他给排水确定定额"];
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
            //必填项验证
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


                    #region 其他给排水确定定额

                    string strDEWhere = string.Format("FL='{0}' and (TGCZ='{1}' or TGCZ is null) and (GGXH='{2}' or GGXH is null) ", drCurrent["FL"], drCurrent["JCCZ"], drCurrent["DYZJ"]);

                    this.QTGPSQDDEBindingSource.Filter = strDEWhere;

                    foreach (DataRowView item in this.QTGPSQDDEBindingSource)
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
            if ("打洞眼".Equals(toString(drCurrent["FL"])))
            {
                if (!string.IsNullOrEmpty(drCurrent["JCCZ"].ToString()))
                {
                    strContent += "\r\n" + (++i) + "基层材质：" + drCurrent["JCCZ"];
                }
                if (!string.IsNullOrEmpty(drCurrent["DYZJ"].ToString()))
                {
                    strContent += "\r\n" + (++i) + ".洞眼直径：" + drCurrent["DYZJ"] + "mm以内";
                }
                strContent += "\r\n" + "【工程内容】";
                strContent += "\r\n" + "定位、打眼、清理渣土";
            }
            if ("堵洞眼".Equals(toString(drCurrent["FL"])))
            {
                if (!string.IsNullOrEmpty(drCurrent["DYZJ"].ToString()))
                {
                    strContent += "\r\n" + drCurrent["DYZJ"];
                }
                strContent += "\r\n" + "【工程内容】";
                strContent += "\r\n" + "清理、调运砂浆、填塞砂浆、抹灰找平、刷浆、洒水湿润、罩面压光";
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
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FL", typeof(string));
                    DataRow dr1 = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    dr1["FL"] = "打洞眼";
                    dr2["FL"] = "堵洞眼";
                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);
                    popControl1.DataSource = dt;


                    popControl1.ColName = new string[] { "分类|FL|FL" };
                    popControl1.RemoveDefaultColName = new string[] { "JCCZ", "DYZJ" };
                    popControl1.bind();
                    break;
                case "JCCZ":

                    this.QTGPSQDDEBindingSource.Filter = string.Format("FL ='{0}'", currRow["FL"]);
                    popControl1.DataSource = RemoveRepeat(QTGPSQDDEBindingSource, "TGCZ");

                    popControl1.ColName = new string[] { "分类|TGCZ|JCCZ" };
                    popControl1.RemoveDefaultColName = new string[] { "DYZJ" };
                    popControl1.bind();
                    break;
                case "DYZJ":

                    this.QTGPSQDDEBindingSource.Filter = string.Format("FL ='{0}' and ( TGCZ ='{1}' or TGCZ is null)", currRow["FL"], currRow["JCCZ"]);
                    popControl1.DataSource = RemoveRepeat(QTGPSQDDEBindingSource, "GGXH");

                    popControl1.ColName = new string[] { "分类|GGXH|DYZJ" };
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
                this.QTGPSQDDEBindingSource.Filter = string.Format("FL ='{0}'", currRow["FL"]);
                if (0 < QTGPSQDDEBindingSource.Count)
                {
                    this.QTGPSQDDEBindingSource.Filter = string.Format("FL ='{0}' and TGCZ is null", currRow["FL"]);
                    if (1 > QTGPSQDDEBindingSource.Count)
                    {
                        checkMess.Add("基层材质");
                        CheckColl.Add("JCCZ");
                    }
                }
                checkMess.Add("洞眼直径");
                CheckColl.Add("DYZJ");
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}