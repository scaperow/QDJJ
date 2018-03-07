/* 修改为树的全局配色方案 
 * 
 * //不在控制各个模块中的树结构
 *   树-结构配色对象
 *   各个模块独立配置
 *   默认5个层级配置
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList;
using System.Collections;
using DevExpress.Utils;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _TreeListStyle:_StyleObject
    {
        /*
        /// <summary>
        /// 模块化样式
        /// </summary>
        private _TreeListModelStyle m_ModelStyle = null;


        /// <summary>
        /// 获取或设置模块化样式
        /// </summary>
        public _TreeListModelStyle ModelStyle
        {
            get { return this.m_ModelStyle; }
            set { this.m_ModelStyle = value; }
        }
        */

        public _TreeListStyle()
        {
            ///数的去全局默认
            this.Default = new _CAppearance();
            //this.m_ModelStyle = new _TreeListModelStyle();
        }
        

        /// <summary>
        /// 获取当前界面对象
        /// </summary>
        public override BaseAppearanceCollection Get()
        {
            if (this.Current != null)
            {
                if (this.Current.Value != null)
                {
                    BaseAppearanceCollection ga = new TreeListAppearanceCollection(null);
                    System.IO.MemoryStream buffer = new System.IO.MemoryStream(this.Current.Value);
                    ga.RestoreLayoutFromStream(buffer);
                    buffer.Close();
                    return ga;
                }
            }
            return null;
        }

        /*
        /// <summary>
        /// 获取当前界面对象
        /// </summary>
        public  BaseAppearanceCollection Get(string p_name)
        {
            if (this.Current != null)
            {
                if (this.ModelStyle[p_name] != null)
                {
                    if (this.ModelStyle[p_name].CAppearance.Value != null)
                    {
                        BaseAppearanceCollection ga = new TreeListAppearanceCollection(null);
                        System.IO.MemoryStream buffer = new System.IO.MemoryStream(this.ModelStyle[p_name].CAppearance.Value);
                        ga.RestoreLayoutFromStream(buffer);
                        buffer.Close();
                        return ga;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 保存指定模块的设置对象
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_GVA"></param>
        public void Set(string p_name, DevExpress.Utils.BaseAppearanceCollection p_GVA)
        {
            System.IO.MemoryStream buffer = new System.IO.MemoryStream();
            p_GVA.SaveLayoutToStream(buffer);
            this.ModelStyle[p_name].CAppearance.Value = buffer.GetBuffer();
            buffer.Close();
        }*/
    }
}
