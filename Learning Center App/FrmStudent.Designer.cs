namespace Learning_Center_App
{
    partial class frmStudent
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
            this.lblStudCorner = new System.Windows.Forms.Label();
            this.classBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblStudIdNA = new System.Windows.Forms.Label();
            this.lblStudID = new System.Windows.Forms.Label();
            this.lblSelClass = new System.Windows.Forms.Label();
            this.dateTimePickerStartStud = new System.Windows.Forms.DateTimePicker();
            this.cboChooseClassStud = new System.Windows.Forms.ComboBox();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStudFrmTitle = new System.Windows.Forms.Label();
            this.lblSelectDate = new System.Windows.Forms.Label();
            this.lblSelTimeRet = new System.Windows.Forms.Label();
            this.cboTimeStudent = new System.Windows.Forms.ComboBox();
            this.btnRetakes = new System.Windows.Forms.Button();
            this.btnConfirmStud = new System.Windows.Forms.Button();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.lblStudName = new System.Windows.Forms.Label();
            this.btnCloseStud = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblStudCorner);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 67);
            this.panel1.TabIndex = 0;
            // 
            // lblStudCorner
            // 
            this.lblStudCorner.Font = new System.Drawing.Font("Century Schoolbook", 20F, System.Drawing.FontStyle.Bold);
            this.lblStudCorner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.lblStudCorner.Location = new System.Drawing.Point(24, 15);
            this.lblStudCorner.Name = "lblStudCorner";
            this.lblStudCorner.Size = new System.Drawing.Size(171, 34);
            this.lblStudCorner.TabIndex = 1;
            this.lblStudCorner.Text = "Students";
            this.lblStudCorner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // classBindingSource
            // 
            this.classBindingSource.DataMember = "class";
            // 
            // lblStudIdNA
            // 
            this.lblStudIdNA.AutoSize = true;
            this.lblStudIdNA.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudIdNA.ForeColor = System.Drawing.Color.White;
            this.lblStudIdNA.Location = new System.Drawing.Point(6, 80);
            this.lblStudIdNA.Name = "lblStudIdNA";
            this.lblStudIdNA.Size = new System.Drawing.Size(129, 16);
            this.lblStudIdNA.TabIndex = 29;
            this.lblStudIdNA.Text = "Student ID/Name:";
            // 
            // lblStudID
            // 
            this.lblStudID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblStudID.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudID.ForeColor = System.Drawing.Color.White;
            this.lblStudID.Location = new System.Drawing.Point(147, 80);
            this.lblStudID.Name = "lblStudID";
            this.lblStudID.Size = new System.Drawing.Size(90, 23);
            this.lblStudID.TabIndex = 28;
            // 
            // lblSelClass
            // 
            this.lblSelClass.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelClass.ForeColor = System.Drawing.Color.White;
            this.lblSelClass.Location = new System.Drawing.Point(107, 177);
            this.lblSelClass.Name = "lblSelClass";
            this.lblSelClass.Size = new System.Drawing.Size(207, 30);
            this.lblSelClass.TabIndex = 41;
            this.lblSelClass.Text = "Select  Class ----->>";
            // 
            // dateTimePickerStartStud
            // 
            this.dateTimePickerStartStud.CalendarFont = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartStud.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartStud.Location = new System.Drawing.Point(371, 264);
            this.dateTimePickerStartStud.Name = "dateTimePickerStartStud";
            this.dateTimePickerStartStud.Size = new System.Drawing.Size(206, 21);
            this.dateTimePickerStartStud.TabIndex = 1;
            this.dateTimePickerStartStud.ValueChanged += new System.EventHandler(this.dateTimePickerStartStud_ValueChanged);
            // 
            // cboChooseClassStud
            // 
            this.cboChooseClassStud.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboChooseClassStud.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classBindingSource, "Class_ID", true));
            this.cboChooseClassStud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChooseClassStud.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChooseClassStud.FormattingEnabled = true;
            this.cboChooseClassStud.Location = new System.Drawing.Point(349, 174);
            this.cboChooseClassStud.Name = "cboChooseClassStud";
            this.cboChooseClassStud.Size = new System.Drawing.Size(251, 31);
            this.cboChooseClassStud.TabIndex = 0;
            this.cboChooseClassStud.SelectedIndexChanged += new System.EventHandler(this.cboChooseClassStud_SelectedIndexChanged);
            // 
            // lblStep3
            // 
            this.lblStep3.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3.ForeColor = System.Drawing.Color.White;
            this.lblStep3.Location = new System.Drawing.Point(6, 345);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(100, 30);
            this.lblStep3.TabIndex = 33;
            this.lblStep3.Text = "Step 3:";
            // 
            // lblStep2
            // 
            this.lblStep2.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2.ForeColor = System.Drawing.Color.White;
            this.lblStep2.Location = new System.Drawing.Point(6, 262);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(100, 30);
            this.lblStep2.TabIndex = 32;
            this.lblStep2.Text = "Step 2:";
            // 
            // lblStep1
            // 
            this.lblStep1.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1.ForeColor = System.Drawing.Color.White;
            this.lblStep1.Location = new System.Drawing.Point(6, 174);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(100, 30);
            this.lblStep1.TabIndex = 31;
            this.lblStep1.Text = "Step 1:";
            // 
            // lblStudFrmTitle
            // 
            this.lblStudFrmTitle.Font = new System.Drawing.Font("Century Schoolbook", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudFrmTitle.ForeColor = System.Drawing.Color.White;
            this.lblStudFrmTitle.Location = new System.Drawing.Point(118, 116);
            this.lblStudFrmTitle.Name = "lblStudFrmTitle";
            this.lblStudFrmTitle.Size = new System.Drawing.Size(410, 38);
            this.lblStudFrmTitle.TabIndex = 30;
            this.lblStudFrmTitle.Text = "Registering For Exam Retake";
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDate.ForeColor = System.Drawing.Color.White;
            this.lblSelectDate.Location = new System.Drawing.Point(107, 264);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(254, 30);
            this.lblSelectDate.TabIndex = 42;
            this.lblSelectDate.Text = "Select Date of retake --->";
            // 
            // lblSelTimeRet
            // 
            this.lblSelTimeRet.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelTimeRet.ForeColor = System.Drawing.Color.White;
            this.lblSelTimeRet.Location = new System.Drawing.Point(107, 348);
            this.lblSelTimeRet.Name = "lblSelTimeRet";
            this.lblSelTimeRet.Size = new System.Drawing.Size(265, 30);
            this.lblSelTimeRet.TabIndex = 43;
            this.lblSelTimeRet.Text = "Select Time of retake --->";
            // 
            // cboTimeStudent
            // 
            this.cboTimeStudent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboTimeStudent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classBindingSource, "Class_ID", true));
            this.cboTimeStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeStudent.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimeStudent.FormattingEnabled = true;
            this.cboTimeStudent.Location = new System.Drawing.Point(406, 342);
            this.cboTimeStudent.Name = "cboTimeStudent";
            this.cboTimeStudent.Size = new System.Drawing.Size(141, 31);
            this.cboTimeStudent.TabIndex = 2;
            // 
            // btnRetakes
            // 
            this.btnRetakes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetakes.Font = new System.Drawing.Font("Century Schoolbook", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetakes.Location = new System.Drawing.Point(240, 566);
            this.btnRetakes.Name = "btnRetakes";
            this.btnRetakes.Size = new System.Drawing.Size(162, 35);
            this.btnRetakes.TabIndex = 4;
            this.btnRetakes.Text = "View Retakes";
            this.btnRetakes.UseVisualStyleBackColor = true;
            this.btnRetakes.Click += new System.EventHandler(this.btnRetakes_Click);
            // 
            // btnConfirmStud
            // 
            this.btnConfirmStud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmStud.Font = new System.Drawing.Font("Century Schoolbook", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmStud.Location = new System.Drawing.Point(183, 450);
            this.btnConfirmStud.Name = "btnConfirmStud";
            this.btnConfirmStud.Size = new System.Drawing.Size(254, 53);
            this.btnConfirmStud.TabIndex = 3;
            this.btnConfirmStud.Text = "Confirm";
            this.btnConfirmStud.UseVisualStyleBackColor = true;
            this.btnConfirmStud.Click += new System.EventHandler(this.btnConfirmStud_Click_1);
            // 
            // lblStep4
            // 
            this.lblStep4.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep4.ForeColor = System.Drawing.Color.White;
            this.lblStep4.Location = new System.Drawing.Point(8, 462);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(149, 30);
            this.lblStep4.TabIndex = 46;
            this.lblStep4.Text = "Step 4: ----->";
            // 
            // lblStudName
            // 
            this.lblStudName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblStudName.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudName.ForeColor = System.Drawing.Color.White;
            this.lblStudName.Location = new System.Drawing.Point(237, 80);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(233, 23);
            this.lblStudName.TabIndex = 50;
            // 
            // btnCloseStud
            // 
            this.btnCloseStud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseStud.Location = new System.Drawing.Point(600, -1);
            this.btnCloseStud.Name = "btnCloseStud";
            this.btnCloseStud.Size = new System.Drawing.Size(46, 35);
            this.btnCloseStud.TabIndex = 51;
            this.btnCloseStud.Text = "X";
            this.btnCloseStud.UseVisualStyleBackColor = true;
            this.btnCloseStud.Click += new System.EventHandler(this.btnCloseStud_Click);
            // 
            // frmStudent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(645, 613);
            this.Controls.Add(this.btnCloseStud);
            this.Controls.Add(this.lblStudName);
            this.Controls.Add(this.btnRetakes);
            this.Controls.Add(this.btnConfirmStud);
            this.Controls.Add(this.lblStep4);
            this.Controls.Add(this.cboTimeStudent);
            this.Controls.Add(this.lblSelTimeRet);
            this.Controls.Add(this.lblSelectDate);
            this.Controls.Add(this.lblSelClass);
            this.Controls.Add(this.dateTimePickerStartStud);
            this.Controls.Add(this.cboChooseClassStud);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblStudFrmTitle);
            this.Controls.Add(this.lblStudIdNA);
            this.Controls.Add(this.lblStudID);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learning Center Apps";
            this.Load += new System.EventHandler(this.FrmStudent_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource classBindingSource;
        private System.Windows.Forms.Label lblStudIdNA;
        private System.Windows.Forms.Label lblStudID;
        private System.Windows.Forms.Label lblSelClass;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartStud;
        private System.Windows.Forms.ComboBox cboChooseClassStud;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStudFrmTitle;
        private System.Windows.Forms.Label lblSelectDate;
        private System.Windows.Forms.Label lblSelTimeRet;
        private System.Windows.Forms.ComboBox cboTimeStudent;
        private System.Windows.Forms.Button btnRetakes;
        private System.Windows.Forms.Button btnConfirmStud;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Label lblStudName;
        private System.Windows.Forms.Label lblStudCorner;
        private System.Windows.Forms.Button btnCloseStud;
    }
}