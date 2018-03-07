using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using System.Data;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI.Controls
{
    public class RepositoryItemComboBoxEx : RepositoryItemComboBox
    {
        public RepositoryItemComboBoxEx(string str,DataTable dt):base()
        {
            //this.DETB=DETB;
            this.DataSource = dt;
            if (!DataSource.Columns.Contains("TZMC"))
            {
                this.DataSource.Columns.Add("TZMC");
            }
           
            this.m_Source = str;
            this.DataBind();
        }
        
        private string m_Source = string.Empty;
        //private DataTable DETB;
        /// <summary>
        /// 获取或设置原始数据源
        /// </summary>
        public string Source
        {
            get
            {
                return this.m_Source;
            }
            set
            {
                this.m_Source = value;
            }
        }

        private DataTable m_DataSource = null;

        /// <summary>
        /// 获取或设置清单特征定额表原始数据源
        /// </summary>
        public DataTable DataSource
        {
            get
            {
                return this.m_DataSource;
            }
            set
            {
                this.m_DataSource = value;

            }
        }

        /// <summary>
        /// 根据原始数据源绑定数据列
        /// </summary>
        public void DataBind()
        {

            if(this.m_Source != string.Empty)
            {
                string[] str = this.m_Source.Split('|');

                for (int i = 0; i < str.Length; i++)
                {

                    ComboBoxSoucer cm = new ComboBoxSoucer();
                   
                    if (str[i]!="")
                    {
                        string [] TZstr= str[i].Split(',');
                        cm.TZname = TZstr[0];
                        if (TZstr.Length > 1)
                        {
                            DataRow[] dr = this.m_DataSource.Select(string.Format(" TZDEH='{0}'", TZstr[1]));
                            if (dr.Length > 0)
                            {
                                cm.DEBH = dr[0];
                                //dr[0]["TZMC"]=
                            }

                            this.Items.Add(cm);
                        }
                    }
                }
                //this.Items.Insert(0, new ComboBoxSoucer());
            }
            
           
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // RepositoryItemComboBoxEx
            // 
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }


    }
    public class ComboBoxSoucer
    {
       
        public string TZname;
        private DataRow m_DEBH;
        public DataRow DEBH
        { 
            get{return m_DEBH;}
            set{m_DEBH = value;}
        }

   
        public override string ToString()
        {
            return TZname;
        }
    }

}
