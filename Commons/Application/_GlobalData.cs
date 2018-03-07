/*
    当前应用程序要的全局数据对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.Application;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _GlobalData
    {
        /// <summary>
        /// 当前对象上级对象
        /// </summary>
        private _Application m_Parent = null;

        /// <summary>
        /// 获取当前对象的父级对象
        /// </summary>
        public _Application Parent
        {
            get { return this.m_Parent; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public _GlobalData(_Application p_Parent)
        {
            this.m_Parent = p_Parent;
            this.m_UserPriceLibrary = new _UserPriceLibrary(this);
            this.m_RepairQuantityUnit = new _RepairQuantityUnit(this);
        }

        /// <summary>
        /// 缓存中的用户价格库
        /// </summary>
        private _UserPriceLibrary m_UserPriceLibrary = null;

        /// <summary>
        /// 获取或设置缓存中的用户价格库
        /// </summary>
        public _UserPriceLibrary UserPriceLibrary
        {
            get { return this.m_UserPriceLibrary; }
            set { this.m_UserPriceLibrary = value; }
        }

        /// <summary>
        /// 缓存中的补充价格库
        /// </summary>
        private _RepairQuantityUnit m_RepairQuantityUnit = null;

        /// <summary>
        /// 获取或设置：缓存中的补充价格库
        /// </summary>
        public _RepairQuantityUnit RepairQuantityUnit
        {
            get { return m_RepairQuantityUnit; }
            set { m_RepairQuantityUnit = value; }
        }

        /// <summary>
        /// 初始化全局数据对象
        /// </summary>
        public void Init()
        {
            //此方法将调用所有全局对象的Init方法
            //this.m_UserPriceLibrary.Load();
            //this.m_RepairQuantityUnit.Load();
        }

        /// <summary>
        /// 保存全局对象
        /// </summary>
        public void Save()
        {
            //this.m_UserPriceLibrary.Save();
            //this.m_RepairQuantityUnit.Save();
        }
    }
}
