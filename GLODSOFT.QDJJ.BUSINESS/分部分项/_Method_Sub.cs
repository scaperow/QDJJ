using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using ZiboSoft.Commons.Common;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Method_Sub:_Methods
    {
        
        //public _Method_Sub(_UnitProject p_Unit):base(p_Unit)
        //{
          
        //}
        public _Method_Sub(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo m_Current)
            : base(m_Currentbus, p_Unit, m_Current)
        {

        }

        /// <summary>
        /// 为分部分项创建清单对象
        /// </summary>
        /// <returns>清单对象</returns>
        public override _Entity_SubInfo Create(int p_Sort, _Entity_SubInfo info)
        {
            int id = ToolKit.ParseInt(this.Unit.StructSource.ModelSubSegments.Rows[0]["ID"]);
            _Entity_SubInfo pro = this.GetproByFixed(info);
            _Entity_SubInfo cinfo = this.GetproByFixed(info, pro);
            _Entity_SubInfo finfo = this.GetproByFixed_J(info, cinfo);
            //info.ID = this.Parent.Parent.Parent.ObjectID;
            info.FPARENTID = id;
            info.PPARENTID = pro.ID;
            info.CPARENTID = cinfo.ID;
            info.PID = finfo.ID;
            info.SSLB = 0;
            info.EnID = this.Current.EnID;
            info.UnID = this.Current.UnID;
            info.Deep = 6;//清单对象深度为5
            this.SetSort(p_Sort, info);
            info.Key = ++this.CurrentBusiness.Current.ObjectKey;
            info.PKey = this.Current.Key;
            info.HL = 0;
            this.Unit.StructSource.ModelSubSegments.Add(info);
            return info;
       
        }
        /// <summary>
        /// 根据清单获取专业
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public _Entity_SubInfo GetproByFixed(_Entity_SubInfo info)
        {
            DataRow pro = null;
            if (info.ZJWZ == "")
            {
                info.ZJWZ = "999999";
            }
            string zjwj = info.ZJWZ.Substring(0, 2);
            pro = this.Unit.StructSource.ModelSubSegments.Select(string.Format("XMBM='{0}'", zjwj)).FirstOrDefault();
            if (pro != null)
            {
                _Entity_SubInfo sinfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(sinfo, pro);
                return sinfo;
            }
            else
            {
                _Entity_SubInfo pinfo = new _Entity_SubInfo();
                DataRow row = GetQDSY(info.LibraryName, zjwj);
                if (row != null)
                {
                    pinfo.XMBM = row["QINGDSYBH"].ToString();
                    pinfo.XMMC = row["MULNR"].ToString();
                    pinfo.LB = "分部-专业";
                    pinfo.GCL = 0.0m;
                    // pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                else
                {
                    pinfo.XMBM = "99";
                    pinfo.XMMC = "补充专业";
                    pinfo.LB = "分部-专业";
                    pinfo.GCL = 0.0m;
                    // pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                
                //pinfo.ID = this.ObjectID;
                int id = ToolKit.ParseInt(this.Unit.StructSource.ModelSubSegments.Rows[0]["ID"]);
                pinfo.PID = id;
                pinfo.PPARENTID = id;
                pinfo.CPARENTID = id;
                pinfo.EnID = this.Current.EnID;
                pinfo.UnID = this.Current.UnID;
                pinfo.Deep = 3;//专业深度为2
                this.Unit.StructSource.ModelSubSegments.Add(pinfo);
                return pinfo;
            }
        }
        /// <summary>
        /// 获取章
        /// </summary>
        /// <param name="info"></param>
        /// <param name="p_pro"></param>
        /// <returns></returns>
        public _Entity_SubInfo GetproByFixed(_Entity_SubInfo info, _Entity_SubInfo p_pro)
        {
            DataRow pro = null;
            string zjwj = info.ZJWZ.Substring(0, 4);
            pro = this.Unit.StructSource.ModelSubSegments.Select(string.Format("XMBM='{0}'", zjwj)).FirstOrDefault();
            if (pro != null)
            {
                _Entity_SubInfo sinfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(sinfo, pro);
                return sinfo;
            }
            else
            {
                _Entity_SubInfo pinfo = new _Entity_SubInfo();
                DataRow row = GetQDSY(info.LibraryName, zjwj);
                if (row != null)
                {
                    pinfo.XMBM = row["QINGDSYBH"].ToString();
                    pinfo.XMMC = row["MULNR"].ToString();
                    pinfo.LB = "分部-章";
                    pinfo.GCL = 0.0m;
                }
                else
                {
                    pinfo.XMBM = "9999";
                    pinfo.XMMC = "补充章";
                    pinfo.LB = "分部-章";
                    pinfo.GCL = 0.0m;
                }
                pinfo.PID = p_pro.ID;
                pinfo.CPARENTID = p_pro.ID;
                pinfo.EnID = this.Current.EnID;
                pinfo.UnID = this.Current.UnID;
                pinfo.Deep = 4;
                this.Unit.StructSource.ModelSubSegments.Add(pinfo);
                return pinfo;
            }
        }
        /// <summary>
        /// 获取节
        /// </summary>
        /// <param name="info"></param>
        /// <param name="p_pro"></param>
        /// <returns></returns>
        public _Entity_SubInfo GetproByFixed_J(_Entity_SubInfo info, _Entity_SubInfo p_pro)
        {
            DataRow pro = null;
            string zjwj = info.ZJWZ.Substring(0, 6);
            pro = this.Unit.StructSource.ModelSubSegments.Select(string.Format("XMBM='{0}'", zjwj)).FirstOrDefault();
            if (pro != null)
            {
                _Entity_SubInfo sinfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(sinfo, pro);
                return sinfo;
            }
            else
            {
                _Entity_SubInfo pinfo = new _Entity_SubInfo();
                DataRow row = GetQDSY(info.LibraryName, zjwj);
                if (row != null)
                {
                    pinfo.XMBM = row["QINGDSYBH"].ToString();
                    pinfo.XMMC = row["MULNR"].ToString();
                    pinfo.LB = "分部-节";
                    pinfo.GCL = 0.0m;
                    //pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                else
                {
                    pinfo.XMBM = "999999";
                    pinfo.XMMC = "补充节";
                    pinfo.LB = "分部-节";
                    pinfo.GCL = 0.0m;
                    //pinfo.Sort = this.Parent.GetSortByType(pinfo.GetType()) + 1;
                }
                //p_pro.Create(pinfo);
               
                pinfo.CPARENTID = p_pro.ID;
                pinfo.EnID = this.Current.EnID;
                pinfo.UnID = this.Current.UnID;
                pinfo.Deep = 5;
                pinfo.PID = p_pro.ID;
                this.Unit.StructSource.ModelSubSegments.Add(pinfo);
               
                return pinfo;
            }
        }

        /// <summary>
        /// 找清单索引
        /// </summary>
        /// <param name="LibraryName"></param>
        /// <param name="QDSY"></param>
        /// <returns></returns>
        private DataRow GetQDSY(string LibraryName, string QDSY)
        {
            //_Library.GetLibrary(LibraryName);
            //DataSet ds = this.Unit.Property.
            DataTable dt =this.Unit.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单索引表"];
            DataRow[] rows = dt.Select(string.Format("QINGDSYBH='{0}'", QDSY));
            if (rows.Length > 0)
            {
                return rows[0];
            }
            else
            {
                return null;
            }

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


            this.Unit.IsCalculated = true;
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
            GLODSOFT.QDJJ.BUSINESS._Project_Statistics stat = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(this.Unit,this.CurrentBusiness);
            stat.Begin();//单位工程计算
        }

        public override void BeginCurrent()
        {
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
            GLODSOFT.QDJJ.BUSINESS._Project_Statistics stat = new GLODSOFT.QDJJ.BUSINESS._Project_Statistics(this.Unit,this.CurrentBusiness);
            stat.Begin();//单位工程计算
        }

        public override void Calculate()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID),"",DataViewRowState.CurrentRows);
            
            foreach (DataRow item in rows)
            {_Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Methods_Pro met = new _Methods_Pro(this.CurrentBusiness,this.Unit,info);
                met.Calculate();
            }

            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
        }
        public static _Method_Sub GetSub(_Business bus, _UnitProject p_Unit)
        {
           _Entity_SubInfo Sub_info = new _Entity_SubInfo();
           DataRow row= p_Unit.StructSource.ModelSubSegments.GetRowByOther("1");
           _ObjectSource.GetObject(Sub_info, row);
           _Method_Sub mrt = new _Method_Sub(bus,p_Unit, Sub_info);
            return mrt;
        }
    }
}
