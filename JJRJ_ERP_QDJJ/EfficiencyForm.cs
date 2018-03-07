using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLODSOFT.QDJJ.BUSINESS;
using GOLDSOFT.QDJJ.COMMONS;
using System.Linq;
using System.Collections;
using ZiboSoft.Commons.Common;
namespace GOLDSOFT.QDJJ.UI
{
    public partial class EfficiencyForm : BaseForm
    {
        public EfficiencyForm()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void EfficiencyForm_Load(object sender, EventArgs e)
        {
            ////此处加条件判断是否含有安装增加费的专业 
            if (true)
            {
                init();
            }
        
        }
        private _Entity_SubInfo m_MFixed;
        /// <summary>
        /// 当前选中的措施清单
        /// </summary>
        public _Entity_SubInfo MFixed
        {
            get { return m_MFixed; }
            set { m_MFixed = value; }
        }

        private decimal RGDJ = 0m;
        private decimal QTJXDJ = 0m;
        private decimal DZJXDJ = 0m;
        private decimal JXDJ = 0m;
        private void init()
        {
             InitDJ();
            this.bindingSource1.DataSource = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Copy();
            dt = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"].Copy();
            if (!dt.Columns.Contains("fl"))
            {
                dt.Columns.Add("fl", typeof(double));
            }
            if (!dt.Columns.Contains("SCDJ"))
            {
                dt.Columns.Add("SCDJ", typeof(double));
            }
            if (dt.PrimaryKey.Length == 0)
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns["CAIJBH"] };
            }

            this.bindingSource2.DataSource = dt;
            this.bindingSource1.Sort = "TX2 asc";
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl2.DataSource = this.bindingSource2;
            B1Fiter();
            this.simpleButton1.Enabled = false;
        }

        decimal SetDJ(string str)
        {
            DataRow[] rows0 = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("LB = '子目' and  JX='True'"));
            DataRow[] rows1 = this.Activitie.StructSource.ModelMeasures.Select(string.Format("LB = '子目' and  JX='True'"));
            List<DataRow> r_list = new List<DataRow>();
            r_list.AddRange(rows0);
            r_list.AddRange(rows1);
            decimal d = 0m;
            foreach (var item0 in r_list)
            {
                DataRow[] rows = this.Activitie.StructSource.ModelQuantity.Select(string.Format("LB in ({0}) and  ZMID={1} and ZCLB='W'", str, item0["ID"]));
                foreach (DataRow item in rows)
                {
                    d += ToolKit.ParseDecimal(item["SCHJ"]) * ToolKit.ParseDecimal(item["GCL"]);
                }
            }
            return d;
        }
        private void InitDJ()
        {
            string Rg = "'人工','其他人工费'";
            string DZ = "'吊装机械','吊装机械台班'";
            string QT = "'机械','其他机械费','机械台班'";
           // string JX = "'机械','其他机械费','机械台班'";
            this.RGDJ = SetDJ(Rg);
            this.DZJXDJ = SetDJ(DZ);
            this.QTJXDJ = SetDJ(QT);
            this.JXDJ = this.DZJXDJ + this.QTJXDJ;
        }
        private void GetSCDJ()
        {
            string dian = "F4";
            foreach (DataRowView item in this.bindingSource2)
            {
                switch (item["CAIJMC"].ToString())
                {
                    case "人工降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.RGDJ.ToString(dian);
                        item.EndEdit();
                        break;
                    case "吊装机械降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.DZJXDJ.ToString(dian);
                        item.EndEdit();
                        break;

                    case "其他机械降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.QTJXDJ.ToString(dian);
                        item.EndEdit();
                        break;
                    case "机械降效":
                        item.BeginEdit();
                        item["SCDJ"] = this.JXDJ.ToString(dian);
                        item.EndEdit();
                        break;
                    default:
                        break;
                }

            }

        }

        /// <summary>
        /// 沿高层数取定额号15-1~15-11，15-23~15-31之间数据
        /// </summary>
        private void B1Fiter()
        {
            this.bindingSource1.Filter = "DINGEH in (" + _Constant.超高定额号 + ")";
            bindingSource1_PositionChanged(null,null);
        }
        /// <summary>
        /// 筛选所对应的材机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            if (dt != null)
            {
                DataRowView drv = this.bindingSource1.Current as DataRowView;
                if (drv != null)
                {
                   string _caj = drv["DECJ"].ToString();
                    string[] _CaiBh = _caj.Split('|');
                    string Fiter = "";
                    for (int i = 0; i < _CaiBh.Length; i++)
                    {
                        DataRow row = dt.Rows.Find(_CaiBh[i].Split(',')[0]);
                        if (row != null)
                        {
                            row["fl"] = _CaiBh[i].Split(',')[1];
                            Fiter += "'" + _CaiBh[i].Split(',')[0] + "',";
                        }
                    }
                    if (Fiter.Length > 0)
                    {
                        Fiter = Fiter.Substring(0, Fiter.Length - 1);
                    }
                    this.bindingSource2.Filter = string.Format("CAIJBH in ({0})", Fiter);
                }
                else
                {
                    this.bindingSource2.Filter = "1<>1";
                }
            }
            GetSCDJ();
        }
        /// <summary>
        /// 打开措施项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            MeasuresSelectForm form = new MeasuresSelectForm();
            form.Activitie = this.Activitie;
            DialogResult dl = form.ShowDialog();
            if (dl==DialogResult.OK)
            {
                DataRowView info = form.bindingSource1.Current as DataRowView;
                _Entity_SubInfo minfo = new _Entity_SubInfo();
                _ObjectSource.GetObject(minfo, info.Row);
                this.m_MFixed = minfo;
                this.simpleButton1.Enabled = true;
            }
        }
        /// <summary>
        /// 取消降效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DataRow[] infos = this.Activitie.StructSource.ModelMeasures.Select("LB='子目-降效'");
            for (int i = 0; i < infos.Length; i++)
            {
                infos[i].Delete();
            }
            _Mothod_Measures method = new _Mothod_Measures(this.CurrentBusiness, this.Activitie, this.GetMea());
            method.Calculate();
            MsgBox.Show("取消成功！请到措施项目查看", MessageBoxButtons.OK);
            
            //this.Activitie.Property.MeasuresProject.DataSource.ResetBindings(false);
            //this.Close();

        }
        private _Entity_SubInfo GetMea()
        {
            _Entity_SubInfo info = new _Entity_SubInfo();
            DataRow[] rows = this.Activitie.StructSource.ModelMeasures.Select("PID=0");
            if (rows.Length > 0) _ObjectSource.GetObject(info, rows[0]);
            return info;
        }
        /// <summary>
        /// 确定设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //确定时创建子目到清单
            _Entity_SubInfo info = new _Entity_SubInfo();
            DataRowView view = this.bindingSource1.Current as DataRowView;
            ChangeDECJ(view);
            if (view!=null)
            {
                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(info, view.Row, this.Activitie.Property.Libraries.FixedLibrary.FullName);
                    info.LB = "子目-降效";
                    _Mothods_MFixed fix = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, this.m_MFixed);
                    var createdMeasure = fix.Create(-1, info);
                    DataRow[] rows = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}", info.ID, info.SSLB));
                    foreach (DataRow item in rows)
                    {
                        item["DEDJ"] = item["SCDJ"];
                    }
                    //fix.Calculate();
                    //var method = GLODSOFT.QDJJ.BUSINESS._Methods.CreateIntaceMet(this.CurrentBusiness, this.Activitie, createdMeasure);
                    //method.Calculate();
                    calculator.Entities.Add(info);

                    this.DialogResult = DialogResult.OK;
                }

                CurrentBusiness.FastCalculate();
            }
        }

        private void ChangeDECJ(DataRowView view)
        {
            if (view != null)
            {
                string _caj = view["DECJ"].ToString();
                string Str = "";
                string[] _CaiBh = _caj.Split('|');
                for (int i = 0; i < _CaiBh.Length; i++)
                {
                    DataRow row = dt.Rows.Find(_CaiBh[i].Split(',')[0]);
                    if (row != null)
                    {
                        //_CaiBh[i].Split(',')[2] = row["SCDJ"].ToString();
                        decimal d = ToolKit.ParseDecimal(row["fl"]) * 0.01m;
                       Str += _CaiBh[i].Split(',')[0] + "," + d + "," + row["SCDJ"].ToString() + "|";
                        //row["fl"] = _CaiBh[i].Split(',')[1];
                        //Fiter += "'" + _CaiBh[i].Split(',')[0] + "',";
                    }
                }

                if (!string.IsNullOrEmpty(Str))
                {
                    view.BeginEdit();
                    view["DECJ"] = Str;
                    view.EndEdit();
                }
            }
        }
        /// <summary>
        /// 取消设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //IEnumerable < _ObjectInfo > infos= from info in this.Activitie.Property.MeasuresProject.ObjectsList.Cast<_ObjectInfo>()
            //                             where info.LB == "子目-降效"
            //                             select info;
            //int count = infos.Count();
            this.Close();
        }
    }
}