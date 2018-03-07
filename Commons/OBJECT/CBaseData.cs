/******************************
*单位工程的基础数
*此数据仅包含单位工程创建时候的数据集合 
*******************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.LIB;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class CBaseData : _InformationData
    {
        //构造时候的默认值
        public CBaseData()
        {
            this.PlaitDate = DateTime.Now;
            this.ReviewDate = DateTime.Now;
        }

        //工程名称
        //private string m_PrjName = string.Empty;
        //工程编号
        private string m_PrjNo = string.Empty;
      
        //库文件集合
        private _Library m_Libraries = null;
      
        //专业类别
        private string m_PrfType = string.Empty;

        /// <summary>
        ///工程类别
        /// </summary>
        private string m_ProType = string.Empty;

        /// <summary>
        /// 工程说明
        /// </summary>
        private string m_Remark = string.Empty;
        /// <summary>
        /// 获取或设置 工程名称
        /// </summary>
        /*public string PrjName
        {
            get { return this.m_PrjName; }
            set {this.m_PrjName = value;}
        }*/

        /// <summary>
        /// 获取或设置当前工程类别
        /// </summary>
        public string ProType
        {
            get
            {
                return this.m_ProType;
            }
            set
            {
                this.m_ProType = value;
            }
        }

        /// <summary>
        /// 获取或设置 工程编号
        /// </summary>
        public string PrjNo
        {
            get { return this.m_PrjNo; }
            set { this.m_PrjNo = value; }
        }


        /// <summary>
        /// 获取或设置 专业类别
        /// </summary>
        public string PrfType
        {
            get { return this.m_PrfType; }
            set { this.m_PrfType = value; }
        }

        /// <summary>
        /// 获取或设置工程说明
        /// </summary>
        public string Remark
        {
            get
            {
                return this.m_Remark;
            }
            set
            {
                this.m_Remark = value;
            }
        }

        /// <summary>
        /// 获取或设置当前的库文件集合
        /// </summary>
        public _Library Libraries
        {
            get
            {
                return this.m_Libraries;
            }
            set
            {
                this.m_Libraries = value;
            }
        }
    }
}
