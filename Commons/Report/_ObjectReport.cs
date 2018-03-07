using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 报表基类
    /// </summary>
    [Serializable]
    public class _ObjectReport
    {
        /// <summary>
        /// 报表序号
        /// </summary>
        private int m_ID;
        /// <summary>
        /// 报表父节点
        /// </summary>
        private int m_PID;
        /// <summary>
        /// 报表类别
        /// </summary>
        private string m_ReportType = string.Empty;
        /// <summary>
        /// 单位报表类别
        /// </summary>
        private string m_UnitReportType = string.Empty;
        /// <summary>
        /// 报表名称
        /// </summary>
        private string m_ReportName = string.Empty;
        /// <summary>
        /// 报表方法名称
        /// </summary>
        private string m_Method = string.Empty;
        /// <summary>
        /// 项目名称
        /// </summary>
        private string m_XMMC = string.Empty;
        /// <summary>
        /// 专业名称
        /// </summary>
        private string m_ZYMC = string.Empty;
        /// <summary>
        /// 字段集合
        /// </summary>
        private string[] m_FileList;
        /// <summary>
        /// 数据源
        /// </summary>
        [NonSerialized]
        private object m_DataSource;

        /// <summary>
        /// 获取或设置：报表序号
        /// </summary>
        [BrowsableAttribute(false)]
        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        /// <summary>
        /// 获取或设置：报表父节点
        /// </summary>
        [BrowsableAttribute(false)]
        public int PID
        {
            get { return m_PID; }
            set { m_PID = value; }
        }
        /// <summary>
        /// 获取或设置：报表名称
        /// </summary>
        [CategoryAttribute("报表"), DisplayName("报表名称"), DescriptionAttribute("建议不修改")]
        public string ReportName
        {
            get { return m_ReportName; }
            set { m_ReportName = value; }
        }
        /// <summary>
        /// 获取或设置：报表方法名称
        /// </summary>
        [BrowsableAttribute(false)]
        public string Method
        {
            get { return m_Method; }
            set { m_Method = value; }
        }
        /// <summary>
        /// 获取或设置：报表类别
        /// </summary>
        [BrowsableAttribute(false)]
        public string ReportType
        {
            get { return m_ReportType; }
            set { m_ReportType = value; }
        }
        /// <summary>
        /// 获取或设置：单位报表类别
        /// </summary>
        [BrowsableAttribute(false)]
        public string UnitReportType
        {
            get { return m_UnitReportType; }
            set { m_UnitReportType = value; }
        }
        /// <summary>
        /// 获取或设置：项目名称
        /// </summary>
        [BrowsableAttribute(false)]
        public string XMMC
        {
            get { return m_XMMC; }
            set { m_XMMC = value; }
        }
        /// <summary>
        /// 获取或设置：专业名称
        /// </summary>
        [BrowsableAttribute(false)]
        public string ZYMC
        {
            get { return m_ZYMC; }
            set { m_ZYMC = value; }
        }
        /// <summary>
        /// 获取或设置：字段集合
        /// </summary>
        [BrowsableAttribute(false)]
        public string[] FileList
        {
            get { return m_FileList; }
            set { m_FileList = value; }
        }
        /// <summary>
        /// 获取或设置：数据源
        /// </summary>
        [BrowsableAttribute(false)]
        public object DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }
        /// <summary>
        /// 获取项目名称
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.m_ReportName;
        }
    }
}
