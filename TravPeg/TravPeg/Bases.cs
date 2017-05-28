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
    public partial class frmBases : Form
    {
        List<string> lsMineVal; List<int> lsMineID;
        List<string> lsTravVal; List<int> lsTravID;

        private frmMain frmM;
        private int ccid = 2; // (2Points) //base List // table - bc
        private DataTable tLkp;

        public frmBases(frmMain frm)
        {
            InitializeComponent();
            frmM = frm;
        }

        private void bcBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void frmBases_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travdataDataSet.v_Base' table. You can move, or remove it, as needed.
            //this.v_BaseTableAdapter.Fill(this.travdataDataSet.v_Base);
            // TODO: This line of code loads data into the 'travdataDataSet.bc' table. You can move, or remove it, as needed.
            

            CommonDGV.Set_DBGridColumns(this.v_BaseDataGridView);

            lsMineVal = new List<string>(); lsMineID = new List<int>();
            lsTravVal = new List<string>(); lsTravID = new List<int>();

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

        private void LoadData(int MineID, int TravID)
        {
            this.v_BaseTableAdapter.FillByMineTravID(this.travdataDataSet.v_Base,MineID,TravID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTrav_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckMT_and_LoadData();
        }

        private void CheckMT_and_LoadData()
        {
            int MineID = -1;
            int TravID = -1;
            if ((cboMine.Items.Count > 0) && (cboTrav.Items.Count > 0))
            {
                if ((cboMine.SelectedIndex > -1) && (cboTrav.SelectedIndex > -1))
                {
                    MineID = lsMineID[cboMine.SelectedIndex];
                    TravID = lsTravID[cboTrav.SelectedIndex];
                }
            }

            LoadData(MineID, TravID);

        }

        private void cboMine_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTrav(lsMineID[cboMine.SelectedIndex]);
        }

        private void addNewBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewBase frm = new frmAddNewBase();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show("New Base Added");
                CheckMT_and_LoadData();
            }
            frm.Dispose();
        }

        private void v_BaseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void v_BaseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (v_BaseDataGridView.CurrentRow != null)
            {
                

                String JobInfoID = v_BaseDataGridView.CurrentRow.Cells["JobInfoID"].Value.ToString();
                String CalcID = v_BaseDataGridView.CurrentRow.Cells["bcid"].Value.ToString();
                String JobDescr = v_BaseDataGridView.CurrentRow.Cells["BS"].Value.ToString()
                             + " - " + v_BaseDataGridView.CurrentRow.Cells["ST"].Value.ToString()
                            + " - " + v_BaseDataGridView.CurrentRow.Cells["FS"].Value.ToString();

                lblJobInfoID.Text = JobDescr;

                if (JobInfoID == "")
                {
                    JobInfoID = "-1";
                }


                tLkp = frmM.LoadDataLookup(ccid,CommonStr.s2i(JobInfoID),CommonStr.s2i(CalcID),JobDescr);
            }
        }
    }
}
