using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravPeg
{
    /// <summary>
    /// Contains global variables for project.
    /// </summary>
    public static class GlobalLogon
    {

        /// <summary>
        /// Static value protected by access routine.
        /// </summary>
        static int _AUID = 0;
        static string _FName = "";
        static string _SName = "";
        static string _Email = "";
        static int _ULevel = 0;
        /// <summary>
        /// Access routine for global variable.
        /// </summary>
        public static int AUID { get { return _AUID;} set {_AUID = value;} }
        public static string FName { get { return _FName; } set { _FName = value; } }
        public static string SName { get { return _SName; } set { _SName = value; } }
        public static string Email { get { return _Email; } set { _Email = value; } }
        public static int ULevel { get { return _ULevel; } set { _ULevel = value; } }

        public static void Clear()
        {
            _AUID = 0;
            _FName = "";
            _SName = "";
            _Email = "";
            _ULevel = 0;
        }

        //User Level Rights 
        public static int StartFromJoinBase = 10; 
        public static int OverWriteExistingPeg = 10;
        public static int OverWriteExistingBase = 10;
        public static int StartFromErrPeg = 10;
        public static int StartFromErrBase = 10;

        public static int SuperUserLevel = 1000;


    }
}
