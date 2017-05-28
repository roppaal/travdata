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
    public partial class frmCalcFunc : Form
    {
        public frmCalcFunc()
        {
            InitializeComponent();
            LoadData();

        }

        private void ccBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ccBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.travdataDataSet);

        }

        private void frmCalcFunc_Load(object sender, EventArgs e)
        {
            CommonDGV.Set_DBGridColumns(this.dataGridView1);
        }

        private void LoadData()
        {
            this.ccTableAdapter1.Fill(travdataDataSet.cc);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
