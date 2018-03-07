using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Subheadings_Statistics_Return : _Statistics
    {
        public _Subheadings_Statistics_Return(_ObjectInfo p_Parent):base(p_Parent)
        { }

        /// <summary>
        /// 计算
        /// </summary>
        public override void Begin()
        {
            base.Begin();

        }


        public override  void Calculate()
        {
            _SubheadingsInfo info = this.Parent as _SubheadingsInfo;
            if (info.ZJFS != _Constant.公式组价 || info.LB=="子目-增加费")
            {
                info.Subheadings_Statistics.Calculate();
            } 
            this.Begin();
        }
    }
}
