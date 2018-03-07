/*
 *  说明一个容器业务的基础类别
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public abstract class _BusContainer:_Business
    {
        
        /// <summary>
        /// 当容器发生变化时候调用
        /// </summary>
        public event ListChangeEventHandler ListChange;

        /// <summary>
        /// 编辑之后（增加 删除 单位工程 单项工程）
        /// </summary>
        protected virtual void onListChange()
        {
            if (ListChange != null)
            {
                this.ListChange();
            }
        }
        
        public _BusContainer()
        {
            ///当前业务类别
            this.BusinessType = EBusinessType.Container;
        }

        #region -----------------容器业务的公共操作函数--------------------
        
        /// <summary>
        /// 为当前容器添加子对象
        /// </summary>
        public virtual void Add(_COBJECTS p_info) { }

        /// <summary>
        /// 从指定的父类容器中移除
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <param name="p_info"></param>
        public virtual void Remove(DataRowView p_Row)
        {
            this.onListChange();
        }

        /// <summary>
        /// 为当前容器添加子对象
        /// </summary>
        /// <param name="p_parent"></param>
        /// <param name="p_info"></param>
        public virtual void AddChild(_COBJECTS p_parent, _COBJECTS p_info) 
        {
            /*this.Current.CDirectories.AcceptChanges(p_info.CDirectories);
            p_parent.CObjectList.Add(p_info.CDirectories.Key, p_info);*/
        }

        /// <summary>
        /// 为当前容器提供批量增加的方法
        /// </summary>
        /// <param name="table"></param>
        public virtual void BatchAdd(_Directory[] p_Infos)
        {
            /*foreach (DictionaryEntry obj in table)
            {
                //暂时不允许批量处理时候添加单项工程此处需要过滤掉单项工程和项目工程
                CUnitProject cu = obj.Value as CUnitProject;
                if (cu != null)
                {
                    this.Current.CDirectories.AcceptChanges(cu.CDirectories);
                    //找到此单位工程的所属单项工程对象添加
                    this.Current[cu.CDirectories.ParentFieldName].CObjectList.Add(cu.CDirectories.Key, cu);
                }
            }*/
        }
        
        /// <summary>
        /// 将当前对象导入到源对象中
        /// </summary>
        /// <param name="p_source">源对象</param>
        /// <param name="p_current">当前对象</param>
        public override void ImportIn(_COBJECTS p_source, ArrayList p_currList)
        {
            /*foreach (object o_obj in p_currList)
            {
                _COBJECT obj = o_obj as _COBJECT;
                this.InitDataObject(obj);
                obj.CDirectories.ParentFieldName = p_source.CDirectories.Key;
                this.Current.CDirectories.AcceptChanges(obj.CDirectories);
                p_source.CObjectList.Add(obj.CDirectories.Key, obj);
            }*/
        }
        #endregion
    }
}
