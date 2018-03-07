using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using System.Data;

namespace GOLDSOFT.QDJJ.CTRL
{
    public class LibCombox : DevExpress.XtraEditors.ComboBoxEdit
    {
        public LibCombox()
        {
            this.DataSource = new BindingSource();
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        /// <summary>
        /// 当前数据的数据源
        /// </summary>
        public BindingSource DataSource;

        public string TypeName = "定额库";
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox fProperties;

        /// <summary>
        /// 显示的字段名称
        /// </summary>
        public string DisplayFieldName = "Name";

        /// <summary>
        /// 用于处理数据库绑定操作
        /// </summary>
        public void DataBind()
        {
            foreach (DataRowView row in this.DataSource.List)
            {
                CList list = new CList();
                list.DisplayName = row[DisplayFieldName].ToString();
                list.value = row;
                this.Properties.Items.Add(list);
            }

            if (this.DataSource.List.Count > 0)
            {
                //默认选择第一项
                this.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 获取选择类别
        /// </summary>
        /// <param name="p_TypeName">类别名称</param>
        public void DoFilter(string p_TypeName)
        {
            //清楚后重新添加
            this.Properties.Items.Clear();
            this.DataSource.Filter = string.Format("typeName = '{0}'", p_TypeName);
            this.DataBind();
        }

        /// <summary>
        /// 获取当前选中的对象
        /// </summary>
        public CList Current
        {
            get
            {
                 return this.SelectedItem as CList;
            }
        }

        private void InitializeComponent()
        {
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            this.ResumeLayout(false);

        }
    }

    /// <summary>
    /// 用于处理普通Combox的扩展类
    /// </summary>
    public class CList
    {
        /// <summary>
        /// 要显示的名称
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// 保存的装箱对象
        /// </summary>
        public object value;

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
