/*
 *  用于当前数据对象的基础类别(项目,单项工程,单位工程)
 *  1.本身数据输入当个
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _COBJECTS : IDataSerializable,IDisposable
    {

        #region -----------------------确定需要保留的成员------------------------

        /// <summary>
        /// 是否电子标书(默认为False)
        /// </summary>
        public bool IsDZBS = false;

        /// <summary>
        /// 为编辑重写的方法
        /// </summary>
        public virtual void BeginEdit(object sender)
        {
            
        }

        #region -----------------------字段名称----------------------------------
        private int _id;
        private int _pid = 0;
        private string _name = string.Empty;
        private string _code = string.Empty;
        private string _qdgz = string.Empty;
        private string _degz = string.Empty;
        private string _pgcdd = string.Empty;
        private int _pjfcx = 0;
        private string _pnsdd = string.Empty;
        private string _creator = string.Empty;
        private string _editor = string.Empty;
        private DateTime _fistdatetime = DateTime.Now;
        private DateTime _editdatetime = DateTime.Now;
        private int _sort = 0;
        private int _deep = 0;
        private string _nodename = string.Empty;
        private string _plaitno = string.Empty;
        private string _reviewname = string.Empty;
        private string _plaitname = string.Empty;
        private DateTime _plaitdate = DateTime.Now;
        private DateTime _reviewdate = DateTime.Now;
        private string _protype = string.Empty;
        private string _prftype = string.Empty;
        private string _templatetype = string.Empty;
        private string _remark = string.Empty;
        private string _qdlibname = string.Empty;
        private string _delibname = string.Empty;
        private string _tjlibname = string.Empty;
        private string _jmsh = string.Empty;
        private string _jqh = string.Empty;
        private string _Time = string.Empty;
        private int _key = 0;
        private int _pkey = 0;
        private int _objectKey = 1;
        private bool _IsCalculated = false;
        private string _PassWord = string.Empty;
        private int _ImageIndex = 0;
        private string _State = "0";//默认为正常


        public string State
        {
            get
            { return this._State; }
            set
            {
                this._State = value;
            }
        }

        public int ImageIndex
        {
            get
            {
                return this._ImageIndex;
            }
            set
            {
                this._ImageIndex = value;
            }
        }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string PassWord
        {
            get
            {
                return _PassWord;
            }
            set
            {
                this._PassWord = value;
            }
        }

        /// <summary>
        /// 是否重新计算
        /// </summary>
        public bool IsCalculated
        {
            get
            {
                return this._IsCalculated;
            }
            set
            {
                this._IsCalculated = value;
            }
        }

        /// <summary>
        /// 对象的主编号Key
        /// </summary>
        public virtual int ObjectKey
        {
            get
            {
                return _objectKey;
            }
            set
            {
                this._objectKey = value;
            }
        }

        /// <summary>
        /// 树形结构key
        /// </summary>
        public int Key
        {
            get
            { return this._key; }
            set
            { this._key = value; }
        }

        /// <summary>
        /// 树形结构PKey
        /// </summary>
        public int PKey
        {
            get
            { return this._pkey; }
            set
            { this._pkey = value; }
        }

        /// <summary>
        /// 获取或设置时间
        /// </summary>
        public string Time
        {
            get
            {
                return this._Time;
            }
            set
            {
                this._Time = value;
            }
        }

        /// <summary>
        /// 获取或设置机器号
        /// </summary>
        public string JQH
        {
            get
            {
                return this._jqh;
            }
            set
            {
                this._jqh = value;
            }
        }

        /// <summary>
        /// 加密锁号
        /// </summary>
        public string JMSH
        {
            get
            {
                return this._jmsh;
            }
            set
            {
                this._jmsh = value;
            }
        }
        /// <summary>
        /// 自编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 引用编号
        /// </summary>
        public int PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 清单规则
        /// </summary>
        public virtual string QDGZ
        {
            set { _qdgz = value; }
            get { return _qdgz; }
        }
        /// <summary>
        /// 定额规则
        /// </summary>
        public virtual string DEGZ
        {
            set { _degz = value; }
            get { return _degz; }
        }
        /// <summary>
        /// 工程地点
        /// </summary>
        public string PGCDD
        {
            set { _pgcdd = value; }
            get { return _pgcdd; }
        }
        /// <summary>
        /// 计费程序
        /// </summary>
        public int PJFCX
        {
            set { _pjfcx = value; }
            get { return _pjfcx; }
        }
        /// <summary>
        /// 纳税地点
        /// </summary>
        public string PNSDD
        {
            set { _pnsdd = value; }
            get { return _pnsdd; }
        }
        /// <summary>
        /// 创建者
        /// </summary>
        public string CREATOR
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 最后编辑人
        /// </summary>
        public string EDITOR
        {
            set { _editor = value; }
            get { return _editor; }
        }
        /// <summary>
        /// 首次创建时间
        /// </summary>
        public DateTime FISTDATETIME
        {
            set { _fistdatetime = value; }
            get { return _fistdatetime; }
        }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime EDITDATETIME
        {
            set { _editdatetime = value; }
            get { return _editdatetime; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 深度
        /// </summary>
        public int Deep
        {
            set { _deep = value; }
            get { return _deep; }
        }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName
        {
            set { _nodename = value; }
            get { return _nodename; }
        }
        /// <summary>
        /// 编制人资格证号
        /// </summary>
        public string PlaitNo
        {
            set { _plaitno = value; }
            get { return _plaitno; }
        }
        /// <summary>
        /// 复核人
        /// </summary>
        public string ReviewName
        {
            set { _reviewname = value; }
            get { return _reviewname; }
        }
        /// <summary>
        /// 编制人
        /// </summary>
        public string PlaitName
        {
            set { _plaitname = value; }
            get { return _plaitname; }
        }
        /// <summary>
        /// 编制日期
        /// </summary>
        public DateTime PlaitDate
        {
            set { _plaitdate = value; }
            get { return _plaitdate; }
        }
        /// <summary>
        /// 复核日期
        /// </summary>
        public DateTime ReviewDate
        {
            set { _reviewdate = value; }
            get { return _reviewdate; }
        }
        /// <summary>
        /// 工程类别
        /// </summary>
        public string ProType
        {
            set { _protype = value; }
            get { return _protype; }
        }
        /// <summary>
        /// 模板类别
        /// </summary>
        public string TemplateType
        {
            set { _templatetype = value; }
            get { return _templatetype; }
        }
        /// <summary>
        /// 专业类别
        /// </summary>
        public string PrfType
        {
            set { _prftype = value; }
            get { return _prftype; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 清单库名称
        /// </summary>
        public virtual string QDLibName
        {
            set { _qdlibname = value; }
            get { return _qdlibname; }
        }
        /// <summary>
        /// 定额库名称
        /// </summary>
        public virtual string DELibName
        {
            set { _delibname = value; }
            get { return _delibname; }
        }
        /// <summary>
        /// 图集库名称
        /// </summary>
        public virtual string TJLibName
        {
            set { _tjlibname = value; }
            get { return _tjlibname; }
        }

        #endregion

        /// <summary>
        /// 当前基础类别的父类别(若为顶级类别此属性为null)
        /// </summary>
        [NonSerialized]
        private _COBJECTS m_Parent = null;
        /// <summary>
        /// 获取当前基础父类别
        /// </summary>
        public _COBJECTS Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        /// <summary>
        /// 克隆当前基础数据成员
        /// </summary>
        public virtual void Clone(_COBJECTS p_Info)
        {
            p_Info.QDGZ = this._qdgz;
            p_Info.DEGZ = this._degz;
            p_Info._pgcdd = this._pgcdd;
            p_Info._pjfcx = this._pjfcx;
            p_Info._pnsdd = this._pnsdd;
        }

        /// <summary>
        /// 获取或设置当前对象的所有数据
        /// </summary>
        public _StructSource StructSource;
        /// <summary>
        /// 空构造函数
        /// </summary>
        public _COBJECTS()
        {
            //构造数据对象
            this.Init();
        }

        /// <summary>
        /// 此方法没有调用之前当前对象仅仅作为实体使用
        /// 单位工程或项目成为业务对象的时候调用此方法
        /// </summary>
        /// <param name="p_ds"></param>
        public virtual void Ready(_StructSource p_ds)
        {
            this.StructSource = p_ds;
        }

        /// <summary>
        /// 构造一个源数据对象
        /// </summary>
        /// <param name="p_info">此数据对象所属创造类型</param>
        public _COBJECTS(_COBJECTS p_info)
        {

            m_Parent = p_info;
            this.Init();
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        public virtual void Init()
        {

            //构造数据对象
            this.NonSeriObject = new _DataObjectList();
            this.m_DataObject = new _DataObjectList();
            this.m_DataObject.Add("配置信息", new _Setting(this));
            this.m_DataObject.Add("基础信息", new _CBasis());
            this.m_StatusInfo = new _StatusInfo(this);
        }

        /// <summary>
        /// 直接添加到项目数据源中
        /// </summary>
        /// <returns></returns>
        public virtual _COBJECTS Add(_COBJECTS p_Info)
        {
            this.StrustObject.Add(p_Info.Directory.Key, p_Info);

            return p_Info;
        }

        #endregion

        /// <summary>
        /// 获取或设置元数据集合中指定键值得对象
        /// </summary>
        /// <param name="p_key"></param>
        /// <returns></returns>
        public virtual _COBJECTS this[long p_key]
        {
            get
            {
                if (this.StrustObject.ObjectList.ContainsKey(p_key))
                {
                    return this.StrustObject.ObjectList[p_key] as _COBJECTS;
                }
                return null;
            }
            set
            {
                if (this.StrustObject.ObjectList.ContainsKey(p_key))
                {
                    this.StrustObject.ObjectList[p_key] = value;
                }
            }
        }

        /// <summary>
        /// 当前对象的数据类型
        /// </summary>
        public EObjectType ObjectType = EObjectType.Default;

        /// <summary>
        /// 当前数据的状态类型
        /// </summary>
        public EObjectState ObjectState = EObjectState.Undefined;

        public bool NeedCalculate = true;

        /// <summary>
        /// 当前对象中的所有数据对象集合
        /// </summary>
        private _DataObjectList m_DataObject = null;

        /// <summary>
        ///获取或设置当前集合的数据对象
        /// </summary>
        public _DataObjectList DataObject
        {
            get
            {
                return this.m_DataObject;
            }
            set
            {
                this.m_DataObject = value;
            }
        }


        [NonSerialized]
        private _DataObjectList m_NonSeriObject = null;
        /// <summary>
        /// 不参与序列化的对象集合
        /// </summary>
        public _DataObjectList NonSeriObject
        {
            get
            {
                return this.m_NonSeriObject;
            }
            set
            {
                this.m_NonSeriObject = value;
            }
        }


        /// <summary>
        /// 当前对象的结构对象
        /// </summary>
        private _DataObjectList m_StrustObject = null;

        /// <summary>
        /// 获取或设置当前的结构对象(单位工程此对象为空)
        /// </summary>
        public _DataObjectList StrustObject
        {
            get
            {
                return this.m_StrustObject;
            }
            set
            {
                this.m_StrustObject = value;
            }
        }

        /// <summary>
        /// 当前数据对象的属性
        /// </summary>
        [NonSerialized]
        private _Property m_Property = null;

        /// <summary>
        /// 获取当前数据对象的属性(所有数据对象都从属性中调用)
        /// </summary>
        public _Property Property
        {
            get
            {
                return this.m_Property;
            }
            set
            {
                this.m_Property = value;
            }
        }



        /// <summary>
        /// 每次使用对象的时候初始化(此方请保证仅在APP.Methods中调用 其他地方不在使用)
        /// </summary>
        /// <param name="p_App"></param>
        /*public virtual void Init(_Application p_App)
        {
            this.m_Application = p_App;
        }*/



        #region ----------------------数据对象(不参与数据保存)--------------------------

        /// <summary>
        /// 当前对象的文件处理集
        /// </summary>
        [NonSerialized]
        private _Files m_Files = null;

        /// <summary>
        /// 获取或设置当前文件对象的文件处理集（此对象不序列化 每次需要保存的时候改变对象的值）
        /// </summary>
        public _Files Files
        {
            get
            {
                return this.m_Files;
            }
            set
            {
                this.m_Files = value;
            }
        }

        /// <summary>
        /// 用于配置如何处理当前的数据对象(数据访问接口)
        /// </summary>
        [NonSerialized]
        private IDataInterface m_DataInterFace = null;

        /// <summary>
        /// 用于配置如何处理当前数据对象(数据访问接口 需要对象操作时候进行配置)
        /// </summary>
        public IDataInterface DataInterFace
        {
            get
            {
                return this.m_DataInterFace;
            }
            set
            {
                this.m_DataInterFace = value;
            }
        }


        private _StatusInfo m_StatusInfo = null;
        /// <summary>
        /// 状态栏取值
        /// </summary>
        public _StatusInfo StatusInfo
        {
            get
            {
                return this.m_StatusInfo;
            }
            set
            {
                this.m_StatusInfo = value;
            }
        }


        #endregion

        #region------------------------配置对象--------------------------
        /// <summary>
        /// 当前对象锁定状态
        /// </summary>
        public bool IsLock
        {
            get
            {
                return this.Property.Setting.IsLock;
            }
        }


        /// <summary>
        /// 当前应用程序对象(初始化后生效)
        /// </summary>
        [NonSerialized]
        private _Application m_Application = null;
        /// <summary>
        /// 获取当前对象的应用程序对象(此对象只能通过Init方法初始化获得)
        /// </summary>
        public _Application Application
        {
            get
            {
                return this.m_Application;
            }
            set
            {
                this.m_Application = value;
            }
        }

        #endregion

        #region------------------------界面展示--------------------------
        /// <summary>
        /// 单位工程此对象为空
        /// </summary>
        private _Directory m_Directory = null;
        /// <summary>
        /// 获取当前界面的展示对象
        /// </summary>
        public _Directory Directory
        {
            get
            {
                return this.m_Directory;
            }
            set
            {
                this.m_Directory = value;
            }
        }

        /// <summary>
        /// 界面展示对象
        /// </summary>
        [NonSerialized]
        private _Reveal m_Reveal = null;

        /// <summary>
        /// 界面展示对象(此对象不参与保存 使用的时候实例化)
        /// </summary>
        public virtual _Reveal Reveal
        {
            get
            {
                return this.m_Reveal;
            }
            set
            {
                this.m_Reveal = value;
            }
        }

        #endregion

        #region------------------------操作对象--------------------------

        /// <summary>
        /// 为当前对象创建一个子对象
        /// </summary>
        /// <returns></returns>
        public virtual _COBJECTS Create()
        {

            return null;
        }



        /// <summary>
        /// 保存记录(可能为空)
        /// </summary>
        private _SaveInfoList m_SaveInfoList = null;

        /// <summary>
        /// 获取或设置保存记录
        /// </summary>
        public _SaveInfoList SaveInfoList
        {
            get
            {
                return this.m_SaveInfoList;
            }
            set
            {
                this.m_SaveInfoList = value;
            }
        }

        #endregion


        #region IDataSerializable 成员

        public virtual void OutSerializable()
        {

        }

        public virtual void InSerializable(object e)
        {

        }


        #endregion


        #region IDisposable 成员

        public void Dispose()
        {
            
        }

        #endregion
    }
}
