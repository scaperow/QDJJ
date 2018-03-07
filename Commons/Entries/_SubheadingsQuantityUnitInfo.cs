/*
    子目工料机对象
    1.子目工料机发生改变触发子目取费参数
 *  2.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Data;
using System.Windows.Forms;
using ZiboSoft.Commons.Common;
using System.Reflection;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 分部分项-工料机对象
    /// </summary>
    [Serializable]
    public class _SubheadingsQuantityUnitInfo : _ObjectQuantityUnitInfo
    {
        

        /// <summary>
        /// 初始化：子目工料机对象
        /// </summary>
        /// <param name="p_Parent">所属：子目</param>
        public _SubheadingsQuantityUnitInfo(_SubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
            this.m_QuantityUnitComponentList = new _QuantityUnitComponentList(this);
        }

        public override _UnitProject Activitie
        {
            get
            {
                return this.Parent.Activitie;
            }
        }
        /// <summary>
        /// 所属对象
        /// </summary>
        private _SubheadingsInfo m_Parent = null;

        /// <summary>
        /// 工料机组成集合
        /// </summary>
        private _QuantityUnitComponentList m_QuantityUnitComponentList = null;

        /// <summary>
        /// 获取或设置：所属对象
        /// </summary>
        public _SubheadingsInfo Parent
        {
            get { return this.m_Parent; }
            set { this.m_Parent = value; }
        }

        /// <summary>
        /// 获取或设置：工料机组成集合
        /// </summary>
        public _QuantityUnitComponentList QuantityUnitComponentList
        {
            get { return m_QuantityUnitComponentList; }
            set { m_QuantityUnitComponentList = value; }
        }

        /// <summary>
        /// 工料机组成集合 BindingSource
        /// </summary>
        [NonSerialized]
        private BindingSource m_QuantityUnitComponentList_BindingSource = new BindingSource();

        /// <summary>
        /// 获取：工料机组成集合 BindingSource
        /// </summary>
        public BindingSource QuantityUnitComponentList_BindingSource
        {
            get
            {
                if (this.m_QuantityUnitComponentList_BindingSource == null)
                {
                    this.m_QuantityUnitComponentList_BindingSource = new BindingSource();
                }
                this.m_QuantityUnitComponentList_BindingSource.DataSource = this.m_QuantityUnitComponentList;
                return this.m_QuantityUnitComponentList_BindingSource;
            }
        }

        #region----------------------公有成员定义---------------------------------
        /// <summary>
        /// 获取或设置：工料机名称
        /// </summary>
        public override string MC
        {
            get { return base.MC; }
            set
            {
                if (base.MC != value)
                {
                    if (this.STATUS == Status.Update && this.Activitie != null)
                    {
                        this.UserPriceLibrary.Activitie = this.Activitie;
                        //this.UserPriceLibrary.Update(this, value.Trim(), _ObjectQuantityUnitInfo.FILED_MC);
                    }
                    else
                    {
                        base.MC = value;
                    }
                }
            }
        }
        /// <summary>
        /// 获取或设置：单位
        /// </summary>
        public override string DW
        {
            get { return base.DW; }
            set
            {
                if (base.DW != value)
                {
                    if (this.STATUS == Status.Update && this.Activitie != null)
                    {
                        this.UserPriceLibrary.Activitie = this.Activitie;
                        //this.UserPriceLibrary.Update(this, value.Trim(), _ObjectQuantityUnitInfo.FILED_DW);
                    }
                    else
                    {
                        base.DW = value;
                    }
                }
            }
        }
        /// <summary>
        /// 获取或设置：市场单价
        /// </summary>
        public override decimal SCDJ
        {
            get { return base.SCDJ; }
            set
            {
                if (base.SCDJ != value)
                {
                    if (this.STATUS == Status.Update && this.Activitie != null)
                    {
                        this.UserPriceLibrary.Activitie = this.Activitie;
                        //this.UserPriceLibrary.Update(this, value, _ObjectQuantityUnitInfo.FILED_SCDJ);
                    }
                    else
                    {
                        base.SCDJ = value;
                        if (this.LB == "主材")
                        {
                            base.DEDJ = value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取或设置：数量
        /// </summary>
        public override decimal SL
        {
            get { return base.SL; }
            set
            {
                if (base.IFSDSL)
                {
                    if (base.XHL != (base.SL / base.GCL))
                    {
                        base.XHL = base.SL / base.GCL;
                    }
                }
                else 
                {
                    if (base.SL != value)
                    {
                        base.SL = value;
                        //修改组成工料机数量
                        if (this.QuantityUnitComponentList.Count != 0)
                        {
                            foreach (_QuantityUnitComponentInfo item in this.QuantityUnitComponentList)
                            {
                                item.STATUS = Status.Update;
                                item.CalculateSL();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取或设置：市场合价
        /// </summary>
        public override decimal SCHJ
        {
            get
            {
                return base.SCHJ;
            }
            set
            {
                if (base.SCHJ != value)
                {
                    base.SCHJ = value;
                    if (this.STATUS != Status.AreAdd && this.Activitie != null)
                    {
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent);
                        this.STATUS = Status.Normal;
                    }
                }
            }
        }

        /// <summary>
        /// 计算风险
        /// </summary>
        public override bool IFFX
        {
            get
            {
                return base.IFFX;
            }
            set
            {
                if (base.IFFX != value)
                {
                    base.IFFX = value;
                    if (this.STATUS == Status.Update && this.Activitie != null)
                    {
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent);
                        this.STATUS = Status.Normal;
                    }
                }
            }
        }
        /// <summary>
        /// 结算单价
        /// </summary>
        public override decimal JSDJ
        {
            get
            {
                return base.JSDJ;
            }
            set
            {
                if (base.JSDJ != value)
                {
                    base.JSDJ = value;
                    if (this.STATUS == Status.Update && this.Activitie != null)
                    {
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent);
                        this.STATUS = Status.Normal;
                    }
                }
            }
        }

        /// <summary>
        /// 用途类别
        /// </summary>
        public override string YTLB
        {
            get
            {
                return base.YTLB;
            }
            set
            {
                if (base.YTLB != value)
                {
                    base.YTLB = value;
                    if (this.STATUS == Status.Update && this.Activitie != null)
                    {
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent);
                        this.STATUS = Status.Normal;
                    }
                }
            }
        }

        /// <summary>
        /// 计算父级市场单价
        /// </summary>
        /// <param name="p_Status"></param>
        public void CalculateParentSCDJ(Status p_Status)
        {
            if (p_Status != Status.AreAdd)
            {
                //this.UserPriceLibrary.Activitie = this.Activitie;
                //IEnumerable<_ObjectQuantityUnitInfo> m_PartQuantityUnit = this.UserPriceLibrary.PartQuantityUnit;
                //this.UserPriceLibrary.PartQuantityUnit = this.Parent.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>();
                //this.STATUS = Status.Update;
                //this.GetZCSCDJ();
                //this.UserPriceLibrary.PartQuantityUnit = m_PartQuantityUnit;
            }
        }

        /// <summary>
        /// 计算父级市场单价
        /// </summary>
        public void CalculateParentSCDJ()
        {
            this.GetZCSCDJ();
        }

        /// <summary>
        /// 计算组成上级的市场单价（保留2位小数）
        /// </summary>
        /// <returns></returns>
        private void GetZCSCDJ()
        {
            this.DEDJ = CDataConvert.ConToValue<System.Decimal>(this.QuantityUnitComponentList.Cast<_QuantityUnitComponentInfo>().Sum(p => p.DEDJ * p.XHL).ToString("N2"));
            this.SCDJ = CDataConvert.ConToValue<System.Decimal>(this.QuantityUnitComponentList.Cast<_QuantityUnitComponentInfo>().Sum(p => p.SCDJ * p.XHL).ToString("N2"));
        }
        #endregion

        /// <summary>
        /// 创建工料机组成
        /// </summary>
        /// <returns>工料机组成对象</returns>
        public void Create()
        {
            if (this.YSBH.StartsWith("P") || this.YSBH.StartsWith("J"))
            {
                _Library.GetLibrary(this.SSKLB);
                if (this.SSKLB == string.Empty)
                {
                    this.SSKLB = this.Activitie.Property.Libraries.FixedLibrary.FullName;
                }
                DataRow[] drs_zc = drs_zc = (_Library.Libraries[this.SSKLB] as DataSet).Tables["配合比表"].Select(string.Format("CAIJBH ='{0}'", this.YSBH));
                this.IFKFJ = drs_zc.Count() > 0 ? true : false;
                foreach (DataRow dr in drs_zc)
                {
                    DataRow[] dr_zc = (_Library.Libraries[this.SSKLB] as DataSet).Tables["材机表"].Select(string.Format("CAIJBH ='{0}'", dr["PHB_CJBH"]));
                    if (dr_zc != null)
                    {
                      
                        _QuantityUnitComponentInfo info = new _QuantityUnitComponentInfo(this);
                        info.STATUS = Status.AreAdd;
                        info.YSBH = dr_zc[0]["CAIJBH"].ToString();
                        info.YSMC = dr_zc[0]["CAIJMC"].ToString();
                        info.YSDW = dr_zc[0]["CAIJDW"].ToString();
                        info.YSXHL = ToolKit.ParseDecimal(dr["PHB_CJSL"]);
                        info.BH = dr_zc[0]["CAIJBH"].ToString();
                        info.MC = dr_zc[0]["CAIJMC"].ToString();
                        info.DW = dr_zc[0]["CAIJDW"].ToString();
                        info.XHL = ToolKit.ParseDecimal(dr["PHB_CJSL"]);
                        info.DEDJ = dr_zc[0]["CAIJDJ"].ToString().Trim() == string.Empty ? 0m : Convert.ToDecimal(dr_zc[0]["CAIJDJ"].ToString());
                        info.LB = dr_zc[0]["CAIJLB"].ToString();
                        info.ZCLB = "W";
                        info.SDCLB = dr_zc[0]["SANDCMC"].ToString();
                        info.SDCXS = dr_zc[0]["SANDCXS"].ToString().Length == 0 ? 0m : Convert.ToDecimal(dr_zc[0]["SANDCXS"]);
                        info.GCL = this.GCL;
                        info.SSKLB = this.Parent.LibraryName;
                        info.SSDWGCLB = this.Parent.GetSSDWGCLB();
                        info.SSDWGC = this.Activitie.Name;
                        _ObjectQuantityUnitInfo y_info = this.Activitie.Property.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == info.BH).FirstOrDefault();
                        if (y_info == null)
                        {
                            info.IFSC = dr_zc[0]["CAIJSC"].ToString() == "是" ? true : false;
                            info.IFZYCL = dr_zc[0]["CAIJXSJG"].ToString() == "是" ? true : false;
                            if (info.LB == "主材" || info.LB == "设备")
                            {
                                info.SCDJ = 0m;
                            }
                            else
                            {
                                info.SCDJ = info.DEDJ;
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
                        info.STATUS = Status.Normal;
                        this.m_QuantityUnitComponentList.Add(info);
                        
                    }
                }
                if (this.IFKFJ)
                {
                    this.CalculateParentSCDJ();
                }
            }
        }

        /// <summary>
        /// 创建：子目工料机创建组成
        /// </summary>
        [ActionAttribute(Command.Create,"创建子目工料机组成")]
        public bool Create(_ObjectQuantityUnitInfo p_info)
        {
            if (p_info != null)
            {
                if (!p_info.YSBH.StartsWith("P") && !p_info.YSBH.StartsWith("J"))
                {
                    _ObjectQuantityUnitInfo c_info = null;
                    if (this.Activitie.Property.RepeatInfo(p_info, out c_info) && this.QuantityUnitComponentList.GetCount(p_info) == 0)
                    {
                        //当前容器业务设置为添加状态
                        _QuantityUnitComponentInfo info = new _QuantityUnitComponentInfo(this);
                        info.STATUS = Status.AreAdd;
                        //状态设置为创建中
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
                        info.ZCLB = this.YSBH.Substring(0, 1);
                        info.SDCLB = p_info.SDCLB;
                        info.SDCXS = p_info.SDCXS;
                        info.GGXH = p_info.GGXH;
                        info.GCL = this.GCL;
                        info.SSKLB = this.SSKLB;
                        info.SSDWGCLB = this.Parent.GetSSDWGCLB();
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
                        int index = (this.m_QuantityUnitComponentList.IndexOf(this.QuantityUnitComponentList_BindingSource.Current) + 1);
                        info.STATUS = Status.Normal;
                        this.m_QuantityUnitComponentList.Add(index, info);
                        this.Parent.Subheadings_Statistics.Begin();
                        this.m_QuantityUnitComponentList_BindingSource.ResetBindings(false);
                        this.Parent.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                        //对象设置为创建中状态
                        this.ActionAttribute("Create" ,"创建子目工料机组成", info,null);
                        this.Activitie.BeginEdit(this);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 替换工料机
        /// </summary>
        /// <param name="this.new_info">需要增加的工料机</param>
        [ActionAttribute(Command.Replace, "替换工料机组成")]
        public bool Replace(_ObjectQuantityUnitInfo p_info)
        {
            if (p_info != null)
            {
                if (this.YSBH.StartsWith("P") || this.YSBH.StartsWith("J"))
                {
                    _ObjectQuantityUnitInfo m_info = this.QuantityUnitComponentList_BindingSource.Current as _ObjectQuantityUnitInfo;
                    _ObjectQuantityUnitInfo c_info = null;
                    if (this.Activitie.Property.RepeatInfo(p_info, out c_info) && (this.QuantityUnitComponentList.GetCount(p_info) == 0 || m_info.BH == p_info.BH))
                    {
                        int indexID = this.QuantityUnitComponentList.IndexOf(m_info);
                        this.m_QuantityUnitComponentList.Remove(m_info, false);
                        _QuantityUnitComponentInfo info = new _QuantityUnitComponentInfo(this);
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
                        info.ZCLB = this.YSBH.Substring(0, 1);
                        info.SDCLB = p_info.SDCLB;
                        info.SDCXS = p_info.SDCXS;
                        info.GCL = this.GCL;
                        info.SSKLB = this.SSKLB;
                        info.SSDWGCLB = this.Parent.GetSSDWGCLB();
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
                        this.m_QuantityUnitComponentList.Add(indexID, info);
                        this.Parent.Subheadings_Statistics.Begin();
                        this.m_QuantityUnitComponentList_BindingSource.ResetBindings(false);
                        this.Parent.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                        this.ActionAttribute("Replace", "替换工料机组成", info, m_info);
                        this.Activitie.BeginEdit(this);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 删除工料机组成
        /// </summary>
        /// <param name="this.new_info">需要删除工料机组成</param>
        [ActionAttribute(Command.Delete, "删除工料机组成")]
        public void Remove(_ObjectQuantityUnitInfo p_info)
        {
            int index = this.QuantityUnitComponentList.IndexOf(p_info);
            this.QuantityUnitComponentList.Remove(p_info, true);
            object p_TagValue = null;
            if (this.QuantityUnitComponentList.Count == index)
            {
                index = index - 1;
            }
            if (index > -1)
            {
                p_TagValue = this.QuantityUnitComponentList[index];
            }
            this.ActionAttribute("Remove", "删除工料机组成", p_info, p_TagValue);
        }

        /// <summary>
        /// 获取当前(子目工料机)下的所有(工料机与工料机组成)
        /// </summary>
        public _List GetAllQuantityUnit
        {
            get
            {
                _List list = new _List();
                foreach (_ObjectQuantityUnitInfo info in this.QuantityUnitComponentList)
                {
                    list.Add(info);
                }
                return list;
            }
        }

        /// <summary>
        /// 开始编辑当前工料机对象
        /// </summary>
        /*public override void BeginModify()
        {
            //通知当前对象改变
            if (this.UseAttribute == EObjectState.UnChange)
            {
                //通知当前对象改变
                this.SetModify(EObjectState.Modify, EDirection.Self);
                this.Parent.OnQuantityUnitChange(this, null);
            }
        }*/

        /// <summary>
        /// 设置修改状态
        /// </summary>
        /// <param name="p_EObjectState"></param>
        /// <param name="p_EDirection"></param>
        /*public override void SetModify(EObjectState p_EObjectState, EDirection p_EDirection)
        {
            switch (p_EDirection)
            {
                case EDirection.Self://仅自己
                    this.UseAttribute = p_EObjectState;
                    break;
                case EDirection.UP://向上寻址
                    this.Parent.SetModify(p_EObjectState, EDirection.Self);
                    this.Parent.SetModify(p_EObjectState, EDirection.UP);
                    break;
                case EDirection.Down://向下寻址设置
                    foreach (_QuantityUnitComponentInfo info in m_QuantityUnitComponentList)
                    {
                        (info as _QuantityUnitComponentInfo).SetModify(p_EObjectState, EDirection.Down);
                    }
                    break;
                case EDirection.TwoWay://双向
                    this.SetModify(p_EObjectState, EDirection.UP);
                    this.SetModify(p_EObjectState, EDirection.Down);
                    break;
            }
        }*/

        /// <summary>
        /// 结束编辑当前工料机对象
        /// </summary>
        /*public override void EndModify()
        {
        }*/

        public override void OnModelEdited(object sender, object args)
        {
            base.OnModelEdited(sender, args);
            this.Parent.OnModelEdited(sender, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnModelActioin(object sender, object args)
        {
            base.OnModelActioin(sender, args);
            this.Parent.OnModelActioin(sender, args);
        }
        /// <summary>
        /// 指定属性需要记录对象时候调用
        /// </summary>
        /// <param name="value"></param>
        public override void ModifyAttribute(string PropertyName, object value, object OriginalValue)
        {
            //单位工程为空或者单位工程没有调用BeginModify方法不会发出请求操作
            if (this.Parent == null) return;
            if (this.Activitie == null) return;
            if (this.Activitie.ModfitingObject == null) return;
            if (this.Activitie.ModfitingObject.Current == null) return;
            if (this.Activitie.ModfitingObject.FiledName != string.Empty)
            {
                if (this.Activitie.ModfitingObject.FiledName != PropertyName) return;
            }
            if (this == this.Activitie.ModfitingObject.Current)
            {

                Type tp = this.GetType();
                MemberInfo info = tp.GetProperty(PropertyName);
                ModifyAttribute myAttribute = Attribute.GetCustomAttribute(info, typeof(ModifyAttribute)) as ModifyAttribute;
                if (myAttribute != null)
                {
                    myAttribute.CurrentValue = value;
                    myAttribute.OriginalValue = OriginalValue;
                    myAttribute.ObjectName = this.MC;
                    myAttribute.Source = this;
                    myAttribute.ActingOn = "清单.子目.工料机";
                    //是否通知
                    //正在编辑的对象和当前对象是一个实例则返回
                    this.OnModelEdited(this, myAttribute);
                }
            }
        }

       
       
        /// <summary>
        /// 指定动作属性
        /// </summary>
        /// <param name="MethodName">方法名称</param>
        /// <param name="p_OtherName">别名</param>
        public override void ActionAttribute(string MethodName, string p_OtherName,object p_Source,object p_TagValue)
        {
            //if (UseAttribute == EObjectState.Appending)
            {
                //找到指定方法操作属性
                ActionAttribute myAttribute = Command.GetMethodAttribute(this, MethodName, p_OtherName);
                if (myAttribute != null)
                {
                    myAttribute.ObjectName = (p_Source as _ObjectQuantityUnitInfo).MC;
                    myAttribute.ActingOn = "清单.子目.工料机.组成";
                    myAttribute.Source = p_Source;
                    myAttribute.TagValue = p_TagValue;
                    this.OnModelActioin(this, myAttribute);
                }
            }
        }

        public override void Rec_Create(ActionAttribute p_attr)
        {
            _SubheadingsQuantityUnitInfo m_info = p_attr.Source as _SubheadingsQuantityUnitInfo;
            _SubheadingsQuantityUnitInfo p_info = p_attr.TagValue as _SubheadingsQuantityUnitInfo;
            if (m_info != null)
            {
                if (this.Activitie.Property.RepeatInfo(m_info))
                {
                    if (this.Parent.SubheadingsQuantityUnitList.GetCount(m_info) == 0)
                    {
                        int index = 0;
                        if (p_info != null)
                        {
                            index = this.Parent.SubheadingsQuantityUnitList.IndexOf(p_info);
                        }
                        this.Parent.SubheadingsQuantityUnitList.Add(index+1, m_info, true);
                        foreach (_QuantityUnitComponentInfo item in m_info.QuantityUnitComponentList)
                        {
                            m_info.QuantityUnitComponentList.AddGLJHZ(item);
                        }
                        //引发计算
                        this.Parent.Subheadings_Statistics.Begin();
                        //刷新数据
                        this.Parent.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                        //对象设置为创建中状态
                        this.Activitie.BeginEdit(this);
                    }
                }
            }
        }

        public override void Rec_Delete(ActionAttribute p_attr)
        {
            _SubheadingsQuantityUnitInfo p_info = p_attr.Source as _SubheadingsQuantityUnitInfo;
            if (p_info != null)
            {
                this.Parent.SubheadingsQuantityUnitList.Remove(p_info);
                //引发计算
                this.Parent.Subheadings_Statistics.Begin();
                //刷新数据
                this.Parent.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                //对象设置为创建中状态
                this.Activitie.BeginEdit(this);
            }
        }

        public override void Rec_Replace(ActionAttribute p_attr)
        {
            _SubheadingsQuantityUnitInfo m_info = p_attr.Source as _SubheadingsQuantityUnitInfo;
            _SubheadingsQuantityUnitInfo p_info = p_attr.TagValue as _SubheadingsQuantityUnitInfo;
            if (m_info != null && p_info != null)
            {
                if (this.Activitie.Property.RepeatInfo(m_info))
                {
                    if ((this.Parent.SubheadingsQuantityUnitList.GetCount(m_info) == 0 || p_info.BH == m_info.BH))
                    {
                        int index = this.Parent.SubheadingsQuantityUnitList.IndexOf(p_info);
                        this.Parent.SubheadingsQuantityUnitList.Remove(p_info);
                        this.Parent.SubheadingsQuantityUnitList.Add(index, m_info, false);
                        foreach (_QuantityUnitComponentInfo item in m_info.QuantityUnitComponentList)
                        {
                            m_info.QuantityUnitComponentList.AddGLJHZ(item);
                        }
                        //引发计算
                        this.Parent.Subheadings_Statistics.Begin();
                        //刷新数据
                        this.Parent.SubheadingsQuantityUnitList_BindingSource.ResetBindings(false);
                        //对象设置为创建中状态
                        this.Activitie.BeginEdit(this);
                    }
                }
            }
        }
    }
}
