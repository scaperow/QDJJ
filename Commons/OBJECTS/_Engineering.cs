/*
    单项工程对象
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{

    [Serializable]
    public class _Engineering : _COBJECTS
    {
        public _Engineering()
            : base()
        {
            this.ImageIndex = 1;
        }
        public _Engineering(_COBJECTS p_Info)
            : base(p_Info)
        {
            //主目录对象(单项工程不在独立创建取消此方法)
            this.ImageIndex = 1; 
            this.Directory = new _Directory(this);
        }

        /// <summary>
        /// 重写初始化方法
        /// </summary>
        public override void Init()
        {
            base.Init();
            this.ObjectType = EObjectType.Engineering;
            //构造结构对象
            this.StrustObject = new _DataObjectList();
            //项目数据信息
            this.DataObject.Add("基本信息", new _BasicInformation());
            this.NonSeriObject.Add("工程统计", new _ProjStatistics());
            this.Reveal = new _Reveal(this);
            //属性准备
            this.Property = new _En_Property(this);
        }

        /// <summary>
        /// 创建一个子对象(仅获取一个新的单位工程对象)
        /// 如果单位工程是此方法调用获得说明单位工程属于项目中的单位工程
        /// </summary>
        /// <returns></returns>
        public new _UnitProject Create()
        {
            _UnitProject info = new _UnitProject(this);            
            this.Clone(info);
            info.PID = this.ID;
            info.Deep = 2;
            //此处添加可能的排序
            info.Sort = (this.Parent as _Projects).UnSort + 1;
            this.Clone(info);
            //初始化项目编码
            info.CODE = this.CODE + info.Sort.ToString().PadLeft(3, '0');
            return info;

            /*info.ObjectState = EObjectState.Creating;
            info.Directory.PKey = this.Directory.Key;
            info.Directory.ImageIndex = 2;
            info.Directory.Deep = 2;
            //通过项目创建单项工程对象时候自动继承项目的属性数据
            info.Property.Basis = this.Property.Basis.Copy() as _CBasis;
            //初始化项目编码
            info.Property.Code = this.Property.Basis.CODE + info.Directory.Sort.ToString().PadLeft(3, '0');
            return info;*/
        }

        /// <summary>
        /// 添加一个已经存在的单项工程对象到当前项目下
        /// </summary>
        /// <param name="p_Info"></param>
        /// <returns></returns>
        public override _COBJECTS Add(_COBJECTS p_Info)
        {
            p_Info.Parent = this;
            this.Clone(p_Info);
            p_Info.PID = this.ID;
            p_Info.Deep = 1;
            //初始化项目编码
            p_Info.CODE = this.CODE + p_Info.Sort.ToString().PadLeft(3, '0');
            p_Info.Sort = (this.Parent as _Projects).UnSort++;
            this.Parent.StructSource.ModelProject.Add(p_Info);
            return p_Info;

            /*p_Info.Directory = new _Directory(p_Info);
            p_Info.Parent = this;
            p_Info.ObjectState = EObjectState.Created;
            p_Info.Directory.PKey = this.Directory.Key;
            //项目是唯一的每个新项目都从当前0开始标识
            p_Info.Directory.ImageIndex = 2;
            p_Info.Directory.Deep = 2;
            //通过项目创建单项工程对象时候自动继承项目的属性数据
            string name = p_Info.Property.Basis.Name;
            p_Info.Property.Basis = this.Property.Basis.Copy() as _CBasis;
            p_Info.Property.Name = name;
            //初始化项目编码
            p_Info.Property.Code = this.Property.Basis.CODE + p_Info.Directory.Sort.ToString().PadLeft(3, '0');
            return base.Add(p_Info);*/
        }

        /*public override int UnitCount
        {
            get
            {
                return this.StrustObject.ObjectList.Count;
            }
        }*/

        public override void OutSerializable()
        {

        }

        public override void InSerializable(object e)
        {
            _Projects proj = e as _Projects;
            this.Parent = proj;
            this.StrustObject = new _DataObjectList();
            this.Reveal = new _Reveal(this);
            this.Property = new _En_Property(this);
            this.NonSeriObject = new _DataObjectList();
            this.NonSeriObject.Add("工程统计", new _ProjStatistics());
            //proj.StrustObject.Add(this.Directory.Key, this);
        }
    }
}
