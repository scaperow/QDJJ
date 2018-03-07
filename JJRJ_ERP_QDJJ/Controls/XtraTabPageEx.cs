/*
 * 处理单位工程的选项卡控件(继承子XtraTabPage)
 * XtraTabPage 包含两种
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTab;
using GOLDSOFT.QDJJ.COMMONS;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 每个选项卡都是一个单位工程(除了项目默认除外)
    /// </summary>
    public class XtraTabPageEx:XtraTabPage
    {
        private string m_XtraTabType = "单位工程";

        /// <summary>
        /// 获取当前选项卡的类型
        /// </summary>
        public string XtraTabType
        {
            get
            {
                return this.m_XtraTabType;
            }
        }

        /// <summary>
        /// 获取一个(单位工程)选项卡对象
        /// </summary>
        /// <returns></returns>
        public static XtraTabPageEx CreateInstance(CWellComeProject p_Parent, _UnitProject p_UnitProject)
        {
            //如果不存在当前打开的工程文件对象则放入此工程
            /*if (_Common.Application.Global.Configuration.Bool_Temporary_UnitProject)
            {
                if (!_Common.Application.Cache.Cache_Bak_Object.Contains(p_UnitProject))
                {
                    _Common.Application.Cache.Cache_Bak_Object.Add(p_UnitProject);
                }
            }*/
            

            XtraTabPageEx xtp = new XtraTabPageEx();           
            xtp.m_XtraTabType = "单位工程";
            xtp.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            //创建新的应用窗体
            xtp.m_ProjectForm = new ProjectForm();
            //同步当前业务对象
            GLODSOFT.QDJJ.BUSINESS._Project_Statistics statistics = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(p_UnitProject, p_Parent.CurrentBusiness);
            statistics.Calculate();
            xtp.m_ProjectForm.CurrentBusiness = p_Parent.CurrentBusiness;
            p_UnitProject.NeedCalculate = true;
            //活动的单位工程
            xtp.m_ProjectForm.Activitie = p_UnitProject;
            //设置父类容器
            xtp.m_ProjectForm.Parent_Projects = p_Parent;
            xtp.m_ProjectForm.FormBorderStyle = FormBorderStyle.None;
            xtp.m_ProjectForm.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            xtp.GetProjectForm.MainForm = p_Parent.Parent as ApplicationForm;
            //设置为非顶级控件
            xtp.m_ProjectForm.TopLevel = false;
            //显示窗体
            xtp.m_ProjectForm.Visible = true;
            xtp.Text = p_UnitProject.Name;
          
            xtp.ImageIndex = 2;
           
            //当有新子列表被添加到工作区时激发
            xtp.m_ProjectForm.WorkPanel.ControlAdded += new ControlEventHandler(WorkPanel_ControlAdded);
            xtp.Controls.Add(xtp.m_ProjectForm);
            return xtp;
        }


        /// <summary>
        /// 创建项目欢迎页面
        /// </summary>
        /// <param name="p_Project">当前项目</param>
        /// <returns></returns>
        public static XtraTabPageEx CreateWellCome(_Projects p_Project)
        {
            XtraTabPageEx xtp = new XtraTabPageEx();
            xtp.m_XtraTabType = "项目指引";
            xtp.Text = p_Project.Property.Basis.Name;
            xtp.ImageIndex = 0;
            CWellComeProject form = new CWellComeProject();
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            //设置为非顶级控件
            form.TopLevel = false;
            //显示窗体
            form.Visible = true;
            xtp.Controls.Add(form);
            return xtp;
        }

        /// <summary>
        /// 当有新子列表被添加到工作区时激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void WorkPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        

        /// <summary>
        /// 每个选显卡都包含一个项目操作主窗体
        /// </summary>
        private ProjectForm m_ProjectForm = null;

        /// <summary>
        /// 获取或设置当前选项卡的项目主窗体
        /// </summary>
        public ProjectForm GetProjectForm
        {
            get
            {
                return this.m_ProjectForm;
            }
            set
            {
                this.m_ProjectForm = value;
            }
        }        

        /// <summary>
        /// 获取或设置用来处理选项卡的对象
        /// </summary>
        //private CTagObjects m_CTagObjects = null;

        /// <summary>
        /// 获取或设置用来处理选项卡的对象
        /// </summary>
        /*public CTagObjects CTagObjects
        {
            get
            {
                return this.m_CTagObjects;
            }
            set
            {
                this.m_CTagObjects = value;
            }
        }*/

        /// <summary>
        ///  当前选项卡的单位工程对象
        /// </summary>
        private _UnitProject m_CUnitProject = null;

        /// <summary>
        /// 获取或设置当前选项卡的单位工程
        /// </summary>
        public _UnitProject UnitProject
        {
            get
            {
                return this.m_CUnitProject;
            }
            set
            {
                this.m_CUnitProject = value;
            }
        }

        /// <summary>
        ///  当前选项卡的工程对象
        /// </summary>
        private _Projects m_CProjects = null;

        /// <summary>
        /// 获取或设置当前选项卡的工程
        /// </summary>
        public _Projects Projects
        {
            get
            {
                return this.m_CProjects;
            }
            set
            {
                this.m_CProjects = value;
            }
        }

    }
}
