using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Entity_SubFree
    {
        /// <summary>
        /// 序号
        /// </summary>		
        private int _id;
        /// <summary>
        /// 序号
        /// </summary>
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
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
        /// 所属类别：0 分部分项、1措施项目
        /// </summary>		
        private int _sslb;
        /// <summary>
        /// 所属类别：0 分部分项、1措施项目
        /// </summary>
        public virtual int SSLB
        {
            get { return _sslb; }
            set { _sslb = value; }
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
        /// 排序
        /// </summary>		
        private int _sort;
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        /// <summary>
        /// 引用号
        /// </summary>		
        private string _yyh;
        /// <summary>
        /// 引用号
        /// </summary>
        public virtual string YYH
        {
            get { return _yyh; }
            set { _yyh = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>		
        private string _mc;
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string MC
        {
            get { return _mc; }
            set { _mc = value; }
        }
        /// <summary>
        /// BDS
        /// </summary>		
        private string _bds;
        /// <summary>
        /// BDS
        /// </summary>
        public virtual string BDS
        {
            get { return _bds; }
            set { _bds = value; }
        }
        /// <summary>
        /// 市场价基础
        /// </summary>		
        private string _scjjc;
        /// <summary>
        /// 市场价基础
        /// </summary>
        public virtual string SCJJC
        {
            get { return _scjjc; }
            set { _scjjc = value; }
        }
        /// <summary>
        /// 投标价基础
        /// </summary>		
        private string _tbjsjc;
        /// <summary>
        /// 投标价基础
        /// </summary>
        public virtual string TBJSJC
        {
            get { return _tbjsjc; }
            set { _tbjsjc = value; }
        }
        /// <summary>
        /// 标底价基础
        /// </summary>		
        private string _bdjsjc;
        /// <summary>
        /// 标底价基础
        /// </summary>
        public virtual string BDJSJC
        {
            get { return _bdjsjc; }
            set { _bdjsjc = value; }
        }
        /// <summary>
        /// 费率
        /// </summary>		
        private decimal _fl;
        /// <summary>
        /// 费率
        /// </summary>
        public virtual decimal FL
        {
            get { return _fl; }
            set { _fl = value; }
        }
        /// <summary>
        /// 投标金额
        /// </summary>		
        private decimal _tbje;
        /// <summary>
        /// 投标金额
        /// </summary>
        public virtual decimal TBJE
        {
            get { return _tbje; }
            set { _tbje = value; }
        }
        /// <summary>
        /// 标底金额
        /// </summary>		
        private decimal _bdje;
        /// <summary>
        /// 标底金额
        /// </summary>
        public virtual decimal BDJE
        {
            get { return _bdje; }
            set { _bdje = value; }
        }
        /// <summary>
        /// 费用类别
        /// </summary>		
        private string _fylb;
        /// <summary>
        /// 费用类别
        /// </summary>
        public virtual string FYLB
        {
            get { return _fylb; }
            set { _fylb = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _bz;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string BZ
        {
            get { return _bz; }
            set { _bz = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        private bool _status;
        /// <summary>
        /// 状态
        /// </summary>
        public virtual bool STATUS
        {
            get { return _status; }
            set { _status = value; }
        }        
    }
}
