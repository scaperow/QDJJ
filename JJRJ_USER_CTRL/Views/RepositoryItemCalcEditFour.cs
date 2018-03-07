using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;

namespace GOLDSOFT.QDJJ.CTRL
{
    /// <summary>
    /// 数字控件（保留4位小数）
    /// </summary>
    public class RepositoryItemCalcEditFour : RepositoryItemCalcEdit
    {
        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.NullText = "0";
            this.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            this.Appearance.TextOptions.VAlignment = VertAlignment.Top;
            this.Buttons[0].Visible = false;//不显示 计算器
            this.DisplayFormat.FormatType = FormatType.Numeric;
            this.DisplayFormat.FormatString = "############0.####";
            this.EditMask = "############0.####"; //格式化 最大 千亿、保留4位小数
        }
    }
}
