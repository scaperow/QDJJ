using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Entity_IncreaseCosts
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        /// <summary>
        /// ID
        /// </summary>
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 单位ID
        /// </summary>		
        private int _unid;
        /// <summary>
        /// 单位ID
        /// </summary>
        public virtual int UnID
        {
            get { return _unid; }
            set { _unid = value; }
        }
        /// <summary>
        /// 单项ID
        /// </summary>		
        private int _enid;
        /// <summary>
        /// 单项ID
        /// </summary>
        public virtual int EnID
        {
            get { return _enid; }
            set { _enid = value; }
        }
        /// <summary>
        /// 清单ID
        /// </summary>		
        private int _qdid;
        /// <summary>
        /// 清单ID
        /// </summary>
        public virtual int QDID
        {
            get { return _qdid; }
            set { _qdid = value; }
        }
        /// <summary>
        /// 子目ID
        /// </summary>		
        private int _zmid;
        /// <summary>
        /// 子目ID
        /// </summary>
        public virtual int ZMID
        {
            get { return _zmid; }
            set { _zmid = value; }
        }
        /// <summary>
        /// 增加费名称
        /// </summary>		
        private string _name;
        /// <summary>
        /// 增加费名称
        /// </summary>
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 代号
        /// </summary>		
        private string _dh;
        /// <summary>
        /// 代号
        /// </summary>
        public virtual string DH
        {
            get { return _dh; }
            set { _dh = value; }
        }
        /// <summary>
        /// 计算基础
        /// </summary>		
        private string _jsjc;
        /// <summary>
        /// 计算基础
        /// </summary>
        public virtual string JSJC
        {
            get { return _jsjc; }
            set { _jsjc = value; }
        }
        /// <summary>
        /// 附加基数
        /// </summary>		
        private string _fjjs;
        /// <summary>
        /// 附加基数
        /// </summary>
        public virtual string FJJS
        {
            get { return _fjjs; }
            set { _fjjs = value; }
        }
        /// <summary>
        /// 系数
        /// </summary>		
        private decimal _xs;
        /// <summary>
        /// 系数
        /// </summary>
        public virtual decimal XS
        {
            get { return _xs; }
            set { _xs = value; }
        }
        /// <summary>
        /// 人工系数
        /// </summary>		
        private decimal _rgxs;
        /// <summary>
        /// 人工系数
        /// </summary>
        public virtual decimal RGXS
        {
            get { return _rgxs; }
            set { _rgxs = value; }
        }
        /// <summary>
        /// 材料系数
        /// </summary>		
        private decimal _clxs;
        /// <summary>
        /// 材料系数
        /// </summary>
        public virtual decimal CLXS
        {
            get { return _clxs; }
            set { _clxs = value; }
        }
        /// <summary>
        /// 机械系数
        /// </summary>		
        private decimal _jxxs;
        /// <summary>
        /// 机械系数
        /// </summary>
        public virtual decimal JXXS
        {
            get { return _jxxs; }
            set { _jxxs = value; }
        }
        /// <summary>
        /// 人工费
        /// </summary>		
        private decimal _rgf;
        /// <summary>
        /// 人工费
        /// </summary>
        public virtual decimal RGF
        {
            get { return _rgf; }
            set { _rgf = value; }
        }
        /// <summary>
        /// 材料费
        /// </summary>		
        private decimal _clf;
        /// <summary>
        /// 材料费
        /// </summary>
        public virtual decimal CLF
        {
            get { return _clf; }
            set { _clf = value; }
        }
        /// <summary>
        /// 机械费
        /// </summary>		
        private decimal _jxf;
        /// <summary>
        /// 机械费
        /// </summary>
        public virtual decimal JXF
        {
            get { return _jxf; }
            set { _jxf = value; }
        }
        /// <summary>
        /// 合价
        /// </summary>		
        private decimal _hj;
        /// <summary>
        /// 合价
        /// </summary>
        public virtual decimal HJ
        {
            get { return _hj; }
            set { _hj = value; }
        }
        /// <summary>
        /// 0分部1措施
        /// </summary>		
        private int _sslb;
        /// <summary>
        /// 0分部1措施
        /// </summary>
        public virtual int SSLB
        {
            get { return _sslb; }
            set { _sslb = value; }
        }        
    }
}
