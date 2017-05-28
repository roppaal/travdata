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
    public partial class frmPegs : Form
    {

        List<string> lsMineVal; List<int> lsMineID;
        List<string> lsTravVal; List<int> lsTravID;
        private frmMain frmM;//ref to mainform 
        private int ccid = 1;// (1x Point) //Peg List //Peg Control //table -  pc
        DataTable tLkp;

        public frmPegs(frmMain frm)
        {
            InitializeComponent();
            frmM = frm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData(int MineID,int TravID)
        {
            // TODO: This line of code loads data into the 'travdataDataSet.v_Peg' table. You can move, or remove it, as needed.
            // this.v_PegTableAdapter.Fill(this.travdataDataSet.v_Peg);
            this.v_PegTableAdapter.FillByMineTravID(this.travdataDataSet.v_Peg,MineID,TravID);
        }

        private void frmPegs_Load(object sender, EventArgs e)
        {


            CommonDGV.Set_DBGridColumns(this.v_PegDataGridView);

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

        private void v_PegDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addNewPegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewPeg frm = new frmAddNewPeg();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show("New Peg Added");
                CheckMT_and_LoadData();
            }
            frm.Dispose();
        }

        private void cboMine_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTrav(lsMineID[cboMine.SelectedIndex]);
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

        private void v_PegDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (v_PegDataGridView.CurrentRow != null)
            {
                 //DataGridViewRow r = v_PegDataGridView.CurrentRow;

                 //lblJobInfoID.Text = v_PegDataGridView.CurrentRow.Cells["JobInfoID"].Value.ToString();

                //int rowIndex = v_PegDataGridView.CurrentCell.RowIndex;
                //lblJobInfoID.Text = rowIndex.ToString();

                //lblJobInfoID.Text = v_PegDataGridView.Rows[rowIndex].Cells["JobInfoID"].Value.ToString();


                //frmM.LoadDataLookup(CommonStr.s2i(this.travdataDataSet.v_Peg.JobInfoIDColumn.ToString()));
            }
        }

        private void v_PegDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (v_PegDataGridView.CurrentRow != null)
            {
                lblJobInfoID.Text = v_PegDataGridView.CurrentRow.Cells["Peg"].Value.ToString();

                String JobInfoID = v_PegDataGridView.CurrentRow.Cells["JobInfoID"].Value.ToString();

                String CalcID = v_PegDataGridView.CurrentRow.Cells["pcid"].Value.ToString();
                String JobDescr = v_PegDataGridView.CurrentRow.Cells["Peg"].Value.ToString();

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
