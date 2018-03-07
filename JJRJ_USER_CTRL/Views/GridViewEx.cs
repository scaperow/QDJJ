using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.CTRL
{
    public class GridViewEx:GridView
    {
        

        /// <summary>
        /// 当需要Grid使用特殊的配色应用是后调用
        /// </summary>
        /// <param name="p_RowObject"></param>
        /// <param name="p_StyleInfo"></param>
        public delegate void SetRowCellColorHandler(object sender, CellColorArgs e);

        /// <summary>
        /// 单元格处理参数
        /// </summary>
        public class CellColorArgs
        {
            /// <summary>
            /// 当前处理的对象
            /// </summary>
            public object RowObject = null;
            /// <summary>
            /// 当前对象的配色方案
            /// </summary>
            public _SchemeColor SchemeColor = null;
            /// <summary>
            /// 当前应用配色
            /// </summary>
            public AppearanceObject Appearance = null;
            /// <summary>
            /// 当前色彩列对象
            /// </summary>
            public GridColumn Column = null;
        }
        
        /// <summary>
        /// 是否开启特殊配色方案
        /// </summary>
        private bool m_UseSpecialColor = false;

        public bool UseSpecialColor
        {
            set
            {
                if (value)
                {
                    this.OptionsView.EnableAppearanceEvenRow = this.OptionsView.EnableAppearanceOddRow = !value;
                }
                this.m_UseSpecialColor = value;
            }
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            //this.OptionsBehavior.EditorShowMode = EditorShowMode.Click;
        } 

        /// <summary>
        /// 委托-行色彩发生变化时候调用
        /// </summary>
        public event SetRowColorHandler SetRowColorChange;

        /// <summary>
        /// 委托-单元格发生变化的时激发事件
        /// </summary>
        public event SetRowCellColorHandler SetRowCellColorStyle;

        /// <summary>
        /// 当设置单元格样式时候激发的事件
        /// </summary>
        public void OnSetRowCellColor(object sender, CellColorArgs e)
        {
            if (this.SetRowCellColorStyle != null)
            {
                this.SetRowCellColorStyle(sender, e);
            }
        }

        /// <summary>
        /// 当设置行样式的时候激发事件
        /// </summary>
        public void OnSetRowColor(object p_RowObject, _SchemeColor p__SchemeColor, DevExpress.Utils.AppearanceObject appearance)
        {
            if (this.SetRowColorChange != null)
            {
                this.SetRowColorChange(p_RowObject, p__SchemeColor, appearance);
            }
        }


        /// <summary>
        ///  获取或设置控件的应用模块名称(若为空不添加任何特殊样式)
        ///  分类:工料机 
        /// </summary>
        private string m_ModelName = string.Empty;
        /// <summary>
        /// 获取或设置控件的应用模块名称
        /// </summary>
        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }
            set
            {
                this.m_ModelName = value;
            }
        }


        /// <summary>
        /// 当前树的列字段配置
        /// </summary>
        private _ColumnLayout m_ColumnLayout = null;

        /// <summary>
        /// 当前树的列字段配置
        /// </summary>
        public _ColumnLayout ColumnLayout
        {
            get
            {
                return this.m_ColumnLayout;
            }
            set
            {
                if (value != null)
                {
                    value.Get(this.ModelName, this);
                }
                this.m_ColumnLayout = value;
            }
        }

        /// <summary>
        /// 列颜色
        /// </summary>
        private _ColumnColor m_ColumnColor = null;

        /// <summary>
        /// 获取或设置列配色
        /// </summary>
        public _ColumnColor ColumnColor
        {
            get
            {
                return this.m_ColumnColor;
            }
            set
            {
                if (value != null)
                {
                    if (value[this.ModelName] != null)
                    {
                        foreach (GridColumn col in this.Columns)
                        {
                            _CellStyle style = value[this.ModelName][col.FieldName];
                            //保存颜色
                            if (style != null)
                            {
                                col.AppearanceCell.BackColor = style.BColor;
                            }
                        }
                    }
                }
            }
        }

        private GridViewAppearances m_GridViewAppearances = null;

        /// <summary>
        /// 获取或设置配色方案
        /// </summary>
        private _SchemeColor m_SchemeColor = null;

        /// <summary>
        /// 获取或设置配色方案
        /// </summary>
        public _SchemeColor SchemeColor
        {
            get
            {
                return this.m_SchemeColor;
            }
            set
            {
                if (value != null)
                {
                    this.m_SchemeColor = value;
                    if (value.GridStyle != null)
                    {
                        //this.OptionsView.EnableAppearanceEvenRow = this.OptionsView.EnableAppearanceOddRow = false;
                        //this.OptionsPrint.EnableAppearanceEvenRow = this.OptionsPrint.EnableAppearanceOddRow = false;
                        m_GridViewAppearances = value.GridStyle.Get() as GridViewAppearances;
                        this.Appearance.Assign(m_GridViewAppearances);
                        this.Appearance.HorzLine.BackColor = Color.FromArgb(142, 170, 205);
                        this.Appearance.VertLine.BackColor = Color.FromArgb(142, 170, 205);

                    }
                    else
                    {
                        //取默认值
                        this.Appearance.Reset();
                    }
                    
                }
            }
        }

        
        /// <summary>
        /// 当默认配色执行完毕后调用特殊配色方案
        /// </summary>
        /// <param name="e"></param>
        private void SetRowColor(int rowHandle, DevExpress.Utils.AppearanceObject appearance)
        {
            //类别颜色配置
            
            object oRowObject = this.GetRow(rowHandle);
            DataRowView info = (oRowObject as DataRowView);
            if (info != null)
            {
                //取类别
               
                    if (this.m_SchemeColor != null)
                    {
                        appearance.BeginUpdate();
                        _SpecialStyleInfo style = this.m_SchemeColor.SpecialStyle.Get(info["LB"].ToString());
                        if (style != null)
                        {
                            
                            
                            appearance.Font = new Font(appearance.Font.FontFamily, appearance.Font.Size, style.Font);
                            //字体颜色
                            appearance.ForeColor = style.ForeColor.IsEmpty ? appearance.ForeColor : style.ForeColor;
                            //背景颜色
                            appearance.BackColor = style.BColor.IsEmpty ? appearance.BackColor : style.BColor;

                            appearance.BackColor2 = style.BColor2.IsEmpty ? appearance.BackColor2 : style.BColor2;

                        }
                        this.OnSetRowColor(oRowObject, this.m_SchemeColor, appearance);
                        appearance.EndUpdate();
                    }

            }            
        }

        //RowCellStyle
        protected override DevExpress.Utils.AppearanceObject RaiseGetRowStyle(int rowHandle, DevExpress.XtraGrid.Views.Base.GridRowCellState state, DevExpress.Utils.AppearanceObject appearance, out bool highPriority)
        {
            
            AppearanceObject ao = base.RaiseGetRowStyle(rowHandle, state, appearance, out highPriority);
             //若为空使用系统颜色(不使用特殊配色)
            if (this.m_SchemeColor == null) return ao;

            if (this.m_SchemeColor.GridStyle == null)
            {
                return ao;
            }

             bool b_1 =((state & DevExpress.XtraGrid.Views.Base.GridRowCellState.Even) != 0);
             bool b_2 = ((state & DevExpress.XtraGrid.Views.Base.GridRowCellState.Odd) != 0);

             //object obj = this.m_SchemeColor.GridStyle.Get();
           
             //GridViewAppearances gva = obj as GridViewAppearances;
             if (this.m_GridViewAppearances != null)
             {
                 if (b_1)
                 {
                     ao.Assign(this.m_GridViewAppearances.EvenRow);
                 }
                 if (b_2)
                 {
                     ao.Assign(this.m_GridViewAppearances.OddRow);
                 }
             }

             if (m_UseSpecialColor)
             {
                 //奇数偶数都做此操作
                 if (b_1 || b_2)
                 {
                     this.SetRowColor(rowHandle, ao);
                 }
             }
             //AppearanceObject ao = base.RaiseGetRowStyle(rowHandle, state, appearance, out highPriority);
             return ao;
        }


        protected void RaiseColumnsLayout()
        {
            if (this.m_ColumnLayout != null)
            {
                this.m_ColumnLayout.Set(this.m_ModelName, this);
            }
        }

        protected override void  RaiseColumnWidthChanged(DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
 	        base.RaiseColumnWidthChanged(e);
            RaiseColumnsLayout();
        }



        private List<string> EditedObject = new List<string>();



        protected override void  RaiseCellValueChanged(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
 	         base.RaiseCellValueChanged(e);

             //编辑结束 记录当前编辑的对象
             //EditNode = e.Node;
             // EditColumn = e.Column;
             DataRow row  = this.GetDataRow(e.RowHandle);
             if (row.Table.Columns.Contains("ID"))
             {
                 string str = string.Format("{0},{1},{2}", e.RowHandle, e.Column.ColumnHandle, row["ID"]);
                 if (!EditedObject.Contains(str))
                 {
                     EditedObject.Add(str);
                 }
             }
        }

        /// <summary>
        /// 重新绘制单元格的时候条件(首先判断是否修改)
        /// </summary>
        /// <param name="rowHandle"></param>
        /// <param name="column"></param>
        /// <param name="state"></param>
        /// <param name="appearance"></param>
        /// <returns></returns>
        protected override AppearanceObject RaiseGetRowCellStyle(int rowHandle, DevExpress.XtraGrid.Columns.GridColumn column, DevExpress.XtraGrid.Views.Base.GridRowCellState state, AppearanceObject appearance)
        {
            AppearanceObject ao = base.RaiseGetRowCellStyle(rowHandle, column, state, appearance);
            if (this.m_SchemeColor != null)
            {
                if (SetRowCellColorStyle != null)
                {
                    CellColorArgs args = new CellColorArgs();
                    args.Appearance = ao;
                    args.RowObject = this.GetRow(rowHandle);
                    args.SchemeColor = this.m_SchemeColor;
                    args.Column = column;
                    //事件调用
                    this.OnSetRowCellColor(this, args);
                }
            }
            
            string str = string.Format("{0},{1}", rowHandle, column.ColumnHandle);
            if (this.EditedObject.Contains(str))
            {
                ao.Font = new Font(ao.Font.FontFamily, ao.Font.Size, FontStyle.Bold);
            }
            else
            {
                ao.Font = new Font(ao.Font.FontFamily, ao.Font.Size, ao.Font.Style);
            }
            //if (RaiseColumnColor(column, ao)) return ao;
            return ao;
        }

        /// <summary>
        /// 列配色优先
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool RaiseColumnColor(DevExpress.XtraGrid.Columns.GridColumn column,AppearanceObject ao)
        {
            //if (!e.Column.AppearanceCell.BackColor.IsEmpty || e.Column.AppearanceCell.BackColor == Color.White) return ao;
            if (this.ColumnColor != null)
            {
                _CellStyle style = this.ColumnColor[this.ModelName][column.FieldName];
                if (style != null)
                {
                    ao.BackColor = style.BColor;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 重绘单元格的时候事件
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseCustomDrawCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            base.RaiseCustomDrawCell(e);   
        }

        protected override void RaiseValidatingEditor(DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                switch (this.FocusedColumn.ColumnType.Name)
                {
                    case "String":

                        break;
                    case "Decimal":
                        Convert.ToDecimal(e.Value);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                e.ErrorText = "格式错误,按Esc取消后重新输入！";
                e.Valid = false;
            }
            finally
            {
                base.RaiseValidatingEditor(e);

            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // GridViewEx
            // 
            this.OptionsCustomization.AllowGroup = false;
            this.OptionsMenu.EnableColumnMenu = false;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
