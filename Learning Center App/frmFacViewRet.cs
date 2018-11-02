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

namespace Learning_Center_App
{
    public partial class frmFacViewRet : Form
    {
  
        SqlConnection NAME = new SqlConnection("Data Source = <SERVER>;Initial Catalog = <DATABASE>; Integrated Security = True; MultipleActiveResultSets=True");

        public static string classIDGeneral = "";


        //call following later in different voids in order to populate datagridview with values from database 
        SqlDataAdapter dataAdapt = new SqlDataAdapter();    
        DataTable dataTbl = new DataTable();                
        BindingSource bindSource = new BindingSource();     


        public frmFacViewRet()
        {
            InitializeComponent();

        }

        private void frmFacViewRet_Load(object sender, EventArgs e)
        {
            this.dataGridViewFacVR.DefaultCellStyle.ForeColor = Color.Black;

            lblFacIDVR.Text = frmFaculty.facIDViewRet;        //pass faculty ID from faculty form. (public static string- top of faculty form)
            lblFacNameVR.Text = frmFaculty.facNameViewRet;    //pass faculty Name from faculty form. (public static string- top of faculty form)

            FillCombo();  //inistialize void FillCombo (populate it with classes for this specific faculty member)

        }

        private void btnBackFacVR_Click(object sender, EventArgs e)  //back button (to faculty form)
        {
            new frmFaculty().Show();
            this.Close();
        }


        void FillCombo()  //fills combobox with classes for the specific faculty 
        {
            //query to search for classes (ID and description) in the class table for the specific faculty member based on faculty ID
            string Query = "SELECT Class_ID, Class_Description FROM dbo.class WHERE Faculty_ID =@FacultyID";
            SqlCommand Command = new SqlCommand(Query, NAME);
            Command.Parameters.Add(new SqlParameter("@FacultyID", lblFacIDVR.Text));

            SqlDataReader dataReader;

            try
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();

                    dataReader = Command.ExecuteReader();


                    while (dataReader.Read())
                    {
                        string classID = dataReader.GetValue(0).ToString();          //gets Class ID value from dataReader and converts it into string                   
                        string classDescrip = dataReader.GetValue(1).ToString();     //gets Class Description value from dataReader and converts it into string 

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

        private void btnSrchClass_Click(object sender, EventArgs e)   //search retakes based on selection from combobox
        {
            dataTbl.Clear();  //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)

            //query to select all the columns from the retake table based on faculty ID and selected class
            string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Opened On"", Retake_EndDate AS ""Open Till"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"" FROM dbo.retake WHERE Faculty_ID = @FacultyID AND Class_ID =@ClassID";
            SqlCommand Command = new SqlCommand(Query, NAME);
            Command.Parameters.Add(new SqlParameter("@FacultyID", lblFacIDVR.Text));
            Command.Parameters.Add(new SqlParameter("@ClassID", classIDGeneral.ToString()));

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
                dataGridViewFacVR.DataSource = bindSource;
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

        private void cboClassFacSrchPan_SelectedIndexChanged(object sender, EventArgs e)     //new class selected from the combobox with classes
        {
            string ClassIdentifierString = this.cboClassFacSrchPan.GetItemText(this.cboClassFacSrchPan.SelectedItem);    //converting selected item to the string and getting it ready to be cropped
            string classIDent = ClassIdentifierString.Substring(0, 5);  //cropping class ID from the whole item selected (Class ID and Description) 

            classIDGeneral = classIDent.ToString();  //passing the cropped string (class ID) to the public static string (classIDGeneral) so it can be passed around and called in other voids
        }

        private void btnSrchStuIDNam_Click(object sender, EventArgs e)
        {          
            if (txtStudNamSrch.Text.Trim().Length == 0)   //making sure there's no input in the textbox
            {
                if (txtStuIDSrch.Text.Trim().Length != 0)    //making sure there's input in the textbox
                {
                    dataTbl.Clear();    //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)


                    //query to select all the columns from the retake table based on faculty ID and student ID (last few number, or only one - used wildcard)
                    string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Opened On"", Retake_EndDate AS ""Open Till"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"" FROM dbo.retake WHERE Faculty_ID =@FacultyID AND Student_ID LIKE @stuID";
                    SqlCommand CommanddDd = new SqlCommand(Query, NAME);
                    CommanddDd.Parameters.Add(new SqlParameter("@FacultyID", lblFacIDVR.Text));
                    CommanddDd.Parameters.AddWithValue("@stuID", "%" + txtStuIDSrch.Text);   //assigning parameters to the Student ID (passed text from Textbox with Student ID, along with wildcard)

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
                        dataGridViewFacVR.DataSource = bindSource;
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
                else if (txtStuIDSrch.Text.Trim().Length == 0)  //warning message if there's no input in the textbox
                {
                    MessageBox.Show("Please enter Student Name OR Student ID to search for retakes.");
                }
            }
            else if (txtStudNamSrch.Text.Trim().Length != 0)      //making sure there's input in the textbox
            {
                if (txtStuIDSrch.Text.Trim().Length == 0)   //making sure there's no input in the textbox
                {
                    dataTbl.Clear();    //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)


                    //query to select all the columns from the retake table based on faculty ID and student name (first few letters, or only one - used wildcard)
                    string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Opened On"", Retake_EndDate AS ""Open Till"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"" FROM dbo.retake WHERE Faculty_ID =@FacultyID AND Student_Name LIKE @stuName";
                    SqlCommand CommanDDD = new SqlCommand(Query, NAME);
                    CommanDDD.Parameters.Add(new SqlParameter("@FacultyID", lblFacIDVR.Text));
                    CommanDDD.Parameters.AddWithValue("@stuName", txtStudNamSrch.Text + "%");  //assigning parameters to the Student Name (passed text from Textbox with Student Name, along with wildcard)

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
                        dataGridViewFacVR.DataSource = bindSource;
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

        private void txtStuIDSrch_KeyPress(object sender, KeyPressEventArgs e)   //void to make sure that textbox for student ID only accepts numbers
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)   //only numbers accepted ... textbox also has limited length (set to maxLength = 8 in properties)
            {
                e.Handled = true;
            }
        }

        private void btnSrchDate_Click(object sender, EventArgs e)
        {
            if (dateTimePickerTo.Value < dateTimePickerFrom.Value)   //making sure the dates are in appropriate order ("from" before "to")
            {

                MessageBox.Show("End Date has to be after Start Date.");   //warning message if dates not in order
            }

            else if (dateTimePickerTo.Value >= dateTimePickerFrom.Value)    //making sure the dates are in appropriate order ("from" before "to")
            {
                dataTbl.Clear();    //clears DataTable making sure the datagridView is clear and ready to display new values (so it's not stacking new records on top of old ones)


                //query to select all the columns from the retake table based on faculty ID and Retake Start Date (from - to)
                string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Student_Name AS ""Student Name"", Student_ID AS ""Student ID"", Retake_StartDate AS ""Opened On"", Retake_EndDate AS ""Open Till"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Scheduled Time"", Retake_Status AS ""Retake Status"" FROM dbo.retake WHERE Faculty_ID =@FacultyID AND Retake_StartDate BETWEEN '" + dateTimePickerFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + dateTimePickerTo.Value.Date.ToString("yyyy-MM-dd") + "'";
                SqlCommand Command = new SqlCommand(Query, NAME);
                Command.Parameters.Add(new SqlParameter("@FacultyID", lblFacIDVR.Text));

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
                    dataGridViewFacVR.DataSource = bindSource;
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
    }
}
