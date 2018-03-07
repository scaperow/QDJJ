using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.Linq;
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    /// <summary>
    /// 增加补充人材机
    /// </summary>
    public partial class InsertRepairQuantityUnit : CBaseForm
    {
        /// <summary>
        /// 创建一个新工料机
        /// </summary>
        private DataRow new_info = null;
        /// <summary>
        /// 名称
        /// </summary>
        private string m_mc = string.Empty;
        /// <summary>
        /// 类别
        /// </summary>
        private string m_lb = string.Empty;

        private bool m_isSave = true;


        public DataRow New_Row
        {
            get { return new_info; }
        }

        public bool IS_SAVE
        {
            get { return m_isSave; }
            set { m_isSave = value; }
        }

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string MC
        {
            get { return m_mc; }
            set
            {
                m_mc = value;
                this.textEdit2.Text = APP.RepairQuantityUnit.GetMC(m_mc);
            }
        }
        /// <summary>
        /// 获取或设置类别
        /// </summary>
        public string LB
        {
            get { return m_lb; }
            set
            {
                m_lb = value;
                this.comboBoxEdit1.EditValue = m_lb;
                //if (m_lb == "主材" || m_lb == "设备")
                //{
                //    this.calcEdit1.Enabled = false;
                //}
                if(this.m_isSave)
                    this.textEdit1.Text = APP.RepairQuantityUnit.GetRepairBH();
                else
                    this.textEdit1.Text = APP.RepairQuantityUnit.GetRepairBH(this.Activitie);
            }
        }

        public InsertRepairQuantityUnit()
        {
            InitializeComponent();
        }

        private void InsertRepairQuantityUnit_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            m_mc = string.Empty;
            m_lb = string.Empty;
            this.new_info = this.GetNewInfo();
            if (!APP.RepairQuantityUnit.BH_Exist(this.Activitie, textEdit1.Text.Trim(), this.m_isSave))
            {
                MsgBox.Alert("编号为:" + this.textEdit1.Text.Trim() + " 已经存在");
                this.textEdit1.Focus();
                return;
            }
            if (!APP.RepairQuantityUnit.Data_Exist(this.Activitie, new_info["MC"].ToString(), new_info["DW"].ToString(), new_info["SCDJ"].ToString(), this.m_isSave))
            {
                MsgBox.Alert("名称为:" + new_info["MC"].ToString() + " 单位为:" + new_info["DW"].ToString() + " 市场单价为:" + new_info["SCDJ"].ToString() + "的数据已经存在");
                this.textEdit1.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 入库选择 入库：生成库内有序编号 不入：生成当前项目有序编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                this.m_isSave = true;
                this.textEdit1.Text = APP.RepairQuantityUnit.GetRepairBH();
                this.comboBoxEdit1.SelectedIndexChanged -= new EventHandler(comboBoxEdit1_SelectedIndexChanged);
            }
            else
            {
                this.m_isSave = false;
                this.textEdit1.Text = APP.RepairQuantityUnit.GetRepairBH(this.Activitie, this.comboBoxEdit1.Text.Trim());
                this.comboBoxEdit1.SelectedIndexChanged += new EventHandler(comboBoxEdit1_SelectedIndexChanged);
            }
        }

        /// <summary>
        /// 生成编号前缀 只运用于不入库产生 为类别前缀
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 1)
            {
                this.textEdit1.Text = APP.RepairQuantityUnit.GetRepairBH(this.Activitie, this.comboBoxEdit1.Text.Trim());
            }
            //if (comboBoxEdit1.Text == "主材" || comboBoxEdit1.Text == "设备")
            //{
            //    calcEdit1.Enabled = false;
            //}
            //else
            //{
            //    calcEdit1.Enabled = true;
            //}
        }

        /// <summary>
        /// 添加补充工料机
        /// </summary>
        public DataRow GetNewInfo()
        {
            this.new_info = this.Activitie.StructSource.ModelQuantity.NewRow();
            this.new_info["YSBH"] = this.textEdit1.Text;
            this.new_info["YSMC"] = this.textEdit2.Text.Trim();
            this.new_info["YSDW"] = this.comboBoxEdit2.Text.Trim();
            this.new_info["YSXHL"] = 1m;
            this.new_info["DEDJ"] = this.calcEdit1.Value;
            this.new_info["BH"] = this.new_info["YSBH"];
            this.new_info["MC"] = this.new_info["YSMC"];
            this.new_info["DW"] = this.new_info["YSDW"];
            this.new_info["SL"] = 1m;
            this.new_info["LB"] = this.comboBoxEdit1.Text.Trim();
            this.new_info["IFZYCL"] = true;
            this.new_info["GGXH"] = this.textEdit7.Text.Trim();
            this.new_info["XHL"] = this.new_info["YSXHL"];
            this.new_info["SCDJ"] = this.new_info["DEDJ"];
            this.new_info["SSDWGC"] = this.Activitie.Name;
            this.new_info["SSKLB"] = this.Activitie.PrfType;
            return new_info;
        }
    }
}