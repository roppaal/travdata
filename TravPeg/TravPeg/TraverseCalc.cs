using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravPeg
{   
    public partial class frmTraverseCalc : Form
    {

        public static int ccid = 5; //Traverse Calc funciton ID
        private frmMain frmM;//ref to mainform 

        private int BinID = 1; // current record

        public bool LoadingData = false;
        private bool Busy_CalcBtnClicked = false; //when calc button is clicked
        private bool Busy_calc_Coords = false;  //inside calc loop. stop visual control to initiate calc while busy with calc

        const bool ShowClassLimitFail = true;

        

        int rBS = 0; //row in dgvSetup for BS
        int rST = 1; //row in dgvSetup for ST
        int rFS = 2; //row in dgvSetup for FS

        DataTable tbfw;  //base field work
        DataView tvbfw;

        DataTable tPeg;  //Pegs
        DataView tvBS;   // BS
        DataView tvST;   // ST
        DataView tvFS;   // FS

        DataTable tHor;  //horizotals
        DataView tvHor;

        DataTable tHorSum;  //horizotals summary
        DataView tvHorSum;

        DataTable tVert;  //vertical
        DataView tvVert;

        DataTable tVertSum;  //vertical summary
        DataView tvVertSum;

        DataTable tClass;
        DataView vClass;

        DataTable tLkp;
        DataView vLkp;



        List<string> lsClassVal; List<int> lsClassID;
        List<string> lsMineVal; List<int> lsMineID;
        List<string> lsTravVal; List<int> lsTravID;
        List<string> lsLPVal; List<int> lsLPID;
        List<string> lsGTVal; List<int> lsGTID; //GradeType

        List<DataClass.PegYXZ> lsP; 


        DataClass.PegYXZ p1; //BackSight - peg
        DataClass.PegYXZ p2; //Station   - peg 
        DataClass.PegYXZ p3; //Forsight  - peg

        DataClass.Base3 b;  //bs - stn - fs - base fields

        


        public frmTraverseCalc(frmMain frm)
        {
            InitializeComponent();
            frmM = frm;
        
            tbfw = dmMain.CreateBinTable("v_bfw");
            tvbfw = new DataView(tbfw);

            tPeg = dmMain.CreateBinTable("v_pc");
            tvBS = new DataView(tPeg);
            tvST = new DataView(tPeg);
            tvFS = new DataView(tPeg);

            tHor = dmMain.CreateBinTable("hor");
            tvHor = new DataView(tHor);
            tHorSum = dmMain.CreateBinTable("horsum");
            tvHorSum = new DataView(tHorSum);

            tVert = dmMain.CreateBinTable("vert");
            tvVert = new DataView(tVert);
            tVertSum = dmMain.CreateBinTable("vertsum");
            tvVertSum = new DataView(tVertSum);

            tClass = dmMain.LoadMainTable("c");
            vClass = new DataView(tClass);

            tLkp = dmMain.CreateBinLkpTable(ccid);
            vLkp = new DataView(tLkp);

            txtSTN_G.DataBindings.Add("Text", tvST, "G");// set stn grade (Stn_G)
            txtInstrHgt.DataBindings.Add("Text", tvbfw, "InstrHgt");// InstrHgt Base Data
            txtGrade.DataBindings.Add("Text", tvbfw, "Grade");// Grade
            txtPlottingPnt.DataBindings.Add("Text",tvbfw,"PPnt1");//Plotting Point
            txtSTChainAdj.DataBindings.Add("Text", tvbfw, "STChainAdj");//ST Adj Chain

            lblPPnt1.DataBindings.Add("Text",tvbfw,"PPnt1");
            lblPPnt1X.DataBindings.Add("Text", tvbfw, "PPnt1X");
            lblPPnt1Y.DataBindings.Add("Text", tvbfw, "PPnt1Y");
            lblPPnt1Z.DataBindings.Add("Text", tvbfw, "PPnt1Z");

            lblClass.DataBindings.Add("Text", vClass, "Descr");// Class Name

            lsClassVal = new List<string>(); lsClassID = new List<int>();
            lsMineVal = new List<string>(); lsMineID = new List<int>();
            lsTravVal = new List<string>(); lsTravID = new List<int>();
            lsLPVal = new List<string>(); lsLPID = new List<int>(); // Line Peg 
            lsGTVal = new List<string>(); lsGTID = new List<int>(); // Grade Type

            dmMain.load_LookUpVal("C", "CID", "Descr", lsClassID, lsClassVal, false);
            cboClass.DataSource = lsClassVal;

            if (cboClass.Items.Count == 0)
            {
                MessageBox.Show("No Class Data Found", "Load Class", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            dmMain.load_LookUpVal("GradeType", "GradeTypeID", "Descr", lsGTID, lsGTVal, false);
            cboGradeType.DataSource = lsGTVal;

            if (cboGradeType.Items.Count == 0)
            {
                MessageBox.Show("No Grade Found", "Load GradeType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lsP = new List<DataClass.PegYXZ>();

            b = new DataClass.Base3();

            p1 = new DataClass.PegYXZ();
            p2 = new DataClass.PegYXZ();
            p3 = new DataClass.PegYXZ();

            prepare_dgvSetup();

            fill_bfw();
            fill_Hor();
            fill_Vert();


        }

        internal bool check_ForBinData()  //check if data exists in the bin
        {
            return dmMain.CheckForBinData(ccid, tbfw);
        }

        internal void load_Lkps()
        {
           
        }

        private void set_ViewPosition(int bid)
        {
            string RowFilterStr = "BinID = " + bid.ToString();
            

            tvbfw.RowFilter = RowFilterStr;       //3 base fieldwork
            

            string bs = tvbfw[0]["BS"].ToString();
            string st = tvbfw[0]["ST"].ToString();
            string fs = tvbfw[0]["FS"].ToString();

            fill_dgvSetup(bs, st, fs);           // Setup Pegs

            tvHor.RowFilter = RowFilterStr;       // horizotals
            tvHorSum.RowFilter = RowFilterStr;    // horizotals summary
            tvVert.RowFilter = RowFilterStr;      // vertical
            tvVertSum.RowFilter = RowFilterStr;   // vertical summary

            string ClassFilterStr = "cid = " + tvbfw[0]["cid"].ToString();
            vClass.RowFilter = ClassFilterStr;

            if (cboGradeType.Items.Count > 0)
            {
                cboGradeType.SelectedIndex = CommonStr.s2i(tvbfw[0]["GradeTypeID"].ToString());
            }

            if (cboClass.Items.Count > 0)
            {
                cboClass.SelectedIndex = CommonStr.s2i(tvbfw[0]["CID"].ToString());
            }
            fill_ClassLimits();

        }



        private void next_Peg()  // navigate next rec
        {
            if (BinID < tbfw.Rows.Count)
            {
                BinID += 1;
            }
        }

        private void prev_Peg()  //navigate prev rec
        {
            if (BinID > 1) {
                BinID -= 1;
            }

        }



        private void clear_TmpTables()
        {
            dmMain.ClearBinTable(ccid, tbfw);
            dmMain.ClearBinTable(ccid, tPeg);
            dmMain.ClearBinTable(ccid, tHor);
            dmMain.ClearBinTable(ccid, tHorSum);
            dmMain.ClearBinTable(ccid, tVert);
            dmMain.ClearBinTable(ccid, tVertSum);
            dmMain.ClearBinTable(ccid, tLkp);

        }


        private void save_TmpTables()
        {
            dmMain.SaveBinTable(ccid, tbfw);
            dmMain.SaveBinTable(ccid, tPeg);
            dmMain.SaveBinTable(ccid, tHor);
            dmMain.SaveBinTable(ccid, tHorSum);
            dmMain.SaveBinTable(ccid, tVert);
            dmMain.SaveBinTable(ccid, tVertSum);
            dmMain.SaveBinTable(ccid, tLkp);
            
        }

        public void load_TmpTables()
        {
           // LoadingData = true;

            dmMain.LoadBinTable(ccid, tbfw);
            dmMain.LoadBinTable(ccid, tPeg);
            dmMain.LoadBinTable(ccid, tHor);
            dmMain.LoadBinTable(ccid, tHorSum);
            dmMain.LoadBinTable(ccid, tVert);
            dmMain.LoadBinTable(ccid, tVertSum);
            dmMain.LoadBinTable(ccid, tLkp);

           // LoadingData = false;

            set_ViewPosition(1); // load first record

        }


        private void frmTraverseCalc_Load(object sender, EventArgs e)
        {
                        
//
        }

        public void prepare_dgvSetup()
        {   //add 3 rows bs, st, fs
            dgvSetup.Rows.Add();//bs  
            dgvSetup.Rows.Add();//st
            dgvSetup.Rows.Add();//fs

            dgvSetup.Rows[rBS].Cells["Type"].Value = "BS";
            dgvSetup.Rows[rST].Cells["Type"].Value = "ST";
            dgvSetup.Rows[rFS].Cells["Type"].Value = "FS";

            dgvSetup.RowCount =3;
        }


        private void set_dgvSetupRow(DataView v,string Peg, int r)
        {//dr["LP"].ToString()
            dgvSetup.Rows[r].Cells["Peg"].Value = Peg;

            dgvSetup.Rows[rBS].Cells["Type"].Value = "BS";
            dgvSetup.Rows[rST].Cells["Type"].Value = "ST";
            dgvSetup.Rows[rFS].Cells["Type"].Value = "FS";

            if (v.Count > 0) { 

                dgvSetup.Rows[r].Cells["Y"].Value = v[0]["Y"];
                dgvSetup.Rows[r].Cells["X"].Value = v[0]["X"];
                dgvSetup.Rows[r].Cells["Z"].Value = v[0]["Z"];
                dgvSetup.Rows[r].Cells["G"].Value = v[0]["G"];
            }
            else
            {
                dgvSetup.Rows[r].Cells["Y"].Value = "";
                dgvSetup.Rows[r].Cells["X"].Value = "";
                dgvSetup.Rows[r].Cells["Z"].Value = "";
                dgvSetup.Rows[r].Cells["G"].Value = "";
            }

        }

        private void fill_dgvSetup(string bs, string st, string fs)
        {   
            tvBS.RowFilter = "Peg = '" + bs + "'";
            set_dgvSetupRow(tvBS,bs, rBS);
            tvST.RowFilter = "Peg = '" + st + "'";
            set_dgvSetupRow(tvST,st, rST);
            tvFS.RowFilter = "Peg = '" + fs + "'";
            set_dgvSetupRow(tvFS,fs, rFS);

            tvbfw[0]["bsid"] = tvBS[0]["pcid"]; //Pegs ID's
            tvbfw[0]["stid"] = tvST[0]["pcid"];
            tvbfw[0]["fsid"] = tvFS[0]["pcid"];

            tvbfw[0]["BSPegID"] = tvBS[0]["PegID"]; //Peg Name ID's
            tvbfw[0]["STPegID"] = tvST[0]["PegID"];
            tvbfw[0]["FSPegID"] = tvFS[0]["PegID"];

            lblSurvey.Text = bs + " -> " + st + " -> " + fs;
        }

        public void fill_bfw()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = tvbfw;
            CommonDGV.Set_DBGridColumns(this.dataGridView1);
        }

        public void fill_Hor()
        {
            dgvHor.AutoGenerateColumns = false;
            CommonDGV.LinkTableToGridColumns(tvHor, dgvHor);
            dgvHor.DataSource = tvHor;
            CommonDGV.Set_DBGridColumns(this.dgvHor);
        }

        public void fill_Vert()
        {
            dgvVert.AutoGenerateColumns = false;
            CommonDGV.LinkTableToGridColumns(tvVert, dgvVert);
            dgvVert.DataSource = tvVert;
            CommonDGV.Set_DBGridColumns(this.dgvVert);
        }

        public void add_pcid(int pcid)
        {
            dmMain.AddToBin(tPeg, "v_pc", "pcid = " + pcid.ToString(), 1, 1,1);
        }

        public void add_bcid(int prevID, DataClass.Base2 b,DataClass.PegYXZ newpeg)
        {

            //Add Base

            tbfw.Rows.Add();
            int r = tbfw.Rows.Count - 1;
            int binID = tbfw.Rows.Count;
            if (prevID < 0)
            {
                prevID = binID;
            }

            //order
            tbfw.Rows[r]["binID"] = binID;
            tbfw.Rows[r]["prevID"] = prevID;
            tbfw.Rows[r]["Ord"] = 1;

            //new Peg
            tbfw.Rows[r]["MTID"] = newpeg.MTID;

            tbfw.Rows[r]["FS"] = newpeg.Peg;
            tbfw.Rows[r]["FSID"] = 0;
            tbfw.Rows[r]["FSPegID"] = 0;

            tbfw.Rows[r]["CCID"] = ccid; //traverse calc function id = 5
            tbfw.Rows[r]["LP"] = newpeg.LP;
            tbfw.Rows[r]["AUID"] = GlobalLogon.AUID;

            //carry from old
            tbfw.Rows[r]["CID"] = b.CID; //class
            tbfw.Rows[r]["Grade"] = b.Grade;
            tbfw.Rows[r]["GradeTypeID"] = b.GradeTypeID;
            
            cboGradeType.SelectedIndex  = b.GradeTypeID;


            //Existing Base
            tbfw.Rows[r]["BS"] = b.ST;
            tbfw.Rows[r]["BSID"] = b.STID;
            tbfw.Rows[r]["BSPegID"] = b.STPegID;
            
            tbfw.Rows[r]["ST"] = b.FS;
            tbfw.Rows[r]["STID"] = b.FSID;
            tbfw.Rows[r]["STPegID"] = b.FSPegID;
            tbfw.Rows[r]["InstrHgt"] = 0;

            tbfw.Rows[r]["BSED"] = b.polar.ED;
            tbfw.Rows[r]["BSHD"] = b.polar.HD;
            tbfw.Rows[r]["BSBear"] = b.polar.Bear;
            tbfw.Rows[r]["BSBearR"] = b.polar.Bear180();

            //Zeros for new base
            tbfw.Rows[r]["HAFL"] = 0;
            tbfw.Rows[r]["HAFR"] = 0;
            tbfw.Rows[r]["FSBear"] = 0;
            tbfw.Rows[r]["FSBearR"] = 0;
            tbfw.Rows[r]["FSHD"] = 0;
            tbfw.Rows[r]["FSED"] = 0;
            
            tbfw.Rows[r]["EID"] = 0;
            tbfw.Rows[r]["BLogID"] = 0;
            
            tbfw.Rows[r]["CCnt"] = 0;
            tbfw.Rows[r]["BSEDErr"] = 0;
            tbfw.Rows[r]["BSHDErr"] = 0;
            tbfw.Rows[r]["HAFLErr"] = 0;
            tbfw.Rows[r]["HAFRErr"] = 0;
            tbfw.Rows[r]["FSHDErr"] = 0;
            tbfw.Rows[r]["FSEDErr"] = 0;
            tbfw.Rows[r]["BSCnt"] = 0;
            tbfw.Rows[r]["ArcCnt"] = 0;
            tbfw.Rows[r]["FSCnt"] = 0;
            tbfw.Rows[r]["BaseID"] = 0; //new base

            //Add FS Peg

            add_New_FSPeg(tbfw.Rows[r]);

            fill_dgvSetup(tbfw.Rows[r]["BS"].ToString(), tbfw.Rows[r]["ST"].ToString(), tbfw.Rows[r]["FS"].ToString());
        }


        private void add_New_FSPeg(DataRow BaseRec)
        {
            DataRow r = tPeg.Rows.Add();

            dgvSetup.Rows[rFS].Cells["Type"].Value = "FS";

            r["pcid"] = BaseRec["FSID"];
            r["PegID"] = BaseRec["FSPegID"];
            r["Peg"] = BaseRec["FS"];
            r["X"] = System.DBNull.Value;
            r["Y"] = System.DBNull.Value;
            r["Z"] = System.DBNull.Value;
            r["G"] = System.DBNull.Value;
            r["MTID"] = BaseRec["MTID"];
            r["LP"] = BaseRec["LP"];
         //   r["MineID"] = BaseRec["MineID"];
         //   r["TravID"] = BaseRec["TravID"];
         //   r["Mine"] = BaseRec["Mine"];
         //   r["Trav"] = BaseRec["Trav"];

            //order
            r["binID"] = BaseRec["binID"];
            r["prevID"] = BaseRec["prevID"];
            r["Ord"] = BaseRec["Ord"];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }





        private void button4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(vbfw[0]["InstrHgt"].ToString());
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveTmp_Click(object sender, EventArgs e)
        {
            save_TmpTables();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVert_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddArc_Click(object sender, EventArgs e)
        {
            tHor.Rows.Add();
            int r = tHor.Rows.Count - 1;
            tHor.Rows[r]["BinID"] = BinID;
            int o = tvHor.Count;
            tHor.Rows[r]["Ord"] = o;
            tHor.Rows[r]["ATag"] = 0;
        }

 

        private void calc_Horizontal()
        {
            if (LoadingData)
            {
                return;
            }
            //loop through current view
            //get values
            //calculate - update - temp store 
            //update summary 
            
            List<double> lsHAFL = new List<double>();
            List<double> lsHAFR = new List<double>();

            double HAFLAve = 0;
            double HAFRAve = 0;
            double HAFLErr = 0;
            double HAFRErr = 0;
            double Adj = 0;
            double HAFL = 0;
            double HAFR = 0;

            //Horizontal fieldwork 
            string SearchStr = "BinID = "+BinID.ToString();
            DataRow[] Rows;
            Rows = tHor.Select(SearchStr);

            //Horizontal fieldwork 
            DataRow[] RowSum;
            
            RowSum = tHorSum.Select(SearchStr);
            if (RowSum.Count() < 1) {
                DataRow rhs = tHorSum.Rows.Add();
                rhs["BinID"] = BinID;//should be one row 
                //tHorSum.Rows[0]["BinID"]=BinID;//should be one row
            }

            RowSum = tHorSum.Select(SearchStr);

            // MessageBox.Show(RowSum.Count().ToString());

            // Fieldwork
            foreach (DataRow r in Rows ) //row in hor table
            {
                if ((r["HAFL1"] != null) && (r["HAFL2"] != null))
                {
                    r["HAFL"] = CommonStr.ConvertDecToDMS(CalcClass.CalcHAFL(CommonStr.ConvertDMSToDec(r["HAFL1"].ToString()), CommonStr.ConvertDMSToDec(r["HAFL2"].ToString())));
                    lsHAFL.Add(CommonStr.ConvertDMSToDec(r["HAFL"].ToString()));
                
                }
                else
                {
                    r["HAFL"] = null;
                }
                if ((r["HAFR1"] != null) && (r["HAFR2"] != null))
                {
                    r["HAFR"] = CommonStr.ConvertDecToDMS(CalcClass.CalcHAFL(CommonStr.ConvertDMSToDec(r["HAFR2"].ToString()), CommonStr.ConvertDMSToDec(r["HAFR1"].ToString())));
                    lsHAFR.Add(CommonStr.ConvertDMSToDec(r["HAFR"].ToString()));
 
                }
                else
                {
                    r["HAFR"] = null;
                }

                if ((r["HAFL"] != null) && (r["HAFR"] != null))
                {
                    r["HAErr"] = CommonStr.ConvertDecToDMS((CommonStr.s2d(r["HAFL"].ToString()) + CommonStr.s2d((r["HAFR"].ToString()))) - 360);
                    r["ATag"] = 1;
                }
                else
                {
                    r["HAErr"] = null;
                    r["ATag"] = 0;
                }
            }
            //Summary
            
            //Work with a dec angles
            CalcClass.calc_ListAveAndErr_Dbl(lsHAFL, out HAFLAve, out HAFLErr);//send dec in
            CalcClass.calc_ListAveAndErr_Dbl(lsHAFR, out HAFRAve, out HAFRErr);//send dec in
          
            if ((HAFLAve > 0) && (HAFRAve > 0))  
            {
                Adj = (360 - (HAFLAve + HAFRAve)) / 2;
            }
            else
            {
                Adj = 0;
            }
            if ((HAFLAve > 0)) // need at least HAFL
            {
                HAFL = HAFLAve + Adj;
                HAFR = HAFRAve + Adj;
                if (HAFR == 0)
                {
                    HAFR = 360 - HAFL; 
                }

                
            }
            //fill summary
            RowSum[0]["BinID"] = BinID;
            RowSum[0]["HAFLCnt"] = lsHAFL.Count;
            RowSum[0]["HAFRCnt"] = lsHAFR.Count;
            RowSum[0]["HAFL"] = CommonStr.ConvertDecToDMS(HAFL);
            RowSum[0]["HAFR"] = CommonStr.ConvertDecToDMS(HAFR);
            RowSum[0]["HAFLAve"] = CommonStr.ConvertDecToDMS(HAFLAve);
            RowSum[0]["HAFRAve"] = CommonStr.ConvertDecToDMS(HAFRAve);
            RowSum[0]["HAFLErr"] = CommonStr.ConvertDecToDMS(HAFLErr);
            RowSum[0]["HAFRErr"] = CommonStr.ConvertDecToDMS(HAFRErr);
            RowSum[0]["HAFRErr"] = CommonStr.ConvertDecToDMS(HAFRErr);
            RowSum[0]["HACorr"] = CommonStr.ConvertDecToDMS(Adj);

            set_ViewPosition(BinID);
            dgvHor.Update();
            dgvHor.Refresh();

            if(!Busy_CalcBtnClicked)//Calc will calculate it later
                calc_Coords();
        }

        public void calc_Coords(bool ShowMsg=false)
        {
            if (LoadingData) {
                return;
            }

            if (Busy_calc_Coords==true) {
                return;
            }
 
            if ((tvbfw.Count>0)&&(tvHorSum.Count>0)&&(tvST.Count>0)&&(tvVertSum.Count>0))
            {
                Busy_calc_Coords = true;
                try
                {
                    double BSBear = CommonStr.ConvertDMSToDec(tvbfw[0]["BSBear"].ToString());
                    double HAFL = CommonStr.ConvertDMSToDec(tvHorSum[0]["HAFL"].ToString());
                    double HAFR = CommonStr.ConvertDMSToDec(tvHorSum[0]["HAFR"].ToString());
                    double FSBear = CalcClass.Ang360(BSBear + HAFL);
                    double HD = CommonStr.s2d(tvVertSum[0]["FSHD"].ToString());
                    double ED = CommonStr.s2d(tvVertSum[0]["FSED"].ToString());
                    double dY = 0, dX = 0, dZ = 0;

                    tvbfw[0]["FSBear"] = FSBear;
                    tvbfw[0]["FSBearR"] = CalcClass.Ang360(FSBear - 180);
                    tvbfw[0]["FSED"] = tvVertSum[0]["FSED"].ToString();
                    tvbfw[0]["FSHD"] = tvVertSum[0]["FSHD"].ToString();

                    tvbfw[0]["BSEDErr"] = tvVertSum[0]["BSEDErr"].ToString();
                    tvbfw[0]["BSHDErr"] = tvVertSum[0]["BSHDErr"].ToString();
                    tvbfw[0]["FSEDErr"] = tvVertSum[0]["FSEDErr"].ToString();
                    tvbfw[0]["FSHDErr"] = tvVertSum[0]["FSHDErr"].ToString();

                    tvbfw[0]["HAFL"] = tvHorSum[0]["HAFL"];
                    tvbfw[0]["HAFR"] = tvHorSum[0]["HAFR"];

                    tvbfw[0]["HAFLErr"] = tvHorSum[0]["HAFLErr"];
                    tvbfw[0]["HAFRErr"] = tvHorSum[0]["HAFRErr"];

                    tvbfw[0]["LP"] = tvFS[0]["LP"];

                    CalcClass.Calc_dYXZ(FSBear, HD, ED, out dY, out dX, out dZ);

                    tvFS[0]["Y"] = CommonStr.s2d(tvST[0]["Y"].ToString()) + dY;
                    tvFS[0]["X"] = CommonStr.s2d(tvST[0]["X"].ToString()) + dX;
                    tvFS[0]["Z"] = CommonStr.s2d(tvST[0]["Z"].ToString()) + dZ;

                    tvFS[0]["EDErr"] = CommonStr.s2d(tvbfw[0]["FSEDErr"].ToString());
                    tvFS[0]["HDErr"] = CommonStr.s2d(tvbfw[0]["FSHDErr"].ToString());
                    tvFS[0]["HAErr"] = CommonStr.s2d(tvbfw[0]["HAFLErr"].ToString());

                    tvFS[0]["CCID"] = CommonStr.s2i(tvbfw[0]["CCID"].ToString());
                    tvFS[0]["CCNT"] = CommonStr.s2i(tvbfw[0]["CCNT"].ToString());
                    tvFS[0]["CID"] = CommonStr.s2i(tvbfw[0]["CID"].ToString());
                    tvFS[0]["EID"] = CommonStr.s2i(tvbfw[0]["EID"].ToString());  // ??? needs to be after the calc
                    tvFS[0]["AUID"] = CommonStr.s2i(tvbfw[0]["AUID"].ToString());

                    set_dgvSetupRow(tvFS, tvFS[0]["Peg"].ToString(), rFS);

                    calc_Grade();
                    calc_PlottingPoints();
                    calc_LPChains();

                    // set all peg following to calculated false
                    foreach (DataRow r in tbfw.Rows)
                    {
                        if (CommonStr.s2i(r["BinID"].ToString()) > BinID)
                        {
                            r["Calculated"] = 0;
                        }
                    }
                }
                finally
                {
                    Busy_calc_Coords = false;
                }
            }

            fill_ClassLimits(ShowMsg);

        }

        private void fill_ClassLimits(bool ShowMsg=false)
        {
            int FailCnt = 0;
            tvbfw[0]["Calculated"] = 0; //false
            tvFS[0]["Calculated"] = 0; //false
            System.Drawing.Color c = System.Drawing.Color.Black;
            
            if ((vClass.Count>0) &&(tvHorSum.Count>0) && (tvVertSum.Count > 0))
            {
                //Horizontal Limits
                double HAFLErr = CommonStr.s2d(tvHorSum[0]["HAFLErr"].ToString());
                double HAFRErr = CommonStr.s2d(tvHorSum[0]["HAFRErr"].ToString());
                int HAFLCnt = CommonStr.s2i(tvHorSum[0]["HAFLCnt"].ToString());
                int HAFRCnt = CommonStr.s2i(tvHorSum[0]["HAFRCnt"].ToString());
                double HALimit = CommonStr.s2d(vClass[0]["HALimit"].ToString());
                int ArcCnt = CommonStr.s2i(vClass[0]["ArcCnt"].ToString());
                //angles already in DMS
                lblHAFLErr.Text = CommonStr.a2s(HAFLErr);
                lblHAFRErr.Text = CommonStr.a2s(HAFRErr);
                lblHAFLCnt.Text = HAFLCnt.ToString();
                lblHAFRCnt.Text = HAFRCnt.ToString();

                lblHAFLErrLim.Text = CommonStr.a2s(HALimit);
                lblHAFRErrLim.Text = CommonStr.a2s(HALimit);
                lblHAFLCntLim.Text = ArcCnt.ToString();
                lblHAFRCntLim.Text = ArcCnt.ToString();

                lblHAFLErrPass.Text = CommonStr.ErrPass(HALimit, HAFLErr, ref FailCnt, out c); lblHAFLErrPass.ForeColor = c;
                lblHAFRErrPass.Text = CommonStr.ErrPass(HALimit, HAFRErr, ref FailCnt, out c); lblHAFRErrPass.ForeColor = c;
                lblHAFLCntPass.Text = CommonStr.CntPass(ArcCnt, HAFLCnt, ref FailCnt, out c);  lblHAFLCntPass.ForeColor = c;
                lblHAFRCntPass.Text = CommonStr.CntPass(ArcCnt, HAFLCnt, ref FailCnt, out c);  lblHAFRCntPass.ForeColor = c;

                //BS Vertical

                double HDErr = CommonStr.s2d(tvVertSum[0]["BSHDErr"].ToString());
                double EDErr = CommonStr.s2d(tvVertSum[0]["BSEDErr"].ToString());
                int Cnt = CommonStr.s2i(tvVertSum[0]["BSCnt"].ToString());

                double HDErrLim = CommonStr.s2d(vClass[0]["HDLimit"].ToString());
                double EDErrLim = CommonStr.s2d(vClass[0]["EDLimit"].ToString());
                double HDErrRel = CommonStr.s2d(tvVertSum[0]["BSHD"].ToString()) * CommonStr.s2d(vClass[0]["HDRel"].ToString());
                double EDErrRel = CommonStr.s2d(tvVertSum[0]["BSHD"].ToString()) * CommonStr.s2d(vClass[0]["EDRel"].ToString());
                int CntLim = CommonStr.s2i(vClass[0]["BSCnt"].ToString());

                lblBSHDErr.Text = CommonStr.d2s(HDErr);
                lblBSEDErr.Text = CommonStr.d2s(EDErr);
                lblBSHDRel.Text = CommonStr.d2s(HDErr);
                lblBSEDRel.Text = CommonStr.d2s(EDErr);
                lblBSCnt.Text = Cnt.ToString();

                lblBSHDErrLim.Text = CommonStr.d2s(HDErrLim);
                lblBSEDErrLim.Text = CommonStr.d2s(EDErrLim);
                lblBSHDRelLim.Text = CommonStr.d2s(HDErrRel);
                lblBSEDRelLim.Text = CommonStr.d2s(EDErrRel);
                lblBSCntLim.Text = CntLim.ToString();

                CommonStr.ErrPass(HALimit, HAFLErr, ref FailCnt, out c); lblHAFLErrPass.ForeColor = c;

                lblBSHDErrPass.Text = CommonStr.ErrPass(HDErrLim, HDErr, ref FailCnt, out c); lblBSHDErrPass.ForeColor = c;
                lblBSEDErrPass.Text = CommonStr.ErrPass(EDErrLim, EDErr, ref FailCnt, out c); lblBSEDErrPass.ForeColor = c;
                lblBSHDRelPass.Text = CommonStr.ErrPass(HDErrRel, HDErr, ref FailCnt, out c); lblBSHDRelPass.ForeColor = c;
                lblBSEDRelPass.Text = CommonStr.ErrPass(EDErrRel, EDErr, ref FailCnt, out c); lblBSEDRelPass.ForeColor = c;
                lblBSCntPass.Text = CommonStr.CntPass(CntLim, Cnt, ref FailCnt, out c);       lblBSCntPass.ForeColor = c;

                //FS Vertical

                HDErr = CommonStr.s2d(tvVertSum[0]["FSHDErr"].ToString());
                EDErr = CommonStr.s2d(tvVertSum[0]["FSEDErr"].ToString());
                Cnt = CommonStr.s2i(tvVertSum[0]["FSCnt"].ToString());

                HDErrLim = CommonStr.s2d(vClass[0]["HDLimit"].ToString());
                EDErrLim = CommonStr.s2d(vClass[0]["EDLimit"].ToString());
                HDErrRel = CommonStr.s2d(tvVertSum[0]["FSHD"].ToString()) * CommonStr.s2d(vClass[0]["HDRel"].ToString());
                EDErrRel = CommonStr.s2d(tvVertSum[0]["FSHD"].ToString()) * CommonStr.s2d(vClass[0]["EDRel"].ToString());
                CntLim = CommonStr.s2i(vClass[0]["FSCnt"].ToString());

                lblFSHDErr.Text = CommonStr.d2s(HDErr);
                lblFSEDErr.Text = CommonStr.d2s(EDErr);
                lblFSHDRel.Text = CommonStr.d2s(HDErr);
                lblFSEDRel.Text = CommonStr.d2s(EDErr);
                lblFSCnt.Text = Cnt.ToString();

                lblFSHDErrLim.Text = CommonStr.d2s(HDErrLim);
                lblFSEDErrLim.Text = CommonStr.d2s(EDErrLim);
                lblFSHDRelLim.Text = CommonStr.d2s(HDErrRel);
                lblFSEDRelLim.Text = CommonStr.d2s(EDErrRel);
                lblFSCntLim.Text = CntLim.ToString();

                lblFSHDErrPass.Text = CommonStr.ErrPass(HDErrLim, HDErr, ref FailCnt, out c); lblFSHDErrPass.ForeColor = c;
                lblFSEDErrPass.Text = CommonStr.ErrPass(EDErrLim, EDErr, ref FailCnt, out c); lblFSEDErrPass.ForeColor = c;
                lblFSHDRelPass.Text = CommonStr.ErrPass(HDErrRel, HDErr, ref FailCnt, out c); lblFSHDRelPass.ForeColor = c;
                lblFSEDRelPass.Text = CommonStr.ErrPass(EDErrRel, EDErr, ref FailCnt, out c); lblFSEDRelPass.ForeColor = c;
                lblFSCntPass.Text = CommonStr.CntPass(CntLim, Cnt, ref FailCnt, out c);       lblFSCntPass.ForeColor = c;
                
            }
            else
            {
                string na = "n/a";
                c = Color.Blue;
                //Horizontal Limits
                lblHAFLErr.Text = na;
                lblHAFRErr.Text = na;
                lblHAFLCnt.Text = na;
                lblHAFRCnt.Text = na;

                lblHAFLErrLim.Text = na;
                lblHAFRErrLim.Text = na;
                lblHAFLCntLim.Text = na;
                lblHAFRCntLim.Text = na;

                lblHAFLErrPass.Text =na;  lblHAFLErrPass.ForeColor = c;
                lblHAFRErrPass.Text =na;  lblHAFRErrPass.ForeColor = c;
                lblHAFLCntPass.Text =na;  lblHAFLCntPass.ForeColor = c;
                lblHAFRCntPass.Text =na;  lblHAFRCntPass.ForeColor = c;

                //BS Vertical
                lblBSHDErr.Text = na;
                lblBSEDErr.Text = na;
                lblBSHDRel.Text = na;
                lblBSEDRel.Text = na;
                lblBSCnt.Text = na;

                lblBSHDErrLim.Text = na;
                lblBSEDErrLim.Text = na;
                lblBSHDRelLim.Text = na;
                lblBSEDRelLim.Text = na;
                lblBSCntLim.Text   = na;

                lblBSHDErrPass.Text = na; lblBSHDErrPass.ForeColor = c;
                lblBSEDErrPass.Text = na; lblBSEDErrPass.ForeColor = c;
                lblBSHDRelPass.Text = na; lblBSHDRelPass.ForeColor = c;
                lblBSEDRelPass.Text = na; lblBSEDRelPass.ForeColor = c;
                lblBSCntPass.Text   = na; lblBSCntPass.ForeColor = c;                               

                //FS Vertical

                lblFSHDErr.Text = na;
                lblFSEDErr.Text = na;
                lblFSHDRel.Text = na;
                lblFSEDRel.Text = na;
                lblFSCnt.Text = na;

                lblFSHDErrLim.Text = na;
                lblFSEDErrLim.Text = na;
                lblFSHDRelLim.Text = na;
                lblFSEDRelLim.Text = na;
                lblFSCntLim.Text = na;

                lblFSHDErrPass.Text =na; lblFSHDErrPass.ForeColor = c;
                lblFSEDErrPass.Text =na; lblFSEDErrPass.ForeColor = c;
                lblFSHDRelPass.Text =na; lblFSHDRelPass.ForeColor = c;
                lblFSEDRelPass.Text =na; lblFSEDRelPass.ForeColor = c;
                lblFSCntPass.Text = na;  lblFSCntPass.ForeColor = c;

                FailCnt = -1;
            }

            if (FailCnt > 0)
            {
                lblFail.Text = "Fail(" + FailCnt.ToString() + ")";
                lblFail.ForeColor = Color.Red;
                if (ShowMsg)
                {
                    tc1.SelectedIndex = 1;//error tab
                    MessageBox.Show("The calcuation check failed on " + FailCnt.ToString() + " class limit checks", "Calc Limit Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            if (FailCnt == 0)
            { 
                lblFail.Text = "Pass";
                lblFail.ForeColor = Color.Green;
                tvbfw[0]["Calculated"] = 1; //true
                tvFS[0]["Calculated"] = 1; //true
                if (ShowMsg)
                {
                    MessageBox.Show("The calcuation check Passed", "Calc Limit Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                lblFail.Text = "Not Calculated";
                lblFail.ForeColor = Color.Blue;
            }

        }

        private void add_Vert(int VertDirID)
        {
            tVert.Rows.Add();
            int r = tVert.Rows.Count - 1;
            tVert.Rows[r]["BinID"] = BinID;
            int o = tvVert.Count;
            tVert.Rows[r]["Ord"] = o;
            tVert.Rows[r]["VertDirID"] = VertDirID;
            tVert.Rows[r]["InstrHgt"] = tvbfw[0]["InstrHgt"];
            tVert.Rows[r]["ATag"] = 0;
        }

        
        private void btnVert_ST_BS_Click(object sender, EventArgs e)
        {
            add_Vert(1); //ST_BS Back Check
        }

        private void btnVert_BS_ST_Click(object sender, EventArgs e)
        {
            add_Vert(2); //BS_ST Back Check
        }

        private void btn_Vert_ST_FS_Click(object sender, EventArgs e)
        {
            add_Vert(3); //ST_FS Back Check
        }

        private void calc_Vertical()
        {
            //loop through current view
            //get values
            //calculate - update - temp store 
            //update summary 

            if (LoadingData)
            {
                return;
            }

            if (tvbfw.Count == 0)
            {
                return;
            }
            
            List<double> lsBSED = new List<double>();
            List<double> lsBSHD = new List<double>();
            List<double> lsFSED = new List<double>();
            List<double> lsFSHD = new List<double>();

            //Adding Start Base HD and ED 
            lsBSED.Add(CommonStr.s2d(tvbfw[0]["BSED"].ToString()));
            lsBSHD.Add(CommonStr.s2d(tvbfw[0]["BSHD"].ToString()));

            double Dip = 0;
            double Adj = 0;
            double MD = 0; 
            double ED = 0;
            double HD = 0;
            double BobHgt = 0;


            double InstrHgt;
            if (txtInstrHgt.Text == "")
            {
                txtInstrHgt.Text = tvbfw[0]["InstrHgt"].ToString();
                InstrHgt = CommonStr.s2d(txtInstrHgt.Text);
            }
            else
            {
                InstrHgt = CommonStr.s2d(txtInstrHgt.Text);
                tvbfw[0]["InstrHgt"] = InstrHgt;
            }
                      

            //Vert fieldwork 
            string SearchStr = "BinID = " + BinID.ToString();
            DataRow[] Rows;
            Rows = tVert.Select(SearchStr);

            //Vert Summary 
            DataRow[] RowSum;
            RowSum = tVertSum.Select(SearchStr);
            if (RowSum.Count() < 1)
            {
                DataRow rvs = tVertSum.Rows.Add();
                rvs["BinID"] = BinID;//should be one row
            }
            RowSum = tVertSum.Select(SearchStr);

            // Fieldwork
            foreach (DataRow r in Rows) //rows in vert table
            {
                if (r["VertDirID"].ToString().Length > 0)
                {
                    if ((r["VertDirID"].ToString()[0] == '1') || (r["VertDirID"].ToString()[0] == '3'))
                    {  // update instrHgt if setup is at station
                        r["InstrHgt"] = tvbfw[0]["InstrHgt"];
                    }

                    if ((r["VAFL"] != null) && (r["VAFR"] != null) && (r["MD"] != null) && (r["InstrHgt"] != null) && (r["BobHgt"] != null))
                    {
                        Dip = CalcClass.Calc_Dip_From_VAFL(CommonStr.ConvertDMSToDec(r["VAFL"].ToString()), CommonStr.ConvertDMSToDec(r["VAFR"].ToString()), out Adj);
                        MD = CommonStr.s2d(r["MD"].ToString());
                        CalcClass.CalcHDED(Dip, MD, out HD, out ED);
                        InstrHgt = CommonStr.s2d(r["InstrHgt"].ToString());
                        BobHgt = CommonStr.s2d(r["BobHgt"].ToString());
                        ED = InstrHgt + ED + BobHgt;

                        if ((r["VertDirID"].ToString()[0] == '2')) // old vertical in drirection BS to ST
                        {
                            ED = (-1) * ED;
                        }

                        r["ED"] = ED;
                        r["HD"] = HD;
                        r["Dip"] = Dip;
                        r["VAErr"] = Adj;
                        r["ATag"] = 1;

                        if ((r["VertDirID"].ToString()[0] == '1') || (r["VertDirID"].ToString()[0] == '2')) // BS
                        {
                            lsBSED.Add(ED);
                            lsBSHD.Add(HD);
                        }
                        else
                        {
                            lsFSED.Add(ED);
                            lsFSHD.Add(HD);
                        }
                    }
                    else
                    {
                        r["ED"] = null;
                        r["HD"] = null;
                        r["Dip"] = null;
                        r["VAErr"] = null;
                        r["ATag"] = 0;

                    }
                }
            }
            
            //Summary
            //get ave
            double BSHD = 0;
            double BSHDErr = 0;
            double BSED = 0;
            double BSEDErr = 0;
            double FSHD = 0;
            double FSHDErr = 0;
            double FSED = 0;
            double FSEDErr = 0;

            CalcClass.calc_ListAveAndErr_Dbl(lsBSHD, out BSHD, out BSHDErr);
            CalcClass.calc_ListAveAndErr_Dbl(lsBSED, out BSED, out BSEDErr);
            CalcClass.calc_ListAveAndErr_Dbl(lsFSHD, out FSHD, out FSHDErr);
            CalcClass.calc_ListAveAndErr_Dbl(lsFSED, out FSED, out FSEDErr);

            //fill summary
            RowSum[0]["BinID"] = BinID;
            RowSum[0]["BSCnt"] = lsBSED.Count();
            RowSum[0]["BSHD"] = BSHD;
            RowSum[0]["BSED"] = BSED;
            RowSum[0]["BSHDErr"] = BSHDErr;
            RowSum[0]["BSEDErr"] = BSEDErr;
            RowSum[0]["FSCnt"] = lsFSED.Count();
            RowSum[0]["FSHD"] = FSHD;
            RowSum[0]["FSED"] = FSED;
            RowSum[0]["FSHDErr"] = FSHDErr;
            RowSum[0]["FSEDErr"] = FSEDErr;

            set_ViewPosition(BinID);
            dgvVert.Update();
            dgvVert.Refresh();
            if(!Busy_CalcBtnClicked) //Calc will call it later
                calc_Coords();
            
            
        }

        private void calc_Grade()
        {
            double Grade = CommonStr.s2d(txtGrade.Text);
            double FSG = CommonStr.s2d(tvFS[0]["Z"].ToString()); //default
            tvFS[0]["G"] = FSG;    //Z Grade default 

            double BSBear = CommonStr.ConvertDMSToDec(tvbfw[0]["BSBear"].ToString());
            double HAFL = CommonStr.ConvertDMSToDec(tvHorSum[0]["HAFL"].ToString());
            double FSBear = CalcClass.Ang360(BSBear + HAFL);

            double FSHD = CommonStr.s2d(tvVertSum[0]["FSHD"].ToString());
            double FSED = CommonStr.s2d(tvVertSum[0]["FSED"].ToString());
            
            double STY = CommonStr.s2d(tvST[0]["Y"].ToString());//default to fs coords
            double STX = CommonStr.s2d(tvST[0]["X"].ToString());
            double STZ = CommonStr.s2d(tvST[0]["Z"].ToString());
            double STG = CommonStr.s2d(tvST[0]["G"].ToString());

            if ((txtSTN_G.Text == "")&&(Math.Abs(STG)>0))//no stn grade filled in, but db has value
            {
                txtSTN_G.Text = STG.ToString();
            }

            if ((txtSTN_G.Text != "") && (Math.Abs(STG) == 0))//no stg db value, but text value filled in
            {
                STG = CommonStr.s2d(txtSTN_G.Text);
                tvST[0]["G"] = STG;
            }

            if (cboGradeType.Items.Count == 0) //no grade type selected
            {
                return;
            }
            if (lsGTID==null) // no grade types loaded
            {
                return;
            }
            if (tvFS.Count == 0) //no fs peg
            {
                return;
            }
            if (txtSTN_G.Text == "")//no stn grade
            {
                return;
            }

            if (tvVertSum.Count == 0) // no vert summary
            {
                return;
            }
             
            if (tvVertSum.Count == 1)  // if vert summary continue with grade
            {
               
             
                double dG = CalcClass.CalcGrade(lsGTID[cboGradeType.SelectedIndex], Grade, FSHD);
                FSG = STG + dG;
                tvFS[0]["G"] = FSG;
                
                set_dgvSetupRow(tvST, tvST[0]["Peg"].ToString(), rST);
                set_dgvSetupRow(tvFS, tvFS[0]["Peg"].ToString(), rFS);
                
            }

        }


        private void calc_PlottingPoints()
        {


            double BSBear = CommonStr.ConvertDMSToDec(tvbfw[0]["BSBear"].ToString());
            double HAFL = CommonStr.ConvertDMSToDec(tvHorSum[0]["HAFL"].ToString());
            double FSBear = CalcClass.Ang360(BSBear + HAFL);

            double FSHD = CommonStr.s2d(tvVertSum[0]["FSHD"].ToString());
            double FSED = CommonStr.s2d(tvVertSum[0]["FSED"].ToString());
            double dY, dX, dZ = 0;

            double STY = CommonStr.s2d(tvST[0]["Y"].ToString());//default to fs coords
            double STX = CommonStr.s2d(tvST[0]["X"].ToString());
            double STZ = CommonStr.s2d(tvST[0]["Z"].ToString());
            double STG = CommonStr.s2d(tvST[0]["G"].ToString());

            tvbfw[0]["PPnt1"] = 0;// Plotting Points
            tvbfw[0]["PPnt1Y"] = tvFS[0]["Y"];//default to fs coords
            tvbfw[0]["PPnt1X"] = tvFS[0]["X"];
            tvbfw[0]["PPnt1Z"] = tvFS[0]["Z"];

            double PPnt1 = CommonStr.s2d(txtPlottingPnt.Text);  // Plotting Point Distance
            if (PPnt1 > 0) //Calc y x z  
            {
                CalcClass.Calc_dYXZ(FSBear, FSHD, FSED, PPnt1, out dY, out dX, out dZ);
                tvbfw[0]["PPnt1Y"] = STY + dY;//default to fs coords
                tvbfw[0]["PPnt1X"] = STX + dX;
                tvbfw[0]["PPnt1Z"] = STZ + dZ;
            }

        }

        private void calc_LPChains()
        {

            double STZ = CommonStr.s2d(tvST[0]["Z"].ToString());
            double STG = CommonStr.s2d(tvST[0]["G"].ToString());

            double FSZ = CommonStr.s2d(tvFS[0]["Z"].ToString());
            double FSG = CommonStr.s2d(tvFS[0]["G"].ToString());


            tvST[0]["Chain"] = STZ - STG;//FS Chain Lenght  Z - G
            tvFS[0]["Chain"] = FSZ - FSG;//FS Chain Lenght  Z - G

            double STChainAdj = CommonStr.s2d(txtSTChainAdj.Text); // Adjusted Chain Lenght

            tvbfw[0]["STChainAdj"] = STChainAdj; // Adjusted Chain Lenght
            tvbfw[0]["FSChainAdj"] = (STZ - STG) - (FSZ - FSG) + STChainAdj; // (STChain -  FSChain) + STChainAdj//Adjusted Chain Lenght
        }




        private void dgvHor_KeyDown(object sender, KeyEventArgs e)
        {
            CommonDGV.KeyDown(sender, e);
        }

        private void dgvHor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (MouseButtons != 0) return;
            CommonDGV.CellEndEdit(sender, e);
            calc_Horizontal();
        }

        private void dgvVert_KeyDown(object sender, KeyEventArgs e)
        {
            CommonDGV.KeyDown(sender, e);
        }

        private void dgvVert_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (MouseButtons != 0) return;
            CommonDGV.CellEndEdit(sender, e);
            calc_Vertical();
        }

        private void txtInstrHgt_TextChanged(object sender, EventArgs e)
        {
            if (tvbfw.Count > 0)
            {
                calc_Vertical();
            }
        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {
            if (tvbfw.Count > 0)
            {
                calc_Coords();
            }
        }

        private void cboGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tvbfw.Count > 0)
            {
                tvbfw[0]["GradeTypeID"] = cboGradeType.SelectedIndex;
                calc_Coords();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Delete Temp Traverse Calculations","Empty Temp Tables",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }
            clear_TmpTables();
            dlgSelectBase dlg = new dlgSelectBase();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(dlg.p1.pcid.ToString());
                MessageBox.Show("Base Selected");

                add_pcid(dlg.p1.pcid);
                add_pcid(dlg.p2.pcid);
                add_bcid(-1,dlg.bs, dlg.p3);
                
            }
            dlg.Dispose();
        }

        private void txtSTN_G_TextChanged(object sender, EventArgs e)
        {
            if (tvbfw.Count > 0)
            { 
                calc_Coords();
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (find_BSST_BaseData()) 
            {
                Busy_CalcBtnClicked = true;
                try
                {
                    calc_Horizontal();
                    calc_Vertical();
                    calc_Coords(ShowClassLimitFail);
                }
                finally {
                    Busy_CalcBtnClicked = false;
                }

            }
        }

        private bool find_BSST_BaseData()
        {   //Need to update data
            //Peg BS ST 
            //will always be current, //when open TC interface, current will be in bin tables and calcs will keep bin current
            //Find Base BS ST 
            //Starting Base will be correct.  if BinID=1 then continue else
            //Following bases might not be. 
            //Check the previous base PrevID
            //bool result = false;
            int PrevID = CommonStr.s2i(tvbfw[0]["PrevID"].ToString());
            int BinID = CommonStr.s2i(tvbfw[0]["BinID"].ToString());
            string BS = tvbfw[0]["BS"].ToString();
            string ST = tvbfw[0]["ST"].ToString();
            DataClass.Base2 base2 = new DataClass.Base2(); //store returned base info 
            if (CommonStr.s2i(tvbfw[0]["BinID"].ToString()) == 1)
            {
                return true;//first base
            }
            else
            {
                //check if base calculated
                foreach (DataRow r in tbfw.Rows)
                    if (CommonStr.s2i(r["BinID"].ToString()) == PrevID)
                    {
                        if (CommonStr.s2i(r["Calculated"].ToString()) != 1)
                        {
                            MessageBox.Show("Prev Base not calculated", "Peg Calculation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }//calculated, get the lastest base info
                    }
                //find bs st detail
                if (dmMain.Find_Bin_BSSTN_Base(BS, ST, BinID, tbfw, base2))
                {
                    tvbfw[0]["BSED"] = base2.polar.ED;
                    tvbfw[0]["BSHD"] = base2.polar.HD;
                    tvbfw[0]["BSBear"] = base2.polar.Bear;
                    tvbfw[0]["BSBearR"] = base2.polar.Bear180();
                    return true;
                }
                else
                {
                    MessageBox.Show("Could not Find Base(" + BS + " --> " + ST + ")", "New Peg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //MessageBox.Show("Could not Find Base(" + BS + " --> " + ST + ")(PrevID"+ PrevID.ToString()+ ")", "New Peg", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //return result; //could not find previous base (PrevID)
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tpResults_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tvbfw.Count > 0)
            {
                tvbfw[0]["CID"] = cboClass.SelectedIndex;
                string ClassFilterStr = "cid = " + tvbfw[0]["cid"].ToString();
                vClass.RowFilter = ClassFilterStr;
                fill_ClassLimits();
            }
        }

        private void cmdNewP_Click(object sender, EventArgs e)
        {
            dlgAddNewTravPeg dlg = new dlgAddNewTravPeg();
            dlg.ParentForm = this;
            dlg.LoadCboBS(tPeg,tbfw,lsClassID,lsClassVal,tvST[0]["Peg"].ToString(),tvFS[0]["Peg"].ToString(),vClass[0]["Descr"].ToString());

            //load lsBS_lsST  lsST_lsBS add binID
            //load cboBS with (all pegs)
            //select bs
            //find all connected lsBS_lsST  lsST_lsBS
            //select fs
            //get binID
            //check if reversed 
            //select class
            //select linepeg
            //check if class is higher then base class
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                return;
            }
                
        }

        private void bntNext_Click(object sender, EventArgs e)
        {
            int MaxBinID = tbfw.Rows.Count;
            if(BinID< MaxBinID)
            {
                BinID++;
                set_ViewPosition(BinID);
                
            }
            else
            {
                MessageBox.Show("Last Peg","Traverse Calculation",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }

        private void bntPrev_Click(object sender, EventArgs e)
        {
            
            if (BinID > 1)
            {
                BinID--;
                set_ViewPosition(BinID);
            }
            else
            {
                MessageBox.Show("First Peg", "Traverse Calculation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!AllCalculated(tbfw,"Traverse Pegs"))
            {
                return;
            }
            try
            {
                
                tvbfw = new DataView(tbfw);
                tvBS = new DataView(tPeg);
                tvST = new DataView(tPeg);
                tvFS = new DataView(tPeg);
                tvVert = new DataView(tVert);
                tvVertSum = new DataView(tVertSum);
                tvHor = new DataView(tHor);
                tvHorSum = new DataView(tHorSum);


                frmM.Save_BinLookupVal(ccid,tLkp); //Safe the currently selected values to the bin

                //loop through data
                foreach (DataRow r in tbfw.Rows)
                {
                    string RowFilterStr = "BinID = "+ CommonStr.s2i(r["BinID"].ToString());
                    //set current position
                    //set_ViewPosition(tBinID);

                    
                    tvbfw.RowFilter = RowFilterStr;       //3 base fieldwork
                    // Setup Peg Positiopsm
                    tvBS.RowFilter = "Peg = '" + tvbfw[0]["BS"].ToString() + "'";
                    tvST.RowFilter = "Peg = '" + tvbfw[0]["ST"].ToString() + "'";
                    tvFS.RowFilter = "Peg = '" + tvbfw[0]["FS"].ToString() + "'";
                    // Set the rest
                    tvHor.RowFilter = RowFilterStr;       // horizotals
                    tvHorSum.RowFilter = RowFilterStr;    // horizotals summary
                    tvVert.RowFilter = RowFilterStr;      // vertical
                    tvVertSum.RowFilter = RowFilterStr;   // vertical summary


                    //Save Data
                    // +  FS Peg 

                    string BaseName = tvbfw[0]["BinID"] + " "+ tvbfw[0]["BS"] + " - " + tvbfw[0]["ST"] +" - "+ tvbfw[0]["FS"];

                    //Add Job Data

                    dmMain.IfNullNegOne(tvFS[0], "pcid");  //vFS is the coord of the fore sight 
                    dmMain.IfNullNegOne(tvFS[0], "PegID");

                    //Make sure the BS ID is correct
                    int BSpcid = dmMain.Add_pc(tvBS[0].Row); //Save Peg and Coords
                    int BSPegID = dmMain.Get_PegNameID(tvBS[0]["Peg"].ToString()); //Get Peg Text Name Coords

                    // + + Get New Peg Version
                    tvBS[0]["pcid"] = BSpcid; //Coords ID 
                    tvBS[0]["PegID"] = BSPegID; // Text Name ID

                    tvbfw[0]["BSID"] = BSpcid;
                    tvbfw[0]["BSPegID"] = BSPegID;


                    //Make sure the BS ID is correct
                    int STpcid = dmMain.Add_pc(tvST[0].Row); //Save Peg and Coords
                    int STPegID = dmMain.Get_PegNameID(tvST[0]["Peg"].ToString()); //Get Peg Text Name Coords

                    // + + Get New Peg Version
                    tvST[0]["pcid"] = STpcid; //Coords ID 
                    tvST[0]["PegID"] = STPegID; // Text Name ID

                    tvbfw[0]["STID"] = STpcid;
                    tvbfw[0]["STPegID"] = STPegID;


                    //Make sure the BS ID is correct
                    int FSpcid = dmMain.Add_pc(tvFS[0].Row); //Save Peg and Coords
                    int FSPegID = dmMain.Get_PegNameID(tvFS[0]["Peg"].ToString()); //Get Peg Text Name Coords
                                        
                    // + + Get New Peg Version
                    tvFS[0]["pcid"] = FSpcid; //Coords ID 
                    tvFS[0]["PegID"] = FSPegID; // Text Name ID

                    tvbfw[0]["FSID"] = FSpcid;
                    tvbfw[0]["FSPegID"] = FSPegID;

                    dmMain.IfNullNegOne(tvbfw[0], "FSPegID");
                    // +  Base Data
                    // + + Get New Base Version ???

                    int BaseID = dmMain.Add_BasePegs(CommonStr.s2i(tvbfw[0]["STPegID"].ToString()), CommonStr.s2i(tvbfw[0]["FSPegID"].ToString()));
                    tvbfw[0]["BaseID"] = BaseID; //Text Name ID

                    int bcid = dmMain.Add_bc(tvbfw[0].Row);  //Polar Coords ID
                    tvbfw[0]["bcid"] = bcid;

                    dmMain.IfNullNegOne(tvbfw[0], "bfwid");

                    // +  Base Fieldwork 
                    int bfwid = dmMain.Add_bfw(tvbfw[0].Row);// qry does not exec and return value
                    tvbfw[0]["bfwid"] = bfwid;

                    // + + Get new Fieldwork version ??
                    // +  Vert - Multiple
                    int vertID = 0;
                    foreach (DataRowView rowView in tvVert)
                    {
                        DataRow row = rowView.Row;
                        row["bfwid"] = bfwid;
                        vertID = dmMain.Add_Vert(bfwid,row);
                    }
                    MessageBox.Show("Table Row Count"+tVertSum.Rows.Count.ToString()+" "+ BaseName);
                    MessageBox.Show("View Row Count" + tvVertSum.Count.ToString());

                    // +  Vert Sum - One 
                    tvVertSum[0]["bfwid"] = bfwid;
                    int vertSumID = dmMain.Add_VertSum(bfwid, tvVertSum[0].Row);
                    
                    // +  Hor - Multiple
                    int HorID = 0;
                    foreach (DataRowView rowView in tvHor)
                    {
                        DataRow row = rowView.Row;
                        row["bfwid"] = bfwid;
                        HorID = dmMain.Add_Hor(bfwid, row);
                    }

                    // +  Hor Sum - One
                    tvHorSum[0]["bfwid"] = bfwid;
                    int horSumID = dmMain.Add_HorSum(bfwid, tvHorSum[0].Row);
                    
                    //use the fieldwork id - bfwid
                    int JobInfoID = dmMain.Add_JobInfo(ccid, bfwid, tvBS[0]["Peg"].ToString() + " - " + tvST[0]["Peg"].ToString()+" - "+tvFS[0]["Peg"].ToString());
                    //update the basecontrol  (bc) and pegcontrol (pc) with JobInfo
                    dmMain.Update_Calc_JobInfo(JobInfoID, FSpcid, GlobalLookup.JobInfo_Update_Peg);
                    dmMain.Update_Calc_JobInfo(JobInfoID, bcid, GlobalLookup.JobInfo_Update_Base);


                    // update the JobInfo fields     
                    
                    dmMain.Add_JobInfoData(JobInfoID,tLkp);  // currently selected  // Already Safed to Bin


                }
            }
            finally
            {
                save_TmpTables();
            }
        }

        private bool AllCalculated(DataTable tbl,string FunctionName)
        {
            
            foreach(DataRow r in tbl.Rows)
            {
                if (r["Calculated"].ToString() != "1")
                {
                    MessageBox.Show("All the "+ FunctionName+" were not calculated",FunctionName,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void frmTraverseCalc_Enter(object sender, EventArgs e)
        {
            frmM.set_BinLookupVal(-1, ccid, tLkp);
        }


        private void frmTraverseCalc_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            rptPegCalc rpt = new rptPegCalc();

            //empty print tabel for user id 
            dmMain.EmptyPrintTbl(GlobalLogon.AUID);
            //add new record ids to print
            int bfwid = 0;
            foreach (DataRow r in tbfw.Rows)
            {
                bfwid = CommonStr.s2i(r["bfwid"].ToString());
                dmMain.Add_Print_ID(GlobalLogon.AUID, bfwid);
            }
            //envoke print form
            frmReporting frm = new frmReporting(rpt);
            frm.MdiParent = frmM;
            frm.Show();

        }
    }
}
