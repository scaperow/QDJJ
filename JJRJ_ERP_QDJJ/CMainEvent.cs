/*
 此类型用于扩展MainRibbonForm的类型
 * 主要处理事件和过程
 * 创建人:华威
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTab;
using GLODSOFT.QDJJ.BUSINESS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ApplicationForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {


        #region  ---------------操作过程---------------



        /// <summary>
        /// 根据文件对象打开文件业务
        /// </summary>
        /// <param name="p_Info"></param>
        /*public bool OpenProject(FileInfo p_Info)
        {
            //如果文件存在
            if (p_Info.Exists)
            {
                CResult r = APP.Methods.Open(p_Info.FullName);
                //创建文件对象 
                if (r.Success)
                {
                    _Business bus = r.Value as _Business;
                    if (this.Validation(bus))
                    {
                        //开启新业务窗体
                        this.ActionFace.OpenNewBussinessForm(bus);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(this, r.ErrorInformation, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
           
        }*/

        /// <summary>
        ///  打开项目(打开方式)
        /// </summary>
        /*private void OpenProject()
        {
            System.Windows.Forms.DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                CResult r = APP.Methods.Open(this.openFileDialog1.FileName);
               //创建文件对象 
               if (r.Success)
               {
                   _Business bus = r.Value as _Business;
                   if (this.Validation(bus))
                   {
                       //开启新业务窗体
                       this.ActionFace.OpenNewBussinessForm(bus);
                   }
               }
               else
               {
                   MessageBox.Show(this, r.ErrorInformation, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }        
            }
        }*/

        /// <summary>
        /// 开启密码效验窗体
        /// </summary>
        /// <returns></returns>
        public bool Validation(_Business p_bus)
        {
            //如果为null或者为空验证通过
            if (p_bus.Current.PassWord != string.Empty)
            {
                CValidationPWD form = new CValidationPWD();
                form.CurrentBusiness = p_bus;
                form.Source = p_bus.Current;
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    //验证通过
                    return true;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存当前业务(仅保存当前业务对象)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            //当前活动的业务窗体
            Container form = this.ActiveMdiChild as Container;
            if (form != null)
            {
                form.Save();
            }
            /*switch (APP.WorkFlows.WorkFlowType)
            {
                case EWorkFlowType.PROJECT:
                case EWorkFlowType.Engineering:
                    //实现容器类型的数据保存
                    //循环当前选项卡(如果保存容器不存在当前已经打开的选项卡则加入到保存中)
                    if (_Common.Application.Global.Configuration.Bool_Temporary_UnitProject)
                    {
                        foreach (object obj in this.xtraTabControl1.TabPages)
                        {
                            XtraTabPageEx xtp = obj as XtraTabPageEx;
                            if (xtp != null)
                            {
                                if (xtp.UnitProject != null)
                                {
                                    if (!_Common.Application.Cache.Cache_Bak_Object.Contains(xtp.UnitProject))
                                    {
                                        _Common.Application.Cache.Cache_Bak_Object.Add(xtp.UnitProject);
                                    }
                                }
                            }
                        }
                    }

                    APP.General.Current.Save();
                    break;
                default://默认为单位工程单独保存
                    APP.General.Activitie.Save();
                    break;
            }*/
        }

        
        /// <summary>
        ///导出单位工程操作 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBI_ImportOut_ItemClick(object sender, ItemClickEventArgs e)
        {           
             /*if (APP.General.Activitie != null)
             {
                 CImportOut form = new CImportOut();
                 form.DataSource = APP.General.Activitie;
                 form.ShowDialog();
             }*/
        }

        /// <summary>
        /// 导入单位工程操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBI_ImportIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*CImportIn form = new CImportIn();
            form.Source = APP.General.Current;
            form.ShowDialog();*/
        }


        #endregion

        #region ---------------控件事件调用------------------
/*
        /// <summary>
        /// 导出事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_Import_OUT_ItemClick(object sender, ItemClickEventArgs e)
        {
            //找到选中的单位工程或者单项工程对象
            _COBJECTS obj = this.projectTrees1.SelectItem;
            CImportOut form = new CImportOut();
            form.DataSource = obj;
            form.ShowDialog();

        }

        /// <summary>
        /// 导入事件处理
        /// </summary>
        /// <param name="sender">激发事件源</param>
        /// <param name="e"></param>
        void Event_Import_IN_ItemClick(object sender, ItemClickEventArgs e)
        {
            CImportIn form = new CImportIn();
            
            form.ShowDialog();
        }
 * */

        /// <summary>
        /// 为当前项目添加单位工程事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_New_UnitProject_ItemClick(object sender, ItemClickEventArgs e)
        {
            //根据操作类别判断如何添加单位工程(
            //1.项目操作下的单位工程添加(必须存在选择单项工程) 
            //2.单项工程下单位工程直接添加
            //1.获取节点的深度
            
            //判断当前树的结构类型（单位 or 单项）
           
            /*switch (this.projectTrees1.DataType)
            {
                case "CProjects"://单位工程
                    this.doTreeAddProject();
                    break;
                case "CEngineering"://单项工程
                    //默认取当前数据对象
                    this.doTreeAddEngineering();
                    break;
            }*/
            
        }

        /// <summary>
        /// 单项类型添加
        /// </summary>
        private void doTreeAddEngineering()
        {
           /* int level = this.projectTrees1.treeList1.Selection[0].Level;
            int key = -1;
            switch (level)
            {
                case 0:
                    key = Convert.ToInt32(this.projectTrees1.treeList1.Selection[0].GetValue("Key"));
                    break;
                case 1:
                    key = Convert.ToInt32(this.projectTrees1.treeList1.Selection[0].ParentNode.GetValue("Key"));
                    break;
            }
            //如果找到key获取
            if (key != -1)
            {
                _Engineering ce = APP.General.CurrentCEngineering;
                _UnitProject cu = ce.Create();
                NewUnitProjectForm form = new NewUnitProjectForm();
                form.Engineering = ce;
                form.UnitProject = cu;
                DialogResult r = form.ShowDialog();
                if (r == DialogResult.OK)
                {
                    this.ReLoad();
                }
            }*/
        }


        /// <summary>
        /// 添加单项工程事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_New_Engineering_ItemClick(object sender, ItemClickEventArgs e)
        {
           /* NewEngineeringForm from = new NewEngineeringForm();
            DialogResult r = from.ShowDialog();
            if (r == DialogResult.OK)
            {
                //添加成功重新刷新清单
                this.ReLoad();
            }
            */
        }

        /// <summary>
        /// 项目列表批量添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Event_Batch_ADD_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            //此处实现批量添加逻辑
            
            {
                /*BatchForm form = new BatchForm();
                form.ShowDialog();*/
            }

        }


        /// <summary>
        /// 关闭正在执行的业务对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult r = MessageBox.Show(_Prompt.关闭提示, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            switch(r)
            {
                case DialogResult.Yes:
                    APP.WorkFlows.Close(true);
                    this.TabClose();
                    break;
                case DialogResult.No:
                    APP.WorkFlows.Close(false);
                    this.TabClose();
                    break;
                case DialogResult.Cancel:
                    
                    break;
            }
        }

        /// <summary>
        /// 当关闭某个业务的时候调用此方法控制界面的关闭逻辑
        /// </summary>
        private void TabClose()
        {
            //选项卡关闭
            //this.xtraTabControl1.Close();
            //this.dockManager1.Close();
            //应该处理所有单位工程对应的快捷操作窗口的关闭
        }

        #endregion

    }
}
