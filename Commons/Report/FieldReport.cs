using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraPrinting;
using System.ComponentModel;
using System.Drawing;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class FieldReport
    {
        /// <summary>
        /// 绑定字段
        /// </summary>
        private string m_Field = string.Empty;
        /// <summary>
        /// 列表标题
        /// </summary>
        private string m_Bands = string.Empty;
        /// <summary>
        /// 列表名称
        /// </summary>
        private string m_Caption = string.Empty;
        /// <summary>
        /// 列表头部对齐方式
        /// </summary>
        private Alignment m_TopAlignment = Alignment.居中;
        /// <summary>
        /// 列表头部字体
        /// </summary>
        private Font m_HeaderFont = new Font("宋体", 9F, FontStyle.Bold);
        /// <summary>
        /// 列表宽度
        /// </summary>
        private int m_RowWidth = 100;
        /// <summary>
        /// 列表内容对齐方式
        /// </summary>
        private Alignment m_ContentAlignment = Alignment.居中;
        /// <summary>
        /// 列表内容字体
        /// </summary>
        private Font m_FormFont = new Font("宋体", 9F);

        public override string ToString()
        {
            if (m_Bands != string.Empty)
            {
                return m_Bands + "-" + m_Caption;
            }
            return m_Caption;
        }

        /// <summary>
        /// 获取或设置：绑定字段
        /// </summary>
        [CategoryAttribute("列表头部"), TypeConverter(typeof(FileNameConverter)), DisplayName("绑定字段"), DescriptionAttribute("字段")]
        public string Field
        {
            get { return m_Field; }
            set
            {
                string[] n_f = value.Split('/');
                if (n_f.Length == 2)
                {
                    m_Caption = n_f[0];
                    m_Field = n_f[1];
                }
                else
                {
                    m_Field = value;
                }
            }
        }
        /// <summary>
        /// 列表标题
        /// </summary>
        [CategoryAttribute("列表头部"), DisplayName("列头标题"), DescriptionAttribute("合并列")]
        public string Bands
        {
            get { return m_Bands; }
            set { m_Bands = value; }
        }
        /// <summary>
        /// 获取或设置：列表名称
        /// </summary>
        [CategoryAttribute("列表头部"), DisplayName("列头名称"), DescriptionAttribute("列名：列的标题名称")]
        public string Caption
        {
            get { return m_Caption; }
            set { m_Caption = value; }
        }
        /// <summary>
        /// 获取或设置：列表头部对齐方式
        /// </summary>
        [CategoryAttribute("列表头部"), DisplayName("列头对齐方式"), DescriptionAttribute("列表头部对齐方式")]
        public Alignment TopAlignment
        {
            get { return m_TopAlignment; }
            set { m_TopAlignment = value; }
        }
        /// <summary>
        /// 获取或设置：列表宽度
        /// </summary>
        [CategoryAttribute("列表头部"), DisplayName("列头宽度"), DescriptionAttribute("列的宽度（以0.1毫米为单位）")]
        public int RowWidth
        {
            get { return m_RowWidth; }
            set { m_RowWidth = value; }
        }

        /// <summary>
        /// 获取或设置：表头字体
        /// </summary>
        [CategoryAttribute("列表头部"), DisplayName("列头字体"), DescriptionAttribute("列头字体")]
        public Font HeaderFont
        {
            get { return m_HeaderFont; }
            set { m_HeaderFont = value; }
        }
        /// <summary>
        /// 获取或设置：列表内容对齐方式
        /// </summary>
        [CategoryAttribute("列表内容"), DisplayName("列表内容对齐方式"), DescriptionAttribute("列表内容对齐方式")]
        public Alignment ContentAlignment
        {
            get { return m_ContentAlignment; }
            set { m_ContentAlignment = value; }
        }
        /// <summary>
        /// 获取或设置：表格字体
        /// </summary>
        [CategoryAttribute("列表内容"), DisplayName("列表内容字体"), DescriptionAttribute("列表内容字体")]
        public Font FormFont
        {
            get { return m_FormFont; }
            set { m_FormFont = value; }
        }
    }
}
