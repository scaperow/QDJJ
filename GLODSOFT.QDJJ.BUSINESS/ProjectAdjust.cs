using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.COMMONS;
using System.Data;

namespace GLODSOFT.QDJJ.BUSINESS
{
  public  class ProjectAdjust
    {

      private _Business CurrentBusiness;
   
      public ProjectAdjust(_Business b)
      {
          this.CurrentBusiness = b;
      }
      public void Adjust(decimal d)
      {
          switch (CurrentBusiness.WorkFlowType)
          {
              case GOLDSOFT.QDJJ.COMMONS.EWorkFlowType.None:
                  return;
                  break;
              case GOLDSOFT.QDJJ.COMMONS.EWorkFlowType.PROJECT:
                  ProjectTAdjust(d);
                  break;
              case GOLDSOFT.QDJJ.COMMONS.EWorkFlowType.Engineering:
                  break;
              case GOLDSOFT.QDJJ.COMMONS.EWorkFlowType.UnitProject:
                  UnitProject(d, this.CurrentBusiness.Current as _UnitProject);
                  break;
              default:
                  break;
          }
      }
      private void ProjectTAdjust(decimal d)
      {
          _Projects p = this.CurrentBusiness.Current as _Projects;

          DataRow[] EnRows = this.CurrentBusiness.Current.StructSource.ModelProject.Select("PID = 1");

          foreach (DataRow row in EnRows)
          {
              _Engineering einfo = this.CurrentBusiness.Current.Create() as _Engineering;
              _ObjectSource.GetObject(einfo, row);


              DataRow[] UnRows = this.CurrentBusiness.Current.StructSource.ModelProject.Select(string.Format("PID = {0}", einfo.ID));
              _UnitProject pinfo = null;
        
              foreach (DataRow r in UnRows)
              {
                  pinfo = r["UnitProject"] as _UnitProject;
                  if (pinfo == null)
                  {
                      //反序列化
                      pinfo = (this.CurrentBusiness as _Pr_Business).GetObject(r["OBJECT"]) as _UnitProject;
                      //回写到表中
                      pinfo.InSerializable(einfo);
                      _ObjectSource.GetObject(pinfo, r);
                      this.CurrentBusiness.Current.StructSource.ModelProject.AppendUnit(pinfo);
                      //pinfo.Property = new _Un_Property(pinfo);
                      //pinfo.Reveal = new
                     
                  }

                  UnitProject(d, pinfo);
              }
          }
      }
      private void UnitProject(decimal d,_UnitProject un)
      {
          foreach (_ObjectQuantityUnitInfo item in un.Property.GetAllQuantityUnit)
          {
              decimal d1 = item.XHL * d;
              item.XHL = d1;
          }
      }

    }
}
