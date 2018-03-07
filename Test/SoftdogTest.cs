using GoldSoft.Common.Model;
using GoldSoft.Common.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class SoftdogTest : Form
    {
        public SoftdogTest()
        {
            InitializeComponent();
        }

        private void ButtonValidateHardware_Click(object sender, EventArgs e)
        {
            var result = Softdog.ValidateLocal();
            if (result.Error)
            {
                MessageBox.Show(result.Message);
                return;
            }

            

            //var result2 = JsonConvert.DeserializeObject<JObject>(result.ToString());
            //if (protocol == null)
            //{
            //    MessageBox.Show("系统异常");
            //    return;
            //}

            //if (protocol.Error)
            //{
            //    MessageBox.Show(protocol.Message);
            //    return;
            //}

            MessageBox.Show("验证成功");
        }
    }
}
