using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BaseInfo : ABaseForm
    {

        private object m_Parm;
        public delegate void SourceChangeHanld(object obj, DataRow args,List<DataRow> rows);
        public event SourceChangeHanld SourceChange;
        public virtual object Parm
        {
            get { return m_Parm; }
            set { m_Parm = value; }
        }
        private ProInformation m_InformationForm;

        public ProInformation InformationForm
        {
            get { return m_InformationForm; }
            set { m_InformationForm = value; }
        }

        /// <summary>
        /// 节点编号
        /// </summary>
        private int _keyID = -1;
        /// <summary>
        /// 节点编号
        /// </summary>
        public int KeyID
        {
            get { return _keyID; }
            set { _keyID = value; }
        }

        public BaseInfo()
        {
            InitializeComponent();
        }

        public virtual void OnSourceChange(object sender, DataRow args, List<DataRow> rows)
        {
            if (SourceChange != null)
            {
                this.SourceChange(sender, args,  rows);
            }
        }
      

    }
}