/*
 用于处理对象LinQ的筛选函数
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 查询元素结构体(为筛选提供必要的元素)
    /// </summary>
    public struct _Element
    {
        /// <summary>
        /// 元素在实体中的名称
        /// </summary>
        public string key;
        /// <summary>
        /// 元素在实体中的值(需要多个值得时候此处定义为数组)
        /// </summary>
        public object value;

        public Type TypeC;

        /// <summary>
        /// 关系
        /// </summary>
        public string Relationship;
    }


    /// <summary>
    /// 定义类的筛选函数对象
    /// </summary>
    public class _Filter
    {

        /// <summary>
        /// 构造一个类型筛选器
        /// </summary>
        /// <param name="p_Source">筛选源对象</param>
        /// <param name="p_Elements">筛选元素</param>
        /*public _Filter(IEnumerable<T> p_Source, _Element[] p_Elements)
        {
            this.m_FilterObject = p_Source;
        }

        /// <summary>
        /// 筛选对象
        /// </summary>
        private IEnumerable<T> m_FilterObject = null;

        /// <summary>
        /// 筛选对象(此对象必须设置)
        /// </summary>
        public IEnumerable<T> FilterObject
        {
            get
            {
                return this.m_FilterObject;
            }
            set
            {
                this.m_FilterObject = value;
            }
        }*/

        /// <summary>
        /// 执行当前的筛选函数
        /// </summary>
        public IEnumerable<T> Query<T>(IEnumerable<T> p_Object,_Element[] p_elements)
        {


            var list = from p in p_Object.Cast<T>()
            select p; 
            foreach(_Element e in p_elements)
            {
                
                
                //list = list.Where(c => Convert.ChangeType((c.GetType().GetProperty(e.key).GetValue(c, null)), e.TypeC) == Convert.ChangeType(e.value, e.TypeC));
                list = list.Where(c => this.doWhere<T>(c, c.GetType().GetProperty(e.key).PropertyType, e));

            }

            return list.ToList<T>();
        }

        /// <summary>
        /// 执行当前的筛选函数
        /// </summary>
        public IEnumerable<T> Query<T>(IEnumerable<T> p_Object, _Element p_elements)
        {


            var list = from p in p_Object.Cast<T>()
                       select p;
            list = list.Where(c => this.doWhere<T>(c, c.GetType().GetProperty(p_elements.key).PropertyType, p_elements));

            return list.ToList<T>();
        }

        private bool doWhere<T>(T obj,Type t,_Element e)
        {
            switch (t.Name)
            {
                case "String":
                     return obj.GetType().GetProperty(e.key).GetValue(obj, null).ToString() == e.value.ToString();
                    
            }
            return false;
        }
    }
}
