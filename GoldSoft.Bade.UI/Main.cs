using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils.Drawing;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using GoldSoft.Bade.UI;

namespace GoldSoft.Bade.UI
{


    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
            InitializeTreeList();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            SplashScreen splash = new SplashScreen();
            if (splash.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Visible = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void InitializeTreeList()
        {
            //this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            //this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //this.treeListColumn1.Caption = "项目编码";
            //this.treeListColumn1.FieldName = "XMBM";
            //this.treeListColumn1.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
            //this.treeListColumn1.Name = "treeListColumn1";
            //this.treeListColumn1.OptionsColumn.AllowSort = false;
            //this.treeListColumn1.Visible = true;
            //this.treeListColumn1.VisibleIndex = 0;
            //this.treeListColumn1.Width = 126;
            var codeColumn = new TreeListColumn()
            {
                Caption = "项目编码",
                FieldName = "QDBH",
                Fixed = FixedStyle.Left,
                Name = "codeColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 126
            };

            var seriazeColumn = new TreeListColumn()
            {
                Caption = "序号",
                FieldName = "XH",
                Fixed = FixedStyle.Left,
                Name = "seriazeColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 80
            };

            var nameColumn = new TreeListColumn()
            {
                Caption = "项目名称",
                FieldName = "QDMC",
                Fixed = FixedStyle.Left,
                Name = "nameColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 200
            };

            var unitColumn = new TreeListColumn()
            {
                Caption = "计量单位",
                FieldName = "DW",
                Fixed = FixedStyle.Left,
                Name = "unitColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 80
            };

            var quantityColumn = new TreeListColumn()
            {
                Caption = "工程数量",
                FieldName = "GCL",
                Name = "quantityColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 80
            };

            var cloudPriceColumn = new TreeListColumn()
            {
                Caption = "云报价标识",
                FieldName = "HasAppled",
                Name = "cloudPriceColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 80
            };

            var usePriceColumn = new TreeListColumn()
            {
                Caption = "采集标识",
                FieldName = "CanIdentity",
                Name = "usePriceColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 80
            };

            var complexPriceColumn = new TreeListColumn()
            {
                Caption = "组价方式",
                FieldName = "ResultForProgram",
                Name = "complexPriceColumn",
                Visible = true,
                VisibleIndex = 0,
                Width = 80
            };

            this.Tree.Columns.AddRange(new TreeListColumn[]{
                codeColumn,seriazeColumn,nameColumn,unitColumn,quantityColumn,cloudPriceColumn,usePriceColumn,complexPriceColumn
            });

            this.Tree.SelectionChanged += Tree_SelectionChanged;
            this.Tree.NodeCellStyle += Tree_NodeCellStyle;
            this.Tree.MouseClick += Tree_MouseClick;
        }

        void Tree_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MenusTree.ShowPopup(Cursor.Position);
            }
        }

        void Tree_SelectionChanged(object sender, EventArgs e)
        {
            if (this.Tree.Selection.Count == 0)
            {
                MenuToggle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            if (this.Tree.Selection.Count == 1)
            {
                MenuToggle.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                var node = this.Tree.Selection[0];
                MenuToggle.Caption = node.Expanded ? "折叠" : "展开";
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void ButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        private void ButtonOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void ButtonCloudAnalysis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        //void Identity_IdentityOneCompleted(object sender, IdentityResultArgs e)
        //{
        //    return;
        //    this.Invoke(new MethodInvoker(delegate
        //    {
        //        foreach (TreeListNode node in Tree.Nodes)
        //        {

        //            var record = this.Tree.GetDataRecordByNode(node) as Excels;
        //            if (record != null && record.ID == e.Excel.ID)
        //            {
        //                var builder = new StringBuilder();
        //                for (var i = 0; i < e.Excel.RulesMatched.Count; i++)
        //                {
        //                    builder.Append(e.Excel.RulesMatched[i].Pick("DEBH")["DEBH"] + ",,|");
        //                }

        //                builder.Append("@");

        //                if (record.State == IdentityResultStateEnum.Success)
        //                {
        //                    record.ResultForProgram = builder.ToString();
        //                }
        //            }
        //        }
        //    }));

        //}

        void Identity_IdentityAllCompleted(object sender, EventArgs e)
        {
          
        }


        private void ButtonApplyToCurrent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        
        }

        private void ButtonApplyToEmpty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
        }

        private void ButtonApplyToAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
       
        }

        private void StartReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Tree_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
          
        }

        private void MenuToggle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (this.Tree.Selection.Count == 1)
            {
                var node = this.Tree.Selection[0];
                node.Expanded = !node.Expanded;
            }

        }

        private void MenuOpenAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Tree.Selection.Count == 0 || this.Tree.Selection.Count == 1)
            {
                this.Tree.ExpandAll();
            }
            else
            {
                foreach (TreeListNode node in this.Tree.Selection)
                {
                    node.Expanded = true;
                }
            }
        }

        private void FoldAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.Tree.Selection.Count == 0 || this.Tree.Selection.Count == 1)
            {
                this.Tree.CollapseAll();
            }
            else
            {
                foreach (TreeListNode node in this.Tree.Selection)
                {
                    node.Expanded = false;
                }
            }
        }
    }
}
