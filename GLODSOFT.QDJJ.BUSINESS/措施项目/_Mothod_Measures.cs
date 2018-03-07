/*
 措施项目方法
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using ZiboSoft.Commons.Common;
using System.Reflection;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Mothod_Measures : _Methods
    {


        public _Mothod_Measures(_Business m_Currentbus, _UnitProject p_Unit, _Entity_SubInfo p_info)
            : base(m_Currentbus, p_Unit, p_info)
        {

        }

        public override void BeginCurrent()
        {
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
            _Project_Statistics stat = new _Project_Statistics(this.Unit,this.CurrentBusiness);
            stat.Begin();//单位工程计算
        }

        /// <summary>
        /// 初始化时默认套用某模板
        /// </summary>
        public void Load()
        {
            //if (this.IsInit)
            {
                string str = this.Unit.ProType;
                string fileName = string.Format("{0}{1}.{2}", APP.Cache.AppFolder + "模板文件\\措施项目模板\\", Tname(str), "CMBX");

                //DataRow r = this.Unit.StructSource.ModelMeasures.Rows[0];
                //if (r != null)
                //{
                //    _Entity_SubInfo info = new _Entity_SubInfo();
                //    _ObjectSource.GetObject(info,r);
                //    this.Current
                //}
                this.Load(fileName);
                //DataTable dt = APP.Application.Global.DataTamp.MeasuresList.Tables[Tname(str)];
                // LoadTable(dt);
                //this.m_IsInit = false;
            }

        }

        public void CalculateWithoutHeader()
        {
            var table = this.GetDataSource.GetChanges();
            using (var calculator = new Calculator(this.CurrentBusiness, this.Unit))
            {
                calculator.Rows.AddRange(table.Select());
            }
        }

        public void CalculateHeader()
        {
            var rows = this.GetDataSource.Select("  XMBM = 'C10101' OR XMBM = 'C10102' OR XMBM = 'C10103' OR XMBM = 'C10104' "," XMBM DESC ");
            using (var calculator = new Calculator(this.CurrentBusiness, this.Unit))
            {
                calculator.Rows.AddRange(rows);
            }
  
        }

        private void LoadTable(DataTable dt)
        {
            if (dt == null)
            {
                return;
            }

            _Methods met = null;

            DataRow[] crows = dt.Select("ParentID=1");//父级编号为1的为通用项目
            int xh = 1;
            for (int i = 0; i < crows.Length; i++)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                info.JSJC = "";
                //info.FL = "";
                info.GCL = 0m;
                info.XMMC = crows[i]["Name"].ToString();
                info.XMBM = crows[i]["Codes"].ToString();
                info.OLDXMBM = crows[i]["Codes"].ToString();
                info.SC = true;
                info.JBHZ = true;
                //通用项目添加到集合
                this.Create(i, info);
                DataRow[] rows = dt.Select("ParentID=" + crows[i]["ID"] + "");//父级编号为为通用项目ID的项为清单
                int m = 1;
                for (int j = 0; j < rows.Length; j++)
                {
                    _Entity_SubInfo minfo = new _Entity_SubInfo();

                    minfo.XMMC = rows[j]["Name"].ToString();
                    minfo.LB = rows[j]["Type"].ToString();
                    minfo.GCL = 1m;
                    minfo.JSJC = rows[j]["Calculation"].ToString();
                    minfo.FL = ToolKit.ParseDecimal(rows[j]["Rate"]);
                    minfo.DW = rows[j]["Unit"].ToString();
                    minfo.XMBM = rows[j]["Codes"].ToString();
                    minfo.OLDXMBM = rows[j]["Codes"].ToString();
                    minfo.SC = true;
                    minfo.JBHZ = true;
                    minfo.XH = xh++;
                    minfo.ZJFS = "子目组价";
                    if (rows[j]["Remark"].ToString().Contains("通用项目"))
                    {
                        //minfo.XH2 = int.Parse(rows[j]["Remark"].ToString().Replace("通用项目", ""));
                    }
                    if (i == 0 && m < 5)
                    {
                        minfo.ISTY = true;
                    }
                    m++;
                    //info.Create(minfo);
                    met = new _Motheds_CommonProj(this.CurrentBusiness, this.Unit, info);
                    met.Create(j, minfo);

                    DataRow[] srows = dt.Select("ParentID=" + rows[j]["ID"] + "");//父级编号为为清单ID的项为子目
                    for (int k = 0; k < srows.Length; k++)
                    {
                        _Entity_SubInfo sinfo = new _Entity_SubInfo();
                        sinfo.XMMC = srows[k]["Name"].ToString();
                        sinfo.LB = srows[k]["Type"].ToString();
                        sinfo.JSJC = srows[k]["Calculation"].ToString();
                        sinfo.FL = ToolKit.ParseDecimal(srows[k]["Rate"]);
                        sinfo.DW = srows[k]["Unit"].ToString();
                        sinfo.LibraryName = this.Unit.Property.DLibraries.FixedLibrary.FullName;
                        sinfo.GCL = 1m;
                        sinfo.XMBM = srows[k]["Codes"].ToString();
                        sinfo.OLDXMBM = srows[k]["Codes"].ToString();
                        sinfo.SC = true;
                        sinfo.JBHZ = true;
                        if (!string.IsNullOrEmpty(sinfo.JSJC))
                        {
                            sinfo.ZJFS = "公式组价";
                        }
                        //minfo.Create(sinfo);
                        met = new _Mothods_MFixed(this.CurrentBusiness, this.Unit, minfo);
                        met.Create(k, sinfo);
                    }
                }

            }
        }


        private _Entity_SubInfo GetInfoByRow(DataRow row)
        {
            _Entity_SubInfo p_obj = new _Entity_SubInfo();
            Type tp = p_obj.GetType();
            foreach (DataColumn col in row.Table.Columns)
            {
                PropertyInfo info = tp.GetProperty(col.ColumnName);
                if (info != null)
                {
                    if (row[col.ColumnName] != System.DBNull.Value)
                        info.SetValue(p_obj, row[col.ColumnName], null);
                }
            }
            return p_obj;
        }

        private void LoadTempletTable(DataTable dt, Calculator calculator)
        {
            if (dt == null)
            {
                return;
            }
            try
            {
                _Methods met = null;
                string where = "PID=1";
                DataRow[] rs = dt.Select("PID=0");
                if (rs.Length > 0) where = string.Format("PID={0}", rs[0]["ID"]);
                DataRow[] crows = dt.Select(where);//父级编号为1的为通用项目
                int xh = 1;
                for (int i = 0; i < crows.Length; i++)
                {
                    _Entity_SubInfo info = GetInfoByRow(crows[i]);
                    //info.JSJC = "";
                    ////info.FL = "";
                    //info.GCL = 0m;
                    //info.XMMC = crows[i]["XMMC"].ToString();
                    //info.XMBM = crows[i]["XMBM"].ToString();
                    //info.OLDXMBM = crows[i]["OLDXMBM"].ToString();
                    //info.JBHZ =ToolKit.ParseBoolen (crows[i]["JBHZ"]);
                    //info.SC = ToolKit.ParseBoolen (crows[i]["SC"]);
                    //通用项目添加到集合
                    this.Create(i, info);
                    DataRow[] rows = dt.Select("PID=" + crows[i]["ID"] + "");//父级编号为为通用项目ID的项为清单
                    int m = 1;
                    for (int j = 0; j < rows.Length; j++)
                    {
                        _Entity_SubInfo minfo = GetInfoByRow(rows[j]);

                        //minfo.XMMC = rows[j]["XMMC"].ToString();
                        //minfo.LB = rows[j]["LB"].ToString();
                        //minfo.GCL = 1m;
                        //minfo.JSJC = rows[j]["JSJC"].ToString();
                        //minfo.FL = ToolKit.ParseDecimal(rows[j]["FL"]);
                        //minfo.DW = rows[j]["DW"].ToString();
                        //minfo.XMBM = rows[j]["XMBM"].ToString();
                        //minfo.OLDXMBM = rows[j]["OLDXMBM"].ToString();
                        //minfo.JBHZ = ToolKit.ParseBoolen(rows[j]["JBHZ"]);
                        //minfo.SC = ToolKit.ParseBoolen(rows[j]["SC"]);
                        minfo.XH = xh++;
                        //if (rows[j]["Remark"].ToString().Contains("通用项目"))
                        //{
                        //    //minfo.XH2 = int.Parse(rows[j]["Remark"].ToString().Replace("通用项目", ""));
                        //}
                        if (i == 0 && m < 5)
                        {
                            minfo.ISTY = true;
                        }
                        m++;
                        //info.Create(minfo);
                        met = new _Motheds_CommonProj(this.CurrentBusiness, this.Unit, info);
                        calculator.Entities.Add(met.Create(j, minfo));

                        DataRow[] srows = dt.Select("PID=" + rows[j]["ID"] + "");//父级编号为为清单ID的项为子目
                        for (int k = 0; k < srows.Length; k++)
                        {
                            _Entity_SubInfo sinfo = GetInfoByRow(srows[k]);
                            //sinfo.XMMC = srows[k]["XMMC"].ToString();
                            //sinfo.LB = srows[k]["LB"].ToString();
                            //sinfo.JSJC = srows[k]["JSJC"].ToString();
                            //minfo.FL = ToolKit.ParseDecimal(rows[k]["FL"]);
                            //sinfo.DW = srows[k]["DW"].ToString();
                            sinfo.LibraryName = this.Unit.Property.DLibraries.FixedLibrary.FullName;
                            //sinfo.GCL = 1m;
                            //sinfo.XMBM = srows[k]["XMBM"].ToString();
                            //sinfo.OLDXMBM = srows[k]["OLDXMBM"].ToString();
                            //sinfo.JBHZ = ToolKit.ParseBoolen(srows[k]["JBHZ"]);
                            //sinfo.SC = ToolKit.ParseBoolen(srows[k]["SC"]);
                            //minfo.Create(sinfo);
                            met = new _Mothods_MFixed(this.CurrentBusiness, this.Unit, minfo);
                            calculator.Entities.Add(met.Create(k, sinfo));
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override _Entity_SubInfo Create(int p_Sort, _Entity_SubInfo info)
        {
            info.PID = this.Current.ID;
            info.STATUS = false;
            info.EnID = this.Current.EnID;
            info.UnID = this.Current.UnID;
            info.SSLB = 1;
            info.Deep = this.Current.Deep + 1;
            this.SetSort(p_Sort, info);
            info.Key = ++this.CurrentBusiness.Current.ObjectKey;
            info.PKey = this.Current.Key;
            this.Unit.StructSource.ModelMeasures.Add(info);
            return info;
        }

        private string Tname(string str)
        {

            string Tname = "";
            int value = -1;
            value = str.IndexOf("安装专业");
            if (value > -1) Tname = "【安装专业】措施模板";
            value = str.IndexOf("机械土石方专业");
            if (value > -1) Tname = "【机械土石方专业】措施模板";
            value = str.IndexOf("建筑装饰专业");
            if (value > -1) Tname = "【建筑装饰专业】措施模板";
            value = str.IndexOf("人工土石方专业");
            if (value > -1) Tname = "【人工土石方专业】措施模板";
            value = str.IndexOf("市政安装专业");
            if (value > -1) Tname = "【市政安装专业】措施模板";
            value = str.IndexOf("市政建筑安装专业");
            if (value > -1) Tname = "【市政建筑安装专业】措施模板";
            value = str.IndexOf("市政建筑专业");
            if (value > -1) Tname = "【市政建筑专业】措施模板";
            value = str.IndexOf("一般土建专业");
            if (value > -1) Tname = "【一般土建专业】措施模板";
            value = str.IndexOf("园林绿化专业");
            if (value > -1) Tname = "【园林绿化专业】措施模板";
            value = str.IndexOf("桩基专业");
            if (value > -1) Tname = "【桩基专业】措施模板";
            value = str.IndexOf("装饰装修专业");
            if (value > -1) Tname = "【装饰装修专业】措施模板";
            return Tname;


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
            _Project_Statistics stat = new _Project_Statistics(this.Unit,this.CurrentBusiness);
            stat.Begin();//单位工程计算
        }

        public override void Calculate()
        {
            DataRow[] rows = this.GetDataSource.Select(string.Format("PID={0}", this.Current.ID), "", DataViewRowState.CurrentRows);

            foreach (DataRow item in rows)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, item);
                _Motheds_CommonProj met = new _Motheds_CommonProj(this.CurrentBusiness, this.Unit, info);
                met.Calculate();
            }
            _SubSegment_Statistics sta = new _SubSegment_Statistics(this.Current, this.Unit);
            sta.DataSource = this.GetDataSource;
            sta.Begin();
            //CalculateKCAQWMCSF();
        }
        private void CalculateKCAQWMCSF()
        {
            DataRow[] rows1 = this.Unit.StructSource.ModelMeasures.Select(string.Format("XMBM='{0}'", "C10101"), "", DataViewRowState.CurrentRows);
            if (rows1.Length > 0)
            {
                _Entity_SubInfo CSAQ = new _Entity_SubInfo();
                _ObjectSource.GetObject(CSAQ, rows1[0]);
                _Mothods_MFixed fix = new _Mothods_MFixed(null, this.Unit, CSAQ);
                fix.Begin(null);
                _Method_Metaanalysis method = new _Method_Metaanalysis(this.Unit);
                method.Calculate();

            }
        }
        /// <summary>
        /// 保存模板
        /// </summary>
        public void Save(string p_FileName)
        {
            DataTable table = this.Unit.StructSource.ModelMeasures.Copy();
            DataView dv = table.DefaultView;
            dv.Sort = "XH asc,Sort asc";
            DataTable table1 = dv.ToTable();
            DataRow[] infos = table1.Select(" XMBM is null and  XMMC is null ");
            for (int i = 0; i < infos.Length; i++)
            {
                    infos[i].Delete();

            }
            table.AcceptChanges();
            CFiles.BinarySerialize(table, p_FileName);
        }

        public void Load(string p_FileName)
        {
            /*object obj = CFiles.Deserialize(Path);
            this.m_Source = obj as DataTable;
            this.m_FilePath = Path;
            FileInfo info = new FileInfo(Path);
            this.m_FileName = info.Name.Replace(info.Extension, "");*/
            try
            {
                using (var calculator = new Calculator(CurrentBusiness, Unit))
                {
                    //删除工料机，子目取费。安装增加费
                    DataRow[] rowsGLJ = this.Unit.StructSource.ModelQuantity.Select("SSLB=1");
                    calculator.Entities.AddRange(_Entity_SubInfo.ParseMore(rowsGLJ));
                    foreach (DataRow item in rowsGLJ)
                    {
                        item.Delete();
                    }
                    DataRow[] rowsQF = this.Unit.StructSource.ModelSubheadingsFee.Select("SSLB=1");
                    calculator.Entities.AddRange(_Entity_SubInfo.ParseMore(rowsQF));
                    foreach (DataRow item in rowsQF)
                    {
                        item.Delete();
                    }
                    DataRow[] rowsZJF = this.Unit.StructSource.ModelIncreaseCosts.Select("SSLB=1");
                    calculator.Entities.AddRange(_Entity_SubInfo.ParseMore(rowsZJF));
                    foreach (DataRow item in rowsZJF)
                    {
                        item.Delete();
                    }
                    //更换模板
                    DataTable table = CFiles.Deserialize(p_FileName) as DataTable;
                    this.Unit.DataTemp.MDataTemp.FileName = p_FileName;
                    this.Unit.DataTemp.MDataTemp.IsChange = true;
                    //删除当前模板 
                    this.Unit.StructSource.ModelMeasures.Clear();
                    this.Unit.StructSource.ModelMeasures.Add(this.Current);
                    this.Unit.StructSource.ModelMeasures.AcceptChanges();
                    this.LoadTempletTable(table, calculator);
                }

                CurrentBusiness.FastCalculate();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
