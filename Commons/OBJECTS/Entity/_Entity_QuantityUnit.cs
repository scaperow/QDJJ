using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Entity_QuantityUnit
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
        /// 父级ID
        /// </summary>		
        private int _pid;
        /// <summary>
        /// 父级ID
        /// </summary>
        public virtual int PID
        {
            get { return _pid; }
            set { _pid = value; }
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
        /// 原始编号
        /// </summary>		
        private string _ysbh = string.Empty;
        /// <summary>
        /// 原始编号
        /// </summary>
        public virtual string YSBH
        {
            get { return _ysbh; }
            set { _ysbh = value; }
        }
        /// <summary>
        /// 原始名称
        /// </summary>		
        private string _ysmc = string.Empty;
        /// <summary>
        /// 原始名称
        /// </summary>
        public virtual string YSMC
        {
            get { return _ysmc; }
            set { _ysmc = value; }
        }
        /// <summary>
        /// 原始单位
        /// </summary>		
        private string _ysdw = string.Empty;
        /// <summary>
        /// 原始单位
        /// </summary>
        public virtual string YSDW
        {
            get { return _ysdw; }
            set { _ysdw = value; }
        }
        /// <summary>
        /// 原始消耗量
        /// </summary>		
        private decimal _ysxhl;
        /// <summary>
        /// 原始消耗量
        /// </summary>
        public virtual decimal YSXHL
        {
            get { return _ysxhl; }
            set { _ysxhl = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>		
        private string _bh = string.Empty;
        /// <summary>
        /// 编号
        /// </summary>
        public virtual string BH
        {
            get { return _bh; }
            set { _bh = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>		
        private string _mc = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string MC
        {
            get { return _mc; }
            set { _mc = value; }
        }
        /// <summary>
        /// 单位
        /// </summary>		
        private string _dw = string.Empty;
        /// <summary>
        /// 单位
        /// </summary>
        public virtual string DW
        {
            get { return _dw; }
            set { _dw = value; }
        }
        /// <summary>
        /// 消耗量
        /// </summary>		
        private decimal _xhl;
        /// <summary>
        /// 消耗量
        /// </summary>
        public virtual decimal XHL
        {
            get { return _xhl; }
            set { _xhl = value; }
        }
        /// <summary>
        /// 类别
        /// </summary>		
        private string _lb = string.Empty;
        /// <summary>
        /// 类别
        /// </summary>
        public virtual string LB
        {
            get { return _lb; }
            set { _lb = value; }
        }
        /// <summary>
        /// 定额单价
        /// </summary>		
        private decimal _dedj;
        /// <summary>
        /// 定额单价
        /// </summary>
        public virtual decimal DEDJ
        {
            get { return _dedj; }
            set { _dedj = value; }
        }
        /// <summary>
        /// 定额合价
        /// </summary>		
        private decimal _dehj;
        /// <summary>
        /// 定额合价
        /// </summary>
        public virtual decimal DEHJ
        {
            get { return _dehj; }
            set { _dehj = value; }
        }
        /// <summary>
        /// 市场单价
        /// </summary>		
        private decimal _scdj;
        /// <summary>
        /// 市场单价
        /// </summary>
        public virtual decimal SCDJ
        {
            get { return _scdj; }
            set { _scdj = value; }
        }
        /// <summary>
        /// 市场合价
        /// </summary>		
        private decimal _schj;
        /// <summary>
        /// 市场合价
        /// </summary>
        public virtual decimal SCHJ
        {
            get { return _schj; }
            set { _schj = value; }
        }
        /// <summary>
        /// 单价差
        /// </summary>		
        private decimal _djc;
        /// <summary>
        /// 单价差
        /// </summary>
        public virtual decimal DJC
        {
            get { return _djc; }
            set { _djc = value; }
        }
        /// <summary>
        /// 结算单价
        /// </summary>		
        private decimal _jsdj;
        /// <summary>
        /// 结算单价
        /// </summary>
        public virtual decimal JSDJ
        {
            get { return _jsdj; }
            set { _jsdj = value; }
        }
        /// <summary>
        /// 结算单价差
        /// </summary>		
        private decimal _jsdjc;
        /// <summary>
        /// 结算单价差
        /// </summary>
        public virtual decimal JSDJC
        {
            get { return _jsdjc; }
            set { _jsdjc = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>		
        private decimal _sl;
        /// <summary>
        /// 数量
        /// </summary>
        public virtual decimal SL
        {
            get { return _sl; }
            set { _sl = value; }
        }
        /// <summary>
        /// 工程量
        /// </summary>		
        private decimal _gcl;
        /// <summary>
        /// 工程量
        /// </summary>
        public virtual decimal GCL
        {
            get { return _gcl; }
            set { _gcl = value; }
        }
        /// <summary>
        /// 是否主要材料
        /// </summary>		
        private bool _ifzycl;
        /// <summary>
        /// 是否主要材料
        /// </summary>
        public virtual bool IFZYCL
        {
            get { return _ifzycl; }
            set { _ifzycl = value; }
        }
        /// <summary>
        /// 组成类别
        /// </summary>		
        private string _zclb = string.Empty;
        /// <summary>
        /// 组成类别
        /// </summary>
        public virtual string ZCLB
        {
            get { return _zclb; }
            set { _zclb = value; }
        }
        /// <summary>
        /// 规格及型号
        /// </summary>		
        private string _ggxh = string.Empty;
        /// <summary>
        /// 规格及型号
        /// </summary>
        public virtual string GGXH
        {
            get { return _ggxh; }
            set { _ggxh = value; }
        }
        /// <summary>
        /// 三大材类别
        /// </summary>		
        private string _sdclb = string.Empty;
        /// <summary>
        /// 三大材类别
        /// </summary>
        public virtual string SDCLB
        {
            get { return _sdclb; }
            set { _sdclb = value; }
        }
        /// <summary>
        /// 三大材系数
        /// </summary>		
        private decimal _sdcxs;
        /// <summary>
        /// 三大材系数
        /// </summary>
        public virtual decimal SDCXS
        {
            get { return _sdcxs; }
            set { _sdcxs = value; }
        }
        /// <summary>
        /// 用途类别
        /// </summary>		
        private string _ytlb = string.Empty;
        /// <summary>
        /// 用途类别
        /// </summary>
        public virtual string YTLB
        {
            get { return _ytlb; }
            set { _ytlb = value; }
        }
        /// <summary>
        /// 是否选择
        /// </summary>		
        private bool _ifxz;
        /// <summary>
        /// 是否选择
        /// </summary>
        public virtual bool IFXZ
        {
            get { return _ifxz; }
            set { _ifxz = value; }
        }
        /// <summary>
        /// 是否输出
        /// </summary>		
        private bool _ifsc;
        /// <summary>
        /// 是否输出
        /// </summary>
        public virtual bool IFSC
        {
            get { return _ifsc; }
            set { _ifsc = value; }
        }
        /// <summary>
        /// 是否风险
        /// </summary>		
        private bool _iffx;
        /// <summary>
        /// 是否风险
        /// </summary>
        public virtual bool IFFX
        {
            get { return _iffx; }
            set { _iffx = value; }
        }
        /// <summary>
        /// 是否锁定市场单价
        /// </summary>		
        private bool _ifsdscdj;
        /// <summary>
        /// 是否锁定市场单价
        /// </summary>
        public virtual bool IFSDSCDJ
        {
            get { return _ifsdscdj; }
            set { _ifsdscdj = value; }
        }
        /// <summary>
        /// 是否锁定数量
        /// </summary>		
        private bool _ifsdsl;
        /// <summary>
        /// 是否锁定数量
        /// </summary>
        public virtual bool IFSDSL
        {
            get { return _ifsdsl; }
            set { _ifsdsl = value; }
        }
        /// <summary>
        /// 是否可分解
        /// </summary>		
        private bool _ifkfj;
        /// <summary>
        /// 是否可分解
        /// </summary>
        public virtual bool IFKFJ
        {
            get { return _ifkfj; }
            set { _ifkfj = value; }
        }
        /// <summary>
        /// 所属库类别
        /// </summary>		
        private string _ssklb = string.Empty;
        /// <summary>
        /// 所属库类别
        /// </summary>
        public virtual string SSKLB
        {
            get { return _ssklb; }
            set { _ssklb = value; }
        }
        /// <summary>
        /// 所属单位工程名称
        /// </summary>		
        private string _ssdwgc = string.Empty;
        /// <summary>
        /// 所属单位工程名称
        /// </summary>
        public virtual string SSDWGC
        {
            get { return _ssdwgc; }
            set { _ssdwgc = value; }
        }
        /// <summary>
        /// 工料机备注
        /// </summary>		
        private string _gljbz = string.Empty;
        /// <summary>
        /// 工料机备注
        /// </summary>
        public virtual string GLJBZ
        {
            get { return _gljbz; }
            set { _gljbz = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _ctime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CTIME
        {
            get { return _ctime; }
            set { _ctime = value; }
        }
        /// <summary>
        /// 数量合
        /// </summary>		
        private decimal _slh;
        /// <summary>
        /// 数量合
        /// </summary>
        public virtual decimal SLH
        {
            get { return _slh; }
            set { _slh = value; }
        }
        /// <summary>
        /// 定额合价
        /// </summary>		
        private decimal _sldehj;
        /// <summary>
        /// 定额合价
        /// </summary>
        public virtual decimal SLDEHJ
        {
            get { return _sldehj; }
            set { _sldehj = value; }
        }
        /// <summary>
        /// 市场合价
        /// </summary>		
        private decimal _slschj;
        /// <summary>
        /// 市场合价
        /// </summary>
        public virtual decimal SLSCHJ
        {
            get { return _slschj; }
            set { _slschj = value; }
        }
        /// <summary>
        /// 结算合价差
        /// </summary>		
        private decimal _jshjc;
        /// <summary>
        /// 结算合价差
        /// </summary>
        public virtual decimal JSHJC
        {
            get { return _jshjc; }
            set { _jshjc = value; }
        }
        /// <summary>
        /// 合价差
        /// </summary>		
        private decimal _hjc;
        /// <summary>
        /// 合价差
        /// </summary>
        public virtual decimal HJC
        {
            get { return _hjc; }
            set { _hjc = value; }
        }
        /// <summary>
        /// 三大材和价
        /// </summary>		
        private decimal _sdchj;
        /// <summary>
        /// 三大材和价
        /// </summary>
        public virtual decimal SDCHJ
        {
            get { return _sdchj; }
            set { _sdchj = value; }
        }
        /// <summary>
        /// 厂家
        /// </summary>		
        private string _cj = string.Empty;
        /// <summary>
        /// 厂家
        /// </summary>
        public virtual string CJ
        {
            get { return _cj; }
            set { _cj = value; }
        }
        /// <summary>
        /// 品牌
        /// </summary>		
        private string _pp = string.Empty;
        /// <summary>
        /// 品牌
        /// </summary>
        public virtual string PP
        {
            get { return _pp; }
            set { _pp = value; }
        }
        /// <summary>
        /// 质量等级
        /// </summary>		
        private string _zldj = string.Empty;
        /// <summary>
        /// 质量等级
        /// </summary>
        public virtual string ZLDJ
        {
            get { return _zldj; }
            set { _zldj = value; }
        }
        /// <summary>
        /// 供应商
        /// </summary>		
        private string _gys = string.Empty;
        /// <summary>
        /// 供应商
        /// </summary>
        public virtual string GYS
        {
            get { return _gys; }
            set { _gys = value; }
        }
        /// <summary>
        /// 产地
        /// </summary>		
        private string _cd = string.Empty;
        /// <summary>
        /// 产地
        /// </summary>
        public virtual string CD
        {
            get { return _cd; }
            set { _cd = value; }
        }
        /// <summary>
        /// 厂家备注
        /// </summary>		
        private string _cjbz = string.Empty;
        /// <summary>
        /// 厂家备注
        /// </summary>
        public virtual string CJBZ
        {
            get { return _cjbz; }
            set { _cjbz = value; }
        }
        /// <summary>
        /// 修改后市场单价
        /// </summary>		
        private decimal _xghscdj;
        /// <summary>
        /// 修改后市场单价
        /// </summary>
        public virtual decimal XGHSCDJ
        {
            get { return _xghscdj; }
            set { _xghscdj = value; }
        }
        /// <summary>
        /// 调整系数
        /// </summary>		
        private decimal _tzxs;
        /// <summary>
        /// 调整系数
        /// </summary>
        public virtual decimal TZXS
        {
            get { return _tzxs; }
            set { _tzxs = value; }
        }
        
        
    }
}
