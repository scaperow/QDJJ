/*
 * 计算参数统计结果
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
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CParameterStatisticsFrom : ABaseForm
    {
        /// <summary>
        /// 单位工程
        /// </summary>
        private _UnitProject m_CUnitProject;

        /// <summary>
        /// 获取或设置单位工程对象
        /// </summary>
        public _UnitProject UnitProject
        {
            get
            {
                return m_CUnitProject;
            }
            set
            {
                m_CUnitProject = value;
            }
        }

        public CParameterStatisticsFrom()
        {
            InitializeComponent();
        }

        private void CParameterStatisticsFrom_Load(object sender, EventArgs e)
        {
            //屏蔽项目列表的右键功能
            this.projectTrees1.isRight = false;
            projectTrees1.treeList1.DoubleClick += new EventHandler(treeList1_DoubleClick);
            projectTrees1.CurrBusiness = this.CurrentBusiness;
            projectTrees1.DataSource = this.CurrentBusiness.Current;
            projectTrees1.DataBind();

            this.variableList1.IsDisplayValue = true;
            
            //默认打开当前项目参数
            //this.variableList1.DataSource = this.CurrentBusiness.Current.Property.Statistics.ResultVarable;
            //this.variableList1.DataBind();
            this.variableList1.DataSource = this.CurrentBusiness.Current.StructSource.ModelProjVariable;
            //默认绑定全部项目的数据
            this.variableList1.DataBind(0,-3);
        }

        /// <summary>
        /// 双击的时候选择当前对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeList1_DoubleClick(object sender, EventArgs e)
        {
            DataRowView row = this.projectTrees1.bindingSource1.Current as DataRowView;
            if (row != null)
            {
                int id = ToolKit.ParseInt(row["ID"]);
                if (row["DEEP"].Equals(1))
                {
                    this.variableList1.DataBind(id, -2);
                }
                if (row["DEEP"].Equals(2))
                {
                    this.variableList1.DataBind(id, -1);
                }
                if (row["DEEP"].Equals(0))
                {
                    this.variableList1.DataBind(id, -3);
                }
            }
        }

        public override void OnInitForm()
        {
            base.OnInitForm();
            (this.BusContainer as CWellComeProject).AfterStatisticaled += new AfterStatisticaledHandler(CParameterStatisticsFrom_AfterStatisticaled);
        }

        void CParameterStatisticsFrom_AfterStatisticaled(object sender, object args)
        {
            //重新绑定
            treeList1_DoubleClick(this.projectTrees1, null);
        }

        

        public override void OnRemoveForm()
        {
            base.OnRemoveForm();
            (this.BusContainer as CWellComeProject).AfterStatisticaled -= new AfterStatisticaledHandler(CParameterStatisticsFrom_AfterStatisticaled);
        }
        
    }
}
