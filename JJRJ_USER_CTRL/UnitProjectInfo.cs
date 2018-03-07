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
    public partial class UnitProjectInfo : BaseControl
    {
        /// <summary>
        /// 应用于展示的临时数据源对象
        /// </summary>
        private DataTable m_Table = null;

        /// <summary>
        ///  要操作的单位工程数据源
        /// </summary>
        private _UnitProject m_DataSource = null;

        /// <summary>
        /// 获取或设置的单位工程数据源
        /// </summary>
        public _UnitProject DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void doLoadData()
        {
            if (this.m_DataSource != null)
            {

                this.Add("工程名称", this.m_DataSource.Property.Basis.Name);
                this.Add("工程编号", this.m_DataSource.Property.BaseData.PrjNo);
                this.Add("编制人资格证号", this.m_DataSource.Property.BaseData.PlaitNo);
                this.Add("编制人", this.m_DataSource.Property.BaseData.PlaitName);
                this.Add("复核人", this.m_DataSource.Property.BaseData.ReviewName);
                this.Add("编制人", this.m_DataSource.Property.BaseData.PlaitName);
                this.Add("编制日期", this.m_DataSource.Property.BaseData.PlaitDate.ToString("yyyy年mm月dd日"));
                this.Add("复核日期", this.m_DataSource.Property.BaseData.PlaitDate.ToString("yyyy年mm月dd日"));
                this.Add("清单规则", this.m_DataSource.Property.Libraries.ListGallery.Rule);
                this.Add("清单名称", this.m_DataSource.Property.Libraries.ListGallery.LibName);
                this.Add("定额规则", this.m_DataSource.Property.Libraries.FixedLibrary.Rule);
                this.Add("定额名称", this.m_DataSource.Property.Libraries.FixedLibrary.LibName);
                this.Add("图集库", this.m_DataSource.Property.Libraries.AtlasGallery.LibName);
                this.Add("专业类别", this.m_DataSource.Property.BaseData.PrfType);

                this.treeList1.DataSource = this.m_Table;
            }

        }

        /// 构造并初始化基础属性表
        /// </summary>
        /// <returns></returns>
        private DataTable Buider()
        {
            //
            DataTable table = new DataTable("临时表");
            //此结构为基础表的结构
            DataColumn dc = table.Columns.Add("ID", typeof(int));//唯一表示
            table.Columns.Add("Name", typeof(string));//属性名称
            table.Columns.Add("Value", typeof(string));//属性值
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 0;
            dc.AutoIncrementStep = 1;
            this.m_Table = table;
            return table;

        }

        /// <summary>
        /// 添加一个属性对
        /// </summary>
        /// <param name="p_Name"></param>
        /// <param name="p_Value"></param>
        private void Add(string p_Name, string p_Value)
        {
            DataRow row = this.m_Table.NewRow();
            row.BeginEdit();
            row["Name"] = p_Name;
            row["Value"] = p_Value;
            row.EndEdit();
            this.m_Table.Rows.Add(row);
            this.m_Table.AcceptChanges();
        }

        public UnitProjectInfo()
        {
            InitializeComponent();
        }

        private void UnitProjectInfo_Load(object sender, EventArgs e)
        {
            
        }

        public void DataBind()
        {
            initForm();
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void initForm()
        {
            this.Buider();
            this.doLoadData();
        }
    }
}
