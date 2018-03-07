/*
 单独单位工程文件中基础数据以对象中
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Runtime.Serialization;
using System.Data;
using System.Xml.Serialization;


namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _UnitProject : _COBJECTS, IXmlSerializable 
    {
        #region ------------------保留成员----------------------
        /// <summary>
        /// 通知单位工程编辑
        /// </summary>
        /// <param name="sender">引发编辑的对象</param>
        public override void BeginEdit(object sender)
        {
            //状态修改为编辑

            switch (this.ObjectState)
            {
                case EObjectState.Creating:
                case EObjectState.Modify:
                case EObjectState.Created:
                    break;
                default:
                    this.ObjectState = EObjectState.Modify;
                    //通知指定行的状态为修改
                    if (this.Parent != null)
                    {
                        if (this.Parent.Parent != null)
                        {
                            this.Parent.Parent.StructSource.ModelProject.SetModifty(this.ID);
                        }
                    }
                    break;
            }
        }
        [NonSerialized]
        public _CModfitingObject ModfitingObject;

        /// <summary>
        /// 指定当前单位工程正在编辑某个对象(主要用于当前编辑对象通知给界面操作记录时候使用)
        /// </summary>
        /// <param name="sender">要编辑的对象实例</param>
        public void BeginModfity(object sender)
        {
            //if (ModfitingObject != null) throw new Exception("上次BeginModfity之后没有关闭！");
            if (ModfitingObject == null) ModfitingObject = new _CModfitingObject();
            ModfitingObject.Current = sender;
            ModfitingObject.FiledName = string.Empty;
        }

        /// <summary>
        /// 指定当前单位工程正在编辑某个对象(主要用于当前编辑对象通知给界面操作记录时候使用)
        /// </summary>
        /// <param name="sender">要编辑的对象实例</param>
        public void BeginModfity(object sender, string FliedName)
        {
            //if (ModfitingObject != null) throw new Exception("上次BeginModfity之后没有关闭！");
            if (ModfitingObject == null) ModfitingObject = new _CModfitingObject();
            ModfitingObject.Current = sender;
            ModfitingObject.FiledName = FliedName;
        }

        /// <summary>
        /// 单位工程完成上次BeginModfity编辑
        /// </summary>
        public void EndModfity()
        {
            //ModfitingObject.Init();
        }

        public _UnitProject()
            : base()
        {
            this.Init();
            this.ImageIndex = 2;
            //this.Directory = new _Directory(this);
        }

        public override void Ready(_StructSource p_ds)
        {
            //this.StructSource = new _StructSource();
            //this.StructSource.UnitjBuilder();

              DataTable t = null;
            try
            {

                foreach (DataTable table in p_ds.Tables)
                {
                    t = table;
                    this.StructSource.Tables[table.TableName].Merge(table);
                }
            }
            catch (Exception e)
            {
                //Debug.Show(p_ds, t.TableName);
            }

            if (StructSource.ModelInfomation != null)
            {
                {
                    if (StructSource.ModelInfomation.Get("文件类型") != null)
                    {
                        this.IsDZBS = StructSource.ModelInfomation.Get("文件类型").ToString().Equals("电子标书");
                    }
                    else
                    { this.IsDZBS = false; }

                }
            }
            _ObjectSource.GetObject(this, this.StructSource.ModelProject.Rows[0]);
        }

        public _UnitProject(_COBJECTS p_Info)
            : base(p_Info)
        {
            this.ImageIndex = 2;
            this.Directory = new _Directory(this);
        }



        public override void Init()
        {
            base.Init();
            //单位工程的结构数据集合
            this.StructSource = new _StructSource();
            this.StructSource.UnitjBuilder();
            this.ObjectType = EObjectType.UnitProject;
            //记录模板操作临时数据
            this.DataTemp = new _AppDataTemp();
            //单位工程信息的所有数据        
            //this.DataObject.Add("基本数据", new CBaseData());
            this.DataObject.Add("库对象", new _Library());
            //this.DataObject.Add("分部分项", new _SubSegments(this));
            //this.DataObject.Add("汇总分析", new _Metaanalysis(this));
            //this.DataObject.Add("其他项目", new _OtherProject(this));
            //this.DataObject.Add("用途类别汇总", new YTLBSummaryList(this));
            //this.DataObject.Add("措施项目", new _MeasuresProject(this));
            //this.DataObject.Add("参数设置", new _ParameterSettings(this));
            //this.DataObject.Add("工程历史", new _History());
            //this.NonSeriObject.Add("工程统计", new _Project_Statistics(this));
            this.NonSeriObject.Add("子目增加费", new _IncreaseCosts(this));
            //this.NonSeriObject.Add("子目临时计算", new TemporaryCalculate(this));
            //this.NonSeriObject.Add("工料机汇总", new _List());
            //单位工程中的附加功能数据
            this.Reveal = new _Reveal(this);
            this.Property = new _Un_Property(this);
        }


        /// <summary>
        /// 清单规则
        /// </summary>
        public override string QDGZ
        {
            set { base.QDGZ = value; /*this.Property.DLibraries.ListGallery.Rule = value;*/ }
            get { return base.QDGZ; }
        }
        /// <summary>
        /// 定额规则
        /// </summary>
        public override string DEGZ
        {
            set { base.DEGZ = value; /*this.Property.DLibraries.FixedLibrary.Rule = value;*/ }
            get { return base.DEGZ; }
        }

        /// <summary>
        /// 清单库名称
        /// </summary>
        public override string QDLibName
        {
            set { base.QDLibName = value; /*this.Property.DLibraries.ListGallery.LibName = value;*/ }
            get { return base.QDLibName; }
        }

        /// <summary>
        /// 定额库名称
        /// </summary>
        public override string DELibName
        {
            set { base.DELibName = value; /*this.Property.DLibraries.FixedLibrary.LibName = value;*/ }
            get { return base.DELibName; }
        }

        /// <summary>
        /// 图集库名称
        /// </summary>
        public override string TJLibName
        {
            set { base.TJLibName = value; /*this.Property.DLibraries.AtlasGallery.LibName = value;*/ }
            get { return base.TJLibName; }
        }

        public override int ObjectKey
        {
            get
            {
                return 0;
            }
            set
            {
                base.ObjectKey = value;
            }
        }
        /// <summary>
        /// 计价基础
        /// </summary>
        public int JJJC { get; set; }
        /// <summary>
        /// 单位工程模板类
        /// </summary>
        public _AppDataTemp DataTemp = null;

        #endregion

        #region IDataSerializable 成员


        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            if (e is _Files)
            {
                this.Files = e as _Files;
            }

            _Engineering en = e as _Engineering;
            if (en != null)
            {
                en.StrustObject.Add(this.ID, this);
            }

            this.Reveal = new _Reveal(this);
            this.Parent = en;
            if (this.Property == null)
            {
                this.Property = new _Un_Property(this);
            }
            this.NonSeriObject = new _DataObjectList();
            this.NonSeriObject.Add("工程统计", new _Project_Statistics(this));
            this.NonSeriObject.Add("子目增加费", new _IncreaseCosts(this));
            this.NonSeriObject.Add("子目临时计算", new TemporaryCalculate(this));
            this.NonSeriObject.Add("工料机汇总", new _List());
            this.Property.SubSegments.InSerializable(this);
            this.Property.MeasuresProject.InSerializable(this);
            this.Property.OtherProject.InSerializable(this);
            this.Property.Statistics.Calculate();
        }

        /// <summary>
        /// 用于暂存 活动ID
        /// </summary>
        public int ActiviteId { get; set; }


        #endregion

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return new System.Xml.Schema.XmlSchema();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {

        }
    }
}
