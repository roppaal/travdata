using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravPeg
{
    public static class DataClass
    {

        public class PYXZ
        {
            
            public double X = 0;
            public double Y = 0;
            public double Z = 0;
            public double G = 0;
            public int LP = 0;
            
            public void Clear()
            {
               
                X = 0;
                Y = 0;
                Z = 0;
                G = 0;
                LP = 0;
            }
        }
        public class PegYXZ
        {

            public PYXZ coord = new PYXZ();

            public int pcid = -1;
            public int PegID = -1;
            public string Peg = "";
            public int CCID = 0;
            public int CID = 0;
            public int EID = 0;
            public int AUID = 0;
            public int PLogID = 0;
            public double HDErr = 0;
            public double EDErr = 0;
            public double HAErr = 0;
            public int LP = 0;
            public int CCnt = 0;
            public int MTID = 0;
            public int MineID = 0;
            public int TravID = 0;
            public string Mine = "";
            public string Trav = "";
            public string C = ""; //Classs
            public string E=""; //Error Status


            public void Clear()
            {
                coord.Clear();

                pcid = -1;
                PegID = -1;
                Peg = "";
                CCID = 0;
                CID = 0;
                EID = 0;
                AUID = 0;
                PLogID = 0;
                HDErr = 0;
                EDErr = 0;
                HAErr = 0;
                LP = 0;
                CCnt = 0;
                MTID = 0;
                MineID = 0;
                TravID = 0;
                Mine = "";
                Trav = "";
                C = "";
                E = "";

            }
        }

        public class Base3 // 3 point base
        {
            public Polar sbs = new Polar(); // st --> bs
            public Polar sfs = new Polar(); // st --> fs

            public int BFWID = -1;
            public int BCID = -1;
            public int CCID = 0;
            public int BSID = 0;//pcid
            public int STID = 0;//pcid
            public int FSID = 0;//pcid
            public int BSPegID = 0;//PegID
            public int STPegID = 0;//PegID
            public int FSPegID = 0;//PegID
            public string BS = "";
            public string ST = "";
            public string FS = "";
            public double HAFL = 0;
            public double HAFR = 0;
            public double HAFLErr = 0;
            public double HAFRErr = 0;
            public int CID = 0;
            public int EID = 0;
            public int AUID = 0;
            public int BLogID = 0;
            public int LP = 0;
            public int CCnt = 0;
            public int Grade = 0;
            public int GradeTypeID = 0;
            public int BSCnt = 0;
            public int ArcCnt = 0;
            public int FSCnt = 0;
            public int BaseID = 0;
            public int MTID = 0;
            public string Mine = "";
            public string Trav = "";
            public string C = ""; //Classs
            public string E = ""; //Error Status

            public void clear()
            {
                sbs.clear();
                sfs.clear();

                BFWID = -1;
                BCID = -1;
                CCID = 0;
                BSID = 0; BSPegID = 0; BS = "";
                STID = 0; STPegID = 0; ST = "";
                FSID = 0; FSPegID = 0; FS = "";
                HAFL = 0;
                HAFR = 0;
                HAFLErr = 0;
                HAFRErr = 0;
                CID = 0;
                EID = 0;
                AUID = 0;
                BLogID = 0;
                LP = 0;
                CCnt = 0;
                Grade = 0;
                GradeTypeID = 0;
                BSCnt = 0;
                ArcCnt = 0;
                FSCnt = 0;
                BaseID = 0;
                MTID = 0;
                Mine = "";
                Trav = "";
                C = "";
                E = "";
            }

            public void AddBase2(Base2 b2)
            {
                //BCID = b2.BCID;
                //CCID = b2.CCID;
                BSID = b2.STID;
                STID = b2.FSID;

                BSPegID = b2.STPegID;
                STPegID = b2.FSPegID;


                BS = b2.ST;
                ST = b2.FS;
                sbs = b2.polar;
               
                HAFLErr = b2.polar.BearErr;
                HAFRErr = b2.polar.BearErr;
                //CID = b2.CID;
                //EID = b2.EID;
                AUID = GlobalLogon.AUID;
                //BLogID = b2.BLogID;
                LP = b2.LP;
                //CCnt = b2.CCnt;
                Grade = b2.Grade;
                GradeTypeID = b2.GradeTypeID;
                BSCnt = 1;
                //ArcCnt = b2.ArcCnt;
                //FSCnt = b2.FSCnt;
                //BaseID = b2.BaseID;
                MTID = b2.MTID;
                Mine = b2.Mine;
                Trav = b2.Trav;
                //C = b2.C;
                //E = b2.E;
            }
        }


        public class Base2 // 2 point base
        {
            public Polar polar = new Polar(); // st --> fs
             
            public int binID = -1;
            public int BFWID = -1;
            public int BCID = -1;
            public int CCID = 0;
            public int STID = 0;//pcid
            public int FSID = 0;//pcid
            public int STPegID = 0;//PegID
            public int FSPegID = 0;//PegID
            public string ST = "";
            public string FS = "";
            public bool Reversed = false; //reverse base 
            public int CID = 0;
            public int CCnt = 0;
            public int EID = 0;
            public int AUID = 0;
            public int BLogID = 0;
            public int LP = 0;
            public int Grade = 0;
            public int GradeTypeID = 0;
            public int ArcCnt = 0;
            public int FSCnt = 0;
            public int BaseID = 0;
            public int MTID = 0;
            public int MineID = 0;
            public int TravID = 0;
            public string Mine = "";
            public string Trav = "";
            public string C = ""; //Classs
            public string E = ""; //Error Status

            public void clear()
            {
                polar.clear();

                binID = -1;
                BFWID = -1;
                BCID = -1;
                CCID = 0;
                STID = 0; STPegID = 0; ST = "";
                FSID = 0; FSPegID = 0; FS = "";
                Reversed = false;
                CID = 0;
                EID = 0;
                CCnt = 0;
                AUID = 0;
                BLogID = 0;
                LP = 0;
                Grade = 0;
                GradeTypeID = 0;
                ArcCnt = 0;
                FSCnt = 0;
                BaseID = 0;
                MTID = 0;
                MineID = 0;
                TravID = 0;
                Mine = "";
                Trav = "";
                C = "";
                E = "";
            }

            internal void CheckPegOrder(string tmpST, string tmpFS)
            {
                if ((tmpST==FS)&&(tmpFS == ST))
                {
                    int tmpSTID = STID;
                    int tmpSTPegID = STPegID;
                    STID = FSID;
                    STPegID = FSPegID;
                    FSID = tmpSTID;
                    FSPegID = tmpSTPegID;
                    ST = tmpFS;
                    FS = tmpST;
                    Reversed = true;
                    polar.reverse();
                }
            }
        }

        public class Polar
        {
            public double Bear = 0;
            public double BearJoin = 0;
            public double BearManual = -1;
            public double BearErr = 0;
            public double SD = 0;
            public double Dip = 0;
            public double HD = 0;
            public double ED = 0;
            public double HDErr = 0;
            public double EDErr = 0;
            public bool Reversed = false; //reverse base 
            public double Bear180()
            {
                return CalcClass.Ang360(Bear-180);
            }
                
            public void clear()
            {
                Bear = 0;
                BearJoin = 0;
                BearManual = -1; //real bearing if Manually entered
                BearErr = 0;
                SD = 0;
                Dip = 0;
                HD = 0;
                ED = 0;
                HDErr = 0;
                EDErr = 0;
                Reversed = false; //reverse base 
        }

            public void reverse()
            {
                Bear = CalcClass.Ang360(Bear-180);
                BearErr = (-1) * BearErr;
                ED = (-1) *ED;
                EDErr = (-1)*EDErr;
                Reversed = true; //reverse base 
            }
        }




    }
}
