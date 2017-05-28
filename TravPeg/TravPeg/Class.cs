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
    public partial class frmClass : Form
    {
        public frmClass()
        {
            InitializeComponent();
            LoadData();
            if (GlobalLogon.ULevel < 100)
            {
                dataGridView1.ReadOnly = true;
            }
        }

        private void cBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void ccBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            this.cTableAdapter1.Fill(travdataDataSet.c);
        }

        private void frmClass_Load(object sender, EventArgs e)
        {
            CommonDGV.Set_DBGridColumns(this.dataGridView1);
        }
    }
}
