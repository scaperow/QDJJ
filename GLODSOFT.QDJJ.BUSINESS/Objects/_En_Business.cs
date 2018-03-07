/*
 单项工程业务具体操作
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;

namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 单项工程的业务对象
    /// </summary>
    public class _En_Business : _BusContainer
    {

        public _En_Business():base()
        {
            //当前工作流类型为项目
            this.WorkFlowType = EWorkFlowType.Engineering;
          
        }

        /// <summary>
        /// 创建一个新的单项工程(对象状态修改为 创建)
        /// </summary>
        public override void Create()
        {
            //设置当前对象为单项工程
            this.Current = new _Engineering();
        }

        /// <summary>
        /// 结束创建新的项目(对象状态修改为 结束创建)
        /// </summary>
        public override void EndCreate()
        {
            
        }

        /// <summary>
        /// 为指定的单项工程批量添加单位工程
        /// </summary>
        /// <param name="table"></param>
        public override void  BatchAdd(_Directory[] p_Infos)
        {
 	         base.BatchAdd(p_Infos);
        }
       
        /// <summary>
        /// 当打开文件并获取到对象的时候调用此方法为当前单项工程做载入的工作
        /// </summary>
        /// <param name="p_info"></param>
        public override void Load(_COBJECTS p_info)
        {
         
        }
    }
}
