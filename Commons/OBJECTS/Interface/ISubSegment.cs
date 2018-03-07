/*
 分部分项基础数据源接口
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 分部分项数据统计接口实现 实现此接口用于项目统计中的数据统计使用
    /// </summary>
    public interface ISubSegment
    {

        #region ------------------------------基础数据----------------------------------
        ISubSegment IParent
        {
            get;
        }
        long Sort
        {
            get;
            set;
        }
        long Key
        {
            get;
            set;
        }

        long PKey
        {
            get;
            set;
        }

        string ProName
        {
            get;
            set;
        }

        /// <summary>
        /// ID
        /// </summary>
        int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 父级ID （专业章节全部显示的时候）
        /// </summary>
        int PARENTID
        {
            get;
            set;
        }

        /// <summary>
        /// 专业的时候fuid
        /// </summary>
        int PPARENTID
        {
            get;
            set;
        }
        /// <summary>
        /// 在章的时候使用父级ID
        /// </summary>
        int CPARENTID
        {
            get;
            set;
        }
       
        /// <summary>
        /// 不显示任何章节时的父id
        /// </summary>
        int FPARENTID
        {
            get;
            set;
        }
        /// <summary>
        /// 序   号
        /// </summary>
        int XH
        {
            get;
            set;
        }
        /// <summary>
        /// 项目编码
        /// </summary>
        string XMBM
        {
            get;
            set;
        }
        /// <summary>
        /// 原始项目编码
        /// </summary>
        string OLDXMBM
        {
            get;
            set;
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        string XMMC
        {
            get;
            set;
        }
        /// <summary>
        /// 单   位
        /// </summary>
        string DW
        {
            get;
            set;
        }
        /// <summary>
        /// 特   项
        /// </summary>
        string TX
        {
            get;
            set;
        }
        /// <summary>
        /// 类   别
        /// </summary>
        string LB
        {
            get;
            set;
        }
        /// <summary>
        /// 检查标记
        /// </summary>
        bool JCBJ
        {
            get;
            set;
        }
        /// <summary>
        /// 复核标记
        /// </summary>
        bool FHBJ
        {
            get;
            set;
        }
        /// <summary>
        /// 主要清单
        /// </summary>
        bool ZYQD
        {
            get;
            set;
        }
        /// <summary>
        /// 项目特征
        /// </summary>
        string XMTZ
        {
            get;
            set;
        }
        /// <summary>
        /// 锁定单价
        /// </summary>
        bool SDDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 工程量计算式
        /// </summary>
        string GCLJSS
        {
            get;
            set;
        }


        /// <summary>
        /// 局部汇总
        /// </summary>
        bool JBHZ
        {
            get;
            set;
        }
        /// <summary>
        /// 章节位置
        /// </summary>
        string ZJWZ
        {
            get;
            set;
        }
        /// <summary>
        /// 降效
        /// </summary>
        bool JX
        {
            get;
            set;
        }
        /// <summary>
        /// 檐高类别
        /// </summary>
        string YGLB
        {
            get;
            set;
        }
        /// <summary>
        /// 输出
        /// </summary>
        bool SC
        {
            get;
            set;
        }
        /// <summary>
        /// 取费设置
        /// </summary>
        string QFSZ
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        string BEIZHU
        {
            get;
            set;
        }
        /// <summary>
        /// 来源的库
        /// </summary>
        string LibraryName
        {
            get;
            set;
        }
        /// <summary>
        /// 来源
        /// </summary>
        string LY
        {
            get;
            set;
        }
        /// <summary>
        /// 锁定清单
        /// </summary>
        bool SDQD
        {
            get;
            set;
        }
        /// <summary>
        /// 是否分包
        /// </summary>
        bool SFFB
        {
            get;
            set;
        }
        /// <summary>
        /// 含量
        /// </summary>
        decimal HL
        {
            get;
            set;
        }
        /// <summary>
        /// 工程量
        /// </summary>
        decimal GCL
        {
            get;
            set;
        }
        /// <summary>
        /// 直接调价
        /// </summary>
        decimal ZJTJ
        {
            get;
            set;
        }
        /// <summary>
        /// 综合单价
        /// </summary>
        decimal ZHDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 综合合价
        /// </summary>
        decimal ZHHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 直接费单价
        /// </summary>
        decimal ZJFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 人工费单价
        /// </summary>
        decimal RGFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 材料费单价
        /// </summary>
        decimal CLFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 机械费单价
        /// </summary>
        decimal JXFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 主材费单价
        /// </summary>
        decimal ZCFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 设备费单价
        /// </summary>
        decimal SBFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 管理费单价
        /// </summary>
        decimal GLFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 利润单价
        /// </summary>
        decimal LRDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 风险单价
        /// </summary>
        decimal FXDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 规费单价
        /// </summary>
        decimal GFDJ
        {
            get;
            set;
        }
        /// <summary>
        /// 税金单价
        /// </summary>
        decimal SJDJ
        {
            get;
            set;
        }

        /// <summary>
        /// 定额材机
        /// </summary>
        string DECJ
        {
            get;
            set;
        }

        /// <summary>
        /// 界面显示的清单序号
        /// </summary>
        string FXH
        {
            get;
            set;
        }
        /// <summary>
        /// 消耗量
        /// </summary>
        decimal XHL
        {
            get;
            set;
        }

     
        /// <summary>
        /// 评标指定金额
        /// </summary>
         decimal PBZD
        {
            get;
            set;
        }

        /// <summary>
        /// 乙供金额
        /// </summary>
         decimal YGJE
        {
            get;
            set;
        }

        #endregion

        #region ---------------------------计算类属性--------------------------
        /// <summary>
        /// 直接费合价
        /// </summary>
        decimal ZJFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 人工费合价
        /// </summary>
        decimal RGFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 材料费合价
        /// </summary>
        decimal CLFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 机械费合价
        /// </summary>
        decimal JXFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 主材费合价
        /// </summary>
        decimal ZCFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 设备费合价
        /// </summary>
        decimal SBFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 管理费合价
        /// </summary>
        decimal GLFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 利润合价
        /// </summary>
        decimal LRHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 风险合价
        /// </summary>
        decimal FXHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 规费合价
        /// </summary>
        decimal GFHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 税金合价
        /// </summary>
        decimal SJHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 价差合计
        /// </summary>
        decimal JCHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 差价合计
        /// </summary>
        decimal CJHJ
        {
            get;
            set;
        }
        /// <summary>
        /// 暂估金额
        /// </summary>
        decimal ZGJE
        {
            get;
            set;
        }
        /// <summary>
        /// 甲供金额
        /// </summary>
        decimal JGJE
        {
            get;
            set;
        }

        /// <summary>
        /// 分包金额
        /// </summary>
        decimal FBJE
        {
            get;
            set;
        }


        
        /// <summary>
        /// 计算基础
        /// </summary>
        string JSJC
        {
            get;
            set;
        }
        
        /// <summary>
        /// 费率
        /// </summary>
        string FL
        {
            get;
            set;
        }

        
        /// <summary>
        /// 组价方式
        /// </summary>
        string ZJFS
        {
            get;
            set;
        }


        
        /// <summary>
        /// 获取或设置：清单编号
        /// </summary>
        string QDBH
        {
            get;
            set;
        }
        #endregion
        
        
    }
}
