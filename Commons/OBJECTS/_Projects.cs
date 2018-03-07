/*
 * 当前项目的对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Projects : _COBJECTS
    {

        /// <summary>
        /// 通知单位工程编辑
        /// </summary>
        /// <param name="sender">引发编辑的对象</param>
        public override void BeginEdit(object sender)
        {
            //状态修改为编辑

            switch (this.ObjectState)
            {
                case EObjectState.Creating:
                case EObjectState.Modify:
                case EObjectState.Created:

                    break;
                default:
                    this.ObjectState = EObjectState.Modify;
                    //通知指定行的状态为修改
                    this.StructSource.ModelProject.SetModifty(this.ID);
                    break;
            }
        }
       
        public override int ObjectKey
        {
            get
            {
                return base.ObjectKey;
            }
            set
            {
                base.ObjectKey = value;
            }
        }

        /// <summary>
        /// 单位工程排序
        /// </summary>
        private int m_UnSort = 0;
        private int m_EnSort = 0;
        /// <summary>
        /// 获取单位工程当前排序
        /// </summary>
        public int UnSort
        {
            get
            {
                return this.m_UnSort;
            }
            set
            {
                this.m_UnSort = value;
            }
        }

        /// <summary>
        /// 获取单项工程的排序
        /// </summary>
        public int EnSort
        {
            get
            {
                return this.m_EnSort;
            }
            set
            {
                this.m_EnSort = value;
            }
        }

        public _Projects()
            : base()
        {
            //项目的状态默认为已经创建结束，自身并不属于某个容器中
            this.ImageIndex = 0;
            this.ObjectState = EObjectState.Created;
        }
        public _Projects(_COBJECTS p_Info)
            : base(p_Info)
        {
            //项目的状态默认为已经创建结束，自身并不属于某个容器中
            this.ImageIndex = 0;
            this.ObjectState = EObjectState.Created;
        }

        /// <summary>
        /// 重写初始化方法
        /// </summary>
        public override void Init()
        {
            base.Init();

            //项目结构数据(数据包含当前项目下的所有数据集)
            this.StructSource = new _StructSource();
            this.StructSource.ProjBuilder();
            //初始化数据
            //默认项目编号为P
            this.CODE = "GC";
            this.PID = -1;
            //当前数据对象是项目需要构造项目容器集
            this.ObjectType = EObjectType.PROJECT;
            //主目录对象
            this.Directory = new _Directory(this);
            this.Directory.PKey = -1;
            this.Directory.ImageIndex = 0;
            this.Directory.Deep = 0;
            this.Directory.Sort = 0;
            //构造结构对象
            this.StrustObject = new _DataObjectList();
            //项目数据信息
            this.DataObject.Add("项目信息", new _BasicInformation());
            this.NonSeriObject.Add("工程统计", new _ProjStatistics());
            //this.DataObject.Add("导入导出", new _Export(this));
            //此处添加项目汇总分析，分部分项，措施项目，工料机汇总，项目报表 等对象
            //this.DataObject.Add("汇总分析", new _ProMetaanalysis(this));
            //展现类准备工作
            this.Reveal = new _Reveal(this);
            //属性准备
            this.Property = new _Pro_Property(this);

        }

        /*public override void Init(GOLDSOFT.QDJJ.COMMONS._Application p_App)
        {
            base.Init(p_App);
        }*/

        /// <summary>
        /// 创建一个子对象(仅获取一个新的单项工程对象)
        /// </summary>
        /// <returns></returns>
        public override _COBJECTS Create()
        {
            _Engineering info = new _Engineering(this);
            //info.ObjectState = EObjectState.Creating;
            //项目是唯一的每个新项目都从当前0开始标识
            /*info.Directory.PKey = this.Directory.Key;
            info.Directory.ImageIndex = 1;
            info.Directory.Deep = 1;*/
            //通过项目创建单项工程对象时候自动继承项目的属性数据
            //info.Property.Basis = this.Property.Basis.Copy() as _CBasis;
            info.Parent = this;
            this.Clone(info);
            info.PID = this.ID;
            info.Deep = 1;
            info.Sort = this.EnSort + 1;
            //初始化项目编码
            info.CODE = this.CODE + info.Sort.ToString().PadLeft(2, '0');
            
            return info;
        }

        /// <summary>
        /// 添加一个已经存在的单项工程对象到当前项目下
        /// </summary>
        /// <param name="p_Info"></param>
        /// <returns></returns>
        public override _COBJECTS Add(_COBJECTS p_Info)
        {
            this.Clone(p_Info);
            p_Info.PID = this.ID;
            p_Info.Deep = 1;
            //初始化项目编码
            p_Info.Property.Basis.CODE = this.Property.Basis.CODE + p_Info.Directory.Sort.ToString().PadLeft(3, '0');
            this.StructSource.ModelProject.Add(p_Info);
            return p_Info;
        }





        public override void OutSerializable()
        {

        }

        /// <summary>
        /// 实现序列化后的方法 此方法以后被删除
        /// </summary>
        /// <param name="e"></param>
        public override void InSerializable(object e)
        {
            this.StrustObject = new _DataObjectList();
            this.NonSeriObject = new _DataObjectList();
            this.Files = e as _Files;
            this.Reveal = new _Reveal(this);
            this.Property = new _Pro_Property(this);
            
            this.NonSeriObject.Add("工程统计", new _ProjStatistics());

        }
    }
}
