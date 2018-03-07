using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Data;
using GOLDSOFT.QDJJ.BUSINESS;

namespace GLODSOFT.QDJJ.BUSINESS
{

    public class _Methods_Fixed : _Methods
    {
        /*public _Methods_Fixed(_UnitProject p_Unit):base(p_Unit)
        {
            
        }*/
        public delegate void ZiMuAdd(_Entity_SubInfo info);
        /// <summary>
        /// 子目添加完成事件
        /// </summary>
        /// 
        //[field: NonSerializedAttribute()]
        public event ZiMuAdd OnZiMuAdded;
        public _Methods_Fixed(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
            : base(m_Currentbus, p_Unit, p_info)
        {

        }
        /// <summary>
        /// Copy当前清单到指定清单之下
        /// </summary>
        /// <param name="QD_info"></param>
        public override void CopyTo(_Entity_SubInfo QD_info)
        {
            DataRow[] rows = this.Unit.StructSource.ModelSubSegments.Select(string.Format("PID={0} and SSLB={1}", this.Current.ID, this.Current.SSLB));
            this.Current.Key = ++this.CurrentBusiness.Current.ObjectKey;
            if (QD_info==null)
                this.SetSort(-1, this.Current);
            else
            this.SetSort(QD_info.Sort, this.Current);

            int intCount = GLODSOFT.QDJJ.BUSINESS._Methods.GetCountByBH(this.Current.OLDXMBM, this.Unit.StructSource.ModelSubSegments);
            this.Current.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetQDbeizhu(this.Current.OLDXMBM, intCount, "YJFZ");

            this.Unit.StructSource.ModelSubSegments.Add(this.Current);
            foreach (DataRow item in rows)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Methods_Subheadings m = new _Methods_Subheadings(this. CurrentBusiness, this.Unit,info);
                m.CopyTo(this.Current);

            }
          
               
        }
        /// <summary>
        /// 批量创建子目
        /// </summary>
        /// <param name="infos"></param>
        public override void Create(List<_Entity_SubInfo> infos)
        {
            foreach (_Entity_SubInfo item in infos)
            {
                var entity = this.CreateZM(-1, item, false);
            }
            this.Begin(null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Sort"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public _Entity_SubInfo CreateZM(int p_Sort, _Entity_SubInfo info, bool isGCL)
        {
            if (string.IsNullOrEmpty(this.Current.XMBM) && string.IsNullOrEmpty(this.Current.XMMC)) return info;
            info.PID = this.Current.ID;
            info.CPARENTID = this.Current.ID;
            info.FPARENTID = this.Current.ID;
            info.PPARENTID = this.Current.ID;
            info.SSLB = this.Current.SSLB;
            info.EnID = this.Current.EnID;
            info.UnID = this.Current.UnID;
            
            info.Deep = 6;//子目深度为6
            this.SetSort(p_Sort, info);
            info.Key = ++this.CurrentBusiness.Current.ObjectKey;
            info.PKey = this.Current.Key;
            if (isGCL)
            {
                info.GCL = this.Current.GCL;
                SetZMGCL(info);
            }
            //设置子目的工程量以及消耗量
            info.QDBH = this.Current.ID.ToString();//设置清单编码 用于措施到模板
            if (info.SSLB.Equals(1))
            {
                this.Unit.StructSource.ModelMeasures.Add(info);
            }
            else
            {
                this.Unit.StructSource.ModelSubSegments.Add(info);
            }
            //创建子目参数表
            this.Unit.StructSource.ModelVariable.Init_ZM(info.ID, info.SSLB);
            //添加工料机
            _Methods_Subheadings mSub = new _Methods_Subheadings(this.CurrentBusiness, this.Unit, info);
            mSub.Create();
            if (OnZiMuAdded != null)
            {
                OnZiMuAdded(info);
            }
            mSub.BeginCurrent();//只计算当前
            return info;
        }
        /// <summary>
        /// 工程信息使用【不用给工程量赋值】
        /// </summary>
        /// <param name="p_Sort"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public _Entity_SubInfo CreateZM(int p_Sort, _Entity_SubInfo info)
        {
            if (string.IsNullOrEmpty(this.Current.XMBM) && string.IsNullOrEmpty(this.Current.XMMC)) return info;
            info.PID = this.Current.ID;
            info.CPARENTID = this.Current.ID;
            info.FPARENTID = this.Current.ID;
            info.PPARENTID = this.Current.ID;
            info.SSLB = this.Current.SSLB;
            info.EnID = this.Current.EnID;
            info.UnID = this.Current.UnID;
            //info.GCL = this.Current.GCL;
            info.Deep = 6;//子目深度为6
            this.SetSort(p_Sort, info);
            info.Key = ++this.CurrentBusiness.Current.ObjectKey;
            info.PKey = this.Current.Key;
            //if (isGCL)
            //    SetZMGCL(info);//设置子目的工程量以及消耗量
            info.QDBH = this.Current.ID.ToString();//设置清单编码 用于措施到模板
            if (info.SSLB.Equals(1))
            {
                this.Unit.StructSource.ModelMeasures.Add(info);
            }
            else
            {
                this.Unit.StructSource.ModelSubSegments.Add(info);
            }
            //创建子目参数表
            this.Unit.StructSource.ModelVariable.Init_ZM(info.ID, info.SSLB);
            //添加工料机
            _Methods_Subheadings mSub = new _Methods_Subheadings(this.CurrentBusiness, this.Unit, info);
            mSub.Create();
            if (OnZiMuAdded != null)
            {
                OnZiMuAdded(info);
            }
            mSub.BeginCurrent();//只计算当前
            return info;
        }
        /// <summary>
        /// 设置子目的工程量以及消耗量（创建子目时调用）
        /// </summary>
        /// <param name="info"></param>
        public void SetZMGCL(_Entity_SubInfo info)
        {
            int m = ToolKit.ParseInt(APP.Application.Global.Configuration.Configs["工程量输入方式"]);
            if (m > 0)
            {
                // decimal c = _Methods.GetNumber(info.DW);
                //if (c != 0)
                //{
                decimal d = _ConvertUnit.Convert(this.Current.DW, info.DW);
                info.GCL = d * info.GCL;
                // }
            }
            if (this.Current.GCL != 0)
                info.HL = info.GCL / this.Current.GCL;
        }
        /// <summary>
        /// 在当前清单没有子目自动创建子目
        /// </summary>
        private void CreateSubByCurrent()
        {
            DataRow[] rs = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID));
            if (rs.Length > 0) return;
            _Entity_SubInfo info = new _Entity_SubInfo();
            info.XMBM = "补" + this.Current.OLDXMBM.Replace("补", "");
            info.OLDXMBM = this.Current.OLDXMBM.Replace("补", "");
            info.XMMC = "补充定额";
            info.GCL = this.Current.GCL;
            info.SC = true;
            info.LB = "子目";
            info.DW = this.Current.DW;
            info.TX = this.Unit.ProType.Replace("【", "").Replace("】", "").Substring(0, 2);
            info.LibraryName = this.Unit.Property.Libraries.FixedLibrary.FullName;
            this.Create(false,-1, info);
            _Methods_Subheadings m = new _Methods_Subheadings(this.CurrentBusiness, this.Unit, info);
            _Methods_ParamsSeting m_Methods_ParamsSeting = new _Methods_ParamsSeting(this.Unit);
            DataRow dr_UnitFee = m_Methods_ParamsSeting.GetUnitFeeInfo(info.OLDXMBM);

            decimal gLF = ToolKit.ParseDecimal(dr_UnitFee["GLFFL"])*0.01m;
            decimal LR = ToolKit.ParseDecimal(dr_UnitFee["LRFL"])*0.01m;
           

            decimal xhl = this.Current.ZJTJ / (1 + gLF + LR + gLF * LR);
            DataRow r = this.Unit.StructSource.ModelQuantity.NewRow();
            r["YSBH"] = APP.RepairQuantityUnit.GetRepairBH(this.Unit, "材料"); 
            r["YSMC"] = info.XMMC;
            r["YSDW"] = info.DW;
            r["YSXHL"] = xhl;
            r["DEDJ"] = 1;
            r["BH"] = r["YSBH"];
            r["MC"] = info.XMMC;
            r["DW"] = info.DW;
            r["XHL"] = xhl;
            r["SCDJ"] = 1;
            r["LB"] = "材料";
            r["ZCLB"] = "W";
            r["SDCLB"] = string.Empty;
            r["SDCXS"] = 0;
            r["IFSC"] = true;
            r["IFFX"] = false;
            r["IFSDSCDJ"] = false;
            r["IFZYCL"] = true;
            r["YTLB"] = string.Empty;
            m.CreateGLJ(r);

        }
        public override _Entity_SubInfo Create(int p_Sort, _Entity_SubInfo info)
        {
            this.CreateZM(p_Sort, info, true);
            this.Begin(null);

            return info;
        }
        public _Entity_SubInfo Create(bool IsGCL, int p_Sort, _Entity_SubInfo info)
        {
            this.CreateZM(p_Sort, info, IsGCL);
            this.Begin(null);

            return info;
        }
        /// <summary>
        /// 工程信息使用【不用给工程量赋值】
        /// </summary>
        /// <param name="p_Sort"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public _Entity_SubInfo CreateByGCXX(int p_Sort, _Entity_SubInfo info)
        {
            this.CreateZM(p_Sort, info);//工程信息使用【不用给工程量赋值】
            this.Begin(null);
            return info;
        }
        /// <summary>
        /// 此处创建不处理工程量
        /// </summary>
        /// <param name="p_Sort"></param>
        /// <param name="info"></param>
        /// <param name="IsGCL"></param>
        /// <returns></returns>
        public _Entity_SubInfo Create(int p_Sort, _Entity_SubInfo info, bool IsGCL)
        {
            this.CreateZM(p_Sort, info, IsGCL);
            this.Begin(null);
            return info;
        }
        /// <summary>
        /// 删除子目包括当前清单
        /// </summary>
        public override void RemoveAllChild()
        {
            DataRow[] gljRows = null;
            DataRow[] scRows = null;
            DataRow[] zmqfRows = null;
            DataRow[] cszmqfRows = null;
            DataRow[] azzjfRows = null;

            _SubSegmentsSource source = this.Unit.StructSource.ModelSubSegments;

            DataRow[] rows = source.Select(string.Format("PID = {0}", this.Current.ID));
            foreach (DataRow row in rows)
            {
                gljRows = this.Unit.StructSource.ModelQuantity.Select("ZMID = " + row["id"].ToString());
                scRows = this.Unit.StructSource.ModelStandardConversion.Select("ZMID = " + row["id"].ToString());
                zmqfRows = this.Unit.StructSource.ModelSubheadingsFee.Select("ZMID = " + row["id"].ToString());
                cszmqfRows = this.Unit.StructSource.ModelPSubheadingsFee.Select("ZMID = " + row["id"].ToString());
                azzjfRows = this.Unit.StructSource.ModelIncreaseCosts.Select("ZMID = " + row["id"].ToString());
                foreach (DataRow glj in gljRows)
                {
                    glj.Delete();
                }
                foreach (DataRow sc in scRows)
                {
                    sc.Delete();
                }
                foreach (DataRow zmqf in zmqfRows)
                {
                    zmqf.Delete();
                }
                foreach (DataRow cszmqf in cszmqfRows)
                {
                    cszmqf.Delete();
                }
                foreach (DataRow azzjf in azzjfRows)
                {
                    azzjf.Delete();
                }

                row.Delete();
            }           


            DataRow r = source.GetRowByOther(this.Current.ID.ToString());
            if (r != null)
                this.RemoveParent(r);
            //DataRow[] rows = source.Select(string.Format("UnId = {0} and SSLB ={1} and PID = {2}", this.Current.UnID, this.Current.SSLB, this.Current.PID), string.Empty, DataViewRowState.CurrentRows);
            //if (rows.Length < 2)
            //{
            //    DataRow row = source.GetRowByOther(this.Current.PID.ToString());
            //    if(row!=null)
            //    this.RemoveParent(row);

            //}
            //else
            //{
            //   DataRow r= source.GetRowByOther(this.Current.ID.ToString());
            //   if (r != null) r.Delete();
            //}


        }

        private void RemoveParent(DataRow row)
        {
            _SubSegmentsSource source = this.Unit.StructSource.ModelSubSegments;
            DataRow[] rows = source.Select(string.Format(" PID = {0}", row["PID"]), string.Empty, DataViewRowState.CurrentRows);
            if (rows.Length < 2)
            {
                DataRow row1 = source.GetRowByOther(row["PID"].ToString());
                if (row1 != null)
                {
                    if (row1["PID"].Equals(0))
                    {
                        row.Delete();
                        _Entity_SubInfo info = new _Entity_SubInfo();
                        _ObjectSource.GetObject(info, row1);
                        GLODSOFT.QDJJ.BUSINESS._Methods mets = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.CurrentBusiness, this.Unit, info);
                        mets.Begin(null);
                    }
                    else
                    {
                        this.RemoveParent(row1);
                    }
                }
            }
            else
            {
                DataRow r = source.GetRowByOther(row["ID"].ToString());
                if (r != null)
                {
                    if (!r["PID"].Equals(0))
                    {
                        string id = r["PID"].ToString();
                        r.Delete();
                        DataRow r1 = source.GetRowByOther(id);
                        _Entity_SubInfo info = new _Entity_SubInfo();
                        _ObjectSource.GetObject(info, r1);
                        GLODSOFT.QDJJ.BUSINESS._Methods mets = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.CurrentBusiness, this.Unit, info);
                        mets.Begin(null);

                    }
                }
            }
        }
        public override void RemoveChild(_Entity_SubInfo info)
        {

        }

        public override void Begin(List<int> session)
        {
            if (session != null)
            {
                if (session.Contains(Current.ID))
                {
                    return;
                }
                else
                {
                    session.Add(Current.ID);
                }
            }


            _Entity_SubInfo info = null;
            DataRow row = null;
            _Methods met = null;

            _FixedList_Statistics sta = new _FixedList_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin(GetDataSource.Select("PID = " + Current.ID));


            //计算子目所属节
            info = new _Entity_SubInfo();
            row = this.Unit.StructSource.ModelSubSegments.GetRowByOther(this.Current.PID.ToString());
            _ObjectSource.GetObject(info, row);
            met = new _Method_Fest(this.CurrentBusiness, this.Unit, info);
            met.Begin(session);
        }

        public override void Calculate()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);

            foreach (DataRow item in rows)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Methods_Subheadings met = new _Methods_Subheadings(this.CurrentBusiness, this.Unit, info);
                met.Calculate();
            }
            _FixedList_Statistics sta = new _FixedList_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin(GetDataSource.Select("PID = '" + Current.ID + "'"));
        }

        public override void BeginCurrent()
        {
            _FixedList_Statistics sta = new _FixedList_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin(GetDataSource.Select("PID = " + Current.ID));
        }

        /// <summary>
        /// 修改工程量
        /// </summary>
        public override void UpGCL()
        {
            bool flag = ToolKit.ParseBoolen(APP.Application.Global.Configuration.Configs["清单工程量设置"]);
            if (flag)
            {
                DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0} and SSLB={1} and TX <> '子目-增加费'", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
                _Methods_Subheadings met = new _Methods_Subheadings(this.CurrentBusiness, this.Unit, null);
                foreach (DataRow row in rows)
                {
                    row["GCL"] = (ToolKit.ParseDecimal(row["HL"]) * this.Current.GCL).ToString("F4");
                    _Entity_SubInfo info = new _Entity_SubInfo();
                    _ObjectSource.GetObject(info, row);
                    met.Current = info;
                    met.UpZMGLJGCL();
                    met.BeginCurrent();//计算子目当前数据
                    if (!string.IsNullOrEmpty(info.QDBH))
                    {
                        DataRow[] rows1 = this.Unit.StructSource.ModelMeasures.Select(string.Format("QDBH={0} and XMBM='{1}'", info.QDBH, info.XMBM));
                        _Mothods_MSubheadings mett = new _Mothods_MSubheadings(this.CurrentBusiness, this.Unit, null);
                        foreach (DataRow item in rows1)
                        {
                            _Entity_SubInfo sinfo = new _Entity_SubInfo();
                            _ObjectSource.GetObject(sinfo, item);
                            sinfo.GCL = info.GCL * _Methods.GetNumber(sinfo.DW);
                            mett.Current = sinfo;
                            mett.UpGCL();
                        }
                    }
                }
            }
            this.Begin(null);
        }
        /// <summary>
        /// 修改直接调价
        /// </summary>
        public override void UpZJTJ()
        {
            decimal zhdj = this.Current.ZHDJ;
            if (!this.Current.SDDJ)//没有锁定单价则调整
            {
                if (zhdj == 0) zhdj = 1;
                decimal c = this.Current.ZJTJ / zhdj;
                DataRow[] rows = this.Unit.StructSource.ModelQuantity.Select(string.Format("QDID={0} and SSLB={1} and ZCLB='W' and IFSDSL=False", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
                if (rows.Length < 1)
                {
                    this.CreateSubByCurrent();
                    // rows = this.Unit.StructSource.ModelQuantity.Select(string.Format("QDID={0} and SSLB={1} and ZCLB='W' and IFSDSL=False", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
                }
                else
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        if (!rows[i]["LB"].ToString().Contains('%'))
                            rows[i]["XHL"] = ToolKit.ParseDecimal(rows[i]["XHL"]) * c;
                        _Methods_Quantity.RowCalculateAndParentSCDJ(rows[i]);

                    }
                }
                this.AllSubhendingCalcCurrent();
                this.Begin(null);

            }
            DataRow r = (this.GetDataSource as _SubSegmentsSource).GetRowByOther(this.Current.ID.ToString());
            if (r != null) r["ZJTJ"] = 0;
        }
        public void AllSubhendingCalcCurrent()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0} and SSLB={1}", this.Current.ID, this.Current.SSLB), "", DataViewRowState.CurrentRows);
            _Methods_Subheadings met = new _Methods_Subheadings(this.CurrentBusiness, this.Unit, null);
            foreach (DataRow row in rows)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, row);
                met.Current = info;
                met.BeginCurrent();//计算子目当前数据
            }
        }

        /// <summary>
        /// 复制组价到其他清单
        /// </summary>
        public void CopySubhendingToFix(int IsTh, int type, _Entity_SubInfo p_Toinfo)
        {
            this.SubhendingToFix(IsTh, type, this.Current, p_Toinfo, "FZZJ");
        }
        /// <summary>
        /// 提取其他清单组价
        /// </summary>
        public void FromSubhendingToFix(int IsTh, int type, _Entity_SubInfo p_frominfo)
        {
            this.SubhendingToFix(IsTh, type, p_frominfo, this.Current, "TQZJ");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsTh">0替换1增加</param>
        /// <param name="type">0复用含量1复用工程量</param>
        /// <param name="p_frominfo"></param>
        /// <param name="p_Toinfo"></param>
        private void SubhendingToFix(int IsTh, int type, _Entity_SubInfo p_frominfo, _Entity_SubInfo p_Toinfo)
        {
            DataRow[] zrs = this.Unit.StructSource.ModelSubSegments.Select(string.Format(" PID={0}", p_frominfo.ID));
            if (IsTh == 0) this.DeleteRows(p_Toinfo);
            for (int i = 0; i < zrs.Length; i++)
            //foreach (DataRow row in zrs)
            {
                DataRow row = zrs[i];

                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, row);
                _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Unit, p_Toinfo);
                SetGCLandHL(p_Toinfo, info, type);
                fix.Create(-1, info, false);
            }
        }
        /// <summary>
        /// 李波2013.02.27重载【作用各种备注】
        /// </summary>
        /// <param name="IsTh">0替换1增加</param>
        /// <param name="type">0复用含量1复用工程量</param>
        /// <param name="p_frominfo"></param>
        /// <param name="p_Toinfo"></param>
        private void SubhendingToFix(int IsTh, int type, _Entity_SubInfo p_frominfo, _Entity_SubInfo p_Toinfo,string strCZBM)
        {
            DataRow[] zrs = this.Unit.StructSource.ModelSubSegments.Select(string.Format(" PID={0}", p_frominfo.ID));
            if (IsTh == 0) this.DeleteRows(p_Toinfo);
            for (int i = 0; i < zrs.Length; i++)
            //foreach (DataRow row in zrs)
            {
                DataRow row = zrs[i];

                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, row);
                _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Unit, p_Toinfo);
                //重载添加的东东
                info.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Method_Sub.GetDEbeizhu(strCZBM, i + 1, p_Toinfo.OLDXMBM);
                SetGCLandHL(p_Toinfo, info, type);
                fix.Create(-1, info, false);
            }
        }
        /// <summary>
        /// 设置工程量或者含量
        /// </summary>
        /// <param name="p_Toinfo">目标清单</param>
        /// <param name="p_info">，要处理的子目</param>
        /// <param name="type">，复用的是含量还是工程量</param>
        private void SetGCLandHL(_Entity_SubInfo p_Toinfo, _Entity_SubInfo p_info, int type)
        {
            if (type == 0)//复用含量
            {
                p_info.GCL = p_Toinfo.GCL * p_info.HL;
            }
            else
            {
                if (p_Toinfo.GCL != 0)
                    p_info.HL = p_info.GCL / p_Toinfo.GCL;
                else
                    p_info.HL = 0;
            }
        }
        private void DeleteRows(_Entity_SubInfo p_Toinfo)
        {
            DataRow[] zrs = this.Unit.StructSource.ModelSubSegments.Select(string.Format(" PID={0}", p_Toinfo.ID));
            for (int i = 0; i < zrs.Length; i++)
            {
                zrs[i].Delete();
            }
        }
    }
}
