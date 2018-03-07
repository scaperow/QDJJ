using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Method_Sub_ImportExcel : _Methods
    {
        public _Method_Sub_ImportExcel(_Business p_Bus, _UnitProject p_Unit)
        {
            this.Unit = p_Unit;
            this.CurrentBusiness = p_Bus;
        }
        private bool m_IsClear = false;

        public bool IsClear
        {
            get { return m_IsClear; }
            set { m_IsClear = value; }
        }

        private string m_FileName;

        //public string FileName
        //{
        //    get { return m_FileName; }
        //    set { m_FileName = value; }
        //}
        private DataTable table;
        public void Import(string filaname)
        {
            this.m_FileName = filaname;
            if (this.m_IsClear)
            {
                //this.ClerSub();
            }
            this.GetTable();
            bool flag = false;
            _Method_Sub sub = this.GetSub();
            _Entity_SubInfo info =new _Entity_SubInfo();
            int count = 1;
            foreach (DataRow item in this.table.Rows)
            {
                if (ToolKit.ParseInt(item[0])>0)
                {
                    flag = true; 
                }
                if (flag)
                {

                    if (item[0] == DBNull.Value && item[1] == DBNull.Value && item[2] == DBNull.Value && item[3] == DBNull.Value)
                    {
                        return;
                    }
                    int XH = ToolKit.ParseInt(item[0]);
                    string XMBM = item[1].ToString();
                    string XMMC = item[2].ToString();
                    string DW = item[3].ToString();
                    decimal GCL = ToolKit.ParseDecimal(item[4]);
                    if (XH > 0)//清单
                    {
                        if (XMBM.Length > 9)
                        {
                            string xmbm = XMBM.Substring(0, 9);
                            DataRow[] rows = this.Unit.Property.Libraries.ListGallery.LibraryDataSet.Tables["清单表"].Select(string.Format("QINGDBH='{0}'", xmbm));
                            if (rows.Length > 0)
                            {
                                info = new _Entity_SubInfo();
                                _Methods.SetFixedInfo(info, rows[0], this.Unit.Property.Libraries.ListGallery.FullName, this.Unit.StructSource.ModelSubSegments, "ZYLB");
                                info.XH = XH;
                                info.XMBM = XMBM;
                                info.XMMC = XMMC;
                                info.DW = DW;
                                info.GCL = GCL;
                                int m = GLODSOFT.QDJJ.BUSINESS._Methods.GetCountByBH(xmbm, this.Unit.StructSource.ModelSubSegments);
                                info.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetQDbeizhu(xmbm, m, "EXCL");
                                sub.Create(-1, info);
                            }
                            else//补充清单
                            {
                                info = new _Entity_SubInfo();
                                info.XH = XH;
                                info.XMBM = XMBM;
                                info.OLDXMBM = xmbm;
                                info.XMMC = XMMC;
                                info.DW = DW;
                                info.LB = "清单";
                                info.ZJWZ = "999999";
                                info.GCL = GCL;
                                int m = GLODSOFT.QDJJ.BUSINESS._Methods.GetCountByBH(xmbm, this.Unit.StructSource.ModelSubSegments);
                                info.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetQDbeizhu(xmbm, m, "EXCL");
                                sub.Create(-1, info);
                            }

                        }
                        else//补充清单
                        {
                            info = new _Entity_SubInfo();
                            info.XH = XH;
                            info.XMBM = XMBM;
                            info.OLDXMBM = XMBM;
                            info.XMMC = XMMC;
                            info.DW = DW;
                            info.LB = "清单";
                            info.ZJWZ = "999999";
                            info.GCL = GCL;
                            int m = GLODSOFT.QDJJ.BUSINESS._Methods.GetCountByBH(XMBM, this.Unit.StructSource.ModelSubSegments);
                            info.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetQDbeizhu(XMBM, m, "EXCL");
                            sub.Create(-1, info);
                        }
                    }
                    else//子目的处理
                    {
                        string xmbm = XMBM.Replace("换", "");
                        xmbm = xmbm.Split(' ')[0];
                        DataRow[] rows = this.Unit.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Select(string.Format("DINGEH='{0}'", xmbm));
                        _Methods_Fixed fix = new _Methods_Fixed(this.CurrentBusiness, this.Unit, info);
                        if (rows.Length > 0)
                        {
                            _Entity_SubInfo sinfo = new _Entity_SubInfo();
                            _Methods.SetSubheadingsInfo(sinfo, rows[0], this.Unit.Property.Libraries.FixedLibrary.FullName);
                           // _ObjectSource.GetObject(sinfo, rows[0]);
                            sinfo.XH = XH;
                            sinfo.XMBM = XMBM;
                            sinfo.XMMC = XMMC;
                            sinfo.DW = DW;
                            sinfo.LB = "子目";
                            sinfo.GCL = GCL;
                            sinfo.OLDXMBM = xmbm;
                            sinfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("EXCL", count, info.OLDXMBM);
                            fix.Create(false, -1, sinfo);
                            count++;
                        }
                        else
                        {
                            _Entity_SubInfo sinfo = new _Entity_SubInfo();
                            sinfo.XH = XH;
                            sinfo.XMBM = XMBM;
                            sinfo.OLDXMBM = xmbm;
                            sinfo.XMMC = XMMC;
                            sinfo.DW = DW;
                            sinfo.GCL = GCL;
                            sinfo.LB = "子目";
                            sinfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("EXCL", count, info.OLDXMBM);
                            fix.Create(false,-1, sinfo);
                            count++;
                        }
                    }
                }
            }
        }
        public void ClerSub()
        {
            DataRow[] rows = this.Unit.StructSource.ModelSubSegments.Select("PID<>0","deep desc");
            
            for (int i = 0; i < rows.Length; i++)
            {
                try
                {
                    rows[i].Delete();
                }
                catch (Exception e)
                {
                    string s = e.Message;
                }   
            }
        }
        private _Method_Sub GetSub()
        {
           
            DataRow[] rows = this.Unit.StructSource.ModelSubSegments.Select("PID=0");
            if (rows.Length > 0)
            {
                _Entity_SubInfo info = new _Entity_SubInfo();
                _ObjectSource.GetObject(info, rows[0]);
                _Method_Sub sub = new _Method_Sub(this.CurrentBusiness, this.Unit, info);
                return sub;
            }
            return null;
           
        }
        private void GetTable()
        {
            FileInfo file = new FileInfo(this.m_FileName);
            if (!file.Exists)
            {
                throw new Exception("文件不存在");
            }
            string extension = file.Extension;
            string strConn = "";
            switch (extension)
            {
                case ".xls":
                    //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.m_FileName + "; Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                    //break;
                case ".xlsx":
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.m_FileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.m_FileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            table = new DataTable();
            OleDbConnection oleConn = new OleDbConnection(strConn);
            try
            {
                oleConn.Open();
                //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等
                DataTable dtSheetName = oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                string strSql = "SELECT * FROM [" + dtSheetName.Rows[0]["TABLE_NAME"] + "]";
                OleDbCommand oleCom = new OleDbCommand(strSql, oleConn);
                using (OleDbDataReader rdr = oleCom.ExecuteReader())
                {
                    table.Load(rdr);
                }
            }
            catch (Exception)
            {
                // MsgBox.Alert("文件被占用请重试");
                //return;
            }
            finally
            {
                if (oleConn.State == ConnectionState.Open)
                {
                    oleConn.Close();
                }
            }

        }
    }
}
