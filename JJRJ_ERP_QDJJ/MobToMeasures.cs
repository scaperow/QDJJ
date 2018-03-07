using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class MobToMeasures : BaseForm
    {
        public MobToMeasures()
        {
            InitializeComponent();
        }


      
        /// <summary>
        /// 选择措施项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MeasuresSelectForm form = new MeasuresSelectForm();
            form.Activitie = this.Activitie;
            DialogResult dl = form.ShowDialog();
            if (dl==DialogResult.OK)
            {
                DataRowView info = form.bindingSource1.Current as DataRowView;
                this.textEdit1.Tag = info;
                this.textEdit1.Text = info["XMMC"].ToString();
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataRowView info0 = this.textEdit1.Tag as DataRowView;
            if (info0 == null) return;
            _Entity_SubInfo info = new _Entity_SubInfo();
            _ObjectSource.GetObject(info, info0.Row);
            _Mothods_MFixed fix = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, info);
            _Entity_SubInfo sinfo = new _Entity_SubInfo();
            //_FixedListInfo info1 = null;
            _Methods_Subheadings subfix = new _Methods_Subheadings(this.CurrentBusiness, this.Activitie, null);
            if (info != null)
            {
                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    foreach (DataRowView item in this.bindingSource1)
                    {
                        _ObjectSource.GetObject(sinfo, item.Row);
                        // subfix.Current = sinfo;
                        // subfix.Begin();
                        var entity = fix.Create(-1, sinfo);
                        entity.BEIZHU = sinfo.BEIZHU;

                        DataRow[] rows1 = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}", sinfo.ID, sinfo.SSLB));
                        for (int i = 0; i < rows1.Length; i++)
                        {
                            rows1[i].Delete();
                        }

                        DataRow[] rows = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}", item["ID"], item["SSLB"]));
                        for (int i = 0; i < rows.Length; i++)
                        {
                            rows[i]["QDID"] = sinfo.PID;
                            rows[i]["ZMID"] = sinfo.ID;
                            rows[i]["SSLB"] = sinfo.SSLB;
                        }

                        //item["SC"] = false;
                        DataRow r = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(item["ID"].ToString());
                        if (r != null)
                        {
                            _Entity_SubInfo sinfo1 = new _Entity_SubInfo();
                            _ObjectSource.GetObject(sinfo1, r);
                            subfix.Current = sinfo1;
                            subfix.Begin(null);
                            calculator.Entities.Add(sinfo1);
                            calculator.CalculateFinish += new EventHandler(delegate(object o, EventArgs handler)
                            {
                                r["SC"] = false;
                            });
                        }
                    }

                    calculator.Entities.Add(info);
                }

                this.Close();
            }
        }

       
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MobToMeasures_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            IEnumerable<DataRow> infos = from info in this.Activitie.StructSource.ModelSubSegments.AsEnumerable()
                                             where info.RowState!=DataRowState.Deleted&& info["TX"].Equals("模板")&& this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}",info["ID"],info["SSLB"])).Length>0
                                             select info;

            DataRow[] rows = infos.ToArray();
            if(rows.Length>0)
                this.bindingSource1.DataSource = rows.CopyToDataTable();
            //SetQDBM();
            this.treeList1.DataSource = this.bindingSource1;
            
        }
        //private void SetQDBM()
        //{
        //    foreach (da item in this.bindingSource1)
        //    {
        //        item.QDBH = item.Parent.XMBM;
        //    }
        //}
    }
}
