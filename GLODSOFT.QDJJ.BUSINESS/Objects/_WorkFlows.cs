/*
 *  当前应用程序的工作流(包含业务的对象)
 *  此对象的创建处理当前应用程序要早做什么样的工作
 *  特殊:
 *  
 *      1.一个工作流只能包含1个容器业务对象存在
 *      2.一个工作流允许包含多个非容器对象同时存在
 *      
 *      修改 一个工作流允许处理多个业务对象(不在区分容器业务与非容器业务)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _WorkFlows
    {
        /// <summary>
        /// 加密锁号
        /// </summary>
        private string m_LockNum = string.Empty;

        /// <summary>
        /// 获取或设置加密锁号
        /// </summary>
        public string LockNum
        {
            get
            {
                return this.m_LockNum;
            }
            set
            {
                this.m_LockNum = value;
            }
        }


        public _WorkFlows()
        {
            //构造时候创建工作流流控制对象
            m_Operaty = new _Operaty(this);
        }

        private _Operaty m_Operaty = null;

        /// <summary>
        /// 获取当前业务流的控制对象
        /// </summary>
        public _Operaty Operaty
        {
            get
            {
                return this.m_Operaty;
            }
        }

        /// <summary>
        /// 获取当前正在操作的工作流类型(容器类型) 非容器类型此处没有状态枚举
        /// </summary>
        public EWorkFlowType WorkFlowType
        {
            get 
            {
                if (this.m_Container != null)
                {
                    return this.m_Container.WorkFlowType;
                }
                else
                {
                    //没有任何容器操作
                    return EWorkFlowType.None;
                }
            }
            
        }


        /// <summary>
        /// 容器业务
        /// </summary>
        private _BusContainer m_Container = null;

        /// <summary>
        /// 非容器业务
        /// </summary>
        private _BusNotContainer m_NotContainer = null;

        /// <summary>
        /// 获取当前工作流中的容器业务
        /// </summary>
        
        public _BusContainer Container
        {
            get
            {
                return this.m_Container;
            }
        }

        /// <summary>
        /// 获取当前工作流的非容器业务
        /// </summary>
        public _BusNotContainer NotContainer
        {
            get 
            {
                return this.m_NotContainer; 
            }
        }


        /// <summary>
        /// 初始化新的工作流(每次创建新业务的时候必须初始化)
        /// </summary>
        /// <param name="p_WorkFlowType">为哪个共组进行初始化操作</param>
        /// <returns></returns>
        public _Business Init(EWorkFlowType p_WorkFlowType)
        {
            _Business bus = null;
            switch (p_WorkFlowType)
            {
                case EWorkFlowType.PROJECT://容器
                       bus= this.init_project();
                    break;
                case EWorkFlowType.Engineering://容器
                    bus = this.init_engineering();
                    break;
                case EWorkFlowType.UnitProject://非容器
                    bus = this.init_unitproject();
                    break;
            }

            return bus;
        }

        /// <summary>
        /// 关闭当前工作流(关闭主要用于处理容器业务)
        /// </summary>
        public void Close(bool p_IsSave)
        {
            //关闭容器业务(容器业务不为空)
            if (this.Container != null)
            {
                if (p_IsSave)
                {
                    //如果保存关闭此处调用保存方法
                    //this.Container.Current.Save();
                }

                //如果需要的可以实现每个容器对象的Close()完成关闭的内部操作
                this.Container.Close();
                //清空当前容器业务
                this.m_Container = null;
            }
        }

        #region ------------------------私有方法---------------------------

        /// <summary>
        /// 为项目进行初始化操作
        /// </summary>
        private _Business init_project()
        {
            //创建容器具体业务
            _Business bus = new _Pr_Business();
            
            bus.Init();
            return bus;
        }

        /// <summary>
        /// 为单项工程进行初始化操作
        /// </summary>
        private _Business init_engineering()
        {
            //创建容器业务
            _Business bus = new _En_Business();
            bus.Init();
            return bus;
        }

        /// <summary>
        /// 为单位工程进行初始化操作
        /// </summary>
        private _Business init_unitproject()
        {
            //创建非容器业务(如果此业务对象存在不用重新创建)

            _Business bus = new _Un_Business();
            bus.Init();
            return bus;
        }

        #endregion
    }
}
