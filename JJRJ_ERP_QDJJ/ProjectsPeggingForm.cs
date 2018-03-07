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
using DevExpress.XtraGrid;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProjectsPeggingForm : BaseForm
    {
        public ProjectsPeggingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 分部分项数据
        /// </summary>
        private ArrayList fbfx = new ArrayList();
        /// <summary>
        /// 措施项目数据
        /// </summary>
        private ArrayList csxm = new ArrayList();

        /// <summary>
        /// 当前选中项
        /// </summary>
        private _ObjectQuantityUnitInfo m_DataSource = null;

        /// <summary>
        /// 获取或设置:当前选中项
        /// </summary>
        public _ObjectQuantityUnitInfo DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }

        private void ProjectsPeggingForm_Load(object sender, EventArgs e)
        {
            _Projects m_Projects = this.CurrentBusiness.Current as _Projects;
            if (m_Projects != null)
            {

                foreach (_Engineering m_Engineering in m_Projects.StrustObject.ObjectList.Values)
                {
                    foreach (_UnitProject m_UnitProject in m_Engineering.StrustObject.ObjectList.Values)
                    {
                        this.FileFBFX(m_UnitProject);
                        this.FileCSXM(m_UnitProject);
                    }
                }
                this.bindingSourceFBFX.DataSource = this.fbfx;
                this.bindingSourceCSXM.DataSource = this.csxm;
                this.gridViewCSXM.ExpandAllGroups();
                this.gridViewFBFX.ExpandAllGroups();
            }
        }

        /// <summary>
        /// 填充措施项目数据
        /// </summary>
        private void FileCSXM(_UnitProject p_UnitProject)
        {
            IEnumerable<_ObjectQuantityUnitInfo> m_list = p_UnitProject.Property.MeasuresProject.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == m_DataSource.BH);
            foreach (_ObjectQuantityUnitInfo item in m_list)
            {
                _SubheadingsInfo m_SubheadingsInfo = null;
                if (item.GetType() == typeof(_SubheadingsQuantityUnitInfo))
                {
                    m_SubheadingsInfo = (item as _SubheadingsQuantityUnitInfo).Parent;
                }
                else
                {
                    m_SubheadingsInfo = (item as _QuantityUnitComponentInfo).Parent.Parent;
                }
                m_SubheadingsInfo.XHL = m_SubheadingsInfo.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Sum(p => p.XHL);
                this.GetCSXMInfo(m_SubheadingsInfo);
            }
            
        }

        /// <summary>
        /// 填充分部分项项目数据
        /// </summary>
        private void FileFBFX(_UnitProject p_UnitProject)
        {
            IEnumerable<_ObjectQuantityUnitInfo> m_list = p_UnitProject.Property.SubSegments.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == m_DataSource.BH);
            foreach (_ObjectQuantityUnitInfo item in m_list)
            {
                _SubheadingsInfo m_SubheadingsInfo = null;
                if (item.GetType() == typeof(_SubheadingsQuantityUnitInfo))
                {
                    m_SubheadingsInfo = (item as _SubheadingsQuantityUnitInfo).Parent;
                }
                else
                {
                    m_SubheadingsInfo = (item as _QuantityUnitComponentInfo).Parent.Parent;
                }
                m_SubheadingsInfo.XHL = m_SubheadingsInfo.GetAllQuantityUnit.Cast<_ObjectQuantityUnitInfo>().Sum(p => p.XHL);
                this.GetFBFXInfo(m_SubheadingsInfo);
            }
        }

        /// <summary>
        /// 验证分部分项子目并且合并数据
        /// </summary>
        /// <param name="p_ob"></param>
        private void GetFBFXInfo(object p_ob)
        {
            if (!this.fbfx.Contains(p_ob))
            {
                this.fbfx.Add(p_ob);
            }
        }

        /// <summary>
        /// 验证措施项目子目并且合并数据
        /// </summary>
        /// <param name="p_ob"></param>
        private void GetCSXMInfo(object p_ob)
        {
            if (!this.csxm.Contains(p_ob))
            {
                this.csxm.Add(p_ob);
            }
        }

        /// <summary>
        /// 双击跳转事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl_DoubleClick(object sender, EventArgs e)
        {
            GridControl m_GroupControl = sender as GridControl;
            _SubheadingsInfo m_SubheadingsInfo = null;
            if (m_GroupControl != null)
            {
                if (m_GroupControl.Name == "gridControlFBFX")
                {
                    //只有双击子目对象有效其它不处理
                    m_SubheadingsInfo = this.bindingSourceFBFX.Current as _SubheadingsInfo;
                    if (m_SubheadingsInfo != null)
                    {
                        //选中双击子目对应在分部分项上的子目
                        m_SubheadingsInfo.Activitie.Property.SubSegments.ChangeSource();
                        m_SubheadingsInfo.Activitie.Property.SubSegments.DataSource.Position = m_SubheadingsInfo.Activitie.Property.SubSegments.DataSource.IndexOf(m_SubheadingsInfo);
                        this.Position(m_SubheadingsInfo);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    m_SubheadingsInfo = this.bindingSourceCSXM.Current as _SubheadingsInfo;
                    if (m_SubheadingsInfo != null)
                    {
                        m_SubheadingsInfo.Activitie.Property.MeasuresProject.DataSource.Position = m_SubheadingsInfo.Activitie.Property.MeasuresProject.DataSource.IndexOf(m_SubheadingsInfo);
                        this.Position(m_SubheadingsInfo);
                        this.DialogResult = DialogResult.Yes;
                    }
                }
            }
        }

        /// <summary>
        /// 设置选中
        /// </summary>
        /// <param name="p_SubheadingsInfo"></param>
        private void Position(_SubheadingsInfo p_SubheadingsInfo)
        {
            //查看选中的子目中是否存在双击反查的工料机 如果存在则选中工料机 如果不存在或者存在于组成中不选中
            IEnumerable<_ObjectQuantityUnitInfo> list = p_SubheadingsInfo.SubheadingsQuantityUnitList.Cast<_ObjectQuantityUnitInfo>().Where(p => p.BH == this.m_DataSource.BH);
            if (list.Count() == 1)
            {
                //选中反查工料机
                p_SubheadingsInfo.SubheadingsQuantityUnitList_BindingSource.Position = p_SubheadingsInfo.SubheadingsQuantityUnitList_BindingSource.IndexOf(list.ToList()[0] as _SubheadingsQuantityUnitInfo);
            }
        }


    }
}