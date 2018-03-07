using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using System.Linq;

namespace GOLDSOFT.QDJJ.CTRL
{
    public partial class ManualConversionControl : BaseControl
    {
        private _ObjectInfo m_info = null;

        public _ObjectInfo Info
        {
            set { m_info = value; }
        }

        

        public ManualConversionControl()
        {
            InitializeComponent();
        }

        private void ManualConversionControl_Load(object sender, EventArgs e)
        {
            
        }



        
    }
}
