namespace TravPeg
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveyFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traverseSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignToCalculationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLkp = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblCalcName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.travdataDataSet = new TravPeg.travdataDataSet();
            this.v_JDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_JDataTableAdapter = new TravPeg.travdataDataSetTableAdapters.v_JDataTableAdapter();
            this.tableAdapterManager = new TravPeg.travdataDataSetTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdSaveLkpData = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlLkp.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_JDataBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.surveyFunctionsToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(660, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // surveyFunctionsToolStripMenuItem
            // 
            this.surveyFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traverseSurveyToolStripMenuItem,
            this.gradesToolStripMenuItem});
            this.surveyFunctionsToolStripMenuItem.Name = "surveyFunctionsToolStripMenuItem";
            this.surveyFunctionsToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.surveyFunctionsToolStripMenuItem.Text = "Calculation Functions";
            this.surveyFunctionsToolStripMenuItem.Click += new System.EventHandler(this.surveyFunctionsToolStripMenuItem_Click);
            // 
            // traverseSurveyToolStripMenuItem
            // 
            this.traverseSurveyToolStripMenuItem.Name = "traverseSurveyToolStripMenuItem";
            this.traverseSurveyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.traverseSurveyToolStripMenuItem.Text = "Traverse Survey";
            this.traverseSurveyToolStripMenuItem.Click += new System.EventHandler(this.traverseSurveyToolStripMenuItem_Click);
            // 
            // gradesToolStripMenuItem
            // 
            this.gradesToolStripMenuItem.Name = "gradesToolStripMenuItem";
            this.gradesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.gradesToolStripMenuItem.Text = "Grades";
            this.gradesToolStripMenuItem.Click += new System.EventHandler(this.gradesToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pegsToolStripMenuItem,
            this.BasesToolStripMenuItem,
            this.fieldworkToolStripMenuItem,
            this.printToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // pegsToolStripMenuItem
            // 
            this.pegsToolStripMenuItem.Name = "pegsToolStripMenuItem";
            this.pegsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.pegsToolStripMenuItem.Text = "Pegs";
            this.pegsToolStripMenuItem.Click += new System.EventHandler(this.pegsToolStripMenuItem_Click);
            // 
            // BasesToolStripMenuItem
            // 
            this.BasesToolStripMenuItem.Name = "BasesToolStripMenuItem";
            this.BasesToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.BasesToolStripMenuItem.Text = "Bases";
            this.BasesToolStripMenuItem.Click += new System.EventHandler(this.BasesToolStripMenuItem_Click);
            // 
            // fieldworkToolStripMenuItem
            // 
            this.fieldworkToolStripMenuItem.Name = "fieldworkToolStripMenuItem";
            this.fieldworkToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fieldworkToolStripMenuItem.Text = "Fieldwork";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.classToolStripMenuItem,
            this.calculationTypesToolStripMenuItem,
            this.lookupsToolStripMenuItem,
            this.assignToCalculationsToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.classToolStripMenuItem.Text = "Survey Class Setup";
            this.classToolStripMenuItem.Click += new System.EventHandler(this.classToolStripMenuItem_Click);
            // 
            // calculationTypesToolStripMenuItem
            // 
            this.calculationTypesToolStripMenuItem.Name = "calculationTypesToolStripMenuItem";
            this.calculationTypesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.calculationTypesToolStripMenuItem.Text = "Calculation Types";
            this.calculationTypesToolStripMenuItem.Click += new System.EventHandler(this.calculationTypesToolStripMenuItem_Click);
            // 
            // lookupsToolStripMenuItem
            // 
            this.lookupsToolStripMenuItem.Name = "lookupsToolStripMenuItem";
            this.lookupsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.lookupsToolStripMenuItem.Text = "Lookup Setup";
            this.lookupsToolStripMenuItem.Click += new System.EventHandler(this.lookupsToolStripMenuItem_Click);
            // 
            // assignToCalculationsToolStripMenuItem
            // 
            this.assignToCalculationsToolStripMenuItem.Name = "assignToCalculationsToolStripMenuItem";
            this.assignToCalculationsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.assignToCalculationsToolStripMenuItem.Text = "Assign Lookup to Calculations";
            this.assignToCalculationsToolStripMenuItem.Click += new System.EventHandler(this.assignToCalculationsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // pnlLkp
            // 
            this.pnlLkp.Controls.Add(this.panel1);
            this.pnlLkp.Controls.Add(this.pnlTitle);
            this.pnlLkp.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLkp.Location = new System.Drawing.Point(499, 24);
            this.pnlLkp.Name = "pnlLkp";
            this.pnlLkp.Size = new System.Drawing.Size(161, 520);
            this.pnlLkp.TabIndex = 3;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblCalcName);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(161, 36);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblCalcName
            // 
            this.lblCalcName.AutoSize = true;
            this.lblCalcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalcName.ForeColor = System.Drawing.Color.Red;
            this.lblCalcName.Location = new System.Drawing.Point(3, 13);
            this.lblCalcName.Name = "lblCalcName";
            this.lblCalcName.Size = new System.Drawing.Size(70, 13);
            this.lblCalcName.TabIndex = 1;
            this.lblCalcName.Text = "Calculation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fieldwork Properties";
            // 
            // travdataDataSet
            // 
            this.travdataDataSet.DataSetName = "travdataDataSet";
            this.travdataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_JDataBindingSource
            // 
            this.v_JDataBindingSource.DataMember = "v_JData";
            this.v_JDataBindingSource.DataSource = this.travdataDataSet;
            // 
            // v_JDataTableAdapter
            // 
            this.v_JDataTableAdapter.ClearBeforeFill = true;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdSaveLkpData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 34);
            this.panel1.TabIndex = 2;
            // 
            // cmdSaveLkpData
            // 
            this.cmdSaveLkpData.Location = new System.Drawing.Point(26, 3);
            this.cmdSaveLkpData.Name = "cmdSaveLkpData";
            this.cmdSaveLkpData.Size = new System.Drawing.Size(123, 26);
            this.cmdSaveLkpData.TabIndex = 2;
            this.cmdSaveLkpData.Text = "Save User Data";
            this.cmdSaveLkpData.UseVisualStyleBackColor = true;
            this.cmdSaveLkpData.Click += new System.EventHandler(this.cmdSaveLkpData_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 544);
            this.Controls.Add(this.pnlLkp);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "TravPeg";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlLkp.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travdataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_JDataBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surveyFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traverseSurveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignToCalculationsToolStripMenuItem;
        private System.Windows.Forms.Panel pnlLkp;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblCalcName;
        private System.Windows.Forms.Label label1;
        private travdataDataSet travdataDataSet;
        private System.Windows.Forms.BindingSource v_JDataBindingSource;
        private travdataDataSetTableAdapters.v_JDataTableAdapter v_JDataTableAdapter;
        private travdataDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdSaveLkpData;
    }
}

