using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class LXXMForm : BaseUI
    {
        public LXXMForm()
        {
            InitializeComponent();
        }
        public LXXMForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void LXXMForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
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
            this.bindingSource1.DataSource = InfTable.LXXM;//零星项目
            this.InfTable.LXXM.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//零星项目

            QDQDindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["零星项目确定清单"];
            QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["零星项目确定定额"];

            LXXMCLLBBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["零星项目材料类别"];
            //LXXMJCBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["零星项目基层"];

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
            //添加验证必填项
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
                    //从输入获取MCFL（零星分类）
                    string strQDWhere = string.Format("LXFL = '{0}'", toString(drCurrent["FL"]));

                    QDQDindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.QDQDindingSource.Count)
                    {
                        DataRowView view = this.QDQDindingSource[0] as DataRowView;
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
                    this.QDQDindingSource.Filter = "";///清单取完以后  条件置回空；


                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    //确定定额
                    string strWhere = "1=1 ";

                    if (!string.IsNullOrEmpty(toString(drCurrent["FL"])))
                    {
                        strWhere += string.Format(" and LXFL = '{0}'", toString(drCurrent["FL"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["CLLB"])))
                    {
                        strWhere += string.Format(" and CLLB = '{0}'", toString(drCurrent["CLLB"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["jc"])))
                    {
                        strWhere += string.Format(" and JC = '{0}'", toString(drCurrent["JC"]));
                    }
                    if (!string.IsNullOrEmpty(toString(drCurrent["ZTLX"])))
                    {
                        strWhere += string.Format(" and NTLX = '{0}'", toString(drCurrent["ZTLX"]));
                    }

                    //筛选条件
                    QDDEBindingSource.Filter = strWhere;


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
            if (!string.IsNullOrEmpty(drCurrent["JC"].ToString()) || !string.IsNullOrEmpty(drCurrent["FL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".分类：" + drCurrent["FL"] + "　" + drCurrent["JC"] ;
            }
            if (!string.IsNullOrEmpty(drCurrent["CLLB"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".材料类别：" + drCurrent["CLLB"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZTLX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".零星项目粘贴类型：" + drCurrent["ZTLX"];
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
        #endregion
        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "FL":
                    popControl1.DataSource = this.QDQDindingSource;
                    QDQDindingSource.Filter = "";
                    popControl1.ColName = new string[] { "分类|LXFL|FL" };

                    //清空材料类别、黏贴类型 数据
                    popControl1.RemoveDefaultColName = new string[] { "CLLB", "JC", "ZTLX" };
                    popControl1.bind();
                    break;
                case "CLLB":
                    popControl1.DataSource = this.LXXMCLLBBindingSource;
                    LXXMCLLBBindingSource.Filter = string.Format(" LXFL = '{0}'", currRow["FL"]);
                    popControl1.ColName = new string[] { "材料类别|CLLB|CLLB" };

                    //清空基层、黏贴类型 数据
                    popControl1.RemoveDefaultColName = new string[] { "JC", "ZTLX" };
                    popControl1.bind();
                    break;
                case "JC":

                    popControl1.DataSource = this.QDDEBindingSource;

                    QDDEBindingSource.Filter = string.Format("LXFL ='{0}' and CLLB = '{1}'", currRow["FL"], currRow["CLLB"]);
                    DataTable dt=QDDEBindingSource.DataSource as DataTable;
                    //去重复
                    popControl1.DataSource = RemoveRepeat(dt, "JC");

                    popControl1.ColName = new string[] { "基层|JC|JC" };

                    //清空黏贴类型、黏贴类型 数据
                    popControl1.RemoveDefaultColName = new string[] { "ZTLX" };
                    popControl1.bind();
                    break;
                case "ZTLX":

                    popControl1.DataSource = this.QDDEBindingSource;

                    QDDEBindingSource.Filter = string.Format("LXFL = '{0}' and (CLLB is null or CLLB = '{1}') and (JC is null or  JC = '{2}') and NTLX is not null", currRow["FL"], currRow["CLLB"], currRow["JC"]);
                    popControl1.ColName = new string[] { "粘贴类型|NTLX|ZTLX" };
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

            this.QDQDindingSource.Filter = string.Format("LXFL = '{0}'", drCurrent["FL"]);
            if (0 < QDQDindingSource.Count)
            {
                DataRowView view = this.QDQDindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        private void checkeArr()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            //判断是否已加载数据行
            if(currRow!=null)
            {
                //点击确定清单前   判断必填项
                List<string> checkMess = new List<string>();
                List<string> CheckColl = new List<string>();
                checkMess.Add("分类");
                CheckColl.Add("FL");


                LXXMCLLBBindingSource.Filter = string.Format(" LXFL = '{0}'", currRow["FL"]);
                if (0 < LXXMCLLBBindingSource.Count)
                {
                    LXXMCLLBBindingSource.Filter = string.Format(" LXFL = '{0}' and CLLB is null", currRow["FL"]);
                    if (1 > LXXMCLLBBindingSource.Count)
                    {
                        checkMess.Add("材料类别");
                        CheckColl.Add("CLLB");
                    }
                }
                QDDEBindingSource.Filter = string.Format("LXFL ='{0}' and CLLB like '%,{1},%'", currRow["FL"], currRow["CLLB"]);
                if (0 < QDDEBindingSource.Count)
                {
                    QDDEBindingSource.Filter = string.Format("LXFL ='{0}' and CLLB like '%,{1},%'  and JC is null ", currRow["FL"], currRow["CLLB"]);
                    if (1 > QDDEBindingSource.Count)
                    {
                        checkMess.Add("基层");
                        CheckColl.Add("JC");
                    }
                }
                QDDEBindingSource.Filter = string.Format("LXFL = '{0}' and (CLLB is null or CLLB = '{1}') and (JC is null or  JC = '{2}')", currRow["FL"], currRow["CLLB"], currRow["JC"]);
                if (0 < QDDEBindingSource.Count)
                {
                    QDDEBindingSource.Filter = string.Format("LXFL = '{0}' and (CLLB is null or CLLB = '{1}') and (JC is null or  JC = '{2}') and NTLX is  null", currRow["FL"], currRow["CLLB"], currRow["JC"]);
                    if (1> QDDEBindingSource.Count)
                    {
                        checkMess.Add("粘贴类型");
                        CheckColl.Add("ZTLX");
                    }
                }
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}