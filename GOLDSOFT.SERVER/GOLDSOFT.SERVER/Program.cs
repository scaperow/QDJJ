﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GOLDSOFT.SERVER
{
    static class Program
    {
        public static Form1 form1;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);

        }
    }
}
