using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 所有类的基类
    /// </summary>
    [Serializable]
    public class _BaseObject:ICopy
    {
        public _BaseObject() { }

        /// <summary>
        /// 当前活动的单位工程对象
        /// </summary>
        private _UnitProject m_Activitie = null;

        /// <summary>
        /// 获取或设置：当前活动的单位工程对象
        /// </summary>
        public virtual _UnitProject Activitie
        {
            get
            {
                return this.m_Activitie;
            }
            set
            {
                this.m_Activitie = value;
            }
        }

        #region ICopy 成员

        public virtual void Copys()
        {
            //throw new NotImplementedException();
        }

        public virtual void Paste()
        {
           // throw new NotImplementedException();
        }

        public virtual bool IsPaste()
        {
            IDataObject o = Clipboard.GetDataObject();
            object obj = o.GetData(typeof(_CopyList));
            if (obj != null)
            {
                return true;
            }
            return false;
        }
       


        public virtual void Copys(object o)
        {
            
        }
        /// <summary>
        /// 为还原数据准备的增加方法
        /// </summary>
        /// <param name="p_attr"></param>
        public virtual void Rec_Create(ActionAttribute p_attr) { }
        /// <summary>
        /// 为还原数据准备的替换方法
        /// </summary>
        /// <param name="p_attr"></param>
        public virtual void Rec_Delete(ActionAttribute p_attr) { }
        /// <summary>
        /// 为还原数据准备的替换方法
        /// </summary>
        /// <param name="p_attr"></param>
        public virtual void Rec_Replace(ActionAttribute p_attr) { }
        #endregion

    }
}
