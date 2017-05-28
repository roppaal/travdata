namespace TravPeg
{
    partial class dlgAddNewTravPeg
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cboBS = new System.Windows.Forms.ComboBox();
            this.cboST = new System.Windows.Forms.ComboBox();
            this.txtFS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cboLP = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 31);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(19, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Add Peg";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdAdd);
            this.panel2.Controls.Add(this.cmdClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 34);
            this.panel2.TabIndex = 1;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(211, 6);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(294, 5);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cboBS
            // 
            this.cboBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBS.FormattingEnabled = true;
            this.cboBS.Location = new System.Drawing.Point(22, 66);
            this.cboBS.Name = "cboBS";
            this.cboBS.Size = new System.Drawing.Size(99, 21);
            this.cboBS.TabIndex = 2;
            this.cboBS.SelectedIndexChanged += new System.EventHandler(this.cboBS_SelectedIndexChanged);
            // 
            // cboST
            // 
            this.cboST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboST.FormattingEnabled = true;
            this.cboST.Location = new System.Drawing.Point(145, 66);
            this.cboST.Name = "cboST";
            this.cboST.Size = new System.Drawing.Size(98, 21);
            this.cboST.TabIndex = 3;
            // 
            // txtFS
            // 
            this.txtFS.Location = new System.Drawing.Point(263, 67);
            this.txtFS.Name = "txtFS";
            this.txtFS.Size = new System.Drawing.Size(106, 20);
            this.txtFS.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Back Sight";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Station";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fore Sight";
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(263, 93);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(106, 21);
            this.cboClass.TabIndex = 8;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(208, 101);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 13);
            this.lblClass.TabIndex = 9;
            this.lblClass.Text = "Class";
            // 
            // cboLP
            // 
            this.cboLP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLP.FormattingEnabled = true;
            this.cboLP.Location = new System.Drawing.Point(263, 120);
            this.cboLP.Name = "cboLP";
            this.cboLP.Size = new System.Drawing.Size(106, 21);
            this.cboLP.TabIndex = 121;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(192, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 120;
            this.label20.Text = "PegType";
            // 
            // dlgAddNewTravPeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 197);
            this.Controls.Add(this.cboLP);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.cboClass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFS);
            this.Controls.Add(this.cboST);
            this.Controls.Add(this.cboBS);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "dlgAddNewTravPeg";
            this.Text = "Add New Traverse Peg";
            this.Load += new System.EventHandler(this.dlgAddNewTravPeg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboBS;
        private System.Windows.Forms.ComboBox cboST;
        private System.Windows.Forms.TextBox txtFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cboLP;
        private System.Windows.Forms.Label label20;
    }
}