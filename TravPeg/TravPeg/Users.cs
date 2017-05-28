using System;
using System.Windows.Forms;
using System.Data;

namespace TravPeg
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        class auFlds {
            public int AUID = 0;
            public string FName ="";
            public string SName = "";
            public string Email = "";
            public string Pword = "";
            public int ULevel = 0;
            public int ATag = 0;

            public int Read_Val_GUI(frmUsers f, int iAUID)
            {
                AUID = iAUID;
                FName = f.txtFName.Text.Trim();
                SName = f.txtSName.Text.Trim();
                Email = f.txtEmail.Text.Trim();
                Pword = f.txtPword.Text.Trim();
                if (f.chkSiteAdmin.Checked == true) {
                    ULevel = 1000;
                }
                else {
                    ULevel = (int)f.udULevel.Value;
                }
                ATag = 1;

                if ( (!FName.Length.Equals(0)) 
                    && (!SName.Length.Equals(0)) 
                    && (!Email.Length.Equals(0)) 
                    && (!Pword.Length.Equals(0)) ){
                    return 1;
                }
                else {
                    MessageBox.Show("Not all the fields have values","Enter User Details",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return -1;
                }
                                
            }
        } 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void auBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
        {
            this.Validate();
            this.auBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.travdataDataSet);

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travdataDataSet.au' table. You can move, or remove it, as needed.
            this.auTableAdapter.Fill(this.travdataDataSet.au);
            ReadDataGridRow();

        }


        private void ReadDataGridRow()
        {

            DataGridView g = this.auDataGridView;
            if (g.CurrentRow != null)
            {
                int r = g.CurrentRow.Index;

                txtFName.Text = g.Rows[r].Cells[GetFldIdx(g, "FName")].Value.ToString();
                txtSName.Text = g.Rows[r].Cells[GetFldIdx(g, "SName")].Value.ToString();
                txtEmail.Text = g.Rows[r].Cells[GetFldIdx(g, "Email")].Value.ToString();
                txtPword.Text = g.Rows[r].Cells[GetFldIdx(g, "PWord")].Value.ToString();
                udULevel.Value = Convert.ToInt32(g.Rows[r].Cells[GetFldIdx(g, "ULevel")].Value.ToString());
            }

        }



        private int GetFldIdx(DataGridView dgv, string fld)
        {
            int idx = 0;
            if ((dgv != null) && (!fld.Length.Equals(0)))
            {
                
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    if (fld.CompareTo(dgv.Columns[i].HeaderText)==0) {
                        idx = i;
                        
                    }
                }
            }
            
            return idx;
        }

        private void btnUpdatePeg_Click(object sender, EventArgs e)
        {

            // String s = auDataGridView.Columns[2].HeaderText;
            // String s = auDataGridView.Rows[2].Cells["dataGridViewTextBoxColumn2"].Value.ToString();

            string sAUID = auDataGridView.CurrentRow.Cells[GetFldIdx(auDataGridView, "AUID")].Value.ToString();
            int iAUID =  Convert.ToInt32(sAUID);

            auFlds au = new auFlds();
            if (au.Read_Val_GUI(this, iAUID) != 1)
            {
                MessageBox.Show("Record not updated");
            }
            else {

                DataTable tbl = new travdataDataSet.auDataTable();
                DataRow row = tbl.NewRow();
                string[] idx = { "AUID"};


                row["AUID"] = au.AUID;
                row["FName"] = au.FName;
                row["SName"] = au.SName;
                row["Email"] = au.Email;
                row["Pword"] = au.Pword;
                row["ULevel"] = au.ULevel;
                row["ATag"] = au.ATag;

                if (Convert.ToInt16(row["AUID"].ToString()) > -1)
                {
                    dmMain.Update_Rec(idx,row);
                    this.auTableAdapter.Fill(this.travdataDataSet.au);
                    ReadDataGridRow();

                }
            }

        }


        private void auDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (auDataGridView.RowCount > 0)
            {
                ReadDataGridRow();
            }

        }

        private void auDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (auDataGridView.RowCount > 0)
            {
                ReadDataGridRow();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   //never delete, just de-activate
            DataGridView g = this.auDataGridView;
            if (g.CurrentRow != null)
            {
                int r = g.CurrentRow.Index;
                string idx  = g.Rows[r].Cells[GetFldIdx(g, "AUID")].Value.ToString();
                if (!idx.Length.Equals(0))
                {

                    if (dmMain.Set_ATag("AU","AUID",idx,"0")>-1)
                    {
                        MessageBox.Show("Record Deleted");
                        this.auTableAdapter.Fill(this.travdataDataSet.au);
                        ReadDataGridRow();

                    }
                    else
                    {
                        MessageBox.Show("Record NOT Deleted");
                    }

                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            
            int iAUID = -1;

            auFlds au = new auFlds();
            if (au.Read_Val_GUI(this, iAUID) != 1)
            {
                MessageBox.Show("Record not updated");
            }
            else
            {
                DataSet ds = new travdataDataSet();
                DataTable tbl = new travdataDataSet.auDataTable();
                DataRow row = tbl.NewRow();

                row["AUID"] = au.AUID;//need to be -1;
                row["FName"] = au.FName;
                row["SName"] = au.SName;
                row["Email"] = au.Email;
                row["Pword"] = au.Pword;
                row["ULevel"] = au.ULevel;
                row["ATag"] = au.ATag;

                if (Convert.ToInt16(row["AUID"].ToString()) == -1)
                {
                    dmMain.Add_Rec(row);
                    this.auTableAdapter.Fill(this.travdataDataSet.au);
                    ReadDataGridRow();
                }
            }

        }
    }
}
