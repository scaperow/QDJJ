using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class FileNameConverter : StringConverter
    {
        private static string[] m_FileList;

        public static string[] FileList
        {
            get { return m_FileList; }
            set { m_FileList = value; }
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(m_FileList);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
