namespace TravPeg
{
    partial class frmPegs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblJobInfoID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTrav = new System.Windows.Forms.ComboBox();
            this.cboMine = new System.Windows.Forms.ComboBox();
            this.lblTiltle = new System.Windows.Forms.Label();
            this.pnlFrm = new System.Windows.Forms.Panel();
            this.v_PegDataGridView = new System.Windows.Forms.DataGridView();
            this.cmnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewPegToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v_PegBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travdataDataSet = new TravPeg.travdataDataSet();
            this.v_PegTableAdapter = new TravPeg.travdataDataSetTableAdapters.v_PegTableAdapter();
            this.tableAdapterManager = new TravPeg.travdataDataSetTableAdapters.TableAdapterManager();
            this.pcid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobInfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBot.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFrm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_PegDataGridView)).BeginInit();
            this.cmnuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_PegBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBot
            // 
            this.pnlBot.Controls.Add(this.btnClose);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 363);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(801, 25);
            this.pnlBot.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(724, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblJobInfoID);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.cboTrav);
            this.pnlTop.Controls.Add(this.cboMine);
            this.pnlTop.Controls.Add(this.lblTiltle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(801, 35);
            this.pnlTop.TabIndex = 1;
            // 
            // lblJobInfoID
            // 
            this.lblJobInfoID.AutoSize = true;
            this.lblJobInfoID.Location = new System.Drawing.Point(476, 12);
            this.lblJobInfoID.Name = "lblJobInfoID";
            this.lblJobInfoID.Size = new System.Drawing.Size(35, 13);
            this.lblJobInfoID.TabIndex = 6;
            this.lblJobInfoID.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Traverse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mine";
            // 
            // cboTrav
            // 
            this.cboTrav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrav.FormattingEnabled = true;
            this.cboTrav.Location = new System.Drawing.Point(320, 8);
            this.cboTrav.Name = "cboTrav";
            this.cboTrav.Size = new System.Drawing.Size(121, 21);
            this.cboTrav.TabIndex = 3;
            this.cboTrav.SelectedIndexChanged += new System.EventHandler(this.cboTrav_SelectedIndexChanged);
            // 
            // cboMine
            // 
            this.cboMine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMine.FormattingEnabled = true;
            this.cboMine.Location = new System.Drawing.Point(120, 7);
            this.cboMine.Name = "cboMine";
            this.cboMine.Size = new System.Drawing.Size(121, 21);
            this.cboMine.TabIndex = 2;
            this.cboMine.SelectedIndexChanged += new System.EventHandler(this.cboMine_SelectedIndexChanged);
            // 
            // lblTiltle
            // 
            this.lblTiltle.AutoSize = true;
            this.lblTiltle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiltle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTiltle.Location = new System.Drawing.Point(5, 5);
            this.lblTiltle.Name = "lblTiltle";
            this.lblTiltle.Size = new System.Drawing.Size(49, 20);
            this.lblTiltle.TabIndex = 1;
            this.lblTiltle.Text = "Pegs";
            // 
            // pnlFrm
            // 
            this.pnlFrm.Controls.Add(this.v_PegDataGridView);
            this.pnlFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrm.Location = new System.Drawing.Point(0, 35);
            this.pnlFrm.Name = "pnlFrm";
            this.pnlFrm.Size = new System.Drawing.Size(801, 328);
            this.pnlFrm.TabIndex = 2;
            // 
            // v_PegDataGridView
            // 
            this.v_PegDataGridView.AutoGenerateColumns = false;
            this.v_PegDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.v_PegDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pcid,
            this.Peg,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn20,
            this.CC,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.JobInfoID});
            this.v_PegDataGridView.ContextMenuStrip = this.cmnuGrid;
            this.v_PegDataGridView.DataSource = this.v_PegBindingSource;
            this.v_PegDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.v_PegDataGridView.Location = new System.Drawing.Point(0, 0);
            this.v_PegDataGridView.MultiSelect = false;
            this.v_PegDataGridView.Name = "v_PegDataGridView";
            this.v_PegDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.v_PegDataGridView.Size = new System.Drawing.Size(801, 328);
            this.v_PegDataGridView.TabIndex = 0;
            this.v_PegDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.v_PegDataGridView_RowEnter);
            this.v_PegDataGridView.SelectionChanged += new System.EventHandler(this.v_PegDataGridView_SelectionChanged);
            // 
            // cmnuGrid
            // 
            this.cmnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPegToolStripMenuItem});
            this.cmnuGrid.Name = "contextMenuStrip1";
            this.cmnuGrid.Size = new System.Drawing.Size(147, 26);
            // 
            // addNewPegToolStripMenuItem
            // 
            this.addNewPegToolStripMenuItem.Name = "addNewPegToolStripMenuItem";
            this.addNewPegToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addNewPegToolStripMenuItem.Text = "Add New Peg";
            this.addNewPegToolStripMenuItem.Click += new System.EventHandler(this.addNewPegToolStripMenuItem_Click);
            // 
            // v_PegBindingSource
            // 
            this.v_PegBindingSource.DataMember = "v_Peg";
            this.v_PegBindingSource.DataSource = this.travdataDataSet;
            // 
            // travdataDataSet
            // 
            this.travdataDataSet.DataSetName = "travdataDataSet";
            this.travdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_PegTableAdapter
            // 
            this.v_PegTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.aumtTableAdapter = null;
            this.tableAdapterManager.auTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.baseTableAdapter = null;
            this.tableAdapterManager.bcTableAdapter = null;
            this.tableAdapterManager.bfwTableAdapter = null;
            this.tableAdapterManager.ccjoincalcTableAdapter = null;
            this.tableAdapterManager.cclkpTypeTableAdapter = null;
            this.tableAdapterManager.ccTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.cTableAdapter = null;
            this.tableAdapterManager.eTableAdapter = null;
            this.tableAdapterManager.horsumTableAdapter = null;
            this.tableAdapterManager.horTableAdapter = null;
            this.tableAdapterManager.JobInfoDataTableAdapter = null;
            this.tableAdapterManager.JobInfoTableAdapter = null;
            this.tableAdapterManager.lkpTableAdapter = null;
            this.tableAdapterManager.lkpTypeTableAdapter = null;
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
            // pcid
            // 
            this.pcid.DataPropertyName = "pcid";
            this.pcid.HeaderText = "pcid";
            this.pcid.Name = "pcid";
            this.pcid.Width = 50;
            // 
            // Peg
            // 
            this.Peg.DataPropertyName = "Peg";
            this.Peg.HeaderText = "Peg";
            this.Peg.Name = "Peg";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "LP";
            this.dataGridViewTextBoxColumn19.HeaderText = "LP";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 30;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "X";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.HeaderText = "X";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Y";
            dataGridViewCellStyle2.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "Y";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Z";
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "Z";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "G";
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn7.HeaderText = "G";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "C";
            this.dataGridViewTextBoxColumn11.HeaderText = "C";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 30;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "E";
            this.dataGridViewTextBoxColumn13.HeaderText = "E";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 30;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "HDErr";
            dataGridViewCellStyle5.Format = "N2";
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn16.HeaderText = "HDErr";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 50;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "EDErr";
            dataGridViewCellStyle6.Format = "N2";
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn17.HeaderText = "EDErr";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 50;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "HAErr";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn18.HeaderText = "HAErr";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 50;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "CCnt";
            this.dataGridViewTextBoxColumn20.HeaderText = "CCnt";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 30;
            // 
            // CC
            // 
            this.CC.DataPropertyName = "CC";
            this.CC.HeaderText = "CC";
            this.CC.Name = "CC";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "FName";
            this.dataGridViewTextBoxColumn26.HeaderText = "FName";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "SName";
            this.dataGridViewTextBoxColumn27.HeaderText = "SName";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Width = 25;
            // 
            // JobInfoID
            // 
            this.JobInfoID.DataPropertyName = "JobInfoID";
            this.JobInfoID.HeaderText = "JobInfoID";
            this.JobInfoID.Name = "JobInfoID";
            this.JobInfoID.Width = 50;
            // 
            // frmPegs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 388);
            this.Controls.Add(this.pnlFrm);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBot);
            this.Name = "frmPegs";
            this.Text = "Pegs";
            this.Load += new System.EventHandler(this.frmPegs_Load);
            this.pnlBot.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFrm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v_PegDataGridView)).EndInit();
            this.cmnuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v_PegBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFrm;
        private System.Windows.Forms.Label lblTiltle;
        private travdataDataSet travdataDataSet;
        private System.Windows.Forms.BindingSource v_PegBindingSource;
        private travdataDataSetTableAdapters.v_PegTableAdapter v_PegTableAdapter;
        private travdataDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView v_PegDataGridView;
        private System.Windows.Forms.ContextMenuStrip cmnuGrid;
        private System.Windows.Forms.ToolStripMenuItem addNewPegToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboTrav;
        private System.Windows.Forms.ComboBox cboMine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblJobInfoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobInfoID;
    }
}