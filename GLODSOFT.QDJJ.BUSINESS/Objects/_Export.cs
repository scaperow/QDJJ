using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.ZBS;
using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using System.IO;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
/***********数据导出***************/
namespace GLODSOFT.QDJJ.BUSINESS
{
    /// <summary>
    /// 项目的 xml数据导出
    /// </summary>
    [Serializable]
    public class _Export
    {
        private _Projects m_Parent;

        /// <summary>
        /// 获取所属对象
        /// </summary>
        public _Projects Parent
        {
            get { return this.m_Parent; }
            set { this.m_Parent = value; }
        }

        private _Business m_CurrentBusiness;
        /// <summary>
        /// 当前业务
        /// </summary>
        public _Business CurrentBusiness
        {
            get { return m_CurrentBusiness; }
            set { m_CurrentBusiness = value; }
        }
        private const string Dian = "F2";
        private 建设项目 m_Source;
        /// <summary>
        /// DBS数据源
        /// </summary>
        public 建设项目 Source
        {
            get { return m_Source; }
            set { m_Source = value; }
        }
        public _Export(_Business p_CurrentBusiness)
        {
            this.m_Parent = (p_CurrentBusiness.Current as _Projects);
            this.m_CurrentBusiness = p_CurrentBusiness;
        }
        private bool m_IsZBS;

        public bool IsZBS
        {
            get { return m_IsZBS; }
            set { m_IsZBS = value; }
        }
        /// <summary>
        /// 汇总分析模板
        /// </summary>
        private string m_HTemplatePath;
        /// <summary>
        /// 规费税金模板
        /// </summary>
        private string m_GTemplatePath;
        /// <summary>
        /// ZBS格式的导出
        /// </summary>
        /// <param name="Filepath">保存路径</param>
        public void ExportZBS(string Filepath)
        {
            this.m_IsZBS = true;
            this.m_Source = new 建设项目();
            SetProjectZBS();
            Filepath = Filepath + "\\" + this.m_Parent.Name + "\\招标文件\\";
            DirectoryInfo info = ToolKit.GetDirectoryInfo(Filepath);
            string FileName = Filepath + this.m_Parent.Name + ".ZBS";
            CFiles.XmlSerialize(this.m_Source, FileName);

        }
        /// <summary>
        /// TBS格式的导出
        /// </summary>
        /// <param name="Filepath"></param>
        public void ExportTBS(string Filepath)
        {
            this.m_IsZBS = false;
            this.m_Source = new 建设项目();
            SetProjectZBS();

            Filepath = Filepath + "\\" + this.m_Parent.Name + "\\投标文件\\";
            DirectoryInfo info = ToolKit.GetDirectoryInfo(Filepath);
            string FileName = Filepath + this.m_Parent.Name + ".TBS";
            CFiles.XmlSerialize(this.m_Source, FileName);

        }

        /// <summary>
        /// BD
        /// </summary>
        /// <param name="Filepath"></param>
        public void ExportBD(string Filepath)
        {
            this.m_IsZBS = false;
            this.m_Source = new 建设项目();
            SetProjectZBS();
            Filepath = Filepath + "\\" + this.m_Parent.Name + "\\标底文件\\";
            DirectoryInfo info = ToolKit.GetDirectoryInfo(Filepath);
            
            string FileName = Filepath + this.m_Parent.Name + ".BD";
            CFiles.XmlSerialize(this.m_Source, FileName);

        }

        /// <summary>
        /// 项目信息赋值
        /// </summary>
        private void SetProjectZBS()
        {
            if (this.m_Parent == null) return;
            this.m_Source.标准名称 = "西安市建设工程电子标书接口标准";
            this.m_Source.标准版本号 = "2.0";
            this.m_Source.报建号 = "";
            this.m_Source.项目名称 = this.m_Parent.Name;
            //this.m_Source.工程代号 = "";

            if (IsZBS)
            {
                SetZB();//招标信息赋值
            }
            else
            {
                SetZB();//招标信息赋值
                SetTB();//投标信息赋值
            }

            DataRow[] EnRows = m_Parent.StructSource.ModelProject.Select("Deep = 1");
            this.m_Source.单项工程 = new 单项工程[EnRows.Length];
            int i = 0;
            this.CurrentBusiness.Calculate();
            bool flag = File.Exists(this.CurrentBusiness.Current.Files.FullName);
            _Pr_Business pr = this.CurrentBusiness as _Pr_Business;
            if (flag)
            {
                pr.BeginData();
            }
          
            //pr.ProjDataBase.MyTran = pr.DBTran as System.Data.OleDb.OleDbTransaction;

            foreach (DataRow row in EnRows)
            {
                _Engineering einfo = this.m_Parent.Create() as _Engineering;
                _ObjectSource.GetObject(einfo, row);
                this.m_Source.单项工程[i] = new 单项工程();
                SetEngZBS(this.m_Source.单项工程[i], einfo);
                i++;
            }

            foreach (_Engineering item in this.m_Parent.StrustObject.ObjectList.Values)
            {


            }
            if (flag)
            {
                pr.EndData();
                pr.ReadyUseFile();
            }
        }
        /// <summary>
        /// 投标信息赋值
        /// </summary>
        private void SetTB()
        {
            if (this.m_Parent.StructSource.TenderInfoSource.Rows.Count > 0)
            {
                DataRow info = this.m_Parent.StructSource.TenderInfoSource.Rows[0];
                this.m_Source.投标信息表 = new 投标信息表();
                //_TenderInformation info = this.m_Parent.Property.BasicInformation.TenderInformation;
                this.m_Source.投标信息表.投标人 = info["TBDWDBR"].ToString();
                this.m_Source.投标信息表.投标工期 = info["TBGQ"].ToString();
                this.m_Source.投标信息表.总报价 = this.m_Parent.StructSource.ModelProjVariable.GetDecimal(0, -3, "ZZJ").ToString(Dian);
                this.m_Source.投标信息表.总措施项目费 = this.m_Parent.StructSource.ModelProjVariable.GetDecimal(0, -3, "CSXMHJ").ToString(Dian);
                this.m_Source.投标信息表.安全文明施工措施费 = this.m_Parent.StructSource.ModelProjVariable.GetDecimal(0, -3, "CSAQWM").ToString(Dian);
                this.m_Source.投标信息表.项目经理或注册建造师 = info["JZS"].ToString();
                this.m_Source.投标信息表.项目经理或建造师注册号 = info["JZSH"].ToString();
                this.m_Source.投标信息表.编制人员1 = info["PlaitName"].ToString();
                this.m_Source.投标信息表.注册号1 = info["PlaitNo"].ToString();
                this.m_Source.投标信息表.编制人员2 = "";
                this.m_Source.投标信息表.注册号2 = "";
                //this.m_Source.投标信息表.编制人员3 = "";
                //this.m_Source.投标信息表.注册号3 = "";
                this.m_Source.投标信息表.编制时间 = info["PlaitDate"].ToString();
                //this.m_Source.投标信息表.备注 = info["Remark"].ToString();
                this.m_Source.投标信息表.锁号 = this.m_Parent.JMSH;
                this.m_Source.投标信息表.时间 = this.m_Parent.Time;
                this.m_Source.投标信息表.电脑串号 = this.m_Parent.JQH;
            }
        }
        /// <summary>
        /// 招标信息赋值
        /// </summary>
        /// <param name="dt"></param>
        private void SetZB()
        {
            if (this.m_Parent.StructSource.BiddingInfoSource.Rows.Count > 0)
            {
                DataRow info = this.m_Parent.StructSource.BiddingInfoSource.Rows[0];
                this.m_Source.招标信息表 = new 招标信息表();
                this.m_Source.招标信息表.工程类型 = info["GCLX"].ToString();
                this.m_Source.招标信息表.建设单位 = info["JSDW"].ToString();
                this.m_Source.招标信息表.招标代理 = info["ZBDLR"].ToString();
                this.m_Source.招标信息表.工程地点 = this.m_Parent.PGCDD;
                this.m_Source.招标信息表.计价依据 = this.m_Parent.DEGZ;
                this.m_Source.招标信息表.招标范围 = info["ZBFW"].ToString();
                this.m_Source.招标信息表.总招标面积 = info["ZBMJ"].ToString();
                this.m_Source.招标信息表.招标工期 = info["ZBGQ"].ToString();
                this.m_Source.招标信息表.编制人员1 = info["PlaitName"].ToString();
                this.m_Source.招标信息表.注册号1 = info["PlaitNo"].ToString();
                this.m_Source.招标信息表.编制人员2 = "";
                this.m_Source.招标信息表.注册号2 = "";
                //this.m_Source.招标信息表.编制人员3 = "";
                //this.m_Source.招标信息表.注册号3 = "";
           
                this.m_Source.招标信息表.编制单位 = info["BZDW"].ToString();
                this.m_Source.招标信息表.设计单位 = info["SJDW"].ToString();
                this.m_Source.招标信息表.编制时间 = info["PlaitDate"].ToString();
                this.m_Source.招标信息表.招标要求担保类型 = info["DBLX"].ToString();
                this.m_Source.招标信息表.纳税地区类别 = this.m_Parent.PNSDD;
               // this.m_Source.招标信息表.备注 = info["Remark"].ToString();
                this.m_Source.招标信息表.锁号 =this.m_Parent.JMSH;
                this.m_Source.招标信息表.时间 = this.m_Parent.Time;
                this.m_Source.招标信息表.电脑串号 = this.m_Parent.JQH;
            }
        }

        /// <summary>
        /// 单项工程的赋值
        /// </summary>
        /// <param name="dt"></param>
        private void SetEngZBS(单项工程 dx, _Engineering ceng)
        {
            _Pr_Business  pr=this.CurrentBusiness as _Pr_Business;
            dx.单项工程名称 = ceng.Name;
            dx.建筑面积 = "";
            DataRow[] UnRows = this.m_Parent.StructSource.ModelProject.Select(string.Format("PID = {0}", ceng.ID), "Sort asc");
            _UnitProject pinfo = null;
            dx.单位工程 = new 单位工程[UnRows.Length];
            int i = 0;
            object o=null;

            foreach (DataRow r in UnRows)
            {
                pinfo = null;
                o = pr.ObjectList[r["ID"]];
                if (o != null) pinfo = o as _UnitProject;
                 //pinfo = r["UnitProject"] as _UnitProject;
                //_ObjectSource.GetObject(pinfo, r);
                if (pinfo == null)
                {
                    pinfo = new _UnitProject();
                    _ObjectSource.GetObject(pinfo, r);
                  //  pinfo.Deep = 2;

                    pr.LoadForXml(pinfo);
                    //反序列化
                    //  pinfo = (this.CurrentBusiness as _Pr_Business).Load()
                    //回写到表中 
                    //  pinfo.InSerializable(ceng);
                   // this.m_Parent.StructSource.ModelProject.AppendUnit(pinfo);//此方法在新建的工程中无效
                    //pinfo.Property = new _Un_Property(pinfo);
                    //pinfo.Reveal = new
                }
                
                dx.单位工程[i] = new 单位工程();
                SetCUnitZBS(dx.单位工程[i], pinfo);
                i++;
            }
        }
        /// <summary>
        /// 单位工程赋值
        /// </summary>
        /// <param name="dw"></param>
        /// <param name="uprj"></param>
        private void SetCUnitZBS(单位工程 dw, _UnitProject uprj)
        {
            this.m_CurrentBusiness.SetKeyNo(uprj);
            dw.锁号 = uprj.JMSH;
            dw.时间 = uprj.Time;
            dw.电脑串号 = uprj.JQH;
            dw.单位工程名称 = uprj.Name;
            dw.清单专业 = uprj.Property.DLibraries.ListGallery.LibName.Replace("清单库", "");
            dw.定额专业 = uprj.PrfType.Replace("【", "").Replace("】", "").Replace("专业", "");
            dw.单位工程造价汇总表 = new 单位工程造价汇总表();
            //if (uprj.Property.Metaanalysis.Source != null)
            SetHuiZongZBS(dw.单位工程造价汇总表, uprj.StructSource.ModelMetaanalysis);
            dw.分部分项表 = new 分部分项表();//分部分项赋值
            //uprj.Property.SubSegments.SetXH();//重排序号
            SetQD(dw.分部分项表, uprj.StructSource.ModelSubSegments, uprj);
            dw.措施项目表 = new 措施项目表();//措施项目赋值
            //if (!uprj.Property.MeasuresProject.IsInit)
            SetCBT(dw.措施项目表, uprj.StructSource.ModelMeasures, uprj);

            dw.其他项目表 = new 其他项目表();//其他项目赋值
            // if(!uprj.Property.OtherProject.IsInit)
            SetOtherZBS(dw.其他项目表, uprj);
            dw.需评审的材料表 = new 需评审的材料表();
            dw.材料设备暂估价 = new 材料设备暂估价();
            dw.甲供材料或设备表 = new 甲供材料或设备表();
            dw.人材机库 = new 人材机库();
            dw.三大材 = new 三大材();
            dw.工程代号 = uprj.CODE;
            DataRow[] QuantityUnitSummary = uprj.StructSource.ModelQuantity.AsEnumerable().Distinct(new MergerSummarys()).ToArray();
            DataRow[] QuantityYTLB = uprj.StructSource.ModelYTLBSummary.AsEnumerable().Distinct(new MergerSummarys()).ToArray();
            
            if (!IsZBS)
            {
                dw.人材机库.人才机 = new List<人材机>();
                SetRcj(dw.人材机库, QuantityUnitSummary, uprj);
                SetSDC(dw.三大材, QuantityUnitSummary.Where(p => !p["SDCLB"].Equals("")).ToArray());
                
            }
            SetXPS(dw.需评审的材料表, QuantityYTLB.Where(p => p["YTLB"].Equals(UseType.评标指定材料.ToString())).ToArray());
            SetZGCL(dw.材料设备暂估价, QuantityYTLB.Where(p => p["YTLB"].Equals(UseType.暂定价材料.ToString())).ToArray());
            SetJGCL(dw.甲供材料或设备表, QuantityYTLB.Where(p => p["YTLB"].Equals(UseType.甲供材料.ToString())).ToArray());
            dw.规费税金清单表 = new 规费税金清单表();
            //if (!uprj.Property.Metaanalysis.IsInit)
            // if (uprj.Property.Metaanalysis.Source!=null)
            SetSJ(dw.规费税金清单表, uprj.StructSource.ModelMetaanalysis);
        }

        /// <summary>
        /// 需评审的材料表
        /// </summary>
        /// <param name="sj"></param>
        /// <param name="m"></param>
        private void SetXPS(需评审的材料表 sj, DataRow[] m)
        {
            if (m == null) return;
            sj.评审材料 = new List<评审材料>();
            for (int i = 0; i < m.Length; i++)
            {
                DataRow item = m[i];
                评审材料 r = new 评审材料();
                r.序号 = (i + 1).ToString();
                r.材料编号 = item["BH"].ToString();
                r.名称 = item["MC"].ToString();
                r.规格型号 = item["GGXH"].ToString();
                r.单位 = item["DW"].ToString();
                if (IsZBS)
                {
                    r.单价 = "";
                    r.合价 = "";
                    r.数量 = "";
                }
                else
                {
                    r.单价 = item["SCDJ"].ToString();
                    r.合价 = item["SCHJ"].ToString();
                    r.数量 = item["SL"].ToString();
                
                }
                r.备注 = item["GLJBZ"].ToString();
                sj.评审材料.Add(r);
            }

        }
        /// <summary>
        /// 材料设备暂估价
        /// </summary>
        /// <param name="sj"></param>
        /// <param name="m"></param>
        private void SetZGCL(材料设备暂估价 sj, DataRow[] m)
        {
            if (m == null) return;
            sj.材料设备暂估价明细 = new List<材料设备暂估价明细>();
            for (int i = 0; i < m.Length; i++)
            {
                DataRow item = m[i];
                材料设备暂估价明细 r = new 材料设备暂估价明细();
                r.序号 = (i + 1).ToString();
                r.材料或设备编号 = item["BH"].ToString();
                r.材料名称 = item["MC"].ToString();
                r.规格型号 = item["GGXH"].ToString();
                r.计量单位 = item["DW"].ToString();
                r.暂估单价 = item["SCDJ"].ToString();
                if (IsZBS)
                {
                    r.数量 = "";
                    r.合价 = "";
                }
                else
                {
                    r.数量 = item["SL"].ToString();
                    r.合价 = item["SCHJ"].ToString();
                }
                r.备注 = item["GLJBZ"].ToString();
                sj.材料设备暂估价明细.Add(r);
            }
        }
        /// <summary>
        /// 甲供材料或设备表
        /// </summary>
        /// <param name="sj"></param>
        /// <param name="m"></param>
        private void SetJGCL(甲供材料或设备表 sj, DataRow[] m)
        {
            if (m == null) return;
            sj.甲供材料或设备 = new List<甲供材料或设备>();
            for (int i = 0; i < m.Length; i++)
            {
                DataRow item = m[i];
                甲供材料或设备 r = new 甲供材料或设备();
                r.序号 = (i + 1).ToString();
                r.材料或设备编号 = item["BH"].ToString();
                r.名称 = item["MC"].ToString();
                r.规格型号 = item["GGXH"].ToString();
                r.单位 = item["DW"].ToString();
                r.单价 = item["SCDJ"].ToString();
                if (IsZBS)
                {
                    r.数量 = "";
                    r.合价 = "";

                }
                else
                {
                    r.数量 = item["SL"].ToString();
                    r.合价 = item["SCHJ"].ToString();
                }
                r.备注 = item["GLJBZ"].ToString();
                sj.甲供材料或设备.Add(r);
            }

        }


        private void SetSDC(三大材 sj, DataRow[] m)
        {
            if (m == null) return;
            sj.人才机 = new List<人材机>();
            foreach (DataRow item in m)
            {
                人材机 r = new 人材机();
                r.暂估价材料关联号 = "";
                r.甲供材料关联号 = "";
                r.评审材料关联号 = "";
                r.材料号 = item["BH"].ToString();
                r.材料名 = item["MC"].ToString();
                r.规格型号 = item["GGXH"].ToString();
                r.单位 = item["DW"].ToString();
                r.单价 = item["SCDJ"].ToString();
                r.数量 = item["SL"].ToString();
                r.费用类别 = item["LB"].ToString();
                r.主要材料标志 = ToolKit.ParseBoolen(item["IFZYCL"]);
                r.定额价 = item["DEDJ"].ToString();
                r.类别 = item["SDCLB"].ToString();
                sj.人才机.Add(r);
            }
        }

        /// <summary>
        ///单位工程人材机库赋值
        /// </summary>
        /// <param name="sj"></param>
        /// <param name="m"></param>
        private void SetRcj(人材机库 sj, DataRow[] m, _UnitProject uprj)
        {
            sj.人才机 = new List<人材机>();
            DataRow[] QuantityYTLB;
            foreach (DataRow item in m)
            {
                QuantityYTLB = uprj.StructSource.ModelYTLBSummary.Select("BDBH='" + item["BH"].ToString() +"'");
                人材机 r = new 人材机();
                if (QuantityYTLB != null && QuantityYTLB.Length > 0)
                {
                    if (item["YTLB"].ToString().Equals("暂定价材料"))
                    {
                        r.暂估价材料关联号 = QuantityYTLB[0]["BH"].ToString();
                        r.甲供材料关联号 = "";
                        r.评审材料关联号 = "";
                    }
                    else if (item["YTLB"].ToString().Equals("甲供材料"))
                    {
                        r.甲供材料关联号 = QuantityYTLB[0]["BH"].ToString();
                        r.暂估价材料关联号 = "";
                        r.评审材料关联号 = "";
                    }
                    else if (item["YTLB"].ToString().Equals("评标指定材料"))
                    {
                        r.评审材料关联号 = QuantityYTLB[0]["BH"].ToString();
                        r.暂估价材料关联号 = "";
                        r.甲供材料关联号 = "";
                    }
                }
                else
                {
                    r.暂估价材料关联号 = "";
                    r.甲供材料关联号 = "";
                    r.评审材料关联号 = "";
                }
                r.材料号 = item["BH"].ToString();
                r.材料名 = item["MC"].ToString();
                r.规格型号 = item["GGXH"].ToString();
                r.单位 = item["DW"].ToString();
                r.单价 = item["SCDJ"].ToString();
                r.数量 = item["SL"].ToString();
                r.费用类别 = item["LB"].ToString();
                r.主要材料标志 = ToolKit.ParseBoolen(item["IFZYCL"]);
                r.定额价 = item["DEDJ"].ToString();
                if (item["IFKFJ"].Equals(true))
                {
                    DataRow[] rows = uprj.StructSource.ModelQuantity.Select(string.Format("PID={0} and SSLB={1}", item["ID"], item["SSLB"]));

                    r.人材机含量 = new List<人材机含量>();
                    foreach (DataRow item1 in rows)
                    {
                        人材机含量 hl = new 人材机含量();
                        hl.材料号 = item1["BH"].ToString();
                        hl.含量 = item1["XHL"].ToString();
                        hl.原始含量 = item1["YSXHL"].ToString();
                        r.人材机含量.Add(hl);
                    }

                    //if (info1!=null)
                    //{
                    //    if (info1.QuantityUnitComponentList.Count > 0)
                    //    {
                    //        r.人材机含量 = new List<人材机含量>();
                    //        foreach (_ObjectQuantityUnitInfo item1 in info1.QuantityUnitComponentList)
                    //        {

                    //            人材机含量 hl = new 人材机含量();
                    //            hl.材料号 = item1.BH;
                    //            hl.含量 = item1.XHL.ToString();
                    //            hl.原始含量 = item1.YSXHL.ToString();
                    //            r.人材机含量.Add(hl);
                    //        }
                    //    }

                    //}
                }

                sj.人才机.Add(r);
                // r.主要材料标志 = item["zy;
            }
        }


        /// <summary>
        /// 税金赋值 
        /// </summary>
        /// <param name="sj"></param>
        /// <param name="m"></param>
        private void SetSJ(规费税金清单表 sj, _MetaanalysisSource m)
        {
            SetTemplate(m);
            规费税金清单表 gfsj = CFiles.XmlDeserialize(typeof(规费税金清单表), this.m_GTemplatePath) as 规费税金清单表;

            sj.规费税金项 = gfsj.规费税金项;
            foreach (规费税金项 item in gfsj.规费税金项)
            {
                if (item.费用名称.Contains("劳保统筹") || item.费用名称.Contains("养老保险"))
                {
                    item.费率 = getValueByHuizong(QFtype.FL, "劳保统筹", m);
                    if (ToolKit.ParseDecimal(item.费率) <= 0)
                    {
                        item.费率 = ToolKit.TrimZero(getValueByHuizong(QFtype.FL, "养老保险", m));
                    }
                }

                if (!IsZBS)
                {

                    if (item.费用名称.Contains("劳保统筹") || item.费用名称.Contains("养老保险"))
                    {
                        item.金额 = getValueByHuizong(QFtype.JE, "劳保统筹", m);
                        item.费率 = ToolKit.TrimZero(getValueByHuizong(QFtype.FL, "劳保统筹", m));
                        if (ToolKit.ParseDecimal(item.金额) <= 0)
                        {
                            item.金额 = getValueByHuizong(QFtype.JE, "养老保险", m);
                            item.费率 = getValueByHuizong(QFtype.FL, "养老保险", m);
                        }
                    }
                    else
                    {
                        item.费率 = ToolKit.TrimZero(getValueByHuizong(QFtype.FL, item.费用名称, m));
                        item.金额 = getValueByHuizong(QFtype.JE, item.费用名称, m);
                    }

                }
                else
                {
                    item.费率 = ToolKit.TrimZero(getValueByHuizong(QFtype.FL, item.费用名称, m));
                    item.金额 = "0";
                }
            }
        }
        /// <summary>
        /// 其他项目赋值
        /// </summary>
        /// <param name="qt"></param>
        /// <param name="other"></param>
        private void SetOtherZBS(其他项目表 qt, _UnitProject uprj)
        {
            string jrgxh = "1";

            //sql = "select * from 其他项目表  where Remark='属于投标人部分'";
            //DataTable table = null, childTable = null;
            //table = this.FillTable(sql, p_tran);
            //if (table != null)
            //{
            //    foreach (DataRow row in table.Rows)
            //    {
            //        sql = "select * from 其他项目表  where ParentID = " + row["ID"].ToString();

            //        childTable = this.FillTable(sql, p_tran);
            //        sql = "update 其他项目表 set Calculation='',Unitprice=0,Combinedprice=0,jsdJ=0,cjdj=0,cjHj=0,Coefficient=0 where ID =";
            //        this.ExecuteSql(sql + row["ID"].ToString(), p_tran);
            //        if (childTable != null)
            //        {
            //            foreach (DataRow cRow in childTable.Rows)
            //            {
            //                this.ExecuteSql(sql + cRow["ID"].ToString(), p_tran);
            //            }
            //        }
            //    }
            //}

            DataRow[] rows = uprj.StructSource.ModelOtherProject.Select(string.Format(" Feature='{0}'or Feature='{1}'or Feature='{2}'or Feature='{3}' or Feature='{4}'", "ZLJE", "ZYGCZGJ", "JRG", "ZCBFWF", "FSPTJJJ"));
            qt.其他项目清单 = new 其他项目清单[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                qt.其他项目清单[i] = new 其他项目清单();
                qt.其他项目清单[i].序号 = rows[i]["Number"].ToString().Replace("F1.", "");
                qt.其他项目清单[i].项目名称 = rows[i]["Name"].ToString();
                qt.其他项目清单[i].计量单位 = rows[i]["Unit"].ToString();
                qt.其他项目清单[i].工程数量 = rows[i]["Quantities"].ToString();
                qt.其他项目清单[i].综合单价 = "1";
                qt.其他项目清单[i].计算基础 = rows[i]["Calculation"].ToString();
                qt.其他项目清单[i].费率 = rows[i]["Coefficient"].ToString();
                if (!string.IsNullOrEmpty(rows[i]["Combinedprice"].ToString()) && !IsZBS)
                {
                    qt.其他项目清单[i].合价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    qt.其他项目清单[i].综合单价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Unitprice"].ToString()),2).ToString();
                }
                else 
                {
                    if (!rows[i]["Number"].ToString().StartsWith("F1.1") && !rows[i]["Number"].ToString().StartsWith("F1.2"))
                    {
                        qt.其他项目清单[i].合价 = "";
                        qt.其他项目清单[i].综合单价 = "";
                        qt.其他项目清单[i].计算基础 = "";
                        qt.其他项目清单[i].费率 = "";
                    }
                    else
                    {
                        qt.其他项目清单[i].合价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                        qt.其他项目清单[i].综合单价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Unitprice"].ToString()), 2).ToString();
                    }

                
                }

                qt.其他项目清单[i].费用类型 = rows[i]["Name"].ToString();
                if (qt.其他项目清单[i].项目名称 == "计日工")
                {
                    jrgxh = qt.其他项目清单[i].序号;
                }

            }
            /*********暂列金额明细*********/
            qt.暂列金额明细表 = new 暂列金额明细表();
            rows = uprj.StructSource.ModelOtherProject.Select(string.Format(" Feature='{0}' ", "SJBGCJ"));
            qt.暂列金额明细表.暂列金额明细 = new 暂列金额明细[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                qt.暂列金额明细表.暂列金额明细[i] = new 暂列金额明细();
                qt.暂列金额明细表.暂列金额明细[i].序号 = rows[i]["Number"].ToString().Replace("F1.", "");
                qt.暂列金额明细表.暂列金额明细[i].项目名称 = rows[i]["Name"].ToString();
                qt.暂列金额明细表.暂列金额明细[i].计量单位 = rows[i]["Unit"].ToString();
                if (!IsZBS)
                {
                    if (!string.IsNullOrEmpty(rows[i]["Combinedprice"].ToString()))
                    {
                        qt.暂列金额明细表.暂列金额明细[i].暂定金额 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }
                    else
                    {
                        qt.暂列金额明细表.暂列金额明细[i].暂定金额 = "0";
                    }

                }
                else
                {
                    if (!rows[i]["Number"].ToString().StartsWith("F1.1") && !rows[i]["Number"].ToString().StartsWith("F1.2"))
                    {
                        qt.暂列金额明细表.暂列金额明细[i].暂定金额 = "0"; 
                    }
                    else
                    {
                        qt.暂列金额明细表.暂列金额明细[i].暂定金额 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }

                    
                
                }

                qt.暂列金额明细表.暂列金额明细[i].备注 = rows[i]["Remark"].ToString();
            }
            /*********专业工程暂估价明细表*********/
            qt.专业工程暂估价明细表 = new 专业工程暂估价明细表();
            rows = uprj.StructSource.ModelOtherProject.Select(string.Format(" Feature='{0}' or Feature='{1}' ", "ZCSBZGJ", "LXFBGCE"));
            qt.专业工程暂估价明细表.专业工程暂估明细 = new 专业工程暂估明细[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                qt.专业工程暂估价明细表.专业工程暂估明细[i] = new 专业工程暂估明细();
                qt.专业工程暂估价明细表.专业工程暂估明细[i].序号 = rows[i]["Number"].ToString().Replace("F1.", "");
                qt.专业工程暂估价明细表.专业工程暂估明细[i].项目名称 = rows[i]["Name"].ToString();
                qt.专业工程暂估价明细表.专业工程暂估明细[i].计量单位 = rows[i]["Unit"].ToString();
                if (!IsZBS)
                {
                    if (!string.IsNullOrEmpty(rows[i]["Combinedprice"].ToString()))
                    {


                        qt.专业工程暂估价明细表.专业工程暂估明细[i].暂估单价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }
                    else
                    {
                        qt.专业工程暂估价明细表.专业工程暂估明细[i].暂估单价 = "0";
                    }
                }
                else
                {
                    if (!rows[i]["Number"].ToString().StartsWith("F1.1") && !rows[i]["Number"].ToString().StartsWith("F1.2"))
                    {
                        qt.专业工程暂估价明细表.专业工程暂估明细[i].暂估单价 = "0";
                    }
                    else
                    {
                        qt.专业工程暂估价明细表.专业工程暂估明细[i].暂估单价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }

                }
                qt.专业工程暂估价明细表.专业工程暂估明细[i].备注 = rows[i]["Remark"].ToString();
            }


            /*********计日工表*********/
            qt.计日工表 = new 计日工表();
            rows = uprj.StructSource.ModelOtherProject.Select(string.Format(" Feature like '%{0}%' or  Feature like '%{1}%' or  Feature like '%{2}%' ", "JRGRG", "JRGCL", "JRGJX"));
            //qt.计日工表.计日工项 = null;
            for (int i = 0; i < rows.Length; i++)
            {
                DataRow[] rows1 = uprj.StructSource.ModelOtherProject.Select(string.Format(" ParentID = {0} ", rows[i]["ID"]));
                if (rows1.Length > 0)
                {
                    if (qt.计日工表.计日工项 == null)
                    {
                        qt.计日工表.计日工项 = new List<计日工项>();
                    }
                    SetJRG(rows1, qt.计日工表, uprj, jrgxh);
                }
            }

            /*********总承包服务费项目表*********/
            qt.总承包服务费项目表 = new 总承包服务费项目表();
            rows = uprj.StructSource.ModelOtherProject.Select(string.Format(" Feature='{0}' or Feature='{1}' ", "FBGLFWF", "FBRBGF"));
            qt.总承包服务费项目表.总承包服务费项 = new 总承包服务费项[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                qt.总承包服务费项目表.总承包服务费项[i] = new 总承包服务费项();
                qt.总承包服务费项目表.总承包服务费项[i].序号 = rows[i]["Number"].ToString().Replace("F1.", "");
                qt.总承包服务费项目表.总承包服务费项[i].项目名称 = rows[i]["Name"].ToString();
                qt.总承包服务费项目表.总承包服务费项[i].工程数量 = rows[i]["Quantities"].ToString();
                qt.总承包服务费项目表.总承包服务费项[i].计量单位 = rows[i]["Unit"].ToString();
                qt.总承包服务费项目表.总承包服务费项[i].综合单价 = "0";
                qt.总承包服务费项目表.总承包服务费项[i].合价 = "0";
                if (!IsZBS)
                {
                    if (!string.IsNullOrEmpty(rows[i]["Combinedprice"].ToString()))
                    {
                        qt.总承包服务费项目表.总承包服务费项[i].综合单价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Unitprice"].ToString()), 2).ToString();
                        qt.总承包服务费项目表.总承包服务费项[i].合价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }
                }
                else
                {
                    if (!rows[i]["Number"].ToString().StartsWith("F1.1") && !rows[i]["Number"].ToString().StartsWith("F1.2"))
                    {
                        qt.总承包服务费项目表.总承包服务费项[i].综合单价 = "";
                        qt.总承包服务费项目表.总承包服务费项[i].合价 = "";
                    }
                    else
                    {
                        qt.总承包服务费项目表.总承包服务费项[i].综合单价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Unitprice"].ToString()), 2).ToString();
                        qt.总承包服务费项目表.总承包服务费项[i].合价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }
                }

                qt.总承包服务费项目表.总承包服务费项[i].类别 = (i + 1).ToString();
                qt.总承包服务费项目表.总承包服务费项[i].备注 = rows[i]["Remark"].ToString();
            }

        }
        private void SetJRG(DataRow[] rows, 计日工表 计日工表, _UnitProject uprj, string jrgxh)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                计日工项 jrg = new 计日工项();
                jrg.编号 = jrgxh + "." + (计日工表.计日工项.Count + 1).ToString();
                jrg.名称 = rows[i]["Name"].ToString();
                jrg.单位 = rows[i]["Unit"].ToString();
                jrg.暂定数量 = rows[i]["Quantities"].ToString();
                jrg.综合单价=rows[i]["Calculation"].ToString();
                jrg.合价 = "0";

                if (!IsZBS)
                {
                    if (!string.IsNullOrEmpty(rows[i]["Combinedprice"].ToString()))
                    {
                        jrg.合价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }
                }
                else
                {
                    if (!rows[i]["Number"].ToString().StartsWith("F1.1") && !rows[i]["Number"].ToString().StartsWith("F1.2"))
                    {
                        jrg.综合单价 = "";
                        jrg.合价 = "";
                    }
                    else
                    {
                        jrg.合价 = Math.Round(ToolKit.ParseDecimal(rows[i]["Combinedprice"].ToString()), 2).ToString();
                    }
                }
                DataRow[] rows1 = uprj.StructSource.ModelOtherProject.Select(string.Format("ID={0}", rows[i]["ParentID"].ToString()));
                if (rows1.Length > 0)
                {
                    jrg.类别 = rows1[0]["Name"].ToString();
                }

                jrg.备注 = rows[i]["Remark"].ToString();
                计日工表.计日工项.Add(jrg);
            }
        }
        private DataRow GetMeasuresFirst(_UnitProject uprj)
        {
            DataRow[] rows = uprj.StructSource.ModelMeasures.Select("PID=0");
            if (rows.Length > 0) return rows[0]; else return null;
        }
        /// <summary>
        /// 措施项目赋值
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="mea"></param>
        private void SetCBT(措施项目表 cs, _MeasuresSource mea, _UnitProject uprj)
        {
            string stringChnNames = "零一二三四五六七八九";
            string stringNumNames = "0123456789";
            DataRow m = GetMeasuresFirst(uprj);

            DataRow[] rows = mea.Select(string.Format("PID={0}", m["ID"]), "Sort asc", DataViewRowState.CurrentRows);
            cs.措施项目标题 = new 措施项目标题[rows.Length];
            int i = 0;
            foreach (DataRow item in rows)
            {
                cs.措施项目标题[i] = new 措施项目标题();
                cs.措施项目标题[i].名称 = item["XMMC"].ToString();//通用项目的编码是名称
                cs.措施项目标题[i].序号 = stringChnNames[stringNumNames.IndexOf((i + 1).ToString())].ToString();
                cs.措施项目标题[i].项目编码 = item["XMBM"].ToString();
                if (item["XMBM"].Equals("C101"))
                {
                    SetTYCQD(cs.措施项目标题[i], item, uprj);
                }
                else
                {
                    SetCQD(cs.措施项目标题[i], item, uprj);
                }
                i++;
            }
        }
        /// <summary>
        /// 通用项目的清单赋值
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="Commonroject"></param>
        private void SetTYCQD(措施项目标题 cs, DataRow Commonroject, _UnitProject uprj)
        {

            cs.措施项目清单 = new List<措施项目清单>();
            DataRow[] rows = uprj.StructSource.ModelMeasures.Select(string.Format("PID={0}", Commonroject["ID"]), "Sort asc", DataViewRowState.CurrentRows);
            foreach (DataRow item in rows)
            {

                措施项目清单 csqd = new 措施项目清单();
                // csqd.序号 = item["XH2"].ToString();
                csqd.序号 = item["XH"].ToString();
                csqd.名称 = item["XMMC"].ToString();
                csqd.单位 = item["DW"].ToString();
                csqd.清单编码 = item["XMBM"].ToString();

                csqd.数量 = item["GCL"].ToString();
                csqd.计费基础表达式 = GetFormula(item["JSJC"].ToString(), "措施项目");
                csqd.计费基础金额 = "0";
                csqd.费率 = ToolKit.TrimZero(item["FL"].ToString());
                if (!IsZBS)
                {

                    csqd.综合合价 = item["ZHHJ"].ToString();
                    csqd.人工费合计 = item["RGFHJ"].ToString();
                    csqd.材料费合计 = item["CLFHJ"].ToString();
                    csqd.机械费合计 = item["JXFHJ"].ToString();
                    csqd.主材费合计 = item["ZCFHJ"].ToString();
                    csqd.设备费合计 = item["SBFHJ"].ToString();
                    csqd.管理费合计 = item["GLFHJ"].ToString();
                    csqd.利润合计 = item["LRHJ"].ToString();
                    csqd.风险合计 = item["FXHJ"].ToString();
                    csqd.规费合计 = item["GFHJ"].ToString();
                    csqd.税金合计 = item["SJHJ"].ToString();
                }
                else
                {

                    csqd.综合合价 = "0";
                    csqd.人工费合计 = "0";
                    csqd.材料费合计 = "0";
                    csqd.机械费合计 = "0";
                    csqd.主材费合计 = "0";
                    csqd.设备费合计 = "0";
                    csqd.管理费合计 = "0";
                    csqd.利润合计 = "0";
                    csqd.风险合计 = "0";
                    csqd.规费合计 = "0";
                    csqd.税金合计 = "0";
                }
                if (!item["ZJFS"].Equals("子目组价"))
                {
                    csqd.公式组价 = true;
                    if (item["LB"].Equals("清单") && int.Parse(item["XH"].ToString()) > 4 && IsZBS)
                    {
                        csqd.费率 = "0";
                        csqd.计费基础表达式 = "";
                        csqd.综合合价 = "0";
                    }
                }

                csqd.行类别 = "措施项";
                csqd.备注 = Commonroject["XMBM"].ToString();
                //安全文明施工(含环境保护、文明施工、安全施工、临时设施)从汇总分析取费
                cs.措施项目清单.Add(csqd);
                //if (item["XH2==1)
                //{
                //   DataRow[] rows = Commonroject.Parent.Parent.Property.Metaanalysis.Source.Select(string.Format(" Number like '%{0}%' ", "F2.1."));

                //   foreach (DataRow row in rows)
                //   {

                //       措施项目清单 csqdz = new 措施项目清单();
                //       csqdz.序号 = row["Number"].ToString().Replace("F2.","");
                //       csqdz.名称 = row["Name"].ToString();
                //       csqdz.单位 = row["Name"].ToString();
                //       csqdz.数量 = "1";

                //       csqdz.计费基础表达式 = GetFormula(row["Calculation"].ToString());
                //       csqdz.计费基础金额 = "0";
                //       csqdz.费率 = row["Coefficient"].ToString();
                //      // csqdz.综合合价 = row["Coefficient"].ToString();
                //     //  csqdz.人工费合计 = item["RGFHJ; 
                //      // csqdz.材料费合计 = item["CLFHJ;
                //     //  csqdz.机械费合计 = item["JXFHJ;
                //      // csqdz.主材费合计 = item["ZCFHJ;
                //      // csqdz.设备费合计 = item["SBFHJ;
                //     //  csqdz.管理费合计 = item["GLFHJ;
                //    //   csqdz.利润合计 = item["LRHJ;
                //      // csqdz.风险合计 = item["FXHJ;
                //    //   csqdz.规费合计 = item["GFHJ;

                //      // csqdz.税金合计 = item["SJHJ; 
                //       csqdz.公式组价 = true;
                //       csqdz.行类别 = "子措施项";
                //       csqdz.备注 = Commonroject.XMBM;
                //       //安全文明施工(含环境保护、文明施工、安全施工、临时设施)从汇总分析取费
                //       cs.措施项目清单.Add(csqdz);
                //   }

                //}

                int i = 0;
                bool flag = false;//标识是否有子目组价的子目
                DataRow[] rows1 = uprj.StructSource.ModelMeasures.Select(string.Format("PID={0}", item["ID"]), " Sort asc", DataViewRowState.CurrentRows);
                foreach (DataRow item0 in rows1)
                {
                    if (ToolKit.ParseInt(item["XH"])>4)
                    {
                        flag = true;
                        break;
                        // SetZM()
                    }
                    else
                    {

                        i++;
                        措施项目清单 csqdz = new 措施项目清单();
                        // csqdz.序号 = item["XH2"].ToString() + "." + i.ToString();
                        csqdz.序号 = item["XH"].ToString() + "." + i.ToString();
                        csqdz.名称 = item0["XMMC"].ToString();
                        csqdz.单位 = item0["DW"].ToString();
                        csqdz.数量 = item0["GCL"].ToString();
                        csqdz.清单编码 = item["XMBM"].ToString();
                        csqdz.计费基础表达式 = GetFormula(item0["JSJC"].ToString(), "措施项目");
                        csqdz.计费基础金额 = "0";
                        csqdz.费率 = ToolKit.TrimZero(item0["FL"].ToString());
                        if (!IsZBS)
                        {

                            csqdz.综合合价 = item0["ZHHJ"].ToString();
                            csqdz.人工费合计 = item0["RGFHJ"].ToString();
                            csqdz.材料费合计 = item0["CLFHJ"].ToString();
                            csqdz.机械费合计 = item0["JXFHJ"].ToString();
                            csqdz.主材费合计 = item0["ZCFHJ"].ToString();
                            csqdz.设备费合计 = item0["SBFHJ"].ToString();
                            csqdz.管理费合计 = item0["GLFHJ"].ToString();
                            csqdz.利润合计 = item0["LRHJ"].ToString();
                            csqdz.风险合计 = item0["FXHJ"].ToString();
                            csqdz.规费合计 = item0["GFHJ"].ToString();
                            csqdz.税金合计 = item0["SJHJ"].ToString();
                        }
                        else
                        {
                            csqdz.综合合价 = "0";
                            csqdz.人工费合计 = "0";
                            csqdz.材料费合计 = "0";
                            csqdz.机械费合计 = "0";
                            csqdz.主材费合计 = "0";
                            csqdz.设备费合计 = "0";
                            csqdz.管理费合计 = "0";
                            csqdz.利润合计 = "0";
                            csqdz.风险合计 = "0";
                            csqdz.规费合计 = "0";
                            csqdz.税金合计 = "0";
                        }
                        if (!item0["ZJFS"].Equals("子目组价"))
                        {
                            csqdz.公式组价 = true;
                            if (item0["LB"].Equals("清单") && int.Parse(item["XH"].ToString()) > 4 && IsZBS)
                            {
                                csqdz.费率 = "0";
                                csqdz.计费基础表达式 = "";
                                csqdz.综合合价 = "0";
                            }
                        }
                        csqdz.行类别 = "子措施项";
                        csqdz.备注 = Commonroject["XMBM"].ToString();
                        //安全文明施工(含环境保护、文明施工、安全施工、临时设施)从汇总分析取费
                        cs.措施项目清单.Add(csqdz);
                    }
                }
                if (flag)//若还有子目组价则
                {
                    if (!IsZBS)
                    {
                        csqd.定额子目 = SetZM(csqd.定额子目, item, uprj);

                    }
                }
            }
        }
        private void SetCQD(措施项目标题 cs, DataRow Commonroject, _UnitProject uprj)
        {
            DataRow[] rows = uprj.StructSource.ModelMeasures.Select(string.Format("PID={0}", Commonroject["ID"]), "Sort asc", DataViewRowState.CurrentRows);
            cs.措施项目清单 = new List<措施项目清单>();
            foreach (DataRow item in rows)
            {
                措施项目清单 csqd = new 措施项目清单();
                csqd.序号 = item["XH"].ToString();
                csqd.名称 = item["XMMC"].ToString();
                csqd.单位 = item["DW"].ToString();
                csqd.数量 = item["GCL"].ToString();
                csqd.计费基础表达式 = GetFormula(item["JSJC"].ToString(), "措施项目");
                csqd.计费基础金额 = "0";
                csqd.清单编码 = item["XMBM"].ToString();
                if (!IsZBS)
                {
                    csqd.费率 = ToolKit.TrimZero(item["FL"].ToString());
                    csqd.综合合价 = item["ZHHJ"].ToString();
                    csqd.人工费合计 = item["RGFHJ"].ToString();
                    csqd.材料费合计 = item["CLFHJ"].ToString();
                    csqd.机械费合计 = item["JXFHJ"].ToString();
                    csqd.主材费合计 = item["ZCFHJ"].ToString();
                    csqd.设备费合计 = item["SBFHJ"].ToString();
                    csqd.管理费合计 = item["GLFHJ"].ToString();
                    csqd.利润合计 = item["LRHJ"].ToString();
                    csqd.风险合计 = item["FXHJ"].ToString();
                    csqd.规费合计 = item["GFHJ"].ToString();
                    csqd.税金合计 = item["SJHJ"].ToString();
                }
                else
                {
                    csqd.费率 = "0";
                    csqd.综合合价 = "0";
                    csqd.人工费合计 = "0";
                    csqd.材料费合计 = "0";
                    csqd.机械费合计 = "0";
                    csqd.主材费合计 = "0";
                    csqd.设备费合计 = "0";
                    csqd.管理费合计 = "0";
                    csqd.利润合计 = "0";
                    csqd.风险合计 = "0";
                    csqd.规费合计 = "0";
                    csqd.税金合计 = "0";
                }
                if (!item["ZJFS"].Equals("子目组价"))
                {
                    csqd.公式组价 = true;

                    if (item["LB"].Equals("清单") && int.Parse(item["XH"].ToString()) > 4 && IsZBS)
                    {
                        csqd.费率 = "0";
                        csqd.计费基础表达式 = "";
                        csqd.综合合价 = "0";
                    }
                }
                csqd.行类别 = "措施项";
                csqd.备注 = Commonroject["XMBM"].ToString();
                //安全文明施工(含环境保护、文明施工、安全施工、临时设施)从汇总分析取费
                cs.措施项目清单.Add(csqd);

                int i = 0;

                bool flag = false;//标识是否有子目组价的子目
                DataRow[] rows1 = uprj.StructSource.ModelMeasures.Select(string.Format("PID={0}", item["ID"]), "Sort asc", DataViewRowState.CurrentRows);
                foreach (DataRow item0 in rows1)
                {
                    if (ToolKit.ParseInt(item["XH"]) > 4)
                    {
                        flag = true;
                        break;
                        // SetZM()
                    }
                    else
                    {
                        i++;
                        措施项目清单 csqdz = new 措施项目清单();
                        csqdz.序号 = item["XH"].ToString() + "." + i.ToString();
                        csqdz.名称 = item0["XMMC"].ToString();
                        csqdz.单位 = item0["DW"].ToString();
                        csqdz.数量 = item0["GCL"].ToString();
                        csqdz.计费基础表达式 = GetFormula(item0["JSJC"].ToString(), "措施项目");
                        csqdz.计费基础金额 = "0";
                        csqdz.清单编码 = item["XMBM"].ToString();
                        if (!IsZBS)
                        {
                            csqdz.费率 = ToolKit.TrimZero(item0["FL"].ToString());
                            csqdz.综合合价 = item0["ZHHJ"].ToString();
                            csqdz.人工费合计 = item0["RGFHJ"].ToString();
                            csqdz.材料费合计 = item0["CLFHJ"].ToString();
                            csqdz.机械费合计 = item0["JXFHJ"].ToString();
                            csqdz.主材费合计 = item0["ZCFHJ"].ToString();
                            csqdz.设备费合计 = item0["SBFHJ"].ToString();
                            csqdz.管理费合计 = item0["GLFHJ"].ToString();
                            csqdz.利润合计 = item0["LRHJ"].ToString();
                            csqdz.风险合计 = item0["FXHJ"].ToString();
                            csqdz.规费合计 = item0["GFHJ"].ToString();
                            csqdz.税金合计 = item0["SJHJ"].ToString();
                        }
                        else
                        {
                            csqdz.费率 = "0";
                            csqdz.综合合价 = "0";
                            csqdz.人工费合计 = "0";
                            csqdz.材料费合计 = "0";
                            csqdz.机械费合计 = "0";
                            csqdz.主材费合计 = "0";
                            csqdz.设备费合计 = "0";
                            csqdz.管理费合计 = "0";
                            csqdz.利润合计 = "0";
                            csqdz.风险合计 = "0";
                            csqdz.规费合计 = "0";
                            csqdz.税金合计 = "0";
                        }
                        if (!item0["ZJFS"].Equals("子目组价"))
                        {
                            csqdz.公式组价 = true;
                            if (item0["LB"].Equals("清单") && int.Parse(item0["XH"].ToString()) > 4 && IsZBS)
                            {
                                csqdz.费率 = "0";
                                csqdz.计费基础表达式 = "";
                                csqdz.综合合价 = "0";
                            }
                        }
                        csqdz.行类别 = "子措施项";
                        csqdz.备注 = Commonroject["XMBM"].ToString();
                        //安全文明施工(含环境保护、文明施工、安全施工、临时设施)从汇总分析取费
                        cs.措施项目清单.Add(csqdz);
                    }
                }

                if (flag)//若han有子目组价则
                {
                    if (!IsZBS)
                    {
                        csqd.定额子目 = SetZM(csqd.定额子目, item, uprj);
                    }
                }




            }


        }


        /// <summary>
        /// 分部分项清单的赋值
        /// </summary>
        /// <param name="fb"></param>
        /// <param name="sub"></param>
        private void SetQD(分部分项表 fb, _SubSegmentsSource sub, _UnitProject p_un)
        {

            DataRow[] rows = sub.Select(string.Format("LB='清单'"), "XH asc", DataViewRowState.CurrentRows);

            fb.分部分项清单 = new 分部分项清单[rows.Length];

            for (int i = 0; i < rows.Length; i++)

            //foreach (_FixedListInfo item in infos)
            {
                fb.分部分项清单[i] = new 分部分项清单();
                fb.分部分项清单[i].序号 = rows[i]["XH"].ToString();
                fb.分部分项清单[i].清单编码 = rows[i]["XMBM"].ToString();
                fb.分部分项清单[i].名称 = rows[i]["XMMC"].ToString();
                fb.分部分项清单[i].项目特征及工作内容 = rows[i]["XMTZ"].ToString();
                fb.分部分项清单[i].单位 = rows[i]["DW"].ToString();
                fb.分部分项清单[i].数量 = rows[i]["GCL"].ToString();

                fb.分部分项清单[i].管理费计费基础 = "0";
                fb.分部分项清单[i].管理费费率 = "0";
                fb.分部分项清单[i].利润计费基础 = "0";
                fb.分部分项清单[i].利润费率 = "0";
                fb.分部分项清单[i].风险计费基础 = "0";
                fb.分部分项清单[i].风险费率 = "0";
                fb.分部分项清单[i].规费计费基础 = "0";
                fb.分部分项清单[i].规费费率 = "0";

                fb.分部分项清单[i].税金计费基础 = "0";
                fb.分部分项清单[i].税金费率 = "0";
                fb.分部分项清单[i].主要清单 = ToolKit.ParseBoolen(rows[i]["ZYQD"]);
                fb.分部分项清单[i].专业类别 = p_un.ProType.Replace("【", "").Replace("】", "").Replace("专业", "");
                if (fb.分部分项清单[i].专业类别.Contains("建筑装饰"))
                {
                    fb.分部分项清单[i].专业类别 = "一般土建";
                }
                else if (fb.分部分项清单[i].专业类别.Contains("市政建筑安装"))
                {
                    fb.分部分项清单[i].专业类别 = "市政建筑";
                }

                fb.分部分项清单[i].序号 = rows[i]["XH"].ToString();

                if (!IsZBS)
                {
                    fb.分部分项清单[i].综合单价 = rows[i]["ZHDJ"].ToString();
                    fb.分部分项清单[i].综合合价 = rows[i]["ZHHJ"].ToString();
                    fb.分部分项清单[i].人工费单价 = rows[i]["RGFDJ"].ToString();
                    fb.分部分项清单[i].材料费单价 = rows[i]["CLFDJ"].ToString();
                    fb.分部分项清单[i].机械费单价 = rows[i]["JXFDJ"].ToString();
                    fb.分部分项清单[i].主材费单价 = rows[i]["ZCFDJ"].ToString();
                    fb.分部分项清单[i].设备费单价 = rows[i]["SBFDJ"].ToString();

                    fb.分部分项清单[i].管理费单价 = rows[i]["GLFDJ"].ToString();
                    fb.分部分项清单[i].利润单价 = rows[i]["LRDJ"].ToString();
                    fb.分部分项清单[i].风险单价 = rows[i]["FXDJ"].ToString();
                    fb.分部分项清单[i].规费单价 = rows[i]["GFDJ"].ToString();
                    fb.分部分项清单[i].税金单价 = rows[i]["SJDJ"].ToString();
                    //if (item.SubheadingsList.Count > 0)
                    //{
                    fb.分部分项清单[i].定额子目 = SetZM(fb.分部分项清单[i].定额子目, rows[i], p_un);

                    //}

                }
                else
                {
                    fb.分部分项清单[i].综合单价 = "0";
                    fb.分部分项清单[i].综合合价 = "0";
                    fb.分部分项清单[i].人工费单价 = "0";
                    fb.分部分项清单[i].材料费单价 = "0";
                    fb.分部分项清单[i].机械费单价 = "0";
                    fb.分部分项清单[i].主材费单价 = "0";
                    fb.分部分项清单[i].设备费单价 = "0";

                    fb.分部分项清单[i].管理费单价 = "0";
                    fb.分部分项清单[i].利润单价 = "0";
                    fb.分部分项清单[i].风险单价 = "0";
                    fb.分部分项清单[i].规费单价 = "0";
                    fb.分部分项清单[i].税金单价 = "0";
                }

            }
        }

        /// <summary>
        /// 子目赋值
        /// </summary>
        /// <param name="zm"></param>
        /// <param name="info">清单</param>
        private List<定额子目> SetZM(List<定额子目> zm, DataRow info, _UnitProject p_un)
        {
            bool IsM = false;
            //_FixedListInfo info1 = info as _FixedListInfo;
            //_MFixedListInfo info2= info as _MFixedListInfo;
            //IEnumerable<_ObjectInfo> infos;
            _SubSegmentsSource source = null;
            if (info["SSLB"].Equals(0))
            {
                source = p_un.StructSource.ModelSubSegments;
            }

            else
            {
                source = p_un.StructSource.ModelMeasures;
                IsM = true;
            }
            DataRow[] rows = source.Select(string.Format("PID={0}", info["ID"]), "Sort asc", DataViewRowState.CurrentRows);
            if (rows.Length < 0) return null; else zm = new List<定额子目>();
            foreach (DataRow ietm in rows)
            {
                if (!ietm["ZJFS"].Equals("费率组价") && !ietm["ZJFS"].Equals("直接组价"))
                {

                    定额子目 z = new 定额子目();
                    z.定额号 = ietm["XMBM"].ToString();
                    //  z.换算 = "";
                    z.名称 = ietm["XMMC"].ToString();
                    z.单位 = ietm["DW"].ToString();
                    z.数量 = ietm["GCL"].ToString();
                    z.综合单价 = ietm["ZHDJ"].ToString();
                    z.综合合价 = ietm["ZHHJ"].ToString();
                    z.人工费单价 = ietm["RGFDJ"].ToString();
                    z.材料费单价 = ietm["CLFDJ"].ToString();
                    z.机械费单价 = ietm["JXFDJ"].ToString();
                    z.主材费单价 = ietm["ZCFDJ"].ToString();
                    z.设备费单价 = ietm["SBFDJ"].ToString();
                    z.管理费单价 = ietm["GLFDJ"].ToString();
                    z.利润单价 = ietm["LRDJ"].ToString();
                    z.风险单价 = ietm["FXDJ"].ToString();
                    z.规费单价 = ietm["GFDJ"].ToString();
                    z.税金单价 = ietm["SJDJ"].ToString();
                    //z.利润计费基础 = ietm["XMBM;
                    // z.利润费率 = ietm["XMBM;

                    //z.风险计费基础 = ietm["XMBM;
                    //z.风险费率 = ietm["XMBM;

                    //z.规费计费基础 = ietm["XMBM;
                    //z.规费费率 = ietm["XMBM;

                    // z.税金计费基础 = ietm["XMBM;
                    // z.税金费率 = ietm["XMBM;
                    z.人工费价差 = "0";
                    z.材料费价差 = "0";
                    z.机械费价差 = "0";
                    z.专业类别 = ietm["ZYLB"].ToString();
                    //z.定额库代码 =
                    SetZMQF(ietm, z, p_un);
                    if (!IsM)
                    {
                        DataRow zinfo = ietm;
                        z.专业类别 = ietm["ZYLB"].ToString();
                        z.人材机含量 = SetZMCJ(z.人材机含量, ietm, p_un);
                    }
                    else
                    {


                        z.专业类别 = ietm["ZYLB"].ToString();
                        z.人材机含量 = SetZMCJ(z.人材机含量, ietm, p_un);

                    }
                    if (string.IsNullOrEmpty(z.专业类别.ToString()))
                    {
                        z.专业类别 = p_un.PrfType.Replace("【", "").Replace("】", "").Replace("专业", "");
                        if (z.专业类别.Contains("建筑装饰"))
                        {
                            z.专业类别 = "一般土建";
                        }
                        else if (z.专业类别.Contains("市政建筑安装"))
                        {
                            z.专业类别 = "市政建筑";
                        }

                    }
                    else
                    {
                        z.专业类别 = z.专业类别.Replace("专业", "");
                        if (z.专业类别.Contains("建筑装饰"))
                        {
                            z.专业类别 = "一般土建";
                        }
                        else if (z.专业类别.Contains("市政建筑安装"))
                        {
                            z.专业类别 = "市政建筑";
                        }
                    }
                    if (ietm["LibraryName"].ToString().Contains("建筑"))
                    {
                        z.定额库代码 = 1;
                    }
                    else if (ietm["LibraryName"].ToString().Contains("安装"))
                    {
                        z.定额库代码 = 2;
                    }
                    else if (ietm["LibraryName"].ToString().Contains("市政"))
                    {
                        z.定额库代码 = 3;
                    }
                    else if (ietm["LibraryName"].ToString().Contains("园林"))
                    {
                        z.定额库代码 = 4;
                    }
                    else if (ietm["LibraryName"].ToString().Contains("绿化"))
                    {
                        z.定额库代码 = 5;
                    }
                    else
                    {
                        z.定额库代码 = 0;
                    }
                    zm.Add(z);
                }
            }
            return zm;
        }

        private void SetZMQF(DataRow item, 定额子目 z, _UnitProject p_un)
        {
            DataRow info1 = item;


            if (info1 != null)
            {
                DataRow[] rows = p_un.StructSource.ModelSubheadingsFee.Select(string.Format("ZMID={0} and SSLB={1}", info1["ID"], info1["SSLB"]), "", DataViewRowState.CurrentRows);
                z.管理费费率 = ToolKit.TrimZero(GetFormula(ZMQFDH("二", rows, QFtype.FL), "子目取费"));
                z.管理费计费基础 = GetFormula(ZMQFDH("二", rows, QFtype.JSJC), "子目取费");

                z.利润计费基础 = GetFormula(ZMQFDH("三", rows, QFtype.JSJC), "子目取费"); ;
                z.利润费率 = ToolKit.TrimZero(GetFormula(ZMQFDH("三", rows, QFtype.FL), "子目取费"));

                z.风险计费基础 = GetFormula(ZMQFDH("F6", rows, QFtype.JSJC), "子目取费");
                z.风险费率 = ToolKit.TrimZero(GetFormula(ZMQFDH("F6", rows, QFtype.FL), "子目取费"));

                z.规费计费基础 = "";
                z.规费费率 = "0";

                z.税金计费基础 = "";
                z.税金费率 = "0";
            }


        }
        private string ZMQFDH(string No, DataRow[] list, QFtype type)
        {
            //string str = "";
            IEnumerable<DataRow> lists = from info in list.Cast<DataRow>()
                                         where info["YYH"].Equals(No)
                                         select info;
            if (lists.Count() > 0)
            {
                DataRow inf = lists.First();

                switch (type)
                {
                    case QFtype.FL:
                        return inf["FL"].ToString();
                        break;
                    case QFtype.JSJC:
                        return inf["TBJSJC"].ToString();
                        break;
                    default:
                        return inf["TBJSJC"].ToString();
                        break;
                }

            }

            else
            {
                return "";
            }

        }
        /// <summary>
        /// 子目下的材机赋值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="info"></param>
        private List<人材机含量> SetZMCJ(List<人材机含量> list, DataRow info, _UnitProject p_un)
        {
            //_SubheadingsInfo info1 = info as _SubheadingsInfo;
            //_MSubheadingsInfo info2 = info as _MSubheadingsInfo;
            // IEnumerable<_ObjectQuantityUnitInfo> infos;
            DataRow[] rows = p_un.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1} and ZCLB='W'", info["ID"], info["SSLB"]), "", DataViewRowState.CurrentRows);
            if (rows.Length > 0) { list = new List<人材机含量>(); } else { return null; }
            foreach (DataRow item in rows)
            {
                人材机含量 r = new 人材机含量();
                r.材料号 = item["BH"].ToString();
                r.原始含量 = item["YSXHL"].ToString();
                r.含量 = item["XHL"].ToString();
                list.Add(r);
            }
            return list;
        }

        /// <summary>
        /// 单位工程造价汇总表
        /// </summary>
        private void SetHuiZongZBS(单位工程造价汇总表 hz, _MetaanalysisSource dw)
        {
            SetTemplate(dw);
            单位工程造价汇总表 hzb = CFiles.XmlDeserialize(typeof(单位工程造价汇总表), this.m_HTemplatePath) as 单位工程造价汇总表;
            hz.单位工程费用项 = hzb.单位工程费用项;
            foreach (单位工程费用项 item in hz.单位工程费用项)
            {
                item.费率 =ToolKit.TrimZero(getValueByHuizong(QFtype.FL, item.费用名称, dw));
                if (!this.IsZBS)
                {
                    item.金额 = getValueByHuizong(QFtype.JE, item.费用名称, dw);
                }
            }
        }

        /// <summary>
        /// 获取费率及金额
        /// </summary>
        private string getValueByHuizong(QFtype Type, string Name, _MetaanalysisSource m)
        {


            string Str = "0";
            DataRow[] rows = m.Select(string.Format(" Name like '%{0}%' ", Name));
            if (rows.Length > 0)
            {


                switch (Type)
                {
                    case QFtype.FL:
                        Str = rows[0]["Coefficient"].ToString();
                        break;
                    case QFtype.JE:
                        Str = ToolKit.ParseDecimal(rows[0]["Price"]).ToString(Dian);
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(Str))
            {
                return Str;
            }
            else
            {
                return "0";
            }

        }
        /// <summary>
        /// 获取接口变量
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        private string GetFormula(string Str, string BW)
        {
            string str = Str;
            DataSet ds = _Common.Application.Global.DataTamp.变量对应表;
            if (ds.Tables.Count > 0)
            {

                DataTable dt = ds.Tables["系统变量对应表"];
                DataRow[] rows = dt.Select(" 系统变量='" + Str + "' and 说明='" + BW + "' and 是否本系统='True' ");
                if (rows.Length > 0)
                {
                    str = rows[0]["接口变量"].ToString();
                }

            }
            return str;
        }

        /// <summary>
        /// 确定汇总和规费模板
        /// </summary>
        private void SetTemplate(_MetaanalysisSource m)
        {
            DataRow[] rows = m.Select(string.Format(" Feature = '{0}'", "CSXMF"));
            if (rows.Length > 0)
            {
                DataRow[] rows1 = m.Select(string.Format(" Name = '{0}'", "其中：安全文明施工措施费"));
                DataRow[] rows2 = m.Select(string.Format(" Name = '{0}'", "安全文明施工措施项目费"));
                DataRow[] rows5 = m.Select(string.Format(" Feature = '{0}'", "ZZJ"));
                string jsjc = "";
                if (rows5.Length > 0)
                {
                    jsjc = rows5[0]["Calculation"].ToString();
                }

                if (rows1.Length < 1 && rows2.Length < 1 && jsjc.Split('-').Length == 3)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "001.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "001.xml";
                }
                else if (rows1.Length < 1 && rows2.Length < 1 && jsjc.Split('-').Length == 2)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "002.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "001.xml";

                }

                else if (rows1.Length < 1 && rows2.Length < 1 && jsjc.Split('+').Length == 2)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "003.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "003.xml";

                }

                else if (rows1.Length < 1 && rows2.Length > 0 && jsjc.Split('+').Length == 2)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "004.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "004.xml";

                }
                else if (rows1.Length < 1 && rows2.Length > 0 && jsjc.Split('-').Length == 2)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "005.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "005.xml";

                }

                else if (rows1.Length < 1 && rows2.Length > 0 && jsjc.Split('-').Length == 3)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "006.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "005.xml";

                }
                else if (rows1.Length > 0 && rows2.Length < 1 && jsjc.Split('-').Length == 2)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "007.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "007.xml";

                }
                else if (rows1.Length > 0 && rows2.Length < 1 && jsjc.Split('+').Length == 2)
                {
                    this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "008.xml";
                    this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "008.xml";

                }


                DataRow[] rows4 = m.Select(string.Format(" Name like '%{0}%'", "分部分项工程费"));
                DataRow[] rows6 = m.Select(string.Format(" Name like '%{0}%'", "分部分项人工费调增差价合计"));

                if (rows4.Length > 0 && rows6.Length>0)
                {
                    DataRow[] rows3 = m.Select(string.Format(" ParentID = {0} ", rows4[0]["ID"]));

                    if (rows1.Length > 0 && rows2.Length < 1 && rows3.Length > 0 && jsjc.Split('-').Length == 2)
                    {
                        this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "009.xml";
                        this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "009.xml";

                    }
                    else if (rows1.Length > 0 && rows2.Length < 1 && rows3.Length > 0 && jsjc.Split('+').Length == 2)
                    {
                        this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "010.xml";
                        this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "010.xml";

                    }
                    else
                    {
                        this.m_HTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\单位工程造价汇总表\\" + "010.xml";
                        this.m_GTemplatePath = _Common.Application.Global.AppFolder + "XML模板\\规费税金清单表\\" + "010.xml";
                    }
                }

            }
        }
    }
    public enum QFtype
    {
        FL,
        JE,
        JSJC

    }
}
