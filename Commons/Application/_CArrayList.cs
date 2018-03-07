/**********************************************
 * 重写的ArrayList主要用于项目清单函数
 * 
 *********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _CArrayList:ArrayList
    {
        public override int Add(object value)
        {     
            return base.Add(value);
        }

        /// <summary>
        /// 用于添加项目清单的集合添加方法
        /// </summary>
        /// <param name="value">集合清单</param>
        /// <returns>所在集合中的位置</returns>
        public int Add(_CDirectories value)
        {
            value.Key = base.Add(value);
            return value.Key;
        }

        /// <summary>
        /// 获取删选过后的结果集合(去除所有单位工程)
        /// </summary>
        /// <returns></returns>
        public _CArrayList GetFilter()
        {
            ArrayList list = this.Clone() as ArrayList;

            for (int i = 0; i < list.Count; i++)
            {
                _CDirectories info = list[i] as _CDirectories;
                if (info.TypeName == 操作类型.单位工程)
                {
                    list.Remove(list[i]);
                }
            }

            _CArrayList listA = new _CArrayList();
            listA.AddRange(list.ToArray());
            return listA;
        }
    }
}
