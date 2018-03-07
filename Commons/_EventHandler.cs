/*
 自定义事件
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 当前业务对象编辑的时候事件处理
    /// </summary>
    public delegate void  EditEventHandler();

    /// <summary>
    /// 当业务对象集合发生变化时候激发
    /// </summary>
    public delegate void  ListChangeEventHandler();

    /// <summary>
    /// 当全局配色方案发生变化时候调用
    /// </summary>
    public delegate void GlobalStyleChangeHandler();

    /// <summary>
    /// 当需要Grid使用特殊的配色应用是后调用
    /// </summary>
    /// <param name="p_RowObject"></param>
    /// <param name="p_StyleInfo"></param>
    public delegate void SetRowColorHandler(object p_RowObject, _SchemeColor p_SchemeColor, DevExpress.Utils.AppearanceObject appearance);

    /// <summary>
    /// 当库发生变化后执行后调用
    /// </summary>
    public delegate void LibraryChangeHandler(GOLDSOFT.QDJJ.COMMONS.LIB._Library._LibraryData p_Library);

    /// <summary>
    /// 当AForm窗体发生变化时候激发
    /// </summary>
    public delegate void ModelChangeHandler(object sender,object args);

    /// <summary>
    /// 当项目工程统计的时候激发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void BeforeStatisticalHandler(object sender,object args);

    /// <summary>
    /// 当项目工程统计的时候激发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void AfterStatisticaledHandler(object sender, object args);

    /// <summary>
    /// 当项目工程统计的时候激发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void DoStatisticalHandler(object sender, object args);


    /// <summary>
    /// 当统计完成后调用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void StatisticalCompletedHandler(object sender,object args);

    /// <summary>
    /// 还原xml对象的时候激发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void RevertXmlObject(object sender,object args);

    /// <summary>
    /// 当线程池完成操作时候激发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void RunTreadPoolCompleted(object sender, object args);

    /// <summary>
    /// 当前模块发生编辑操作时候激发
    /// </summary>
    /// <param name="sender">激发源</param>
    /// <param name="args">一般参数是属性对象</param>
    public delegate void ModelEditedHandler(object sender, object args);

   /// <summary>
    /// 当前模块发生操作动作的时候激发
    /// </summary>
    /// <param name="sender">激发源</param>
    /// <param name="args">一般参数是属性对象</param>
    public delegate void ModelActioinHandler(object sender,object args);
    
    /// <summary>
    /// 界面需要进度条初始化的地方此处编写
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void WorkerInitHandler(object sender,object args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void SetLogContentHandler(object sender, object args);
    /// <summary>
    /// 发生在保存之前
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void BeforeSaveHandler(object sender, object args);
    /// <summary>
    /// 发生在保存之后
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void AfterSaveHandler(object sender, object args);
 
    
}
