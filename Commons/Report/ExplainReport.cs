﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing;
using System.Drawing.Design;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 说明报表
    /// </summary>
    [Serializable]
    public class ExplainReport : _ObjectReport
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
        /// 字体样式
        /// </summary>
        private Font m_TitleFont = new Font("宋体", 21.75F, FontStyle.Bold);
        /// <summary>
        /// 对齐方式
        /// </summary>
        private Alignment m_TitleTextAlignment = Alignment.居中;
        /// <summary>
        /// 内容信息
        /// </summary>
        private string m_ExplainContent = string.Empty;
        /// <summary>
        /// 内容字体
        /// </summary>
        private Font m_ExplainFont = new Font("宋体", 12F);
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
        /// 获取或设置：内容信息
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(ContentEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [CategoryAttribute("内容"), DisplayName("内容信息"), DescriptionAttribute("列表集合")]
        public string ExplainContent
        {
            get { return m_ExplainContent; }
            set { m_ExplainContent = value; }
        }
        /// <summary>
        /// 获取或设置：内容字体
        /// </summary>
        [CategoryAttribute("内容"), DisplayName("内容字体"), DescriptionAttribute("列表集合")]
        public Font ExplainFont
        {
            get { return m_ExplainFont; }
            set { m_ExplainFont = value; }
        }
    }
}