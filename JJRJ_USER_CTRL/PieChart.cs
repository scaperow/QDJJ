using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class PieChart : UserControl
    {
        public PieChart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取或设置：显示字段名称
        /// </summary>
        public string ShowName
        {
            get { return this.chartControl1.Series[0].ArgumentDataMember; }
            set { this.chartControl1.Series[0].ArgumentDataMember = value; }
        }

        /// <summary>
        /// 获取或设置：数值字段名称
        /// </summary>
        public string ValueName
        {
            get { return this.chartControl1.Series[0].ValueDataMembers[0]; }
            set { this.chartControl1.Series[0].ValueDataMembers[0] = value; }
        }

        /// <summary>
        /// 获取或设置：数据源
        /// </summary>
        public object DataSource
        {
            get { return this.chartControl1.DataSource; }
            set { this.chartControl1.DataSource = value; }
        }
    }
}
