namespace Learning_Center_App
{
    partial class frmFaculty
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
            this.lblFacFrmTitle = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep6 = new System.Windows.Forms.Label();
            this.lblSelectStud = new System.Windows.Forms.Label();
            this.cboChooseClass = new System.Windows.Forms.ComboBox();
            this.classBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.btnConfirmFac = new System.Windows.Forms.Button();
            this.chckLstBox = new System.Windows.Forms.CheckedListBox();
            this.btnRetakesFac = new System.Windows.Forms.Button();
            this.lblSelClass = new System.Windows.Forms.Label();
            this.lblFacID = new System.Windows.Forms.Label();
            this.lblFacIdNamNA = new System.Windows.Forms.Label();
            this.lblFacName = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.cboReasonRetake = new System.Windows.Forms.ComboBox();
            this.lblStep5 = new System.Windows.Forms.Label();
            this.lblSpecifyOther = new System.Windows.Forms.Label();
            this.txtReasonRet = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFacCorner = new System.Windows.Forms.Label();
            this.btnCloseFac = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFacFrmTitle
            // 
            this.lblFacFrmTitle.Font = new System.Drawing.Font("Century Schoolbook", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacFrmTitle.ForeColor = System.Drawing.Color.White;
            this.lblFacFrmTitle.Location = new System.Drawing.Point(209, 103);
            this.lblFacFrmTitle.Name = "lblFacFrmTitle";
            this.lblFacFrmTitle.Size = new System.Drawing.Size(499, 38);
            this.lblFacFrmTitle.TabIndex = 3;
            this.lblFacFrmTitle.Text = "Assigning Students For Exam Retake";
            // 
            // lblStep1
            // 
            this.lblStep1.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1.ForeColor = System.Drawing.Color.White;
            this.lblStep1.Location = new System.Drawing.Point(26, 160);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(100, 30);
            this.lblStep1.TabIndex = 4;
            this.lblStep1.Text = "Step 1:";
            // 
            // lblStep2
            // 
            this.lblStep2.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2.ForeColor = System.Drawing.Color.White;
            this.lblStep2.Location = new System.Drawing.Point(24, 262);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(100, 30);
            this.lblStep2.TabIndex = 5;
            this.lblStep2.Text = "Step 2:";
            // 
            // lblStep3
            // 
            this.lblStep3.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3.ForeColor = System.Drawing.Color.White;
            this.lblStep3.Location = new System.Drawing.Point(24, 347);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(100, 30);
            this.lblStep3.TabIndex = 6;
            this.lblStep3.Text = "Step 3:";
            // 
            // lblStep6
            // 
            this.lblStep6.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep6.ForeColor = System.Drawing.Color.White;
            this.lblStep6.Location = new System.Drawing.Point(23, 723);
            this.lblStep6.Name = "lblStep6";
            this.lblStep6.Size = new System.Drawing.Size(100, 30);
            this.lblStep6.TabIndex = 7;
            this.lblStep6.Text = "Step 6:";
            // 
            // lblSelectStud
            // 
            this.lblSelectStud.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectStud.ForeColor = System.Drawing.Color.White;
            this.lblSelectStud.Location = new System.Drawing.Point(130, 262);
            this.lblSelectStud.Name = "lblSelectStud";
            this.lblSelectStud.Size = new System.Drawing.Size(347, 30);
            this.lblSelectStud.TabIndex = 8;
            this.lblSelectStud.Text = "Select Students  ------------->>>";
            // 
            // cboChooseClass
            // 
            this.cboChooseClass.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboChooseClass.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classBindingSource, "Class_ID", true));
            this.cboChooseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChooseClass.Font = new System.Drawing.Font("Century Schoolbook", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChooseClass.FormattingEnabled = true;
            this.cboChooseClass.Location = new System.Drawing.Point(134, 194);
            this.cboChooseClass.Name = "cboChooseClass";
            this.cboChooseClass.Size = new System.Drawing.Size(307, 29);
            this.cboChooseClass.TabIndex = 0;
            this.cboChooseClass.SelectedIndexChanged += new System.EventHandler(this.cboChooseClass_SelectedIndexChanged_1);
            // 
            // classBindingSource
            // 
            this.classBindingSource.DataMember = "class";
            // 
            // damjanDataSet
            // 

            // 
            // lblStartDate
            // 
            this.lblStartDate.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.Color.White;
            this.lblStartDate.Location = new System.Drawing.Point(130, 347);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(347, 30);
            this.lblStartDate.TabIndex = 10;
            this.lblStartDate.Text = "Select The Start Date Of Retake:";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(162, 380);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(204, 21);
            this.dateTimePickerStart.TabIndex = 2;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Location = new System.Drawing.Point(162, 491);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(204, 21);
            this.dateTimePickerEnd.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.White;
            this.lblEndDate.Location = new System.Drawing.Point(130, 458);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(347, 30);
            this.lblEndDate.TabIndex = 13;
            this.lblEndDate.Text = "Select The End Date Of Retake:";
            // 
            // lblStep4
            // 
            this.lblStep4.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep4.ForeColor = System.Drawing.Color.White;
            this.lblStep4.Location = new System.Drawing.Point(24, 458);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(100, 30);
            this.lblStep4.TabIndex = 12;
            this.lblStep4.Text = "Step 4:";
            // 
            // btnConfirmFac
            // 
            this.btnConfirmFac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmFac.Font = new System.Drawing.Font("Century Schoolbook", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmFac.Location = new System.Drawing.Point(133, 711);
            this.btnConfirmFac.Name = "btnConfirmFac";
            this.btnConfirmFac.Size = new System.Drawing.Size(254, 53);
            this.btnConfirmFac.TabIndex = 4;
            this.btnConfirmFac.Text = "Confirm";
            this.btnConfirmFac.UseVisualStyleBackColor = true;
            this.btnConfirmFac.Click += new System.EventHandler(this.btnConfirm_Click_1);
            // 
            // chckLstBox
            // 
            this.chckLstBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chckLstBox.CheckOnClick = true;
            this.chckLstBox.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckLstBox.FormattingEnabled = true;
            this.chckLstBox.Location = new System.Drawing.Point(514, 166);
            this.chckLstBox.Name = "chckLstBox";
            this.chckLstBox.Size = new System.Drawing.Size(316, 529);
            this.chckLstBox.TabIndex = 1;
            // 
            // btnRetakesFac
            // 
            this.btnRetakesFac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetakesFac.Font = new System.Drawing.Font("Century Schoolbook", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetakesFac.Location = new System.Drawing.Point(586, 742);
            this.btnRetakesFac.Name = "btnRetakesFac";
            this.btnRetakesFac.Size = new System.Drawing.Size(162, 35);
            this.btnRetakesFac.TabIndex = 5;
            this.btnRetakesFac.Text = "View Retakes";
            this.btnRetakesFac.UseVisualStyleBackColor = true;
            this.btnRetakesFac.Click += new System.EventHandler(this.btnRetakesFac_Click);
            // 
            // classTableAdapter
            // 
            // 
            // lblSelClass
            // 
            this.lblSelClass.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelClass.ForeColor = System.Drawing.Color.White;
            this.lblSelClass.Location = new System.Drawing.Point(132, 161);
            this.lblSelClass.Name = "lblSelClass";
            this.lblSelClass.Size = new System.Drawing.Size(309, 30);
            this.lblSelClass.TabIndex = 19;
            this.lblSelClass.Text = "Select a Class:";
            // 
            // lblFacID
            // 
            this.lblFacID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblFacID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacID.ForeColor = System.Drawing.Color.White;
            this.lblFacID.Location = new System.Drawing.Point(141, 75);
            this.lblFacID.Name = "lblFacID";
            this.lblFacID.Size = new System.Drawing.Size(93, 23);
            this.lblFacID.TabIndex = 26;
            // 
            // lblFacIdNamNA
            // 
            this.lblFacIdNamNA.AutoSize = true;
            this.lblFacIdNamNA.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacIdNamNA.ForeColor = System.Drawing.Color.White;
            this.lblFacIdNamNA.Location = new System.Drawing.Point(4, 77);
            this.lblFacIdNamNA.Name = "lblFacIdNamNA";
            this.lblFacIdNamNA.Size = new System.Drawing.Size(127, 16);
            this.lblFacIdNamNA.TabIndex = 27;
            this.lblFacIdNamNA.Text = "Faculty ID/Name:";
            // 
            // lblFacName
            // 
            this.lblFacName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblFacName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacName.ForeColor = System.Drawing.Color.White;
            this.lblFacName.Location = new System.Drawing.Point(237, 75);
            this.lblFacName.Name = "lblFacName";
            this.lblFacName.Size = new System.Drawing.Size(208, 23);
            this.lblFacName.TabIndex = 28;
            // 
            // lblReason
            // 
            this.lblReason.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.ForeColor = System.Drawing.Color.White;
            this.lblReason.Location = new System.Drawing.Point(131, 575);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(88, 30);
            this.lblReason.TabIndex = 31;
            this.lblReason.Text = "Reason:";
            // 
            // cboReasonRetake
            // 
            this.cboReasonRetake.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboReasonRetake.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classBindingSource, "Class_ID", true));
            this.cboReasonRetake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReasonRetake.Font = new System.Drawing.Font("Century Schoolbook", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReasonRetake.FormattingEnabled = true;
            this.cboReasonRetake.Items.AddRange(new object[] {
            "School Related Activity",
            "ADA",
            "Other"});
            this.cboReasonRetake.Location = new System.Drawing.Point(228, 574);
            this.cboReasonRetake.Name = "cboReasonRetake";
            this.cboReasonRetake.Size = new System.Drawing.Size(220, 29);
            this.cboReasonRetake.TabIndex = 29;
            // 
            // lblStep5
            // 
            this.lblStep5.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep5.ForeColor = System.Drawing.Color.White;
            this.lblStep5.Location = new System.Drawing.Point(25, 574);
            this.lblStep5.Name = "lblStep5";
            this.lblStep5.Size = new System.Drawing.Size(100, 30);
            this.lblStep5.TabIndex = 30;
            this.lblStep5.Text = "Step 5:";
            // 
            // lblSpecifyOther
            // 
            this.lblSpecifyOther.Font = new System.Drawing.Font("Century Schoolbook", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecifyOther.ForeColor = System.Drawing.Color.White;
            this.lblSpecifyOther.Location = new System.Drawing.Point(12, 626);
            this.lblSpecifyOther.Name = "lblSpecifyOther";
            this.lblSpecifyOther.Size = new System.Drawing.Size(162, 30);
            this.lblSpecifyOther.TabIndex = 32;
            this.lblSpecifyOther.Text = "If other, specify:";
            // 
            // txtReasonRet
            // 
            this.txtReasonRet.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtReasonRet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReasonRet.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReasonRet.Location = new System.Drawing.Point(171, 623);
            this.txtReasonRet.MaxLength = 49;
            this.txtReasonRet.Name = "txtReasonRet";
            this.txtReasonRet.Size = new System.Drawing.Size(307, 27);
            this.txtReasonRet.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblFacCorner);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 67);
            this.panel1.TabIndex = 56;
            // 
            // lblFacCorner
            // 
            this.lblFacCorner.Font = new System.Drawing.Font("Century Schoolbook", 20F, System.Drawing.FontStyle.Bold);
            this.lblFacCorner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.lblFacCorner.Location = new System.Drawing.Point(24, 15);
            this.lblFacCorner.Name = "lblFacCorner";
            this.lblFacCorner.Size = new System.Drawing.Size(171, 34);
            this.lblFacCorner.TabIndex = 1;
            this.lblFacCorner.Text = "Faculty";
            this.lblFacCorner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseFac
            // 
            this.btnCloseFac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseFac.Location = new System.Drawing.Point(831, -1);
            this.btnCloseFac.Name = "btnCloseFac";
            this.btnCloseFac.Size = new System.Drawing.Size(46, 35);
            this.btnCloseFac.TabIndex = 57;
            this.btnCloseFac.Text = "X";
            this.btnCloseFac.UseVisualStyleBackColor = true;
            this.btnCloseFac.Click += new System.EventHandler(this.btnCloseFac_Click);
            // 
            // frmFaculty
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(876, 804);
            this.Controls.Add(this.btnCloseFac);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtReasonRet);
            this.Controls.Add(this.lblSpecifyOther);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.cboReasonRetake);
            this.Controls.Add(this.lblStep5);
            this.Controls.Add(this.lblFacName);
            this.Controls.Add(this.lblFacIdNamNA);
            this.Controls.Add(this.lblFacID);
            this.Controls.Add(this.lblSelClass);
            this.Controls.Add(this.btnRetakesFac);
            this.Controls.Add(this.chckLstBox);
            this.Controls.Add(this.btnConfirmFac);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStep4);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.cboChooseClass);
            this.Controls.Add(this.lblSelectStud);
            this.Controls.Add(this.lblStep6);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblFacFrmTitle);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmFaculty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learning Center Apps";
            this.Load += new System.EventHandler(this.frmFaculty_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFacFrmTitle;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep6;
        private System.Windows.Forms.Label lblSelectStud;
        private System.Windows.Forms.ComboBox cboChooseClass;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Button btnConfirmFac;
        private System.Windows.Forms.CheckedListBox chckLstBox;
        private System.Windows.Forms.Button btnRetakesFac;
        private System.Windows.Forms.BindingSource classBindingSource;
        private System.Windows.Forms.Label lblSelClass;
        private System.Windows.Forms.Label lblFacID;
        private System.Windows.Forms.Label lblFacIdNamNA;
        private System.Windows.Forms.Label lblFacName;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cboReasonRetake;
        private System.Windows.Forms.Label lblStep5;
        private System.Windows.Forms.Label lblSpecifyOther;
        private System.Windows.Forms.TextBox txtReasonRet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFacCorner;
        private System.Windows.Forms.Button btnCloseFac;
    }
}