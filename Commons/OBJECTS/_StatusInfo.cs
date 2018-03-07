using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
   public class _StatusInfo
    {
       private _COBJECTS Current;  
       public _StatusInfo(_COBJECTS p_obj)
       {
           this.Current = p_obj;
       }
       /// <summary>
       /// 获取清单个数
       /// </summary>
       public int 清单个数
       {
           get 
           {
              DataRow[] rows= this.Current.StructSource.ModelSubSegments.Select("LB='清单'");
              return rows.Length;
           }
       }

       /// <summary>
       /// 获取子目个数
       /// </summary>
       public int 子目个数
       {
           get 
           {
               DataRow[] rows = this.Current.StructSource.ModelSubSegments.Select("LB='子目'");
               return rows.Length;
           }
       }

       /// <summary>
       /// 措施项目费
       /// </summary>
       public decimal 措施项目费
       {
           get 
           {
               if (this.Current is _UnitProject)
               {
                   return this.Current.StructSource.ModelProjVariable.GetDecimal(this.Current.ID, -1, "CSXMF");
               }
               else
               {
                   return this.Current.StructSource.ModelProjVariable.GetDecimal(this.Current.ID, -3, "CSXMF");
               }
           }
       }

       /// <summary>
       /// 分部分项费
       /// </summary>
       public decimal 分部分项费
       {
           get 
           {
               if (this.Current is _UnitProject)
               {
                   return this.Current.StructSource.ModelProjVariable.GetDecimal(this.Current.ID, -1, "FBFXHJ");
               }
               else
               {
                   return this.Current.StructSource.ModelProjVariable.GetDecimal(this.Current.ID, -3, "FBFXHJ");
               }
           }
       }

       /// <summary>
       /// 当前工程总造价
       /// </summary>
       public decimal 当前工程总造价
       {
           get 
           {
               if (this.Current is _UnitProject)
               {
                  return this.Current.StructSource.ModelProjVariable.GetDecimal(this.Current.ID,-1,"ZZJ");
               }
               else
               {
                   return this.Current.StructSource.ModelProjVariable.GetDecimal(this.Current.ID, -3, "ZZJ");
               }
           }
       }

       /// <summary>
       /// 获工料机数
       /// </summary>
       public int 工料机数
       {
           get 
           {
               try
               {
                     DataTable table = this.Current.StructSource.ModelQuantity.Copy();
               DataView v = table.DefaultView;
               DataTable dt =v.ToTable(true, "BH");
               return dt.Rows.Count;
               }
               catch (Exception)
               {

                   return 0;
               }
           }
       }
    }
}
