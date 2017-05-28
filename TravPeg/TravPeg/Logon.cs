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
    public partial class frmLogon : Form
    {
        public frmLogon()
        {
            InitializeComponent();
            GlobalLogon.Clear();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (!dmMain.logon(txtUName.Text, txtPWord.Text))
            {
                MessageBox.Show("Logon Failed", "Logon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Welcome "+GlobalLogon.FName, "Logon", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
