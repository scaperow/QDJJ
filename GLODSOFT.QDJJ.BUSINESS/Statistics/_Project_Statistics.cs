/*
 为单位工程准备的变量计算结果集
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{
    [Serializable]
    public class _Project_Statistics : GLODSOFT.QDJJ.BUSINESS._Statistics
    {



        _VariableSource ResultVarable = null;
        _VariableSource UNResultVarable = null;
        _Business Business;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_Parent"></param>
        public _Project_Statistics(_UnitProject p_Parent, BUSINESS._Business business)
            : base(p_Parent)
        {
            this.Unit = p_Parent;
            this.ResultVarable = this.Unit.StructSource.ModelResultVariable;
            this.UNResultVarable = this.Unit.StructSource.ModelProjVariable;
            this.Business = business;
        }

        /// <summary>
        /// 重写如何开始计算
        /// </summary>
        public void Begin()
        {
            //此处处理开始统计代码
            //1.统计当前单位工程的分部分项代码
            //2.统计当前单位工程措施项目代码
            //3.统计当前单位工程其他项目代码
            //this.ResultVarable.DataSource.Clear();
            builder();
            this.SetFBFX();
            this.CalculateTX();
            this.SetCSXM();
            this.SetQTXM();
        }

        /// <summary>
        /// 单位工程计算
        /// </summary>
        public void Calculate()
        {
            this.Unit.IsCalculated = false;
            this.RestXH();
            //this.DeleteKong();
            _Methods method = null;
            method = new _Method_Sub(null, this.Unit, this.GetSub());
            method.Calculate();
            method = new _Mothod_Measures(null, this.Unit, this.GetTop1MeasureItem());
            method.Calculate();
            this.Begin();
            method = new _Method_OtherProject(null, this.Unit);
            method.Calculate();
            this.Begin();
            method = new _Method_Metaanalysis(this.Unit);
            method.Calculate();

            CalculateWithouSubsegment();
            this.Unit.NeedCalculate = true;
        }

        public void CalculateWithouSubsegment()
        {

            try
            {
                Variablies.Clear();
                CalculateTX();
                CalculateJX();
                CalculateZJF();
                CalculateKCAQWMCSF();
                CalculateQT();
                CalculateC10101();
                CalculateResult();
                this.Unit.NeedCalculate = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        Dictionary<string, object> Variablies = new Dictionary<string, object>();

        /// <summary>
        /// 計算最終結果
        /// </summary>
        private void CalculateResult()
        {
          
            var CSAQWM = ToolKit.ParseDecimal(Variablies["CSAQWM"]);
            var KCAQWMCSF = ToolKit.ParseDecimal(Variablies["KCAQWMCSF"]);
            var CSXMHJ = CSAQWM + KCAQWMCSF;

            var rows = this.Unit.StructSource.ModelMeasures.Select("XMBM = 'C101'");
            foreach (var row in rows)
            {
                _Methods.Build(Business, Unit, _Entity_SubInfo.Parse(row)).BeginCurrent();
            }

            rows = this.Unit.StructSource.ModelMeasures.Select("XMBM = '措施项目'");
            foreach (var row in rows)
            {
                _Methods.Build(Business, Unit, _Entity_SubInfo.Parse(row)).BeginCurrent();
            }

            var measureMethod = new _Mothod_Measures(this.Business, Unit, GetTop1MeasureItem());
            measureMethod.BeginCurrent();


            var metaanlysis = new _Method_Metaanalysis(Unit);
            metaanlysis.Calculate();


            this.UNResultVarable.Set(this.Unit.ID, -1, "CSXMHJ", CSXMHJ);
            this.UNResultVarable.Set(this.Unit.ID, -1, "CSXMF", CSXMHJ);

            this.ResultVarable.Set(this.Unit.ID, -1, "CSXMHJ", CSXMHJ);
            this.ResultVarable.Set(this.Unit.ID, -1, "CSXMF", CSXMHJ);

            //var otherStatistics = new _Method_OtherProject(this.Business, this.Unit);
            //otherStatistics.Begin();

            //var metaanalysis = new _Method_Metaanalysis(this.Unit);
            //metaanalysis.Begin(null);
        }

        /// <summary>
        /// 計算措施項目中的C10101清單值
        /// </summary>
        private void CalculateC10101()
        {
            var rows = this.Unit.StructSource.ModelMeasures.Select("(XMBM = 'C10101' OR XMBM = 'c10101') AND LB = '清单' AND XH = 1");

            foreach (var row in rows)
            {
                var entity = _Entity_SubInfo.Parse(row);
                _Methods.Build(Business, Unit, entity).Calculate();
            }

            decimal CSAQWM = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "XMBM='C10101'"));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSAQWM", CSAQWM);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "AQWM", CSAQWM);

            this.ResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSAQWM", CSAQWM);
            this.ResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "AQWM", CSAQWM);

            Variablies["CSAQWM"] = CSAQWM;
            Variablies["AQWM"] = CSAQWM;
        }

        /// <summary>
        /// 計算其他項目的合計值
        /// </summary>
        private void CalculateQT()
        {
            var other = new _Method_OtherProject(null, this.Unit);
            other.Calculate();

            SetQTXM();
        }

        /// <summary>
        /// 計算扣除安全文明措施费并放入變量表
        /// </summary>
        private void CalculateKCAQWMCSF()
        {

            //"Sum(RGFHJ)", "LB like '%子目%' AND TX='人工'"

            var rows = this.Unit.StructSource.ModelMeasures.Select("XH > 1");
            foreach (var row in rows)
            {
                _Methods.Build(Business, Unit, _Entity_SubInfo.Parse(row)).Calculate();
            }


            var result = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("SUM(ZHHJ)", "XH > 1"));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "KCAQWMCSF", result);
            this.ResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "KCAQWMCSF", result);
            Variablies["KCAQWMCSF"] = result;
        }

        /// <summary>
        /// 計算子目增加費并放入變量表中
        /// </summary>
        private void CalculateZJF()
        {
            var rows = this.Unit.StructSource.ModelMeasures.Select("TX LIKE '%增加费%' AND LB = '子目'");
            foreach (var row in rows)
            {
                var entity = _Entity_SubInfo.Parse(row);
                _Methods.Build(Business, Unit, entity).BeginCurrent();
            }
        }

        /// <summary>
        /// 計算子目降效的值并放入變量表中
        /// </summary>
        private void CalculateJX()
        {
            var rows = this.Unit.StructSource.ModelMeasures.Select("TX LIKE '%降效%' AND LB = '子目'");
            foreach (var row in rows)
            {
                var entity = _Entity_SubInfo.Parse(row);
                _Methods.Build(Business, Unit, entity).BeginCurrent();
            }


        }

        /// <summary>
        /// 清单排序
        /// </summary>
        private void RestXH()
        {
            DataRow[] rs1 = this.Unit.StructSource.ModelSubSegments.Select("(XH is null  or XH=0) and LB='清单'");
            if (rs1.Length > 0)//条件成立则需要重排
            {
                DataRow[] rows = this.Unit.StructSource.ModelSubSegments.Select("LB='清单'", "sort asc");
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i]["XH"] = i + 1;
                }
            }
        }
        private void DeleteKong()
        {
            DataRow[] ros_Mea = this.Unit.StructSource.ModelMeasures.Select("(XMBM is null or XMBM='')  and (XMMC is null or XMMC='')");
            DataRow[] ros_Sub = this.Unit.StructSource.ModelSubSegments.Select("(XMBM is null or XMBM='')  and (XMMC is null or XMMC='')");
            for (int i = 0; i < ros_Mea.Length; i++)
            {
                ros_Mea[i].Delete();
            }
            for (int i = 0; i < ros_Sub.Length; i++)
            {
                ros_Sub[i].Delete();
            }

        }
        /// <summary>
        /// 设置其他项目的合计
        /// </summary>
        public void SetQTXM()
        {
            _Entity_OtherProject info = GetTop1OtherItem();
            //_OtherProject_Statistics sta = new _OtherProject_Statistics(this.Unit);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMHJ", this.ResultVarable.Get(info.id, 2, _Statistics.FILED_ZHHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMCJHJ", this.ResultVarable.Get(info.id, 2, "QTXMCJHJ"));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMRGCJHJ", this.ResultVarable.Get(info.id, 2, "QTXMRGCJHJ"));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMJSCJHJ", this.ResultVarable.Get(info.id, 2, "QTXMJSCJHJ"));//结算差价
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZLJE", this.ResultVarable.Get(info.id, 2, "ZLJE"));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "SJBGCJ", this.ResultVarable.Get(info.id, 2, "SJBGCJ"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZYGCZGJ", this.ResultVarable.Get(info.id, 2, "ZYGCZGJ"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZCSBZGJ", this.ResultVarable.Get(info.id, 2, "ZCSBZGJ"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "LXFBGCE", this.ResultVarable.Get(info.id, 2, "LXFBGCE"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRG", this.ResultVarable.Get(info.id, 2, "JRG"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRGRG", this.ResultVarable.Get(info.id, 2, "JRGRG"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRGCL", this.ResultVarable.Get(info.id, 2, "JRGCL"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRGJX", this.ResultVarable.Get(info.id, 2, "JRGJX"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZCBFWF", this.ResultVarable.Get(info.id, 2, "ZCBFWF"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBGLFWF", this.ResultVarable.Get(info.id, 2, "FBGLFWF"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBRBGF", this.ResultVarable.Get(info.id, 2, "FBRBGF"));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FSPTJJJ", this.ResultVarable.Get(info.id, 2, "FSPTJJJ"));
        }


        /// <summary>
        /// 获取分部分项对象
        /// </summary>
        /// <returns></returns>
        private _Entity_SubInfo GetSub()
        {
            _Entity_SubInfo info = new _Entity_SubInfo();
            DataRow[] rows = this.Unit.StructSource.ModelSubSegments.Select("PID=0");
            if (rows.Length > 0) _ObjectSource.GetObject(info, rows[0]);
            return info;
        }
        /// <summary>
        /// 获取其他项目对象
        /// </summary>
        /// <returns></returns>
        private _Entity_OtherProject GetTop1OtherItem()
        {
            _Entity_OtherProject info = new _Entity_OtherProject();
            DataRow[] rows = this.Unit.StructSource.ModelOtherProject.Select("ParentID=0");
            if (rows.Length > 0) _ObjectSource.GetObject(info, rows[0]);
            return info;
        }

        private _Entity_SubInfo GetTop1MeasureItem()
        {
            _Entity_SubInfo info = new _Entity_SubInfo();
            DataRow[] rows = this.Unit.StructSource.ModelMeasures.Select("PID=0");
            if (rows.Length > 0) _ObjectSource.GetObject(info, rows[0]);
            return info;
        }
        /// <summary>
        /// 设置分部分项参数
        /// </summary>
        public void SetFBFX()
        {
            this.Current = GetSub();
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_ZHHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXRGFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_RGFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_CLFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXZCFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_ZCFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXSBFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_SBFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJXFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_JXFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXGLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_GLFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXLRHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_LRHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXFXHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FXHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXZGJEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_ZGHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJGJEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_JGJEHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXFBJEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBJEHJ));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEZHHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDERGFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DERGFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDECLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DECLFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEZCFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEZCFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDESBFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DESBFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEJXFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEJXFHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEGLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEGLFHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDELRHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DELRHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEFXHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEFXHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJCHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXJCHJ));
            //人工费价差加上混合机械人工（J4001）
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXRGJCHJ", this.ResultVarable.GetDecimal(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXRGJCHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCLJCHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXCLJCHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJXJCHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXJXJCHJ));

            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXCJHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXRGCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXRGCJHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCLCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXCLCJHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJXCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXJXCJHJ));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXGFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_GFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXSJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_SJHJ));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEZGJEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEZGHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEJGJEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEJGJEHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEFBJEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEFBJEHJ));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXZJFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_ZJFHJ));
        }

        /// <summary>
        /// 计算特性的值并存入变量表
        /// </summary>
        public void CalculateTX()
        {
            decimal 人工rgf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(RGFHJ)", "LB like '%子目%' AND TX='人工'"));
            decimal 建筑rgf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(RGFHJ)", "LB like '%子目%' AND TX='建筑'"));
            decimal 安装rgf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(RGFHJ)", "LB like '%子目%' AND TX='安装'"));
            decimal 建筑jxf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(JXFHJ)", "LB like '%子目%' AND TX='建筑'"));
            decimal 桩基CLF = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(CLFHJ)", "LB like '%子目%' AND TX='桩基'"));
            decimal 机械xmf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='机械'"));
            decimal 桩基xmf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='桩基'"));
            decimal 建筑xmf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='建筑'"));
            decimal 装饰xmf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='装饰'"));


            人工rgf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(RGFHJ)", "LB like '%子目%' AND TX='人工'"));
            建筑rgf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(RGFHJ)", "LB like '%子目%' AND TX='建筑'"));
            安装rgf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(RGFHJ)", "LB like '%子目%' AND TX='安装'"));
            建筑jxf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(JXFHJ)", "LB like '%子目%' AND TX='建筑'"));
            桩基CLF += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(CLFHJ)", "LB like '%子目%' AND TX='桩基'"));
            机械xmf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='机械'"));
            桩基xmf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='桩基'"));
            建筑xmf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='建筑'"));
            装饰xmf += ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "LB like '%子目%' AND TX='装饰'"));

            decimal QJZxmf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(ZHHJ)", "LB = '清单' AND TX='JZ'"));
            decimal QZSjxf = ToolKit.ParseDecimal(this.Unit.StructSource.ModelSubSegments.Compute("Sum(JXFHJ)", "LB = '清单' AND TX='ZS'"));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[人工].rgf", 人工rgf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[建筑].rgf", 建筑rgf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[安装].rgf", 安装rgf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[桩基].clf", 桩基CLF);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[建筑].jxf", 建筑jxf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[机械].xmf", 机械xmf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[桩基].xmf", 桩基xmf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[建筑].xmf", 建筑xmf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[装饰].xmf", 装饰xmf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Q[JZ].xmf", QJZxmf);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Q[ZS].jxf", QZSjxf);
        }

        /// <summary>
        /// 设置措施项目
        /// </summary>
        public void SetCSXM()
        {
            this.Current = GetTop1MeasureItem();
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_ZHHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMRGFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_RGFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_CLFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMZCFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_ZCFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMSBFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_SBFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMGLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_GLFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMLRHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_LRHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMFXHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FXHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJXFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_JXFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEZHHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDERGFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DERGFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDECLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DECLFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEZCFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEZCFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDESBFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DESBFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEGLFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEGLFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDELRHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DELRHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEFXHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEFXHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEJXFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_DEJXFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJCHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXJCHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMRGJCHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXRGJCHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCLJCHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXCLJCHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJXJCHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXJXJCHJ));

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMZJFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_ZJFHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXCJHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMRGCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXRGCJHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCLCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXCLCJHJ));
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJXCJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_FBFXJXCJHJ));


            decimal CSAQWM = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "XMBM='C10101'"));
            decimal CSWMSG = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "XMBM='1.1'"));
            decimal CSHJBH = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "XMBM='1.2'"));
            decimal CSLSSS = ToolKit.ParseDecimal(this.Unit.StructSource.ModelMeasures.Compute("Sum(ZHHJ)", "XMBM='1.3'"));
            decimal KCAQWMCSF = this.Current.ZHHJ - CSAQWM;

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSAQWM", CSAQWM);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSWMSG", CSWMSG);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSHJBH", CSHJBH);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSLSSS", CSLSSS);
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "KCAQWMCSF", KCAQWMCSF);

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMGFHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_GFHJ));
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMSJHJ", this.ResultVarable.Get(this.Current.ID, this.Current.SSLB, GLODSOFT.QDJJ.BUSINESS._Statistics.FILED_SJHJ));


        }

        /// <summary>
        /// 创建子目变量对象
        /// </summary>
        public void builder()
        {
            #region -----------------------------分部分项最终参数------------------------
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXHJ", 0, "[分部分项]分部分项合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXRGFHJ", 0, "[分部分项]分部分项人工费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCLFHJ", 0, "[分部分项]分部分项材料费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXZCFHJ", 0, "[分部分项]分部分项主材费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXSBFHJ", 0, "[分部分项]分部分项设备费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJXFHJ", 0, "[分部分项]分部分项机械费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXGLFHJ", 0, "[分部分项]分部分项管理费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXLRHJ", 0, "[分部分项]分部分项利润合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXFXHJ", 0, "[分部分项]分部分项风险合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXZGJEHJ", 0, "[分部分项]分部分项暂估金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJGJEHJ", 0, "[分部分项]分部分项甲供金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXFBJEHJ", 0, "[分部分项]分部分项分包金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJBHZHJ", 0, "[分部分项]分部分项局部汇总金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEHJ", 0, "[分部分项]分部分项定额价合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDERGFHJ", 0, "[分部分项]分部分项定额人工费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDECLFHJ", 0, "[分部分项]分部分项定额材料费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEZCFHJ", 0, "[分部分项]分部分项定额主材费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDESBFHJ", 0, "[分部分项]分部分项定额设备费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEJXFHJ", 0, "[分部分项]分部分项定额机械费合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEGLFHJ", 0, "[分部分项]分部分项定额管理费合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDELRHJ", 0, "[分部分项]分部分项定额利润合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEFXHJ", 0, "[分部分项]分部分项定额风险合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEZGJEHJ", 0, "[分部分项]分部分项定额暂估金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEJGJEHJ", 0, "[分部分项]分部分项定额甲供金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEFBJEHJ", 0, "[分部分项]分部分项定额分包金额合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXDEJBHZHJ", 0, "[分部分项]分部分项定额局部汇总金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXZJFHJ", 0, "[分部分项]分部分项直接费合价");

            // this.UNResultVarable.Set(this.Unit.PID,this.Unit.ID,-1,"HHJXFHJ", 0, "[分部分项]混合机械人工费合价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJCHJ", 0, "[分部分项]分部分项价差合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXRGJCHJ", 0, "[分部分项]分部分项人工费价差合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCLJCHJ", 0, "[分部分项]分部分项材料费价差合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJXJCHJ", 0, "[分部分项]分部分项机械费价差合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCJHJ", 0, "[分部分项]分部分项可能发生的差价合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXRGCJHJ", 0, "[分部分项]分部分项人工费调增差价合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXCLCJHJ", 0, "[分部分项]分部分项材料费调增差价合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXJXCJHJ", 0, "[分部分项]分部分项机械费调增差价合计");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[人工].rgf", 0, "[分部分项]定额特项为“人工”的人工费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Q[ZS].jxf", 0, "[分部分项]清单特项为“ZS”的机械费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[建筑].rgf", 0, "[分部分项]定额特项为“建筑”的人工费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[安装].rgf", 0, "[分部分项]定额特项为“安装”的人工费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[桩基].clf", 0, "[分部分项]定额特项为“桩基”的材料费");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[建筑].jxf", 0, "[分部分项]定额特项为“建筑”的机械费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[机械].xmf", 0, "[分部分项]定额特项为“机械”的综合合价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[桩基].xmf", 0, "[分部分项]定额特项为“桩基”的综合合价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[建筑].xmf", 0, "[分部分项]定额特项为“建筑”的综合合价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Z[装饰].xmf", 0, "[分部分项]定额特项为“装饰”的综合合价");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Q[JZ].xmf", 0, "[分部分项]清单特项为“JZ”的综合合价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "Q[ZS].jxf", 0, "[分部分项]清单特项为“ZS”的综合合价");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXGFHJ", 0, "[分部分项]分部分项规费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBFXSJHJ", 0, "[分部分项]分部分项税金合计");
            #endregion

            #region -------------------------------措施项目最终参数------------------------
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMHJ", 0, "[措施项目]措施项目合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMRGFHJ", 0, "[措施项目]措施项目人工费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCLFHJ", 0, "[措施项目]措施项目材料费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMZCFHJ", 0, "[措施项目]措施项目主材费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMSBFHJ", 0, "[措施项目]措施项目设备费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJXFHJ", 0, "[措施项目]措施项目机械费合计");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMGLFHJ", 0, "[措施项目]措施项目管理费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMLRHJ", 0, "[措施项目]措施项目利润合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMFXHJ", 0, "[措施项目]措施项目风险合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMZGJEHJ", 0, "[措施项目]措施项目暂估金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJGJEHJ", 0, "[措施项目]措施项目甲供金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMFBJEHJ", 0, "[措施项目]措施项目分包金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJBHZHJ", 0, "[措施项目]措施项目局部汇总金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEHJ", 0, "[措施项目]措施项目定额价合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDERGFHJ", 0, "[措施项目]措施项目定额人工费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDECLFHJ", 0, "[措施项目]措施项目定额材料费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEZCFHJ", 0, "[措施项目]措施项目定额主材费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDESBFHJ", 0, "[措施项目]措施项目定额设备费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEJXFHJ", 0, "[措施项目]措施项目定额机械费合计");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEGLFHJ", 0, "[措施项目]措施项目定额管理费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDELRHJ", 0, "[措施项目]措施项目定额利润合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEFXHJ", 0, "[措施项目]措施项目定额风险合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEZGJEHJ", 0, "[措施项目]措施项目定额暂估金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEJGJEHJ", 0, "[措施项目]措施项目定额甲供金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEFBJEHJ", 0, "[措施项目]措施项目定额分包金额合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMDEJBHZHJ", 0, "[措施项目]措施项目定额局部汇总金额合计");
            //this.UNResultVarable.Set(this.Unit.PID,this.Unit.ID,-1,"CSXMJC"         , 0, "[措施项目]措施项目价差");
            //this.UNResultVarable.Set(this.Unit.PID,this.Unit.ID,-1,"CSXMCJ"         , 0, "[措施项目]措施项目差价");

            //this.UNResultVarable.Set(this.Unit.PID,this.Unit.ID,-1,"HHJXFHJ", 0, "[措施项目]混合机械人工费合价");
            //this.UNResultVarable.Set(this.Unit.PID,this.Unit.ID,-1,"FBFXJCHJ", 0, "[措施项目]分部分项价差合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJCHJ", 0, "[措施项目]措施项目价差合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMRGJCHJ", 0, "[措施项目]措施项目人工费价差合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCLJCHJ", 0, "[措施项目]措施项目材料费价差合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJXJCHJ", 0, "[措施项目]措施项目机械费价差合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCJHJ", 0, "[措施项目]措施项目可能发生的差价合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMRGCJHJ", 0, "[措施项目]措施项目人工费调增差价合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMCLCJHJ", 0, "[措施项目]措施项目材料费调增差价合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMJXCJHJ", 0, "[措施项目]措施项目机械费调增差价合计");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSAQWM", 0, "[措施项目]安全文明施工措施费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSWMSG", 0, "[措施项目]安全文明施工费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSHJBH", 0, "[措施项目]环境保护费（含排污）");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSLSSS", 0, "[措施项目]临时设施费");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMGFHJ", 0, "[措施项目]措施项目规费合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMSJHJ", 0, "[措施项目]措施项目税金合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "KCAQWMCSF", 0, "[措施项目]扣除安全文明施工费");

            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "CSXMZJFHJ", 0, "[措施项目]措施项目直接费合价");
            #endregion

            #region -------------------------------其他项目最终参数------------------------
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMHJ", 0, "[其他项目]其他项目合计");

            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMCJHJ", 0, "[其他项目]其他项目差价合价");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMJSCJHJ", 0, "[其他项目]其他项目结算差价合计");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "QTXMRGCJHJ", 0, "[其他项目]其他项目人工费调增差价合计");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZLJE", 0, "[其他项目]暂列金额");
            //this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "SJBGCJ", 0, "[其他项目]设计变更及材料（主材）差价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZYGCZGJ", 0, "[其他项目]专业工程暂估价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZCSBZGJ", 0, "[其他项目]主材设备暂估价");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "LXFBGCE", 0, "[其他项目]另行分包的专业工程金额");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRG", 0, "[其他项目]计日工");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRGRG", 0, "[其他项目]人工");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRGCL", 0, "[其他项目]材料");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "JRGJX", 0, "[其他项目]机械");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "ZCBFWF", 0, "[其他项目]总承包服务费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBGLFWF", 0, "[其他项目]发包人发包专业工程管理服务费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FBRBGF", 0, "[其他项目]发包人供应材料、设备保管费");
            this.UNResultVarable.Set(this.Unit.PID, this.Unit.ID, -1, "FSPTJJJ", 0, "[其他项目]副食品调节基金");

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
            foreach (DataRow row in this.ResultVarable.Rows)
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
