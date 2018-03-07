using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _FSubheadingsInfo : _SubheadingsInfo
    {
        public _FSubheadingsInfo()
            : base()
        { }
        //public _FSubheadingsInfo(_FixedListInfo p_Parent)
        //    : base(p_Parent)
        //{ }
        public override decimal GCL
        {
            get { return base.GCL; }
            set {
                base.GCL = value;
                UpdateGCL();
            }
        }

        private void UpdateGCL()
        {
            if (this.Parent == null) return;
      
            if (this.Parent.GetType()==typeof(_FFixedListInfo))
            {
                if (this.TX=="模板")
                {
                    IEnumerable<_ObjectInfo> infos = from info in this.Activitie.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
                                                     where info.XMBM == this.XMBM
                                                     select info;
                    foreach (_ObjectInfo item in infos)
                    {
                        item.GCL = this.GCL;
                    }
                }
            }
            
        }

        public override string GetSSDWGCLB()
        {
            return "分部分项";
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

            _FixedListInfo p = this.Parent;
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
            this.Parent.Paste();
        }
     

    }
}
