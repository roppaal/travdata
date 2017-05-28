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
    
    public partial class frmAddNewPeg : Form
    {
        List<string> lsMineVal; List<int> lsMineID;
        List<string> lsTravVal; List<int> lsTravID;

        Pegflds pf;

        class Pegflds
        {

            public int pcid = -1;
            public int PegID = -1;
            public double X = 0;
            public double Y = 0;
            public double Z = 0;
            public double G = 0;
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
            public int Read_Val_GUI(frmAddNewPeg f, int ipcid)
            {
                pcid = ipcid;
                PegID = dmMain.Get_PegNameID(f.txtPegName.Text);
                X = CommonStr.s2d(f.txtX.Text);
                Y = CommonStr.s2d(f.txtY.Text);
                Z = CommonStr.s2d(f.txtZ.Text);
                G = CommonStr.s2d(f.txtG.Text);
                CCID = 0;
                CID = 0;
                EID = 0;
                AUID = GlobalLogon.AUID;
                PLogID = 0;
                HDErr = 0;
                EDErr = 0;
                HAErr = 0;
                LP = 0;
                CCnt = 0;
                MineID = f.lsMineID[f.cboMine.SelectedIndex];
                TravID = f.lsTravID[f.cboTrav.SelectedIndex];
                MTID = dmMain.Get_MTID(MineID, TravID);

                return PegID;

            }

           

            public int CheckInput(frmAddNewPeg f)
            {

                if (  
                      (f.txtX.Text.Length>0)
                   && (f.txtY.Text.Length>0)
                   && (f.txtZ.Text.Length>0)
                   && (f.txtPegName.Text.Length>0)
                   && (f.cboMine.Text.Length>0)
                   && (f.cboTrav.Text.Length>0)
                   )
                {
                    return 1;
                }
                else
                {
                    MessageBox.Show("Not all the fields have values", "Enter Peg Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
               
            }
        }




//##################################################################3333
        public frmAddNewPeg()
        {
            InitializeComponent();
        }

        private void frmAddNewPeg_Load(object sender, EventArgs e)
        {
            lsMineVal = new List<string>(); lsMineID = new List<int>();
            lsTravVal = new List<string>(); lsTravID = new List<int>();
            pf = new Pegflds();

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

        private void loadTrav(int MineID)
        {
            cboTrav.DataSource = null;
            cboTrav.Items.Clear();
            dmMain.Load_LookUpValWhere("v_mt", "TravID", "Trav", "MineID =" + MineID.ToString(), lsTravID, lsTravVal, false);
            cboTrav.DataSource = lsTravVal;
        }

        private void cboMine_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTrav(lsMineID[cboMine.SelectedIndex]);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int tpcid = 0;
            if ((pf.CheckInput(this) == 1)&&(pf.Read_Val_GUI(this, -1) > -1)) {
                pf.pcid = dmMain.Get_PCID(txtPegName.Text);
                
                tpcid = dmMain.Add_pc(   
                                  pf.pcid
                                , pf.PegID
                                , pf.X
                                , pf.Y
                                , pf.Z
                                , pf.G
                                , pf.CCID
                                , pf.CID
                                , pf.EID
                                , pf.AUID
                                , pf.PLogID
                                , pf.HDErr
                                , pf.EDErr
                                , pf.HAErr
                                , pf.LP
                                , pf.CCnt
                                , pf.MTID
                                 );
                MessageBox.Show("pcid =" + tpcid.ToString(), "pcid");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
