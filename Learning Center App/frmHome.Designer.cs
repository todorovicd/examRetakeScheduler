namespace Learning_Center_App
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.btnFaculty = new System.Windows.Forms.Button();
            this.pnlName = new System.Windows.Forms.Panel();
            this.lblNameApplication = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserPass = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblInstructionHome = new System.Windows.Forms.Label();
            this.lblWelcStud = new System.Windows.Forms.Label();
            this.lblWelcFac = new System.Windows.Forms.Label();
            this.lblWelcManag = new System.Windows.Forms.Label();
            this.lblWelcAdmin = new System.Windows.Forms.Label();
            this.lblChoseCat = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linklblPassReset = new System.Windows.Forms.LinkLabel();
            this.toolTipPasswordInfo = new System.Windows.Forms.ToolTip(this.components);
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnCloseHome = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.btnStudents);
            this.panel1.Controls.Add(this.btnAdmin);
            this.panel1.Controls.Add(this.btnManage);
            this.panel1.Controls.Add(this.btnFaculty);
            this.panel1.Controls.Add(this.pnlName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 571);
            this.panel1.TabIndex = 0;
            // 
            // btnStudents
            // 
            this.btnStudents.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStudents.BackgroundImage")));
            this.btnStudents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Century Schoolbook", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Location = new System.Drawing.Point(-1, 75);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(312, 118);
            this.btnStudents.TabIndex = 2;
            this.btnStudents.Text = "Students";
            this.btnStudents.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdmin.BackgroundImage")));
            this.btnAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Century Schoolbook", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdmin.Location = new System.Drawing.Point(-1, 447);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(312, 118);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnManage
            // 
            this.btnManage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnManage.BackgroundImage")));
            this.btnManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnManage.FlatAppearance.BorderSize = 0;
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.Font = new System.Drawing.Font("Century Schoolbook", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManage.ForeColor = System.Drawing.Color.White;
            this.btnManage.Location = new System.Drawing.Point(-1, 323);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(312, 118);
            this.btnManage.TabIndex = 4;
            this.btnManage.Text = "Management";
            this.btnManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // btnFaculty
            // 
            this.btnFaculty.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFaculty.BackgroundImage")));
            this.btnFaculty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFaculty.FlatAppearance.BorderSize = 0;
            this.btnFaculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaculty.Font = new System.Drawing.Font("Century Schoolbook", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFaculty.ForeColor = System.Drawing.Color.White;
            this.btnFaculty.Location = new System.Drawing.Point(-1, 199);
            this.btnFaculty.Name = "btnFaculty";
            this.btnFaculty.Size = new System.Drawing.Size(312, 118);
            this.btnFaculty.TabIndex = 3;
            this.btnFaculty.Text = "Faculty";
            this.btnFaculty.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFaculty.UseVisualStyleBackColor = true;
            this.btnFaculty.Click += new System.EventHandler(this.btnFaculty_Click);
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pnlName.Controls.Add(this.lblNameApplication);
            this.pnlName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlName.Location = new System.Drawing.Point(0, 0);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(312, 70);
            this.pnlName.TabIndex = 2;
            // 
            // lblNameApplication
            // 
            this.lblNameApplication.AutoSize = true;
            this.lblNameApplication.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.lblNameApplication.Location = new System.Drawing.Point(35, 19);
            this.lblNameApplication.Name = "lblNameApplication";
            this.lblNameApplication.Size = new System.Drawing.Size(234, 30);
            this.lblNameApplication.TabIndex = 14;
            this.lblNameApplication.Text = "Retake Scheduler\r\n";
            this.lblNameApplication.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(410, 256);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(129, 25);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Username:";
            this.lblUserName.Visible = false;
            // 
            // lblUserPass
            // 
            this.lblUserPass.AutoSize = true;
            this.lblUserPass.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPass.ForeColor = System.Drawing.Color.White;
            this.lblUserPass.Location = new System.Drawing.Point(410, 324);
            this.lblUserPass.Name = "lblUserPass";
            this.lblUserPass.Size = new System.Drawing.Size(126, 25);
            this.lblUserPass.TabIndex = 3;
            this.lblUserPass.Text = "Password:";
            this.lblUserPass.Visible = false;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUserName.Font = new System.Drawing.Font("Century Schoolbook", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(552, 255);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(217, 32);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Visible = false;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPass.Font = new System.Drawing.Font("Century Schoolbook", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(552, 323);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(217, 32);
            this.txtPass.TabIndex = 5;
            this.toolTipPasswordInfo.SetToolTip(this.txtPass, "Your default password is your Date Of Birth in the following format \"mm-dd-YYYY\"");
            this.txtPass.Visible = false;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown_1);
            // 
            // lblInstructionHome
            // 
            this.lblInstructionHome.AutoSize = true;
            this.lblInstructionHome.Font = new System.Drawing.Font("Century Schoolbook", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructionHome.ForeColor = System.Drawing.Color.White;
            this.lblInstructionHome.Location = new System.Drawing.Point(381, 199);
            this.lblInstructionHome.Name = "lblInstructionHome";
            this.lblInstructionHome.Size = new System.Drawing.Size(407, 21);
            this.lblInstructionHome.TabIndex = 6;
            this.lblInstructionHome.Text = "Please Enter Username and Password To Proceed";
            this.lblInstructionHome.Visible = false;
            // 
            // lblWelcStud
            // 
            this.lblWelcStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcStud.ForeColor = System.Drawing.Color.White;
            this.lblWelcStud.Location = new System.Drawing.Point(443, 104);
            this.lblWelcStud.Name = "lblWelcStud";
            this.lblWelcStud.Size = new System.Drawing.Size(288, 32);
            this.lblWelcStud.TabIndex = 7;
            this.lblWelcStud.Text = "Welcome Student";
            this.lblWelcStud.Visible = false;
            // 
            // lblWelcFac
            // 
            this.lblWelcFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcFac.ForeColor = System.Drawing.Color.White;
            this.lblWelcFac.Location = new System.Drawing.Point(443, 104);
            this.lblWelcFac.Name = "lblWelcFac";
            this.lblWelcFac.Size = new System.Drawing.Size(288, 32);
            this.lblWelcFac.TabIndex = 8;
            this.lblWelcFac.Text = "Welcome Faculty";
            this.lblWelcFac.Visible = false;
            // 
            // lblWelcManag
            // 
            this.lblWelcManag.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcManag.ForeColor = System.Drawing.Color.White;
            this.lblWelcManag.Location = new System.Drawing.Point(421, 104);
            this.lblWelcManag.Name = "lblWelcManag";
            this.lblWelcManag.Size = new System.Drawing.Size(354, 32);
            this.lblWelcManag.TabIndex = 9;
            this.lblWelcManag.Text = "Welcome Management";
            this.lblWelcManag.Visible = false;
            // 
            // lblWelcAdmin
            // 
            this.lblWelcAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcAdmin.ForeColor = System.Drawing.Color.White;
            this.lblWelcAdmin.Location = new System.Drawing.Point(455, 104);
            this.lblWelcAdmin.Name = "lblWelcAdmin";
            this.lblWelcAdmin.Size = new System.Drawing.Size(288, 32);
            this.lblWelcAdmin.TabIndex = 10;
            this.lblWelcAdmin.Text = "Welcome Admin";
            this.lblWelcAdmin.Visible = false;
            // 
            // lblChoseCat
            // 
            this.lblChoseCat.Font = new System.Drawing.Font("Century Schoolbook", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoseCat.ForeColor = System.Drawing.Color.White;
            this.lblChoseCat.Location = new System.Drawing.Point(364, 86);
            this.lblChoseCat.Name = "lblChoseCat";
            this.lblChoseCat.Size = new System.Drawing.Size(467, 50);
            this.lblChoseCat.TabIndex = 11;
            this.lblChoseCat.Text = "Please Choose Your Category";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(510, 453);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(167, 37);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Visible = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linklblPassReset
            // 
            this.linklblPassReset.AutoSize = true;
            this.linklblPassReset.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblPassReset.LinkColor = System.Drawing.Color.White;
            this.linklblPassReset.Location = new System.Drawing.Point(570, 361);
            this.linklblPassReset.Name = "linklblPassReset";
            this.linklblPassReset.Size = new System.Drawing.Size(180, 16);
            this.linklblPassReset.TabIndex = 13;
            this.linklblPassReset.TabStop = true;
            this.linklblPassReset.Text = "Password Change/Reset Portal";
            this.linklblPassReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblPassReset_LinkClicked);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panelLeft.Location = new System.Drawing.Point(313, 76);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(7, 118);
            this.panelLeft.TabIndex = 14;
            // 
            // btnCloseHome
            // 
            this.btnCloseHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseHome.Location = new System.Drawing.Point(831, -1);
            this.btnCloseHome.Name = "btnCloseHome";
            this.btnCloseHome.Size = new System.Drawing.Size(46, 35);
            this.btnCloseHome.TabIndex = 15;
            this.btnCloseHome.Text = "X";
            this.btnCloseHome.UseVisualStyleBackColor = true;
            this.btnCloseHome.Click += new System.EventHandler(this.btnCloseHome_Click);
            // 
            // frmHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(876, 571);
            this.Controls.Add(this.btnCloseHome);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.linklblPassReset);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblChoseCat);
            this.Controls.Add(this.lblWelcAdmin);
            this.Controls.Add(this.lblWelcManag);
            this.Controls.Add(this.lblWelcFac);
            this.Controls.Add(this.lblWelcStud);
            this.Controls.Add(this.lblInstructionHome);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserPass);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learning Center Apps";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.panel1.ResumeLayout(false);
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnFaculty;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserPass;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblInstructionHome;
        private System.Windows.Forms.Label lblWelcStud;
        private System.Windows.Forms.Label lblWelcFac;
        private System.Windows.Forms.Label lblWelcManag;
        private System.Windows.Forms.Label lblWelcAdmin;
        private System.Windows.Forms.Label lblChoseCat;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linklblPassReset;
        private System.Windows.Forms.ToolTip toolTipPasswordInfo;
        private System.Windows.Forms.Label lblNameApplication;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnCloseHome;
    }
}

