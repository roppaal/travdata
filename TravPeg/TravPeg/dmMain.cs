using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.IO;

namespace TravPeg
{
    class dmMain
    {

        /*
        public class LogonAU{
             int AUID = 0;
             string FName = "";
             string SName = "";
             string Email = "";
             int ULevel = 0;
          
         }

        //**/

        internal static string conStr()
        {
            return global::TravPeg.Properties.Settings.Default.travdataConnStr;
        }

        internal static int execNonQry(string qry)
        {
            
            
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr()))
                {
                    SqlCommand command = new SqlCommand(qry, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }

        internal static DataTable LoadMainTable(string tn)  //load table from main database
        {
            return LoadMainTable(tn, "");
        }
        internal static DataTable LoadMainTable(string tn, string q) ////load table from main database with query
        {
            if (q != "")
            {
                q += " where ";
            }
            string query = "SELECT * FROM dbo.[" + tn +"] "+ q;

            SqlConnection sqlConn = new SqlConnection(conStr());
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlConn.Close();
            return dt;
        }

        internal static int Add_cc_lkpType(int ccid, int lkpTypeID, int iATag)
        {
            int ID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_Add_cc_lkpType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@iCCID", ccid);
                        cmd.Parameters.AddWithValue("@ilkpTypeID", lkpTypeID);
                        cmd.Parameters.AddWithValue("@iATag", iATag);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            ID = Convert.ToInt32(dr["ccLkpTypeID"].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could NOT Add Calculation Method Lookup ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return ID;
        }

        internal static int AddLkpType(int ID, string Descr, int ATag)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_Add_LkpType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@iID", ID);
                        cmd.Parameters.AddWithValue("@iDescr", Descr);
                        cmd.Parameters.AddWithValue("@iATag", ATag);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            ID = Convert.ToInt32(dr["LkpTypeID"].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could NOT Add Lookup Type ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return ID;
        }

        internal static int AddLkp(int LID, int ID, string Descr, int ATag)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_Add_Lkp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@iLID", LID);
                        cmd.Parameters.AddWithValue("@iID", ID);
                        cmd.Parameters.AddWithValue("@iDescr", Descr);
                        cmd.Parameters.AddWithValue("@iATag", ATag);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            ID = Convert.ToInt32(dr["LkpID"].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could Add Lookup Value ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return ID;
        }
        //-------------------------Load Lookup Types-------------------------------------
        
        internal static bool Load_LookUpTypes(List<int> lsLkpTypeID, List<String> lsLkpTypeVal, List<String> lsLkpDataType)
        {
            lsLkpTypeID.Clear();
            lsLkpTypeVal.Clear();
            lsLkpDataType.Clear();
            

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(conStr()))
                {

                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT  lkpTypeID,Descr,ATag,DataType FROM LkpType WHERE  ATag=1", conn))
                        {
                            //rows number of record got inserted
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                lsLkpTypeID.Add(Convert.ToInt32(dr["lkpTypeID"].ToString()));
                                lsLkpTypeVal.Add(dr["Descr"].ToString());
                                lsLkpDataType.Add(dr["DataType"].ToString());

                            }
                            dr.Close();
                            ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                        }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not fill lookup Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }/**/
            return true;
        }

        //----------------Lookup Bin Path   -----------------------

        internal static String LookupDir()
        {
            //For the full path (filename included): string exePath = Application.ExecutablePath;
            //For the path only: string appPath = Application.StartupPath;
            //CreateDirectory(Application.StartupPath + "\\Temp");
            string path = Application.StartupPath + "\\Temp";
            DirectoryInfo di;
            if (!Directory.Exists(path))
            {   // Try to create the directory.
                di = Directory.CreateDirectory(path);
            }
            return Application.StartupPath + "\\Temp\\";
        }

        //----------------Lookup Bin Table  -----------------------

        internal static DataTable CreateBinLkpTable(int ccid)
        {
            String tn = "Lkp";
            DataTable dt = new DataTable();
            try { 
                    dt.TableName = "bin" + tn;

                    
                    dt.Columns.Add("CCID"); dt.Columns["CCID"].DataType = System.Type.GetType("System.Int32");
                    dt.Columns.Add("LkpTypeID"); dt.Columns["LkpTypeID"].DataType = System.Type.GetType("System.Int32");
                    dt.Columns.Add("Lookup"); dt.Columns["Lookup"].DataType = System.Type.GetType("System.String");
                    dt.Columns.Add("LkpID"); dt.Columns["LkpID"].DataType = System.Type.GetType("System.Int32");
                    dt.Columns.Add("LkpVal"); dt.Columns["LkpVal"].DataType = System.Type.GetType("System.String");
                    dt.Columns.Add("DataType"); dt.Columns["DataType"].DataType = System.Type.GetType("System.String");

                    string fn = LookupDir() + ccid.ToString() + dt.TableName + ".xml";

                    if ((!File.Exists(fn))&&(dt.Rows.Count<1))
                    {
                        Initiate_LkpTable(ccid,dt);    
                        SaveBinTable(ccid,dt);
                    }
                    return dt;                        
             }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not Open Table :" + tn, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }/**/
        }

        internal static void Initiate_LkpTable(int ccid, DataTable dt)
        {

            DataColumnCollection columns = dt.Columns;
            if (columns.Contains("JobInfoDataID"))
            {
                return; //dont try and add new rows to existing JobInfo Id. Need new plan
                //This table pc says there is a JobInfoID but it is not connected to any stored JobInfoData 
                //The table row count is then zero and enters this "Initiate_LkpTable" function 
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("select lkpTypeID, Lookup, DataType from v_cc_lkp_Type where ccid=@ccid", conn))
                    {
                        cmd.Parameters.AddWithValue("@ccid", ccid);
                        
                        //rows number of record got inserted
                        SqlDataReader dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            DataRow r = dt.NewRow();
                        
                            r["CCID"] = ccid;
                            r["LkpTypeID"] = dr["LkpTypeID"];
                            r["Lookup"] = dr["Lookup"];
                            r["DataType"] = dr["DataType"];
                            dt.Rows.Add(r);
                        }
                          dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not Initiate_LkpTable !", MessageBoxButtons.OK, MessageBoxIcon.Error);
  
            }/**/

        }


        //----------------Function Bin Table ----------------------
        internal static DataTable CreateBinTable(string tn)
        {
            DataTable dt = new DataTable();
            string qry = "select top 1 * from " + tn;

            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {

                        SqlDataReader dr = cmd.ExecuteReader();
                        
                        dt.TableName = "bin" + tn;
                        dt.Columns.Add("binID"); dt.Columns["binID"].DataType = System.Type.GetType("System.Int32");
                        dt.Columns.Add("Ord"); dt.Columns["Ord"].DataType = System.Type.GetType("System.Int32");
                        dt.Columns.Add("prevID"); dt.Columns["prevID"].DataType = System.Type.GetType("System.Int32");
                        dt.Columns.Add("Calculated"); dt.Columns["Calculated"].DataType = System.Type.GetType("System.Int32");


                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            dt.Columns.Add(dr.GetName(i)); dt.Columns[dr.GetName(i)].DataType = dr.GetFieldType(i);//  System.Type.GetType(dr.GetDataTypeName(i));
                            /*
                            dynamic fieldMetaData = new ExpandoObject();
                            var columnName = reader.GetName(i);
                            var value = reader[i];
                            var dotNetType = reader.GetFieldType(i);
                            var sqlType = reader.GetDataTypeName(i);
                            var specificType = reader.GetProviderSpecificFieldType(i);
                            fieldMetaData.columnName = columnName;
                            fieldMetaData.value = value;
                            fieldMetaData.dotNetType = dotNetType;
                            fieldMetaData.sqlType = sqlType;
                            fieldMetaData.specificType = specificType;
                            metaDataList.Add(fieldMetaData);
                            /**/
                        }

                        //ColumnName
                        //DataType
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                        return dt;
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not Open Table :" + tn, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }/**/
        }


        internal static bool ClearBinTable(int ccid, DataTable tbl)
        {
            tbl.Clear();
            string fname = LookupDir()+ ccid.ToString() + tbl.TableName + ".xml";
            try
            {
                File.Delete(fname);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        internal static bool CheckForBinData(int ccid, DataTable tbl)
        {
            DataTable t = new DataTable(tbl.TableName);
            t.Merge(tbl);
            if (!LoadBinTable(ccid, t))  // no temp table
            {
                return false;
            }
            if (t.Rows.Count > 0)
            {
                return true;  // yes records
            }
            else
            {
                return false; // no records
            }

        }

        internal static void SaveBinTable(int ccid, DataTable tbl)
        {

            tbl.WriteXml(LookupDir()+ ccid.ToString() + tbl.TableName+".xml");

            if (GlobalLookup.JobInfoID == -1) // Create New JobInfoID
            {
            }
            
        }


        internal static bool LoadBinTable(int ccid, DataTable tbl)
        {
            string path = LookupDir();
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Temp path does not exist","Could NOT Load Temp Data",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            string fn = LookupDir() + ccid.ToString() + tbl.TableName + ".xml";
            if (!File.Exists(fn))
            {
                MessageBox.Show("Temp file does not exist. :"+fn, "Could NOT Load Temp Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            tbl.ReadXml(fn);
            return true;
        }



        internal static void AddToBin(DataTable tBin, string tn, string whereStr,int binID, int prevID,int Ord)
        {
            string qry = "select * from " + tn + " where " + whereStr;
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            tBin.Rows.Add();
                            tBin.Rows[tBin.Rows.Count - 1]["binID"] = binID;
                            tBin.Rows[tBin.Rows.Count - 1]["prevID"] = prevID;
                            tBin.Rows[tBin.Rows.Count - 1]["Ord"] = Ord;

                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                tBin.Rows[tBin.Rows.Count - 1][dr.GetName(i)] = dr[i];
                            }
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not open table "+tn , MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

//---------------------------------------------------


        internal static int Get_PegNameID(string PegName)
        {
            int PegID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT PegID FROM Peg WHERE Descr=@PegName", conn))
                    {
                        cmd.Parameters.AddWithValue("@PegName", PegName);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            PegID = Convert.ToInt32(dr["PegID"].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                     
                    }
                }

                if (PegID < 0)
                {
                    string queryString = " insert into Peg(Descr)Values('" + PegName + "')";
                    execNonQry(queryString);
                    return Get_PegNameID(PegName);
                }
                else
                {
                    return PegID;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not Find Peg ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }/**/
        }

        internal static void LoadPegTypes(List<int> lsID, List<string> lsVal)
        {
            lsID.Add(0); lsVal.Add("Normal Peg");
            lsID.Add(1); lsVal.Add("FLP");
            lsID.Add(2); lsVal.Add("BLP");
        }

        internal static int Add_BasePegs(int PegID1, int PegID2)
        {
            int ID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_Add_BasePegs", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@iPegID1", PegID1);
                        cmd.Parameters.AddWithValue("@iPegID2", PegID2);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            ID = Convert.ToInt32(dr["BaseID"].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not Find Peg ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return ID;
        }

        internal static int Add_bc(DataRow r)
        {
            DataClass.Base3 b = new DataClass.Base3();

            b.BFWID = CommonStr.s2i(r["BFWID"].ToString());
            b.BCID = CommonStr.s2i(r["BCID"].ToString());
            b.CCID = CommonStr.s2i(r["CCID"].ToString());

            b.BS = (r["BS"].ToString());
            b.BSID = CommonStr.s2i(r["BSID"].ToString());
            b.BSPegID = CommonStr.s2i(r["BSPegID"].ToString());


            b.ST = (r["ST"].ToString());
            b.STID = CommonStr.s2i(r["STID"].ToString());
            b.STPegID = CommonStr.s2i(r["STPegID"].ToString());

            b.FS = (r["FS"].ToString());
            b.FSID = CommonStr.s2i(r["FSID"].ToString());
            b.FSPegID = CommonStr.s2i(r["FSPegID"].ToString());

            b.HAFL = CommonStr.s2d(r["HAFL"].ToString());

            b.sfs.Bear = CommonStr.s2d(r["FSBear"].ToString());
            b.sfs.HD = CommonStr.s2d(r["FSHD"].ToString());
            b.sfs.ED = CommonStr.s2d(r["FSED"].ToString());

            b.CID = CommonStr.s2i(r["CID"].ToString());
            b.EID = CommonStr.s2i(r["EID"].ToString());
            b.AUID = CommonStr.s2i(r["AUID"].ToString());
            b.BLogID = CommonStr.s2i(r["BLogID"].ToString());
            b.LP = CommonStr.s2i(r["LP"].ToString());
            b.CCnt = CommonStr.s2i(r["CCnt"].ToString());
            b.Grade = CommonStr.s2i(r["Grade"].ToString());
            b.GradeTypeID = CommonStr.s2i(r["GradeTypeID"].ToString());
            b.sbs.EDErr = CommonStr.s2d(r["BSEDErr"].ToString());
            b.sbs.HDErr = CommonStr.s2d(r["BSHDErr"].ToString());
            b.HAFLErr = CommonStr.s2d(r["HAFLErr"].ToString());
            b.HAFRErr = CommonStr.s2d(r["HAFRErr"].ToString());
            b.sfs.HDErr = CommonStr.s2d(r["FSHDErr"].ToString());
            b.sfs.EDErr = CommonStr.s2d(r["FSEDErr"].ToString());
            b.sfs.BearErr = b.HAFLErr;
            b.BSCnt = CommonStr.s2i(r["BSCnt"].ToString());
            b.ArcCnt = CommonStr.s2i(r["ArcCnt"].ToString());
            b.FSCnt = CommonStr.s2i(r["FSCnt"].ToString());
            b.BaseID = CommonStr.s2i(r["BaseID"].ToString());
            b.MTID = CommonStr.s2i(r["MTID"].ToString());
           // b.Mine = (r["Mine"].ToString());
          //  b.Trav = (r["Trav"].ToString());
          //  b.E = (r["E"].ToString());
          //  b.C = (r["C"].ToString());

            return Add_bc(b);
        }

        internal static int Add_bc(DataClass.Base3 b)
        {
            int ID = -1;
            if ((b.STID > -1) && (b.FSID> -1))
                try
                {
                    using (SqlConnection conn = new SqlConnection(conStr()))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("usp_Add_bc", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@iBCID", b.BCID);
                            cmd.Parameters.AddWithValue("@iCCID", b.CCID);
                            cmd.Parameters.AddWithValue("@iBSID", b.BSID);
                            cmd.Parameters.AddWithValue("@iSTID", b.STID);
                            cmd.Parameters.AddWithValue("@iFSID", b.FSID);
                            cmd.Parameters.AddWithValue("@iHAFL", b.HAFL);
                            cmd.Parameters.AddWithValue("@iFSBear", b.sfs.Bear);
                            cmd.Parameters.AddWithValue("@iFSHD", b.sfs.HD);
                            cmd.Parameters.AddWithValue("@iFSED", b.sfs.ED);
                            cmd.Parameters.AddWithValue("@iCID", b.CID);
                            cmd.Parameters.AddWithValue("@iEID", b.EID);
                            cmd.Parameters.AddWithValue("@iAUID", b.AUID);
                            cmd.Parameters.AddWithValue("@iBLogID", b.BLogID);
                            cmd.Parameters.AddWithValue("@iLP", b.LP);
                            cmd.Parameters.AddWithValue("@iCCnt", b.CCnt);
                            cmd.Parameters.AddWithValue("@iGrade", b.Grade);
                            cmd.Parameters.AddWithValue("@iGradeTypeID", b.GradeTypeID);
                            cmd.Parameters.AddWithValue("@iBSEDErr", b.sbs.EDErr);
                            cmd.Parameters.AddWithValue("@iBSHDErr", b.sbs.HDErr);
                            cmd.Parameters.AddWithValue("@iHAFLErr", b.HAFLErr);
                            cmd.Parameters.AddWithValue("@iHAFRErr", b.HAFRErr);
                            cmd.Parameters.AddWithValue("@iFSHDErr", b.sfs.HDErr);
                            cmd.Parameters.AddWithValue("@iFSEDErr", b.sfs.EDErr);
                            cmd.Parameters.AddWithValue("@iBSCnt", b.BSCnt);
                            cmd.Parameters.AddWithValue("@iArcCnt", b.ArcCnt);
                            cmd.Parameters.AddWithValue("@iFSCnt", b.FSCnt);
                            cmd.Parameters.AddWithValue("@iBaseID", b.BaseID);
                            cmd.Parameters.AddWithValue("@iMTID", b.MTID);

                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                ID = CommonStr.s2i(dr["bcid"].ToString());
                            }
                            dr.Close();
                            ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "Could not Find Peg ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            b.BCID = ID;
            return ID;
        }

        internal static int Get_BaseIDbyPegIDs(int PegID1, int PegID2)
        {
            int ID = -1;
            if ((PegID1>-1)&&(PegID2>-1))
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_Get_BaseIDbyPegIDs", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@iPegID1", PegID1);
                        cmd.Parameters.AddWithValue("@iPegID2", PegID2);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            ID = Convert.ToInt32(dr["BaseID"].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not Find Peg ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return ID;
        }


        public static int Get_PCID(int PegID) //Get pcid from pc using PegID. 
        {
            int pcid = -1;
            if (PegID > -1)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conStr()))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT pcid FROM pc WHERE PegID=@PegID", conn))
                        {
                            cmd.Parameters.AddWithValue("@PegID", PegID);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                pcid = Convert.ToInt32(dr["pcid"].ToString());
                            }
                            dr.Close();
                            ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                        }
                    }
                    return pcid;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "Could not Find PegID in PC ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            else
            {
                return -1;
            }

        }
        public static int Get_PCID(string PegName) //Get pcid from pc using the PegName
        {
            int PegID = Get_PegNameID(PegName);
            return Get_PCID(PegID);
        }

        internal static int Get_bc2_ByNames(string Peg1, string Peg2, DataClass.Base2 b)
        {
            int PegID1 = Get_PegNameID(Peg1); //Peg Name ID 
            int PegID2 = Get_PegNameID(Peg2); //Peg Name ID
            b.ST = Peg1;
            b.FS = Peg2;
            b.BaseID = Get_BaseIDbyPegIDs(PegID1, PegID2);
            return Get_bc2_ByBaseID(b.BaseID, b);
        }

        private static int Get_bc2_ByBaseID(int baseID, DataClass.Base2 b)
        {
            b.BCID = -1;
            if (b.BaseID > -1)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conStr()))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("usp_Get_bc_ByBaseID", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iBaseID", b.BaseID);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                string tmpST = b.ST; //to see if the peg order is reverse from what is needed
                                string tmpFS = b.FS;

                                b.BFWID = Convert.ToInt32(dr["BFWID"].ToString());
                                b.BCID = Convert.ToInt32(dr["BCID"].ToString());
                                b.CCID = Convert.ToInt32(dr["CCID"].ToString());

                                b.ST = (dr["ST"].ToString());
                                b.STID = Convert.ToInt32(dr["STID"].ToString());
                                b.STPegID = Convert.ToInt32(dr["STPegID"].ToString());

                                b.FS = (dr["FS"].ToString());
                                b.FSID = Convert.ToInt32(dr["FSID"].ToString());
                                b.FSPegID = Convert.ToInt32(dr["FSPegID"].ToString());
                                
                    
                                b.polar.Bear = CommonStr.s2d(dr["FSBear"].ToString());
                                b.polar.HD = CommonStr.s2d(dr["FSHD"].ToString());
                                b.polar.ED = CommonStr.s2d(dr["FSED"].ToString());

                                b.CID = Convert.ToInt32(dr["CID"].ToString());
                                b.EID = Convert.ToInt32(dr["EID"].ToString());
                                b.AUID = Convert.ToInt32(dr["AUID"].ToString());
                                b.BLogID = Convert.ToInt32(dr["BLogID"].ToString());
                                b.LP = Convert.ToInt32(dr["LP"].ToString());
                                b.CCnt = Convert.ToInt32(dr["CCnt"].ToString());
                                b.Grade = Convert.ToInt32(dr["Grade"].ToString());
                                b.GradeTypeID = Convert.ToInt32(dr["GradeTypeID"].ToString());

                                b.polar.HDErr = CommonStr.s2d(dr["FSHDErr"].ToString());
                                b.polar.EDErr = CommonStr.s2d(dr["FSEDErr"].ToString());
                                b.polar.BearErr = CommonStr.s2d(dr["HAFLErr"].ToString());

                                b.ArcCnt = Convert.ToInt32(dr["ArcCnt"].ToString());
                                b.FSCnt = Convert.ToInt32(dr["FSCnt"].ToString());
                                b.BaseID = Convert.ToInt32(dr["BaseID"].ToString());
                                b.MTID = Convert.ToInt32(dr["MTID"].ToString());
                                b.Mine = (dr["Mine"].ToString());
                                b.Trav = (dr["Trav"].ToString());
                                b.E = (dr["E"].ToString());
                                b.C = (dr["C"].ToString());

                                b.CheckPegOrder(tmpST, tmpFS);

                            }
                            dr.Close();
                            ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                        }
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "Could not Find BaseID in BC ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            return b.BCID;
        }


        internal static int Get_bc3_ByNames(string Peg1, string Peg2, DataClass.Base3 b)
        {
            int PegID1 = Get_PegNameID(Peg1); //Peg Name ID 
            int PegID2 = Get_PegNameID(Peg2); //Peg Name ID
            b.ST = Peg1;
            b.FS = Peg2;
            b.BaseID = Get_BaseIDbyPegIDs(PegID1, PegID2);
            return Get_bc3_ByBaseID(b.BaseID,b);
                    
        }

        private static int Get_bc3_ByBaseID(int baseID, DataClass.Base3 b)
        {
            b.BCID = -1;
            
            if (b.BaseID > -1)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(conStr()))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("usp_Get_bc_ByBaseID", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure; 
                            cmd.Parameters.AddWithValue("@iBaseID",b.BaseID);
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                b.BFWID = Convert.ToInt32(dr["BFWID"].ToString());

                                b.BCID = Convert.ToInt32(dr["BCID"].ToString());
                                b.CCID = Convert.ToInt32(dr["CCID"].ToString());

                                b.BS = (dr["BS"].ToString());
                                b.BSID = Convert.ToInt32(dr["BSID"].ToString());
                                b.BSPegID = Convert.ToInt32(dr["BSPegID"].ToString());


                                b.ST = (dr["ST"].ToString());
                                b.STID = Convert.ToInt32(dr["STID"].ToString());
                                b.STPegID = Convert.ToInt32(dr["STPegID"].ToString());

                                b.FS = (dr["FS"].ToString());
                                b.FSID = Convert.ToInt32(dr["FSID"].ToString());
                                b.FSPegID = Convert.ToInt32(dr["FSPegID"].ToString());

                                b.HAFL = CommonStr.s2d(dr["HAFL"].ToString());

                                b.sfs.Bear = CommonStr.s2d(dr["FSBear"].ToString());
                                b.sfs.HD = CommonStr.s2d(dr["FSHD"].ToString());
                                b.sfs.ED = CommonStr.s2d(dr["FSED"].ToString());

                                b.CID = Convert.ToInt32(dr["CID"].ToString());
                                b.EID = Convert.ToInt32(dr["EID"].ToString());
                                b.AUID = Convert.ToInt32(dr["AUID"].ToString());
                                b.BLogID = Convert.ToInt32(dr["BLogID"].ToString());
                                b.LP = Convert.ToInt32(dr["LP"].ToString());
                                b.CCnt = Convert.ToInt32(dr["CCnt"].ToString());
                                b.Grade = Convert.ToInt32(dr["Grade"].ToString());
                                b.GradeTypeID = Convert.ToInt32(dr["GradeTypeID"].ToString());
                                b.sbs.EDErr = CommonStr.s2d(dr["BSEDErr"].ToString());
                                b.sbs.HDErr = CommonStr.s2d(dr["BSHDErr"].ToString());
                                b.HAFLErr = CommonStr.s2d(dr["HAFLErr"].ToString());
                                b.HAFRErr = CommonStr.s2d(dr["HAFRErr"].ToString());
                                b.sfs.HDErr = CommonStr.s2d(dr["FSHDErr"].ToString());
                                b.sfs.EDErr = CommonStr.s2d(dr["FSEDErr"].ToString());
                                b.sfs.BearErr = b.HAFLErr;
                                b.BSCnt = Convert.ToInt32(dr["BSCnt"].ToString());
                                b.ArcCnt = Convert.ToInt32(dr["ArcCnt"].ToString());
                                b.FSCnt = Convert.ToInt32(dr["FSCnt"].ToString());
                                b.BaseID = Convert.ToInt32(dr["BaseID"].ToString());
                                b.MTID = Convert.ToInt32(dr["MTID"].ToString());
                                b.Mine = (dr["Mine"].ToString());
                                b.Trav = (dr["Trav"].ToString());
                                b.E = (dr["E"].ToString());
                                b.C = (dr["C"].ToString());

                            }
                            dr.Close();
                            ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                        }
                    }
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(), "Could not Find BaseID in BC ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            return b.BCID;
        }

        internal static bool logon(string EM, string PW)
        {
            GlobalLogon.Clear();
                
            if (EM.Length == 0)
            {
                return false;
            }
            if (PW.Length == 0)
            {
                return false;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT * FROM au WHERE Email = @Email and PWord=@PWord and ATag=1", conn))
                        {
                        cmd.Parameters.AddWithValue("@Email", EM);
                        cmd.Parameters.AddWithValue("@PWord", PW);

                        //rows number of record got inserted
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            GlobalLogon.AUID = Convert.ToInt32(dr["AUID"].ToString());
                            GlobalLogon.FName = dr["FName"].ToString();
                            GlobalLogon.SName = dr["SName"].ToString();
                            GlobalLogon.Email = dr["Email"].ToString();
                            GlobalLogon.ULevel = Convert.ToInt32(dr["ULevel"].ToString());

                        }
                        else
                        {
                            return false;
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                        if (GlobalLogon.AUID > -1)
                        {
                            return true;
                        }
                        else
                        { return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not logon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }/**/

            
        }

        internal static bool Get_PegCoords(DataClass.PegYXZ p)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT * FROM v_Peg WHERE Peg=@Peg", conn))
                    {
                        cmd.Parameters.AddWithValue("@Peg", p.Peg);
                        
                        //rows number of record got inserted
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            p.pcid = Convert.ToInt32(dr["pcid"].ToString());
                            p.PegID = Convert.ToInt32(dr["PegID"].ToString());
                            p.Peg = (dr["Peg"].ToString());
                            p.coord.X = CommonStr.s2d(dr["X"].ToString());
                            p.coord.Y = CommonStr.s2d(dr["Y"].ToString());
                            p.coord.Z = CommonStr.s2d(dr["Z"].ToString());
                            p.coord.G = CommonStr.s2d(dr["G"].ToString());
                            p.CCID = Convert.ToInt32(dr["CCID"].ToString());
                            p.CID = Convert.ToInt32(dr["CID"].ToString());
                            p.EID = Convert.ToInt32(dr["EID"].ToString());
                            p.AUID = Convert.ToInt32(dr["AUID"].ToString());
                            p.PLogID = Convert.ToInt32(dr["PLogID"].ToString());
                            p.HDErr = CommonStr.s2d(dr["HDErr"].ToString());
                            p.EDErr = CommonStr.s2d(dr["EDErr"].ToString());
                            p.HAErr = CommonStr.s2d(dr["HAErr"].ToString());
                            p.LP = Convert.ToInt32(dr["LP"].ToString());
                            p.CCnt = Convert.ToInt32(dr["CCnt"].ToString());
                            p.MTID = Convert.ToInt32(dr["MTID"].ToString());
                            p.MineID = Convert.ToInt32(dr["MineID"].ToString());
                            p.TravID = Convert.ToInt32(dr["TravID"].ToString());
                            p.Mine = (dr["Mine"].ToString());
                            p.Trav = (dr["Trav"].ToString());
                            p.E = (dr["E"].ToString());
                            p.C = (dr["C"].ToString());



                        }
                        else
                        {
                            return false;
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                        if (GlobalLogon.AUID > -1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could Read Coords :" + p.Peg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }/**/

        }

        internal static bool Get_MTPegCoords(DataClass.PegYXZ p)
        {
            try
            {
                using (SqlConnection conn =  new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT * FROM v_Peg WHERE Peg=@Peg and MTID=@MTID", conn))
                    {
                        cmd.Parameters.AddWithValue("@Peg", p.Peg);
                        cmd.Parameters.AddWithValue("@MTID", p.MTID);

                        //rows number of record got inserted
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            p.pcid = Convert.ToInt32(dr["pcid"].ToString());
                            p.PegID = Convert.ToInt32(dr["PegID"].ToString());
                            p.Peg = (dr["Peg"].ToString());
                            p.coord.X = CommonStr.s2d(dr["X"].ToString());
                            p.coord.Y = CommonStr.s2d(dr["Y"].ToString());
                            p.coord.Z = CommonStr.s2d(dr["Z"].ToString());
                            p.coord.G = CommonStr.s2d(dr["G"].ToString());
                            p.CCID = Convert.ToInt32(dr["CCID"].ToString());
                            p.CID = Convert.ToInt32(dr["CID"].ToString());
                            p.EID = Convert.ToInt32(dr["EID"].ToString());
                            p.AUID = Convert.ToInt32(dr["AUID"].ToString());
                            p.PLogID = Convert.ToInt32(dr["PLogID"].ToString());
                            p.HDErr = CommonStr.s2d(dr["HDErr"].ToString());
                            p.EDErr = CommonStr.s2d(dr["EDErr"].ToString());
                            p.HAErr = CommonStr.s2d(dr["HAErr"].ToString());
                            p.LP = Convert.ToInt32(dr["LP"].ToString());
                            p.CCnt = Convert.ToInt32(dr["CCnt"].ToString());
                            p.MTID = Convert.ToInt32(dr["MTID"].ToString());
                            p.MineID = Convert.ToInt32(dr["MineID"].ToString());
                            p.TravID = Convert.ToInt32(dr["TravID"].ToString());
                            p.Mine = (dr["Mine"].ToString());
                            p.Trav = (dr["Trav"].ToString());
                            p.E = (dr["E"].ToString());
                            p.C = (dr["C"].ToString());

                        }
                        else
                        {
                            return false;
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                        if (GlobalLogon.AUID > -1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could Read Coords :"+p.Peg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }/**/

        }

        internal static int Add_pc(DataRow r)
        {
            int PegID = Get_PegNameID(r["Peg"].ToString());
            int pcid = Get_PCID(PegID); //if exists(pcid>0), update else insert

            return dmMain.Add_pc(pcid, PegID
                    , CommonStr.s2d(r["X"].ToString())
                    , CommonStr.s2d(r["Y"].ToString())
                    , CommonStr.s2d(r["Z"].ToString())
                    , CommonStr.s2d(r["G"].ToString())
                    , CommonStr.s2i(r["CCID"].ToString()) 
                    , CommonStr.s2i(r["CID"].ToString())
                    , CommonStr.s2i(r["EID"].ToString())
                    , CommonStr.s2i(r["AUID"].ToString())
                    , CommonStr.s2i(r["PLogID"].ToString())
                    , CommonStr.s2d(r["HDErr"].ToString())
                    , CommonStr.s2d(r["EDErr"].ToString())
                    , CommonStr.s2d(r["HAErr"].ToString())
                    , CommonStr.s2i(r["LP"].ToString())
                    , CommonStr.s2i(r["CCnt"].ToString())
                    , CommonStr.s2i(r["MTID"].ToString())
                    );
 
        } 

        internal static int Add_pc( int pcid
                                    , int PegID
                                    , double X
                                    , double Y
                                    , double Z
                                    , double G
                                    , int CCID
                                    , int CID
                                    , int EID
                                    , int AUID
                                    , int PLogID
                                    , double HDErr
                                    , double EDErr
                                    , double HAErr
                                    , int LP
                                    , int CCnt
                                    , int MTID )
        {
            int tpcid = 0;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Add_pc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ipcid"  ,SqlDbType.Int).Value = pcid      ;
                    cmd.Parameters.Add("@iPegID" ,SqlDbType.Int).Value =  PegID     ;
                    cmd.Parameters.Add("@iTStamp",SqlDbType.DateTime).Value =  DateTime.Now    ;
                    cmd.Parameters.Add("@iX"     ,SqlDbType.Float).Value =  X         ;
                    cmd.Parameters.Add("@iY"     ,SqlDbType.Float).Value =  Y         ;
                    cmd.Parameters.Add("@iZ"     ,SqlDbType.Float).Value =  Z         ;
                    cmd.Parameters.Add("@iG"     ,SqlDbType.Float).Value =  G         ;
                    cmd.Parameters.Add("@iCCID"  ,SqlDbType.Int).Value =  CCID      ;
                    cmd.Parameters.Add("@iCID"   ,SqlDbType.Int).Value =  CID       ;
                    cmd.Parameters.Add("@iEID"   ,SqlDbType.Int).Value =  EID       ;
                    cmd.Parameters.Add("@iAUID"  ,SqlDbType.Int).Value =  AUID      ;
                    cmd.Parameters.Add("@iPLogID",SqlDbType.Int).Value =  PLogID    ;
                    cmd.Parameters.Add("@iHDErr" ,SqlDbType.Float).Value =  HDErr     ;
                    cmd.Parameters.Add("@iEDErr" ,SqlDbType.Float).Value =  EDErr     ;
                    cmd.Parameters.Add("@iHAErr" ,SqlDbType.Float).Value =  HAErr     ;
                    cmd.Parameters.Add("@iLP"    ,SqlDbType.Int).Value =  LP        ;
                    cmd.Parameters.Add("@iCCnt"  ,SqlDbType.Int).Value =  CCnt      ;
                    cmd.Parameters.Add("@iMTID"  ,SqlDbType.Int).Value =  MTID      ;

                    con.Open();
                    //cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tpcid = CommonStr.s2i(dr["pcid"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return tpcid;
        }

        internal static int Add_JobInfo(int CCID, int CalcID, string Descr)
        {
            int JobInfoID = 0;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Add_JobInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@iCCID", SqlDbType.Int).Value = CCID;
                    cmd.Parameters.Add("@iCalcID", SqlDbType.Int).Value = CalcID;
                    cmd.Parameters.Add("@iDescr", SqlDbType.VarChar).Value = Descr;
                    con.Open();
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        JobInfoID = CommonStr.s2i(dr["JobInfoID"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return JobInfoID;
        }


        internal static int Update_Calc_JobInfo(int JobInfoID,int CalcID, int JobInfo_Update)
        {
            
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Update_Calc_JobInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@iJobInfoID", SqlDbType.Int).Value = JobInfoID;
                    cmd.Parameters.Add("@iCalcID", SqlDbType.Int).Value = CalcID;
                    cmd.Parameters.Add("@iTable", SqlDbType.Int).Value = JobInfo_Update;
                    con.Open();
                    //cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        JobInfoID = CommonStr.s2i(dr["JobInfoID"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return JobInfoID;
        }


        internal static int Add_JobInfoData(int JobInfoID, int lkpTypeID, int LkpID, String Descr)
        {

            //loop through binLkp
            //Add value to JobInfoData

            int JobInfoDataID = -1;

            using (SqlConnection con = new SqlConnection((conStr())))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Add_JobInfoData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@iJobInfoID", SqlDbType.Int).Value = JobInfoID;
                    cmd.Parameters.Add("@ilkpTypeID", SqlDbType.Int).Value = lkpTypeID;
                    cmd.Parameters.Add("@ilkpID", SqlDbType.Int).Value = LkpID;
                    cmd.Parameters.Add("@iDescr", SqlDbType.VarChar).Value = Descr;

                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        JobInfoDataID = CommonStr.s2i(dr["JobInfoDataID"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
                    //cmd.ExecuteNonQuery();

                    
                
            }
            return JobInfoDataID;
            
        }



        internal static int Add_JobInfoData(int JobInfoID, DataTable tLkp)
        {

            //loop through binLkp
            //Add value to JobInfoData

            int i = 0;

            foreach (DataRow r in tLkp.Rows)
            {
                i++;

                Add_JobInfoData(
                      JobInfoID
                    , CommonStr.s2i(r["lkpTypeID"].ToString())
                    , CommonStr.s2i(r["LkpID"].ToString())
                    , r["LkpVal"].ToString()
                    );

            }
                   
            return i;
        }
        internal static int Get_MTID(int mineID, int travID)
        {
            int MTID = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT MTID FROM MT WHERE MineID=@MineID and TravID=@TravID and ATag=1", conn))
                    {
                        cmd.Parameters.AddWithValue("@MineID", mineID);
                        cmd.Parameters.AddWithValue("@TravID", travID);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MTID = Convert.ToInt32(dr["MTID"].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                        return MTID;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could read MTID ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }/**/
        }


        internal static bool Load_LookUpValWhere(string TN, string fldID, string fldVal, string whereStr, List<KeyValuePair<int, string>> ls, bool AddDefaultAll = false)
        {
            ls.Clear();
            if (AddDefaultAll)
            {
                ls.Add(new KeyValuePair<int, string>( -1, "<select>"));
            }

            if (whereStr.Length > 0)
            {
                whereStr = "and " + whereStr;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(conStr()))
                {

                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT " + fldID + "," + fldVal + " FROM " + TN + " WHERE 1=1 " + whereStr + " and ATag=1", conn))
                    {
                        //rows number of record got inserted
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ls.Add(new KeyValuePair<int, string>(Convert.ToInt32(dr[fldID].ToString()), dr[fldVal].ToString()));
                            
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not fill lookup " + TN, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }/**/
            return true;
        }

        internal static bool Load_LookUpValWhere(string TN, string fldID, string fldVal, string whereStr,List<int> lsID, List<string> lsVal, bool AddDefaultAll = false)
        {
            lsID.Clear();
            lsVal.Clear();
            if (whereStr.Length > 0)
            {
                whereStr = "and " + whereStr;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(conStr()))
                {
                    
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT " + fldID + "," + fldVal + " FROM " + TN + " WHERE 1=1 "+ whereStr + " and ATag=1", conn))
                    {
                        //rows number of record got inserted
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            lsID.Add(Convert.ToInt32(dr[fldID].ToString()));
                            lsVal.Add(dr[fldVal].ToString());
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Could not fill lookup " + TN, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }/**/

            if (AddDefaultAll==true)
            {
                lsID.Insert(0, -1);
                lsVal.Insert(0, "<select>");
            }
            return true;

        
        }

        internal static int Add_Print_ID(int AUID, int CalcID)
        {
            int printid = -1;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Add_Print_ID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@iAUID", SqlDbType.Int).Value = AUID;
                    cmd.Parameters.Add("@iCalcID", SqlDbType.Int).Value = CalcID;

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.Read())
                    {
                        printid = Convert.ToInt32(dr["PrintID"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup

                }

            }
            return printid;
        }

        internal static int EmptyPrintTbl(int AUID)
        {
           
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Empty_PrintTbl", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@iAUID", SqlDbType.Int).Value = AUID;
                    
                    con.Open();
                    
                }
                
            }
            return 1;
        }

        internal static int Del_Rec(string TN, string Fld,string ID)
        {
            string queryString = "delete from "+TN+" where "+Fld+" = "+ID;

            return execNonQry(queryString);
                        
        }


        internal static int Set_ATag(string TN, string Fld, string ID, string ATag)
        {
            string queryString = " update     " + TN 
                               + " set ATag = "+ATag
                               + " where      " + Fld + " = " + ID;

            return execNonQry(queryString);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        internal static int Add_Rec(DataRow row)
        {
            // insert into tn(name,fullname)values(@name,@fullane); 
            // 
            int rows_affected = 0;
            string tn = row.Table.TableName;
            string flds = "";
            string parms = "";
            int colcnt = row.Table.Columns.Count;

            for (int r = 0; r < colcnt - 1; r++) {

                if (!row.Table.Columns[r].AutoIncrement)
                {
                    flds = flds + "," + row.Table.Columns[r].ColumnName;
                    parms = parms + ",@" + row.Table.Columns[r].ColumnName;
                }
            }

            if (flds.Length > 0)
            {
                flds = flds.Remove(0, 1);
                parms = parms.Remove(0, 1);
            }else
            {
                return -1;
            }

          
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("INSERT INTO " + tn + "(" + flds + ") VALUES(" + parms + ")", conn))

                    {
                        for(int r = 0; r < colcnt - 1; r++) {

                            if (!row.Table.Columns[r].AutoIncrement)
                            {
                                cmd.Parameters.AddWithValue("@" + row.Table.Columns[r].ColumnName, row[row.Table.Columns[r].ColumnName]);
                                
                            }
                        }

                        //rows number of record got inserted
                        rows_affected = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(),tn+": Insert Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }/**/

            return rows_affected;
        }

        internal static int Add_bfw(DataRow r)
        {
            int bfwid = 0;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Add_bfw", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iBFWID", r["BFWID"]);
                    cmd.Parameters.AddWithValue("@iBCID", r["BCID"]);
                    cmd.Parameters.AddWithValue("@iCCID", r["CCID"]);
                    cmd.Parameters.AddWithValue("@iBSID", r["BSID"]);
                    cmd.Parameters.AddWithValue("@iSTID", r["STID"]);
                    cmd.Parameters.AddWithValue("@iFSID", r["FSID"]);
                    cmd.Parameters.AddWithValue("@iBSED", r["BSED"]);
                    cmd.Parameters.AddWithValue("@iBSHD", r["BSHD"]);
                    cmd.Parameters.AddWithValue("@iBSBear", r["BSBear"]);
                    cmd.Parameters.AddWithValue("@iBSBearR", r["BSBearR"]);
                    cmd.Parameters.AddWithValue("@iHAFL", r["HAFL"]);
                    cmd.Parameters.AddWithValue("@iHAFR", r["HAFR"]);
                    cmd.Parameters.AddWithValue("@iFSBear", r["FSBear"]);
                    cmd.Parameters.AddWithValue("@iFSBearR", r["FSBearR"]);
                    cmd.Parameters.AddWithValue("@iFSHD", r["FSHD"]);
                    cmd.Parameters.AddWithValue("@iFSED", r["FSED"]);
                    cmd.Parameters.AddWithValue("@iCID", r["CID"]);
                    cmd.Parameters.AddWithValue("@iEID", r["EID"]);
                    cmd.Parameters.AddWithValue("@iAUID", r["AUID"]);
                    cmd.Parameters.AddWithValue("@iBLogID", r["BLogID"]);
                    cmd.Parameters.AddWithValue("@iLP", r["LP"]);
                    cmd.Parameters.AddWithValue("@iCCnt", r["CCnt"]);
                    cmd.Parameters.AddWithValue("@iGrade", r["Grade"]);
                    cmd.Parameters.AddWithValue("@iGradeTypeID",r["GradeTypeID"]);
                    cmd.Parameters.AddWithValue("@iBSEDErr", r["BSEDErr"]);
                    cmd.Parameters.AddWithValue("@iBSHDErr", r["BSHDErr"]);
                    cmd.Parameters.AddWithValue("@iHAFLErr", r["HAFLErr"]);
                    cmd.Parameters.AddWithValue("@iHAFRErr", r["HAFRErr"]);
                    cmd.Parameters.AddWithValue("@iFSHDErr", r["FSHDErr"]);
                    cmd.Parameters.AddWithValue("@iFSEDErr", r["FSEDErr"]);
                    cmd.Parameters.AddWithValue("@iBSCnt", r["BSCnt"]);
                    cmd.Parameters.AddWithValue("@iArcCnt", r["ArcCnt"]);
                    cmd.Parameters.AddWithValue("@iFSCnt", r["FSCnt"]);
                    cmd.Parameters.AddWithValue("@iBaseID", r["BaseID"]);
                    cmd.Parameters.AddWithValue("@iMTID", r["MTID"]);
                    cmd.Parameters.AddWithValue("@iInstrHgt", r["InstrHgt"]);
                    cmd.Parameters.AddWithValue("@iSTChainAdj", r["STChainAdj"]);
                    cmd.Parameters.AddWithValue("@iFSChainAdj", r["FSChainAdj"]);
                    cmd.Parameters.AddWithValue("@iPPnt1", r["PPnt1"]);
                    cmd.Parameters.AddWithValue("@iPPnt1Y", r["PPnt1Y"]);
                    cmd.Parameters.AddWithValue("@iPPnt1X", r["PPnt1X"]);
                    cmd.Parameters.AddWithValue("@iPPnt1Z", r["PPnt1Z"]);

                    //con.Open();
                    //cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        bfwid = CommonStr.s2i(dr["bfwid"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return bfwid;
        }

        internal static void IfNullNegOne(DataRowView r, string fld)
        {
            if (r[fld].ToString() == "")
            {
                r[fld] = -1;
            }
        }
        

        internal static int Update_Rec(string[] idx, DataRow row)
        {
            // update tn
            //  set   name     =@name
            //       ,fullname =@fullname
            // where  auid     =@auid
            // and    email    =@email; 
            // 

            int rows_affected = 0;
            string tn = row.Table.TableName;
            string flds = "";
            string wheres = "";
            int colcnt = row.Table.Columns.Count;
            string fld = "";
            for (int r = 0; r < colcnt - 1; r++)
            {
                fld = row.Table.Columns[r].ColumnName;
                if (idx.Contains(fld))
                {
                    wheres = wheres + "and " + fld + " = @" + fld;
                }
                else
                {
                    flds = flds + ", " + fld + " = @" + fld;
                }
                
            }
            if (flds.Length > 0)
            {
                flds = flds.Remove(0, 1);
            }
            else
            {
                return -1;
            }

            if (wheres.Length > 0)
            {
                wheres = wheres.Remove(0, 3);
                wheres = " where " + wheres;
            }
            
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(conStr()))
                {
                    conn.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("UPDATE " + tn + " SET " + flds + " " + wheres, conn))

                    {
                        for (int r = 0; r < colcnt - 1; r++)
                        {
                                                       
                             cmd.Parameters.AddWithValue("@" + row.Table.Columns[r].ColumnName, row[row.Table.Columns[r].ColumnName]);
                                                       
                        }

                        //rows number of record got inserted
                        rows_affected = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), tn + ": Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }/**/

            return rows_affected;
        }



        internal static bool load_LookUpVal(string TN, string fldID, string fldVal, List<int> lsID, List<string> lsVal, bool AddDefaultAll = false)
        {
            return Load_LookUpValWhere(TN, fldID, fldVal,  "", lsID,lsVal, AddDefaultAll);
        }

        internal static bool Load_LookUpVal(string TN, string fldID, string fldVal, List<KeyValuePair<int, string>> ls, bool AddDefaultAll = false)
        {
           return Load_LookUpValWhere(TN, fldID, fldVal, "", ls, AddDefaultAll);
        }

        internal static bool Find_Bin_BSSTN_Base(string BS, string ST,int BinID, DataTable tBase, DataClass.Base2 b)
        {
            bool FoundBase = false;
            foreach (DataRow r in tBase.Rows)
                if (BinID != CommonStr.s2i(r["BinID"].ToString()))
                {

                    if ((ST == r["BS"].ToString()) || (ST == r["ST"].ToString()) || (ST == r["FS"].ToString()))
                    {
                        if ((BS == r["BS"].ToString()) && (ST == r["ST"].ToString()))  // A B C   ->  A B D
                        {
                            b.polar.Bear = CommonStr.s2d(r["BSBear"].ToString());
                            b.polar.ED = CommonStr.s2d(r["BSED"].ToString());
                            b.polar.HD = CommonStr.s2d(r["BSHD"].ToString());
                            b.MTID = CommonStr.s2i(r["MTID"].ToString());
                            b.binID = CommonStr.s2i(r["binID"].ToString());
                            FoundBase = true;
                        }
                        else
                            if ((BS == r["ST"].ToString()) && (ST == r["FS"].ToString()))  // A B C   ->   B C D
                        {
                            b.polar.Bear = CommonStr.s2d(r["FSBear"].ToString());
                            b.polar.ED = CommonStr.s2d(r["FSED"].ToString());
                            b.polar.HD = CommonStr.s2d(r["FSHD"].ToString());
                            b.MTID = CommonStr.s2i(r["MTID"].ToString());
                            b.binID = CommonStr.s2i(r["binID"].ToString());

                            FoundBase = true;
                        }
                        else
                            if ((BS == r["ST"].ToString()) && (ST == r["BS"].ToString()))  // A B C   ->  B A D
                        {
                            b.polar.Bear = CommonStr.s2d(r["BSBear"].ToString());
                            b.polar.ED = CommonStr.s2d(r["BSED"].ToString());
                            b.polar.HD = CommonStr.s2d(r["BSHD"].ToString());
                            b.polar.reverse();
                            b.MTID = CommonStr.s2i(r["MTID"].ToString());
                            b.binID = CommonStr.s2i(r["binID"].ToString());

                            FoundBase = true;
                        }
                        else
                            if ((BS == r["FS"].ToString()) && (ST == r["ST"].ToString()))  // A B C   ->  C B D
                        {
                            b.polar.Bear = CommonStr.s2d(r["FSBear"].ToString());
                            b.polar.ED = CommonStr.s2d(r["FSED"].ToString());
                            b.polar.HD = CommonStr.s2d(r["FSHD"].ToString());
                            b.polar.reverse();
                            b.MTID = CommonStr.s2i(r["MTID"].ToString());
                            b.binID = CommonStr.s2i(r["binID"].ToString());
                            FoundBase = true;
                        }
                    }
                
                }
           return FoundBase;
        }


        internal static int Add_Vert(int bfwid, DataRow r)
        {
            int vertid = 0;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Add_vert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iBFWID",r["BFWID"]);
                    cmd.Parameters.AddWithValue("@iVertDirID",r["VertDirID"]);
                    cmd.Parameters.AddWithValue("@iCnt",r["Ord"]);  // Use Ord as Cnt
                    cmd.Parameters.AddWithValue("@iInstrHgt",r["InstrHgt"]);
                    cmd.Parameters.AddWithValue("@iVAFL",r["VAFL"]);
                    cmd.Parameters.AddWithValue("@iVAFR",r["VAFR"]);
                    cmd.Parameters.AddWithValue("@iMD",r["MD"]);
                    cmd.Parameters.AddWithValue("@iBobHgt",r["BobHgt"]);
                    cmd.Parameters.AddWithValue("@iDip",r["Dip"]);
                    cmd.Parameters.AddWithValue("@iHD",r["HD"]);
                    cmd.Parameters.AddWithValue("@iED",r["ED"]);
                    cmd.Parameters.AddWithValue("@iVAErr",r["VAErr"]);
                    cmd.Parameters.AddWithValue("@iATag",r["ATag"]);

                    //con.Open();
                    //cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        vertid = CommonStr.s2i(dr["vertid"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return vertid;
        }

        internal static int Add_Hor(int bfwid, DataRow r)
        {
            int horid = 0;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Add_hor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iBFWID", r["BFWID"]);
                    cmd.Parameters.AddWithValue("@iCnt", r["Ord"]);
                    cmd.Parameters.AddWithValue("@iHAFL1", r["HAFL1"]);
                    cmd.Parameters.AddWithValue("@iHAFL2", r["HAFL2"]);
                    cmd.Parameters.AddWithValue("@iHAFR1", r["HAFR1"]);
                    cmd.Parameters.AddWithValue("@iHAFR2", r["HAFR2"]);
                    cmd.Parameters.AddWithValue("@iHAFL", r["HAFL"]);
                    cmd.Parameters.AddWithValue("@iHAFR", r["HAFR"]);
                    cmd.Parameters.AddWithValue("@iHAErr", r["HAErr"]);
                    cmd.Parameters.AddWithValue("@iATag", r["ATag"]);

                    //con.Open();
                    //cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        horid = CommonStr.s2i(dr["horid"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return horid;
        }

        internal static int Add_VertSum(int bfwid, DataRow r)
        {
            int vertsumid = 0;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Add_vertsum", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iBFWID", r["BFWID"]);
                    cmd.Parameters.AddWithValue("@iBSCnt", r["BSCnt"]);
                    cmd.Parameters.AddWithValue("@iBSHD", r["BSHD"]);
                    cmd.Parameters.AddWithValue("@iBSED", r["BSED"]);
                    cmd.Parameters.AddWithValue("@iBSHDErr", r["BSHDErr"]);
                    cmd.Parameters.AddWithValue("@iBSEDErr", r["BSEDErr"]);
                    cmd.Parameters.AddWithValue("@iFSCnt", r["FSCnt"]);
                    cmd.Parameters.AddWithValue("@iFSHD", r["FSHD"]);
                    cmd.Parameters.AddWithValue("@iFSED", r["FSED"]);
                    cmd.Parameters.AddWithValue("@iFSHDErr", r["FSHDErr"]);
                    cmd.Parameters.AddWithValue("@iFSEDErr", r["FSEDErr"]);

                    

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        vertsumid = CommonStr.s2i(dr["vertsumid"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return vertsumid;
        }


        internal static int Add_HorSum(int bfwid, DataRow r)
        {
            int horsumid = 0;
            using (SqlConnection con = new SqlConnection((conStr())))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_Add_horsum", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iBFWID", r["BFWID"]);
                    cmd.Parameters.AddWithValue("@iHAFLAve", r["HAFLAve"]);
                    cmd.Parameters.AddWithValue("@iHAFRAve", r["HAFRAve"]);
                    cmd.Parameters.AddWithValue("@iHACorr", r["HACorr"]);
                    cmd.Parameters.AddWithValue("@iHAFL", r["HAFL"]);
                    cmd.Parameters.AddWithValue("@iHAFR", r["HAFR"]);
                    cmd.Parameters.AddWithValue("@iHAFLErr", r["HAFLErr"]);
                    cmd.Parameters.AddWithValue("@iHAFRErr", r["HAFRErr"]);
                    cmd.Parameters.AddWithValue("@iHAFLCnt", r["HAFLCnt"]);
                    cmd.Parameters.AddWithValue("@iHAFRCnt", r["HAFRCnt"]);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        horsumid = CommonStr.s2i(dr["horsumid"].ToString());

                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();//always good idea to do proper cleanup
                }
            }
            return horsumid;
        }

    }

}



