using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public abstract class _ObjectSubheadingsFee
    {
        #region----------------------字段常量定义---------------------------------
        /// <summary>
        /// 表名
        /// </summary>
        public const string TABLE_NAME = "SUBHEADINGSFEE";
        /// <summary>
        /// 编号
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        /// 父级编号
        /// </summary>
        public const string FILED_PARENTID = "PARENTID";
        /// <summary>
        /// 引用号
        /// </summary>
        public const string FILED_YYH = "YYH";
        /// <summary>
        /// 名称
        /// </summary>
        public const string FILED_MC = "MC";
        /// <summary>
        /// 未知
        /// </summary>
        public const string FILED_BDS = "BDS";
        /// <summary>
        /// 投标计算基础
        /// </summary>
        public const string FILED_TBJSJC = "TBJSJC";
        /// <summary>
        /// 标底计算基础
        /// </summary>
        public const string FILED_BDJSJC = "BDJSJC";
        /// <summary>
        /// 费率
        /// </summary>
        public const string FILED_FL = "FL";
        /// <summary>
        /// 备注
        /// </summary>
        public const string FILED_BEIZHU = "BZ";
        /// <summary>
        /// 状态
        /// </summary>
        public const string FILED_STATUS = "STATUS";
        /// <summary>
        /// 投标金额
        /// </summary>
        public const string FILED_TBJE = "TBJE";
        /// <summary>
        /// 标底金额
        /// </summary>
        public const string FILED_BDJE = "TBJE";
        /// <summary>
        /// 费用类别
        /// </summary>
        public const string FILED_FYLB = "FYLB";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        /// 编号
        /// </summary>
        private int m_ID;
        /// <summary>
        /// 父级编号
        /// </summary>
        private int m_PARENTID;
        /// <summary>
        /// 引用号
        /// </summary>
        private string m_YYH = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        private string m_MC = string.Empty;
        /// <summary>
        /// 投标计算基础
        /// </summary>
        private string m_TBJSJC = string.Empty;
        /// <summary>
        /// 标底计算基础
        /// </summary>
        private string m_BDJSJC = string.Empty;
        /// <summary>
        /// 未知
        /// </summary>
        private string m_BDS = string.Empty;
        /// <summary>
        /// 费率
        /// </summary>
        private decimal m_FL;
        /// <summary>
        /// 备注
        /// </summary>
        private string m_BZ = string.Empty;
        /// <summary>
        /// 投标金额
        /// </summary>
        private decimal m_TBJE;
        /// <summary>
        /// 标底金额
        /// </summary>
        private decimal m_BDJE;
        /// <summary>
        /// 状态
        /// </summary>
        private bool m_STATUS = false;
        /// <summary>
        /// 费用类别
        /// </summary>
        private string m_FYLB = string.Empty;
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
        /// 父级编号
        /// </summary>
        public int PARENTID
        {
            get { return m_PARENTID; }
            set { m_PARENTID = value; }
        }
        /// <summary>
        /// 引用号
        /// </summary>
        public string YYH
        {
            get { return m_YYH; }
            set { m_YYH = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string MC
        {
            get { return m_MC; }
            set { m_MC = value; }
        }
        /// <summary>
        /// 未知
        /// </summary>
        public string BDS
        {
            get { return m_BDS; }
            set { m_BDS = value; }
        }
        /// <summary>
        /// 投标计算基础
        /// </summary>
        public virtual string TBJSJC
        {
            get { return m_TBJSJC; }
            set { m_TBJSJC = value; }
        }

        /// <summary>
        /// 标底计算基础
        /// </summary>
        public string BDJSJC
        {
            get { return m_BDJSJC; }
            set { m_BDJSJC = value; }
        }
        /// <summary>
        /// 费率
        /// </summary>
        public virtual decimal FL
        {
            get { return m_FL; }
            set { m_FL = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string BZ
        {
            get { return m_BZ; }
            set { m_BZ = value; }
        }
        /// <summary>
        /// 投标金额
        /// </summary>
        public decimal TBJE
        {
            get { return m_TBJE; }
            set { m_TBJE = value; }
        }
        /// <summary>
        /// 标底金额
        /// </summary>
        public decimal BDJE
        {
            get { return m_BDJE; }
            set { m_BDJE = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public bool STATUS
        {
            get { return m_STATUS; }
            set { m_STATUS = value; }
        }
        /// <summary>
        /// 费用类别
        /// </summary>
        public virtual string FYLB
        {
            get { return m_FYLB; }
            set { m_FYLB = value; }
        }
        #endregion
    }
}
