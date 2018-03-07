/**********************************************************************  
 *  
 *        CLR Version:  2.0.50727.3634  
 *        NameSpace:    GOLDSOFT.QDJJ.COMMONS.Information  
 *        FileName:     _InformationTable  
 *        
 *        Author:       李波
 *        CreatedTime:  2012-10-22 09:57:56
 *        LastTime:     2012-10-22 09:57:56
 *        Describe:     
 *        http://www.cnblogs.com/Relict/  
 *  
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _InformationTable
    {
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        public _InformationTable()
        {
            Init();
        }
        private bool m_IsInit = true;
        /// <summary>
        /// 标识是否初始化过
        /// </summary>
        public bool IsInit
        {
            get { return m_IsInit; }
            set { m_IsInit = value; }
        }

        #region ModTable

        #region 土建
        #region 土方
        /////////////////////土方//////////////////////////////////////////
        /// <summary>
        /// 场地平整
        /// </summary>
        private DataTable _cdpz;
        /// <summary>
        /// 人工土方
        /// </summary>
        private DataTable _rgtf;
        /// <summary>
        /// 机械土方
        /// </summary>
        private DataTable _jxtf;
        /// <summary>
        /// 回填夯实碾压
        /// </summary>
        private DataTable _hthsny;
        /// <summary>
        /// 土(石)方运输
        /// </summary>
        private DataTable _tsfys;
        /// <summary>
        /// 支撑防护
        /// </summary>
        private DataTable _zcfh;
        ///==================================================================================================
        /// <summary>
        /// 场地平整
        /// </summary>
        public DataTable CDPZ
        {
            get { return _cdpz; }
            set { _cdpz = value; }
        }
        /// <summary>
        /// 人工土方
        /// </summary>
        public DataTable RGTF
        {
            get { return _rgtf; }
            set { _rgtf = value; }
        }
        /// <summary>
        /// 机械土方
        /// </summary>
        public DataTable JXTF
        {
            get { return _jxtf; }
            set { _jxtf = value; }
        }
        /// <summary>
        /// 回填夯实碾压
        /// </summary>
        public DataTable HTHSNY
        {
            get { return _hthsny; }
            set { _hthsny = value; }
        }
        /// <summary>
        /// 土(石)方运输
        /// </summary>
        public DataTable TSFYS
        {
            get { return _tsfys; }
            set { _tsfys = value; }
        }
        /// <summary>
        /// 支撑防护
        /// </summary>
        public DataTable ZCFH
        {
            get { return _zcfh; }
            set { _zcfh = value; }
        }
        #endregion

        #region 结构
        //////////////////////结构/////////////////////////////////////////
        /// <summary>
        /// 钢筋
        /// </summary>
        private DataTable _Rebar;
        /// <summary>
        /// 基础
        /// </summary>
        private DataTable _Basis;
        /// <summary>
        /// 其他构建
        /// </summary>
        private DataTable _Other;
        /// <summary>
        /// 板表
        /// </summary>
        private DataTable _Plank;
        /// <summary>
        /// 墙表
        /// </summary>
        private DataTable _Wall;
        /// <summary>
        /// 梁表
        /// </summary>
        private DataTable _Girder;
        /// <summary>
        /// 柱表
        /// </summary>
        private DataTable _Pillar;
        /// <summary>
        /// 预制构件
        /// </summary>
        private DataTable _yzgj;
        ///=================================结构=================================================================
        /// <summary>
        /// 钢筋
        /// </summary>
        public DataTable Rebar
        {
            get { return _Rebar; }
            set { _Rebar = value; }
        }
        /// <summary>
        /// 基础
        /// </summary>
        public DataTable Basis
        {
            get { return _Basis; }
            set { _Basis = value; }
        }
        /// <summary>
        /// 其他构建
        /// </summary>
        public DataTable Other
        {
            get { return _Other; }
            set { _Other = value; }
        }
        /// <summary>
        /// 板表
        /// </summary>
        public DataTable Plank
        {
            get { return _Plank; }
            set { _Plank = value; }
        }
        /// <summary>
        /// 墙表
        /// </summary>
        public DataTable Wall
        {
            get { return _Wall; }
            set { _Wall = value; }
        }
        /// <summary>
        /// 梁表
        /// </summary>
        public DataTable Girder
        {
            get { return _Girder; }
            set { _Girder = value; }
        }
        /// <summary>
        /// 柱表
        /// </summary>
        public DataTable Pillar
        {
            get { return _Pillar; }
            set { _Pillar = value; }
        }
        /// <summary>
        /// 预制构件
        /// </summary>
        public DataTable YZGJ
        {
            get { return _yzgj; }
            set { _yzgj = value; }
        }
        #endregion

        #region 建筑
        //////////////////////建筑/////////////////////////////////////////

        #region 门窗
        ///////////////////////////////门窗/////////////////////////////
        /// <summary>
        /// 木门窗
        /// </summary>
        private DataTable _mmc;
        /// <summary>
        /// 钢门窗
        /// </summary>
        private DataTable _gmc;
        /// <summary>
        /// 人防砼门
        /// </summary>
        private DataTable _rftm;
        /// <summary>
        /// 铝合金门窗
        /// </summary>
        private DataTable _lhjmc;
        /// <summary>
        /// 塑钢门窗
        /// </summary>
        private DataTable _sgmc;
        /// <summary>
        /// 卷闸门
        /// </summary>
        private DataTable _jzm;
        /// <summary>
        /// 防盗防火门
        /// </summary>
        private DataTable _fdfhm;
        /// <summary>
        /// 电动门
        /// </summary>
        private DataTable _ddm;
        /// <summary>
        /// 幕墙    
        /// </summary>
        private DataTable _mq;
        ///============================门窗======================================================================
        /// <summary>
        /// 木门窗
        /// </summary>
        public DataTable MMC
        {
            get { return _mmc; }
            set { _mmc = value; }
        }
        /// <summary>
        /// 钢门窗
        /// </summary>
        public DataTable GMC
        {
            get { return _gmc; }
            set { _gmc = value; }
        }
        /// <summary>
        /// 人防砼门
        /// </summary>
        public DataTable RFTM
        {
            get { return _rftm; }
            set { _rftm = value; }
        }
        /// <summary>
        /// 铝合金门窗
        /// </summary>
        public DataTable LHJMC
        {
            get { return _lhjmc; }
            set { _lhjmc = value; }
        }
        /// <summary>
        /// 塑钢门窗
        /// </summary>
        public DataTable SGMC
        {
            get { return _sgmc; }
            set { _sgmc = value; }
        }
        /// <summary>
        /// 卷闸门
        /// </summary>
        public DataTable JZM
        {
            get { return _jzm; }
            set { _jzm = value; }
        }
        /// <summary>
        /// 防盗防火门
        /// </summary>
        public DataTable FDFHM
        {
            get { return _fdfhm; }
            set { _fdfhm = value; }
        }
        /// <summary>
        /// 电动门
        /// </summary>
        public DataTable DDM
        {
            get { return _ddm; }
            set { _ddm = value; }
        }
        /// <summary>
        /// 幕墙
        /// </summary>
        public DataTable MQ
        {
            get { return _mq; }
            set { _mq = value; }
        }
        #endregion

        /// <summary>
        /// 保温
        /// </summary>
        private DataTable _Warm;
        /// <summary>
        /// 防水
        /// </summary>
        private DataTable _WaterProof;
        /// <summary>
        /// 砌筑
        /// </summary>
        private DataTable _Masonry;
        /// <summary>
        /// 变形缝
        /// </summary>
        private DataTable _bxf;
        /// <summary>
        /// 零星项目
        /// </summary>
        private DataTable _lxxm;
        /// <summary>
        /// 屋面
        /// </summary>
        private DataTable _wm;
        /// <summary>
        /// 室外工程
        /// </summary>
        private DataTable _swgc;
        /// <summary>
        /// 金属构件
        /// </summary>
        private DataTable _jsgj;
        /// <summary>
        /// 栏杆、栏板、扶手
        /// </summary>
        private DataTable _lglbfs;
        /// <summary>
        /// 耐酸防腐
        /// </summary>
        private DataTable _nsff;
        /// <summary>
        /// 建筑其他
        /// </summary>
        private DataTable _jzqt;
        ///=============================建筑========================================================
        /// <summary>
        /// 保温
        /// </summary>
        public DataTable Warm
        {
            get { return _Warm; }
            set { _Warm = value; }
        }
        /// <summary>
        /// 防水
        /// </summary>
        public DataTable WaterProof
        {
            get { return _WaterProof; }
            set { _WaterProof = value; }
        }
        /// <summary>
        /// 砌筑
        /// </summary>
        public DataTable Masonry
        {
            get { return _Masonry; }
            set { _Masonry = value; }
        }
        /// <summary>
        /// 变形缝
        /// </summary>
        public DataTable BXF
        {
            get { return _bxf; }
            set { _bxf = value; }
        }
        /// <summary>
        /// 零星项目
        /// </summary>
        public DataTable LXXM
        {
            get { return _lxxm; }
            set { _lxxm = value; }
        }
        /// <summary>
        /// 屋面
        /// </summary>
        public DataTable WM
        {
            get { return _wm; }
            set { _wm = value; }
        }
        /// <summary>
        /// 室外工程
        /// </summary>
        public DataTable SWGC
        {
            get { return _swgc; }
            set { _swgc = value; }
        }
        /// <summary>
        /// 金属构件
        /// </summary>
        public DataTable JSGJ
        {
            get { return _jsgj; }
            set { _jsgj = value; }
        }
        /// <summary>
        /// 栏杆、栏板、扶手
        /// </summary>
        public DataTable LGLBFS
        {
            get { return _lglbfs; }
            set { _lglbfs = value; }
        }
        /// <summary>
        /// 耐酸防腐
        /// </summary>
        public DataTable NSFF
        {
            get { return _nsff; }
            set { _nsff = value; }
        }
        /// <summary>
        /// 建筑其他
        /// </summary>
        public DataTable JZQT
        {
            get { return _jzqt; }
            set { _jzqt = value; }
        }
        #endregion

        #region 装饰
        #region 楼地面
        /////////////////////楼地面//////////////////////////////////////////
        /// <summary>
        /// 楼地面
        /// </summary>
        private DataTable _ldm;
        /// <summary>
        /// 楼梯、台阶
        /// </summary>
        private DataTable _lttj;
        /// <summary>
        /// 踢脚
        /// </summary>
        private DataTable _tj;
        /// <summary>
        /// 楼地面做法
        /// </summary>
        private DataTable _ldmzf;
        ///======================楼地面=============================================
        /// <summary>
        /// 楼地面
        /// </summary>
        public DataTable LDM
        {
            get { return _ldm; }
            set { _ldm = value; }
        }
        /// <summary>
        /// 楼梯、台阶
        /// </summary>
        public DataTable LTTJ
        {
            get { return _lttj; }
            set { _lttj = value; }
        }
        /// <summary>
        /// 踢脚
        /// </summary>
        public DataTable TJ
        {
            get { return _tj; }
            set { _tj = value; }
        }
        public DataTable LDMZF
        {
            get { return _ldmzf; }
            set { _ldmzf = value; }
        }
        #endregion

        #region 墙柱面
        /////////////////////墙柱面//////////////////////////////////////////
        /// <summary>
        /// 抹灰
        /// </summary>
        private DataTable _mh;
        /// <summary>
        /// 块料面层
        /// </summary>
        private DataTable _klmc;
        /// <summary>
        /// 面层装饰
        /// </summary>
        private DataTable _mczs;
        ///
        /// 墙柱面做法
        /// 
        private DataTable _qzmzf;
        ///======================墙柱面=============================================
        /// <summary>
        /// 抹灰
        /// </summary>
        public DataTable MH
        {
            get { return _mh; }
            set { _mh = value; }
        }
        /// <summary>
        /// 块料面层
        /// </summary>
        public DataTable KLMC
        {
            get { return _klmc; }
            set { _klmc = value; }
        }
        /// <summary>
        /// 面层装饰
        /// </summary>
        public DataTable MCZS
        {
            get { return _mczs; }
            set { _mczs = value; }
        }

        ///<summary>
        ///墙柱面做法
        ///</summary>
        public DataTable QZMZF
        {
            get { return _qzmzf; }
            set { _qzmzf = value; }
        }
        #endregion

        #region 天棚
        /////////////////////天棚//////////////////////////////////////////
        /// <summary>
        /// 天棚抹灰
        /// </summary>
        private DataTable _tpmh;
        /// <summary>
        /// 平面、跌级天棚
        /// </summary>
        private DataTable _pmdjtp;
        /// <summary>
        /// 艺术造型天棚
        /// </summary>
        private DataTable _yszxtp;
        /// <summary>
        /// 其他天棚
        /// </summary>
        private DataTable _qttp;
        ///======================天棚=============================================
        /// <summary>
        /// 天棚抹灰
        /// </summary>
        public DataTable TPMH
        {
            get { return _tpmh; }
            set { _tpmh = value; }
        }
        /// <summary>
        /// 平面、跌级天棚
        /// </summary>
        public DataTable PMDJTP
        {
            get { return _pmdjtp; }
            set { _pmdjtp = value; }
        }
        /// <summary>
        /// 艺术造型天棚
        /// </summary>
        public DataTable YSZXTP
        {
            get { return _yszxtp; }
            set { _yszxtp = value; }
        }
        /// <summary>
        /// 其他天棚
        /// </summary>
        public DataTable QTTP
        {
            get { return _qttp; }
            set { _qttp = value; }
        }
        #endregion

        /////////////////////装饰//////////////////////////////////////////
        /// <summary>
        /// 裱糊
        /// </summary>
        private DataTable _bh;
        /// <summary>
        /// 涂料油漆
        /// </summary>
        private DataTable _tlyq;
        /// <summary>
        /// 装饰线条
        /// </summary>
        private DataTable _zsxt;
        ///======================装饰=============================================
        /// <summary>
        /// 裱糊
        /// </summary>
        public DataTable BH
        {
            get { return _bh; }
            set { _bh = value; }
        }
        /// <summary>
        /// 涂料油漆
        /// </summary>
        public DataTable TLYQ
        {
            get { return _tlyq; }
            set { _tlyq = value; }
        }
        /// <summary>
        /// 装饰线条
        /// </summary>
        public DataTable ZSXT
        {
            get { return _zsxt; }
            set { _zsxt = value; }
        }
        #endregion

        #region 图集
        ///////////////////////图集////////////////////////////////////////
        private DataTable m_TJTable;
        private DataTable m_ZFTable;
        ///================图集=============================================
        /// <summary>
        /// 图集
        /// </summary>
        public DataTable TJTable
        {
            get { return m_TJTable; }
            set { m_TJTable = value; }
        }
        /// <summary>
        /// 图集做法
        /// </summary>
        public DataTable ZFTable
        {
            get { return m_ZFTable; }
            set { m_ZFTable = value; }
        }
        #endregion
        #endregion

        #region 安装
        
        #region 第一册
        /// <summary>
        /// _切削设备
        /// </summary>
        private DataTable _切削设备;
        /// <summary>
        /// _起重设备
        /// </summary>
        private DataTable _起重设备;
        /// <summary>
        /// _风机安装
        /// </summary>
        private DataTable _风机安装;
        /// <summary>
        /// _泵安装
        /// </summary>
        private DataTable _泵安装;
        /// <summary>
        /// _其他机械
        /// </summary>
        private DataTable _其他机械;
        /// <summary>
        /// _附属设备
        /// </summary>
        private DataTable _附属设备;


        public DataTable 切削设备
        {
            get { return _切削设备; }
            set { _切削设备 = value; }
        }
        public DataTable 起重设备
        {
            get { return _起重设备; }
            set { _起重设备 = value; }
        }
        public DataTable 风机安装
        {
            get { return _风机安装; }
            set { _风机安装 = value; }
        }
        public DataTable 泵安装
        {
            get { return _泵安装; }
            set { _泵安装 = value; }
        }
        public DataTable 其他机械
        {
            get { return _其他机械; }
            set { _其他机械 = value; }
        }
        public DataTable 附属设备
        {
            get { return _附属设备; }
            set { _附属设备 = value; }
        }


        #endregion

        #region 第二册
        /// <summary>
        /// _变压器
        /// </summary>
        private DataTable _变压器;
        /// <summary>
        /// _配电装置
        /// </summary>
        private DataTable _配电装置;
        /// <summary>
        /// _母线绝缘子
        /// </summary>
        private DataTable _母线绝缘子;
        /// <summary>
        /// _控制设备及低压电器
        /// </summary>
        private DataTable _控制设备及低压电器;
        /// <summary>
        /// _蓄电池
        /// </summary>
        private DataTable _蓄电池;
        /// <summary>
        /// _电机
        /// </summary>
        private DataTable _电机;
        /// <summary>
        /// _滑触线
        /// </summary>
        private DataTable _滑触线;
        /// <summary>
        /// _电缆沟及桥架
        /// </summary>
        private DataTable _电缆沟及桥架;
        /// <summary>
        /// _电缆敷设
        /// </summary>
        private DataTable _电缆敷设;
        /// <summary>
        /// _防雷接地
        /// </summary>
        private DataTable _防雷接地;
        /// <summary>
        /// _10KV以下架空配电线路
        /// </summary>
        private DataTable _10KV以下架空配电线路1;
        /// <summary>
        /// _电气调整试验
        /// </summary>
        private DataTable _电气调整试验;
        ///////////////////////////////////////////////////////////////////////////
        public DataTable 变压器
        {
            get { return _变压器; }
            set { _变压器 = value; }
        }
        public DataTable 配电装置
        {
            get { return _配电装置; }
            set { _配电装置 = value; }
        }
        public DataTable 母线绝缘子
        {
            get { return _母线绝缘子; }
            set { _母线绝缘子 = value; }
        }
        public DataTable 控制设备及低压电器
        {
            get { return _控制设备及低压电器; }
            set { _控制设备及低压电器 = value; }
        }
        public DataTable 蓄电池
        {
            get { return _蓄电池; }
            set { _蓄电池 = value; }
        }
        public DataTable 电机
        {
            get { return _电机; }
            set { _电机 = value; }
        }
        public DataTable 滑触线
        {
            get { return _滑触线; }
            set { _滑触线 = value; }
        }
        public DataTable 电缆沟及桥架
        {
            get { return _电缆沟及桥架; }
            set { _电缆沟及桥架 = value; }
        }
        public DataTable 电缆敷设
        {
            get { return _电缆敷设; }
            set { _电缆敷设 = value; }
        }
        public DataTable 防雷接地
        {
            get { return _防雷接地; }
            set { _防雷接地 = value; }
        }
        public DataTable _10KV以下架空配电线路
        {
            get { return _10KV以下架空配电线路1; }
            set { _10KV以下架空配电线路1 = value; }
        }
        public DataTable 电气调整试验
        {
            get { return _电气调整试验; }
            set { _电气调整试验 = value; }
        }


        #region	配管配线
        /// <summary>
        /// _配管
        /// </summary>
        private DataTable _配管;
        /// <summary>
        /// _配线
        /// </summary>
        private DataTable _配线;
        /// <summary>
        /// _钢索架设母线
        /// </summary>
        private DataTable _钢索架设母线;
        /// <summary>
        /// _接线盒
        /// </summary>
        private DataTable _接线盒;
        /// <summary>
        /// _凿槽
        /// </summary>
        private DataTable _凿槽;
        /// <summary>
        /// _打透眼
        /// </summary>
        private DataTable _打透眼;
        ///////////////////////////////////////////////////////////////////////////
        public DataTable 配管
        {
            get { return _配管; }
            set { _配管 = value; }
        }
        public DataTable 配线
        {
            get { return _配线; }
            set { _配线 = value; }
        }
        public DataTable 钢索架设母线
        {
            get { return _钢索架设母线; }
            set { _钢索架设母线 = value; }
        }
        public DataTable 接线盒
        {
            get { return _接线盒; }
            set { _接线盒 = value; }
        }
        public DataTable 凿槽
        {
            get { return _凿槽; }
            set { _凿槽 = value; }
        }
        public DataTable 打透眼
        {
            get { return _打透眼; }
            set { _打透眼 = value; }
        }



        #endregion

        #region	照明器具
        /// _普通灯具
        /// </summary>
        private DataTable _普通灯具;
        /// _装饰灯具
        /// </summary>
        private DataTable _装饰灯具;
        /// _其他灯具
        /// </summary>
        private DataTable _其他灯具;
        /// _开关插座
        /// </summary>
        private DataTable _开关插座;
        /// _电梯电气
        /// </summary>
        private DataTable _电梯电气;
        ///////////////////////////////////////////////////////////////////////////
        public DataTable 普通灯具
        {
            get { return _普通灯具; }
            set { _普通灯具 = value; }
        }
        public DataTable 装饰灯具
        {
            get { return _装饰灯具; }
            set { _装饰灯具 = value; }
        }
        public DataTable 其他灯具
        {
            get { return _其他灯具; }
            set { _其他灯具 = value; }
        }
        public DataTable 开关插座
        {
            get { return _开关插座; }
            set { _开关插座 = value; }
        }
        public DataTable 电梯电气
        {
            get { return _电梯电气; }
            set { _电梯电气 = value; }
        }
        #endregion
        #endregion

        #region 第六册
        /// <summary>
        /// _管道安装
        /// </summary>
        private DataTable _管道安装;
        /// <summary>
        /// _管件连接
        /// </summary>
        private DataTable _管件连接;
        /// <summary>
        /// _阀门
        /// </summary>
        private DataTable _阀门;
        /// <summary>
        /// _法兰
        /// </summary>
        private DataTable _法兰;
        /// <summary>
        /// _管件
        /// </summary>
        private DataTable _管件;
        /// <summary>
        /// _吹排清洗、压力试验
        /// </summary>
        private DataTable _吹排清洗压力试验;
        /// <summary>
        /// _其他管道
        /// </summary>
        private DataTable _其他管道;
        ///==================================================================================================
        public DataTable 管道安装
        {
            get { return _管道安装; }
            set { _管道安装 = value; }
        }
        public DataTable 管件连接
        {
            get { return _管件连接; }
            set { _管件连接 = value; }
        }
        public DataTable 阀门
        {
            get { return _阀门; }
            set { _阀门 = value; }
        }
        public DataTable 法兰
        {
            get { return _法兰; }
            set { _法兰 = value; }
        }
        public DataTable 管件
        {
            get { return _管件; }
            set { _管件 = value; }
        }
        public DataTable 吹排清洗压力试验
        {
            get { return _吹排清洗压力试验; }
            set { _吹排清洗压力试验 = value; }
        }
        public DataTable 其他管道
        {
            get { return _其他管道; }
            set { _其他管道 = value; }
        }
        #endregion

        #region	第七册

        #region	1.水灭火系统
        /// <summary>
        /// _水灭火管道安装
        /// </summary>
        private DataTable _水灭火管道安装;
        /// <summary>
        /// _水灭火系统组件
        /// </summary>
        private DataTable _水灭火系统组件;
        /// <summary>
        /// _消火栓
        /// </summary>
        private DataTable _消火栓;
        /// <summary>
        /// _气压罐
        /// </summary>
        private DataTable _气压罐;
        ////////////////////////////////////////////////////////////////////////////
        public DataTable 水灭火管道安装
        {
            get { return _水灭火管道安装; }
            set { _水灭火管道安装 = value; }
        }
        public DataTable 水灭火系统组件
        {
            get { return _水灭火系统组件; }
            set { _水灭火系统组件 = value; }
        }
        public DataTable 消火栓
        {
            get { return _消火栓; }
            set { _消火栓 = value; }
        }
        public DataTable 气压罐
        {
            get { return _气压罐; }
            set { _气压罐 = value; }
        }
        #endregion

        #region	2.气灭火系统
        /// <summary>
        /// _气灭火管道安装
        /// </summary>
        private DataTable _气灭火管道安装;
        /// <summary>
        /// _气灭火系统组件
        /// </summary>
        private DataTable _气灭火系统组件;
        /// <summary>
        /// _严密性、装置调试
        /// </summary>
        private DataTable _严密性装置调试;
        ////////////////////////////////////////////////////////////////////////////
        public DataTable 气灭火管道安装
        {
            get { return _气灭火管道安装; }
            set { _气灭火管道安装 = value; }
        }
        public DataTable 气灭火系统组件
        {
            get { return _气灭火系统组件; }
            set { _气灭火系统组件 = value; }
        }
        public DataTable 严密性装置调试
        {
            get { return _严密性装置调试; }
            set { _严密性装置调试 = value; }
        }
        #endregion

        #region	3-4-5
        /// <summary>
        /// _泡沫灭火系统
        /// </summary>
        private DataTable _泡沫灭火系统;
        /// <summary>
        /// _火灾自动报警系统
        /// </summary>
        private DataTable _火灾自动报警系统;
        /// <summary>
        /// _系统装置调试
        /// </summary>
        private DataTable _系统装置调试;
        ////////////////////////////////////////////////////////////////////////////
        public DataTable 泡沫灭火系统
        {
            get { return _泡沫灭火系统; }
            set { _泡沫灭火系统 = value; }
        }
        public DataTable 火灾自动报警系统
        {
            get { return _火灾自动报警系统; }
            set { _火灾自动报警系统 = value; }
        }
        public DataTable 系统装置调试
        {
            get { return _系统装置调试; }
            set { _系统装置调试 = value; }
        }
        #endregion
        #endregion

        #region 第八册

        #region	给排水、雨水
        /////////////////////给排水、雨水//////////////////////////////////////////
        /// <summary>
        /// _给排水室外无缝钢管
        /// </summary>
        private DataTable _给排水室外无缝钢管;
        /// <summary>
        /// _给排水室外其他管材
        /// </summary>
        private DataTable _给排水室外其他管材;
        /// <summary>
        /// 给排水室内无缝钢管
        /// </summary>
        private DataTable _给排水室内无缝钢管;
        /// <summary>
        /// 给排水室内其他管材
        /// </summary>
        private DataTable _给排水室内其他管材;
        /// <summary>
        /// 给排水埋地管道
        /// </summary>
        private DataTable _给排水埋地管道;
        /// <summary>
        /// 给排水卫生器具
        /// </summary>
        private DataTable _给排水卫生器具;
        /// <summary>
        /// 给排水水表
        /// </summary>
        private DataTable _给排水水表;
        ///==================================================================================================
        /// <summary>
        /// 给排水室外无缝钢管
        /// </summary>
        public DataTable 给排水室外无缝钢管
        {
            get { return _给排水室外无缝钢管; }
            set { _给排水室外无缝钢管 = value; }
        }
        /// <summary>
        /// 给排水室外其他管材
        /// </summary>
        public DataTable 给排水室外其他管材
        {
            get { return _给排水室外其他管材; }
            set { _给排水室外其他管材 = value; }
        }
        /// <summary>
        /// 给排水室内无缝钢管
        /// </summary>
        public DataTable 给排水室内无缝钢管
        {
            get { return _给排水室内无缝钢管; }
            set { _给排水室内无缝钢管 = value; }
        }
        /// <summary>
        /// 给排水室内其他管材
        /// </summary>
        public DataTable 给排水室内其他管材
        {
            get { return _给排水室内其他管材; }
            set { _给排水室内其他管材 = value; }
        }
        /// <summary>
        /// 给排水埋地管道
        /// </summary>
        public DataTable 给排水埋地管道
        {
            get { return _给排水埋地管道; }
            set { _给排水埋地管道 = value; }
        }
        /// <summary>
        /// 给排水卫生器具
        /// </summary>
        public DataTable 给排水卫生器具
        {
            get { return _给排水卫生器具; }
            set { _给排水卫生器具 = value; }
        }
        /// <summary>
        /// 给排水水表
        /// </summary>
        public DataTable 给排水水表
        {
            get { return _给排水水表; }
            set { _给排水水表 = value; }
        }
        #endregion

        #region	采暖热源
        /////////////////////采暖热源//////////////////////////////////////////
        /// <summary>
        /// _采暖热源室外无缝钢管
        /// </summary>
        private DataTable _采暖热源室外无缝钢管;
        /// <summary>
        /// _采暖热源室外其他管材
        /// </summary>
        private DataTable _采暖热源室外其他管材;
        /// <summary>
        /// 采暖热源室内无缝钢管
        /// </summary>
        private DataTable _采暖热源室内无缝钢管;
        /// <summary>
        /// 采暖热源室内其他管材
        /// </summary>
        private DataTable _采暖热源室内其他管材;
        /// <summary>
        /// 采暖热源埋地管道
        /// </summary>
        private DataTable _采暖热源埋地管道;
        /// <summary>
        /// 采暖热源供暖器具
        /// </summary>
        private DataTable _采暖热源供暖器具;
        ///==================================================================================================
        /// <summary>
        /// 采暖热源室外无缝钢管
        /// </summary>
        public DataTable 采暖热源室外无缝钢管
        {
            get { return _采暖热源室外无缝钢管; }
            set { _采暖热源室外无缝钢管 = value; }
        }
        /// <summary>
        /// 采暖热源室外其他管材
        /// </summary>
        public DataTable 采暖热源室外其他管材
        {
            get { return _采暖热源室外其他管材; }
            set { _采暖热源室外其他管材 = value; }
        }
        /// <summary>
        /// 采暖热源室内无缝钢管
        /// </summary>
        public DataTable 采暖热源室内无缝钢管
        {
            get { return _采暖热源室内无缝钢管; }
            set { _采暖热源室内无缝钢管 = value; }
        }
        /// <summary>
        /// 采暖热源室内其他管材
        /// </summary>
        public DataTable 采暖热源室内其他管材
        {
            get { return _采暖热源室内其他管材; }
            set { _采暖热源室内其他管材 = value; }
        }
        /// <summary>
        /// 采暖热源埋地管道
        /// </summary>
        public DataTable 采暖热源埋地管道
        {
            get { return _采暖热源埋地管道; }
            set { _采暖热源埋地管道 = value; }
        }
        /// <summary>
        /// 采暖热源供暖器具
        /// </summary>
        public DataTable 采暖热源供暖器具
        {
            get { return _采暖热源供暖器具; }
            set { _采暖热源供暖器具 = value; }
        }
        #endregion

        #region	燃气管道
        /////////////////////燃气管道//////////////////////////////////////////
        /// <summary>
        /// _燃气管道
        /// </summary>
        private DataTable _燃气管道;
        /// <summary>
        /// _燃气管道附件
        /// </summary>
        private DataTable _燃气管道附件;
        /// <summary>
        /// _燃气加热设备
        /// </summary>
        private DataTable _燃气加热设备;
        /// <summary>
        /// _然气灶具
        /// </summary>
        private DataTable _燃气灶具;
        /// <summary>
        /// _燃气表
        /// </summary>
        private DataTable _燃气表;
        ////////////////////////////////////////////////////////////////////////////
        public DataTable 燃气管道
        {
            get { return _燃气管道; }
            set { _燃气管道 = value; }
        }
        public DataTable 燃气管道附件
        {
            get { return _燃气管道附件; }
            set { _燃气管道附件 = value; }
        }
        public DataTable 燃气加热设备
        {
            get { return _燃气加热设备; }
            set { _燃气加热设备 = value; }
        }
        public DataTable 燃气灶具
        {
            get { return _燃气灶具; }
            set { _燃气灶具 = value; }
        }
        public DataTable 燃气表
        {
            get { return _燃气表; }
            set { _燃气表 = value; }
        }
        #endregion

        #region	消火栓
        /////////////////////消火栓//////////////////////////////////////////
        /// <summary>
        /// _消火栓室外无缝钢管
        /// </summary>
        private DataTable _消火栓室外无缝钢管;
        /// <summary>
        /// _消火栓室外其他管材
        /// </summary>
        private DataTable _消火栓室外其他管材;
        /// <summary>
        /// 消火栓室内无缝钢管
        /// </summary>
        private DataTable _消火栓室内无缝钢管;
        /// <summary>
        /// 消火栓室内其他管材
        /// </summary>
        private DataTable _消火栓室内其他管材;
        /// <summary>
        /// 消火栓埋地管道
        /// </summary>
        private DataTable _消火栓埋地管道;
        ///==================================================================================================
        /// <summary>
        /// 消火栓室外无缝钢管
        /// </summary>
        public DataTable 消火栓室外无缝钢管
        {
            get { return _消火栓室外无缝钢管; }
            set { _消火栓室外无缝钢管 = value; }
        }
        /// <summary>
        /// 消火栓室外其他管材
        /// </summary>
        public DataTable 消火栓室外其他管材
        {
            get { return _消火栓室外其他管材; }
            set { _消火栓室外其他管材 = value; }
        }
        /// <summary>
        /// 消火栓室内无缝钢管
        /// </summary>
        public DataTable 消火栓室内无缝钢管
        {
            get { return _消火栓室内无缝钢管; }
            set { _消火栓室内无缝钢管 = value; }
        }
        /// <summary>
        /// 消火栓室内其他管材
        /// </summary>
        public DataTable 消火栓室内其他管材
        {
            get { return _消火栓室内其他管材; }
            set { _消火栓室内其他管材 = value; }
        }
        /// <summary>
        /// 消火栓埋地管道
        /// </summary>
        public DataTable 消火栓埋地管道
        {
            get { return _消火栓埋地管道; }
            set { _消火栓埋地管道 = value; }
        }
        #endregion


        /// <summary>
        /// 阀门法兰
        /// </summary>
        private DataTable _阀门_法兰;
        public DataTable 阀门_法兰
        {
            get { return _阀门_法兰; }
            set { _阀门_法兰 = value; }
        }

        #region 其他
        ///=============================其他==========================================================
        /// <summary>
        /// _管道支架
        /// </summary>
        private DataTable _管道支架;
        /// <summary>
        /// _伸缩器
        /// </summary>
        private DataTable _伸缩器;
        /// <summary>
        ///  _水箱
        /// </summary>
        private DataTable _水箱;
        /// <summary>
        /// _管道干线碰头
        /// </summary>
        private DataTable _管道干线碰头;
        /// <summary>
        /// _凿槽刨沟补槽
        /// </summary>
        private DataTable _凿槽刨沟补槽;
        /// <summary>
        /// _打堵洞眼
        /// </summary>
        private DataTable _打堵洞眼;
        /// <summary>
        /// _塑料检查井
        /// </summary>
        private DataTable _塑料检查井;
        /// <summary>
        /// _其他器具
        /// </summary>
        private DataTable _其他器具;
        ///==================================================================================================
        public DataTable 管道支架
        {
            get { return _管道支架; }
            set { _管道支架 = value; }
        }
        public DataTable 伸缩器
        {
            get { return _伸缩器; }
            set { _伸缩器 = value; }
        }
        public DataTable 水箱
        {
            get { return _水箱; }
            set { _水箱 = value; }
        }
        public DataTable 管道干线碰头
        {
            get { return _管道干线碰头; }
            set { _管道干线碰头 = value; }
        }
        public DataTable 凿槽刨沟补槽
        {
            get { return _凿槽刨沟补槽; }
            set { _凿槽刨沟补槽 = value; }
        }

        public DataTable 打堵洞眼
        {
            get { return _打堵洞眼; }
            set { _打堵洞眼 = value; }
        }
        public DataTable 塑料检查井
        {
            get { return _塑料检查井; }
            set { _塑料检查井 = value; }
        }
        public DataTable 其他器具
        {
            get { return _其他器具; }
            set { _其他器具 = value; }
        }

        #endregion

        #endregion

        #region 第九册
        #region	通风空调工程
        /////////////////////通风空调工程//////////////////////////////////////////
        /// <summary>
        /// _通风及空调设备
        /// </summary>
        private DataTable _通风及空调设备;
        ///////////////////////////////////////////////////////////////////////////
        public DataTable 通风及空调设备
        {
            get { return _通风及空调设备; }
            set { _通风及空调设备 = value; }
        }
        #region	部件制作安装
        /// <summary>
        /// _风管制作安装
        /// </summary>
        private DataTable _风管制作安装;
        /// <summary>
        /// _调节阀制作安装
        /// </summary>
        private DataTable _调节阀制作安装;
        /// <summary>
        /// _风口制作安装
        /// </summary>
        private DataTable _风口制作安装;
        /// <summary>
        /// _风帽制作安装
        /// </summary>
        private DataTable _风帽制作安装;
        /// <summary>
        /// _罩类制作安装
        /// </summary>
        private DataTable _罩类制作安装;
        /// <summary>
        /// _消声器静压箱
        /// </summary>
        private DataTable _消声器静压箱;
        /// <summary>
        /// _其他部件
        /// </summary>
        private DataTable _其他部件;
        ///////////////////////////////////////////////////////////////////////////
        public DataTable 风管制作安装
        {
            get { return _风管制作安装; }
            set { _风管制作安装 = value; }
        }
        public DataTable 调节阀制作安装
        {
            get { return _调节阀制作安装; }
            set { _调节阀制作安装 = value; }
        }
        public DataTable 风口制作安装
        {
            get { return _风口制作安装; }
            set { _风口制作安装 = value; }
        }
        public DataTable 风帽制作安装
        {
            get { return _风帽制作安装; }
            set { _风帽制作安装 = value; }
        }
        public DataTable 罩类制作安装
        {
            get { return _罩类制作安装; }
            set { _罩类制作安装 = value; }
        }
        public DataTable 消声器静压箱
        {
            get { return _消声器静压箱; }
            set { _消声器静压箱 = value; }
        }
        public DataTable 其他部件
        {
            get { return _其他部件; }
            set { _其他部件 = value; }
        }

        #region 第十册  第十一册 第十二册

        /////////////////////自动化仪表安装//////////////////////////////////////////
        /// <summary>
        /// _自动化仪表安装
        /// </summary>
        private DataTable _自动化仪表安装;
        /// <summary>
        /// _综合布线
        /// </summary>
        private DataTable _综合布线;
        /// <summary>
        /// _智能系统
        /// </summary>
        private DataTable _智能系统;
        /////////////////////////////////////////////////////////////////////////////
        public DataTable 自动化仪表安装
        {
            get { return _自动化仪表安装; }
            set { _自动化仪表安装 = value; }
        }
        public DataTable 综合布线
        {
            get { return _综合布线; }
            set { _综合布线 = value; }
        }
        public DataTable 智能系统
        {
            get { return _智能系统; }
            set { _智能系统 = value; }
        }

        #endregion
        #endregion

        #endregion
        #endregion

        #endregion
        #endregion


        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (this.IsInit)
            {
                #region 土建
                /*====================土方=============================*/
                this.CDPZ = CreatTable("场地平整");
                this.RGTF = CreatTable("人工土方");
                this.JXTF = CreatTable("机械土方");
                this.HTHSNY = CreatTable("回填夯实碾压");
                this.TSFYS = CreatTable("土(石)方运输");
                this.ZCFH = CreatTable("支撑防护");
                /*====================结构=============================*/
                this.Rebar = CreatTable("钢筋");
                this.Basis = CreatTable("基础");
                this.Other = CreatTable("其他构件");
                this.Plank = CreatTable("板表");
                this.Wall = CreatTable("墙表");
                this.Girder = CreatTable("梁表");
                this.Pillar = CreatTable("柱表");
                this.YZGJ = CreatTable("预制构件");
                /*======================建筑===========================*/
                this.Warm = CreatTable("保温");
                this.WaterProof = CreatTable("防水");
                this.Masonry = CreatTable("砌筑");
                this.BXF = CreatTable("变形缝");
                this.LXXM = CreatTable("零星项目");
                this.WM = CreatTable("屋面");
                this.SWGC = CreatTable("室外工程");
                this.JSGJ = CreatTable("金属构件");
                this.LGLBFS = CreatTable("栏杆、栏板、扶手");
                this.NSFF = CreatTable("耐酸防腐");
                this.JZQT = CreatTable("建筑其他");
                /*=================装饰================================*/
                this.BH = CreatTable("裱糊");
                this.TLYQ = CreatTable("涂料油漆");
                this.ZSXT = CreatTable("装饰线条");
                /*=================门窗================================*/
                this.MMC = CreatTable("木门窗");
                this.GMC = CreatTable("钢门窗");
                this.RFTM = CreatTable("人防砼门");
                this.LHJMC = CreatTable("铝合金门窗");
                this.SGMC = CreatTable("塑钢门窗");
                this.JZM = CreatTable("卷闸门");
                this.FDFHM = CreatTable("防盗防火门");
                this.DDM = CreatTable("电动门");
                this.MQ = CreatTable("幕墙");
                /*=================楼地面================================*/
                this.LDM = CreatTable("楼地面");
                this.LTTJ = CreatTable("楼梯、台阶");
                this.TJ = CreatTable("踢脚");
                this.LDMZF = CreatTable("楼地面做法");
                /*=================墙柱面================================*/
                this.MH = CreatTable("抹灰");
                this.KLMC = CreatTable("块料面层");
                this.MCZS = CreatTable("面层装饰");
                this.QZMZF = CreatTable("墙柱面做法");
                /*=================天棚================================*/
                this.TPMH = CreatTable("天棚抹灰");
                this.PMDJTP = CreatTable("平面、跌级天棚");
                this.YSZXTP = CreatTable("艺术造型天棚");
                this.QTTP = CreatTable("其他天棚");
                /*======================图集===========================*/
                this.BuildTable();
                #endregion

                #region 安装

                #region 第一册
                this.切削设备 = CreatTable("切削设备");
                this.起重设备 = CreatTable("起重设备");
                this.风机安装 = CreatTable("风机安装");
                this.泵安装 = CreatTable("泵安装");
                this.其他机械 = CreatTable("其他机械");
                this.附属设备 = CreatTable("附属设备");
                #endregion

                #region 第二册
                this.变压器 = CreatTable("变压器");
                this.配电装置 = CreatTable("配电装置");
                this.母线绝缘子 = CreatTable("母线绝缘子");
                this.控制设备及低压电器 = CreatTable("控制设备及低压电器");
                this.蓄电池 = CreatTable("蓄电池");
                this.电机 = CreatTable("电机");
                this.滑触线 = CreatTable("滑触线");
                this.电缆沟及桥架 = CreatTable("电缆沟及桥架");
                this.电缆敷设 = CreatTable("电缆敷设");
                this.防雷接地 = CreatTable("防雷接地");
                this._10KV以下架空配电线路 = CreatTable("10KV以下架空配电线路");
                this.电气调整试验 = CreatTable("电气调整试验");

                #region 配管配线
                this.配管 = CreatTable("配管");
                this.配线 = CreatTable("配线");
                this.钢索架设母线 = CreatTable("钢索架设母线");
                this.接线盒 = CreatTable("接线盒");
                this.凿槽 = CreatTable("凿槽");
                this.打透眼 = CreatTable("打透眼");
                #endregion

                #region 照明器具
                this.普通灯具 = CreatTable("普通灯具");
                this.装饰灯具 = CreatTable("装饰灯具");
                this.其他灯具 = CreatTable("其他灯具");
                this.开关插座 = CreatTable("开关插座");
                this.电梯电气 = CreatTable("电梯电气");
                #endregion

                #endregion

                #region 第六册
                this.管道安装 = CreatTable("管道安装");
                this.管件连接 = CreatTable("管件连接");
                this.阀门 = CreatTable("阀门");
                this.法兰 = CreatTable("法兰");
                this.管件 = CreatTable("管件");
                this.吹排清洗压力试验 = CreatTable("吹排清洗压力试验");
                this.其他管道 = CreatTable("其他管道");
                #endregion

                #region	第七册

                #region	1.水灭火系统
                this.水灭火管道安装 = CreatTable("水灭火管道安装");
                this.水灭火系统组件 = CreatTable("水灭火系统组件");
                this.消火栓 = CreatTable("消火栓");
                this.气压罐 = CreatTable("气压罐");
                #endregion

                #region	2.气灭火系统
                this.气灭火管道安装 = CreatTable("气灭火管道安装");
                this.气灭火系统组件 = CreatTable("气灭火系统组件");
                this.严密性装置调试 = CreatTable("严密性装置调试");
                #endregion

                #region	3-4-5
                this.泡沫灭火系统 = CreatTable("泡沫灭火系统");
                this.火灾自动报警系统 = CreatTable("火灾自动报警系统");
                this.系统装置调试 = CreatTable("系统装置调试");
                #endregion
                #endregion

                #region 第八册

                #region 给排水、雨水
                this._给排水室外无缝钢管 = CreatTable("给排水室外无缝钢管");
                this._给排水室外其他管材 = CreatTable("给排水室外其他管材");
                this._给排水室内无缝钢管 = CreatTable("给排水室内无缝钢管");
                this._给排水室内其他管材 = CreatTable("给排水室内其他管材");
                this._给排水埋地管道 = CreatTable("给排水埋地管道");
                this._给排水卫生器具 = CreatTable("给排水卫生器具");
                this._给排水水表 = CreatTable("给排水水表");
                #endregion

                #region 采暖热源
                this._采暖热源室外无缝钢管 = CreatTable("采暖热源室外无缝钢管");
                this._采暖热源室外其他管材 = CreatTable("采暖热源室外其他管材");
                this._采暖热源室内无缝钢管 = CreatTable("采暖热源室内无缝钢管");
                this._采暖热源室内其他管材 = CreatTable("采暖热源室内其他管材");
                this._采暖热源埋地管道 = CreatTable("采暖热源埋地管道");
                this._采暖热源供暖器具 = CreatTable("采暖热源供暖器具"); 
                #endregion

                #region 燃气管道
                this._燃气管道 = CreatTable("燃气管道");
                this._燃气管道附件 = CreatTable("燃气管道附件");
                this._燃气加热设备 = CreatTable("燃气加热设备");
                this._燃气灶具 = CreatTable("燃气灶具");
                this._燃气表 = CreatTable("燃气表");
                #endregion

                #region 消火栓
                this._消火栓室外无缝钢管 = CreatTable("消火栓室外无缝钢管");
                this._消火栓室外其他管材 = CreatTable("消火栓室外其他管材");
                this._消火栓室内无缝钢管 = CreatTable("消火栓室内无缝钢管");
                this._消火栓室内其他管材 = CreatTable("消火栓室内其他管材");
                this._消火栓埋地管道 = CreatTable("消火栓埋地管道");
                #endregion

                #region 阀门_法兰
                this.阀门_法兰 = CreatTable("阀门_法兰");
                #endregion

                #region 其他
                this._管道支架 = CreatTable("管道支架");
                this._伸缩器 = CreatTable("伸缩器");
                this._水箱 = CreatTable("水箱");
                this._管道干线碰头 = CreatTable("管道干线碰头");
                this._凿槽刨沟补槽 = CreatTable("凿槽_刨沟_补槽");
                this._打堵洞眼 = CreatTable("打堵洞眼");
                this._塑料检查井 = CreatTable("塑料检查井");
                this._其他器具 = CreatTable("其他器具");
                #endregion

                #endregion

                #region 第九册
                this.通风及空调设备 = CreatTable("通风及空调设备");

                #region 部件制作安装

                this.风管制作安装 = CreatTable("风管制作安装");
                this.调节阀制作安装 = CreatTable("调节阀制作安装");
                this.风口制作安装 = CreatTable("风口制作安装");
                this.风帽制作安装 = CreatTable("风帽制作安装");
                this.罩类制作安装 = CreatTable("罩类制作安装");
                this.消声器静压箱 = CreatTable("消声器静压箱");
                this.其他部件 = CreatTable("其他部件");

                #region 第十册  第十一册 第十二册
                this.自动化仪表安装 = CreatTable("自动化仪表安装");
                this.综合布线 = CreatTable("综合布线");
                this.智能系统 = CreatTable("智能系统");
                #endregion
                #endregion
                #endregion
                #endregion
                this.IsInit = false;
            }
        }
        #region 图集
        private void BuildTable()
        {
            this.m_TJTable = new DataTable();
            this.m_TJTable.Columns.Add("ID", typeof(int));
            this.m_TJTable.Columns.Add("SYBH", typeof(string));
            this.m_TJTable.Columns.Add("TJBH", typeof(string));
            this.m_TJTable.Columns.Add("TJMC", typeof(string));
            this.m_TJTable.Columns.Add("HD", typeof(string));
            this.m_TJTable.Columns.Add("DW", typeof(string));
            this.m_TJTable.Columns.Add("BZ", typeof(string));
            this.m_TJTable.Columns.Add("CLFS", typeof(string));
            this.m_TJTable.Columns.Add("QDBH", typeof(string));
            this.m_TJTable.Columns.Add("QDMC", typeof(string));
            this.m_TJTable.Columns.Add("QDDW", typeof(string));
            this.m_TJTable.Columns.Add("LXID", typeof(int));
            this.m_TJTable.Columns.Add("GCL", typeof(decimal));
            this.m_TJTable.Columns.Add("OP", typeof(string));
            DataColumn cID = this.m_TJTable.Columns.Add("Key", typeof(int));
            cID.AutoIncrement = true;
            cID.AutoIncrementSeed = 1;
            cID.AutoIncrementStep = 1;
            this.m_TJTable.Columns.Add("BW", typeof(string));
            this.m_TJTable.Columns.Add("BEIZHU", typeof(string));
            this.m_TJTable.Columns.Add("IsFresh", typeof(bool));
            this.m_ZFTable = new DataTable();
            //图集做法表的构造
            this.m_ZFTable.Columns.Add("ID", typeof(int));
            this.m_ZFTable.Columns.Add("TJBH", typeof(string));
            this.m_ZFTable.Columns.Add("ZFBH", typeof(string));
            this.m_ZFTable.Columns.Add("ZFMC", typeof(string));
            this.m_ZFTable.Columns.Add("BS", typeof(string));
            this.m_ZFTable.Columns.Add("CLFS", typeof(string));
            DataColumn col = this.m_ZFTable.Columns.Add("Check", typeof(bool));
            col.DefaultValue = true;
            DataColumn col1 = this.m_ZFTable.Columns.Add("TJID", typeof(int));
            col1.DefaultValue = 0;
            this.m_ZFTable.Columns.Add("OP", typeof(string));
            this.m_ZFTable.Columns.Add("LXID", typeof(string));
            this.m_ZFTable.Columns.Add("XS", typeof(string));

        }
        #endregion

        #region 初始化 数据源格式
        /// <summary>
        /// 初始化 数据源格式
        /// </summary>
        /// <param name="strTableType"></param>
        /// <returns></returns>
        public DataTable CreatTable(string strTableType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");///编号
            dt.Columns["ID"].AutoIncrement = true;
            dt.Columns["ID"].AutoIncrementSeed = 1;
            dt.Columns["ID"].AutoIncrementStep = 1;
            dt.Columns["ID"].ReadOnly = true;
            dt.Columns.Add("XH");///序号
            dt.Columns.Add("FormMC");///视图名称 


            dt.Columns.Add("DW");///单位【m3】
            dt.Columns["DW"].DefaultValue = "M3";
            //dt.Columns["DW"].ReadOnly = true;

            switch (strTableType)
            {
                #region 土建

                #region 土方
                /*=====================土方=====================================*/
                case "场地平整":
                    dt.Columns.Add("CDPZLX");///场地平整类型
                    dt.Columns["DW"].DefaultValue = "M2";///单位【M2】
                    dt.Columns["FormMC"].DefaultValue = "土方：场地平整";
                    break;
                case "人工土方":
                    dt.Columns.Add("WTLX");///挖土类型
                    dt.Columns.Add("WTPJHD");///挖土平均厚度(m)
                    dt.Columns["FormMC"].DefaultValue = "土方：人工土方";
                    break;
                case "机械土方":
                    dt.Columns.Add("JXLX");///机械类型
                    dt.Columns.Add("TCYJL");///推铲运距离(m)
                    dt.Columns["FormMC"].DefaultValue = "土方：机械土方";
                    break;
                case "回填夯实碾压":
                    dt.Columns.Add("HSNYYQ");///夯实碾压要求
                    dt.Columns.Add("TZYQ");///土质要求
                    dt.Columns["FormMC"].DefaultValue = "土方：回填夯实碾压";
                    break;
                case "土(石)方运输":
                    dt.Columns.Add("TSFYSFS");///土(石)方运输方式
                    dt.Columns.Add("YTJL");///运土距离(m)
                    dt.Columns["FormMC"].DefaultValue = "土方：土(石)方运输";
                    break;
                case "支撑防护":
                    dt.Columns.Add("DTBLX");///挡土板类型
                    dt.Columns.Add("ZCFS");///支撑方式
                    dt.Columns["FormMC"].DefaultValue = "土方：支撑防护";
                    break;
                #endregion

                #region 结构
                /*=====================结构=====================================*/
                case "钢筋":
                    dt.Columns.Add("GJMC");///钢筋名称
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("JTXS");///接头形式
                    dt.Columns.Add("JTGS");///接头个数                       
                    dt.Columns["DW"].DefaultValue = "T";///单位【T】
                    dt.Columns["FormMC"].DefaultValue = "结构：钢筋";
                    break;
                case "基础":
                    dt.Columns.Add("JCBH");///基础编号
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("BDG");///底标高
                    dt.Columns.Add("CCXX");///尺寸信息
                    dt.Columns.Add("HNTBHLYQ");///混凝土拌合料要求
                    dt.Columns.Add("HNTQDDJ");///混凝土强度等级
                    dt.Columns["FormMC"].DefaultValue = "结构：基础";
                    break;
                case "其他构件":
                    dt.Columns.Add("GJBH");///构件编号
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("CCMS");///尺寸描述（mm）
                    dt.Columns.Add("HNTBHLYQ");///混凝土拌合料要求
                    dt.Columns.Add("HNTQDDJ");///混凝土强度等级
                    dt.Columns["FormMC"].DefaultValue = "结构：其他构件";
                    break;
                case "板表":
                    dt.Columns.Add("BBH");///板编号
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("BHD");///板厚度（mm）
                    dt.Columns.Add("BBG");///板标高（m）
                    dt.Columns.Add("HNTBHLYQ");///混凝土拌合料要求
                    dt.Columns.Add("HNTQDDJ");///混凝土强度等级
                    dt.Columns["FormMC"].DefaultValue = "结构：板表";
                    break;
                case "墙表":
                    dt.Columns.Add("QBH");///墙编号
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("ZXHX");///直行、弧形
                    dt.Columns.Add("QHD");///墙厚度（mm）
                    dt.Columns.Add("QGD");///墙高度（m）
                    dt.Columns.Add("HNTBHLYQ");///混凝土拌合料要求
                    dt.Columns.Add("HNTQDDJ");///混凝土强度等级
                    dt.Columns["FormMC"].DefaultValue = "结构：墙表";
                    break;
                case "梁表":
                    dt.Columns.Add("LBH");///梁编号
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("JMXZ");///截面形状
                    dt.Columns.Add("LK");///梁宽（mm）
                    dt.Columns.Add("LG");///梁高（mm）
                    dt.Columns.Add("LDBG");///梁底标高（m）
                    dt.Columns.Add("HNTBHLYQ");///混凝土拌合料要求
                    dt.Columns.Add("HNTQDDJ");///混凝土强度等级
                    dt.Columns["FormMC"].DefaultValue = "结构：梁表";
                    break;
                case "柱表":
                    dt.Columns.Add("ZBH");///柱编号
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("JMXZ");///截面形状
                    dt.Columns.Add("YCBC");///一侧边长（mm）
                    dt.Columns.Add("LYCBC");///另一侧边长（mm）
                    dt.Columns.Add("ZJHZC");///直径或周长（mm）
                    dt.Columns.Add("ZGD");///柱高度（m）
                    dt.Columns.Add("HNTBHLYQ");///混凝土拌合料要求
                    dt.Columns.Add("HNTQDDJ");///混凝土强度等级
                    dt.Columns["FormMC"].DefaultValue = "结构：柱表";
                    break;
                case "预制构件":
                    dt.Columns.Add("YZGJBH");///预制构件编号
                    dt.Columns.Add("LB");///类别
                    dt.Columns.Add("TJHD");///体积厚度
                    dt.Columns.Add("YJ");///运距
                    dt.Columns.Add("HNTQDDJ");///混凝土强度等级
                    dt.Columns["FormMC"].DefaultValue = "结构：预制构件";
                    break;
                #endregion

                #region 建筑
                /*=====================建筑=====================================*/
                case "保温":
                    dt.Columns.Add("BWBW");///保温部位
                    dt.Columns.Add("BWCL");///保温材料
                    dt.Columns.Add("BWCL2");///保温材料
                    dt.Columns.Add("BWCL3");///保温材料
                    dt.Columns.Add("HD", typeof(float));///厚度（mm）
                    //dt.Columns["HD"].DefaultValue = "0";
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "建筑：保温";
                    break;
                case "防水":
                    dt.Columns.Add("FSCLFL");///防水材料分类
                    dt.Columns.Add("FSBW");///防水部位
                    dt.Columns.Add("FSCLPZ"); ///防水材料品种
                    dt.Columns.Add("FSCLPZ2"); ///防水材料品种
                    dt.Columns.Add("FSCLPZ3"); ///防水材料品种
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "建筑：防水";
                    break;
                case "砌筑":
                    dt.Columns.Add("QTQBH");///砌体墙编号
                    dt.Columns.Add("QTLX");///墙体类型
                    dt.Columns.Add("QTHD");///墙体厚度（mm）
                    dt.Columns.Add("ZPZ");///砖品种、规格
                    dt.Columns.Add("GFYQ");///勾缝要求
                    dt.Columns.Add("SJBHLYQ");///砂浆拌合料要求
                    dt.Columns.Add("SJDJQD");///砂浆强度等级
                    dt.Columns["FormMC"].DefaultValue = "建筑：砌筑";
                    break;
                case "变形缝":
                    dt.Columns.Add("BXFBW");///变形缝部位
                    dt.Columns.Add("CLZL");///材料种类
                    dt.Columns.Add("FK", typeof(float));///缝宽（mm）
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "建筑：变形缝";
                    break;
                case "零星项目":
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("CLLB"); ///材料类别
                    dt.Columns.Add("JC"); ///基层
                    dt.Columns.Add("ZTLX"); ///粘贴类型
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "建筑：零星项目";
                    break;
                case "屋面":
                    dt.Columns.Add("BH");///编号
                    dt.Columns.Add("TTZL");///檀条种类
                    dt.Columns.Add("GWTZL"); ///挂瓦条种类
                    dt.Columns.Add("WZL"); ///瓦种类
                    dt.Columns.Add("bl");///标识列
                    dt.Columns["FormMC"].DefaultValue = "建筑：屋面";
                    break;
                case "室外工程":
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("CLMCZL"); ///材料名称种类
                    dt.Columns.Add("HDLJFS"); ///厚度（cm）、连接方式
                    dt.Columns.Add("GJ"); ///管径
                    dt.Columns.Add("DCZL"); ///垫层种类
                    dt.Columns["DW"].DefaultValue = "樘";
                    dt.Columns["FormMC"].DefaultValue = "建筑：室外工程";
                    break;
                case "金属构件":
                    dt.Columns.Add("GJBH");///构件编号
                    dt.Columns.Add("GJFL");///构件分类
                    dt.Columns.Add("CX");///除锈
                    dt.Columns.Add("JSGJYJ");///金属构件运距
                    dt.Columns.Add("YQPZSQBS1");///油漆品种、刷漆遍数1
                    dt.Columns.Add("YQPZSQBS2");///油漆品种、刷漆遍数2
                    dt.Columns["DW"].DefaultValue = "T";
                    dt.Columns["FormMC"].DefaultValue = "建筑：金属构件";
                    break;
                case "栏杆、栏板、扶手":
                    dt.Columns.Add("BH");///编号
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("CZ");///材质
                    dt.Columns.Add("GGXH");///规格型号
                    dt.Columns.Add("GD");///栏杆高度(mm)
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "建筑：栏杆、栏板、扶手";
                    break;
                case "耐酸防腐":
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("NSFFCLZL"); ///耐酸防腐材料种类
                    dt.Columns.Add("HD"); ///厚度
                    dt.Columns.Add("GLCCLZL");///隔离层材料种类
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "建筑：耐酸防腐";
                    break;
                case "建筑其他":
                    dt.Columns.Add("MC");///名称
                    dt.Columns.Add("FL"); ///分类
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "建筑：建筑其他";
                    break;
                #endregion

                #region 装饰
                /*=====================装饰=====================================*/
                case "裱糊":
                    dt.Columns.Add("JC");///基层
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("NTFS");///粘帖方式
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "装饰：裱糊";
                    break;
                case "涂料油漆":
                    dt.Columns.Add("FL1");///分类1
                    dt.Columns.Add("FL2");///分类2
                    dt.Columns.Add("MC");///名称
                    dt.Columns.Add("YQPZSQBS1"); ///油漆品种 刷漆遍数1
                    dt.Columns.Add("YQPZSQBS2"); ///油漆品种 刷漆遍数2
                    dt.Columns.Add("DK"); ///洞宽(mm)
                    dt.Columns.Add("DG"); ///洞高(mm)
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "装饰：涂料油漆";
                    break;
                case "装饰线条":
                    dt.Columns.Add("JC");///基层
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("NTFS");///粘帖方式
                    dt.Columns.Add("GGCC");///规格尺寸
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "装饰：装饰线条";
                    break;
                #endregion

                #region 门窗
                /*=====================门窗=====================================*/
                case "木门窗":
                    dt.Columns.Add("MMCBH");///木门窗编号
                    dt.Columns.Add("MMCFL");///木门窗分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns.Add("MMCLX");///木门窗类型
                    dt.Columns.Add("MCWJFJ");///门窗五金附件
                    dt.Columns.Add("MCWJFJ2");///门窗五金附件2
                    dt.Columns.Add("MMCYSJL");///木门窗运输距离(km)
                    dt.Columns.Add("MMCYQPZ");///木门窗油漆品种                  
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】
                    dt.Columns["FormMC"].DefaultValue = "门窗：木门窗";
                    break;
                case "钢门窗":
                    dt.Columns.Add("GMCBH");///钢门窗编号
                    dt.Columns.Add("GMCFL");///钢门窗分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns.Add("GMCCX");///钢门窗除锈
                    dt.Columns.Add("GMCYQPZ");///钢门窗油漆品种
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】
                    dt.Columns["FormMC"].DefaultValue = "门窗：钢门窗";
                    break;
                case "人防砼门":
                    dt.Columns.Add("RFMBH");///人防门编号
                    dt.Columns.Add("RFMFL");///人防门分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】
                    dt.Columns["FormMC"].DefaultValue = "门窗：人防砼门";
                    break;
                case "铝合金门窗":
                    dt.Columns.Add("LHJMCBH");///铝合金门窗编号
                    dt.Columns.Add("LHJMCFL");///铝合金门窗分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns.Add("LHJMCWJFJ");///铝合金门窗五金附件
                    dt.Columns.Add("LHJMCWJFJ2");///铝合金门窗五金附件2
                    dt.Columns.Add("LHJCS");///铝合金窗纱
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】
                    dt.Columns["FormMC"].DefaultValue = "门窗：铝合金门窗";
                    break;
                case "塑钢门窗":
                    dt.Columns.Add("SGMCBH");///塑钢门窗编号
                    dt.Columns.Add("SGMCFL");///塑钢门窗分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns.Add("SGMCWJFJ");///塑钢门窗五金附件
                    dt.Columns.Add("SGMCWJFJ2");///塑钢门窗五金附件2
                    dt.Columns.Add("SGCCS");///塑钢窗窗纱
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】                        
                    dt.Columns["FormMC"].DefaultValue = "门窗：塑钢门窗";
                    break;
                case "卷闸门":
                    dt.Columns.Add("JZMBH");///卷闸门编号
                    dt.Columns.Add("JZMFL");///卷闸门分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】
                    dt.Columns["FormMC"].DefaultValue = "门窗：卷闸门";
                    break;
                case "防盗防火门":
                    dt.Columns.Add("FDFHMBH");///防盗防火门编号
                    dt.Columns.Add("FDFHMFL");///防盗防火门分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】
                    dt.Columns["FormMC"].DefaultValue = "门窗：防盗防火门";
                    break;
                case "电动门":
                    dt.Columns.Add("DDMBH");///电动门编号
                    dt.Columns.Add("DDMFL");///电动门分类
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns["DW"].DefaultValue = "樘";///单位【樘】
                    dt.Columns["FormMC"].DefaultValue = "门窗：电动门";
                    break;
                case "幕墙":
                    dt.Columns.Add("MQBH");///幕墙编号
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("LX");///类型
                    dt.Columns.Add("DK");///洞宽(mm)
                    dt.Columns.Add("DG");///洞高(mm)
                    dt.Columns["DW"].DefaultValue = "m2";///单位【m2】
                    dt.Columns["FormMC"].DefaultValue = "门窗：幕墙";
                    break;
                #endregion

                #region 楼地面
                /*=====================楼地面=====================================*/
                case "楼地面":
                    dt.Columns.Add("MCFL");///面层分类
                    dt.Columns.Add("DCCLMC");///垫层材料名称
                    dt.Columns.Add("DCHD");///垫层厚度（mm）
                    dt.Columns.Add("ZPCCLMC");///找平层材料名称
                    dt.Columns.Add("ZPCHD");///找平层厚度（mm）
                    dt.Columns.Add("MCCLZL");///面层材料种类
                    dt.Columns.Add("JCCL");///基层材料
                    dt.Columns.Add("SCYHY");///石材养护液
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "楼地面：楼地面";
                    break;
                case "楼梯、台阶":
                    dt.Columns.Add("FL");///分类
                    dt.Columns.Add("MCFL");///面层分类
                    dt.Columns.Add("DCCLMC");///垫层材料名称
                    dt.Columns.Add("DCHD");///垫层厚度（mm）
                    dt.Columns.Add("ZPCCLMC");///找平层材料名称
                    dt.Columns.Add("ZPCHD");///找平层厚度（mm）
                    dt.Columns.Add("MCCLZL");///面层材料种类
                    dt.Columns.Add("JCCL");///基层材料
                    dt.Columns.Add("FHT"); ///防滑条
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "楼地面：楼梯、台阶";
                    break;
                case "踢脚":
                    dt.Columns.Add("MCZL");///面层种类
                    dt.Columns.Add("NTFS");///粘帖方式
                    dt.Columns.Add("JCCL");///基层材料
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "楼地面：踢脚";
                    break;
                case "楼地面做法":
                    dt.Columns.Add("ZFMC1");///做法名称1
                    dt.Columns.Add("ZFMC2");///做法名称2
                    dt.Columns.Add("ZFMC3");///做法名称3
                    dt.Columns.Add("ZFMC4");///做法名称4
                    dt.Columns.Add("DCCLMC");///垫层材料名称
                    dt.Columns.Add("DCHD");///垫层厚度
                    dt.Columns.Add("FSCL1");///防水材料1 
                    dt.Columns.Add("FSCL2");///防水材料2
                    dt.Columns.Add("BWCL");///保温材料
                    dt.Columns.Add("BWCLHD");///保温材料厚度                                            
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "楼地面：楼地面做法";
                    break;
                #endregion

                #region 墙柱面
                /*=====================墙柱面=====================================*/
                case "抹灰":
                    dt.Columns.Add("MHFL");///抹灰分类
                    dt.Columns.Add("SJZL");///砂浆种类
                    dt.Columns.Add("QTLX");///墙体类型
                    dt.Columns.Add("SJHD", typeof(Int32));///砂浆厚度
                    dt.Columns.Add("SJPHB");///砂浆配合比
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "墙柱面：抹灰";
                    break;
                case "块料面层":
                    dt.Columns.Add("MCCLPZ");///面层材料品种
                    dt.Columns.Add("KLMCGG");///块料面层规格
                    dt.Columns.Add("QTCL");///墙体材料
                    dt.Columns.Add("YWJC");///有无基层
                    dt.Columns.Add("GNTFS");///挂、粘帖方式
                    dt.Columns.Add("TJCHDCLZL");///贴结层厚度、材料种类
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "墙柱面：块料面层";
                    break;
                case "面层装饰":
                    dt.Columns.Add("LGCLPZGG");///龙骨材料品种、规格
                    dt.Columns.Add("JCCLPZGG");///基层材料品种、规格
                    dt.Columns.Add("MCCLPZGG");///面层材料品种、规格
                    dt.Columns.Add("GDCLPZGG");///隔断材料品种、规格
                    dt.Columns.Add("ZLGJSMPZGG");///柱龙骨及饰面品种、规格
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns.Add("bl");///标识列
                    dt.Columns["FormMC"].DefaultValue = "墙柱面：面层装饰";
                    break;
                case "墙柱面做法":
                    dt.Columns.Add("ZFMC1");///做法名称1
                    dt.Columns.Add("ZFMC2");///做法名称2
                    dt.Columns.Add("ZFMC3");///做法名称3
                    dt.Columns.Add("FSCL1");///防水材料1 
                    dt.Columns.Add("FSCL2");///防水材料2
                    dt.Columns.Add("BWCL");///保温材料
                    dt.Columns.Add("BWCLHD");///保温材料厚度                                            
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "墙柱面：墙柱面做法";

                    break;
                #endregion

                #region 天棚
                /*=====================天棚=====================================*/
                case "天棚抹灰":
                    dt.Columns.Add("SJLX");///砂浆类型
                    dt.Columns.Add("JC");///基层
                    dt.Columns.Add("PHBSJZL");///配合比、砂浆种类
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "天棚：天棚抹灰";
                    break;
                case "平面、跌级天棚":
                    dt.Columns.Add("LGGGCZ");///龙骨规格、材质
                    dt.Columns.Add("JCGGCZ");///基层规格、材质
                    dt.Columns.Add("MCGGCZ");///面层规格、材质
                    dt.Columns.Add("DCGGCZ");///灯槽规格、材质
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns.Add("bl");///标识列
                    dt.Columns["FormMC"].DefaultValue = "天棚：平面、跌级天棚";
                    break;
                case "艺术造型天棚":
                    dt.Columns.Add("LGGGCZ");///龙骨规格、材质
                    dt.Columns.Add("JCGGCZ");///基层规格、材质
                    dt.Columns.Add("MCGGCZ");///面层规格、材质
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns.Add("bl");///标识列
                    dt.Columns["FormMC"].DefaultValue = "天棚：艺术造型天棚";
                    break;
                case "其他天棚":
                    dt.Columns.Add("TPFL");///天棚分类
                    dt.Columns.Add("GGCZ");///规格、材质
                    dt.Columns["DW"].DefaultValue = "M2";
                    dt.Columns["FormMC"].DefaultValue = "天棚：其他天棚";
                    break;
                #endregion

                #endregion

                #region 安装

                #region 第一册
                case "切削设备":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("SBZL");//设备质量(t以内)
                    dt.Columns.Add("DJLSKGJ");//地脚螺栓孔灌浆
                    dt.Columns.Add("SBDZYJCJGJ");//设备底座与基础间灌浆
                    dt.Columns["FormMC"].DefaultValue = "第一册：切削设备";
                    break;
                case "起重设备":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第一册：起重设备";
                    break;
                case "风机安装":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第一册：风机安装";
                    break;
                case "泵安装":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第一册：泵安装";
                    break;
                case "其他机械":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第一册：其他机械";
                    break;
                case "附属设备":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第一册：附属设备";
                    break;
                #endregion

                #region 第二册

                case "变压器":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第二册：变压器";
                    break;
                case "配电装置":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第二册：配电装置";
                    break;
                case "母线绝缘子":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第二册：母线绝缘子";
                    break;
                case "控制设备及低压电器":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第二册：控制设备及低压电器";
                    break;
                case "蓄电池":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("RL");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第二册：蓄电池";
                    break;
                case "电机":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGRLGL");//规格、容量、功率
                    dt.Columns["FormMC"].DefaultValue = "第二册：电机";
                    break;
                case "滑触线":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：滑触线";
                    break;
                case "电缆沟及桥架":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：电缆沟及桥架";
                    break;
                case "电缆敷设":
                    dt.Columns.Add("DLFL");//电缆分类
                    dt.Columns.Add("GGXH");//规格型号
                    dt.Columns.Add("JGGB");//揭（盖）盖板
                    dt.Columns.Add("DLZDTGGXH");//电缆终端头规格型号
                    dt.Columns.Add("DLZJTGGXH");//电缆中间头规格型号
                    dt.Columns.Add("DLBHG");//电缆保护管
                    dt.Columns.Add("FHZR");//防火阻燃
                    dt.Columns.Add("DLFH");//电缆防护
                    dt.Columns["FormMC"].DefaultValue = "第二册：电缆敷设";
                    break;
                case "防雷接地":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("JDJB");//接地极（板）
                    dt.Columns.Add("JDMX");//接地母线
                    dt.Columns.Add("JDKJX");//接地跨接线
                    dt.Columns.Add("BLZW");//避雷针（网）
                    dt.Columns.Add("BLYXX");//避雷引下线
                    dt.Columns.Add("BLW");//避雷网
                    dt.Columns.Add("DDWLJ");//等电位联结
                    dt.Columns.Add("YQFF");//油漆（防腐）
                    dt.Columns["FormMC"].DefaultValue = "第二册：防雷接地";
                    break;
                case "10KV以下架空配电线路":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：10KV以下架空配电线路";
                    break;
                case "电气调整试验":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：电气调整试验";
                    break;

                #region 配管配线
                case "配管":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("PGCZ");//配管材质
                    dt.Columns.Add("PGFS");//配管方式
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：配管";
                    break;
                case "配线":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("PXFS");//配线方式
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：配线";
                    break;
                case "钢索架设母线":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("FSBW");//敷设部位
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：钢索架设母线";
                    break;
                case "接线盒":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("MZAZ");//明装、暗装
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：接线盒";
                    break;
                case "凿槽":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("ZCBW");//凿槽部位
                    dt.Columns.Add("ZCFS");//凿槽方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第二册：凿槽";
                    break;
                case "打透眼":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("DTYBW");//打透眼部位
                    dt.Columns.Add("ZJ");//直径
                    dt.Columns["FormMC"].DefaultValue = "第二册：打透眼";
                    break;
                #endregion

                #region 照明灯具
                case "普通灯具":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("ZJ");//直径
                    dt.Columns.Add("SYTH");//示意图号
                    dt.Columns["FormMC"].DefaultValue = "第二册：普通灯具";
                    break;
                case "装饰灯具":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("ZJ");//直径
                    dt.Columns.Add("SYTH");//示意图号
                    dt.Columns["FormMC"].DefaultValue = "第二册：装饰灯具";
                    break;
                case "其他灯具":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("ZJ");//直径
                    dt.Columns.Add("SYTH");//示意图号
                    dt.Columns["FormMC"].DefaultValue = "第二册：其他灯具";
                    break;
                case "开关插座":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("ZJ");//直径
                    dt.Columns.Add("SYTH");//示意图号
                    dt.Columns["FormMC"].DefaultValue = "第二册：开关插座";
                    break;
                case "电梯电气":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("ZJ");//直径
                    dt.Columns.Add("SYTH");//示意图号
                    dt.Columns["FormMC"].DefaultValue = "第二册：电梯电气";
                    break;
                #endregion

                #endregion

                #region 第六册
                case "管道安装":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GJ");//管径（mm）
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第六册：管道安装";
                    break;
                case "管件连接":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GJ");//管径（mm）
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第六册：管件连接";
                    break;
                case "阀门":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GJ");//管径（mm）
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第六册：阀门";
                    break;
                case "法兰":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GJ");//管径（mm）
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第六册：法兰";
                    break;
                case "管件":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GJ");//管径（mm）
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第六册：管件";
                    break;
                case "吹排清洗压力试验":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GCZJYN");//公称直径(mm)以内
                    dt.Columns["FormMC"].DefaultValue = "第六册：吹排清洗压力试验";
                    break;
                case "其他管道":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GCZJYN");//公称直径(mm)以内
                    dt.Columns["FormMC"].DefaultValue = "第六册：其他管道";
                    break;
                #endregion

                #region 第七册

                #region 水灭火系统

                case "水灭火管道安装":
                    dt.Columns.Add("AZBW");//安装部位
                    dt.Columns.Add("CZLX");//材质类型
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("ZDJ");//支吊架
                    dt.Columns["FormMC"].DefaultValue = "第七册：水灭火管道安装";
                    break;
                case "水灭火系统组件":
                    dt.Columns.Add("CZLX");//材质类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第七册：水灭火系统组件";
                    break;
                case "消火栓":
                    dt.Columns.Add("AZBW");//安装部位
                    dt.Columns.Add("AZFS");//安装方式
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第七册：消火栓";
                    break;
                case "气压罐":
                    dt.Columns.Add("MC");//名称
                    dt.Columns["MC"].DefaultValue = "气压罐";
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第七册：气压罐";
                    break;
                #endregion

                #region 气灭火系统

                case "气灭火管道安装":
                    dt.Columns.Add("CZLX");//材质类型
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第七册：气灭火管道安装";
                    break;
                case "气灭火系统组件":
                    dt.Columns.Add("CZLX");//材质类型
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第七册：气灭火系统组件";
                    break;
                case "严密性装置调试":
                    dt.Columns.Add("MC");//名称
                    dt.Columns.Add("SYRQGG");//试验容器规格
                    dt.Columns["FormMC"].DefaultValue = "第七册：严密性装置调试";
                    break;
                #endregion


                case "泡沫灭火系统":
                    dt.Columns.Add("PMFSQZL");//泡沫发生器种类
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("PMFSQXH");//泡沫发生器型号
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第七册：泡沫灭火系统";
                    break;
                case "火灾自动报警系统":
                    dt.Columns.Add("MC");//名称
                    dt.Columns.Add("DXZZXZ");//多线制、总线制
                    dt.Columns.Add("AZFS");//安装方式
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("KZDSL");//控制点数量
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第七册：火灾自动报警系统";
                    break;
                case "系统装置调试":
                    dt.Columns.Add("XTZZTSMC");//系统装置调试名称
                    dt.Columns.Add("DS");//点数
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第七册：系统装置调试";
                    break;
                #endregion

                #region 第八册

                #region 给排水、雨水
                case "给排水室外无缝钢管":
                    dt.Columns.Add("SSJZ");//输送介质
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位【不用防报错】
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：给排水室外无缝钢管";
                    break;
                case "给排水室外其他管材":
                    dt.Columns.Add("SSJZ");//输送介质
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位【不用防报错】
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：给排水室外其他管材";
                    break;
                case "给排水室内无缝钢管":
                    dt.Columns.Add("SSJZ");//输送介质
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求2
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：给排水室内无缝钢管";
                    break;
                case "给排水室内其他管材":
                    dt.Columns.Add("SSJZ");//输送介质
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：给排水室内其他管材";
                    break;
                case "给排水埋地管道":
                    dt.Columns.Add("SSJZ");//输送介质
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：给排水埋地管道";
                    break;
                case "给排水卫生器具":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("ZZXSGGXH");//组装形式、规格、型号
                    dt.Columns.Add("AZGD");//安装高度
                    dt.Columns["FormMC"].DefaultValue = "第八册：给排水卫生器具";
                    break;
                case "给排水水表":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("SBXH");//水表型号
                    dt.Columns.Add("AZGD");//安装高度
                    dt.Columns["FormMC"].DefaultValue = "第八册：给排水水表";
                    break;
                #endregion

                #region 采暖热源
                case "采暖热源室外无缝钢管":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求2
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：采暖热源室外无缝钢管";
                    break;
                case "采暖热源室外其他管材":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位【不用防报错】
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：采暖热源室外其他管材";
                    break;
                case "采暖热源室内无缝钢管":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求2
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：采暖热源室内无缝钢管";
                    break;
                case "采暖热源室内其他管材":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：采暖热源室内其他管材";
                    break;
                case "采暖热源埋地管道":
                    dt.Columns.Add("SSJZ");//输送介质
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：采暖热源埋地管道";
                    break;
                case "采暖热源供暖器具":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("GCZJ");//公称直径
                    dt.Columns.Add("AZGD");//安装高度
                    dt.Columns["FormMC"].DefaultValue = "第八册：采暖热源供暖器具";
                    break;
                #endregion

                #region 燃气管道
                case "燃气管道":
                    dt.Columns.Add("AZBW");//安装部位
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：燃气管道";
                    break;
                case "燃气管道附件":
                    dt.Columns.Add("GDFJMC");//管道附件名称
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("AZGD");//安装高度
                    dt.Columns["DW"].DefaultValue = "个";
                    dt.Columns["FormMC"].DefaultValue = "第八册：燃气管道附件";
                    break;
                case "燃气加热设备":
                    dt.Columns.Add("GNYT");//功能、用途
                    dt.Columns.Add("GGXH");//规格型号
                    dt.Columns.Add("AZGD");//安装高度
                    dt.Columns["DW"].DefaultValue = "台";
                    dt.Columns["FormMC"].DefaultValue = "第八册：燃气加热设备";
                    break;
                case "燃气灶具":
                    dt.Columns.Add("SYFW");//使用范围
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("AZGD");//安装高度
                    dt.Columns["FormMC"].DefaultValue = "第八册：燃气灶具";
                    break;
                case "燃气表":
                    dt.Columns.Add("SYFW");//使用范围
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("AZGD");//安装高度
                    dt.Columns["DW"].DefaultValue = "块";
                    dt.Columns["FormMC"].DefaultValue = "第八册：燃气表";
                    break;
                #endregion

                #region 消火栓
                case "消火栓室外无缝钢管":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求2
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：消火栓室外无缝钢管";
                    break;
                case "消火栓室外其他管材":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位【不用防报错】
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    //dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求【不用防报错】2
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：消火栓室外其他管材";
                    break;
                case "消火栓室内无缝钢管":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWQFFSYYQ2");//保温前防腐、刷油要求2
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：消火栓室内无缝钢管";
                    break;
                case "消火栓室内其他管材":
                    dt.Columns.Add("SSJZ");//输送介质【不用防报错】
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：消火栓室内其他管材";
                    break;
                case "消火栓埋地管道":
                    dt.Columns.Add("SSJZ");//输送介质
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("LJFS");//连接方式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("TGCZ");//套管材质
                    dt.Columns.Add("TGGS", typeof(int));//套管个数
                    dt.Columns.Add("CX");//除锈【不用防报错】
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求【不用防报错】
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD");//保温厚度(mm)
                    dt.Columns.Add("FCCBHCCL");//防潮层、保护层材料
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns.Add("BWHFFSYYQ2");//保温后防腐、刷油要求2
                    dt.Columns["DW"].DefaultValue = "M";
                    dt.Columns["FormMC"].DefaultValue = "第八册：消火栓埋地管道";
                    break;
                #endregion

                #region 阀门_法兰
                case "阀门_法兰":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("FMFLPZMC");//阀门法兰品种、名称
                    dt.Columns.Add("JTXS");//接头形式
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("BWQFFSYYQ");//保温前防腐、刷油要求
                    dt.Columns.Add("BWJRCLZL");//保温绝热材料种类
                    dt.Columns.Add("BWHD", typeof(int));//保温厚度
                    dt.Columns.Add("BWHFFSYYQ");//保温后防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第八册：阀门_法兰";
                    break;
                #endregion


                #region 其他
                case "管道支架":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("CZBW");//操作部位
                    dt.Columns.Add("CX");//除锈
                    dt.Columns.Add("FFSYYQ");//防腐、刷油要求
                    dt.Columns["FormMC"].DefaultValue = "第八册：管道支架";
                    break;
                case "伸缩器":
                    dt.Columns.Add("FL");//分类
                    dt.Columns["FL"].DefaultValue = "伸缩器";
                    dt.Columns.Add("LJFS");//链接方式
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns["FormMC"].DefaultValue = "第八册：伸缩器";
                    break;
                case "水箱":
                    dt.Columns.Add("FL");//分类
                    dt.Columns["FL"].DefaultValue = "小型容器";
                    dt.Columns.Add("SXCZXZ");//水箱材质、形状
                    dt.Columns.Add("ZLRL");//重量、容量
                    dt.Columns.Add("SXDZBG");//水箱底座标高
                    dt.Columns["FormMC"].DefaultValue = "第八册：水箱";
                    break;
                case "管道干线碰头":
                    dt.Columns.Add("FL");//分类
                    dt.Columns["FL"].DefaultValue = "管道干线碰头";
                    dt.Columns.Add("CZJKLX");//材质、接口类型
                    dt.Columns.Add("GCZJ");//公称直径
                    dt.Columns["FormMC"].DefaultValue = "第八册：管道干线碰头";
                    break;
                case "凿槽_刨沟_补槽":
                    dt.Columns.Add("FL");//分类
                    dt.Columns["FL"].DefaultValue = "凿槽、刨沟、补槽";
                    dt.Columns.Add("ZCLB");//凿槽类别
                    dt.Columns.Add("JGLB");//结构类别
                    dt.Columns.Add("CGCCKS");//槽沟尺寸宽×深(mm以内)
                    dt.Columns["FormMC"].DefaultValue = "第八册：凿槽刨沟补槽";
                    break;
                case "打堵洞眼":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("JCCZ");//基层材质
                    dt.Columns.Add("DYZJ");//洞眼直径(mm以内)
                    dt.Columns["FormMC"].DefaultValue = "第八册：打堵洞眼";
                    break;
                case "塑料检查井":
                    dt.Columns.Add("FL");//分类
                    dt.Columns["FL"].DefaultValue = "塑料检查井";
                    dt.Columns.Add("GGXH");//型号、规格
                    dt.Columns["FormMC"].DefaultValue = "第八册：塑料检查井";
                    break;
                case "其他器具":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("CLPZMC");//材料品种、名称
                    dt.Columns.Add("JTXS");//接头形式
                    dt.Columns.Add("GG");//规格
                    dt.Columns["FormMC"].DefaultValue = "第八册：其他器具";
                    break;
                #endregion

                #endregion

                #region 第九册
                case "通风及空调设备":
                    dt.Columns.Add("MC");//名称
                    dt.Columns.Add("AZFS");//安装方式
                    dt.Columns.Add("GGXH");//规格型号
                    dt.Columns.Add("SBDZAZGDJDPM");//设备底座安装高度距地平面(m)
                    dt.Columns["FormMC"].DefaultValue = "第九册：通风及空调设备";
                    break;
                #region 其他
                case "风管制作安装":
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("XZ");//形状
                    dt.Columns.Add("JKXS");//接口形式
                    dt.Columns.Add("BWTGSJYQ");//保温套管设计要求
                    dt.Columns.Add("BCHD");//板材厚度（mm）
                    dt.Columns.Add("ZCHZJ");//周长或直径
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第九册：风管制作安装";
                    break;
                case "调节阀制作安装":
                    dt.Columns.Add("TJFMC");//调节阀名称
                    dt.Columns.Add("ZJHZCYN");//直径或周长(mm)以内
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第九册：调节阀制作安装";
                    break;
                case "风口制作安装":
                    dt.Columns.Add("FKMC");//风口名称
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GGXH");//规格、型号
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第九册：风口制作安装";
                    break;
                case "风帽制作安装":
                    dt.Columns.Add("CZ");//材质
                    dt.Columns.Add("XZ");//形状
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第九册：风帽制作安装";
                    break;
                case "罩类制作安装":
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("GG");//规格
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第九册：罩类制作安装";
                    break;
                case "消声器静压箱":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("LB");//类别
                    dt.Columns.Add("CCGG");//尺寸、规格
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第九册：消声器静压箱";
                    break;
                case "其他部件":
                    dt.Columns.Add("MC");//名称
                    dt.Columns.Add("LX");//类型
                    dt.Columns.Add("CCGG");//尺寸、规格
                    dt.Columns.Add("CZGD");//操作高度
                    dt.Columns["FormMC"].DefaultValue = "第九册：其他部件";
                    break;
                #endregion

                #region 第十册  第十一册 第十二册
                case "自动化仪表安装":
                    dt.Columns.Add("FL1");//分类1
                    dt.Columns.Add("FL2");//分类2
                    dt.Columns.Add("MC");//名称
                    dt.Columns["FormMC"].DefaultValue = "第十册：自动化仪表安装";
                    break;
                case "综合布线":
                    dt.Columns.Add("FL");//分类
                    dt.Columns.Add("GGXH");//规格、名称
                    dt.Columns.Add("ZHBXXH");//综合布线型号
                    dt.Columns["FormMC"].DefaultValue = "第十一册：综合布线";
                    break;
                case "智能系统":
                    dt.Columns.Add("XTFL");//系统分类
                    dt.Columns.Add("SBFL");//设备分类
                    dt.Columns.Add("GGMC");//规格、名称
                    dt.Columns["FormMC"].DefaultValue = "第十二册：智能系统";
                    break;
                #endregion
                #endregion

                #endregion
            }
            dt.Columns.Add("SWGCL", typeof(float));///实物工程量
            dt.Columns.Add("SZBW");///所在部位
            dt.Columns.Add("BZ");///备注
            dt.Columns.Add("IsFresh", typeof(bool));///是否刷新
            return dt;
        }
        #endregion
    }
}