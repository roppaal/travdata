namespace TravPeg
{
    partial class frmUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlFrm = new System.Windows.Forms.Panel();
            this.auDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travdataDataSet = new TravPeg.travdataDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSiteAdmin = new System.Windows.Forms.CheckBox();
            this.udULevel = new System.Windows.Forms.NumericUpDown();
            this.txtPword = new System.Windows.Forms.MaskedTextBox();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txtSName = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdatePeg = new System.Windows.Forms.Button();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTiltle = new System.Windows.Forms.Label();
            this.auTableAdapter = new TravPeg.travdataDataSetTableAdapters.auTableAdapter();
            this.tableAdapterManager = new TravPeg.travdataDataSetTableAdapters.TableAdapterManager();
            this.pnlFrm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.auDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udULevel)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFrm
            // 
            this.pnlFrm.Controls.Add(this.auDataGridView);
            this.pnlFrm.Controls.Add(this.panel1);
            this.pnlFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrm.Location = new System.Drawing.Point(0, 35);
            this.pnlFrm.Name = "pnlFrm";
            this.pnlFrm.Size = new System.Drawing.Size(721, 310);
            this.pnlFrm.TabIndex = 5;
            // 
            // auDataGridView
            // 
            this.auDataGridView.AutoGenerateColumns = false;
            this.auDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.auDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.auDataGridView.DataSource = this.auBindingSource;
            this.auDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.auDataGridView.Location = new System.Drawing.Point(0, 0);
            this.auDataGridView.Name = "auDataGridView";
            this.auDataGridView.Size = new System.Drawing.Size(532, 310);
            this.auDataGridView.TabIndex = 1;
            this.auDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.auDataGridView_CellClick);
            this.auDataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.auDataGridView_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AUID";
            this.dataGridViewTextBoxColumn1.HeaderText = "AUID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FName";
            this.dataGridViewTextBoxColumn2.HeaderText = "FName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SName";
            this.dataGridViewTextBoxColumn3.HeaderText = "SName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn4.HeaderText = "Email";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Pword";
            this.dataGridViewTextBoxColumn5.HeaderText = "Pword";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 65;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ULevel";
            this.dataGridViewTextBoxColumn6.HeaderText = "ULevel";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ATag";
            this.dataGridViewTextBoxColumn7.HeaderText = "ATag";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 40;
            // 
            // auBindingSource
            // 
            this.auBindingSource.DataMember = "au";
            this.auBindingSource.DataSource = this.travdataDataSet;
            // 
            // travdataDataSet
            // 
            this.travdataDataSet.DataSetName = "travdataDataSet";
            this.travdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(532, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 310);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkSiteAdmin);
            this.panel2.Controls.Add(this.udULevel);
            this.panel2.Controls.Add(this.txtPword);
            this.panel2.Controls.Add(this.linkLabel5);
            this.panel2.Controls.Add(this.linkLabel4);
            this.panel2.Controls.Add(this.linkLabel3);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.linkLabel2);
            this.panel2.Controls.Add(this.txtSName);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.txtFName);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 272);
            this.panel2.TabIndex = 0;
            // 
            // chkSiteAdmin
            // 
            this.chkSiteAdmin.AutoSize = true;
            this.chkSiteAdmin.Enabled = false;
            this.chkSiteAdmin.Location = new System.Drawing.Point(25, 221);
            this.chkSiteAdmin.Name = "chkSiteAdmin";
            this.chkSiteAdmin.Size = new System.Drawing.Size(76, 17);
            this.chkSiteAdmin.TabIndex = 16;
            this.chkSiteAdmin.Text = "Site Admin";
            this.chkSiteAdmin.UseVisualStyleBackColor = true;
            // 
            // udULevel
            // 
            this.udULevel.Location = new System.Drawing.Point(25, 195);
            this.udULevel.Name = "udULevel";
            this.udULevel.Size = new System.Drawing.Size(129, 20);
            this.udULevel.TabIndex = 15;
            this.udULevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPword
            // 
            this.txtPword.Location = new System.Drawing.Point(25, 156);
            this.txtPword.Name = "txtPword";
            this.txtPword.Size = new System.Drawing.Size(129, 20);
            this.txtPword.TabIndex = 14;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(22, 179);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(58, 13);
            this.linkLabel5.TabIndex = 13;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "User Level";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(22, 140);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(53, 13);
            this.linkLabel4.TabIndex = 11;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Password";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(22, 102);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(32, 13);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(25, 118);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(129, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(22, 64);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(49, 13);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Surname";
            // 
            // txtSName
            // 
            this.txtSName.Location = new System.Drawing.Point(25, 80);
            this.txtSName.Name = "txtSName";
            this.txtSName.Size = new System.Drawing.Size(129, 20);
            this.txtSName.TabIndex = 6;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(22, 26);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Name";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(25, 42);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(129, 20);
            this.txtFName.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddNew);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdatePeg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 247);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 25);
            this.panel3.TabIndex = 3;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(0, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(60, 20);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(118, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 20);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdatePeg
            // 
            this.btnUpdatePeg.Location = new System.Drawing.Point(59, 3);
            this.btnUpdatePeg.Name = "btnUpdatePeg";
            this.btnUpdatePeg.Size = new System.Drawing.Size(60, 20);
            this.btnUpdatePeg.TabIndex = 3;
            this.btnUpdatePeg.Text = "Update";
            this.btnUpdatePeg.UseVisualStyleBackColor = true;
            this.btnUpdatePeg.Click += new System.EventHandler(this.btnUpdatePeg_Click);
            // 
            // pnlBot
            // 
            this.pnlBot.Controls.Add(this.btnClose);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 345);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(721, 25);
            this.pnlBot.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(644, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTiltle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(721, 35);
            this.pnlTop.TabIndex = 4;
            // 
            // lblTiltle
            // 
            this.lblTiltle.AutoSize = true;
            this.lblTiltle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiltle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTiltle.Location = new System.Drawing.Point(5, 5);
            this.lblTiltle.Name = "lblTiltle";
            this.lblTiltle.Size = new System.Drawing.Size(100, 20);
            this.lblTiltle.TabIndex = 0;
            this.lblTiltle.Text = "User Setup";
            // 
            // auTableAdapter
            // 
            this.auTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.aumtTableAdapter = null;
            this.tableAdapterManager.auTableAdapter = this.auTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.baseTableAdapter = null;
            this.tableAdapterManager.bcTableAdapter = null;
            this.tableAdapterManager.bfwTableAdapter = null;
            this.tableAdapterManager.ccjoincalcTableAdapter = null;
            this.tableAdapterManager.ccTableAdapter = null;
            this.tableAdapterManager.cTableAdapter = null;
            this.tableAdapterManager.eTableAdapter = null;
            this.tableAdapterManager.horsumTableAdapter = null;
            this.tableAdapterManager.horTableAdapter = null;
            this.tableAdapterManager.lpchainTableAdapter = null;
            this.tableAdapterManager.mineTableAdapter = null;
            this.tableAdapterManager.mtTableAdapter = null;
            this.tableAdapterManager.pcTableAdapter = null;
            this.tableAdapterManager.pegTableAdapter = null;
            this.tableAdapterManager.travTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TravPeg.travdataDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.vertsumTableAdapter = null;
            this.tableAdapterManager.vertTableAdapter = null;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 370);
            this.Controls.Add(this.pnlFrm);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmUsers";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.pnlFrm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.auDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udULevel)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pnlBot.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFrm;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel1;
        private travdataDataSet travdataDataSet;
        private System.Windows.Forms.BindingSource auBindingSource;
        private travdataDataSetTableAdapters.auTableAdapter auTableAdapter;
        private travdataDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView auDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown udULevel;
        private System.Windows.Forms.MaskedTextBox txtPword;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txtSName;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdatePeg;
        private System.Windows.Forms.Label lblTiltle;
        private System.Windows.Forms.CheckBox chkSiteAdmin;
    }
}