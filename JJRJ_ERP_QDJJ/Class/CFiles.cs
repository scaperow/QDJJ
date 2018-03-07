using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GOLDSOFT.QDJJ.UI
{
    public class CFiles
    {
        /// <summary>   
        /// 二进制序列化对象   
        /// </summary>   
        /// <param name="obj"></param>   
        public static void BinarySerialize(object obj)
        {
            using (FileStream stream = new FileStream("d:\\MyObject.dat", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formater = new BinaryFormatter();
                formater.Serialize(stream, obj);
                
            }
        }

        /// <summary>   
        /// 二进制反序列化   
        /// </summary>   
        /// <param name="fileName"></param>   
        //public static void BinaryDeserialize(string fileName)
        //{
        //    using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        //    {
        //        BinaryFormatter formater = new BinaryFormatter();
        //        MyObject obj = (MyObject)formater.Deserialize(stream);
        //        Console.WriteLine("对象已经被反序列化。" + obj.ToString());
        //    }
        //}   

    }
}
