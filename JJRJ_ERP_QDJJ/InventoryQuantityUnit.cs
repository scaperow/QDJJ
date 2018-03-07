using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class InventoryQuantityUnit : BaseForm
    {
        public InventoryQuantityUnit()
        {
            InitializeComponent();
        }

        public InventoryQuantityUnit(_Business p_bus)
        {
            InitializeComponent();
            this.CurrentBusiness = p_bus;
        }


        /// <summary>
        /// 筛选相同工料机
        /// </summary>
        /// <param name="info">工料机汇总集合</param>
        public void DoFilter(_List info)
        {
            this.gridControl1.DataSource = info;
        }

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
        }

        /*public override void Refresh()
        {
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            base.Refresh();
        }*/

        public string ModelName = string.Empty;

        public override void GlobalStyleChange()
        {
            this.gridView1.UseSpecialColor = true;
            this.gridView1.ModelName = ModelName;
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            this.gridView1.ColumnLayout = APP.DataObjects.GColor.ColumnLayout;
        }

        private void gridView1_SetRowColorChange(object p_RowObject, _SchemeColor p_SchemeColor, DevExpress.Utils.AppearanceObject appearance)
        {
            

            _ObjectQuantityUnitInfo info = (p_RowObject as _ObjectQuantityUnitInfo);
            if (info.YSBH == info.BH && info.YSDW == info.DW && info.YSMC == info.MC && info.SCDJ != info.DEDJ)
            {
                //获取特殊样式绑定颜色
                _SpecialStyleInfo style = p_SchemeColor.SpecialStyle.Get("市场单价修改");
                if (style != null)
                {
                    appearance.Font = new Font(appearance.Font.FontFamily, appearance.Font.Size, style.Font);
                    //字体颜色
                    appearance.ForeColor = style.ForeColor.IsEmpty ? appearance.ForeColor : style.ForeColor;
                    //背景颜色
                    appearance.BackColor = style.BColor.IsEmpty ? appearance.BackColor : style.BColor;

                    appearance.BackColor2 = style.BColor2.IsEmpty ? appearance.BackColor2 : style.BColor2;
                }
            }
        }
    }
}