using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using GOLDSOFT.QDJJ.CTRL;

namespace GOLDSOFT.QDJJ.COMMONS
{
    public class CommonUserControlShow
    {
        public PrimitiveFormula uc = new PrimitiveFormula();

            //# region 控件显示控制
            ///// <summary>
            ///// 面积控件显示控制
            ///// </summary>
            ///// <param name="ImgLstControl"></param>
            //public void UserAreaControlShow(ImageListBoxControl ImgLstControl)
            //{
            //    try
            //    {
            //        int imgIndx = ImgLstControl.SelectedIndex;
            //        switch (imgIndx)
            //        {
            //            case 0:
            //                UserControlMethodThree();
            //                break;
            //            case 1:
            //                UserControlMethodFour();
            //                break;
            //            case 2:
            //                UserControlMethodFour();
            //                break;
            //            case 3:
            //                UserControlMethodNine();
            //                break;
            //            case 4:
            //                UserControlMethodThree();
            //                break;
            //            case 5:
            //                UserControlMethodThree();
            //                break;
            //            case 6:
            //                UserControlMethodFour();
            //                break;
            //            case 7:
            //                UserControlMethodThree();
            //                break;
            //            case 8:
            //                UserControlMethodFour();
            //                break;
            //            case 9:
            //                UserControlMethodThree();
            //                break;
            //            case 10:
            //                UserControlMethodFour();
            //                break;
            //            case 11:
            //                UserControlMethodTwo();
            //                break;
            //            case 12:
            //                UserControlMethodTwo();
            //                break;
            //            case 13:

            //                UserControlMethodFive();
            //                break;
            //            case 14:
            //                UserControlMethodTwo();
            //                break;
            //            case 15:
            //                UserControlMethodThree();
            //                break;
            //            case 16:
            //                UserControlMethodFive();
            //                break;
            //            case 17:
            //                UserControlMethodTwo();
            //                break;
            //            case 18:
            //                UserControlMethodFour();
            //                break;
            //            case 19:
            //                UserControlMethodThree();
            //                break;
            //            case 20:
            //                UserControlMethodTwo();
            //                break;
            //            case 21:
            //                UserControlMethodTwo();
            //                break;
            //            case 22:
            //                UserControlMethodTwo();
            //                break;
            //            case 23:
            //                UserControlMethodOne();
            //                break;
            //            case 24:
            //                UserControlMethodThree();
            //                break;
            //            case 25:
            //                UserControlMethodOne();
            //                break;
            //            case 26:
            //                UserControlMethodOne();
            //                break;
            //            case 27:
            //                UserControlMethodThree();
            //                break;
            //            case 28:
            //                UserControlMethodTwo();
            //                break;
            //            case 29:
            //                UserControlMethodThree();
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //}


            ///// <summary>
            ///// 体积控件显示控制
            ///// </summary>
            ///// <param name="ImgLstControl"></param>
            //public void UserVolumeControlShow(ImageListBoxControl ImgLstControl)
            //{
            //    try
            //    {
            //        int imgIndx = ImgLstControl.SelectedIndex;
            //        switch (imgIndx)
            //        {

            //            case 0:
            //                UserControlMethodTwenlve();
            //                break;
            //            case 1:
            //                UserControlMethodThree();
            //                break;
            //            case 2:
            //                UserControlMethodFour();
            //                break;
            //            case 3:
            //                UserControlMethodSix();
            //                break;
            //            case 4:
            //                UserControlMethodFour();
            //                break;
            //            case 5:
            //                UserControlMethodFour();
            //                break;
            //            case 6:
            //                UserControlMethodThree();
            //                break;
            //            case 7:
            //                UserControlMethodFour();
            //                break;
            //            case 8:
            //                UserControlMethodThree();
            //                break;
            //            case 9:
            //                UserControlMethodThree();
            //                break;
            //            case 10:
            //                UserControlMethodTwo();
            //                break;
            //            case 11:
            //                UserControlMethodTwo();
            //                break;
            //            case 12:
            //                UserControlMethodFive();
            //                break;
            //            case 13:
            //                UserControlMethodThree();
            //                break;
            //            case 14:
            //                UserControlMethodTwo();
            //                break;
            //            case 15:
            //                UserControlMethodOne();
            //                break;
            //            case 16:
            //                UserControlMethodFour();
            //                break;
            //            case 17:
            //                UserControlMethodFive();
            //                break;
            //            case 18:
            //                UserControlMethodSix();
            //                break;
            //            case 19:
            //                UserControlMethodThree();
            //                break;
            //            case 20:
            //                UserControlMethodFour();
            //                break;
            //            case 21:
            //                UserControlMethodThree();
            //                break;
            //            case 22:
            //                UserControlMethodTwo();
            //                break;
            //            case 23:
            //                UserControlMethodThree();
            //                break;
            //            case 24:
            //                UserControlMethodThree();
            //                break;
            //            case 25:
            //                UserControlMethodTwo();
            //                break;
            //            case 26:
            //                UserControlMethodTwo();
            //                break;
            //            case 27:
            //                UserControlMethodOne();
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //}

            ///// <summary>
            ///// 周长控件显示控制
            ///// </summary>
            ///// <param name="ImgLstControl"></param>
            //public void UserCircumferenceControlShow(ImageListBoxControl ImgLstControl)
            //{
            //    try
            //    {
            //        int imgIndx = ImgLstControl.SelectedIndex;
            //        switch (imgIndx)
            //        {
            //            case 0:
            //                UserControlMethodThree();
            //                break;
            //            case 1:
            //                UserControlMethodTwo();
            //                break;
            //            case 2:
            //                UserControlMethodTwo();
            //                break;
            //            case 3:
            //                UserControlMethodOne();
            //                break;
            //            case 4:
            //                UserControlMethodOne();
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //}


            ///// <summary>
            ///// 送电线路控件控制
            ///// </summary>
            ///// <param name="ImgLstControl"></param>
            //public void UserCircuitControlShow(ImageListBoxControl ImgLstControl)
            //{
            //    try
            //    {
            //        int imgIndx = ImgLstControl.SelectedIndex;
            //        switch (imgIndx)
            //        {
            //            case 0:
            //                UserControlMethodSix();
            //                break;
            //            case 1:
            //                UserControlMethodSix();
            //                break;
            //            case 2:
            //                UserControlMethodFour();
            //                break;
            //            case 3:
            //                UserControlMethodFour();
            //                break;
            //            case 4:
            //                UserControlMethodFive();
            //                break;
            //            case 5:
            //                UserControlMethodFive();
            //                break;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }

            //}
            //# endregion
            //# region 控件显示公共方法
            ///// <summary>
            ///// 一个参数控件显示控制
            ///// </summary>
            //public void UserControlMethodOne()
            //{
            //    uc.Lab4.Visible = true;
            //    uc.TxtName4.Visible = true;

            //    uc.Lab.Visible = false;
            //    uc.Lab2.Visible = false;
            //    uc.Lab3.Visible = false;
            //    uc.Lab5.Visible = false;
            //    uc.Lab6.Visible = false;
            //    uc.Lab7.Visible = false;
            //    uc.Lab8.Visible = false;
            //    uc.Lab9.Visible = false;
            //    uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false;
            //    uc.Lab12.Visible = false;



            //    uc.TxtName.Visible = false;
            //    uc.TxtName2.Visible = false;
            //    uc.TxtName3.Visible = false;
            //    uc.TxtName5.Visible = false;
            //    uc.TxtName6.Visible = false;
            //    uc.TxtName7.Visible = false;
            //    uc.TxtName8.Visible = false;
            //    uc.TxtName9.Visible = false;
            //    uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;
            //}

            ///// <summary>
            ///// 二个参数控件显示控制
            ///// </summary>
            //public void UserControlMethodTwo()
            //{

            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;

            //    uc.Lab.Visible = false;
            //    uc.Lab2.Visible = false;
            //    uc.Lab3.Visible = false;
            //    uc.Lab6.Visible = false;
            //    uc.Lab7.Visible = false;
            //    uc.Lab8.Visible = false;
            //    uc.Lab9.Visible = false;
            //    uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false;
            //    uc.Lab12.Visible = false;
            //    uc.TxtName.Visible = false;
            //    uc.TxtName2.Visible = false;
            //    uc.TxtName3.Visible = false;
            //    uc.TxtName6.Visible = false;
            //    uc.TxtName7.Visible = false;
            //    uc.TxtName8.Visible = false;
            //    uc.TxtName9.Visible = false;
            //    uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;

            //}

            ///// <summary>
            ///// 三个参数控件显示控制
            ///// </summary>
            //public void UserControlMethodThree()
            //{
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;

            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;


            //    uc.Lab.Visible = false;
            //    uc.Lab2.Visible = false;
            //    uc.Lab3.Visible = false;
            //    uc.Lab7.Visible = false;
            //    uc.Lab8.Visible = false;
            //    uc.Lab9.Visible = false;
            //    uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false;
            //    uc.Lab12.Visible = false;

            //    uc.TxtName.Visible = false;
            //    uc.TxtName2.Visible = false;
            //    uc.TxtName3.Visible = false;
            //    uc.TxtName7.Visible = false;
            //    uc.TxtName8.Visible = false;
            //    uc.TxtName9.Visible = false;
            //    uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;

            //}

            ///// <summary>
            ///// 四个参数控件显示控制
            ///// </summary>
            //public void UserControlMethodFour()
            //{
            //    uc.Lab3.Visible = true;
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;
            //    uc.TxtName3.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;


            //    uc.Lab.Visible = false;
            //    uc.Lab2.Visible = false;
            //    uc.Lab7.Visible = false;
            //    uc.Lab8.Visible = false;
            //    uc.Lab9.Visible = false;
            //    uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false;
            //    uc.Lab12.Visible = false;
            //    uc.TxtName.Visible = false;
            //    uc.TxtName2.Visible = false;
            //    uc.TxtName7.Visible = false;
            //    uc.TxtName8.Visible = false;
            //    uc.TxtName9.Visible = false;
            //    uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;

            //}

            ///// <summary>
            ///// 五个参数控件显示控制
            ///// </summary>
            //public void UserControlMethodFive()
            //{
            //    uc.Lab3.Visible = true;
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;
            //    uc.Lab7.Visible = true;
            //    uc.TxtName3.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;
            //    uc.TxtName7.Visible = true;


            //    uc.Lab.Visible = false;
            //    uc.Lab2.Visible = false;
            //    uc.Lab8.Visible = false;
            //    uc.Lab9.Visible = false;
            //    uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false;
            //    uc.Lab12.Visible = false;
            //    uc.TxtName.Visible = false;
            //    uc.TxtName2.Visible = false;
            //    uc.TxtName8.Visible = false;
            //    uc.TxtName9.Visible = false;
            //    uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;

            //}

            ///// <summary>
            ///// 六个参数控件显示控制
            ///// </summary>
            //private void UserControlMethodSix()
            //{

            //    uc.Lab3.Visible = true;
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;
            //    uc.Lab7.Visible = true;
            //    uc.Lab8.Visible = true;


            //    uc.TxtName3.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;
            //    uc.TxtName7.Visible = true;
            //    uc.TxtName8.Visible = true;


            //    uc.Lab.Visible = false;
            //    uc.Lab2.Visible = false;
            //    uc.Lab9.Visible = false;
            //    uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false;
            //    uc.Lab12.Visible = false;

            //    uc.TxtName.Visible = false;
            //    uc.TxtName2.Visible = false;
            //    uc.TxtName9.Visible = false;
            //    uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;




            //}

            ///// <summary>
            ///// 八个参数控件显示控制
            ///// </summary>
            //private void UserControlMethodEight()
            //{
            //    uc.Lab3.Visible = true;
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;
            //    uc.Lab7.Visible = true;
            //    uc.Lab8.Visible = true;
            //    uc.Lab9.Visible = true;
            //    uc.Lab10.Visible = true;
              

            //    uc.TxtName3.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;
            //    uc.TxtName7.Visible = true;
            //    uc.TxtName8.Visible = true;
            //    uc.TxtName9.Visible = true;
            //    uc.TxtName10.Visible = true;
               

            //    uc.Lab.Visible = false;
            //    uc.Lab2.Visible = false;
            //    uc.Lab9.Visible = false;
            //    uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false;

            //    uc.Lab12.Visible = false;
            //    uc.TxtName.Visible = false;
            //    uc.TxtName2.Visible = false;
            //    uc.TxtName9.Visible = false;
            //    uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;
            //}
            //private void UserControlMethodNine()
            //{
            //    uc.Lab2.Visible = true;
            //    uc.Lab3.Visible = true;
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;
            //    uc.Lab7.Visible = true;
            //    uc.Lab8.Visible = true;
            //    uc.Lab9.Visible = true;
            //    uc.Lab10.Visible = true;

            //    uc.TxtName2.Visible = true;
            //    uc.TxtName3.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;
            //    uc.TxtName7.Visible = true;
            //    uc.TxtName8.Visible = true;
            //    uc.TxtName9.Visible = true;
            //    uc.TxtName10.Visible = true;
               

            //    uc.Lab.Visible = false;
            //    //uc.Lab9.Visible = false;
            //    //uc.Lab10.Visible = false;
            //    uc.Lab11.Visible = false ;
            //    uc.Lab12.Visible = false;

            //    uc.TxtName.Visible = false;
            //    //uc.TxtName9.Visible = false;
            //    //uc.TxtName10.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;
            //}
            ///// <summary>
            ///// 十个参数控件显示控制
            ///// </summary>
            //private void UserControlMethodTen()
            //{
            //    uc.Lab.Visible = true;
            //    uc.Lab2.Visible = true;
            //    uc.Lab3.Visible = true;
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;
            //    uc.Lab7.Visible = true;
            //    uc.Lab8.Visible = true;
            //    uc.Lab9.Visible = true;
            //    uc.Lab10.Visible = true;

            //    uc.TxtName.Visible = true;
            //    uc.TxtName2.Visible = true;
            //    uc.TxtName3.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;
            //    uc.TxtName7.Visible = true;
            //    uc.TxtName8.Visible = true;
            //    uc.TxtName9.Visible = true;
            //    uc.TxtName10.Visible = true;

            //    uc.Lab11.Visible = false;
            //    uc.Lab12.Visible = false;
            //    uc.TxtName11.Visible = false;
            //    uc.TxtName12.Visible = false;

            //}
            //public void UserControlMethodTwenlve()
            //{
            //    uc.Lab.Visible = true;
            //    uc.Lab2.Visible = true;
            //    uc.Lab3.Visible = true;
            //    uc.Lab4.Visible = true;
            //    uc.Lab5.Visible = true;
            //    uc.Lab6.Visible = true;
            //    uc.Lab7.Visible = true;
            //    uc.Lab8.Visible = true;
            //    uc.Lab9.Visible = true;
            //    uc.Lab10.Visible = true;
            //    uc.Lab11.Visible = true;
            //    uc.Lab12.Visible = true;

            //    uc.TxtName.Visible = true;
            //    uc.TxtName2.Visible = true;
            //    uc.TxtName3.Visible = true;
            //    uc.TxtName4.Visible = true;
            //    uc.TxtName5.Visible = true;
            //    uc.TxtName6.Visible = true;
            //    uc.TxtName7.Visible = true;
            //    uc.TxtName8.Visible = true;
            //    uc.TxtName9.Visible = true;
            //    uc.TxtName10.Visible = true;
            //    uc.TxtName11.Visible = true;
            //    uc.TxtName12.Visible = true;
            //}

            //# endregion

            //# region 面积控件长度控制
            //public void AreaControlShow()
            //{

            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 22;
            //}

            //public void AreaControlShowOne()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 103;
            //    uc.Lab4.Left = uc.TxtName4.Left - 103;
            //    uc.Lab5.Left = uc.TxtName5.Left - 94;
            //    uc.Lab6.Left = uc.TxtName6.Left - 83;
            //}

            //public void AreaControlShowTwo()
            //{

            //    uc.Lab3.Left = uc.TxtName3.Left - 22;
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 24;
            //    uc.Lab6.Left = uc.TxtName6.Left - 22;
            //}

            //public void AreaControlShowThree()
            //{
            //    uc.Lab2.Left = uc.TxtName3.Left - 22;
            //    uc.Lab3.Left = uc.TxtName3.Left - 22;
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 22;
            //    uc.Lab7.Left = uc.TxtName7.Left - 28;
            //    uc.Lab8.Left = uc.TxtName8.Left - 28;
            //    uc.Lab9.Left = uc.TxtName9.Left - 28;
            //    uc.Lab10.Left = uc.TxtName10.Left - 28;
            //    //uc.Lab11.Left = uc.TxtName11.Left - 28;
            //}

            //public void AreaControlShowFive()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 120;
            //    uc.Lab5.Left = uc.TxtName5.Left - 50;
            //    uc.Lab6.Left = uc.TxtName6.Left - 80;

            //}

            //public void AreaControlShowSix()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 120;
            //    uc.Lab4.Left = uc.TxtName4.Left - 50;
            //    uc.Lab5.Left = uc.TxtName5.Left - 55;
            //    uc.Lab6.Left = uc.TxtName6.Left - 93;
            //}
            //public void AreaControlShowSeven()
            //{

            //    uc.Lab4.Left = uc.TxtName4.Left - 129;
            //    uc.Lab5.Left = uc.TxtName5.Left - 50;
            //    uc.Lab6.Left = uc.TxtName6.Left - 51;
            //}
            //public void AreaControlShowEight()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 120;
            //    uc.Lab4.Left = uc.TxtName4.Left - 50;
            //    uc.Lab5.Left = uc.TxtName5.Left - 75;
            //    uc.Lab6.Left = uc.TxtName6.Left - 93;
            //}
            //public void AreaControlShowNine()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 95;
            //    uc.Lab5.Left = uc.TxtName5.Left - 105;
            //    uc.Lab6.Left = uc.TxtName6.Left - 82;
            //}
            //public void AreaControlShowTen()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 102;
            //    uc.Lab4.Left = uc.TxtName4.Left - 119;
            //    uc.Lab5.Left = uc.TxtName5.Left - 94;
            //    uc.Lab6.Left = uc.TxtName6.Left - 84;
            //}
            //public void AreaControlEleven()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 97;
            //    uc.Lab5.Left = uc.TxtName5.Left - 84;
            //}
            //public void AreaControlTwelve()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //}
            //public void AreaControlThirteen()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 22;
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 29;
            //    uc.Lab7.Left = uc.TxtName7.Left - 29;
            //}

            //public void AreaControlFifteen()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 27;
            //    uc.Lab5.Left = uc.TxtName5.Left - 27;
            //    uc.Lab6.Left = uc.TxtName6.Left - 23;
            //}
            //public void AreaControlSixteen()
            //{
            //    //uc.Lab.Left =  uc.TxtName.Left - 22;
            //    //uc.Lab2.Left = uc.TxtName2.Left - 22;
            //    //uc.Lab3.Left = uc.TxtName3.Left - 22;
            //    //uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    //uc.Lab5.Left = uc.TxtName5.Left - 22;

            //    uc.Lab3.Left = uc.TxtName3.Left - 22;
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 22;
            //    uc.Lab7.Left = uc.TxtName7.Left - 22;
            //}
            //public void AreaControlSeventeen()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 21;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //}
            //public void AreaControlEighteen()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 103;
            //    uc.Lab4.Left = uc.TxtName4.Left - 102;
            //    uc.Lab5.Left = uc.TxtName5.Left - 95;
            //    uc.Lab6.Left = uc.TxtName6.Left - 83;
            //}
            //public void AreaControlTwenty_One()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 26;
            //    uc.Lab5.Left = uc.TxtName5.Left - 26;
            //}
            //public void AreaControlTwenty_Two()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 26;
            //    uc.Lab5.Left = uc.TxtName5.Left - 26;
            //}
            //public void AreaControlTwenty_Three()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 24;
            //}

            //public void AreaControlTwenty_Five()
            //{

            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //}
            //# endregion
            //#region 体积控件长度控制
            //public void VolumControlShow()
            //{
            //    uc.Lab.Left = uc.TxtName.Left - 24;
            //    uc.Lab2.Left = uc.TxtName2.Left - 24;
            //    uc.Lab3.Left = uc.TxtName3.Left - 30;
            //    uc.Lab4.Left = uc.TxtName4.Left - 30;
            //    uc.Lab5.Left = uc.TxtName5.Left - 30;
            //    uc.Lab6.Left = uc.TxtName6.Left - 30;
            //    uc.Lab7.Left = uc.TxtName7.Left - 30;
            //    uc.Lab8.Left = uc.TxtName8.Left - 30;
            //    uc.Lab9.Left = uc.TxtName9.Left - 24;
            //    uc.Lab10.Left = uc.TxtName10.Left - 30;
            //    uc.Lab11.Left = uc.TxtName11.Left - 30;
            //    uc.Lab12.Left = uc.TxtName12.Left - 30;
            //}
            //public void VolumControlShowOne()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 22;
            //}

            //public void VolumControlShowTwo()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 104;
            //    uc.Lab4.Left = uc.TxtName4.Left - 103;
            //    uc.Lab5.Left = uc.TxtName5.Left - 95;
            //    uc.Lab6.Left = uc.TxtName6.Left - 88;
            //}
            //public void VolumControlShowThree()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 23;
            //    uc.Lab4.Left = uc.TxtName4.Left - 23;
            //    uc.Lab5.Left = uc.TxtName5.Left - 29;
            //    uc.Lab6.Left = uc.TxtName6.Left - 29;
            //    uc.Lab7.Left = uc.TxtName7.Left - 22;
            //    uc.Lab8.Left = uc.TxtName8.Left - 29;
            //}
            //public void VolumControlShowFour()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 120;
            //    uc.Lab4.Left = uc.TxtName4.Left - 55;
            //    uc.Lab5.Left = uc.TxtName5.Left - 76;
            //    uc.Lab6.Left = uc.TxtName6.Left - 95;
            //}
            //public void VolumControlShowFive()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 120;
            //    uc.Lab4.Left = uc.TxtName4.Left - 51;
            //    uc.Lab5.Left = uc.TxtName5.Left - 52;
            //    uc.Lab6.Left = uc.TxtName6.Left - 106;
            //}
            //public void VolumControlShowSix()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 96;
            //    uc.Lab5.Left = uc.TxtName5.Left - 71;
            //    uc.Lab6.Left = uc.TxtName6.Left - 95;

            //}
            //public void VolumControlShowSeven()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 103;
            //    uc.Lab4.Left = uc.TxtName4.Left - 117;
            //    uc.Lab5.Left = uc.TxtName5.Left - 94;
            //    uc.Lab6.Left = uc.TxtName6.Left - 87;
            //}
            //public void VolumControlShowEight()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 26;
            //    uc.Lab6.Left = uc.TxtName6.Left - 26;
            //}
            //public void VolumControlShowNine()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 29;
            //    uc.Lab5.Left = uc.TxtName5.Left - 29;
            //    uc.Lab6.Left = uc.TxtName6.Left - 24;
            //}
            //public void VolumControlShowTen()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //}
            ////public void VolumControlShowEleven()
            ////{
            ////    //uc.Lab.Left = uc.TxtName.Left - 22;
            ////    //uc.Lab2.Left = uc.TxtName2.Left - 22;
            ////    uc.Lab4.Left = uc.TxtName.Left - 22;
            ////    uc.Lab5.Left = uc.TxtName2.Left - 22;
            ////}
            //public void VolumControlShowTwelve()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 22;
            //    uc.Lab4.Left = uc.TxtName4.Left - 28;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 28;
            //    uc.Lab7.Left = uc.TxtName7.Left - 22;
            //}
            //public void VolumControlShowThirteen()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 22;
            //}
            //public void VolumControlShowFourteen()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //}
            //public void VolumControlShowFifteen()
            //{

            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //}
            //public void VolumControlShowSixteen()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 104;
            //    uc.Lab4.Left = uc.TxtName4.Left - 109;
            //    uc.Lab5.Left = uc.TxtName5.Left - 96;
            //    uc.Lab6.Left = uc.TxtName6.Left - 88;
            //}
            //public void VolumControlShowSeventeen()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 24;
            //    uc.Lab4.Left = uc.TxtName4.Left - 24;
            //    uc.Lab5.Left = uc.TxtName5.Left - 30;
            //    uc.Lab6.Left = uc.TxtName6.Left - 30;
            //    uc.Lab7.Left = uc.TxtName7.Left - 24;
            //}
            //public void VolumControlShowEighteen()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 24;
            //    uc.Lab4.Left = uc.TxtName4.Left - 24;
            //    uc.Lab5.Left = uc.TxtName5.Left - 30;
            //    uc.Lab6.Left = uc.TxtName6.Left - 30;
            //    uc.Lab7.Left = uc.TxtName7.Left - 24;
            //    uc.Lab8.Left = uc.TxtName8.Left - 30;
            //}
            //public void VolumControlShowNineteen()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 28;
            //    uc.Lab5.Left = uc.TxtName5.Left - 28;
            //    uc.Lab6.Left = uc.TxtName6.Left - 24;
            //}
            //public void VolumControlShowTwenty()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 30;
            //    uc.Lab4.Left = uc.TxtName4.Left - 30;
            //    uc.Lab5.Left = uc.TxtName5.Left - 24;
            //    uc.Lab6.Left = uc.TxtName6.Left - 24;
            //}
            //public void VolumControlShowTwenty_One()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 32;
            //    uc.Lab6.Left = uc.TxtName6.Left - 32;
            //}
            //public void VolumControlShowTwenty_Two()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 24;
            //}
            //public void VolumControlShowTwenty_Three()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 28;
            //    uc.Lab5.Left = uc.TxtName5.Left - 28;
            //    uc.Lab6.Left = uc.TxtName6.Left - 24;
            //}
            //public void VolumControlShowTwenty_Four()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 28;
            //    uc.Lab5.Left = uc.TxtName5.Left - 28;
            //    uc.Lab6.Left = uc.TxtName6.Left - 24;
            //}
            //public void VolumControlShowTwenty_Five()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 24;
            //}


            //#endregion
            //#region 周长控件长度控制
            //public void CircumferenceControlShow()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 22;
            //    uc.Lab6.Left = uc.TxtName6.Left - 22;

            //}
            //public void CircumferenceControlShowOne()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //    uc.Lab5.Left = uc.TxtName5.Left - 24;
            //}
            //public void CircumferenceControlShowTwo()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 28;
            //    uc.Lab5.Left = uc.TxtName5.Left - 28;
            //}
            //public void CircumferenceControlShowThree()
            //{
            //    uc.Lab4.Left = uc.TxtName4.Left - 22;
            //}
            //#endregion
            //#region 送电线路控件长度控制
            //public void CircuitControlShow()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 86;
            //    uc.Lab4.Left = uc.TxtName4.Left - 110;
            //    uc.Lab5.Left = uc.TxtName5.Left - 158;
            //    uc.Lab6.Left = uc.TxtName6.Left - 110;
            //    uc.Lab7.Left = uc.TxtName7.Left - 98;
            //    uc.Lab8.Left = uc.TxtName8.Left - 76;
            //}
            //public void CircuitControlShowOne()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 86;
            //    uc.Lab4.Left = uc.TxtName4.Left - 110;
            //    uc.Lab5.Left = uc.TxtName5.Left - 110;
            //    uc.Lab6.Left = uc.TxtName6.Left - 98;
            //    uc.Lab7.Left = uc.TxtName7.Left - 76;
            //    uc.Lab8.Left = uc.TxtName8.Left - 120;
            //}
            //public void CircuitControlShowTwo()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 86;
            //    uc.Lab4.Left = uc.TxtName4.Left - 110;
            //    uc.Lab5.Left = uc.TxtName5.Left - 110;
            //    uc.Lab6.Left = uc.TxtName6.Left - 96;
            //}
            //public void CircuitControlShowThree()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 86;
            //    uc.Lab4.Left = uc.TxtName4.Left - 110;
            //    uc.Lab5.Left = uc.TxtName5.Left - 158;
            //    uc.Lab6.Left = uc.TxtName6.Left - 110;
            //}
            //public void CircuitControlShowFour()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 86;
            //    uc.Lab4.Left = uc.TxtName4.Left - 110;
            //    uc.Lab5.Left = uc.TxtName5.Left - 110;
            //    uc.Lab6.Left = uc.TxtName6.Left - 98;
            //    uc.Lab7.Left = uc.TxtName7.Left - 122;
            //}
            //public void CircuitControlShowFive()
            //{
            //    uc.Lab3.Left = uc.TxtName3.Left - 86;
            //    uc.Lab4.Left = uc.TxtName4.Left - 98;
            //    uc.Lab5.Left = uc.TxtName5.Left - 98;
            //    uc.Lab6.Left = uc.TxtName6.Left - 110;
            //    uc.Lab7.Left = uc.TxtName7.Left - 86;
            //}
            //#endregion

            ///// <summary>
            ///// 控件清空
            ///// </summary>
            //public void UserControlClear()
            //{
            //    uc.TxtName.Text = "0.00";
            //    uc.TxtName2.Text = "0.00";
            //    uc.TxtName3.Text = "0.00";
            //    uc.TxtName4.Text = "0.00";
            //    uc.TxtName5.Text = "0.00";
            //    uc.TxtName6.Text = "0.00";
            //    uc.TxtName7.Text = "0.00";
            //    uc.TxtName8.Text = "0.00";
            //    uc.TxtName9.Text = "0.00";
            //    uc.TxtName10.Text = "0.00";
            //    uc.TxtName11.Text = "0.00";
            //    uc.TxtName12.Text = "0.00";
            //   _result = 0.00;
            //}
            
            ///// <summary>
            ///// 结果变量
            ///// </summary>
            //private double _result = 0.00;
            //public double Result
            //{
            //    get { return _result; }
            //    set { _result = value; }
            //}
       }
  }

