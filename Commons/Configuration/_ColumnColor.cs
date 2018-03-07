using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ColumnColor
    {
        /// <summary>
        /// 获取或设置元数据集合中指定键值得对象
        /// </summary>
        /// <param name="p_key"></param>
        /// <returns></returns>
        public _ColumnAppearance this[string p_MolName]
        {
            get
            {
                if (this.m_ColumnList.ContainsKey(p_MolName))
                {
                    return this.m_ColumnList[p_MolName] as _ColumnAppearance;
                }
                return null;
            }
            set
            {
                this.Set(p_MolName, value);
            }
        }


        /// <summary>
        /// 存放指定模块的(列配色)
        /// </summary>
        private Hashtable m_ColumnList = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public _ColumnColor()
        {
            m_ColumnList = new Hashtable();
        }

        /// <summary>
        /// 设置列模块对象
        /// </summary>
        /// <param name="p_MolName"></param>
        public void Set(string p_MolName, _ColumnAppearance value)
        {
            if (this.m_ColumnList.ContainsKey(p_MolName))
            {
                this.m_ColumnList[p_MolName] = value;
            }
            else
            {
                this.m_ColumnList.Add(p_MolName, value);
            }
        }

        /// <summary>
        /// 初始化个体模块
        /// </summary>
        /// <param name="p_MolName"></param>
        public void Init(string p_MolName)
        {
            if (this[p_MolName] == null)
            {
                this[p_MolName] = new _ColumnAppearance();
            }
        }
    }

    /// <summary>
    /// 一个独立模块的列颜色集合
    /// </summary>
    [Serializable]
    public class _ColumnAppearance
    {

        /// <summary>
        /// 获取或设置元数据集合中指定键值得对象
        /// </summary>
        /// <param name="p_key"></param>
        /// <returns></returns>
        public _CellStyle this[string p_ColName]
        {
            get
            {
                if (this.m_ColumnsColor.ContainsKey(p_ColName))
                {
                    return this.m_ColumnsColor[p_ColName] as _CellStyle;
                }
                return null;
            }
            set
            {
                this.Set(p_ColName, value);
            }
        }

        /// <summary>
        /// 存放指定模块的(列配色)
        /// </summary>
        private Hashtable m_ColumnsColor = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public _ColumnAppearance()
        {
            m_ColumnsColor = new Hashtable();
        }

        /// <summary>
        /// 设置列模块对象
        /// </summary>
        /// <param name="p_MolName"></param>
        public void Set(string p_ColumnName, _CellStyle value)
        {
            //空与白色不参与保存
            if (value.BColor.IsEmpty || value.BColor == Color.White)
            {
                if (this.m_ColumnsColor.ContainsKey(p_ColumnName))
                {
                    this.m_ColumnsColor.Remove(p_ColumnName);
                    return;
                }
            }

            if (this.m_ColumnsColor.ContainsKey(p_ColumnName))
            {
                this.m_ColumnsColor[p_ColumnName] = value;
            }
            else
            {
                this.m_ColumnsColor.Add(p_ColumnName, value);
            }
        }

    }
    
}
