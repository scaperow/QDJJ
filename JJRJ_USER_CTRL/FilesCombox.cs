using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;

namespace GOLDSOFT.QDJJ.CTRL
{
    public class FilesCombox : DevExpress.XtraEditors.ComboBoxEdit
    {


        public void doLoadData(string m_DirName, string ExtName)
        {
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            string s_path = string.Format("{0}{1}{2}", AppDomain.CurrentDomain.BaseDirectory, "库文件\\", m_DirName);
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(s_path);
            System.IO.FileInfo[] fi = info.GetFiles(ExtName, System.IO.SearchOption.TopDirectoryOnly);
            foreach (System.IO.FileInfo file in fi)
            {
                CList list = new CList();
                list.DisplayName = file.Name;
                list.value = file.FullName;
                this.Properties.Items.Add(list);
            }
        }
       

    }
}
