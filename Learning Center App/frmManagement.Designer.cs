namespace Learning_Center_App
{
    partial class frmManagement
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
            this.lblManagFrmTitle = new System.Windows.Forms.Label();
            this.dataGridViewManag = new System.Windows.Forms.DataGridView();
            this.lblSrchStudID = new System.Windows.Forms.Label();
            this.lblSrchDate = new System.Windows.Forms.Label();
            this.lblOr = new System.Windows.Forms.Label();
            this.txtStudIDSrch = new System.Windows.Forms.TextBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.paneSrchStudIDManag = new System.Windows.Forms.Panel();
            this.lblOr3 = new System.Windows.Forms.Label();
            this.lblStuIDPanelSrch = new System.Windows.Forms.Label();
            this.lblStuNamPanelSrch = new System.Windows.Forms.Label();
            this.txtStudNamSrch = new System.Windows.Forms.TextBox();
            this.btnSrchStuIDNam = new System.Windows.Forms.Button();
            this.panelSrchDateManag = new System.Windows.Forms.Panel();
            this.btnSrchDate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.damjanDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblInstrUpdtRetMng = new System.Windows.Forms.Label();
            this.lblRetIDMng = new System.Windows.Forms.Label();
            this.txtRetIDMng = new System.Windows.Forms.TextBox();
            this.btnUpdtRetStat = new System.Windows.Forms.Button();
            this.lblManageIDNumbers = new System.Windows.Forms.Label();
            this.lblManageID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMngCorner = new System.Windows.Forms.Label();
            this.btnCloseMng = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManag)).BeginInit();
            this.paneSrchStudIDManag.SuspendLayout();
            this.panelSrchDateManag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.damjanDataSetBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblManagFrmTitle
            // 
            this.lblManagFrmTitle.AutoSize = true;
            this.lblManagFrmTitle.Font = new System.Drawing.Font("Century Schoolbook", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagFrmTitle.ForeColor = System.Drawing.Color.White;
            this.lblManagFrmTitle.Location = new System.Drawing.Point(277, 80);
            this.lblManagFrmTitle.Name = "lblManagFrmTitle";
            this.lblManagFrmTitle.Size = new System.Drawing.Size(492, 29);
            this.lblManagFrmTitle.TabIndex = 30;
            this.lblManagFrmTitle.Text = " Students Assigned For Exam Retake";
            // 
            // dataGridViewManag
            // 
            this.dataGridViewManag.AllowUserToAddRows = false;
            this.dataGridViewManag.AllowUserToDeleteRows = false;
            this.dataGridViewManag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewManag.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewManag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManag.Location = new System.Drawing.Point(22, 309);
            this.dataGridViewManag.MultiSelect = false;
            this.dataGridViewManag.Name = "dataGridViewManag";
            this.dataGridViewManag.ReadOnly = true;
            this.dataGridViewManag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManag.Size = new System.Drawing.Size(1033, 256);
            this.dataGridViewManag.TabIndex = 31;
            // 
            // lblSrchStudID
            // 
            this.lblSrchStudID.Font = new System.Drawing.Font("Century Schoolbook", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrchStudID.ForeColor = System.Drawing.Color.White;
            this.lblSrchStudID.Location = new System.Drawing.Point(73, 2);
            this.lblSrchStudID.Name = "lblSrchStudID";
            this.lblSrchStudID.Size = new System.Drawing.Size(188, 30);
            this.lblSrchStudID.TabIndex = 32;
            this.lblSrchStudID.Text = "Search Student:";
            // 
            // lblSrchDate
            // 
            this.lblSrchDate.Font = new System.Drawing.Font("Century Schoolbook", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrchDate.ForeColor = System.Drawing.Color.White;
            this.lblSrchDate.Location = new System.Drawing.Point(108, 2);
            this.lblSrchDate.Name = "lblSrchDate";
            this.lblSrchDate.Size = new System.Drawing.Size(149, 30);
            this.lblSrchDate.TabIndex = 33;
            this.lblSrchDate.Text = "Search Date:";
            // 
            // lblOr
            // 
            this.lblOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOr.ForeColor = System.Drawing.Color.White;
            this.lblOr.Location = new System.Drawing.Point(444, 196);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(168, 33);
            this.lblOr.TabIndex = 34;
            this.lblOr.Text = "<------ OR ------>";
            // 
            // txtStudIDSrch
            // 
            this.txtStudIDSrch.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtStudIDSrch.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudIDSrch.Location = new System.Drawing.Point(78, 89);
            this.txtStudIDSrch.MaxLength = 9;
            this.txtStudIDSrch.Name = "txtStudIDSrch";
            this.txtStudIDSrch.Size = new System.Drawing.Size(199, 27);
            this.txtStudIDSrch.TabIndex = 1;
            this.txtStudIDSrch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudIDSrch_KeyPress);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(94, 45);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(188, 21);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(96, 94);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(188, 21);
            this.dateTimePickerTo.TabIndex = 1;
            // 
            // paneSrchStudIDManag
            // 
            this.paneSrchStudIDManag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.paneSrchStudIDManag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paneSrchStudIDManag.Controls.Add(this.lblOr3);
            this.paneSrchStudIDManag.Controls.Add(this.lblStuIDPanelSrch);
            this.paneSrchStudIDManag.Controls.Add(this.lblStuNamPanelSrch);
            this.paneSrchStudIDManag.Controls.Add(this.txtStudNamSrch);
            this.paneSrchStudIDManag.Controls.Add(this.btnSrchStuIDNam);
            this.paneSrchStudIDManag.Controls.Add(this.lblSrchStudID);
            this.paneSrchStudIDManag.Controls.Add(this.txtStudIDSrch);
            this.paneSrchStudIDManag.Location = new System.Drawing.Point(115, 130);
            this.paneSrchStudIDManag.Name = "paneSrchStudIDManag";
            this.paneSrchStudIDManag.Size = new System.Drawing.Size(314, 163);
            this.paneSrchStudIDManag.TabIndex = 38;
            // 
            // lblOr3
            // 
            this.lblOr3.AutoSize = true;
            this.lblOr3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOr3.ForeColor = System.Drawing.Color.White;
            this.lblOr3.Location = new System.Drawing.Point(142, 65);
            this.lblOr3.Name = "lblOr3";
            this.lblOr3.Size = new System.Drawing.Size(27, 15);
            this.lblOr3.TabIndex = 57;
            this.lblOr3.Text = "OR";
            // 
            // lblStuIDPanelSrch
            // 
            this.lblStuIDPanelSrch.AutoSize = true;
            this.lblStuIDPanelSrch.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStuIDPanelSrch.ForeColor = System.Drawing.Color.White;
            this.lblStuIDPanelSrch.Location = new System.Drawing.Point(19, 94);
            this.lblStuIDPanelSrch.Name = "lblStuIDPanelSrch";
            this.lblStuIDPanelSrch.Size = new System.Drawing.Size(33, 19);
            this.lblStuIDPanelSrch.TabIndex = 56;
            this.lblStuIDPanelSrch.Text = "ID:";
            // 
            // lblStuNamPanelSrch
            // 
            this.lblStuNamPanelSrch.AutoSize = true;
            this.lblStuNamPanelSrch.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStuNamPanelSrch.ForeColor = System.Drawing.Color.White;
            this.lblStuNamPanelSrch.Location = new System.Drawing.Point(10, 35);
            this.lblStuNamPanelSrch.Name = "lblStuNamPanelSrch";
            this.lblStuNamPanelSrch.Size = new System.Drawing.Size(60, 19);
            this.lblStuNamPanelSrch.TabIndex = 55;
            this.lblStuNamPanelSrch.Text = "Name:";
            // 
            // txtStudNamSrch
            // 
            this.txtStudNamSrch.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtStudNamSrch.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudNamSrch.Location = new System.Drawing.Point(78, 32);
            this.txtStudNamSrch.MaxLength = 9;
            this.txtStudNamSrch.Name = "txtStudNamSrch";
            this.txtStudNamSrch.Size = new System.Drawing.Size(199, 27);
            this.txtStudNamSrch.TabIndex = 0;
            // 
            // btnSrchStuIDNam
            // 
            this.btnSrchStuIDNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrchStuIDNam.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSrchStuIDNam.Location = new System.Drawing.Point(113, 130);
            this.btnSrchStuIDNam.Name = "btnSrchStuIDNam";
            this.btnSrchStuIDNam.Size = new System.Drawing.Size(75, 25);
            this.btnSrchStuIDNam.TabIndex = 2;
            this.btnSrchStuIDNam.Text = "Search";
            this.btnSrchStuIDNam.UseVisualStyleBackColor = true;
            this.btnSrchStuIDNam.Click += new System.EventHandler(this.btnSrchStuIDNam_Click);
            // 
            // panelSrchDateManag
            // 
            this.panelSrchDateManag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.panelSrchDateManag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSrchDateManag.Controls.Add(this.btnSrchDate);
            this.panelSrchDateManag.Controls.Add(this.label1);
            this.panelSrchDateManag.Controls.Add(this.label2);
            this.panelSrchDateManag.Controls.Add(this.lblSrchDate);
            this.panelSrchDateManag.Controls.Add(this.dateTimePickerFrom);
            this.panelSrchDateManag.Controls.Add(this.dateTimePickerTo);
            this.panelSrchDateManag.Location = new System.Drawing.Point(620, 130);
            this.panelSrchDateManag.Name = "panelSrchDateManag";
            this.panelSrchDateManag.Size = new System.Drawing.Size(338, 163);
            this.panelSrchDateManag.TabIndex = 39;
            // 
            // btnSrchDate
            // 
            this.btnSrchDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrchDate.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSrchDate.Location = new System.Drawing.Point(134, 130);
            this.btnSrchDate.Name = "btnSrchDate";
            this.btnSrchDate.Size = new System.Drawing.Size(75, 25);
            this.btnSrchDate.TabIndex = 2;
            this.btnSrchDate.Text = "Search";
            this.btnSrchDate.UseVisualStyleBackColor = true;
            this.btnSrchDate.Click += new System.EventHandler(this.btnSrchDate_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "To------>";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "From--->";
            // 
            // damjanDataSet

            // 
            // damjanDataSetBindingSource
            // 

            this.damjanDataSetBindingSource.Position = 0;
            // 
            // lblInstrUpdtRetMng
            // 
            this.lblInstrUpdtRetMng.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrUpdtRetMng.ForeColor = System.Drawing.Color.White;
            this.lblInstrUpdtRetMng.Location = new System.Drawing.Point(71, 593);
            this.lblInstrUpdtRetMng.Name = "lblInstrUpdtRetMng";
            this.lblInstrUpdtRetMng.Size = new System.Drawing.Size(363, 29);
            this.lblInstrUpdtRetMng.TabIndex = 51;
            this.lblInstrUpdtRetMng.Text = "Update Retake Status if Completed ----->";
            // 
            // lblRetIDMng
            // 
            this.lblRetIDMng.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetIDMng.ForeColor = System.Drawing.Color.White;
            this.lblRetIDMng.Location = new System.Drawing.Point(479, 594);
            this.lblRetIDMng.Name = "lblRetIDMng";
            this.lblRetIDMng.Size = new System.Drawing.Size(104, 29);
            this.lblRetIDMng.TabIndex = 52;
            this.lblRetIDMng.Text = "Retake ID:";
            // 
            // txtRetIDMng
            // 
            this.txtRetIDMng.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRetIDMng.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetIDMng.Location = new System.Drawing.Point(592, 592);
            this.txtRetIDMng.MaxLength = 4;
            this.txtRetIDMng.Name = "txtRetIDMng";
            this.txtRetIDMng.Size = new System.Drawing.Size(85, 27);
            this.txtRetIDMng.TabIndex = 0;
            this.txtRetIDMng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRetIDMng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetIDMng_KeyPress);
            // 
            // btnUpdtRetStat
            // 
            this.btnUpdtRetStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnUpdtRetStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdtRetStat.Font = new System.Drawing.Font("Century Schoolbook", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdtRetStat.Location = new System.Drawing.Point(723, 588);
            this.btnUpdtRetStat.Name = "btnUpdtRetStat";
            this.btnUpdtRetStat.Size = new System.Drawing.Size(243, 35);
            this.btnUpdtRetStat.TabIndex = 1;
            this.btnUpdtRetStat.Text = "Retake Taken";
            this.btnUpdtRetStat.UseVisualStyleBackColor = false;
            this.btnUpdtRetStat.Click += new System.EventHandler(this.btnUpdtRetStat_Click);
            // 
            // lblManageIDNumbers
            // 
            this.lblManageIDNumbers.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageIDNumbers.ForeColor = System.Drawing.Color.White;
            this.lblManageIDNumbers.Location = new System.Drawing.Point(115, 74);
            this.lblManageIDNumbers.Name = "lblManageIDNumbers";
            this.lblManageIDNumbers.Size = new System.Drawing.Size(88, 15);
            this.lblManageIDNumbers.TabIndex = 89;
            // 
            // lblManageID
            // 
            this.lblManageID.AutoSize = true;
            this.lblManageID.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageID.ForeColor = System.Drawing.Color.White;
            this.lblManageID.Location = new System.Drawing.Point(4, 74);
            this.lblManageID.Name = "lblManageID";
            this.lblManageID.Size = new System.Drawing.Size(108, 15);
            this.lblManageID.TabIndex = 88;
            this.lblManageID.Text = "Management ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblMngCorner);
            this.panel1.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 67);
            this.panel1.TabIndex = 90;
            // 
            // lblMngCorner
            // 
            this.lblMngCorner.Font = new System.Drawing.Font("Century Schoolbook", 20F, System.Drawing.FontStyle.Bold);
            this.lblMngCorner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.lblMngCorner.Location = new System.Drawing.Point(11, 14);
            this.lblMngCorner.Name = "lblMngCorner";
            this.lblMngCorner.Size = new System.Drawing.Size(210, 34);
            this.lblMngCorner.TabIndex = 1;
            this.lblMngCorner.Text = "Management";
            this.lblMngCorner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseMng
            // 
            this.btnCloseMng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseMng.Location = new System.Drawing.Point(1028, -1);
            this.btnCloseMng.Name = "btnCloseMng";
            this.btnCloseMng.Size = new System.Drawing.Size(46, 35);
            this.btnCloseMng.TabIndex = 91;
            this.btnCloseMng.Text = "X";
            this.btnCloseMng.UseVisualStyleBackColor = true;
            this.btnCloseMng.Click += new System.EventHandler(this.btnCloseMng_Click);
            // 
            // frmManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1073, 706);
            this.Controls.Add(this.btnCloseMng);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblManageIDNumbers);
            this.Controls.Add(this.lblManageID);
            this.Controls.Add(this.btnUpdtRetStat);
            this.Controls.Add(this.txtRetIDMng);
            this.Controls.Add(this.lblRetIDMng);
            this.Controls.Add(this.lblInstrUpdtRetMng);
            this.Controls.Add(this.panelSrchDateManag);
            this.Controls.Add(this.paneSrchStudIDManag);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.dataGridViewManag);
            this.Controls.Add(this.lblManagFrmTitle);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learning Center Apps";
            this.Load += new System.EventHandler(this.frmManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManag)).EndInit();
            this.paneSrchStudIDManag.ResumeLayout(false);
            this.paneSrchStudIDManag.PerformLayout();
            this.panelSrchDateManag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.damjanDataSetBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblManagFrmTitle;
        private System.Windows.Forms.DataGridView dataGridViewManag;
        private System.Windows.Forms.Label lblSrchStudID;
        private System.Windows.Forms.Label lblSrchDate;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.TextBox txtStudIDSrch;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Panel paneSrchStudIDManag;
        private System.Windows.Forms.Panel panelSrchDateManag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource damjanDataSetBindingSource;
        private System.Windows.Forms.Button btnSrchStuIDNam;
        private System.Windows.Forms.Button btnSrchDate;
        private System.Windows.Forms.TextBox txtStudNamSrch;
        private System.Windows.Forms.Label lblStuIDPanelSrch;
        private System.Windows.Forms.Label lblStuNamPanelSrch;
        private System.Windows.Forms.Label lblOr3;
        private System.Windows.Forms.Label lblInstrUpdtRetMng;
        private System.Windows.Forms.Label lblRetIDMng;
        private System.Windows.Forms.TextBox txtRetIDMng;
        private System.Windows.Forms.Button btnUpdtRetStat;
        private System.Windows.Forms.Label lblManageIDNumbers;
        private System.Windows.Forms.Label lblManageID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMngCorner;
        private System.Windows.Forms.Button btnCloseMng;
    }
}