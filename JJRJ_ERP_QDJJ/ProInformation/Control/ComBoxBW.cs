using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using GLODSOFT.QDJJ.BUSINESS;
using System.Data;
using System.IO;

namespace GOLDSOFT.QDJJ.UI
{
    public class ComBoxBW : RepositoryItemComboBox
    {
        private static string filePath = APP.Application.Global.AppFolder.FullName + "库文件\\用户价格库";
        private static string fileName = string.Format("{0}\\{1}", filePath, APP.GoldSoftClient.GlodSoftDiscern.CurrNo + ".SZBW");
        public ComBoxBW()
            : base()
        {

            this.PopupFormSize = new System.Drawing.Size(0, 600);
            if (APP.Application == null) return;
            if (APP.Application.Global == null) return;
            if (APP.Application.Global.DataTamp == null) return;
            DataSet ds = APP.Application.Global.DataTamp.工程信息表;
            if (ds == null || ds.Tables.Count < 1)
                ds = APP.Application.Global.DataTamp.安装专业工程信息表;
            if (ds == null) return;
            if (ds.Tables["所在部位"] == null) return;


            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        this.Items.Add(line);
                    }
                    reader.Close();
                }

            }

            DataTable dt = ds.Tables["所在部位"];
            foreach (DataRow item in dt.Rows)
            {
                this.Items.Add(item["BWMC"]);
            }

        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ComBoxBW
            // 
            //this.PopupFormMinSize = new System.Drawing.Size(0, 600);
            //this.EditValueChanged += new System.EventHandler(this.ComBoxBW_EditValueChanged_1);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private void ComBoxBW_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ComBoxBW_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MsgBox.Alert("自己写的值");
        }

        public void SaveCusotmerValue(string value)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new Exception("需要提供包括路径的文件名");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            this.Items.Insert(0, value);
            StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8);
            sw.WriteLine(value); 
            sw.Close(); 

        }


    }
}
