using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
   public class _ConvertUnit
    {
       //private Hashtable Area=new Hashtable();
       private static DataTable m_Source;

        public static DataTable Source
        {
            get { return m_Source; }
            set { m_Source = value; }
        }
        public static decimal Convert(string a_Unit, string b_Unit)
        {
            decimal d = 0m;
            if (m_Source!=null)
            {
                if (a_Unit == null || b_Unit == null) return 0;
                DataRow[] rowsb = m_Source.Select(string.Format("Name='{0}'", b_Unit.ToUpper()));
                DataRow[] rowsa = m_Source.Select(string.Format("Name='{0}'", a_Unit.ToUpper()));
                if (rowsb.Length>0&&rowsa.Length>0)
                {
                    if (rowsb[0]["Type"].ToString()==rowsa[0]["Type"].ToString())
                    {
                        return ToolKit.ParseDecimal(rowsa[0]["Value"]) / ToolKit.ParseDecimal(rowsb[0]["Value"]);
                    }
                }

            }
            return d;
        }
      
    }

   
}
