/*
 *  全局系统操作需要保存的数据对象
 *  1.分部分项中的列(需要修改)
 *  2.配色方案
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 全局数据对象
    /// </summary>
    [Serializable]
    public class _DataObjects
    {
        /// <summary>
        /// 每次加载数据对象后保存的路径
        /// </summary>
        private string m_Path = string.Empty;

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="p_dir"></param>
        /// <returns></returns>
        public static _DataObjects Load(DirectoryInfo p_dir)
        {
            string str = string.Format("{0}config\\options.cfg", p_dir.FullName);
            object obj = CFiles.Deserialize(str);
            _DataObjects _data= obj as _DataObjects;
            _data.m_Path = str;
            /* _data.m_Columns = new _Columns();*/
            //_data.m_GColor = new GlobalStyle();

            return _data;
        }

        /// <summary>
        /// 保存当前配置对象
        /// </summary>
        public void Save()
        {
            CFiles.BinarySerialize(this,this.m_Path);
        }

        /// <summary>
        /// 保存当前配置对象
        /// </summary>
        public void Save(string p_Path)
        {
            CFiles.BinarySerialize(this, p_Path);
        }

        /// <summary>
        /// 获取或设置全局配色方案
        /// </summary>
        private GlobalStyle m_GColor = null;

        /// <summary>
        /// 获取或设置全局配色方案
        /// </summary>
        public GlobalStyle GColor
        {
            get
            {
                return this.m_GColor;
            }
            set
            {
                this.m_GColor = value;
            }
        }


        /*private _Columns m_Columns = null;

        /// <summary>
        /// 分部分项中需要保存的列
        /// </summary>
        public _Columns Columns 
        {
            get 
            {
                return this.m_Columns;
            }
            set
            {
                this.m_Columns = value;
            }
        }*/

        

        /// <summary>
        /// 构造全局数据对象
        /// </summary>
        public _DataObjects()
        {
            //m_Columns = new _Columns();
            //配色全局变量
            m_GColor = new GlobalStyle();
        }
        
    }
}
