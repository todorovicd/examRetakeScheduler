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

namespace Learning_Center_App
{
    public partial class frmStudent : Form
    {
      
        SqlConnection NAME = new SqlConnection("Data Source = <SERVER>;Initial Catalog = <DATABASE>; Integrated Security = True; MultipleActiveResultSets=True");

      

        public static string classIDGeneral_2 = "";  //value passed in here from combobox selected item in the form.
         
        public static string stuIDViewRet = "";     // value passed in here from label with student ID (top of the form)

        public static string stuNameViewRet = "";   //value passed in here from label with student Name (top of the form)


        public frmStudent()
        {
            InitializeComponent();

            FillComboClassStud();
            //datePickerStrtValues();

        }

        private void FrmStudent_Load_1(object sender, EventArgs e)
        {
            lblStudID.Text = frmHome.setValue;  //setValue text passed from Home Form Username textbox.
            StuNameLabel();

            FillComboClassStud();  //initialize void

            stuIDViewRet = lblStudID.Text;  //passes Student ID string to the public static String (stuIDViewRet) to be used in other voids
            stuNameViewRet = lblStudName.Text;  //passes Student Name string to the public static String (stuNameViewRet) to be used in other voids

        }
        private void StuNameLabel()  //searches database for Student Name based on Student ID passed from Home Form (Username)
        {
            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                string insertQuery = "SELECT UserT_Name FROM userTable WHERE UserT_ID = @classID";  //Query to find Student Name based on Student ID 
                using (SqlCommand CommandCheck = new SqlCommand(insertQuery, NAME))
                {
                    CommandCheck.Parameters.AddWithValue("@classID", lblStudID.Text);
                    using (SqlDataReader dataReaderCheck = CommandCheck.ExecuteReader())
                    {
                        while (dataReaderCheck.Read())
                        {
                            string stuNamDisply = dataReaderCheck.GetValue(0).ToString();  
                            lblStudName.Text = stuNamDisply.ToString();

                        }
                        dataReaderCheck.Close();
                    }
                }
                if (NAME.State == ConnectionState.Open)
                {
                    NAME.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void datePickerStrtValues()  //sets dateTimePicker Values based on Faculty Input in the database
        {
            //query to find dates for specific classes in the database (retake table)
            string Query = "SELECT Retake_EndDate FROM retake WHERE Student_ID = @StudentID AND Class_ID = @ClassID AND Retake_StartDate BETWEEN DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) AND DATEADD(DAY, 7, CAST(GETDATE() AS DATE));";
            SqlCommand Command = new SqlCommand(Query, NAME);
            Command.Parameters.Add(new SqlParameter("@StudentID", lblStudID.Text));
            Command.Parameters.Add(new SqlParameter("@ClassID", classIDGeneral_2.ToString()));

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
                    dateTimePickerStartStud.MinDate = DateTime.Now;    //minimum date for DateTImePicker is current date

                    string maxDatePick = dataReader.GetValue(0).ToString();  //same procedure. now looking for Retake End Date in the database
                    DateTime End_Date = Convert.ToDateTime(maxDatePick);

                    //if user decides to schedule retake on the actual RetakeEndDate, exception will occur saying MaxDate has to be greater than or equal to MinDate
                    End_Date = End_Date.AddHours(23);   //for that reason I add 23 hours (less than a day) to the MaxDate, dodging the exception that way.  

                    dateTimePickerStartStud.MaxDate = (End_Date);           //setting second DateTimePicker max date to the appropriate values

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

        private void FillComboClassStud()  //fills ComboBox with Classes from the database for the specific student which have not been scheduled yet. 
        {

            //query to find classes, for specific student, that have not been scheduled yet and End Date of retake has not passed 
            string Query = "SELECT Class_ID, Class_Description FROM retake WHERE Student_ID = @StudentID AND Student_Scheduled_Date IS NULL AND Retake_StartDate BETWEEN DATEADD(DAY, -9, CAST(GETDATE() AS DATE)) AND DATEADD(DAY, 9, CAST(GETDATE() AS DATE)) AND  Retake_EndDate >= CAST(GETDATE() AS DATE);";
            SqlCommand Command = new SqlCommand(Query, NAME);
            Command.Parameters.AddWithValue("@StudentID", lblStudID.Text);

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

                        string classID = dataReader.GetValue(0).ToString();  //gets class ID from retake table
                        string classDescription = dataReader.GetValue(1).ToString();  //gets class Description from retake table

                    cboChooseClassStud.Items.Add(string.Format("{0} {1}", classID, classDescription));  //concatenates Class ID and Description to be displayed in ComboBox 
                                  
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

        private void btnConfirmStud_Click_1(object sender, EventArgs e)  //Confirming Retake Scheduling 
        {
            if (cboChooseClassStud.SelectedItem == null)
            {
                MessageBox.Show("Please select an appropriate Class.");
            }
            else if (cboTimeStudent.SelectedItem == null)
            {
                MessageBox.Show("Please select an appropriate time.");
            }
            else
            {
                string studentTimePicked = cboTimeStudent.SelectedItem.ToString();  //gets selected value from combobox with Times of retake
                string timePicked = studentTimePicked.Substring(0, 8);              //reads everything in the combobox except AM/PM

                string clsPick = cboChooseClassStud.SelectedItem.ToString();    //selected value from combobox with avaliable classes
                string classPickedStud = clsPick.Substring(0, 5);               //selects Class ID from value in combobox with Classes


                //cinfirmation message box listing Class Picked (only ID), Scheduled Date and Scheduled Time. if canceled, data is not saved. IF ok, data saved. 
                string messBox = "You're about to schedule a retake for: " + classPickedStud + ", on: " + dateTimePickerStartStud.Value.Date.ToString("MM-dd-yyyy") + ", at: " + cboTimeStudent.SelectedItem.ToString() + "";

                DialogResult res = MessageBox.Show("'" + messBox + "'", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    //Update query (Scheduled Date, Scheduled Time) based on Student ID, Class ID and where Start Date and End Date is 7 days before and after current date (in that time frame)
                    string insertQueryStudent = "UPDATE dbo.retake SET Student_Scheduled_Date = '" + dateTimePickerStartStud.Value.Date.ToString("yyyy-MM-dd") + "', Student_Scheduled_Time = @TimePicked, Retake_Scheduled = GETDATE() WHERE Student_Id = @StudentID AND Class_ID = @ClassPicked AND Retake_StartDate BETWEEN DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) AND DATEADD(DAY, 7, CAST(GETDATE() AS DATE));";

                    SqlCommand command = new SqlCommand(insertQueryStudent, NAME);
                    command.Parameters.AddWithValue("@TimePicked", timePicked);
                    command.Parameters.AddWithValue("@StudentID", lblStudID.Text);
                    command.Parameters.AddWithValue("@ClassPicked", classPickedStud);


                    if (NAME.State == ConnectionState.Closed)
                    {
                        NAME.Open();
                    }

                    try
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Class scheduled successfully. Good luck!");



                            //log activity block here //////////////////////////////////////////////////////////////////////////////

                            string hostName = Dns.GetHostName();
                            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                            string userName = Environment.UserName;



                            string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@StudentID, @Username, 'Student Scheduled Retake', @HostName, GETDATE(), @IPAddress)";

                            SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                            cmdAvtivityLog.Parameters.AddWithValue("@StudentID", lblStudID.Text);
                            cmdAvtivityLog.Parameters.AddWithValue("@Username", userName.ToString());
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
                            MessageBox.Show("Error!!");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }

            if (NAME.State == ConnectionState.Open)
            {
                NAME.Close();
            }
        }

        private void cboChooseClassStud_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ClassIdentifierString = this.cboChooseClassStud.GetItemText(this.cboChooseClassStud.SelectedItem);  //value of the selected item
            string classIDent = ClassIdentifierString.Substring(0, 5);  //crops first five characters (only Class ID from everything in combobox)

            classIDGeneral_2 = classIDent.ToString();  //passes Class ID from the selected value in combobox (cropped) to the public static string (classIDGeneral_2) to be used in other voids.

            datePickerStrtValues();  //triggers dateTimePicker values after selecting specific class. 

        }

        private void btnRetakes_Click(object sender, EventArgs e)  //opens new form displaying all the retakes in the database for that specific student
        {
            new frmStudViewRet().Show();
            this.Close();
        }

        //BELLOW - Times list based on the day selected. Do this at the beggining of every semester if we know scheduling retakes won't be available on specific days at specific times. (bellow is just an example)

        private void dateTimePickerStartStud_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStartStud.Value.DayOfWeek == DayOfWeek.Monday || dateTimePickerStartStud.Value.DayOfWeek == DayOfWeek.Wednesday)
            {
                this.cboTimeStudent.Items.Clear();

                cboTimeStudent.Items.Add("08:00:00 AM");
                cboTimeStudent.Items.Add("10:00:00 AM");
                cboTimeStudent.Items.Add("11:00:00 AM");
                cboTimeStudent.Items.Add("12:00:00 PM");
                cboTimeStudent.Items.Add("01:00:00 PM");
                cboTimeStudent.Items.Add("02:00:00 PM");
                cboTimeStudent.Items.Add("03:00:00 PM");
            }
            else if (dateTimePickerStartStud.Value.DayOfWeek == DayOfWeek.Friday)
            {
                this.cboTimeStudent.Items.Clear();

                cboTimeStudent.Items.Add("08:00:00 AM");
                cboTimeStudent.Items.Add("09:00:00 AM");
                cboTimeStudent.Items.Add("10:00:00 AM");
                cboTimeStudent.Items.Add("11:00:00 AM");
                cboTimeStudent.Items.Add("12:00:00 PM");
                cboTimeStudent.Items.Add("01:00:00 PM");
                cboTimeStudent.Items.Add("02:00:00 PM");
            }
            else if (dateTimePickerStartStud.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePickerStartStud.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                this.cboTimeStudent.Items.Clear();

                MessageBox.Show("Can't schedule a retake on a weekend!");
            }
            else
            {
                this.cboTimeStudent.Items.Clear();

                cboTimeStudent.Items.Add("08:00:00 AM");
                cboTimeStudent.Items.Add("09:00:00 AM");
                cboTimeStudent.Items.Add("10:00:00 AM");
                cboTimeStudent.Items.Add("11:00:00 AM");
                cboTimeStudent.Items.Add("12:00:00 PM");
                cboTimeStudent.Items.Add("01:00:00 PM");
                cboTimeStudent.Items.Add("02:00:00 PM");
                cboTimeStudent.Items.Add("03:00:00 PM");
            }
        }

        private void btnCloseStud_Click(object sender, EventArgs e)
        {
            //message box informing students that changes won't be possible afer exiting form. student can make as many changes to the retake as they want as long as they don't exit the form. 
            DialogResult res = MessageBox.Show("You are about to Exit the Student Form. You won't be able to make any changes to the classes already scheduled. Please double check.", "Exiting Form?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                new frmHome().Show();
                this.Close();
            }
        }
    }
}
