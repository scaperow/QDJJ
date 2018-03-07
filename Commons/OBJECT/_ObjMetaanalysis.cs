/*
    所有数据源对象的汇总分析通用属性基础类别
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ObjMetaanalysis
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_info"></param>
        public _ObjMetaanalysis(_COBJECTS p_info)
        {
            this.m_Parent = p_info;
        }

        /// <summary>
        /// 所属的数据对象
        /// </summary>
        private _COBJECTS m_Parent = null;

        /// <summary>
        /// 所属的数据对象
        /// </summary>
        public _COBJECTS Parent
        {
            get
            {
                return this.m_Parent;
            }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public virtual long Key
        {
            get
            {
                return this.m_Parent.ID;
            }
        }
        /// <summary>
        /// 外键
        /// </summary>
        public virtual long PKey
        {
            get
            {
                return this.m_Parent.PID;
            }
        }

        /// <summary>
        /// 工程序号
        /// </summary>
        public virtual string XH
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 工程代号
        /// </summary>
        public virtual string Code
        {
            get
            {
                return this.m_Parent.CODE;
            }
        }

        /// <summary>
        /// 工程名称
        /// </summary>
        public virtual string Name
        {
            get
            {
                
                return this.m_Parent.Name;
            }
        }

        /// <summary>
        /// 专业
        /// </summary>
        public virtual string PrfType
        {
            get
            {
                return this.m_Parent.PrfType;
            }
        }

        /// <summary>
        /// 分部分项工程费
        /// </summary>
        public virtual Decimal FGCF
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 措施项目费
        /// </summary>
        public virtual Decimal CSXMF
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 其他项目费
        /// </summary>
        public virtual Decimal QTXMF
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 其他项目费
        /// </summary>
        public virtual Decimal GF
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 税金
        /// </summary>
        public virtual Decimal SJ
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 总造价
        /// </summary>
        public virtual Decimal ZZJ
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 安全文明施工费
        /// </summary>
        public virtual Decimal AQWM
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 劳保费用
        /// </summary>
        public virtual decimal LBTC
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 建设单位
        /// </summary>
        public virtual string JSDW
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 建筑面积
        /// </summary>
        public virtual decimal JZMJ
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 单位造价
        /// </summary>
        public virtual decimal DWZJ
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 占总价比（%）
        /// </summary>
        public virtual decimal ZZJB
        {
            get
            {
                return 100;
            }
        }

        /// <summary>
        /// 备注BZ
        /// </summary>
        public virtual string BZ
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 实现填充当前对象到p_List集合中
        /// </summary>
        /// <param name="p_List"></param>
        public virtual void Fill(_List p_List)
        {

        }
    }
}
