/*
 此处修改可打开任何可用文件类型
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLODSOFT.QDJJ.BUSINESS;
using DevExpress.XtraTreeList.Nodes;
using GOLDSOFT.QDJJ.COMMONS.ZBS;
using ZiboSoft.Commons.Common;
using System.IO;
using DevExpress.XtraBars.Ribbon;
using GOLDSOFT.QDJJ.COMMONS;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class NewProjeByXml : CBaseForm
    {

        private _Files m_Files = null;

        /// <summary>
        /// 获取当前弹出框的父类窗体
        /// </summary>
        private RibbonForm m_Master = null;

        /// <summary>
        /// 获取当前弹出框的父类窗体
        /// </summary>
        public RibbonForm Master
        {
            get
            {
                return this.m_Master;
            }
            set
            {
                this.m_Master = value;
            }
        }

        public NewProjeByXml()
        {
            InitializeComponent();
        }



        #region --------------------------ZBS,TBS-------------------------
        建设项目 js;
        /// <summary>
        /// 根据文件反序列化为对象
        /// </summary>
        public void LoadByXml()
        {
            this.js = GOLDSOFT.QDJJ.COMMONS.CFiles.XmlDeserialize(typeof(建设项目), this.buttonEdit1.Text) as 建设项目;
            //APP.CurrentJSXM = this.js;
        }
        private List<单位工程> m_DW;
        private void BindTree()
        {
            m_DW = new List<单位工程>();
            LoadByXml();
            if (js != null)
            {
                TreeListNode node = this.treeList1.AppendNode(new object[] { "建设项目", js.项目名称, "" }, -1);

                foreach (单项工程 item in js.单项工程)
                {
                    TreeListNode node1 = this.treeList1.AppendNode(new object[] { "单项工程", item.单项工程名称, "" }, node);
                    if (item.单位工程 == null) continue;
                    foreach (单位工程 item1 in item.单位工程)
                    {
                        m_DW.Add(item1);
                        this.treeList1.AppendNode(new object[] { "单位工程", item1.单位工程名称, item1.清单专业 }, node1);
                    }
                }
                this.treeList1.ExpandAll();
                //this.UnExists();
            }


        }
        private void UnExists()
        {
            bool flag = false;
            string str = string.Empty;
            foreach (单位工程 item in this.m_DW)
            {
                foreach (单位工程 dw in this.m_DW)
                {
                    if (item.工程代号 == dw.工程代号 && !item.Equals(dw))
                    {
                        str += string.Format("{0}[{1}],", item.单位工程名称, item.工程代号);
                    }
                }
            }
            str = str.TrimEnd(',');
            if (str.Length > 0) flag = true;
            if (flag)
            {
                this.labelControl3.Text = "单位工程[工程代号]有重复,请检查。";
                //MsgBox.Show(str + "以上单位工程编号重复。", MessageBoxButtons.OK);
                this.labelControl3.Visible = true;
                this.simpleButton1.Enabled = false;
            }
            else
            {
                this.labelControl3.Visible = false;
                this.simpleButton1.Enabled = true;
            }
            //return flag;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Commit();
        }

        private void Commit()
        {
            if (this.buttonEdit1.Text != string.Empty)
            {
                switch (m_Files.FileType)
                {
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.单项工程:
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.单位工程:
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.项目文件:
                        this.DialogResult = DialogResult.Yes;
                        break;
                    case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.XML文件:
                        this.DialogResult = DialogResult.OK;
                        break;
                    default://不做任何操作

                        return;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// 加载窗体的时候调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewProjeByXml_Load(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "全部文件|*.*|项目文件|*.jxmx|工程文件|*.jgcx|TBS文件|*.tbs|ZBS文件|*.zbs|电子标书|*.JZBX";
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //此处判断打开文件的类型然后继续操作
                this.buttonEdit1.Text = this.openFileDialog1.FileName;
                //if (rdoTZDJ.Checked)
                //    APP.JJJC = 1;
                //else if (rdoDEDJ.Checked)
                //    APP.JJJC = 2;
                //else if (rdoSCDJ.Checked)
                //    APP.JJJC = 3;
                //else
                //    APP.JJJC = 1;
                //选择操作
                this.Opear();
                //BindTree();
            }

        }

        /// <summary>
        ///  打开操作筛选
        /// </summary>
        private void Opear()
        {


            FileInfo file = new FileInfo(this.openFileDialog1.FileName);
            m_Files = new _Files();
            m_Files.Init(file.FullName);
            APP.FileType = m_Files.FileType;
            switch (m_Files.FileType)
            {
                case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.单项工程:
                case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.单位工程:
                case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.项目文件:
                    this.ctrlAttributes1.Visible = true;
                    this.treeList1.Visible = false;
                    OpenObjects();
                    break;
                case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.电子标书:
                    try
                    {
                        //string filename = this.openFileDialog1.FileName.Replace(".JZBX", ".JXMX");
                        //update by fuqiang 2013.07.16
                        string filename = string.Format("{0}{1}", this.openFileDialog1.FileName.Substring(0, this.openFileDialog1.FileName.Length - 4), "JXMX");
                        File.Copy(this.openFileDialog1.FileName, filename, false);
                        this.openFileDialog1.FileName = filename;
                        this.ctrlAttributes1.Visible = true;
                        this.treeList1.Visible = false;
                        OpenObjects();
                    }
                    catch (Exception e)
                    {
                        switch (e.GetType().Name)
                        {
                            case "IOException":
                                string filename = this.openFileDialog1.SafeFileName.Replace("JZBX", "JXMX");
                                MsgBox.Show(string.Format("[{0}]文件已存在，请检查后再次导入", filename), MessageBoxButtons.OK);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.XML文件:
                    this.ctrlAttributes1.Visible = false;
                    this.treeList1.Visible = true;
                    BindTree();
                    break;
                case GOLDSOFT.QDJJ.COMMONS._Files.CFileType.工程信息文件:
                    MsgBox.Show("该文件为工程信息文件，请在工程信息中打开", MessageBoxButtons.OK);
                    break;
                default://不做任何操作
                    MessageBox.Show(this, _Prompt.无法识别的打开文件, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }




        }


  



        #region --------------------------打开基本文件操作--------------------------

        /// <summary>
        /// 打开已经有的项目对象(此处修改为线程操作)
        /// </summary>
        private void OpenObjects()
        {

            FileInfo info = new FileInfo(this.openFileDialog1.FileName);

            if (info != null)
            {
                if (info.Exists)
                {
                    //打开指定单位工程逻辑
                    CActionData.Load(info, this.m_Master as ApplicationForm);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        #endregion

    }
}
