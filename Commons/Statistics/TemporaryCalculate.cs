using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
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
        private ArrayList m_CalculateSubheadingsList = new ArrayList();

        /// <summary>
        /// 获取或设置：临时计算集合
        /// </summary>
        public ArrayList CalculateSubheadingsList
        {
            get { return m_CalculateSubheadingsList; }
            set { m_CalculateSubheadingsList = value; }
        }

        /// <summary>
        /// 临时计算集合
        /// </summary>
        private ArrayList m_CalculateFixedList = new ArrayList();

        /// <summary>
        /// 获取或设置：临时计算集合
        /// </summary>
        public ArrayList CalculateFixedList
        {
            get { return m_CalculateFixedList; }
            set { m_CalculateFixedList = value; }
        }

        public void Add(DataRow p_dr)
        {
            DataRow zm_dr = null;
            DataRow qd_dr = null;
            switch (p_dr["SSLB"].ToString())
            {
                case "0":
                    zm_dr = this.Parent.StructSource.ModelSubSegments.GetRowByOther(p_dr["ZMID"].ToString());
                    qd_dr = this.Parent.StructSource.ModelSubSegments.GetRowByOther(p_dr["QDID"].ToString());
                    break;
                case "1":
                    zm_dr = this.Parent.StructSource.ModelMeasures.GetRowByOther(p_dr["ZMID"].ToString());
                    qd_dr = this.Parent.StructSource.ModelMeasures.GetRowByOther(p_dr["QDID"].ToString());
                    break;
                default:
                    break;
            }
            if (!m_CalculateSubheadingsList.Contains(zm_dr))
            {
                m_CalculateSubheadingsList.Add(zm_dr);
            }
            if (!m_CalculateFixedList.Contains(zm_dr))
            {
                m_CalculateFixedList.Add(zm_dr);
            }
        }

        /// <summary>
        /// 计算临时集合的所有子目
        /// </summary>
        public void Calculate()
        {

            //foreach (DataRow item in m_CalculateSubheadingsList)
            //{
            //    //_Subheadings_Statistics stat = new _Subheadings_Statistics(item, this.Unit);
            //    //stat.Begin();
            //    //stat.FBegin();
            //}
            //foreach (DataRow item in m_CalculateFixedList)
            //{
            //     //item.Subheadings_Statistics.Begin();
            //}
            //m_CalculateSubheadingsList.Clear();
            //m_CalculateFixedList.Clear();
        }
    }
}
