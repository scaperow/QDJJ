using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class CircuitFormula
    {
        public string Formula(string L, string S, string X, string c, string h, string μ)
        {
           // V=(L+2*c)*(S+2*c)*h+μ*X*X*(S+2*c)/2+μ*X*X*(L+2*c)/3
            string strText = "("+L +"+"+ 2 +"*"+ c+")"+ "*"+ "("+S +"+"+ 2 +"*"+c+")"+ "*"+ h +"+"+ μ +"*"+ X +"*"+ X +"*"+ "("+S +"+"+ 2 +"*"+ c+")"+ "/"+ 2 +"+"+ μ+"*"+ X +"*"+ X +"*"+ "("+L +"+"+ 2 +"*"+ c+")"+ "/"+ 3;
           return strText;
        }
        public string FormulaOne(string L, string S, string c, string h, string μ, string K)
        {
            //V=K*(L+2*c)*(S+2*c)*h+μ*h*h*(S+2*c)
            string strText = K +"*"+ "("+L +"+"+ 2 +"*"+ c+")"+ "*" +"("+S +"+"+2 +"*"+ c+")"+ "*"+ h +"+"+ μ +"*"+ h +"*"+ h +"*"+ "("+S +"+"+ 2 +"*"+ c+")";
            return strText ;
        }
        public string FormulaTwo(string L, string S, string c, string h)
        {
           // V=3.1415926*(L+2*c)*(S+2*c)*h/6
            string strText = 3.1415926 +"*" +"("+L +"+"+ 2 +"*"+ c+")"+ "*" +"("+S +"+"+ 2 +"*"+ c+")"+ "*"+ h +"/"+ 6;
            return strText ;
        }
        public string FormulaThree(string L, string S, string X, string c)
        {
            //V=(L+2*c)*(S+2*c)*X/2
            string strText = "("+L +"+"+ 2 +"*"+ c+")"+ "*"+ "("+S +"+"+ 2 +"*"+ c+")"+ "*"+ X+"/"+ 2;
            return strText ;
        }
        public string FormulaFour(string L, string S, string c, string h, string K)
        {
            //V=K*(L+2*c)*(S+2*c)*h
            string strText = K +"*"+ "("+L +"+"+ 2 +"*"+ c+")"+ "*"+ "("+S +"+"+ 2 +"*"+ c+")"+ "*"+ h;
            return strText ;
        }
        public string FormulaFive(string L,string a,string b,string c,string h)
        { 
            //V=(a+2*c+b+2*c)*h/2*L
            string strText =  "("+a +"+"+ 2 +"*"+ c +"+"+ b +"+"+ 2 +"*"+ c+")"+ "*"+ h +"/"+ 2 +"*"+ L;
            return strText ;
        }
    }
}
