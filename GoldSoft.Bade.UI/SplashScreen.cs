using GoldSoft.Common.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GoldSoft.Bade.UI
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            ThreadPool.QueueUserWorkItem(delegate
            {

                var result = Softdog.ValidateLocal();
                if (result.Success)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.Enabled = true;
                        this.Cursor = Cursors.Default;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }));
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.Enabled = true;
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(result.Message);
                    }));
                }
            });
        }

        private void ButtonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            

        }
    }
}
