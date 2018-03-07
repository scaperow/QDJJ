/*
 * 容器业务所使用的组件集
 * 项目使用
 * 项目清单 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GOLDSOFT.QDJJ.CTRL;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class _PBaseControls : Component
    {
        public _PBaseControls()
        {
            InitializeComponent();
        }

        public _PBaseControls(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
