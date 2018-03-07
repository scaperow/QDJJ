/*2011年10月15日 业务重新构造业务实现
 *所有业务的基础类别
 *分类:容器业务(项目业务，非项目业务)  非容器业务(单位工程等单体对象业务)
 *生存周期 1.业务创建 2.为创建的业务做准备工作 3.结束创建业务 4.操作 5.释放业务
 *每个业务都有自己的数据对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.DATA;
using System.Collections;
using System.IO;


namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 所有业务的抽象基类
    /// </summary>
    public abstract class _Business
    {
        #region ----------------------------------属性---------------------------
        /// <summary>
        /// 当前业务的数据连接对象
        /// </summary>
        private _ObjectDataBase m_DataBase = null;

        /// <summary>
        /// 当前业务的数据连接对象(当一个业务被创建 或者被打开的时候此对象创建连接 必须在业务关闭时候释放)
        /// </summary>
        public _ObjectDataBase DataBase
        {
            get
            {
                return this.m_DataBase;
            }
            set
            {
                this.m_DataBase = value;
            }
        }


        /// <summary>
        /// 开启链接
        /// </summary>
        public virtual void OpenDataBase()
        {
            ///创建链接
            m_DataBase = new _ObjectDataBase(string.Format(_DataBase.AccessConnString, this.Current.Files.FullName));
        }

        /// <summary>
        /// 关闭链接
        /// </summary>
        public virtual void CloseDataBase()
        {

        }


        /// <summary>
        /// 当前业务的业务类别
        /// </summary>
        private EBusinessType m_BusinessType;

        /// <summary>
        /// 当前业务的数据对象
        /// </summary>
        private _COBJECTS m_Current;

        /// <summary>
        /// 获取或设置当前业务的数据对象
        /// </summary>
        public virtual _COBJECTS Current
        {
            get
            {
                return this.m_Current;
            }
            set
            {
                this.m_Current = value;
            }
        }


        /// <summary>
        /// 获取或设置当前业务的业务类别
        /// </summary>
        public EBusinessType BusinessType
        {
            get
            {
                return this.m_BusinessType;
            }
            set
            {
                this.m_BusinessType = value;
            }
        }

        /// <summary>
        /// 当前容器对象的工作流状态
        /// </summary>
        private EWorkFlowType m_WorkFlowType = EWorkFlowType.None;

        /// <summary>
        /// 获取或设置当前的工作流状态
        /// </summary>
        public EWorkFlowType WorkFlowType
        {
            get { return this.m_WorkFlowType; }
            set { this.m_WorkFlowType = value; }
        }

        #endregion

        #region ----------------------------------业务生存周期----------------------------------

        /// <summary>
        /// 为当前容器创建新的子项目
        /// </summary>
        public virtual void Create() { }

        /// <summary>
        /// 首次创建虚方法
        /// </summary>
        public virtual void FristEndCreate()
        { 
        }

        /// <summary>
        /// 结束创建新的子项目(确认创建后的操作)
        /// </summary>
        public virtual void EndCreate()
        {
            ///结束创建初始化对象
            APP.Methods.Init(this.Current);
        }

        /// <summary>
        /// 为当前业务做初始化准备
        /// </summary>
        public virtual void Init() { }

        /// <summary>
        /// 将当前对象导入到源对象中
        /// </summary>
        /// <param name="p_source">源对象</param>
        /// <param name="p_current">当前对象</param>
        public virtual void ImportIn(_COBJECTS p_source, ArrayList p_currList) { }

        /// <summary>
        /// 当前数据替换源数据
        /// </summary>
        /// <param name="p_source">源数据</param>
        /// <param name="p_curr">当前数据</param>
        public virtual _COBJECTS Replace(_COBJECTS p_source, _COBJECTS p_curr) { return null; }

        /// <summary>
        /// 关闭当前业务
        /// </summary>
        public virtual void Close() { }

        /// <summary>
        /// 加载已经存在的业务(通常打开文件获取对象后调用此方法)
        /// </summary>
        /// <param name="p_info"></param>
        public virtual void Load(_COBJECTS p_info) { }
        /// <summary>
        /// 加载已经存在项目中的单位工程(保证一次链接完成，p_OnlyOneConn为true不关闭现有的业务链接)
        /// </summary>
        /// <param name="p_info"></param>
        /// <param name="p_OnlyOneConn"></param>
        public virtual void Load(_COBJECTS p_info, bool p_OnlyOneConn) { }

        /// <summary>
        /// 尝试初始化一个数据对象
        /// </summary>
        /// <param name="p_info"></param>
        public virtual void InitDataObject(_COBJECTS p_info)
        {

        }

        /// <summary>
        /// 提供通过文件加载项目到当前业务的方法
        /// </summary>
        /// <param name="p_files">文件对象</param>
        public virtual CResult Load(_Files p_files) { return null; }

        /// <summary>
        /// 打开一个业务文件到
        /// </summary>
        /// <returns></returns>
        public virtual CResult Open(_Files p_files) { return null; }

        /// <summary>
        /// 保存当前业务
        /// </summary>
        /// <returns></returns>
        public virtual CResult Save() { return null; }

        public virtual void Calculate()
        { 
        }

        /// <summary>
        /// 设置写入加密锁号
        /// </summary>
        public virtual void SetKeyNo()
        {
            this.setJMSH(this.Current as _COBJECTS);
            this.setJQH(this.Current as _COBJECTS);
        }
        /// <summary>
        /// 设置写入加密锁号
        /// </summary>
        /// <param name="info">单位工程或者项目</param>
        public virtual void SetKeyNo(_COBJECTS info)
        {
            this.setJMSH(info);
            this.setJQH(info);
        }

        /// <summary>
        /// 设置加密锁号 和时间
        /// </summary>
        /// <returns></returns>
        private  void setJMSH(_COBJECTS info)
        {
            if (info == null) return;
            //锁号,锁号,锁号
           // _COBJECTS info = this.Current as _COBJECTS;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string curr = APP.GoldSoftClient.GlodSoftDiscern.CurrNo;
            string[] keys = null;
            if (info.JMSH != string.Empty)
            {//如果不存在写入
                keys = info.JMSH.Split(',');
                if (!this.isExist(curr, keys))
                {
                    info.JMSH += string.Format(",{0}",curr);
                    info.Time += string.Format(",{0}", time);
                }
            }
            else
            {
                //直接写入
                info.JMSH = curr;
                info.Time = time;
            }
        }

        /// <summary>
        /// 设置机器号
        /// </summary>
        private  void setJQH(_COBJECTS info)
        {
            if (info == null) return;
            string curr = APP.MachineNumber;
            string[] keys = null;
            if (info.JQH != string.Empty)
            {//如果不存在写入
                keys = info.JQH.Split(',');
                if (!this.isExist(curr, keys))
                {
                    info.JQH += string.Format(",{0}", curr);
                }
            }
            else
            {
                //直接写入
                info.JQH = curr;
               
            }
        }
       



        /// <summary>
        /// 指定字符串在字符串数组中是否存在
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strArr">字符串数组</param>
        /// <returns>是否存在</returns>
        private bool isExist(string str, string[] strArr)
        {
            foreach (string s in strArr)
            {
                if (s == str)
                {
                    return true;
                }
            }
            return false;
        }


        public virtual void FastCalculate()
        {

        }
        #endregion
    }
}
