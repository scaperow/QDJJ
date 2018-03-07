using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;
namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _UnInformation : IDataSerializable
    {
        //  private _UnitProject m_Parent;
        /// <summary>
        /// 当清单选择时所触发的事件
        /// </summary>
        /// <param name="Sender">所触发的航对象 </param>
        /// <param name="Check">是否选中</param>
        public delegate void CheckHandler(object Sender, bool Check);
        [field: NonSerializedAttribute()]
        public event CheckHandler OnCheck;
        //public _UnitProject Parent
        //{
        //    get { return m_Parent; }
        //    set { m_Parent = value; }
        //}
        private _InformationTable m_InformationTable;
        public _InformationTable InformationTable
        {
            get { return m_InformationTable; }
            set { m_InformationTable = value; }
        }
        private InformationType m_InformationType;

        public InformationType InformationType
        {
            get { return m_InformationType; }
            set { m_InformationType = value; }
        }
        private DataTable m_TreeTable;
        public DataTable TreeTable
        {
            get { return m_TreeTable; }
            set { m_TreeTable = value; }
        }
        public void EventCheck(object Sender, bool Check)
        {
            if (this.OnCheck != null) this.OnCheck(Sender, Check);
        }

        //private DataTable m_Source;

        ///// <summary>
        ///// 当前数据源
        ///// </summary>
        //public DataTable Source
        //{
        //    get { return m_Source; }
        //    set { m_Source = value; }
        //}

        private bool m_IsInit = true;
        /// <summary>
        /// 标识是否初始化过（添加默认模板）
        /// </summary>
        public bool IsInit
        {
            get { return m_IsInit; }
            set { m_IsInit = value; }
        }
        private DataTable m_QDTable = null;
        /// <summary>
        /// 清单集合
        /// </summary>
        public DataTable QDTable
        {
            get { return m_QDTable; }
            set { m_QDTable = value; }
        }

        private DataTable m_DETable = null;
        /// <summary>
        /// 定额集合
        /// </summary>
        public DataTable DETable
        {
            get { return m_DETable; }
            set { m_DETable = value; }
        }
        public _UnInformation()
        {
            // this.m_Parent = _un;
            this.m_InformationTable = new _InformationTable();
        }


        /// <summary>
        /// 初始化
        /// </summary>

        public void Init()
        {
            if (this.m_IsInit)
            {

                //this.Build();
                this.BuildTable();
                this.m_IsInit = false;

            }
        }

        /// <summary>
        /// 清单和定额表的创建
        /// </summary>
        public void BuildTable()
        {
            this.m_QDTable = new DataTable();
            this.m_DETable = new DataTable();
            DataColumn col = this.m_QDTable.Columns.Add("ID", typeof(int));
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 1;
            col.AutoIncrementStep = 1;
            this.m_QDTable.Columns.Add("QDBH");//清单编号
            this.m_QDTable.Columns.Add("QDMC");//名称
            this.m_QDTable.Columns.Add("DW");//单位
            this.m_QDTable.Columns.Add("XS", typeof(float));//系数
            this.m_QDTable.Columns.Add("GCL", typeof(float));//工程量
            this.m_QDTable.Columns.Add("TJ");//所操作的条件
            this.m_QDTable.Columns.Add("Check", typeof(bool));
            this.m_QDTable.Columns.Add("ZJ");//清单所属章节【清单编号前六位】
            this.m_QDTable.Columns["Check"].DefaultValue = true; //是否打钩
            this.m_QDTable.Columns.Add("IsFresh", typeof(bool));
            this.m_QDTable.Columns["IsFresh"].DefaultValue = false; //是否刷新
            this.m_QDTable.Columns.Add("WZLX");//刷新到 分布分项 还是 措施项目
            this.m_QDTable.Columns["WZLX"].DefaultValue = "分布分项";
            this.m_QDTable.Columns.Add("WZ");//刷新到具体位置
            this.m_QDTable.Columns.Add("BZ");//备注
            //定额表

            DataColumn col1 = this.m_DETable.Columns.Add("ID", typeof(int));
            col1.AutoIncrement = true;
            col1.AutoIncrementSeed = 1;
            col1.AutoIncrementStep = 1;
            this.m_DETable.Columns.Add("DEBH");
            this.m_DETable.Columns.Add("QDBH");
            this.m_DETable.Columns.Add("DEMC");
            this.m_DETable.Columns.Add("DW");
            this.m_DETable.Columns.Add("XS", typeof(float));
            this.m_DETable.Columns.Add("GCL", typeof(float));
            this.m_DETable.Columns.Add("Check", typeof(bool));
            this.m_DETable.Columns["Check"].DefaultValue = true;
            this.m_DETable.Columns.Add("HSQ");
            this.m_DETable.Columns.Add("HSH");
            this.m_DETable.Columns.Add("TJ");

            this.m_DETable.Columns.Add("WZLX");//刷新到 分布分项 还是 措施项目
            this.m_DETable.Columns["WZLX"].DefaultValue = "分布分项";
            this.m_DETable.Columns.Add("WZ");//刷新到具体位置

            this.m_DETable.Columns.Add("ZCMCTH");//替换工料机中 主材的名称
        }

        #region IDataSerializable 成员
        public void OutSerializable()
        {

        }

        public void InSerializable(object e)
        {



        }

        #endregion
    }
}
