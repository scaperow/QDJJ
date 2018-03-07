using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using GOLDSOFT.QDJJ.BUSINESS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class IncreaseCostsInfoList : BaseForm
    {
        public IncreaseCostsInfoList()
        {
            InitializeComponent();
           
        }
        private _Entity_SubInfo m_CurObj;
        /// <summary>
        /// 当前的子目对象
        /// </summary>
        public _Entity_SubInfo CurObj
        {
            get { return m_CurObj; }
            set { m_CurObj = value; }
        }
        public void DoFilter(_Entity_SubInfo info)
        {
            this.m_CurObj = info;
            if (this.bindingSource1.DataSource == null)
            {
                this.bindingSource1.DataSource = this.Activitie.StructSource.ModelIncreaseCosts.DefaultView;
                this.gridControl1.DataSource = bindingSource1;
            }
            this.bindingSource1.Filter = string.Format("ZMID={0} and SSLB={1}",this.m_CurObj.ID,this.m_CurObj.SSLB);
           
        }
        private void IncreaseCostsInfoList_Load(object sender, EventArgs e)
        {
            this.bindingSource1.DataSource = this.Activitie.StructSource.ModelIncreaseCosts.DefaultView;
            this.gridControl1.DataSource = bindingSource1;
        }
        /*public override void Refresh()
        {
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
            base.Refresh();
        }*/

        public override void GlobalStyleChange()
        {
            this.gridView1.SchemeColor = APP.DataObjects.GColor.UseColor.Current();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Refresh();
        }
        public override void LockActivitie()
        {
            if (this.Activitie == null) return;
            if (!this.Activitie.IsLock)
            {
                this.gridView1.OptionsBehavior.Editable = false;
            }
            else
            {
                this.gridView1.OptionsBehavior.Editable = true;
            }
        }

     
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            switch (e.Item.Caption)

            {
                case "选择增加费":
                    IncreaseCostsSelect s = new IncreaseCostsSelect();
                    s.Activitie = this.Activitie;
                    s.DataSource = this.Activitie.Property.IncreaseCosts.DataSource.Copy();
                    s.CurObj = this.m_CurObj;
                    DialogResult d = s.ShowDialog();
                    if (d == DialogResult.OK)
                    {
                        // (this.m_CurObj as _SubheadingsInfo).IncreaseCostsList.a
                        foreach (DataRowView item in s.treeListEx1.CheckNodes)
                        {
                           DataRow[]  rows=this.Activitie.StructSource.ModelIncreaseCosts.Select(string.Format("ZMID={0} and SSLB={1}",this.m_CurObj.ID,this.m_CurObj.SSLB));
                           if (IsEsixtZJF(rows, item["Code"].ToString()))
                            {
                                _Entity_IncreaseCosts info1 = new _Entity_IncreaseCosts();
                                _Method_IncreaseCosts.SetInfo(item.Row, info1);
                                info1.EnID = this.m_CurObj.EnID;
                                info1.UnID = this.m_CurObj.UnID;
                                info1.ZMID = this.m_CurObj.ID;
                                info1.QDID = this.m_CurObj.PID;
                                this.Activitie.StructSource.ModelIncreaseCosts.Add(info1);
                                _Methods_IncreaseInfo minfo = new _Methods_IncreaseInfo(this.Activitie, info1);
                                minfo.CurrentBegin(this.m_CurObj);//计算当前行
                            }
                        }
                    }
                    break;
                case "删除增加费":
                    if (this.bindingSource1.Current == null) return;
                    this.bindingSource1.RemoveCurrent();
                    break;
                default:
                    break;
            }
            
            
        }
        private bool IsEsixtZJF(DataRow[] infos, string Code)
        {
            bool flag = true;
            foreach (DataRow item in infos)
            {
                if (item["DH"].Equals(Code))
                {
                    return false;
                }

            }
            return flag;
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView v = this.bindingSource1.Current as DataRowView;
            if (v == null) return;
            _Entity_IncreaseCosts info = new _Entity_IncreaseCosts();
            _ObjectSource.GetObject(info, v.Row);
            _Methods_IncreaseInfo met = new _Methods_IncreaseInfo(this.Activitie, info);
            met.CurrentBegin(this.CurObj);
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            GridControl gv = sender as GridControl;

            BaseHitInfo hi = gv.FocusedView.CalcHitInfo(e.Location);
            
            if (e.Button == MouseButtons.Right)
            {
                if (CurObj != null)
                {
                    if (CurObj.LB.Equals("子目-增加费"))
                    {
                        if (this.Activitie == null) return;
                        if (this.Activitie.IsLock) this.popupMenu1.ShowPopup(Control.MousePosition);
                    }
                }
            }

        }

    }
}
