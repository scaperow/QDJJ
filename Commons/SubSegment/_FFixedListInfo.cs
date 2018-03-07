using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _FFixedListInfo : _FixedListInfo
    {
     public  _FFixedListInfo():base()
     {}
     //public _FFixedListInfo(_FestivalInfo p_Parent)
     //    : base(p_Parent)
     //{ }
     public override void Create(_SubheadingsInfo info)
     {
        // info.Activitie = this.Activitie;
         if (this.XMBM == "" && this.XMMC == "") return;
         info.Parent = this;
         info.ID = this.Parent.Parent.Parent.Parent.ObjectID;
         this.Parent.Parent.Parent.Parent.ObjectsList.Add(info);
         base.Create(info);
         if (info.XMBM!=""&&info.BEIZHU=="")
         {
             info.BEIZHU = this.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
         }

     }
     public override void RemoveIncrease()
     {
         _SubheadingsInfo[] arr = this.IncreaseCostsList.Cast<_SubheadingsInfo>().ToArray();
         foreach (_SubheadingsInfo item in arr)
         {
             this.Activitie.Property.SubSegments.ObjectsList.Remove(item);
             this.SubheadingsList.Remove(item);
         }
         //this.IncreaseCostsList.Clear();
     }
     public override void CreateByXml(_SubheadingsInfo info)
     {
         // info.Activitie = this.Activitie;
         if (this.XMBM == "" && this.XMMC == "") return;
         info.Parent = this;
         info.ID = this.Parent.Parent.Parent.Parent.ObjectID;
         this.Parent.Parent.Parent.Parent.ObjectsList.Add(info);
         base.CreateByXml(info);
         if (info.XMBM != "" && info.BEIZHU == "")
         {
             info.BEIZHU = this.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
         }

     }

     public override bool JBHZ
     {
         get { return base.JBHZ; }
         set { base.JBHZ = value; this.Parent.Begin(); }
     }
        /// <summary>
        /// 创建子目到指定位置
        /// </summary>
        /// <param name="info"></param>
        /// <param name="Index_info"></param>
     public override void Create(_SubheadingsInfo info, _SubheadingsInfo Index_info)
     {
         if (this.XMBM == "" && this.XMMC == "") return;
         info.Parent = this;
         info.ID = this.Parent.Parent.Parent.Parent.ObjectID;
         this.Parent.Parent.Parent.Parent.ObjectsList.Insert(info,Index_info);
         base.Create(info);
         //if (info.IsHs)
         //{
        
         //        base.OnZiMuAddEvent(info);
             
         //}
         if (info.XMBM != "" && info.BEIZHU == "")
         {
             info.BEIZHU = this.OLDXMBM + "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
         }
     }

     public override _UnitProject Activitie
     {
         get
         {
             if (this.Parent == null) return null;
             return this.Parent.Activitie;
         }
     }
     public override void Remove(_SubheadingsInfo info)
     {
         base.Remove(info);
         this.Parent.Parent.Parent.Parent.ObjectsList.Remove(info);
         this.Begin();
     }
     private void AddZm()
     {
         if (this.Parent == null) return;
         //if (this.Activitie == null) return;
         if (this.SubheadingsList.Count<1)
         {

             _SubheadingsInfo info = new _FSubheadingsInfo();
             info.XMBM = "补" + this.OLDXMBM.Replace("补","");
             info.OLDXMBM = this.OLDXMBM.Replace("补", "");
             info.XMMC = "补充定额";
             info.GCL = 1m;
             info.SC = true;
             info.LB = "子目";
             info.DW = this.DW;
             info.TX = this.Activitie.ProType.Replace("【","").Replace("】","").Substring(0, 2);
             info.LibraryName = this.Activitie.Property.Libraries.FixedLibrary.FullName;
             this.Create(info);
             this.Activitie.Property.SubSegments.ChangeSource();
            // this.Activitie.Property.SubSegments.DataSource.ResetBindings(false);
            // this.Activitie.Property.SubSegments.DataSource.ResetBindings(false);
         }
     
     }

     public override decimal ZJTJ
     {
         get { return base.ZJTJ; }
         set
         {

             AddZm();//若该清单下没有子目则添加子目
             base.ZJTJ = value;
             //C=直接调价/综合单价,子目工料机的消耗量变更为原消耗量*C
         }
     }

     public override decimal GCL
     {
         get { return base.GCL; }
         set
         {

             //AddZm();//若该清单下没有子目则添加子目
             base.GCL = value;
             //C=直接调价/综合单价,子目工料机的消耗量变更为原消耗量*C
         }
     }
    
     /*public override long PKey
     {
         get
         {
             return this.Parent.Key;
         }
         set
         {
             //this.m_PKey = value;
         }
     }*/
     public override string ProName
     {
         get
         {
             return this.Parent.ProName;
         }
         set { }
     }
     public override ISubSegment IParent
     {
         get
         {
             return this.Parent;
         }
     }
     public override void Copys()
     {
         _FestivalInfo p = this.Parent;
         this.Parent = null;
         Clipboard.SetDataObject(this);
         this.Parent = p;
     }

   
     public override void Copys(object o)
     {

         Clipboard.SetDataObject(o);

     }
     public override void Paste()
     {
         IDataObject o = Clipboard.GetDataObject();

         _CopyList obj = o.GetData(typeof(_CopyList)) as _CopyList;
         if (obj == null) return;
         switch (obj.Ctype)
         {
             case CopType.清单:
                 foreach (_FixedListInfo info in obj)
                 {
                     info.InSerializable(null);
                     this.Activitie.Property.SubSegments.Create(info);
                     object[] items = info.SubheadingsList.ToArray();
                     info.SubheadingsList.Clear();
                     foreach (_SubheadingsInfo item in items)
                     {
                         info.Create(item);
                     }
                 }

                 break;
             case CopType.子目:
                 foreach (_SubheadingsInfo sinfo in obj)
                 {
                     sinfo.InSerializable(null);
                     this.Create(sinfo);
                 }

                 break;
             default:
                 break;
         }
        
         Clipboard.Clear();
     }
     public override bool IsPaste()
     {
         IDataObject o = Clipboard.GetDataObject();
        object obj= o.GetData(typeof(_CopyList));
        if (obj!=null)
        {
            return true;
        }
        return false;
     }
    }
}
