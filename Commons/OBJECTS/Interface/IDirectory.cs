/*
 属性目录实现接口
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    interface IDirectory
    {
      long Key { get;set; }
      long PKey { get;set; }
      string NodeName { get; set; }
      int ImageIndex { get; set; }      
      int Deep { get; set; }
      long Sort { get; set; }
    }
}
