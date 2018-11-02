using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;


namespace Learning_Center_App
{
    public partial class frmAdmin : Form
    {

        SqlConnection NAME = new SqlConnection("Data Source =<SERVER NAME>;Initial Catalog = <DATABASE NAME>; Integrated Security = True; MultipleActiveResultSets=True");

        public static string classIDGeneral = "";    //

        public static string facultyID = "";         //

        public static string classChosenID = "";     //

        //call following later in different voids in order to populate datagridview with values from database 
        SqlDataAdapter dataAdapt = new SqlDataAdapter();
        DataTable dataTbl = new DataTable();
        BindingSource bindSource = new BindingSource();
        SqlCommandBuilder cmdBuilder = new SqlCommandBuilder();


        public frmAdmin()
        {
            InitializeComponent();
        }

        private void AdminFrm_Load(object sender, EventArgs e)
        {
            this.dataGridViewAdminVR.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridViewUsersRoles.DefaultCellStyle.ForeColor = Color.Black;

            
            txtRolPassword.UseSystemPasswordChar = true;

            lblAdminIDNumbers.Text = frmHome.setValue;


            FillCombo();  //inistialize void FillCombo (populate it with classes for this specific faculty member)

            this.dataGridViewAdminVR.Columns["RowNum"].Visible = false;    //first column in DataGridView (for row numbers) for counting is not visible untill search buttons pressed

            this.pnlMngRetAdmin.Visible = false;    //panel with all elements for retake management is hidden untill Button is pressed


            dateTimePickerStart.MinDate = DateTime.Now;   
            dateTimePickerStart.MaxDate = DateTime.Now.AddDays(15);    //first DateTimePicker maximum date is set to curent date plus 15 days

            dateTimePickerEnd.MinDate = DateTime.Now;                  //second DateTimePicker minimum date is set to current date
            dateTimePickerEnd.MaxDate = DateTime.Now.AddDays(15);      //second DateTimePicker maximum date is set to curent date plus 15 days

            dateTimePickerSched.MinDate = DateTime.Now;                //third DateTimePicker minimum date is set to current date
            dateTimePickerSched.MaxDate = DateTime.Now.AddDays(15);    //third DateTimePicker maximum date is set to curent date plus 15 days

            dateTimePickerSched.Visible = false;
            cboSchedTime.Visible = false;

            btnHideSchedTime.Visible = false;
            btnHideSchedDate.Visible = false;

            this.pnlRolesAdmin.Visible = false;

        }

        void FillCombo()   ////fills combobox with all classes from retake table
        {
            string Query = "SELECT Class_ID, Class_Description FROM dbo.class;";    //query to search for classes (ID and description) in retake table

            SqlCommand Command = new SqlCommand(Query, NAME);
            SqlDataReader dataReader;

            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();

                    dataReader = Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        string classID = dataReader.GetValue(0).ToString();       //gets Class ID value from dataReader and converts it into string 
                        string classDescrip = dataReader.GetValue(1).ToString();  //gets Class Description value from dataReader and converts it into string

                        cboClassFacSrchPan.Items.Add(string.Format("{0}  {1}", classID, classDescrip));   //concatenates Class ID and Class Description to be displayed in combobox
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            if (NAME.State == ConnectionState.Open)
            {
                NAME.Close();
            }
        }

        private void cboClassFacSrchPan_SelectedIndexChanged(object sender, EventArgs e)      //new class selected from the combobox with classes
        {
            string ClassIdentifierString = this.cboClassFacSrchPan.GetItemText(this.cboClassFacSrchPan.SelectedItem);     //converting selected item to the string and getting it ready to be cropped
            string classIDent = ClassIdentifierString.Substring(0, 5);    //cropping class ID from the whole item selected (Class ID and Description)

            classIDGeneral = classIDent.ToString();   //passing the cropped string (class ID) to the public static string (classIDGeneral) so it can be passed around and called in other voids

        }

        private void btnSrchClass_Click_1(object sender, EventArgs e)
        {
            if (cboClassFacSrchPan.SelectedItem == null)   //making sure there's selection in the combobox with classes. If nothing selected, then no action. 
            {

            }
            else
            {
                this.dataGridViewAdminVR.Columns["RowNum"].Visible = true;    //first column in DataGridView (for row numbers) for counting is visible when search buttons pressed

                dataTbl.Clear();   //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

                //query to select all the columns from the retake table based on Class ID from combobox selection
                string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Retake_ID AS ""Retake ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Start Date"", Retake_EndDate AS ""End Date"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"", Retake_Reason AS ""Reason"" FROM dbo.retake WHERE Class_ID = @ClassID";
                SqlCommand Command = new SqlCommand(Query, NAME);
                Command.Parameters.AddWithValue("@ClassID", classIDGeneral.ToString());


                try
                {
                    if (NAME.State == ConnectionState.Closed)
                    {
                        NAME.Open();
                    }

                    //following few lines are used to populate datagridview with values from the database based on the query 
                    dataAdapt.SelectCommand = Command;
                    dataAdapt.Fill(dataTbl);
                    bindSource.DataSource = dataTbl;
                    dataGridViewAdminVR.DataSource = bindSource;
                    dataAdapt.Update(dataTbl);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                if (NAME.State == ConnectionState.Open)
                {
                    NAME.Close();
                }
            }
        }

        private void txtUserIDSrch_KeyPress(object sender, KeyPressEventArgs e)    //void to make sure that textbox for User ID (student/faculty) only accepts numbers
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)    //only numbers accepted ... textbox also has limited length (set to maxLength = 8 in properties)
            {
                e.Handled = true;
            }
        }

        private void btnSrchUserIDNam_Click(object sender, EventArgs e)
        {
            this.dataGridViewAdminVR.Columns["RowNum"].Visible = true;     //first column in DataGridView (for row numbers) for counting is visible when search buttons pressed

            if (txtUserNamSrch.Text.Length == 0)   //making sure there's no input in the textbox
            {
                if (txtUserIDSrch.Text.Length > 0)    //making sure there's input in the textbox
                {
                    if (cboWhoAdmin.Text == "Student")   //if the selection in the combobox is student then proceed with following code block
                    {
                        dataTbl.Clear();    //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

                        //query to select all the columns from the retake table based on student ID (last few number, or only one - used wildcard)
                        string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"",Retake_ID AS ""Retake ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Start Date"", Retake_EndDate AS ""End Date"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"", Retake_Reason AS ""Reason"" FROM dbo.retake WHERE Student_ID LIKE @userID";
                        SqlCommand CommanddDd = new SqlCommand(Query, NAME);
                        CommanddDd.Parameters.AddWithValue("@userID", "%" + txtUserIDSrch.Text);    //assigning parameters to the User ID (passed text from Textbox with Student ID, along with wildcard)

                        try
                        {
                            if (NAME.State == ConnectionState.Closed)
                            {
                                NAME.Open();
                            }

                            //following few lines are used to populate datagridview with values from the database based on the query 
                            dataAdapt.SelectCommand = CommanddDd;
                            dataAdapt.Fill(dataTbl);
                            bindSource.DataSource = dataTbl;
                            dataGridViewAdminVR.DataSource = bindSource;
                            dataAdapt.Update(dataTbl);

                        }
                        catch (Exception ex)
                        {
                          
                            MessageBox.Show(ex.Message);
                        }

                        if (NAME.State == ConnectionState.Open)
                        {
                            NAME.Close();
                        }
                    }
                    else if (cboWhoAdmin.Text == "Faculty")   //if the selection in the combobox is faculty then proceed with following code block
                    {
                        dataTbl.Clear();   //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

                        //query to select all the columns from the retake table based on faculty ID (last few number, or only one - used wildcard)
                        string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Retake_ID AS ""Retake ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Start Date"", Retake_EndDate AS ""End Date"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"", Retake_Reason AS ""Reason"" FROM dbo.retake WHERE Faculty_ID LIKE @userID";
                        SqlCommand CommanddDd = new SqlCommand(Query, NAME);
                        CommanddDd.Parameters.AddWithValue("@userID", "%" + txtUserIDSrch.Text);    //assigning parameters to the User ID (passed text from Textbox with Faculty ID, along with wildcard)

                        try
                        {
                            if (NAME.State == ConnectionState.Closed)
                            {
                                NAME.Open();
                            }

                            //following few lines are used to populate datagridview with values from the database based on the query 
                            dataAdapt.SelectCommand = CommanddDd;
                            dataAdapt.Fill(dataTbl);
                            bindSource.DataSource = dataTbl;
                            dataGridViewAdminVR.DataSource = bindSource;
                            dataAdapt.Update(dataTbl);

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                        if (NAME.State == ConnectionState.Open)
                        {
                            NAME.Close();
                        }
                    }

                }
                else if (txtUserIDSrch.Text.Length == 0)  //making sure there's no input in the textbox. if no input then don't do anything
                {
                   
                }
            }
            else if (txtUserNamSrch.Text.Length > 0)   //making sure there's input in the textbox
            {
                if (txtUserIDSrch.Text.Length == 0)   //making sure there's no input in the textbox
                {
                    if (cboWhoAdmin.Text == "Student")   //if the selection in the combobox is student then proceed with following code block
                    {
                        dataTbl.Clear();  //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

                        //query to select all the columns from the retake table based on student name (first few letters, or only one - used wildcard)
                        string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Retake_ID AS ""Retake ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Start Date"", Retake_EndDate AS ""End Date"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"", Retake_Reason AS ""Reason"" FROM dbo.retake WHERE Student_Name LIKE @userName";
                        SqlCommand CommanDDD = new SqlCommand(Query, NAME);
                        CommanDDD.Parameters.AddWithValue("@userName", txtUserNamSrch.Text + "%");  //assigning parameters to the User Name (passed text from Textbox with Student Name, along with wildcard)

                        try
                        {
                            if (NAME.State == ConnectionState.Closed)
                            {
                                NAME.Open();
                            }

                            //following few lines are used to populate datagridview with values from the database based on the query 
                            dataAdapt.SelectCommand = CommanDDD;
                            dataAdapt.Fill(dataTbl);
                            bindSource.DataSource = dataTbl;
                            dataGridViewAdminVR.DataSource = bindSource;
                            dataAdapt.Update(dataTbl);

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                        if (NAME.State == ConnectionState.Open)
                        {
                            NAME.Close();
                        }
                    }
                    else if (cboWhoAdmin.Text == "Faculty")
                    {
                        dataTbl.Clear();   //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

                        //query to select all the columns from the retake table based on user name (last few number, or only one - used wildcard)
                        string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Retake_ID AS ""Retake ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Start Date"", Retake_EndDate AS ""End Date"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"", Retake_Reason AS ""Reason"" FROM dbo.retake WHERE Faculty_Name LIKE @userName";
                        SqlCommand CommanDDD = new SqlCommand(Query, NAME);
                        CommanDDD.Parameters.AddWithValue("@userName", txtUserNamSrch.Text + "%");   //assigning parameters to the User Name (passed text from Textbox with Faculty Name, along with wildcard)

                        try
                        {
                            if (NAME.State == ConnectionState.Closed)
                            {
                                NAME.Open();
                            }

                            //following few lines are used to populate datagridview with values from the database based on the query 
                            dataAdapt.SelectCommand = CommanDDD;
                            dataAdapt.Fill(dataTbl);
                            bindSource.DataSource = dataTbl;
                            dataGridViewAdminVR.DataSource = bindSource;
                            dataAdapt.Update(dataTbl);

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                        if (NAME.State == ConnectionState.Open)
                        {
                            NAME.Close();
                        }
                    }
                }
            }
        }

        private void btnSrchDate_Click(object sender, EventArgs e)
        {
            this.dataGridViewAdminVR.Columns["RowNum"].Visible = true;    //first column in DataGridView (for row numbers) for counting is visible when search buttons pressed

            if (dateTimePickerTo.Value < dateTimePickerFrom.Value)   //making sure the dates are in appropriate order ("from" before "to")
            {

                MessageBox.Show("End Date has to be after Start Date.");    //warning message if dates not in order
            }

            else if (dateTimePickerTo.Value >= dateTimePickerFrom.Value)    //making sure the dates are in appropriate order ("from" before "to")
            {
                dataTbl.Clear();   //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)


                //query to select all the columns from the retake table based on Retake Start Date (from - to)
                string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Retake_ID AS ""Retake ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Start Date"", Retake_EndDate AS ""End Date"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"", Retake_Reason AS ""Reason"" FROM dbo.retake WHERE Retake_StartDate BETWEEN '" + dateTimePickerFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + dateTimePickerTo.Value.Date.ToString("yyyy-MM-dd") + "'";
                SqlCommand Command = new SqlCommand(Query, NAME);

                try
                {
                    if (NAME.State == ConnectionState.Closed)
                    {
                        NAME.Open();
                    }

                    //following few lines are used to populate datagridview with values from the database based on the query 
                    dataAdapt.SelectCommand = Command;
                    dataAdapt.Fill(dataTbl);
                    bindSource.DataSource = dataTbl;
                    dataGridViewAdminVR.DataSource = bindSource;
                    dataAdapt.Update(dataTbl);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            if (NAME.State == ConnectionState.Open)
            {
                NAME.Close();
            }
        }

        private void dataGridViewAdminVR_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridViewAdminVR.Rows[e.RowIndex].Cells["RowNum"].Value = (e.RowIndex + 1).ToString();  //adding a new column to dataGridView for row numbers(self incrementing based on numbers of rows/records displayed from database)
        }

        private void btnVwRetakes_Click(object sender, EventArgs e)
        {
            //making elements appropriate to the button pressed (View Retakes, Manage Retakes) visible in the form
            this.panelSrchClassIDAdmin.Visible = true;
            this.paneSrchStuFacAdmin.Visible = true;
            this.panelSrchDateAdmin.Visible = true;
            this.dataGridViewAdminVR.Visible = true;
            this.lblOr1.Visible = true;
            this.lblOr2.Visible = true;
            this.pnlMngRetAdmin.Visible = false;
            this.pnlRolesAdmin.Visible = false;

        }

        private void btnMngRetakes_Click(object sender, EventArgs e)
        {
            //making elements appropriate to the button pressed (View Retakes, Manage Retakes) visible in the form
            this.panelSrchClassIDAdmin.Visible = false;
            this.paneSrchStuFacAdmin.Visible = false;
            this.panelSrchDateAdmin.Visible = false;
            this.dataGridViewAdminVR.Visible = false;
            this.lblOr1.Visible = false;
            this.lblOr2.Visible = false;
            this.pnlMngRetAdmin.Visible = true;
            this.pnlRolesAdmin.Visible = false;

        }





        //* * * * * * * * * * * * * * * * * *       MANAGE RETAKES CODE - FROM HERE DOWN      * * * * * * * * * * * * * * * * * *//





        private void btnDeleteRec_Click(object sender, EventArgs e)  //delete Record Buttom
        {
            if (txtRetID.Text.Trim().Length == 0)   //making sure there's input in the textbox
            {
                MessageBox.Show("Enter Retake ID to delete record.");  //warning message if there's no input in the Retake ID textbox
            }
            else
            {
                string msgBX = "You are about to permanently delete record from database with the Retake ID: " + txtRetID.Text + "";  //dialogue box, confirm deletion of record

                DialogResult res = MessageBox.Show("'" + msgBX + "'", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {

                    //query to delete specific record from database based on the Retake ID (input from the textbox)
                    string delRecQuery = "DELETE from dbo.retake WHERE Retake_ID = '" + txtRetID.Text + "'";

                    SqlCommand command = new SqlCommand(delRecQuery, NAME);

                    if (NAME.State == ConnectionState.Closed)
                    {
                        NAME.Open();
                    }

                    try
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Record has been deleted successfully");



                            //log activity block here //////////////////////////////////////////////////////////////////////////////

                            string hostName = Dns.GetHostName();
                            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                            string userName = Environment.UserName;

                            string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES ('Admin', @UserLogged, 'Retake Deleted', @HostName, GETDATE(), @IPAddress)";

                            SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                            cmdAvtivityLog.Parameters.AddWithValue("@Username", lblAdminIDNumbers.Text);
                            cmdAvtivityLog.Parameters.AddWithValue("@UserLogged", userName.ToString());
                            cmdAvtivityLog.Parameters.AddWithValue("@HostName", hostName.ToString());
                            cmdAvtivityLog.Parameters.AddWithValue("@IPAddress", myIP.ToString());


                            try
                            {
                                if (cmdAvtivityLog.ExecuteNonQuery() == 1)
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }


                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////


                        }
                        else
                        {
                            MessageBox.Show("Something is wrong. Please doublecheck the data.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (NAME.State == ConnectionState.Open)
                    {
                        NAME.Close();
                    }
                }
            }                        
        }

        private void btnUpdateRec_Click(object sender, EventArgs e)  //update record button 
        {
            if (txtRetID.Text.Trim().Length == 0)    //making sure there's input in the textbox
            {
                MessageBox.Show("Enter Retake ID to update a record.");      //warning message if there's no input in the Retake ID textbox
            }
            else
            {
                if (dateTimePickerEnd.Value < dateTimePickerStart.Value)   //making sure the dates are in appropriate order ("from" before "to")
                {                
                    MessageBox.Show("End Date has to be after Start Date.");
                }
                else if (dateTimePickerEnd.Value >= dateTimePickerStart.Value)   //making sure the dates are in appropriate order ("from" before "to")
                {
                    if (cboRetStatus.Text.Length == 0)  //making sure there's input in the textbox
                    {
                        MessageBox.Show("Please select a valide Retake Status");   //warning message if there's no input in the Retake ID textbox

                    }
                    else if (cboRetStatus.Text.Length > 0)   //making sure there's input in the textbox
                    {
                        string msgBX = "You are about to update record with the Retake ID: " + txtRetID.Text + "";

                        DialogResult res = MessageBox.Show("'" + msgBX + "'", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);  //dialogue box, confirm update of the record

                        if (res == DialogResult.OK)
                        {
                            if (dateTimePickerSched.Visible == true && cboSchedTime.Visible == true)   //setting Retake Scheduled Date/Time if that needs to be changed along with something else.
                            {
                                if (dateTimePickerSched.Value >= dateTimePickerStart.Value && dateTimePickerSched.Value <= dateTimePickerEnd.Value)   //making sure the dates are in appropriate order (scheduled date in between "from" and "to")
                                {
                                    //query to update record in the database based on all parameters: Start / End Date, Scheduled Date/ Time, Retake Status and Retake ID.
                                    string updateQuery = "UPDATE dbo.retake SET Retake_StartDate = '" + dateTimePickerStart.Value.Date.ToString("yyyy-MM-dd") + "', Retake_EndDate = '" + dateTimePickerEnd.Value.Date.ToString("yyyy-MM-dd") + "', Student_Scheduled_Date = '" + dateTimePickerSched.Value.Date.ToString("yyyy-MM-dd") + "', Student_Scheduled_Time = @ScheduledTime, Retake_Status = @RetakeStatus  WHERE Retake_ID = @RetakeID";

                                    SqlCommand command = new SqlCommand(updateQuery, NAME);
                                    command.Parameters.AddWithValue("@ScheduledTime", cboSchedTime.Text);
                                    command.Parameters.AddWithValue("@RetakeStatus", cboRetStatus.Text);
                                    command.Parameters.AddWithValue("@RetakeID", txtRetID.Text);



                                    if (NAME.State == ConnectionState.Closed)
                                    {
                                        NAME.Open();
                                    }

                                    try
                                    {
                                        if (command.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Record has been updated successfully");


                                            //log activity block here //////////////////////////////////////////////////////////////////////////////

                                            string hostName = Dns.GetHostName();
                                            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                                            string userName = Environment.UserName;



                                            string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@Username, @UserLogged, 'Retake Updated', @HostName, GETDATE(), @IPAddress)";

                                            SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                                            cmdAvtivityLog.Parameters.AddWithValue("@Username", lblAdminIDNumbers.Text);
                                            cmdAvtivityLog.Parameters.AddWithValue("@UserLogged", userName.ToString());
                                            cmdAvtivityLog.Parameters.AddWithValue("@HostName", hostName.ToString());
                                            cmdAvtivityLog.Parameters.AddWithValue("@IPAddress", myIP.ToString());

                                            try
                                            {
                                                if (cmdAvtivityLog.ExecuteNonQuery() == 1)
                                                {

                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message);
                                            }


                                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////


                                        }
                                        else
                                        {
                                            MessageBox.Show("Something is wrong. Please doublecheck the data.");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }

                                    if (NAME.State == ConnectionState.Open)
                                    {
                                        NAME.Close();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Retake Scheduled date has to be between Start Date and End Date. Please double check.");  //warning message if dates are not in order
                                }
                            }
                            else if (dateTimePickerSched.Visible == false && cboSchedTime.Visible == false)  //making sure to leave Retake Scheduled Date/Time not visible (null) if record has to be updated on the faculty request, but still hasn't been scheduled by a student.
                            {

                                //query to update record in the database based on all parameters: simillar as previous one, with the exception of Retake Scheduled Date/Time, which are omitted in this case. Only Retake Start/End date need to be altered.
                                string updateQuery = "UPDATE dbo.retake SET Retake_StartDate = '" + dateTimePickerStart.Value.Date.ToString("yyyy-MM-dd") + "', Retake_EndDate = '" + dateTimePickerEnd.Value.Date.ToString("yyyy-MM-dd") + "', Student_Scheduled_Date = NULL, Student_Scheduled_Time = NULL, Retake_Status = @RetakeStatus WHERE Retake_ID = @RetakeID";

                                SqlCommand command = new SqlCommand(updateQuery, NAME);
                                command.Parameters.AddWithValue("@RetakeStatus", cboRetStatus.Text);
                                command.Parameters.AddWithValue("@RetakeID", txtRetID.Text);

                                if (NAME.State == ConnectionState.Closed)
                                {
                                    NAME.Open();
                                }

                                try
                                {
                                    if (command.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Record has been updated successfully");



                                        //log activity block here //////////////////////////////////////////////////////////////////////////////

                                        string hostName = Dns.GetHostName();
                                        string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                                        string userName = Environment.UserName;



                                        string logActivityQuery2 = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@Username, @UserLogged, 'Retake Updated', @HostName, GETDATE(), @IPAddress)";

                                        SqlCommand cmdAvtivityLog2 = new SqlCommand(logActivityQuery2, NAME);
                                        cmdAvtivityLog2.Parameters.AddWithValue("@Username", lblAdminIDNumbers.Text);
                                        cmdAvtivityLog2.Parameters.AddWithValue("@UserLogged", userName.ToString());
                                        cmdAvtivityLog2.Parameters.AddWithValue("@HostName", hostName.ToString());
                                        cmdAvtivityLog2.Parameters.AddWithValue("@IPAddress", myIP.ToString());

                                        try
                                        {
                                            if (cmdAvtivityLog2.ExecuteNonQuery() == 1)
                                            {

                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }


                                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////



                                    }
                                    else
                                    {
                                        MessageBox.Show("Something is wrong. Please doublecheck the data.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                if (NAME.State == ConnectionState.Open)
                                {
                                    NAME.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong. Please make sure you follow the instructions and complete all the necessary information.");
                            }
                        }
                    }                                                         
                }             
            }
        }

        private void txtRetID_KeyPress(object sender, KeyPressEventArgs e)    //void to make sure that textbox for Retake ID only accepts numbers
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)      //only numbers accepted ... textbox also has limited length (set to maxLength = 4 in properties)
            {
                e.Handled = true;
            }
        }

        private void btnSetSchedDateVisible_Click(object sender, EventArgs e)
        {
            dateTimePickerSched.Visible = true;
            btnSetSchedDateVisible.Visible = false;
            btnHideSchedDate.Visible = true;

        }

        private void btnSetSchedTimeVisible_Click(object sender, EventArgs e)
        {
            cboSchedTime.Visible = true;
            btnSetSchedTimeVisible.Visible = false;
            btnHideSchedTime.Visible = true;

        }

        private void btnHideSchedDate_Click(object sender, EventArgs e)
        {
            dateTimePickerSched.Visible = false;
            btnSetSchedDateVisible.Visible = true;
            btnHideSchedDate.Visible = false;
        }

        private void btnHideSchedTime_Click(object sender, EventArgs e)
        {
            cboSchedTime.Visible = false;
            btnSetSchedTimeVisible.Visible = true;
            btnHideSchedTime.Visible = false;
        }




        //ASSIGN ROLES FORM FROM HERE DOWN    *******************************************************************************************************************************


      

        private void btnAssignRoles_Click(object sender, EventArgs e)
        {
            this.pnlRolesAdmin.Visible = true;
            this.panelSrchClassIDAdmin.Visible = false;
            this.paneSrchStuFacAdmin.Visible = false;
            this.panelSrchDateAdmin.Visible = false;
            this.dataGridViewAdminVR.Visible = false;
            this.lblOr1.Visible = false;
            this.lblOr2.Visible = false;
            this.pnlMngRetAdmin.Visible = false;

            
        }

        private void btnAssignRole_Click(object sender, EventArgs e)
        {
            
            if (txtRolUserID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid Username.");
            }
            else
            {
                if (txtRolUserID.Text.Length < 5)
                {
                    MessageBox.Show("Too short. User ID must be a number between 10000 and 99999");
                }
                else
                {

                    string findUserID = "SELECT UserT_ID FROM dbo.userTable WHERE UserT_ID = @UserID";

                    SqlCommand cmdFindUserID = new SqlCommand(findUserID, NAME);
                    cmdFindUserID.Parameters.AddWithValue("@UserID", txtRolUserID.Text);

                    SqlDataReader dataReadFindUserID;

                    try
                    {
                        if (NAME.State == ConnectionState.Closed)
                        {
                            NAME.Open();
                        }

                        dataReadFindUserID = cmdFindUserID.ExecuteReader();

                        int count = 0;

                        while (dataReadFindUserID.Read())
                        {
                            count += 1;

                        }

                        if (count == 1)
                        {

                            MessageBox.Show("User ID already exists. Choose another one.");

                        }
                        else
                        {
                            string insertQuery = "Insert into dbo.userTable (UserT_ID, UserT_Name, UserT_Role, UserT_Email, UserT_Password) Values (@UserID, @UserName, @UserRoleSelected, @UserEmail, @UserPassword)";

                            SqlCommand command = new SqlCommand(insertQuery, NAME);
                            command.Parameters.AddWithValue("@UserID", txtRolUserID.Text);
                            command.Parameters.AddWithValue("@UserName", txtRolUsername.Text);
                            command.Parameters.AddWithValue("@UserRoleSelected", cboRoles.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@UserEmail", txtRolUserEmail.Text);
                            command.Parameters.AddWithValue("@UserPassword", txtRolPassword.Text);



                            try
                            {
                                if (command.ExecuteNonQuery() == 1)
                                {

                                    MessageBox.Show("User Role successfully created!");


                                    //////////Email Block Here //////////////////////////////

                                    try
                                    {                                    
                                            MailMessage msg = new MailMessage(<EMAIL>, "" + txtRolUserEmail.Text + "", "IMPORTANT: Learning Center - New Role Assigned", "Administrator: Rhonda Ryther assigned you a new role: " + cboRoles.SelectedItem.ToString() + ". Your User ID for this role is: " + txtRolUserID.Text + ", and your CURRENT password is: " + txtRolPassword.Text + ". You are required to change your password at next login for security purposes. (password change portal is located on the home page of Exam - Retake Scheduler. Thank you!");
                                            SmtpClient mail = new SmtpClient();
                                            mail.Host = <PROTOCOL>;
                                            mail.Port = 587;
                                            mail.Credentials = new NetworkCredential(<EMAIL>, <PASSWORD>);
                                            mail.EnableSsl = true;
                                            mail.Send(msg);
                                                                              
                                    }
                                    catch (Exception exp)
                                    {

                                        MessageBox.Show(exp.Message);
                                    }


                                    txtRolUserID.Clear();
                                    txtRolUsername.Clear();
                                    txtRolPassword.Clear();
                                    txtRolUserEmail.Clear();


                                    /////////////////////////////////////////////////////////


                                    //log activity block here //////////////////////////////////////////////////////////////////////////////

                                    string hostName = Dns.GetHostName();
                                    string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                                    string userName = Environment.UserName;



                                    string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@Username, @UserLogged, 'New User Role Created', @HostName, GETDATE(), @IPAddress)";

                                    SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                                    cmdAvtivityLog.Parameters.AddWithValue("@Username", lblAdminIDNumbers.Text);
                                    cmdAvtivityLog.Parameters.AddWithValue("@UserLogged", userName.ToString());
                                    cmdAvtivityLog.Parameters.AddWithValue("@HostName", hostName.ToString());
                                    cmdAvtivityLog.Parameters.AddWithValue("@IPAddress", myIP.ToString());


                                    try
                                    {
                                        if (cmdAvtivityLog.ExecuteNonQuery() == 1)
                                        {

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }


                                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    if (NAME.State == ConnectionState.Open)
                    {
                        NAME.Close();
                    }
                }
            }
        }

        private void lblViewAdmins_Click(object sender, EventArgs e)
        {
            string Query = @"SELECT UserT_ID, UserT_Name AS ""Username"", UserT_Role AS ""Role"", UserT_Email AS ""User Email"" FROM dbo.userTable WHERE UserT_Role = 'Admin'";
            SqlCommand Command = new SqlCommand(Query, NAME);

            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                SqlDataAdapter dataAdapt = new SqlDataAdapter();
                dataAdapt.SelectCommand = Command;
                DataTable dataSet = new DataTable();
                dataAdapt.Fill(dataSet);
                BindingSource bindSource = new BindingSource();

                bindSource.DataSource = dataSet;
                dataGridViewUsersRoles.DataSource = bindSource;
                dataAdapt.Update(dataSet);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            if (NAME.State == ConnectionState.Open)
            {
                NAME.Close();
            }
        }

        private void btnViewManagement_Click(object sender, EventArgs e)
        {
            string Query = "SELECT UserT_ID, UserT_Name, UserT_Role, UserT_Email FROM dbo.userTable WHERE UserT_Role = 'Management'";
            SqlCommand Command = new SqlCommand(Query, NAME);

            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                SqlDataAdapter dataAdapt = new SqlDataAdapter();
                dataAdapt.SelectCommand = Command;
                DataTable dataSet = new DataTable();
                dataAdapt.Fill(dataSet);
                BindingSource bindSource = new BindingSource();

                bindSource.DataSource = dataSet;
                dataGridViewUsersRoles.DataSource = bindSource;
                dataAdapt.Update(dataSet);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            if (NAME.State == ConnectionState.Open)
            {
                NAME.Close();
            }
        }

        private void btnDelUserRoles_Click(object sender, EventArgs e)
        {
            if (txtDeleteUserID.Text.Trim().Length == 0)   //making sure there's input in the textbox
            {
                MessageBox.Show("Enter User ID to be deleted.");  //warning message if there's no input in the Retake ID textbox
            }
            else
            {
                string msgBX = "You are about to permanently delete user with User ID: " + txtDeleteUserID.Text + "";  //dialogue box, confirm deletion of record

                DialogResult res = MessageBox.Show("'" + msgBX + "'", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {

                    //query to delete specific record from database based on the Retake ID (input from the textbox)
                    string delUserQuery = "DELETE from dbo.userTable WHERE UserT_ID = '" + txtDeleteUserID.Text + "'";

                    SqlCommand cmdDelUser = new SqlCommand(delUserQuery, NAME);

                    if (NAME.State == ConnectionState.Closed)
                    {
                        NAME.Open();
                    }

                    try
                    {
                        if (cmdDelUser.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("User has been deleted successfully");



                            //log activity block here /////////////////////////////////////////////////////////////////////////////////////

                            string hostName = Dns.GetHostName();
                            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                            string userName = Environment.UserName;



                            string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@Username, @UserLogged, 'User Deleted', @HostName, GETDATE(), @IPAddress)";

                            SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                            cmdAvtivityLog.Parameters.AddWithValue("@Username", lblAdminIDNumbers.Text);
                            cmdAvtivityLog.Parameters.AddWithValue("@UserLogged", userName.ToString());
                            cmdAvtivityLog.Parameters.AddWithValue("@HostName", hostName.ToString());
                            cmdAvtivityLog.Parameters.AddWithValue("@IPAddress", myIP.ToString());

                            try
                            {
                                if (cmdAvtivityLog.ExecuteNonQuery() == 1)
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }


                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////


                        }
                        else
                        {
                            MessageBox.Show("Something is wrong. Please doublecheck the data.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (NAME.State == ConnectionState.Open)
                    {
                        NAME.Close();
                    }
                }
            }
        }

        private void viewPassChckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (viewPassChckBox.Checked)
            {
                txtRolPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtRolPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtRolPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void btnCloseHome_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmHome().Show();
        }
    }
}