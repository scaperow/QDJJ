/*
    表-配色结构
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _GridStyle:_StyleObject
    {
        public _GridStyle()
        {
            this.Default = new _CAppearance();
        }

        

        /// <summary>
        /// 获取当前界面对象
        /// </summary>
        public override BaseAppearanceCollection Get()
        {
            if (this.Current != null)
            {
                if (this.Current.Value != null)
                {
                    BaseAppearanceCollection ga = new GridViewAppearances(null);
                    System.IO.MemoryStream buffer = new System.IO.MemoryStream(this.Current.Value);
                    ga.RestoreLayoutFromStream(buffer);
                    buffer.Close();
                    return ga;
                }
            }
            return null;
        }

    }
}
