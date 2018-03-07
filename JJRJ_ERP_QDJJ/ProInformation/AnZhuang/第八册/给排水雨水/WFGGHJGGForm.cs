using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using DevExpress.XtraGrid;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class WFGGHJGGForm : BaseUI
    {
        public WFGGHJGGForm()
        {
            InitializeComponent();
        }

        private void WFGGHJGGForm_Load(object sender, EventArgs e)
        {
            OnlyOneDataSource();//绑定数据源
        }
        #region 字段、属性
        private string _azbw;
        /// <summary>
        /// 安装部位
        /// </summary>
        public string AZBW
        {
            get { return _azbw; }
        }
        private string _ssjz;
        /// <summary>
        /// 输送介质
        /// </summary>
        public string SSJZ
        {
            get { return _ssjz; }
        }
        private string _cz;
        /// <summary>
        /// 材质
        /// </summary>
        public string CZ
        {
            get { return _cz; }
        }
        private bool _isbhcz = true;
        /// <summary>
        /// 是否包含材质
        /// </summary>
        public bool ISBHCZ
        {
            get { return _isbhcz; }
        }
        private string _gdxdcx;
        /// <summary>
        /// 管道消毒冲洗
        /// </summary>
        public string GDXDCX
        {
            get { return _gdxdcx; }
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
        #endregion

        #region 绑定数据源

        private void AlwaysExecute()
        {
            switch (this.KeyID)
            {
                case 63:
                    this.bindingSource1.DataSource = this.InfTable.给排水室外无缝钢管;
                    this.InfTable.给排水室外无缝钢管.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.给排水室外无缝钢管.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "输送介质", "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "SSJZ", "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["CZBW"].Visible = false;//操作部位列
                    this._azbw = "室外";//安装部位
                    this._ssjz = "给水,排水";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = true;//是否包含材质
                    this._gdxdcx = "给水";//管道消毒冲洗
                    break;
                case 64:
                    this.bindingSource1.DataSource = this.InfTable.给排水室外其他管材;
                    this.InfTable.给排水室外其他管材.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.给排水室外其他管材.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "输送介质", "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "SSJZ", "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["CZBW"].Visible = false;//操作部位列
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "室外";//安装部位
                    this._ssjz = "给水,排水";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "给水";//管道消毒冲洗
                    break;
                case 66:
                    this.bindingSource1.DataSource = this.InfTable.给排水室内无缝钢管;
                    this.InfTable.给排水室内无缝钢管.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.给排水室内无缝钢管.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "输送介质", "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "SSJZ", "CZ", "LJFS", "GG" };
                    this._azbw = "室内";//安装部位
                    this._ssjz = "给水,排水";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = true;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 67:
                    this.bindingSource1.DataSource = this.InfTable.给排水室内其他管材;
                    this.InfTable.给排水室内其他管材.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.给排水室内其他管材.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "输送介质", "材质" };
                    this.ArrCheckColl = new string[] { "SSJZ", "CZ" };
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "室内";//安装部位
                    this._ssjz = "给水,排水,雨水";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 68:
                    this.bindingSource1.DataSource = this.InfTable.给排水埋地管道;
                    this.InfTable.给排水埋地管道.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.给排水埋地管道.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "输送介质", "材质" };
                    this.ArrCheckColl = new string[] { "SSJZ", "CZ" };
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "埋地";//安装部位
                    this._ssjz = "给水,排水";//输送介质
                    this._cz = "清单计价";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 73:
                    this.bindingSource1.DataSource = this.InfTable.采暖热源室外无缝钢管;
                    this.InfTable.采暖热源室外无缝钢管.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.采暖热源室外无缝钢管.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this._azbw = "室外";//安装部位
                    this._ssjz = "采暖热源";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = true;//是否包含材质
                    this._gdxdcx = "采暖";//管道消毒冲洗
                    break;
                case 74:
                    this.bindingSource1.DataSource = this.InfTable.采暖热源室外其他管材;
                    this.InfTable.采暖热源室外其他管材.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.采暖热源室外其他管材.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this.gridView1.Columns["CZBW"].Visible = false;//操作部位列
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "室外";//安装部位
                    this._ssjz = "采暖热源";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "采暖";//管道消毒冲洗
                    break;
                case 76:
                    this.bindingSource1.DataSource = this.InfTable.采暖热源室内无缝钢管;
                    this.InfTable.采暖热源室内无缝钢管.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.采暖热源室内无缝钢管.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this._azbw = "室内";//安装部位
                    this._ssjz = "采暖热源";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = true;//是否包含材质
                    this._gdxdcx = "采暖";//管道消毒冲洗
                    break;
                case 77:
                    this.bindingSource1.DataSource = this.InfTable.采暖热源室内其他管材;
                    this.InfTable.采暖热源室内其他管材.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.采暖热源室内其他管材.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "室内";//安装部位
                    this._ssjz = "采暖热源";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "采暖";//管道消毒冲洗
                    break;
                case 78:
                    this.bindingSource1.DataSource = this.InfTable.采暖热源埋地管道;
                    this.InfTable.采暖热源埋地管道.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.采暖热源埋地管道.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "输送介质", "材质" };
                    this.ArrCheckColl = new string[] { "SSJZ", "CZ" };
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "埋地";//安装部位
                    this._ssjz = "采暖热源";//输送介质
                    this._cz = "清单计价";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 88:
                    this.bindingSource1.DataSource = this.InfTable.消火栓室外无缝钢管;
                    this.InfTable.消火栓室外无缝钢管.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.消火栓室外无缝钢管.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this.gridView1.Columns["CZBW"].Visible = false;//操作部位列
                    this._azbw = "室外";//安装部位
                    this._ssjz = "消火栓";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = true;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 89:
                    this.bindingSource1.DataSource = this.InfTable.消火栓室外其他管材;
                    this.InfTable.消火栓室外其他管材.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.消火栓室外其他管材.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this.gridView1.Columns["CZBW"].Visible = false;//操作部位列
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "室外";//安装部位
                    this._ssjz = "消火栓";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 91:
                    this.bindingSource1.DataSource = this.InfTable.消火栓室内无缝钢管;
                    this.InfTable.消火栓室内无缝钢管.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.消火栓室内无缝钢管.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this._azbw = "室内";//安装部位
                    this._ssjz = "消火栓";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = true;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 92:
                    this.bindingSource1.DataSource = this.InfTable.消火栓室内其他管材;
                    this.InfTable.消火栓室内其他管材.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.消火栓室内其他管材.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "材质", "连接方式", "规格" };
                    this.ArrCheckColl = new string[] { "CZ", "LJFS", "GG" };
                    this.gridView1.Columns["SSJZ"].Visible = false;//输送介质列
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "室内";//安装部位
                    this._ssjz = "消火栓";//输送介质
                    this._cz = "无缝钢管,焊接钢管";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
                case 93:
                    this.bindingSource1.DataSource = this.InfTable.消火栓埋地管道;
                    this.InfTable.消火栓埋地管道.RowChanged -= new DataRowChangeEventHandler(this.RowChanged);
                    this.InfTable.消火栓埋地管道.RowChanged += new DataRowChangeEventHandler(this.RowChanged);
                    this.ArrCheckMess = new string[] { "输送介质", "材质" };
                    this.ArrCheckColl = new string[] { "SSJZ", "CZ" };
                    this.gridView1.Columns["CX"].Visible = false;//除锈列
                    this.gridView1.Columns["BWQFFSYYQ"].Visible = false;//保温前防腐刷油要求列
                    this.gridView1.Columns["BWQFFSYYQ2"].Visible = false;//保温前防腐刷油要求列2
                    this._azbw = "埋地";//安装部位
                    this._ssjz = "消火栓";//输送介质
                    this._cz = "清单计价";//材质
                    this._isbhcz = false;//是否包含材质
                    this._gdxdcx = "";//管道消毒冲洗
                    break;
            }
        }
        private void OnlyOneDataSource()
        {
            this.QDGDDEbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["确定管道定额"];
            this.GDSZbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["高度设置"];
            DataTable dtTemp = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["套管规格范围"];
            this.TGGGFWbindingSource.DataSource = this.SplitDataFW(dtTemp, "GGFW", "MaxGGFW", "MinGGFW", '～');
            this.FFSYCXbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["防腐刷油_除锈"];
            dtTemp = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["保温绝热工程"];
            dtTemp = this.SplitDataFW(dtTemp, "SBZJ", "MaxSBZJ", "MinSBZJ", '～');
            this.BWJRGCbindingSource.DataSource = this.SplitDataFW(dtTemp, "JRHD", "MaxJRHD", "MinJRHD", '～');
            this.GCZJZHbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["公称直径转换"];
            this.GPSQDQDbindingSource.DataSource = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["给排水确定清单"];
            dtTemp = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["其他给排水确定定额"];
            this.QTGPSQDDEbindingSource.DataSource = this.SplitDataFW(dtTemp, "GGFW", "MaxGGFW", "MinGGFW", '～');
            dtTemp = APP.Application.Global.DataTamp.安装专业工程信息表.Tables["管道消毒冲洗"];
            this.GDXDCXbindingSource.DataSource = this.SplitDataFW(dtTemp, "GGXH", "MaxGGXH", "MinGGXH", '～');
        }
        #endregion

        #region 确定清单
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ScreenWDBH(false);///添加筛选清单
        }
        protected override void btnScreenQDBH_Click(object sender, EventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) return;
            base.btnScreenQDBH_Click(sender, e);


            if (this.KeyID == 67 || this.KeyID == 68 || this.KeyID == 78 || this.KeyID == 93)
            {
                string strSSJZ = toString(currRow["SSJZ"]);//输送介质
                if (string.IsNullOrEmpty(strSSJZ))
                {
                    strSSJZ = this.SSJZ;
                }
                this.QDGDDEbindingSource.Filter = string.Format(" (AZBW is null or AZBW like '%,{0},%') and SSJZ like '%,{1},%' and CZ like '%,{2},%' ", this.AZBW, strSSJZ, toString(currRow["CZ"]));
                int iCount = this.QDGDDEbindingSource.Count;
                if (iCount > 0)
                {
                    this.QDGDDEbindingSource.Filter = string.Format(" (AZBW is null or AZBW like '%,{0},%') and SSJZ like '%,{1},%' and CZ like '%,{2},%' and LJFS is not null", this.AZBW, strSSJZ, toString(currRow["CZ"]));
                    if (iCount == this.QDGDDEbindingSource.Count)
                    {
                        this.CheckNull("LJFS", this.gridView1.Columns["LJFS"].Caption);
                    }
                }

                this.QDGDDEbindingSource.Filter = string.Format(" (AZBW is null or AZBW like '%,{0},%') and SSJZ like '%,{1},%' and CZ like '%,{2},%' and LJFS='{3}' "
                                                     , this.AZBW, strSSJZ, toString(currRow["CZ"]), toString(currRow["LJFS"]));
                iCount = this.QDGDDEbindingSource.Count;
                if (iCount > 0)
                {
                    this.QDGDDEbindingSource.Filter = this.QDGDDEbindingSource.Filter = string.Format(" (AZBW is null or AZBW like '%,{0},%') and SSJZ like '%,{1},%' and CZ like '%,{2},%' and LJFS='{3}' and GG is not Null"
                                                     , this.AZBW, strSSJZ, toString(currRow["CZ"]), toString(currRow["LJFS"]));
                    {
                        this.CheckNull("GG", this.gridView1.Columns["GG"].Caption);
                    }
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
                DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
                if (null == drCurrent)
                {
                    this.InformationForm.Fiter(" 1<>1 ");
                    return;
                }
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
                    //获取规格范围
                    this.GCZJZHbindingSource.Filter = string.Format(" YSGG = '{0}'", drCurrent["GG"]);
                    DataRowView drGCZJ = this.GCZJZHbindingSource.Current as DataRowView;

                    //获取操作高度
                    this.GDSZbindingSource.Filter = string.Format(" SYFW = '{0}' and BTMS='{1}' and GD='{2}'", "给排水", "操作高度", drCurrent["CZGD"]);
                    DataRowView drCZGD = this.GDSZbindingSource.Current as DataRowView;
                    this.GDSZbindingSource.Filter = string.Format(" SYFW = '{0}' and BTMS='{1}' and GD='{2}'", "给排水", "操作部位", drCurrent["CZBW"]);
                    DataRowView drCZBW = this.GDSZbindingSource.Current as DataRowView;
                    #region 确定清单
                    this.GPSQDQDbindingSource.Filter = string.Format("CZ like '%,{0},%'", toString(drCurrent["CZ"]));
                    DataRow dr = APP.UnInformation.QDTable.NewRow();
                    if (0 < this.GPSQDQDbindingSource.Count)
                    {
                        DataRowView view = this.GPSQDQDbindingSource[0] as DataRowView;
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
                        dr["WZLX"] = WZLX.分部分项;
                    }
                    #endregion

                    #region 确定定额
                    List<DataRow> rows = new List<DataRow>();
                    StringBuilder sb = new StringBuilder();

                    string strSSJZ = toString(drCurrent["SSJZ"]);//输送介质
                    if (string.IsNullOrEmpty(toString(drCurrent["SSJZ"])))
                    {
                        strSSJZ = this.SSJZ;
                    }

                    #region 确定管道定额
                    //string strDEWhere = string.Format("AZBW like '%,{0},%' and SSJZ like '%,{1},%' and CZ like '%,{2},%' and {3} and {4}"
                    //                                    , this.AZBW, strSSJZ, drCurrent["CZ"]
                    //                                    , string.IsNullOrEmpty(toString(drCurrent["LJFS"])) ? " LJFS is null " : "LJFS like '%," + drCurrent["LJFS"] + ",%'"
                    //                                    ,string.IsNullOrEmpty(toString(drCurrent["GG"])) ? " GG is null " : "GG like '%," + drCurrent["GG"] + ",%'");

                    string strDEWhere = string.Format("AZBW like '%,{0},%' and SSJZ like '%,{1},%' and CZ like '%,{2},%' and LJFS = '{3}' and GG like '%,{4},%'"
                                    , this.AZBW, strSSJZ, drCurrent["CZ"], drCurrent["LJFS"], drCurrent["GG"]);
                    this.QDGDDEbindingSource.Filter = strDEWhere;
                    foreach (DataRowView item in this.QDGDDEbindingSource)
                    {
                        DataRow row = APP.UnInformation.DETable.NewRow();
                        string DEBHXS = "";
                        if (drCZGD != null)
                            DEBHXS = toString(drCZGD["XS"]);
                        if (drCZBW != null)
                        {
                            if (!string.IsNullOrEmpty(DEBHXS))
                            {
                                DEBHXS += toString(drCZBW["XS"]).Replace("r", "");
                            }
                            else
                            {
                                DEBHXS = toString(drCZBW["XS"]);
                            }
                        }
                        row["DEBH"] = toString(toString(item["DEBH"]) + "　" + DEBHXS);
                        row["DEMC"] = item["DEMC"];
                        row["DW"] = item["DEDW"];
                        row["XS"] = item["GCLXS"];
                        row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                        row["QDBH"] = dr["QDBH"];
                        row["TJ"] = strTJ;
                        row["WZLX"] = WZLX.分部分项;
                        row["ZCMCTH"] = toString(drCurrent["CZ"]) + " " + toString(drCurrent["GG"]);
                        rows.Add(row);
                        sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                    }
                    #endregion

                    if (drGCZJ != null)//需要用到公称直径、计算直径
                    {

                        #region 其他给排水确定定额
                        strDEWhere = string.Format("TGCZ = '{0}' and MinGGFW<={1} and MaxGGFW >= {1} "
                                                            , drCurrent["TGCZ"], ToolKit.ParseInt(drGCZJ["GCZJ"]));
                        this.QTGPSQDDEbindingSource.Filter = strDEWhere;
                        foreach (DataRowView item in this.QTGPSQDDEbindingSource)
                        {
                            DataRow row = APP.UnInformation.DETable.NewRow();
                            row["DEBH"] = item["DEBH"];
                            row["DEMC"] = item["DEMC"];
                            row["DW"] = item["DEDW"];
                            if (toString(item["GCLXS"]).Equals("G"))
                            {
                                row["XS"] = double.Parse(dr["GCL"].ToString()) == 0.0d ? 0 : Math.Round(ToolKit.ParseDecimal(drCurrent["TGGS"]) / ToolKit.ParseDecimal(dr["GCL"]),6);
                                row["GCL"] = drCurrent["TGGS"];
                            }
                            else
                            {
                                row["XS"] = item["GCLXS"];
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                            }

                            row["QDBH"] = dr["QDBH"];
                            row["TJ"] = strTJ;
                            row["WZLX"] = WZLX.分部分项;
                            rows.Add(row);
                            sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                        }
                        #endregion

                        #region 管道消毒冲洗
                        if (toString(drCurrent["CZBW"]) == "管道间、管廊内")
                        {
                            this._gdxdcx = "管道压力试验";
                        }
                        else
                        {
                            this._gdxdcx = "";
                        }
                        string[] strWhere = null;
                        if (this.KeyID == 76 || this.KeyID == 73)
                        {
                            strWhere = new string[] { string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", this.GDXDCX, ToolKit.ParseInt(drGCZJ["GCZJ"]))
                                                      ,string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", "采暖", ToolKit.ParseInt(drGCZJ["GCZJ"])) };
                        }
                        else if(this.KeyID == 78 || this.KeyID == 68)// || this.KeyID == 91)
                        {
                            strWhere = new string[] { string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", this.GDXDCX, ToolKit.ParseInt(drGCZJ["GCZJ"]))
                                                      ,string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", "管道压力试验", ToolKit.ParseInt(drGCZJ["GCZJ"])) 
                                                      ,string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", "采暖", ToolKit.ParseInt(drGCZJ["GCZJ"])) };
                        }
                        else if (this.KeyID == 74 || this.KeyID == 77)
                        {
                            strWhere = new string[] { string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", this.GDXDCX, ToolKit.ParseInt(drGCZJ["GCZJ"]))
                                                      ,string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", toString(drCurrent["SSJZ"]), ToolKit.ParseInt(drGCZJ["GCZJ"]))
                                                      ,string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", "采暖", ToolKit.ParseInt(drGCZJ["GCZJ"]))};
                        }
                        else
                        {
                            strWhere = new string[] { string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", this.GDXDCX, ToolKit.ParseInt(drGCZJ["GCZJ"]))
                                                      ,string.Format("FL like '%,{0},%' and MinGGXH<={1} and MaxGGXH >= {1}", toString(drCurrent["SSJZ"]), ToolKit.ParseInt(drGCZJ["GCZJ"])) };
                        }

                        foreach (string strItem in strWhere)
                        {
                            this.GDXDCXbindingSource.Filter = strItem;
                            foreach (DataRowView item in this.GDXDCXbindingSource)
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
                        }
                        #endregion

                        #region 防腐刷油、除锈

                        Hashtable ht = new Hashtable();
                        ht.Add("KEY1", string.Format("FL = '除锈工程' and BW = '管道' and LX='{0}' ", drCurrent["CX"]));//添加keyvalue键值对
                        ht.Add("KEY2", string.Format("FL = '防腐刷油工程' and (BW='管道刷油' or BW= '管道防腐') and LX='{0}' ", drCurrent["BWQFFSYYQ"]));
                        ht.Add("KEY3", string.Format("FL = '防腐刷油工程' and (BW='管道刷油' or BW= '管道防腐') and LX='{0}' ", drCurrent["BWHFFSYYQ"]));
                        if (drCurrent.Row.Table.Columns.Contains("BWQFFSYYQ2"))
                            ht.Add("KEY4", string.Format("FL = '防腐刷油工程' and (BW='管道刷油' or BW= '管道防腐') and LX='{0}' ", drCurrent["BWQFFSYYQ2"]));
                        if (drCurrent.Row.Table.Columns.Contains("BWHFFSYYQ2")) 
                            ht.Add("KEY5", string.Format("FL = '防腐刷油工程' and (BW='管道刷油' or BW= '管道防腐') and LX='{0}' ", drCurrent["BWHFFSYYQ2"]));
                        foreach (string strItem in ht.Keys)
                        {
                            this.FFSYCXbindingSource.Filter = toString(ht[strItem]);
                            foreach (DataRowView item in this.FFSYCXbindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                string strGCLXS = toString(item["GCLXS"]);
                                if (strItem.Equals("KEY2") || strItem.Equals("KEY4"))
                                {
                                    strGCLXS = toString(item["BWQXS"]);

                                }
                                else if (strItem.Equals("KEY3") || strItem.Equals("KEY5"))
                                {
                                    strGCLXS = toString(item["BWHXS"]);
                                }
                                row["XS"] = ToolKit.Calculate(strGCLXS.Replace("Φ", toString(drGCZJ["JSZJ"])).Replace("HD", toString(drCurrent["BWHD"])));
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
                        decimal iBWHD = ToolKit.ParseDecimal(drCurrent["BWHD"]);
                        decimal iGCZJ = ToolKit.ParseDecimal(drGCZJ["GCZJ"]);
                        strWhere = new string[]{string.Format("FL='保温绝热工程' and BWLB = '保温层'  and BWFL='管道' and JRCL ='{0}' and (MinJRHD<={1} and MaxJRHD >= {1} or JRHD is null) and (MinSBZJ<={2} and MaxSBZJ >= {2} or SBZJ is null)"
                                                      , drCurrent["BWJRCLZL"], iBWHD,iGCZJ),
                                            string.Format("FL='保温绝热工程' and BWLB = '防潮层、保护层'  and BWFL='管道' and JRCL ='{0}'" , drCurrent["FCCBHCCL"])};
                        foreach (string strItem in strWhere)
                        {
                            this.BWJRGCbindingSource.Filter = strItem;
                            foreach (DataRowView item in this.BWJRGCbindingSource)
                            {
                                DataRow row = APP.UnInformation.DETable.NewRow();
                                row["DEBH"] = item["DEBH"];
                                row["DEMC"] = item["DEMC"];
                                row["DW"] = item["DEDW"];
                                //如果包含厚度  则执行特定算法
                                //3.1415926*(Φ*0.001+1.003*HD*0.001)*1.003*HD*0.001
                                string strGCLXS = toString(item["GCLXS"]).Replace("Φ", toString(drGCZJ["JSZJ"])).Replace("HD", toString(drCurrent["BWHD"]));
                                row["XS"] = ToolKit.Calculate(strGCLXS);
                                row["GCL"] = ToolKit.ParseDecimal(row["XS"]) * ToolKit.ParseDecimal(dr["GCL"]);
                                row["QDBH"] = dr["QDBH"];
                                row["TJ"] = strTJ;
                                row["WZLX"] = WZLX.分部分项;
                                rows.Add(row);
                                sb.Append(string.Format("{0},{1},{2},{3}|", row["DEBH"], row["XS"], "", ""));
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        DebugErr("公称直径转换表数据不全！" + drCurrent["GG"]);
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
        protected override void btnRefreshQDMC_Click(object sender, EventArgs e)
        {
            if (null == this.bindingSource1.Current) return;
            DataRowView drCurrent = this.bindingSource1.Current as DataRowView;
            string strKey = "项目特征";
            string strContent = "【项目特征】";
            int i = 0;
            if (!string.IsNullOrEmpty(this.AZBW))
            {
                strContent += "\r\n" + (++i) + ".安装部位：" + this.AZBW;
            }
            if (!string.IsNullOrEmpty(drCurrent["SSJZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".输送介质：" + drCurrent["SSJZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".材质：" + drCurrent["CZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["GG"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".规格：" + drCurrent["GG"];
            }
            if (!string.IsNullOrEmpty(drCurrent["LJFS"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".连接形式：" + drCurrent["LJFS"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZBW"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".操作部位：" + drCurrent["CZBW"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CZGD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".操作高度：" + drCurrent["CZGD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["TGCZ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".套管材质：" + drCurrent["TGCZ"];
            }
            if (!string.IsNullOrEmpty(drCurrent["CX"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".管道除锈：" + drCurrent["CX"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWQFFSYYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防腐、刷油要求：" + drCurrent["BWQFFSYYQ"];
            }
            if (drCurrent.Row.Table.Columns.Contains("BWQFFSYYQ2") && !string.IsNullOrEmpty(drCurrent["BWQFFSYYQ2"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防腐、刷油要求2：" + drCurrent["BWQFFSYYQ2"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWJRCLZL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温绝热材料种类：" + drCurrent["BWJRCLZL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWHD"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温厚度(mm)：" + drCurrent["BWHD"];
            }
            if (!string.IsNullOrEmpty(drCurrent["FCCBHCCL"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".防潮层、保护层：" + drCurrent["FCCBHCCL"];
            }
            if (!string.IsNullOrEmpty(drCurrent["BWHFFSYYQ"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温后防腐、刷油要求：" + drCurrent["BWHFFSYYQ"];
            }
            if (drCurrent.Row.Table.Columns.Contains("BWHFFSYYQ2") && !string.IsNullOrEmpty(drCurrent["BWHFFSYYQ2"].ToString()))
            {
                strContent += "\r\n" + (++i) + ".保温后防腐、刷油要求2：" + drCurrent["BWHFFSYYQ2"];
            }

            this.InformationForm.SetFixedName(strKey, strContent);

            strKey = "工程内容";
            strContent = "【工程内容】";
            i = 0;
            strContent += "\r\n" + (++i) + ".管道、管件及弯管的制作安装";
            strContent += "\r\n" + (++i) + ".套管的制作安装";
            if (this.SSJZ.Contains("采暖") || this.SSJZ.Contains("给水"))
            {
                strContent += "\r\n" + (++i) + ".管道消毒、冲洗";
            }
            if (this.SSJZ.Contains("采暖") || this.SSJZ.Contains("给水") || this.AZBW.Contains("埋地") || toString(drCurrent["CZBW"]).Contains("管道间、管廊内"))
            {
                strContent += "\r\n" + (++i) + ".管道水压及泄漏试验";
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

        #region SET popControl1
        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            popControl1.PopupControl.Size = new Size(e.Column.Width, popControl1.PopupControl.Height);
            string strSSJZ = toString(currRow["SSJZ"]);//输送介质
            if (string.IsNullOrEmpty(strSSJZ))
            {
                strSSJZ = this.SSJZ;
            }
            switch (e.Column.FieldName)
            {
                case "SSJZ":
                    popControl1.DataSource = this.strToTable(this.SSJZ, "SSJZ");
                    popControl1.ColName = new string[] { "输送介质|SSJZ|SSJZ" };
                    popControl1.RemoveDefaultColName = new string[] { "LJFS", "GG", "TGCZ", "CZ" };
                    popControl1.bind();
                    break;
                case "CZ":
                    if (this.ISBHCZ)
                    {
                        popControl1.DataSource = this.strToTable(this.CZ, "CZ");
                    }
                    else
                    {
                        this.QDGDDEbindingSource.Filter = string.Format("AZBW like '%,{0},%' and SSJZ like '%,{1},%'", this.AZBW, strSSJZ);
                        DataTable de = this.strToTable(this.QDGDDEbindingSource, "CZ", this.CZ.Split(','), ',');
                        popControl1.DataSource = this.RemoveRepeat(this.strToTable(this.QDGDDEbindingSource, "CZ", this.CZ.Split(','), ','), "CZ");
                    }
                    popControl1.ColName = new string[] { "材质|CZ|CZ" };
                    popControl1.RemoveDefaultColName = new string[] { "LJFS", "GG", "TGCZ" };
                    popControl1.bind();
                    break;
                case "LJFS":
                    this.QDGDDEbindingSource.Filter = string.Format(" (AZBW is null or AZBW like '%,{0},%') and SSJZ like '%,{1},%' and CZ like '%,{2},%'", this.AZBW, strSSJZ, toString(currRow["CZ"]));
                    DataView dvTemp = this.QDGDDEbindingSource.List as DataView;
                    if (dvTemp != null)
                    {
                        popControl1.DataSource = dvTemp.ToTable(true, "LJFS");
                    }
                    else
                    {
                        popControl1.DataSource = null;
                    }
                    popControl1.ColName = new string[] { "连接方式|LJFS|LJFS" };
                    popControl1.RemoveDefaultColName = new string[] { "GG", "TGCZ" };
                    popControl1.bind();
                    break;
                case "GG":
                    this.QDGDDEbindingSource.Filter = string.Format(" (AZBW is null or AZBW like '%,{0},%') and SSJZ like '%,{1},%' and CZ like '%,{2},%' and LJFS='{3}'"
                                                     , this.AZBW, strSSJZ, toString(currRow["CZ"]), toString(currRow["LJFS"]));
                    DataTable dt = this.RemoveRepeat(this.strToTable(this.QDGDDEbindingSource, "GG", ','), "GG");
                    if (dt != null)
                        dt.DefaultView.Sort = "GG asc";
                    popControl1.DataSource = dt;
                    popControl1.ColName = new string[] { "规格|GG|GG" };
                    popControl1.RemoveDefaultColName = new string[] { "TGCZ", "BWHD" };
                    popControl1.bind();
                    break;
                case "CZBW":
                    string strWhere = string.Format("SYFW='{0}' and BTMS='{1}'", "给排水", "操作部位");
                    if (this._azbw == "埋地")
                    {
                        strWhere += " and GD<>'管道间、管廊内'";
                    }
                    this.GDSZbindingSource.Filter = strWhere;
                    popControl1.DataSource = this.RemoveRepeat(this.GDSZbindingSource, "GD");
                    popControl1.ColName = new string[] { "操作部位|GD|CZBW" };
                    popControl1.bind();
                    break;
                case "CZGD":
                    this.GDSZbindingSource.Filter = string.Format("SYFW='{0}' and BTMS='{1}'", "给排水", "操作高度");
                    popControl1.DataSource = this.RemoveRepeat(this.GDSZbindingSource, "GD");
                    popControl1.ColName = new string[] { "操作高度|GD|CZGD" };
                    popControl1.bind();
                    break;
                case "TGCZ":
                    this.GCZJZHbindingSource.Filter = string.Format("YSGG='{0}'", currRow["GG"]);
                    int GCZJ = -1;//公称直径
                    foreach (DataRowView item in this.GCZJZHbindingSource)
                    {
                        GCZJ = ToolKit.ParseInt(item["GCZJ"]);
                    }
                    this.TGGGFWbindingSource.Filter = string.Format("MinGGFW<={0} and MaxGGFW>={0}", GCZJ);
                    popControl1.DataSource = this.RemoveRepeat(this.strToTable(this.TGGGFWbindingSource, "TGCZ", ','), "TGCZ");
                    popControl1.ColName = new string[] { "套管材质|TGCZ|TGCZ" };
                    popControl1.bind();
                    break;
                case "CX":
                    this.FFSYCXbindingSource.Filter = "FL='除锈工程' and BW='管道'";
                    popControl1.DataSource = this.FFSYCXbindingSource;
                    popControl1.ColName = new string[] { "除锈|LX|CX" };
                    popControl1.bind();
                    break;
                case "BWQFFSYYQ":
                    this.FFSYCXbindingSource.Filter = "FL='防腐刷油工程' and (BW='管道刷油' or BW='管道防腐')";
                    popControl1.DataSource = this.FFSYCXbindingSource;
                    popControl1.ColName = new string[] { "保温前防腐、刷油要求|LX|BWQFFSYYQ" };
                    popControl1.bind();
                    break;
                case "BWQFFSYYQ2":
                    this.FFSYCXbindingSource.Filter = "FL='防腐刷油工程' and (BW='管道刷油' or BW='管道防腐')";
                    popControl1.DataSource = this.FFSYCXbindingSource;
                    popControl1.ColName = new string[] { "保温前防腐、刷油要求|LX|BWQFFSYYQ2" };
                    popControl1.bind();
                    break;
                case "BWJRCLZL":
                    this.BWJRGCbindingSource.Filter = "FL='保温绝热工程' and BWLB='保温层' and BWFL='管道'";
                    popControl1.DataSource = this.RemoveRepeat(this.BWJRGCbindingSource, "JRCL");
                    popControl1.ColName = new string[] { "保温绝热材料种类|JRCL|BWJRCLZL" };
                    popControl1.bind();
                    break;
                case "TGGS":
                    repositoryItemSpinEdit1.MinValue = 1;
                    repositoryItemSpinEdit1.MaxValue = 99999999999999;
                    break;
                case "BWHD":
                    repositoryItemSpinEdit1.MinValue = 0;
                    repositoryItemSpinEdit1.MaxValue = 1;

                    this.GCZJZHbindingSource.Filter = string.Format("YSGG='{0}'", currRow["GG"]);
                    int JSZJ = -1;//计算直径
                    foreach (DataRowView item in this.GCZJZHbindingSource)
                    {
                        JSZJ = ToolKit.ParseInt(item["JSZJ"]);
                    }
                    this.BWJRGCbindingSource.Filter = string.Format("FL='保温绝热工程' and BWLB='保温层' and BWFL='管道' and JRCL='{0}' and MinSBZJ<={1} and MaxSBZJ>={1}", currRow["BWJRCLZL"], JSZJ);
                    if (this.BWJRGCbindingSource.DataSource != null)
                    {
                        this.BWJRGCbindingSource.Sort = "MinJRHD asc";
                        DataRowView rowTemp = this.BWJRGCbindingSource.Current as DataRowView;
                        if (rowTemp != null)
                        {
                            repositoryItemSpinEdit1.MinValue = ToolKit.ParseDecimal(rowTemp["MinJRHD"]);
                        }
                        this.BWJRGCbindingSource.Sort = "MaxJRHD desc";
                        rowTemp = this.BWJRGCbindingSource.Current as DataRowView;
                        if (rowTemp != null)
                        {
                            repositoryItemSpinEdit1.MaxValue = ToolKit.ParseDecimal(rowTemp["MaxJRHD"]);
                        }
                    }
                    break;
                case "FCCBHCCL":
                    this.BWJRGCbindingSource.Filter = "FL='保温绝热工程' and BWLB='防潮层、保护层' and BWFL='管道'";
                    popControl1.DataSource = this.RemoveRepeat(this.BWJRGCbindingSource, "JRCL");
                    popControl1.ColName = new string[] { "防潮层、保护层材料|JRCL|FCCBHCCL" };
                    popControl1.bind();
                    break;
                case "BWHFFSYYQ":
                    this.FFSYCXbindingSource.Filter = "FL='防腐刷油工程' and (BW='管道刷油' or BW='管道防腐')";
                    popControl1.DataSource = this.FFSYCXbindingSource;
                    popControl1.ColName = new string[] { "保温后防腐、刷油要求|LX|BWHFFSYYQ" };
                    popControl1.bind();
                    break;
                case "BWHFFSYYQ2":
                    this.FFSYCXbindingSource.Filter = "FL='防腐刷油工程' and (BW='管道刷油' or BW='管道防腐')";
                    popControl1.DataSource = this.FFSYCXbindingSource;
                    popControl1.ColName = new string[] { "保温后防腐、刷油要求|LX|BWHFFSYYQ2" };
                    popControl1.bind();
                    break;
            }
        }
        #endregion

        private void popControl1_onCurrentChanged(popControl Sender, DataRowView CurrRowView)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (currRow == null) { return; }
            this.bindPopReturn(Sender, CurrRowView);
            this.gridView1.HideEditor();
        }

    }
}