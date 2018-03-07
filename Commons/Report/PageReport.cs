using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Drawing;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class PageReport : _ObjectReport
    {
        /// <summary>
        /// 页面边距
        /// </summary>
        private Margins m_Margins = new Margins(100, 100, 100, 100);
        /// <summary>
        /// 纸张型号
        /// </summary>
        private PaperKind m_PaperKind = PaperKind.A4;
        /// <summary>
        /// 纸张方向
        /// </summary>
        private Direction m_Landscape = Direction.纵向;
        /// <summary>
        /// 标题内容
        /// </summary>
        private string m_TitleCaption = string.Empty;
        /// <summary>
        /// 距上
        /// </summary>
        private int m_TopDistance = 0;
        /// <summary>
        /// 字体样式
        /// </summary>
        private Font m_TitleFont = new Font("宋体", 21.75F, FontStyle.Bold);
        /// <summary>
        /// 对齐方式
        /// </summary>
        private Alignment m_TitleTextAlignment = Alignment.居中;
        /// <summary>
        /// 行集合
        /// </summary>
        private RowReport[] m_RowReports;
        /// <summary>
        /// 获取或设置：页面边距
        /// </summary>
        [BrowsableAttribute(false), CategoryAttribute("报表"), DisplayName("页面边距"), DescriptionAttribute("内容与纸张的间距分左右上线")]
        public Margins Margins
        {
            get { return m_Margins; }
            set { m_Margins = value; }
        }
        /// <summary>
        /// 获取或设置：纸张型号
        /// </summary>
        [CategoryAttribute("报表"), DisplayName("纸张型号"), DescriptionAttribute("")]
        public PaperKind PaperKind
        {
            get { return m_PaperKind; }
            set { m_PaperKind = value; }
        }
        /// <summary>
        /// 获取或设置：纸张方向
        /// </summary>
        [CategoryAttribute("报表"), DisplayName("纸张方向"), DescriptionAttribute("true=横向 false=竖向")]
        public Direction Landscape
        {
            get { return m_Landscape; }
            set { m_Landscape = value; }
        }
        /// <summary>
        /// 获取或设置：标题距上距离
        /// </summary>
        [CategoryAttribute("标题"), DisplayName("距上"), DescriptionAttribute("请输入内容")]
        public int TopDistance
        {
            get { return m_TopDistance; }
            set { m_TopDistance = value; }
        }
        /// <summary>
        /// 获取或设置：标题内容
        /// </summary>
        [CategoryAttribute("标题"), DisplayName("标题内容"), DescriptionAttribute("请输入内容")]
        public string TitleCaption
        {
            get { return m_TitleCaption; }
            set { m_TitleCaption = value; }
        }
        /// <summary>
        /// 获取或设置：字体样式
        /// </summary>
        [BrowsableAttribute(false), CategoryAttribute("标题"), DisplayName("字体样式"), DescriptionAttribute("请选择合适的字体样式")]
        public Font TitleFont
        {
            get { return m_TitleFont; }
            set { m_TitleFont = value; }
        }
        /// <summary>
        /// 获取或设置：对齐方式
        /// </summary>
        [CategoryAttribute("标题"), DisplayName("对齐方式"), DescriptionAttribute("标题内容对齐方式")]
        public Alignment TitleTextAlignment
        {
            get { return m_TitleTextAlignment; }
            set { m_TitleTextAlignment = value; }
        }
        /// <summary>
        /// 获取或设置：行集合
        /// </summary>
        [CategoryAttribute("行信息"), DisplayName("行信息"), DescriptionAttribute("编辑行信息")]
        public RowReport[] RowReports
        {
            get
            {
                FileNameConverter.FileList = this.FileList;
                return m_RowReports;
            }
            set { m_RowReports = value; }
        }
    }
}
