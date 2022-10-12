using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberConvert.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {

            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(double number)
        {
            string result = "";
            ///example. (987,654,321.01)
            int decimalPart = Convert.ToInt32((number % 1) * 100);
            int integerPart = Convert.ToInt32(number - number % 1);

            ///special case: 1 dollar with no "s"
            if (integerPart == 1)
                result = GetBasic(integerPart) + " dollar";

            else if (integerPart == 0)
                result = "zero dollars";
            else
            {
                ///millions, 6-9 digit (987,000,000)
                if (integerPart >= 1000000 & integerPart < 1000000000)
                {
                    result = GetHundreds(integerPart / 1000000) + " million";
                    integerPart = integerPart - (integerPart / 1000000) * 1000000;

                }
                ///thousands, 3-6 digit  (654,000)
                if (integerPart >= 1000 && integerPart < 1000000)
                {
                    result += (result == "" ? "" : " ") + GetHundreds(integerPart / 1000) + " thousand";
                    integerPart = integerPart - (integerPart / 1000) * 1000;
                }
                ///hundreds, 1-3 digit (321)
                if (integerPart > 1)
                {
                    result += (result == "" ? "" : " ")  + GetHundreds(integerPart) + " dollars";
                }
                else
                {
                    result += " dollars";
                }
            }
            ///CENTS , decimal (0.01)
            if (decimalPart > 0)
            {
                if(decimalPart==1)
                    result += " and " + GetHundreds(decimalPart) + " cent";
                else
                    result += " and " + GetHundreds(decimalPart) + " cents";
            }
            ViewBag.result = result;
            return View();
        }
        public string GetHundreds(int n)
        {
            string rtn = "";
            bool dash = false;

            if (n >= 100)
            {
                rtn = GetBasic(n / 100) + " hundred";
                n = n - (n / 100) * 100;

            }
            switch (n / 10)
            {
                case 0:
                    {
                        ///1~9
                    }
                    break;
                case 1:
                    {
                        //10~19
                        switch (n - 10)
                        {
                            case 0:
                                n -= 10;
                                rtn += (rtn == "" ? "" : " ") + "ten";
                                break;
                            case 1:
                                n -= 11;
                                rtn += (rtn == "" ? "" : " ") + "eleven";
                                break;
                            case 2:
                                n -= 12;
                                rtn += (rtn == "" ? "" : " ") + "twelve";
                                break;
                            case 3:
                                n -= 13;
                                rtn += (rtn == "" ? "" : " ") + "thirteen";
                                break;
                            case 4:
                                n -= 14;
                                rtn += (rtn == "" ? "" : " ") + "fourteen";
                                break;
                            case 5:
                                n -= 15;
                                rtn += (rtn == "" ? "" : " ") + "fifteen";
                                break;
                            case 6:
                                n -= 16;
                                rtn += (rtn == "" ? "" : " ") + "sixteen";
                                break;
                            case 7:
                                n -= 17;
                                rtn += (rtn == "" ? "" : " ") + "seventeen";
                                break;
                            case 8:
                                n -= 18;
                                rtn += (rtn == "" ? "" : " ") + "eighteen";
                                break;
                            case 9:
                                n -= 19;
                                rtn += (rtn == "" ? "" : " ") + "nineteen";
                                break;

                        }
                    }
                    break;
                ///20.30.40.50.60.70.80.90
                case 2:
                    n = n - 20;
                    rtn += (rtn == "" ? "" : " ") + "twenty";
                    dash = true;
                    break;
                case 3:
                    n = n - 30;
                    rtn += (rtn == "" ? "" : " ") + "thirty";
                    dash = true;
                    break;
                case 4:
                    n = n - 40;
                    rtn += (rtn == "" ? "" : " ") + "forty";
                    dash = true;
                    break;
                case 5:
                    n = n - 50;
                    rtn += (rtn == "" ? "" : " ") + "fifty";
                    dash = true;
                    break;
                case 6:
                    n = n - 60;
                    rtn += (rtn == "" ? "" : " ") + "sixty";
                    dash = true;
                    break;
                case 7:
                    n = n - 70;
                    rtn += (rtn == "" ? "" : " ") + "seventy";
                    dash = true;
                    break;
                case 8:
                    n = n - 80;
                    rtn += (rtn == "" ? "" : " ") + "eighty";
                    dash = true;
                    break;
                case 9:
                    n = n - 90;
                    rtn += (rtn == "" ? "" : " ") + "ninety";
                    dash = true;
                    break;


            }
            
            /// Basic
            if (n > 0)
            {
                rtn += (rtn == "" ? "" : (dash ? "-" : " ")) + GetBasic(n);
            }
            return rtn;
            
        }
        public string GetBasic(int n)
        {
            string rtn = "";
            switch (n)
            {
                case 1:
                    rtn = "one";
                    break;
                case 2:
                    rtn = "two";
                    break;
                case 3:
                    rtn = "three";
                    break;
                case 4:
                    rtn = "four";
                    break;
                case 5:
                    rtn = "five";
                    break;
                case 6:
                    rtn = "six";
                    break;
                case 7:
                    rtn = "seven";
                    break;
                case 8:
                    rtn = "eight";
                    break;
                case 9:
                    rtn = "nine";
                    break;
                case 0:
                    rtn = "zero";
                    break;
            }
            return rtn;
        }
    }
}