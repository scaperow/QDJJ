using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class Command
    {
        /// <summary>
        /// 创建命令 名称
        /// </summary>
        public const string Create = "Create";

        /// <summary>
        /// 修改命令 名称
        /// </summary>
        public const string Modify = "Modify";

        /// <summary>
        /// 删除命令 名称
        /// </summary>
        public const string Delete = "Delete";
        /// <summary>
        /// 替换命令
        /// </summary>
        public const string Replace = "Replace";


        /// <summary>
        /// 根据方法名与别名获取指定对象的操作属性
        /// </summary>
        /// <param name="obj">指定对象</param>
        /// <param name="p_MethodName">方法名称</param>
        /// <param name="p_OtherName">别名（一个对象中的别名是唯一的）</param>
        /// <returns>操作属性</returns>
        public static ActionAttribute GetMethodAttribute(object obj, string p_MethodName, string p_OtherName)
        {
                Type tp = obj.GetType();
                MemberInfo[] infos = tp.GetMember(p_MethodName);
                //找到指定方法
                ActionAttribute myAttribute;
                foreach (MemberInfo info in infos)
                {
                    myAttribute = Attribute.GetCustomAttribute(info, typeof(ActionAttribute)) as ActionAttribute;
                    if (myAttribute != null)
                    {
                        if (myAttribute.OtherName == p_OtherName)
                        {
                            return myAttribute;

                        }
                    }
                }
                return null;
        }

        /// <summary>
        /// 根据ModfyAttrBute还原原始值
        /// </summary>
        /// <param name="p_Attr"></param>
        public static void ModifyObject(ModifyAttribute p_Attr)
        {
            Type tp = p_Attr.Source.GetType();
            PropertyInfo info = tp.GetProperty(p_Attr.PropertyName);
            if(info != null)
            {
                info.SetValue(p_Attr.Source, p_Attr.OriginalValue,null);
            }
        }

        /// <summary>
        /// 根据ModfyAttrBute还原原始值
        /// </summary>
        /// <param name="p_Attr"></param>
        public static void ActionObject(ActionAttribute p_Attr)
        {
            //可能为清单 子目 工料机 组成
            _BaseObject bo = p_Attr.Source as _BaseObject;
            switch (p_Attr.CommandName)
	        {
                case Command.Create:
                    bo.Rec_Create(p_Attr);
                    break;
                case Command.Delete:
                    bo.Rec_Delete(p_Attr);
                    break;
                case Command.Replace:
                    bo.Rec_Replace(p_Attr);
                    break;
	        }
        }
    }
}
