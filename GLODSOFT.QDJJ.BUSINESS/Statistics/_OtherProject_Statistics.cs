using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZiboSoft.Commons.Common;
using GOLDSOFT.QDJJ.COMMONS;

namespace GLODSOFT.QDJJ.BUSINESS
{

    [Serializable]
    public class _OtherProject_Statistics:_Statistics
    {

        _VariableSource ResultVarable;
        public _OtherProject_Statistics(_UnitProject p_Parent):base(p_Parent)
        {
            this.Unit = p_Parent;
            
        }

        public   void Begin()
        {
            if (Unit.StructSource.ModelOtherProject.Rows.Count == 0)
            {
                return;
            }

            DataRow r= this.Unit.StructSource.ModelOtherProject.Rows[0];
            int id = ToolKit.ParseInt(r["ID"]);
            this.ResultVarable = this.Unit.StructSource.ModelResultVariable;

            this.ResultVarable.Set(this.Unit.PID,id,2,_ObjectInfo.FILED_ZHHJ, getHJ("QTXMHJ"));
            decimal QTXMCJHJ = getCJHJ("QTXMHJ");
            this.ResultVarable.Set(this.Unit.PID, id, 2, "QTXMCJHJ", QTXMCJHJ);
            decimal QTXMRGCJHJ = getCJHJ("JRGRG");
            this.ResultVarable.Set(this.Unit.PID, id, 2, "QTXMRGCJHJ", QTXMRGCJHJ);
            this.ResultVarable.Set(this.Unit.PID, id, 2, "QTXMJSCJHJ", QTXMCJHJ - QTXMRGCJHJ);//结算差价
            this.ResultVarable.Set(this.Unit.PID, id, 2, "ZLJE", getHJ("ZLJE"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "SJBGCJ", getHJ("SJBGCJ"));

            this.ResultVarable.Set(this.Unit.PID, id, 2, "ZYGCZGJ", getHJ("ZYGCZGJ"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "ZCSBZGJ", getHJ("ZCSBZGJ"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "LXFBGCE", getHJ("LXFBGCE"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "JRG", getHJ("JRG"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "JRGRG", getHJ("JRGRG"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "JRGCL", getHJ("JRGCL"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "JRGJX", getHJ("JRGJX"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "ZCBFWF", getHJ("ZCBFWF"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "FBGLFWF", getHJ("FBGLFWF"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "FBRBGF", getHJ("FBRBGF"));
            this.ResultVarable.Set(this.Unit.PID, id, 2, "FSPTJJJ", getHJ("FSPTJJJ"));
          
        }

        public void Calculate()
        {
           
            this.Begin();
        }
        private decimal getCJHJ(string P_Feature)
        {
            DataRow[] rows = this.Unit.StructSource.ModelOtherProject.Select(string.Format("Feature = '{0}'", P_Feature));
            if (rows.Length > 0)
            {
                return ToolKit.ParseDecimal(rows[0]["cjhj"]);
            }
            return 0;
        }

        private decimal getHJ(string P_Feature)
        {
            DataRow[] rows = this.Unit.StructSource.ModelOtherProject.Select(string.Format("Feature = '{0}'", P_Feature));
            if (rows.Length > 0)
            {
                return ToolKit.ParseDecimal(rows[0]["Combinedprice"]);
            }
             return 0;
        }
    }
}
