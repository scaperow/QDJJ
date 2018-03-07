using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTab;
using System.Data;

namespace GOLDSOFT.QDJJ.UI.Controls
{
    public class XtraTabPageCostSelectEx : XtraTabPage
    {
        public XtraTabPageCostSelectEx(DataTable p_dt,string p_xsl)
        {
            this.Text = p_dt.TableName;
            CostSelectControl csc = new CostSelectControl(p_xsl);
            csc.Dock = System.Windows.Forms.DockStyle.Fill;
            csc.bindingSource1.DataSource = p_dt;
            this.Controls.Add(csc);
        }

        public object Current()
        {
            return (this.Controls[0] as CostSelectControl).bindingSource1.Current;
        }
    }
}
