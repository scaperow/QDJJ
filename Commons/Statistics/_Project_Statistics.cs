/*
 为单位工程准备的变量计算结果集
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Project_Statistics : _Statistics, IAttributes
    {
        /// <summary>
        /// 当前所属的单位工程
        /// </summary>
        private _UnitProject m_Parent;

        /// <summary>
        /// 当前所属的单位工程
        /// </summary>
        public new _UnitProject Parent
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
        /// 构造函数
        /// </summary>
        /// <param name="p_Parent"></param>
        public _Project_Statistics(_UnitProject p_Parent)
            : base()
        {
            this.m_Parent = p_Parent;
        }

        /// <summary>
        /// 重写如何开始计算
        /// </summary>
        public override void Begin()
        {
            //此处处理开始统计代码
            //1.统计当前单位工程的分部分项代码
            //2.统计当前单位工程措施项目代码
            //3.统计当前单位工程其他项目代码
            this.ResultVarable.DataSource.Clear();
            builder();
            this.SetFBFX();
            this.SetFBFXOther();
            this.SetCSXM();
            this.SetQTXM();
        }

        public override void Calculate()
        {

            this.m_Parent.Property.SubSegments.Statistics.Calculate();
            this.m_Parent.Property.MeasuresProject.Statistics.Calculate();
            //this.m_Parent.Property.OtherProject.Statistics.Calculate();
            this.Begin();
        }

        /// <summary>
        /// 设置其他项目的合计
        /// </summary>
        private void SetQTXM()
        {
            this.ResultVarable.Set("QTXMHJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get(_Statistics.FILED_ZHHJ));
            this.ResultVarable.Set("QTXMCJHJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("QTXMCJHJ"));
            this.ResultVarable.Set("QTXMRGCJHJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("QTXMRGCJHJ"));
            this.ResultVarable.Set("QTXMJSCJHJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("QTXMJSCJHJ"));//结算差价
            this.ResultVarable.Set("ZLJE", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("ZLJE"));
            this.ResultVarable.Set("SJBGCJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("SJBGCJ"));
            this.ResultVarable.Set("ZYGCZGJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("ZYGCZGJ"));
            this.ResultVarable.Set("ZCSBZGJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("ZCSBZGJ"));
            this.ResultVarable.Set("LXFBGCE", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("LXFBGCE"));
            this.ResultVarable.Set("JRG", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("JRG"));
            this.ResultVarable.Set("JRGRG", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("JRGRG"));
            this.ResultVarable.Set("JRGCL", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("JRGCL"));
            this.ResultVarable.Set("JRGJX", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("JRGJX"));
            this.ResultVarable.Set("ZCBFWF", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("ZCBFWF"));
            this.ResultVarable.Set("FBGLFWF", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("FBGLFWF"));
            this.ResultVarable.Set("FBRBGF", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("FBRBGF"));
            this.ResultVarable.Set("FSPTJJJ", this.m_Parent.Property.OtherProject.Statistics.ResultVarable.Get("FSPTJJJ"));
        }

        /// <summary>
        /// 设置分部分项参数
        /// </summary>
        private void SetFBFX()
        {
            ///循环分部分项计算结果数据添加到单位工程数据源中
            /*foreach (DataRow row in this.m_Parent.SubSegments.Statistics.ResultVarable.DataSource.Rows)
            {
                
            }
            */
            //this.ResultVarable.Set("HHJXFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_HHJXRGF));
            this.ResultVarable.Set("FBFXHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_ZHHJ));
            this.ResultVarable.Set("FBFXRGFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_RGFHJ));
            this.ResultVarable.Set("FBFXCLFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_CLFHJ));
            this.ResultVarable.Set("FBFXZCFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_ZCFHJ));
            this.ResultVarable.Set("FBFXSBFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_SBFHJ));
            this.ResultVarable.Set("FBFXJXFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_JXFHJ));
            this.ResultVarable.Set("FBFXGLFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_GLFHJ));
            this.ResultVarable.Set("FBFXLRHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_LRHJ));
            this.ResultVarable.Set("FBFXFXHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FXHJ));
            this.ResultVarable.Set("FBFXZGJEHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_ZGHJ));
            this.ResultVarable.Set("FBFXJGJEHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_JGJEHJ));
            this.ResultVarable.Set("FBFXFBJEHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBJEHJ));

            //this.ResultVarable.Set("FBFXJBHZHJ", this.m_Parent.SubSegments.Statistics.ResultVarable.Get(_Statistics.));
            this.ResultVarable.Set("FBFXDEHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DEZHHJ));
            this.ResultVarable.Set("FBFXDERGFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DERGFHJ));
            this.ResultVarable.Set("FBFXDECLFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DECLFHJ));
            this.ResultVarable.Set("FBFXDEZCFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DEZCFHJ));
            this.ResultVarable.Set("FBFXDESBFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DESBFHJ));
            this.ResultVarable.Set("FBFXDEJXFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DEJXFHJ));

            this.ResultVarable.Set("FBFXDEGLFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DEGLFHJ));
            this.ResultVarable.Set("FBFXDELRHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DELRHJ));
            this.ResultVarable.Set("FBFXDEFXHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DEFXHJ));
            //this.ResultVarable.Set("FBFXDEZGJEHJ", this.m_Parent.SubSegments.Statistics.ResultVarable.Get(_Statistics.));
            //this.ResultVarable.Set("FBFXDEJGJEHJ", this.m_Parent.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DESBFHJ));
            //this.ResultVarable.Set("FBFXDEFBJEHJ", this.m_Parent.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_DESBFHJ));

            //this.ResultVarable.Set("FBFXDEJBHZHJ", this.m_Parent.SubSegments.Statistics.ResultVarable.Get(_Statistics.));


            this.ResultVarable.Set("FBFXJCHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXJCHJ));
            //人工费价差加上混合机械人工（J4001）
            this.ResultVarable.Set("FBFXRGJCHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.GetDecimal(_Statistics.FILED_FBFXRGJCHJ));
            this.ResultVarable.Set("FBFXCLJCHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXCLJCHJ));
            this.ResultVarable.Set("FBFXJXJCHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXJXJCHJ));

            this.ResultVarable.Set("FBFXCJHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXCJHJ));
            this.ResultVarable.Set("FBFXRGCJHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXRGCJHJ));
            this.ResultVarable.Set("FBFXCLCJHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXCLCJHJ));
            this.ResultVarable.Set("FBFXJXCJHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXJXCJHJ));

            this.ResultVarable.Set("FBFXGFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_GFHJ));
            this.ResultVarable.Set("FBFXSJHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_SJHJ));

            //this.ResultVarable.Set("HHJXFHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_HHJXRGF));
            //this.ResultVarable.Set("FBFXJCHJ", this.m_Parent.Property.SubSegments.Statistics.ResultVarable.Get(_Statistics.FILED_HHJXRGFJC));

        }
        /// <summary>
        /// 分部分项特殊参数
        /// </summary>
        private void SetFBFXOther()
        {


            decimal 人工rgf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                              where n as _SubheadingsInfo != null && n.TX == "人工"
                              select n.RGFHJ).Sum();

            人工rgf+= (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                     where n as _SubheadingsInfo!=null && n.TX == "人工"
                     select n.RGFHJ).Sum();
                        
            decimal 建筑rgf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "建筑"
                             select n.RGFHJ).Sum();
            建筑rgf += (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "建筑"
                             select n.RGFHJ).Sum();


            decimal 安装rgf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "安装"
                             select n.RGFHJ).Sum();

            安装rgf += (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "安装"
                             select n.RGFHJ).Sum();


            decimal 建筑jxf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                   where n as _SubheadingsInfo != null && n.TX == "建筑"
                             select n.JXFHJ).Sum();

            建筑jxf += (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "建筑"
                             select n.JXFHJ).Sum();


            decimal 桩基CLF = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "桩基"
                             select n.CLFHJ).Sum();
            桩基CLF = (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "桩基"
                             select n.CLFHJ).Sum();

            decimal 机械xmf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "机械"
                              select n.ZHHJ).Sum();
            机械xmf += (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "机械"
                             select n.ZHHJ).Sum();


            decimal 桩基xmf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "桩基"
                             select n.ZHHJ).Sum();
            桩基xmf += (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "桩基"
                             select n.ZHHJ).Sum();


            decimal 建筑xmf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "建筑"
                             select n.ZHHJ).Sum();

            建筑xmf += (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "建筑"
                             select n.ZHHJ).Sum();

            decimal 装饰xmf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "装饰"
                             select n.ZHHJ).Sum();
            装饰xmf += (from n in this.m_Parent.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                             where n as _SubheadingsInfo != null && n.TX == "装饰"
                             select n.ZHHJ).Sum();

            decimal QJZxmf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                              where n as _FixedListInfo != null && n.TX.ToUpper() == "JZ"
                                     select n.ZHHJ).Sum();
                                             
            decimal QZSjxf = (from n in this.m_Parent.Property.SubSegments.ObjectsList.Cast<_ObjectInfo>()
                              where n as _FixedListInfo != null && n.TX.ToUpper() == "ZS"
                              select n.ZHHJ).Sum();

            this.ResultVarable.Set("Z[人工].rgf", 人工rgf);
            this.ResultVarable.Set("Z[建筑].rgf", 建筑rgf);
            this.ResultVarable.Set("Z[安装].rgf", 安装rgf);
            this.ResultVarable.Set("Z[桩基].clf", 桩基CLF);

            this.ResultVarable.Set("Z[建筑].jxf", 建筑jxf);
            this.ResultVarable.Set("Z[机械].xmf", 机械xmf);
            this.ResultVarable.Set("Z[桩基].xmf", 桩基xmf);
            this.ResultVarable.Set("Z[建筑].xmf", 建筑xmf);
            this.ResultVarable.Set("Z[装饰].xmf", 装饰xmf);

            this.ResultVarable.Set("Q[JZ].xmf", QJZxmf);
            this.ResultVarable.Set("Q[ZS].jxf", QZSjxf);

        }

        /// <summary>
        /// 设置措施项目
        /// </summary>
        private void SetCSXM()
        {


            this.ResultVarable.Set("CSXMHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_ZHHJ));
            this.ResultVarable.Set("CSXMRGFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_RGFHJ));
            this.ResultVarable.Set("CSXMCLFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_CLFHJ));
            this.ResultVarable.Set("CSXMZCFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_ZCFHJ));
            this.ResultVarable.Set("CSXMSBFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_SBFHJ));
            this.ResultVarable.Set("CSXMGLFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_GLFHJ));
            this.ResultVarable.Set("CSXMLRHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_LRHJ));
            this.ResultVarable.Set("CSXMFXHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FXHJ));
            this.ResultVarable.Set("CSXMJXFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_JXFHJ));
            //this.ResultVarable.Set("CSXMZGJEHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.));咱估金额
            //this.ResultVarable.Set("CSXMJGJEHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.));甲供金额
            //this.ResultVarable.Set("CSXMFBJEHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.));分包金额
            //this.ResultVarable.Set("CSXMJBHZHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.));∑措施项目局部汇总金额合价汇总
            this.ResultVarable.Set("CSXMDEHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DEZHHJ));
            this.ResultVarable.Set("CSXMDERGFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DERGFHJ));
            this.ResultVarable.Set("CSXMDECLFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DECLFHJ));
            this.ResultVarable.Set("CSXMDEZCFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DEZCFHJ));
            this.ResultVarable.Set("CSXMDESBFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DESBFHJ));
            this.ResultVarable.Set("CSXMDEGLFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DEGLFHJ));
            this.ResultVarable.Set("CSXMDELRHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DELRHJ));
            this.ResultVarable.Set("CSXMDEFXHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DEFXHJ));
            this.ResultVarable.Set("CSXMDEJXFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_DEJXFHJ));
            //this.ResultVarable.Set("CSXMDEZGJEHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.)); 定额暂估金额
            //this.ResultVarable.Set("CSXMDEJGJEHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_ZCFHJ));定额甲供
            //this.ResultVarable.Set("CSXMDEFBJEHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_SBFHJ));定额分包
            //this.ResultVarable.Set("CSXMDEJBHZHJ", this.m_Parent.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_GLFHJ));∑定额措施项目局部汇总金额合价汇总
            //this.ResultVarable.Set("CSXMJC", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_JCHJ));
            this.ResultVarable.Set("KCAQWMCSF", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get("KCAQWMCSF"));



            this.ResultVarable.Set("CSXMJCHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXJCHJ));
            this.ResultVarable.Set("CSXMRGJCHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXRGJCHJ));
            this.ResultVarable.Set("CSXMCLJCHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXCLJCHJ));
            this.ResultVarable.Set("CSXMJXJCHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXJXJCHJ));
            this.ResultVarable.Set("CSXMCJHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXCJHJ));
            this.ResultVarable.Set("CSXMRGCJHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXRGCJHJ));
            this.ResultVarable.Set("CSXMCLCJHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXCLCJHJ));
            this.ResultVarable.Set("CSXMJXCJHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_FBFXJXCJHJ));

            this.ResultVarable.Set("CSAQWM", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get("CSAQWM"));
            this.ResultVarable.Set("CSWMSG", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get("CSWMSG"));
            this.ResultVarable.Set("CSHJBH", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get("CSHJBH"));
            this.ResultVarable.Set("CSLSSS", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get("CSLSSS"));

            this.ResultVarable.Set("CSXMGFHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_GFHJ));
            this.ResultVarable.Set("CSXMSJHJ", this.m_Parent.Property.MeasuresProject.Statistics.ResultVarable.Get(_Statistics.FILED_SJHJ));


        }

        /// <summary>
        /// 创建子目变量对象
        /// </summary>
        private void builder()
        {
            #region -----------------------------分部分项最终参数------------------------
            this.ResultVarable.Set("FBFXHJ", 0, "[分部分项]分部分项合计");
            this.ResultVarable.Set("FBFXRGFHJ", 0, "[分部分项]分部分项人工费合计");
            this.ResultVarable.Set("FBFXCLFHJ", 0, "[分部分项]分部分项材料费合计");
            this.ResultVarable.Set("FBFXZCFHJ", 0, "[分部分项]分部分项主材费合计");
            this.ResultVarable.Set("FBFXSBFHJ", 0, "[分部分项]分部分项设备费合计");
            this.ResultVarable.Set("FBFXJXFHJ", 0, "[分部分项]分部分项机械费合计");
            this.ResultVarable.Set("FBFXGLFHJ", 0, "[分部分项]分部分项管理费合计");
            this.ResultVarable.Set("FBFXLRHJ", 0, "[分部分项]分部分项利润合计");
            this.ResultVarable.Set("FBFXFXHJ", 0, "[分部分项]分部分项风险合计");
            this.ResultVarable.Set("FBFXZGJEHJ", 0, "[分部分项]分部分项暂估金额合计");
            this.ResultVarable.Set("FBFXJGJEHJ", 0, "[分部分项]分部分项甲供金额合计");
            this.ResultVarable.Set("FBFXFBJEHJ", 0, "[分部分项]分部分项分包金额合计");
            this.ResultVarable.Set("FBFXJBHZHJ", 0, "[分部分项]分部分项局部汇总金额合计");
            this.ResultVarable.Set("FBFXDEHJ", 0, "[分部分项]分部分项定额价合计");
            this.ResultVarable.Set("FBFXDERGFHJ", 0, "[分部分项]分部分项定额人工费合计");
            this.ResultVarable.Set("FBFXDECLFHJ", 0, "[分部分项]分部分项定额材料费合计");
            this.ResultVarable.Set("FBFXDEZCFHJ", 0, "[分部分项]分部分项定额主材费合计");
            this.ResultVarable.Set("FBFXDESBFHJ", 0, "[分部分项]分部分项定额设备费合计");
            this.ResultVarable.Set("FBFXDEJXFHJ", 0, "[分部分项]分部分项定额机械费合计");
            this.ResultVarable.Set("FBFXDEGLFHJ", 0, "[分部分项]分部分项定额管理费合计");
            this.ResultVarable.Set("FBFXDELRHJ", 0, "[分部分项]分部分项定额利润合计");
            this.ResultVarable.Set("FBFXDEFXHJ", 0, "[分部分项]分部分项定额风险合计");
            this.ResultVarable.Set("FBFXDEZGJEHJ", 0, "[分部分项]分部分项定额暂估金额合计");
            this.ResultVarable.Set("FBFXDEJGJEHJ", 0, "[分部分项]分部分项定额甲供金额合计");
            this.ResultVarable.Set("FBFXDEFBJEHJ", 0, "[分部分项]分部分项定额分包金额合计");
            this.ResultVarable.Set("FBFXDEJBHZHJ", 0, "[分部分项]分部分项定额局部汇总金额合计");


            // this.ResultVarable.Set("HHJXFHJ", 0, "[分部分项]混合机械人工费合价");
            this.ResultVarable.Set("FBFXJCHJ", 0, "[分部分项]分部分项价差合计");
            this.ResultVarable.Set("FBFXRGJCHJ", 0, "[分部分项]分部分项人工费价差合计");
            this.ResultVarable.Set("FBFXCLJCHJ", 0, "[分部分项]分部分项材料费价差合计");
            this.ResultVarable.Set("FBFXJXJCHJ", 0, "[分部分项]分部分项机械费价差合计");
            this.ResultVarable.Set("FBFXCJHJ", 0, "[分部分项]分部分项可能发生的差价合计");
            this.ResultVarable.Set("FBFXRGCJHJ", 0, "[分部分项]分部分项人工费调增差价合计");
            this.ResultVarable.Set("FBFXCLCJHJ", 0, "[分部分项]分部分项材料费调增差价合计");
            this.ResultVarable.Set("FBFXJXCJHJ", 0, "[分部分项]分部分项机械费调增差价合计");

            this.ResultVarable.Set("Z[人工].rgf", 0, "[分部分项]定额特项为“人工”的人工费");
            this.ResultVarable.Set("Q[ZS].jxf", 0, "[分部分项]清单特项为“ZS”的综合合价");
            this.ResultVarable.Set("Z[建筑].rgf", 0, "[分部分项]定额特项为“建筑”的人工费");
            this.ResultVarable.Set("Z[安装].rgf", 0, "[分部分项]定额特项为“安装”的人工费");
            this.ResultVarable.Set("Z[桩基].clf", 0, "[分部分项]定额特项为“桩基”的材料费");

            this.ResultVarable.Set("Z[建筑].jxf", 0, "[分部分项]定额特项为“建筑”的机械费");
            this.ResultVarable.Set("Z[机械].xmf", 0, "[分部分项]定额特项为“机械”的综合合价");
            this.ResultVarable.Set("Z[桩基].xmf", 0, "[分部分项]定额特项为“桩基”的综合合价");
            this.ResultVarable.Set("Z[建筑].xmf", 0, "[分部分项]定额特项为“建筑”的综合合价");
            this.ResultVarable.Set("Z[装饰].xmf", 0, "[分部分项]定额特项为“装饰”的综合合价");

            this.ResultVarable.Set("Q[JZ].xmf", 0, "[分部分项]清单特项为“JZ”的综合合价");
            this.ResultVarable.Set("Q[ZS].jxf", 0, "[分部分项]清单特项为“ZS”的综合合价");

            this.ResultVarable.Set("FBFXGFHJ", 0, "[分部分项]分部分项规费合计");
            this.ResultVarable.Set("FBFXSJHJ", 0, "[分部分项]分部分项税金合计");
            #endregion

            #region -------------------------------措施项目最终参数------------------------
            this.ResultVarable.Set("CSXMHJ", 0, "[措施项目]措施项目合计");
            this.ResultVarable.Set("CSXMRGFHJ", 0, "[措施项目]措施项目人工费合计");
            this.ResultVarable.Set("CSXMCLFHJ", 0, "[措施项目]措施项目材料费合计");
            this.ResultVarable.Set("CSXMZCFHJ", 0, "[措施项目]措施项目主材费合计");
            this.ResultVarable.Set("CSXMSBFHJ", 0, "[措施项目]措施项目设备费合计");
            this.ResultVarable.Set("CSXMJXFHJ", 0, "[措施项目]措施项目机械费合计");

            this.ResultVarable.Set("CSXMGLFHJ", 0, "[措施项目]措施项目管理费合计");
            this.ResultVarable.Set("CSXMLRHJ", 0, "[措施项目]措施项目利润合计");
            this.ResultVarable.Set("CSXMFXHJ", 0, "[措施项目]措施项目风险合计");
            this.ResultVarable.Set("CSXMZGJEHJ", 0, "[措施项目]措施项目暂估金额合计");
            this.ResultVarable.Set("CSXMJGJEHJ", 0, "[措施项目]措施项目甲供金额合计");
            this.ResultVarable.Set("CSXMFBJEHJ", 0, "[措施项目]措施项目分包金额合计");
            this.ResultVarable.Set("CSXMJBHZHJ", 0, "[措施项目]措施项目局部汇总金额合计");
            this.ResultVarable.Set("CSXMDEHJ", 0, "[措施项目]措施项目定额价合计");
            this.ResultVarable.Set("CSXMDERGFHJ", 0, "[措施项目]措施项目定额人工费合计");
            this.ResultVarable.Set("CSXMDECLFHJ", 0, "[措施项目]措施项目定额材料费合计");
            this.ResultVarable.Set("CSXMDEZCFHJ", 0, "[措施项目]措施项目定额主材费合计");
            this.ResultVarable.Set("CSXMDESBFHJ", 0, "[措施项目]措施项目定额设备费合计");
            this.ResultVarable.Set("CSXMDEJXFHJ", 0, "[措施项目]措施项目定额机械费合计");

            this.ResultVarable.Set("CSXMDEGLFHJ", 0, "[措施项目]措施项目定额管理费合计");
            this.ResultVarable.Set("CSXMDELRHJ", 0, "[措施项目]措施项目定额利润合计");
            this.ResultVarable.Set("CSXMDEFXHJ", 0, "[措施项目]措施项目定额风险合计");
            this.ResultVarable.Set("CSXMDEZGJEHJ", 0, "[措施项目]措施项目定额暂估金额合计");
            this.ResultVarable.Set("CSXMDEJGJEHJ", 0, "[措施项目]措施项目定额甲供金额合计");
            this.ResultVarable.Set("CSXMDEFBJEHJ", 0, "[措施项目]措施项目定额分包金额合计");
            this.ResultVarable.Set("CSXMDEJBHZHJ", 0, "[措施项目]措施项目定额局部汇总金额合计");
            //this.ResultVarable.Set("CSXMJC"         , 0, "[措施项目]措施项目价差");
            //this.ResultVarable.Set("CSXMCJ"         , 0, "[措施项目]措施项目差价");

            //this.ResultVarable.Set("HHJXFHJ", 0, "[措施项目]混合机械人工费合价");
            //this.ResultVarable.Set("FBFXJCHJ", 0, "[措施项目]分部分项价差合计");
            this.ResultVarable.Set("CSXMJCHJ", 0, "[措施项目]措施项目价差合计");
            this.ResultVarable.Set("CSXMRGJCHJ", 0, "[措施项目]措施项目人工费价差合计");
            this.ResultVarable.Set("CSXMCLJCHJ", 0, "[措施项目]措施项目材料费价差合计");
            this.ResultVarable.Set("CSXMJXJCHJ", 0, "[措施项目]措施项目机械费价差合计");
            this.ResultVarable.Set("CSXMCJHJ", 0, "[措施项目]措施项目可能发生的差价合计");
            this.ResultVarable.Set("CSXMRGCJHJ", 0, "[措施项目]措施项目人工费调增差价合计");
            this.ResultVarable.Set("CSXMCLCJHJ", 0, "[措施项目]措施项目材料费调增差价合计");
            this.ResultVarable.Set("CSXMJXCJHJ", 0, "[措施项目]措施项目机械费调增差价合计");

            this.ResultVarable.Set("CSAQWM", 0, "[措施项目]安全文明施工措施费");
            this.ResultVarable.Set("CSWMSG", 0, "[措施项目]安全文明施工费");
            this.ResultVarable.Set("CSHJBH", 0, "[措施项目]环境保护费（含排污）");
            this.ResultVarable.Set("CSLSSS", 0, "[措施项目]临时设施费");

            this.ResultVarable.Set("CSXMGFHJ", 0, "[措施项目]措施项目规费合计");
            this.ResultVarable.Set("CSXMSJHJ", 0, "[措施项目]措施项目税金合计");
            this.ResultVarable.Set("KCAQWMCSF", 0, "[措施项目]扣除安全文明施工费");

            #endregion

            #region -------------------------------其他项目最终参数------------------------
            this.ResultVarable.Set("QTXMHJ", 0, "[其他项目]其他项目合计");

            this.ResultVarable.Set("QTXMCJHJ", 0, "[其他项目]其他项目差价合价");
            this.ResultVarable.Set("QTXMJSCJHJ", 0, "[其他项目]其他项目结算差价合计");
            this.ResultVarable.Set("QTXMRGCJHJ", 0, "[其他项目]其他项目人工费调增差价合计");
            this.ResultVarable.Set("ZLJE", 0, "[其他项目]暂列金额");
            this.ResultVarable.Set("SJBGCJ", 0, "[其他项目]设计变更及材料（主材）差价");
            this.ResultVarable.Set("ZYGCZGJ", 0, "[其他项目]专业工程暂估价");
            this.ResultVarable.Set("ZCSBZGJ", 0, "[其他项目]主材设备暂估价");
            this.ResultVarable.Set("LXFBGCE", 0, "[其他项目]另行分包的专业工程金额");
            this.ResultVarable.Set("JRG", 0, "[其他项目]计日工");
            this.ResultVarable.Set("JRGRG", 0, "[其他项目]人工");
            this.ResultVarable.Set("JRGCL", 0, "[其他项目]材料");
            this.ResultVarable.Set("JRGJX", 0, "[其他项目]机械");
            this.ResultVarable.Set("ZCBFWF", 0, "[其他项目]总承包服务费");
            this.ResultVarable.Set("FBGLFWF", 0, "[其他项目]发包人发包专业工程管理服务费");
            this.ResultVarable.Set("FBRBGF", 0, "[其他项目]发包人供应材料、设备保管费");
            this.ResultVarable.Set("FSPTJJJ", 0, "[其他项目]副食品调节基金");

            #endregion
        }

        #region IAttributes 成员

        public object Source
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 当前参数信息
        /// </summary>
        /// <param name="p_Table"></param>
        public void ConvertToDisplay(CAttributes p_Table)
        {
            int key = p_Table.Add(-1, "单位工程结果参数");
            //要添加的属性节点
            foreach (DataRow row in this.ResultVarable.DataSource.Rows)
            {
                p_Table.Add(key, row["Key"].ToString(), row["Value"]);
            }
        }

        public void ChangeValue(CAttributes p_Table, DataRowChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
