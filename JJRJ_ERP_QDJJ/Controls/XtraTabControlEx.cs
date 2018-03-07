/*
    清单计价的主要工作选项卡控件(继承XtraTabControl)
 *  选项卡中的内容为单位工程操作，单位工程嵌套项目使用依赖于项目操作容器
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTab;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.Collections;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.UI
{
    public class XtraTabControlEx : XtraTabControl
    {
        /// <summary>
        /// 是否存在此单位工程
        /// </summary>
        /// <param name="p_UnitProject"></param>
        /// <returns></returns>
        public bool IsExist(_UnitProject p_UnitProject)
        {
            XtraTabPageEx xtp = null;
            xtp = this.Find(p_UnitProject);
            if (xtp == null) return false;
            return true;
        }

        /// <summary>
        /// 锁定单位工程
        /// </summary>
        /// <param name="p_UnitProject"></param>
        public void LockUnit(_UnitProject p_UnitProject)
        {
            XtraTabPageEx xtp = this.Find(p_UnitProject);
            if (xtp != null)
            {
                xtp.GetProjectForm.LockUnit();
            }
        }

        /// <summary>
        /// 接触锁定单位工程
        /// </summary>
        /// <param name="p_UnitProject"></param>
        public void UnLockUnit(_UnitProject p_UnitProject)
        {
            XtraTabPageEx xtp = this.Find(p_UnitProject);
            if (xtp != null)
            {
                xtp.GetProjectForm.UnLockUnit();
            }
        }

        /// <summary>
        /// 创建一个新的单位工程选项卡(空工程)
        /// </summary>
        /// <param name="p_UnitProject">单位工程</param>
        public void CreateNewUnitProject(CWellComeProject p_Parent,_UnitProject p_UnitProject)
        {   
            //如果选项卡已经存在设置为当前操作选中
            XtraTabPageEx xtp = null;

            xtp = this.Find(p_UnitProject);

            if (xtp == null)
            {
                xtp = XtraTabPageEx.CreateInstance(p_Parent, p_UnitProject);
                xtp.UnitProject = p_UnitProject;
              
                //若已经存在当前选项卡则被调用
                this.TabPages.Add(xtp);
            }
            this.SelectedTabPage = xtp;
        }


        /// <summary>
        /// 替换当前选项卡
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <param name="p_UnitProject"></param>
        public void Replace(CWellComeProject p_Parent, _UnitProject p_UnitProject,int OldId)
        {
            //1.如果选项卡是当前打开的选项卡 重新添加页面数据
            //2.如果当前选项卡存在列表中 重新添加数据

            XtraTabPageEx xtp = this.Find(p_UnitProject, OldId);
            if (xtp == null) return;

            //APP.Methods.Init(p_UnitProject);
            //xtp.XtraTabType = "单位工程";
            //xtp.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            GLODSOFT.QDJJ.BUSINESS._Project_Statistics statistics = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(p_UnitProject, p_Parent.CurrentBusiness);
            statistics.Calculate();
            //创建新的应用窗体
            xtp.GetProjectForm = new ProjectForm();
            xtp.UnitProject = p_UnitProject;
            //同步当前业务对象
            xtp.GetProjectForm.CurrentBusiness = p_Parent.CurrentBusiness;
            p_UnitProject.NeedCalculate = true;
            //活动的单位工程
            xtp.GetProjectForm.Activitie = p_UnitProject;

            //设置父类容器
            xtp.GetProjectForm.Parent_Projects = p_Parent;
            xtp.GetProjectForm.FormBorderStyle = FormBorderStyle.None;
            xtp.GetProjectForm.Dock = DockStyle.Fill;//设置样式是否填充整个PANEL 
            //设置为非顶级控件
            xtp.GetProjectForm.TopLevel = false;
            //显示窗体
            xtp.GetProjectForm.Visible = true;
            xtp.Text = p_UnitProject.Name;
            xtp.GetProjectForm.dp_Function.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            //当前存在的重新加载数据            
            //删除原来的Project对象
            xtp.Controls.Remove(xtp.Controls[0]);
            //添加新的Project对象
            xtp.Controls.Add(xtp.GetProjectForm);
        }
        
        /// <summary>
        /// 创建项目欢迎界面
        /// </summary>
        /// <param name="p_Project"></param>
        public void CreateProjectWellCome(_Projects p_Project)
        {
            XtraTabPageEx xtp = null;
            xtp = XtraTabPageEx.CreateWellCome(p_Project);
            xtp.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.TabPages.Add(xtp);
        }

        /// <summary>
        /// (重写)获取或设置当前选择的项
        /// </summary>
        public new XtraTabPageEx SelectedTabPage
        {
            get
            {
                return base.SelectedTabPage as XtraTabPageEx;
            }
            set
            {
                base.SelectedTabPage = value;
            }
        }



        /// <summary>
        /// 如果当前单位工程已经存在返回存在的选项卡(如果当前为项目操作通过字典操作如果为单位工程操作则按照项目名称查找)
        /// </summary>
        /// <param name="p_UnitProject"></param>
        /// <returns></returns>
        public XtraTabPageEx Find(_UnitProject p_UnitProject)
        {
            
            foreach (XtraTabPageEx xtp in this.TabPages)
            {
                
                    _UnitProject cp = xtp.UnitProject;
                    if (cp != null)
                    {
                        //变更此处判断不在使用项目名称 改为使用当前对象的key
                        if (cp.ID == p_UnitProject.ID)
                        {
                            return xtp;
                        }                        
                    }   
            }
            return null;
        }

        /// <summary>
        /// 如果当前单位工程已经存在返回存在的选项卡(如果当前为项目操作通过字典操作如果为单位工程操作则按照项目名称查找)
        /// </summary>
        /// <param name="p_UnitProject"></param>
        /// <returns></returns>
        public XtraTabPageEx Find(object p_ID)
        {

            foreach (XtraTabPageEx xtp in this.TabPages)
            {

                _UnitProject cp = xtp.UnitProject;
                if (cp != null)
                {
                    //变更此处判断不在使用项目名称 改为使用当前对象的key
                    if (cp.ID.Equals(p_ID))
                    {
                        return xtp;
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// 如果当前单位工程已经存在返回存在的选项卡(如果当前为项目操作通过字典操作如果为单位工程操作则按照项目名称查找)
        /// </summary>
        /// <param name="p_UnitProject"></param>
        /// <returns></returns>
        public XtraTabPageEx Find(_UnitProject p_UnitProject,int OldID)
        {

            foreach (XtraTabPageEx xtp in this.TabPages)
            {

                _UnitProject cp = xtp.UnitProject;
                if (cp != null)
                {
                    //变更此处判断不在使用项目名称 改为使用当前对象的key
                    if (cp.ID == OldID)
                    {
                        return xtp;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 删除指定单项工程选项卡(如果存在)
        /// </summary>
        /// <param name="infos"></param>
        public void Remove(_Engineering infos)
        {
            foreach (_UnitProject obj in infos.StrustObject.ObjectList.Values)
            {
                XtraTabPageEx xtp = this.Find((obj as _UnitProject));
                if (xtp != null)
                {
                    this.TabPages.Remove(xtp);
                }
            }
        }

        /// <summary>
        /// 删除指定单项工程选项卡(如果存在)
        /// </summary>
        /// <param name="infos"></param>
        public void Remove(_UnitProject info)
        {
                XtraTabPageEx xtp = this.Find(info);
                if (xtp != null)
                {
                    this.TabPages.Remove(xtp);
                }
            
        }

        /// <summary>
        /// 删除指定单项工程选项卡(如果存在)
        /// </summary>
        /// <param name="infos"></param>
        public void Remove(object p_ID)
        {
            XtraTabPageEx xtp = this.Find(p_ID);
            if (xtp != null)
            {
                this.TabPages.Remove(xtp);
            }

        }
        

        /// <summary>
        /// 判断两个选项卡正在操作的内容是否相同
        /// </summary>
        /// <param name="curr_Page">当前选项卡</param>
        /// <param name="pav_Page">前一个选项卡</param>
        /// <returns></returns>
        private bool IsSame(XtraTabPageEx curr_Page, XtraTabPageEx pav_Page)
        {

            if (pav_Page == null) return false;

            ProjectForm from1 = curr_Page.Controls[0] as ProjectForm;
            ProjectForm from2 = pav_Page.Controls[0] as ProjectForm;
            if (from1 == null || from2 == null) return false;
            if (from1.GetWorkAreas == null || from2.GetWorkAreas == null) return false;
            if (from1.GetWorkAreas.GetType().Name == from2.GetWorkAreas.GetType().Name)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 重写选项卡切换时候的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnSelectedPageChanged(object sender, DevExpress.XtraTab.ViewInfo.ViewInfoTabPageChangedEventArgs e)
        {
            base.OnSelectedPageChanged(sender, e);
            
            if (e.Page != null)
            {
                XtraTabPageEx xtp = e.Page as XtraTabPageEx;
                XtraTabPageEx xtp1 = e.PrevPage as XtraTabPageEx;
                //选项卡切换的时候设置活动容器
                //ActiveWindow.ActiveContainer = xtp.GetProjectForm;
                //设置当前活动的单位工程
                //APP.General.Activitie = xtp.UnitProject;
                
                /*if (xtp.XtraTabType == "项目指引")
                {
                    xtp.CTagObjects.SetLayout();
                }
                else
                {
                    if (!this.IsSame(xtp, xtp1))
                    {
                        xtp.CTagObjects.SetLayout();
                    }

                    //如论是否相同此方便必须加载以获取控件内数据
                    
                }*/
                //xtp.CTagObjects.ReLoad();

            }
        }

        /// <summary>
        /// 选择项
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelecting(TabPageCancelEventArgs e)
        {
            base.OnSelecting(e);
           

            /*if (this.SelectedTabPage != null)
            {
                if (this.SelectedTabPage.XtraTabType == "项目指引")
                {

                }
                else
                {
                    if (this.SelectedTabPage.GetProjectForm.GetWorkArea != null)
                    {
                        string str = this.SelectedTabPage.GetProjectForm.GetWorkArea.Text;
                        this.SelectedTabPage.CTagObjects.SaveLayout(str);
                    }
                }
            }*/
        }

        /// <summary>
        /// 关闭所有的选项卡
        /// </summary>
        public void Close()
        {
            this.TabPages.Clear();
        }
    }
}
