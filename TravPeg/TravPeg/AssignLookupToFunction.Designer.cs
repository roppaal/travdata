namespace TravPeg
{
    partial class frmAssignLookupToFunction
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ccDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travdataDataSet = new TravPeg.travdataDataSet();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboLkpType = new System.Windows.Forms.ComboBox();
            this.v_cc_lkp_TypeDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v_cc_lkp_TypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ccTableAdapter = new TravPeg.travdataDataSetTableAdapters.ccTableAdapter();
            this.tableAdapterManager = new TravPeg.travdataDataSetTableAdapters.TableAdapterManager();
            this.v_cc_lkp_TypeTableAdapter = new TravPeg.travdataDataSetTableAdapters.v_cc_lkp_TypeTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_cc_lkp_TypeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_cc_lkp_TypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 31);
            this.panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(832, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 45);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assign Lookups to Calculations";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ccDataGridView);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 222);
            this.panel3.TabIndex = 4;
            // 
            // ccDataGridView
            // 
            this.ccDataGridView.AutoGenerateColumns = false;
            this.ccDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ccDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.ccDataGridView.DataSource = this.ccBindingSource;
            this.ccDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ccDataGridView.Name = "ccDataGridView";
            this.ccDataGridView.ReadOnly = true;
            this.ccDataGridView.Size = new System.Drawing.Size(253, 222);
            this.ccDataGridView.TabIndex = 1;
            this.ccDataGridView.SelectionChanged += new System.EventHandler(this.ccDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CCID";
            this.dataGridViewTextBoxColumn1.HeaderText = "CCID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Descr";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descr";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ATag";
            this.dataGridViewTextBoxColumn3.HeaderText = "ATag";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 40;
            // 
            // ccBindingSource
            // 
            this.ccBindingSource.DataMember = "cc";
            this.ccBindingSource.DataSource = this.travdataDataSet;
            // 
            // travdataDataSet
            // 
            this.travdataDataSet.DataSetName = "travdataDataSet";
            this.travdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(253, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(16, 222);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.v_cc_lkp_TypeDataGridView);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(269, 45);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(643, 222);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.btnDel);
            this.panel6.Controls.Add(this.btnAdd);
            this.panel6.Controls.Add(this.cboLkpType);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 186);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(643, 36);
            this.panel6.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Image = global::TravPeg.Properties.Resources.del;
            this.btnDel.Location = new System.Drawing.Point(281, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(20, 20);
            this.btnDel.TabIndex = 2;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::TravPeg.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(255, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(20, 20);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboLkpType
            // 
            this.cboLkpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLkpType.FormattingEnabled = true;
            this.cboLkpType.Location = new System.Drawing.Point(39, 8);
            this.cboLkpType.Name = "cboLkpType";
            this.cboLkpType.Size = new System.Drawing.Size(210, 21);
            this.cboLkpType.TabIndex = 0;
            // 
            // v_cc_lkp_TypeDataGridView
            // 
            this.v_cc_lkp_TypeDataGridView.AutoGenerateColumns = false;
            this.v_cc_lkp_TypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.v_cc_lkp_TypeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6});
            this.v_cc_lkp_TypeDataGridView.DataSource = this.v_cc_lkp_TypeBindingSource;
            this.v_cc_lkp_TypeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.v_cc_lkp_TypeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.v_cc_lkp_TypeDataGridView.Name = "v_cc_lkp_TypeDataGridView";
            this.v_cc_lkp_TypeDataGridView.ReadOnly = true;
            this.v_cc_lkp_TypeDataGridView.Size = new System.Drawing.Size(643, 222);
            this.v_cc_lkp_TypeDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "LookUp";
            this.dataGridViewTextBoxColumn9.HeaderText = "LookUp";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CCID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CCID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "lkpTypeID";
            this.dataGridViewTextBoxColumn7.HeaderText = "LTID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "cclkpTypeID";
            this.dataGridViewTextBoxColumn6.HeaderText = "CCLTID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // v_cc_lkp_TypeBindingSource
            // 
            this.v_cc_lkp_TypeBindingSource.DataMember = "v_cc_lkp_Type";
            this.v_cc_lkp_TypeBindingSource.DataSource = this.travdataDataSet;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(269, 45);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 222);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // ccTableAdapter
            // 
            this.ccTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.ccTableAdapter = this.ccTableAdapter;
            this.tableAdapterManager.cTableAdapter = null;
            this.tableAdapterManager.eTableAdapter = null;
            this.tableAdapterManager.horsumTableAdapter = null;
            this.tableAdapterManager.horTableAdapter = null;
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
            // v_cc_lkp_TypeTableAdapter
            // 
            this.v_cc_lkp_TypeTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAssignLookupToFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 298);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmAssignLookupToFunction";
            this.Text = "Assign Lookups to Calculations";
            this.Load += new System.EventHandler(this.frmAssignLookupToFunction_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ccDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v_cc_lkp_TypeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_cc_lkp_TypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter1;
        private travdataDataSet travdataDataSet;
        private System.Windows.Forms.BindingSource ccBindingSource;
        private travdataDataSetTableAdapters.ccTableAdapter ccTableAdapter;
        private travdataDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView ccDataGridView;
        private System.Windows.Forms.BindingSource v_cc_lkp_TypeBindingSource;
        private travdataDataSetTableAdapters.v_cc_lkp_TypeTableAdapter v_cc_lkp_TypeTableAdapter;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboLkpType;
        private System.Windows.Forms.DataGridView v_cc_lkp_TypeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button1;
    }
}