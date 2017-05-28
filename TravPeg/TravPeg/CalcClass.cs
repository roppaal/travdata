using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravPeg
{
    public static class CalcClass
    {
        public static double Deg2Rad =  Math.PI / 180;
        public static double Rad2Deg =  180 /  Math.PI;

        public static double ConvertDecToDMS(double a)
        {

            return 1;
        }

        public static double CalcHAFL(double HAFL1, double HAFL2)
        {
            return Ang360((HAFL2 - HAFL1));
        }

        public static double CalcHAFR(double HAFR2, double HAFR1)
        {
            return Ang360((HAFR1 - HAFR2));
        }

        public static double CalcBear(double y1, double y2, double x1, double x2, string angleType)
        {
            double tBear =0;
           
            double y = y2 - y1;
            double x = x2 - x1;

            if ((x == 0) && (y > 0)) {
                tBear = Math.PI / 2;
            } else
            if ((x == 0) && (y < 0)) {
                tBear = Math.PI + Math.PI / 2;
            } else
            if ((x >= 0) && (y == 0))
            { tBear = 0;
            } else
            if ((x < 0) && (y == 0))
            { tBear = Math.PI;
            } else
            {
                tBear = Math.Atan(y / x);
                if ((y < 0) && (x > 0))
                { tBear = tBear + Math.PI * 2;
                } else
                if ((y >= 0) && (x < 0))
                { tBear = tBear + Math.PI;
                } else
                if ((y < 0) && (x < 0))
                { tBear = tBear + Math.PI;
                }
            }

            if (angleType.ToLower()=="rad")
            { return  tBear;
            }
            else
            { return  (tBear * Rad2Deg);
            }
           
        }

        public static double CalcJoinBear(DataClass.PYXZ st, DataClass.PYXZ fs, DataClass.Polar b, string angleType)
        {
            double y = 0; double x = 0; double z = 0; double tBear = 0; double tDip = 0;

            y = fs.Y - st.Y;
            x = fs.X - st.X;
            z = fs.Z - st.Z;

            b.ED = z;
            b.HD = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            b.SD = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            if ((b.HD == 0) && (z == 0)) {
                tDip = 0;
            } else
            if ((b.HD == 0) && (z > 0))
            { tDip = 90;
            } else
            if ((b.HD == 0) && (z < 0))
            { tDip = 270;
            } else
            { tDip = Math.Atan(z / b.HD);
            }
            tBear = CalcBear(0, y, 0, x, "Rad");
            // { Rad otherwise we will have double conversion for Dec}
            if (angleType.ToLower() == "rad")
            {
                b.Dip = tDip;
                b.BearJoin = tBear;
            }
            else { 
            
              b.Dip = tDip * Rad2Deg;
              b.BearJoin= (tBear * Rad2Deg);
            }
            return b.BearJoin;
        }
        public static bool CalcJoinBase_NotDone(DataClass.PegYXZ bs, DataClass.PegYXZ st, DataClass.PegYXZ fs, DataClass.Base3 b)
        {

            // b.BCID = 0;
            b.CCID = 0; // join
            b.BSID = bs.pcid;
            b.STID = st.pcid;
            b.FSID = fs.pcid;
            b.BS = bs.Peg;
            b.ST = st.Peg;
            b.FS = fs.Peg;


            if (b.BSID > -1){  // 3 Point Base

            }else // 2 Point Base
            {
                b.HAFL = 0;
            }

            b.sfs.Bear = 0;
            b.sfs.HD = 0;
            b.sfs.ED = 0;

            b.CID = 0;
            b.EID = 0;
            b.AUID = GlobalLogon.AUID;
            b.BLogID = 0;
            b.LP = fs.LP;
            b.CCnt = 1;
            b.Grade = 0;
            b.GradeTypeID = 0;

            b.sbs.EDErr = 0;
            b.sbs.HDErr = 0;
            b.HAFLErr = 0;
            b.HAFRErr = 0;
            b.sfs.HDErr = 0;
            b.sfs.EDErr = 0;

            b.BSCnt = 0;
            b.ArcCnt = 0;
            b.FSCnt = 0;
            b.BaseID = 0;
            b.MTID = fs.MTID;

            return false;
        }


        public static double CalcAngErr(double ang1, double ang2)
        {
            return Ang180(ang1 - ang2);
        }

        internal static double Ang360(double v)
        {
            while (v < 0) { v += 360; }
            while (v > 360) { v -= 360; }
            return v;
        }

        internal static double Ang180(double v)
        {
            while (v < -180) { v += 180; }
            while (v > +180) { v -= 180; }
            return v;
        }


        
        internal static double Calc_Dip_From_VAFL(double VAFL, double VAFR,out double Adj)
        {   // vafl 87 vafr 272  then (360 - (87 + 272))/ = +0.5 then vafl = 87 + 0.5 = 87.5  --> Dip = 90 - 87.5 = 2.5
            // vafl 272 vafr 87  then (360 - (272 + 87))/ = +0.5 then vafl = 272 + 0.5 = 272.5 --> Dip = 272.5 - 270 = 2.5
            Adj = (360 - (VAFL + VAFR)) / 2; //make correction , if sum id greater than 360, subtract half of error
            double dip = VAFL + Adj; 
            if (dip <= 180)
                { dip = 90 - dip; } // 
            else
                { dip = 270 - dip; }
            return dip;
        }

        internal static double CalcHDED(double Dip, double MD, out double HD , out double ED)
        {
            HD = MD * Math.Cos(Dip * Deg2Rad);
            ED = MD * Math.Sin(Dip * Deg2Rad);
            return HD;
        }



        internal static double calc_ListAveAndErr_Dbl(List<Double> ls, out Double v, out Double err) //Double in out
        {
            v = 0;
            err = 0;
            if (ls.Count > 0)
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    v += ls[i];
                }
                v = v / ls.Count(); //v is now the ave
                for (int i = 0; i < ls.Count; i++)
                {
                    if (err < Math.Abs(v - ls[i])) { err = (v - ls[i]); }
                }
            }
            return v;
        }
        internal static double CalcGrade(int GradeTypeID,double Grade, double HD)
        {
            /*
                GradeTypeID Descr
                0   No Grade
                1   Level Grade
                2   Ratio(1:200)
                3   Percentage(0.1 %)
                4   Angle(1" 02' 03')
            */

            double g = 0;
            if ((Grade==0)||(HD==0))
            {
                g = 0;
            }
            else
            if (GradeTypeID == 0) // 0   No Grade
            {
                g = 0;
            }
            else if (GradeTypeID == 1) //1   Level Grade
            {
                g = 0;
            }
            else if (GradeTypeID == 2) //2   Ratio(1:200)
            {
                g = HD / Grade;   //-- example HD 50m Grade 200m  --> 50m/200m = 0.250m  
            }
            else if (GradeTypeID == 3) //3   Percentage(0.1 %)
            {
                g = HD * Grade/100;   //-- example HD 50m Grade 0.1%m  --> 50m * 0.1/100m = 0.050m  
            }
            else if (GradeTypeID == 3) //3   Percentage(0.1 %)
            {
                g = HD * Math.Tan(Grade*Deg2Rad);   //-- example HD 50m Grade 0.1%m  --> 50m * 0.1/100m = 0.050m  
            }

            return g;
        }

        internal static void Calc_dYXZ(double Bear, double HD, double ED, out double dY, out double dX, out double dZ)
        {
            dZ = ED;
            dY = HD * Math.Sin(Bear * Deg2Rad);
            dX = HD * Math.Cos(Bear * Deg2Rad);
            
        }

        internal static void Calc_dYXZ(double Bear, double HD, double ED,double SD, out double dY, out double dX, out double dZ)
        {
            //use HD and ED to calc vert Dip
            //Use Dip to calc new HD and ED  
            double ang = Math.Atan(ED/HD);
            ED = SD * Math.Sin(ang);
            HD = SD * Math.Cos(ang);

            dZ = ED;
            dY = HD * Math.Sin(Bear * Deg2Rad);
            dX = HD * Math.Cos(Bear * Deg2Rad);

        }
    }
}
