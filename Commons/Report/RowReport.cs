using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class RowReport
    {
        /// <summary>
        /// 绑定字段
        /// </summary>
        private string m_Field = string.Empty;
        /// <summary>
        /// 左标题字体
        /// </summary>
        private Font m_LeftFont = new Font("宋体", 10.5F);
        /// <summary>
        /// 左标题长度
        /// </summary>
        private int m_LeftLength = 0;
        /// <summary>
        /// 左标题
        /// </summary>
        private string m_LeftContent = string.Empty;
        /// <summary>
        /// 右标题字体
        /// </summary>
        private Font m_RightFont = new Font("宋体", 10.5F);
        /// <summary>
        /// 右标题长度
        /// </summary>
        private int m_RightLength = 0;
        /// <summary>
        /// 右标题
        /// </summary>
        private string m_RightContent = string.Empty;
        /// <summary>
        /// 内容字体
        /// </summary>
        private Font m_ContentFont = new Font("宋体", 12F);
        /// <summary>
        /// 内容对齐方式
        /// </summary>
        private Alignment m_ContentAlignment = Alignment.居中;
        /// <summary>
        /// 内容长度
        /// </summary>
        private int m_ContentLength = 0;
        /// <summary>
        /// 距上
        /// </summary>
        private int m_TopDistance = 0;
        /// <summary>
        /// 距左
        /// </summary>
        private int m_LeftDistance = 0;

        public override string ToString()
        {
            if (m_LeftContent == string.Empty)
            {
                return m_RightContent;
            }
            return m_LeftContent;
        }

        /// <summary>
        /// 获取或设置：绑定字段
        /// </summary>
        [CategoryAttribute("基础信息"), TypeConverter(typeof(FileNameConverter)), DisplayName("绑定字段"), DescriptionAttribute("建议不修改")]
        public string Field
        {
            get { return m_Field; }
            set
            {
                string[] n_f = value.Split('/');
                if (n_f.Length == 2)
                {
                    m_Field = n_f[1];
                }
                else
                {
                    m_Field = value;
                }
            }
        }
        /// <summary>
        /// 获取或设置：距上
        /// </summary>
        [CategoryAttribute("基础信息"), DisplayName("距上"), DescriptionAttribute("建议不修改")]
        public int TopDistance
        {
            get { return m_TopDistance; }
            set { m_TopDistance = value; }
        }
        /// <summary>
        /// 获取或设置：距左
        /// </summary>
        [CategoryAttribute("基础信息"), DisplayName("距左"), DescriptionAttribute("建议不修改")]
        public int LeftDistance
        {
            get { return m_LeftDistance; }
            set { m_LeftDistance = value; }
        }
        /// <summary>
        /// 获取或设置：左标题字体
        /// </summary>
        [CategoryAttribute("左标题信息"), DisplayName("左标题字体"), DescriptionAttribute("建议不修改")]
        public Font LeftFont
        {
            get { return m_LeftFont; }
            set { m_LeftFont = value; }
        }
        /// <summary>
        /// 获取或设置：左标题
        /// </summary>
        [CategoryAttribute("左标题信息"), DisplayName("左标题内容"), DescriptionAttribute("建议不修改")]
        public string LeftContent
        {
            get { return m_LeftContent; }
            set { m_LeftContent = value; }
        }
        /// <summary>
        /// 获取或设置：左标题长度
        /// </summary>
        [CategoryAttribute("左标题信息"), DisplayName("左标题长度"), DescriptionAttribute("建议不修改")]
        public int LeftLength
        {
            get { return m_LeftLength; }
            set { m_LeftLength = value; }
        }
        /// <summary>
        /// 获取或设置：右标题字体
        /// </summary>
        [CategoryAttribute("右标题信息"), DisplayName("右标题字体"), DescriptionAttribute("建议不修改")]
        public Font RightFont
        {
            get { return m_RightFont; }
            set { m_RightFont = value; }
        }
        /// <summary>
        /// 获取或设置：右标题
        /// </summary>
        [CategoryAttribute("右标题信息"), DisplayName("右标题内容"), DescriptionAttribute("建议不修改")]
        public string RightContent
        {
            get { return m_RightContent; }
            set { m_RightContent = value; }
        }
        /// <summary>
        /// 获取或设置：右标题长度
        /// </summary>
        [CategoryAttribute("右标题信息"), DisplayName("右标题长度"), DescriptionAttribute("建议不修改")]
        public int RightLength
        {
            get { return m_RightLength; }
            set { m_RightLength = value; }
        }
        /// <summary>
        /// 获取或设置：内容字体
        /// </summary>
        [CategoryAttribute("内容信息"), DisplayName("内容字体"), DescriptionAttribute("建议不修改")]
        public Font ContentFont
        {
            get { return m_ContentFont; }
            set { m_ContentFont = value; }
        }
        /// <summary>
        /// 获取或设置：内容长度
        /// </summary>
        [CategoryAttribute("内容信息"), DisplayName("内容长度"), DescriptionAttribute("建议不修改")]
        public int ContentLength
        {
            get { return m_ContentLength; }
            set { m_ContentLength = value; }
        }
        /// <summary>
        /// 获取或设置：内容对齐方式
        /// </summary>
        [CategoryAttribute("内容信息"), DisplayName("内容对齐方式"), DescriptionAttribute("建议不修改")]
        public Alignment ContentAlignment
        {
            get { return m_ContentAlignment; }
            set { m_ContentAlignment = value; }
        }

    }
}
