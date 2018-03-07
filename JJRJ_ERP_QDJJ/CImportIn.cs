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
using System.IO;
using ZiboSoft.Commons.Common;
using System.Collections;
using GOLDSOFT.QDJJ.UI.Class;

namespace GOLDSOFT.QDJJ.UI
{
    public partial class CImportIn : CBaseForm
    {

        private ArrayList m_ObjectList = null; 

        /// <summary>
        /// 进行导入操作的源数据对象(左边数据对象)
        /// </summary>
        private _COBJECTS m_Source = null;

        /// <summary>
        /// 仅当替换单位工程时候返回的替换后的对象数据
        /// </summary>
        public _COBJECTS ReplaceObject
        {
            get
            {
                if (this.m_ObjectList.Count == 1)
                {
                    return this.m_ObjectList[0] as _COBJECTS;
                }
                return null;
            }
        }

        /// <summary>
        /// 当前打开工程文件对象(右边控件数据对象)
        /// </summary>
        public _COBJECTS Source
        {
            get
            {
                return this.m_Source;
            }
            set
            {
                this.m_Source = value;
            }
        }

        public CImportIn()
        {
            InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //打开按钮操作(可能一次打开多个文件)
            DialogResult r = this.openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                m_ObjectList = new ArrayList();
                //选择文件大于一个的时候
                if (this.openFileDialog1.FileNames.Length > 1)
                {
                    this.lookUpEdit1.Enabled = true;
                    foreach (string str in this.openFileDialog1.FileNames)
                    {
                        this.OpenOneFile(str);
                    }
                }
                else
                {
                    this.lookUpEdit1.Enabled = false;
                    this.OpenOneFile(this.openFileDialog1.FileName);
                }
               
            }
        }

        /// <summary>
        /// 单独打开一个文件
        /// </summary>
        private void OpenOneFile(string p_fileName)
        {
            //此处进行预打开对象操作
            _Files files = new _Files();
            //创建文件对象 
            files.Init(p_fileName);
            if (files.Exists)
            {

                this.buttonEdit1.Text = files.FullName;
                //CResult result = APP.WorkFlows.Operaty.LoadOnlyObject(files);
                CResult result = CActionData.Load(files);
                if (result.Success)
                {
                    _COBJECTS obj = result.Value as _COBJECTS;
                    obj.Files = files;
                    m_ObjectList.Add(obj);
                    //初始化打开的文件对象
                    this.Init();
                }
                else
                {
                    //MessageBox.Show(result.ErrorInformation);
                }
            }
        }

        /// <summary>
        /// 初始化单位工程/也可能是单项工程 属性窗口(已经选择了打开单位工程文件此处进行预加载处理)
        /// </summary>
        private void Init()
        {
            if (this.m_ObjectList != null)
            {
                _COBJECTS obj = this.m_ObjectList[0] as _COBJECTS;
                this.textEdit1.Text = obj.Name;
                //默认选中第0项
                this.ctrlAttributes2.IDataSource = obj.Reveal.Attributes ;
                this.ctrlAttributes2.DataBind();

                //初始化look控件
                this.lookUpEdit1.Properties.DataSource = this.m_ObjectList;
                this.lookUpEdit1.EditValue = obj;
                
            }
        }

        /// <summary>
        /// 初始化项目属性窗口(当前必须拥有项目操作类型)
        /// </summary>
        private void InitLeft()
        {
            //将新的项目 导入\替换 的数据源对象
            this.ctrlAttributes1.IDataSource = this.m_Source.Reveal.Attributes;
            this.ctrlAttributes1.DataBind();
        }



        private void CImportIn_Load(object sender, EventArgs e)
        {
            InitLeft();
            InitOpear();
            
        }

        /// <summary>
        /// 初始化操作
        /// </summary>
        private void InitOpear()
        {
            try
            {
                //1.如果源数据是单项工程
                switch (this.m_Source.ObjectType)
                {
                    case EObjectType.UnitProject://单位工程 新的替换旧的
                        this.openFileDialog1.Multiselect = false;
                        break;
                    case EObjectType.Engineering://单项工程 新的添加到旧的里面
                        this.openFileDialog1.Multiselect = true;
                        break;
                }

                //2.如果源数据是单位工程
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch { }
                MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        private void lookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //this.lookUpEdit1.ShowPopup();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //确定导入计划 
            try
            {
               switch (this.m_Source.ObjectType)
               {
                    case  EObjectType.UnitProject://替换操作
                        
                            replace();
                           break;
                    case EObjectType.Engineering://导入操作
                           import();
                           break;
               }
            }
            catch (Exception ex)
            {
                try
                {
                    SendMailUtil.SendMail(ex);
                }
                catch{ }
                MessageBox.Show("操作出现异常，请联系管理人员。", "金建软件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        /// <summary>
        /// 导入单项工程
        /// </summary>
        private void replace()
        {
            if (this.m_ObjectList != null)
            {
                if (this.m_ObjectList.Count > 0)
                {
                    _COBJECTS s_COBJECTS = this.m_ObjectList[0] as _COBJECTS;
                    if (s_COBJECTS.IsDZBS)
                    {
                        if (this.m_Source.Name != s_COBJECTS.Name)
                        {
                             /*DialogResult dr = MsgBox.Show("匹配失败，是否继续", MessageBoxButtons.YesNo);
                             if (dr == DialogResult.No)
                             {
                                 this.DialogResult = DialogResult.No;
                                 return;
                             }*/
                        }
                    }
                    this.CurrentBusiness.Replace(this.m_Source, s_COBJECTS);
                    //替换成功
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        /// <summary>
        /// 具体导入实现
        /// </summary>
        private void import()
        {

            //倒入业务
            if (this.m_ObjectList != null)
            {
                if (this.m_ObjectList.Count > 0)
                {
                    this.CurrentBusiness.ImportIn(this.m_Source, this.m_ObjectList);
                    //添加导入成功
                    this.DialogResult = DialogResult.Yes;
                }
            }
            
                
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //根据选择获取值
            _UnitProject obj = this.lookUpEdit1.EditValue as _UnitProject;
            //路径
            this.textEdit1.Text = obj.Name;

            this.buttonEdit1.Text = obj.Files.FullName;
            //名称
            this.ctrlAttributes2.IDataSource = obj.Reveal.Attributes;
            this.ctrlAttributes2.DataBind();
        }
    }
}