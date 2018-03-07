/*
 用于展示集合的对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Reveal
    {
        /// <summary>
        /// 计算后的结果集
        /// </summary>
        private _List[] m_Result = null;

        /// <summary>
        /// 获取结果集合
        /// </summary>
        public _List[] Result
        {
            get
            {
                return this.m_Result;
            }
        }

        public _Reveal(_COBJECTS p_Info)
        {
            if (p_Info is _Projects)
            {
                //1.汇总分析 2.分部分项 3.措施项目
                m_Result = new _List[4] { new _List(), new _List(), new _List(), new _List() };
                this.m_ObjMetaanalysis = new _ProMetaanalysis(p_Info);
                this.m_ProSubSegment = new _Pro_SubSegment(p_Info);
                this.m_ProMeasures = new _ProMeasures(p_Info);
                this.m_Attributes = new _Pro_Attr(p_Info);
            }

            if (p_Info is _Engineering)
            {
                this.m_ObjMetaanalysis = new _EngMetaanalysis(p_Info);
                this.m_ProSubSegment = new _En_SubSegment(p_Info);
                this.m_ProMeasures = new _EnMeasures(p_Info);
                this.m_Attributes = new _En_Attr(p_Info);
            }

            if (p_Info is _UnitProject)
            {
                this.m_ObjMetaanalysis = new _UnMetaanalysis(p_Info);
                this.m_ProSubSegment = new _Un_SubSegment(p_Info);
                this.m_ProMeasures = new _UnMeasures(p_Info);
                this.m_Attributes = new _Un_Attr(p_Info);
            }
        }


        public void Init(ERevealType p_ERevealType)
        {
            //1.汇总分析 2.分部分项 3.措施项目 4.项目工料机汇总
             switch (p_ERevealType)
                {
                    case ERevealType.Default:
                        m_Result = new _List[4] { new _List(), new _List(), new _List(), new _List() };
                        break;
                    case ERevealType.汇总分析:
                        m_Result[0] = new _List();
                        break;
                 case ERevealType.分部分项:
                        m_Result[1] = new _List();
                        break;
                 case ERevealType.措施项目:
                        m_Result[2] = new _List();
                        break;
                 default:
                        break;
                      
                }
        }

        /// <summary>
        /// 获取指定的结果集
        /// </summary>
        /// <param name="p_LName"></param>
        /// <returns></returns>
        public _List Get(ERevealType p_ERevealType)
        {
            switch (p_ERevealType)
            {
                case ERevealType.汇总分析:
                    return this.m_Result[0];
                case  ERevealType.分部分项:
                    return this.m_Result[1];
                case ERevealType.措施项目:
                    return this.m_Result[2];
                case ERevealType.项目工料机汇总:
                    return this.m_Result[3];
                default:
                    return null;
            }   
        }

        /// <summary>
        /// 设置结果集合的值
        /// </summary>
        /// <param name="p_LName"></param>
        /// <param name="p_List"></param>
        public void Set(ERevealType p_ERevealType, _List p_List)
        {
            switch (p_ERevealType)
            {
                case ERevealType.汇总分析: 
                    this.m_Result[0] = p_List;
                    break;
                case ERevealType.分部分项:
                    this.m_Result[1] = p_List;
                    break;
                case ERevealType.措施项目:
                    this.m_Result[2] = p_List;
                    break;
                case ERevealType.项目工料机汇总:
                    this.m_Result[3] = p_List;
                    break;
                default:

                    break;
            }   
        }

        /// <summary>
        /// 项目分部分项
        /// </summary>
        private _ProjectObjectInfo m_ProSubSegment = null;
        /// <summary>
        /// 项目措施项目
        /// </summary>
        private _ProjectObjectInfo m_ProMeasures = null;
        /// <summary>
        /// 项目汇总分析
        /// </summary>
        private _ObjMetaanalysis m_ObjMetaanalysis = null;



        public _ObjMetaanalysis ProMetaanalysis
        {
            get
            {
                return this.m_ObjMetaanalysis;
            }
            set
            {
                this.m_ObjMetaanalysis = value;
            }
        }



        public _ProjectObjectInfo ProSubSegment
        {
            get
            {
                return this.m_ProSubSegment;
            }
            set
            {
                this.m_ProSubSegment = value;
            }
        }

        
        /// <summary>
        /// 措施项目展示对象
        /// </summary>
        public _ProjectObjectInfo ProMeasures
        {
            get
            {
                return this.m_ProMeasures;
            }
            set
            {
                this.m_ProMeasures = value;
            }
        }
        /// <summary>
        /// 获取当前对象属性接口实现
        /// </summary>
        private IAttributes m_Attributes = null;

        /// <summary>
        /// 获取当前对象属性接口实现
        /// </summary>
        public IAttributes Attributes
        {
            get
            {
                return this.m_Attributes;
            }
            set
            {
                this.m_Attributes = value;
            }
        }
    }
}
