/*
 * 展示为属性的用户控件 任何需要显示其属性的对象均可使用(对象只需实现IAttributes接口)
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class CtrlAttributes : BaseControl
    {

        ///// <summary>
        ///// 绑定数据
        ///// </summary>
        ///// <param name="sender">事件源</param>
        ///// <param name="args"></param>
        //public delegate void BeginDataBindHandler();

        ///// <summary>
        ///// 获取焦点时候激发
        ///// </summary>
        //public event BeginDataBindHandler BeginDataBind;


        //public Action<IAttributes> delegateMethod = new Action<IAttributes>(DataBind);


        /// <summary>
        /// 数据源
        /// </summary>
        private IAttributes m_IDataSource = null;
        /// <summary>
        /// 获取或设置当前数据源数据接口
        /// </summary>
        public IAttributes IDataSource
        {
            get
            {
                return this.m_IDataSource;
            }
            set
            {
                this.m_IDataSource = value;
            }
        }
        /// <summary>
        /// 控件是否只读
        /// </summary>
        private bool m_IsEdit = false;
        /// <summary>
        /// 控件是否可编辑
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return this.m_IsEdit;
            }
            set
            {
                this.m_IsEdit = value;
            }
        }
        /// <summary>
        /// 属性
        /// </summary>
        private CAttributes m_Attributes = null;

        public CtrlAttributes()
        {
            InitializeComponent();
           
        }
        private void Attributes_Load(object sender, EventArgs e)
        {
            this.m_Attributes = new CAttributes();
            this.m_Attributes.RowChanged += new DataRowChangeEventHandler(m_Attributes_RowChanged);
        }
        /// <summary>
        /// 当行对象发生变化的时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_Attributes_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Change)
            {
                //回写接口处理函数
                this.IDataSource.ChangeValue(this.m_Attributes, e);
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void DataBind()
        {
            //调用接口函数创建属性集合
            this.m_IDataSource.ConvertToDisplay(this.m_Attributes);
            this.bindingSource1.DataSource = this.m_Attributes;
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.ExpandAll();
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        public void DataBind(IAttributes dAttributes)
        {
            //调用接口函数创建属性集合
            this.m_IDataSource = null;
            this.bindingSource1.DataSource = null;
            this.treeList1.DataSource = null;
            this.m_IDataSource = dAttributes;
            CAttributes mAttribute = new CAttributes();
            this.m_IDataSource.ConvertToDisplay(mAttribute);
            this.bindingSource1.DataSource = mAttribute;
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.ExpandAll();
        }
        /// <summary>
        /// 节点改变的时候事件处理
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //类型
            if (e.Node == null) return;
            bool b_IsType = Convert.ToBoolean(e.Node.GetValue("IsEdit"));
            //1.判断全局是否可编辑
            if (this.m_IsEdit)
            {
                if (b_IsType)
                {
                    //如果是分类 只读
                    this.treeList1.Columns[1].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    //不是分类可编辑
                    this.treeList1.Columns[1].OptionsColumn.AllowEdit = true;
                }
            }
            else
            {
                this.treeList1.Columns[1].OptionsColumn.AllowEdit = false;
            }
        }
    }
}
