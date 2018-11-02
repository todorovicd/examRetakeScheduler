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
    public partial class frmStudViewRet : Form
    {
     
        SqlConnection NAME = new SqlConnection("Data Source = <SERVER>;Initial Catalog = <DATABASE>; Integrated Security = True; MultipleActiveResultSets=True");

        public frmStudViewRet()
        {
            InitializeComponent();
        }

        private void frmStudViewRet_Load(object sender, EventArgs e)  //as the form loads it triggers the query to display information in datagrid view.
        {
            this.dataGridViewStudVR.DefaultCellStyle.ForeColor = Color.Black;

            lblStudIDVR.Text = frmStudent.stuIDViewRet;
            lblStuNameVR.Text = frmStudent.stuNameViewRet;

            //query to display info for all retakes for that specific student from retake table 
            string Query = @"SELECT CONCAT(Class_ID, Class_Description) AS ""Class"", Faculty_Name AS ""Faculty Name"", Faculty_ID AS ""Faculty ID"", Student_Scheduled_Date AS ""Scheduled On"", Student_Scheduled_Time AS ""Time"", Retake_Status AS ""Retake Status"" FROM retake WHERE Student_ID = @StudentID";
            SqlCommand Command = new SqlCommand(Query, NAME);
            Command.Parameters.AddWithValue("@StudentID", lblStudIDVR.Text);


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
                dataGridViewStudVR.DataSource = bindSource;
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

        private void btnBackStVR_Click(object sender, EventArgs e)  //back button to Student main Form
        {
            new frmStudent().Show();
            this.Close();
        }
    }
}
