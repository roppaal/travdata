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
    public partial class dlgSelectBase : Form
    {

        List<string> lsMineVal; List<int> lsMineID;
        List<string> lsTravVal; List<int> lsTravID;
        List<string> lsLPVal; List<int> lsLPID;
        
        public DataClass.PegYXZ p1; //BackSight - peg
        public DataClass.PegYXZ p2; //Station   - peg 
        public DataClass.PegYXZ p3; //Forsight  - peg

        public DataClass.Base2 sf;  //stn to fs - base fields
        public DataClass.Base2 bs;  //bs to stn - base fields

        public dlgSelectBase()
        {
            InitializeComponent();
        }

        private void dlgSelectBase_Load(object sender, EventArgs e)
        {

            lsMineVal = new List<string>(); lsMineID = new List<int>();
            lsTravVal = new List<string>(); lsTravID = new List<int>();
            lsLPVal = new List<string>(); lsLPID = new List<int>();

            bs = new DataClass.Base2();
            sf = new DataClass.Base2();

            p1 = new DataClass.PegYXZ();
            p2 = new DataClass.PegYXZ();
            p3 = new DataClass.PegYXZ();

            Clear_Base_BS(bs);
            Clear_Base_SF(sf);
            Clear_Peg1(p1);
            Clear_Peg2(p2);
            Clear_Peg3(p3);

            dmMain.LoadPegTypes(lsLPID, lsLPVal);
            cboLP.DataSource = lsLPVal;
            cboLP.SelectedIndex = 0;

            dmMain.load_LookUpVal("Mine", "MineID", "Descr", lsMineID, lsMineVal, false);
            cboMine.DataSource = lsMineVal;
            if (cboMine.Items.Count > 0)
            {
                loadTrav(lsMineID[0]);
            }
            else
            {
                MessageBox.Show("No Mines Found", "Load Mines", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool CheckInput()
        {

            if (
                    (1 == 1)

                && (this.txtPeg1.Text.Length > 0)
                && (this.txtPeg2.Text.Length > 0)
                && (this.txtPeg3.Text.Length > 0)
                && (p1.pcid > 0) && (p2.pcid > 0)
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




        private void Clear_Peg1(DataClass.PegYXZ p)
        {
            lblPeg1.ForeColor = Color.Black;
            lblMine1.Text = "n/a";
            lblTrav1.Text = "n/a";
            lblPeg1X.Text = "";
            lblPeg1Y.Text = "";
            lblPeg1Z.Text = "";
            lblLP1.Text = "n/a";
            lblPeg1G.Text = "";
            lblPeg1E.Text = "";
            lblPeg1C.Text = "";
            p.Clear();
        }

        private void Clear_Peg2(DataClass.PegYXZ p)
        {
            lblPeg2.ForeColor = Color.Black;
            lblMine2.Text = "n/a";
            lblTrav2.Text = "n/a";
            lblPeg2X.Text = "";
            lblPeg2Y.Text = "";
            lblPeg2Z.Text = "";
            lblLP2.Text = "n/a";
            lblPeg2G.Text = "";
            lblPeg2E.Text = "";
            lblPeg2C.Text = "";

            p.Clear();
        }

        private void Clear_Peg3(DataClass.PegYXZ p)
        {

            lblPeg3.ForeColor = Color.Green;
            lblPeg3F.Text = "New Peg Not Found";
            lblPeg3F.ForeColor = Color.Green;
            lblMine3.Text = "n/a";
            lblTrav3.Text = "n/a";
            lblPeg3X.Text = "";
            lblPeg3Y.Text = "";
            lblPeg3Z.Text = "";
            lblLP3.Text = "n/a";
            lblPeg3G.Text = "";
            lblPeg3E.Text = "";
            lblPeg3C.Text = "";

            p.Clear();
        }

        private void Clear_Base_SF(DataClass.Base2 b) // stn to fs
        {
            lblBaseSF.ForeColor = Color.Green;
            lblBaseSF.Text = "STN to FS Not Found";
            lblBearSF.Text = "";
            lblBear180SF.Text = "";
            lblHDSF.Text = "";
            lblEDSF.Text = "";
            lblBearErrSF.Text = "";
            lblLPSF.Text = "no";
            lblESF.Text = "";
            lblCSF.Text = "";

            b.clear();
        }

        private void Clear_Base_BS(DataClass.Base2 b) // bs to stn 
        {
            lblBaseBS.ForeColor = Color.Red;
            lblBaseBS.Text = "BS to STN Not Found";
            lblBearBS.Text = "";
            lblBear180BS.Text = "";
            lblHDBS.Text = "";
            lblEDBS.Text = "";
            lblBearErrBS.Text = "";
            lblLPBS.Text = "no";
            lblEBS.Text = "";
            lblCBS.Text = "";
            
            b.clear();
        }

        private void txtPeg1_TextChanged(object sender, EventArgs e)
        {
            Clear_Peg1(p1);
            Clear_Base_BS(bs);

            p1.Peg = txtPeg1.Text.Trim();

            if ((p1.Peg != ""))
            {
                if (dmMain.Get_PegCoords(p1))
                {

                    lblPeg1.ForeColor = Color.Green;
                    lblMine1.Text = p1.Mine;
                    lblTrav1.Text = p1.Trav;
                    lblPeg1X.Text = CommonStr.d2s(p1.coord.X);
                    lblPeg1Y.Text = CommonStr.d2s(p1.coord.Y);
                    lblPeg1Z.Text = CommonStr.d2s(p1.coord.Z);
                    lblLP1.Text = CommonStr.LP_Text(p1.LP);
                    lblPeg3G.Text = CommonStr.d2s(p1.coord.G);
                    lblPeg3E.Text = p1.E;
                    lblPeg3C.Text = p1.C;

                    Check_IfBaseExists_BS();

                }
            }
        }

        private void txtPeg2_TextChanged(object sender, EventArgs e)
        {
            Clear_Peg2(p2);
            Clear_Base_BS(bs);
            Clear_Base_SF(sf);

            p2.Peg = txtPeg2.Text.Trim();

            if (p2.Peg != "")
            {
                if (dmMain.Get_PegCoords(p2))
                {
                    lblPeg2.ForeColor = Color.Green;

                    lblMine2.Text = p2.Mine;
                    lblTrav2.Text = p2.Trav;
                    lblPeg2X.Text = CommonStr.d2s(p2.coord.X);
                    lblPeg2Y.Text = CommonStr.d2s(p2.coord.Y);
                    lblPeg2Z.Text = CommonStr.d2s(p2.coord.Z);
                    lblLP2.Text = CommonStr.LP_Text(p2.LP);
                    lblPeg2G.Text = CommonStr.d2s(p2.coord.G);
                    lblPeg2E.Text = p2.E;
                    lblPeg2C.Text = p2.C;

                    lblMineSF.Text = p2.Mine;
                    lblTravSF.Text = p2.Trav;

                    cboMine.Text = p2.Mine;
                    cboTrav.Text = p2.Trav;

                    Check_IfBaseExists_BS();
                    Check_IfBaseExists_SF();
                }
            }
        }

        private void txtPeg3_TextChanged(object sender, EventArgs e)
        {
            Clear_Peg3(p3);
            Clear_Base_SF(sf);

            p3.Peg = txtPeg3.Text.Trim();
            p3.Mine= lsMineVal[cboMine.SelectedIndex];
            p3.Trav= lsTravVal[cboTrav.SelectedIndex];
            p3.MineID = lsMineID[cboMine.SelectedIndex];
            p3.TravID = lsTravID[cboTrav.SelectedIndex];
            p3.MTID = dmMain.Get_MTID(p3.MineID, p3.TravID);
            
            if ((p3.Peg != ""))
            {
                if (dmMain.Get_PegCoords(p3))
                {

                    lblPeg3.ForeColor = Color.Red;
                    lblPeg3F.ForeColor = Color.Red;
                    lblPeg3F.Text = "New Peg Exists";
                    lblMine3.Text = p3.Mine;
                    lblTrav3.Text = p3.Trav;
                    lblPeg3X.Text = CommonStr.d2s(p3.coord.X);
                    lblPeg3Y.Text = CommonStr.d2s(p3.coord.Y);
                    lblPeg3Z.Text = CommonStr.d2s(p3.coord.Z);
                    lblLP3.Text = CommonStr.LP_Text(p3.LP);
                    lblPeg3G.Text = CommonStr.d2s(p3.coord.G);
                    lblPeg3E.Text = p3.E;
                    lblPeg3C.Text = p3.C;


                    Check_IfBaseExists_SF();

                }
            }
        }

  
        private void loadTrav(int MineID)
        {
            cboTrav.DataSource = null;
            cboTrav.Items.Clear();
            dmMain.Load_LookUpValWhere("v_mt", "TravID", "Trav", "MineID =" + MineID.ToString(), lsTravID, lsTravVal, false);
            cboTrav.DataSource = lsTravVal;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Check_IfBaseExists_BS() // BS ST - Remember to reverse - STN to BS
        {
            
            bs.clear();
            if (dmMain.Get_bc2_ByNames(p2.Peg, p1.Peg, bs) > -1)  // Reverse base???
            {
 

                lblBaseBS.Text = "STN to BS Base Exists";
                lblBaseBS.ForeColor = Color.Green;

                lblMineBS.Text = bs.Mine;
                lblTravBS.Text = bs.Trav;
                lblBearBS.Text = CommonStr.ConvertDecToDMS(bs.polar.Bear);
                lblBear180BS.Text = CommonStr.ConvertDecToDMS(bs.polar.Bear180());
                lblBearErrBS.Text = CommonStr.ConvertDecToDMS(bs.polar.BearErr);
                lblHDBS.Text = CommonStr.d2s(bs.polar.HD);
                lblEDBS.Text = CommonStr.d2s(bs.polar.ED);
                lblLPBS.Text = CommonStr.LP_Text(bs.LP);
                lblEBS.Text = bs.E;
                lblCBS.Text = bs.C;
            }

        }


        private void Check_IfBaseExists_SF() // STN FS
        {
           
            sf.clear();
            if (dmMain.Get_bc2_ByNames(p2.Peg, p3.Peg, sf) > -1)
            {
           
                lblBaseSF.Text = "STN to FS Base Exists";
                lblBaseSF.ForeColor = Color.Red;
                lblMineSF.Text = sf.Mine;
                lblTravSF.Text = sf.Trav;
                lblBearSF.Text = CommonStr.ConvertDecToDMS(sf.polar.Bear);
                lblBear180SF.Text = CommonStr.ConvertDecToDMS(sf.polar.Bear180());
                lblBearErrSF.Text = CommonStr.ConvertDecToDMS(sf.polar.BearErr);
                lblHDSF.Text = CommonStr.d2s(sf.polar.HD);
                lblEDSF.Text = CommonStr.d2s(sf.polar.ED);
                lblLPSF.Text = CommonStr.LP_Text(sf.LP);
                lblESF.Text = sf.E;
                lblCSF.Text = sf.C;

            }

        }

        private void cboMine_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTrav(lsMineID[cboMine.SelectedIndex]);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { string CalcType = "Peg Calclation";

            if ((p1.LP>0) || (p2.LP>0) || (bs.LP > 0))
            {
                MessageBox.Show("Line Pegs and Bases can not start a new survey", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (p1.pcid < 0)  //BackSight does not exist
            {
                MessageBox.Show("Backsight Peg ("+txtPeg1.Text+") not found","Start New "+CalcType,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if ((p1.EID==1)&&(GlobalLogon.ULevel< GlobalLogon.StartFromErrPeg))
            {
                MessageBox.Show("Backsight Peg (" + txtPeg1.Text + ") error status not good enough for the current user level", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((p1.EID > 1) && (GlobalLogon.ULevel < GlobalLogon.SuperUserLevel))
            {
                MessageBox.Show("Backsight Peg (" + txtPeg1.Text + ") error status to big", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (p2.pcid < 0)  //Station does not exist
            {
                MessageBox.Show("Station Peg (" + txtPeg2.Text + ") not found", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((p2.EID == 1) && (GlobalLogon.ULevel < GlobalLogon.StartFromErrPeg))
            {
                MessageBox.Show("Station Peg (" + txtPeg2.Text + ") error status not good enough for the current user level", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((p2.EID > 1) && (GlobalLogon.ULevel < GlobalLogon.SuperUserLevel))
            {
                MessageBox.Show("Station Peg (" + txtPeg2.Text + ") error status to big", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPeg3.Text.Length == 0)
            {
                MessageBox.Show("New Peg Needs a Name", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (p3.pcid > -1) //New Peg Exists
            {
                if (GlobalLogon.ULevel < GlobalLogon.OverWriteExistingPeg)
                {
                    MessageBox.Show("New Peg (" + txtPeg3.Text + ") already exists. User Level and not over write an existing peg", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }else
                {
                    if (MessageBox.Show("New Peg (" + txtPeg3.Text + ") already exists. Do you want to over write the peg?", "Start New " + CalcType, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

            }
            if (bs.BCID<0)
            {
                MessageBox.Show("BS STN Base (" + txtPeg1.Text +" -> "+txtPeg2.Text+ ") not found", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else
            {
                if (((bs.CCID==1)||(bs.CCID==3))&& (GlobalLogon.ULevel < GlobalLogon.StartFromJoinBase)) //manual 2P and 3P bases. (auto calc)
                {
                    MessageBox.Show("User Level can not start from a calculated join base(" + txtPeg1.Text + " -> " + txtPeg2.Text + ") ", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if((bs.EID==1)&&(GlobalLogon.ULevel < GlobalLogon.StartFromErrBase))
                {
                    MessageBox.Show("User Level can not start from an Error base(" + txtPeg1.Text + " -> " + txtPeg2.Text + ") ", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(bs.EID > 1) 
                {
                    MessageBox.Show("Can not start from an Error base(" + txtPeg1.Text + " -> " + txtPeg2.Text + ") ", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                               
            }

            if (sf.BCID > -1)
            {
                if (GlobalLogon.ULevel < GlobalLogon.OverWriteExistingBase)
                {
                    MessageBox.Show("New Base (" + txtPeg2.Text+" -> "+ txtPeg3.Text + ") already exists. User Level and not over write an existing base", "Start New " + CalcType, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (MessageBox.Show("New Base (" + txtPeg2.Text + " -> " + txtPeg3.Text + ") already exists. Do you want to over write the base?", "Start New " + CalcType, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

            }

            MessageBox.Show("Add New Base(" + txtPeg2.Text + " -> " + txtPeg3.Text + ")");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
