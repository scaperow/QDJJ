using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace GOLDSOFT.QDJJ.UI.Controls
{
    public class BindingSourceEx : BindingSource
    {
        public BindingSourceEx(IContainer container)
            : base(container)
        {

        }
        public delegate void HandBindFiter(object snder);
        public event HandBindFiter OnBindFiter;
        public override string Filter
        {
            get
            {
                return base.Filter;
            }
            set
            {
                base.Filter = value;
                if (OnBindFiter != null)
                {
                    OnBindFiter(this);
                }
            }
        }

    }
}
