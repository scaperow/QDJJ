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
    public partial class PMDJTPForm : BaseUI
    {
        public PMDJTPForm()
        {
            InitializeComponent();
        }
        public PMDJTPForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void PMDJTPForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.PMDJTP;
            this.InfTable.PMDJTP.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.QDDEBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["天棚面层确定定额"];
            this.QDQDBindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["天棚类型确定清单"];
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

            //未填验证
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

                    #region 确定清单

                    //根据天棚规格型号   优先选择清单
                    string tpggxh = "天棚龙骨";
                    if ((!string.IsNullOrEmpty(drCurrent["LGGGCZ"].ToString())
                        || !string.IsNullOrEmpty(drCurrent["JCGGCZ"].ToString())
                        || !string.IsNullOrEmpty(drCurrent["MCGGCZ"].ToString())))
                    {
                        tpggxh = "天棚龙骨";
                        if (string.IsNullOrEmpty(drCurrent["LGGGCZ"].ToString())
                            && string.IsNullOrEmpty(drCurrent["JCGGCZ"].ToString())
                            && !string.IsNullOrEmpty(drCurrent["MCGGCZ"].ToString()))
                        {
                            this.QDDEBindingSource.Filter = string.Format("TPLB='平面、跌级天棚' and GGCZ = '{0}'", drCurrent["MCGGCZ"]);
                            DataRowView mcCurrent = QDDEBindingSource[0] as DataRowView;
                            tpggxh = mcCurrent["TPFL"].ToString();

                        }
                    }
                    else if (!string.IsNullOrEmpty(drCurrent["DCGGCZ"].ToString()))
                    {
                        tpggxh = "天棚灯槽";
                    }




                    //（室外工程清单）
                    string strQDWhere = string.Format("TPLB = '平面、跌级天棚' and FL like '%,{0},%'", tpggxh);
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
                    this.QDQDBindingSource.Filter = "";


                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();


                    //龙骨规格、材质
                    this.QDDEBindingSource.Filter = string.Format("TPLB='平面、跌级天棚' and TPFL='天棚龙骨'  and GGCZ = '{0}'", drCurrent["LGGGCZ"]);
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
                    //基层规格、材质
                    this.QDDEBindingSource.Filter = string.Format("TPLB='平面、跌级天棚' and TPFL='天棚基层'   and GGCZ = '{0}'", drCurrent["JCGGCZ"]);
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

                    //面层规格、材质
                    this.QDDEBindingSource.Filter = string.Format("TPLB='平面、跌级天棚' and (TPFL='天棚面层' or TPFL='格栅天棚')   and GGCZ = '{0}'", drCurrent["MCGGCZ"]);
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

                    //灯槽规格、材质
                    this.QDDEBindingSource.Filter = string.Format("TPLB='平面、跌级天棚' and TPFL='天棚灯槽'  and GGCZ = '{0}'", drCurrent["DCGGCZ"]);
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
            if (!string.IsNullOrEmpty(drCurrent["LGGGCZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".龙骨规格、材质：" + drCurrent["LGGGCZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JCGGCZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".基层规格、材质：" + drCurrent["JCGGCZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["MCGGCZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".面层规格、材质：" + drCurrent["MCGGCZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["DCGGCZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".灯槽规格、材质：" + drCurrent["DCGGCZ"];
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
            DataTable dt = this.QDDEBindingSource.DataSource as DataTable;
            switch (e.Column.FieldName)
            {
                case "LGGGCZ":
                    //龙骨规格、材质
                    popControl1.DataSource = this.QDDEBindingSource;
                    QDDEBindingSource.Filter = "TPLB='平面、跌级天棚' and TPFL ='天棚龙骨'";


                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                    popControl1.ColName = new string[] { "龙骨规格、材质|GGCZ|LGGGCZ" };
                    popControl1.bind();
                    break;
                case "JCGGCZ":
                    //基层规格、材质
                    popControl1.DataSource = this.QDDEBindingSource;
                    QDDEBindingSource.Filter = "TPLB='平面、跌级天棚' and TPFL ='天棚基层'";


                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                    popControl1.ColName = new string[] { "基层规格、材质|GGCZ|JCGGCZ" };
                    popControl1.bind();
                    break;
                case "MCGGCZ":

                    //面层规格、材质
                    popControl1.DataSource = this.QDDEBindingSource;
                    QDDEBindingSource.Filter = "TPLB='平面、跌级天棚' and ( TPFL ='天棚面层'or TPFL='格栅天棚')";


                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                    popControl1.ColName = new string[] { "面层规格、材质|GGCZ|MCGGCZ" };
                    popControl1.bind();
                    break;
                case "DCGGCZ":

                    //灯槽规格、材质
                    popControl1.DataSource = this.QDDEBindingSource;
                    QDDEBindingSource.Filter = "TPLB='平面、跌级天棚' and TPFL ='天棚灯槽'";



                    //去重复
                    popControl1.DataSource = this.RemoveRepeat(dt, "GGCZ");
                    popControl1.ColName = new string[] { "灯槽规格、材质|GGCZ|DCGGCZ" };
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
            checkNull();
        }

        private bool checkInsert()
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if ((currRow["LGGGCZ"] != null && !string.IsNullOrEmpty(currRow["LGGGCZ"].ToString()))
                || (currRow["JCGGCZ"] != null && !string.IsNullOrEmpty(currRow["JCGGCZ"].ToString()))
                || (currRow["MCGGCZ"] != null && !string.IsNullOrEmpty(currRow["MCGGCZ"].ToString()))
                || (currRow["DCGGCZ"] != null && !string.IsNullOrEmpty(currRow["DCGGCZ"].ToString())))
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
