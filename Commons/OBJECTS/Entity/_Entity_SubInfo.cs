using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Entity_SubInfo //: IComparable<_Entity_SubInfo> //IComparer<_Entity_SubInfo>
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
        /// 父级ID （专业章节全部显示的时候）
        /// </summary>		
        private int _pid;
        /// <summary>
        /// 父级ID （专业章节全部显示的时候）
        /// </summary>
        public virtual int PID
        {
            get { return _pid; }
            set { _pid = value; }
        }
        /// <summary>
        /// 父级ID （专业的时候）
        /// </summary>		
        private int _pparentid;
        /// <summary>
        /// 父级ID （专业的时候）
        /// </summary>
        public virtual int PPARENTID
        {
            get { return _pparentid; }
            set { _pparentid = value; }
        }
        /// <summary>
        /// 父级ID （在章的时候使用父级）
        /// </summary>		
        private int _cparentid;
        /// <summary>
        /// 父级ID （在章的时候使用父级）
        /// </summary>
        public virtual int CPARENTID
        {
            get { return _cparentid; }
            set { _cparentid = value; }
        }
        /// <summary>
        /// 父级ID （不显示任何章节时的父）
        /// </summary>		
        private int _fparentid;
        /// <summary>
        /// 父级ID （不显示任何章节时的父）
        /// </summary>
        public virtual int FPARENTID
        {
            get { return _fparentid; }
            set { _fparentid = value; }
        }
        /// <summary>
        /// 序   号
        /// </summary>		
        private int _xh;
        /// <summary>
        /// 序   号
        /// </summary>
        public virtual int XH
        {
            get { return _xh; }
            set { _xh = value; }
        }
        /// <summary>
        /// 项目编码
        /// </summary>		
        private string _xmbm;
        /// <summary>
        /// 项目编码
        /// </summary>
        public virtual string XMBM
        {
            get { return _xmbm; }
            set { _xmbm = value; }
        }
        /// <summary>
        /// 原始项目编码
        /// </summary>		
        private string _oldxmbm;
        /// <summary>
        /// 原始项目编码
        /// </summary>
        public virtual string OLDXMBM
        {
            get { return _oldxmbm; }
            set { _oldxmbm = value; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>		
        private string _xmmc;
        /// <summary>
        /// 项目名称
        /// </summary>
        public virtual string XMMC
        {
            get { return _xmmc; }
            set { _xmmc = value; }
        }
        /// <summary>
        /// 单   位
        /// </summary>		
        private string _dw;
        /// <summary>
        /// 单   位
        /// </summary>
        public virtual string DW
        {
            get { return _dw; }
            set { _dw = value; }
        }
        /// <summary>
        /// 特   项
        /// </summary>		
        private string _tx;
        /// <summary>
        /// 特   项
        /// </summary>
        public virtual string TX
        {
            get { return _tx; }
            set { _tx = value; }
        }
        /// <summary>
        ///  类   别
        /// </summary>		
        private string _lb;
        /// <summary>
        ///  类   别
        /// </summary>
        public virtual string LB
        {
            get { return _lb; }
            set { _lb = value; }
        }
        /// <summary>
        /// 检查标记
        /// </summary>		
        private bool _jcbj;
        /// <summary>
        /// 检查标记
        /// </summary>
        public virtual bool JCBJ
        {
            get { return _jcbj; }
            set { _jcbj = value; }
        }
        /// <summary>
        /// 复核标记
        /// </summary>		
        private bool _fhbj;
        /// <summary>
        /// 复核标记
        /// </summary>
        public virtual bool FHBJ
        {
            get { return _fhbj; }
            set { _fhbj = value; }
        }
        /// <summary>
        /// 主要清单
        /// </summary>		
        private bool _zyqd;
        /// <summary>
        /// 主要清单
        /// </summary>
        public virtual bool ZYQD
        {
            get { return _zyqd; }
            set { _zyqd = value; }
        }
        /// <summary>
        /// 锁定单价
        /// </summary>		
        private bool _sddj;
        /// <summary>
        /// 锁定单价
        /// </summary>
        public virtual bool SDDJ
        {
            get { return _sddj; }
            set { _sddj = value; }
        }
        /// <summary>
        /// 局部汇总
        /// </summary>		
        private bool _jbhz;
        /// <summary>
        /// 局部汇总
        /// </summary>
        public virtual bool JBHZ
        {
            get { return _jbhz; }
            set { _jbhz = value; }
        }
        /// <summary>
        /// 项目特征
        /// </summary>		
        private string _xmtz;
        /// <summary>
        /// 项目特征
        /// </summary>
        public virtual string XMTZ
        {
            get { return _xmtz; }
            set { _xmtz = value; }
        }
        /// <summary>
        /// 工程量计算式
        /// </summary>		
        private string _gcljss;
        /// <summary>
        /// 工程量计算式
        /// </summary>
        public virtual string GCLJSS
        {
            get { return _gcljss; }
            set { _gcljss = value; }
        }
        /// <summary>
        /// 章节位置
        /// </summary>		
        private string _zjwz;
        /// <summary>
        /// 章节位置
        /// </summary>
        public virtual string ZJWZ
        {
            get { return _zjwz; }
            set { _zjwz = value; }
        }
        /// <summary>
        /// 降效
        /// </summary>		
        private bool _jx;
        /// <summary>
        /// 降效
        /// </summary>
        public virtual bool JX
        {
            get { return _jx; }
            set { _jx = value; }
        }
        /// <summary>
        /// 输出
        /// </summary>		
        private bool _sc;
        /// <summary>
        /// 输出
        /// </summary>
        public virtual bool SC
        {
            get { return _sc; }
            set { _sc = value; }
        }
        /// <summary>
        /// 檐高类别
        /// </summary>		
        private string _yglb;
        /// <summary>
        /// 檐高类别
        /// </summary>
        public virtual string YGLB
        {
            get { return _yglb; }
            set { _yglb = value; }
        }
        /// <summary>
        /// 取费设置
        /// </summary>		
        private string _qfsz;
        /// <summary>
        /// 取费设置
        /// </summary>
        public virtual string QFSZ
        {
            get { return _qfsz; }
            set { _qfsz = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _beizhu;
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string BEIZHU
        {
            get { return _beizhu; }
            set { _beizhu = value; }
        }
        /// <summary>
        /// 来源的库
        /// </summary>		
        private string _libraryname;
        /// <summary>
        /// 来源的库
        /// </summary>
        public virtual string LibraryName
        {
            get { return _libraryname; }
            set { _libraryname = value; }
        }
        /// <summary>
        /// 来源
        /// </summary>		
        private string _ly;
        /// <summary>
        /// 来源
        /// </summary>
        public virtual string LY
        {
            get { return _ly; }
            set { _ly = value; }
        }
        /// <summary>
        /// 锁定清单
        /// </summary>		
        private bool _sdqd;
        /// <summary>
        /// 锁定清单
        /// </summary>
        public virtual bool SDQD
        {
            get { return _sdqd; }
            set { _sdqd = value; }
        }
        /// <summary>
        /// 是否分包
        /// </summary>		
        private bool _sffb;
        /// <summary>
        /// 是否分包
        /// </summary>
        public virtual bool SFFB
        {
            get { return _sffb; }
            set { _sffb = value; }
        }
        /// <summary>
        /// 含量
        /// </summary>		
        private decimal _hl;
        /// <summary>
        /// 含量
        /// </summary>
        public virtual decimal HL
        {
            get { return _hl; }
            set { _hl = value; }
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
        /// 直接调价
        /// </summary>		
        private decimal _zjtj;
        /// <summary>
        /// 直接调价
        /// </summary>
        public virtual decimal ZJTJ
        {
            get { return _zjtj; }
            set { _zjtj = value; }
        }
        /// <summary>
        /// 综合单价
        /// </summary>		
        private decimal _zhdj;
        /// <summary>
        /// 综合单价
        /// </summary>
        public virtual decimal ZHDJ
        {
            get { return _zhdj; }
            set { _zhdj = value; }
        }
        /// <summary>
        /// 综合合价
        /// </summary>		
        private decimal _zhhj;
        /// <summary>
        /// 综合合价
        /// </summary>
        public virtual decimal ZHHJ
        {
            get { return _zhhj; }
            set { _zhhj = value; }
        }
        /// <summary>
        /// 直接费单价
        /// </summary>		
        private decimal _zjfdj;
        /// <summary>
        /// 直接费单价
        /// </summary>
        public virtual decimal ZJFDJ
        {
            get { return _zjfdj; }
            set { _zjfdj = value; }
        }
        /// <summary>
        /// 人工费单价
        /// </summary>		
        private decimal _rgfdj;
        /// <summary>
        /// 人工费单价
        /// </summary>
        public virtual decimal RGFDJ
        {
            get { return _rgfdj; }
            set { _rgfdj = value; }
        }
        /// <summary>
        /// 材料费单价
        /// </summary>		
        private decimal _clfdj;
        /// <summary>
        /// 材料费单价
        /// </summary>
        public virtual decimal CLFDJ
        {
            get { return _clfdj; }
            set { _clfdj = value; }
        }
        /// <summary>
        /// 机械费单价
        /// </summary>		
        private decimal _jxfdj;
        /// <summary>
        /// 机械费单价
        /// </summary>
        public virtual decimal JXFDJ
        {
            get { return _jxfdj; }
            set { _jxfdj = value; }
        }
        /// <summary>
        /// 主材费单价
        /// </summary>		
        private decimal _zcfdj;
        /// <summary>
        /// 主材费单价
        /// </summary>
        public virtual decimal ZCFDJ
        {
            get { return _zcfdj; }
            set { _zcfdj = value; }
        }
        /// <summary>
        /// 设备费单价
        /// </summary>		
        private decimal _sbfdj;
        /// <summary>
        /// 设备费单价
        /// </summary>
        public virtual decimal SBFDJ
        {
            get { return _sbfdj; }
            set { _sbfdj = value; }
        }
        /// <summary>
        /// 管理费单价
        /// </summary>		
        private decimal _glfdj;
        /// <summary>
        /// 管理费单价
        /// </summary>
        public virtual decimal GLFDJ
        {
            get { return _glfdj; }
            set { _glfdj = value; }
        }
        /// <summary>
        /// 利润单价
        /// </summary>		
        private decimal _lrdj;
        /// <summary>
        /// 利润单价
        /// </summary>
        public virtual decimal LRDJ
        {
            get { return _lrdj; }
            set { _lrdj = value; }
        }
        /// <summary>
        /// 风险单价
        /// </summary>		
        private decimal _fxdj;
        /// <summary>
        /// 风险单价
        /// </summary>
        public virtual decimal FXDJ
        {
            get { return _fxdj; }
            set { _fxdj = value; }
        }
        /// <summary>
        /// 规费单价
        /// </summary>		
        private decimal _gfdj;
        /// <summary>
        /// 规费单价
        /// </summary>
        public virtual decimal GFDJ
        {
            get { return _gfdj; }
            set { _gfdj = value; }
        }
        /// <summary>
        /// 税金单价
        /// </summary>		
        private decimal _sjdj;
        /// <summary>
        /// 税金单价
        /// </summary>
        public virtual decimal SJDJ
        {
            get { return _sjdj; }
            set { _sjdj = value; }
        }
        /// <summary>
        /// 差价单价
        /// </summary>		
        private decimal _cjdj;
        /// <summary>
        /// 差价单价
        /// </summary>
        public virtual decimal CJDJ
        {
            get { return _cjdj; }
            set { _cjdj = value; }
        }
        /// <summary>
        /// 价差单价
        /// </summary>		
        private decimal _jcdj;
        /// <summary>
        /// 价差单价
        /// </summary>
        public virtual decimal JCDJ
        {
            get { return _jcdj; }
            set { _jcdj = value; }
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
        /// 直接费合价
        /// </summary>		
        private decimal _zjfhj;
        /// <summary>
        /// 直接费合价
        /// </summary>
        public virtual decimal ZJFHJ
        {
            get { return _zjfhj; }
            set { _zjfhj = value; }
        }
        /// <summary>
        /// 人工费合价
        /// </summary>		
        private decimal _rgfhj;
        /// <summary>
        /// 人工费合价
        /// </summary>
        public virtual decimal RGFHJ
        {
            get { return _rgfhj; }
            set { _rgfhj = value; }
        }
        /// <summary>
        /// 材料费合价
        /// </summary>		
        private decimal _clfhj;
        /// <summary>
        /// 材料费合价
        /// </summary>
        public virtual decimal CLFHJ
        {
            get { return _clfhj; }
            set { _clfhj = value; }
        }
        /// <summary>
        /// 机械费合价
        /// </summary>		
        private decimal _jxfhj;
        /// <summary>
        /// 机械费合价
        /// </summary>
        public virtual decimal JXFHJ
        {
            get { return _jxfhj; }
            set { _jxfhj = value; }
        }
        /// <summary>
        /// 主材费合价
        /// </summary>		
        private decimal _zcfhj;
        /// <summary>
        /// 主材费合价
        /// </summary>
        public virtual decimal ZCFHJ
        {
            get { return _zcfhj; }
            set { _zcfhj = value; }
        }
        /// <summary>
        /// 设备费合价
        /// </summary>		
        private decimal _sbfhj;
        /// <summary>
        /// 设备费合价
        /// </summary>
        public virtual decimal SBFHJ
        {
            get { return _sbfhj; }
            set { _sbfhj = value; }
        }
        /// <summary>
        /// 管理费合价
        /// </summary>		
        private decimal _glfhj;
        /// <summary>
        /// 管理费合价
        /// </summary>
        public virtual decimal GLFHJ
        {
            get { return _glfhj; }
            set { _glfhj = value; }
        }
        /// <summary>
        /// 利润合价
        /// </summary>		
        private decimal _lrhj;
        /// <summary>
        /// 利润合价
        /// </summary>
        public virtual decimal LRHJ
        {
            get { return _lrhj; }
            set { _lrhj = value; }
        }
        /// <summary>
        /// 风险合价
        /// </summary>		
        private decimal _fxhj;
        /// <summary>
        /// 风险合价
        /// </summary>
        public virtual decimal FXHJ
        {
            get { return _fxhj; }
            set { _fxhj = value; }
        }
        /// <summary>
        /// 规费合价
        /// </summary>		
        private decimal _gfhj;
        /// <summary>
        /// 规费合价
        /// </summary>
        public virtual decimal GFHJ
        {
            get { return _gfhj; }
            set { _gfhj = value; }
        }
        /// <summary>
        /// 税金合价
        /// </summary>		
        private decimal _sjhj;
        /// <summary>
        /// 税金合价
        /// </summary>
        public virtual decimal SJHJ
        {
            get { return _sjhj; }
            set { _sjhj = value; }
        }
        /// <summary>
        /// 价差合计
        /// </summary>		
        private decimal _jchj;
        /// <summary>
        /// 价差合计
        /// </summary>
        public virtual decimal JCHJ
        {
            get { return _jchj; }
            set { _jchj = value; }
        }
        /// <summary>
        /// 差价合计
        /// </summary>		
        private decimal _cjhj;
        /// <summary>
        /// 差价合计
        /// </summary>
        public virtual decimal CJHJ
        {
            get { return _cjhj; }
            set { _cjhj = value; }
        }
        /// <summary>
        /// 暂估金额
        /// </summary>		
        private decimal _zgje;
        /// <summary>
        /// 暂估金额
        /// </summary>
        public virtual decimal ZGJE
        {
            get { return _zgje; }
            set { _zgje = value; }
        }
        /// <summary>
        /// 甲供金额
        /// </summary>		
        private decimal _jgje;
        /// <summary>
        /// 甲供金额
        /// </summary>
        public virtual decimal JGJE
        {
            get { return _jgje; }
            set { _jgje = value; }
        }
        /// <summary>
        /// 分包金额
        /// </summary>		
        private decimal _fbje;
        /// <summary>
        /// 分包金额
        /// </summary>
        public virtual decimal FBJE
        {
            get { return _fbje; }
            set { _fbje = value; }
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
        /// 定额材机
        /// </summary>		
        private string _decj;
        /// <summary>
        /// 定额材机
        /// </summary>
        public virtual string DECJ
        {
            get { return _decj; }
            set { _decj = value; }
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
        /// 组价方式
        /// </summary>		
        private string _zjfs;
        /// <summary>
        /// 组价方式
        /// </summary>
        public virtual string ZJFS
        {
            get { return _zjfs; }
            set { _zjfs = value; }
        }
        /// <summary>
        /// 清单编号
        /// </summary>		
        private string _qdbh;
        /// <summary>
        /// 清单编号
        /// </summary>
        public virtual string QDBH
        {
            get { return _qdbh; }
            set { _qdbh = value; }
        }
        /// <summary>
        /// 项目内容
        /// </summary>		
        private string _xmnr;
        /// <summary>
        /// 项目内容
        /// </summary>
        public virtual string XMNR
        {
            get { return _xmnr; }
            set { _xmnr = value; }
        }
        /// <summary>
        /// 项目特征值
        /// </summary>		
        private string _xmtzz;
        /// <summary>
        /// 项目特征值
        /// </summary>
        public virtual string XMTZZ
        {
            get { return _xmtzz; }
            set { _xmtzz = value; }
        }
        /// <summary>
        /// 图元公式
        /// </summary>		
        private string _tygs;
        /// <summary>
        /// 图元公式
        /// </summary>
        public virtual string TYGS
        {
            get { return _tygs; }
            set { _tygs = value; }
        }
        /// <summary>
        /// 标识是否通用项目的前四项
        /// </summary>		
        private bool _isty;
        /// <summary>
        /// 标识是否通用项目的前四项
        /// </summary>
        public virtual bool ISTY
        {
            get { return _isty; }
            set { _isty = value; }
        }
        /// <summary>
        /// 评标指定金额
        /// </summary>		
        private decimal _pbzd;
        /// <summary>
        /// 评标指定金额
        /// </summary>
        public virtual decimal PBZD
        {
            get { return _pbzd; }
            set { _pbzd = value; }
        }
        /// <summary>
        /// 乙供金额
        /// </summary>		
        private decimal _ygje;
        /// <summary>
        /// 乙供金额
        /// </summary>
        public virtual decimal YGJE
        {
            get { return _ygje; }
            set { _ygje = value; }
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
        /// <summary>
        /// 自动生成
        /// </summary>		
        private bool _zdsc;
        /// <summary>
        /// 自动生成
        /// </summary>
        public virtual bool ZDSC
        {
            get { return _zdsc; }
            set { _zdsc = value; }
        }
        /// <summary>
        /// 树型结构主编号
        /// </summary>		
        private int _key;
        /// <summary>
        /// 树型结构主编号
        /// </summary>
        public virtual int Key
        {
            get { return _key; }
            set { _key = value; }
        }
        /// <summary>
        /// 树型结构外编号
        /// </summary>		
        private int _pkey;
        /// <summary>
        /// 树型结构外编号
        /// </summary>
        public virtual int PKey
        {
            get { return _pkey; }
            set { _pkey = value; }
        }
        /// <summary>
        /// 深度
        /// </summary>		
        private int _deep;
        /// <summary>
        /// 深度
        /// </summary>
        public virtual int Deep
        {
            get { return _deep; }
            set { _deep = value; }
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
        /// 单位工程ID
        /// </summary>		
        private int _unid;
        /// <summary>
        /// 单位工程ID
        /// </summary>
        public virtual int UnID
        {
            get { return _unid; }
            set { _unid = value; }
        }
        /// <summary>
        /// 单项工程ID
        /// </summary>		
        private int _enid;
        /// <summary>
        /// 单项工程ID
        /// </summary>
        public virtual int EnID
        {
            get { return _enid; }
            set { _enid = value; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>		
        private string _ZYLB;
        /// <summary>
        /// 创建日期
        /// </summary>
        public string ZYLB
        {
            get { return _ZYLB; }
            set { _ZYLB = value; }
        }

        /// <summary>
        /// 创建日期(0分部分项 1措施项目)
        /// </summary>		
        private int _SSLB;
        /// <summary>
        /// 创建日期
        /// </summary>
        public int SSLB
        {
            get { return _SSLB; }
            set { _SSLB = value; }
        }

       		
        private decimal _rgfjc;
        /// <summary>
        /// 人工费调增
        /// </summary>
        public virtual decimal RGFJC
        {
            get { return _rgfjc; }
            set { _rgfjc = value; }
        }

        private decimal _CLFJC;
        /// <summary>
        /// 材料费调增
        /// </summary>
        public virtual decimal CLFJC
        {
            get { return _CLFJC; }
            set { _CLFJC = value; }
        }

        private decimal _jxfjc;
        /// <summary>
        ///  机械费调增
        /// </summary>
        public virtual decimal JXFJC
        {
            get { return _jxfjc; }
            set { _jxfjc = value; }
        }

        //#region IComparer<_Entity_SubInfo> 成员

        //public int Compare(_Entity_SubInfo x, _Entity_SubInfo y)
        //{
        //    if (x.LB.Equals(y.LB).Equals("清单") || x.LB.Equals(y.LB).Equals("子目"))
        //    {
        //        return 0;
        //    }
        //    else if(x.LB.Equals("清单")) 
        //    {
        //        return 
        //    }
        //}

        //#endregion

        //#region IComparable<_Entity_SubInfo> 成员

        //public int CompareTo(_Entity_SubInfo other)
        //{
        //    if (this.LB.Equals(other.LB).Equals("清单") || this.LB.Equals(other.LB).Equals("子目"))
        //    {
        //        return 0;
        //    }
        //    else if (this.LB.Equals("清单") && other.LB.Equals("子目"))
        //    {
        //        return 1;
        //    }
        //    //else if (this.LB.Equals("子目") && other.LB.Equals("清单"))
        //    //{
        //        return -1;
        //    //}
        //}

        //#endregion

        public static _Entity_SubInfo Parse(DataRow row)
        {
            var entity = new _Entity_SubInfo();
            _ObjectSource.GetObject(entity, row);

            return entity;
        }

        public static List<_Entity_SubInfo> ParseMore(params DataRow[] rows)
        {
            var result = new List<_Entity_SubInfo>();
            foreach (var row in rows)
            {
                result.Add(Parse(row));
            }

            return result;
        }
    }
}
