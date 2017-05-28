namespace TravPeg
{
    partial class frmLookups
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lkpTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travdataDataSet = new TravPeg.travdataDataSet();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnLkpTypeAdd = new System.Windows.Forms.Button();
            this.btnlkpTypeUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkLkpType = new System.Windows.Forms.CheckBox();
            this.txtlkpType = new System.Windows.Forms.TextBox();
            this.lkpTypeDataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLkpAdd = new System.Windows.Forms.Button();
            this.btnLkpUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkLkp = new System.Windows.Forms.CheckBox();
            this.txtLkp = new System.Windows.Forms.TextBox();
            this.lkpDataGridView = new System.Windows.Forms.DataGridView();
            this.lkpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lkpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lkpTypeTableAdapter = new TravPeg.travdataDataSetTableAdapters.lkpTypeTableAdapter();
            this.tableAdapterManager = new TravPeg.travdataDataSetTableAdapters.TableAdapterManager();
            this.lkpTableAdapter = new TravPeg.travdataDataSetTableAdapters.lkpTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTypeDataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 280);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 31);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(724, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lkpTypeBindingSource
            // 
            this.lkpTypeBindingSource.DataMember = "lkpType";
            this.lkpTypeBindingSource.DataSource = this.travdataDataSet;
            // 
            // travdataDataSet
            // 
            this.travdataDataSet.DataSetName = "travdataDataSet";
            this.travdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.lkpTypeDataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.lkpDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(804, 235);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnLkpTypeAdd);
            this.panel5.Controls.Add(this.btnlkpTypeUpdate);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.chkLkpType);
            this.panel5.Controls.Add(this.txtlkpType);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 184);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(340, 51);
            this.panel5.TabIndex = 2;
            // 
            // btnLkpTypeAdd
            // 
            this.btnLkpTypeAdd.Location = new System.Drawing.Point(285, 16);
            this.btnLkpTypeAdd.Name = "btnLkpTypeAdd";
            this.btnLkpTypeAdd.Size = new System.Drawing.Size(33, 23);
            this.btnLkpTypeAdd.TabIndex = 4;
            this.btnLkpTypeAdd.Text = "+";
            this.btnLkpTypeAdd.UseVisualStyleBackColor = true;
            this.btnLkpTypeAdd.Click += new System.EventHandler(this.btnLkpTypeAdd_Click);
            // 
            // btnlkpTypeUpdate
            // 
            this.btnlkpTypeUpdate.Location = new System.Drawing.Point(247, 16);
            this.btnlkpTypeUpdate.Name = "btnlkpTypeUpdate";
            this.btnlkpTypeUpdate.Size = new System.Drawing.Size(32, 23);
            this.btnlkpTypeUpdate.TabIndex = 3;
            this.btnlkpTypeUpdate.Text = "U";
            this.btnlkpTypeUpdate.UseVisualStyleBackColor = true;
            this.btnlkpTypeUpdate.Click += new System.EventHandler(this.btnlkpTypeUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lookup Name";
            // 
            // chkLkpType
            // 
            this.chkLkpType.AutoSize = true;
            this.chkLkpType.Location = new System.Drawing.Point(226, 19);
            this.chkLkpType.Name = "chkLkpType";
            this.chkLkpType.Size = new System.Drawing.Size(15, 14);
            this.chkLkpType.TabIndex = 1;
            this.chkLkpType.UseVisualStyleBackColor = true;
            // 
            // txtlkpType
            // 
            this.txtlkpType.Location = new System.Drawing.Point(85, 16);
            this.txtlkpType.Name = "txtlkpType";
            this.txtlkpType.Size = new System.Drawing.Size(135, 20);
            this.txtlkpType.TabIndex = 0;
            // 
            // lkpTypeDataGridView1
            // 
            this.lkpTypeDataGridView1.AutoGenerateColumns = false;
            this.lkpTypeDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lkpTypeDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.lkpTypeDataGridView1.DataSource = this.lkpTypeBindingSource;
            this.lkpTypeDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lkpTypeDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.lkpTypeDataGridView1.Name = "lkpTypeDataGridView1";
            this.lkpTypeDataGridView1.ReadOnly = true;
            this.lkpTypeDataGridView1.Size = new System.Drawing.Size(340, 235);
            this.lkpTypeDataGridView1.TabIndex = 1;
            this.lkpTypeDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lkpTypeDataGridView1_CellContentClick);
            this.lkpTypeDataGridView1.SelectionChanged += new System.EventHandler(this.lkpTypeDataGridView1_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "lkpTypeID";
            this.dataGridViewTextBoxColumn8.HeaderText = "LID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 40;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Descr";
            this.dataGridViewTextBoxColumn9.HeaderText = "Lookup Name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ATag";
            this.dataGridViewTextBoxColumn10.HeaderText = "ATag";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 40;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(340, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(12, 235);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnLkpAdd);
            this.panel4.Controls.Add(this.btnLkpUpdate);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.chkLkp);
            this.panel4.Controls.Add(this.txtLkp);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 184);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(448, 51);
            this.panel4.TabIndex = 1;
            // 
            // btnLkpAdd
            // 
            this.btnLkpAdd.Location = new System.Drawing.Point(285, 14);
            this.btnLkpAdd.Name = "btnLkpAdd";
            this.btnLkpAdd.Size = new System.Drawing.Size(33, 23);
            this.btnLkpAdd.TabIndex = 9;
            this.btnLkpAdd.Text = "+";
            this.btnLkpAdd.UseVisualStyleBackColor = true;
            // 
            // btnLkpUpdate
            // 
            this.btnLkpUpdate.Location = new System.Drawing.Point(247, 14);
            this.btnLkpUpdate.Name = "btnLkpUpdate";
            this.btnLkpUpdate.Size = new System.Drawing.Size(32, 23);
            this.btnLkpUpdate.TabIndex = 8;
            this.btnLkpUpdate.Text = "U";
            this.btnLkpUpdate.UseVisualStyleBackColor = true;
            this.btnLkpUpdate.Click += new System.EventHandler(this.btnLkpUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lookup Value";
            // 
            // chkLkp
            // 
            this.chkLkp.AutoSize = true;
            this.chkLkp.Location = new System.Drawing.Point(226, 17);
            this.chkLkp.Name = "chkLkp";
            this.chkLkp.Size = new System.Drawing.Size(15, 14);
            this.chkLkp.TabIndex = 6;
            this.chkLkp.UseVisualStyleBackColor = true;
            // 
            // txtLkp
            // 
            this.txtLkp.Location = new System.Drawing.Point(85, 14);
            this.txtLkp.Name = "txtLkp";
            this.txtLkp.Size = new System.Drawing.Size(135, 20);
            this.txtLkp.TabIndex = 5;
            // 
            // lkpDataGridView
            // 
            this.lkpDataGridView.AutoGenerateColumns = false;
            this.lkpDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lkpDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lkpID,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn5});
            this.lkpDataGridView.DataSource = this.lkpBindingSource;
            this.lkpDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lkpDataGridView.Location = new System.Drawing.Point(0, 0);
            this.lkpDataGridView.Name = "lkpDataGridView";
            this.lkpDataGridView.ReadOnly = true;
            this.lkpDataGridView.Size = new System.Drawing.Size(448, 235);
            this.lkpDataGridView.TabIndex = 0;
            this.lkpDataGridView.SelectionChanged += new System.EventHandler(this.lkpDataGridView_SelectionChanged);
            // 
            // lkpID
            // 
            this.lkpID.DataPropertyName = "lkpID";
            this.lkpID.HeaderText = "ID";
            this.lkpID.Name = "lkpID";
            this.lkpID.ReadOnly = true;
            this.lkpID.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Descr";
            this.dataGridViewTextBoxColumn6.HeaderText = "Lookup Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ATag";
            this.dataGridViewTextBoxColumn7.HeaderText = "ATag";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "lkpTypeID";
            this.dataGridViewTextBoxColumn5.HeaderText = "LID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // lkpBindingSource
            // 
            this.lkpBindingSource.DataMember = "lkp";
            this.lkpBindingSource.DataSource = this.travdataDataSet;
            // 
            // lkpTypeTableAdapter
            // 
            this.lkpTypeTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.cTableAdapter = null;
            this.tableAdapterManager.eTableAdapter = null;
            this.tableAdapterManager.horsumTableAdapter = null;
            this.tableAdapterManager.horTableAdapter = null;
            this.tableAdapterManager.lkpTableAdapter = this.lkpTableAdapter;
            this.tableAdapterManager.lkpTypeTableAdapter = this.lkpTypeTableAdapter;
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
            // lkpTableAdapter
            // 
            this.lkpTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Setup Lookup Group and Values";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 45);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmLookups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 311);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmLookups";
            this.Text = "Setup Lookup Groups and Values";
            this.Load += new System.EventHandler(this.frmLookups_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpTypeDataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private travdataDataSet travdataDataSet;
        private System.Windows.Forms.BindingSource lkpTypeBindingSource;
        private travdataDataSetTableAdapters.lkpTypeTableAdapter lkpTypeTableAdapter;
        private travdataDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private travdataDataSetTableAdapters.lkpTableAdapter lkpTableAdapter;
        private System.Windows.Forms.BindingSource lkpBindingSource;
        private System.Windows.Forms.DataGridView lkpTypeDataGridView1;
        private System.Windows.Forms.DataGridView lkpDataGridView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLkpTypeAdd;
        private System.Windows.Forms.Button btnlkpTypeUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkLkpType;
        private System.Windows.Forms.TextBox txtlkpType;
        private System.Windows.Forms.Button btnLkpAdd;
        private System.Windows.Forms.Button btnLkpUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkLkp;
        private System.Windows.Forms.TextBox txtLkp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn lkpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}