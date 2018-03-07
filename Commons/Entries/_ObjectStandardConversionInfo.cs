using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 标准换算基类
    /// </summary>
    [Serializable]
    public abstract class _ObjectStandardConversionInfo
    {
        #region----------------------字段常量定义---------------------------------
        /// <summary>
        /// 表名
        /// </summary>
        public const string TABLE_NAME = "STANDARDCONVERSION";
        /// <summary>
        /// 编号
        /// </summary>
        public const string FILED_ID = "ID";
        /// <summary>
        /// 是否选择
        /// </summary>
        public const string FILED_IFXZ = "IFXZ";
        /// <summary>
        /// 是否换算
        /// </summary>
        public const string FILED_IFHS = "IFHS";
        /// <summary>
        /// 定额号
        /// </summary>
        public const string FILED_DEH = "DEH";
        /// <summary>
        /// 换算类别
        /// </summary>
        public const string FILED_HSLB = "HSLB";
        /// <summary>
        /// 换算信息
        /// </summary>
        public const string FILED_HSXX = "HSXX";
        /// <summary>
        /// 单价_单位
        /// </summary>
        public const string FILED_DJ_DW = "DJ_DW";
        /// <summary>
        /// 基本量_人工系数
        /// </summary>
        public const string FILED_JBL_RGXS = "JBL_RGXS";
        /// <summary>
        /// 定额号_材料系数
        /// </summary>
        public const string FILED_DEH_CLXS = "DEH_CLXS";
        /// <summary>
        /// 调整量_机械系数
        /// </summary>
        public const string FILED_TZL_JXXS = "TZL_JXXS";
        /// <summary>
        /// 主材
        /// </summary>
        public const string FILED_ZC = "ZC";
        /// <summary>
        /// 设备
        /// </summary>
        public const string FILED_SB = "SB";
        /// <summary>
        /// 消耗类别
        /// </summary>
        public const string FILED_XHLB = "XHLB";
        /// <summary>
        /// 分组
        /// </summary>
        public const string FILED_FZ = "FZ";
        /// <summary>
        /// 未知
        /// </summary>
        public const string FILED_THZHC = "THZHC";
        /// <summary>
        /// 未知
        /// </summary>
        public const string FILED_THWZFC = "THWZFC";
        /// <summary>
        /// 未知
        /// </summary>
        public const string FILED_HSXI = "HSXI";
        #endregion

        #region----------------------私有成员定义---------------------------------
        /// <summary>
        /// 编号
        /// </summary>
        private int m_ID;
        /// <summary>
        /// 是否选择
        /// </summary>
        private bool m_IFXZ;
        /// <summary>
        /// 是否换算
        /// </summary>
        private bool m_IFHS;
        /// <summary>
        /// 定额号
        /// </summary>
        private string m_DEH = string.Empty;
        /// <summary>
        /// 换算类别
        /// </summary>
        private string m_HSLB = string.Empty;
        /// <summary>
        /// 换算信息
        /// </summary>
        private string m_HSXX = string.Empty;
        /// <summary>
        /// 单价_单位
        /// </summary>
        private string m_DJ_DW = string.Empty;
        /// <summary>
        /// 基本量_人工系数
        /// </summary>
        private string m_JBL_RGXS = string.Empty;
        /// <summary>
        /// 定额号_材料系数
        /// </summary>
        private string m_DEH_CLXS = string.Empty;
        /// <summary>
        /// 调整量_机械系数
        /// </summary>
        private string m_TZL_JXXS = string.Empty;
        /// <summary>
        /// 主材
        /// </summary>
        private string m_ZC = string.Empty;
        /// <summary>
        /// 设备
        /// </summary>
        private string m_SB = string.Empty;
        /// <summary>
        /// 消耗类别
        /// </summary>
        private string m_XHLB = string.Empty;
        /// <summary>
        /// 分组
        /// </summary>
        private string m_FZ = string.Empty;
        /// <summary>
        /// 未知
        /// </summary>
        private string m_THZHC = string.Empty;
        /// <summary>
        /// 未知
        /// </summary>
        private string m_THWZFC = string.Empty;
        /// <summary>
        /// 未知
        /// </summary>
        private string m_HSXI = string.Empty;

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
        /// 是否选择
        /// </summary>
        public virtual bool IFXZ
        {
            get { return m_IFXZ; }
            set { m_IFXZ = value; }
        }
        /// <summary>
        /// 是否换算
        /// </summary>
        public bool IFHS
        {
            get { return m_IFHS; }
            set { m_IFHS = value; }
        }
        /// <summary>
        /// 定额号
        /// </summary>
        public string DEH
        {
            get { return m_DEH; }
            set { m_DEH = value; }
        }
        /// <summary>
        /// 换算类别
        /// </summary>
        public string HSLB
        {
            get { return m_HSLB; }
            set { m_HSLB = value; }
        }
        /// <summary>
        /// 换算信息
        /// </summary>
        public string HSXX
        {
            get { return m_HSXX; }
            set { m_HSXX = value; }
        }
        /// <summary>
        /// 单价_单位
        /// </summary>
        public string DJ_DW
        {
            get { return m_DJ_DW; }
            set { m_DJ_DW = value; }
        }
        /// <summary>
        /// 基本量_人工系数
        /// </summary>
        public string JBL_RGXS
        {
            get { return m_JBL_RGXS; }
            set { m_JBL_RGXS = value; }
        }
        /// <summary>
        /// 定额号_材料系数
        /// </summary>
        public string DEH_CLXS
        {
            get { return m_DEH_CLXS; }
            set { m_DEH_CLXS = value; }
        }
        /// <summary>
        /// 调整量_机械系数
        /// </summary>
        public string TZL_JXXS
        {
            get { return m_TZL_JXXS; }
            set { m_TZL_JXXS = value; }
        }
        /// <summary>
        /// 主材
        /// </summary>
        public string ZC
        {
            get { return m_ZC; }
            set { m_ZC = value; }
        }
        /// <summary>
        /// 设备
        /// </summary>
        public string SB
        {
            get { return m_SB; }
            set { m_SB = value; }
        }
        /// <summary>
        /// 消耗类别
        /// </summary>
        public string XHLB
        {
            get { return m_XHLB; }
            set { m_XHLB = value; }
        }
        /// <summary>
        /// 分组
        /// </summary>
        public string FZ
        {
            get { return m_FZ; }
            set { m_FZ = value; }
        }
        /// <summary>
        /// 未知
        /// </summary>
        public string THZHC
        {
            get { return m_THZHC; }
            set { m_THZHC = value; }
        }
        /// <summary>
        /// 未知
        /// </summary>
        public string THWZFC
        {
            get { return m_THWZFC; }
            set { m_THWZFC = value; }
        }
        /// <summary>
        /// 未知
        /// </summary>
        public string HSXI
        {
            get { return m_HSXI; }
            set { m_HSXI = value; }
        }
        #endregion
    }
}
