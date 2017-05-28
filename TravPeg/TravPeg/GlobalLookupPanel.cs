using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravPeg
{

    
    public static class GlobalLookup
    {

        //Form MainFrm;

        public static List<string> lsLkpTypeVal;
        public static List<int> lsLkpTypeID;
        public static List<String> lsLkpDataType;
        public static DataTable curLkpTbl;
        public static String curLkpFile;
        public static int curLkpCCID;
        public static int JobInfoID;
        public static int currCalcID;
        public static String currJobDescr;

        //Constants as to which tables to update the JobInfoID - [usp_Update_Calc_JobInfo]
        public static int JobInfo_Update_Peg = 1; //Peg Only
        public static int JobInfo_Update_Base = 2; //Base Only
        
        internal static void showlookups(bool showlkp=false)
        {
           // frmMain.ShowLookups(showlkp);
        }
    }
}
