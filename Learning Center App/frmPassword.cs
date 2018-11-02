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
using System.Security.Cryptography;

namespace Learning_Center_App
{
    public partial class frmPassword : Form
    {

        SqlConnection NAME = new SqlConnection("Data Source = <SERVER>;Initial Catalog = <DATABASE>; Integrated Security = True; MultipleActiveResultSets=True");

        DataSet dsUserPass = new DataSet();
        DataSet dsSecQA2 = new DataSet();

        private static string SecurityQsText1;
        private static string SecurityQsText2;

        private static string randomStringCode;

        private static string userEmail;

        private static string savedQAHash1;
        private static string savedQAHash2;

        private static string savedQASalt1;
        private static string savedQASalt2;

        
        public frmPassword()
        {
            InitializeComponent();
        }


        private void frmPassword_Load(object sender, EventArgs e)
        {
            pnlChangePass.Visible = false;
            pnlForgotPass.Visible = false;
            lblPassInstruct.Visible = false;

            lblWelcPassword.Visible = true;

            btnSendCode.Enabled = false;
            btnSaveChangPass.Enabled = false;

            btnSavPassFP.Enabled = false;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            pnlChangePass.Visible = true;
            pnlForgotPass.Visible = false;
            lblPassInstruct.Visible = true;
            lblWelcPassword.Visible = false;
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            pnlChangePass.Visible = false;
            pnlForgotPass.Visible = true;
            lblPassInstruct.Visible = true;
            lblWelcPassword.Visible = false;
        }

        private int numberPass(string pass)
        {
            int num = 0;

            foreach (char ch in pass)
            {
                if (char.IsDigit(ch))
                {
                    num++;
                }
            }
            return num;
        }

        private int upperCase(string pass)
        {
            int num = 0;

            foreach (char ch in pass)
            {
                if (char.IsUpper(ch))
                {
                    num++;
                }
            }
            return num;
        }

        private void btnExitFP_Click(object sender, EventArgs e)
        {
            string delAuthCodeQuery = "DELETE FROM dbo.authentication WHERE UserAuthenticationID =@UserName";

            SqlCommand cmdDelCode = new SqlCommand(delAuthCodeQuery, NAME);
            cmdDelCode.Parameters.AddWithValue("@UserName", txtUserNamFP.Text);


            if (NAME.State == ConnectionState.Closed)
            {
                NAME.Open();
            }

            try
            {
                if (cmdDelCode.ExecuteNonQuery() == 1)
                {

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

            new frmHome().Show();
            this.Close();
        }


        private void btnSavPassFP_Click(object sender, EventArgs e)
        {
            if (txtNewPassFP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter valid password!");
            }
            else
            {
                if (txtNewPassFP.Text != txtConfPassFP.Text)
                {
                    MessageBox.Show("Passwords don't match. Please retype.");
                }
                else
                {
                    //password validation block here. (call other voids)

                    const int MIN_LENGTHFP = 8;

                    string passwordFP = txtNewPassFP.Text;

                    if (passwordFP.Length >= MIN_LENGTHFP & numberPass(passwordFP) >= 1 & upperCase(passwordFP) >= 1)
                    {
                        if (NAME.State == ConnectionState.Closed)
                        {
                            NAME.Open();
                        }

                        try
                        {
                            string srchSecQA = "SELECT UserT_Ans1, UserT_SaltSec1, UserT_Ans2, UserT_SaltSec2 FROM dbo.userTable WHERE UserT_ID = @UserName";

                            SqlCommand cmdSrchQA = new SqlCommand(srchSecQA, NAME);

                            cmdSrchQA.Parameters.AddWithValue("@UserName", txtUserNamFP.Text);

                            SqlDataAdapter dataAdaptQA = new SqlDataAdapter(cmdSrchQA);

                            DataTable dtblQAHash = new DataTable();

                            dataAdaptQA.Fill(dtblQAHash);

                            if (dtblQAHash.Rows.Count == 1)
                            {
                                try
                                {
                                    foreach (DataRow row in dtblQAHash.Rows)
                                    {
                                        savedQAHash1 = row["UserT_Ans1"].ToString();
                                        savedQASalt1 = row["UserT_SaltSec1"].ToString();

                                        savedQAHash2 = row["UserT_Ans2"].ToString();
                                        savedQASalt2 = row["UserT_SaltSec2"].ToString();
                                    }

                                    byte[] saltQA1 = Convert.FromBase64String(savedQASalt1);
                                    byte[] saltQA2 = Convert.FromBase64String(savedQASalt2);


                                    string userPlainTextAns1 = txtSecAns1FP.Text.ToLower();
                                    string userPlainTextAns2 = txtSecAns2FP.Text.ToLower();


                                    string saltAndPlainTextAnsPreHash1 = savedQASalt1 + userPlainTextAns1;
                                    string saltAndPlainTextAnsPreHash2 = savedQASalt2 + userPlainTextAns2;


                                    var pbkdf21 = new Rfc2898DeriveBytes(saltAndPlainTextAnsPreHash1, saltQA1, 10000);
                                    var pbkdf22 = new Rfc2898DeriveBytes(saltAndPlainTextAnsPreHash2, saltQA2, 10000);


                                    byte[] hash1 = pbkdf21.GetBytes(32);
                                    byte[] hash2 = pbkdf22.GetBytes(32);


                                    string userHashedAnswer1 = Convert.ToBase64String(hash1);
                                    string userHashedAnswer2 = Convert.ToBase64String(hash2);

                                    if (userHashedAnswer1 == savedQAHash1 && userHashedAnswer2 == savedQAHash2)
                                    {

                                        //Update Password block of code ************************************************************************************************


                                        //Hash Password Block (generate salt and prepend to the password before hashing) **********************************************


                                        byte[] salt;
                                        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);  //generate new salt

                                        string saltSaved = Convert.ToBase64String(salt);  //salt to string so it can be saved in database along with hashed password

                                        string passPlainText = txtNewPassFP.Text;

                                        string saltAndPlainTextPassPreHash = saltSaved + passPlainText;

                                        var pbkdf2 = new Rfc2898DeriveBytes(saltAndPlainTextPassPreHash, salt, 10000);    //hashing function

                                        byte[] hash = pbkdf2.GetBytes(32);

                                        string newPasswordFP = Convert.ToBase64String(hash);    //hashed password to string so it can be saved


                                        //*****************************************************************************************************************************


                                        string updatePass = "UPDATE dbo.userTable SET UserT_Password = @NewPassword, UserT_Salt = @NewSaltGenerated WHERE UserT_ID = @Username";

                                        SqlCommand cmdUpdtPass = new SqlCommand(updatePass, NAME);
                                        cmdUpdtPass.Parameters.AddWithValue("@NewPassword", newPasswordFP.ToString());
                                        cmdUpdtPass.Parameters.AddWithValue("@NewSaltGenerated", saltSaved.ToString());
                                        cmdUpdtPass.Parameters.AddWithValue("@Username", txtUserNamFP.Text);


                                        try
                                        {
                                            if (cmdUpdtPass.ExecuteNonQuery() == 1)
                                            {
                                                MessageBox.Show("Passsword updated successfully");


                                                // log activity block here //////////////////////////////////////////////////////////////////////////////


                                                string hostName = Dns.GetHostName();
                                                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                                                string userName = Environment.UserName;


                                                string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@Username, @UserLogged, 'Password Reset', @HostName, GETDATE(), @IPAddress)";

                                                SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                                                cmdAvtivityLog.Parameters.AddWithValue("@Username", txtUserNamFP.Text);
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


                                                string delAuthCodeQuery = "DELETE FROM dbo.authentication WHERE UserAuthenticationID =@UserName";

                                                SqlCommand cmdDelCode = new SqlCommand(delAuthCodeQuery, NAME);
                                                cmdDelCode.Parameters.AddWithValue("@UserName", txtUserNamFP.Text);

                                                try
                                                {
                                                    if (cmdDelCode.ExecuteNonQuery() == 1)
                                                    {

                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                }

                                                txtUserNamFP.Clear();
                                                lblSecQ1Text.Text = "";
                                                txtSecAns1FP.Clear();
                                                lblSecQ2Text.Text = "";
                                                txtSecAns2FP.Clear();
                                                txtNewPassFP.Clear();
                                                txtConfPassFP.Clear();
                                                txtAuthentCode.Clear();
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
                                    else
                                    {
                                        MessageBox.Show("Security Answer(s) you have guven us don't match our records. Please double-check everything. If you forgot the answers please contact Rhonda Ryther (rytherr@moval.edu)");
                                    }
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong, make sure you didn't change your Username.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);                        }
                    }
                    else
                    {
                        MessageBox.Show("Password doesn't meat minimum criteria. It must contain: Upper case, Lower case, Number, and has to be at least 8 characters long.");
                    }

                    if (NAME.State == ConnectionState.Open)
                    {
                        NAME.Close();
                    }               
                }
            }
        }

        private void txtNewPassFP_TextChanged(object sender, EventArgs e)
        {
            txtNewPassFP.PasswordChar = '*';
        }

        private void txtConfPassFP_TextChanged(object sender, EventArgs e)
        {
            txtConfPassFP.PasswordChar = '*';
        }

        private void txtUserNamFP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)      //only numbers accepted ... textbox also has limited length (set to maxLength = 9 in properties)
            {
                e.Handled = true;
            }
        }

        private void btnFindUSername_Click(object sender, EventArgs e)
        {
            if (txtUserNamFP.Text == "")
            {
                MessageBox.Show("Please enter a valid Username.");
            }
            else
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                string findSecQsFP = "SELECT UserT_SecQ1, UserT_SecQ2 from dbo.userTable WHERE UserT_ID = @Username AND UserT_SecQ1 IS NOT NULL AND UserT_SecQ2 IS NOT NULL";

                SqlCommand cmdSecQFP = new SqlCommand(findSecQsFP, NAME);
                cmdSecQFP.Parameters.AddWithValue("@Username", txtUserNamFP.Text);

                SqlDataReader dataReadSecQsFP;

                try
                {
                   
                    dataReadSecQsFP = cmdSecQFP.ExecuteReader();

                    int count = 0;

                    while (dataReadSecQsFP.Read())
                    {
                        count += 1;
                    }

                    if (count == 1)
                    {
                        randomStringGenerator();

                        string searchEmailAddress = "SELECT UserT_Email FROM dbo.userTable WHERE UserT_ID =@Username";

                        SqlCommand cmdEmail = new SqlCommand(searchEmailAddress, NAME);
                        cmdEmail.Parameters.Add(new SqlParameter("@Username", txtUserNamFP.Text));

                        SqlDataReader readEmail = cmdEmail.ExecuteReader();

                        try
                        {
                            while (readEmail.Read())
                            {
                                string userEmail = readEmail.GetValue(0).ToString();


                                MailMessage msg = new MailMessage(<EMAIL>, "" + userEmail.ToString() + "", "Authentication Code", "Your one-time authentication code for Exam-Retake Scheduler is: " + randomStringCode.ToString() + ". This code will expire once you close the application.");
                                SmtpClient mail = new SmtpClient();
                                mail.Host = "smtp.gmail.com";
                                mail.Port = 587;
                                mail.Credentials = new NetworkCredential(<EMAIL>, <PASSWORD>);
                                mail.EnableSsl = true;
                                mail.Send(msg);

                                MessageBox.Show("Your one-time authentication code has been sent to: '" + userEmail.ToString() + "'.");
                            }
                        }
                        catch (Exception exp)
                        {

                            MessageBox.Show(exp.Message);
                        }
                  
                        string insertQuery = "INSERT INTO dbo.authentication VALUES(@UserAuthentID, @UserAuthentCode)";

                        SqlCommand command = new SqlCommand(insertQuery, NAME);
                        command.Parameters.Add(new SqlParameter("@UserAuthentID", txtUserNamFP.Text));
                        command.Parameters.Add(new SqlParameter("@UserAuthentCode", randomStringCode.ToString()));

                        try
                        {
                            if (command.ExecuteNonQuery() == 1)
                            {

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
                    else
                    {
                        MessageBox.Show("Something is wrong. Please make sure the Username is correct. If you haven't changed your password before (haven't set security questions), try typing your Date Of Birth when logging in.");

                        lblSecQ1Text.Text = "";
                        lblSecQ2Text.Text = "";
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

        private void randomStringGenerator()
        {
            char[] characters = "qwertyuioplkjhgfdsazxcvbnm1234567890".ToCharArray();
            Random r = new Random();
            string randomString = "";
            for (int i = 0; i < 10; i++)
            {
                randomString += characters[r.Next(0, 35)].ToString();

                randomStringCode = randomString;
            }
        }

        private void btnAuthent_Click(object sender, EventArgs e)
        {
            if (txtUserNamFP.Text == "" || txtAuthentCode.Text == "")
            {
                MessageBox.Show("Make sure both Username and Authentication Code are entered.");
            }

            else
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                string authenticateQuery = "SELECT * FROM dbo.authentication WHERE UserAuthenticationID = @Username AND UserAuthenticationCode = @UserCode";

                SqlCommand cmdAuthent = new SqlCommand(authenticateQuery, NAME);
                cmdAuthent.Parameters.AddWithValue("@Username", txtUserNamFP.Text);
                cmdAuthent.Parameters.AddWithValue("@UserCode", txtAuthentCode.Text);


                SqlDataReader dataReadAuthenticate;

                try
                {
                    dataReadAuthenticate = cmdAuthent.ExecuteReader();

                    int count = 0;

                    while (dataReadAuthenticate.Read())
                    {
                        count += 1;
                    }

                    if (count == 1)
                    {
                        btnSavPassFP.Enabled = true;

                        string findSecQsFP = "SELECT UserT_SecQ1, UserT_SecQ2 from dbo.userTable WHERE UserT_ID = @Username AND UserT_SecQ1 IS NOT NULL AND UserT_SecQ2 IS NOT NULL";

                        SqlCommand cmdSecQFP = new SqlCommand(findSecQsFP, NAME);
                        cmdSecQFP.Parameters.AddWithValue("@Username", txtUserNamFP.Text);

                        SqlDataReader dataReadSecQsFP;

                        try
                        {                           
                            dataReadSecQsFP = cmdSecQFP.ExecuteReader();

                            int count2 = 0;

                            while (dataReadSecQsFP.Read())
                            {
                                count2 += 1;

                                string SecQ1 = dataReadSecQsFP.GetValue(0).ToString();

                                string SecQ2 = dataReadSecQsFP.GetValue(1).ToString();

                                SecurityQsText1 = SecQ1.ToString();
                                SecurityQsText2 = SecQ2.ToString();
                            }

                            if (count2 == 1)
                            {

                                lblSecQ1Text.Text = SecurityQsText1.ToString();
                                lblSecQ2Text.Text = SecurityQsText2.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Something is wrong. Please make sure the Username is correct. If you haven't changed your password before (haven't set security questions), try typing your Date Of Birth when logging in.");

                                lblSecQ1Text.Text = "";
                                lblSecQ2Text.Text = "";
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
                        MessageBox.Show("Something is wrong. If you closed this window after getting Authentication Code, it will not work. Press Find User button to receive a new Code.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //************************************************************************************************************************************


        //************************************     CHANGE PASSWORD PORTAL CODE FROM HERE DOWN  **********************************************


        //************************************************************************************************************************************


        private void btnValidateCredentCP_Click(object sender, EventArgs e)
        {          
            if (NAME.State == ConnectionState.Closed)
            {
                NAME.Open();
            }

            if (txtUsernameCP.Text.Trim().Length != 0 & txtOldPass.Text.Trim().Length != 0)
            {
                string passText = txtOldPass.Text;

                if (passText.ToLower().Contains('-'))
                {
                    string srchUserDefaultPass = "SELECT * FROM dbo.userTable WHERE UserT_ID = @UserName AND UserT_Password = @UserPasswordDefault";

                    SqlCommand cmdSrchUserDefaultPass = new SqlCommand(srchUserDefaultPass, NAME);
                    cmdSrchUserDefaultPass.Parameters.AddWithValue("@UserName", txtUsernameCP.Text);
                    cmdSrchUserDefaultPass.Parameters.AddWithValue("@UserPasswordDefault", txtOldPass.Text);

                    try
                    {
                        SqlDataAdapter dataAdaptQAExist = new SqlDataAdapter(cmdSrchUserDefaultPass);

                        dataAdaptQAExist.Fill(dsSecQA2);

                        int o = dsSecQA2.Tables[0].Rows.Count;

                        if (o > 0)
                        {
                            SqlCommand cmdSrchQADefPass = new SqlCommand("SELECT * FROM userTable where UserT_ID = @Username AND UserT_SecQ1 IS NULL AND UserT_SecQ1 IS NULL AND UserT_Ans1 IS NULL AND UserT_Ans2 IS NULL", NAME);
                            cmdSrchQADefPass.Parameters.AddWithValue("@UserName", txtUsernameCP.Text);

                            SqlDataAdapter sdaQADef = new SqlDataAdapter(cmdSrchQADefPass);

                            DataTable dtblQADef = new DataTable();


                            try
                            {
                                sdaQADef.Fill(dtblQADef);

                                if (dtblQADef.Rows.Count == 1)
                                {
                                    MessageBox.Show("Good deal, we found you in our database! Proceed by setting up your Security Questions.");

                                    btnSendCode.Enabled = true;
                                    btnSaveChangPass.Enabled = true;
                                }

                                else
                                {
                                    MessageBox.Show("Looks like you already set up Security Questions. Scratch your head couple times.");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            findUsernamePassQAHashed();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    findUsernamePassQAHashed();
                }
            }
            else if (txtUsernameCP.Text.Trim().Length == 0 || txtOldPass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter correct username and password.");
            }

            if (NAME.State == ConnectionState.Open)
            {
                NAME.Close();
            }
        }

        private void findUsernamePassQAHashed()
        {
            if (NAME.State == ConnectionState.Closed)
            {
                NAME.Open();
            }


            SqlCommand cmdSrchUsernamPass = new SqlCommand("SELECT UserT_ID, UserT_Password, UserT_Salt FROM userTable where UserT_ID = @Username", NAME);
            cmdSrchUsernamPass.Parameters.AddWithValue("@UserName", txtUsernameCP.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmdSrchUsernamPass);

            DataTable dtbl = new DataTable();

            try
            {
                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    string savedPasswordHash = dtbl.Rows[0][1].ToString();
                    byte[] hashedBytes = Convert.FromBase64String(savedPasswordHash);

                    byte[] salt = new byte[16];

                    Array.Copy(hashedBytes, 0, salt, 0, 16);


                    var pbkdf2 = new Rfc2898DeriveBytes(txtOldPass.Text, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);


                    int ok = 1;

                    for (int i = 0; i < 20; i++)

                        if (hashedBytes[i + 16] != hash[i])
                            ok = 0;

                    if (ok == 1)
                    {
                        SqlCommand cmdSrchQAHashPass = new SqlCommand("SELECT * FROM userTable where UserT_ID = @Username AND UserT_SecQ1 IS NULL AND UserT_SecQ1 IS NULL AND UserT_Ans1 IS NULL AND UserT_Ans2 IS NULL", NAME);
                        cmdSrchQAHashPass.Parameters.AddWithValue("@UserName", txtUsernameCP.Text);

                        SqlDataAdapter sdaQAHash = new SqlDataAdapter(cmdSrchQAHashPass);

                        DataTable dtblQAHash = new DataTable();

                        try
                        {
                            sdaQAHash.Fill(dtblQAHash);

                            if (dtblQAHash.Rows.Count == 1)
                            {
                                MessageBox.Show("Good deal, we found you in our database! Proceed by setting up your Security Questions.");

                                btnSendCode.Enabled = true;
                                btnSaveChangPass.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Looks like you already set up Security Questions. Scratch your head couple times.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong username/password! Information enetered doesn't match our records. If you believe the information is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username/password! Information enetered doesn't match our records. If you believe the information is correct please contact Rhonda Ryther (rytherr@moval.edu). Thank you.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!! Your default password is your Date Of Birth in format mm-dd-YYYY ");
            }
            if (NAME.State == ConnectionState.Open)
            {
                NAME.Close();
            }
        }

        private void btnSaveChangPass_Click(object sender, EventArgs e)
        {
         
            if (cboSecQ1.Text == "" || txtSecAns1.Text =="" || cboSecQ2.Text == "" || txtSecAns2.Text == "" || cboSecQ1.Text == cboSecQ2.Text)
            {
                MessageBox.Show("Please make sure to select two Diferent Security questions.");
            }
            else
            {
                if (txtNewPassCP.Text == "")
                {
                    MessageBox.Show("Please enter valid password!");
                }
                else
                {
                    if (txtNewPassCP.Text != txtConfPassCP.Text)
                    {
                        MessageBox.Show("Passwords don't match. Please retype.");
                    }
                    else
                    {
                        if (NAME.State == ConnectionState.Closed)
                        {
                            NAME.Open();
                        }

                        //password validation block here. (call other voids)

                        const int MIN_LENGTHCP = 8;

                        string passwordCP = txtNewPassCP.Text;

                        if (passwordCP.Length >= MIN_LENGTHCP & numberPass(passwordCP) >= 1 & upperCase(passwordCP) >= 1)
                        {
                            string authenticateQueryCP = "SELECT * FROM dbo.authentication WHERE UserAuthenticationID = @Username AND UserAuthenticationCode = @UserCode";

                            SqlCommand cmdAuthentCP = new SqlCommand(authenticateQueryCP, NAME);
                            cmdAuthentCP.Parameters.AddWithValue("@Username", txtUsernameCP.Text);
                            cmdAuthentCP.Parameters.AddWithValue("@UserCode", txtAuthentCodeChangePass.Text);


                            SqlDataAdapter dataAdapt = new SqlDataAdapter(cmdAuthentCP);

                            DataSet dsUserCP = new DataSet();

                            dataAdapt.Fill(dsUserCP);

                            int i = dsUserCP.Tables[0].Rows.Count;

                            if (i > 0)
                            {

                                //Update Password block of code ************************************************************************************************

                                //Hash Password Block (generate salt and prepend to the password before hashing) **********************************************

                                byte[] salt;  
                                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);  //generate new salt

                                string saltSaved = Convert.ToBase64String(salt);  //salt to string so it can be saved in database along with hashed password

                                string passPlainText = txtNewPassCP.Text;

                                string saltAndPlainTextPassPreHash = saltSaved + passPlainText;

                                var pbkdf2 = new Rfc2898DeriveBytes(saltAndPlainTextPassPreHash, salt, 10000);    //hashing function

                                byte[] hash = pbkdf2.GetBytes(32);
  
                                string newPasswordCP = Convert.ToBase64String(hash);    //hashed password to string so it can be saved


                                //*****************************************************************************************************************************


                                //Hash SecAnswer1 Block ********************************************************************************************************

                                byte[] saltSec1;
                                new RNGCryptoServiceProvider().GetBytes(saltSec1 = new byte[16]);  //generate new salt

                                string saltSavedSec1 = Convert.ToBase64String(saltSec1);  //salt to string so it can be saved in database 

                                string SecAnswerText1 = txtSecAns1.Text;

                                string SecAnswerLowCase1 = SecAnswerText1.ToLower();

                                string saltAndPlainTextSecAnsPreHash1 = saltSavedSec1 + SecAnswerLowCase1;

                                var pbkdf21 = new Rfc2898DeriveBytes(saltAndPlainTextSecAnsPreHash1, saltSec1, 10000);    //hashing function

                                byte[] hashSec1 = pbkdf21.GetBytes(32);

                                string stringToSaveSec1 = Convert.ToBase64String(hashSec1);    //hashed Answer to string so it can be saved

                                //*****************************************************************************************************************************


                                //Hash SecAnswer2 Block ********************************************************************************************************

                                byte[] saltSec2;
                                new RNGCryptoServiceProvider().GetBytes(saltSec2 = new byte[16]);  

                                string saltSavedSec2 = Convert.ToBase64String(saltSec2);

                                string SecAnswerText2 = txtSecAns2.Text;

                                string SecAnswerLowCase2 = SecAnswerText2.ToLower();

                                string saltAndPlainTextSecAnsPreHash2 = saltSavedSec2 + SecAnswerLowCase2;

                                var pbkdf22 = new Rfc2898DeriveBytes(saltAndPlainTextSecAnsPreHash2, saltSec2, 10000);    

                                byte[] hashSec2 = pbkdf22.GetBytes(32);

                                string stringToSaveSec2 = Convert.ToBase64String(hashSec2);    

                                //*****************************************************************************************************************************


                                string updatePassCP = "UPDATE dbo.userTable SET UserT_Password = @NewPassword, UserT_Salt = @NewSaltGenerated, UserT_SecQ1 = @SecurityQuestion1, UserT_Ans1 = @Answer1, UserT_SaltSec1 = @SaltSec1, UserT_SecQ2 = @SecurityQuestion2,  UserT_Ans2 = @Answer2, UserT_SaltSec2 = @SaltSec2 WHERE UserT_ID = @Username";

                                SqlCommand cmdUpdtPassCP = new SqlCommand(updatePassCP, NAME);
                                cmdUpdtPassCP.Parameters.AddWithValue("@NewPassword", newPasswordCP.ToString());
                                cmdUpdtPassCP.Parameters.AddWithValue("@NewSaltGenerated", saltSaved.ToString());
                                cmdUpdtPassCP.Parameters.AddWithValue("@SecurityQuestion1", cboSecQ1.Text);
                                cmdUpdtPassCP.Parameters.AddWithValue("@Answer1", stringToSaveSec1.ToString());
                                cmdUpdtPassCP.Parameters.AddWithValue("@SaltSec1", saltSavedSec1.ToString());
                                cmdUpdtPassCP.Parameters.AddWithValue("@SecurityQuestion2", cboSecQ2.Text);
                                cmdUpdtPassCP.Parameters.AddWithValue("@Answer2", stringToSaveSec2.ToString());
                                cmdUpdtPassCP.Parameters.AddWithValue("@SaltSec2", saltSavedSec2.ToString());
                                cmdUpdtPassCP.Parameters.AddWithValue("@Username", txtUsernameCP.Text);


                                try
                                {
                                    if (cmdUpdtPassCP.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Passsword updated successfully");

                                        btnSendCode.Enabled = false;
                                        btnSaveChangPass.Enabled = false;

                                        string hostName = Dns.GetHostName();
                                        string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                                        string userName = Environment.UserName;



                                        string logActivityQuery = "INSERT INTO dbo.activityLog (UserA_ID, UserA_LoggedIn, UserA_Activity, Machine_Name, Time_Stamp, Machine_IP) VALUES (@Username, @UserLogged, 'Password Change', @HostName, GETDATE(), @IPAddress)";

                                        SqlCommand cmdAvtivityLog = new SqlCommand(logActivityQuery, NAME);
                                        cmdAvtivityLog.Parameters.AddWithValue("@Username", txtUserNamFP.Text);
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


                                        string delAuthCodeQuery = "DELETE FROM dbo.authentication WHERE UserAuthenticationID =@UserName";

                                        SqlCommand cmdDelCode = new SqlCommand(delAuthCodeQuery, NAME);
                                        cmdDelCode.Parameters.AddWithValue("@UserName", txtUsernameCP.Text);

                                        try
                                        {
                                            if (cmdDelCode.ExecuteNonQuery() == 1)
                                            {

                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        txtUsernameCP.Clear();
                                        txtOldPass.Clear();
                                        cboSecQ1.Text = "";
                                        txtSecAns1.Clear();
                                        cboSecQ2.Text = "";
                                        txtSecAns2.Clear();
                                        txtNewPassCP.Clear();
                                        txtConfPassCP.Clear();
                                        txtAuthentCodeChangePass.Clear();
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

                                dsUserPass.Clear();
                                dsSecQA2.Clear(); dsUserCP.Clear();

                            }
                            else
                            {

                                MessageBox.Show("Something is not right. Make sure you typed your Authentication CODE right.");
                                dsUserCP.Clear();
                            }                                 
                        }
                        else
                        {
                            MessageBox.Show("Password doesn't meat minimum criteria. It must contain: Upper case, Lower case, Number, and has to be at least 8 characters long.");
                        }
                        if (NAME.State == ConnectionState.Open)
                        {
                            NAME.Close();
                        }

                    }
                }                    
            }
        }

        private void txtNewPassCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNewPassCP.PasswordChar = '*';
        }

        private void txtConfPassCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtConfPassCP.PasswordChar = '*';
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)      //only numbers accepted ... textbox also has limited length (set to maxLength = 9 in properties)
            {
                e.Handled = true;
            }
        }

        private void txtOldPass_TextChanged(object sender, EventArgs e)
        {
            txtOldPass.PasswordChar = '*';
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            if (txtUsernameCP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a valid Username.");
            }
            else
            {
                if (NAME.State == ConnectionState.Closed)
                {
                    NAME.Open();
                }

                string searchEmailAddressChangePass = "SELECT UserT_Email FROM dbo.userTable WHERE UserT_ID =@Username";

                SqlCommand cmdEmailCP = new SqlCommand(searchEmailAddressChangePass, NAME);
                cmdEmailCP.Parameters.Add(new SqlParameter("@Username", txtUsernameCP.Text));

                SqlDataAdapter dataAdapt = new SqlDataAdapter(cmdEmailCP);

                DataSet dsUserEmail = new DataSet("UserT_Email");

                dataAdapt.FillSchema(dsUserEmail, SchemaType.Source, "userTable");

                dataAdapt.Fill(dsUserEmail, "userTable");

                DataTable dt;
                dt = dsUserEmail.Tables["userTable"];

                int i = dsUserEmail.Tables[0].Rows.Count;

                try
                {
                    if (i > 0)
                    {
                        randomStringGenerator();

                        foreach (DataRow drCurrent in dt.Rows)
                        {
                            userEmail = drCurrent["UserT_Email"].ToString();

                        }

                        MailMessage msg = new MailMessage(<EMAIL>, "" + userEmail.ToString() + "", "Authentication Code", "Your one-time authentication code for password change is: " + randomStringCode.ToString() + ". This code will expire once you close the application.");
                        SmtpClient mail = new SmtpClient();
                        mail.Host = "smtp.gmail.com";
                        mail.Port = 587;
                        mail.Credentials = new NetworkCredential(<EMAIL>, <PASSWORD>);
                        mail.EnableSsl = true;
                        mail.Send(msg);

                        MessageBox.Show("Your one-time authentication code has been sent to: '" + userEmail.ToString() + "'.");

                        string insertQuery = "INSERT INTO dbo.authentication VALUES(@UserAuthentID, @UserAuthentCode)";

                        SqlCommand command = new SqlCommand(insertQuery, NAME);
                        command.Parameters.Add(new SqlParameter("@UserAuthentID", txtUsernameCP.Text));
                        command.Parameters.Add(new SqlParameter("@UserAuthentCode", randomStringCode.ToString()));

                        try
                        {
                            if (command.ExecuteNonQuery() == 1)
                            {

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

                        dsUserEmail.Clear();

                    }
                    else 
                    {
                    MessageBox.Show("Something is wrong. Please make sure your Username is correct!");
                    dsUserEmail.Clear();

                    }           
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                if (NAME.State == ConnectionState.Open)
                {
                    NAME.Close();
                }
            }          
        }

        private void btnExitCP_Click_1(object sender, EventArgs e)
        {
            string delAuthCodeQueryCP = "DELETE FROM dbo.authentication WHERE UserAuthenticationID =@UserName";

            SqlCommand cmdDelCodeCP = new SqlCommand(delAuthCodeQueryCP, NAME);
            cmdDelCodeCP.Parameters.AddWithValue("@UserName", txtUsernameCP.Text);


            if (NAME.State == ConnectionState.Closed)
            {
                NAME.Open();
            }

            try
            {
                if (cmdDelCodeCP.ExecuteNonQuery() == 1)
                {

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

            new frmHome().Show();
            this.Close();
        }
    }
}
