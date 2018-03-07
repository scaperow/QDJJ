/*
 用于处理项目汇总分得筛选逻辑应用
 最终确定时候返回查询结果结构体
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CPro_Sub_Data_Filter : BaseForm
    {
        public DataTable DataSource = null;

        public DataTable Result = null;

        public CPro_Sub_Data_Filter()
        {
            InitializeComponent();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup rg = sender as RadioGroup;
            if (rg.SelectedIndex == 0)
            {
                this.lookUpEdit1.Enabled = true;
                this.labelControl3.Enabled = this.spinEdit1.Enabled = false;
                this.labelControl3.Enabled = this.spinEdit2.Enabled = false;
            }
            if (rg.SelectedIndex == 1)
            {
                this.lookUpEdit1.Enabled = false;
                this.labelControl3.Enabled = this.spinEdit1.Enabled = true;
                this.labelControl3.Enabled = this.spinEdit2.Enabled = false;
            }
            if (rg.SelectedIndex == 2)
            {
                this.lookUpEdit1.Enabled = false;
                this.labelControl3.Enabled = this.spinEdit1.Enabled = false;
                this.labelControl3.Enabled = this.spinEdit2.Enabled = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 确定查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.checkEdit1.Checked)//方式1
            {
                bool[] bs = new bool[3];
                bs[0] = this.radioGroup1.SelectedIndex == 0 ? true : false;
                bs[1] = this.radioGroup1.SelectedIndex == 1 ? true : false;
                bs[2] = this.radioGroup1.SelectedIndex == 2 ? true : false;
                this.DoFilter(bs);
                QueryParent();
            }
            if (this.checkEdit2.Checked)//方式2
            {
                this.DoFilter2();
                QueryParent();
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 方式2
        /// </summary>
        /// <param name="bs"></param>
        private void DoFilter2()
        {
            
            //绑定清单数据
            IEnumerable<DataRow> infos =  from i in this.DataSource.AsEnumerable()
                                              where ForF(i)
                                              select i;

            
            infos.CopyToDataTable(Result, LoadOption.OverwriteChanges);

            

        }

        /// <summary>
        /// 方式2的查询条件
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private bool ForF(DataRow row)
        {
            bool flag = false;
            if (row["LB"].Equals("清单"))
            {
                //所有待检查标记的清单
                if (this.checkedListBoxControl1.Items[0].CheckState == CheckState.Checked)
                {
                    flag |= (bool)row["JCBJ"];
                }
                //所有带复查标记
                if (this.checkedListBoxControl1.Items[1].CheckState == CheckState.Checked)
                {
                    flag |= (bool)row["FHBJ"];
                }
                //主要清单
                if (this.checkedListBoxControl1.Items[2].CheckState == CheckState.Checked)
                {
                    flag |= (bool)row["ZYQD"];
                }
                //分包清单
                if (this.checkedListBoxControl1.Items[3].CheckState == CheckState.Checked)
                {
                    flag |= (bool)row["SFFB"];
                }
                //所有评标指定材料
                if (this.checkedListBoxControl1.Items[4].CheckState == CheckState.Checked)
                {
                    flag |= decimal.Parse(row["PBZD"].ToString()) > 0;
                    
                }
                //甲招已供材料
                if (this.checkedListBoxControl1.Items[5].CheckState == CheckState.Checked)
                {
                    flag |= decimal.Parse(row["YGJE"].ToString()) > 0;
                }
                //甲供材料
                if (this.checkedListBoxControl1.Items[6].CheckState == CheckState.Checked)
                {
                    flag |= decimal.Parse(row["JGJE"].ToString()) > 0;
                }
                //所有带复查标记
                if (this.checkedListBoxControl1.Items[7].CheckState == CheckState.Checked)
                {
                    flag |= decimal.Parse(row["ZGJE"].ToString()) > 0;
                }
            }
            
            

            //如果选中添加子目与上级工程对象
            if (flag)
            {
                this.AddZM(row);
                //DoQuery(p_info);
            }

            return flag;
        }


        /// <summary>
        /// 根据条件查询结果(并且赋值给结果集合)
        /// </summary>
        /// <param name="bs"></param>
        public void DoFilter(bool[] bs)
        {
            
            if (bs[0])
            {

                //绑定清单数据
                IEnumerable<DataRow> infos = from i in this.DataSource.AsEnumerable()
                                             where ForE(i, bs) 
                                             select i;


                DataTable table = this.DataSource.Clone();
                infos.CopyToDataTable(table, LoadOption.OverwriteChanges);
                this.Result.Merge(table);
            }
            if (bs[1])
            {
                int top = Convert.ToInt32(this.spinEdit1.Value);

                //绑定清单数据
                IEnumerable<DataRow> infos = (from i in this.DataSource.AsEnumerable()
                                                 where i["LB"].Equals("清单")   orderby i["ZHHJ"] descending
                                                  select i).Take(top);

                infos = from i in infos.Cast<DataRow>()
                                                   where ForE(i, bs)
                                                  orderby i["ZHDJ"] descending
                                                  select i;

                DataTable table = this.DataSource.Clone();
                infos.CopyToDataTable(table, LoadOption.OverwriteChanges);
                this.Result.Merge(table);
            }
            if (bs[2])
            {
                int top = Convert.ToInt32(this.spinEdit2.Value);

                //绑定清单数据
                IEnumerable<DataRow> infos = (from i in this.DataSource.AsEnumerable()
                                                  where i["LB"].Equals("清单")
                                                  orderby i["ZHHJ"] descending
                                                  select i).Take(top);

                /*infos = from i in infos.Cast<ISubSegment>()
                        where ForE(i, bs)
                        orderby i.ZHHJ descending
                        select i;*/
                DataTable table = this.DataSource.Clone();
                infos.CopyToDataTable(table, LoadOption.OverwriteChanges);
                this.Result.Merge(table);
            }
        }

       

        private bool ForE(DataRow row,bool[] bs)
        {
            switch (row["LB"].ToString())
            {
                case "清单":                
                    if (bs[0])
                    {//根据清单编号选择

                        if (row["OLDXMBM"].Equals(this.lookUpEdit1.Text))
                        {
                            //添加子目
                            this.AddZM(row);
                            //DoQuery(info);
                            return true;
                        }
                    }
                    if (bs[1])
                    {
                        this.AddZM(row);
                        //DoQuery(info);
                        return true;
                    }
                    break;
            }

            return false;
        }

        /// <summary>
        /// 添加子目
        /// </summary>
        /// <param name="row"></param>
        private void AddZM(DataRow row)
        {
            //类别是子目并且id = row
            DataRow[] rows = this.DataSource.Select(string.Format(" PPARENTID = {0} and LB in ('子目') and UnID = {1} ",row["ID"],row["UnID"]));
            foreach (DataRow r in rows)
            {
                this.Result.Rows.Add(r.ItemArray);
            }
        }

        /// <summary>
        /// 结果中筛选
        /// </summary>
        public void QueryParent()
        {
            //循环查询
            DataRow[] rows = this.DataSource.Select("LB not in ('清单','子目')");
            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    //如果满足条件则加入对象
                    this.AddParent(row);
                }
            }

            //绑定清单数据
            /*IEnumerable<DataRow> infos = from i in this.DataSource.AsEnumerable()
                                         where ForP(i)
                                         select i;


            DataTable table = this.DataSource.Clone();
            infos.CopyToDataTable(table, LoadOption.OverwriteChanges);
            this.Result.Merge(table);*/
        }

        public void AddParent(DataRow row)
        {
            DataRow[] rows;
            if (row["LB"].Equals("整个项目"))
            {
                //肯定需要添加
                this.Result.Rows.Add(row.ItemArray);
            }
            if (row["LB"].Equals("单项工程"))
            {
                //存在清单并且没有自己
                rows = this.Result.Select(string.Format(" EnID = {0} and key <> {1} ", row["EnID"], row["Key"]));
                if (rows.Length > 0)
                {
                    //肯定需要添加
                    this.Result.Rows.Add(row.ItemArray);
                }
            }

            if (row["LB"].Equals("单位工程"))
            {
                //存在清单并且没有自己
                rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1}  ", row["UnID"], row["Key"]));
                if (rows.Length > 0)
                {
                    //肯定需要添加
                    this.Result.Rows.Add(row.ItemArray);
                }
            }

            if (row["LB"].Equals("分部-专业"))
            {
                //存在清单并且没有自己
                rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1} and PPARENTID = {2} ", row["UnID"], row["Key"], row["ID"]));
                if (rows.Length > 0)
                {
                    //肯定需要添加
                    this.Result.Rows.Add(row.ItemArray);
                }
            }
            if (row["LB"].Equals("分部-章"))
            {
                //存在清单并且没有自己
                rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1} and CPARENTID = {2} ", row["UnID"], row["Key"], row["ID"]));
                if (rows.Length > 0)
                {
                    //肯定需要添加
                    this.Result.Rows.Add(row.ItemArray);
                }
            }
            if (row["LB"].Equals("分部-节"))
            {
                //存在清单并且没有自己
                rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1} and PID = {2} ", row["UnID"], row["Key"], row["ID"]));
                if (rows.Length > 0)
                {
                    //肯定需要添加
                    this.Result.Rows.Add(row.ItemArray);
                }
            }
            //类别为空的 是措施项目的处理
            if (row["LB"].Equals(string.Empty))
            {
                if (row["XMMC"].Equals("通用项目"))
                {
                    //存在清单并且没有自己
                    rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1} and PID = {2}", row["UnID"], row["Key"], row["ID"]));
                    if (rows.Length > 0)
                    {
                        //肯定需要添加
                        this.Result.Rows.Add(row.ItemArray);
                    }
                }
                if (row["XMMC"].Equals("建筑工程"))
                {
                    //存在清单并且没有自己
                    rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1} and PID = {2}", row["UnID"], row["Key"], row["ID"]));
                    if (rows.Length > 0)
                    {
                        //肯定需要添加
                        this.Result.Rows.Add(row.ItemArray);
                    }
                }
                if (row["XMMC"].Equals("装饰装修工程"))
                {
                    //存在清单并且没有自己
                    rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1} and PID = {2}", row["UnID"], row["Key"], row["ID"]));
                    if (rows.Length > 0)
                    {
                        //肯定需要添加
                        this.Result.Rows.Add(row.ItemArray);
                    }
                }
            }
        }   

        /// <summary>
        /// 父亲循环是否添加
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool ForP(DataRow row)
        {
            //"整个项目","单项工程", "单位工程","分部-专业" ,"分部-章", "分部-节","清单" ,"子目"
            
            DataRow[] rows;
            if (row["LB"].Equals("清单")) return false;
            if (row["LB"].Equals("子目")) return false;

            if (row["LB"].Equals("整个项目"))
            {
                return true;
            }
            if (row["LB"].Equals("单项工程"))
            {
                 rows = this.Result.Select(string.Format(" EnID = {0} and key <> {1} ",row["EnId"],row["Key"]));
                 if (rows.Length > 0)
                 {
                     return true;
                 } 
                return false;
            }

            if (row["LB"].Equals("单位工程"))
            {
                rows = this.Result.Select(string.Format(" UnID = {0} and key <> {1} and EnID = {2}  ", row["UnId"], row["Key"],row["EnID"]));
                if (rows.Length > 0)
                {
                    return true;
                }
                return false;
            }

            if (row["LB"].Equals("分部-专业"))
            {
                rows = this.Result.Select(string.Format(" PPARENTID = {0} and ID <> {0}  and LB = '清单' and UnID = {1}", row["ID"],row["UnID"]));
                if (rows.Length > 0)
                {
                    return true;
                }
                return false;
            }
            if (row["LB"].Equals("分部-章"))
            {
                rows = this.Result.Select(string.Format(" CPARENTID = {0} and ID <> {0}  and LB = '清单' and UnID = {1} and PPARENTID = {2}", row["ID"], row["UnID"], row["PPARENTID"]));
                if (rows.Length > 0)
                {
                    return true;
                }
                return false;
            }
            if (row["LB"].Equals("分部-节"))
            {
                rows = this.Result.Select(string.Format(" PID = {0}  and ID <> {0} and LB = '清单' and UnID = {1} and PPARENTID ={2} and CPARENTID = {3}", row["ID"], row["UnID"], row["PPARENTID"], row["CPARENTID"]));
                if (rows.Length > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 根据清单对象递归所有的
        /// </summary>
        /// <param name="info"></param>
        public void DoQuery(DataRow row)
        {
                /*if (info.IParent == null)
                {
                    if (!this.Result.Contains(info))
                        this.Result.Add(info);
                    return;
                }
                if (!this.Result.Contains(info))
                    this.Result.Add(info);
                this.DoQuery(info.IParent);*/
            

        }


        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void groupControl1_Click(object sender, EventArgs e)
        {
          
            this.checkEdit1.Checked = true;
            this.checkEdit2.Checked = false;
            this.checkedListBoxControl1.Enabled = this.checkEdit2.Checked;
            this.radioGroup1.Enabled  = this.checkEdit1.Checked;
            radioGroup1_SelectedIndexChanged(this.radioGroup1, null);
        }

        private void groupControl2_Click(object sender, EventArgs e)
        {
            this.checkEdit2.Checked = true;
            this.checkEdit1.Checked = false;
            //启用筛选条件2
            this.checkedListBoxControl1.Enabled = this.checkEdit2.Checked;
            this.radioGroup1.Enabled = this.labelControl3.Enabled = this.labelControl1.Enabled = this.spinEdit1.Enabled = this.spinEdit2.Enabled = this.lookUpEdit1.Enabled  = this.checkEdit1.Checked;

        }

        private void CPro_Sub_Data_Filter_Load(object sender, EventArgs e)
        {
            this.Result = this.DataSource.Clone();
            radioGroup1_SelectedIndexChanged(this.radioGroup1,null);
            DoLoadData();
            
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DoLoadData()
        {
            if (this.DataSource != null)
            {
                //绑定清单数据
                IEnumerable<DataRow> infos = (from i in this.DataSource.AsEnumerable()
                                                       where i["LB"].Equals("清单") 
                                                      select i).Distinct(new EntrtyComparer());

                DataTable table = this.DataSource.Clone();
                infos.CopyToDataTable(table, LoadOption.OverwriteChanges);
                this.lookUpEdit1.Properties.DataSource = table;
                
            }
        }
    }
}