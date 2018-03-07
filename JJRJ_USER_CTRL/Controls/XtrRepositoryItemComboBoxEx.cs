/*
 编辑控件重写
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;

namespace GOLDSOFT.QDJJ.CTRL
{
    public class XtrRepositoryItemComboBoxEx : RepositoryItemComboBox
    {
        /// <summary>
        /// 用于构造项的字符串数组
        /// </summary>
        private object[] m_ItemsSource = null;

        /// <summary>
        /// 获取或设置字符串数组
        /// </summary>
        public object[] ItemsSource
        {
            get
            {
                return this.m_ItemsSource;
            }
            set
            {
                this.m_ItemsSource = value;
            }
        }

        public XtrRepositoryItemComboBoxEx()
            : base()
        {
           
        }

        /// <summary>
        /// 重载构造函数
        /// </summary>
        /// <param name="items"></param>
        public XtrRepositoryItemComboBoxEx(object[] items)
            : base()
        {
            this.m_ItemsSource = items;
            this.Items.AddRange(items);
        }

        public void DataBind()
        {
            if (this.m_ItemsSource != null)
            {
                this.Items.AddRange(this.m_ItemsSource);
            }
        }
    }
}
