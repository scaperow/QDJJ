/*
    工程对象(包括单位工程/项目/单项工程 的全局保存变量此处编写)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Setting
    {

        /// <summary>
        /// 当前基础类别的父类别(若为顶级类别此属性为null)
        /// </summary>
        private _COBJECTS m_Parent = null;
        /// <summary>
        /// 获取当前基础父类别
        /// </summary>
        public virtual _COBJECTS Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        /// <summary>
        /// 数据配置对象的构造函数
        /// </summary>
        public _Setting(_COBJECTS p_Info)
        {
            this.m_Parent = p_Info;
            //this.m_ColumnLayout = new _ColumnLayout();
        }

        /// <summary>
        /// 数据配置对象的构造函数
        /// </summary>
        public _Setting()
        {
            //this.m_ColumnLayout = new _ColumnLayout();
        }

        /// <summary>
        /// 当前数据对象的密码(若为空则不设置密码)
        /// </summary>
        private string m_PassWord = string.Empty;

        /// <summary>
        /// 当前数据对象的密码(若为空则不设置密码)
        /// </summary>
        public string PassWord
        {
            get
            {
                return this.m_PassWord;
            }
            set
            {
                this.m_PassWord = value;
            }
        }

        private bool m_IsLock = true;
        /// <summary>
        /// 当前对象是否宋鼎
        /// </summary>
        public bool IsLock
        {
            get { return m_IsLock; }
            set { m_IsLock = value; }
        }

        /*
        /// <summary>
        /// 列配置对象
        /// </summary>
        private _ColumnLayout m_ColumnLayout = null;

        /// <summary>
        /// 获取或设置列配置对象
        /// </summary>
        public _ColumnLayout ColumnLayout
        {
            get
            {
                return this.m_ColumnLayout;
            }
            set
            {
                this.m_ColumnLayout = value;
            }
        }*/

       
        //private _List m_ReportList = null;

        //public _List ReportList
        //{
        //    get
        //    {
               
        //        return m_ReportList;
               
        //    }
        //    set
        //    {
        //        this.m_ReportList = value;
        //    }
        //}

        //public void Init(_Application p_App)
        //{
        //    if (this.m_ReportList == null)
        //    {
        //        switch (this.Parent.ObjectType)
        //        {
        //            case EObjectType.Default:
        //                break;
        //            case EObjectType.PROJECT:
        //                this.m_ReportList = p_App.Global.DataTamp.XMReports;
        //                break;
        //            case EObjectType.Engineering:
        //                break;
        //            case EObjectType.UnitProject:
        //                this.m_ReportList = p_App.Global.DataTamp.DWGCReports;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
