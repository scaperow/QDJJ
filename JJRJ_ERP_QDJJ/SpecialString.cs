using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors.Controls;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class SpecialString : DevExpress.XtraEditors.XtraForm
    {
        private string[] str = { "①","②","③","④","⑤","⑥","⑦","⑧","⑨","⑩","≤","≥","÷","±","≈","≠","Φ","Ω","π","∑","‰","℃","￥","㎡","ⅰ","ⅱ","ⅲ","ⅳ","ⅴ","ⅵ","ⅶ","ⅷ","ⅸ","ⅹ","√","∞","Ⅰ","Ⅱ","Ⅲ","Ⅳ","Ⅴ","Ⅵ","Ⅶ","Ⅷ","Ⅸ","Ⅹ","Ⅺ","Ⅻ","⑴","⑵","⑶","⑷","⑸","⑹","⑺","⑻","⑼","⑽","⑾","⑿","α","β","γ","δ","ε","ζ","η","θ","ξ","σ","ρ","τ","￡","§","μ","υ","λ","д","г","ω","∵","∴","∠","※","↑","↓","←","→","【","】","〖","〗","★","☆","●","◎","～"};
        
        public SpecialString()
        {
            InitializeComponent();
            load();
        }

        private void XtraForm11_Load(object sender, EventArgs e)
        {

        }

        private void load()
        {
            this.Width = 284;
            this.Height = 284;
            int top = 12;
            int left = 12;
            Size m_Size = new Size(20, 20);
            for (int i = 0; i < str.Length; i++)
            {
                SimpleButton m_SimpleButton = new SimpleButton();
                m_SimpleButton.ButtonStyle = BorderStyles.HotFlat;
                m_SimpleButton.Location = new Point(left, top);
                m_SimpleButton.Name = "simpleButton" + i;
                m_SimpleButton.Size = m_Size;
                m_SimpleButton.TabIndex = 0;
                m_SimpleButton.Text = str[i];
                m_SimpleButton.Click += new System.EventHandler(simpleButton_Click);
                this.Controls.Add(m_SimpleButton);
                left += 26;
                if (left >= this.Width - 26)
                {
                    left = 12;
                    top += 26;
                }
                if (top >= this.Height - 38)
                {
                    this.Height += 22;
                }
            }
        }

        private void simpleButton_Click(object sender, EventArgs e)
        {
            SimpleButton m_SimpleButton = sender as SimpleButton;
            if (m_SimpleButton != null)
            {
                SendKeys.SendWait(m_SimpleButton.Text);
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();//获得当前活动窗体
        [DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr hwnd);//设置活动窗体

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x21)
            {
                m.Result = new IntPtr(3);
                return;
            }
            else if (m.Msg == 0x086)
            {
                if (((int)m.WParam & 0xFFFF) != 0)
                {

                    if (m.LParam != IntPtr.Zero)
                    {
                        SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
}