using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class PrviewTJLX : BaseInfo
    {
        public PrviewTJLX()
        {
            InitializeComponent();
        }
        DataTable m_Source;
       
        public PrviewTJLX(_UnitProject p_CUnitProject)
        {
            this.Activitie = p_CUnitProject;
            InitializeComponent();
        }
        public PrviewTJLX(_UnitProject p_CUnitProject,string TJBH,string LX)
        {
            this.Activitie = p_CUnitProject;
            InitializeComponent();
            this.bindingSource1.Filter = string.Format("TJBH like '%{0}%' and CLFS='{1}'", TJBH, LX);
        }

        public PrviewTJLX(_UnitProject p_CUnitProject, string TJBH, string LX,string BS)
        {
            this.Activitie = p_CUnitProject;
            InitializeComponent();
            this.bindingSource1.Filter = string.Format("TJBH like '%{0}%' and CLFS='{1}' and BS='{2}'", TJBH, LX,BS);
        }

        private void PrviewTJLX_Load(object sender, EventArgs e)
        {
            this.init();
        }
        private void init()
        {
            try
            {
                this.m_Source = this.Activitie.Property.Libraries.AtlasGallery.LibraryDataSet.Tables["图集类型表"].Copy();
            }
            catch { return; }
           if (!this.m_Source.Columns.Contains("HD1"))
           {
               this.m_Source.Columns.Add("HD1");
           }
           this.bindingSource1.DataSource = this.m_Source;
           this.gridControl1.DataSource = this.bindingSource1;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName=="HD1")
            {
                DataRowView   v=this.bindingSource1.Current as DataRowView;
                if (v["HD"]!=null)
                {

                    if (v["HD"].ToString() != string.Empty)
                    {
                        e.Column.OptionsColumn.ReadOnly = false;
                        string str = v["HD"].ToString();
                        this.repositoryItemComboBox1.Items.Clear();
                        this.repositoryItemComboBox1.Items.AddRange(str.Split(','));
                        e.RepositoryItem = this.repositoryItemComboBox1;
                    }
                    else
                    {
                        e.Column.OptionsColumn.ReadOnly = true;
                    }
                    
                }
                
            }
        }
    }
}
