/*
     用于存取表格列样式
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using System.Collections;
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _ColumnLayout
    {
        /// <summary>
        /// 临时保存列的样式(里面存对象 所有的 临时类)
        /// </summary>
        private Hashtable m_ColumnLayoutList = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public _ColumnLayout()
        {
            m_ColumnLayoutList = new Hashtable();
        }

        /// <summary>
        /// 每次写入内存的时候调用此方法
        /// </summary>
        /// <param name="p_name">名称</param>
        /// <param name="p_xtl"></param>
        public void Set(string p_name, DevExpress.XtraTreeList.TreeList p_xtl)
        {
            if (p_name != string.Empty)
            {
                System.IO.MemoryStream buffer = new System.IO.MemoryStream();
                p_xtl.SaveLayoutToStream(buffer);
                this.m_ColumnLayoutList[p_name] = buffer.GetBuffer();
                buffer.Close();
            }
        }

        /// <summary>
        /// 每次写入内存的时候调用此方法
        /// </summary>
        /// <param name="p_name">名称</param>
        /// <param name="p_xtl"></param>
        public void Set(string p_name, DevExpress.XtraGrid.Views.Grid.GridView p_gv)
        {
            if (p_name != string.Empty)
            {
                System.IO.MemoryStream buffer = new System.IO.MemoryStream();
                p_gv.SaveLayoutToStream(buffer, OptionsLayoutBase.FullLayout);
                this.m_ColumnLayoutList[p_name] = buffer.GetBuffer();
                buffer.Close();
            }
        }

        /// <summary>
        /// 读取内存中的样式
        /// </summary>
        /// <param name="p_name">主键名称</param>
        /// <param name="p_xtl">树</param>
        public void Get(string p_name, DevExpress.XtraTreeList.TreeList p_xtl)
        {
            if (p_name == string.Empty) return;
            if (this.m_ColumnLayoutList.ContainsKey(p_name))
            {
                
                byte[] bt = this.m_ColumnLayoutList[p_name] as byte[];
                System.IO.MemoryStream buffer = new System.IO.MemoryStream(bt);
                p_xtl.RestoreLayoutFromStream(buffer);
                buffer.Close();
            }
        }

        /// <summary>
        /// 读取内存中的样式
        /// </summary>
        /// <param name="p_name">主键名称</param>
        /// <param name="p_xtl">树</param>
        public void Get(string p_name, DevExpress.XtraGrid.Views.Grid.GridView p_gv)
        {
            if (p_name == string.Empty) return;

            if (this.m_ColumnLayoutList.ContainsKey(p_name))
            {
                byte[] bt = this.m_ColumnLayoutList[p_name] as byte[];
                System.IO.MemoryStream buffer = new System.IO.MemoryStream(bt);
                p_gv.RestoreLayoutFromStream(buffer);
                buffer.Close();
            }
        }
    }


    /// <summary>
    /// 对象中存放列颜色
    /// </summary>
    [Serializable]
    public class ColumnAppearance
    {
        /// <summary>
        /// 临时保存列的样式(里面存对象 所有的 临时类)
        /// </summary>
        private Hashtable m_ColumnLayoutList = null;

        private Hashtable m_ColumnColor = null;

        /// <summary>
        /// 构造函数(列的名称)
        /// </summary>
        public ColumnAppearance()
        {
            m_ColumnLayoutList = new Hashtable();
            m_ColumnColor = new Hashtable();
        }


    }
}
