using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using System.IO;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CHistoryForm : ABaseForm
    {

        public CHistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重写的初始化(每次打开执行)
        /// </summary>
        public override void Init()
        {
            base.Init();
        }

        private void CHistoryForm_Load(object sender, EventArgs e)
        {
            //第一次加载的时候执行
            this.ctrlHistory1.DataSource = this.Activitie.Property.History;
            this.ctrlHistory1.DataBind();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //为还原单位工程的事件处理
            //1.读取备份项目文件
            //2.当前的单位工程设置为获取的单位工程
            /*string path = string.Format("{0}{1}{2}", APP.Application.Global.AppFolder.FullName, APP.Application.Global.Configuration.Path_Temporary_UnitProject, this.ctrlHistory1.Current);
            CResult result = APP.Methods.Restitute(path, this.Activitie);
            if (!result.Success)
            {
                Alert(result.ErrorInformation);
            }*/
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //扫描历史文件是否存在
            foreach (DataRow row in this.ctrlHistory1.DataSource.HistoryTable.Rows)
            {
                string ph = row["FileName"].ToString();
                string path = string.Format("{0}{1}{2}", APP.Application.Global.AppFolder.FullName, APP.Application.Global.Configuration.Path_Temporary_UnitProject, ph);
                //循环查询是否存在对象
                FileInfo file = new FileInfo(path);
                row.BeginEdit();
                row["IsUse"] = file.Exists;
                row.EndEdit();
            }
        }
    }
}