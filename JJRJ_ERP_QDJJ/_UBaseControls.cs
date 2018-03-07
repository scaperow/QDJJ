using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class _UBaseControls : Component
    {
        public _UBaseControls()
        {
            InitializeComponent();
        }

        public _UBaseControls(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void Init(_UnitProject p_UnitProject)
        {
            //初始化清单
            this.listGallery1.Folder = APP.Application.Global.AppFolder;
            this.listGallery1.Default = p_UnitProject;
            //为清单控件添加双击事件
            /*this.Ctrl_ListGallery.treeList1.DoubleClick -= new EventHandler(treeList1_DoubleClick);
            this.Ctrl_ListGallery.treeList1.DoubleClick += new EventHandler(treeList1_DoubleClick);
            this.Ctrl_ListGallery.listBoxControl1.DoubleClick -= new EventHandler(listBoxControl1_DoubleClick);
            this.Ctrl_ListGallery.listBoxControl1.DoubleClick += new EventHandler(listBoxControl1_DoubleClick);*/

            //初始化定额
            this.fixedLibrary1.Folder = APP.Application.Global.AppFolder;
            this.fixedLibrary1.Default = p_UnitProject;
            /*this.Ctrl_FixedLibrary.listBoxControl2.DoubleClick -= new EventHandler(listBoxControl2_DoubleClick);
            this.Ctrl_FixedLibrary.listBoxControl2.DoubleClick += new EventHandler(listBoxControl2_DoubleClick);*/
        }
    }
}
