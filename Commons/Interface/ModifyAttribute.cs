/*
 为修改属性记录日志提供的特性
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 修改属性时候提供的记录方法
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Property,       //可应用任何元素
     AllowMultiple = true,                            //允许应用多次
     Inherited = true)]
    public class ModifyAttribute : System.Attribute
    {

        public ModifyAttribute()
        { }
        public ModifyAttribute(string p_FieldName, string p_PropertyName, string p_OtherName)
        {
            this._FieldName    = p_FieldName;
            this._PropertyName = p_PropertyName;
            this._OtherName = p_OtherName;
        }

        /// <summary>
        /// 作用域
        /// </summary>
        private string _ActingOn;
        /// <summary>
        /// 当前字段名称
        /// </summary>
        private string _FieldName;
        /// <summary>
        /// 属性名称
        /// </summary>
        private string _PropertyName;
        /// <summary>
        /// 其他名称
        /// </summary>
        private string _OtherName;
        /// <summary>
        /// 当前值
        /// </summary>
        private object _CurrentValue;
        /// <summary>
        /// 原始值
        /// </summary>
        private object _OriginalValue;

        /// <summary>
        /// 对象名称
        /// </summary>
        private string _ObjectName;
        /// <summary>
        /// 受影响的对象
        /// </summary>
        private object p_Source;
        
        /// <summary>
        /// 获取或设置当前模块名称
        /// </summary>
        private string _ModelName = string.Empty;
        /// <summary>
        /// 获取或设置当前模块名称
        /// </summary>
        public string ModelName
        {
            get
            {
                return this._ModelName;
            }
            set
            {
                this._ModelName = value;
            }
        }

        /// <summary>
        /// 受影响的对象
        /// </summary>
        public object Source
        {
            get
            {
                return p_Source;
            }
            set
            {
                this.p_Source = value;
            }
        }


        /// <summary>
        /// 当前对象名称
        /// </summary>
        public string ObjectName
        {
            get { return this._ObjectName; }
            set { this._ObjectName = value; }
        }

        /// <summary>
        /// 获取或设置作用域
        /// </summary>
        public string ActingOn
        {
            get { return this._ActingOn; }
            set { this._ActingOn = value; }
        }
        /// <summary>
        /// 当前字段名称
        /// </summary>
        public string FieldName
        {
            get { return this._FieldName; }
            set { this._FieldName = value; }
        }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName
        {
            get { return this._PropertyName;}
            set { this._PropertyName = value;}
        }
        /// <summary>
        /// 当前值
        /// </summary>
        public object CurrentValue
        {
            get { return this._CurrentValue; }
            set { this._CurrentValue = value; }
        }
        /// <summary>
        /// 当前值
        /// </summary>
        public object OriginalValue
        {
            get { return this._OriginalValue; }
            set { this._OriginalValue = value; }
        }

        /// <summary>
        /// 日志结果
        /// </summary>
        /// <returns></returns>
        public string ToLog()
        {
            return string.Format("{0} 修改 {1}  {2} -> {3}", _ModelName,_ObjectName, _OriginalValue, _CurrentValue);
        }
    }
}
