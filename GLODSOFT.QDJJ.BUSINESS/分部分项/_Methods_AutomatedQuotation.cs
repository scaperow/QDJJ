using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;
using System.Text.RegularExpressions;

namespace GLODSOFT.QDJJ.BUSINESS
{
    public class _Methods_AutomatedQuotation : _Methods
    {
        public _Methods_AutomatedQuotation(_UnitProject p_Unit)
            : base(p_Unit)
        {
           
        }
        public void Refersh()
        {
            DataRow[] ros = this.Unit.StructSource.ModelSubSegments.Select("Lb='清单'","",DataViewRowState.CurrentRows);
            foreach (DataRow item in ros)
            {
                DataRow[] rows = GetSubhendings(item);//获取子目
                foreach (DataRow row in rows)
                {
                   //添加子目到清单
                }
            }
        }
        /// <summary>
        /// 根据清单行获取子目
        /// </summary>
        /// <param name="r">清单行</param>
        private DataRow[]  GetSubhendings(DataRow r)
        {
            DataTable dt = APP.Application.Global.DataTamp.自动报价.Tables["分类确定定额"];
            IEnumerable<DataRow> rows = from n in dt.AsEnumerable()
                                        where n["QDFW"].ToString().Contains(r["OLDXMBM"].ToString()) && getWhere(n, r["XMMC"].ToString())
                                        select n;
            return rows.ToArray();
        }
        private bool getWhere(DataRow r,string p_str)
        {
            bool flag = true;
            string XMMC = p_str;
            string Expression = r["CZFW"].ToString();
            Expression = Expression.Replace("[或]", "(或)");
            string[] Arr = Expression.Split(new string[] { "(或)" }, StringSplitOptions.None);
            for (int i = 0; i < Arr.Length; i++)
            {
                if (i == 0) flag = getyu(Arr[i], XMMC);

                else
                { 
                    flag |= getyu(Arr[i], XMMC);
                }
            }
            return flag;
        }

        private bool getyu(string str, string XMMC)
        {
            bool flag = true;
            string[] Arr2 = str.Split(new string[] { "(与)" }, StringSplitOptions.None);

            for (int i = 0; i < Arr2.Length; i++)
            {
                if (Arr2[i].Contains("(非)"))
                {
                    if (i == 0)
                    {
                        flag = !XMMC.Contains(Arr2[i].Replace("(非)", string.Empty));
                    }
                    else
                    {
                        flag &= !XMMC.Contains(Arr2[i].Replace("(非)", string.Empty));
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        flag = XMMC.Contains(Arr2[i]);
                    }

                    else
                    {
                        flag &= XMMC.Contains(Arr2[i]);
                    }
                }
            }
           
            return flag;
        }
    }
}
