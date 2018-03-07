using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.COMMONS;
using ZiboSoft.Commons.Common;
using DevExpress.XtraEditors;
using GOLDSOFT.QDJJ.COMMONS.LIB;
using GLODSOFT.QDJJ.BUSINESS;
using System.Collections;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class ProSetting : BaseInfo
    {
        public ProSetting()
        {
            InitializeComponent();
        }

        private void ProSetting_Load(object sender, EventArgs e)
        {
            this.xtraTabPage4.PageVisible = false;
            radioGroup1_SelectedIndexChanged(null, null);
            radioGroup2_SelectedIndexChanged(null, null);
            //DefaultView();//默认试图
        }
        /// <summary>
        /// 第一个查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbtnView1_LinkClick(object sender, EventArgs e)
        {
            DefaultView();//默认试图
        }
        /// <summary>
        /// 默认试图
        /// </summary>
        private void DefaultView()
        {
            //label1.Visible = true;
            label2.Visible = false;
            groupControl1.Height = 130;
            groupControl2.SetBounds(5, 140, 510, 23);
        }
        /// <summary>
        /// 第二个查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbtnView2_LinkClick(object sender, EventArgs e)
        {
            //label1.Visible = false;
            label2.Visible = true;
            groupControl1.Height = 23;
            groupControl2.SetBounds(5, 33, 510, 130);
        }
        /// <summary>
        /// 第三个选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (1 == radioGroup3.SelectedIndex)
            {
                btnEdit1.Enabled = true;
            }
            else
            {
                btnEdit1.Text = string.Empty;
                btnEdit1.Tag = string.Empty;
                btnEdit1.Enabled = false;
            }
        }

        /// <summary>
        /// 第一个石灰转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                ArrayList m_ArrayList = this.GetAllSub(string.Format("ZCLB='W' AND YSBH IN({0})", _Constant.石灰转换定额范围));
                DataRow new_info = GetSSH();
                foreach (DataRow item in m_ArrayList)
                {
                    decimal yxhl = 0m;
                    decimal xhl = 0m;
                    DataRow sshkg = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W'AND YSBH='10900'", item["SSLB"], item["ID"])).FirstOrDefault();
                    DataRow ssht = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W'AND YSBH='10901'", item["SSLB"], item["ID"])).FirstOrDefault();
                    if (sshkg != null)
                    {
                        yxhl += _ConvertUnit.Convert(sshkg["DW"].ToString(), "千克") * ToolKit.ParseDecimal(sshkg["XHL"]);
                        xhl += _ConvertUnit.Convert(sshkg["DW"].ToString(), "千克") * ToolKit.ParseDecimal(sshkg["XHL"]) * 1.3m;
                        sshkg.Delete();
                    }
                    if (ssht != null)
                    {
                        yxhl += _ConvertUnit.Convert(ssht["DW"].ToString(), "千克") * ToolKit.ParseDecimal(ssht["XHL"]);
                        xhl += _ConvertUnit.Convert(ssht["DW"].ToString(), "千克") * ToolKit.ParseDecimal(ssht["XHL"]) * 1.3m;
                        ssht.Delete();
                    }

                    new_info["YSXHL"] = xhl;
                    new_info["XHL"] = xhl;
                    new_info["CTIME"] = DateTime.Now;
                    new_info["SSLB"] = item["SSLB"];
                    new_info["EnID"] = item["EnID"];
                    new_info["UnID"] = item["UnID"];
                    new_info["ZMID"] = item["ID"];
                    new_info["QDID"] = item["PID"];
                    new_info["PID"] = DBNull.Value;
                    this.Activitie.StructSource.ModelQuantity.Add(new_info);

                    DataRow rg = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB='{0}' AND ZMID={1} AND LB='{2}'", item["SSLB"], item["ID"], "人工"), "YSBH").FirstOrDefault();
                    if (rg != null)
                    {
                        rg["XHL"] = ToolKit.ParseDecimal(rg["XHL"]) - (yxhl * 0.001m) * 0.478m;
                    }
                    DataRow sui = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB='{0}' AND ZMID={1} AND YSBH='{2}'", item["SSLB"], item["ID"], "11610"), "YSBH").FirstOrDefault();
                    if (sui != null)
                    {
                        sui["XHL"] = ToolKit.ParseDecimal(sui["XHL"]) - (yxhl * 0.001m) * 0.043m;
                    }
                    _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
                    _ObjectSource.GetObject(m_Entity_SubInfo, item);
                    _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(this.CurrentBusiness, this.Activitie, m_Entity_SubInfo);
                    m_Methods_Subheadings.Begin(null);
                }
                MsgBox.Alert("【" + m_ArrayList.Count + "】条子目 生石灰-转换-熟石灰");
            }
            else
            {
                int m_index = 0;
                ArrayList m_ArrayList = this.GetAllSub("ZCLB='W' AND YSBH='10905'");
                foreach (DataRow item in m_ArrayList)
                {
                    _Entity_SubInfo m_QD_Entity_SubInfo = null;
                    _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
                    _ObjectSource.GetObject(m_Entity_SubInfo, item);
                    if (m_Entity_SubInfo.SSLB == 0)
                    {
                        m_QD_Entity_SubInfo = new _Entity_SubInfo();
                        DataRow dr_qd = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(m_Entity_SubInfo.PID.ToString());
                        if (dr_qd != null)
                        {
                            _ObjectSource.GetObject(m_QD_Entity_SubInfo, dr_qd);
                            _Methods_Fixed m_Methods_Fixed = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                            _Entity_SubInfo f_Entity_SubInfo = GetZMByID(m_Entity_SubInfo.OLDXMBM);
                            if (f_Entity_SubInfo != null)
                            {
                                item.Delete();
                                f_Entity_SubInfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("GCSZ", ++m_index, m_Methods_Fixed.Current.OLDXMBM);
                                m_Methods_Fixed.Create(m_Entity_SubInfo.Sort - 1, f_Entity_SubInfo);
                            }
                        }
                    }
                    else
                    {
                        m_QD_Entity_SubInfo = new _Entity_SubInfo();
                        DataRow dr_qd = this.Activitie.StructSource.ModelMeasures.GetRowByOther(m_Entity_SubInfo.PID.ToString());
                        if (dr_qd != null)
                        {
                            _ObjectSource.GetObject(m_QD_Entity_SubInfo, dr_qd);
                            _Mothods_MFixed m_Mothods_MFixed = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                            _Entity_SubInfo c_Entity_SubInfo = GetZMByID(m_Entity_SubInfo.OLDXMBM);
                            if (c_Entity_SubInfo != null)
                            {
                                item.Delete();
                                c_Entity_SubInfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("GCSZ", ++m_index, m_Mothods_MFixed.Current.OLDXMBM);
                                m_Mothods_MFixed.Create(m_Entity_SubInfo.Sort - 1, c_Entity_SubInfo);
                            }
                        }
                    }
                }
                MsgBox.Alert("【" + m_ArrayList.Count + "】条子目 熟石灰-转换-生石灰");
            }
        }

        /// <summary>
        /// 第二个砂浆转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            APP.UserPriceLibrary.AllQuantityUnit = this.Activitie.StructSource.ModelQuantity;
            APP.UserPriceLibrary.UnName = this.Activitie.Name;
            APP.UserPriceLibrary.Range = 1;
            if (this.radioGroup2.SelectedIndex == 1)
            {
                ArrayList m_ArrayList = this.GetAllSub("ZCLB='W' AND YSBH='J06016' AND XHL <> 0");
                int count = m_ArrayList.Count;
                //抹灰工程
                foreach (DataRow item in m_ArrayList)
                {
                    DataRow[] mh = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W' AND YSBH IN({2})", item["SSLB"], item["ID"], _Constant.抹灰工程定额范围));
                    if (mh.Length > 0)
                    {
                        DataRow rg = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W' AND LB='人工'", item["SSLB"], item["ID"]), "YSBH").FirstOrDefault();
                        DataRow jx = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W' AND BH='J06016'", item["SSLB"], item["ID"]), "YSBH").FirstOrDefault();
                        decimal rgxhl = 0m;
                        foreach (DataRow dr in mh)
                        {
                            if (!dr["MC"].ToString().Contains("(预拌砂浆)"))
                            {
                                dr.BeginEdit();
                                dr["MC"] = dr["MC"].ToString() + "(预拌砂浆)";
                                APP.UserPriceLibrary.Update("MC", dr["MC", DataRowVersion.Current], dr);
                                dr.EndEdit();
                            }
                        }
                        //修改消耗量
                        foreach (DataRow mhs in mh)
                        {
                            rgxhl += ToolKit.ParseDecimal(mhs["XHL"]) * 1.1m * _ConvertUnit.Convert(mhs["DW"].ToString(), "立方米");
                        }
                        if (rg != null)
                        {
                            rg["XHL"] = ToolKit.ParseDecimal(rg["XHL"]) - rgxhl;
                        }
                        if (jx != null)
                        {
                            jx["XHL"] = 0m;
                        }
                    }

                    //砌筑工程
                    DataRow[] qz = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W' AND YSBH IN ({2}) ", item["SSLB"], item["ID"], _Constant.砌筑工程定额范围));
                    if (qz.Count() > 0)
                    {
                        DataRow rg = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W' AND LB='人工'", item["SSLB"], item["ID"]), "YSBH").FirstOrDefault();
                        DataRow jx = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W' AND BH='J06016'", item["SSLB"], item["ID"]), "YSBH").FirstOrDefault();
                        decimal rgxhl = 0m;
                        //修改名称
                        DataRow dr = qz.FirstOrDefault();
                        if (dr != null)
                        {
                            if (!dr["MC"].ToString().Contains("(预拌砂浆)"))
                            {
                                dr.BeginEdit();
                                dr["MC"] = dr["MC"].ToString() + "(预拌砂浆)";
                                APP.UserPriceLibrary.Update("MC", dr["MC", DataRowVersion.Current], dr);
                                dr.EndEdit();
                            }
                        }
                        foreach (DataRow qzs in qz)
                        {
                            rgxhl += ToolKit.ParseDecimal(qzs["XHL"]) * 0.69m * _ConvertUnit.Convert(qzs["DW"].ToString(), "立方米");
                        }
                        if (rg != null)
                        {
                            rg["XHL"] = ToolKit.ParseDecimal(rg["XHL"]) - rgxhl;
                        }
                        if (jx != null)
                        {
                            jx["XHL"] = 0m;
                        }
                    }
                    string m_NewSubheadings = item["EnID"] + "," + item["UnID"] + "," + item["SSLB"] + "," + item["ID"] + "|";
                    if (!APP.UserPriceLibrary.SubheadingsInfo.Contains(m_NewSubheadings))
                    {
                        APP.UserPriceLibrary.SubheadingsInfo += m_NewSubheadings;
                    }
                }
                _Methods_Subheadings m_Methods_Subheadings = new _Methods_Subheadings(this.Activitie);
                m_Methods_Subheadings.BatchCalculate();
                MsgBox.Alert("【" + count + "】条子目 现场制拌砂浆-转换-预拌砂浆");
            }
            else
            {
                int m_index = 0;
                ArrayList m_ArrayList = this.GetAllSub("ZCLB='W' AND YSBH='J06016' AND XHL=0");
                foreach (DataRow item in m_ArrayList)
                {
                    _Entity_SubInfo m_QD_Entity_SubInfo = null;
                    _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
                    _ObjectSource.GetObject(m_Entity_SubInfo, item);
                    if (m_Entity_SubInfo.SSLB == 0)
                    {
                        m_QD_Entity_SubInfo = new _Entity_SubInfo();
                        DataRow dr_qd = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(m_Entity_SubInfo.PID.ToString());
                        if (dr_qd != null)
                        {
                            _ObjectSource.GetObject(m_QD_Entity_SubInfo, dr_qd);
                            _Methods_Fixed m_Methods_Fixed = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                            _Entity_SubInfo f_Entity_SubInfo = GetZMByID(m_Entity_SubInfo.OLDXMBM);
                            if (f_Entity_SubInfo != null)
                            {
                                item.Delete();
                                f_Entity_SubInfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("GCSZ", ++m_index, m_Methods_Fixed.Current.OLDXMBM);
                                m_Methods_Fixed.Create(m_Entity_SubInfo.Sort - 1, f_Entity_SubInfo);
                            }
                        }
                    }
                    else
                    {
                        m_QD_Entity_SubInfo = new _Entity_SubInfo();
                        DataRow dr_qd = this.Activitie.StructSource.ModelMeasures.GetRowByOther(m_Entity_SubInfo.PID.ToString());
                        if (dr_qd != null)
                        {
                            _ObjectSource.GetObject(m_QD_Entity_SubInfo, dr_qd);
                            _Mothods_MFixed m_Mothods_MFixed = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                            _Entity_SubInfo c_Entity_SubInfo = GetZMByID(m_Entity_SubInfo.OLDXMBM);
                            if (c_Entity_SubInfo != null)
                            {
                                item.Delete();
                                c_Entity_SubInfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("GCSZ", ++m_index, m_Mothods_MFixed.Current.OLDXMBM);
                                m_Mothods_MFixed.Create(m_Entity_SubInfo.Sort - 1, c_Entity_SubInfo);
                            }
                        }
                    }
                   
                }
                MsgBox.Alert("【" + m_ArrayList.Count + "】条子目 预拌砂浆-转换-现场制拌砂浆");
            }
        }

        /// <summary>
        /// 第三个模板应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit3_Click(object sender, EventArgs e)
        {
            if (radioGroup3.SelectedIndex == 1)
            {
                DataRow qd_dr = this.btnEdit1.Tag as DataRow;
                if (qd_dr != null)
                {
                    ArrayList m_ArrayList = this.GetAllMBSub();
                    if (m_ArrayList.Count > 0)
                    {
                        _Entity_SubInfo m_QD_Entity_SubInfo = new _Entity_SubInfo();
                        _ObjectSource.GetObject(m_QD_Entity_SubInfo, qd_dr);
                        _Mothods_MFixed m_Mothods_MFixed = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                        _Entity_SubInfo m_ZM_Entity_SubInfo = new _Entity_SubInfo();
                        foreach (DataRow item in m_ArrayList)
                        {
                            item["SC"] = false;
                            _ObjectSource.GetObject(m_ZM_Entity_SubInfo, item);
                            m_ZM_Entity_SubInfo.SC = true;
                            m_Mothods_MFixed.Create(-1, m_ZM_Entity_SubInfo);
                            DataRow[] csxm_drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1}", m_ZM_Entity_SubInfo.SSLB, m_ZM_Entity_SubInfo.ID));
                            foreach (DataRow csxm_glj_item in csxm_drs)
                            {
                                csxm_glj_item.Delete();
                            }
                            DataRow[] fbfx_drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1}", item["SSLB"], item["ID"]));
                            foreach (DataRow fbfx_glj_item in fbfx_drs)
                            {
                                fbfx_glj_item["QDID"] = m_ZM_Entity_SubInfo.PID;
                                fbfx_glj_item["ZMID"] = m_ZM_Entity_SubInfo.ID;
                                fbfx_glj_item["SSLB"] = m_ZM_Entity_SubInfo.SSLB;
                            }
                        }
                    }
                    MsgBox.Alert("【" + m_ArrayList.Count + "】条子目 模板到措施成功");
                }
            }
            else
            {
                DialogResult dl = MessageBox.Show("您确认将模板还原到分部分项？", "提示", MessageBoxButtons.YesNo);
                if (dl == DialogResult.No) return;
                DataRow[] drs = this.Activitie.StructSource.ModelMeasures.Select("TX='模板'");
                if (drs.Length > 0)
                {
                    _Methods_Fixed m_Methods_Fixed = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, null);
                    _Entity_SubInfo m_Entity_SubInfo = new _Entity_SubInfo();
                    foreach (DataRow item in drs)
                    {
                        _Entity_SubInfo info = null;
                        DataRow qd_dr = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(item["QDBH"].ToString());
                        DataRow zm_dr = this.Activitie.StructSource.ModelSubSegments.Select(string.Format("QDBH='{0}' and XMBM='{1}'", item["QDBH"], item["XMBM"])).FirstOrDefault();
                        if (qd_dr != null)
                        {
                            info = new _Entity_SubInfo();
                            _ObjectSource.GetObject(info, qd_dr);
                            m_Methods_Fixed.Current = info;
                        }
                        if (info != null)
                        {
                            if (zm_dr == null)
                            {
                                m_Entity_SubInfo.SC = true;
                                _ObjectSource.GetObject(m_Entity_SubInfo, item);
                                m_Methods_Fixed.Create(-1, m_Entity_SubInfo);
                                DataRow[] fbfx_drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}", m_Entity_SubInfo.ID, m_Entity_SubInfo.SSLB));
                                foreach (DataRow fbfx_glj_item in fbfx_drs)
                                {
                                    fbfx_glj_item.Delete();
                                }
                            }
                            else
                            {
                                zm_dr["SC"] = true;
                                _ObjectSource.GetObject(m_Entity_SubInfo, zm_dr);
                            }
                            DataRow[] csxm_drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("ZMID={0} and SSLB={1}", item["ID"], item["SSLB"]));
                            foreach (DataRow csxm_drs_item in csxm_drs)
                            {
                                csxm_drs_item["QDID"] = m_Entity_SubInfo.PID;
                                csxm_drs_item["ZMID"] = m_Entity_SubInfo.ID;
                                csxm_drs_item["SSLB"] = m_Entity_SubInfo.SSLB;
                            }
                        }
                        item.Delete();
                    }
                    MsgBox.Alert("【" + drs.Length + "】条子目 模板到分部成功");
                }
            }
        }

        /// <summary>
        /// 第四个混凝土转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit4_Click(object sender, EventArgs e)
        {
            int m_index = 0;
            if (APP.Application.Global.DataTamp.工程设置.Tables.Count == 0) return;
            if (this.radioGroup4.SelectedIndex == 1)
            {
                //普通转换商品
                DataRow[] deh_drs = APP.Application.Global.DataTamp.工程设置.Tables["混凝土转换"].Select("LB='定额编号'");
                int count = 0;
                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    foreach (DataRow deh_item in deh_drs)
                    {
                        _Entity_SubInfo m_QD_Entity_SubInfo = new _Entity_SubInfo();
                        _Methods_Fixed m_QD_Methods_Fixed = null;
                        ArrayList zm_ArrayList = this.GetAllHNTSub(deh_item["PTHNT"].ToString());
                        foreach (DataRow zm_item in zm_ArrayList)
                        {
                            _Entity_SubInfo new_Entity_SubInfo = null;
                            if (zm_item["SSLB"].Equals(0))
                            {
                                DataRow qd_dr = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(zm_item["PID"].ToString());
                                _ObjectSource.GetObject(m_QD_Entity_SubInfo, qd_dr);
                                m_QD_Methods_Fixed = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                                new_Entity_SubInfo = this.GetZMByID(deh_item["SPHNT"].ToString());
                            }
                            else
                            {
                                DataRow qd_dr = this.Activitie.StructSource.ModelMeasures.GetRowByOther(zm_item["PID"].ToString());
                                _ObjectSource.GetObject(m_QD_Entity_SubInfo, qd_dr);
                                m_QD_Methods_Fixed = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                                new_Entity_SubInfo = this.GetZMByID(deh_item["SPHNT"].ToString());
                            }
                            if (new_Entity_SubInfo != null)
                            {

                                DataRow[] phb_glj_drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W'", zm_item["SSLB"], zm_item["ID"]), "BH");
                                foreach (DataRow phb_glj_item in phb_glj_drs)
                                {
                                    DataRow cl_dr = APP.Application.Global.DataTamp.工程设置.Tables["混凝土转换"].Select(string.Format("LB='材料' AND PTHNT='{0}'", phb_glj_item["YSBH"])).FirstOrDefault();
                                    if (cl_dr != null)
                                    {
                                        string[] m_mrth = deh_item["MRZTH"].ToString().Split('|');
                                        if (m_mrth.Length == 2)
                                        {
                                            if (!m_mrth[1].Equals(cl_dr["SPHNT"]))
                                            {
                                                new_Entity_SubInfo.XMBM += "换";
                                                new_Entity_SubInfo.XMMC += "//换：" + m_mrth[1] + "," + cl_dr["SPHNT"];
                                            }
                                            new_Entity_SubInfo.DECJ = new_Entity_SubInfo.DECJ.Replace(m_mrth[1].ToString(), cl_dr["SPHNT"].ToString());
                                            new_Entity_SubInfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("GCSZ", ++m_index, m_QD_Methods_Fixed.Current.OLDXMBM);
                                            continue;
                                        }
                                    }
                                }


                                m_QD_Methods_Fixed.Create(ToolKit.ParseInt(zm_item["Sort"]) - 1, new_Entity_SubInfo);
                                new_Entity_SubInfo.GCL = (int)double.Parse(zm_item["GCL"].ToString());
                                new_Entity_SubInfo.HL = (int)double.Parse(zm_item["HL"].ToString());
                                this.Activitie.StructSource.ModelSubSegments.UpDate(new_Entity_SubInfo);
                                zm_item.Delete();
                                count++;
                            }

                            calculator.Entities.Add(new_Entity_SubInfo);
                        }
                    }
                    MsgBox.Alert("【" + count + "】条子目 （普通混凝土）转换（商品混凝土）成功");
                }
            }
            else
            {
                DataTable hntzh = APP.Application.Global.DataTamp.工程设置.Tables["混凝土转换"];
                if (hntzh == null) return;
                //商品转换普通
                DataRow[] deh_drs = APP.Application.Global.DataTamp.工程设置.Tables["混凝土转换"].Select("LB='定额编号'");
                int count = 0;

                using (var calculator = new Calculator(CurrentBusiness, Activitie))
                {
                    foreach (DataRow deh_item in deh_drs)
                    {
                        _Entity_SubInfo m_QD_Entity_SubInfo = new _Entity_SubInfo();
                        _Methods_Fixed m_QD_Methods_Fixed = null;
                        ArrayList zm_ArrayList = this.GetAllHNTSub(deh_item["SPHNT"].ToString());

                        foreach (DataRow zm_item in zm_ArrayList)
                        {
                            _Entity_SubInfo new_Entity_SubInfo = null;
                            if (zm_item["SSLB"].Equals(0))
                            {
                                DataRow qd_dr = this.Activitie.StructSource.ModelSubSegments.GetRowByOther(zm_item["PID"].ToString());
                                _ObjectSource.GetObject(m_QD_Entity_SubInfo, qd_dr);
                                m_QD_Methods_Fixed = new _Methods_Fixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                                new_Entity_SubInfo = this.GetZMByID(deh_item["PTHNT"].ToString());
                            }
                            else
                            {
                                DataRow qd_dr = this.Activitie.StructSource.ModelMeasures.GetRowByOther(zm_item["PID"].ToString());
                                _ObjectSource.GetObject(m_QD_Entity_SubInfo, qd_dr);
                                m_QD_Methods_Fixed = new _Mothods_MFixed(this.CurrentBusiness, this.Activitie, m_QD_Entity_SubInfo);
                                new_Entity_SubInfo = this.GetZMByID(deh_item["PTHNT"].ToString());
                            }
                            if (new_Entity_SubInfo != null)
                            {
                                DataRow[] phb_glj_drs = this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB={0} AND ZMID={1} AND ZCLB='W'", zm_item["SSLB"], zm_item["ID"]), "BH");
                                foreach (DataRow phb_glj_item in phb_glj_drs)
                                {
                                    DataRow cl_dr = APP.Application.Global.DataTamp.工程设置.Tables["混凝土转换"].Select(string.Format("LB='材料' AND SPHNT='{0}'", phb_glj_item["YSBH"])).FirstOrDefault();
                                    if (cl_dr != null)
                                    {
                                        string[] m_mrth = deh_item["MRZTH"].ToString().Split('|');
                                        if (m_mrth.Length == 2)
                                        {
                                            if (!m_mrth[0].Equals(cl_dr["PTHNT"]))
                                            {
                                                new_Entity_SubInfo.XMBM += "换";
                                                new_Entity_SubInfo.XMMC += "//换：" + m_mrth[0] + "," + cl_dr["PTHNT"];
                                            }
                                            new_Entity_SubInfo.DECJ = new_Entity_SubInfo.DECJ.Replace(m_mrth[0].ToString(), cl_dr["PTHNT"].ToString());
                                            new_Entity_SubInfo.BEIZHU = GLODSOFT.QDJJ.BUSINESS._Methods.GetDEbeizhu("GCSZ", ++m_index, m_QD_Methods_Fixed.Current.OLDXMBM);
                                            continue;
                                        }
                                    }
                                }

                                var entity = m_QD_Methods_Fixed.Create(ToolKit.ParseInt(zm_item["Sort"]) - 1, new_Entity_SubInfo);
                                zm_item.Delete();
                                count++;
                                calculator.Entities.Add(entity);

                            }
                        }
                    }
                }
                MsgBox.Alert("【" + count + "】条子目 （商品混凝土）转换（普通混凝土）成功");
            }
        }

        /// <summary>
        /// 获取所有混凝土子目
        /// </summary>
        /// <returns></returns>
        private ArrayList GetAllHNTSub(string p_XMBM)
        {
            ArrayList m_ArrayList = new ArrayList();
            try
            {
                m_ArrayList.AddRange(this.Activitie.StructSource.ModelSubSegments.Select(string.Format("OLDXMBM='{0}'", p_XMBM)));
                m_ArrayList.AddRange(this.Activitie.StructSource.ModelMeasures.Select(string.Format("OLDXMBM='{0}'", p_XMBM)));
            }
            catch (Exception)
            {
                return new ArrayList();
            }
            return m_ArrayList;
        }

        /// <summary>
        /// 获取所有模板子目
        /// </summary>
        /// <returns></returns>
        private ArrayList GetAllMBSub()
        {
            ArrayList m_ArrayList = new ArrayList();
            try
            {
                m_ArrayList.AddRange(this.Activitie.StructSource.ModelSubSegments.AsEnumerable().Where(p => p["TX"].Equals("模板") ? this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB=0 AND ZMID={0}", p["ID"])).Length > 0 ? true : false : false).ToArray());
            }
            catch (Exception)
            {
                return new ArrayList();
            }
            return m_ArrayList;
        }

        /// <summary>
        /// 获取所有符合条件的子目
        /// </summary>
        /// <param name="p_Format"></param>
        /// <returns></returns>
        private ArrayList GetAllSub(string p_Format)
        {
            ArrayList m_ArrayList = new ArrayList();
            try
            {
                m_ArrayList.AddRange(this.Activitie.StructSource.ModelSubSegments.AsEnumerable().Where(p => p["LB"].Equals("子目") ? this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB=0 AND ZMID={0} AND {1}", p["ID"], p_Format)).Length > 0 ? true : false : false).ToArray());
                m_ArrayList.AddRange(this.Activitie.StructSource.ModelMeasures.AsEnumerable().Where(p => p["LB"].Equals("子目") ? this.Activitie.StructSource.ModelQuantity.Select(string.Format("SSLB=1 AND ZMID={0} AND {1}", p["ID"], p_Format)).Length > 0 ? true : false : false).ToArray());
            }
            catch (Exception)
            {
                return new ArrayList();
            }
            return m_ArrayList;
        }

        private _Entity_SubInfo GetZMByID(string temp)
        {
            DataRow[] rows = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["定额表"].Select(string.Format("DINGEH='{0}'", temp.ToUpper()));
            _Entity_SubInfo sinfo = new _Entity_SubInfo();
            GLODSOFT.QDJJ.BUSINESS._Methods.SetSubheadingsInfo(sinfo, rows[0], this.Activitie.Property.Libraries.FixedLibrary.FullName);
            sinfo.LibraryName = this.Activitie.Property.Libraries.FixedLibrary.FullName;
            return sinfo;

        }

        /// <summary>
        /// 获取熟石灰
        /// </summary>
        /// <returns></returns>
        private DataRow GetSSH()
        {
            DataRow dr = this.Activitie.Property.Libraries.FixedLibrary.LibraryDataSet.Tables["材机表"].Select("CAIJBH ='10905'").FirstOrDefault();
            if (dr != null)
            {
                DataRow y_info = this.Activitie.StructSource.ModelQuantity.Select("BH='10905'").FirstOrDefault();
                DataRow new_info = this.Activitie.StructSource.ModelQuantity.NewRow();
                new_info["YSBH"] = dr["CAIJBH"].ToString();
                new_info["YSMC"] = dr["CAIJMC"].ToString();
                new_info["YSDW"] = dr["CAIJDW"].ToString();
                new_info["DEDJ"] = dr["CAIJDJ"].ToString().Trim() == string.Empty ? 0m : Convert.ToDecimal(dr["CAIJDJ"].ToString());
                new_info["BH"] = dr["CAIJBH"].ToString();
                new_info["MC"] = dr["CAIJMC"].ToString();
                new_info["DW"] = dr["CAIJDW"].ToString();
                new_info["LB"] = dr["CAIJLB"].ToString();
                new_info["SCDJ"] = new_info["DEDJ"];
                new_info["ZCLB"] = "W";
                new_info["SDCLB"] = dr["SANDCMC"].ToString();
                new_info["SDCXS"] = dr["SANDCXS"].ToString().Length == 0 ? 0m : Convert.ToDecimal(dr["SANDCXS"]);

                if (y_info == null)
                {
                    new_info["IFSC"] = dr["CAIJSC"].ToString() == "是" ? true : false;
                    new_info["IFFX"] = false;
                    new_info["IFSDSCDJ"] = false;
                    new_info["IFZYCL"] = dr["CAIJXSJG"].ToString() == "是" ? true : false;
                    if (new_info["LB"].Equals("主材") || new_info["LB"].Equals("设备"))
                    {
                        new_info["SCDJ"] = 0m;
                    }
                    new_info["YTLB"] = string.Empty;
                }
                else
                {
                    new_info["IFSC"] = y_info["IFSC"];
                    new_info["IFFX"] = y_info["IFFX"];
                    new_info["IFSDSCDJ"] = y_info["IFSDSCDJ"];
                    new_info["IFZYCL"] = y_info["IFZYCL"];
                    new_info["YTLB"] = y_info["YTLB"];
                    new_info["SCDJ"] = y_info["SCDJ"];
                    new_info["JSDJ"] = y_info["JSDJ"];
                    new_info["CJ"] = y_info["CJ"];
                    new_info["PP"] = y_info["PP"];
                    new_info["ZLDJ"] = y_info["ZLDJ"];
                    new_info["GYS"] = y_info["GYS"];
                    new_info["CD"] = y_info["CD"];
                    new_info["CJBZ"] = y_info["CJBZ"];
                }
                return new_info;
            }
            return null;
        }

        /// <summary>
        /// 选择弹框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ButtonEdit btnEdit = (sender as ButtonEdit);
            MeasuresSelectForm form = new MeasuresSelectForm();
            form.Activitie = this.Activitie;
            DialogResult dl = form.ShowDialog();
            if (dl == DialogResult.OK)
            {
                DataRowView info = form.bindingSource1.Current as DataRowView;
                btnEdit.Tag = info.Row;
                btnEdit.Text = info["XMMC"].ToString();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 1)
            {
                this.memoEdit1.Text = _Constant.石灰转换说明;
            }
            else
            {
                this.memoEdit1.Text = "重新套定额号";
            }
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup2.SelectedIndex == 1)
            {
                this.memoEdit3.Text = "一：抹灰工程\r\n" + _Constant.抹灰工程说明 + "\r\n\r\n" + "二：砌筑工程\r\n" + _Constant.砌筑工程说明;
            }
            else
            {
                this.memoEdit3.Text = "重新套定额号";
            }
        }
    }
}
