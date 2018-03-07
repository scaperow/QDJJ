/*
 当前项目数据访问的参数统一编写
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace GOLDSOFT.QDJJ.DATA
{
    //为什么签不进去
    public partial class _ProjDataBase : _ObjectDataBase
    {

        /// <summary>
        /// 项目批量更新参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_UPDATE
        {

            get
            {
                OleDbParameter[] parameters = {
						new OleDbParameter("@PID", OleDbType.Integer,4) ,            
                        new OleDbParameter("@Name", OleDbType.VarChar,100) ,            
                        new OleDbParameter("@CODE", OleDbType.VarChar,0) ,            
                        new OleDbParameter("@QDGZ", OleDbType.VarChar,4) ,            
                        new OleDbParameter("@DEGZ", OleDbType.VarChar,4) ,            
                        new OleDbParameter("@PGCDD", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@PJFCX", OleDbType.SmallInt) ,            
                        new OleDbParameter("@PNSDD", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@CREATOR", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@EDITOR", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@Sort", OleDbType.Integer,4) ,            
                        new OleDbParameter("@Deep", OleDbType.Integer,4) ,            
                        new OleDbParameter("@NodeName", OleDbType.VarChar,100) ,            
                        new OleDbParameter("@PlaitNo", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@ReviewName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@PlaitName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@ProType", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@PrfType", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@Remark", OleDbType.VarChar,0) ,            
                        new OleDbParameter("@QDLibName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@DELibName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@TJLibName", OleDbType.VarChar,50),
                        new OleDbParameter("@FISTDATETIME", OleDbType.Date),
                        new OleDbParameter("@EDITDATETIME", OleDbType.Date),
                        new OleDbParameter("@PlaitDate", OleDbType.Date),
                        new OleDbParameter("@ReviewDate", OleDbType.Date),
                        new OleDbParameter("@Key", OleDbType.Integer,4),
                        new OleDbParameter("@PKey", OleDbType.Integer,4),
                        new OleDbParameter("@PassWord", OleDbType.VarChar,255),
                        new OleDbParameter("@JMSH", OleDbType.VarChar,255),
                        new OleDbParameter("@JQH", OleDbType.VarChar,255),
                        new OleDbParameter("@Time", OleDbType.VarChar,255),
                        new OleDbParameter("@ImageIndex", OleDbType.Integer),
                        new OleDbParameter("@State", OleDbType.VarChar),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
                        
            };

                parameters[0].SourceColumn = "PID";
                parameters[1].SourceColumn = "Name";
                parameters[2].SourceColumn = "CODE";
                parameters[3].SourceColumn = "QDGZ";
                parameters[4].SourceColumn = "DEGZ";
                parameters[5].SourceColumn = "PGCDD";
                parameters[6].SourceColumn = "PJFCX";
                parameters[7].SourceColumn = "PNSDD";
                parameters[8].SourceColumn = "CREATOR";
                parameters[9].SourceColumn = "EDITOR";
                parameters[10].SourceColumn = "Sort";
                parameters[11].SourceColumn = "Deep";
                parameters[12].SourceColumn = "NodeName";
                parameters[13].SourceColumn = "PlaitNo";
                parameters[14].SourceColumn = "ReviewName";
                parameters[15].SourceColumn = "PlaitName";
                parameters[16].SourceColumn = "ProType";
                parameters[17].SourceColumn = "PrfType";
                parameters[18].SourceColumn = "Remark";
                parameters[19].SourceColumn = "QDLibName";
                parameters[20].SourceColumn = "DELibName";
                parameters[21].SourceColumn = "TJLibName";
                parameters[22].SourceColumn = "FISTDATETIME";
                parameters[23].SourceColumn = "EDITDATETIME";
                parameters[24].SourceColumn = "PlaitDate";
                parameters[25].SourceColumn = "ReviewDate";
                parameters[26].SourceColumn = "Key";
                parameters[27].SourceColumn = "PKey";
                parameters[28].SourceColumn = "PassWord";
                parameters[29].SourceColumn = "JMSH";
                parameters[30].SourceColumn = "JQH";
                parameters[31].SourceColumn = "Time";
                parameters[32].SourceColumn = "ImageIndex";
                parameters[33].SourceColumn = "State";
                parameters[34].SourceColumn = "ID";
                //parameters[26].Direction = System.Data.ParameterDirection.InputOutput;
                return parameters;
            }
        }

        /// <summary>
        /// 变量表参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_VARIABLE
        {
            get
            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@Key", OleDbType.VarChar,100),
                                    new OleDbParameter("@Value", OleDbType.VarChar,100),
                                    new OleDbParameter("@Remark", OleDbType.VarChar,0),
                                    new OleDbParameter("@Length", OleDbType.Integer,4),
                                    new OleDbParameter("@FYLB", OleDbType.VarChar,100)
                                };

                parameters[0].SourceColumn = "Key";
                parameters[1].SourceColumn = "Value";
                parameters[2].SourceColumn = "Remark";
                parameters[3].SourceColumn = "Length";
                parameters[4].SourceColumn = "FYLB";

                return parameters;
            }
        }

        /// <summary>
        /// 分部分项更新参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_SUBDATA
        {
            get
            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@PID", OleDbType.SmallInt),
                        new OleDbParameter("@PPARENTID", OleDbType.SmallInt),
                        new OleDbParameter("@CPARENTID", OleDbType.SmallInt),
                        new OleDbParameter("@FPARENTID", OleDbType.SmallInt),
                        new OleDbParameter("@XH", OleDbType.SmallInt),
                        new OleDbParameter("@XMBM", OleDbType.VarChar,255),
                        new OleDbParameter("@OLDXMBM", OleDbType.VarChar,255),
                        new OleDbParameter("@XMMC", OleDbType.VarChar,10000),
                        new OleDbParameter("@DW", OleDbType.VarChar,255),
                        new OleDbParameter("@TX", OleDbType.VarChar,255),
                        new OleDbParameter("@LB", OleDbType.VarChar,255),
                        new OleDbParameter("@JCBJ", OleDbType.Boolean,1),
                        new OleDbParameter("@FHBJ", OleDbType.Boolean,1),
                        new OleDbParameter("@ZYQD", OleDbType.Boolean,1),
                        new OleDbParameter("@SDDJ", OleDbType.Boolean,1),
                        new OleDbParameter("@JBHZ", OleDbType.Boolean,1),
                        new OleDbParameter("@XMTZ", OleDbType.VarChar,255),
                        new OleDbParameter("@GCLJSS", OleDbType.VarChar,255),
                        new OleDbParameter("@ZJWZ", OleDbType.VarChar,255),
                        new OleDbParameter("@JX", OleDbType.Boolean,1),
                        new OleDbParameter("@SC", OleDbType.Boolean,1),
                        new OleDbParameter("@YGLB", OleDbType.VarChar,255),
                        new OleDbParameter("@QFSZ", OleDbType.VarChar,255),
                        new OleDbParameter("@BEIZHU", OleDbType.VarChar,10000),
                        new OleDbParameter("@LibraryName", OleDbType.VarChar,255),
                        new OleDbParameter("@LY", OleDbType.VarChar,255),
                        new OleDbParameter("@SDQD", OleDbType.Boolean,1),
                        new OleDbParameter("@SFFB", OleDbType.Boolean,1),
                        new OleDbParameter("@HL", OleDbType.Decimal),
                        new OleDbParameter("@GCL", OleDbType.Decimal),
                        new OleDbParameter("@ZJTJ", OleDbType.Decimal),
                        new OleDbParameter("@ZHDJ", OleDbType.Decimal),
                        new OleDbParameter("@ZHHJ", OleDbType.Decimal),
                        new OleDbParameter("@ZJFDJ", OleDbType.Decimal),
                        new OleDbParameter("@RGFDJ", OleDbType.Decimal),
                        new OleDbParameter("@CLFDJ", OleDbType.Decimal),
                        new OleDbParameter("@JXFDJ", OleDbType.Decimal),
                        new OleDbParameter("@ZCFDJ", OleDbType.Decimal),
                        new OleDbParameter("@SBFDJ", OleDbType.Decimal),
                        new OleDbParameter("@GLFDJ", OleDbType.Decimal),
                        new OleDbParameter("@LRDJ", OleDbType.Decimal),
                        new OleDbParameter("@FXDJ", OleDbType.Decimal),
                        new OleDbParameter("@GFDJ", OleDbType.Decimal),
                        new OleDbParameter("@SJDJ", OleDbType.Decimal),
                        new OleDbParameter("@CJDJ", OleDbType.Decimal),
                        new OleDbParameter("@JCDJ", OleDbType.Decimal),
                        new OleDbParameter("@XHL", OleDbType.Decimal),
                        new OleDbParameter("@ZJFHJ", OleDbType.Decimal),
                        new OleDbParameter("@RGFHJ", OleDbType.Decimal),
                        new OleDbParameter("@CLFHJ", OleDbType.Decimal),
                        new OleDbParameter("@JXFHJ", OleDbType.Decimal),
                        new OleDbParameter("@ZCFHJ", OleDbType.Decimal),
                        new OleDbParameter("@SBFHJ", OleDbType.Decimal),
                        new OleDbParameter("@GLFHJ", OleDbType.Decimal),
                        new OleDbParameter("@LRHJ", OleDbType.Decimal),
                        new OleDbParameter("@FXHJ", OleDbType.Decimal),
                        new OleDbParameter("@GFHJ", OleDbType.Decimal),
                        new OleDbParameter("@SJHJ", OleDbType.Decimal),
                        new OleDbParameter("@JCHJ", OleDbType.Decimal),
                        new OleDbParameter("@CJHJ", OleDbType.Decimal),
                        new OleDbParameter("@ZGJE", OleDbType.Decimal),
                        new OleDbParameter("@JGJE", OleDbType.Decimal),
                        new OleDbParameter("@FBJE", OleDbType.Decimal),
                        new OleDbParameter("@FL", OleDbType.Decimal),
                        new OleDbParameter("@DECJ", OleDbType.VarChar,255),
                        new OleDbParameter("@JSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@ZJFS", OleDbType.VarChar,255),
                        new OleDbParameter("@QDBH", OleDbType.VarChar,255),
                        new OleDbParameter("@XMNR", OleDbType.VarChar,255),
                        new OleDbParameter("@XMTZZ", OleDbType.VarChar,255),
                        new OleDbParameter("@TYGS", OleDbType.VarChar,255),
                        new OleDbParameter("@ISTY", OleDbType.Boolean,1),
                        new OleDbParameter("@PBZD", OleDbType.Decimal),
                        new OleDbParameter("@YGJE", OleDbType.Decimal),
                        new OleDbParameter("@STATUS", OleDbType.Boolean,1),
                        new OleDbParameter("@ZDSC", OleDbType.Boolean,1),
                        new OleDbParameter("@Key", OleDbType.Integer,4),
                        new OleDbParameter("@PKey", OleDbType.Integer,4),
                        new OleDbParameter("@Deep", OleDbType.Integer,4),
                        new OleDbParameter("@Sort", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.SmallInt),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@SSLB", OleDbType.Integer,4),
                         new OleDbParameter("@RGFJC", OleDbType.Decimal),
                        new OleDbParameter("@CLFJC", OleDbType.Decimal),
                        new OleDbParameter("@JXFJC", OleDbType.Decimal),
                        new OleDbParameter("@DZBS", OleDbType.Boolean),
                        new OleDbParameter("@ID", OleDbType.Integer,4),
                        new OleDbParameter("@ZYLB", OleDbType.VarChar,50)
                      
            };

                parameters[0].SourceColumn = "PID";
                parameters[1].SourceColumn = "PPARENTID";
                parameters[2].SourceColumn = "CPARENTID";
                parameters[3].SourceColumn = "FPARENTID";
                parameters[4].SourceColumn = "XH";
                parameters[5].SourceColumn = "XMBM";
                parameters[6].SourceColumn = "OLDXMBM";
                parameters[7].SourceColumn = "XMMC";
                parameters[8].SourceColumn = "DW";
                parameters[9].SourceColumn = "TX";
                parameters[10].SourceColumn = "LB";
                parameters[11].SourceColumn = "JCBJ";
                parameters[12].SourceColumn = "FHBJ";
                parameters[13].SourceColumn = "ZYQD";
                parameters[14].SourceColumn = "SDDJ";
                parameters[15].SourceColumn = "JBHZ";
                parameters[16].SourceColumn = "XMTZ";
                parameters[17].SourceColumn = "GCLJSS";
                parameters[18].SourceColumn = "ZJWZ";
                parameters[19].SourceColumn = "JX";
                parameters[20].SourceColumn = "SC";
                parameters[21].SourceColumn = "YGLB";
                parameters[22].SourceColumn = "QFSZ";
                parameters[23].SourceColumn = "BEIZHU";
                parameters[24].SourceColumn = "LibraryName";
                parameters[25].SourceColumn = "LY";
                parameters[26].SourceColumn = "SDQD";
                parameters[27].SourceColumn = "SFFB";
                parameters[28].SourceColumn = "HL";
                parameters[29].SourceColumn = "GCL";
                parameters[30].SourceColumn = "ZJTJ";
                parameters[31].SourceColumn = "ZHDJ";
                parameters[32].SourceColumn = "ZHHJ";
                parameters[33].SourceColumn = "ZJFDJ";
                parameters[34].SourceColumn = "RGFDJ";
                parameters[35].SourceColumn = "CLFDJ";
                parameters[36].SourceColumn = "JXFDJ";
                parameters[37].SourceColumn = "ZCFDJ";
                parameters[38].SourceColumn = "SBFDJ";
                parameters[39].SourceColumn = "GLFDJ";
                parameters[40].SourceColumn = "LRDJ";
                parameters[41].SourceColumn = "FXDJ";
                parameters[42].SourceColumn = "GFDJ";
                parameters[43].SourceColumn = "SJDJ";
                parameters[44].SourceColumn = "CJDJ";
                parameters[45].SourceColumn = "JCDJ";
                parameters[46].SourceColumn = "XHL";
                parameters[47].SourceColumn = "ZJFHJ";
                parameters[48].SourceColumn = "RGFHJ";
                parameters[49].SourceColumn = "CLFHJ";
                parameters[50].SourceColumn = "JXFHJ";
                parameters[51].SourceColumn = "ZCFHJ";
                parameters[52].SourceColumn = "SBFHJ";
                parameters[53].SourceColumn = "GLFHJ";
                parameters[54].SourceColumn = "LRHJ";
                parameters[55].SourceColumn = "FXHJ";
                parameters[56].SourceColumn = "GFHJ";
                parameters[57].SourceColumn = "SJHJ";
                parameters[58].SourceColumn = "JCHJ";
                parameters[59].SourceColumn = "CJHJ";
                parameters[60].SourceColumn = "ZGJE";
                parameters[61].SourceColumn = "JGJE";
                parameters[62].SourceColumn = "FBJE";
                parameters[63].SourceColumn = "FL";
                parameters[64].SourceColumn = "DECJ";
                parameters[65].SourceColumn = "JSJC";
                parameters[66].SourceColumn = "ZJFS";
                parameters[67].SourceColumn = "QDBH";
                parameters[68].SourceColumn = "XMNR";
                parameters[69].SourceColumn = "XMTZZ";
                parameters[70].SourceColumn = "TYGS";
                parameters[71].SourceColumn = "ISTY";
                parameters[72].SourceColumn = "PBZD";
                parameters[73].SourceColumn = "YGJE";
                parameters[74].SourceColumn = "STATUS";
                parameters[75].SourceColumn = "ZDSC";
                parameters[76].SourceColumn = "Key";
                parameters[77].SourceColumn = "PKey";
                parameters[78].SourceColumn = "Deep";
                parameters[79].SourceColumn = "Sort";
                parameters[80].SourceColumn = "UnID";
                parameters[81].SourceColumn = "EnID";
                parameters[82].SourceColumn = "SSLB";

                parameters[83].SourceColumn = "RGFJC";
                parameters[84].SourceColumn = "CLFJC";
                parameters[85].SourceColumn = "JXFJC";
                parameters[86].SourceColumn = "DZBS";
                parameters[87].SourceColumn = "ID";
                parameters[88].SourceColumn = "ZYLB";


                return parameters;
            }
        }

        /// <summary>
        /// 措施项目更新参数
        /// </summary>
        /* public OleDbParameter[] PARAMS_PROJ_MEASUREDATA
         {
             get
             {
                 #region --------------参数------------
                 OleDbParameter[] parameters = {
                         new OleDbParameter("@PID", OleDbType.Integer),
                         new OleDbParameter("@PPARENTID", OleDbType.Integer),
                         new OleDbParameter("@CPARENTID", OleDbType.Integer),
                         new OleDbParameter("@FPARENTID", OleDbType.Integer),
                         new OleDbParameter("@XH", OleDbType.Integer),
                         new OleDbParameter("@XMBM", OleDbType.VarChar,255),
                         new OleDbParameter("@OLDXMBM", OleDbType.VarChar,255),
                         new OleDbParameter("@XMMC", OleDbType.VarChar,255),
                         new OleDbParameter("@DW", OleDbType.VarChar,255),
                         new OleDbParameter("@TX", OleDbType.VarChar,255),
                         new OleDbParameter("@LB", OleDbType.VarChar,255),
                         new OleDbParameter("@JCBJ", OleDbType.Boolean),
                         new OleDbParameter("@FHBJ", OleDbType.Boolean),
                         new OleDbParameter("@ZYQD", OleDbType.Boolean),
                         new OleDbParameter("@SDDJ", OleDbType.Boolean),
                         new OleDbParameter("@JBHZ", OleDbType.Boolean),
                         new OleDbParameter("@XMTZ", OleDbType.VarChar,255),
                         new OleDbParameter("@GCLJSS", OleDbType.VarChar,255),
                         new OleDbParameter("@ZJWZ", OleDbType.VarChar,255),
                         new OleDbParameter("@JX", OleDbType.Boolean),
                         new OleDbParameter("@SC", OleDbType.Boolean),
                         new OleDbParameter("@YGLB", OleDbType.VarChar,255),
                         new OleDbParameter("@QFSZ", OleDbType.VarChar,255),
                         new OleDbParameter("@BEIZHU", OleDbType.VarChar,255),
                         new OleDbParameter("@LibraryName", OleDbType.VarChar,255),
                         new OleDbParameter("@LY", OleDbType.VarChar,255),
                         new OleDbParameter("@SDQD", OleDbType.Boolean),
                         new OleDbParameter("@SFFB", OleDbType.Boolean),
                         new OleDbParameter("@HL", OleDbType.Decimal),
                         new OleDbParameter("@GCL", OleDbType.Decimal),
                         new OleDbParameter("@ZJTJ", OleDbType.Decimal),
                         new OleDbParameter("@ZHDJ", OleDbType.Decimal),
                         new OleDbParameter("@ZHHJ", OleDbType.Decimal),
                         new OleDbParameter("@ZJFDJ", OleDbType.Decimal),
                         new OleDbParameter("@RGFDJ", OleDbType.Decimal),
                         new OleDbParameter("@CLFDJ", OleDbType.Decimal),
                         new OleDbParameter("@JXFDJ", OleDbType.Decimal),
                         new OleDbParameter("@ZCFDJ", OleDbType.Decimal),
                         new OleDbParameter("@SBFDJ", OleDbType.Decimal),
                         new OleDbParameter("@GLFDJ", OleDbType.Decimal),
                         new OleDbParameter("@LRDJ", OleDbType.Decimal),
                         new OleDbParameter("@FXDJ", OleDbType.Decimal),
                         new OleDbParameter("@GFDJ", OleDbType.Decimal),
                         new OleDbParameter("@SJDJ", OleDbType.Decimal),
                         new OleDbParameter("@CJDJ", OleDbType.Decimal),
                         new OleDbParameter("@JCDJ", OleDbType.Decimal),
                         new OleDbParameter("@XHL", OleDbType.Decimal),
                         new OleDbParameter("@ZJFHJ", OleDbType.Decimal),
                         new OleDbParameter("@RGFHJ", OleDbType.Decimal),
                         new OleDbParameter("@CLFHJ", OleDbType.Decimal),
                         new OleDbParameter("@JXFHJ", OleDbType.Decimal),
                         new OleDbParameter("@ZCFHJ", OleDbType.Decimal),
                         new OleDbParameter("@SBFHJ", OleDbType.Decimal),
                         new OleDbParameter("@GLFHJ", OleDbType.Decimal),
                         new OleDbParameter("@LRHJ", OleDbType.Decimal),
                         new OleDbParameter("@FXHJ", OleDbType.Decimal),
                         new OleDbParameter("@GFHJ", OleDbType.Decimal),
                         new OleDbParameter("@SJHJ", OleDbType.Decimal),
                         new OleDbParameter("@JCHJ", OleDbType.Decimal),
                         new OleDbParameter("@CJHJ", OleDbType.Decimal),
                         new OleDbParameter("@ZGJE", OleDbType.Decimal),
                         new OleDbParameter("@JGJE", OleDbType.Decimal),
                         new OleDbParameter("@FBJE", OleDbType.Decimal),
                         new OleDbParameter("@FL", OleDbType.Decimal),
                         new OleDbParameter("@DECJ", OleDbType.VarChar,255),
                         new OleDbParameter("@JSJC", OleDbType.VarChar,255),
                         new OleDbParameter("@ZJFS", OleDbType.VarChar,255),
                         new OleDbParameter("@QDBH", OleDbType.VarChar,255),
                         new OleDbParameter("@XMNR", OleDbType.VarChar,255),
                         new OleDbParameter("@XMTZZ", OleDbType.VarChar,255),
                         new OleDbParameter("@TYGS", OleDbType.VarChar,255),
                         new OleDbParameter("@ISTY", OleDbType.Boolean),
                         new OleDbParameter("@PBZD", OleDbType.Decimal),
                         new OleDbParameter("@YGJE", OleDbType.Decimal),
                         new OleDbParameter("@STATUS", OleDbType.Boolean),
                         new OleDbParameter("@ZDSC", OleDbType.Boolean),
                         new OleDbParameter("@UnID", OleDbType.Integer),
                         new OleDbParameter("@Key", OleDbType.Integer),
                         new OleDbParameter("@PKey", OleDbType.Integer),
                         new OleDbParameter("@Deep", OleDbType.Integer),
                         new OleDbParameter("@Sort", OleDbType.Integer),
                         new OleDbParameter("@EnID", OleDbType.Integer),
                         new OleDbParameter("@ID", OleDbType.Integer),
                         new OleDbParameter("@RGFJC", OleDbType.Decimal),
                         new OleDbParameter("@CLFJC", OleDbType.Decimal),
                         new OleDbParameter("@JXFJC", OleDbType.Decimal)
             };

                 parameters[0].SourceColumn = "PID";
                 parameters[1].SourceColumn = "PPARENTID";
                 parameters[2].SourceColumn = "CPARENTID";
                 parameters[3].SourceColumn = "FPARENTID";
                 parameters[4].SourceColumn = "XH";
                 parameters[5].SourceColumn = "XMBM";
                 parameters[6].SourceColumn = "OLDXMBM";
                 parameters[7].SourceColumn = "XMMC";
                 parameters[8].SourceColumn = "DW";
                 parameters[9].SourceColumn = "TX";
                 parameters[10].SourceColumn = "LB";
                 parameters[11].SourceColumn = "JCBJ";
                 parameters[12].SourceColumn = "FHBJ";
                 parameters[13].SourceColumn = "ZYQD";
                 parameters[14].SourceColumn = "SDDJ";
                 parameters[15].SourceColumn = "JBHZ";
                 parameters[16].SourceColumn = "XMTZ";
                 parameters[17].SourceColumn = "GCLJSS";
                 parameters[18].SourceColumn = "ZJWZ";
                 parameters[19].SourceColumn = "JX";
                 parameters[20].SourceColumn = "SC";
                 parameters[21].SourceColumn = "YGLB";
                 parameters[22].SourceColumn = "QFSZ";
                 parameters[23].SourceColumn = "BEIZHU";
                 parameters[24].SourceColumn = "LibraryName";
                 parameters[25].SourceColumn = "LY";
                 parameters[26].SourceColumn = "SDQD";
                 parameters[27].SourceColumn = "SFFB";
                 parameters[28].SourceColumn = "HL";
                 parameters[29].SourceColumn = "GCL";
                 parameters[30].SourceColumn = "ZJTJ";
                 parameters[31].SourceColumn = "ZHDJ";
                 parameters[32].SourceColumn = "ZHHJ";
                 parameters[33].SourceColumn = "ZJFDJ";
                 parameters[34].SourceColumn = "RGFDJ";
                 parameters[35].SourceColumn = "CLFDJ";
                 parameters[36].SourceColumn = "JXFDJ";
                 parameters[37].SourceColumn = "ZCFDJ";
                 parameters[38].SourceColumn = "SBFDJ";
                 parameters[39].SourceColumn = "GLFDJ";
                 parameters[40].SourceColumn = "LRDJ";
                 parameters[41].SourceColumn = "FXDJ";
                 parameters[42].SourceColumn = "GFDJ";
                 parameters[43].SourceColumn = "SJDJ";
                 parameters[44].SourceColumn = "CJDJ";
                 parameters[45].SourceColumn = "JCDJ";
                 parameters[46].SourceColumn = "XHL";
                 parameters[47].SourceColumn = "ZJFHJ";
                 parameters[48].SourceColumn = "RGFHJ";
                 parameters[49].SourceColumn = "CLFHJ";
                 parameters[50].SourceColumn = "JXFHJ";
                 parameters[51].SourceColumn = "ZCFHJ";
                 parameters[52].SourceColumn = "SBFHJ";
                 parameters[53].SourceColumn = "GLFHJ";
                 parameters[54].SourceColumn = "LRHJ";
                 parameters[55].SourceColumn = "FXHJ";
                 parameters[56].SourceColumn = "GFHJ";
                 parameters[57].SourceColumn = "SJHJ";
                 parameters[58].SourceColumn = "JCHJ";
                 parameters[59].SourceColumn = "CJHJ";
                 parameters[60].SourceColumn = "ZGJE";
                 parameters[61].SourceColumn = "JGJE";
                 parameters[62].SourceColumn = "FBJE";
                 parameters[63].SourceColumn = "FL";
                 parameters[64].SourceColumn = "DECJ";
                 parameters[65].SourceColumn = "JSJC";
                 parameters[66].SourceColumn = "ZJFS";
                 parameters[67].SourceColumn = "QDBH";
                 parameters[68].SourceColumn = "XMNR";
                 parameters[69].SourceColumn = "XMTZZ";
                 parameters[70].SourceColumn = "TYGS";
                 parameters[71].SourceColumn = "ISTY";
                 parameters[72].SourceColumn = "PBZD";
                 parameters[73].SourceColumn = "YGJE";
                 parameters[74].SourceColumn = "STATUS";
                 parameters[75].SourceColumn = "ZDSC";
                 parameters[76].SourceColumn = "UnID";
                 parameters[77].SourceColumn = "Key";
                 parameters[78].SourceColumn = "PKey";
                 parameters[79].SourceColumn = "Deep";
                 parameters[80].SourceColumn = "Sort";
                 parameters[81].SourceColumn = "EnID";
                 parameters[82].SourceColumn = "ID";
                 parameters[83].SourceColumn = "RGFJC";
                 parameters[84].SourceColumn = "CLFJC";
                 parameters[85].SourceColumn = "JXFJC";
                 #endregion
                 return parameters;
             }
         }*/


        public OleDbParameter[] PARAMS_PROJ_METAANALYSIS
        {
            get
            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@Key", OleDbType.Integer),
                        new OleDbParameter("@PKey", OleDbType.Integer),
                        new OleDbParameter("@FGCF", OleDbType.Decimal),
                        new OleDbParameter("@CSXMF", OleDbType.Decimal),
                        new OleDbParameter("@QTXMF", OleDbType.Decimal),
                        new OleDbParameter("@GF", OleDbType.Decimal),
                        new OleDbParameter("@SJ", OleDbType.Decimal),
                        new OleDbParameter("@ZZJ", OleDbType.Decimal),
                        new OleDbParameter("@AQWM", OleDbType.Decimal),
                        new OleDbParameter("@LBTC", OleDbType.Decimal),
                        new OleDbParameter("@JSDW", OleDbType.VarChar,255),
                        new OleDbParameter("@JZMJ", OleDbType.Integer),
                        new OleDbParameter("@DWZJ", OleDbType.Decimal),
                        new OleDbParameter("@ZZJB", OleDbType.Decimal),
                        new OleDbParameter("@BZ", OleDbType.VarChar),
                        new OleDbParameter("@PID", OleDbType.Integer)
            };

                parameters[0].SourceColumn = "Key";
                parameters[1].SourceColumn = "PKey";
                parameters[2].SourceColumn = "FGCF";
                parameters[3].SourceColumn = "CSXMF";
                parameters[4].SourceColumn = "QTXMF";
                parameters[5].SourceColumn = "GF";
                parameters[6].SourceColumn = "SJ";
                parameters[7].SourceColumn = "ZZJ";
                parameters[8].SourceColumn = "AQWM";
                parameters[9].SourceColumn = "LBTC";
                parameters[10].SourceColumn = "JSDW";
                parameters[11].SourceColumn = "JZMJ";
                parameters[12].SourceColumn = "DWZJ";
                parameters[13].SourceColumn = "ZZJB";
                parameters[14].SourceColumn = "BZ";
                parameters[15].SourceColumn = "PID";
                return parameters;
            }
        }


        /// <summary>
        /// 子目取费参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_SUBFREEDATA
        {
            get
            {
                OleDbParameter[] parameters = {
						                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                                                new OleDbParameter("@UnID", OleDbType.Integer,4),
                                                new OleDbParameter("@SSLB", OleDbType.Integer,4),
                                                new OleDbParameter("@QDID", OleDbType.Integer,4),
                                                new OleDbParameter("@ZMID", OleDbType.Integer,4),
                                                new OleDbParameter("@Sort", OleDbType.Integer,4),
                                                new OleDbParameter("@YYH", OleDbType.VarChar,255),
                                                new OleDbParameter("@MC", OleDbType.VarChar,255),
                                                new OleDbParameter("@BDS", OleDbType.VarChar,255),
                                                new OleDbParameter("@SCJJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@TBJSJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@BDJSJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@FL", OleDbType.Decimal),
                                                new OleDbParameter("@TBJE", OleDbType.Decimal),
                                                new OleDbParameter("@BDJE", OleDbType.Decimal),
                                                new OleDbParameter("@FYLB", OleDbType.VarChar,255),
                                                new OleDbParameter("@BZ", OleDbType.VarChar,255),
                                                new OleDbParameter("@STATUS", OleDbType.Boolean,1),
                                                new OleDbParameter("@JSSX", OleDbType.Integer),
                                                new OleDbParameter("@ID", OleDbType.Integer,4),
                                                new OleDbParameter("@QFLB", OleDbType.VarChar,255)
            };

                parameters[0].SourceColumn = "EnID";
                parameters[1].SourceColumn = "UnID";
                parameters[2].SourceColumn = "SSLB";
                parameters[3].SourceColumn = "QDID";
                parameters[4].SourceColumn = "ZMID";
                parameters[5].SourceColumn = "Sort";
                parameters[6].SourceColumn = "YYH";
                parameters[7].SourceColumn = "MC";
                parameters[8].SourceColumn = "BDS";
                parameters[9].SourceColumn = "SCJJC";
                parameters[10].SourceColumn = "TBJSJC";
                parameters[11].SourceColumn = "BDJSJC";
                parameters[12].SourceColumn = "FL";
                parameters[13].SourceColumn = "TBJE";
                parameters[14].SourceColumn = "BDJE";
                parameters[15].SourceColumn = "FYLB";
                parameters[16].SourceColumn = "BZ";
                parameters[17].SourceColumn = "STATUS";
                parameters[18].SourceColumn = "JSSX";
                parameters[19].SourceColumn = "ID";
                parameters[20].SourceColumn = "QFLB";
                return parameters;
            }
        }

        /// <summary>
        /// 子目取费参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_SUBFREEDATA_Value(DataRow p_Row)
        {

            {
                OleDbParameter[] parameters = {
						                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                                                new OleDbParameter("@UnID", OleDbType.Integer,4),
                                                new OleDbParameter("@SSLB", OleDbType.Integer,4),
                                                new OleDbParameter("@QDID", OleDbType.Integer,4),
                                                new OleDbParameter("@ZMID", OleDbType.Integer,4),
                                                new OleDbParameter("@Sort", OleDbType.Integer,4),
                                                new OleDbParameter("@YYH", OleDbType.VarChar,255),
                                                new OleDbParameter("@MC", OleDbType.VarChar,255),
                                                new OleDbParameter("@BDS", OleDbType.VarChar,255),
                                                new OleDbParameter("@SCJJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@TBJSJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@BDJSJC", OleDbType.VarChar,255),
                                                new OleDbParameter("@FL", OleDbType.Decimal),
                                                new OleDbParameter("@TBJE", OleDbType.Decimal),
                                                new OleDbParameter("@BDJE", OleDbType.Decimal),
                                                new OleDbParameter("@FYLB", OleDbType.VarChar,255),
                                                new OleDbParameter("@BZ", OleDbType.VarChar,255),
                                                new OleDbParameter("@STATUS", OleDbType.Boolean,1),
                                                new OleDbParameter("@JSSX", OleDbType.Integer),
                                                new OleDbParameter("@ID", OleDbType.Integer,4),
                                                new OleDbParameter("@QFLB", OleDbType.VarChar,255)
            };

                parameters[0].Value = p_Row["EnID"];
                parameters[1].Value = p_Row["UnID"];
                parameters[2].Value = p_Row["SSLB"];
                parameters[3].Value = p_Row["QDID"];
                parameters[4].Value = p_Row["ZMID"];
                parameters[5].Value = p_Row["Sort"];
                parameters[6].Value = p_Row["YYH"];
                parameters[7].Value = p_Row["MC"];
                parameters[8].Value = p_Row["BDS"];
                parameters[9].Value = p_Row["SCJJC"];
                parameters[10].Value = p_Row["TBJSJC"];
                parameters[11].Value = p_Row["BDJSJC"];
                parameters[12].Value = p_Row["FL"];
                parameters[13].Value = p_Row["TBJE"];
                parameters[14].Value = p_Row["BDJE"];
                parameters[15].Value = p_Row["FYLB"];
                parameters[16].Value = p_Row["BZ"];
                parameters[17].Value = p_Row["STATUS"];
                parameters[18].Value = p_Row["JSSX"];
                parameters[19].Value = p_Row["ID"];
                parameters[20].Value = p_Row["QFLB"];
                return parameters;
            }
        }


        /// <summary>
        /// 工料机参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_QUANTITY
        {
            get
            {

                OleDbParameter[] parameters = {
                        new OleDbParameter("@PID", OleDbType.Integer,4),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@SSLB", OleDbType.Integer,4),
                        new OleDbParameter("@QDID", OleDbType.Integer,4),
                        new OleDbParameter("@ZMID", OleDbType.Integer,4),
                        new OleDbParameter("@YSBH", OleDbType.VarChar,255),
                        new OleDbParameter("@YSMC", OleDbType.VarChar,255),
                        new OleDbParameter("@YSDW", OleDbType.VarChar,255),
                        new OleDbParameter("@YSXHL", OleDbType.Decimal),
                        new OleDbParameter("@BH", OleDbType.VarChar,255),
                        new OleDbParameter("@MC", OleDbType.VarChar,255),
                        new OleDbParameter("@DW", OleDbType.VarChar,255),
                        new OleDbParameter("@XHL", OleDbType.Decimal),
                        new OleDbParameter("@LB", OleDbType.VarChar,255),
                        new OleDbParameter("@DEDJ", OleDbType.Decimal),
                        //new OleDbParameter("@DEHJ", OleDbType.Decimal),
                        new OleDbParameter("@SCDJ", OleDbType.Decimal),
                        //new OleDbParameter("@SCHJ", OleDbType.Decimal),
                        //new OleDbParameter("@DJC", OleDbType.Decimal),
                        new OleDbParameter("@JSDJ", OleDbType.Decimal),
                        //new OleDbParameter("@JSDJC", OleDbType.Decimal),
                        //new OleDbParameter("@SL", OleDbType.Decimal),
                        new OleDbParameter("@GCL", OleDbType.Decimal),
                        new OleDbParameter("@IFZYCL", OleDbType.Boolean,1),
                        new OleDbParameter("@ZCLB", OleDbType.VarChar,50),
                        new OleDbParameter("@GGXH", OleDbType.VarChar,255),
                        new OleDbParameter("@SDCLB", OleDbType.VarChar,255),
                        new OleDbParameter("@SDCXS", OleDbType.Decimal),
                        new OleDbParameter("@YTLB", OleDbType.VarChar,255),
                        new OleDbParameter("@IFXZ", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSC", OleDbType.Boolean,1),
                        new OleDbParameter("@IFFX", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSDSCDJ", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSDSL", OleDbType.Boolean,1),
                        new OleDbParameter("@IFKFJ", OleDbType.Boolean,1),
                        new OleDbParameter("@SSKLB", OleDbType.VarChar,255),
                        new OleDbParameter("@GLJBZ", OleDbType.VarChar,255),
                        new OleDbParameter("@CTIME", OleDbType.Date),
                        new OleDbParameter("@SLH", OleDbType.Decimal),
                        new OleDbParameter("@SLDEHJ", OleDbType.Decimal),
                        new OleDbParameter("@SLSCHJ", OleDbType.Decimal),
                        //new OleDbParameter("@JSHJC", OleDbType.Decimal),
                        //new OleDbParameter("@HJC", OleDbType.Decimal),
                        //new OleDbParameter("@SDCHJ", OleDbType.Decimal),
                        new OleDbParameter("@CJ", OleDbType.VarChar,255),
                        new OleDbParameter("@PP", OleDbType.VarChar,255),
                        new OleDbParameter("@ZLDJ", OleDbType.VarChar,255),
                        new OleDbParameter("@GYS", OleDbType.VarChar,255),
                        new OleDbParameter("@CD", OleDbType.VarChar,255),
                        new OleDbParameter("@CJBZ", OleDbType.VarChar,255),
                        new OleDbParameter("@XGHSCDJ", OleDbType.Decimal),
                        new OleDbParameter("@TZXS", OleDbType.Decimal),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].SourceColumn = "PID";
                parameters[1].SourceColumn = "EnID";
                parameters[2].SourceColumn = "UnID";
                parameters[3].SourceColumn = "SSLB";
                parameters[4].SourceColumn = "QDID";
                parameters[5].SourceColumn = "ZMID";
                parameters[6].SourceColumn = "YSBH";
                parameters[7].SourceColumn = "YSMC";
                parameters[8].SourceColumn = "YSDW";
                parameters[9].SourceColumn = "YSXHL";
                parameters[10].SourceColumn = "BH";
                parameters[11].SourceColumn = "MC";
                parameters[12].SourceColumn = "DW";
                parameters[13].SourceColumn = "XHL";
                parameters[14].SourceColumn = "LB";
                parameters[15].SourceColumn = "DEDJ";
                //parameters[16].SourceColumn = "DEHJ";
                parameters[16].SourceColumn = "SCDJ";
                //parameters[18].SourceColumn = "SCHJ";
                //parameters[19].SourceColumn = "DJC";
                parameters[17].SourceColumn = "JSDJ";
                //parameters[21].SourceColumn = "JSDJC";
                //parameters[22].SourceColumn = "SL";
                parameters[18].SourceColumn = "GCL";
                parameters[19].SourceColumn = "IFZYCL";
                parameters[20].SourceColumn = "ZCLB";
                parameters[21].SourceColumn = "GGXH";
                parameters[22].SourceColumn = "SDCLB";
                parameters[23].SourceColumn = "SDCXS";
                parameters[24].SourceColumn = "YTLB";
                parameters[25].SourceColumn = "IFXZ";
                parameters[26].SourceColumn = "IFSC";
                parameters[27].SourceColumn = "IFFX";
                parameters[28].SourceColumn = "IFSDSCDJ";
                parameters[29].SourceColumn = "IFSDSL";
                parameters[30].SourceColumn = "IFKFJ";
                parameters[31].SourceColumn = "SSKLB";
                parameters[32].SourceColumn = "GLJBZ";
                parameters[33].SourceColumn = "CTIME";
                parameters[34].SourceColumn = "SLH";
                parameters[35].SourceColumn = "SLDEHJ";
                parameters[36].SourceColumn = "SLSCHJ";
                //parameters[42].SourceColumn = "JSHJC";
                //parameters[43].SourceColumn = "HJC";
                //parameters[44].SourceColumn = "SDCHJ";
                parameters[37].SourceColumn = "CJ";
                parameters[38].SourceColumn = "PP";
                parameters[39].SourceColumn = "ZLDJ";
                parameters[40].SourceColumn = "GYS";
                parameters[41].SourceColumn = "CD";
                parameters[42].SourceColumn = "CJBZ";
                parameters[43].SourceColumn = "XGHSCDJ";
                parameters[44].SourceColumn = "TZXS";
                parameters[45].SourceColumn = "ID";
                return parameters;
            }
        }

        /// <summary>
        /// 安装增加费
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_Increase
        {
            get
            {

                OleDbParameter[] parameters = {
						            new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@QDID", OleDbType.Integer,4),
                        new OleDbParameter("@ZMID", OleDbType.Integer,4),
                        new OleDbParameter("@Name", OleDbType.VarChar,255),
                        new OleDbParameter("@DH", OleDbType.VarChar,255),
                        new OleDbParameter("@JSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@FJJS", OleDbType.VarChar,255),
                        new OleDbParameter("@XS", OleDbType.Decimal),
                        new OleDbParameter("@RGXS", OleDbType.Decimal),
                        new OleDbParameter("@CLXS", OleDbType.Decimal),
                        new OleDbParameter("@JXXS", OleDbType.Decimal),
                        new OleDbParameter("@RGF", OleDbType.Decimal),
                        new OleDbParameter("@CLF", OleDbType.Decimal),
                        new OleDbParameter("@JXF", OleDbType.Decimal),
                        new OleDbParameter("@HJ", OleDbType.Decimal),
                        new OleDbParameter("@SSLB", OleDbType.Integer,4),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].SourceColumn = "UnID";
                parameters[1].SourceColumn = "EnID";
                parameters[2].SourceColumn = "QDID";
                parameters[3].SourceColumn = "ZMID";
                parameters[4].SourceColumn = "Name";
                parameters[5].SourceColumn = "DH";
                parameters[6].SourceColumn = "JSJC";
                parameters[7].SourceColumn = "FJJS";
                parameters[8].SourceColumn = "XS";
                parameters[9].SourceColumn = "RGXS";
                parameters[10].SourceColumn = "CLXS";
                parameters[11].SourceColumn = "JXXS";
                parameters[12].SourceColumn = "RGF";
                parameters[13].SourceColumn = "CLF";
                parameters[14].SourceColumn = "JXF";
                parameters[15].SourceColumn = "HJ";
                parameters[16].SourceColumn = "SSLB";
                parameters[17].SourceColumn = "ID";
                return parameters;
            }
        }

        /// <summary>
        /// 标准换算
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_StandardConversion
        {
            get
            {

                OleDbParameter[] parameters = {
						            new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@SSLB", OleDbType.Integer,4),
                        new OleDbParameter("@QDID", OleDbType.Integer,4),
                        new OleDbParameter("@ZMID", OleDbType.Integer,4),
                        new OleDbParameter("@IFXZ", OleDbType.Boolean,1),
                        new OleDbParameter("@DEH", OleDbType.VarChar,255),
                        new OleDbParameter("@HSLB", OleDbType.VarChar,255),
                        new OleDbParameter("@HSXX", OleDbType.VarChar,255),
                        new OleDbParameter("@DJ_DW", OleDbType.VarChar,255),
                        new OleDbParameter("@JBL_RGXS", OleDbType.VarChar,255),
                        new OleDbParameter("@DEH_CLXS", OleDbType.VarChar,255),
                        new OleDbParameter("@TZL_JXXS", OleDbType.VarChar,255),
                        new OleDbParameter("@ZC", OleDbType.VarChar,255),
                        new OleDbParameter("@SB", OleDbType.VarChar,255),
                        new OleDbParameter("@XHLB", OleDbType.VarChar,255),
                        new OleDbParameter("@FZ", OleDbType.VarChar,255),
                        new OleDbParameter("@THZHC", OleDbType.VarChar,255),
                        new OleDbParameter("@THWZFC", OleDbType.VarChar,255),
                        new OleDbParameter("@HSXI", OleDbType.VarChar,255),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].SourceColumn = "EnID";
                parameters[1].SourceColumn = "UnID";
                parameters[2].SourceColumn = "SSLB";
                parameters[3].SourceColumn = "QDID";
                parameters[4].SourceColumn = "ZMID";
                parameters[5].SourceColumn = "IFXZ";
                parameters[6].SourceColumn = "DEH";
                parameters[7].SourceColumn = "HSLB";
                parameters[8].SourceColumn = "HSXX";
                parameters[9].SourceColumn = "DJ_DW";
                parameters[10].SourceColumn = "JBL_RGXS";
                parameters[11].SourceColumn = "DEH_CLXS";
                parameters[12].SourceColumn = "TZL_JXXS";
                parameters[13].SourceColumn = "ZC";
                parameters[14].SourceColumn = "SB";
                parameters[15].SourceColumn = "XHLB";
                parameters[16].SourceColumn = "FZ";
                parameters[17].SourceColumn = "THZHC";
                parameters[18].SourceColumn = "THWZFC";
                parameters[19].SourceColumn = "HSXI";
                parameters[20].SourceColumn = "ID";
                return parameters;
            }
        }

        /// <summary>
        /// 用途类别
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_YTLBSummary
        {
            get
            {

                OleDbParameter[] parameters = {
                                            new OleDbParameter("@PID", OleDbType.Integer,4), 
                                            new OleDbParameter("@EnID", OleDbType.Integer,4), 
                                            new OleDbParameter("@UnID", OleDbType.Integer,4), 
                                            new OleDbParameter("@SSLB", OleDbType.Integer,4), 
                                            new OleDbParameter("@QDID", OleDbType.Integer,4), 
                                            new OleDbParameter("@ZMID", OleDbType.Integer,4), 
                                            new OleDbParameter("@YSBH", OleDbType.VarChar,255), 
                                            new OleDbParameter("@YSMC", OleDbType.VarChar,255), 
                                            new OleDbParameter("@YSDW", OleDbType.VarChar,255), 
                                            new OleDbParameter("@YSXHL", OleDbType.Decimal), 
                                            new OleDbParameter("@BH", OleDbType.VarChar,255), 
                                            new OleDbParameter("@MC", OleDbType.VarChar,255), 
                                            new OleDbParameter("@DW", OleDbType.VarChar,255), 
                                            new OleDbParameter("@XHL", OleDbType.Decimal), 
                                            new OleDbParameter("@LB", OleDbType.VarChar,255), 
                                            new OleDbParameter("@DEDJ", OleDbType.Decimal), 
                                            //new OleDbParameter("@DEHJ", OleDbType.Decimal), 
                                            new OleDbParameter("@SCDJ", OleDbType.Decimal), 
                                            //new OleDbParameter("@SCHJ", OleDbType.Decimal), 
                                            //new OleDbParameter("@DJC", OleDbType.Decimal), 
                                            new OleDbParameter("@JSDJ", OleDbType.Decimal), 
                                            //new OleDbParameter("@JSDJC", OleDbType.Decimal), 
                                            new OleDbParameter("@GCL", OleDbType.Decimal), 
                                            //new OleDbParameter("@SL", OleDbType.Decimal), 
                                            new OleDbParameter("@IFZYCL", OleDbType.Boolean,1), 
                                            new OleDbParameter("@ZCLB", OleDbType.VarChar,50), 
                                            new OleDbParameter("@GGXH", OleDbType.VarChar,255), 
                                            new OleDbParameter("@SDCLB", OleDbType.VarChar,255), 
                                            new OleDbParameter("@SDCXS", OleDbType.Decimal), 
                                            new OleDbParameter("@YTLB", OleDbType.VarChar,255), 
                                            new OleDbParameter("@IFXZ", OleDbType.Boolean,1),
                                            new OleDbParameter("@IFSC", OleDbType.Boolean,1), 
                                            new OleDbParameter("@IFFX", OleDbType.Boolean,1),
                                            new OleDbParameter("@IFSDSCDJ", OleDbType.Boolean,1), 
                                            new OleDbParameter("@IFSDSL", OleDbType.Boolean,1), 
                                            new OleDbParameter("@IFKFJ", OleDbType.Boolean,1),
                                            new OleDbParameter("@GLJBZ", OleDbType.VarChar,255), 
                                            new OleDbParameter("@CTIME", OleDbType.Date), 
                                            new OleDbParameter("@SLH", OleDbType.Decimal), 
                                            //new OleDbParameter("@SLDEHJ", OleDbType.Decimal), 
                                            //new OleDbParameter("@SLSCHJ", OleDbType.Decimal), 
                                            //new OleDbParameter("@JSHJC", OleDbType.Decimal), 
                                            new OleDbParameter("@HJC", OleDbType.Decimal), 
                                            new OleDbParameter("@SDCHJ", OleDbType.Decimal), 
                                            new OleDbParameter("@CJ", OleDbType.VarChar,255), 
                                            new OleDbParameter("@PP", OleDbType.VarChar,255), 
                                            new OleDbParameter("@ZLDJ", OleDbType.VarChar,255), 
                                            new OleDbParameter("@GYS", OleDbType.VarChar,255), 
                                            new OleDbParameter("@CD", OleDbType.VarChar,255), 
                                            new OleDbParameter("@CJBZ", OleDbType.VarChar,255), 
                                            new OleDbParameter("@XGHSCDJ", OleDbType.Decimal), 
                                            new OleDbParameter("@TZXS", OleDbType.Decimal), 
                                            new OleDbParameter("@BDBH", OleDbType.VarChar,50), 
                                            new OleDbParameter("@SSKLB", OleDbType.VarChar,255), 
                                            new OleDbParameter("@DZBS", OleDbType.Boolean,1), 
                                            new OleDbParameter("@ID", OleDbType.Integer,4), 
            };
                parameters[0].SourceColumn = "PID";
                parameters[1].SourceColumn = "EnID";
                parameters[2].SourceColumn = "UnID";
                parameters[3].SourceColumn = "SSLB";
                parameters[4].SourceColumn = "QDID";
                parameters[5].SourceColumn = "ZMID";
                parameters[6].SourceColumn = "YSBH";
                parameters[7].SourceColumn = "YSMC";
                parameters[8].SourceColumn = "YSDW";
                parameters[9].SourceColumn = "YSXHL";
                parameters[10].SourceColumn = "BH";
                parameters[11].SourceColumn = "MC";
                parameters[12].SourceColumn = "DW";
                parameters[13].SourceColumn = "XHL";
                parameters[14].SourceColumn = "LB";
                parameters[15].SourceColumn = "DEDJ";
                //parameters[16].SourceColumn = "DEHJ";
                parameters[16].SourceColumn = "SCDJ";
                //parameters[18].SourceColumn = "SCHJ";
                //parameters[19].SourceColumn = "DJC";
                parameters[17].SourceColumn = "JSDJ";
                //parameters[21].SourceColumn = "JSDJC";
                parameters[18].SourceColumn = "GCL";
                //parameters[23].SourceColumn = "SL";
                parameters[19].SourceColumn = "IFZYCL";
                parameters[20].SourceColumn = "ZCLB";
                parameters[21].SourceColumn = "GGXH";
                parameters[22].SourceColumn = "SDCLB";
                parameters[23].SourceColumn = "SDCXS";
                parameters[24].SourceColumn = "YTLB";
                parameters[25].SourceColumn = "IFXZ";
                parameters[26].SourceColumn = "IFSC";
                parameters[27].SourceColumn = "IFFX";
                parameters[28].SourceColumn = "IFSDSCDJ";
                parameters[29].SourceColumn = "IFSDSL";
                parameters[30].SourceColumn = "IFKFJ";
                parameters[31].SourceColumn = "GLJBZ";
                parameters[32].SourceColumn = "CTIME";
                parameters[33].SourceColumn = "SLH";
                parameters[34].SourceColumn = "SLDEHJ";
                parameters[35].SourceColumn = "SLSCHJ";
                //parameters[42].SourceColumn = "JSHJC";
                //parameters[43].SourceColumn = "HJC";
                //parameters[44].SourceColumn = "SDCHJ";
                parameters[36].SourceColumn = "CJ";
                parameters[37].SourceColumn = "PP";
                parameters[38].SourceColumn = "ZLDJ";
                parameters[39].SourceColumn = "GYS";
                parameters[40].SourceColumn = "CD";
                parameters[41].SourceColumn = "CJBZ";
                parameters[42].SourceColumn = "XGHSCDJ";
                parameters[43].SourceColumn = "TZXS";
                parameters[44].SourceColumn = "BDBH";
                parameters[45].SourceColumn = "SSKLB";
                parameters[46].SourceColumn = "DZBS";
                parameters[47].SourceColumn = "ID"; 
                return parameters;
            }
        }

        /// <summary>
        /// 汇总分析
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_Metaanalysis
        {
            get
            {

                OleDbParameter[] parameters = {
						            new OleDbParameter("@ParentID", OleDbType.Integer,4),
                        new OleDbParameter("@Number", OleDbType.VarChar,255),
                        new OleDbParameter("@Feature", OleDbType.VarChar,255),
                        new OleDbParameter("@Name", OleDbType.VarChar,255),
                        new OleDbParameter("@Calculation", OleDbType.VarChar,0),
                        new OleDbParameter("@Coefficient", OleDbType.Decimal),
                        new OleDbParameter("@Remark", OleDbType.VarChar,0),
                        new OleDbParameter("@Price", OleDbType.Decimal),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].SourceColumn = "ParentID";
                parameters[1].SourceColumn = "Number";
                parameters[2].SourceColumn = "Feature";
                parameters[3].SourceColumn = "Name";
                parameters[4].SourceColumn = "Calculation";
                parameters[5].SourceColumn = "Coefficient";
                parameters[6].SourceColumn = "Remark";
                parameters[7].SourceColumn = "Price";
                parameters[8].SourceColumn = "EnID";
                parameters[9].SourceColumn = "UnID";
                parameters[10].SourceColumn = "ID";
                return parameters;
            }
        }

        /// <summary>
        /// 其他项目
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_OtherProject
        {
            get
            {
                OleDbParameter[] parameters = {
						                    new OleDbParameter("@ParentID", OleDbType.Integer,4),
                                            new OleDbParameter("@Number", OleDbType.VarChar,100),
                                            new OleDbParameter("@Name", OleDbType.VarChar,50),
                                            new OleDbParameter("@Unit", OleDbType.VarChar,50),
                                            new OleDbParameter("@Quantities", OleDbType.VarChar,50),
                                            new OleDbParameter("@Calculation", OleDbType.VarChar,50),
                                            new OleDbParameter("@Unitprice", OleDbType.Decimal),
                                            new OleDbParameter("@Combinedprice", OleDbType.Decimal),
                                            new OleDbParameter("@Remark", OleDbType.VarChar,0),
                                            new OleDbParameter("@Feature", OleDbType.VarChar,255),
                                            new OleDbParameter("@beiyong", OleDbType.VarChar,255),
                                            new OleDbParameter("@IsSys", OleDbType.Boolean,1),
                                            new OleDbParameter("@jsdJ", OleDbType.Decimal),
                                            new OleDbParameter("@cjdj", OleDbType.Decimal),
                                            new OleDbParameter("@cjhj", OleDbType.Decimal),
                                            new OleDbParameter("@Coefficient", OleDbType.Decimal),
                                            new OleDbParameter("@EnID", OleDbType.Integer,4),
                                            new OleDbParameter("@UnID", OleDbType.Integer,4),
                                            new OleDbParameter("@Key", OleDbType.Integer,4),
                                            new OleDbParameter("@PKey", OleDbType.Integer,4),
                                            new OleDbParameter("@DZBS", OleDbType.Boolean),
                                            new OleDbParameter("@id", OleDbType.Integer,4)
                                            
                    };

                parameters[0].SourceColumn = "ParentID";
                parameters[1].SourceColumn = "Number";
                parameters[2].SourceColumn = "Name";
                parameters[3].SourceColumn = "Unit";
                parameters[4].SourceColumn = "Quantities";
                parameters[5].SourceColumn = "Calculation";
                parameters[6].SourceColumn = "Unitprice";
                parameters[7].SourceColumn = "Combinedprice";
                parameters[8].SourceColumn = "Remark";
                parameters[9].SourceColumn = "Feature";
                parameters[10].SourceColumn = "beiyong";
                parameters[11].SourceColumn = "IsSys";
                parameters[12].SourceColumn = "jsdJ";
                parameters[13].SourceColumn = "cjdj";
                parameters[14].SourceColumn = "cjhj";
                parameters[15].SourceColumn = "Coefficient";
                parameters[16].SourceColumn = "EnID";
                parameters[17].SourceColumn = "UnID";
                parameters[18].SourceColumn = "Key";
                parameters[19].SourceColumn = "PKey";
                parameters[20].SourceColumn = "DZBS";
                parameters[21].SourceColumn = "id";
                return parameters;
            }
        }

        /// <summary>
        /// 其他项目
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_OtherProject_Value(DataRow p_Row)
        {
            {
                OleDbParameter[] parameters = {
						                    new OleDbParameter("@ParentID", OleDbType.Integer,4),
                                            new OleDbParameter("@Number", OleDbType.VarChar,100),
                                            new OleDbParameter("@Name", OleDbType.VarChar,50),
                                            new OleDbParameter("@Unit", OleDbType.VarChar,50),
                                            new OleDbParameter("@Quantities", OleDbType.VarChar,50),
                                            new OleDbParameter("@Calculation", OleDbType.VarChar,50),
                                            new OleDbParameter("@Unitprice", OleDbType.Decimal),
                                            new OleDbParameter("@Combinedprice", OleDbType.Decimal),
                                            new OleDbParameter("@Remark", OleDbType.VarChar,0),
                                            new OleDbParameter("@Feature", OleDbType.VarChar,255),
                                            new OleDbParameter("@beiyong", OleDbType.VarChar,255),
                                            new OleDbParameter("@IsSys", OleDbType.Boolean,1),
                                            new OleDbParameter("@jsdJ", OleDbType.Decimal),
                                            new OleDbParameter("@cjdj", OleDbType.Decimal),
                                            new OleDbParameter("@cjhj", OleDbType.Decimal),
                                            new OleDbParameter("@Coefficient", OleDbType.Decimal),
                                            new OleDbParameter("@EnID", OleDbType.Integer,4),
                                            new OleDbParameter("@UnID", OleDbType.Integer,4),
                                            new OleDbParameter("@Key", OleDbType.Integer,4),
                                            new OleDbParameter("@PKey", OleDbType.Integer,4),
                                            new OleDbParameter("@DZBS", OleDbType.Boolean),
                                            new OleDbParameter("@id", OleDbType.Integer,4)
                    };

                parameters[0].Value = p_Row["ParentID"];
                parameters[1].Value = p_Row["Number"];
                parameters[2].Value = p_Row["Name"];
                parameters[3].Value = p_Row["Unit"];
                parameters[4].Value = p_Row["Quantities"];
                parameters[5].Value = p_Row["Calculation"];
                parameters[6].Value = p_Row["Unitprice"];
                parameters[7].Value = p_Row["Combinedprice"];
                parameters[8].Value = p_Row["Remark"];
                parameters[9].Value = p_Row["Feature"];
                parameters[10].Value = p_Row["beiyong"];
                parameters[11].Value = p_Row["IsSys"];
                parameters[12].Value = p_Row["jsdJ"];
                parameters[13].Value = p_Row["cjdj"];
                parameters[14].Value = p_Row["cjhj"];
                parameters[15].Value = p_Row["Coefficient"];
                parameters[16].Value = p_Row["EnID"];
                parameters[17].Value = p_Row["UnID"];
                parameters[18].Value = p_Row["Key"];
                parameters[19].Value = p_Row["PKey"];
                parameters[20].Value = p_Row["DZBS"];
                parameters[21].Value = p_Row["id"];
                return parameters;
            }
        }


        /// <summary>
        /// 工程取费
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_UnitFree
        {
            get
            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@GCLB", OleDbType.VarChar,255),
                        new OleDbParameter("@DEHFW", OleDbType.VarChar,255),
                        new OleDbParameter("@GLFFL", OleDbType.Decimal),
                        new OleDbParameter("@LRFL", OleDbType.Decimal),
                        new OleDbParameter("@FXTBFL", OleDbType.Decimal),
                        new OleDbParameter("@FXBDFL", OleDbType.Decimal),
                        new OleDbParameter("@GLFTBJSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@GLFBDJSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@LRFTBJSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@LRFBDJSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@FXFTBJSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@FXFBDJSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@IFSFHZ", OleDbType.Boolean,1),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].SourceColumn = "EnID";
                parameters[1].SourceColumn = "UnID";
                parameters[2].SourceColumn = "GCLB";
                parameters[3].SourceColumn = "DEHFW";
                parameters[4].SourceColumn = "GLFFL";
                parameters[5].SourceColumn = "LRFL";
                parameters[6].SourceColumn = "FXTBFL";
                parameters[7].SourceColumn = "FXBDFL";
                parameters[8].SourceColumn = "GLFTBJSJC";
                parameters[9].SourceColumn = "GLFBDJSJC";
                parameters[10].SourceColumn = "LRFTBJSJC";
                parameters[11].SourceColumn = "LRFBDJSJC";
                parameters[12].SourceColumn = "FXFTBJSJC";
                parameters[13].SourceColumn = "FXFBDJSJC";
                parameters[14].SourceColumn = "IFSFHZ";
                parameters[15].SourceColumn = "ID";
                return parameters;
            }
        }

        /// <summary>
        /// 变量表
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_Variable
        {
            get
            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@Key", OleDbType.VarChar,50),
                        new OleDbParameter("@Value", OleDbType.VarChar,50),
                        new OleDbParameter("@Remark", OleDbType.VarChar,0),
                        new OleDbParameter("@Length", OleDbType.Integer,4),
                        new OleDbParameter("@FYLB", OleDbType.VarChar,50),
                        new OleDbParameter("@Sort", OleDbType.Integer,4),
                        new OleDbParameter("@Type", OleDbType.VarChar,50),
                        new OleDbParameter("@ISDE", OleDbType.Boolean,1),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };




                parameters[0].SourceColumn = "Key";
                parameters[1].SourceColumn = "Value";
                parameters[2].SourceColumn = "Remark";
                parameters[3].SourceColumn = "Length";
                parameters[4].SourceColumn = "FYLB";
                parameters[5].SourceColumn = "Sort";
                parameters[6].SourceColumn = "Type";
                parameters[7].SourceColumn = "ISDE";
                parameters[8].SourceColumn = "EnID";
                parameters[9].SourceColumn = "ID";
                return parameters;
            }
        }


        /// <summary>
        /// 分部分项更新参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_SUBDATA_Value(DataRow p_Row)
        {

            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@PID", OleDbType.SmallInt),
                        new OleDbParameter("@PPARENTID", OleDbType.SmallInt),
                        new OleDbParameter("@CPARENTID", OleDbType.SmallInt),
                        new OleDbParameter("@FPARENTID", OleDbType.SmallInt),
                        new OleDbParameter("@XH", OleDbType.SmallInt),
                        new OleDbParameter("@XMBM", OleDbType.VarChar,255),
                        new OleDbParameter("@OLDXMBM", OleDbType.VarChar,255),
                        new OleDbParameter("@XMMC", OleDbType.VarChar,10000),
                        new OleDbParameter("@DW", OleDbType.VarChar,255),
                        new OleDbParameter("@TX", OleDbType.VarChar,255),
                        new OleDbParameter("@LB", OleDbType.VarChar,255),
                        new OleDbParameter("@JCBJ", OleDbType.Boolean,1),
                        new OleDbParameter("@FHBJ", OleDbType.Boolean,1),
                        new OleDbParameter("@ZYQD", OleDbType.Boolean,1),
                        new OleDbParameter("@SDDJ", OleDbType.Boolean,1),
                        new OleDbParameter("@JBHZ", OleDbType.Boolean,1),
                        new OleDbParameter("@XMTZ", OleDbType.VarChar,255),
                        new OleDbParameter("@GCLJSS", OleDbType.VarChar,255),
                        new OleDbParameter("@ZJWZ", OleDbType.VarChar,255),
                        new OleDbParameter("@JX", OleDbType.Boolean,1),
                        new OleDbParameter("@SC", OleDbType.Boolean,1),
                        new OleDbParameter("@YGLB", OleDbType.VarChar,255),
                        new OleDbParameter("@QFSZ", OleDbType.VarChar,255),
                        new OleDbParameter("@BEIZHU", OleDbType.VarChar,10000),
                        new OleDbParameter("@LibraryName", OleDbType.VarChar,255),
                        new OleDbParameter("@LY", OleDbType.VarChar,255),
                        new OleDbParameter("@SDQD", OleDbType.Boolean,1),
                        new OleDbParameter("@SFFB", OleDbType.Boolean,1),
                        new OleDbParameter("@HL", OleDbType.Decimal),
                        new OleDbParameter("@GCL", OleDbType.Decimal),
                        new OleDbParameter("@ZJTJ", OleDbType.Decimal),
                        new OleDbParameter("@ZHDJ", OleDbType.Decimal),
                        new OleDbParameter("@ZHHJ", OleDbType.Decimal),
                        new OleDbParameter("@ZJFDJ", OleDbType.Decimal),
                        new OleDbParameter("@RGFDJ", OleDbType.Decimal),
                        new OleDbParameter("@CLFDJ", OleDbType.Decimal),
                        new OleDbParameter("@JXFDJ", OleDbType.Decimal),
                        new OleDbParameter("@ZCFDJ", OleDbType.Decimal),
                        new OleDbParameter("@SBFDJ", OleDbType.Decimal),
                        new OleDbParameter("@GLFDJ", OleDbType.Decimal),
                        new OleDbParameter("@LRDJ", OleDbType.Decimal),
                        new OleDbParameter("@FXDJ", OleDbType.Decimal),
                        new OleDbParameter("@GFDJ", OleDbType.Decimal),
                        new OleDbParameter("@SJDJ", OleDbType.Decimal),
                        new OleDbParameter("@CJDJ", OleDbType.Decimal),
                        new OleDbParameter("@JCDJ", OleDbType.Decimal),
                        new OleDbParameter("@XHL", OleDbType.Decimal),
                        new OleDbParameter("@ZJFHJ", OleDbType.Decimal),
                        new OleDbParameter("@RGFHJ", OleDbType.Decimal),
                        new OleDbParameter("@CLFHJ", OleDbType.Decimal),
                        new OleDbParameter("@JXFHJ", OleDbType.Decimal),
                        new OleDbParameter("@ZCFHJ", OleDbType.Decimal),
                        new OleDbParameter("@SBFHJ", OleDbType.Decimal),
                        new OleDbParameter("@GLFHJ", OleDbType.Decimal),
                        new OleDbParameter("@LRHJ", OleDbType.Decimal),
                        new OleDbParameter("@FXHJ", OleDbType.Decimal),
                        new OleDbParameter("@GFHJ", OleDbType.Decimal),
                        new OleDbParameter("@SJHJ", OleDbType.Decimal),
                        new OleDbParameter("@JCHJ", OleDbType.Decimal),
                        new OleDbParameter("@CJHJ", OleDbType.Decimal),
                        new OleDbParameter("@ZGJE", OleDbType.Decimal),
                        new OleDbParameter("@JGJE", OleDbType.Decimal),
                        new OleDbParameter("@FBJE", OleDbType.Decimal),
                        new OleDbParameter("@FL", OleDbType.Decimal),
                        new OleDbParameter("@DECJ", OleDbType.VarChar,255),
                        new OleDbParameter("@JSJC", OleDbType.VarChar,255),
                        new OleDbParameter("@ZJFS", OleDbType.VarChar,255),
                        new OleDbParameter("@QDBH", OleDbType.VarChar,255),
                        new OleDbParameter("@XMNR", OleDbType.VarChar,255),
                        new OleDbParameter("@XMTZZ", OleDbType.VarChar,255),
                        new OleDbParameter("@TYGS", OleDbType.VarChar,255),
                        new OleDbParameter("@ISTY", OleDbType.Boolean,1),
                        new OleDbParameter("@PBZD", OleDbType.Decimal),
                        new OleDbParameter("@YGJE", OleDbType.Decimal),
                        new OleDbParameter("@STATUS", OleDbType.Boolean,1),
                        new OleDbParameter("@ZDSC", OleDbType.Boolean,1),
                        new OleDbParameter("@Key", OleDbType.Integer,4),
                        new OleDbParameter("@PKey", OleDbType.Integer,4),
                        new OleDbParameter("@Deep", OleDbType.Integer,4),
                        new OleDbParameter("@Sort", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.SmallInt),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@SSLB", OleDbType.Integer,4),
                       
                        new OleDbParameter("@RGFJC", OleDbType.Decimal),
                        new OleDbParameter("@CLFJC", OleDbType.Decimal),
                        new OleDbParameter("@JXFJC", OleDbType.Decimal), 
                        new OleDbParameter("@DZBS", OleDbType.Boolean),
                        new OleDbParameter("@ID", OleDbType.Integer,4),
                         new OleDbParameter("@ZYLB", OleDbType.VarChar,50)
            };

                parameters[0].Value = p_Row["PID"];
                parameters[1].Value = p_Row["PPARENTID"];
                parameters[2].Value = p_Row["CPARENTID"];
                parameters[3].Value = p_Row["FPARENTID"];
                parameters[4].Value = p_Row["XH"];
                parameters[5].Value = p_Row["XMBM"];
                parameters[6].Value = p_Row["OLDXMBM"];
                parameters[7].Value = p_Row["XMMC"];
                parameters[8].Value = p_Row["DW"];
                parameters[9].Value = p_Row["TX"];
                parameters[10].Value = p_Row["LB"];
                parameters[11].Value = p_Row["JCBJ"];
                parameters[12].Value = p_Row["FHBJ"];
                parameters[13].Value = p_Row["ZYQD"];
                parameters[14].Value = p_Row["SDDJ"];
                parameters[15].Value = p_Row["JBHZ"];
                parameters[16].Value = p_Row["XMTZ"];
                parameters[17].Value = p_Row["GCLJSS"];
                parameters[18].Value = p_Row["ZJWZ"];
                parameters[19].Value = p_Row["JX"];
                parameters[20].Value = p_Row["SC"];
                parameters[21].Value = p_Row["YGLB"];
                parameters[22].Value = p_Row["QFSZ"];
                parameters[23].Value = p_Row["BEIZHU"];
                parameters[24].Value = p_Row["LibraryName"];
                parameters[25].Value = p_Row["LY"];
                parameters[26].Value = p_Row["SDQD"];
                parameters[27].Value = p_Row["SFFB"];
                parameters[28].Value = p_Row["HL"];
                parameters[29].Value = p_Row["GCL"];
                parameters[30].Value = p_Row["ZJTJ"];
                parameters[31].Value = p_Row["ZHDJ"];
                parameters[32].Value = p_Row["ZHHJ"];
                parameters[33].Value = p_Row["ZJFDJ"];
                parameters[34].Value = p_Row["RGFDJ"];
                parameters[35].Value = p_Row["CLFDJ"];
                parameters[36].Value = p_Row["JXFDJ"];
                parameters[37].Value = p_Row["ZCFDJ"];
                parameters[38].Value = p_Row["SBFDJ"];
                parameters[39].Value = p_Row["GLFDJ"];
                parameters[40].Value = p_Row["LRDJ"];
                parameters[41].Value = p_Row["FXDJ"];
                parameters[42].Value = p_Row["GFDJ"];
                parameters[43].Value = p_Row["SJDJ"];
                parameters[44].Value = p_Row["CJDJ"];
                parameters[45].Value = p_Row["JCDJ"];
                parameters[46].Value = p_Row["XHL"];
                parameters[47].Value = p_Row["ZJFHJ"];
                parameters[48].Value = p_Row["RGFHJ"];
                parameters[49].Value = p_Row["CLFHJ"];
                parameters[50].Value = p_Row["JXFHJ"];
                parameters[51].Value = p_Row["ZCFHJ"];
                parameters[52].Value = p_Row["SBFHJ"];
                parameters[53].Value = p_Row["GLFHJ"];
                parameters[54].Value = p_Row["LRHJ"];
                parameters[55].Value = p_Row["FXHJ"];
                parameters[56].Value = p_Row["GFHJ"];
                parameters[57].Value = p_Row["SJHJ"];
                parameters[58].Value = p_Row["JCHJ"];
                parameters[59].Value = p_Row["CJHJ"];
                parameters[60].Value = p_Row["ZGJE"];
                parameters[61].Value = p_Row["JGJE"];
                parameters[62].Value = p_Row["FBJE"];
                parameters[63].Value = p_Row["FL"];
                parameters[64].Value = p_Row["DECJ"];
                parameters[65].Value = p_Row["JSJC"];
                parameters[66].Value = p_Row["ZJFS"];
                parameters[67].Value = p_Row["QDBH"];
                parameters[68].Value = p_Row["XMNR"];
                parameters[69].Value = p_Row["XMTZZ"];
                parameters[70].Value = p_Row["TYGS"];
                parameters[71].Value = p_Row["ISTY"];
                parameters[72].Value = p_Row["PBZD"];
                parameters[73].Value = p_Row["YGJE"];
                parameters[74].Value = p_Row["STATUS"];
                parameters[75].Value = p_Row["ZDSC"];
                parameters[76].Value = p_Row["Key"];
                parameters[77].Value = p_Row["PKey"];
                parameters[78].Value = p_Row["Deep"];
                parameters[79].Value = p_Row["Sort"];
                parameters[80].Value = p_Row["UnID"];
                parameters[81].Value = p_Row["EnID"];
                parameters[82].Value = p_Row["SSLB"];

                parameters[83].Value = p_Row["RGFJC"];
                parameters[84].Value = p_Row["CLFJC"];
                parameters[85].Value = p_Row["JXFJC"];
                parameters[86].Value = p_Row["DZBS"];
                parameters[87].Value = p_Row["ID"];
                parameters[88].Value = p_Row["ZYLB"];
                return parameters;
            }
        }

        /// <summary>
        /// 工料机参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_QUANTITY_Value(DataRow p_Row)
        {

            {

                OleDbParameter[] parameters = {
                        new OleDbParameter("@PID", OleDbType.Integer,4),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@SSLB", OleDbType.Integer,4),
                        new OleDbParameter("@QDID", OleDbType.Integer,4),
                        new OleDbParameter("@ZMID", OleDbType.Integer,4),
                        new OleDbParameter("@YSBH", OleDbType.VarChar,255),
                        new OleDbParameter("@YSMC", OleDbType.VarChar,255),
                        new OleDbParameter("@YSDW", OleDbType.VarChar,255),
                        new OleDbParameter("@YSXHL", OleDbType.Decimal),
                        new OleDbParameter("@BH", OleDbType.VarChar,255),
                        new OleDbParameter("@MC", OleDbType.VarChar,255),
                        new OleDbParameter("@DW", OleDbType.VarChar,255),
                        new OleDbParameter("@XHL", OleDbType.Decimal),
                        new OleDbParameter("@LB", OleDbType.VarChar,255),
                        new OleDbParameter("@DEDJ", OleDbType.Decimal),
                        //new OleDbParameter("@DEHJ", OleDbType.Decimal),

                        
                        new OleDbParameter("@SCDJ", OleDbType.Decimal),
                        //new OleDbParameter("@SCHJ", OleDbType.Decimal),
                        //new OleDbParameter("@DJC", OleDbType.Decimal),
                        new OleDbParameter("@JSDJ", OleDbType.Decimal),
                        //new OleDbParameter("@JSDJC", OleDbType.Decimal),
                        //new OleDbParameter("@SL", OleDbType.Decimal),
                        new OleDbParameter("@GCL", OleDbType.Decimal),
                        new OleDbParameter("@IFZYCL", OleDbType.Boolean,1),
                        new OleDbParameter("@ZCLB", OleDbType.VarChar,50),
                        new OleDbParameter("@GGXH", OleDbType.VarChar,255),
                        new OleDbParameter("@SDCLB", OleDbType.VarChar,255),
                        new OleDbParameter("@SDCXS", OleDbType.Decimal),
                        new OleDbParameter("@YTLB", OleDbType.VarChar,255),
                        new OleDbParameter("@IFXZ", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSC", OleDbType.Boolean,1),
                        new OleDbParameter("@IFFX", OleDbType.Boolean,1),

                        
                        new OleDbParameter("@IFSDSCDJ", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSDSL", OleDbType.Boolean,1),
                        new OleDbParameter("@IFKFJ", OleDbType.Boolean,1),
                        new OleDbParameter("@SSKLB", OleDbType.VarChar,255),
                        new OleDbParameter("@GLJBZ", OleDbType.VarChar,255),
                        new OleDbParameter("@CTIME", OleDbType.Date),
                        new OleDbParameter("@SLH", OleDbType.Decimal),
                        new OleDbParameter("@SLDEHJ", OleDbType.Decimal),
                        new OleDbParameter("@SLSCHJ", OleDbType.Decimal),
                        //new OleDbParameter("@JSHJC", OleDbType.Decimal),
                        //new OleDbParameter("@HJC", OleDbType.Decimal),
                        //new OleDbParameter("@SDCHJ", OleDbType.Decimal),

                        new OleDbParameter("@CJ", OleDbType.VarChar,255),
                        new OleDbParameter("@PP", OleDbType.VarChar,255),
                        new OleDbParameter("@ZLDJ", OleDbType.VarChar,255),
                        new OleDbParameter("@GYS", OleDbType.VarChar,255),
                        new OleDbParameter("@CD", OleDbType.VarChar,255),
                        new OleDbParameter("@CJBZ", OleDbType.VarChar,255),
                        new OleDbParameter("@XGHSCDJ", OleDbType.Decimal),
                        new OleDbParameter("@TZXS", OleDbType.Decimal),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].Value = p_Row["PID"];
                parameters[1].Value = p_Row["EnID"];
                parameters[2].Value = p_Row["UnID"];
                parameters[3].Value = p_Row["SSLB"];
                parameters[4].Value = p_Row["QDID"];
                parameters[5].Value = p_Row["ZMID"];
                parameters[6].Value = p_Row["YSBH"];
                parameters[7].Value = p_Row["YSMC"];
                parameters[8].Value = p_Row["YSDW"];
                parameters[9].Value = p_Row["YSXHL"];
                parameters[10].Value = p_Row["BH"];
                parameters[11].Value = p_Row["MC"];
                parameters[12].Value = p_Row["DW"];
                parameters[13].Value = p_Row["XHL"];
                parameters[14].Value = p_Row["LB"];
                parameters[15].Value = p_Row["DEDJ"];
                //parameters[16].Value = p_Row["DEHJ"];
                parameters[16].Value = p_Row["SCDJ"];
                //parameters[18].Value = p_Row["SCHJ"];
                //parameters[19].Value = p_Row["DJC"];
                parameters[17].Value = p_Row["JSDJ"];
                //parameters[21].Value = p_Row["JSDJC"];
                //parameters[22].Value = p_Row["SL"];
                parameters[18].Value = p_Row["GCL"];
                parameters[19].Value = p_Row["IFZYCL"];
                parameters[20].Value = p_Row["ZCLB"];
                parameters[21].Value = p_Row["GGXH"];
                parameters[22].Value = p_Row["SDCLB"];
                parameters[23].Value = p_Row["SDCXS"];
                parameters[24].Value = p_Row["YTLB"];
                parameters[25].Value = p_Row["IFXZ"];
                parameters[26].Value = p_Row["IFSC"];
                parameters[27].Value = p_Row["IFFX"];
                parameters[28].Value = p_Row["IFSDSCDJ"];
                parameters[29].Value = p_Row["IFSDSL"];
                parameters[30].Value = p_Row["IFKFJ"];
                parameters[31].Value = p_Row["SSKLB"];
                parameters[32].Value = p_Row["GLJBZ"];
                parameters[33].Value = p_Row["CTIME"];
                parameters[34].Value = p_Row["SLH"];
                parameters[35].Value = p_Row["SLDEHJ"];
                parameters[36].Value = p_Row["SLSCHJ"];
                //parameters[42].Value = p_Row["JSHJC"];
                //parameters[43].Value = p_Row["HJC"];
                //parameters[44].Value = p_Row["SDCHJ"];
                parameters[37].Value = p_Row["CJ"];
                parameters[38].Value = p_Row["PP"];
                parameters[39].Value = p_Row["ZLDJ"];
                parameters[40].Value = p_Row["GYS"];
                parameters[41].Value = p_Row["CD"];
                parameters[42].Value = p_Row["CJBZ"];
                parameters[43].Value = p_Row["XGHSCDJ"];
                parameters[44].Value = p_Row["TZXS"];
                parameters[45].Value = p_Row["ID"];
                return parameters;
            }
        }
        public OleDbParameter[] PARAMS_PROJ_YTLBSummary_Value(DataRow p_Row)
        {
                OleDbParameter[] parameters = {
                        new OleDbParameter("@PID", OleDbType.Integer,4),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@SSLB", OleDbType.Integer,4),
                        new OleDbParameter("@QDID", OleDbType.Integer,4),
                        new OleDbParameter("@ZMID", OleDbType.Integer,4),
                        new OleDbParameter("@YSBH", OleDbType.VarChar,255),
                        new OleDbParameter("@YSMC", OleDbType.VarChar,255),
                        new OleDbParameter("@YSDW", OleDbType.VarChar,255),
                        new OleDbParameter("@YSXHL", OleDbType.Decimal),
                        new OleDbParameter("@BH", OleDbType.VarChar,255),
                        new OleDbParameter("@MC", OleDbType.VarChar,255),
                        new OleDbParameter("@DW", OleDbType.VarChar,255),
                        new OleDbParameter("@XHL", OleDbType.Decimal),
                        new OleDbParameter("@LB", OleDbType.VarChar,255),
                        new OleDbParameter("@DEDJ", OleDbType.Decimal),
                        //new OleDbParameter("@DEHJ", OleDbType.Decimal),
                        new OleDbParameter("@SCDJ", OleDbType.Decimal),
                        //new OleDbParameter("@SCHJ", OleDbType.Decimal),
                        //new OleDbParameter("@DJC", OleDbType.Decimal),
                        new OleDbParameter("@JSDJ", OleDbType.Decimal),
                        //new OleDbParameter("@JSDJC", OleDbType.Decimal),
                        //new OleDbParameter("@SL", OleDbType.Decimal),
                        new OleDbParameter("@GCL", OleDbType.Decimal),
                        new OleDbParameter("@IFZYCL", OleDbType.Boolean,1),
                        new OleDbParameter("@ZCLB", OleDbType.VarChar,50),
                        new OleDbParameter("@GGXH", OleDbType.VarChar,255),
                        new OleDbParameter("@SDCLB", OleDbType.VarChar,255),
                        new OleDbParameter("@SDCXS", OleDbType.Decimal),
                        new OleDbParameter("@YTLB", OleDbType.VarChar,255),
                        new OleDbParameter("@IFXZ", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSC", OleDbType.Boolean,1),
                        new OleDbParameter("@IFFX", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSDSCDJ", OleDbType.Boolean,1),
                        new OleDbParameter("@IFSDSL", OleDbType.Boolean,1),
                        new OleDbParameter("@IFKFJ", OleDbType.Boolean,1),
                        new OleDbParameter("@SSKLB", OleDbType.VarChar,255),
                        new OleDbParameter("@GLJBZ", OleDbType.VarChar,255),
                        new OleDbParameter("@CTIME", OleDbType.Date),
                        new OleDbParameter("@SLH", OleDbType.Decimal),
                        new OleDbParameter("@SLDEHJ", OleDbType.Decimal),
                        new OleDbParameter("@SLSCHJ", OleDbType.Decimal),
                        //new OleDbParameter("@JSHJC", OleDbType.Decimal),
                        //new OleDbParameter("@HJC", OleDbType.Decimal),
                        //new OleDbParameter("@SDCHJ", OleDbType.Decimal),
                        new OleDbParameter("@CJ", OleDbType.VarChar,255),
                        new OleDbParameter("@PP", OleDbType.VarChar,255),
                        new OleDbParameter("@ZLDJ", OleDbType.VarChar,255),
                        new OleDbParameter("@GYS", OleDbType.VarChar,255),
                        new OleDbParameter("@CD", OleDbType.VarChar,255),
                        new OleDbParameter("@CJBZ", OleDbType.VarChar,255),
                        new OleDbParameter("@XGHSCDJ", OleDbType.Decimal),
                        new OleDbParameter("@TZXS", OleDbType.Decimal),
                        new OleDbParameter("@BDBH", OleDbType.VarChar,50),
                        new OleDbParameter("@DZBS", OleDbType.Boolean),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].Value = p_Row["PID"];
                parameters[1].Value = p_Row["EnID"];
                parameters[2].Value = p_Row["UnID"];
                parameters[3].Value = p_Row["SSLB"];
                parameters[4].Value = p_Row["QDID"];
                parameters[5].Value = p_Row["ZMID"];
                parameters[6].Value = p_Row["YSBH"];
                parameters[7].Value = p_Row["YSMC"];
                parameters[8].Value =p_Row[ "YSDW"];
                parameters[9].Value = p_Row["YSXHL"];
                parameters[10].Value =p_Row[ "BH"];
                parameters[11].Value = p_Row["MC"];
                parameters[12].Value = p_Row["DW"];
                parameters[13].Value = p_Row["XHL"];
                parameters[14].Value = p_Row["LB"];
                parameters[15].Value = p_Row["DEDJ"];
                //parameters[16].SourceColumn = "DEHJ";
                parameters[16].Value = p_Row["SCDJ"];
                //parameters[18].SourceColumn = "SCHJ";
                //parameters[19].SourceColumn = "DJC";
                parameters[17].Value = p_Row["JSDJ"];
                //parameters[21].SourceColumn = "JSDJC";
                //parameters[22].SourceColumn = "SL";
                parameters[18].Value = p_Row["GCL"];
                parameters[19].Value = p_Row["IFZYCL"];
                parameters[20].Value = p_Row["ZCLB"];
                parameters[21].Value = p_Row["GGXH"];
                parameters[22].Value =p_Row[ "SDCLB"];
                parameters[23].Value =p_Row[ "SDCXS"];
                parameters[24].Value =p_Row[ "YTLB"];
                parameters[25].Value = p_Row["IFXZ"];
                parameters[26].Value = p_Row["IFSC"];
                parameters[27].Value = p_Row["IFFX"];
                parameters[28].Value = p_Row["IFSDSCDJ"];
                parameters[29].Value = p_Row["IFSDSL"];
                parameters[30].Value = p_Row["IFKFJ"];
                parameters[31].Value = p_Row["SSKLB"];
                parameters[32].Value = p_Row["GLJBZ"];
                parameters[33].Value = p_Row["CTIME"];
                parameters[34].Value = p_Row["SLH"];
                parameters[35].Value = p_Row["SLDEHJ"];
                parameters[36].Value = p_Row["SLSCHJ"];
                //parameters[42].SourceColumn = "JSHJC";
                //parameters[43].SourceColumn = "HJC";
                //parameters[44].SourceColumn = "SDCHJ";
                parameters[37].Value = p_Row["CJ"];
                parameters[38].Value = p_Row["PP"];
                parameters[39].Value = p_Row["ZLDJ"];
                parameters[40].Value = p_Row["GYS"];
                parameters[41].Value = p_Row["CD"];
                parameters[42].Value = p_Row["CJBZ"];
                parameters[43].Value = p_Row["XGHSCDJ"];
                parameters[44].Value = p_Row["TZXS"];
                parameters[45].Value = p_Row["BDBH"];
                parameters[46].Value = p_Row["DZBS"];
                parameters[47].Value = p_Row["ID"];
                return parameters;
            }
       
        /// <summary>
        /// 汇总分析参数（项目的）
        /// </summary>
        /// <param name="p_Row"></param>
        /// <returns></returns>
        public OleDbParameter[] PARAMS_PROJ_METAANALYSIS_Value(DataRow p_Row)
        {

            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@Key", OleDbType.Integer),
                        new OleDbParameter("@PKey", OleDbType.Integer),
                        new OleDbParameter("@FGCF", OleDbType.Decimal),
                        new OleDbParameter("@CSXMF", OleDbType.Decimal),
                        new OleDbParameter("@QTXMF", OleDbType.Decimal),
                        new OleDbParameter("@GF", OleDbType.Decimal),
                        new OleDbParameter("@SJ", OleDbType.Decimal),
                        new OleDbParameter("@ZZJ", OleDbType.Decimal),
                        new OleDbParameter("@AQWM", OleDbType.Decimal),
                        new OleDbParameter("@LBTC", OleDbType.Decimal),
                        new OleDbParameter("@JSDW", OleDbType.VarChar,255),
                        new OleDbParameter("@JZMJ", OleDbType.Integer),
                        new OleDbParameter("@DWZJ", OleDbType.Decimal),
                        new OleDbParameter("@ZZJB", OleDbType.Decimal),
                        new OleDbParameter("@BZ", OleDbType.VarChar),
                        new OleDbParameter("@PID", OleDbType.Integer)
            };

                parameters[0].Value = p_Row["Key"];
                parameters[1].Value = p_Row["PKey"];
                parameters[2].Value = p_Row["FGCF"];
                parameters[3].Value = p_Row["CSXMF"];
                parameters[4].Value = p_Row["QTXMF"];
                parameters[5].Value = p_Row["GF"];
                parameters[6].Value = p_Row["SJ"];
                parameters[7].Value = p_Row["ZZJ"];
                parameters[8].Value = p_Row["AQWM"];
                parameters[9].Value = p_Row["LBTC"];
                parameters[10].Value = p_Row["JSDW"];
                parameters[11].Value = p_Row["JZMJ"];
                parameters[12].Value = p_Row["DWZJ"];
                parameters[13].Value = p_Row["ZZJB"];
                parameters[14].Value = p_Row["BZ"];
                parameters[15].Value = p_Row["PID"];
                return parameters;
            }
        }

        /// <summary>
        /// 汇总分析(单位工程的)
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_Metaanalysis_Value(DataRow p_Row)
        {

            {

                OleDbParameter[] parameters = {
						            new OleDbParameter("@ParentID", OleDbType.Integer,4),
                        new OleDbParameter("@Number", OleDbType.VarChar,255),
                        new OleDbParameter("@Feature", OleDbType.VarChar,255),
                        new OleDbParameter("@Name", OleDbType.VarChar,255),
                        new OleDbParameter("@Calculation", OleDbType.VarChar,0),
                        new OleDbParameter("@Coefficient", OleDbType.Decimal),
                        new OleDbParameter("@Remark", OleDbType.VarChar,0),
                        new OleDbParameter("@Price", OleDbType.Decimal),
                        new OleDbParameter("@EnID", OleDbType.Integer,4),
                        new OleDbParameter("@UnID", OleDbType.Integer,4),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
            };

                parameters[0].Value = p_Row["ParentID"];
                parameters[1].Value = p_Row["Number"];
                parameters[2].Value = p_Row["Feature"];
                parameters[3].Value = p_Row["Name"];
                parameters[4].Value = p_Row["Calculation"];
                parameters[5].Value = p_Row["Coefficient"];
                parameters[6].Value = p_Row["Remark"];
                parameters[7].Value = p_Row["Price"];
                parameters[8].Value = p_Row["EnID"];
                parameters[9].Value = p_Row["UnID"];
                parameters[10].Value = p_Row["ID"];
                return parameters;
            }
        }




        public OleDbParameter[] PARAMS_PROJ_UPDATE_Value(DataRow p_Row)
        {
            {
                OleDbParameter[] parameters = {
						new OleDbParameter("@PID", OleDbType.Integer,4) ,            
                        new OleDbParameter("@Name", OleDbType.VarChar,100) ,            
                        new OleDbParameter("@CODE", OleDbType.VarChar,0) ,            
                        new OleDbParameter("@QDGZ", OleDbType.VarChar,4) ,            
                        new OleDbParameter("@DEGZ", OleDbType.VarChar,4) ,            
                        new OleDbParameter("@PGCDD", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@PJFCX", OleDbType.SmallInt) ,            
                        new OleDbParameter("@PNSDD", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@CREATOR", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@EDITOR", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@Sort", OleDbType.Integer,4) ,            
                        new OleDbParameter("@Deep", OleDbType.Integer,4) ,            
                        new OleDbParameter("@NodeName", OleDbType.VarChar,100) ,            
                        new OleDbParameter("@PlaitNo", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@ReviewName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@PlaitName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@ProType", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@PrfType", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@Remark", OleDbType.VarChar,10000) ,            
                        new OleDbParameter("@QDLibName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@DELibName", OleDbType.VarChar,50) ,            
                        new OleDbParameter("@TJLibName", OleDbType.VarChar,50),
                        new OleDbParameter("@FISTDATETIME", OleDbType.Date),
                        new OleDbParameter("@EDITDATETIME", OleDbType.Date),
                        new OleDbParameter("@PlaitDate", OleDbType.Date),
                        new OleDbParameter("@ReviewDate", OleDbType.Date),
                        new OleDbParameter("@Key", OleDbType.Integer,4),
                        new OleDbParameter("@PKey", OleDbType.Integer,4),
                        new OleDbParameter("@PassWord", OleDbType.Integer,4),
                        new OleDbParameter("@JMSH", OleDbType.VarChar,255),
                        new OleDbParameter("@JQH", OleDbType.VarChar,255),
                        new OleDbParameter("@Time", OleDbType.VarChar,255),
                        new OleDbParameter("@ImageIndex", OleDbType.Integer),
                        new OleDbParameter("@State", OleDbType.VarChar),
                        new OleDbParameter("@ID", OleDbType.Integer,4)
                        
            };

                parameters[0].Value = p_Row["PID"];
                parameters[1].Value = p_Row["Name"];
                parameters[2].Value = p_Row["CODE"];
                parameters[3].Value = p_Row["QDGZ"];
                parameters[4].Value = p_Row["DEGZ"];
                parameters[5].Value = p_Row["PGCDD"];
                parameters[6].Value = p_Row["PJFCX"];
                parameters[7].Value = p_Row["PNSDD"];
                parameters[8].Value = p_Row["CREATOR"];
                parameters[9].Value = p_Row["EDITOR"];
                parameters[10].Value = p_Row["Sort"];
                parameters[11].Value = p_Row["Deep"];
                parameters[12].Value = p_Row["NodeName"];
                parameters[13].Value = p_Row["PlaitNo"];
                parameters[14].Value = p_Row["ReviewName"];
                parameters[15].Value = p_Row["PlaitName"];
                parameters[16].Value = p_Row["ProType"];
                parameters[17].Value = p_Row["PrfType"];
                parameters[18].Value = p_Row["Remark"];
                parameters[19].Value = p_Row["QDLibName"];
                parameters[20].Value = p_Row["DELibName"];
                parameters[21].Value = p_Row["TJLibName"];
                parameters[22].Value = p_Row["FISTDATETIME"];
                parameters[23].Value = p_Row["EDITDATETIME"];
                parameters[24].Value = p_Row["PlaitDate"];
                parameters[25].Value = p_Row["ReviewDate"];
                parameters[26].Value = p_Row["Key"];
                parameters[27].Value = p_Row["PKey"];
                parameters[28].Value = p_Row["PassWord"];
                parameters[29].Value = p_Row["JMSH"];
                parameters[30].Value = p_Row["JQH"];
                parameters[31].Value = p_Row["Time"];
                parameters[32].Value = p_Row["ImageIndex"];
                parameters[33].Value = p_Row["State"];
                parameters[34].Value = p_Row["ID"];
                //parameters[26].Direction = System.Data.ParameterDirection.InputOutput;
                return parameters;
            }
        }


        /// <summary>
        /// 分部分项更新参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_BiddingInfo
        {
            get
            {
                OleDbParameter[] parameters = {
						                        new OleDbParameter("@JSDWDBR", OleDbType.VarChar,255),
                                                new OleDbParameter("@ZBDLR", OleDbType.VarChar,255),
                                                new OleDbParameter("@ZBDLDBR", OleDbType.VarChar,255),
                                                new OleDbParameter("@GCLX", OleDbType.VarChar,255),
                                                new OleDbParameter("@ZBFW", OleDbType.VarChar,255),
                                                new OleDbParameter("@ZBMJ", OleDbType.VarChar,255),
                                                new OleDbParameter("@ZBGQ", OleDbType.VarChar,255),
                                                new OleDbParameter("@BZDW", OleDbType.VarChar,255),
                                                new OleDbParameter("@SJDW", OleDbType.VarChar,255),
                                                new OleDbParameter("@DBLX", OleDbType.VarChar,255),
                                                new OleDbParameter("@PlaitNo", OleDbType.VarChar,255),
                                                new OleDbParameter("@ReviewName", OleDbType.VarChar,255),
                                                new OleDbParameter("@PlaitName", OleDbType.VarChar,255),
                                                new OleDbParameter("@PlaitDate", OleDbType.Date),
                                                new OleDbParameter("@ReviewDate", OleDbType.Date),
                                                new OleDbParameter("@JSDW", OleDbType.VarChar,255),
                                                new OleDbParameter("@BZDWDBR", OleDbType.VarChar,255)
                                    
            };

                parameters[0].SourceColumn = "JSDWDBR";
                parameters[1].SourceColumn = "ZBDLR";
                parameters[2].SourceColumn = "ZBDLDBR";
                parameters[3].SourceColumn = "GCLX";
                parameters[4].SourceColumn = "ZBFW";
                parameters[5].SourceColumn = "ZBMJ";
                parameters[6].SourceColumn = "ZBGQ";
                parameters[7].SourceColumn = "BZDW";
                parameters[8].SourceColumn = "SJDW";
                parameters[9].SourceColumn = "DBLX";
                parameters[10].SourceColumn = "PlaitNo";
                parameters[11].SourceColumn = "ReviewName";
                parameters[12].SourceColumn = "PlaitName";
                parameters[13].SourceColumn = "PlaitDate";
                parameters[14].SourceColumn = "ReviewDate";
                parameters[15].SourceColumn = "JSDW";
                parameters[16].SourceColumn = "BZDWDBR";

                return parameters;
            }
        }

        /// <summary>
        /// 分部分项更新参数
        /// </summary>
        public OleDbParameter[] PARAMS_PROJ_TenderInfo
        {
            get
            {
                OleDbParameter[] parameters = {
						            new OleDbParameter("@TBDWDBR", OleDbType.VarChar,50),
                                    new OleDbParameter("@TBGQ", OleDbType.VarChar,50),
                                    new OleDbParameter("@ZLCN", OleDbType.VarChar,0),
                                    new OleDbParameter("@BBZJ", OleDbType.VarChar,50),
                                    new OleDbParameter("@DBLX", OleDbType.VarChar,50),
                                    new OleDbParameter("@JZS", OleDbType.VarChar,50),
                                    new OleDbParameter("@JZSH", OleDbType.VarChar,50),
                                    new OleDbParameter("@PlaitNo", OleDbType.VarChar,255),
                                    new OleDbParameter("@ReviewName", OleDbType.VarChar,255),
                                    new OleDbParameter("@PlaitName", OleDbType.VarChar,255),
                                    new OleDbParameter("@PlaitDate", OleDbType.Date),
                                    new OleDbParameter("@ReviewDate", OleDbType.Date),
                                    new OleDbParameter("@TBDW", OleDbType.VarChar,50)
                        };

                parameters[0].SourceColumn = "TBDWDBR";
                parameters[1].SourceColumn = "TBGQ";
                parameters[2].SourceColumn = "ZLCN";
                parameters[3].SourceColumn = "BBZJ";
                parameters[4].SourceColumn = "DBLX";
                parameters[5].SourceColumn = "JZS";
                parameters[6].SourceColumn = "JZSH";
                parameters[7].SourceColumn = "PlaitNo";
                parameters[8].SourceColumn = "ReviewName";
                parameters[9].SourceColumn = "PlaitName";
                parameters[10].SourceColumn = "PlaitDate";
                parameters[11].SourceColumn = "ReviewDate";
                parameters[12].SourceColumn = "TBDW";

                return parameters;
            }
        }
    }
}
