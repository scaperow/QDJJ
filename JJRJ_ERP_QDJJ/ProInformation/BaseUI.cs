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
using ZiboSoft.Commons.Common;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class BaseUI : BaseInfo
    {
        public BaseUI()
        {
            InitializeComponent();
            //if (APP.UnInformation != null && APP.UnInformation.OnCheck != null && UnInformation_OnCheck != null)
            if (APP.UnInformation != null)
            {
                APP.UnInformation.OnCheck -= new _UnInformation.CheckHandler(UnInformation_OnCheck);
                APP.UnInformation.OnCheck += new _UnInformation.CheckHandler(UnInformation_OnCheck);
            }
        }
        public BaseUI(_UnitProject p_CUnitProject)
        {
            this.Activitie = p_CUnitProject;
            InitializeComponent();
            APP.UnInformation.OnCheck -= new _UnInformation.CheckHandler(UnInformation_OnCheck);
            APP.UnInformation.OnCheck += new _UnInformation.CheckHandler(UnInformation_OnCheck);
        }


        #region   字段属性
        /// <summary>
        /// 当前行
        /// </summary>
        public DataRowView CurrRow
        {
            get { return this.bindingSource1.Current as DataRowView; }
        }
        /// <summary>
        /// 复制行
        /// </summary>
        private DataRowView _copyRow = null;
        /// <summary>
        /// 复制行
        /// </summary>
        public DataRowView CopyRow
        {
            get { return _copyRow; }
        }

        /// <summary>
        /// 需要验证的字段
        /// </summary>
        private string[] _arrCheckColl = null;
        /// <summary>
        /// 需要验证的字段
        /// </summary>
        protected string[] ArrCheckColl
        {
            get { return _arrCheckColl; }
            set { _arrCheckColl = value; }
        }
        /// <summary>
        /// 需要验证的字段 的提示字符串
        /// </summary>
        private string[] _arrCheckMess;
        /// <summary>
        /// 需要验证的字段 的提示字符串
        /// </summary>
        protected string[] ArrCheckMess
        {
            get { return _arrCheckMess; }
            set { _arrCheckMess = value; }
        }
        /// <summary>
        /// 验证结果
        /// </summary>
        private bool _checkResult;
        /// <summary>
        /// 验证结果
        /// </summary>
        protected bool CheckResult
        {
            get { return _checkResult; }
        }

        /// <summary>
        /// 工程信息表
        /// </summary>
        public _InformationTable InfTable
        {
            get
            {
                return APP.UnInformation.InformationTable;
            }
        }
        #endregion

        #region 操作

        #region 确认清单编号【分空验证】
        protected virtual void btnScreenQDBH_Click(object sender, EventArgs e)
        {

            _checkResult = false;
            if (ArrCheckColl != null && ArrCheckMess != null)
            {
                for (int i = 0; i < ArrCheckColl.Length; i++)
                {
                    CheckNull(ArrCheckColl[i], ArrCheckMess[i]);
                    if (_checkResult)
                    {
                        return;
                    }
                }
            }

        }
        /// <summary>
        /// 分空验证
        /// </summary>
        /// <param name="CollName"></param>
        /// <param name="AltMessage"></param>
        protected void CheckNull(string CollName, string AltMessage)
        {
            if (!_checkResult)
            {
                DataRowView drCurr = this.bindingSource1.Current as DataRowView;
                if (null == drCurr) return;
                if (drCurr.Row.Table.Columns.Contains(CollName) && string.IsNullOrEmpty(drCurr[CollName].ToString()))
                {
                    MsgBox.Alert("请输入" + AltMessage);
                    _checkResult = true;
                }
            }
        }
        #endregion

        #region 刷新数量
        private void btnRefreshGCL_Click(object sender, EventArgs e)
        {
            DataRowView drCurr = this.bindingSource1.Current as DataRowView;
            if (drCurr == null) return;
            //string strTJ = string.Format("{0}[{1}]", drCurr["FormMC"], drCurr["ID"]);//条件  清单、子目标识
            //string strTJ = string.Format("{0}[{1}]", drCurrent["FormMC"], drCurrent["ID"]);//条件  清单、子目标识

            string strTJ = "";
            if (string.IsNullOrEmpty(drCurr["BZ"].ToString()))
            {
                strTJ = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "G" + APP.GoldSoftClient.GlodSoftDiscern.CurrNo + "G";
                drCurr["BZ"] = strTJ;
            }
            else
            {
                strTJ = drCurr["BZ"].ToString();
            }
            this.InformationForm.UpdateGCL(null, strTJ, ToolKit.ParseDecimal(drCurr["SWGCL"]));
        }
        #endregion

        #region 刷新描述
        protected virtual void btnRefreshQDMC_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 右键处理
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RemoveNull(0);
            AddRow(false);
        }
        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="isFirst"></param>
        protected void AddRow(bool isFirst)
        {
            if (isFirst && this.bindingSource1.Count > 0)
            {
                return;
            }
            this.bindingSource1.AddNew();
            if (this.bindingSource1.Current == null) return;
            DataRowView curr = (this.bindingSource1.Current as DataRowView);
            if (curr != null)
            {
                curr["XH"] = bindingSource1.Count;
            }
            this.bindingSource1.ResetBindings(false);
        }

        #region 给行添加默认值  【没有使用】
        /// <summary>
        /// 给行添加默认值
        /// </summary>
        /// <param name="strArrDefault">默认值数组</param>
        protected void AddRowDefault(string[] strArrDefault)
        {
            DataRowView curr = (this.bindingSource1.Current as DataRowView);
            //curr["FormMC"] = string.Format("{0}【{1}】", curr["FormMC"], curr["ID"]);
            foreach (string item in strArrDefault)
            {
                string[] strDef = new string[2];
                strDef = item.Split(',');
                curr[strDef[0]] = strDef[1];
            }
            this.bindingSource1.ResetBindings(false);
        }
        #endregion

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult r = MsgBox.Show("是否删除当前选中行？", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == r)
            {
                try
                {
                    ///若删除项为复制项  清空剪切板
                    if (this._copyRow == (this.bindingSource1.Current as DataRowView))
                    {
                        this._copyRow = null;
                    }
                    DataRowView currRow = this.bindingSource1.Current as DataRowView;
                    if (this.InformationForm != null)
                    {
                        //this.InformationForm.Remove(string.Format("{0}[{1}]", currRow["FormMC"], currRow["ID"]));
                        this.InformationForm.Remove(currRow["BZ"].ToString());
                    }
                    this.bindingSource1.RemoveCurrent();
                    ///重新排列序号
                    for (int i = this.bindingSource1.Count; i > 0; i--)
                    {
                        (this.bindingSource1[i - 1] as DataRowView)["XH"] = i;
                    }
                    ///刷新
                    this.bindingSource1.ResetBindings(false);
                }
                catch (Exception)
                { }

            }
        }
        #region 移除 无效数据项
        /// <summary>
        /// 移除 无效数据项
        /// </summary>
        protected void RemoveNull()
        {
            this.RemoveNull(0);
        }
        /// <summary>
        /// 移除 无效数据项
        /// </summary>
        protected void RemoveNull(int intStart)
        {
            try
            {
                ///清空剪切板
                this._copyRow = null;

                ///拼接  空项 筛选条件
                StringBuilder strWhere = new StringBuilder(" 1=1 ");
                if (null != ArrCheckColl)
                {
                    foreach (string collName in ArrCheckColl)
                    {
                        strWhere.Append(string.Format(" and {0} is null", collName));
                    }
                }
                else
                {
                    strWhere.Append(" and 1<> 1");
                }
                this.bindingSource1.Filter = strWhere.ToString();
                ///移除空项  非当前项
                for (int i = this.bindingSource1.Count; i > intStart; i--)
                {
                    this.bindingSource1.RemoveAt(i - 1);
                }
                ///移除 筛选条件
                this.bindingSource1.Filter = "";
                ///重新排列序号
                for (int i = this.bindingSource1.Count; i > 0; i--)
                {
                    (this.bindingSource1[i - 1] as DataRowView)["XH"] = i;
                }
                ///刷新
                this.bindingSource1.ResetBindings(false);
            }
            catch (Exception)
            { }
        }
        #endregion
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bindingSource1.Current != null)
            {
                this._copyRow = bindingSource1.Current as DataRowView;
            }
        }
        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPasteRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.CopyRow != null)
                {

                    DataRowView drTemp = bindingSource1.AddNew() as DataRowView;
                    for (int i = drTemp.Row.ItemArray.Length - 1; i > 0; i--)
                    {
                        drTemp[i] = this.CopyRow[i];
                    }
                    drTemp["XH"] = bindingSource1.Count;
                    drTemp["BZ"] = string.Empty;
                    this.bindingSource1.EndEdit();
                }
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// 上移
        /// 作者:付强
        /// 功能:DataRow上移
        /// 日期:2013-8-29
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void moveUp()
        {
            try
            {
                DataTable dt = this.bindingSource1.DataSource as DataTable;
                DataRowView currRow = this.bindingSource1.Current as DataRowView;
                int index = dt.Rows.IndexOf(currRow.Row);

                if (index <= 0)
                    return;
                DataRow newRow = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newRow[i] = currRow[i];
                }
                this.bindingSource1.MovePrevious();
                dt.Rows.RemoveAt(index);
                dt.Rows.InsertAt(newRow, index - 1);

                

                //if (index - 1 == 0)
                //{
                //    this.bindingSource1.MoveFirst();
                //}
                //else
                //{
                this.bindingSource1.MovePrevious();
                //}
                //重新排列序号
                for (int i = this.bindingSource1.Count; i > 0; i--)
                {
                    (this.bindingSource1[i - 1] as DataRowView)["XH"] = i;
                }
                ///刷新
                //this.bindingSource1.ResetBindings(false);

            }
            catch (Exception)
            { }
        
        }
        /// <summary>
        /// 下移
        /// 作者:付强
        /// 功能:DataRow下移
        /// 日期:2013-8-29
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void moveDown()
        {
            try
            {
                DataTable dt = this.bindingSource1.DataSource as DataTable;
                DataRowView currRow = this.bindingSource1.Current as DataRowView;
                int index = dt.Rows.IndexOf(currRow.Row);

                if (index >= dt.Rows.Count)
                    return;
                DataRow newRow = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newRow[i] = currRow[i];
                }
                dt.Rows.RemoveAt(index);
                dt.Rows.InsertAt(newRow, index + 1);


                this.bindingSource1.MoveNext();
                ///重新排列序号
                for (int i = this.bindingSource1.Count; i > 0; i--)
                {
                    (this.bindingSource1[i - 1] as DataRowView)["XH"] = i;
                }
                ///刷新
                this.bindingSource1.ResetBindings(false);
            }
            catch (Exception)
            { }
        }


        private void btnMoveUp_ItemClick(object sender, EventArgs e)
        {
            moveUp();
        }
        private void btnMoveDown_ItemClick(object sender, EventArgs e)
        {
            moveDown();
        }
        /// <summary>
        /// 数据提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDataErr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRowView currRow = this.bindingSource1.Current as DataRowView;
                if (currRow == null) return;
                DataErr formDataErr = new DataErr();
                formDataErr.StrFormName = toString(currRow["FormMC"]);
                StringBuilder strTemp = new StringBuilder();
                foreach (DataColumn item in currRow.DataView.Table.Columns)
                {
                    strTemp.Append("," + item.ColumnName + ":" + currRow[item.ColumnName]);
                }
                //formDataErr.StrFormName = this.Params.ToString();
                formDataErr.StrColNameVal += "{" + strTemp.ToString().Substring(1, strTemp.ToString().Length - 1) + "}";
                formDataErr.ShowDialog();
            }
            catch { }
        }
        /// <summary>
        /// 点击右键
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="e"></param>
        protected void SetPopBar(DevExpress.XtraGrid.GridControl gv, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gv.FocusedView.CalcHitInfo(e.Location) as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo;
            if (e.Button == MouseButtons.Right)
            {
                if (hi.InRow)
                {
                    this.btnDelRow.Enabled = true;
                    this.btnCopyRow.Enabled = true;
                    this.btnDataErr.Enabled = true;
                    this.btnMoveUp.Enabled = true;
                    this.btnMoveDown.Enabled = true;
                }
                else
                {
                    this.btnDelRow.Enabled = false;
                    this.btnCopyRow.Enabled = false;
                    this.btnDataErr.Enabled = false;
                    this.btnMoveUp.Enabled = false;
                    this.btnMoveDown.Enabled = false;
                }
                if (null == CopyRow)
                {
                    this.btnPasteRow.Enabled = false;
                }
                else
                {
                    this.btnPasteRow.Enabled = true;
                }
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        #endregion

        /// <summary>
        /// 通知单位工程 界面值发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //this.Activitie.BeginEdit(null);
        }
        /// <summary>
        /// 刷新变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Check"></param>
        protected void UnInformation_OnCheck(object sender, bool Check)
        {
            DataRow row = sender as DataRow;
            if (row == null)
            {
                return;
            }
            string[] strTemp = CDataConvert.ConToValue<string>(row["TJ"]).Split('：');
            if (strTemp.Length > 1)
            {
                string[] arrtemp = strTemp[1].Split(new char[] { '[', ']' });
                if (arrtemp.Length > 1)
                {
                    DataTable dt = this.bindingSource1.DataSource as DataTable;
                    if (null != dt)
                    {
                        DataRow[] rows = dt.Select(string.Format("ID={0}", arrtemp[1]));
                        if (rows.Length > 0) rows[0]["IsFresh"] = Check;
                    }
                }


            }
        }
        #endregion

        /// <summary>
        /// 调试 时候启用的弹窗，正式发布以后 请注意屏蔽此方法内容
        /// </summary>
        /// <param name="msg"></param>
        protected void DebugErr(string msg)
        {
            Alert(msg);
            //Application.Restart();
        }

        #region 绑定下拉框 返回的值
        /// <summary>
        /// 绑定下拉框 返回的值
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="CurrRowView"></param>
        protected void bindPopReturn(popControl Sender, DataRowView CurrRowView)
        {
            DataRowView currRow = this.bindingSource1.Current as DataRowView;
            if (null == currRow) { return; }
            ///绑定返回值
            if (null != Sender.ColName)
            {
                foreach (string item in Sender.ColName)
                {
                    string[] strField = item.Split('|');
                    if (strField.Length == 3)
                    {
                        try
                        {
                            if (currRow[strField[2].Trim()] == CurrRowView[strField[1].Trim()])
                            {
                                continue;
                            }
                            currRow[strField[2].Trim()] = CurrRowView[strField[1].Trim()];
                            /// 清空关联项
                            if (null != Sender.RemoveDefaultColName)
                            {
                                foreach (string itemClear in Sender.RemoveDefaultColName)
                                {
                                    currRow[itemClear.Trim()] = DBNull.Value;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //DebugErr(ex.Message);
                        }
                    }
                }
            }
            this.bindingSource1.ResetBindings(false);
        }
        #endregion

        #region 分隔符 隔开的字符串、表 列 转换成 Table
        /// <summary>
        /// 表中用分隔符 隔开的字符串列 处理成新表
        /// </summary>
        /// <param name="DtSource;">数据源</param>
        /// <param name="ColName">列名</param>
        /// <param name="cSeparator">分隔符</param>
        /// <returns>处理后的DataTable</returns>
        protected DataTable strToTable(BindingSource DtSource, string ColName, params char[] cSeparator)
        {
            DataTable dt = null;
            try
            {
                if (DtSource != null && 0 < DtSource.Count)
                {
                    dt = new DataTable();
                    dt.Columns.Add(ColName, typeof(string));
                    foreach (DataRowView drv in DtSource)
                    {
                        strToTable(dt, toString(drv[ColName]), ColName, cSeparator);
                    }
                }
            }
            catch { return null; };
            return dt;
        }
        /// <summary>
        /// 表中用分隔符 隔开的字符串列 处理成新表
        /// </summary>
        /// <param name="DtSource;">数据源</param>
        /// <param name="ColName">列名</param>
        /// <param name="arrRemoveStr">移除的字符串数组</param>
        /// <param name="cSeparator">分隔符</param>
        /// <returns>处理后的DataTable</returns>
        protected DataTable strToTable(BindingSource DtSource, string ColName, string[] arrRemoveStr, params char[] cSeparator)
        {
            DataTable dt = null;
            try
            {
                if (DtSource != null && 0 < DtSource.Count)
                {
                    dt = new DataTable();
                    dt.Columns.Add(ColName, typeof(string));
                    foreach (DataRowView drv in DtSource)
                    {
                        strToTable(dt, toString(drv[ColName]), ColName, arrRemoveStr, cSeparator);
                    }
                }
            }
            catch { return null; };
            return dt;
        }
        /// <summary>
        ///  分隔符 隔开的字符串转换成 Table 【默认逗号分隔】
        /// </summary>
        /// <param name="strItems">分隔符 隔开的字符串</param>
        /// <param name="ColName">列名</param>
        /// <returns>处理后的DataTable</returns>
        protected DataTable strToTable(string strItems, string ColName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(ColName, typeof(string));
            strToTable(dt, strItems, ColName);
            return dt;
        }
        /// <summary>
        ///  分隔符 隔开的字符串转换成 Table
        /// </summary>
        /// <param name="strItems">分隔符 隔开的字符串</param>
        /// <param name="ColName">列名</param>
        /// <returns>处理后的DataTable</returns>
        protected DataTable strToTable(string strItems, string ColName, params char[] cSeparator)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(ColName, typeof(string));
            strToTable(dt, strItems, ColName, ',');
            return dt;
        }
        /// <summary>
        /// 分隔符 隔开的字符串追加到表中【默认逗号分隔】
        /// </summary>
        /// <param name="dtTemp">需要追加到的表</param>
        /// <param name="strItems">分隔符 隔开的字符串</param>
        /// <param name="ColName">列名</param>
        protected void strToTable(DataTable dtTemp, string strItems, string ColName)
        {
            strToTable(dtTemp, strItems, ColName, ',');
        }
        /// <summary>
        /// 分隔符 隔开的字符串追加到表中
        /// </summary>
        /// <param name="dtTemp">需要追加到的表</param>
        /// <param name="strItems">逗号隔开的字符串</param>
        /// <param name="ColName">列名</param>
        /// <param name="cSeparator">分隔符</param>
        protected void strToTable(DataTable dtTemp, string strItems, string ColName, params char[] cSeparator)
        {
            strToTable(dtTemp, strItems, ColName, null, cSeparator);
        }
        /// <summary>
        /// 分隔符 隔开的字符串追加到表中
        /// </summary>
        /// <param name="dtTemp">需要追加到的表</param>
        /// <param name="strItems">逗号隔开的字符串</param>
        /// <param name="ColName">列名</param>
        /// <param name="arrRemoveStr">移除的字符串数组</param>
        /// <param name="cSeparator">分隔符</param>
        protected void strToTable(DataTable dtTemp, string strItems, string ColName, string[] arrRemoveStr, params char[] cSeparator)
        {
            if (dtTemp == null)
            {
                dtTemp = new DataTable();
            }
            if (!dtTemp.Columns.Contains(ColName))
            {
                dtTemp.Columns.Add(ColName, typeof(string));
            }
            if (strItems == null)
            {
                strItems = "";
            }
            string[] arrStrTemp = strItems.Split(cSeparator);
            foreach (string item in arrStrTemp)
            {
                string strTemp = item;
                if (arrRemoveStr != null)
                {
                    foreach (string strItem in arrRemoveStr)
                    {
                        strTemp = item.Replace(strItem, "");
                        if (string.IsNullOrEmpty(strTemp))
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(strTemp))
                {
                    DataRow row = dtTemp.NewRow();
                    row[ColName] = strTemp;
                    dtTemp.Rows.Add(row);
                }

            }
        }
        /// <summary>
        /// 分隔符 隔开的字符串追加到表中
        /// </summary>
        /// <param name="dtTemp">需要追加到的表</param>
        /// <param name="strItems">逗号隔开的字符串</param>
        /// <param name="ColName">列名</param>
        /// <param name="cSeparator">分隔符</param>
        protected void strToTable(DataTable dtTemp, string strItems, string ColName, params string[] cSeparator)
        {
            if (dtTemp == null)
            {
                dtTemp = new DataTable();
            }
            if (!dtTemp.Columns.Contains(ColName))
            {
                dtTemp.Columns.Add(ColName, typeof(string));
            }
            string[] strTemp = strItems.Split(cSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in strTemp)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    DataRow row = dtTemp.NewRow();
                    row[ColName] = item;
                    dtTemp.Rows.Add(row);
                }
            }
        }
        #endregion

        #region 移除Table重复数据
        /// <summary>
        /// 移除Table重复数据
        /// </summary>
        /// <param name="dtTemp">Table</param>
        /// <param name="obj">判断重复项的列集合</param>
        /// <returns></returns>
        protected DataTable RemoveRepeat(DataTable dtTemp, params string[] obj)
        {
            if (dtTemp != null)
            {
                foreach (string item in obj)
                {
                    if (!dtTemp.Columns.Contains(item))
                    {
                        return null;
                    }
                }
                return dtTemp.DefaultView.ToTable(true, obj);
            }
            return null;
        }
        protected DataTable RemoveRepeat(BindingSource bdSource, params string[] obj)
        {
            if (bdSource != null)
            {
                DataRowView drv = bdSource.Current as DataRowView;
                if (drv != null)
                {
                    return RemoveRepeat(drv.DataView.Table, obj);
                }
            }
            return null;
        }
        #endregion

        #region 类型转换
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string toString(object obj)
        {
            if (obj == null)
            {
                return string.Empty.Trim();
            }
            else
            {
                return obj.ToString().Trim();
            }
        }
        #endregion

        /// <summary>
        /// 刷新的位置类型
        /// </summary>
        public enum WZLX
        {
            分部分项,
            措施项目
        }

        #region 根据数值获取范围
        protected enum BHTYPE
        {
            全部包含,
            只包含前项
        }
        /// <summary>
        /// 根据数值获取范围
        /// </summary>
        /// <param name="oYQCS">用户录入的值</param>
        /// <param name="BHTYPE">包含类型【全部包含，只包含前项】</param>
        /// <param name="dtTemp">数据源</param>
        /// <param name="strColName">判断的字段</param>
        /// <returns>库中的工程要求参数</returns>
        protected string GetFWBySZ(object oYQCS, BHTYPE eBHTYPE, DataTable dtTemp, string strColName)
        {
            if (toString(oYQCS).Split('～').Length != 2)
            {
                if (!dtTemp.Columns.Contains(strColName)) return toString(oYQCS);

                decimal dYQCS = ToolKit.ParseDecimal(oYQCS);
                foreach (DataRow item in dtTemp.Rows)
                {
                    string[] arrStr = toString(item[strColName]).Split('～');
                    if (arrStr.Length != 2) { continue; }

                    switch (eBHTYPE)
                    {
                        case BHTYPE.全部包含:
                            if (dYQCS >= ToolKit.ParseDecimal(arrStr[0]) && dYQCS <= ToolKit.ParseDecimal(arrStr[1]))
                            {
                                return toString(item[strColName]);
                            }
                            break;
                        case BHTYPE.只包含前项:
                            if (dYQCS >= ToolKit.ParseDecimal(arrStr[0]) && dYQCS < ToolKit.ParseDecimal(arrStr[1]))
                            {
                                return toString(item[strColName]);
                            }
                            break;
                    }
                }
            }
            return toString(oYQCS);
        }
        #endregion

        #region 根据范围截取成两个字段【最大值和最小值】
        protected DataTable SplitDataFW(DataTable DataSource, string FWColmName, string MaxColmName, string MinColmName, params char[] strSeparator)
        {
            if (DataSource == null) return DataSource;
            if (!DataSource.Columns.Contains(FWColmName)) return DataSource;
            if (DataSource.Columns.Contains(MaxColmName)) return DataSource;
            if (DataSource.Columns.Contains(MinColmName)) return DataSource;

            DataTable dtTemp = DataSource.Copy();
            DataColumn MaxColm = new DataColumn(MaxColmName, typeof(int));
            DataColumn MinColm = new DataColumn(MinColmName, typeof(int));
            dtTemp.Columns.AddRange(new DataColumn[] { MaxColm, MinColm });
            foreach (DataRow item in dtTemp.Rows)
            {
                string[] ArrStrTemp = toString(item[FWColmName]).Split(strSeparator);
                if (ArrStrTemp.Length == 2)
                {
                    item[MinColmName] = ToolKit.ParseInt(ArrStrTemp[0]);
                    item[MaxColmName] = ToolKit.ParseInt(ArrStrTemp[1]);
                }
            }
            return dtTemp;
        }
        protected DataTable SplitDataFW(BindingSource bindingSource, string FWColmName, string MaxColmName, string MinColmName, params char[] strSeparator)
        {
            DataTable dt = bindingSource.DataSource as DataTable;
            if (dt == null)
                return null;
            else
                return SplitDataFW(dt, FWColmName, MaxColmName, MinColmName, strSeparator);
        }
        #endregion

    }
}