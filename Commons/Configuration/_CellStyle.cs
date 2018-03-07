/*
 单元格的样式对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _CellStyle
    {

        private Color m_ForeColor;

        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return this.m_ForeColor;
            }
            set
            {
                this.m_ForeColor = value;
            }
        }

        /// <summary>
        /// 背景颜色
        /// </summary>
        private Color m_BColor;

        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color BColor
        {
            get
            {
                return this.m_BColor;
            }
            set
            {
                this.m_BColor = value;
            }
        }

        /*
        private FontStyle m_FontStyle;

        /// <summary>
        /// 字体样式
        /// </summary>
        public FontStyle MFontStyle
        {
            get
            {
                return this.m_FontStyle;
            }
            set
            {
                this.m_FontStyle = value;
            }
        }*/

        
        /// <summary>
        /// 字体
        /// </summary>
        private Font m_Font = null;

        /// <summary>
        /// 字体
        /// </summary>
        public Font MFont
        {
            get
            {
                return this.m_Font;
            }
            set
            {
                this.m_Font = value;
            }
        }
        
    }
}
