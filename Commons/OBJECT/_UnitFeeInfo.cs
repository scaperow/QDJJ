using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 工程取费对象
    /// </summary>
    [Serializable]
    public class _UnitFeeInfo
    {
        /// <summary>
        /// 初始化：原始工程取费对象
        /// </summary>
        public _UnitFeeInfo(_ParameterSettings p_Parent)
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 所属对象
        /// </summary>
        private _ParameterSettings m_Parent = null;

        /// <summary>
        /// 获取所属对象
        /// </summary>
        public _ParameterSettings Parent
        {
            get { return this.m_Parent; }
            set { this.m_Parent = value; }
        }

        #region----------------------字段常量定义---------------------------------
        /// <summary>
        /// 表名
        /// </summary>
        public const string TABLE_NAME = "UNITFEE";
        /// <summary>
        /// 编号
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        /// 工程类别
        /// </summary>
        public const string FILED_GCLB = "GCLB";
        /// <summary>
        /// 定额号范围
        /// </summary>
        public const string FILED_DEHFW = "DEHFW";
        /// <summary>
        /// 管理费费率
        /// </summary>
        public const string FILED_GLFFL = "GLFFL";
        /// <summary>
        /// 利润费率
        /// </summary>
        public const string FILED_LRFL = "LRFL";
        /// <summary>
        /// 风险投标费率
        /// </summary>
        public const string FILED_FXTBFL = "FXTBFL";
        /// <summary>
        /// 风险标底费率
        /// </summary>
        public const string FILED_FXBDFL = "FXBDFL";
        /// <summary>
        /// 管理费投标计算基础
        /// </summary>
        public const string FILED_GLFTBJSJC = "GLFTBJSJC";
        /// <summary>
        /// 管理费标底计算基础
        /// </summary>
        public const string FILED_GLFBDJSJC = "GLFBDJSJC";
        /// <summary>
        /// 利润费投标计算基础
        /// </summary>
        public const string FILED_LRFTBJSJC = "LRFTBJSJC";
        /// <summary>
        /// 利润费标底计算基础
        /// </summary>
        public const string FILED_LRFBDJSJC = "LRFBDJSJC";
        /// <summary>
        /// 风险费投标计算基础
        /// </summary>
        public const string FILED_FXFTBJSJC = "FXFTBJSJC";
        /// <summary>
        /// 风险费标底计算基础
        /// </summary>
        public const string FILED_FXFBDJSJC = "FXFBDJSJC";
        /// <summary>
        /// 是否税费汇总
        /// </summary>
        public const string FILED_IFSFHZ  = "IFSFHZ";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        /// 编号
        /// </summary>
        private int m_ID;
        /// <summary>
        /// 工程类别
        /// </summary>
        private string m_GCLB = string.Empty;
        /// <summary>
        /// 定额号范围
        /// </summary>
        private string m_DEHFW = string.Empty;
        /// <summary>
        /// 管理费费率
        /// </summary>
        private decimal m_GLFFL;
        /// <summary>
        /// 利润费率
        /// </summary>
        private decimal m_LRFL;
        /// <summary>
        /// 风险投标费率
        /// </summary>
        private decimal m_FXTBFL;
        /// <summary>
        /// 风险标底费率
        /// </summary>
        private decimal m_FXBDFL;
        /// <summary>
        /// 管理费投标计算基础
        /// </summary>
        private string m_GLFTBJSJC = string.Empty;
        /// <summary>
        /// 管理费标底计算基础
        /// </summary>
        private string m_GLFBDJSJC = string.Empty;
        /// <summary>
        /// 利润费投标计算基础
        /// </summary>
        private string m_LRFTBJSJC = string.Empty;
        /// <summary>
        /// 利润费标底计算基础
        /// </summary>
        private string m_LRFBDJSJC = string.Empty;
        /// <summary>
        /// 风险费投标计算基础
        /// </summary>
        private string m_FXFTBJSJC = string.Empty;
        /// <summary>
        /// 风险费标底计算基础
        /// </summary>
        private string m_FXFBDJSJC = string.Empty;
        /// <summary>
        /// 是否税费汇总
        /// </summary>
        private bool m_IFSFHZ;

        #endregion

        #region----------------------公共成员定义---------------------------------
        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        /// <summary>
        /// 工程类别
        /// </summary>
        public string GCLB
        {
            get { return m_GCLB; }
            set { m_GCLB = value; }
        }
        /// <summary>
        /// 定额号范围
        /// </summary>
        public string DEHFW
        {
            get { return m_DEHFW; }
            set { m_DEHFW = value; }
        }
        /// <summary>
        /// 管理费费率
        /// </summary>
        public decimal GLFFL
        {
            get { return m_GLFFL; }
            set { m_GLFFL = value; }
        }
        /// <summary>
        /// 利润费率
        /// </summary>
        public decimal LRFL
        {
            get { return m_LRFL; }
            set { m_LRFL = value; }
        }
        /// <summary>
        /// 风险投标费率
        /// </summary>
        public decimal FXTBFL
        {
            get { return m_FXTBFL; }
            set { m_FXTBFL = value; }
        }
        /// <summary>
        /// 风险标底费率
        /// </summary>
        public decimal FXBDFL
        {
            get { return m_FXBDFL; }
            set { m_FXBDFL = value; }
        }
        /// <summary>
        /// 管理费投标计算基础
        /// </summary>
        public string GLFTBJSJC
        {
            get { return m_GLFTBJSJC; }
            set { m_GLFTBJSJC = value; }
        }
        /// <summary>
        /// 管理费标底计算基础
        /// </summary>
        public string GLFBDJSJC
        {
            get { return m_GLFBDJSJC; }
            set { m_GLFBDJSJC = value; }
        }
        /// <summary>
        /// 利润费投标计算基础
        /// </summary>
        public string LRFTBJSJC
        {
            get { return m_LRFTBJSJC; }
            set { m_LRFTBJSJC = value; }
        }
        /// <summary>
        /// 利润费标底计算基础
        /// </summary>
        public string LRFBDJSJC
        {
            get { return m_LRFBDJSJC; }
            set { m_LRFBDJSJC = value; }
        }
        /// <summary>
        /// 风险费投标计算基础
        /// </summary>
        public string FXFTBJSJC
        {
            get { return m_FXFTBJSJC; }
            set { m_FXFTBJSJC = value; }
        }
        /// <summary>
        /// 风险费标底计算基础
        /// </summary>
        public string FXFBDJSJC
        {
            get { return m_FXFBDJSJC; }
            set { m_FXFBDJSJC = value; }
        }
        /// <summary>
        /// 是否税费汇总
        /// </summary>
        public bool IFSFHZ
        {
            get { return m_IFSFHZ; }
            set { m_IFSFHZ = value; }
        }
        #endregion
    }
}
