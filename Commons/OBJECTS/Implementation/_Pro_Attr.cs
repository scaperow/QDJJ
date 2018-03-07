using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Pro_Attr:IAttributes
    {

        public _Pro_Attr(_COBJECTS p_Info)
        {
            this.m_Parent = p_Info;
        }

        /// <summary>
        /// 当前基础类别的父类别(若为顶级类别此属性为null)
        /// </summary>
        private _COBJECTS m_Parent = null;
        /// <summary>
        /// 获取当前基础父类别
        /// </summary>
        public _COBJECTS Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }

        #region IAttributes 成员


        /// <summary>
        /// 项目的属性转换接口实现
        /// </summary>
        /// <param name="p_Table"></param>
        public void ConvertToDisplay(CAttributes p_Table)
        {
            //项目属性
            int key = p_Table.Add(-1, "项目信息");
            p_Table.Add(key, "项目名称", this.Parent.Name, "Name", this.Parent);
            p_Table.Add(key, "项目编号", this.Parent.CODE, "CODE", this.Parent);
            p_Table.Add(key, "工程地点", this.Parent.PGCDD, "PGCDD", this.Parent);
            p_Table.Add(key, "纳税地点", this.Parent.PNSDD, "PNSDD", this.Parent);
            p_Table.Add(key, "计费程序", this.Parent.PJFCX, "PJFCX", this.Parent);
            p_Table.Add(key, "清单规则", this.Parent.QDGZ, "QDGZ", this.Parent);
            p_Table.Add(key, "定额规则", this.Parent.DEGZ, "DEGZ", this.Parent);
            //单项工程统计
            
            //key = p_Table.Add(-1, "单项工程统计");
            object EnCount = this.Parent.StructSource.ModelProject.Compute("COUNT(ID)", "DEEP = 1");
            object UnCount = this.Parent.StructSource.ModelProject.Compute("count(ID)", "DEEP = 2");
            p_Table.Add(key, "单项工程", EnCount);
            p_Table.Add(key, "单位工程", UnCount);
        }

        /// <summary>
        /// 获取属性的源类型
        /// </summary>
        object IAttributes.Source
        {
            get
            {
                return this;
            }
            set
            {

            }

        }
        /// <summary>
        /// 回写处理
        /// </summary>
        /// <param name="p_Table"></param>
        /// <param name="e"></param>
        public void ChangeValue(CAttributes p_Table, System.Data.DataRowChangeEventArgs e)
        {
            object obj = e.Row["Source"];//源对象
            object value = e.Row["Value"];        //显示的值
            string filed = e.Row["FiledName"].ToString();//源字段名称(表是字段名称/对象为对象的属性名称)
            object type = e.Row["Type"];
            //在obj中找到字段进行处理
            System.Reflection.PropertyInfo info = obj.GetType().GetProperty(filed);
            info.SetValue(obj, value, null);
        }

        #endregion
    }
}
