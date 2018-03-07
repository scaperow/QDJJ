/*
 * 此对象用于处理全局配色方案
 * 1.每个皮肤都需要一套这样的样式(此处初始化为皮肤集合)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using DevExpress.XtraTreeList;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class GlobalStyle
    {
        #region --------------------------新修改的方式代码-----------------------

        /// <summary>
        /// 全局样式发生变化时候激发
        /// </summary>
        [field:NonSerialized]
        public event GlobalStyleChangeHandler GlobalStyleChange;

        /// <summary>
        /// 当全局样式发生变化时调用
        /// </summary>
        public void OnGlobalStyleChange()
        {
            if(this.GlobalStyleChange != null)
            {
                this.GlobalStyleChange();
            }
        }

        /// <summary>
        /// 索引器获取指定的皮肤配色方案
        /// </summary>
        /// <param name="p_SkinName"></param>
        /// <returns></returns>
        public _UseColor this[string p_SkinName]
        {
            get
            {
                if (this.m_UseColorList.ContainsKey(p_SkinName))
                    return this.m_UseColorList[p_SkinName] as _UseColor;
                return null;
            }
            set
            {
                if (this.m_UseColorList.ContainsKey(p_SkinName))
                    this.m_UseColorList[p_SkinName] = value;
                this.m_UseColorList.Add(p_SkinName, value);
            }
        }

        private _UseColor GetUseColor(string p_SkinName)
        {
            if (this.m_UseColorList.ContainsKey(p_SkinName))
                return this.m_UseColorList[p_SkinName] as _UseColor;
            return null;
        }

        /// <summary>
        /// 返回当前选择的皮肤的配色对象
        /// </summary>
        public _UseColor UseColor
        {
            get
            {
                if (this.m_UseColorList.ContainsKey(SkinName))
                    return this.m_UseColorList[SkinName] as _UseColor;
                return null;
                //return this[SkinName];
            }
        }

        /// <summary>
        /// 获取或设置当前正在使用的皮肤名称(所有的方案只保留一套)
        /// </summary>
        private string m_SkinName = "全局皮肤";

        /// <summary>
        /// 获取或设置当前正使用的皮肤名称
        /// </summary>
        public string SkinName
        {
            get
            {
                return this.m_SkinName;
            }
            set
            {
                this.m_SkinName = value;
            }
        }

        /// <summary>
        /// 当前使用的皮肤 不再使用SkinName
        /// </summary>
        private string m_CurrSkinName = string.Empty;

        public string CurrSkinName
        {
            get
            {
                return this.m_CurrSkinName;
            }
            set
            {
                this.m_CurrSkinName = value;
            }
        }

        /// <summary>
        /// 当前皮肤的配色方案
        /// </summary>
        private Hashtable m_UseColorList = null;

        /// <summary>
        /// 返回皮肤配色方案
        /// </summary>
        public Hashtable UseColorList
        {
            get
            {
                return this.m_UseColorList;
            }
        }

        /// <summary>
        /// 初始化配色方案(此方法仅调用一次)
        /// </summary>
        /// <param name="p_strs"></param>
        public void Init(string[] p_strs)
        {
            foreach (string s in p_strs)
            {
                if (!this.m_UseColorList.ContainsKey(s))
                {
                    this.m_UseColorList.Add(s, new _UseColor());
                }
            }

            this.m_SkinName = p_strs[0];
        }

        public GlobalStyle()
        {
            //this.m_SchemeColor = new _SchemeColor();
            this.m_UseColorList = new Hashtable();
            //默认的配置
            this.m_ColumnLayout = new _ColumnLayout();
            //列颜色配置对象
            this.m_ColumnColor = new _ColumnColor();
        }

        /// <summary>
        /// 列的颜色配置对象
        /// </summary>
        private _ColumnColor m_ColumnColor = null;

        /// <summary>
        /// 获取或设置列颜色配置对象
        /// </summary>
        public _ColumnColor ColumnColor
        {
            get
            {
                return this.m_ColumnColor;
            }
            set
            {
                this.m_ColumnColor = value;
            }
        } 

        /// <summary>
        /// 列配置对象
        /// </summary>
        private _ColumnLayout m_ColumnLayout = null;

        /// <summary>
        /// 获取或设置列配置对象
        /// </summary>
        public _ColumnLayout ColumnLayout
        {
            get
            {
                return this.m_ColumnLayout;
            }
            set
            {
                this.m_ColumnLayout = value;
            }
        }

        /// <summary>
        /// 控件界面样式
        /// </summary>
        //private _SchemeColor m_SchemeColor = null;

       

        /// <summary>
        /// 获取副本
        /// </summary>
        /// <returns></returns>
        public virtual object Copy()
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

        #endregion


        /*
        #region-------------------------之前写的代码----------------------

        /// <summary>
        /// 默认配色方案
        /// </summary>
        private _SchemeColor m_Default = null;

        /// <summary>
        /// 获取或设置默认配色方案
        /// </summary>
        public _SchemeColor Defalut
        {
            get
            {
                return this.m_Default;
            }
            set
            {
                this.m_Default = value;
            }
        }


        /// <summary>
        /// 配色方案集合
        /// </summary>
        private Hashtable m_SchemeClorList = null;

        /// <summary>
        /// 配色方案集合
        /// </summary>
        public Hashtable SchemeClorList
        {
            get
            {
                return this.m_SchemeClorList;
            }
            set
            {
                this.m_SchemeClorList = value;
            }
        }

       

        /// <summary>
        /// 将制定方面名称设置为默认值
        /// </summary>
        /// <param name="p_Name"></param>
        public void SetDefalut(string p_Name)
        {
            //如果存在使用汇总分析
            if (this.m_SchemeClorList.ContainsKey(p_Name))
            {
                _SchemeColor sc = this.Defalut.Copy() as _SchemeColor;
                sc.Name = p_Name;
                this.m_SchemeClorList[p_Name] = sc;
            }
        }

        /// <summary>
        /// 获取指定的配色方案(若不存在则返回整体项目的方案)
        /// </summary>
        /// <param name="p_Name"></param>
        /// <returns></returns>
        public _SchemeColor GetSchemeColor(string p_Name)
        {
            //如果存在使用汇总分析
            if (this.m_SchemeClorList.ContainsKey(p_Name))
            {
                return this.m_SchemeClorList[p_Name] as _SchemeColor;
            }
            else
            {
                //使用疯子项目
                return this.m_SchemeClorList["整体项目"] as _SchemeColor;
            }
        }

        /// <summary>
        /// 配色方案构造函数(构造时候会添加整体方案与默认方案)
        /// </summary>
        public GlobalStyle()
        {
            m_SchemeColor = new _SchemeColor();


            ///第一次初始化默认配色方案
            this.m_Default = new _SchemeColor("默认方案");
            m_SchemeClorList = new Hashtable();
            m_SchemeClorList.Add("整体项目", new _SchemeColor("整体项目"));
            /*m_SchemeClorList.Add("分部分项", new _SchemeColor("分部分项"));
            m_SchemeClorList.Add("措施项目", new _SchemeColor("措施项目"));
            m_SchemeClorList.Add("汇总分析", new _SchemeColor("汇总分析"));
            m_SchemeClorList.Add("其他项目", new _SchemeColor("其他项目"));*/
            
        //}
          
        /*
        /// <summary>
        /// 获取副本
        /// </summary>
        /// <returns></returns>
        public virtual object Copy()
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
        #endregion
        */

    }
}
