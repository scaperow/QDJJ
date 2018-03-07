using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZiboSoft.Commons.Common;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class popControl : DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    {
        public delegate void CurrentChangedHanld(popControl Sender, DataRowView CurrRowView);
        public event CurrentChangedHanld onCurrentChanged;
        public popControl()
        {
            InitializeComponent();
            PopupContainerControl m_popupContainerControl = new PopupContainerControl();
            m_popupContainerControl.Controls.Add(this.gridControlEx1);
            this.PopupControl = m_popupContainerControl;
        }

        #region 属性、字段
        /// <summary>
        /// 处理后的数据存放
        /// </summary>
        private DataTable dataSource = null;
        private object objDataSource = null;
        /// <summary>
        /// 数据源
        /// </summary>
        public object DataSource
        {
            set
            {
                this._RemoveDefaultColName = null;
                this._ColName = null;
                objDataSource = value;
            }
        }
        private string[] _ColName;
        /// <summary>
        /// 绑定字段名  格式eg：【{编号|ID|ID , 姓名|XM|Name,类别|JGGJMC|LB}】【显示列名 | 绑定列名 | 选中当前行后当前列返回给哪一列】
        /// </summary>
        public string[] ColName
        {
            get { return _ColName; }
            set { _ColName = value; }
        }
        private string[] _RemoveDefaultColName;
        /// <summary>
        /// 重新选择后 需要清空的关联列 【注意：当数据源发生改变后当前属性需要重新  赋值。也就是最好放在数据源后面赋值】
        /// </summary>
        public string[] RemoveDefaultColName
        {
            get { return _RemoveDefaultColName; }
            set { _RemoveDefaultColName = value; }
        }
        #endregion

        #region 处理 绑定数据源
        public void bind()
        {
            
            this.dataSource = null;
            if ((objDataSource as BindingSource) != null && ((objDataSource as BindingSource).DataSource as DataTable) != null)
            {
                this.dataSource = ((objDataSource as BindingSource).DataSource as DataTable).DefaultView.ToTable();
            }
            else if ((objDataSource as DataTable) != null)
            {
                this.dataSource = (objDataSource as DataTable).DefaultView.ToTable();
            }
            if (this.dataSource != null)
            {
                if (!this.dataSource.Columns.Contains("IndexId"))
                {
                    this.dataSource.Columns.Add("IndexId");
                }
                this.dataSource.Columns["IndexId"].DefaultValue = "IndexId";
                this.dataSource.Rows.InsertAt(dataSource.NewRow(), 0);
            }
        }
        #endregion

        #region 选择改变
        private void gridView1_Click(object sender, EventArgs e)
        {
            if (this.bindingSourceEx1 == null) { return; }
            if (this.bindingSourceEx1.Current == null) { return; }
            if (this.onCurrentChanged != null)
            {
                this.onCurrentChanged(this, this.bindingSourceEx1.Current as DataRowView);
            }
            this.bindingSourceEx1.DataSource = null;
        }
        #endregion

        #region 显示下拉同时加载数据源等操作
        private void popControl_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.dataSource == null)
            {
                e.Cancel = true;
                return;
            }
            StringBuilder strWhere = new StringBuilder(" 1=1 ");
            #region 绑定到控件
            this.gridView1.Columns.Clear();
            if (null != this.ColName)
            {
                int VisibleIndex = 0;
                foreach (string item in this.ColName)
                {
                    string[] Field = item.Split('|');
                    if (Field.Length == 3)
                    {
                        if (!this.dataSource.Columns.Contains(Field[1].Trim()))
                        {
                            e.Cancel = true;
                            return;
                        }
                        DevExpress.XtraGrid.Columns.GridColumn Column = new DevExpress.XtraGrid.Columns.GridColumn();
                        Column.Caption = Field[0].Trim();
                        Column.FieldName = Field[1].Trim();
                        Column.OptionsColumn.AllowEdit = false;
                        Column.VisibleIndex = VisibleIndex++;
                        Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        Column.Visible = true;
                        this.gridView1.Columns.Add(Column);

                        strWhere.Append(" and " + Field[1].Trim() + " is not null");
                    }
                }
            }
            else
            {
                this.bindingSourceEx1.Filter = "";
                e.Cancel = true;
                return;
            }
            this.gridControlEx1.Refresh();
            #endregion
            this.bindingSourceEx1.DataSource = this.dataSource;
            this.bindingSourceEx1.Filter = strWhere.ToString();
            if (this.bindingSourceEx1.Count < 1)
            {
                e.Cancel = true;
            }
            this.bindingSourceEx1.Filter = "";
        }
        #endregion
    }
}