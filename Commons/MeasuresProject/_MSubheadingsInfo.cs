using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using System.Data;
namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 措施项目-子目对象
    /// </summary>
    [Serializable]
    public class _MSubheadingsInfo : _SubheadingsInfo
    {
        public _MSubheadingsInfo()
            : base()
        { }
        //public _MSubheadingsInfo(_FixedListInfo p_Parent)
        //    : base(p_Parent)
        //{ }
        public override void NewInfo()
        {
            base.NewInfo();
            this.Statistics = new _Subheadings_Statistics_Return(this);//暂时和分部分项的计算类同一调用
        }
        public override _UnitProject Activitie
        {
            get
            {
                if (this.Parent == null) return null;
                return this.Parent.Activitie;
            }
        }
        public override string GetSSDWGCLB()
        {
            return "措施项目";
        }



        public override long PKey
        {
            get
            {
                return this.Parent.Key;
            }
            set
            {
                //this.m_PKey = value;
            }
        }

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
            //return base.Copy();
        }
        public override void Copys(object o)
        {

            Clipboard.SetDataObject(o);

        }
        public override void Paste()
        {
            this.Parent.Paste();
        }

        /// <summary>
        /// 计算基础发生改变的时候要做的事
        /// </summary>
        public override string JSJC
        {
            get { return base.JSJC; }
            set
            {

                base.JSJC = value;
                if (this.STATUS)
                {
                    this.Begin();
                }

            }
        }
        /// <summary>
        /// 费率发生改变的时候要做的事
        /// </summary>
        public override string FL
        {
            get { return base.FL; }
            set
            {

                base.FL = value;
                if (this.STATUS)
                {
                    this.Begin();
                }

            }
        }
       

        public override void SetOpera(string p_txt)
        {
            this.XMMC += p_txt;
            this.Activitie.Property.MeasuresProject.DataSource.ResetBindings(false);
        }
      
       
    }
}
