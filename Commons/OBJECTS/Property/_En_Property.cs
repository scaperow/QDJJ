using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _En_Property : _Property
    {
        public _En_Property (_COBJECTS p_Info):base(p_Info)
        {
            
        }

        /// <summary>
        /// 是否存在指定名称的单位工程
        /// </summary>
        /// <param name="p_Name"></param>
        /// <param name="p_ObjectType"></param>
        /// <returns></returns>
        public override bool IsExist(string p_Code, GOLDSOFT.QDJJ.COMMONS.EObjectType p_ObjectType)
        {
            foreach (_COBJECTS item in this.Parent.StrustObject.ObjectList.Values)
            {
                if (p_ObjectType == EObjectType.UnitProject)
                {
                    if (item.Property.Basis.CODE == p_Code)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 设置当前OBJECTS的状态
        /// </summary>
        /// <param name="p_State"></param>
        public override void SetObjectState(EObjectState p_State)
        {
            ///设置自己的状态
            this.Parent.ObjectState = p_State;
            foreach (_COBJECTS item in this.Parent.StrustObject.ObjectList.Values)
            {
                item.Property.SetObjectState(p_State);
            }
        }

        /// <summary>
        /// 对象中状态为p_State1修改为p_State2
        /// </summary>
        /// <param name="p_State1"></param>
        /// <param name="p_State2"></param>
        public override void ChangeObjectState(EObjectState p_State1, EObjectState p_State2)
        {
            if (this.Parent.ObjectState == p_State1)
            {
                this.Parent.ObjectState = p_State2;
            }
            foreach (_COBJECTS item in this.Parent.StrustObject.ObjectList.Values)
            {
                item.Property.ChangeObjectState(p_State1, p_State2);
            }
        }
    }
}
