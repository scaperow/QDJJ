using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Report:IDisposable
    {
        public DataSetHelper m_DataSetHelper = new DataSetHelper();

        /// <summary>
        /// 获取或设置当前业务对象
        /// </summary>
        private _Business m_CurrBusiness = null;

        /// <summary>
        /// 获取或设置当前业务对象
        /// </summary>
        public _Business CurrBusiness
        {
            get
            {
                return this.m_CurrBusiness;
            }
            set
            {
                this.m_CurrBusiness = value;

            }
        }

        /// <summary>
        /// 数据源
        /// </summary>
        private _StructSource m_StructSource = null;

        /// <summary>
        /// 获取或设置：数据源
        /// </summary>
        public _StructSource StructSource
        {
            get { return m_StructSource; }
            set { m_StructSource = value; }
        }

        /// <summary>
        /// 当前报表模版
        /// </summary>
        private _List m_ReportStencil = new _List();

        /// <summary>
        ///获取或设置： 当前报表模版
        /// </summary>
        public _List ReportStencil
        {
            get { return m_ReportStencil; }
            set 
            {
                if (value == null) return;
                m_ReportStencil.Clear();
                m_ReportStencil.AddRange(value.ToArray());
            }
        }

        /// <summary>
        /// 报表结果
        /// </summary>
        private ArrayList m_ReportResult = null;

        /// <summary>
        /// 获取或设置：报表结果
        /// </summary>
        public ArrayList ReportResult
        {
            get { return m_ReportResult; }
            set { m_ReportResult = value; }
        }

        private int m_UnID;

        public int UnID
        {
            get { return m_UnID; }
            set { m_UnID = value; }
        }

        /// <summary>
        /// 绑定报表数据
        /// </summary>
        public virtual ArrayList BindingSource()
        {
            return null;
        }

        /// <summary>
        /// 小数点格式化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public decimal Formart(object o)
        {
            return decimal.Parse(ToolKit.ParseDecimal(o).ToString("F2"));
        }
        /// <summary>
        /// 小数点格式化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public decimal Formart(object o, int p_num)
        {
            return decimal.Parse(ToolKit.ParseDecimal(o).ToString(string.Format("F{0}", p_num)));
        }

        #region IDisposable 成员

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
