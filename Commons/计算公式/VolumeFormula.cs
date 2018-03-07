using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT
{
    public  class VolumeFormula
    {
        public string Formula(string a,string b,string a1,string b1,string a2,string b2,string a3,string b3,string h ,string h1,string h2,string h3)
        {
            string strText = a +"*"+ b +"*"+ h1 +"+"+ h3 +"*"+ a1 +"*"+ b1 +"+"+ h2 +"*"+ "("+a +"*"+ b +"+"+ a1 +"*"+ b1 +"+"+ "("+a +"+"+ a1+")"+ "*"+ "("+b +"+"+ b1+")"+")"+" /"+ 6 +"-"+ h +"*"+ "("+a2 +"*"+ b2 +"+"+ a3 +"*"+ b3 +"+"+ "("+a2 +"+"+ a3+")"+ "*" +"("+b2 +"+"+ b3+")"+")"+ "/"+ 6;
            return strText;
        }

        public string FormulaOne(string a,string b,string h)
        {
            string strText = a + "*" + b + "*" + h;
            return strText;
        }

        public string FormulaTwo(string D1,string D2,string δ, string L)
        {
           // V=3.1415926*(D1+D2+15+1.033*δ)*1.033*δ*L/1000000
            string strText = 3.1415926 +"*"+ "("+D1 +"+"+ D2 +"+"+ 15 +"+"+ 1.033 +"*"+ δ+")"+ "*"+ 1.033 +"*"+ δ +"*"+ L +"/"+ 1000000;
            return strText;
        }
        public string FormulaThree(string a,string b,string a1,string b1,string h,string h1)
        {
            string strText = a1 +"*"+ b1 +"*"+ h1 +"+"+ "("+h +"-"+ h1+")"+ "*"+ "("+a1 +"*"+ b1 +"+"+ a +"*"+ b +"+"+ "sqrt"+"("+a1 +"*"+ b1 +"*"+ a +"*"+ b+")"+")"+ "/"+ 3;
            return strText;
        }
        public string FormulaFour(string D, string K,string N,string δ)
        {
            string strText = 3.1415926 + "*" + "(" + D + "+" + 1.033 + "*" + δ + ")" + "*" + 2.5 + "*" + D + "*" + 1.033 + "*" + δ + "*" + K + "*" + N + "/" + 1000000000; 
             return strText;
        }

        public string FormulaFive(string D,string K,string N,string δ)
        {
            string strText = 3.1415926 +"*"+"("+D+"+"+1.033+"*"+δ+")"+"*"+1.5+"*"+D+"*"+1.033+"*"+δ+"*"+K+"*"+N+"/"+1000000000;
            return strText;
        }
        public string FormulaSix(string D,string L,string δ)
        {
           // V=3.1415926*(D+1.033*δ)*1.033*δ*L/1000000
            string strText = 3.1415926 +"*"+ "("+D +"+"+ 1.033 +"*"+ δ+")" +"*"+ 1.033 +"*"+ δ +"*"+ L +"/"+ 1000000;
            return strText;
        }
        public string FormulaSeven(string D1,string D2,string δ,string L)
        {
           // V=3.1415926*(D1+D2+15+1.033*δ)*1.033*δ*L/1000000
            string strText = 3.1415926 +"*"+ "("+D1 +"+"+ D2 +"+"+ 15 +"+"+ 1.033 +"*"+ δ+")"+ "*"+ 1.033 +"*"+ δ +"*"+ L +"/"+ 1000000;
            return strText;
        }
        public string FormulaEight(string r,string l1,string l2)
        {
            string strText = 3.1415926+"*"+ r +"*"+ r +"*"+ "+("+l1 +"+"+ l2 +"-"+ 2 +"*"+ r +"/"+ 3+")";
            return strText;
        }
        public string FormulaNine(string s1,string s2,string h)
        {
           string strText = h +"*"+ "("+s1 +"+"+ s2 +"+"+ "sqrt"+"("+s1 +"*"+ s2+")"+")"+ "/"+ 3;
            return strText;
        }
        public string FormulaTen(string s,string h)
        {
            string strText = s +"*"+ h;
            return strText;
        }
        public string FormulaEleven(string s, string h)
        {
            string strText = s +"*"+ h +"/"+ 3;
            return strText;
        }
        public string FormulaTwelve(string a,string a1,string b,string b1,string H)
        {
            string strText = H+" *"+ "("+"("+2 +"*"+ a1 +"+"+ a+")"+ "*"+ b1 +"+"+ "("+2 +"*"+ a +"*"+ a1+")"+ "*" +b+")" +"/"+ 6;
            return strText;
        }
        public string FormulaThirteen(string a,string b,string h)
        {
            string strText = 3.1415926 +"*"+ h +"*"+ "("+3 +"*"+ a +"*"+ a +"+"+ 3 +"*"+ b +"*"+ b +"+"+ h +"*"+ h+")"+ "/"+ 6;
            return strText ;
        }
        public string FormulaFourteen(string a,string h)
        {
            string strText = 3.1415926 +"*"+ h +"*"+ "("+3 +"*"+ a +"*"+ a +"+"+ h +"*"+ h+")"+ "/"+ 6;
            return strText;
        }
        public string FormulaFifteen(string r)
        {
            string strText = 4 +"*"+ 3.1415926 +"*"+ r +"^"+ 3 +"/"+ 3;
            return strText;
        }
        public string FormulaSixteen(string D1, string D2,string δ,string  L)
        {
           // V=3.1415926*(D1+1.5*D2+15+1.033*δ)*1.033*δ*L/1000000
            string strText = 3.1415926 +"*"+ "("+D1 +"+"+ 1.5 +"*"+ D2 +"+"+ 15 +"+"+ 1.033 +"*"+ δ+")"+ "*" +1.033 +"*"+ δ +"*"+ L +"/"+ 1000000;
            return strText;
        }
        public string FormulaSeventeen(string a,string b,string a1,string b1,string h)
        {
            string strText = h +"*"+ "("+a +"*"+ b +"+"+ "("+a +"+"+ a1+")"+ "*"+ "("+b +"+"+ b1+")" +"+"+ a1 +"*"+ b1+")";
            return strText ;
        }
        public string FormulaEighteen(string a,string b,string a1,string b1,string h,string h1)
        {
            string strText = a +"*"+ b +"*"+ h +"+"+ h1 +"*"+ "("+a +"*"+ b +"+"+ "("+a +"+"+ a1+")"+ "*"+ "("+b +"+"+ b1+")"+ "+"+ a1 +"*"+ b1+")"+ "/"+ 6;
            return strText ;
        }
        public string FormulaNineteen(string r1,string r2,string h)
        {
            string strText = 3.1415926 +"*"+ h +"*"+ "("+2 +"*"+ r2 +"*"+ r2 +"+"+ r1 +"* "+r1+")"+ "/"+ 3;
            return strText ;
        }
        public string FormulaTwenty(string a1,string a3,string b,string h)
        {
            string strText = "("+a1 +"+"+ a3+")"+ "*"+ b +"*"+ h +"/"+ 6;
            return strText ;
        }
        public string FormulaTwenty_One(string r,string h1,string h2)
        {
            string strText = 3.1415926 +"*"+ r +"*"+ r +"*"+ "("+h1 +"+"+ h2+")"+ "/"+ 2;
            return strText ;
        }
        public string FormulaTwenty_Two(string r,string d)
        {
            string strText = 2 +"*"+ 3.1415926 +"*"+ 3.1415926 +"*"+ r +"*"+ d +"*"+ d;
            return strText ;
        }
        public string FormulaTwenty_Three(string r1,string r2,string h)
        {
            string strText = 3.1415926 +"*"+ h +"*"+ "("+r2+"*"+ r2 +"-"+ r1 +"*"+ r1+")";
            return strText ;
        }
        public string FormulaTwenty_Four(string r1,string r2,string h)
        {
            string strText = 3.1415926 +"*"+ h +"*"+ "("+r1 +"*"+ r1 +"+"+ r2 +"*"+ r2 +"+"+ r1 +"*"+ r2+")"+ "/"+ 3;
            return strText ;
        }
        public string FormulaTwenty_Five(string r,string h )
        {
            string strText = 3.1415926 +"*"+ r +"*"+ r +"*"+ h;
            return strText ;
        }
        public string FormulaTwenty_Six(string r,string h )
        {
            string strText = 3.1415926+ "*"+ r +"*"+ r +"*"+ h +"/"+ 3;
            return strText ;
        }
        public string FormulaTwenty_Seven(string a)
        {
            string strText = a + "^" + 3;
            return strText;

        }
    }
} 
