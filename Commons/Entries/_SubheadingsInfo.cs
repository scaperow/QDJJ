using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using ZiboSoft.Commons.Common;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 分部分项-子目对象
    /// </summary>
    [Serializable]
    public class _SubheadingsInfo : _ObjectInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_Parent"></param>
        //public _SubheadingsInfo(_FixedListInfo p_Parent)
        //{
        //    this.m_Parent = p_Parent;
        //    NewInfo();
        //}

        /// <summary>
        /// 空构造
        /// </summary>
        public _SubheadingsInfo()
        {
            NewInfo();
        }
        public override _UnitProject Activitie
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent.Activitie;
            }
        }
        /// <summary>
        /// 初始化：子目下的所有对象
        /// </summary>
        public virtual void NewInfo()
        {
            this.m_SubheadingsQuantityUnitList = new _SubheadingsQuantityUnitList(this);
            this.m_StandardConversionList = new _StandardConversionList(this);
            this.m_Subheadings_Statistics = new _Subheadings_Statisticss(this);
            this.m_SubheadingsFeeList = new _SubheadingsFeeList(this);
            this.Statistics = new _Subheadings_Statistics_Return(this);
            this.m_IncreaseCostsList = new _IncreaseCostsList(this);
            //this.m_QDBH = this.Parent.OLDXMBM;
        }
        private bool m_SetOp = true;
        /// <summary>
        /// 是否记录工料机操作
        /// </summary>
        public bool SetOp
        {
            get { return m_SetOp; }
            set { m_SetOp = value; }
        }
        /// <summary>
        /// 工料机操作记录
        /// </summary>
        /// <param name="p_txt">操作内容</param>
        public virtual void SetOpera(string p_txt)
        {
            if (m_SetOp)
            {
                this.XMMC += p_txt;
                this.Activitie.Property.SubSegments.DataSource.ResetBindings(false);
            }
        }

        #region----------------------私有属性---------------------------------
        /// <summary>
        /// 所属清单
        /// </summary>
        private _FixedListInfo m_Parent = null;

        /// <summary>
        /// 子目工料机集合对象
        /// </summary>
        private _SubheadingsQuantityUnitList m_SubheadingsQuantityUnitList = null;

        /// <summary>
        /// 子目取费集合对象
        /// </summary>
        private _SubheadingsFeeList m_SubheadingsFeeList = null;

        /// <summary>
        /// 标准换算集合对象
        /// </summary> 
        private _StandardConversionList m_StandardConversionList = null;

        /// <summary>
        /// 子目增加费对象
        /// </summary>
        private _IncreaseCostsList m_IncreaseCostsList;

        /// <summary>
        /// 子目基础结果
        /// </summary>
        private _Subheadings_Statisticss m_Subheadings_Statistics = null;

        private bool m_IsHs = true;

        /// <summary>
        /// 是否换算
        /// </summary>
        public bool IsHs
        {
            get { return m_IsHs; }
            set { m_IsHs = value; }
        }
        #endregion

        #region----------------------公共属性---------------------------------
        /// <summary>
        /// 所属清单
        /// </summary>
        public _FixedListInfo Parent
        {
            get { return this.m_Parent; }
            set { this.m_Parent = value; }
        }
        /// <summary>
        /// 获取或设置：子目工料机集合对象
        /// </summary>
        public _SubheadingsQuantityUnitList SubheadingsQuantityUnitList
        {
            get { return m_SubheadingsQuantityUnitList; }
            set { m_SubheadingsQuantityUnitList = value; }
        }

        /// <summary>
        /// 获取或设置：标准换算集合对象
        /// </summary>
        public _StandardConversionList StandardConversionList
        {
            get { return m_StandardConversionList; }
            set { m_StandardConversionList = value; }
        }

        /// <summary>
        /// 获取或设置：子目取费集合对象
        /// </summary>
        public _SubheadingsFeeList SubheadingsFeeList
        {
            get { return m_SubheadingsFeeList; }
            set { m_SubheadingsFeeList = value; }
        }
        /// <summary>
        /// 获取或设置：子目基础结果
        /// </summary>
        public _Subheadings_Statisticss Subheadings_Statistics
        {
            get { return m_Subheadings_Statistics; }
            set { m_Subheadings_Statistics = value; }
        }

        /// <summary>
        /// 获取或设置：子目增加费对象
        /// </summary>
        public _IncreaseCostsList IncreaseCostsList
        {
            get { return m_IncreaseCostsList; }
            set { m_IncreaseCostsList = value; }
        }

        #endregion

        #region----------------------集合BindingSource---------------------------------
        /// <summary>
        /// 子目工料机BindingSource
        /// </summary>
        [NonSerialized]
        private BindingSource m_SubheadingsQuantityUnitList_BindingSource = new BindingSource();

        /// <summary>
        /// 获取：子目工料机BindingSource
        /// </summary>
        public BindingSource SubheadingsQuantityUnitList_BindingSource
        {
            get
            {
                if (this.m_SubheadingsQuantityUnitList_BindingSource == null)
                {
                    this.m_SubheadingsQuantityUnitList_BindingSource = new BindingSource();
                }
                if (this.SubheadingsQuantityUnitList.Count > 0)
                    this.m_SubheadingsQuantityUnitList_BindingSource.DataSource = this.SubheadingsQuantityUnitList;
                return this.m_SubheadingsQuantityUnitList_BindingSource;
            }
        }


        /// <summary>
        /// 标准换算BindingSource
        /// </summary>
        [NonSerialized]
        private BindingSource m_StandardConversionList_BindingSource = new BindingSource();

        /// <summary>
        /// 获取：标准换算BindingSource
        /// </summary>
        public BindingSource StandardConversionList_BindingSource
        {
            get
            {
                if (this.m_StandardConversionList_BindingSource == null)
                {
                    this.m_StandardConversionList_BindingSource = new BindingSource();
                }
                if (this.m_StandardConversionList.Count > 0)
                    this.m_StandardConversionList_BindingSource.DataSource = this.m_StandardConversionList;
                return this.m_StandardConversionList_BindingSource;
            }
        }

        /// <summary>
        /// 子目取费BindingSource
        /// </summary>
        [NonSerialized]
        private BindingSource m_SubheadingsFeeList_BindingSource = new BindingSource();

        /// <summary>
        /// 获取：子目取费BindingSource
        /// </summary>
        public BindingSource SubheadingsFeeList_BindingSource
        {
            get
            {
                if (this.m_SubheadingsFeeList_BindingSource == null)
                {
                    this.m_SubheadingsFeeList_BindingSource = new BindingSource();
                }
                if (this.m_SubheadingsFeeList.Count > 0)
                    this.m_SubheadingsFeeList_BindingSource.DataSource = this.m_SubheadingsFeeList;
                return this.m_SubheadingsFeeList_BindingSource;
            }
        }
        #endregion

        #region----------------------重写属性---------------------------------
        /// <summary>
        /// 获取或设置：工程量
        /// </summary>
        public override decimal GCL
        {
            get { return base.GCL; }
            set
            {

                int flag = 0;
                if (this.Activitie != null)
                {
                    if (this.Activitie.Application != null)
                    {
                        flag = ToolKit.ParseInt(this.Activitie.Application.Global.Configuration.Configs["工程量输入方式"]);
                    }
                }
                if (flag > 0)
                {
                    //通知属性修改
                    if (this.ISXSHS)
                        base.GCL = value / GetNumber();
                    else base.GCL = value;

                    //if (this.STATUS)
                    //{
                    //    if (this.Parent != null)
                    //    {
                    //        if (this.ISXSHS)
                    //        {
                    //            if (this.Parent.GCL > 0)
                    //                base.HL = base.GCL / this.Parent.GCL;
                    //        }
                    //    }
                       
                    //}
                    //this.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                }
                else 
                {
                    base.GCL = value;
                }
                if (this.Parent != null)
                {
                    if (this.Parent.GCL > 0)
                        base.HL = base.GCL / this.Parent.GCL;
                }
                SetGCL(base.GCL);
                this.Begin();
            }
        }

        /// <summary>
        /// 获取字符窜中第一个字母前的所有数字
        /// </summary>
        /// <returns></returns>
        private decimal GetNumber()
        {
            string Str = this.DW;
            Str = System.Text.RegularExpressions.Regex.Match(Str, @"[0-9]\d+(\.\d+)?").Value;
            if (Str == string.Empty)
            {
                return 1m;
            }
            else
            {
                return decimal.Parse(Str);
            }

        }

        ///// <summary>
        ///// 获取或设置：直接调价
        ///// </summary>
        //public override decimal ZJTJ
        //{
        //    get { return base.ZJTJ; }
        //    set
        //    {
        //        base.ZJTJ = value;
        //        //C=直接调价/综合单价,子目工料机的消耗量变更为原消耗量*C
        //        if (this.STATUS)
        //        {
        //            UpXHL(value);
        //        }
        //    }
        //}



        /// <summary>
        /// 获取或设置：含量
        /// </summary>
        public override decimal HL
        {
            get { return base.HL; }
            set
            {
                base.HL = value;
                //if (this.STATUS)//确定是修改还是添加
                //{

                //int flag = 0;
                //if (this.Activitie != null)
                //{
                //    if (this.Activitie.Application != null)
                //    {
                //        flag = ToolKit.ParseInt(this.Activitie.Application.Global.Configuration.Configs["工程量输入方式"]);
                //    }
                //}
                //if (flag > 0)
                //{
                    if (this.ISXSHS)
                    {
                        SetHL(value);
                        SetGCL(base.GCL);
                        this.Begin();
                    }
                //}
                //}
            }
        }
        ///// <summary>
        ///// 通过方法给含量赋值不导致计算
        ///// </summary>
        ///// <param name="d"></param>
        //public void SetHLS(decimal d)
        //{
        //    base.HL = d;
        //}
        /// <summary>
        /// 是否计算（在批量修改消耗量的时候，修改完之后只计算一次）
        /// </summary>
        private bool m_IsCalc;

        /// <summary>
        /// 获取或设置：是否计算（在批量修改消耗量的时候，修改完之后只计算一次）
        /// </summary>
        public bool IsCalc
        {
            get { return m_IsCalc; }
            set
            {
                m_IsCalc = value;
            }
        }
        #endregion

        #region----------------------计算、创建、调控方法---------------------------------
        /// <summary>
        /// 修改工料机的消耗量
        /// </summary>
        /// <param name="value"></param>
        private void UpXHL(decimal value)
        {
            decimal zhdj = this.ZHDJ;
            if (zhdj == 0)
            {
                zhdj = 1;
            }
            decimal c = value / zhdj;
            Math.Round(c, 6);
            _List t = GetAllQuantityUnit;
            this.m_IsCalc = false;
            foreach (_ObjectQuantityUnitInfo item in t)
            {
                item.XHL = item.XHL * c;
            }
            this.m_Subheadings_Statistics.Begin();
            this.m_IsCalc = true;
        }

        /// <summary>
        /// 计算工程量
        /// </summary>
        /// <param name="p_HL">含量</param>
        private void SetHL(decimal p_HL)
        {
            if (this.Parent == null) return;
            base.GCL = this.Parent.GCL * p_HL;
        }


        public void SetHL()
        {
            if (this.HL > 0)
            {
                base.GCL = this.Parent.GCL * this.HL;
            }
            else
            {
                base.GCL = this.Parent.GCL;
            }
            this.Begin();
        }
        /// <summary>
        /// 设置下属工程量
        /// </summary>
        /// <param name="p_GCL">工程量</param>
        private void SetGCL(decimal p_GCL)
        {
            foreach (_SubheadingsQuantityUnitInfo info in this.SubheadingsQuantityUnitList)
            {
                info.STATUS = Status.Update;
                info.GCL = p_GCL;

            }

            this.m_Subheadings_Statistics.Begin();
        }

        /// <summary>
        /// 创建：子目工料机、标准换算、子目取费、子目基础结果集
        /// </summary>
        public void Create()
        {
            if (this.LB == "子目" || this.LB == "子目-降效" || this.LB == "子目-增加费")
            {
                if (this.DECJ != string.Empty)
                {
                    if (this.m_SubheadingsQuantityUnitList.Count < 1) CreateZMGLJ();

                }
                if (this.m_StandardConversionList.Count < 1) CreateBZHS();
                if (this.m_SubheadingsFeeList.Count < 1) CreateZMQFS();
                this.Parent.IFChange = true;
            }
        }

        /// <summary>
        /// 创建子目增加费
        /// </summary>
        public void CreateIncrease(_IncreaseCostsInfo info)
        {
            this.m_IncreaseCostsList.Add(info);
        }


        /// <summary>
        /// 开始计算
        /// </summary>
        public void Begin()
        {
            this.Statistics.Begin();
            this.IncreaseBegin();
            if (this.Parent!=null)
            this.Parent.Begin();
        }
        private void IncreaseBegin()
        {
            foreach (_IncreaseCostsInfo item in this.IncreaseCostsList)
            {
                item.Begin();
            }
        }

        /// <summary>
        /// 刷新子目
        /// </summary>
        public void RefreshSubheadings()
        {
            this.m_SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
            this.m_SubheadingsFeeList_BindingSource.ResetBindings(false);
        }

        public virtual string GetSSDWGCLB()
        {
            return string.Empty;
        }

        /// <summary>
        /// 创建：子目工料机
        /// </summary>
        private void CreateZMGLJ()
        {
            if (this.XMBM.Trim() != string.Empty)
            {
                string whxmbm = this.XMBM.Replace("换", "");
                string[] m_FirstArr = whxmbm.Split(' ');
                if (m_FirstArr.Length == 1)
                {
                    CreateGLJ();
                }
                else
                {
                    for (int i = 1; i < m_FirstArr.Length; i++)
                    {
                        string[] sjhd = m_FirstArr[i].Split('*');

                        switch (sjhd[0])
                        {
                            case "":
                                Preparation(sjhd[0], ToolKit.Calculate("1" + m_FirstArr[i]));
                                break;
                            case "R":
                            case "C":
                            case "J":
                                Preparation(sjhd[0], ToolKit.Calculate(m_FirstArr[i].Replace(sjhd[0], "1")));
                                break;
                            default:
                                string deh = string.Empty;
                                if (sjhd[0].StartsWith("+") || sjhd[0].StartsWith("-"))
                                {
                                    deh = sjhd[0].Substring(1, sjhd[0].Length-1);
                                    Preparation(sjhd[0].Substring(0, 1), deh, ToolKit.Calculate(m_FirstArr[i].Replace(sjhd[0], "1")));
                                }
                                break;
                        }
                    }
                    CreateGLJ();
                }
            }
        }

        /// <summary>
        /// 带定额号
        /// </summary>
        /// <param name="ysde"></param>
        /// <param name="ysf"></param>
        /// <param name="deh"></param>
        /// <param name="s"></param>
        private void Preparation(string p_Symbol, string p_DEH, decimal p_Num)
        {
            DataRow dr = GetDE(p_DEH);
            if (dr != null)
            {
                string[] m_DECJ = dr["DECJ"].ToString().Split('|');
                foreach (string item in m_DECJ)
                {
                    if (item.Trim() != string.Empty)
                    {
                        string[] items = item.Split(',');
                        string m_bh = items[0].ToString();
                        decimal m_xhl = items.Length == 4 ? ToolKit.ParseDecimal(items[3]) : ToolKit.ParseDecimal(items[1]);
                        m_xhl = m_xhl * p_Num;
                        if (this.DECJ.Contains(m_bh))
                        {
                            string strk = this.DECJ.Substring(this.DECJ.IndexOf(m_bh), this.DECJ.Length - this.DECJ.IndexOf(m_bh));
                            string y_item = strk.Substring(0, strk.IndexOf('|'));
                            string[] y_items = y_item.Split(',');
                            decimal y_xhl = y_items.Length == 4 ? ToolKit.ParseDecimal(y_items[3]) : ToolKit.ParseDecimal(y_items[1]);
                            if (p_Symbol == "+")
                            {
                                m_xhl = y_xhl + m_xhl;
                            }
                            else
                            {
                                m_xhl = y_xhl - m_xhl;
                            }
                            this.DECJ = this.DECJ.Replace(y_item, items[0] + "," + items[1] + "," + items[2] + "," + m_xhl);
                        }
                        else
                        {
                            if (p_Symbol == "+")
                            {
                                this.DECJ += items[0] + "," + items[1] + "," + items[2] + "," + m_xhl + "|";
                            }
                            else
                            {
                                this.DECJ += items[0] + "," + items[1] + "," + items[2] + "," + (0 - m_xhl) + "|";
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 单个定额号的处理 比如4-1 *2*2*2*2 R*2
        /// </summary>
        /// <param name="ysde"></param>
        /// <param name="rcl"></param>
        /// <param name="s"></param>
        private void Preparation(string p_RCJType, decimal p_Num)
        {
            string[] strs = this.DECJ.Split('|');
            string m_XDECJ = string.Empty;
            foreach (string item in strs)
            {
                if (item.Trim() != string.Empty)
                {
                    string[] items = item.Split(',');
                    string m_bh = items[0].ToString();
                    decimal m_xhl = items.Length == 4 ? ToolKit.ParseDecimal(items[3]) : ToolKit.ParseDecimal(items[1]);
                    switch (p_RCJType)
                    {
                        case "R":
                            DataRow rdr = GetRCJ(m_bh);
                            if (rdr != null)
                            {
                                if (_Constant.rg.Contains("'" + rdr["CAIJLB"].ToString() + "'"))
                                {
                                    m_xhl = m_xhl * p_Num;
                                }
                            }
                            break;
                        case "C":
                            DataRow rdc = GetRCJ(m_bh);
                            if (rdc != null)
                            {
                                if (_Constant.cl.Contains("'" + rdc["CAIJLB"].ToString() + "'"))
                                {
                                    m_xhl = m_xhl * p_Num;
                                }
                            }
                            break;
                        case "J":
                            DataRow rdj = GetRCJ(m_bh);
                            if (rdj != null)
                            {
                                if (_Constant.jx.Contains("'" + rdj["CAIJLB"].ToString() + "'"))
                                {
                                    m_xhl = m_xhl * p_Num;
                                }
                            }
                            break;
                        default:
                            m_xhl = m_xhl * p_Num;
                            break;
                    }
                    m_XDECJ += items[0] + "," + items[1] + "," + items[2] + "," + m_xhl + "|";
                }
            }
            this.DECJ = m_XDECJ;
        }

        /// <summary>
        /// 获取人材机
        /// </summary>
        /// <param name="p_bh">人材机编号</param>
        /// <returns></returns>
        private DataRow GetRCJ(string p_bh)
        {
            _Library.GetLibrary(this.LibraryName);
            DataTable dt = (_Library.Libraries[this.LibraryName] as DataSet).Tables["材机表"];
            DataRow[] dr = dt.Select(string.Format("CAIJBH ='{0}'", p_bh));
            if (dr != null)
            {
                if (dr.Length == 1)
                {
                    return dr[0];
                }
            }
            return null;
        }

        /// <summary>
        /// 获取定额材机
        /// </summary>
        /// <param name="p_DEH">定额号</param>
        /// <returns></returns>
        private DataRow GetDE(string p_DEH)
        {
            _Library.GetLibrary(this.LibraryName);
            DataTable dt = (_Library.Libraries[this.LibraryName] as DataSet).Tables["定额表"];
            DataRow[] dr = dt.Select(string.Format("DINGEH='{0}'", p_DEH));
            if (dr != null)
            {
                if (dr.Length == 1)
                {
                    return dr[0];
                }
            }
            return null;
        }

        /// <summary>
        /// 创建工料机（根据定额材机）
        /// </summary>
        private void CreateGLJ()
        {
            _Library.GetLibrary(this.LibraryName);
            DataTable dt = (_Library.Libraries[this.LibraryName] as DataSet).Tables["材机表"];
            if (this.DECJ != string.Empty)
            {
                string[] strs = this.DECJ.Split('|');
                CEntityQuantityUnit[] infos = new CEntityQuantityUnit[strs.Length - 1];
                for (int i = 0; i < strs.Length - 1; i++)
                {
                    string[] str = strs[i].Split(',');
                    DataRow[] dr = dt.Select(string.Format("CAIJBH ='{0}'", str[0].ToString()));
                    if (dr != null)
                    {
                        if (dr.Length < 1)
                        {
                            continue;
                        }
                        _SubheadingsQuantityUnitInfo info = new _SubheadingsQuantityUnitInfo(this);
                        info.STATUS = Status.AreAdd;
                        info.YSBH = dr[0]["CAIJBH"].ToString();
                        info.YSMC = dr[0]["CAIJMC"].ToString();
                        info.YSDW = dr[0]["CAIJDW"].ToString();
                        info.YSXHL = Convert.ToDecimal(str[1]);
                        info.BH = dr[0]["CAIJBH"].ToString();
                        info.MC = dr[0]["CAIJMC"].ToString();
                        info.DW = dr[0]["CAIJDW"].ToString();
                        info.LB = dr[0]["CAIJLB"].ToString();
                        info.XHL = str.Length == 4 && !info.LB.Contains("%") ? Convert.ToDecimal(str[3]) : Convert.ToDecimal(str[1]);
                        info.DEDJ = dr[0]["CAIJDJ"].ToString().Trim() == string.Empty ? 0m : Convert.ToDecimal(dr[0]["CAIJDJ"].ToString());
                        info.ZCLB = "W";
                        info.SDCLB = dr[0]["SANDCMC"].ToString();
                        info.SDCXS = dr[0]["SANDCXS"].ToString().Length == 0 ? 0m : Convert.ToDecimal(dr[0]["SANDCXS"]);
                        info.GCL = this.GCL;
                        info.SSKLB = this.LibraryName;
                        info.SSDWGCLB = GetSSDWGCLB();
                        info.SSDWGC = this.Activitie.Name;
                        _ObjectQuantityUnitInfo y_info = this.Activitie.Property.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == info.BH).FirstOrDefault();
                        if (y_info == null)
                        {
                            info.IFSC = dr[0]["CAIJSC"].ToString() == "是" ? true : false;
                            info.IFZYCL = dr[0]["CAIJXSJG"].ToString() == "是" ? true : false;
                            if (str[2] != string.Empty)
                            {
                                info.SCDJ = Convert.ToDecimal(str[2]);
                            }
                            else
                            {
                                if (info.LB == "主材" || info.LB == "设备")
                                {
                                    info.SCDJ = 0m;
                                }
                                else
                                {
                                    info.SCDJ = info.DEDJ;
                                }
                            }
                        }
                        else
                        {
                            info.IFSC = y_info.IFSC;
                            info.IFFX = y_info.IFFX;
                            info.IFSDSCDJ = y_info.IFSDSCDJ;
                            info.IFZYCL = y_info.IFZYCL;
                            info.YTLB = y_info.YTLB;
                            info.SCDJ = y_info.SCDJ;
                            info.JSDJ = y_info.JSDJ;
                            info.CJ = y_info.CJ;
                            info.PP = y_info.PP;
                            info.ZLDJ = y_info.ZLDJ;
                            info.GYS = y_info.GYS;
                            info.CD = y_info.CD;
                            info.CJBZ = y_info.CJBZ;
                        }
                        info.Create();
                        info.STATUS = Status.Normal;
                        this.m_SubheadingsQuantityUnitList.Add(info);
                    }
                }
            }
        }
        /// <summary>
        /// 创建：子目工料机
        /// </summary>
        [ActionAttribute(Command.Create, "子目工料机")]
        public bool CreateZMGLJ(_ObjectQuantityUnitInfo p_info)
        {
            if (p_info != null)
            {
                _ObjectQuantityUnitInfo c_info = null;
                if (this.Activitie.Property.RepeatInfo(p_info, out c_info) && this.SubheadingsQuantityUnitList.GetCount(p_info) == 0)
                {
                    _SubheadingsQuantityUnitInfo info = new _SubheadingsQuantityUnitInfo(this);
                    info.STATUS = Status.AreAdd;
                    info.YSBH = p_info.YSBH;
                    info.YSMC = p_info.YSMC;
                    info.YSDW = p_info.YSDW;
                    info.YSXHL = 1m;
                    info.DEDJ = p_info.DEDJ;
                    info.BH = p_info.BH;
                    info.MC = p_info.MC;
                    info.DW = p_info.DW;
                    info.XHL = 1m;
                    info.SCDJ = p_info.SCDJ;
                    info.LB = p_info.LB;
                    info.ZCLB = "W";
                    info.SDCLB = p_info.SDCLB;
                    info.SDCXS = p_info.SDCXS;
                    info.GCL = this.GCL;
                    info.SSKLB = this.LibraryName;
                    info.SSDWGCLB = GetSSDWGCLB();
                    info.SSDWGC = this.Activitie.Name;
                    if (info.LB == "主材" || info.LB == "设备")
                    {
                        info.SCDJ = 0m;
                    }
                    if (c_info != null)
                    {
                        info.IFSC = c_info.IFSC;
                        info.IFFX = c_info.IFFX;
                        info.IFSDSCDJ = c_info.IFSDSCDJ;
                        info.IFZYCL = c_info.IFZYCL;
                        info.YTLB = c_info.YTLB;
                        info.JSDJ = c_info.JSDJ;
                        info.CJ = c_info.CJ;
                        info.PP = c_info.PP;
                        info.ZLDJ = c_info.ZLDJ;
                        info.GYS = c_info.GYS;
                        info.CD = c_info.CD;
                        info.CJBZ = c_info.CJBZ;
                    }
                    info.Create();
                    int index = (this.SubheadingsQuantityUnitList.IndexOf(this.SubheadingsQuantityUnitList_BindingSource.Current) + 1);
                    info.STATUS = Status.Normal;
                    this.m_SubheadingsQuantityUnitList.Add(index, info, true);
                    this.Subheadings_Statistics.Begin();
                    this.m_SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                    //对象设置为创建中状态
                    this.ActionAttribute("CreateZMGLJ", "子目工料机", info, null);
                    this.Activitie.BeginEdit(this);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 替换工料机
        /// </summary>
        /// <param name="this.new_info">需要增加的工料机</param>
        [ActionAttribute(Command.Replace, "替换工料机")]
        public bool ReplaceZMGLJ(_ObjectQuantityUnitInfo p_info)
        {
            if (p_info != null)
            {
                _ObjectQuantityUnitInfo m_info = this.SubheadingsQuantityUnitList_BindingSource.Current as _ObjectQuantityUnitInfo;
                _ObjectQuantityUnitInfo c_info = null;
                if (this.Activitie.Property.RepeatInfo(p_info, out c_info) && (this.SubheadingsQuantityUnitList.GetCount(p_info) == 0 || m_info.BH == p_info.BH))
                {
                    int index = this.SubheadingsQuantityUnitList.IndexOf(m_info);
                    this.m_SubheadingsQuantityUnitList.Remove(m_info);
                    _SubheadingsQuantityUnitInfo info = new _SubheadingsQuantityUnitInfo(this);
                    info.STATUS = Status.AreAdd;
                    info.YSBH = p_info.YSBH;
                    info.YSMC = p_info.YSMC;
                    info.YSDW = p_info.YSDW;
                    info.YSXHL = 1m;
                    info.DEDJ = p_info.DEDJ;
                    info.BH = p_info.BH;
                    info.MC = p_info.MC;
                    info.DW = p_info.DW;
                    info.XHL = 1m;
                    info.SCDJ = p_info.SCDJ;
                    info.LB = p_info.LB;
                    info.ZCLB = "W";
                    info.SDCLB = p_info.SDCLB;
                    info.SDCXS = p_info.SDCXS;
                    info.GCL = this.GCL;
                    info.SSKLB = this.LibraryName;
                    info.SSDWGCLB = GetSSDWGCLB();
                    info.SSDWGC = this.Activitie.Name;
                    if (info.LB == "主材" || info.LB == "设备")
                    {
                        info.SCDJ = 0m;
                    }
                    if (c_info != null)
                    {
                        info.IFSC = c_info.IFSC;
                        info.IFFX = c_info.IFFX;
                        info.IFSDSCDJ = c_info.IFSDSCDJ;
                        info.IFZYCL = c_info.IFZYCL;
                        info.YTLB = c_info.YTLB;
                        info.JSDJ = c_info.JSDJ;
                        info.CJ = c_info.CJ;
                        info.PP = c_info.PP;
                        info.ZLDJ = c_info.ZLDJ;
                        info.GYS = c_info.GYS;
                        info.CD = c_info.CD;
                        info.CJBZ = c_info.CJBZ;
                    }
                    info.Create();
                    info.STATUS = Status.Normal;
                    this.m_SubheadingsQuantityUnitList.Add(index, info, false);
                    this.Subheadings_Statistics.Begin();
                    this.m_SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                    this.ActionAttribute("ReplaceZMGLJ", "替换工料机", m_info, info);
                    this.Activitie.BeginEdit(this);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除工料机
        /// </summary>
        /// <param name="this.new_info">需要删除工料机</param>
        [ActionAttribute(Command.Delete, "删除工料机")]
        public void RemoveZMGLJ(_ObjectQuantityUnitInfo p_info)
        {
            int index = this.SubheadingsQuantityUnitList.IndexOf(p_info);
            this.SubheadingsQuantityUnitList.Remove(p_info);
            object p_TagValue = null;
            if (this.SubheadingsQuantityUnitList.Count == index)
            {
                index = index - 1;
            }
            if (index > -1)
            {
                p_TagValue = this.SubheadingsQuantityUnitList[index];
            }
            this.ActionAttribute("RemoveZMGLJ", "删除工料机", p_info, p_TagValue);
        }

        /// <summary>
        /// 创建：标准换算
        /// </summary>
        /// <param name="info"></param>
        public void CreateBZHS()
        {
            _Library.GetLibrary(this.LibraryName);
            DataSet ds = (_Library.Libraries[this.LibraryName] as DataSet);
            if (ds == null) return;
            DataRow[] drs = ds.Tables["定额换算表"].Select(string.Format("DINGEH = '{0}'", this.XMBM));
            foreach (DataRow dr in drs)
            {
                _StandardConversionInfo info = new _StandardConversionInfo(this);
                info.DEH = dr["DINGEH"].ToString();
                info.HSLB = dr["HUANSLB"].ToString();
                info.HSXX = dr["TISXX"].ToString();
                info.DJ_DW = dr["DJDW"].ToString();
                info.JBL_RGXS = dr["HUANSJS_R"].ToString();
                info.DEH_CLXS = dr["HUANSDEH_C"].ToString();
                info.TZL_JXXS = dr["ZENGL_J"].ToString();
                info.ZC = dr["ZC"].ToString();
                info.SB = dr["SB"].ToString();
                info.XHLB = dr["XHLB"].ToString();
                if (info.XHLB == "3")
                {
                    info.JBL_RGXS = info.DJ_DW;
                    info.DEH_CLXS = info.DJ_DW;
                    info.TZL_JXXS = info.DJ_DW;
                }
                info.FZ = dr["FZ"].ToString();
                info.THZHC = dr["THZHC"].ToString();
                info.THWZFC = dr["THWZFC"].ToString();
                info.HSXI = dr["HSXI"].ToString();

                if (info.HSLB == "0")
                {
                    this.m_StandardConversionList.StandardConversionInfo = info;
                }
                else
                {
                    this.m_StandardConversionList.Add(info);
                }
            }
        }

        /// <summary>
        /// 创建：子目取费
        /// </summary>
        public virtual void CreateZMQFS()
        {
            if (this.Activitie == null) return;
            if (this.OLDXMBM.Trim() == string.Empty) return;
            string m_XMBM = this.OLDXMBM;
            _UnitFeeInfo unitfee = this.Activitie.Property.ParameterSettings.GetUnitFeeInfo(m_XMBM);
            if (unitfee != null) { this.ZYLB = unitfee.GCLB.Replace("【", "").Replace("】", ""); }
            foreach (_YSSubheadingsFeeInfo item in this.Activitie.Property.ParameterSettings.YSSubheadingsFeeList)
            {
                _SubheadingsFeeInfo info = new _SubheadingsFeeInfo(this);
                info.STATUS = true;
                info.ID = item.ID;
                info.YYH = item.YYH;
                info.MC = item.MC;
                info.BDS = item.BDS;
                info.BZ = item.BZ;
                if (unitfee != null)
                {
                    switch (info.ID)
                    {
                        case 6:
                            info.TBJSJC = unitfee.FXFTBJSJC;
                            info.BDJSJC = unitfee.FXFBDJSJC;
                            info.FL = unitfee.FXTBFL;
                            break;
                        case 8:
                            info.TBJSJC = unitfee.GLFTBJSJC;
                            info.BDJSJC = unitfee.GLFBDJSJC;
                            info.FL = unitfee.GLFFL;
                            break;
                        case 9:
                            info.TBJSJC = unitfee.LRFTBJSJC;
                            info.BDJSJC = unitfee.LRFBDJSJC;
                            info.FL = unitfee.LRFL;
                            break;
                        default:
                            info.TBJSJC = item.TBJSJC;
                            info.BDJSJC = item.BDJSJC;
                            info.FL = item.FL;
                            break;
                    }
                }
                else
                {
                    info.TBJSJC = item.TBJSJC;
                    info.BDJSJC = item.BDJSJC;
                    info.FL = item.FL;
                }
                info.FYLB = item.FYLB;
                info.STATUS = false;
                this.m_SubheadingsFeeList.Add(info);
            }
        }

        /// <summary>
        /// 修改：子目取费
        /// </summary>
        public void UpdateZMQFS(_YSSubheadingsFeeList list)
        {
            foreach (_YSSubheadingsFeeInfo item in list)
            {
                _SubheadingsFeeInfo info = (from n in this.m_SubheadingsFeeList.Cast<_SubheadingsFeeInfo>()
                                            where n.YYH == item.YYH
                                            select n).First();
                if (!string.IsNullOrEmpty(item.TBJSJC))
                {
                    info.TBJSJC = item.TBJSJC;
                }
                if (!string.IsNullOrEmpty(item.BDJSJC))
                {
                    info.BDJSJC = item.BDJSJC;
                }
                if (item.FL > 0)
                {
                    info.FL = item.FL;
                }
            }
        }

        /// <summary>
        /// 获取：当前(子目工料机)下的所有(工料机与工料机组成)
        /// </summary>
        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_SubheadingsQuantityUnitInfo info in this.SubheadingsQuantityUnitList)
                {
                    list.Add(info);
                    list.AddRange(info.GetAllQuantityUnit);
                }
                return list;
            }
        }

        /// <summary>
        /// 获取：当前(子目工料机)下的所有(工料机不含工料机组成)
        /// </summary>
        public _List GetAllQuantityUnitNotZC
        {
            get
            {
                _List list = new _List();
                foreach (_SubheadingsQuantityUnitInfo info in this.SubheadingsQuantityUnitList)
                {
                    list.Add(info);
                }
                return list;
            }
        }

        /// <summary>
        /// 根据条件筛选配合比
        /// </summary>
        /// <param name="Strwhere"></param>
        /// <returns></returns>
        public IEnumerable<_ObjectQuantityUnitInfo> GetQuantityUnit(string Strwhere)
        {
            IEnumerable<_ObjectQuantityUnitInfo> infos = from info in this.SubheadingsQuantityUnitList.Cast<_ObjectQuantityUnitInfo>()
                                                         where Strwhere.Contains(info.BH)
                                                         select info;
            if (Strwhere == _Constant.配合比定额范围)
            {
                infos = from info in this.SubheadingsQuantityUnitList.Cast<_ObjectQuantityUnitInfo>()
                        where Strwhere == info.LB
                        select info;
            }
            return infos;
        }

        /// <summary>
        /// 获取：子目下所有的配合比
        /// </summary>
        public _List GetQuantityUnitComponen
        {
            get
            {
                _List list = new _List();
                foreach (_SubheadingsQuantityUnitInfo item in this.SubheadingsQuantityUnitList)
                {
                    list.AddRange(item.QuantityUnitComponentList.ToArray());
                }
                return list;
            }
        }

        /// <summary>
        /// 直接组价计算
        /// </summary>
        // public virtual void ZBegin()
        //{
        // this.Begin();
        // }
        /// <summary>
        /// 清除子目下的所有数据
        /// </summary>
        public void Clear()
        {
            this.m_SubheadingsQuantityUnitList.Clear();
            this.m_StandardConversionList.Clear();
            this.m_SubheadingsFeeList.Clear();
            this.m_StandardConversionList.Clear();
        }

        public override string XMBM
        {
            get
            {
                return base.XMBM;
            }
            set
            {
                base.XMBM = value;
                // UpxhlXS();
            }
        }

        private decimal m_XHLXS;
        public decimal XHLXS
        {
            get { return this.m_XHLXS; }
            set { this.m_XHLXS = value; }
        }
        public void UpxhlXS()
        {
            string[] arr = this.XMBM.Split(' ');
            if (arr.Length > 1)
            {

                for (int i = 1; i < arr.Length; i++)
                {
                    string[] arr1 = arr[i].Split('*');
                    if (arr1.Length < 2) break;
                    this.m_XHLXS = ToolKit.Calculate(arr[i].Substring(arr[i].IndexOf("*") + 1));
                    switch (arr1[0].ToUpper())
                    {
                        case "":
                            UPXHL("", this.m_XHLXS);
                            break;
                        case "R":
                            UPXHL(_Constant.rg, this.m_XHLXS);
                            break;
                        case "C":
                            UPXHL(_Constant.cl, this.m_XHLXS);
                            break;
                        case "J":
                            UPXHL(_Constant.jx, this.m_XHLXS);
                            break;
                        default:
                            break;
                    }

                }
                this.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
            }
        }
        private void UPXHL(string LB, decimal XS)
        {
            _ObjectQuantityUnitInfo[] infos = null;
            if (!string.IsNullOrEmpty(LB))
            {
                infos = (from n in this.SubheadingsQuantityUnitList.Cast<_ObjectQuantityUnitInfo>()
                         where LB.Contains(n.LB)
                         select n).ToArray();
            }
            else
            {
                infos = this.SubheadingsQuantityUnitList.Cast<_ObjectQuantityUnitInfo>().ToArray();

            }
            if (infos == null) return;
            foreach (_ObjectQuantityUnitInfo item in infos)
            {
                item.XHL = item.YSXHL * this.m_XHLXS;
            }

        }
        public override decimal ZJTJ
        {
            get { return base.ZJTJ; }
            set
            {
                //base.ZJTJ = value;
                //C=直接调价/综合单价,子目工料机的消耗量变更为原消耗量*C
                if (this.STATUS)
                {
                    UpXHL2(value);
                }
            }
        }

        /// <summary>
        /// 修改工料机的消耗量
        /// </summary>
        /// <param name="value"></param>
        private void UpXHL2(decimal value)
        {
            decimal zhdj = this.ZHDJ;
            if (zhdj == 0)
            {
                zhdj = 1;
            }
            decimal c = value / zhdj;
            _List t = GetAllQuantityUnitNotZC;
            UpChildIsCalc(false);
            foreach (_ObjectQuantityUnitInfo item in t)
            {
                if (!item.LB.Contains('%'))
                    item.XHL = item.XHL * c;
            }
            UpChildIsCalc(true);
            //int m = GetInventoryQuantityUnitSummary.Count;
        }

        private void UpChildIsCalc(bool p)
        {

            if (p)
            {
                this.Subheadings_Statistics.Begin();
            }
        }

        /// <summary>
        /// 根据编号获取工料机
        /// </summary>
        /// <param name="DEBH"></param>
        /// <returns></returns>
        public _ObjectQuantityUnitInfo this[string DEBH]
        {
            get
            {
                foreach (_ObjectQuantityUnitInfo item in this.GetAllQuantityUnit)
                {
                    if (item.YSBH == DEBH)
                    {
                        return item;
                    }
                }
                return null;
            }
        }
        public override object Copy()
        {
            return base.Copy();
        }
        #endregion

        #region -----------------------------------扩展修改方法 Edit  By 华威--------------------------

        /// <summary>
        /// 当子目工料机发生变化时候此方法被调用
        /// 1.子目工料机市场合价 定额合价发生变化时候调用此方法
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public void OnQuantityUnitChange(object Sender, object e)
        {
            //当前子目的统计操作包含 子目取费 子目参数
            //this.Subheadings_Statistics.Begin();

        }


        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            this.Statistics = new _Subheadings_Statistics_Return(this);
        }

        public override void OnModelEdited(object sender, object args)
        {
            base.OnModelEdited(sender, args);
            this.Parent.OnModelEdited(sender, args);
        }

        public override void OnModelActioin(object sender, object args)
        {
            base.OnModelActioin(sender, args);
            this.Parent.OnModelActioin(sender, args);
        }

        /// <summary>
        /// 开始编辑当前工料机对象
        /// </summary>
        /*public override void BeginModify()
        {
            if (this.UseAttribute == EObjectState.UnChange)
            {
                //通知当前对象改变
                this.SetModify(EObjectState.Modify, EDirection.Self);
            }
        }*/

        /// <summary>
        /// 结束编辑当前工料机对象
        /// </summary>
        /*public override void EndModify()
        {
            if (this.UseAttribute == EObjectState.Modifing || this.UseAttribute == EObjectState.Modify)
            {
                this.OnQuantityUnitChange(this, null);
                this.SetModify(EObjectState.UnChange, EDirection.Self);
            }
        }*/

        /// <summary>
        /// 设置修改状态
        /// </summary>
        /// <param name="p_EObjectState">要设置的状态</param>
        /// <param name="p_EDirection">设置方向</param>
        /*public override void SetModify(EObjectState p_EObjectState, EDirection p_EDirection)
        {
            switch (p_EDirection)
            {
                case EDirection.Self://仅自己
                    this.UseAttribute = p_EObjectState;
                    break;
                case EDirection.UP://向上寻址
                    this.Parent.SetModify(p_EObjectState, EDirection.Self);
                    this.Parent.SetModify(p_EObjectState, p_EDirection);
                    break;
                case EDirection.Down://向下寻址设置
                    foreach (_SubheadingsQuantityUnitInfo info in m_SubheadingsQuantityUnitList)
                    {
                        (info as _SubheadingsQuantityUnitInfo).SetModify(p_EObjectState, EDirection.Self);
                        (info as _SubheadingsQuantityUnitInfo).SetModify(p_EObjectState, EDirection.Down);
                    }
                    break;
                case EDirection.TwoWay://双向
                    this.SetModify(p_EObjectState, EDirection.UP);
                    this.SetModify(p_EObjectState, EDirection.Down);
                    break;
            }
        }*/

        /// <summary>
        /// 指定属性需要记录对象时候调用
        /// </summary>
        /// <param name="value"></param>
        /*public override void ModifyAttribute(string PropertyName, object value, object OriginalValue)
        {
            //单位工程为空或者单位工程没有调用BeginModify方法不会发出请求操作
            if (this.Activitie == null) return;
            if (this.Activitie.ModfitingObject == null) return;
            if (this.Equals(this.Activitie.ModfitingObject))
            {

                Type tp = this.GetType();
                MemberInfo info = tp.GetProperty(PropertyName);
                ModifyAttribute myAttribute = Attribute.GetCustomAttribute(info, typeof(ModifyAttribute)) as ModifyAttribute;
                if (myAttribute != null)
                {
                    myAttribute.CurrentValue = value;
                    myAttribute.OriginalValue = OriginalValue;
                    myAttribute.ObjectName = this.XMMC;
                    myAttribute.Source = this;
                    myAttribute.ActingOn = "清单.子目";
                    //是否通知
                    //正在编辑的对象和当前对象是一个实例则返回
                    this.OnModelEdited(this, myAttribute);
                }
            }
        }*/

        public override void ActionAttribute(string MethodName, string p_OtherName, object p_Source, object p_TagValue)
        {
            ///Create方法此处收集
            //if (UseAttribute == EObjectState.Appending)
            {
                //找到指定方法操作属性
                ActionAttribute myAttribute = Command.GetMethodAttribute(this, MethodName, p_OtherName);
                if (myAttribute != null)
                {
                    myAttribute.ObjectName = (p_Source as _ObjectQuantityUnitInfo).MC;
                    myAttribute.ActingOn = "清单.子目.工料机";
                    myAttribute.Source = p_Source;
                    myAttribute.TagValue = p_TagValue;
                    this.OnModelActioin(this, myAttribute);
                }
            }
        }
        #endregion
    }
}
