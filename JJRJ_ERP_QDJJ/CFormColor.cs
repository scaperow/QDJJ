using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.Utils;
using System.Collections;
using System.Linq;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CFormColor : BaseForm
    {

        public ApplicationForm AppForm = null;

        /// <summary>
        /// 临时存放(内存中编辑的对象)
        /// </summary>
        private _SchemeColor TempUseColor = null;

        /// <summary>
        /// 
        /// </summary>
        private _UseColor m_UseColor = null;

        /// <summary>
        /// 
        /// </summary>
        public _UseColor GColor
        {
            get
            {
                return this.m_UseColor;
            }
            set
            {
                this.TempUseColor = value.Current().Copy();
                this.m_UseColor = value;
            }
        }

        /// <summary>
        /// 重新获取选择方案使用框架修改后调用
        /// </summary>
        private void RestUseColor()
        {
            this.TempUseColor = m_UseColor.Current().Copy();
        }


        public CFormColor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 应用配色方案到当前(使用客户定义的)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //把临时的方案放入
            this.m_UseColor.Custom = this.TempUseColor;
            this.DialogResult = DialogResult.OK;
        }

        private void CFormColor_Load(object sender, EventArgs e)
        {
            init();
            initData();
            initEvent();

        }

        private void init()
        {
            this.radioGroup1.SelectedIndex = 0;
            //radioGroup1_SelectedIndexChanged(this.radioGroup1,null);
            
        }

        private void initEvent()
        {
            this.bindingSource1.PositionChanged += new EventHandler(bindingSource1_PositionChanged);
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {


        }

        private void initData()
        {



            //初始化树结构数据
            this.bindingSource1.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Color_Temp"];
            this.treeListEx1.SchemeColor = this.TempUseColor;
            this.treeListEx1.DataSource = this.bindingSource1;
            //this.treeListEx1.Refresh();
            this.treeListEx1.ExpandAll();
            //初始化表结构数据
            this.gridView1.SchemeColor = this.TempUseColor;
            this.bindingSource2.DataSource = APP.Application.Global.DataTamp.TempDataSet.Tables["Color_Temp"];
            this.gridControl1.DataSource = this.bindingSource2;

            //初始化特殊数据
            //this.bindingSource3.DataSource = this.TempUseColor.SpecialStyle.Source.Values;
            //this.gridControl2.DataSource = this.bindingSource3;

        }

        /*
         * Grid配置方式
         */
        private void col_bg_EditValueChanged(object sender, EventArgs e)
        {
            this.SetGridStyle();
        }

        /// <summary>
        /// 全局的树结构
        /// </summary>
        private void SetTreeStyle()
        {
            //焦点行
            this.treeListEx1.Appearance.FocusedRow.BackColor = this.T_Color_Bg_F_1.Color;
            this.treeListEx1.Appearance.FocusedRow.BackColor2 = this.T_Color_Bg_F_2.Color;

            //选择行
            this.treeListEx1.Appearance.HideSelectionRow.BackColor = this.T_Color_Bg_F_1.Color;
            this.treeListEx1.Appearance.HideSelectionRow.BackColor2 = this.T_Color_Bg_F_2.Color;

            //奇数行
            this.treeListEx1.Appearance.EvenRow.BackColor = this.T_Color_Bg_Even_1.Color;
            this.treeListEx1.Appearance.EvenRow.BackColor2 = this.T_Color_Bg_Even_2.Color;
            //偶数行
            this.treeListEx1.Appearance.OddRow.BackColor = this.T_Color_Bg_Odd_1.Color;
            this.treeListEx1.Appearance.OddRow.BackColor2 = this.T_Color_Bg_Odd_2.Color;

            //单元格
            this.treeListEx1.Appearance.FocusedCell.BackColor = this.T_Color_Bg_Col_1.Color;
            this.treeListEx1.Appearance.FocusedCell.BackColor2 = this.T_Color_Bg_Col_2.Color;


            
        }

        /// <summary>
        /// 树的局部设置
        /// </summary>
        private void SetTreeFont()
        {
            FontStyle fs = FontStyle.Regular;
            if (this.T_Font_B.Checked)
                fs |= FontStyle.Bold;
            if (this.T_Font_I.Checked)
                fs |= FontStyle.Italic;
            if (this.T_Font_U.Checked)
                fs |= FontStyle.Underline;

            Font f = new Font(this.T_FontEdit.Text, (float)(this.T_Font_Span.Value), fs);

            this.treeListEx1.Appearance.Row.Font = f;
            this.treeListEx1.Appearance.Row.ForeColor = this.T_Font_Color.Color;
        }

        /// <summary>
        /// 设置Grid
        /// </summary>
        private void SetGridStyle()
        {
            /**/
            /*this.gridView1.Appearance.Row.BackColor = this.col_bg_1.Color;
            this.gridView1.Appearance.Row.BackColor2 = this.col_bg_2.Color;*/
            //奇数行
            this.gridView1.Appearance.EvenRow.BackColor = this.G_Color_Bg_Even_1.Color;
            this.gridView1.Appearance.EvenRow.BackColor2 = this.G_Color_Bg_Even_2.Color;
            //偶数行
            this.gridView1.Appearance.OddRow.BackColor = this.G_Color_Bg_Odd_1.Color;
            this.gridView1.Appearance.OddRow.BackColor2 = this.G_Color_Bg_Odd_2.Color;
            //焦点行
            this.gridView1.Appearance.FocusedRow.BackColor = this.G_Color_Bg_F_1.Color;
            this.gridView1.Appearance.FocusedRow.BackColor2 = this.G_Color_Bg_F_2.Color;
            //选择行
            this.gridView1.Appearance.HideSelectionRow.BackColor = this.G_Color_Bg_F_1.Color;
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = this.G_Color_Bg_F_2.Color;
            //单元格
            this.gridView1.Appearance.FocusedCell.BackColor = this.G_Color_Bg_Col_1.Color;
            this.gridView1.Appearance.FocusedCell.BackColor2 = this.G_Color_Bg_Col_2.Color;

        }

        /// <summary>
        /// 设置Grid字体
        /// </summary>
        private void SetGridFont()
        {
            //this.gridControl1.Font = new Font(this.fontEdit1.Text, (float)(this.spinEdit2.Value));
            FontStyle fs = FontStyle.Regular;
            if (this.G_Font_B.Checked)
                fs |= FontStyle.Bold;
            if (this.G_Font_I.Checked)
                fs |= FontStyle.Italic;
            if (this.G_Font_U.Checked)
                fs |= FontStyle.Underline;

            Font f = new Font(this.fontEdit2.Text, (float)(this.spinEdit2.Value), fs);


            this.gridView1.Appearance.Row.Font = f;
            this.gridView1.Appearance.Row.ForeColor = colorEdit4.Color;
        }


        private void Btn_SuBmit_Click(object sender, EventArgs e)
        {
            this.Submit();
        }


        private void bindingSource3_PositionChanged(object sender, EventArgs e)
        {
            //return;
            if (this.bindingSource3.Current != null)
            {
                _SpecialStyleInfo info = this.bindingSource3.Current as _SpecialStyleInfo;
                FontStyle c = info.Font;
                this.S_Font_B.Checked = ((c & FontStyle.Bold) != 0);
                this.S_Font_I.Checked = ((c & FontStyle.Italic) != 0);
                this.S_Font_U.Checked = ((c & FontStyle.Underline) != 0);

                this.S_SL.Appearance.BackColor = info.BColor;
                this.S_SL.Appearance.BackColor2 = info.BColor2;
                this.S_SL.ForeColor = info.ForeColor;


                Font f = new Font(this.S_SL.Font.FontFamily, this.S_SL.Font.Size, c);

                this.S_SL.Font = f;
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (this.bindingSource3.Current != null)
            {
                FontStyle fs = FontStyle.Regular;
                if (this.S_Font_B.Checked)
                    fs |= FontStyle.Bold;
                if (this.S_Font_I.Checked)
                    fs |= FontStyle.Italic;
                if (this.S_Font_U.Checked)
                    fs |= FontStyle.Underline;
                _SpecialStyleInfo info = this.bindingSource3.Current as _SpecialStyleInfo;
                info.Font = fs;

                Font f = new Font(this.S_SL.Font.FontFamily, this.S_SL.Font.Size, fs);

                this.S_SL.Font = f;
            }
        }

        /// <summary>
        /// 背景色1事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemColorEdit1_ColorChanged(object sender, EventArgs e)
        {
            ColorEdit c = sender as ColorEdit;
            this.S_SL.Appearance.BackColor = c.Color;
            _SpecialStyleInfo info = this.bindingSource3.Current as _SpecialStyleInfo;

            info.BColor = c.Color;


        }

        /// <summary>
        /// 背景色1事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemColorEdit2_ColorChanged(object sender, EventArgs e)
        {
            ColorEdit c = sender as ColorEdit;
            this.S_SL.Appearance.BackColor2 = c.Color;
            _SpecialStyleInfo info = this.bindingSource3.Current as _SpecialStyleInfo;

            info.BColor2 = c.Color;



        }

        /// <summary>
        /// 背景色1事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemColorEdit3_ColorChanged(object sender, EventArgs e)
        {
            ColorEdit c = sender as ColorEdit;
            this.S_SL.ForeColor = c.Color;
            _SpecialStyleInfo info = this.bindingSource3.Current as _SpecialStyleInfo;
            info.ForeColor = c.Color;


        }


        #region ------------------------最终操作---------------------

        /// <summary>
        /// 此方法用于设计默认时候使用的(仅用于设计默认值时候使用)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (this.TempUseColor.GridStyle == null) return;
            //提交表格的
            this.TempUseColor.GridStyle.Set(this.gridView1.Appearance);
            this.TempUseColor.TreeStyle.Set(this.treeListEx1.Appearance);
            //提交给用户定义的
            //APP.DataObjects.GColor.UseColor.Default = this.TempUseColor;
            this.m_UseColor.Custom = this.TempUseColor;
            APP.DataObjects.GColor.OnGlobalStyleChange();
            APP.DataObjects.Save();
        }

        /// <summary>
        /// 最终接收提交(紧紧保存客户定义的提交)
        /// </summary>
        private void Submit()
        {
            //提交表格的
            //if (radioGroup2.SelectedIndex == 2)
            {

                this.TempUseColor.GridStyle.Set(this.gridView1.Appearance);
                this.TempUseColor.TreeStyle.Set(this.treeListEx1.Appearance);
                //提交给用户定义的
                this.m_UseColor.Custom = this.TempUseColor;
                this.DialogResult = DialogResult.OK;
            }
           /* else
            {
                this.DialogResult = DialogResult.OK;
            }*/
        }
        #endregion

        /// <summary>
        /// 还原为默认值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void Btn_Rest_Click(object sender, EventArgs e)
        {
            this.gridView1.Appearance.Reset();
            this.treeListEx1.Appearance.Reset();
            APP.DataObjects.GColor.UseColor.SetDefault();
            //this.TempUseColor = APP.DataObjects.GColor.UseColor.Current();
            
            //init();
            //initData();
        }*/

        private void T_Color_EditValueChanged(object sender, EventArgs e)
        {
            this.SetTreeStyle();
        }

        /// <summary>
        /// 树结构的字体设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Font_EditValueChanged(object sender, EventArgs e)
        {
            this.SetTreeFont();
        }

        /// <summary>
        /// 树结构的字体设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void T_Font_CheckedChanged(object sender, EventArgs e)
        {
            this.SetTreeFont();
        }

        private void G_Color_EditValueChanged(object sender, EventArgs e)
        {
            this.SetGridStyle();
        }

        /// <summary>
        /// 树结构的字体设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_Font_EditValueChanged(object sender, EventArgs e)
        {
            this.SetGridFont();
        }

        /// <summary>
        /// 树结构的字体设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_Font_CheckedChanged(object sender, EventArgs e)
        {
            this.SetGridFont();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择改变的时候根据选择不同加载不同的数据
            string typeName = string.Empty;
            switch (this.radioGroup1.SelectedIndex)
            {
                case 0:
                    typeName = _SpecialStyle.TYPE_SUBSEGMENT;
                    break;
                case 1:
                    typeName = _SpecialStyle.TYPE_GLJ;
                    break;
                case 2:
                    typeName = _SpecialStyle.TYPE_OTHER;
                    break;
                case 3://措施项目
                    typeName = _SpecialStyle.TYPE_CSXM;
                    break;
                case 4:
                    typeName = _SpecialStyle.TYPE_OTHERPROJ;
                    break;
                case 5:
                    typeName = _SpecialStyle.TYPE_HUIZONGFENXI;
                    break;
                default:
                    typeName = string.Empty;
                    this.bindingSource3.DataSource = null;
                    this.gridControl2.DataSource = this.bindingSource3;
                    break;
            }

            if (typeName != string.Empty)
            {
                IEnumerable<_SpecialStyleInfo> infos = from i in this.TempUseColor.SpecialStyle.Source.Values.Cast<_SpecialStyleInfo>()
                                                       where i.Type == typeName orderby i.Sort
                                                       select i;
                this.bindingSource3.DataSource = infos.ToArray();
                this.gridControl2.DataSource = this.bindingSource3;
            }
        }
        /// <summary>
        /// 创建新样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            //string path = APP.Application.Global.AppFolder.FullName;
            //string str = string.Format("{0}config\\options.cfg", path);
            _SchemeColor sc = new _SchemeColor();
            APP.DataObjects.GColor = new GlobalStyle();
            APP.DataObjects.GColor.Init(this.AppForm.SkinString);
            APP.DataObjects.GColor.Init(new string[] { "全局皮肤" });
            //保存一个新的配置
            //APP.DataObjects.GColor.ColumnLayout = new _ColumnLayout();
            //APP.DataObjects.GColor.ColumnLayout.Get()
            APP.DataObjects.Save(@"d:\options_New.cfg");


        }

        /// <summary>
        /// 配色方案选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.radioGroup2.SelectedIndex)
            {
                case 0://系统方案
                    this.m_UseColor.UserColor = EUserColor.System;
                    this.IsEdit(false);
                    break;
                case 1://默认方案
                    this.m_UseColor.UserColor = EUserColor.Default;
                    this.IsEdit(true);
                    break;
                case 2://客户定义方案
                    this.m_UseColor.UserColor = EUserColor.Custom;
                    this.IsEdit(true);
                    break;
            }

            //根据方案刷新当前窗体
            RestUseColor();
            initData();
            radioGroup1_SelectedIndexChanged(this.radioGroup1, null);
        }*/


        private void IsEdit(bool p_flag)
        {
            this.SetEnable(this.groupControl3, p_flag);
            this.SetEnable(this.groupControl1, p_flag);
            this.S_Font_B.Enabled = this.S_Font_I.Enabled = this.S_Font_U.Enabled = p_flag;
            this.gridView3.OptionsBehavior.Editable = p_flag;
            
        }

        private void SetEnable(Control p_Control,bool p_flag)
        {
            foreach (Control ctl in p_Control.Controls)
            {
                ctl.Enabled = p_flag;
            }
        }
    }
        
}