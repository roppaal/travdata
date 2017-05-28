using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace TravPeg
{
    public partial class frmMain : Form
    {
        frmTraverseCalc fTraverseCalc; //Traverse Calc Form
        frmPegs fPegs; //Peg List 
        frmBases fBases; //Base List

        public frmMain()
        {
            InitializeComponent();
            create_lkps();
        }
        
        //------------Lookups-------------------------

        private void create_lkps()
        {
            //  http://stackoverflow.com/questions/9861748/adding-button-to-panel-dynamically-and-getting-its-parent-id

            Panel panel;
            ComboBox cbo;
            Label label;
            DateTimePicker dtp;
            TextBox txt;


            int pnlHgt = 35;
            int Left = 1;
            int lblTop = 1;
            int ctrlTop = 15;

            GlobalLookup.lsLkpTypeVal = new List<string>(); 
            GlobalLookup.lsLkpTypeID = new List<int>();
            GlobalLookup.lsLkpDataType = new List<String>();


            List<String> lsLkpVal; List<int> lsLkpID; List<String> lsLkpDataType;


            dmMain.Load_LookUpTypes( GlobalLookup.lsLkpTypeID, GlobalLookup.lsLkpTypeVal,GlobalLookup.lsLkpDataType);

            //Add Panel - to pnlLkp
            //Add Label - to Panel
            //Add DataPicker - to Panel

            //Add Panel - to pnlLkp
            //Add Label - to Panel
            //Add TextBox/Combo - to Panel

            //Link to Function 

            //global veriables (this is only part of the code)

            //need list of active lookup types 

            for (int i = 0; i < GlobalLookup.lsLkpTypeID.Count; i++)
            {
                panel = new Panel();
                pnlLkp.Controls.Add(panel);
                panel.Height = pnlHgt;
                panel.Dock = DockStyle.Top;
                panel.Visible = true;
                panel.Tag = GlobalLookup.lsLkpTypeID[i];

                label = new Label();
                panel.Controls.Add(label);
                label.Tag = GlobalLookup.lsLkpTypeID[i];
                label.Text = GlobalLookup.lsLkpTypeVal[i];
                label.Top = lblTop;
                label.Left = Left;
                label.AutoSize = true;

                if (GlobalLookup.lsLkpDataType[i] == "Combo")
                {
                    cbo = new ComboBox();
                    panel.Controls.Add(cbo);
                    cbo.Tag = GlobalLookup.lsLkpTypeID[i];
                    cbo.Name = GlobalLookup.lsLkpTypeVal[i];
                    cbo.Top = ctrlTop;
                    cbo.Left = Left;
                    cbo.Width = pnlLkp.Width - 2;
                    lsLkpVal = new List<string>(); lsLkpID = new List<int>();
                    dmMain.Load_LookUpValWhere("lkp", "lkpID", "Descr", "lkpTypeID=" + GlobalLookup.lsLkpTypeID[i] + " and ATag=1", lsLkpID, lsLkpVal, true);
                    cbo.DataSource = lsLkpVal;
                }
                else if (GlobalLookup.lsLkpDataType[i] == "Text")
                {
                    txt = new TextBox();
                    panel.Controls.Add(txt);
                    txt.Tag = GlobalLookup.lsLkpTypeID[i];
                    txt.Name = GlobalLookup.lsLkpTypeVal[i];
                    txt.Top = ctrlTop;
                    txt.Left = Left;
                    txt.Width = pnlLkp.Width - 2;
                }
                else if (GlobalLookup.lsLkpDataType[i] == "Date")
                {
                    dtp = new DateTimePicker();
                    panel.Controls.Add(dtp);
                    dtp.Tag = GlobalLookup.lsLkpTypeID[i];
                    dtp.Name = GlobalLookup.lsLkpTypeVal[i];
                    dtp.Top = ctrlTop;
                    dtp.Left = Left;
                    dtp.Width = pnlLkp.Width - 2;
                    dtp.Value = DateTime.Today;
                }
                pnlTitle.Top = 0;
            }

        }

        public void Save_BinLookupVal(int ccid, DataTable tbl)
        {   //Get Values
            if (tbl == null) { return; }
            if (tbl.Rows.Count == 0)
            {
                dmMain.Initiate_LkpTable(ccid, tbl);
            }

            ComboBox cbo;
            TextBox txt;
            DateTimePicker dtp;

            Control c;

            foreach (DataRow r in tbl.Rows)
            {
                Control[] ctrl = pnlLkp.Controls.Find(r["Lookup"].ToString(), true);
                if (ctrl.Length > 0)
                { //found something 
                    c = ctrl[0];
                    if (r["DataType"].ToString() == "Date")
                    {
                        if (c is DateTimePicker)
                        {
                            dtp = (c as DateTimePicker);
                            r["LkpVal"] = dtp.Value.Date;
                        }
                    }
                    else if (r["DataType"].ToString() == "Text")
                    {
                        if (c is TextBox)
                        {
                            txt = (c as TextBox);
                            r["LkpVal"] = txt.Text;
                        }
                    }
                    else if (r["DataType"].ToString() == "Combo")
                    {
                        if (c is ComboBox)
                        {
                            cbo = (c as ComboBox);
                            r["LkpVal"] = cbo.Text;
                            r["LkpID"] = cbo.SelectedIndex;
                        }
                    }
                }
            }

            //Save Values to disk
            dmMain.SaveBinTable( ccid, tbl);
            
        }

        public void set_BinLookupVal(int JobInfoID, int ccid, DataTable tbl, int CalcID = -1, string JobDescr = "")
        {
            if (GlobalLookup.curLkpCCID > -1) //if bin 
            {
                //Save values for previous selected form
                Save_BinLookupVal(GlobalLookup.curLkpCCID, GlobalLookup.curLkpTbl);
            }

            if (tbl == null) { return; }
            //Setup values for the newly selected form
            ComboBox cbo;
            TextBox txt;
            DateTimePicker dtp;
            
            Control c;

            foreach (DataRow r in tbl.Rows)
            {
                Control[] ctrl = pnlLkp.Controls.Find(r["Lookup"].ToString(), true);

                if (ctrl.Length > 0) { //found something 
                    c = ctrl[0];

                    if (r["DataType"].ToString() == "Date")
                    {
                       if (c is DateTimePicker)
                       {
                            dtp = (c as DateTimePicker);
                            if (r["LkpVal"].ToString() == "")//Null
                            {
                                dtp.Value = DateTime.Today;
                            }
                            else
                            {
                                dtp.Value = Convert.ToDateTime(r["LkpVal"].ToString());
                            }
                       }
                    }
                    else if (r["DataType"].ToString() == "Text")
                    {
                        if (c is TextBox)
                        {
                            txt = (c as TextBox);
                            txt.Text = r["LkpVal"].ToString();
                        }
                    }
                    else if (r["DataType"].ToString() == "Combo")
                    {
                        if (c is ComboBox)
                        {
                            cbo = (c as ComboBox);
                            if (r["LkpVal"].ToString() == "") //empty
                            {
                                cbo.SelectedIndex = 0;
                            }
                            else
                            {
                                cbo.SelectedIndex = cbo.Items.IndexOf(r["LkpVal"].ToString());
                            }
                        }
                    }
                }
            }
            //set new current loopkup
            GlobalLookup.curLkpCCID = ccid;
            GlobalLookup.curLkpTbl = tbl;
            GlobalLookup.JobInfoID = JobInfoID;
            GlobalLookup.currCalcID = CalcID;
            GlobalLookup.currJobDescr = JobDescr;

        }

        public void set_LookupVal_Empty(int JobInfoID,int ccid, DataTable tbl, int CalcID =-1, string JobDescr="")
        {

            ComboBox cbo;
            DateTimePicker dtp;
            TextBox txt;

            GlobalLookup.lsLkpTypeVal = new List<string>();
            GlobalLookup.lsLkpTypeID = new List<int>();
            GlobalLookup.lsLkpDataType = new List<String>();
                        
            dmMain.Load_LookUpTypes(GlobalLookup.lsLkpTypeID, GlobalLookup.lsLkpTypeVal, GlobalLookup.lsLkpDataType);

            Control c;

            for (int i = 0; i < GlobalLookup.lsLkpTypeID.Count; i++)
            {
                Control[] ctrl = pnlLkp.Controls.Find(GlobalLookup.lsLkpTypeVal[i], true);

                if (ctrl.Length > 0)
                { //found something 
                    c = ctrl[0];

                    if (GlobalLookup.lsLkpDataType[i] == "Date")
                    {
                        if (c is DateTimePicker)
                        {
                            dtp = (c as DateTimePicker);
                            dtp.Value = DateTime.Today;
                        }
                    }
                    else if (GlobalLookup.lsLkpDataType[i] == "Text")
                    {
                        if (c is TextBox)
                        {
                            txt = (c as TextBox);
                            txt.Text = "";
                        }
                    }
                    else if (GlobalLookup.lsLkpDataType[i] == "Combo")
                    {
                        if (c is ComboBox)
                        {
                           cbo = (c as ComboBox);
                           cbo.SelectedIndex = 0;
                        }
                    }
                }
            }
            //set new current loopkup
            GlobalLookup.curLkpCCID = ccid;
            GlobalLookup.curLkpTbl = tbl;
            GlobalLookup.JobInfoID = JobInfoID;
            GlobalLookup.currCalcID = CalcID;
            GlobalLookup.currJobDescr = JobDescr;

        }

        private void pegsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((fPegs != null) && (fPegs.IsDisposed))
            {
                fPegs = null;
            }

            if (fPegs == null)
            {
                frmPegs fPegs = new frmPegs(this);
                fPegs.MdiParent = this;
                fPegs.Show();
            }
            else
            {
                fPegs.BringToFront();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           

            frmLogon frm = new frmLogon();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                this.Text = "Welcome " + GlobalLogon.FName;
            }
            else
            {
                this.Close();
            }
            frm.Dispose();
        }

        private void BasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((fBases != null) && (fBases.IsDisposed))
            {
                fBases = null;
            }
            if (fBases == null)
            {
                fBases = new frmBases(this);
                fBases.MdiParent = this;
                fBases.Show();
            }
            else
            {
                fBases.BringToFront();
            }
            
        }

        private void traverseSurveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((fTraverseCalc != null) && (fTraverseCalc.IsDisposed))
            {
                fTraverseCalc = null;
            }

            if (fTraverseCalc == null) 
            {   //Create New Form
                fTraverseCalc = new frmTraverseCalc(this);
                fTraverseCalc.LoadingData = true;
                fTraverseCalc.MdiParent = this;
                fTraverseCalc.prepare_dgvSetup();
                if (fTraverseCalc.check_ForBinData()) //if there is already data, load and show the first row
                {
                    fTraverseCalc.load_TmpTables();
                    fTraverseCalc.load_Lkps();
                }
                else                       // load new data
                {
                    dlgSelectBase dlg = new dlgSelectBase();
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show(dlg.p1.pcid.ToString());

                        MessageBox.Show("Base Selected");

                        fTraverseCalc.add_pcid(dlg.p1.pcid);
                        fTraverseCalc.add_pcid(dlg.p2.pcid);
                        fTraverseCalc.add_bcid(-1, dlg.bs, dlg.p3);
                        //frm.Add_Hor(1,1,1);
                        //frm.Add_Vert(1, 1, 1);
                    }
                    dlg.Dispose();

                }
                fTraverseCalc.LoadingData = false;
                fTraverseCalc.calc_Coords(false);
                fTraverseCalc.Show();
            }else
            {
                fTraverseCalc.BringToFront();
            }

            
            
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraverseCalc frm = new frmTraverseCalc(this);
            frm.MdiParent = this;
            frm.add_pcid(1);
            frm.add_pcid(2);
            frm.add_pcid(3);

            frm.Show();
        }

        private void surveyFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptPegList rpt = new rptPegList(); //default - show peg list
            frmReporting frm = new frmReporting(rpt);
            frm.MdiParent = this;
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClass frm = new frmClass();
            frm.MdiParent = this;
            frm.Show();
        }

        private void calculationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalcFunc frm = new frmCalcFunc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lookupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLookups frm = new frmLookups();
            frm.MdiParent = this;
            frm.Show();
        }

        private void assignToCalculationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssignLookupToFunction frm = new frmAssignLookupToFunction();
            frm.MdiParent = this;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            create_lkps();
        }

        public DataTable LoadDataLookup(int ccid,int JobInfoID, int CalcID, string JobDescr)
        {
            // MessageBox.Show(JobInfoID.ToString());
            GlobalLookup.JobInfoID = JobInfoID;
            if (JobInfoID == -1)
            {
                DataTable tbl = dmMain.CreateBinLkpTable(ccid);
                this.set_LookupVal_Empty(JobInfoID, ccid, tbl,CalcID,JobDescr);
                return tbl;
            }
            else
            {
                travdataDataSet.v_JDataDataTable tbl = this.v_JDataTableAdapter.GetDataBy_JobInfoID(JobInfoID);
                set_BinLookupVal(JobInfoID, ccid, tbl, CalcID, JobDescr);
                return tbl;
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void jobInfoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void cmdSaveLkpData_Click(object sender, EventArgs e)
        {

            // CalcID is the ID inside the table eg pcID
            Save_BinLookupVal(GlobalLookup.curLkpCCID, GlobalLookup.curLkpTbl);
            // Get a JobInfo ID
            if ((GlobalLookup.JobInfoID == -1)&& (GlobalLookup.curLkpCCID>-1)&&( GlobalLookup.currCalcID>-1)&&(GlobalLookup.currJobDescr!=""))
            {
                int JobInfoID = dmMain.Add_JobInfo(GlobalLookup.curLkpCCID, GlobalLookup.currCalcID, GlobalLookup.currJobDescr);
                if  (GlobalLookup.curLkpCCID==1) //1 Point -Update Peg List
                {
                    dmMain.Update_Calc_JobInfo(JobInfoID, GlobalLookup.currCalcID, GlobalLookup.JobInfo_Update_Peg);
                }else
                if (GlobalLookup.curLkpCCID == 2) //2 Point -Update Base List
                {
                    dmMain.Update_Calc_JobInfo(JobInfoID, GlobalLookup.currCalcID, GlobalLookup.JobInfo_Update_Base);
                }
                //update user fields
                dmMain.Add_JobInfoData(JobInfoID, GlobalLookup.curLkpTbl);
            }
        }
    }
}
