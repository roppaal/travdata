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
   
    public partial class frmAddNewBase : Form
    {


        DataClass.PegYXZ st; //Station
        DataClass.PegYXZ fs; //Forsight

        DataClass.Base3 bf;  //base fields
        DataClass.Base3 ExistingBase ;

        public int Read_Val_GUI(int ibcid)
       {
            bf.BCID = ibcid;

            bf.BSID = 0; // join will only need a st and fs
            bf.STID = st.pcid;
            bf.FSID = fs.pcid;
            bf.HAFL = 0;
            bf.HAFR = 0;
            CalcClass.CalcJoinBear(st.coord, fs.coord, bf.sfs, "deg");
            bf.CID = 0; //Class
            bf.EID = 0; //Errors 
            bf.AUID = GlobalLogon.AUID; 
            bf.BLogID = -1;  // get this later
            bf.LP = Math.Max(st.LP,fs.LP); //make a line peg if one peg is a lp
            bf.CCnt = 0;  //Calc Cnt
            bf.Grade = 0;
            bf.GradeTypeID = 0; // no grade
            bf.sbs.EDErr = 0; // no bs
            bf.sbs.HDErr = 0; // no bs
            bf.HAFLErr = 0; // calc bearing diff ????
            bf.HAFRErr = 0; // no ha 
            bf.sfs.HDErr = 0; // calculated, no err
            bf.sfs.EDErr = 0; // calculated, no err
            bf.BSCnt = 0; // no bs 
            bf.ArcCnt = 0; // no arc
            bf.FSCnt = 1; // fs
            bf.BaseID = dmMain.Get_BaseIDbyPegIDs(bf.STID,bf.BSID); // find BaseID ???
            bf.MTID = fs.MTID; // take the fs mine and trav

            if (bf.sfs.BearManual > -1)
            {
                bf.CCID = 2; // join with manual bearing
                bf.HAFLErr = bf.sfs.BearErr;
                bf.sfs.Bear = bf.sfs.BearManual; //Manual Entered Bearing- Seen as the correct one
            }
            else
            {
                bf.CCID = 1; // calculated join
                bf.sfs.Bear = bf.sfs.BearJoin;
            }

            return 1;
        }

        public bool CheckInput()
        {

            if (
                    (1==1)
               
                && (this.txtPeg1.Text.Length > 0)
                && (this.txtPeg2.Text.Length > 0)
                && (st.pcid>0) && (fs.pcid>0)
            )
            {
                return true;
            }
            else
            {
                //MessageBox.Show("Not all the fields have values", "Enter Base Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
 

        public frmAddNewBase()
        {
            InitializeComponent();
        }

        private void frmAddNewBase_Load(object sender, EventArgs e)
        {
            pnlBaseExist.Visible = false;
            bf = new DataClass.Base3();
            ExistingBase = new DataClass.Base3();

            st = new DataClass.PegYXZ();
            fs = new DataClass.PegYXZ();

        }



        private void cboMine_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboTrav_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ExistingBase.BCID > -1) {
                if (GlobalLogon.ULevel < 100)
                {
                    MessageBox.Show("You are not allowed to overwrite an existing base","Duplicate Base",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return; 
                }

                if (MessageBox.Show("Do you want to over write the existing base?", "Duplicate Base", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
                    
            }
            if ((bf.STID > -1) && (bf.FSID>-1))
            {
                if (dmMain.Add_bc(bf) > -1)
                {
                    MessageBox.Show("Base Added");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Base Not Added");
                    this.DialogResult = DialogResult.Cancel;
                }
                
                this.Close();

            }
        }



        private void ClearPeg1(DataClass.PegYXZ p)
        {
            lblPeg1.ForeColor = Color.Black;
            lblMine1.Text = "n/a";
            lblTrav1.Text = "n/a";
            lblPeg1X.Text = "";
            lblPeg1Y.Text = "";
            lblPeg1Z.Text = "";
            lblLP1.Text = "n/a";   
            p.Clear();
        }

        private void ClearPeg2(DataClass.PegYXZ p)
        {
            lblPeg2.ForeColor = Color.Black; 
            lblMine2.Text = "n/a";
            lblTrav2.Text = "n/a";
            lblPeg2X.Text = "";
            lblPeg2Y.Text = "";
            lblPeg2Z.Text = "";
            lblLP2.Text = "n/a";

            p.Clear();
        }
        
        private void ClearBase(DataClass.Base3 b)
        {
            lblBase.ForeColor = Color.Black;
            lblBear.Text = "";
            lblBear180.Text = "";
            lblHD.Text = "";
            lblED.Text = "";
            lblLPB.Text = "no";

            b.clear();
        }


        private void txtPeg1_TextChanged(object sender, EventArgs e)
        {
            ClearPeg1(st);
            ClearBase(bf);

            st.Peg = txtPeg1.Text.Trim();

            if ((st.Peg != ""))
            {
                if (dmMain.Get_PegCoords(st)){

                    lblPeg1.ForeColor = Color.Green;
                    lblMine1.Text = st.Mine;
                    lblTrav1.Text = st.Trav;
                    lblPeg1X.Text = CommonStr.d2s(st.coord.X);
                    lblPeg1Y.Text = CommonStr.d2s(st.coord.Y);
                    lblPeg1Z.Text = CommonStr.d2s(st.coord.Z);
                    lblLP2.Text = CommonStr.LP_Text(st.LP);

                    CalcJoin();

                }
            }

        }

        private void txtPeg2_TextChanged(object sender, EventArgs e)
        {
            ClearPeg2(fs);
            ClearBase(bf);
            
            fs.Peg = txtPeg2.Text.Trim();
            
            if (fs.Peg != "")
            {
                if (dmMain.Get_PegCoords(fs))
                {
                    lblPeg2.ForeColor = Color.Green;

                    lblMine2.Text = fs.Mine;
                    lblTrav2.Text = fs.Trav;
                    lblPeg2X.Text = CommonStr.d2s(fs.coord.X);
                    lblPeg2Y.Text = CommonStr.d2s(fs.coord.Y);
                    lblPeg2Z.Text = CommonStr.d2s(fs.coord.Z);
                    lblLP2.Text = CommonStr.LP_Text(fs.LP);

                    lblMineB.Text = fs.Mine;
                    lblTravB.Text = fs.Trav;
                                       
                    CalcJoin();
                }
            }
        }



        private void CalcJoin()
        {

            if (CheckInput())
            {
                Read_Val_GUI(-1);
                lblBase.ForeColor = Color.Green;
                lblLPB.Text = CommonStr.LP_Text(bf.LP);
                lblBear.Text = CommonStr.ConvertDecToDMS(bf.sfs.Bear);
                lblBear180.Text = CommonStr.ConvertDecToDMS(bf.sfs.Bear180());
                lblHD.Text = CommonStr.d2s(bf.sfs.HD);
                lblED.Text = CommonStr.d2s(bf.sfs.ED);

                CheckIfBaseExists();
            }
        }

        private void CheckIfBaseExists()
        {
            pnlBaseExist.Visible = false;
            ExistingBase.clear();
            if (dmMain.Get_bc3_ByNames(st.Peg, fs.Peg, ExistingBase) > -1)
            {
                pnlBaseExist.Visible = true;

                lblMineEB.Text = ExistingBase.Mine;
                lblTravEB.Text = ExistingBase.Trav;
                lblBearEB.Text = CommonStr.ConvertDecToDMS(ExistingBase.sfs.Bear);
                lblBear180EB.Text = CommonStr.ConvertDecToDMS(ExistingBase.sfs.Bear180());
                lblBearErrEB.Text = CommonStr.ConvertDecToDMS(ExistingBase.HAFLErr);
                lblHDEB.Text = CommonStr.d2s(ExistingBase.sfs.HD);
                lblEDEB.Text = CommonStr.d2s(ExistingBase.sfs.ED);
                lblLPEB.Text = CommonStr.LP_Text(ExistingBase.LP);
            }

        }


        private void txtBear_TextChanged(object sender, EventArgs e)
        {
            if (txtBear.Text.Trim() == "")
            {
                 
                bf.sfs.BearManual = -1;
                bf.sfs.BearErr = 0;
                bf.HAFLErr = bf.sfs.BearErr;
                lblBearErr.Text = "0";
            }
            else
            {
                bf.sfs.BearManual = CommonStr.ConvertDMSToDec(txtBear.Text);
                bf.sfs.BearErr=CalcClass.CalcAngErr(bf.sfs.Bear, bf.sfs.BearManual);
                bf.HAFLErr = bf.sfs.BearErr;
                lblBearErr.Text = CommonStr.ConvertDecToDMS(bf.sfs.BearErr);
            }

        }

        private void lblLPB_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblBearErr_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblED_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblHD_Click(object sender, EventArgs e)
        {

        }

        private void lblHD1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
