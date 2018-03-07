using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class AreaQuantityUnit : BaseForm
    {
        /// <summary>
        /// 当前正在操作的子目
        /// </summary>
        private _Methods_Subheadings m_Methods_Subheadings = null;

        public AreaQuantityUnit()
        {
            InitializeComponent();
        }

        public AreaQuantityUnit(_Business p_Business, _UnitProject p_Activitie, ABaseForm p_AParentForm, string p_FormName)
        {
            this.CurrentBusiness = p_Business;
            this.Activitie = p_Activitie;
            this.AParentForm = p_AParentForm;
            m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
            this.Text = p_FormName;
            InitializeComponent();
        }

        /// <summary>
        /// 筛选相同工料机
        /// </summary>
        /// <param name="info">工料机汇总集合</param>
        public void DoFilter(_Entity_SubInfo p_info)
        {
            if(p_info == null) return;
            this.m_Methods_Subheadings.Current = p_info;
            if (this.Activitie.StructSource.ModelQuantity.Rows.Count > 0)
            {
                string str = string.Empty;
                switch (p_info.SSLB)
                {
                    case 0:
                        str = FBFX_HB();
                        break;
                    case 1:
                        str = CSXM_HB();
                        break;
                    default:
                        break;
                }
                if (str == string.Empty) return;
                DataSetHelper m_DataSetHelper = new DataSetHelper();
                DataTable dt = m_DataSetHelper.SelectGroupByInto(this.Activitie.StructSource.ModelQuantity.TableName, this.Activitie.StructSource.ModelQuantity, _Constant.gljzd, str, _Constant.hbtjzd);
                this.gridControl1.DataSource = dt;
            }
            else
            {
                this.gridControl1.DataSource = null;
            }
        }

        private string FBFX_HB()
        {
            string str = string.Empty;
            switch (this.m_Methods_Subheadings.Current.LB)
            {
                case "分部-专业":
                    str = string.Format("QDID IN({0}) AND SSLB={1} AND ZCLB='W'", this.GetQDID(this.Activitie.StructSource.ModelSubSegments, "PPARENTID"), this.m_Methods_Subheadings.Current.SSLB);
                    break;
                case "分部-章":
                    str = string.Format("QDID IN({0}) AND SSLB={1} AND ZCLB='W'", this.GetQDID(this.Activitie.StructSource.ModelSubSegments, "CPARENTID"), this.m_Methods_Subheadings.Current.SSLB);
                    break;
                case "分部-节":
                    str = string.Format("QDID IN({0}) AND SSLB={1} AND ZCLB='W'", this.GetQDID(this.Activitie.StructSource.ModelSubSegments, "PID"), this.m_Methods_Subheadings.Current.SSLB);
                    break;
                case "清单":
                    str = string.Format("QDID = {0} AND SSLB={1} AND ZCLB='W'", this.m_Methods_Subheadings.Current.ID, this.m_Methods_Subheadings.Current.SSLB);
                    break;
                default:
                    if (this.m_Methods_Subheadings.Current.PID == 0)
                    {
                        str = string.Format("UNID = {0} AND SSLB={1} AND ZCLB='W'", this.m_Methods_Subheadings.Current.UnID, this.m_Methods_Subheadings.Current.SSLB);
                    }
                    break;
            }
            return str;
        }

        private string CSXM_HB()
        {
            string str = string.Empty;
            switch (this.m_Methods_Subheadings.Current.LB)
            {
                case "清单":
                    str = string.Format("QDID = {0} AND SSLB={1} and ZCLB='W'", this.m_Methods_Subheadings.Current.ID, this.m_Methods_Subheadings.Current.SSLB);
                    break;
                default:
                    if (this.m_Methods_Subheadings.Current.PID == 0)
                    {
                        str = string.Format("UNID = {0} AND SSLB={1} and ZCLB='W'", this.m_Methods_Subheadings.Current.UnID, this.m_Methods_Subheadings.Current.SSLB);
                    }
                    else
                    {
                        str = string.Format("QDID IN({0}) AND SSLB={1} and ZCLB='W'", this.GetQDID(this.Activitie.StructSource.ModelMeasures, "PID"), this.m_Methods_Subheadings.Current.SSLB);
                    }
                    break;
            }
            return str;
        }

        /// <summary>
        /// 获取清单ID
        /// </summary>
        /// <param name="p_info"></param>
        /// <param name="p_BH"></param>
        /// <returns></returns>
        private string GetQDID(_SubSegmentsSource p_info,string p_BH)
        {
            string str = "-1";
            DataRow[] drs = p_info.Select(string.Format("{0}={1}",p_BH,this.m_Methods_Subheadings.Current.ID));
            foreach (DataRow item in drs)
            {
                if (str == "-1")
                {
                    str = string.Empty;
                }
                str += item["ID"].ToString() + ",";
            }
            if (str != "-1")
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != null)
            {
                switch (e.Column.FieldName)
                {
                    case "SL":
                    case "XHL":
                    case "YSXHL":
                    case "SCDJ":
                    case "SCHJ":
                    case "DEDJ":
                    case "DEHJ":
                        decimal d = ToolKit.ParseDecimal(e.CellValue);
                        if (d.Equals(0m))
                        {
                            e.DisplayText = string.Empty;
                        }
                        break;
                    default:
                        break;
                }
            }
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


            DataRowView info = (p_RowObject as DataRowView);
            if (info["YSBH"] == info["BH"] && info["YSDW"] == info["DW"] && info["YSMC"] == info["MC"] && !info["SCDJ"].Equals(info["DEDJ"]))
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

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void RaiseColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DisplayColumns(this.gridView1);
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridView gv = sender as GridView;
            GridHitInfo hi = gv.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
    }
}