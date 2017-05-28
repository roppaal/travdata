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
    public partial class frmLookups : Form
    {
        public frmLookups()
        {
            InitializeComponent();
        }



        private void frmLookups_Load(object sender, EventArgs e)
        {
            LoadLkpType();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadLkpType()
        {
            // TODO: This line of code loads data into the 'travdataDataSet.lkpType' table. You can move, or remove it, as needed.
            this.lkpTypeTableAdapter.Fill(this.travdataDataSet.lkpType);
            //= lkpTypeDataGridView1.Rows[0];
            LoadLkp(CommonStr.s2i(travdataDataSet.lkpType.Rows[0]["lkpTypeID"].ToString()));
        }

        private void LoadLkp(int lkpTypeID)
        {
            // TODO: This line of code loads data into the 'travdataDataSet.lkp' table. You can move, or remove it, as needed.
            this.lkpTableAdapter.FillByLkpTypeID(this.travdataDataSet.lkp, lkpTypeID);

        }

        private void lkpTypeDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow r = lkpTypeDataGridView1.CurrentRow;
            if (r!=null)
            { 
                string id = r.Cells[0].Value.ToString();
                LoadLkp(CommonStr.s2i(id));
                txtlkpType.Text = r.Cells[1].Value.ToString();
                chkLkpType.Checked = false;
                if (r.Cells[2].Value.ToString()[0] == '1')
                {
                    chkLkpType.Checked = true;
                }
            }
        }

        private void lkpDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow r = lkpDataGridView.CurrentRow;
            if (r != null)
            {
                txtLkp.Text = r.Cells[1].Value.ToString();
                chkLkp.Checked = false;
                if (r.Cells[2].Value.ToString()[0] == '1')
                {
                    chkLkp.Checked = true;
                }
            }
        }

        private void btnlkpTypeUpdate_Click(object sender, EventArgs e)
        {
            
            int ID = -1;
            int ATag = 0;
            DataGridViewRow r = lkpTypeDataGridView1.CurrentRow;
            if (r != null)
            {
                ID = CommonStr.s2i(r.Cells[0].Value.ToString());
            }
            if (chkLkpType.Checked == true)
            {
                ATag = 1;
            }
            dmMain.AddLkpType(ID, txtlkpType.Text, ATag);
        }

        private void btnLkpTypeAdd_Click(object sender, EventArgs e)
        {
            int ID = -1;
            int ATag = 0;
            if (chkLkpType.Checked == true)
            {
                ATag = 1;
            }
            dmMain.AddLkpType(ID, txtlkpType.Text, ATag);
        }

        private void btnLkpUpdate_Click(object sender, EventArgs e)
        {
            int LID = -1; // Lookup Type
            int ID = -1;
            int ATag = 0;
            DataGridViewRow rlt = lkpTypeDataGridView1.CurrentRow;
            if (rlt != null)
            {
                LID = CommonStr.s2i(rlt.Cells[0].Value.ToString());
            }
            DataGridViewRow r = lkpDataGridView.CurrentRow;
            if (r != null)
            {
                ID = CommonStr.s2i(r.Cells[0].Value.ToString());
            }

            if (chkLkp.Checked == true)
            {
                ATag = 1;
            }
            dmMain.AddLkp(LID, ID, txtlkpType.Text, ATag);

        }


        private void lkpTypeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void lkpTypeDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
