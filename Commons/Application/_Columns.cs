/*
 * 用与处理分部分项的列对象的类型
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DevExpress.XtraTreeList.Columns;
using DevExpress.Utils;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Columns
    {

        public ArrayList Columns= null;

        /// <summary>
        /// 获取显示列的个数
        /// </summary>
        public int DisplayCount
        {
            get
            {
                int i = 0;
                foreach (object obj in Columns)
                {
                    _Column col = (obj as _Column);
                    if (col.Visable) i++;
                }
                return i;
            }
        }

        /// <summary>
        /// 默认构造函数 
        /// </summary>
        public _Columns()
        {
            //初始化新的列对象
            Columns = new ArrayList();
            //添加默认创建的列对象
            createDefault("序号", "FXH", 100,true,false);
            createDefault("项目编码", _ObjectInfo.FILED_XMBM, 100, true,false);
            createDefault("项目名称", _ObjectInfo.FILED_XMMC, 100, true,true);
            createDefault("类   别", _ObjectInfo.FILED_LB, 100, true, false);
            createDefault("单   位", _ObjectInfo.FILED_DW, 100, true,false);
            createDefault("特   项", _ObjectInfo.FILED_TX, 100, true,true);
            createDefault("降效", _ObjectInfo.FILED_JX, 100, true, true);
            createDefault("检查标记", _ObjectInfo.FILED_JCBJ, 100, true,true);
            createDefault("复核标记", _ObjectInfo.FILED_FHBJ, 100, true, true);
            createDefault("主要清单", _ObjectInfo.FILED_ZYQD, 100, true, true);
            createDefault("项目特征", _ObjectInfo.FILED_XMTZ, 100, true, true);
            createDefault("锁定单价", _ObjectInfo.FILED_SDDJ, 100, true);
            createDefault("工程量计算式", _ObjectInfo.FILED_GCLJSS, 100, true);



            createDefault("含   量", _ObjectInfo.FILED_HL, 100, true, FormatType.Numeric);
            createDefault("工程量", _ObjectInfo.FILED_GCL, 100, true, FormatType.Numeric);
            createDefault("直接调价", _ObjectInfo.FILED_ZJTJ, 100, true, FormatType.Numeric);
            createDefault("综合单价", _ObjectInfo.FILED_ZHDJ, 100, false, FormatType.Numeric);
            createDefault("综合合价", _ObjectInfo.FILED_ZHHJ, 100, false, FormatType.Numeric);
            createDefault("直接费单价", _ObjectInfo.FILED_ZJFDJ, 100, false, FormatType.Numeric);
            createDefault("人工费单价", _ObjectInfo.FILED_RGFDJ, 100, false, FormatType.Numeric);
            createDefault("材料费单价", _ObjectInfo.FILED_CLFDJ, 100, false, FormatType.Numeric);
            createDefault("机械费单价", _ObjectInfo.FILED_JXFDJ, 100, false, FormatType.Numeric);
            createDefault("主材费单价", _ObjectInfo.FILED_ZCFDJ, 100, false, FormatType.Numeric);
            createDefault("设备费单价", _ObjectInfo.FILED_SBFDJ, 100, false, FormatType.Numeric);
            createDefault("管理费单价", _ObjectInfo.FILED_GLFDJ, 100, false, FormatType.Numeric);
            createDefault("利润单价", _ObjectInfo.FILED_LRDJ, 100, false, FormatType.Numeric);
            createDefault("风险单价", _ObjectInfo.FILED_FXDJ, 100, false, FormatType.Numeric);
            createDefault("直接费合价", _ObjectInfo.FILED_ZJFHJ, 100, false, FormatType.Numeric);
            createDefault("人工费合价", _ObjectInfo.FILED_RGFHJ, 100, false, FormatType.Numeric);
            createDefault("材料费合价", _ObjectInfo.FILED_CLFHJ, 100, false, FormatType.Numeric);
            createDefault("机械费合价", _ObjectInfo.FILED_JXFHJ, 100, false, FormatType.Numeric);
            createDefault("主材费合价", _ObjectInfo.FILED_ZCFHJ, 100, false, FormatType.Numeric);
            createDefault("设备费合价", _ObjectInfo.FILED_SBFHJ, 100, false, FormatType.Numeric);
            createDefault("管理费合价", _ObjectInfo.FILED_GLFHJ, 100, false, FormatType.Numeric);
            createDefault("利润合价", _ObjectInfo.FILED_LRHJ, 100, false, FormatType.Numeric);
            createDefault("风险合价", _ObjectInfo.FILED_FXHJ, 100, false, FormatType.Numeric);
            createDefault("价差合价", _ObjectInfo.FILED_JCHJ, 100, false, FormatType.Numeric);
            createDefault("差价合价", _ObjectInfo.FILED_CJHJ, 100, false, FormatType.Numeric);
            createDefault("暂估金额", _ObjectInfo.FILED_ZGJE, 100, false, FormatType.Numeric);
            createDefault("甲供金额", _ObjectInfo.FILED_JGJE, 100, false, FormatType.Numeric);


            createDefault("是否分包", _ObjectInfo.FILED_SFFB, 100, false);
            createDefault("分包金额", _ObjectInfo.FILED_FBJE, 100, true, FormatType.Numeric);
            createDefault("局部汇总", _ObjectInfo.FILED_JBHZ, 100, true);

        }



        private void createDefault(string p_ColumnName, string p_FiledName, int p_Width, bool p_AllowEdit,FormatType p_type)
        {
            _Column col = new _Column();
            col.ColumnName = p_ColumnName;
            col.FiledName = p_FiledName;
            col.ColumnWidth = p_Width;
            col.IsEdit = p_AllowEdit;
            col.FormatType = p_type;
            //添加到列对象中
            this.Columns.Add(col);
        }

        //初始化一个列
        private void createDefault(string p_ColumnName, string p_FiledName, int p_Width, bool p_AllowEdit)
        {
            _Column col = new _Column();
            col.ColumnName = p_ColumnName;
            col.FiledName = p_FiledName;
            col.ColumnWidth = p_Width;
            col.IsEdit = p_AllowEdit;
            col.FormatType = FormatType.None;
            //添加到列对象中
            this.Columns.Add(col);
        }

        private void createDefault(string p_ColumnName, string p_FiledName, int p_Width, bool p_isVisable, bool p_AllowEdit)
        {
            _Column col = new _Column();
            col.ColumnName = p_ColumnName;
            col.FiledName = p_FiledName;
            col.ColumnWidth = p_Width;
            col.Visable = p_isVisable;
            col.IsEdit = p_AllowEdit;
            col.FormatType = FormatType.None;
            //添加到列对象中
            this.Columns.Add(col);
        }
       
        /// <summary>
        /// 当前列结构体
        /// </summary>
        [Serializable]
        public class _Column
        {
            /// <summary>
            /// 列名称(显示在列上的名称)
            /// </summary>
            private string m_ColumnName ;

            public string ColumnName
            {
                get
                {
                    return this.m_ColumnName;
                }
                set
                {
                    this.m_ColumnName = value;
                }
            }
            /// <summary>
            /// 字段名称
            /// </summary>
            private string m_FiledName;

            public string FiledName
            {
                get
                {
                    return this.m_FiledName;
                }
                set
                {
                    this.m_FiledName = value;
                }
            }

            /// <summary>
            /// 是否锁定列
            /// </summary>
            private bool m_IsLocked;

            public bool IsLocked
            {
                get
                {
                    return this.m_IsLocked;
                }
                set
                {
                    this.m_IsLocked = value;
                }
            }

            /// <summary>
            /// 列对象编辑(如果列允许编辑此处需要设计编辑对象)
            /// </summary>
            private object m_ColumnEdit;

            public object ColumnEdit
            {
                get
                {
                    return this.m_ColumnEdit;
                }
                set
                {
                    this.m_ColumnEdit = value;
                }
            }

            /// <summary>
            /// 是否允许编辑
            /// </summary>
            private bool m_IsEdit;

            public bool IsEdit
            {
                get
                {
                    return this.m_IsEdit;
                }
                set
                {
                    this.m_IsEdit = value;
                }
            }

            /// <summary>
            /// 列宽
            /// </summary>
            private int m_ColumnWidth;

            public int ColumnWidth
            {
                get
                {
                    return this.m_ColumnWidth;
                }
                set
                {
                    this.m_ColumnWidth = value;
                }
            }

            /// <summary>
            /// 是否显示
            /// </summary>
            private bool m_Visable = false;

            public bool Visable
            {
                get
                {
                    return this.m_Visable;
                }
                set
                {
                    this.m_Visable = value;
                }
            }

            private FormatType m_FormatType;

            public FormatType FormatType
            {
                get { return m_FormatType; }
                set { m_FormatType = value; }
            }
          
        }
    }
}
