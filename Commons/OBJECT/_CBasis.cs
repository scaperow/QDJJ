/*
    为统一项目对象结构的基础数据信息(所有业务对象的统一基础数据)
 *  //无论是 项目 单项 单位 工程 相同的属性此处写配置信息
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _CBasis:ICloneable
    {
        

        /// <summary>
        /// 名称
        /// </summary>
        private string m_Name = string.Empty;

        /// <summary>
        /// 获取或设置清单规则
        /// </summary>
        private string m_QDGZ = string.Empty;

        /// <summary>
        /// 获取或设置定额规则
        /// </summary>
        private string m_DEGZ = string.Empty;

        /// <summary>
        /// 业务编号
        /// </summary>
        private System.String m_CODE = string.Empty;
        /// <summary>
        /// 工程地点
        /// </summary>
        private System.String m_PGCDD = string.Empty;
        /// <summary>
        /// 计费程序
        /// </summary>
        private System.Int32 m_PJFCX;
        /// <summary>
        /// 纳税地点
        /// </summary>
        private System.String m_PNSDD = string.Empty;
        /// <summary>
        /// 创建人
        /// </summary>
        private System.String m_CREATOR = string.Empty;
        /// <summary>
        /// 最后编辑人
        /// </summary>
        private System.String m_EDITOR = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        private System.String m_FISTDATETIME = string.Empty;
        /// <summary>
        /// 最后保存时间
        /// </summary>
        private System.String m_EDITDATETIME = string.Empty;



        /// <summary>
        /// 获取或设置当前业务对象的名称(项目/单项工程/单位工程名称)
        /// </summary>
        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        /// <summary>
        /// 获取或设置当前对象的清单规则
        /// </summary>
        public string QDGZ
        {
            get
            {
                return this.m_QDGZ;
            }
            set
            {
                this.m_QDGZ = value;
            }
        }

        /// <summary>
        /// 获取或设置当前对象的定额规则
        /// </summary>
        public string DEGZ
        {
            get
            {
                return this.m_DEGZ;
            }
            set
            {
                this.m_DEGZ = value;
            }
        }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string CODE
        {
            get{return this.m_CODE;}
            set{this.m_CODE = value;}
        }

        /// <summary>
        /// 工程地点
        /// </summary>
        public string PGCDD
        {
            get { return this.m_PGCDD; }
            set { this.m_PGCDD = value; }
        }

        /// <summary>
        /// 计费程序
        /// </summary>
        public int PJFCX
        {
            get { return this.m_PJFCX; }
            set { this.m_PJFCX = value; }
        }

        /// <summary>
        /// 纳税地点
        /// </summary>
        public string PNSDD
        {
            get { return this.m_PNSDD; }
            set { this.m_PNSDD = value; }
        }

        /// <summary>
        /// 创建者
        /// </summary>
        public string CREATOR
        {
            get { return this.m_CREATOR; }
            set { this.m_CREATOR = value; }
        }

        /// <summary>
        /// 最后编辑人
        /// </summary>
        public string EDITOR
        {
            get { return this.m_EDITOR; }
            set { this.m_EDITOR = value; }
        }

        /// <summary>
        /// 首次创建时间
        /// </summary>
        public string FISTDATETIME
        {
            get { return this.m_FISTDATETIME; }
            set { this.m_FISTDATETIME = value; }
        }

        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public string EDITDATETIME
        {
            get { return this.m_EDITDATETIME; }
            set { this.m_EDITDATETIME = value; }
        }

        /// <summary>
        /// 获取当前对象的结构
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return (_ObjectInfo)Activator.CreateInstance(this.GetType());
        }

        /// <summary>
        /// 获取当前对象的副本
        /// </summary>
        /// <returns></returns>
        public object Copy()
        {
            using (MemoryStream ms = new MemoryStream())
            {

                object CloneObject;
                BinaryFormatter bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                // 反序列化至另一个对象(即创建了一个原对象的深表副本)
                CloneObject = bf.Deserialize(ms);
                // 关闭流
                ms.Close();
                return CloneObject;
            }
        }
    }
}
