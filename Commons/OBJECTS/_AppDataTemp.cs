/*
    应用程序数据模板(如果为空则为系统默认，若创建项目后更换了模板，此对象可用)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _AppDataTemp
    {
        public _AppDataTemp()
        {
            this.MDataTemp  = new _UserDataTemp();
            this.MSDataTemp = new _UserDataTemp();
            this.ODataTemp = new _UserDataTemp();
            this.YSZMQFDataTemp = new _UserDataTemp();
            this.YSGCQFDataTemp = new _UserDataTemp();
            this.ZMQFDataTemp = new _UserDataTemp();
        }

        /// <summary>
        /// 措施项目模板
        /// </summary>
        public _UserDataTemp MDataTemp = null;

        /// <summary>
        /// 汇总分析模板
        /// </summary>
        public _UserDataTemp MSDataTemp = null;

        /// <summary>
        /// 其他项目模板
        /// </summary>
        public _UserDataTemp ODataTemp = null;

        /// <summary>
        /// 原始子目取费
        /// </summary>
        public _UserDataTemp YSZMQFDataTemp = null;

        /// <summary>
        /// 原始工程取费
        /// </summary>
        public _UserDataTemp YSGCQFDataTemp = null;

        /// <summary>
        /// 子目取费
        /// </summary>
        public _UserDataTemp ZMQFDataTemp = null;
    }

    [Serializable]
    public class _UserDataTemp
    {
        /// <summary>
        /// 模板路径
        /// </summary>
        public string FileName = string.Empty;

        /// <summary>
        /// 是否更换模板（若为 true 更换模板）
        /// </summary>
        public bool IsChange = false;
    }
}
