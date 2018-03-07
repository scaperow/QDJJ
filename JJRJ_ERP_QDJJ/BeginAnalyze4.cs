/*
    客户信息提交窗体
 *  两种模式 首次应用 变更申请
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GoldSoft.QD_api;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.UI.Client;
using GOLDSOFT.SERVICES.IServicesObject;
using GoldSoft.CICM.UI;
using ZiboSoft.Commons.Common;
using System.IO;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BeginAnalyze4 : CBaseForm
    {
        private string columnName = "";
        public Container _sender;

        public BeginAnalyze4()
        {
            InitializeComponent();


        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "";
            sfd.Filter = "调标文件(*.tbx)|*.tbx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString();
                if (!localFilePath.EndsWith(".tbx")) localFilePath += ".tbx";
                try
                {
                    ApplicationForm pForm = this.MdiParent as ApplicationForm;
                    Container form = pForm.ActiveMdiChild as Container;
                    SubSegmentForm obj = form.GetWorkAreas as SubSegmentForm;
                    File.Copy(APP.Cache.AppFolder + "工程文件\\备份文件\\"+ obj.Activitie.Name  +".xls", localFilePath);
                    File.Delete(APP.Cache.AppFolder + "工程文件\\备份文件\\abcInvite.xls");
                }
                catch (Exception)
                {
                    MessageBox.Show("发生未知异常，请重试", "金建软件");
                }
            }

            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.dataGridView1_DoubleClick(sender, e);
        }

        private void BeginAnalyze4_Load(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            data.Columns.Add(new DataColumn("Name"));
            //data.Columns.Add(new DataColumn("Flag"));
            DataRow row = null; 
            for(int i = 9; i < APP.GoldSoftClient.TB_RESULT.Columns.Count; i++)
            {                
                row = data.NewRow();
                row["Name"] = APP.GoldSoftClient.TB_RESULT.Columns[i].ColumnName;
                //row["Flag"] = true;
                data.Rows.Add(row);
            }

            this.bindingSource1.DataSource = data.DefaultView;
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            columnName = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            ApplicationForm pForm = this.MdiParent as ApplicationForm;
            Container form = pForm.ActiveMdiChild as Container;
            decimal rate = 0.0m;
            decimal oResult = 0.0m;
            int qdID = 0;
            DataRow[] rows = null;
            DataRow row = null;
            bool result = false;
            decimal jsCount = 0.0m, zhdj = 0.0m;

            SubSegmentForm obj = form.GetWorkAreas as SubSegmentForm;          

            for (int i = 0; i < obj.Activitie.StructSource.ModelSubSegments.Rows.Count; i++)
            {
                if (!obj.Activitie.StructSource.ModelSubSegments.Rows[i]["LB"].ToString().Equals("清单")) continue;

                for (int j = 0; j < APP.GoldSoftClient.TB_RESULT.Rows.Count; j++)
                {
                    if (decimal.Parse(obj.Activitie.StructSource.ModelSubSegments.Rows[i]["ZHDJ"].ToString()) == 0.0M ||
                            APP.GoldSoftClient.TB_RESULT.Rows[j][columnName].ToString().Equals("正无穷大") ||
                            APP.GoldSoftClient.TB_RESULT.Rows[j][columnName].ToString().Equals("负无穷大") ||
                            obj.Activitie.StructSource.ModelSubSegments.Rows[i]["ZHDJ"].ToString().Equals("正无穷大") ||
                            obj.Activitie.StructSource.ModelSubSegments.Rows[i]["ZHDJ"].ToString().Equals("负无穷大")) continue;
                    if (obj.Activitie.StructSource.ModelSubSegments.Rows[i]["XH"].ToString().Equals(APP.GoldSoftClient.TB_RESULT.Rows[j]["OLDXH"].ToString()) &&
                        obj.Activitie.StructSource.ModelSubSegments.Rows[i]["UnID"].ToString().Equals(APP.GoldSoftClient.TB_RESULT.Rows[j]["GCID"].ToString()))
                    {
                        row = obj.Activitie.StructSource.ModelSubSegments.Rows[i];
                        row.BeginEdit();
                        //row["ZJTJ"] = APP.GoldSoftClient.TB_RESULT.Rows[j][columnName];
                        
                        decimal.TryParse(APP.GoldSoftClient.TB_RESULT.Rows[j][columnName].ToString(), out jsCount);
                        decimal.TryParse(obj.Activitie.StructSource.ModelSubSegments.Rows[i]["ZHDJ"].ToString(), out zhdj);
                        rate = jsCount / zhdj;
                        //rate = decimal.Parse(APP.GoldSoftClient.TB_RESULT.Rows[j][columnName].ToString()) / decimal.Parse(obj.Activitie.StructSource.ModelSubSegments.Rows[i]["ZHDJ"].ToString());
                        row["ZHDJ"] = APP.GoldSoftClient.TB_RESULT.Rows[j][columnName];
                        row.EndEdit();
                        qdID = int.Parse(obj.Activitie.StructSource.ModelSubSegments.Rows[i]["ID"].ToString());
                        rows = obj.Activitie.StructSource.ModelQuantity.Select("QDID = " + qdID);
                        for (int n = 0; n < rows.Length; n++)
                        {
                            if (!decimal.TryParse(rows[n]["XHL"].ToString(), out oResult)) continue;
                            rows[n].BeginEdit();
                            rows[n]["XHL"] = Math.Round(oResult * rate , 4);
                            rows[n].EndEdit();
                        }
                    }
                }
            }

            //APP.GoldSoftClient.TB_RESULT.Columns.Remove(columnName);

            this.Close();

        }

        private void BeginAnalyze4_FormClosing(object sender, FormClosingEventArgs e)
        {
            APP.GoldSoftClient.TB_RESULT = null;
        }
    }
}