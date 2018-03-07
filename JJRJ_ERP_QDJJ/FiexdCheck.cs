using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;
using GOLDSOFT.QDJJ.COMMONS;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class FiexdCheck : ABaseForm
    {
        public FiexdCheck()
        {
            InitializeComponent();
        }
        private ArrayList m_ArrDE = new ArrayList();

        public ArrayList ArrDE
        {
            get { return m_ArrDE; }
            set { m_ArrDE = value; }
        }
        private string strCZBM = string.Empty;
        /// <summary>
        /// 操作编码
        /// </summary>
        public string StrCZBM
        {
            get { return strCZBM; }
            set { strCZBM = value; }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiexdCheck_Load(object sender, EventArgs e)
        {
            DataTable dt = this.Activitie.StructSource.ModelSubSegments.Select("LB='清单'", " Sort asc").CopyToDataTable();
            this.treeList1.DataSource = dt.DefaultView;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode item in this.treeList1.Nodes)
            {
                if (item.Checked)
                {
                    DataRowView qd = this.treeList1.GetDataRecordByNode(item) as DataRowView;
                    if (qd != null)
                        this.Create(qd);
                }
            }
            MsgBox.Show("处理完成！", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;

        }
        private void Create(DataRowView p_QD)
        {
            int i = 0;
            foreach (DataRowView v in this.m_ArrDE)
            {
                _Entity_SubInfo sinfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(sinfo, v.Row);
                DataRow[] rowsGLJ = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}  and ZCLB='W'", sinfo.ID, sinfo.SSLB));
                DataRow[] rowsZMQF = this.Activitie.StructSource.ModelSubheadingsFee.Select(string.Format("ZMID={0} and SSLB={1}", sinfo.ID, sinfo.SSLB));
                DataRow[] rowsBZHS = this.Activitie.StructSource.ModelStandardConversion.Select(string.Format("ZMID={0} and SSLB={1}", sinfo.ID, sinfo.SSLB));
                DataRow[] rowsZJF = this.Activitie.StructSource.ModelIncreaseCosts.Select(string.Format("ZMID={0} and SSLB={1}", sinfo.ID, sinfo.SSLB));
                DataRow[] rowsBL = this.Activitie.StructSource.ModelVariable.Select(string.Format("ID={0} and Type={1}", sinfo.ID, sinfo.SSLB));
                sinfo.PID = ToolKit.ParseInt(p_QD["ID"]);
                sinfo.Key = ++this.CurrentBusiness.Current.ObjectKey;
                sinfo.PKey = ToolKit.ParseInt(p_QD["Key"]);
                sinfo.CPARENTID = sinfo.PID;
                sinfo.FPARENTID = sinfo.PID;
                sinfo.PPARENTID = sinfo.PID;
                //sinfo.SSLB = this.Current.SSLB;
                //sinfo.EnID = this.Current.EnID;
                // sinfo.UnID = this.Current.UnID;
                sinfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu(strCZBM, ++i, p_QD["OLDXMBM"].ToString());
                this.Activitie.StructSource.ModelSubSegments.Add(sinfo);
                foreach (DataRow item in rowsGLJ)
                {
                    DataRow[] rowsZC = this.Activitie.StructSource.ModelQuantity.Select(string.Format("PID={0} and SSLB={1}", item["ID"], sinfo.SSLB));

                    DataRow r_glj = this.Activitie.StructSource.ModelQuantity.Add(item);
                    r_glj["ZMID"] = sinfo.ID;
                    r_glj["QDID"] = ToolKit.ParseInt(p_QD["ID"]);
                    foreach (DataRow row in rowsZC)
                    {

                        DataRow phb = this.Activitie.StructSource.ModelQuantity.Add(row);
                        phb["ZMID"] = sinfo.ID;
                        phb["QDID"] = ToolKit.ParseInt(p_QD["ID"]);
                        phb["PID"] = r_glj["ID"];
                    }
                }
                foreach (DataRow item in rowsZMQF)
                {

                    DataRow r_glj = this.Activitie.StructSource.ModelSubheadingsFee.Add(item);
                    r_glj["ZMID"] = sinfo.ID;
                    r_glj["QDID"] = ToolKit.ParseInt(p_QD["ID"]);

                }
                foreach (DataRow item in rowsBZHS)
                {
                    DataRow r_glj = this.Activitie.StructSource.ModelSubheadingsFee.Add(item);
                    r_glj["ZMID"] = sinfo.ID;
                    r_glj["QDID"] = ToolKit.ParseInt(p_QD["ID"]);

                }
                foreach (DataRow item in rowsZJF)
                {
                    DataRow r_glj = this.Activitie.StructSource.ModelSubheadingsFee.Add(item);
                    r_glj["ZMID"] = sinfo.ID;
                    r_glj["QDID"] = ToolKit.ParseInt(p_QD["ID"]);
                }
                foreach (DataRow item in rowsBL)
                {
                    DataRow r = this.Activitie.StructSource.ModelVariable.NewRow();
                    r.ItemArray = item.ItemArray;
                    r["ID"] = sinfo.ID;
                    this.Activitie.StructSource.ModelVariable.Rows.Add(r);

                }

                GLODSOFT.QDJJ.BUSINESS._Methods calculateMethod = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntace(this.CurrentBusiness, this.Activitie, sinfo);
                _Modify_Method.Edit_Sub("HL", calculateMethod, v.Row);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ck = sender as CheckEdit;
            foreach (TreeListNode item in this.treeList1.Nodes)
            {
                item.Checked = ck.Checked;
            }
        }
    }
}
