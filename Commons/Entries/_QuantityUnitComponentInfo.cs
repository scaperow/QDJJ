/*
 子目组成对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 工料机组成对象
    /// </summary>
    [Serializable]
    public class _QuantityUnitComponentInfo : _ObjectQuantityUnitInfo
    {
        /// <summary>
        /// 初始化：工料机组成对象
        /// </summary>
        /// <param name="p_Parent">所属：子目工料机对象</param>
        public _QuantityUnitComponentInfo(_SubheadingsQuantityUnitInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }
        public override _UnitProject Activitie
        {
            get
            {
                return this.Parent.Parent.Activitie;
            }
        }
        /// <summary>
        /// 所属对象：子目工料机对象
        /// </summary>
        private _SubheadingsQuantityUnitInfo m_Parent = null;

        /// <summary>
        /// 获取或设置：子目工料机对象
        /// </summary>
        public _SubheadingsQuantityUnitInfo Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
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
                    this.Parent.CalculateParentSCDJ(this.STATUS);
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
                    //base.XHL = 
                }
                else
                {
                    if (base.SL != value)
                    {
                        base.SL = value;
                    }
                }
            }
        }
        /// <summary>
        /// 获取或设置：消耗量
        /// </summary>
        public override decimal XHL
        {
            get { return base.XHL; }
            set
            {
                //通知属性修改
                base.XHL = value;
                this.Parent.CalculateParentSCDJ(this.STATUS);
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
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent.Parent);
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
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent.Parent);
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
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent.Parent);
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
                        //this.Activitie.Property.TemporaryCalculate.Add(this.Parent.Parent);
                        this.STATUS = Status.Normal;
                    }
                }
            }
        }

        /// <summary>
        /// 数量计算
        /// </summary>
        public override void CalculateSL()
        {
            SL = (base.XHL * this.Parent.SL);
        }

        /// <summary>
        /// 计算子目工料机市场单价
        /// </summary>
        public void CalculatePSCDJ()
        {
            this.Parent.SCDJ = (base.SCDJ * base.XHL);
        }

        #endregion

        public override void OnModelEdited(object sender, object args)
        {
            base.OnModelEdited(sender, args);
            this.Parent.OnModelEdited(sender, args);
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
                    myAttribute.ActingOn = "清单.子目.工料机.组成";
                    //是否通知
                    //正在编辑的对象和当前对象是一个实例则返回
                    this.OnModelEdited(this, myAttribute);
                }
            }
        }


        public override void Rec_Create(ActionAttribute p_attr)
        {
            _QuantityUnitComponentInfo m_info = p_attr.Source as _QuantityUnitComponentInfo;
            _QuantityUnitComponentInfo p_info = p_attr.TagValue as _QuantityUnitComponentInfo;
            if (m_info != null)
            {
                if (this.Activitie.Property.RepeatInfo(m_info))
                {
                    if (this.Parent.QuantityUnitComponentList.GetCount(m_info) == 0)
                    {
                        int index = 0;
                        if (p_info != null)
                        {
                            index = this.Parent.QuantityUnitComponentList.IndexOf(p_info);
                        }
                        this.Parent.QuantityUnitComponentList.Add(index, m_info);
                        //引发计算
                        this.Parent.Parent.Subheadings_Statistics.Begin();
                        //刷新数据
                        this.Parent.QuantityUnitComponentList_BindingSource.ResetBindings(false);
                        //对象设置为创建中状态
                        this.Activitie.BeginEdit(this);
                    }
                }
            }
        }

        public override void Rec_Delete(ActionAttribute p_attr)
        {
            _QuantityUnitComponentInfo m_info = p_attr.Source as _QuantityUnitComponentInfo;
            if (m_info != null)
            {
                this.Parent.QuantityUnitComponentList.Remove(m_info, true);
                //引发计算
                this.Parent.Parent.Subheadings_Statistics.Begin();
                //刷新数据
                this.Parent.QuantityUnitComponentList_BindingSource.ResetBindings(false);
                //对象设置为创建中状态
                this.Activitie.BeginEdit(this);
            }
        }

        public override void Rec_Replace(ActionAttribute p_attr)
        {
            _QuantityUnitComponentInfo p_info = p_attr.TagValue as _QuantityUnitComponentInfo;
            _QuantityUnitComponentInfo m_info = p_attr.Source as _QuantityUnitComponentInfo;
            if (m_info != null && p_info != null)
            {
                if (this.Activitie.Property.RepeatInfo(m_info))
                {
                    if ((this.Parent.QuantityUnitComponentList.GetCount(m_info) == 0 || p_info.BH == m_info.BH))
                    {
                        int index = this.Parent.QuantityUnitComponentList.IndexOf(p_info);
                        this.Parent.QuantityUnitComponentList.Remove(p_info, false);
                        this.Parent.QuantityUnitComponentList.Add(index, m_info);
                        //引发计算
                        this.Parent.Parent.Subheadings_Statistics.Begin();
                        //刷新数据
                        this.Parent.QuantityUnitComponentList_BindingSource.ResetBindings(false);
                        //对象设置为创建中状态
                        this.Activitie.BeginEdit(this);
                    }
                }
            }
        }
    }
}
