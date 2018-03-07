using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Entity_StandardConversion
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
        /// 定额号
        /// </summary>		
        private string _deh;
        /// <summary>
        /// 定额号
        /// </summary>
        public virtual string DEH
        {
            get { return _deh; }
            set { _deh = value; }
        }
        /// <summary>
        /// 换算类别
        /// </summary>		
        private string _hslb;
        /// <summary>
        /// 换算类别
        /// </summary>
        public virtual string HSLB
        {
            get { return _hslb; }
            set { _hslb = value; }
        }
        /// <summary>
        /// 换算信息
        /// </summary>		
        private string _hsxx;
        /// <summary>
        /// 换算信息
        /// </summary>
        public virtual string HSXX
        {
            get { return _hsxx; }
            set { _hsxx = value; }
        }
        /// <summary>
        /// 单价_单位
        /// </summary>		
        private string _dj_dw;
        /// <summary>
        /// 单价_单位
        /// </summary>
        public virtual string DJ_DW
        {
            get { return _dj_dw; }
            set { _dj_dw = value; }
        }
        /// <summary>
        /// 基本量_人工系数
        /// </summary>		
        private string _jbl_rgxs;
        /// <summary>
        /// 基本量_人工系数
        /// </summary>
        public virtual string JBL_RGXS
        {
            get { return _jbl_rgxs; }
            set { _jbl_rgxs = value; }
        }
        /// <summary>
        /// 定额号_材料系数
        /// </summary>		
        private string _deh_clxs;
        /// <summary>
        /// 定额号_材料系数
        /// </summary>
        public virtual string DEH_CLXS
        {
            get { return _deh_clxs; }
            set { _deh_clxs = value; }
        }
        /// <summary>
        /// 调整量_机械系数
        /// </summary>		
        private string _tzl_jxxs;
        /// <summary>
        /// 调整量_机械系数
        /// </summary>
        public virtual string TZL_JXXS
        {
            get { return _tzl_jxxs; }
            set { _tzl_jxxs = value; }
        }
        /// <summary>
        /// 主材
        /// </summary>		
        private string _zc;
        /// <summary>
        /// 主材
        /// </summary>
        public virtual string ZC
        {
            get { return _zc; }
            set { _zc = value; }
        }
        /// <summary>
        /// 设备
        /// </summary>		
        private string _sb;
        /// <summary>
        /// 设备
        /// </summary>
        public virtual string SB
        {
            get { return _sb; }
            set { _sb = value; }
        }
        /// <summary>
        /// 消耗类别
        /// </summary>		
        private string _xhlb;
        /// <summary>
        /// 消耗类别
        /// </summary>
        public virtual string XHLB
        {
            get { return _xhlb; }
            set { _xhlb = value; }
        }
        /// <summary>
        /// 分组
        /// </summary>		
        private string _fz;
        /// <summary>
        /// 分组
        /// </summary>
        public virtual string FZ
        {
            get { return _fz; }
            set { _fz = value; }
        }
        /// <summary>
        /// 未知
        /// </summary>		
        private string _thzhc;
        /// <summary>
        /// 未知
        /// </summary>
        public virtual string THZHC
        {
            get { return _thzhc; }
            set { _thzhc = value; }
        }
        /// <summary>
        /// 未知
        /// </summary>		
        private string _thwzfc;
        /// <summary>
        /// 未知
        /// </summary>
        public virtual string THWZFC
        {
            get { return _thwzfc; }
            set { _thwzfc = value; }
        }
        /// <summary>
        /// 未知
        /// </summary>		
        private string _hsxi;
        /// <summary>
        /// 未知
        /// </summary>
        public virtual string HSXI
        {
            get { return _hsxi; }
            set { _hsxi = value; }
        }        
    }
}
