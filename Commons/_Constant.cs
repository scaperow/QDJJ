﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    /// <summary>
    /// 常量类
    /// </summary>
    public class _Constant
    {
        //public  const  string
        /// <summary>
        /// 人工
        /// </summary>
        public const string rgkxg = "'人工'";
        /// <summary>
        /// 材料
        /// </summary>
        public const string clkxg = "'材料'";
        /// <summary>
        /// 机械
        /// </summary>
        public const string jxkxg = "'机械'";
        /// <summary>
        /// 主材
        /// </summary>
        public const string zckxg = "'主材'";
        /// <summary>
        /// 设备
        /// </summary>
        public const string sbkxg = "'设备'";

        /// <summary>
        /// 人工
        /// </summary>
        public const string rg = "'人工','其他人工费','人工%','人工降效'";
        /// <summary>
        /// 材料
        /// </summary>
        public const string cl = "'材料','主材','设备','配合比','其他材料费','材料%','换算用配合比'";
        /// <summary>
        /// 单独材料
        /// </summary>
        public const string ddcl = "'材料','配合比','其他材料费','材料%','换算用配合比'";
        /// <summary>
        /// 机械
        /// </summary>
        public const string jx = "'机械','其他机械费','机械%','机械台班','吊装机械','吊装机械台班','机械降效','吊装机械降效'";
        /// <summary>
        /// 主材
        /// </summary>
        public const string zc = "'主材'";
        /// <summary>
        /// 设备
        /// </summary>
        public const string sb = "'设备'";
        /// <summary>
        /// 可分解机械
        /// </summary>
        public const string kfjjx = "'机械台班'";
        /// <summary>
        /// 不可分解机械
        /// </summary>
        public const string bkfjjx = "'机械','其他机械费','机械%','吊装机械','机械降效','吊装机械降效'";
        /// <summary>
        /// 是否可以计算风险
        /// </summary>
        public const string IFJSFX = "'人工%','材料%','机械%','人工降效','机械降效','吊装机械降效','机械台班','吊装机械台班'";

        public static string[] XMTZ = { "\r\n【项目特征】", "\r\n【工程内容】", "\r\n【标准图集】" };
        /// <summary>
        /// 费用类别
        /// </summary>
        public const string FYLB = "直接费单价,人工费单价,材料费单价,主材费单价,设备费单价,机械费单价,风险单价,管理费单价,利润单价,子目单价";//,规费单价,税金单价
        #region 措施项目中得常量
        public const string 公式组价 = "公式组价";
        public const string 子目组价 = "子目组价";
        //  public const string 费率组价 = "费率组价";
        #endregion

        public const string 配合比定额范围 = "'P-1','P-2','P-3','P-4','P-5','P-6','P-7','P-8','P-9','P-10','P-11','P-12','P-13','P-14','P-15','P-16','P-17','P-18','P-19','P-20','P-21','P-22','P-23','P-24','P-25','P-26','P-27','P-28','P-29','P-30','P-31','P-32','P-33','P-34','P-35','P-36','P-37','P-38','P-39','P-40','P-41','P-42','P-43','P-44','P-45','P-46','P-47','P-48','P-49','P-50','P-51','P-52','P-53','P-54','P-55','P-56','P-57','P-58','P-59','P-60','P-61','P-62','P-63','P-64','P-65','P-66','P-67','P-68','P-69','P-70','P-71','P-72','P-73','P-74','P-75','P-76','P-77','P-78','P-79','P-80','P-81','P-82','P-83','P-84','P-85','P-86','P-87','P-88','P-89','P-90','P-91','P-92','P-93','P-94','P-95','P-96','P-97','P-98','P-99','P-100','P-101','P-102','P-103','P-104','P-105','P-106','P-107','P-108','P-109','P-110','P-111','P-112','P-113','P-114','P-115','P-116','P-117','P-118','P-119','P-120','P-121','P-122','P-123','P-124','P-125','P-126','P-127','P-128','P-129','P-130','P-131','P-132','P-133','P-134','P-135','P-136','P-137','P-138','P-139','P-140','P-141','P-142','P-143','P-144','P-145','P-146','P-147','P-148','P-149','P-150','P-151','P-152','P-153','P-154','P-155','P-156','P-157','P-158','P-159','P-160','P-161','P-162','P-163','P-164','P-165','P-166','P-167','P-168','P-169','P-170','P-171','P-172','P-173','P-174','P-175','P-176','P-177','P-178','P-179','P-180','P-181','P-182','P-183','P-184'";
        public const string 砌筑工程定额范围 = "'P-185','P-186','P-187','P-188','P-189','P-190','P-191','P-192','P-193','P-194','P-195','P-196','P-197','P-198','P-199','P-200','P-201','P-202','P-203','P-204','P-205','P-206','P-207','P-208','P-209'";
        public const string 抹灰工程定额范围 = "'P-210','P-211','P-212','P-213','P-214','P-215','P-216','P-217','P-218','P-219','P-220','P-221','P-222','P-223','P-224','P-225','P-226','P-227','P-228','P-229','P-230','P-231','P-232','P-233','P-234','P-235','P-236','P-237','P-238','P-239','P-240','P-241','P-242','P-243','P-244','P-245','P-246','P-247','P-248','P-249','P-250','P-251','P-252','P-253','P-254','P-255','P-256','P-257','P-258','P-259','P-260','P-261','P-262','P-263','P-264','P-265','P-266','P-267','P-268','P-269','P-270','P-271','P-272','P-273','P-274','P-275','P-276','P-277','P-278','P-279','P-280','P-281','P-282','P-283','P-284','P-285','P-286','P-287','P-288','P-289','P-290','P-291','P-292','P-293','P-294','P-295','P-296','P-297','P-298','P-299','P-300','P-301','P-302','P-303','P-304','P-305','P-306','P-307','P-308','P-309','P-310','P-311','P-312','P-313','P-314','P-315','P-316','P-317','P-318','P-319','P-320','P-321','P-322','P-323','P-324','P-325','P-326','P-327','P-328','P-329','P-330','P-331','P-332','P-333','P-334','P-335','P-336','P-337','P-338','P-339','P-340','P-341','P-342','P-343','P-344','P-345','P-346','P-347','P-348','P-349','P-350','P-351','P-352','P-353','P-354','P-355','P-356','P-357','P-358','P-359','P-360','P-361','P-362','P-363'";
        public const string 石灰转换定额范围 = "'10900','10901'";
        public const string 抹灰工程说明 = " 工程使用预拌砂浆时，在执行消耗量定额时，需对相应定额子目做如下调整：\r\n"
                                           + " 1.抹灰工程中，部分抹灰砂浆种类，相对应定额子目内每立方米砂浆扣除人工1.10工日\r\n"
                                           + " 2.相应定额子目内“灰浆搅拌机200L”的台班消耗量全部扣除\r\n"
                                           + " 3.现场制拌砂浆配合比改为预拌砂浆";




        public const string 石灰转换说明 = " 工程使用袋装熟石灰时，在执行消耗量定额时，需对相应定额子目按下列规定调整：\r\n"
                                            + "　1.袋装熟石灰用量按定额生石灰消耗量乘以1.3的系数\r\n"
                                            + "　2.每吨定额生石灰消耗量应扣除以下材料和用工：\r\n"
                                            + "　人工：0.478工日/t\t 水：0.043m3/t";


        public const string 砌筑工程说明 = " 工程使用预拌砂浆时，在执行消耗量定额时，需对相应定额子目做如下调整：\r\n"
                                                   + " 1.砌筑工程中，部分抹灰砂浆种类，相对应定额子目内每立方米砂浆扣除人工0.69工日\r\n"
                                                   + " 2.相应定额子目内“灰浆搅拌机200L”的台班消耗量全部扣除\r\n"
                                                   + " 3.现场制拌砂浆配合比改为预拌砂浆";

        public const string 回车符 = "\r\n";

        public const string gljzd = "ID,PID,EnID,UnID,SSLB,QDID,ZMID,YSBH,YSMC,YSDW,YSXHL,BH,MC,DW,XHL,LB,DEDJ,DEHJ,SCDJ,SCHJ,DJC,JSDJ,JSDJC,GCL,sum(SL) SL,IFZYCL,ZCLB,GGXH,SDCLB,SDCXS,YTLB,IFXZ,IFSC,IFFX,IFSDSCDJ,IFSDSL,IFKFJ,SSDWGC,GLJBZ,CTIME, JSHJC, HJC, SDCHJ,CJ,PP,ZLDJ,GYS,CD,CJBZ,XGHSCDJ,TZXS,SSKLB";

        public const string hbtjzd = "BH,MC,DW,SCDJ";
        public const string 超高定额号 = "'15-1','15-2','15-3','15-4','15-5','15-6','15-7','15-8','15-9','15-10','15-11','15-23','15-24','15-25','15-26','15-27','15-28','15-29','15-30','15-31'";
    }
}
