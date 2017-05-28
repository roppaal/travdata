namespace TravPeg
{
    partial class frmClass
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cTableAdapter1 = new TravPeg.travdataDataSetTableAdapters.cTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.travdataDataSet = new TravPeg.travdataDataSet();
            this.cidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDLimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eDLimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hALimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hDRelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eDRelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitFlagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relFlagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arcCntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canUseJoinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 30);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 298);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 30);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(422, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 216);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(659, 82);
            this.panel3.TabIndex = 2;
            // 
            // cTableAdapter1
            // 
            this.cTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cidDataGridViewTextBoxColumn,
            this.descrDataGridViewTextBoxColumn,
            this.aTagDataGridViewTextBoxColumn,
            this.hDLimitDataGridViewTextBoxColumn,
            this.eDLimitDataGridViewTextBoxColumn,
            this.hALimitDataGridViewTextBoxColumn,
            this.hDRelDataGridViewTextBoxColumn,
            this.eDRelDataGridViewTextBoxColumn,
            this.limitFlagDataGridViewTextBoxColumn,
            this.relFlagDataGridViewTextBoxColumn,
            this.arcCntDataGridViewTextBoxColumn,
            this.canUseJoinDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(659, 186);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cBindingSource
            // 
            this.cBindingSource.DataMember = "c";
            this.cBindingSource.DataSource = this.travdataDataSet;
            // 
            // travdataDataSet
            // 
            this.travdataDataSet.DataSetName = "travdataDataSet";
            this.travdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cidDataGridViewTextBoxColumn
            // 
            this.cidDataGridViewTextBoxColumn.DataPropertyName = "cid";
            this.cidDataGridViewTextBoxColumn.HeaderText = "cid";
            this.cidDataGridViewTextBoxColumn.Name = "cidDataGridViewTextBoxColumn";
            this.cidDataGridViewTextBoxColumn.ReadOnly = true;
            this.cidDataGridViewTextBoxColumn.Width = 40;
            // 
            // descrDataGridViewTextBoxColumn
            // 
            this.descrDataGridViewTextBoxColumn.DataPropertyName = "Descr";
            this.descrDataGridViewTextBoxColumn.HeaderText = "Descr";
            this.descrDataGridViewTextBoxColumn.Name = "descrDataGridViewTextBoxColumn";
            // 
            // aTagDataGridViewTextBoxColumn
            // 
            this.aTagDataGridViewTextBoxColumn.DataPropertyName = "ATag";
            this.aTagDataGridViewTextBoxColumn.HeaderText = "ATag";
            this.aTagDataGridViewTextBoxColumn.Name = "aTagDataGridViewTextBoxColumn";
            this.aTagDataGridViewTextBoxColumn.Width = 40;
            // 
            // hDLimitDataGridViewTextBoxColumn
            // 
            this.hDLimitDataGridViewTextBoxColumn.DataPropertyName = "HDLimit";
            this.hDLimitDataGridViewTextBoxColumn.HeaderText = "HDLimit";
            this.hDLimitDataGridViewTextBoxColumn.Name = "hDLimitDataGridViewTextBoxColumn";
            this.hDLimitDataGridViewTextBoxColumn.Width = 60;
            // 
            // eDLimitDataGridViewTextBoxColumn
            // 
            this.eDLimitDataGridViewTextBoxColumn.DataPropertyName = "EDLimit";
            this.eDLimitDataGridViewTextBoxColumn.HeaderText = "EDLimit";
            this.eDLimitDataGridViewTextBoxColumn.Name = "eDLimitDataGridViewTextBoxColumn";
            this.eDLimitDataGridViewTextBoxColumn.Width = 60;
            // 
            // hALimitDataGridViewTextBoxColumn
            // 
            this.hALimitDataGridViewTextBoxColumn.DataPropertyName = "HALimit";
            this.hALimitDataGridViewTextBoxColumn.HeaderText = "HALimit";
            this.hALimitDataGridViewTextBoxColumn.Name = "hALimitDataGridViewTextBoxColumn";
            this.hALimitDataGridViewTextBoxColumn.Width = 60;
            // 
            // hDRelDataGridViewTextBoxColumn
            // 
            this.hDRelDataGridViewTextBoxColumn.DataPropertyName = "HDRel";
            this.hDRelDataGridViewTextBoxColumn.HeaderText = "HDRel";
            this.hDRelDataGridViewTextBoxColumn.Name = "hDRelDataGridViewTextBoxColumn";
            this.hDRelDataGridViewTextBoxColumn.Width = 60;
            // 
            // eDRelDataGridViewTextBoxColumn
            // 
            this.eDRelDataGridViewTextBoxColumn.DataPropertyName = "EDRel";
            this.eDRelDataGridViewTextBoxColumn.HeaderText = "EDRel";
            this.eDRelDataGridViewTextBoxColumn.Name = "eDRelDataGridViewTextBoxColumn";
            this.eDRelDataGridViewTextBoxColumn.Width = 60;
            // 
            // limitFlagDataGridViewTextBoxColumn
            // 
            this.limitFlagDataGridViewTextBoxColumn.DataPropertyName = "LimitFlag";
            this.limitFlagDataGridViewTextBoxColumn.HeaderText = "LimitFlag";
            this.limitFlagDataGridViewTextBoxColumn.Name = "limitFlagDataGridViewTextBoxColumn";
            this.limitFlagDataGridViewTextBoxColumn.Width = 40;
            // 
            // relFlagDataGridViewTextBoxColumn
            // 
            this.relFlagDataGridViewTextBoxColumn.DataPropertyName = "RelFlag";
            this.relFlagDataGridViewTextBoxColumn.HeaderText = "RelFlag";
            this.relFlagDataGridViewTextBoxColumn.Name = "relFlagDataGridViewTextBoxColumn";
            this.relFlagDataGridViewTextBoxColumn.Width = 40;
            // 
            // arcCntDataGridViewTextBoxColumn
            // 
            this.arcCntDataGridViewTextBoxColumn.DataPropertyName = "ArcCnt";
            this.arcCntDataGridViewTextBoxColumn.HeaderText = "ArcCnt";
            this.arcCntDataGridViewTextBoxColumn.Name = "arcCntDataGridViewTextBoxColumn";
            this.arcCntDataGridViewTextBoxColumn.Width = 40;
            // 
            // canUseJoinDataGridViewTextBoxColumn
            // 
            this.canUseJoinDataGridViewTextBoxColumn.DataPropertyName = "CanUseJoin";
            this.canUseJoinDataGridViewTextBoxColumn.HeaderText = "CanUseJoin";
            this.canUseJoinDataGridViewTextBoxColumn.Name = "canUseJoinDataGridViewTextBoxColumn";
            this.canUseJoinDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.canUseJoinDataGridViewTextBoxColumn.Width = 40;
            // 
            // frmClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 328);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmClass";
            this.Text = "Survey Class Setup";
            this.Load += new System.EventHandler(this.frmClass_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel3;
        private travdataDataSetTableAdapters.cTableAdapter cTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource cBindingSource;
        private travdataDataSet travdataDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aTagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDLimitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eDLimitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hALimitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hDRelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eDRelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitFlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relFlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arcCntDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn canUseJoinDataGridViewTextBoxColumn;
    }
}