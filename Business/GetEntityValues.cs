using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Business
{
   public  class GetEntityValues
    {
        public static Entity.投标信息表 GetTbxx() //获取投标信息
        {
            Entity.投标信息表 tbxx = new Entity.投标信息表();
            DataRow dr = tbxx.tbxxRow();
            if (dr == null) return null;
            tbxx.TBDW = GetSafeData.ValidateDataRow_S(dr, "tbdw");
            tbxx.TBDWDBR = GetSafeData.ValidateDataRow_S(dr, "tbdwdbr");
            tbxx.TBGQ = GetSafeData.ValidateDataRow_S(dr, "tbgq");
            tbxx.ZLCN = GetSafeData.ValidateDataRow_S(dr, "zlcn");
            tbxx.BBZJ = GetSafeData.ValidateDataRow_S(dr, "bbzj");
            tbxx.DBLX = GetSafeData.ValidateDataRow_S(dr, "dblx");
            tbxx.JZS = GetSafeData.ValidateDataRow_S(dr, "jzs");
            tbxx.JZSH = GetSafeData.ValidateDataRow_S(dr, "jzsh");
            tbxx.PlaitNo = GetSafeData.ValidateDataRow_S(dr, "plaitno");
            tbxx.ReviewName = GetSafeData.ValidateDataRow_S(dr, "reviewname");
            tbxx.PlaitDate = GetSafeData.ValidateDataRow_T(dr, "plaitdate");
            tbxx.ReviewDate  = GetSafeData.ValidateDataRow_T(dr, "reviewdate");
            return tbxx;
        }
        public static Entity.招标信息表 GetZbxx() //获取招标信息
        {
            Entity.招标信息表 zbxx = new Entity.招标信息表();
            DataRow dr = zbxx.zbxxRow();
            if (dr == null) return null;
            zbxx.JSDW = GetSafeData.ValidateDataRow_S(dr, "jsdw");
            zbxx.JSDWDBR = GetSafeData.ValidateDataRow_S(dr, "jsdwdbr");
            zbxx.ZBDLR = GetSafeData.ValidateDataRow_S(dr, "zbdlr");
            zbxx.ZBDLDBR = GetSafeData.ValidateDataRow_S(dr, "zbdldbr");
            zbxx.GCLX = GetSafeData.ValidateDataRow_S(dr, "gclx");
            zbxx.ZBFW = GetSafeData.ValidateDataRow_S(dr, "zbfw");
            zbxx.ZBMJ = GetSafeData.ValidateDataRow_S(dr, "zbmj");
            zbxx.ZBGQ = GetSafeData.ValidateDataRow_S(dr, "zbgq");
            zbxx.BZDW = GetSafeData.ValidateDataRow_S(dr, "bzdw");
            zbxx.SJDW = GetSafeData.ValidateDataRow_S(dr, "sjdw");
            zbxx.DBLX = GetSafeData.ValidateDataRow_S(dr, "dblx");
            zbxx.PlaitNo = GetSafeData.ValidateDataRow_S(dr, "plaitno");
            zbxx.ReviewName = GetSafeData.ValidateDataRow_S(dr, "reviewname");
            zbxx.PlaitName = GetSafeData.ValidateDataRow_S(dr, "plaitname");
            zbxx.PlaitDate = GetSafeData.ValidateDataRow_T(dr, "plaitdate");
            zbxx.ReviewDate = GetSafeData.ValidateDataRow_T(dr, "reviewdate");
            zbxx.BZDWDBR = GetSafeData.ValidateDataRow_S(dr, "bzdwdbr");
            return zbxx;
        }
    }
}
