using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 工料机组成集合对象
    /// </summary>
    [Serializable]
    public class _QuantityUnitComponentList : _List
    {
        /// <summary>
        /// 初始化：工料机组成对象
        /// </summary>
        /// <param name="p_Parent">所属：子目工料机对象</param>
        public _QuantityUnitComponentList(_SubheadingsQuantityUnitInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象：子目工料机对象
        /// </summary>
        private _SubheadingsQuantityUnitInfo m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目工料机对象
        /// </summary>
        public _SubheadingsQuantityUnitInfo Parent
        {
            get { return this.m_Parent; }
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="info">工料机组成对象</param>
        public void Add(_ObjectQuantityUnitInfo info)
        {
            base.Add(info);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="info">对象</param>
        public void Add(int index, _ObjectQuantityUnitInfo info)
        {
            (this as System.Collections.ArrayList).Insert(index, info);
            if (this.Parent.IFKFJ)
            {
                this.Parent.CalculateParentSCDJ(Status.Update);
            }
        }

        /// <summary>
        /// 删除组成对象
        /// </summary>
        /// <param name="info">组成对象</param>
        /// <param name="isCalculate">是否引发计算 true：是</param>
        public void Remove(_ObjectQuantityUnitInfo info ,bool isCalculate)
        {
            base.Remove(info);
            if (isCalculate)
            {
                this.Parent.CalculateParentSCDJ(Status.Update);
            }
            this.Parent.Activitie.BeginEdit(this);
        }

        /// <summary>
        /// 删除组成对象
        /// </summary>
        /// <param name="info">组成对象</param>
        public void RemoveGLJHZ(_ObjectQuantityUnitInfo info)
        {
        }

        /// <summary>
        /// 增加组成对象
        /// </summary>
        /// <param name="info">组成对象</param>
        public void AddGLJHZ(_ObjectQuantityUnitInfo info)
        {
        }

        /// <summary>
        /// 是否重复
        /// </summary>
        /// <returns></returns>
        public int GetCount(_ObjectQuantityUnitInfo p_Info)
        {
            return this.Cast<_QuantityUnitComponentInfo>().Where(p => p.BH == p_Info.BH).Count();
        }
    }
}
