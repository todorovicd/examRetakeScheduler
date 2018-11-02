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
using System.Data.Sql;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Learning_Center_App
{
    public partial class frmHome : Form
    {
    
        SqlConnection NAME = new SqlConnection("Data Source = <SERVER>;Initial Catalog = <DATABASE>; Integrated Security = True; MultipleActiveResultSets=True");


        DataSet dsPassExist = new DataSet();


        public static string setValue = "";

        private static string savedHashDB;
        private static string savedSaltDB;


        public frmHome()
        {
            InitializeComponent();

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
            linklblPassReset.Visible = false;
        }


        private void CheckPasswordDefaultDOB()  //checks if password entered is default or changed. If not changed (message Box saying you should change it soon...)
        {

            if (NAME.State == ConnectionState.Closed)
            {
                NAME.Open();
            }


            string srchUsernamePassExists = "SELECT UserT_Password FROM dbo.userTable WHERE UserT_ID =@Username AND UserT_Password =@UserPassword";

            SqlCommand cmdSrchPassExist = new SqlCommand(srchUsernamePassExists, NAME);
            cmdSrchPassExist.Parameters.Add(new SqlParameter("@Username", txtUserName.Text));
            cmdSrchPassExist.Parameters.Add(new SqlParameter("@UserPassword", txtPass.Text));
            SqlDataAdapter dataAdaptPassExists = new SqlDataAdapter(cmdSrchPassExist);

            dataAdaptPassExists.Fill(dsPassExist);
            int i = dsPassExist.Tables[0].Rows.Count;

            try
            {          
                if (i > 0)
                {
                    dsPassExist.Clear();


                    //query to check if password for specific user is in date format (default password DOB) 
                    string checkPassDefault = "SELECT ISDATE (UserT_Password) FROM dbo.userTable WHERE UserT_ID =@Username AND UserT_Password =@UserPassword";
                    SqlCommand cmdPassDefault = new SqlCommand(checkPassDefault, NAME);
                    cmdPassDefault.Parameters.Add(new SqlParameter("@Username", txtUserName.Text));
                    cmdPassDefault.Parameters.Add(new SqlParameter("@UserPassword", txtPass.Text));

                    SqlDataReader readPassDefault;

                    try
                    {

                        readPassDefault = cmdPassDefault.ExecuteReader();

                        while (readPassDefault.Read())
                        {
                            string readerResult = readPassDefault.GetValue(0).ToString();

                            int numVal = Int32.Parse(readerResult);

                            if (numVal == 0)
                            {

                                differentUsersLogin();

                            }
                            else
                            {
                                MessageBox.Show("Looks like you still haven't changed your default password. Please take a moment and go through the Change Password Portal on the Home Page of the Exam Retake Scheduler. This is for your own security benefit. Thank you!");

                                new frmPassword().Show();
                                this.Hide();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                    txtPass.Clear();

                }
            }
            catch (Exception exx)
            {

                MessageBox.Show(exx.Message);
            }            
        }

        private void btnStudents_Click(object sender, EventArgs e) //Visibility of elements on home form after Specific category has been selected (side buttons)
        {
            panelLeft.Visible = true;
            panelLeft.Height = btnStudents.Height;
            panelLeft.Top = btnStudents.Top;

            lblWelcStud.Visible = true;
            lblChoseCat.Visible = false;
            lblInstructionHome.Visible = true;
            lblWelcAdmin.Visible = false;
            lblWelcFac.Visible = false;
            lblWelcManag.Visible = false;
            lblUserName.Visible = true;
            lblUserPass.Visible = true;
            txtUserName.Visible = true;
            txtPass.Visible = true;
            btnLogin.Visible = true;
            linklblPassReset.Visible = true;

            txtUserName.Focus();

        }

        private void btnFaculty_Click(object sender, EventArgs e)  //Visibility of elements on home form after Specific category has been selected (side buttons)
        {
            panelLeft.Visible = true;
            panelLeft.Height = btnFaculty.Height;
            panelLeft.Top = btnFaculty.Top;

            lblWelcStud.Visible = false;
            lblChoseCat.Visible = false;
            lblInstructionHome.Visible = true;
            lblWelcAdmin.Visible = false;
            lblWelcFac.Visible = true;
            lblWelcManag.Visible = false;
            lblUserName.Visible = true;
            lblUserPass.Visible = true;
            txtUserName.Visible = true;
            txtPass.Visible = true;
            btnLogin.Visible = true;
            linklblPassReset.Visible = true;

            txtUserName.Focus();

        }

        private void btnManage_Click(object sender, EventArgs e)  //Visibility of elements on home form after Specific category has been selected (side buttons)
        {
            panelLeft.Visible = true;
            panelLeft.Height = btnManage.Height;
            panelLeft.Top = btnManage.Top;

            lblWelcStud.Visible = false;
            lblChoseCat.Visible = false;
            lblInstructionHome.Visible = true;
            lblWelcAdmin.Visible = false;
            lblWelcFac.Visible = false;
            lblWelcManag.Visible = true;
            lblUserName.Visible = true;
            lblUserPass.Visible = true;
            txtUserName.Visible = true;
            txtPass.Visible = true;
            btnLogin.Visible = true;
            linklblPassReset.Visible = true;

            txtUserName.Focus();

        }

        private void btnAdmin_Click(object sender, EventArgs e)  //Visibility of elements on home form after Specific category has been selected (side buttons)
        {
            panelLeft.Visible = true;
            panelLeft.Height = btnAdmin.Height;
            panelLeft.Top = btnAdmin.Top;

            lblWelcStud.Visible = false;
            lblChoseCat.Visible = false;
            lblInstructionHome.Visible = true;
            lblWelcAdmin.Visible = true;
            lblWelcFac.Visible = false;
            lblWelcManag.Visible = false;
            lblUserName.Visible = true;
            lblUserPass.Visible = true;
            txtUserName.Visible = true;
            txtPass.Visible = true;
            btnLogin.Visible = true;
            linklblPassReset.Visible = true;

            txtUserName.Focus();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim().Length != 0 & txtPass.Text.Trim().Length != 0)
            {
                string passText = txtPass.Text;

                if (passText.ToLower().Contains('-'))
                {
                    CheckPasswordDefaultDOB();

                }
                else
                {
                    differentUsersLogin();
                }
            }
            else if (txtUserName.Text.Trim().Length == 0 || txtPass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                txtPass.Clear();

            }
        }

        private void differentUsersLogin()
        {

            if (NAME.State == ConnectionState.Closed)
            {
                NAME.Open();
            }

            if (lblWelcFac.Visible == true)  //opens Student form in new window, if credentials correct.
            {
                //query to find user in the database with entered credentials
                SqlCommand Command = new SqlCommand("SELECT UserT_ID, UserT_Password, UserT_Salt FROM userTable where UserT_ID = @Username AND UserT_Role ='Faculty' ", NAME);
                Command.Parameters.Add(new SqlParameter("@Username", txtUserName.Text));

                SqlDataAdapter sda = new SqlDataAdapter(Command);

                DataTable dtbl = new DataTable();

                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    foreach (DataRow row in dtbl.Rows)
                    {
                        savedHashDB = row["UserT_Password"].ToString();
                        savedSaltDB = row["UserT_Salt"].ToString();
                    }

                    byte[] salt = Convert.FromBase64String(savedSaltDB);

                    string userPlainTextPass = txtPass.Text;

                    string saltAndPlainTextPassPreHash = savedSaltDB + userPlainTextPass;

                    var pbkdf2 = new Rfc2898DeriveBytes(saltAndPlainTextPassPreHash, salt, 10000);

                    byte[] hash = pbkdf2.GetBytes(32);

                    string userHashedPassword = Convert.ToBase64String(hash);


                    if (userHashedPassword == savedHashDB)
                    {
                        new frmFaculty().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                        txtPass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                    txtPass.Clear();
                }
            }

            else if (lblWelcStud.Visible == true)  //opens Faculty form in new window, if credentials correct.
            {
                SqlCommand Command = new SqlCommand("SELECT UserT_ID, UserT_Password, UserT_Salt FROM userTable where UserT_ID = @Username AND UserT_Role ='Student' ", NAME);
                Command.Parameters.Add(new SqlParameter("@Username", txtUserName.Text));

                SqlDataAdapter sda = new SqlDataAdapter(Command);

                DataTable dtbl = new DataTable();

                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    foreach (DataRow row in dtbl.Rows)
                    {
                        savedHashDB = row["UserT_Password"].ToString();
                        savedSaltDB = row["UserT_Salt"].ToString();                  
                    }

                    byte[] salt = Convert.FromBase64String(savedSaltDB);

                    string userPlainTextPass = txtPass.Text;

                    string saltAndPlainTextPassPreHash = savedSaltDB + userPlainTextPass;

                    var pbkdf2 = new Rfc2898DeriveBytes(saltAndPlainTextPassPreHash, salt, 10000);

                    byte[] hash = pbkdf2.GetBytes(32);

                    string userHashedPassword = Convert.ToBase64String(hash);


                    if (userHashedPassword == savedHashDB)
                    {
                        new frmStudent().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                        txtPass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                    txtPass.Clear();
                }
            }
            else if (lblWelcManag.Visible == true)  //opens Management form in new window, if credentials correct.
            {
                //query to find user in the database with entered credentials
                SqlCommand Command = new SqlCommand("SELECT UserT_ID, UserT_Password, UserT_Salt FROM userTable where UserT_ID = @Username AND UserT_Role ='Management' ", NAME);
                Command.Parameters.Add(new SqlParameter("@Username", txtUserName.Text));

                SqlDataAdapter sda = new SqlDataAdapter(Command);

                DataTable dtbl = new DataTable();

                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    foreach (DataRow row in dtbl.Rows)
                    {
                        savedHashDB = row["UserT_Password"].ToString();
                        savedSaltDB = row["UserT_Salt"].ToString();
                    }

                    byte[] salt = Convert.FromBase64String(savedSaltDB);

                    string userPlainTextPass = txtPass.Text;

                    string saltAndPlainTextPassPreHash = savedSaltDB + userPlainTextPass;

                    var pbkdf2 = new Rfc2898DeriveBytes(saltAndPlainTextPassPreHash, salt, 10000);

                    byte[] hash = pbkdf2.GetBytes(32);

                    string userHashedPassword = Convert.ToBase64String(hash);


                    if (userHashedPassword == savedHashDB)
                    {
                        new frmManagement().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                        txtPass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                    txtPass.Clear();
                }

            }
            else if (lblWelcAdmin.Visible == true)  //opens Admin form in new window, if credentials correct.
            {

                //query to find user in the database with entered credentials
                SqlCommand Command = new SqlCommand("SELECT UserT_ID, UserT_Password, UserT_Salt FROM userTable where UserT_ID = @Username AND UserT_Role ='Admin' ", NAME);
                Command.Parameters.Add(new SqlParameter("@Username", txtUserName.Text));

                SqlDataAdapter sda = new SqlDataAdapter(Command);

                DataTable dtbl = new DataTable();

                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    foreach (DataRow row in dtbl.Rows)
                    {
                        savedHashDB = row["UserT_Password"].ToString();
                        savedSaltDB = row["UserT_Salt"].ToString();
                    }

                    byte[] salt = Convert.FromBase64String(savedSaltDB);

                    string userPlainTextPass = txtPass.Text;

                    string saltAndPlainTextPassPreHash = savedSaltDB + userPlainTextPass;

                    var pbkdf2 = new Rfc2898DeriveBytes(saltAndPlainTextPassPreHash, salt, 10000);

                    byte[] hash = pbkdf2.GetBytes(32);

                    string userHashedPassword = Convert.ToBase64String(hash);


                    if (userHashedPassword == savedHashDB)
                    {
                        new frmAdmin().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                        txtPass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter correct username and password. If you believe the information entered is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                    txtPass.Clear();
                }
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)  //replaces user input with "*" character in the password textbok
        {
            txtPass.PasswordChar = '*';
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)  //passing text from username textbox to the public string (set value) to be used in other forms
        {
            setValue = txtUserName.Text;
        }

        private void linklblPassReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmPassword().Show();
            this.Hide();
        }

        private void txtPass_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnCloseHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
