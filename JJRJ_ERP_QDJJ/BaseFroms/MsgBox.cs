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
    public partial class MsgBox : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 缓存提示框对象
        /// </summary>
        private static MsgBox MyMsgBox = new MsgBox();

        /// <summary>
        /// 显示提示框对象
        /// </summary>
        /// <param name="p_Text"></param>
        /// <param name="p_Buttons"></param>
        /// <returns></returns>
        public static DialogResult Alert(string p_Text)
        {
            MyMsgBox.TText = p_Text;
            MyMsgBox.Buttons = MessageBoxButtons.OK;
            MyMsgBox.Visible = false;
            return MyMsgBox.ShowDialog();
        }

        /// <summary>
        /// 显示提示框对象
        /// </summary>
        /// <param name="p_Text"></param>
        /// <param name="p_Buttons"></param>
        /// <returns></returns>
        public static DialogResult Show(string p_Text, MessageBoxButtons p_Buttons)
        {
            MyMsgBox.TText = p_Text;
            MyMsgBox.Buttons = p_Buttons;
            MyMsgBox.Visible = false;
            return MyMsgBox.ShowDialog();
        }
        
        private MessageBoxButtons m_Buttons = MessageBoxButtons.OK;

        /// <summary>
        /// 默认选项
        /// </summary>
        public MessageBoxButtons Buttons
        {
            get
            {
                return m_Buttons;
            }
            set
            {
                m_Buttons = value;
            }
        }

        /// <summary>
        /// 需要显示的文本
        /// </summary>
        public string TText
        {
            get
            {
                return this.lbl_Text.Text;
            }
            set
            {
                this.lbl_Text.Text = value;
               // this.labelControl1.Text = value;
            }
        }
        MessageBoxButtons p_MessageBoxButtons = MessageBoxButtons.OK;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            switch (this.m_Buttons)
            {
                case MessageBoxButtons.YesNoCancel:
                    this.P_YES_NO.Visible = true;
                    this.P_OK.Visible = false;
                    this.p_OK_Cencel.Visible = false;
                    this.Text = "金建软件-询问";
                    this.AcceptButton = simpleButton4;
                    break;
                case MessageBoxButtons.OKCancel:
                    simpleButton1.Click += new EventHandler(simpleButton1_Click_OK);
                    p_OK_Cencel_Cencel.Click += new EventHandler(p_OK_Cencel_Cencel_Click_Cencel);
                    this.P_YES_NO.Visible = false;
                    this.P_OK.Visible = false;
                    this.p_OK_Cencel.Visible = true;
                    this.Text = "金建软件-询问";
                    this.AcceptButton = simpleButton1;
                    break;
                case MessageBoxButtons.YesNo:
                    simpleButton1.Click += new EventHandler(simpleButton1_Click_Yes);
                    p_OK_Cencel_Cencel.Click += new EventHandler(p_OK_Cencel_Cencel_Click_No);
                    this.P_YES_NO.Visible = false;
                    this.P_OK.Visible = false;
                    this.p_OK_Cencel.Visible = true;
                    this.Text = "金建软件-询问";
                    this.AcceptButton = simpleButton1;
                    break;
                default:
                    this.P_YES_NO.Visible = false;
                    this.P_OK.Visible = true;
                    this.p_OK_Cencel.Visible = false;
                    this.Text = "金建软件-提示";
                    this.AcceptButton = P_OK_OK;
                    break;
                    
            }
        }

        /// <summary>
        /// 确定取消no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p_OK_Cencel_Cencel_Click_No(object sender, EventArgs e)
        {
            p_OK_Cencel_Cencel.Click -= new EventHandler(p_OK_Cencel_Cencel_Click_No);
            this.DialogResult = DialogResult.No;
        }

        /// <summary>
        /// 确定取消yes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void simpleButton1_Click_Yes(object sender, EventArgs e)
        {
            simpleButton1.Click -= new EventHandler(simpleButton1_Click_Yes);
            this.DialogResult = DialogResult.Yes;
        }


        /// <summary>
        /// 确定取消Cencel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p_OK_Cencel_Cencel_Click_Cencel(object sender, EventArgs e)
        {
            p_OK_Cencel_Cencel.Click -= new EventHandler(p_OK_Cencel_Cencel_Click_Cencel);
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 确定取消Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void simpleButton1_Click_OK(object sender, EventArgs e)
        {
            simpleButton1.Click -= new EventHandler(simpleButton1_Click_OK);
            this.DialogResult = DialogResult.OK;
        }

        public MsgBox()
        {
            InitializeComponent();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void P_OK_OK_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Yes;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void P_OK_OK_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void lbl_Text_SizeChanged(object sender, EventArgs e)
        {
            /*int w = 300;//基础宽
            //设置窗体宽度
            if (this.lbl_Text.Width > this.Width - this.lbl_Text.Left)
            {
                this.Width = this.lbl_Text.Width + this.lbl_Text.Left+20;
            }
            else
            {
                this.Width = w + 20;
            }*/
           /* this.Width = 260;
            this.Height = 130;
            this.panelControl1.Width = this.lbl_Text.Width+5;
            this.panelControl1.Height = this.lbl_Text.Height+5;
            this.Width = this.lbl_Text.Width + this.lbl_Text.Left + 20;*/
        }

        private void MsgBox_VisibleChanged(object sender, EventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                this.Width = 260;
                this.Height = 90;
                //this.panelControl1.Width = this.labelControl1.Width + 5;
                //this.panelControl1.Height = this.labelControl1.Height + 5;

             int  m=   this.lbl_Text.Text.Length * 14;
             if (m < 220)
             {
                 m = 220;
             }
             this.Width = m;
            }
        }

        private void MsgBox_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);

            int l = rect.Width;
            int t = rect.Height;
            //int l = Screen.PrimaryScreen.WorkingArea.Width;
            //int t = Screen.PrimaryScreen.WorkingArea.Height;
            this.Left = (l - this.Width) / 2;
            this.Top = (t - this.Height) / 2;
        }

    }
}