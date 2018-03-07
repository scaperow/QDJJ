/*
 用于保存保存对象的集合对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _SaveInfoList
    {
        private Hashtable m_InfoList = null;

        /// <summary>
        /// 构造函数 存放SaveInfo容器(第一次初始化的时候需要一个Info对象)
        /// </summary>
        public _SaveInfoList()
        {
            this.m_InfoList = new Hashtable();
        }

        /// <summary>
        /// 第一次用来创建 之后都是保存
        /// </summary>
        /// <param name="LockNum"></param>
        public void Create(string LockNum)
        {
            if (this.m_InfoList.Count == 0)
            {
                //首次创建
                _SaveInfo info = new _SaveInfo();
                info.LockNum = LockNum;
                info.EditTime = DateTime.Now;
                info.Type = -1;
                this.m_InfoList.Add("创建", info);
            }
            else
            {
                //是否存在当前锁号
                if (this.m_InfoList.ContainsKey(LockNum))
                {
                    _SaveInfo inf = this.m_InfoList[LockNum] as _SaveInfo;
                    inf.EditTime = DateTime.Now;
                    inf.Type = 0;
                }
                else
                {
                    //首次创建
                    _SaveInfo info = new _SaveInfo();
                    info.LockNum = LockNum;
                    info.EditTime = DateTime.Now;
                    info.Type = -1;
                    this.m_InfoList.Add(LockNum, info);
                }
            }
        }


    }
}
