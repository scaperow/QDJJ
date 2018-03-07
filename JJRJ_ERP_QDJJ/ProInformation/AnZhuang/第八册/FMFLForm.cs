using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class FMFLForm : BaseUI
    {
        public FMFLForm()
        {
            InitializeComponent();
        }

        private void FMFLForm_Load(object sender, EventArgs e)
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
            this.bindingSource1.DataSource = InfTable.阀门_法兰;
            this.InfTable.阀门_法兰.RowChanged += new DataRowChangeEventHandler(this.RowChanged);

            this.FMFLBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["阀门_法兰"];
            this.FFSYCXBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["防腐刷油_除锈"];

            this.BWJRGCBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["保温绝热工程"]; 
            this.BWJRGCBindingSource.DataSource = SplitDataFW(BWJRGCBindingSource, "SBZJ", "MaxSBZJ", "MinSBZJ", '～');

            this.GDSZBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["高度设置"];
            this.GPSQDQDBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["给排水确定清单"];
            this.GCZJZHBindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["公称直径转换"];
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
                    string strQDWhere = string.Format("CZ like '%,{0},%'", toString(drCurrent["FMFLPZMC"]));
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


                    #region 阀门、法兰

                    string strDEWhere = string.Format("FL='{0}' and PZ='{1}'and ( JTXS='{2}' or  JTXS is Null) and GG= '{3}'"
                                        , drCurrent["FL"], drCurrent["FMFLPZMC"], drCurrent["JTXS"], drCurrent["GG"]);

                    this.FMFLBindingSource.Filter = strDEWhere;

                    foreach (DataRowView item in this.FMFLBindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        string debh = toString(item["DEBH"]);

                        //根据高度设置的《系数》   修改定额编号
                        this.GDSZBindingSource.Filter = string.Format("GD ='{0}' or GD ='{1}'", drCurrent["CZBW"], drCurrent["CZGD"]);
                        foreach (DataRowView gdszItem in this.GDSZBindingSource)
                        {
                            if (gdszItem != null && !string.IsNullOrEmpty(toString(gdszItem["XS"])))
                            {
                                if (!debh.Contains(' '))
                                    debh = debh + " " + toString(gdszItem["XS"]);
                                else
                                    debh = debh + toString(gdszItem["XS"]).Substring(1, toString(gdszItem["XS"]).Length - 1);
                            }
                        }
                        
                        row["DEBH"] = debh;
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

                    #region 防腐刷油、除锈
                    string[] strListDEWhere = new string[] { 
                        string.Format("FL='除锈工程' and BW='设备' and LX= '{0}'", drCurrent["CX"]) ,
                        string.Format("FL='防腐刷油工程' and (BW='设备防腐' or BW='设备刷油') and LX= '{0}'", drCurrent["BWQFFSYYQ"]) ,
                        string.Format("FL='防腐刷油工程' and (BW='设备防腐' or BW='设备刷油') and LX= '{0}'", drCurrent["BWHFFSYYQ"]) 
                    };
                    for (int i = 0; i < strListDEWhere.Length; i++)
                    {
                        this.FFSYCXBindingSource.Filter = strListDEWhere[i];
                        foreach (DataRowView item in this.FFSYCXBindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = toString(item["DEBH"]);
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            switch (i)
                            {
                                case 0:
                                    row["XS"] = item["GCLXS"];
                                    break;
                                case 1:
                                    row["XS"] = item["BWQXS"];
                                    break;
                                case 2:
                                    row["XS"] = item["BWHXS"];
                                    break;
                            }
                            row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                        }
                    }
                    #endregion

                    #region 保温绝热工程

                    DataRowView currRow = this.bindingSource1.Current as DataRowView;
                    //获取计算直径  即设备直径
                    this.GCZJZHBindingSource.Filter = string.Format("YSGG = '{0}'", currRow["GG"]);
                    DataRowView sjzj = GCZJZHBindingSource.Current as DataRowView;
                    decimal sbzj = sjzj == null ? -1 : ToolKit.ParseDecimal(sjzj["JSZJ"]);


                    strDEWhere = string.Format("BWLB='保温层' and BWFL='{0}' and JRCL='{1}' and  ((MaxSBZJ>={2} and MinSBZJ<={2}) or SBZJ is null)", drCurrent["FL"], drCurrent["BWJRCLZL"], sbzj);
                    this.BWJRGCBindingSource.Filter = strDEWhere;
                    foreach (DataRowView item in this.BWJRGCBindingSource)
                    {
                        string[] jrhdfw = toString(item["JRHD"]).Split('～');
                        if (jrhdfw.Length == 2
                            && ToolKit.ParseDecimal(jrhdfw[0]) <= ToolKit.ParseDecimal(toString(drCurrent["BWHD"]))
                            && ToolKit.ParseDecimal(jrhdfw[1]) >= ToolKit.ParseDecimal(toString(drCurrent["BWHD"])))
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = toString(item["DEBH"]);
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
            if (!string.IsNullOrEmpty(drCurrent["FMFLPZMC"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".阀门法兰品种、名称：" + drCurrent["FMFLPZMC"];
            }
            if (!string.IsNullOrEmpty(drCurrent["JTXS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".接头形式：" + drCurrent["JTXS"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".规格：" + drCurrent["GG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".操作部位：" + drCurrent["CZBW"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZGD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".操作高度：" + drCurrent["CZGD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".除锈：" + drCurrent["CX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWQFFSYYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温前防腐、刷油要求：" + drCurrent["BWQFFSYYQ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWJRCLZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温绝热材料种类：" + drCurrent["BWJRCLZL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWHD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温厚度：" + drCurrent["BWHD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWHFFSYYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温后防腐、刷油要求：" + drCurrent["BWHFFSYYQ"];
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
                    string fl = "阀门,法兰";
                    popControl1.DataSource = strToTable(fl, "FL");

                    popControl1.ColName = new string[] { "分类|FL|FL" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "FMFLPZMC", "JTXS", "GG" };
                    popControl1.bind();
                    break;
                case "FMFLPZMC":

                    this.FMFLBindingSource.Filter = string.Format(" FL='{0}'", toString(currRow["FL"]));
                    popControl1.DataSource = RemoveRepeat(FMFLBindingSource, "PZ");

                    popControl1.ColName = new string[] { "阀门法兰品种、名称|PZ|FMFLPZMC" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] {  "JTXS", "GG" };
                    popControl1.bind();
                    break;
                case "JTXS":

                    this.FMFLBindingSource.Filter = string.Format(" FL='{0}'and PZ='{1}'", toString(currRow["FL"]), toString(currRow["FMFLPZMC"]));
                    popControl1.DataSource = RemoveRepeat(FMFLBindingSource,"JTXS");

                    popControl1.ColName = new string[] { "接头形式|JTXS|JTXS" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "GG" };
                    popControl1.bind();
                    break;
                case "GG":

                    popControl1.DataSource = this.FMFLBindingSource;
                    this.FMFLBindingSource.Filter = string.Format(" FL='{0}'and PZ='{1}'and (JTXS='{2}' or JTXS is null)"
                                                        , toString(currRow["FL"]), toString(currRow["FMFLPZMC"]), toString(currRow["JTXS"]));

                    popControl1.ColName = new string[] { "规格|GG|GG" };
                    //清除依赖项数据
                    popControl1.RemoveDefaultColName = new string[] { "BWHD" };
                    popControl1.bind();
                    break;
                case "CZBW":

                    this.GDSZBindingSource.Filter = " SYFW='给排水'and BTMS='操作部位'";
                    popControl1.DataSource = RemoveRepeat(GDSZBindingSource, "GD");

                    popControl1.ColName = new string[] { "规格|GD|CZBW" };
                    popControl1.bind();
                    break;
                case "CZGD":

                    this.GDSZBindingSource.Filter = " SYFW='给排水'and BTMS='操作高度'";
                    popControl1.DataSource = RemoveRepeat(GDSZBindingSource,"GD");

                    popControl1.ColName = new string[] { "规格|GD|CZGD" };
                    popControl1.bind();
                    break;
                case "CX":

                    popControl1.DataSource = this.FFSYCXBindingSource;
                    this.FFSYCXBindingSource.Filter = " FL='除锈工程'and BW='设备'";

                    popControl1.ColName = new string[] { "规格|LX|CX" };
                    popControl1.bind();
                    break;
                case "BWQFFSYYQ":

                    popControl1.DataSource = this.FFSYCXBindingSource;
                    this.FFSYCXBindingSource.Filter = " FL='防腐刷油工程'and (BW='设备刷油' or BW='设备防腐')";

                    popControl1.ColName = new string[] { "规格|LX|BWQFFSYYQ" };
                    popControl1.bind();
                    break;
                case "BWJRCLZL":

                    this.BWJRGCBindingSource.Filter = string.Format(" FL='保温绝热工程'and BWLB='保温层' and BWFL='{0}'", toString(currRow["FL"]));
                    popControl1.DataSource = RemoveRepeat(BWJRGCBindingSource,"JRCL");

                    popControl1.ColName = new string[] { "规格|JRCL|BWJRCLZL" };
                    popControl1.bind();
                    break;
                case "BWHFFSYYQ":

                    popControl1.DataSource = this.FFSYCXBindingSource;
                    this.FFSYCXBindingSource.Filter = " FL='防腐刷油工程'and (BW='设备刷油' or BW='设备防腐')";

                    popControl1.ColName = new string[] { "规格|LX|BWHFFSYYQ" };
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
            string strQDWhere = string.Format("CZ like '%,{0},%'", toString(drCurrent["FMFLPZMC"]));
            this.GPSQDQDBindingSource.Filter = strQDWhere;
            if (0 < GPSQDQDBindingSource.Count)
            {
                DataRowView view = this.GPSQDQDBindingSource[0] as DataRowView;
                drCurrent["DW"] = view["QDDW"];
            }
        }
        //验证保温厚度范围
        private void repositoryItemSpinEdit1_Leave(object sender, EventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            //获取计算直径  即设备直径
            this.GCZJZHBindingSource.Filter = string.Format("YSGG = '{0}'", currRow["GG"]);
            DataRowView sjzj = GCZJZHBindingSource.Current as DataRowView;
            decimal sbzj = sjzj == null ? -1 : ToolKit.ParseDecimal(sjzj["JSZJ"]);

            this.BWJRGCBindingSource.Filter = string.Format("FL='保温绝热工程' and BWLB ='保温层' and  BWFL='{0}'  and (JRCL='{1}' or JRCL is null) and ((MaxSBZJ>={2} and MinSBZJ<={2}) or SBZJ is null)", currRow["FL"], currRow["BWJRCLZL"], sbzj);

            //获取保温厚度范围
            decimal minValue = 0;
            decimal maxValue = 0;
            int i = 0;
            foreach (DataRowView item in BWJRGCBindingSource)
            {
                if (item != null && item["JRHD"] != null)
                {
                    string[] jrhd = toString(item["JRHD"]).Split('～');
                    if (jrhd.Length == 2)
                    {
                        if (i == 0)
                        {
                            minValue = decimal.Parse(jrhd[0]);
                            maxValue = decimal.Parse(jrhd[1]);
                            i++;
                        }
                        if (decimal.Parse(jrhd[0]) <= minValue)
                            minValue = decimal.Parse(jrhd[0]);
                        if (decimal.Parse(jrhd[1]) >= maxValue)
                            maxValue = decimal.Parse(jrhd[1]);
                    }
                }
            }
            DevExpress.XtraEditors.SpinEdit edit = sender as DevExpress.XtraEditors.SpinEdit;
            if (edit.Value < minValue)
                edit.Value = minValue;
            else if (edit.Value > maxValue)
                edit.Value = maxValue;
        }
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
                checkMess.Add("阀门法兰品种、名称");
                CheckColl.Add("FMFLPZMC");
                //点击确定清单前   判断必填项
                this.FMFLBindingSource.Filter = string.Format(" FL='{0}'and PZ='{1}'", toString(currRow["FL"]), toString(currRow["FMFLPZMC"]));
                if (0 < FMFLBindingSource.Count)
                {
                    this.FMFLBindingSource.Filter = string.Format(" FL='{0}'and PZ='{1}' and  JTXS is Null", toString(currRow["FL"]), toString(currRow["FMFLPZMC"]));
                    if (1 > FMFLBindingSource.Count)
                    {
                        checkMess.Add("接头形式");
                        CheckColl.Add("JTXS");
                    }
                }
                checkMess.Add("规格");
                CheckColl.Add("GG");
                ArrCheckColl = CheckColl.ToArray();
                ArrCheckMess = checkMess.ToArray();
            }
        }
    }
}