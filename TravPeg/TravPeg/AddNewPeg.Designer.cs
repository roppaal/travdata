﻿namespace TravPeg
{
    partial class frmAddNewPeg
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboMine = new System.Windows.Forms.ComboBox();
            this.cboTrav = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPegName = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 33);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(95, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboMine
            // 
            this.cboMine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMine.FormattingEnabled = true;
            this.cboMine.Location = new System.Drawing.Point(95, 26);
            this.cboMine.Name = "cboMine";
            this.cboMine.Size = new System.Drawing.Size(121, 21);
            this.cboMine.TabIndex = 1;
            this.cboMine.SelectedIndexChanged += new System.EventHandler(this.cboMine_SelectedIndexChanged);
            // 
            // cboTrav
            // 
            this.cboTrav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrav.FormattingEnabled = true;
            this.cboTrav.Location = new System.Drawing.Point(95, 53);
            this.cboTrav.Name = "cboTrav";
            this.cboTrav.Size = new System.Drawing.Size(121, 21);
            this.cboTrav.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Traverse";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Y Coord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "X Coord";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Z Coord";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Peg Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "G Coord";
            // 
            // txtPegName
            // 
            this.txtPegName.Location = new System.Drawing.Point(95, 80);
            this.txtPegName.Name = "txtPegName";
            this.txtPegName.Size = new System.Drawing.Size(121, 20);
            this.txtPegName.TabIndex = 10;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(95, 106);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(121, 20);
            this.txtY.TabIndex = 11;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(95, 132);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(121, 20);
            this.txtX.TabIndex = 12;
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(95, 158);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(121, 20);
            this.txtZ.TabIndex = 13;
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(95, 184);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(121, 20);
            this.txtG.TabIndex = 14;
            // 
            // frmAddNewPeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 267);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtZ);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtPegName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTrav);
            this.Controls.Add(this.cboMine);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddNewPeg";
            this.Text = "Add New Peg";
            this.Load += new System.EventHandler(this.frmAddNewPeg_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cboMine;
        private System.Windows.Forms.ComboBox cboTrav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPegName;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.TextBox txtG;
    }
}