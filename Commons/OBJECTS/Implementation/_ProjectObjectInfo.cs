/*
 项目信息实现类的基础类别
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ProjectObjectInfo:ISubSegment
    {
        /// <summary>
        /// 填充当前对象
        /// </summary>
        /// <param name="p_list"></param>
        /// <param name="p_seed"></param>
        public virtual void Fill(_List p_list, ref int p_seed)
        {
        }

        public _ProjectObjectInfo(_COBJECTS p_Info)
        {
            this.m_Parent = p_Info;
        }

        /// <summary>
        /// 当前基础类别的父类别(若为顶级类别此属性为null)
        /// </summary>
        private _COBJECTS m_Parent = null;
        /// <summary>
        /// 获取当前基础父类别
        /// </summary>
        public _COBJECTS Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        #region ISubSegment 成员

        public virtual int ID
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual int PARENTID
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual int PPARENTID
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual int CPARENTID
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual int FPARENTID
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual int XH
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string XMBM
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string OLDXMBM
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string XMMC
        {
            get
            {
                return this.Parent.Name;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string DW
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string TX
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual  string LB
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool JCBJ
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool FHBJ
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool ZYQD
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string XMTZ
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool SDDJ
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string GCLJSS
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool JBHZ
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string ZJWZ
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool JX
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string YGLB
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool SC
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string QFSZ
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string BEIZHU
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string LibraryName
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string LY
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool SDQD
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool SFFB
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal HL
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal GCL
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal ZJTJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal ZHDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal ZHHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal ZJFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal RGFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal CLFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal JXFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal ZCFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal SBFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal GLFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal LRDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal FXDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal GFDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal SJDJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual string DECJ
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual string FXH
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal XHL
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal ZJFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal RGFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal CLFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual decimal JXFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal ZCFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal SBFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal GLFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal LRHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal FXHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal GFHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal SJHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal JCHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal CJHJ
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal ZGJE
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal JGJE
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal FBJE
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual string JSJC
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual string FL
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual string ZJFS
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual string QDBH
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private long m_Key, m_PKey;
        public long Key
        {
            get
            {
                return this.m_Key;
            }
            set
            {
                this.m_Key = value;
            }
        }

        public long PKey
        {
            get
            {
                return this.m_PKey;
            }
            set
            {
                this.m_PKey = value;
            }
        }

        public string ProName
        {
            get
            {
                return this.Parent.Property.Basis.Name;
            }
            set { }
        }

        public virtual ISubSegment IParent
        {
            get
            {
                return null;
            }

        }
        public  virtual decimal YGJE
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual decimal PBZD
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public  virtual long Sort
        {
            get
            {
                return this.Parent.Directory.Sort;
            }
            set { }
        }

        private long m_UnID;
        public virtual long UnID
        {
            get 
            {
                return this.Parent.ID;
            }
            set
            {
                this.m_UnID = value;
            }
        }

        /// <summary>
        /// 如何填充数据list集合
        /// </summary>
        /// <param name="p_list">要填充的集合列表</param>
        /// <param name="p_seed">虚拟主键结构</param>
        /// <param name="p_type">填充类别 0分部分项 1措施项目</param>
        public virtual void Fill(_List p_list, ref int p_seed, params int[] values)
        {
            //具体方式由子类实现
        }

        #endregion
    }
}
