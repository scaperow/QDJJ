/*
    项目中措施项目的实现类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _UnMeasures : _ProjectObjectInfo
    {
        public _UnMeasures(_COBJECTS p_Info)
            : base(p_Info)
        {
   
        }

        /// <summary>
        /// 填充分部分项统计数据(单位工程添加)
        /// </summary>
        /// <param name="p_list"></param>
        public override void Fill(_List p_list, ref int p_seed)
        {
            //根据类别处理分部分项数据或者措施项目数据

            this.Key = p_seed++;
            p_list.Add(this);
            //分部分项操作
            foreach (ISubSegment sub in this.Parent.Property.MeasuresProject.ObjectsList)
            {
                if (!(sub is _MeasuresProject))
                {
                    sub.Key = p_seed++;
                    p_list.Add(sub);
                }
            }
        }


        public override string LB
        {
            get
            {
                return "单位工程";
            }
            set
            {

            }
        }

        #region ---------------------计算类统计-----------------
        /// <summary>
        /// 直接费合价
        /// </summary>
        public override decimal ZJFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.ZJFHJ;

            }
            set { }

        }
        /// <summary>
        /// 人工费合价
        /// </summary>
        public override decimal RGFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.RGFHJ;
            }
            set { }
        }
        /// <summary>
        /// 材料费合价
        /// </summary>
        public override decimal CLFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.CLFHJ;
            }
            set { }
        }
        /// <summary>
        /// 机械费合价
        /// </summary>
        public override decimal JXFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.JXFHJ;
            }
            set { }
        }
        /// <summary>
        /// 主材费合价
        /// </summary>
        public override decimal ZCFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.ZCFHJ;
            }
            set { }
        }
        /// <summary>
        /// 设备费合价
        /// </summary>
        public override decimal SBFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.SBFHJ;
            }
            set { }
        }
        /// <summary>
        /// 管理费合价
        /// </summary>
        public override decimal GLFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.GLFHJ;
            }
            set { }
        }
        /// <summary>
        /// 利润合价
        /// </summary>
        public override decimal LRHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.LRHJ;
            }
            set { }
        }
        /// <summary>
        /// 风险合价
        /// </summary>
        public override decimal FXHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.FXHJ;
            }
            set { }
        }
        /// <summary>
        /// 规费合价
        /// </summary>
        public override decimal GFHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.GFHJ;
            }
            set { }
        }
        /// <summary>
        /// 税金合价
        /// </summary>
        public override decimal SJHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.SJHJ;
            }
            set { }
        }
        /// <summary>
        /// 价差合计
        /// </summary>
        public override decimal JCHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.JCHJ;
            }
            set { }
        }
        /// <summary>
        /// 差价合计
        /// </summary>
        public override decimal CJHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.CJHJ;
            }
            set { }
        }

        public override decimal ZHHJ
        {
            get
            {
                return this.Parent.Property.MeasuresProject.ZHHJ;
            }
            set
            {

            }
        }

        #endregion
    }
}
