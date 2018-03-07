using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Docking;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using System.IO;
using GOLDSOFT.QDJJ.CTRL;

namespace GOLDSOFT.QDJJ.UI.Controls
{
    public class XtrDockManagerEx : DockManager
    {
        /// <summary>
        /// 是否完成了首次视图界面的初始化工作
        /// </summary>
        private bool isInit = false;

        /// <summary>
        /// 默认布局文件
        /// </summary>
        private string defaultFile
        {
            get
            {
               return string.Format("{0}Layout\\default.xml",APP.Application.Global.AppFolder.FullName);
            }
        }

        /// <summary>
        ///保存用户的操作布局 
        /// </summary>
        private string userFile
        {
            get
            {
                return string.Format("{0}Layout\\My.xml", APP.Application.Global.AppFolder.FullName);
            }
        }

        public XtrDockManagerEx(System.ComponentModel.IContainer container)
            : base(container)
        {
 
        }

        /// <summary>
        /// 加载或者恢复默认布局设置
        /// </summary>
        public void DefaultLayout()
        {
            this.RestoreLayoutFromXml(this.defaultFile);
        }

        /// <summary>
        /// 保存用户的操作布局
        /// </summary>
        public void SaveLayout()
        {
            this.SaveLayoutToXml(this.userFile);
        }

        /// <summary>
        /// 加载用户布局操作
        /// </summary>
        public void LoadLayout()
        {
            this.RestoreLayoutFromXml(this.userFile);
        }

        /// <summary>
        /// 初始化界面的布局操作(初始化默认布局操作单位工程 一般在选项卡第一次创建时候执行此操作)
        /// </summary>
        public void Init()
        {
            //如果存在用户自定义布局则加载用户否则默认布局读取
            if (!this.isInit)
            {
                FileInfo file = new FileInfo(this.userFile);
                if (file.Exists)
                {
                    this.LoadLayout();
                }
                else
                {
                    this.DefaultLayout();
                }
                this.isInit = true;
            }
        }

        /// <summary>
        /// 创建项目或者单项工程时候初始化
        /// </summary>
        public void InitProject()
        {
            //无论何时设置此处显示项目清单
            this.Panels["dp_Functions"].Visibility = DockVisibility.Visible;
            this.Panels["dp_project"].Visibility = DockVisibility.Visible;
        }

        /// <summary>
        /// 关闭的时候处理
        /// </summary>
        public void Close()
        {
            foreach (DockPanel panel in this.Panels)
            {
                panel.Visibility = DockVisibility.Hidden;
                panel.Controls.Clear();
            }
        }
    }
}
