/*
    用于处理界面配色方案
 *  //1.全局的颜色方案
 *  //2.树形结构的5级菜单
 *  //3.普通控件的颜色
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DevExpress.Utils;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GOLDSOFT.QDJJ.COMMONS
{

    [Serializable]
    public class _UseColor
    {
        /// <summary>
        /// 默认使用系统配色
        /// </summary>
        private EUserColor m_UserColor = EUserColor.System;

        /// <summary>
        /// 获取或设置当前所使用的用户配色方案
        /// </summary>
        public EUserColor UserColor
        {
            get
            {
                return this.m_UserColor;
            }
            set
            {
                this.m_UserColor = value;
            }
        }

        public _UseColor()
        {
            //3中方案默认全部为空
            //如果选择系统配色 则直接调用系统色彩方案
            //this.m_Default = new _SchemeColor();
            //this.m_System  = new _SchemeColor(true);
            this.Custom    = new _SchemeColor();
        }

        /// <summary>
        /// 默认的配置(我们帮助设计好的配色)
        /// </summary>
       // private _SchemeColor m_Default = null;

        /// <summary>
        /// 客户定义的配置
        /// </summary>
        private _SchemeColor m_Custom = null;

        /// <summary>
        /// 系统定义配置(永远为空)
        /// </summary>
        //private _SchemeColor m_System = null;

        /// <summary>
        /// 获取或设置默认的配置
        /// </summary>
        //public _SchemeColor System
        //{
        //    get
        //    {
        //        return this.m_System;
        //    }
        //    set
        //    {
        //        this.m_System = value;
        //    }
        //}

        /// <summary>
        /// 获取或设置默认的配置
        /// </summary>
        //public _SchemeColor Default
        //{
        //    get
        //    {
        //        return this.m_Default;
        //    }
        //    set
        //    {
        //        this.m_Default = value;
        //    }
        //}

        /// <summary>
        /// 客户定义的配置
        /// </summary>
        public _SchemeColor Custom
        {
            get
            {
                return this.m_Custom;
            }
            set
            {
                this.m_Custom = value;
            }
        }

        /// <summary>
        /// 获取获取当前使用的配色（目前仅1种配色方案 ）
        /// </summary>
        /// <returns></returns>
        public _SchemeColor Current()
        {
            if (this.m_Custom != null) return this.m_Custom.Copy();
            else return null;
            /*switch (m_UserColor)
            {
                case EUserColor.Custom: //客户定义
                    if (this.m_Custom != null) return this.m_Custom.Copy();
                    return null;

                case EUserColor.Default://我们定义
                    //if (this.m_Default != null) return this.m_Default.Copy();
                    return null;
                default://返货默认的规则
                    //if (this.m_System != null) return this.m_System.Copy();
                    return null;
            }*/
        }

        /// <summary>
        /// 还原为默认值
        /// </summary>
        public void SetDefault()
        {
            //this.m_Custom = null;
        }

        /// <summary>
        /// 获取副本
        /// </summary>
        /// <returns></returns>
        public virtual _UseColor Copy()
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
                _UseColor uc =CloneObject as _UseColor;
                //uc.Current().SpecialStyle.CurrentSpecialTable = this.Current().SpecialStyle.CurrentSpecialTable.Copy();
                return uc;
            }
        }
    }

    /// <summary>
    /// 配色方案
    /// </summary>
    [Serializable]
    public class _SchemeColor 
    {

        #region---------------------新方法-----------------------

        /// <summary>
        /// 树形结构的颜色样式
        /// </summary>
        private _TreeListStyle m_TreeStyle = null;

        /// <summary>
        /// 表结构的颜色样式
        /// </summary>
        private _GridStyle m_GridStyle = null;

        /// <summary>
        /// 特殊应用样式
        /// </summary>
        private _SpecialStyle m_SpecialStyle = null;

        /// <summary>
        /// 获取或设置一个特殊应用
        /// </summary>
        public _SpecialStyle SpecialStyle
        {
            get
            {
                return this.m_SpecialStyle;
            }
            set
            {
                this.m_SpecialStyle = value;
            }
        }

        /// <summary>
        /// 表结构的颜色样式
        /// </summary>
        public _GridStyle GridStyle
        {
            get
            {
                return this.m_GridStyle;
            }
            set
            {
                this.m_GridStyle = value;
            }
        }

        /// <summary>
        /// 树形结构的颜色样式
        /// </summary>
        public _TreeListStyle TreeStyle
        {
            get
            {
                return this.m_TreeStyle;
            }
            set
            {
                this.m_TreeStyle = value;
            }

        }

        /// <summary>
        /// 空构造
        /// </summary>
        public _SchemeColor()
        {
            this.m_TreeStyle    = new _TreeListStyle();
            this.m_GridStyle      = new _GridStyle();
            this.m_SpecialStyle = new _SpecialStyle();
        }

        /// <summary>
        /// 系统级别构造只包含特殊应用
        /// </summary>
        public _SchemeColor(bool p_IsSystem)
        {
            if (!p_IsSystem)
            {
                this.m_TreeStyle = new _TreeListStyle();
                this.m_GridStyle = new _GridStyle();
                this.m_SpecialStyle = new _SpecialStyle();
            }
            else
            {
                this.m_SpecialStyle = new _SpecialStyle();
            }
        }
      

        #endregion

        /*
        private Hashtable m_ColorList = null;

        

        private string m_Name = string.Empty;

        /// <summary>
        /// 字体
        /// </summary>
        private Font m_Font = null;

        /// <summary>
        /// 字体
        /// </summary>
        public Font MFont
        {
            get
            {
                return this.m_Font;
            }
            set
            {
                this.m_Font = value;
            }
        }

        /// <summary>
        /// 布局名称
        /// </summary>
        public string Name
        { get { return this.m_Name; } set { this.m_Name = value; } }

        
        /// <summary>
        /// 需要通过名称获取(默认添加5级节点对象)
        /// </summary>
        /// <param name="p_Name"></param>
        public _SchemeColor(string p_Name)
        {
            this.m_Name = p_Name;
            m_ColorList = new Hashtable();
            //默认添加5级节点默认方案
            for (int i = 0; i < 5; i++)
            {
                m_ColorList.Add(i, new _CAppearance());
            }
            this.m_Font = new Font("宋体", 9);

            
        }


        /// <summary>
        /// 配色方案索引器
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public _CAppearance this[int i]
        {
            get 
            {
                if (m_ColorList.ContainsKey(i))
                {
                    return m_ColorList[i] as _CAppearance;
                }
                return null;
            }
        }*/

        /// <summary>
        /// 获取副本
        /// </summary>
        /// <returns></returns>
        public virtual _SchemeColor Copy()
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

                _SchemeColor sc = CloneObject as _SchemeColor;
                //sc.SpecialStyle.CurrentSpecialTable = this.SpecialStyle.CurrentSpecialTable.Copy();
                return sc;
            }
        }
         

    }
}
