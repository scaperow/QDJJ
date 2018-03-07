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
using DevExpress.XtraGrid;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class QZMZFForm : BaseUI
    {
        public QZMZFForm()
        {
            InitializeComponent();
        }
        public QZMZFForm(_UnitProject p_CUnitProject)
            : base(p_CUnitProject)
        {
            InitializeComponent();
        }

        private void QZMZFForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
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
                this.ArrCheckMess = new string[] { "做法名称" };
                this.ArrCheckColl = new string[] { "ZFMC1" };
                ScreenWDBH(false);///添加筛选清单
                btnAddRow.Caption = "添加" + Parm + "信息";
                this.RemoveNull();///清除无效数据
            }
        }

        #region 绑定数据源
        private void OnlyOneDataSource()
        {
            this.MHQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["抹灰确定定额"];
            this.QZMQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["墙柱面确定清单"];

            //this.LDMFLQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["楼地面分类确定清单"];
            //this.LDMZFQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["楼地面做法定额表"];
            this.DCQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["垫层确定定额"];
            this.FSQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["防水确定定额"];
            this.BWCLbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["保温材料表"];
            this.BWCLQDDEbindingSource.DataSource = APP.Application.Global.DataTamp.工程信息表.Tables["保温部位材料确定定额"];

            if (InfTable.QZMZF == null)
            {
                InfTable.QZMZF = APP.UnInformation.InformationTable.CreatTable("墙柱面做法");
            }

            this.bindingSource1.DataSource = InfTable.QZMZF;///墙柱面做法
            this.InfTable.QZMZF.RowChanged += new DataRowChangeEventHandler(this.RowChanged);//墙柱面做法
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
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
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
                    string strQDWhere = string.Format("FL = '{0}'", ",墙面一般抹灰,");
                    this.QZMQDQDbindingSource.Filter = strQDWhere;
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.QZMQDQDbindingSource.Count)
                    {
                        DataRowView view = this.QZMQDQDbindingSource[0] as DataRowView;
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

                    string[] strArrZFMC = { toString(drCurrent["ZFMC1"]), 
                                            toString(drCurrent["ZFMC2"]),
                                            toString(drCurrent["ZFMC3"]),
                                          };
                    //防水确定定额
                    string[] strArrFSCL = { toString(drCurrent["FSCL1"]), toString(drCurrent["FSCL2"]) };
                    foreach (string stringFSCL in strArrFSCL)
                    {
                        if (!string.IsNullOrEmpty(stringFSCL))
                        {
                            this.FSQDDEbindingSource.Filter = string.Format("(FSBW like '%,墙面,%' or FSBW like '%,立面,%' or FSBW like '%,地下室外墙,%' or FSBW = NULL) and FSCL='{0}'", stringFSCL);

                            foreach (DataRowView item in this.FSQDDEbindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                row["XS"] = item["GCLXS"];
                                row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], item["GCLXS"], "", ""));
                            }
                        }
                    }

                    //保温材料确定定额
                    string[] strArrBWCL = { toString(drCurrent["BWCL"]) };
                    foreach (string stringBWCL in strArrBWCL)
                    {
                        if (!string.IsNullOrEmpty(stringBWCL))
                        {
                            this.BWCLQDDEbindingSource.Filter = string.Format("BWCL='{0}' and (BWBWMC='外墙外保温' or BWBWMC='外墙内保温')", stringBWCL);

                            foreach (DataRowView item in this.BWCLQDDEbindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];

                                string[] strTemp = toString(item["GCLXS"]).Split('/');
                                if (strTemp.Length == 2)
                                {
                                    row["XS"] = ToolKit.ParseDecimal(drCurrent["BWCLHD"]) / ToolKit.ParseDecimal(strTemp[1]);
                                }
                                else
                                {
                                    row["XS"] = item["GCLXS"];
                                }
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], row["XS"], "", ""));
                            }
                        }
                    }


                    foreach (string stringZFMC in strArrZFMC)
                    {
                        if (!string.IsNullOrEmpty(stringZFMC))
                        {

                            this.MHQDDEbindingSource.Filter = string.Format("SJPHB = '{0}'", stringZFMC);
                            foreach (DataRowView item in this.MHQDDEbindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                row["XS"] = item["GCLXS"];
                                row["GCL"] = CDataConvert.ConToValue<float>(row["XS"]) * CDataConvert.ConToValue<float>(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", item["DEBH"], item["GCLXS"], "", ""));
                            }
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
            if (!string.IsNullOrEmpty(toString(drCurrent["ZFMC1"])))
            {
                strContent += "\r\n" + (++i) + "." + drCurrent["ZFMC1"] + "；";
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["ZFMC2"])))
            {
                strContent += "\r\n" + (++i) + "." + drCurrent["ZFMC2"] + "；";
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["ZFMC3"])))
            {
                strContent += "\r\n" + (++i) + "." + drCurrent["ZFMC3"] + "；";
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["FSCL1"])))
            {
                strContent += "\r\n" + (++i) + "." + drCurrent["FSCL1"] + "；";
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["FSCL2"])))
            {
                strContent += "\r\n" + (++i) + "." + drCurrent["FSCL2"] + "；";
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["BWCL"])))
            {
                strContent += "\r\n" + (++i) + "." + drCurrent["BWCL"] + "；";
            }
            if (!string.IsNullOrEmpty(toString(drCurrent["BWCLHD"])))
            {
                strContent += "\r\n" + (++i) + ".保温材料厚度：" + drCurrent["BWCLHD"] + "mm；";
            }

            if (!string.IsNullOrEmpty(drCurrent["SZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".所在部位：" + drCurrent["SZBW"] + "；";
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
            switch (e.Column.FieldName)
            {
                case "ZFMC1":
                    popControl1.DataSource = this.MHQDDEbindingSource;
                    this.MHQDDEbindingSource.Filter = "MHFL='墙面一般抹灰' and SJZL='09j新标准'";
                    popControl1.ColName = new string[] { "墙柱面做法名称|SJPHB|ZFMC1" };
                    popControl1.bind();
                    break;
                case "ZFMC2":
                    popControl1.DataSource = this.MHQDDEbindingSource;
                    this.MHQDDEbindingSource.Filter = "MHFL='墙面一般抹灰' and SJZL='09j新标准'";
                    popControl1.ColName = new string[] { "墙柱面做法名称|SJPHB|ZFMC2" };
                    popControl1.bind();
                    break;
                case "ZFMC3":
                    popControl1.DataSource = this.MHQDDEbindingSource;
                    this.MHQDDEbindingSource.Filter = "MHFL='墙面一般抹灰' and SJZL='09j新标准'";
                    popControl1.ColName = new string[] { "墙柱面做法名称|SJPHB|ZFMC3" };
                    popControl1.bind();
                    break;
                case "FSCL1":
                    this.FSQDDEbindingSource.Filter = "(FSBW like '%,墙面,%' or FSBW like '%,立面,%' or FSBW like '%,地下室外墙,%' or FSBW = NULL)";
                    popControl1.DataSource = this.FSQDDEbindingSource;
                    popControl1.ColName = new string[] { "防水材料品种|FSCL|FSCL1" };
                    popControl1.bind();
                    break;
                case "FSCL2":
                    this.FSQDDEbindingSource.Filter = "(FSBW like '%,墙面,%' or FSBW like '%,立面,%' or FSBW like '%,地下室外墙,%' or FSBW = NULL)";
                    popControl1.DataSource = this.FSQDDEbindingSource;
                    popControl1.ColName = new string[] { "防水材料品种|FSCL|FSCL2" };
                    popControl1.bind();
                    break;
                case "BWCL":

                    this.BWCLbindingSource.Filter = "BWMC='外墙内保温' or BWMC='外墙外保温'";
                    this.bindingSource1.ResetBindings(false);
                    popControl1.DataSource = this.BWCLbindingSource;
                    popControl1.ColName = new string[] { "保温材料|BWCLMC|BWCL" };
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
        }
    }
}
