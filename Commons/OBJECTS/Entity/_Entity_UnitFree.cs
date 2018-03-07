/*
 工程取费
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Entity_UnitFree
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
        /// 工程类别
        /// </summary>		
        private string _gclb;
        /// <summary>
        /// 工程类别
        /// </summary>
        public virtual string GCLB
        {
            get { return _gclb; }
            set { _gclb = value; }
        }
        /// <summary>
        /// 定额号范围
        /// </summary>		
        private string _dehfw;
        /// <summary>
        /// 定额号范围
        /// </summary>
        public virtual string DEHFW
        {
            get { return _dehfw; }
            set { _dehfw = value; }
        }
        /// <summary>
        /// 管理费费率
        /// </summary>		
        private decimal _glffl;
        /// <summary>
        /// 管理费费率
        /// </summary>
        public virtual decimal GLFFL
        {
            get { return _glffl; }
            set { _glffl = value; }
        }
        /// <summary>
        /// 利润费率
        /// </summary>		
        private decimal _lrfl;
        /// <summary>
        /// 利润费率
        /// </summary>
        public virtual decimal LRFL
        {
            get { return _lrfl; }
            set { _lrfl = value; }
        }
        /// <summary>
        /// 风险投标费率
        /// </summary>		
        private decimal _fxtbfl;
        /// <summary>
        /// 风险投标费率
        /// </summary>
        public virtual decimal FXTBFL
        {
            get { return _fxtbfl; }
            set { _fxtbfl = value; }
        }
        /// <summary>
        /// 风险标底费率
        /// </summary>		
        private decimal _fxbdfl;
        /// <summary>
        /// 风险标底费率
        /// </summary>
        public virtual decimal FXBDFL
        {
            get { return _fxbdfl; }
            set { _fxbdfl = value; }
        }
        /// <summary>
        /// 管理费投标计算基础
        /// </summary>		
        private string _glftbjsjc;
        /// <summary>
        /// 管理费投标计算基础
        /// </summary>
        public virtual string GLFTBJSJC
        {
            get { return _glftbjsjc; }
            set { _glftbjsjc = value; }
        }
        /// <summary>
        /// 管理费标底计算基础
        /// </summary>		
        private string _glfbdjsjc;
        /// <summary>
        /// 管理费标底计算基础
        /// </summary>
        public virtual string GLFBDJSJC
        {
            get { return _glfbdjsjc; }
            set { _glfbdjsjc = value; }
        }
        /// <summary>
        /// 利润费投标计算基础
        /// </summary>		
        private string _lrftbjsjc;
        /// <summary>
        /// 利润费投标计算基础
        /// </summary>
        public virtual string LRFTBJSJC
        {
            get { return _lrftbjsjc; }
            set { _lrftbjsjc = value; }
        }
        /// <summary>
        /// 利润费标底计算基础
        /// </summary>		
        private string _lrfbdjsjc;
        /// <summary>
        /// 利润费标底计算基础
        /// </summary>
        public virtual string LRFBDJSJC
        {
            get { return _lrfbdjsjc; }
            set { _lrfbdjsjc = value; }
        }
        /// <summary>
        /// 风险费投标计算基础
        /// </summary>		
        private string _fxftbjsjc;
        /// <summary>
        /// 风险费投标计算基础
        /// </summary>
        public virtual string FXFTBJSJC
        {
            get { return _fxftbjsjc; }
            set { _fxftbjsjc = value; }
        }
        /// <summary>
        /// 风险费标底计算基础
        /// </summary>		
        private string _fxfbdjsjc;
        /// <summary>
        /// 风险费标底计算基础
        /// </summary>
        public virtual string FXFBDJSJC
        {
            get { return _fxfbdjsjc; }
            set { _fxfbdjsjc = value; }
        }
        /// <summary>
        /// 是否税费汇总
        /// </summary>		
        private bool _ifsfhz;
        /// <summary>
        /// 是否税费汇总
        /// </summary>
        public virtual bool IFSFHZ
        {
            get { return _ifsfhz; }
            set { _ifsfhz = value; }
        }        
    }
}
