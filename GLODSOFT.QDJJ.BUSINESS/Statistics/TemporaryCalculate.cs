using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.BUSINESS
{
    public class TemporaryCalculate
    {
        public TemporaryCalculate(_COBJECTS p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属
        /// </summary>
        private _COBJECTS m_Parent;
        /// <summary>
        /// 获取或设置：所属
        /// </summary>
        public _COBJECTS Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        /// <summary>
        /// 临时计算集合
        /// </summary>
        private ArrayList m_CalculateList = new ArrayList();

        /// <summary>
        /// 获取或设置：临时计算集合
        /// </summary>
        private ArrayList CalculateList
        {
            get { return m_CalculateList; }
            set { m_CalculateList = value; }
        }

        public void Add(object p_object)
        {
            if (!m_CalculateList.Contains(p_object))
            {
                m_CalculateList.Add(p_object);
            }
        }

        /// <summary>
        /// 计算临时集合的所有子目
        /// </summary>
        public void Calculate()
        {
            foreach (_SubheadingsInfo item in m_CalculateList)
            {
                item.Subheadings_Statistics.Begin();
            } 
            m_CalculateList.Clear();
        }
    }
}
