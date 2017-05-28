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
    public partial class frmAssignLookupToFunction : Form
    {
        List<string> lsLkpVal; List<int> lsLkpID;


        public frmAssignLookupToFunction()
        {
            InitializeComponent();
            lsLkpVal = new List<string>(); lsLkpID = new List<int>();
    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAssignLookupToFunction_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            try
            {
                this.ccTableAdapter.Fill(this.travdataDataSet.cc);

                dmMain.load_LookUpVal("lkpType", "lkpTypeID", "Descr", lsLkpID, lsLkpVal, false);
                cboLkpType.DataSource = lsLkpVal;

                if (cboLkpType.Items.Count == 0)
                {
                    MessageBox.Show("No Lookup Types Found", "Load Lookup Types", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            { }
        }

        private void LoadCalcLookup()
        {

            DataGridViewRow r = ccDataGridView.CurrentRow;
            if (r != null)
            {
                int ccid = CommonStr.s2i(r.Cells[0].Value.ToString());
                try
                {
                    this.v_cc_lkp_TypeTableAdapter.FillBy_CCID(this.travdataDataSet.v_cc_lkp_Type, ccid);
                }
                finally
                {
                }

            }
        }



        private void ccDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            LoadCalcLookup();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            Add_CC_lkpType(1); //true
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            
            Add_CC_lkpType(0); //false
        }

        private void Add_CC_lkpType(int ATag)
        {
            if (cboLkpType.SelectedIndex < 0)
            {
                MessageBox.Show("No Lookup Selected", "Select Lookup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //need current CCID
            DataGridViewRow r = ccDataGridView.CurrentRow;
            if (r != null)
            {
                int ccid = CommonStr.s2i(r.Cells[0].Value.ToString());
                int lkpTypeID = lsLkpID[cboLkpType.SelectedIndex];
                dmMain.Add_cc_lkpType(ccid, lkpTypeID,ATag);
                //need current lkpTypeID
                //add ccid + lkpType combo to ccLkpType (ATag=0)
            }
            else
            {
                MessageBox.Show("No Calcuation Method Selected", "Select a Calculation Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //refresh
            LoadCalcLookup();

        }

        private void button1_Click(object sender, EventArgs e)
        {
         

        }
}
}
