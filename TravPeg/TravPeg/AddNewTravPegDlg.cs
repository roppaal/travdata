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
    public partial class dlgAddNewTravPeg : Form
    {

        DataTable tPeg;
        DataTable tBase;
        List<string> lsClassVal;
        List<int> lsClassID;

        List<int> lsLPID;
        List<string> lsLPVal;

        public frmTraverseCalc ParentForm;


        public dlgAddNewTravPeg()
        {
            InitializeComponent();
            lsLPID = new List<int>();
            lsLPVal = new List<string>();
        }

        private void dlgAddNewTravPeg_Load(object sender, EventArgs e)
        {

        }

        public void LoadCboBS(DataTable dtPeg, DataTable dtbfw, List<int> tlsClassID, List<string> tlsClassVal, string bs, string st,string c)
        {
            tPeg = dtPeg;
            tBase = dtbfw;
            lsClassID = tlsClassID;
            lsClassVal = tlsClassVal;
            cboClass.DataSource = lsClassVal;
            cboClass.SelectedIndex = cboClass.Items.IndexOf(c);

            dmMain.LoadPegTypes(lsLPID, lsLPVal);
            cboLP.DataSource = lsLPVal;
            cboLP.SelectedIndex = 0;

            foreach (DataRow r in tPeg.Rows)
            {
                cboBS.Items.Add(r["Peg"]);
            }
            cboBS.SelectedIndex = cboBS.Items.IndexOf(bs);
            cboST.SelectedIndex = cboST.Items.IndexOf(st);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSTN(cboBS.Text);
        }

        private void addSTN(string ST)
        {
            if (cboST.Items.IndexOf(ST) < 0)
            {
                cboST.Items.Add(ST);
            }
        }

        private void LoadSTN(string BS)
        {
            cboST.Items.Clear();
            foreach (DataRow r in tBase.Rows)
            {
                if (BS == r["BS"].ToString())
                {
                    addSTN(r["ST"].ToString());
                }else
                if (BS == r["ST"].ToString())
                {
                    addSTN(r["FS"].ToString());
                }
                else
                if (BS == r["ST"].ToString())
                {
                    addSTN(r["BS"].ToString());
                }
                else
                if (BS == r["FS"].ToString())
                {
                    addSTN(r["ST"].ToString());
                }

            }
        }

        private bool CheckIfPegExit()
        {
            bool foundPeg = false;
            string FS = txtFS.Text.Trim();
            foreach (DataRow r in tBase.Rows)
            {
                if ((FS == r["BS"].ToString())|| (FS == r["ST"].ToString())|| (FS == r["FS"].ToString()))
                {
                    foundPeg = true;
                }
            }
            return foundPeg;
        }



        private void cmdAdd_Click(object sender, EventArgs e)
        {
            DataClass.Base2 base2 = new DataClass.Base2();
            DataClass.PegYXZ pegxyz = new DataClass.PegYXZ();
            string BS = cboBS.Text;
            string ST = cboST.Text;
            string FS = txtFS.Text;
            string C = cboClass.Text;
            int CID = lsClassID[lsClassVal.IndexOf(C)];
            int CCID = 5; //traverse peg
            int LP = cboLP.SelectedIndex;

            base2.BaseID = -1;
            base2.BCID = -1;
            base2.BFWID = -1;
            base2.ST = BS;
            base2.FS = ST;
            base2.CCID = CCID;
            base2.CID = CID;
            base2.LP = LP;
            int MaxBinID = tBase.Rows.Count + 1;


            if (txtFS.Text.Trim() == "")
            {
                MessageBox.Show("No Foresight Peg Name ", "New Peg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CheckIfPegExit()){
                MessageBox.Show("Peg Name Exist in current calculation", "New Peg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!dmMain.Find_Bin_BSSTN_Base(BS,ST, MaxBinID, tBase, base2))
            {
                MessageBox.Show("Could not Find Base("+BS+" --> "+ST+")", "New Peg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Check if Peg exist in main database

            pegxyz.pcid = - 1;
            pegxyz.PegID = -1;
            pegxyz.Peg = FS;
            pegxyz.CCID = CCID;
            pegxyz.CID = CID;
            pegxyz.AUID = GlobalLogon.AUID;
            pegxyz.LP = LP;
            pegxyz.Mine = base2.Mine;
            pegxyz.MineID = base2.MineID;
            pegxyz.Trav = base2.Trav;
            pegxyz.TravID = base2.TravID;
            pegxyz.MTID = base2.MTID;

            ParentForm.add_bcid(base2.binID, base2, pegxyz);
            
            MessageBox.Show("Add New Base(" + BS + " -> " + ST + " -> " + FS + ")");

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
