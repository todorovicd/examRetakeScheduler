namespace Learning_Center_App
{
    partial class frmStudViewRet
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
            this.lblStudVRTitle = new System.Windows.Forms.Label();
            this.lblStudIdVRNA = new System.Windows.Forms.Label();
            this.lblStudIDVR = new System.Windows.Forms.Label();
            this.dataGridViewStudVR = new System.Windows.Forms.DataGridView();
            this.btnBackStVR = new System.Windows.Forms.Button();
            this.lblStuNameVR = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStudCorner = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudVR)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStudVRTitle
            // 
            this.lblStudVRTitle.Font = new System.Drawing.Font("Century Schoolbook", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudVRTitle.ForeColor = System.Drawing.Color.White;
            this.lblStudVRTitle.Location = new System.Drawing.Point(297, 113);
            this.lblStudVRTitle.Name = "lblStudVRTitle";
            this.lblStudVRTitle.Size = new System.Drawing.Size(257, 38);
            this.lblStudVRTitle.TabIndex = 33;
            this.lblStudVRTitle.Text = "View My Retakes";
            // 
            // lblStudIdVRNA
            // 
            this.lblStudIdVRNA.AutoSize = true;
            this.lblStudIdVRNA.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudIdVRNA.ForeColor = System.Drawing.Color.White;
            this.lblStudIdVRNA.Location = new System.Drawing.Point(2, 75);
            this.lblStudIdVRNA.Name = "lblStudIdVRNA";
            this.lblStudIdVRNA.Size = new System.Drawing.Size(129, 16);
            this.lblStudIdVRNA.TabIndex = 32;
            this.lblStudIdVRNA.Text = "Student ID/Name:";
            // 
            // lblStudIDVR
            // 
            this.lblStudIDVR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblStudIDVR.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudIDVR.ForeColor = System.Drawing.Color.White;
            this.lblStudIDVR.Location = new System.Drawing.Point(139, 74);
            this.lblStudIDVR.Name = "lblStudIDVR";
            this.lblStudIDVR.Size = new System.Drawing.Size(94, 23);
            this.lblStudIDVR.TabIndex = 31;
            // 
            // dataGridViewStudVR
            // 
            this.dataGridViewStudVR.AllowUserToAddRows = false;
            this.dataGridViewStudVR.AllowUserToDeleteRows = false;
            this.dataGridViewStudVR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudVR.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewStudVR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudVR.Location = new System.Drawing.Point(78, 171);
            this.dataGridViewStudVR.MultiSelect = false;
            this.dataGridViewStudVR.Name = "dataGridViewStudVR";
            this.dataGridViewStudVR.ReadOnly = true;
            this.dataGridViewStudVR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudVR.Size = new System.Drawing.Size(659, 264);
            this.dataGridViewStudVR.TabIndex = 51;
            // 
            // btnBackStVR
            // 
            this.btnBackStVR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.btnBackStVR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackStVR.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackStVR.Location = new System.Drawing.Point(335, 452);
            this.btnBackStVR.Name = "btnBackStVR";
            this.btnBackStVR.Size = new System.Drawing.Size(141, 35);
            this.btnBackStVR.TabIndex = 53;
            this.btnBackStVR.Text = "Back";
            this.btnBackStVR.UseVisualStyleBackColor = false;
            this.btnBackStVR.Click += new System.EventHandler(this.btnBackStVR_Click);
            // 
            // lblStuNameVR
            // 
            this.lblStuNameVR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lblStuNameVR.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStuNameVR.ForeColor = System.Drawing.Color.White;
            this.lblStuNameVR.Location = new System.Drawing.Point(231, 74);
            this.lblStuNameVR.Name = "lblStuNameVR";
            this.lblStuNameVR.Size = new System.Drawing.Size(191, 23);
            this.lblStuNameVR.TabIndex = 54;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lblStudCorner);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 67);
            this.panel1.TabIndex = 55;
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
            // frmStudViewRet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(819, 499);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStuNameVR);
            this.Controls.Add(this.btnBackStVR);
            this.Controls.Add(this.dataGridViewStudVR);
            this.Controls.Add(this.lblStudVRTitle);
            this.Controls.Add(this.lblStudIdVRNA);
            this.Controls.Add(this.lblStudIDVR);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStudViewRet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learning Center Apps";
            this.Load += new System.EventHandler(this.frmStudViewRet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudVR)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblStudVRTitle;
        private System.Windows.Forms.Label lblStudIdVRNA;
        private System.Windows.Forms.Label lblStudIDVR;
        private System.Windows.Forms.DataGridView dataGridViewStudVR;
        private System.Windows.Forms.Button btnBackStVR;
        private System.Windows.Forms.Label lblStuNameVR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStudCorner;
    }
}