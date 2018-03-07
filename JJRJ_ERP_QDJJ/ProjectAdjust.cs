using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProjectAdjust : BaseForm
    {
        public ProjectAdjust()
        {
            InitializeComponent();
        }
        private _Projects m_COBJECT;
        /// <summary>
        /// 当前的项目
        /// </summary>
        public _Projects COBJECT
        {
            get { return m_COBJECT; }
            set { m_COBJECT = value; }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProjectAdjust_Load(object sender, EventArgs e)
        {
            init();
        }
        private void init()
        {
            this.txt_TZQ.Text = GetZZJ().ToString();
        }

        private decimal GetZZJ()
        {
            
            IEnumerable<_ObjMetaanalysis> o = null;
            _List list = this.CurrentBusiness.Current.Reveal.Get(ERevealType.汇总分析);
           // if (list.Count < 1) return 0.0m;
           
            switch (this.CurrentBusiness.Current.ObjectType)
            {
                case EObjectType.Default:
                    break;
                case EObjectType.PROJECT:
                    o = from n in list.Cast<_ObjMetaanalysis>()
                        where n.GetType() == typeof(_ProMetaanalysis)
                        select n;
                    break;
                case EObjectType.Engineering:
                    o = from n in list.Cast<_ObjMetaanalysis>()
                        where n.GetType() == typeof(_EngMetaanalysis)
                        select n;
                    break;
                case EObjectType.UnitProject:
                    DataTable dt = (this.CurrentBusiness.Current as _UnitProject).Property.Metaanalysis.Source;
                    DataRow[] rows = dt.Select("");
                    if (rows.Length > 0)return ToolKit.ParseDecimal(rows[0][""]);
                    else return 0.0m;
                default:
                    break;
            }
            if (o.Count() > 0)
                return o.First().ZZJ;
            else return 0.0m;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GLODSOFT.QDJJ.BUSINESS.ProjectAdjust p=new GLODSOFT.QDJJ.BUSINESS.ProjectAdjust(this.CurrentBusiness);
            decimal  d=ToolKit.ParseDecimal(this.textEdit1.Text)/ToolKit.ParseDecimal(this.txt_TZQ.Text);
            p.Adjust(d);
            this.Close();
        }
    }
}
