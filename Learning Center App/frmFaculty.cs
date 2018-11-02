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
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace Learning_Center_App
{
    public partial class frmFaculty : Form
    {
        
        SqlConnection NAME = new SqlConnection("Data Source = <SERVER>;Initial Catalog = <DATABASE>; Integrated Security = True; MultipleActiveResultSets=True");


        public static string classIDGeneral = "";   //value passed in here from combobox selected item in the form.

        public static string facIDViewRet = "";     //value passed in here from label with Faculty ID

        public static string facNameViewRet = "";   //value passed in here from label with Faculty Name


        DataSet ds = new DataSet();


        public frmFaculty()
        {
            InitializeComponent();

        }


        private void frmFaculty_Load_1(object sender, EventArgs e)
        {

            lblFacID.Text = frmHome.setValue;  //value passed in here from home form (user Name) 

            FacNameLabel();  //triggers FacNameLabel void

            FillCombo();  //triggers FillCombo void

            dateTimePickerStart.MinDate = DateTime.Now;               //sets minimum date for the first DateTimePicker value to the current date 
            dateTimePickerStart.MaxDate = DateTime.Now.AddDays(18);   //sets maximum date for the second DateTimePicker value to the current date plus 18 days 

            dateTimePickerEnd.MinDate = DateTime.Now;                 //sets minimum date for the second DateTimePicker value to the current date 
            dateTimePickerEnd.MaxDate = DateTime.Now.AddDays(18);     //sets maximum date for the second DateTimePicker value to the current date plus 18 days 


            facIDViewRet = lblFacID.Text;       //passes value from label with faculty ID (top of the page) to the public static string to be used in other voids
            facNameViewRet = lblFacName.Text;   //passes value from label with faculty Name (top of the page) to the public static string to be used in other voids

        }


        private void FacNameLabel()  //void to find Faculty name in the database base don the Faculty Id (passed from home form - Username)
        {
            //query to select fac Name based on fac ID
            string selFacNameQuery = "SELECT UserT_Name FROM userTable WHERE UserT_ID =@FacultyID";  
            SqlCommand Command = new SqlCommand(selFacNameQuery, NAME);
            Command.Parameters.Add(new SqlParameter("@FacultyID", lblFacID.Text));

            SqlDataReader dataReader;

            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    string facNamDisply = dataReader.GetValue(0).ToString();  //converts dataReader value (faculty name) to a string to be passed to a label

                    lblFacName.Text = facNamDisply.ToString();    //passes previous string to the faculty Name label to be displayed on tope of the page
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

        private void FillCombo()  //fills combobox with classes from database (specific classes taught by that specific faculty)
        {
            //query to find classes in the database from table CLASS based on Faculty ID 
            string Query = "SELECT Class_ID, Class_Description FROM class WHERE Faculty_ID =@FacultyID";
            SqlCommand Command = new SqlCommand(Query, NAME);
            Command.Parameters.Add(new SqlParameter("@FacultyID", lblFacID.Text));

            SqlDataReader dataReader;

            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    string classID = dataReader.GetValue(0).ToString();  //gets Class ID string from dataReader

                    string classDescrip = dataReader.GetValue(1).ToString();  //gets Class Description string from dataReader

                    cboChooseClass.Items.Add(string.Format("{0}  {1}", classID, classDescrip));  //concatenates Class ID and Description to be displayed in combobox

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

        private void FillCheckList()  //populates check list with student names based on selection in the combobox 
        {
            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                //query to find students in the retake table based on the class ID for that specific Faculty (Faculty ID)
                string insertQuery = "SELECT Student_Name, Student_ID FROM roster WHERE Class_ID=@classID AND Faculty_ID=@facID";
                using (SqlCommand CommandCheck = new SqlCommand(insertQuery, NAME))
                {
                    CommandCheck.Parameters.AddWithValue("@classID", classIDGeneral.ToString());  //sets parameter values for ClassID (gets value from public string (classIDGeneral)
                    CommandCheck.Parameters.AddWithValue("@facID", lblFacID.Text);                //sets parameter values for Faculty ID (gets value from label with faculty ID (top of page)
                    using (SqlDataReader dataReaderCheck = CommandCheck.ExecuteReader())          
                    {
                        while (dataReaderCheck.Read())
                        {
                            string Student_Name = dataReaderCheck.GetValue(0).ToString().Trim();            //gets Student Name from dataReader (trims excell white space). Converts to string
                            string Stud_ID = dataReaderCheck.GetValue(1).ToString();                        //gets Student ID from dataReader. Converts to string 
                            chckLstBox.Items.Add(string.Format("{0}  -  {1}", Student_Name, Stud_ID));      // concatenates Student Name and Student ID to be displayed in the check list
                        }
                        dataReaderCheck.Close();
                    }
                }

                if (NAME.State == ConnectionState.Open)
                {
                    NAME.Close();
                }            
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
                this.Close();
            }
            catch (Exception cx)
            {
                MessageBox.Show(cx.Message);
            }
        }


        private void btnConfirm_Click_1(object sender, EventArgs e)  //confirm retakes button
        {

            if (cboChooseClass.SelectedItem == null)  
            {
                MessageBox.Show("Please select an appropriate Class and Students for Retake.");
            }
            else if (chckLstBox.SelectedItem == null)
            {
                MessageBox.Show("Please select Students for Retake.");
            }
            else
            {
                if (dateTimePickerEnd.Value < dateTimePickerStart.Value)
                {

                    MessageBox.Show("End Date has to be after Start Date.");
                }

                else if (dateTimePickerEnd.Value >= dateTimePickerStart.Value)
                {

                    if (cboReasonRetake.SelectedItem == null)
                    {
                        MessageBox.Show("Please select a valid reason for the retake. If other, please specify briefly!");
                    }
                    else if (cboReasonRetake.SelectedItem.ToString() == "Other" && txtReasonRet.TextLength == 0)
                    {
                        MessageBox.Show("If you selected OTHER as Retake Reason. Make sure to specify the reason!");
                    }

                    else if (cboReasonRetake.SelectedItem != null && cboReasonRetake.SelectedItem.ToString() == "Other" && txtReasonRet.TextLength > 0)
                    {
                       
                        if (NAME.State == ConnectionState.Closed)
                        {
                            NAME.Open();
                        }

                        foreach (var item in chckLstBox.CheckedItems)
                        {

                            string studentChecked = item.ToString();

                            string stuIDChecked = studentChecked.Substring(studentChecked.Length - 9);  //gets student ID from the selected items in the check list (crops ID from ID and name)

                            string studentNameChecked = studentChecked.Substring(0, studentChecked.Length - 9);  //gets student Name from the selected items in the check list (crops Name from ID and name)


     
                            //query to search for existing records with same data in the retake table (same Faculty ID, Class ID, Student ID, and Retake start date in the past 7 days (from current date)) if the record exist, message displayed (can't schedule that often)
                            string searchExistingRecords = "SELECT * FROM dbo.retake WHERE Faculty_ID =@FacultyID  AND Class_ID =@ClassID AND Student_ID =@StudentID AND Retake_StartDate BETWEEN DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) AND CAST(GETDATE() AS DATE)";

                            SqlCommand cmdSrch = new SqlCommand(searchExistingRecords, NAME);
                            cmdSrch.Parameters.Add(new SqlParameter("@FacultyID", facIDViewRet.ToString()));
                            cmdSrch.Parameters.Add(new SqlParameter("@ClassID", classIDGeneral.ToString()));
                            cmdSrch.Parameters.Add(new SqlParameter("@StudentID", stuIDChecked.ToString()));


                            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmdSrch);

                            dataAdapt.Fill(ds);

                            int i = ds.Tables[0].Rows.Count;

                            if (i > 0)
                            {
                                MessageBox.Show("Looks like you already scheduled a retake for Student with ID:" + stuIDChecked.ToString() + ", for Class:" + classIDGeneral.ToString() + ", in the past 7 days. Contact Rhonda Ryther with any questions.");
                                ds.Clear();
                            }
                            else
                            {
                                //message box indicating all the criteria has been satisfied and faculty can proceed with scheduling retakes. (it will pop-up for each selected student) if cancelled, data won't be saved. 
                                string msgBX = "Following student will be granted retake permission: " + item.ToString() + "";

                                DialogResult res = MessageBox.Show("'" + msgBX + "'", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (res == DialogResult.OK)
                                {

                                    //separating class description from (class ID and description) in the combobox. To be saved in the database (look query below)
                                    string chosClass = cboChooseClass.SelectedItem.ToString();
                                    string classDescripChosen = chosClass.ToString();
                                    string classDescriptionFac = classDescripChosen.Remove(0, 5);  //separation occurs here. (extracting description from the whole thing) 


                                    //query to insert data (create new record in the retake table) with all the necessary attributes 
                                    string insertQuery = "INSERT INTO dbo.retake(Class_ID, Class_Description, Student_Name, Student_ID, Faculty_Name, Faculty_ID,Retake_StartDate, Retake_EndDate, Retake_Reason, Retake_Created) VALUES(@ClassID, @ClassDescription, @StudentNameChecked, @StudentIDChecked, @FacultyName, @FacultyID,'" + dateTimePickerStart.Value.Date.ToString("yyyy-MM-dd") + "','" + dateTimePickerEnd.Value.Date.ToString("yyyy-MM-dd") + "', @RetakeReason, GETDATE())";

                                    SqlCommand command = new SqlCommand(insertQuery, NAME);
                                    command.Parameters.Add(new SqlParameter("@ClassID", classIDGeneral.ToString()));
                                    command.Parameters.Add(new SqlParameter("@ClassDescription", classDescriptionFac.ToString()));
                                    command.Parameters.Add(new SqlParameter("@StudentNameChecked", studentNameChecked.ToString()));
                                    command.Parameters.Add(new SqlParameter("@StudentIDChecked", stuIDChecked.ToString()));
                                    command.Parameters.Add(new SqlParameter("@FacultyName", lblFacName.Text));
                                    command.Parameters.Add(new SqlParameter("@FacultyID", lblFacID.Text));
                                    command.Parameters.Add(new SqlParameter("@RetakeReason", txtReasonRet.Text));
                                    

                                    try
                                    {
                                        if (command.ExecuteNonQuery() == 1)
                                        {

                                            MessageBox.Show("Retake successfully scheduled!");


                                            //check for student emails block of code ************************************************************************** 

                                            string searchEmailAddress = "SELECT UserT_Email FROM dbo.userTable WHERE UserT_ID =@StudentID";
                                            SqlCommand cmdEmail = new SqlCommand(searchEmailAddress, NAME);
                                            cmdEmail.Parameters.Add(new SqlParameter("@StudentID", stuIDChecked.ToString()));

                                            SqlDataReader readEmail = cmdEmail.ExecuteReader();                                     

                                            try
                                            {
                                                while (readEmail.Read())
                                                {
                                                    string userEmail = readEmail.GetValue(0).ToString();


                                                    MailMessage msg = new MailMessage(<EMAIL>, "" + userEmail.ToString() + "", "Exam Retake", "Faculty:  " + lblFacName.Text + " has opened exam retake for you, for class: " + cboChooseClass.Text + " starting on: " + dateTimePickerStart.Value.Date.ToString() + ", and ending on " + dateTimePickerEnd.Value.Date.ToString() + ". Please use Exam-Retake Scheduler (available on our campus computers) to Schedule a retake before your permission expires. Thank you!");
                                                    SmtpClient mail = new SmtpClient();
                                                    mail.Host = "smtp.gmail.com";
                                                    mail.Port = 587;
                                                    mail.Credentials = new NetworkCredential(<EMAIL>, <PASSWORD>);
                                                    mail.EnableSsl = true;
                                                    mail.Send(msg);

                                                }
                                            }
                                            catch (Exception exp)
                                            {

                                                MessageBox.Show(exp.Message);
                                            }

                                            //***************************************************************************************************************



                                            //log activity block here //////////////////////////////////////////////////////////////////////////////

                                            string hostName = Dns.GetHostName();
                                            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                                            string userName = Environment.UserName;



                                            string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@FacultyID, @Username, 'Faculty Opened Retake', @HostName, GETDATE(), @IPAddress)";

                                            SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                                            cmdAvtivityLog.Parameters.Add(new SqlParameter("@FacultyID", lblFacID.Text));
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


                                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                                        }
                                        else
                                        {
                                            MessageBox.Show("Error!!");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }

                                ds.Clear();
                            }
                        }
                        if (NAME.State == ConnectionState.Open)
                        {
                            NAME.Close();
                        }
                    }
                                     
                    else if (cboReasonRetake.SelectedItem != null && cboReasonRetake.SelectedItem.ToString() != "Other" && txtReasonRet.TextLength == 0)
                    {
                        if (NAME.State == ConnectionState.Closed)
                        {
                            NAME.Open();
                        }

                        foreach (var item in chckLstBox.CheckedItems)
                        {

                            string studentChecked = item.ToString();

                            string stuIDChecked = studentChecked.Substring(studentChecked.Length - 9);  //gets student ID from the selected items in the check list (crops ID from ID and name)

                            string studentNameChecked = studentChecked.Substring(0, studentChecked.Length - 9);  //gets student Name from the selected items in the check list (crops Name from ID and name)


                            //query to search for existing records with same data in the retake table (same Faculty ID, Class ID, Student ID, and Retake start date in the past 7 days (from current date)) if the record exist, message displayed (can't schedule that often)
                            string searchExistingRecords = "SELECT * FROM dbo.retake WHERE Faculty_ID =@FacultyID  AND Class_ID =@ClassID AND Student_ID =@StudentIDChecked AND Retake_StartDate BETWEEN DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) AND CAST(GETDATE() AS DATE)";

                            SqlCommand cmdSrch = new SqlCommand(searchExistingRecords, NAME);
                            cmdSrch.Parameters.Add(new SqlParameter("@FacultyID", facIDViewRet.ToString()));
                            cmdSrch.Parameters.Add(new SqlParameter("@ClassID", classIDGeneral.ToString()));
                            cmdSrch.Parameters.Add(new SqlParameter("@StudentIDChecked", stuIDChecked.ToString()));

                            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmdSrch);

                            dataAdapt.Fill(ds);

                            int i = ds.Tables[0].Rows.Count;

                            if (i > 0)
                            {
                                MessageBox.Show("Looks like you already scheduled a retake for Student with ID:" + stuIDChecked.ToString() + ", for Class:" + classIDGeneral.ToString() + ", in the past 7 days. Contact Rhonda Ryther with any questions.");
                                ds.Clear();
                            }
                            else
                            {
                                //message box indicating all the criteria has been satisfied and faculty can proceed with scheduling retakes. (it will pop-up for each selected student) if cancelled, data won't be saved. 
                                string msgBX = "Following student will be granted retake permission: " + item.ToString() + "";

                                DialogResult res = MessageBox.Show("'" + msgBX + "'", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (res == DialogResult.OK)
                                {

                                    //separating class description from (class ID and description) in the combobox. To be saved in the database (look query below)
                                    string chosClass = cboChooseClass.SelectedItem.ToString();
                                    string classDescripChosen = chosClass.ToString();
                                    string classDescriptionFac = classDescripChosen.Remove(0, 5);  //separation occurs here. (extracting description from the whole thing) 


                                    //query to insert data (create new record in the retake table) with all the necessary attributes 
                                    string insertQuery = "INSERT INTO dbo.retake(Class_ID, Class_Description, Student_Name, Student_ID, Faculty_Name, Faculty_ID,Retake_StartDate, Retake_EndDate, Retake_Reason, Retake_Created) VALUES(@ClassID, @ClassDescription, @StudentNameChecked, @StudentIDChecked, @FacultyName, @FacultyID,'" + dateTimePickerStart.Value.Date.ToString("yyyy-MM-dd") + "','" + dateTimePickerEnd.Value.Date.ToString("yyyy-MM-dd") + "', @RetakeReason, GETDATE())";

                                    SqlCommand command = new SqlCommand(insertQuery, NAME);
                                    command.Parameters.Add(new SqlParameter("@ClassID", classIDGeneral.ToString()));
                                    command.Parameters.Add(new SqlParameter("@ClassDescription", classDescriptionFac.ToString()));
                                    command.Parameters.Add(new SqlParameter("@StudentNameChecked", studentNameChecked.ToString()));
                                    command.Parameters.Add(new SqlParameter("@StudentIDChecked", stuIDChecked.ToString()));
                                    command.Parameters.Add(new SqlParameter("@FacultyName", lblFacName.Text));
                                    command.Parameters.Add(new SqlParameter("@FacultyID", lblFacID.Text));
                                    command.Parameters.Add(new SqlParameter("@RetakeReason", cboReasonRetake.Text));

                                    try
                                    {
                                        if (command.ExecuteNonQuery() == 1)
                                        {

                                            MessageBox.Show("Retake successfully scheduled!");


                                            //check for student emails block of code ************************************************************************** 

                                            string searchEmailAddress = "SELECT UserT_Email FROM dbo.userTable WHERE UserT_ID =@StudentIDChecked";
                                            SqlCommand cmdEmail = new SqlCommand(searchEmailAddress, NAME);
                                            cmdEmail.Parameters.Add(new SqlParameter("@StudentIDChecked", stuIDChecked.ToString()));

                                            SqlDataReader readEmail = cmdEmail.ExecuteReader();



                                            //log activity block here //////////////////////////////////////////////////////////////////////////////


                                            string hostName = Dns.GetHostName();
                                            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                                            string userName = Environment.UserName;



                                            string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@FacultyID, @Username, 'Faculty Opened Retake', @HostName, GETDATE(), @IPAddress)";

                                            SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                                            cmdAvtivityLog.Parameters.Add(new SqlParameter("@FacultyID", lblFacID.Text));
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

                                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////


                                            try
                                            {
                                                while (readEmail.Read())
                                                {
                                                    string userEmail = readEmail.GetValue(0).ToString();

                                                    MailMessage msg = new MailMessage(<EMAIL>, "" + userEmail.ToString() + "", "Exam Retake", "Faculty:  " + lblFacName.Text + " has opened exam retake for you, for class: " + cboChooseClass.Text + " starting on: " + dateTimePickerStart.Value.Date.ToString() + ", and ending on " + dateTimePickerEnd.Value.Date.ToString() + ". Please use Exam-Retake Scheduler (available on our campus computers) to Schedule a retake before your permission expires. Thank you!");
                                                    SmtpClient mail = new SmtpClient();
                                                    mail.Host = "smtp.gmail.com";
                                                    mail.Port = 587;
                                                    mail.Credentials = new NetworkCredential(<EMAIL>, <PASSWORD>);
                                                    mail.EnableSsl = true;
                                                    mail.Send(msg);

                                                }
                                            }
                                            catch (Exception exp)
                                            {

                                                MessageBox.Show(exp.Message);
                                            }

                                            //check for student emails block of code ************************************************************************** 
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error!!");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }

                                ds.Clear();
                            }
                        }
                    }
                    else if (cboReasonRetake.SelectedItem != null && cboReasonRetake.SelectedItem.ToString() != "Other" && txtReasonRet.TextLength > 0)
                    {
                        MessageBox.Show("Make sure to leave the textbox for Retake Reason blank if the reason is not OTHER.");
                    }

                    if (NAME.State == ConnectionState.Open)
                    {
                        NAME.Close();
                    }
                }              
            }
        }

        private void cboChooseClass_SelectedIndexChanged_1(object sender, EventArgs e)  //selecting different classes in the co
        {
            if (cboChooseClass.SelectedItem != null)
            {              
                string ClassIdentifierString = this.cboChooseClass.GetItemText(this.cboChooseClass.SelectedItem);  //gets selected value from combobox 
                string classIDent = ClassIdentifierString.Substring(0, 5);  //crops Class ID from the selected item in cboBox (class ID and Description)

                classIDGeneral = classIDent.ToString();  //passes previously cropped string to the public static string classIDGeneral to be used in other voids

                chckLstBox.Items.Clear();  //clears check list after each new selection in combobox
                FillCheckList();  //triggers FillCheckList void to populate check list with stdent names
            }
        }

        private void btnRetakesFac_Click(object sender, EventArgs e)  //opens new form with Faculty retakes 
        {
            new frmFacViewRet().Show();
            this.Close();       
        }

        private void btnCloseFac_Click(object sender, EventArgs e)
        {
            new frmHome().Show();
            this.Close();
        }
    }
}
