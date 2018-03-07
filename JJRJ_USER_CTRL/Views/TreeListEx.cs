/*
  重写树形结构
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.Utils;
using System.Data;
using System.Drawing;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.CTRL
{
    public class TreeListEx : DevExpress.XtraTreeList.TreeList
    {
        /// <summary>
        /// 当编辑控件进入焦点的时候激发
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="args"></param>
        public delegate void BeforeEnterEditerHandler(object sender, EditArgs args);

        /// <summary>
        /// 当编辑控件进入焦点的时候激发
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="args"></param>
        public delegate void LostEnterEditerHandler(object sender, EditArgs args);
        /// <summary>
        /// 单元格处理参数
        /// </summary>
        public class EditArgs
        {
            /// <summary>
            ///  当前列对象
            /// </summary>
            public TreeListColumn Column = null;
        }
        private bool m_AllowSort=false;
        /// <summary>
        /// 是否允许排序
        /// </summary>
        public bool AllowSort
        {
            get { return m_AllowSort; }
            set { m_AllowSort = value; }
        }
        private bool m_AllowDoubleEdit = false;
        /// <summary>
        /// 是否允许点击两次编辑
        /// </summary>
        public bool AllowDoubleEdit
        {
            get { return m_AllowDoubleEdit; }
            set { m_AllowDoubleEdit = value; }
        }

        public event SetRowColorHandler SetRowColorChange;
        /// <summary>
        /// 获取焦点时候激发
        /// </summary>
        public event BeforeEnterEditerHandler BeforeEnterEditer;

        /// <summary>
        /// 获取焦点时候激发
        /// </summary>
        public event LostEnterEditerHandler LostEnterEditer;


        /// <summary>
        /// 控件获取焦点时候激发
        /// </summary>
        public void OnLostEnterEditer(object sender, EditArgs args)
        {
            if (this.LostEnterEditer != null)
            {
                this.LostEnterEditer(sender, args);
            }

        }

        

      
        /// <summary>
        /// 控件获取焦点时候激发
        /// </summary>
        public void OnBeforeEnterEditer(object sender, EditArgs args)
        {
            if (this.BeforeEnterEditer != null)
            {
                this.BeforeEnterEditer(sender,args);
            }

        }
 
         /// <summary>
        /// 当全局样式发生变化时调用
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
        ///  分类:分部分项 工料机 
        /// </summary>
        private string m_ModelName = string.Empty;

        /// <summary>
        /// 当前树的列字段配置
        /// </summary>
        private _ColumnLayout m_ColumnLayout = null;
        
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
                        foreach (TreeListColumn col in this.Columns)
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

        public DataRowView Current
        {
            get {
                if (this.FocusedNode != null)
                    return this.GetDataRecordByNode(this.FocusedNode) as DataRowView;
                else
                {
                    return null;
                }
            }
        }
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
                    if (value.TreeStyle != null)
                    {
                        this.Appearance.Assign(value.TreeStyle.Get());
                        this.Appearance.HorzLine.BackColor = Color.FromArgb(142,170,205);
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

         
     
        /*
        /// <summary>
        /// 设置当前Grid的样式对象
        /// </summary>
        private _TreeListStyle m_StyleObject = null;

        /// <summary>
        /// 获取或设置当前Grid的样式对象(赋值后会将样式应用到此控件上)
        /// </summary>
        public _TreeListStyle StyleObject
        {
            get
            {
                return this.m_StyleObject;
            }
            set
            {
                if (value != null)
                {
                    this.Appearance.Assign(value.Get(this.ModelName));
                }
                this.m_StyleObject = value;
            }
        }*/

        private ArrayList m_CheckNodes;

        /// <summary>
        /// 选中的节点集合
        /// </summary>
        public ArrayList CheckNodes
        {
            get { return m_CheckNodes; }
            set { m_CheckNodes = value; }
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.m_CheckNodes = new ArrayList();
            this.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.OptionsBehavior.ImmediateEditor = false;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            MouseEventArgs e1 = e as MouseEventArgs;
            if (e1 != null)
            {
                DevExpress.XtraTreeList.TreeListHitInfo info =this.CalcHitInfo(e1.Location);
                if (info.Node == null)
                {
                    this.CloseEditor();
                }

            }

        }
        
        protected override void RaiseGetCustomNodeCellEdit(GetCustomNodeCellEditEventArgs e, ref DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            if (e.Column.ColumnType == typeof(decimal))
            e.RepositoryItem.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
        }

   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="Level"></param>
        private void Expand(TreeListNodes node, int Level)
        {
            foreach (TreeListNode item in node)
            {
                if (item.Level < Level)
                {
                    item.Expanded = true;
                    Expand(item.Nodes, Level);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 节点展开
        /// </summary>
        /// <param name="Level">要展开的层级数</param>
        public void Expand(int Level)
        {
            Expand(this.Nodes, Level);
            
        
        }

        
        protected override DevExpress.Utils.AppearanceObject RaiseGetCustomNodeCellStyle(DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
                        
            AppearanceObject ao = base.RaiseGetCustomNodeCellStyle(e);
            if (!e.Column.AppearanceCell.BackColor.IsEmpty)
            {
                if (e.Column.AppearanceCell.BackColor.ToArgb() != Color.White.ToArgb())
                {
                    return ao;
                }
            }
            //if (!e.Column.AppearanceCell.BackColor.IsEmpty && e.Column.AppearanceCell.BackColor != Color.White) return ao;
            //如果当前行是焦点行或者是选中行直接返回
            if (this.FocusedNode == e.Node) return ao;
            
            //如果找到列配色方案 直接返回ao
            //if (RaiseColumnColor(e)) return ao;
            
            //不同模块使用不同配色方式
            switch (this.ModelName)
            {
                case "分部分项":
                    this.RaiseGetCustomNodeCellStyleEx(e, "LB");
                    break;
                default://默认配色 按照Level配色
                    this.RaiseGetCustomNodeCellStyleEx(e);
                    break;
            }
            return ao;
        }

        /// <summary>
        /// 列配色优先
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool RaiseColumnColor(DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            //if (!e.Column.AppearanceCell.BackColor.IsEmpty || e.Column.AppearanceCell.BackColor == Color.White) return ao;
            if (this.ColumnColor != null)
            {
                _CellStyle style = this.ColumnColor[this.ModelName][e.Column.FieldName];
                if(style != null)
                {
                    e.Appearance.BackColor = style.BColor;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 其他项目 措施项目 汇总分析 树节点配色
        /// </summary>
        /// <param name="e"></param>
        private void RaiseGetCustomNodeCellStyleEx(DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (this.m_SchemeColor != null)
            {
                //类别颜色配置
                 _SpecialStyleInfo style = null;
                 string str = string.Format("一级[{0}]", this.ModelName);
                 //string str =string.Format("T{0}",e.Node.Level);
                 if (e.Node.Level == 0) str = string.Format("一级[{0}]", this.ModelName);
                 if (e.Node.Level == 1) str = string.Format("二级[{0}]", this.ModelName);
                 if (e.Node.Level == 2) str = string.Format("三级[{0}]", this.ModelName);
                 if (e.Node.Level == 3) str = string.Format("四级[{0}]", this.ModelName);
                 if (e.Node.Level == 4) str = string.Format("五级[{0}]", this.ModelName);
                 style = this.m_SchemeColor.SpecialStyle.Get(str);
                if (style != null)
                {
                    //e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, style.Font);
                    //字体颜色
                    e.Appearance.ForeColor = style.ForeColor;
                    //背景颜色
                    e.Appearance.BackColor = style.BColor;
                    //扩展色
                    //e.Appearance.BackColor2 = style.BColor2;
                }
                ///特殊配色时候自定义处理
                OnSetRowColor(this.GetDataRecordByNode(e.Node), this.m_SchemeColor, e.Appearance);
            }
            //
        }
        

        /// <summary>
        /// 当默认配色执行完毕后调用特殊配色方案(各个模块调用特殊配色)
        /// </summary>
        /// <param name="e"></param>
        private void RaiseGetCustomNodeCellStyleEx(DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e,string p_FileName)
        {
            if (this.m_SchemeColor != null)
            {
                //类别颜色配置
                object obj = e.Node.GetValue(p_FileName);
                if (obj != null)
                {
                    string str = obj.ToString();
                    _SpecialStyleInfo style = null;
                    if (str == string.Empty)
                    {
                        style = this.m_SchemeColor.SpecialStyle.Get("单位工程");
                    }
                    else
                    {
                        //找不到按照层级处理
                        style = this.m_SchemeColor.SpecialStyle.Get(str);
                    }
                        
                        if (style != null)
                        {
                            //e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, style.Font);
                            //字体颜色
                            e.Appearance.ForeColor = style.ForeColor;
                            //背景颜色
                            e.Appearance.BackColor = style.BColor;
                            //扩展色
                            //e.Appearance.BackColor2 = style.BColor2;
                        }

                        ///特殊配色时候自定义处理
                        OnSetRowColor(this.GetDataRecordByNode(e.Node), this.m_SchemeColor, e.Appearance);
                }
            }
            //
        }


        /// <summary>
        /// 重写每次为单元格指定样式的时候调用的方法
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
         /*protected override DevExpress.Utils.AppearanceObject RaiseGetCustomNodeCellStyle(DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
           if (this.m_SchemeColor != null)
            {
                _CAppearance appear = this.m_SchemeColor[e.Node.Level];
                //前景色
                e.Appearance.ForeColor = appear.ForeColor;
                //背景色
                e.Appearance.BackColor = appear.BackColor;
            }
            */            
           

            /*if (this.m_SchemeColor != null)
            {
                if (this.m_SchemeColor.TreeStyle.ModelStyle[this.m_ModelName] != null)
                {
                    _CellStyle cs = this.m_SchemeColor.TreeStyle.ModelStyle[this.m_ModelName][e.Node.Level];
                    if (cs != null)
                    {
                        if (!e.Node.Focused)
                        {
                            e.Appearance.Font = cs.MFont;
                            //字体颜色
                            e.Appearance.ForeColor = cs.ForeColor;
                            //背景颜色
                            e.Appearance.BackColor = cs.BColor;
                        }
                        else
                        {
                            e.Appearance.Font = cs.MFont;
                            //字体颜色
                            e.Appearance.ForeColor = cs.ForeColor;
                        }

                    }
                    //_TreeListStyle ts = (m_StyleObject as _TreeListStyle);

                    //e.Appearance.Assign((ts.CurrentModelStyle[this.m_ModelName][e.Node.Level].Get());
                }
            }
            this.RaiseGetCustomNodeCellStyleEx(e);
            return base.RaiseGetCustomNodeCellStyle(e);
        }*/

   
        /// <summary>
        /// 刷新表格
        /// </summary>
        public override void Refresh()
        {

            /*if (this.m_StyleObject != null)
            {
                this.Appearance.Assign(this.m_StyleObject.Get(this.ModelName));
            }*/
            base.Refresh();
        }

        protected override void RaiseColumnWidthChanged(DevExpress.XtraTreeList.Columns.TreeListColumn column)
        {
            base.RaiseColumnWidthChanged(column);
            RaiseColumnsLayout();
        }

        protected override void RaiseColumnChanged(DevExpress.XtraTreeList.Columns.TreeListColumn column)
        {
            base.RaiseColumnChanged(column);
            RaiseColumnsLayout();
            //RaiseColumnsColor(column);
        }

        /*protected void RaiseColumnsColor(DevExpress.XtraTreeList.Columns.TreeListColumn column)
        {
            if (this.m_ColumnLayout != null)
            {
                this.m_ColumnLayout.Set(this.m_ModelName, this);
            }
        }*/

        protected void RaiseColumnsLayout()
        {
            if (this.m_ColumnLayout != null)
            {
                this.m_ColumnLayout.Set(this.m_ModelName, this);
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeListEx
            // 
            this.OptionsView.EnableAppearanceEvenRow = true;
            this.OptionsView.EnableAppearanceOddRow = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }       

        private List<string> EditedObject = new List<string>();
        protected override void RaiseCellValueChanged(DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            base.RaiseCellValueChanged(e);
            
            //编辑结束 记录当前编辑的对象
            //EditNode = e.Node;
           // EditColumn = e.Column;
            /*string str = string.Format("{0},{1}",e.Node.Id,e.Column.ColumnHandle);
            if(!EditedObject.Contains(str))
            {
                EditedObject.Add(str);
            }*/
            
        }

        /// <summary>
        /// 重绘节点修改过的加粗
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseCustomDrawNodeCell(DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            base.RaiseCustomDrawNodeCell(e);
            if (e.Column.ColumnType == typeof(decimal))
            {
                e.CellText = ToolKit.TrimZero(e.CellText);
            }
            /*string str = string.Format("{0},{1}", e.Node.Id, e.Column.ColumnHandle);
            if (this.EditedObject.Contains(str))
            {
                e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold);
            }
            else
            {
                e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, e.Appearance.Font.Style);
            }*/
        }

        protected override void OnSetValue(TreeListNode node, object columnID, object val)
        {
            //base.OnSetValue(node, columnID, val);

        }
        protected override void OnActiveEditor_GotFocus(object sender, EventArgs e)
        {
            base.OnActiveEditor_GotFocus(sender, e);
            EditArgs args = new EditArgs();
            args.Column = this.FocusedColumn;
            this.OnBeforeEnterEditer(sender, args);
        }
        protected override void OnActiveEditor_LostFocus(object sender, EventArgs e)
        {
            /*base.OnActiveEditor_LostFocus(sender, e);
            EditArgs args = new EditArgs();
            args.Column = this.FocusedColumn;
            this.OnLostEnterEditer(sender, args);*/
        }

        protected override void RaiseCustomDrawColumnHeader(DevExpress.XtraTreeList.CustomDrawColumnHeaderEventArgs e)
        {
          
            base.RaiseCustomDrawColumnHeader(e);
            //if (e.Column!=null)
            //e.Column.OptionsColumn.AllowSort = this.m_AllowSort;
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

        int m_Click = 0;

        public int ClickCount
        {
            get { return m_Click; }
            set { m_Click = value; }
        }
    }
}
