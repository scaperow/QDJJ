using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 特殊配色类(初始化时候应当包含一个需要处理的模块名称数据集合)
    /// </summary>
    [Serializable]
    public class _SpecialStyle 
    {

        public const string TYPE_OTHER = "杂项";
        public const string TYPE_GLJ = "工料机";
        public const string TYPE_SUBSEGMENT = "分部分项";

        public const string TYPE_CSXM = "措施项目";
        public const string TYPE_OTHERPROJ = "其他项目";
        public const string TYPE_HUIZONGFENXI = "汇总分析";

        private Hashtable m_SpecialStyleInfoList = null;

        public Hashtable Source
        {
            get
            {
                return this.m_SpecialStyleInfoList;
            }
        }
        

        /// <summary>
        /// 特殊处理配色数据集合
        /// </summary>
        //private DataTable m_DefaultSpecialTable = null;


        /// <summary>
        /// 获取或设置特殊处理配色数据集合
        /// </summary>
        /*public DataTable CurrentSpecialTable
        {
            get
            {
                return this.m_DefaultSpecialTable;
            }
            set 
            {
                this.m_DefaultSpecialTable = value;
            }
        }*/

        /// <summary>
        /// 构造函数
        /// </summary>
        public _SpecialStyle()
        {
            m_SpecialStyleInfoList = new Hashtable();
            this.init();
        }

        /// <summary>
        /// 初始化数据(仅构造一次)
        /// </summary>
        /*private void initData()
        {
            this.add("人工","LB");
            this.add("人工%", "LB");
            this.add("人工降效", "LB");
            this.add("其他人工费", "LB");
            this.add("材料", "LB");
            this.add("主材", "LB");
            this.add("设备", "LB");
            this.add("配合比", "LB");
            this.add("其他材料费", "LB");
            this.add("材料%", "LB");
            this.add("机械", "LB");
            this.add("其他机械费", "LB");
            this.add("机械%", "LB");
            this.add("机械台班", "LB");
            this.add("吊装机械", "LB");
            this.add("吊装机械台班", "LB");
            this.add("机械降效", "LB");
            this.add("子目降效", "LB");
            this.add("安装增加费", "LB");
            this.add("模板", "TX");
            this.add("锁定清单及组价", "SDQD");
            this.add("锁定市场价", "IFSDSCDJ");
        }*/

        /// <summary>
        /// 获取存在的配色行
        /// </summary>
        /// <param name="p_Name">配色名称</param>
        /// <returns></returns>
        public _SpecialStyleInfo Get(string p_Name)
        {
            if (m_SpecialStyleInfoList.ContainsKey(p_Name))
                return m_SpecialStyleInfoList[p_Name] as _SpecialStyleInfo;
            return null;
        }

       
        /// <summary>
        /// 默认添加的为杂项类型
        /// </summary>
        /// <param name="p_Name"></param>
        private void addInfo(string p_Name)
        {
            if (!m_SpecialStyleInfoList.ContainsKey(p_Name))
            {
                _SpecialStyleInfo info = new _SpecialStyleInfo();
                info.Name = p_Name;
                info.Type = TYPE_OTHER;
                info.Sort = m_SpecialStyleInfoList.Count + 1;
                m_SpecialStyleInfoList.Add(p_Name, info);
            }
        }

        /// <summary>
        /// 默认添加的为杂项类型
        /// </summary>
        /// <param name="p_Name"></param>
        private void addInfo(string p_Name,string p_Type,string ColumnName)
        {
            if (!m_SpecialStyleInfoList.ContainsKey(p_Name))
            {
                _SpecialStyleInfo info = new _SpecialStyleInfo();
                info.Name = p_Name;
                info.Type = p_Type;
                info.Column = ColumnName;
                info.Sort = m_SpecialStyleInfoList.Count + 1;
                m_SpecialStyleInfoList.Add(p_Name, info);
            }
        }

        /// <summary>
        /// 颜色配置
        /// </summary>
        /*private void buider()
        {
            m_DefaultSpecialTable = new DataTable("特殊配色");
            
            DataColumn dc = m_DefaultSpecialTable.Columns.Add("Name", typeof(string));
            m_DefaultSpecialTable.Columns.Add("Color", typeof(Color));
            m_DefaultSpecialTable.Columns.Add("Color2", typeof(Color));
            m_DefaultSpecialTable.Columns.Add("ForeColor", typeof(Color));
            m_DefaultSpecialTable.Columns.Add("Font", typeof(FontStyle));
            m_DefaultSpecialTable.Columns.Add("ColName", typeof(string));           
            //ID列设置为主键
            m_DefaultSpecialTable.PrimaryKey = new DataColumn[] { dc };
            

        }*/

        private void init()
        {
            //初始化工料机
            this.addInfo("人工", TYPE_GLJ,"LB");
            this.addInfo("人工%", TYPE_GLJ, "LB");
            this.addInfo("材料", TYPE_GLJ, "LB");
            this.addInfo("主材", TYPE_GLJ, "LB");
            this.addInfo("设备", TYPE_GLJ, "LB");
            this.addInfo("材料%", TYPE_GLJ, "LB");
            this.addInfo("机械", TYPE_GLJ, "LB");
            this.addInfo("机械%", TYPE_GLJ, "LB");
            this.addInfo("机械台班", TYPE_GLJ, "LB");
            this.addInfo("吊装机械", TYPE_GLJ, "LB");
            this.addInfo("吊装机械台班", TYPE_GLJ, "LB");
            this.addInfo("人工降效", TYPE_GLJ, "LB");
            this.addInfo("机械降效", TYPE_GLJ, "LB");
            this.addInfo("子目降效", TYPE_GLJ, "LB");
            this.addInfo("配合比", TYPE_GLJ, "LB");
            this.addInfo("市场单价修改", TYPE_GLJ, "LB");

            //
            //this.addInfo("锁定清单及组价", TYPE_SUBSEGMENT, "sdqd");
            //sddj
            //this.addInfo("锁定市场价", TYPE_SUBSEGMENT, "sddj");

            //初始化分部分项格式
            this.addInfo("单位工程", TYPE_SUBSEGMENT, "LB");
            this.addInfo("分部-专业", TYPE_SUBSEGMENT, "LB");
            this.addInfo("分部-章", TYPE_SUBSEGMENT, "LB");
            this.addInfo("分部-节", TYPE_SUBSEGMENT, "LB");
            this.addInfo("清单", TYPE_SUBSEGMENT, "LB");
            this.addInfo("子目", TYPE_SUBSEGMENT, "LB");
            this.addInfo("子目-增加费", TYPE_SUBSEGMENT, "LB");
            //TX 字段
            this.addInfo("模板", TYPE_SUBSEGMENT, "TX");
            //this.addInfo("锁定清单及组价", TYPE_SUBSEGMENT, "TX");
            this.addInfo("锁定清单", TYPE_SUBSEGMENT, "SDQD");
            this.addInfo("锁定单价", TYPE_SUBSEGMENT, "SDDJ");
            this.addInfo("分包", TYPE_SUBSEGMENT, "SFFB");
            this.addInfo("甲供", TYPE_SUBSEGMENT, "-1");
            this.addInfo("暂定", TYPE_SUBSEGMENT, "-1");
            this.addInfo("检查标识", TYPE_SUBSEGMENT, "JCBJ");
            this.addInfo("复核标识", TYPE_SUBSEGMENT, "FHBJ");
            


            //其他杂项
            this.addInfo("树节点:一级", TYPE_OTHER,  "T1");
            this.addInfo("树节点:二级", TYPE_OTHER,  "T2");
            this.addInfo("树节点:三级", TYPE_OTHER,  "T3");
            this.addInfo("树节点:四级", TYPE_OTHER,  "T4");
            this.addInfo("树节点:五级", TYPE_OTHER,  "T5");
            
            //措施项目
            this.addInfo(string.Format("一级[{0}]", _SpecialStyle.TYPE_CSXM), _SpecialStyle.TYPE_CSXM, "T1");
            this.addInfo(string.Format("二级[{0}]", _SpecialStyle.TYPE_CSXM), _SpecialStyle.TYPE_CSXM, "T2");
            this.addInfo(string.Format("三级[{0}]", _SpecialStyle.TYPE_CSXM), _SpecialStyle.TYPE_CSXM, "T3");
            this.addInfo(string.Format("四级[{0}]", _SpecialStyle.TYPE_CSXM), _SpecialStyle.TYPE_CSXM, "T4");
            //this.addInfo("二级", _SpecialStyle.TYPE_CSXM, "T2");
            //this.addInfo("三级", _SpecialStyle.TYPE_CSXM, "T3");
            //this.addInfo("四级", _SpecialStyle.TYPE_CSXM, "T4");
            
            //其他项目
            this.addInfo(string.Format("一级[{0}]", _SpecialStyle.TYPE_OTHERPROJ), _SpecialStyle.TYPE_OTHERPROJ, "T1");
            this.addInfo(string.Format("二级[{0}]", _SpecialStyle.TYPE_OTHERPROJ), _SpecialStyle.TYPE_OTHERPROJ, "T2");
            this.addInfo(string.Format("三级[{0}]", _SpecialStyle.TYPE_OTHERPROJ), _SpecialStyle.TYPE_OTHERPROJ, "T3");
            //this.addInfo("二级", _SpecialStyle.TYPE_OTHERPROJ, "T2");
            //this.addInfo("三级", _SpecialStyle.TYPE_OTHERPROJ, "T3");
            
            //汇总分析
            this.addInfo(string.Format("一级[{0}]", _SpecialStyle.TYPE_HUIZONGFENXI), _SpecialStyle.TYPE_HUIZONGFENXI, "T1");
            this.addInfo(string.Format("二级[{0}]", _SpecialStyle.TYPE_HUIZONGFENXI), _SpecialStyle.TYPE_HUIZONGFENXI, "T2");
            this.addInfo(string.Format("三级[{0}]", _SpecialStyle.TYPE_HUIZONGFENXI), _SpecialStyle.TYPE_HUIZONGFENXI, "T3");
            //this.addInfo("一级", _SpecialStyle.TYPE_HUIZONGFENXI, "T1");
            //this.addInfo("二级", _SpecialStyle.TYPE_HUIZONGFENXI, "T2");
            //this.addInfo("三级", _SpecialStyle.TYPE_HUIZONGFENXI, "T3");
        }
    }

    /// <summary>
    /// 特殊样式的集合
    /// </summary>
    [Serializable]
    public class _SpecialStyleInfo
    {
        private string m_Name = string.Empty;
        private Color m_BColor = new Color();
        private Color m_BColor2 = new Color();
        private Color m_ForeColor = new Color();
        private FontStyle m_Font = FontStyle.Regular;
        private string m_Type = string.Empty;
        private string m_Column = string.Empty;
        private int _Sort;

        public int Sort { get { return this._Sort; } set { this._Sort = value; } }
        public string Column { get { return this.m_Column; } set { this.m_Column = value; } }
        public string Type { get { return this.m_Type; } set { this.m_Type = value; } }
        public string Name { get { return this.m_Name; } set { this.m_Name = value; } }
        public Color BColor { get { return this.m_BColor;}set{this.m_BColor = value;} }
        public Color BColor2 { get { return this.m_BColor2; } set { this.m_BColor2 = value; } }
        public Color ForeColor { get { return this.m_ForeColor; } set { this.m_ForeColor = value; } }
        public FontStyle Font { get { return this.m_Font; } set { this.m_Font = value; } }

    }
}
