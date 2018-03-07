using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    [Serializable]
    public class _Un_Attr:IAttributes
    {


        public _Un_Attr(_COBJECTS p_Info)
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
            //不显示基础类型信息
            //base.ConvertToDisplay(p_Table);
            int key = p_Table.Add(-1, "单位工程");
            p_Table.Add(key, "项目名称", this.Parent.Name, "Name", this.Parent);
            p_Table.Add(key, "工程编号", this.Parent.CODE, "CODE", this.Parent);
            p_Table.Add(key, "编制人资格证号", this.Parent.PlaitNo, "PlaitNo", this.Parent);
            p_Table.Add(key, "编制人", this.Parent.PlaitName, "PlaitName", this.Parent);
            p_Table.Add(key, "复核人", this.Parent.ReviewName, "ReviewName", this.Parent);
            p_Table.Add(key, "编制日期", this.Parent.PlaitDate, "PlaitDate", this.Parent);
            p_Table.Add(key, "复核日期", this.Parent.ReviewDate, "ReviewDate", this.Parent);
            p_Table.Add(key, "清单规则", this.Parent.QDGZ, "QDGZ", this.Parent);
            p_Table.Add(key, "清单名称", this.Parent.QDLibName, "QDLibName", this.Parent);
            p_Table.Add(key, "定额规则", this.Parent.DEGZ, "DEGZ", this.Parent);
            p_Table.Add(key, "定额名称", this.Parent.DELibName, "DELibName", this.Parent);
            p_Table.Add(key, "图集库", this.Parent.TJLibName, "LibName", this.Parent);
            p_Table.Add(key, "专业类别", this.Parent.PrfType, "PrfType", this.Parent);
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
