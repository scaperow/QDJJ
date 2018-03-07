using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public  class AreaFormula
    {
        private double m_Result = 0.00;

        public double Result
        {
            get {return  this.m_Result; }
        }
        /// <summary>
        /// 长方体面积公式
        /// </summary>
        /// <returns></returns>
        public string Formula(string a, string b, string h)
        {
           string strText = 2 + "*" + h + "*" + "(" + a + "+" + b + ")";
           return strText;
        }

        public string FormulaOne(string D1, string D2, string δ, string L)
        {
           // string strText = "S = 3.1415926 * (0.001 * D1 + 0.001 * D2 + 0.015 + 0.002 * δ + 0.002 * δ * 5 % +0.0032 + 0.005) * L";
            string strText = 3.1415926 + "*" + "(" + 0.001 + "*" + D1 + 0.001 + "*" + D2 + "+" + 0.015 + "+" + 0.002 + "*" + δ + "+" + 0.002 + "*" + δ + "*" + 5 + "%" + "+" + 0.0032 + "+" + 0.005 + ")" + "*" + L;
            return strText;
        }
        public string FormulaTwo(string h, string b, string m, string n)
        {
            string strText = h +"*"+ (b +"+"+ h +"*"+ "(" +m +"+"+ n+")" +"/"+ 2);
            return strText;
        }
        public string FormulaThree(string a, string b, string c, string d, string e, string h1, string h2, string h3, string h4)
        {
            string strText = 0.5 +"*"+ "("+h1 +"*"+ "("+a +"+"+ b+")" +"+"+ h2+" *"+ "("+ b +" +"+ c+")" + h3 +"*"+ "("+c +"+"+ d+")" +"+"+ h4 +"*"+ "("+d +"+"+ e +")"+")";
            return strText;
        }
        public string FormulaFour(string b, string h, string n)
        {
            string strText = h +"*"+ "("+b +"+" +n +"*" +h+")";
            return strText;
        }
        public string FormulaFive(string D, string K, string N)
        {
            //string strText = "S = 3.1415926 * D * 2.5 * D * K * N / 1000000";
            string strText = 3.1415926 +"*"+ D +"*"+ 2.5 +"*"+ D +"*"+ K +"*"+ N +"/"+ 1000000;
            return strText;
        }

        public string FormulaSix(string D, string K, string N, string δ)
        {
           string strText = 3.1415926 +"*"+ "("+ 0.001 +"*"+ D +"+"+ 0.002 +"*"+ δ +"+"+0.002 +"*"+ δ+"*"+ 5+"%"+")"+ "*"+0.0025 +"*"+ D +"*"+ K +"*"+ N;
           return strText;
        }

        public string FormulaSeven(string D, string K, string N )
        {
            //string strText = "S=3.1415926*(0.001*D+0.002*δ+0.0022*δ*5%+0.0032+0.005)*L";
            string strText = 3.1415926 +"*"+ D +"*"+ 1.5 +"*"+ D +"*"+ K +"*"+ N +"/"+ 1000;
            return strText;
        }
        public string FormulaEight( string D,string K,string N,string δ)
        {
           string strText = 3.1415926 +"*"+ "("+0.001 +"*"+ D +"+"+ 0.0021 +"*"+ δ+")" +"*"+ 0.0015 +"*"+ D +"*"+ K +"*"+ N;
           return strText;
        }
        public string FormulaNine(string D,string δ,string L)
        {
           // S=3.1415926*(0.001*D+0.002*δ+0.0022*δ*5%+0.0032+0.005)*L
            string strText = 3.1415926 + "*" + "(" + 0.001 + "*" + D + "+" + 0.002 + "*" + δ + "+" + 0.0022 + "*" + δ + "*" + 5 + "%" + "+" + 0.0032 + "+" + 0.005 + ")" + "*" + L;
            return strText;
        }
        public string FormulaTen(string D1,string D2 ,string δ,string L)
        {
           // S=3.1415926*(0.001*D1+0.001*D2+0.015+0.002*δ+0.002*δ*5%+0.0032+0.005)*L
            string strText = 3.1415926 + "*" + "(" + 0.001 + "*" + D1 + "+" + 0.001 + "*" + D2 + "+" + 0.015 + "+" + 0.002 + "*" + δ + "+" + 0.002 + "*" + δ + "*" + 5 + "%" + 0.0032 + "+" + 0.005 + ")" + "*" + L;
            return strText;
        }
        public string FormulaEleven(string D,string L)
        {
            string strText = 3.1415926 +"*"+ D +"*"+ L +"*"+ 0.001;
            return strText;
        }
        public string FormulaTwelve(string a,string b)
        {
            string strText = a + "*" + b;
            return strText;
        }

        public string FormulaThirteen(string a,string b, string c ,string h1,string h2)
        {
            string strText = 0.5 + "*" + "(" + "(" + h1 + "+" + h2 + ")" + "*" + b + "+" + a + "*" + h1 + "+" + c + "*" + h2 + ")";
            return strText;
        }
        public string FormulaFourteen(string a,string h)
        {
            string strText = a + "*" + h;
            return strText;
        }
        public string FormulaFifteen(string r1,string r2,string θ)
        {
            string strText = 3.1415926 + "*" + θ + "*" + "(" + r2 + "*" + r2 + "-" + r1 + "*" + r1 + ")" + "/" + 360;
            return strText;
        }
        //public string FormulaSixteen(string a, string b, string c, string d, double α)
        //{
        //    //string strText = 0.5 + "*" + "(" + a + "*" + a + "+" + c + "*" + c + "-" + b + "*" + b + "-" + d + "*" + d + ")" + "*" + "sin" + "(" + "DegToRad" + "(" + α + ")" + ")" + " /" + "cos" + "(" + "DegToRad" + "(" + α + ")" + +")";
        //    //return strText;
        //}
        public string FormulaSeventeen(string r,string α)
        {
           string strText = 3.1415926 + "*" + r + "*" + r + "*" + "(" + α + "/" + 360 + ")";
            return strText;
        }
        public string FormulaEighteen(string D1,string D2,string δ,string L)
        {
            string strText = 3.1415926 + "*" + "(" + 0.001 + "*" + D1 + "+" + 0.015 + "*" + D2 + "+" + 0.002 + "*" + δ + "+" + 0.002 + "*" + δ + "*" + 5 + "%" + "+" + 0.0032 + "+" + 0.005 + ")" + "*" + L;
            return strText;
        }
        public string FormulaNineteen(string a,string b,string h)
        {
            string strText = 0.5 + "*" + "(" + a + "+" + b + ")" + "*" + h;
            return strText;
        }
        public string FormulaTwenty(string b,string h)
        {
            string strText = b + "*" + h;
            return strText;
        }
        public string FormulaTwenty_One(string r1,string r2)
        {
            string strText = 3.1415926 + "*" + r1 + "*" + r2;
            return strText;
        }
        public string FormulaTwenty_Two(string r1,string r2)
        {
            string strText = 3.1415926 + "*" + "(" + r2 + "*" + r2 + "-" + r1 + "*" + r1 + ")";
            return strText;
        }
        public string FormulaTwenty_Three(string r)
        {
            string strText = 3.1415926 + "*" + r + "*" + r;
            return strText;
        }
        public string FormulaTwenty_Four(string a,string k,string n)
        {
            string strText = 0.25 + "*" + a + "*" + a + "*" + k + "*" + "cos" + "(" + "DegToRad" + "(" + 180 + ")" + "/" + k + ")" + "/" + "sin" + "(" + "DegToRad" + "(" + 180 + ")" + "/" + k + ")";
            //this.m_Result = 0.25 + "*" + a + "*" + a + "*" + k + "*" + Math.Acos(180 / 4) + Math.Asin(180 / 4);
            return strText;
           
           
           
        }
        public string FormulaTwenty_Five(string a)
        {
            string strText = 6 +"*"+ a +"*"+ a;
            return strText;
        }
        public string FormulaTwenty_Six(string a )
        {
            string strText = 4 +"*"+ a +"*"+ a;
            return strText;
        }
        public string FormulaTwenty_Seven(string a,string b,string h)
        {
            string strText = 2 +"*"+ "("+a +"*"+ b +"+"+ b +"*"+ h +"+"+ h +"*"+ a+")";
            return strText;
        }
        public string FormulaTwenty_Eight(string a,string h)
        {
            string strText = 0.5 + "*" + a + "*" + h;
           
            return strText;
        }
        public string FormulaTwenty_Nine(string a, string b, string  c)
        {
          string strText = "sqrt"+"(" + "(" + a + "+" + b + "+" + c + ")" + "*" + "(" + b + "+" + c + "-" + a + ")" + " *" + "(" + a + "+" + c + "-" + b + ")" + "*" + "(" + a + "+" + b + "-" + c + ")" + ")" + " /" + 4;
          this.m_Result = Math.Sqrt((Convert.ToDouble(a) + Convert.ToDouble(b) + Convert.ToDouble(c)) * (Convert.ToDouble(b) + Convert.ToDouble(c) - Convert.ToDouble(a)) * (Convert.ToDouble(a) + Convert.ToDouble(c) - Convert.ToDouble(b)) * (Convert.ToDouble(a) + Convert.ToDouble(b) - Convert.ToDouble(c))) / 4;
           return strText;
        }
       
    }
}
