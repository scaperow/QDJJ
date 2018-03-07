/*
 子目工料机集合
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 子目工料机集合对象
    /// </summary>
    [Serializable]
    public class _SubheadingsQuantityUnitList : _List
    {
        /// <summary>
        /// 初始化：子目工料机集合对象
        /// </summary>
        /// <param name="p_Parent">所属：子目</param>
        public _SubheadingsQuantityUnitList(_SubheadingsInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象：子目对象
        /// </summary>
        private _SubheadingsInfo m_Parent = null;

        /// <summary>
        /// 获取所属对象：子目对象
        /// </summary>
        public _SubheadingsInfo Parent
        {
            get { return this.m_Parent; }
        }

        /// <summary>
        /// 将(子目工料机对象)增加到(子目工料机集合对象)的结尾处
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Add(_ObjectQuantityUnitInfo info)
        {
            base.Add(info);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="info">对象</param>
        /// <param name="ifh">增加=true 替换=false</param>
        public void Add(int index, _ObjectQuantityUnitInfo info,bool ifh)
        {
            (this as System.Collections.ArrayList).Insert(index, info);
            if (ifh)
            {
                this.Parent.SetOpera("//增：" + info.MC);
            }
            else
            {
                this.Parent.SetOpera("//换：" + info.MC);
            }
        }
        

        /// <summary>
        /// 删除 子目工料机对象
        /// </summary>
        /// <param name="info">子目工料机对象</param>
        public void Remove(_ObjectQuantityUnitInfo info)
        {
            _SubheadingsQuantityUnitInfo infos = info as _SubheadingsQuantityUnitInfo;
            if (infos.IFKFJ)
            {
                object[] s_info = infos.QuantityUnitComponentList.ToArray();
                foreach (_ObjectQuantityUnitInfo item in s_info)
                {
                    infos.QuantityUnitComponentList.RemoveGLJHZ(item);
                }
            }
            this.Parent.SetOpera("//删：" + info.MC);
            base.Remove(info);
            this.Parent.Subheadings_Statistics.Begin();
            this.Parent.Activitie.BeginEdit(this);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="info">对象</param>
        /// <param name="ifh">增加=true 替换=false</param>
        public void Rec_Add(int index, _ObjectQuantityUnitInfo info, bool ifh)
        {
            (this as System.Collections.ArrayList).Insert(index, info);
        }

        /// <summary>
        /// 获取指定编号的工料机
        /// </summary>
        /// <param name="bh">编号</param>
        /// <returns>返回一条或null</returns>
        public _SubheadingsQuantityUnitInfo GetInfo(string bh)
        {
            IEnumerable<_SubheadingsQuantityUnitInfo> list = this.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.BH == bh);
            return list.Count() == 0 ? null : list.FirstOrDefault();
        }

        /// <summary>
        /// 是否重复
        /// </summary>
        /// <returns></returns>
        public bool RepeatInfo(_ObjectQuantityUnitInfo p_Info)
        {
            IEnumerable<_SubheadingsQuantityUnitInfo> list = this.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.BH == p_Info.BH);
            if (list.Count() == 0)
            {
                return true;
            }
            else
            {
                _SubheadingsQuantityUnitInfo m_Info = list.FirstOrDefault();
                if (m_Info.MC == p_Info.MC && m_Info.DW == p_Info.DW && m_Info.SCDJ == p_Info.SCDJ)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 是否重复
        /// </summary>
        /// <returns></returns>
        public int GetCount(_ObjectQuantityUnitInfo p_Info)
        {
            return this.Cast<_SubheadingsQuantityUnitInfo>().Where(p => p.BH == p_Info.BH).Count();
        }
    }
}
