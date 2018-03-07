/*
   子目集合对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _SubheadingsList : _List
    {
        private _FixedListInfo m_Parent = null;

        public _FixedListInfo Parent
        {
            get { return this.m_Parent; }
        }
        public _SubheadingsList(_FixedListInfo p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 子目添加到集合
        /// </summary>
        /// <param name="p_info"></param>
        public void Add(_ObjectInfo p_info)
        {
            base.Add(p_info);
        }

        /// <summary>
        /// 删除子目
        /// </summary>
        /// <param name="p_info"></param>
        public void Remove(_ObjectInfo p_info)
        {
            //_SubheadingsInfo infos = p_info as _SubheadingsInfo;
            //object[] s_info = infos.SubheadingsQuantityUnitList.ToArray();
            //foreach (_ObjectQuantityUnitInfo item in s_info)
            //{
            //    infos.SubheadingsQuantityUnitList.Remove(item);
            //}
            base.Remove(p_info);
        }

        /// <summary>
        /// 更新子目的父ID
        /// </summary>
        public void UpDateParentID()
        {
            foreach ( _ObjectInfo p_info in this)
            {
                p_info.PARENTID = this.Parent.ID;
            }
        }

        /// <summary>
        /// 更新子目的工程量
        /// </summary>
        public void UpDateGCL()
        {
            foreach (_SubheadingsInfo p_info in this)
            {
              //decimal d= _ConvertUnit.Convert(this.Parent.DW, p_info.DW);
                p_info.SetHL();
               
            }
        }
    }
}
