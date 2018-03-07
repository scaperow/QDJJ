using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QTDJ : BaseUI
    {
        public QTDJ()
        {
            InitializeComponent();
        }
        private void QTDJ_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
        }
        #region 字段、属性
        private string _lb = "";
        /// <summary>
        /// 类别
        /// </summary>
        public string LB
        {
            get { return _lb; }
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
                AlwaysExecute();
                base.Parm = value;
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }
        /// <summary>
        /// 当前项
        /// </summary>
        private DataRowView CurrRow
        {
            get
            {
                return this.bindingSource1.Current as DataRowView;
            }
        }
        #endregion

        #region 绑定数据源

        private void AlwaysExecute()
        {
            switch (this.KeyID)
            {
                case 32:
                    this.bindingSource1.DataSource = this.InfTable.普通灯具;
                    this.InfTable.普通灯具.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.普通灯具.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "分类" };
                    this.ArrCheckColl = new string[] { "FL" };
                    this.gridView1.Columns["GGXH"].Caption = "规格、型号";//规格、型号列
                    this.gridView1.Columns["LX"].Visible = false;//类型列
                    this.gridView1.Columns["ZJ"].Visible = false;//直径列
                    this.gridView1.Columns["SYTH"].Visible = false;//示意图号列
                    this._lb = "普通灯具";//类别
                    break;
                case 33:
                    this.bindingSource1.DataSource = this.InfTable.装饰灯具;
                    this.InfTable.装饰灯具.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.装饰灯具.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "分类" };
                    this.ArrCheckColl = new string[] { "FL" };
                    this.gridView1.Columns["GGXH"].Caption = "垂吊长度、规格";//规格、型号列
                    this.gridView1.Columns["ZJ"].Caption = "直径";//直径列
                    this.gridView1.Columns["LX"].Visible = false;//类型列
                    this._lb = "装饰灯具";//类别
                    break;
                case 34:
                    this.bindingSource1.DataSource = this.InfTable.其他灯具;
                    this.InfTable.其他灯具.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.其他灯具.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "分类" };
                    this.ArrCheckColl = new string[] { "FL" };
                    this.gridView1.Columns["GGXH"].Caption = "规格";//规格、型号列
                    this.gridView1.Columns["ZJ"].Caption = "型号";//直径列
                    this.gridView1.Columns["SYTH"].Visible = false;//示意图号列
                    this._lb = "其他灯具";//类别
                    break;
                case 35:
                    this.bindingSource1.DataSource = this.InfTable.开关插座;
                    this.InfTable.开关插座.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.开关插座.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "分类" };
                    this.ArrCheckColl = new string[] { "FL" };
                    this.gridView1.Columns["GGXH"].Caption = "规格、型号";//规格、型号列
                    this.gridView1.Columns["ZJ"].Visible = false;//直径列
                    this.gridView1.Columns["SYTH"].Visible = false;//示意图号列
                    this._lb = "开关插座";//类别
                    break;
                case -1:
                    this.bindingSource1.DataSource = this.InfTable.电梯电气;
                    this.InfTable.电梯电气.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.电梯电气.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "分类" };
                    this.ArrCheckColl = new string[] { "FL" };
                    this.gridView1.Columns["GGXH"].Visible = false;//规格、型号列
                    this.gridView1.Columns["ZJ"].Visible = false;//直径列
                    this.gridView1.Columns["SYTH"].Visible = false;//示意图号列
                    this._lb = "电梯电气";//类别
                    break;
            }
        }
        private void OnlyOneDataSource()
        {
            this.ZMQJbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["照明器具"];
            this.DQQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["安装确定清单"];
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

            this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}'", this.LB, CurrRow["FL"]);
            int iCount = this.ZMQJbindingSource.Count;
            if (iCount > 0)
            {
                this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and LX is not null", this.LB, CurrRow["FL"]);
                if (iCount == this.ZMQJbindingSource.Count)
                {
                    this.CheckNull("LX", this.gridView1.Columns["LX"].Caption);
                }
            }

            this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (LX IS NULL OR LX='{2}')", this.LB, CurrRow["FL"], CurrRow["LX"]);
            iCount = this.ZMQJbindingSource.Count;
            if (iCount > 0)
            {
                this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (LX IS NULL OR LX='{2}') and GGXH is not null", this.LB, CurrRow["FL"], CurrRow["LX"]);
                if (iCount == this.ZMQJbindingSource.Count)
                {
                    this.CheckNull("GGXH", this.gridView1.Columns["GGXH"].Caption);
                }
            }

            this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (LX IS NULL OR LX='{2}') and GGXH='{3}'"
                         , this.LB, CurrRow["FL"], CurrRow["LX"], CurrRow["GGXH"]);
            iCount = this.ZMQJbindingSource.Count;
            if (iCount > 0)
            {
                this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (LX IS NULL OR LX='{2}') and GGXH='{3}' and ZJ is not null"
                            , this.LB, CurrRow["FL"], CurrRow["LX"], CurrRow["GGXH"]);
                if (iCount == this.ZMQJbindingSource.Count)
                {
                    this.CheckNull("ZJ", this.gridView1.Columns["ZJ"].Caption);
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
                    string strMC = this.LB;
                    if (this.KeyID == 34 || this.KeyID == 35)
                        strMC = toString(CurrRow["FL"]);
                    string strQDWhere = string.Format("ZY='电气' and MC like '%," + strMC + ",%'");
                    this.DQQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.DQQDQDbindingSource.Count)
                    {
                        DataRowView view = this.DQQDQDbindingSource[0] as DataRowView;
                        dr["QDBH"] = view["QDBH"];
                        dr["QDMC"] = view["QDMC"];
                        dr["DW"] = view["QDDW"];
                        dr["XS"] = view["GCLXS"];
                        dr["GCL"] = ToolKit.ParseDecimal(dr["XS"]) * ToolKit.ParseDecimal(drCurrent["SWGCL"]);
                        dr["WZLX"] = WZLX.分部分项;
                        dr["TJ"] = strTJ;
                        if (toString(view["QDBH"]).Length > 5)
                        {
                            dr["ZJ"] = toString(view["QDBH"]).Substring(0, 6);//清单所属章节【清单编号前六位】
                        }
                    }
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();
                    this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (LX is null or LX='{2}') and {3} and (ZJ IS NULL or ZJ='{4}')",
                        this.LB, CurrRow["FL"], CurrRow["LX"]
                        , string.IsNullOrEmpty(toString(CurrRow["GGXH"])) ? "GGXH is null" : "GGXH='" + CurrRow["GGXH"] + "'", CurrRow["ZJ"]);
                    foreach (DataRowView item in this.ZMQJbindingSource)
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
                strContent += "\r\n" + (++i) + "." + this.LB + "分类：" + drCurrent["FL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["LX"].ToString()))
            {
                strContent += "\r\n" + (++i) + "." + this.gridView1.Columns["LX"].Caption + "：" + drCurrent["LX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GGXH"].ToString()))
            {
                strContent += "\r\n" + (++i) + "." + this.gridView1.Columns["GGXH"].Caption + "：" + drCurrent["GGXH"];
            }
            if (!string.IsNullOrEmpty(drCurrent["ZJ"].ToString()))
            {
                strContent += "\r\n" + (++i) + "." + this.gridView1.Columns["ZJ"].Caption + "：" + drCurrent["ZJ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["SYTH"].ToString()))
            {
                strContent += "\r\n" + (++i) + "." + this.gridView1.Columns["SYTH"].Caption + "：" + drCurrent["SYTH"];
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
            if (null == CurrRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            switch (e.Column.FieldName)
            {
                case "FL":
                    this.ZMQJbindingSource.Filter = string.Format("LB='{0}'", this.LB);
                    popControl1.DataSource = this.RemoveRepeat(this.ZMQJbindingSource, "FL");
                    popControl1.ColName = new string[] { "分类|FL|FL" };
                    popControl1.RemoveDefaultColName = new string[] { "LX", "GGXH", "ZJ", "SYTH" };
                    popControl1.bind();
                    break;
                case "LX":
                    this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}'", this.LB, CurrRow["FL"]);
                    popControl1.DataSource = this.RemoveRepeat(this.ZMQJbindingSource, "LX");
                    popControl1.ColName = new string[] { string.Format("{0}|LX|LX", this.gridView1.Columns["LX"].Caption) };
                    popControl1.RemoveDefaultColName = new string[] { "GGXH", "ZJ" };
                    popControl1.bind();
                    break;
                case "GGXH":
                    this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (LX IS NULL OR LX='{2}') and GGXH is not null", this.LB, CurrRow["FL"], CurrRow["LX"]);
                    popControl1.DataSource = this.RemoveRepeat(this.ZMQJbindingSource, "GGXH");
                    popControl1.ColName = new string[] { string.Format("{0}|GGXH|GGXH", this.gridView1.Columns["GGXH"].Caption) };
                    popControl1.RemoveDefaultColName = new string[] { "ZJ" };
                    popControl1.bind();
                    break;
                case "ZJ":
                    this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (LX IS NULL OR LX='{2}') and GGXH='{3}'"
                        , this.LB, CurrRow["FL"], CurrRow["LX"], CurrRow["GGXH"]);
                    popControl1.DataSource = this.RemoveRepeat(this.ZMQJbindingSource, "ZJ");
                    popControl1.ColName = new string[] { string.Format("{0}|ZJ|ZJ", this.gridView1.Columns["ZJ"].Caption) };
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
                    foreach (string item in this.repositoryItemComboBox1.Items)
                    {
                        if (item.Equals(val))
                            return;
                    }

                    this.repositoryItemComboBox1.SaveCusotmerValue(val);

                    break;
            }
        }
        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            if (this.CurrRow == null) return;
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();

            string strMC = this.LB;
            if (this.KeyID == 34 || this.KeyID == 35)
                strMC = toString(CurrRow["FL"]);
            string strQDWhere = string.Format("ZY='电气' and MC like '%," + strMC + ",%'");
            this.DQQDQDbindingSource.Filter = strQDWhere;
            DataRowView currRow = this.DQQDQDbindingSource.Current as DataRowView;
            if (currRow != null)
                CurrRow["DW"] = currRow["QDDW"];


            this.ZMQJbindingSource.Filter = string.Format("LB='{0}' and FL='{1}' and (GGXH IS NULL OR GGXH='{2}') and (ZJ IS NULL OR ZJ='{3}')"
                , this.LB, CurrRow["FL"], CurrRow["GGXH"], CurrRow["ZJ"]);
            currRow = this.ZMQJbindingSource.Current as DataRowView;
            if (currRow != null)
                CurrRow["SYTH"] = currRow["SYTH"];
        }
    }
}