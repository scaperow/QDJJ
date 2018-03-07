/*
 *  中转价格库操作类
 *  此类中包含中转价格库的操作
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 中转价格库操作类
    /// </summary>
    [Serializable]
    public class _TransitPriceLibrary
    {
        #region----------------------私有成员定义---------------------------------

        /// <summary>
        /// 当前对象上级对象
        /// </summary>
        private _UserPriceLibrary m_Parent = null;

        /// <summary>
        /// 当前中转价格库数据表集合
        /// </summary>
        private CTEntitiesTransitPriceLibrary m_CTEntitiesTransitPriceLibrary = null;

        #endregion

        #region----------------------公有成员定义---------------------------------

        /// <summary>
        /// 构造函数
        /// </summary>
        public _TransitPriceLibrary(_UserPriceLibrary p_Parent)
        {
            this.m_Parent = p_Parent;
            this.m_CTEntitiesTransitPriceLibrary = new CTEntitiesTransitPriceLibrary();
        }

        /// <summary>
        /// 获取当前对象的所属对象
        /// </summary>
        public _UserPriceLibrary Parent
        {
            get
            {
                return this.m_Parent;
            }
        }

        /// <summary>
        /// 获取或设置当前用户价格库数据表集合
        /// </summary>
        public CTEntitiesTransitPriceLibrary CTTransitPriceLibrary
        {
            get
            {
                return this.m_CTEntitiesTransitPriceLibrary;
            }
            set
            {
                this.m_CTEntitiesTransitPriceLibrary = value;
            }
        }

        #endregion

        #region----------------------操作方法定义---------------------------------

        /// <summary>
        /// 加载系统中转价格库数据
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// 增加中转价格库
        /// </summary>
        /// <param name="info">中转价格库对象</param>
        public void Insert(CEntityTransitPriceLibrary info)
        {

        }

        /// <summary>
        /// 删除中转价格库
        /// </summary>
        /// <param name="info">中转价格库对象</param>
        private void Delete(CEntityTransitPriceLibrary info)
        {

        }

        /// <summary>
        /// 删除中转价格库
        /// </summary>
        /// <param name="info">中转价格库对象</param>
        private void Update(CEntityTransitPriceLibrary info)
        {

        }

        #endregion

        #region----------------------事件处理定义---------------------------------

        #endregion
    }
}
