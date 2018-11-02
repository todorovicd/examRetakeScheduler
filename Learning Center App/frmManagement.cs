using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Learning_Center_App
{
    public partial class frmManagement : Form
    {
   
        SqlConnection NAME = new SqlConnection("Data Source = <SERVER>;Initial Catalog = <DATABASE>; Integrated Security = True; MultipleActiveResultSets=True");


        //call following later in different voids in order to populate datagridview with values from database 
        SqlDataAdapter dataAdapt = new SqlDataAdapter();
        DataTable dataTbl = new DataTable();
        BindingSource bindSource = new BindingSource();


        public static string studentNameRetakeID;
        public static string studentIDRetakeID;
        public static string classIDRetakeID;
        public static string classDescriptionRetakeID;


        public frmManagement()
        {
            InitializeComponent();
        }

        private void frmManagement_Load(object sender, EventArgs e)
        {
            lblManageIDNumbers.Text = frmHome.setValue;
            this.dataGridViewManag.DefaultCellStyle.ForeColor = Color.Black;        

        }

        private void txtStudIDSrch_KeyPress(object sender, KeyPressEventArgs e)   //void to make sure that textbox for student ID only accepts numbers
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)         //only numbers accepted ... textbox also has limited length (set to maxLength = 4 in properties)
            {
                e.Handled = true;
            }
        }

        private void btnSrchDate_Click(object sender, EventArgs e)
        {
            dataTbl.Clear();     //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)


            //query to select all the columns from the retake table based on Retake Start Date (from - to)
            string Query = @"SELECT Retake_ID AS ""Retake ID"", CONCAT(Class_ID, Class_Description) AS ""Class"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS Time, Retake_Status AS ""Retake Status"" FROM retake WHERE Retake_StartDate BETWEEN '" + dateTimePickerFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + dateTimePickerTo.Value.Date.ToString("yyyy-MM-dd") + "'";
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
                dataGridViewManag.DataSource = bindSource;
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

        private void btnSrchStuIDNam_Click(object sender, EventArgs e)
        {

            if (txtStudNamSrch.Text.Trim().Length == 0)   //making sure there's no input in the textbox
            {
                if (txtStudIDSrch.Text.Trim().Length != 0)   //making sure there's input in the textbox
                {

                    dataTbl.Clear();        //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

                    
                    //query to select all the columns from the retake table based on faculty ID and student ID (last few number, or only one - used wildcard)
                    string StudQuery = @"SELECT Retake_ID AS ""Retake ID"", CONCAT(Class_ID, Class_Description) AS ""Class"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Retake_EndDate AS ""Open Till"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS Time, Retake_Status AS ""Retake Status"" FROM retake WHERE Student_ID LIKE @stuID AND Retake_EndDate >= CAST(GETDATE() AS DATE)";
                    SqlCommand Commandddd = new SqlCommand(StudQuery, NAME);
                    Commandddd.Parameters.AddWithValue("@stuID", "%" + txtStudIDSrch.Text);    //assigning parameters to the Student ID (passed text from Textbox with Student ID, along with wildcard)

                    try
                    {
                        if (NAME.State == ConnectionState.Closed)
                        {
                            NAME.Open();
                        }

                        //following few lines are used to populate datagridview with values from the database based on the query 
                        dataAdapt.SelectCommand = Commandddd;
                        dataAdapt.Fill(dataTbl);
                        bindSource.DataSource = dataTbl;
                        dataGridViewManag.DataSource = bindSource;
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
                else if (txtStudIDSrch.Text.Trim().Length == 0)   //if there's no input in the textbox. don't do anything. don't display anything
                {
          
                }
            }
            else if (txtStudNamSrch.Text.Trim().Length != 0)   //making sure there's input in the textbox
            {
                if (txtStudIDSrch.Text.Trim().Length == 0)    //making sure there's no input in the textbox
                {
                    dataTbl.Clear();       //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

                    //query to select all the columns from the retake table based on faculty ID and student name (first few letters, or only one - used wildcard)
                    string Query = @"SELECT Retake_ID AS ""Retake ID"", CONCAT(Class_ID, Class_Description) AS ""Class"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Retake_EndDate AS ""Open Till"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS Time, Retake_Status AS ""Retake Status"" FROM retake WHERE Student_Name LIKE @stuName AND Retake_EndDate >= CAST(GETDATE() AS DATE)";
                    SqlCommand Command = new SqlCommand(Query, NAME);
                    Command.Parameters.AddWithValue("@stuName", txtStudNamSrch.Text + "%");  //assigning parameters to the Student Name (passed text from Textbox with Student Name, along with wildcard)

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
                        dataGridViewManag.DataSource = bindSource;
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

        private void txtRetIDMng_KeyPress(object sender, KeyPressEventArgs e)    //void to make sure that textbox for retake ID only accepts numbers
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)      //only numbers accepted ... textbox also has limited length (set to maxLength = 4 in properties)
            {
                e.Handled = true;
            }
        }


        private void studNamIDclassIDdescript()   //finds student Name/ID and Class ID/Description based on Retake ID entered (change Retake Status) to be used in email back to professor. Void down bellow. 
        {

            string srchStuClassFromRetID = "SELECT Student_Name, Student_ID, Class_ID, Class_Description FROM dbo.retake WHERE Retake_ID =@RetakeIDManagement";
            SqlCommand cmdSrchStuClassRetID = new SqlCommand(srchStuClassFromRetID, NAME);
            cmdSrchStuClassRetID.Parameters.Add(new SqlParameter("@RetakeIDManagement", txtRetIDMng.Text));

            SqlDataReader readStuClassRetID = cmdSrchStuClassRetID.ExecuteReader();

            try
            {
                while (readStuClassRetID.Read())
                {
                    string stuNameFromRetID = readStuClassRetID.GetValue(0).ToString();
                    string stuIDFromRetID = readStuClassRetID.GetValue(1).ToString();
                    string classIDFromRetID = readStuClassRetID.GetValue(2).ToString();
                    string classDescriptFromRetID = readStuClassRetID.GetValue(3).ToString();


                    studentNameRetakeID = stuNameFromRetID.ToString();
                    studentIDRetakeID = stuIDFromRetID.ToString();
                    classIDRetakeID = classIDFromRetID.ToString();
                    classDescriptionRetakeID = classDescriptFromRetID.ToString();

                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
        }


        private void btnUpdtRetStat_Click(object sender, EventArgs e)
        {
            if (txtRetIDMng.Text.Trim().Length == 0)    //making sure there's no input in the textbox
            {
                MessageBox.Show("Please enter a Retake ID. ");    //warning messsage if there's no input in textbox
            }
            else if (txtRetIDMng.Text.Trim().Length != 0)    //making sure there's input in the textbox
            {

                //query to update Retake Status (to completed) based on the Retake ID.
                string updateRetStatQuery = "UPDATE dbo.retake SET Retake_Status = 'Completed' WHERE Retake_ID = @RetakeIDManagement AND Retake_Status = 'Not Completed' AND Student_Scheduled_Date IS NOT NULL AND Student_Scheduled_Time IS NOT NULL";

                SqlCommand command = new SqlCommand(updateRetStatQuery, NAME);
                command.Parameters.Add(new SqlParameter("@RetakeIDManagement", txtRetIDMng.Text));


                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Retake status has been updated successfully");



                        //log activity block here //////////////////////////////////////////////////////////////////////////////

                        string hostName = Dns.GetHostName();
                        string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                        string userName = Environment.UserName;



                        string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES ('Management', @Username, 'Retake Status Updated', @HostName, GETDATE(), @IPAddress)";

                        SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                        cmdAvtivityLog.Parameters.Add(new SqlParameter("@Username", userName.ToString()));
                        cmdAvtivityLog.Parameters.Add(new SqlParameter("@HostName", hostName.ToString()));
                        cmdAvtivityLog.Parameters.Add(new SqlParameter("@IPAddress", myIP.ToString()));


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


                        //////////////////////////////////////////////////////////////////////////////////////////////////////




                        //********** email professor that retake has been taken **************

                        string searchFacEmailAddress = "SELECT UserT_Email FROM dbo.userTable INNER JOIN dbo.retake ON retake.Faculty_ID = userTable.UserT_ID WHERE dbo.retake.Retake_ID =@RetakeIDManagement";
                        SqlCommand cmdSrchFacEmail = new SqlCommand(searchFacEmailAddress, NAME);
                        cmdSrchFacEmail.Parameters.Add(new SqlParameter("@RetakeIDManagement", txtRetIDMng.Text));

                        SqlDataReader readFacEmail = cmdSrchFacEmail.ExecuteReader();

                        try
                        {
                            while (readFacEmail.Read())
                            {
                                string facEmailAddress = readFacEmail.GetValue(0).ToString();


                                studNamIDclassIDdescript();   //calling void to find student Name/ID and Class ID/Description to be used in the email bellow. 


                                MailMessage msg = new MailMessage(<EMAIL>, "" + facEmailAddress.ToString() + "", "Exam Retake", "Following Student: "+ studentNameRetakeID + " "+ studentIDRetakeID + " has completed Exam Retake for Class: "+ classIDRetakeID + " "+ classDescriptionRetakeID + "");
                                SmtpClient mail = new SmtpClient();
                                mail.Host = "smtp.gmail.com";
                                mail.Port = 587;
                                mail.Credentials = new NetworkCredential(<EMAIL>, <PASSWORD>);
                                mail.EnableSsl = true;
                                mail.Send(msg);


                                txtRetIDMng.Text = "";  //clear text box with Retake ID

                            }
                        }
                        catch (Exception exp)
                        {

                            MessageBox.Show(exp.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something is wrong. Double-check the Retake ID. (Make sure the Retake Status is not completed already and that Retake is actually scheduled.)");
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

        private void btnCloseMng_Click(object sender, EventArgs e)
        {

            string msgBX = "Don't forget to change Retake Status IF NECESSARY before closing.";
            DialogResult closingDialog = MessageBox.Show("" + msgBX + "", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (closingDialog == DialogResult.OK)
            {
                new frmHome().Show();
                this.Close();
            }
        }
    }
 }