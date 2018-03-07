/*
 工程信息操作界面
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CInformationForm : ABaseForm
    {
        public CInformationForm()
        {
            InitializeComponent();
        }

        private void CInformationForm_Load(object sender, EventArgs e)
        {
            this.initEvent();
            this.initFrom();
        }

        private void initEvent()
        {
            this.informationList1.bindingSource1.PositionChanged += new EventHandler(bindingSource1_PositionChanged);
            this.property1.ChangeName += new GOLDSOFT.QDJJ.CTRL.Property.ChangeNameHandler(property1_ChangeName);
        }

        /// <summary>
        /// 如果name属性发生变化的时候激发
        /// </summary>
        /// <param name="row"></param>
        void property1_ChangeName(DataRow row)
        {
            DataRowView r = this.informationList1.bindingSource1.Current as DataRowView;
            r.BeginEdit();
            r["Name"] = row["Value"];
            r.EndEdit();

        }

        /// <summary>
        /// 当主列表数据源选择发生变化时候激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
           /* initButton();
            BindingSource bs = sender as BindingSource;
            DataRowView row = bs.Current as DataRowView;
            if (row != null)
            {
                string key = row["ID"].ToString();
                if (this.informationList1.treeList1.Selection[0] == null) return;
                int lev = this.informationList1.treeList1.Selection[0].Level;
                if (key != "0")
                {
                   

                    if (lev == 1)
                    {
                        this.property1.DataSource = APP.General.Activitie.Informations.Attributes;
                        this.property1.Key = key;
                        this.property1.DataMember = "基础属性表";
                        this.property1.DataBind();
                    }
                    if(lev == 2)
                    {
                        this.property1.DataSource = APP.General.Activitie.Informations.Attributes;
                        this.property1.Key = key;
                        this.property1.DataMember = "属性表";
                        this.property1.DataBind();
                    }
                }
            }*/
        }

        private void initButton()
        {
            if (this.informationList1.treeList1.Selection[0] == null) return;
            int lev = this.informationList1.treeList1.Selection[0].Level;
            //如果选择不是根结点
            
                switch(lev)
                {   
                    case 1://1级节点不可删除
                        this.simpleButton1.Enabled = true;
                        this.simpleButton2.Enabled = false;
                    break;
                    case 2:
                        this.simpleButton1.Enabled = true;
                        this.simpleButton2.Enabled = true;
                    break;
                    default:
                        this.simpleButton1.Enabled = false;
                        this.simpleButton2.Enabled = false;
                        break;
                }
            
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void initFrom()
        {
            //第一次打开窗体的时候初始化工程信息
            /*DataTable table = APP.General.GetGlobalDataTamp("Component");
            if (!APP.General.Activitie.Informations.IsInit)
            {
                APP.General.Activitie.Informations.Init(table);
            }
            //为数据进行绑定操作、
            this.informationList1.DataSource = APP.General.Activitie.Informations.Components;
            this.informationList1.DataBind();*/
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //添加新的结构
            /*if(this.informationList1.GetCurrKey  != -1)
            {
                APP.General.Activitie.Informations.Add(this.informationList1.GetCurrKey, this.informationList1.GetNewName);
            }*/
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //删除新添加的结构(基础结构不允许删除)
            /*if (this.informationList1.treeList1.Selection[0] != null)
            {
                //int key = this.informationList1.treeList1.Selection[0].Id;
                //APP.General.Activitie.Informations.Remove(key);

                DataRowView row = this.informationList1.bindingSource1.Current as DataRowView;
                row.BeginEdit();
                row.Delete();
                row.EndEdit();
                APP.General.Activitie.Informations.Components.AcceptChanges();
                APP.General.Activitie.Informations.Attributes.Tables["属性表"].AcceptChanges();
            }*/
        }
    }
}