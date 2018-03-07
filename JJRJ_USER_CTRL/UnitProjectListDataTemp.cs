using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class UnitProjectListDataTemp : BaseControl
    {
        /// <summary>
        /// 依赖的单项工程
        /// </summary>
        public _Engineering CurrEngineering = null;
        /// <summary>
        /// 自定义名称开启关闭
        /// </summary>
        public bool IsDefineName = false;

        public object m_DataSource = null;
        /// <summary>
        /// 当前选择的工程名称
        /// </summary>
        private string m_projectName = string.Empty;
        /// <summary>
        /// 设置当前操作的单项工程名称
        /// </summary>
        public string CurrentName
        {
            set
            {                
                m_projectName = value;
                this.groupControl2.Text = string.Format("工程名称：{0}", m_projectName);
            }
            get
            {
                return m_projectName;
            }
        }


        /// <summary>
        /// 获取或设置当前控件的数据源
        /// </summary>
        public object DataSource
        {
            set
            {
                this.m_DataSource = value;
            }
            get
            {
                return this.m_DataSource;
            }
        }

        /// <summary>
        /// 获取当先选择行对象
        /// </summary>
        /// <returns></returns>
        public DataRowView[] Selections()
        {
            //获取选中的个数
            int[] count = this.gridView1.GetSelectedRows();
            DataRowView[] rows = new DataRowView[count.Length]; 
            for (int i = 0; i< count.Length; i++)
            {
                rows[i] = this.gridView1.GetRow(count[i]) as DataRowView;
            }

            return rows;
        }


        public UnitProjectListDataTemp()
        {
            InitializeComponent();
        }

        private void UnitProjectListDataTemp_Load(object sender, EventArgs e)
        {
            //第一次加载时
            
        }

        public void DataBind()
        {
              if (this.m_DataSource != null)
              {

                  //如果不存在自定义名称列则添加
                  DataTable table = this.m_DataSource as DataTable;
                  if (table != null)
                  {
                      if (!table.Columns.Contains("defineName"))
                      {
                          table.Columns.Add("defineName", typeof(string));
                          //自定义列的数据与Name数据默认相同
                          foreach (DataRow row in table.Rows)
                          {
                              row.BeginEdit();
                              row["defineName"] = row["Name"];
                              row.EndEdit();
                          }
                      }
                  }

                  this.bindingSource1.DataSource = this.m_DataSource;
                  this.gridControl1.DataSource = this.bindingSource1;
                  
              }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

            this.gridColumn5.Visible =IsDefineName = this.checkEdit1.Checked;
            if (this.checkEdit1.Checked)
                this.gridColumn5.VisibleIndex = 0;
            else
                this.gridColumn5.VisibleIndex = -1;
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (this.CurrEngineering == null) return;

            //清单依据与定额依据
            switch (e.Column.FieldName)
            {
                case "ListBased":
                    e.DisplayText = string.Format("{0} {1}", this.CurrEngineering.Property.Basis.QDGZ,e.Value);
                    break;
                case "FixedBased":
                    e.DisplayText = string.Format("{0} {1}", this.CurrEngineering.Property.Basis.DEGZ, e.Value);
                    break;
            }
        }


    }
}
