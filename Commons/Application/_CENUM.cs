/*
    定义枚举
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 所有数据类型的状态枚举
    /// </summary>
    public enum EObjectState
    {
        /// <summary>
        /// 默认的对象状态为了兼容数据此对象不明如何控制使用
        /// </summary>
        Undefined = -1,
        /// <summary>
        /// 当前对象是新创建的对象(创建的新对象没有提交到容器中)
        /// </summary>
        Creating = 0,
        /// <summary>
        /// 当前对象已经创建结束 (已经被添加到容器工程业务中)
        /// </summary>
        Created = 1,
        /// <summary>
        /// 当前对象上次保存一来没有发生过变化
        /// </summary>
        UnChange = 2,
        /// <summary>
        /// 当前对象正处于修改状态
        /// </summary>
        Modify = 3,
        /// <summary>
        /// 当前对象处于删除状态(一搬情况此状态发生在仅标记删除的时候)
        /// </summary>
        Delete = 4,
        /// <summary>
        /// 删除撤销
        /// </summary>
        UnDelete = 5,
        /// <summary>
        /// 修改中的状态
        /// </summary>
        Modifing = 6,
        /// <summary>
        /// 容器对象专用(容器对象正在添加子项目时候)
        /// </summary>
        Appending = 7
    }

    /// <summary>
    /// 用户皮肤色彩定义枚举
    /// </summary>
    public enum EUserColor
    {
        /// <summary>
        /// 默认值
        /// </summary>
        Default = 0,
        /// <summary>
        /// 系统定义值
        /// </summary>
        System = 1,
        /// <summary>
        /// 客户自定义
        /// </summary>
        Custom = 2
    }

    /// <summary>
    /// 处理业务对象类型(当前业务对象)
    /// </summary>
    public enum EBObjectType
    {
        /// <summary>
        /// 根据打开的文件而定
        /// </summary>
        Auto = 0,
        /// <summary>
        /// 定义一个项目业务
        /// </summary>
        PROJECT = 1,
        /// <summary>
        /// 定义一个单项工程业务
        /// </summary>
        Engineering = 2,
        /// <summary>
        /// 定义一个单位工程业务
        /// </summary>
        UnitProject = 3,
    }

    /// <summary>
    /// 当前业务的容器类型(目前为 项目容器与单项工程容器)
    /// </summary>
    public enum EContainer
    {
        /// <summary>
        /// 定义一个项目业务
        /// </summary>
        ProjectContainer = 1,
        /// <summary>
        /// 定义一个单项工程业务
        /// </summary>
        EngineeringContainer = 2,
    }

    /// <summary>
    /// 业务对象类型用于CObject类型处理
    /// </summary>
    public enum EObjectType
    {
        Default = -1,
        PROJECT = 0,//项目
        Engineering = 1,//单项工程
        UnitProject = 2,//单位工程
        Proj_DZBS = 3//电子标书
    }

    /// <summary>
    /// 应用程序处理的类型
    /// </summary>
    public enum CAppType
    {
        /// <summary>
        /// 应用程序类型不存在
        /// </summary>
        NotExist = -1,
        /// <summary>
        /// 应用程序类型存在
        /// </summary>
        Exist = 1,
        /// <summary>
        /// 单位工程类型（如果应用程序类型为单位工程 则只能在创建单独单位工程业务）
        /// </summary>
        UnitProject = 2
    }

    /// <summary>
    /// 清单结构体
    /// </summary>		
    public struct 操作类型
    {
        /// <summary>
        /// Oracle链接对象名称
        /// </summary>			
        public const int 项目 = 0;
        /// <summary>
        /// SqlServer链接对象名称
        /// </summary>
        public const int 单项工程 = 1;
        /// <summary>
        /// OlEDB链接对象名称
        /// </summary>
        public const int 单位工程 = 2;

    }


    /*以下为2011年10月15日重新定义的枚举变量*/
    /// <summary>
    /// 业务容器类型
    /// </summary>
    public enum EBusinessType
    {
        /// <summary>
        /// 枚举为容器
        /// </summary>
        Container = 1,
        /// <summary>
        /// 枚举为非容器
        /// </summary>
        NotContainer = 2
    }

    /// <summary>
    /// 工作流类型(目前的类型只有2个容器类型 和一个非容器类型 以后扩充的时候添加)
    /// </summary>
    public enum EWorkFlowType
    {
        /// <summary>
        /// 默认当前工作流还不存在
        /// </summary>
        None = -1,
        /// <summary>
        /// 项目类型(容器类型)
        /// </summary>
        PROJECT = 0,//项目
        /// <summary>
        /// 单项工程类型(容器类型)
        /// </summary>
        Engineering = 1,//单项工程
        /// <summary>
        /// 单位工程类型(非容器类型)
        /// </summary>
        UnitProject = 2//单位工程
    }

    /// <summary>
    /// 变量类型
    /// </summary>
    public enum EVariable
    {
        项目变量 = 0,
        单位工程 = 1,
        清单变量 = 2,
        子目变量 = 3
    }


    /// <summary>
    /// 分部分项类型
    /// </summary>
    public enum ESubSegmentType
    {
        清单 = 0,
        子目 = 1
    }
    /// <summary>
    /// 信息类别
    /// </summary>
    public enum EInfoType
    {
        节点 = 0,
        清单 = 1,
        子目 = 2
    }

    public enum EListType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,
        /// <summary>
        /// 专业
        /// </summary>
        Professional = 1,
        /// <summary>
        /// 章
        /// </summary>
        Chapter = 2,
        /// <summary>
        /// 节
        /// </summary>
        Festival = 3
    }

    /// <summary>
    /// 用途类别
    /// </summary>
    public enum UseType
    {
        ///// <summary>
        ///// 暂无用途
        ///// </summary>
        //暂无用途,
        /// <summary>
        /// 甲供材料
        /// </summary>
        甲供材料,
        /// <summary>
        /// 甲定乙供材料
        /// </summary>
        甲定乙供材料,
        /// <summary>
        /// 评标指定材料
        /// </summary>
        评标指定材料,
        /// <summary>
        /// 暂定价材料
        /// </summary>
        暂定价材料
    }

    /// <summary>
    /// 工料机类别
    /// </summary>
    public enum QuantityUnitType
    {
        /// <summary>
        /// 分部分项工料机
        /// </summary>
        _SubheadingsQuantityUnitInfo,
        /// <summary>
        /// 分部分项组成工料机
        /// </summary>
        _QuantityUnitComponentInfo,
        /// <summary>
        /// 措施项目工料机
        /// </summary>
        _MSubheadingsQuantityUnitInfo,
        /// <summary>
        /// 措施项目组成工料机
        /// </summary>
        _MQuantityUnitComponentInfo
    }

    /// <summary>
    /// 关系枚举
    /// </summary>
    public enum ERelation
    {
        等于,
        大于,
        小于,
        大于等于,
        小于等于,
        区间
    }

    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        Normal,
        /// <summary>
        /// 正在添加
        /// </summary>
        AreAdd,
        /// <summary>
        /// 修改状态
        /// </summary>
        Update,
        /// <summary>
        /// 替换状态
        /// </summary>
        Replace,
        /// <summary>
        /// 计算状态
        /// </summary>
        Calculate
    }

    /// <summary>
    /// 数量合类别
    /// </summary>
    public enum SLHType
    {
        /// <summary>
        /// 工料机汇总无组成数量合
        /// </summary>
        GLJHZWSLH,
        /// <summary>
        /// 工料机汇总含机械数量合
        /// </summary>
        GLJHZJSLH,
        /// <summary>
        /// 工料机汇总含配合比数量合
        /// </summary>
        GLJHZPSLH,
        /// <summary>
        /// 工料机汇总含组成数量合
        /// </summary>
        GLJHZZSLH,
        /// <summary>
        /// 分部分项无组成数量合
        /// </summary>
        FBFXWSLH,
        /// <summary>
        /// 分部分项含机械数量合
        /// </summary>
        FBFXJSLH,
        /// <summary>
        /// 分部分项含配合比数量合
        /// </summary>
        FBFXPSLH,
        /// <summary>
        /// 分部分项含组成数量合
        /// </summary>
        FBFXZSLH,
        /// <summary>
        /// 措施项目无组成数量合
        /// </summary>
        CSXMWSLH,
        /// <summary>
        /// 措施项目含机械数量合
        /// </summary>
        CSXMJSLH,
        /// <summary>
        /// 措施项目含配合比数量合
        /// </summary>
        CSXMPSLH,
        /// <summary>
        /// 措施项目含组成数量合
        /// </summary>
        CSXMZSLH
    }

    /// <summary>
    /// 对齐方式
    /// </summary>
    public enum Alignment
    {
        居左,
        居中,
        居右
    }

    /// <summary>
    /// 是与否
    /// </summary>
    public enum Whether
    {
        是,
        否
    }

    /// <summary>
    /// 横向,纵向
    /// </summary>
    public enum Direction
    {
        横向,
        纵向
    }

    /// <summary>
    /// 展示类型
    /// </summary>
    public enum ERevealType
    {
        /// <summary>
        /// 默认为全部
        /// </summary>
        Default = 0,
        汇总分析,
        分部分项,
        措施项目,
        项目工料机汇总
    }

    /// <summary>
    /// 寻址方向
    /// </summary>
    public enum EDirection
    {
        /// <summary>
        /// 不寻址 或者仅仅自己
        /// </summary>
        None = -1,
        /// <summary>
        /// 默认方向
        /// </summary>
        Default = 0,
        /// <summary>
        /// 向上寻址
        /// </summary>
        UP = 1,
        /// <summary>
        /// 向下寻址
        /// </summary>
        Down = 2,
        /// <summary>
        /// 双向寻址
        /// </summary>
        TwoWay = 3,
        /// <summary>
        /// 自己
        /// </summary>
        Self = 4

    }
    /// <summary>
    /// 工程信息 创建类型
    /// </summary>
    public enum InformationType
    {
        建筑装饰 = 0,
        给排水雨水 = 1,
        采暖热源 = 2,
        燃气管道 = 3,
        工业管道 = 4,
        水灭火 = 5,
        气体灭火 = 6,
        泡沫灭火 = 7,
        消火栓 = 8,
        火灾报警 = 9,
        通风空调 = 10,
        电气设备 = 11,
        智能综合 = 12
    }
}
