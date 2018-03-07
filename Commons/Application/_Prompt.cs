/*
 错误提示的公共常量
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class _Prompt
    {
        //工程
        public const string 存在项目操作 = "当前已经打开一个项目，请关闭后再次尝试！";

        public const string 打开文件出错 = "当前打开的文件出错，请尝试从新选择！";
        public const string 无法识别的打开文件 = "对不起，您要打开的文件已经损坏！";//"对不起，你当前选择的文件无法识别。";
        public const string 文件已经存在 = "对不起，您要创建的文件已经存在，请尝试更换文件名称！";
        //操作提示
        public const string 关闭提示     = "系统准备关闭当前业务，是否保存？";

        public const string 汇总分析重新计算 = "是否重新计算汇总分析数据，如果此单位工程没有发生变化则不需要重新计算！";
        public const string 项目重新计算 = "是否重新计算项目数据，如果此项目没有发生变化则不需要重新计算！";
        public const string 工程重新计算 = "是否重新计算工程数据，如果此工程没有发生变化则不需要重新计算！";

        public const string 用户规则已存在 = "用户规则已存在是否覆盖?";
        public const string 用户规则保存成功 = "用户规则保存成功！";

        public const string 加密狗验证失败 = "请确保您的加密狗正确连接您的计算机，并且已经授权！如已经连接请重新尝试。";

        public const string 系统关闭前有子业务提示 = "您还有业务没有处理完毕，请关闭正在处理的业务后尝试！";
        public const string 项目关闭前保存提示 = "当前项目即将关闭，请确认是否保存当前项目！";

        public const string 系统关闭确认 = "您确定退出系统？";
        public const string 文件存在覆盖 = "文件已经存在是否覆盖以前的文件？";
        public const string 措施项目重新计算 = "是否重新计算措施项目数据，如果此单位工程没有发生变化则不需要重新计算！";

        public const string 删除项目 = "您确定要删除当前项目？";
    }
}
