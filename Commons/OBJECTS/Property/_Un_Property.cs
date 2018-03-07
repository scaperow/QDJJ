using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Un_Property:_Property
    {
        public _Un_Property(_COBJECTS p_Info)
            : base(p_Info)
        {
            
        }

        /// <summary>
        /// 填充项目树结构
        /// </summary>
        /// <param name="p_List"></param>
        public override void Fill(_List p_List)
        {
            p_List.Add(this.Parent.Directory);
        }

        /// <summary>
        /// 设置当前OBJECTS的状态
        /// </summary>
        /// <param name="p_State"></param>
        public override void SetObjectState(EObjectState p_State)
        {
            this.Parent.ObjectState = p_State;
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
        }

        /// <summary>
        /// 同步项目编码(非单位工程)
        /// </summary>
        public override string Code
        {
            get
            {
                return this.BaseData.PrjNo;
            }
            set
            {
                this.Basis.CODE = value;
                this.BaseData.PrjNo = value;
            }
        }

        public override _List SubheadingsList
        {
            get
            {
                _List mSubheadingsList = new _List();
                mSubheadingsList.AddRange(this.SubSegments.SubheadingsList.ToArray());
                mSubheadingsList.AddRange(this.MeasuresProject.SubheadingsList.ToArray());
                return mSubheadingsList;
            }
        }
    }
}
