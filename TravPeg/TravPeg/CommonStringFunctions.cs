using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravPeg
{


    public static class CommonStr
    {
        public static string DecimalFormat = "{0:F3}";//123.461
        public static string AngleFormat   = "{0:F4}";//123.4612

        public static int s2i(string s) // "1"
        {
            if (s.Trim() == "")
            {
                return 0;
            }
            else
            try
            {
                return Convert.ToInt16(s);    //1               
            }
            catch
            {
                return 0;
            }
        }
        public static string i2s(int d) //1
        {
            return d.ToString();       //"1"
        }

        public static string d2s(double d)
        {
            return String.Format( DecimalFormat , d);     //123.461
        }

        public static string a2s(double d) //remember angle needs to be converted from decimal to dms
        {
            return String.Format(DecimalFormat, d);     //123.4612
        }

        public static double s2d(string Value)
        {
            if (Value == null) {
                return 0;
            }
            else{
                double OutVal; // = Convert.ToDouble(Value);
                
                double.TryParse(Value, out OutVal);
                if (double.IsNaN(OutVal) || double.IsInfinity(OutVal)){
                    return 0;
                }
                
                return OutVal;
            }
        }

        public static double ConvertDMSToDec(string dmsStr)
        {// dmsStr = "37.4217"  -->> 37.74722
            if (dmsStr.Trim() == "") {
                dmsStr = "0.0";
            }
            double dms = s2d(dmsStr); //  "37.4217" ==> 37.4217
            return ConvertDMSToDec(dms);
        }

        public static double ConvertDMSToDec(double dms)
        {// dms = 37° 42' 17" -->> 37.74722
            double a = Math.Floor(dms);   //                                = 37 a
            double m = dms - a;             // 37.4217 - 37.0000 = 0.4217
            m = Math.Floor(m * 100);      // Ceilimng(0.4217 * 100)         = 42 m
            double s = (dms - a) * 100 - m; // (0.4217)*100 - 42 = 42.17 - 42 = 0.17; s

            s = 100 * s / 60;                    // 100 * 0.17 / 60 = 0.28333
            m = m + s;                           // 42 + 0.28333    = 42.28333
            m = m / 60;                          // 42.28333 / 60   = 0.74722
            a = a + m;                           // 37 + 0.74722    = 37.74722  

            return a;
        }

        public static string ConvertDecToDMS(double dec)
        {   //dec = 37.74722  -->> 37.4217

            double a = Math.Floor(dec);      //      = 37 a
            double m = dec - a;              // 37.74722 - 37.0000 = 0.74722
            m = Math.Floor(m * 60);          // Ceiling(0.74722 * 60)  = ceiling (42.28333) = 42 m
            double s = ((dec - a) * 60) - m; // ((37.74722 - 37.0000)*60) - 42 = 42.28333 - 42 = 0.28333

            s = s * 60;                      // 0.28333 * 60    = 16.99998
            m = m + (s/100);                 // 42 + 16.99/100  = 42.16999
            m = m / 100;                     // 42.16999 / 100   = 0.4216999
            a = a + m;                       // 37 + 0.4216999    = 37.4216999  

            return a2s(a);

        }
        public static string ConvertDecToDMS(string dec)
        {   //dec = 37.74722  -->> 37.4217
            
            return ConvertDecToDMS(s2d(dec));

        }
        public static string LP_Text(int LP)
        {
            if (LP > 0) { return "yes"; } else { return "no"; }
        }

        internal static string ErrPass(double ErrorLimit, double CalcError, ref int FailCnt,out System.Drawing.Color c)
        {
            if (Math.Abs(ErrorLimit) >= Math.Abs(CalcError))
            {   
                c = System.Drawing.Color.Green;
                return "Pass";
            }
            else
            {
                FailCnt = FailCnt+1;
                c = System.Drawing.Color.Red;
                return "Fail";
            }
        }

        internal static string CntPass(int CntLimit, int MeasurementCnt, ref int FailCnt, out System.Drawing.Color c)
        {
            if (CntLimit <= MeasurementCnt)
            {
                c = System.Drawing.Color.Green;
                return "Pass";
            }
            else
            {
                FailCnt = FailCnt + 1;
                c = System.Drawing.Color.Red;
                return "Fail";
            }
        }
    }
}
