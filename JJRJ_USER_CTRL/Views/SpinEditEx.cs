using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.CTRL
{
    public  class SpinEditEx : SpinEdit
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar=='-')
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
    }
}
