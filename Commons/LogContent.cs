using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class LogContent:ArrayList
    {
        /// <summary>
        /// 最后编辑结果
        /// </summary>
        private StringBuilder m_Builder = new StringBuilder();

        public string LogString
        {
            get
            {
                m_Builder = new StringBuilder();
                for (int i = 0; i < this.Count; i++)
                {
                    ModifyAttribute ma = this[i] as ModifyAttribute;
                    if (ma != null)
                    {
                        
                        m_Builder.AppendLine(string.Format("{0}.  {1}", i+1, ma.ToLog()));
                    }
                }
                return this.m_Builder.ToString();
            }
        }

        /// <summary>
        /// 添加一次操作
        /// </summary>
        /// <param name="p_ModifyAttribute"></param>
        /// <returns></returns>
        public int Add(ModifyAttribute p_ModifyAttribute)
        {
            int ci = base.Add(p_ModifyAttribute);
           // m_Builder.AppendLine(string.Format("{0}.  {1}", ci, p_ModifyAttribute.ToLog()));
            return ci;
        }

        /// <summary>
        /// 添加一次操作
        /// </summary>
        /// <param name="p_ActionAttribute"></param>
        /// <returns></returns>
        public int Add(ActionAttribute p_ActionAttribute)
        {
            int ci = base.Add(p_ActionAttribute);
            m_Builder.AppendLine(string.Format("{0}.  {1}", ci, p_ActionAttribute.ToLog()));
            return base.Add(p_ActionAttribute);
        }

        /// <summary>
        /// 返回最后一次操作的属性对象
        /// </summary>
        public Attribute GetLastAttribute
        {
            get 
            {
                if (this.Count == 0) return null;

               Attribute obj = this[this.Count - 1] as Attribute;
               this.RemoveAt(this.Count-1);
               return obj;
            }
        }
    }
}
