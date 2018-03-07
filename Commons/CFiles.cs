using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.InteropServices;

namespace GOLDSOFT.QDJJ.COMMONS
{
    
    public class CFiles
    {
        /// <summary>   
        /// 二进制序列化对象   
        /// </summary>   
        /// <param name="obj"></param>   
        public static void BinarySerialize(object obj ,string path)
        {

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                
                BinaryFormatter formater = new BinaryFormatter();
                formater.Serialize(stream, obj);
            }
        }


       /// <summary>
       /// 反序列化
       /// </summary>
       /// <param name="fileName"></param>
        public static _COBJECTS BinaryDeserialize(string fileName)
        {
            return BinaryDeserializeByProject(fileName);
           /* using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formater = new BinaryFormatter();
                
                _COBJECTS obj = (_COBJECTS)formater.Deserialize(stream);
                return obj;
            }*/
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="fileName"></param>
        public static object Deserialize(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formater = new BinaryFormatter();
                object obj = (object)formater.Deserialize(stream);
                return obj;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="fileName"></param>
        public static DataSet BinaryDeserializeForLib(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formater = new BinaryFormatter();
                object o = formater.Deserialize(stream);
                if (o.GetType().Name == "DataTable")
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add((o as DataTable));
                    return ds;
                }
                DataSet obj = o as DataSet;
                return obj;
            }
        }

        /// <summary>
        /// 反序列化 xml
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static object XmlDeserialize(Type type,string fileName)
        {
                string xml = GetFileXml(fileName);
                StringReader r = new StringReader(xml);
                XmlSerializer xmls = new XmlSerializer(type);   
                object obj = xmls.Deserialize(r);
                r.Close();   
                return obj;
        }
        static string ReplaceLowOrderASCIICharacters(string tmp)
        {
            StringBuilder info = new StringBuilder();
            foreach (char cc in tmp)
            {
                int ss = (int)cc;
                //if (((ss >= 0) && (ss <= 8)) || ((ss >= 11) && (ss <= 12)) || ((ss >= 14) && (ss <= 32)))
                //    info.AppendFormat(" ", ss);
                if (cc.Equals('') || ss == 0x1A || cc.Equals('')) continue;
                
                else info.Append(cc);
            }
            return info.ToString();
        }



        static string GetFileXml(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);

            string fileContent = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            fileContent = ReplaceLowOrderASCIICharacters(fileContent);
            StreamWriter writer = new StreamWriter(fileName, false);
            writer.Write(fileContent);
            writer.Close();
            writer.Dispose();

            XmlReader xmlReader = XmlReader.Create(fileName);
            XmlDocument doc = new XmlDocument();

            doc.Load(xmlReader);
            xmlReader.Close();
            XmlNodeList xnl = doc.GetElementsByTagName("分部分项标题");
            if (xnl.Count == 0) return doc.OuterXml;
            XmlNodeList plist = doc.GetElementsByTagName("分部分项表");
            foreach (XmlElement nodes in plist)
            {
                //当前元素中得 所有分部分项清单
                //XmlNode[] slist =  node.GetElementsByTagName("分部分项清单");
                XmlNode[] slist = nodes.GetElementsByTagName("分部分项清单").Cast<XmlNode>().ToArray();
                //删除所有清单
                nodes.RemoveAll();
                foreach (XmlNode n in slist)
                {
                    nodes.AppendChild(n.CloneNode(true));
                }
            }

            XmlNode[] xnls = doc.GetElementsByTagName("工程特征").Cast<XmlNode>().ToArray();

            foreach (XmlElement nodes in xnls)
            {
                nodes.ParentNode.RemoveChild(nodes);
            }
            return doc.OuterXml;
        }


        /// <summary>
        /// 序列化 xml
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static void XmlSerialize(object obje,string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmls = new XmlSerializer(obje.GetType());
                xmls.Serialize(writer,obje,ns);
                writer.WriteEndDocument();

            }
        }

        #region ---------------------------为保存单位单项项目重写数据读取方法-------------------------------

        /// <summary>   
        /// 二进制序列化对象   
        /// </summary>   
        /// <param name="obj"></param>   
        public static void BinarySerialize(string path,_Projects obj)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                BinaryFormatter formater = new BinaryFormatter();
                
                formater.Serialize(stream, obj);
                //循环单项
                foreach (_Engineering info in obj.StrustObject.ObjectList.Values)
                {
                    formater.Serialize(stream, info);
                    foreach (_UnitProject up in info.StrustObject.ObjectList.Values)
                    {
                        formater.Serialize(stream, up);
                    }

                }

            }
        }


        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static _Projects BinaryDeserializeByProject(string fileName)
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formater = new BinaryFormatter();
                    long lenth = stream.Length;
                    ArrayList list11 = new ArrayList();
                    _Projects proj = null;
                    _Engineering en = null;
                    
                    while (stream.Position != lenth)
                    {

                        object obj = formater.Deserialize(stream);
                        if (obj is _Projects)
                        {
                            proj = obj as _Projects;
                            proj.StrustObject = new _DataObjectList();
                        }
                        if (proj != null)
                        {
                            if (obj is _Engineering)
                            {
                                en = obj as _Engineering;
                                en.Parent = proj;
                                en.StrustObject = new _DataObjectList();
                                proj.StrustObject.Add(en.Directory.Key, en);
                            }
                            if (obj is _UnitProject)
                            {
                                _UnitProject un = obj as _UnitProject;
                                un.Parent = en;
                                en.StrustObject.Add(un.Directory.Key, un);
                            }
                        }


                    }
                    return proj;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        #endregion
    }
}
