using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class CircumferenceFormula
    {
        public string Formula(string a,string b,string h)
        {
            string strText = "sqrt"+"("+a +"*"+ a +"+"+ b +"*"+ b +"+"+ h +"*"+ h+")";
            return strText;
        }
        public string FormulaOne(string r,string α)
        {
            string strText = 3.1415926 +"*"+ r +"*"+ α +"/"+ 180;
            return strText ;
        }
        public string FormulaTwo(string r1,string r2)
        {
            string strText = 3.1415926 +"*"+ "sqrt"+"("+2 +"*"+ "("+r1 +"^"+ 2 +"+"+ r2 +"^"+ 2+")"+")";
            return strText ;
        }
        public string FormulaThree(string r)
        {
            string strText = 2 + "*" + 3.1415926 + "*" + r;
            return strText;
        }
        public string FormulaFour(string a)
        {
            string strText = "sqrt"+"("+3+")"+ "*"+ a;
            return strText ;
        }
    }
}
