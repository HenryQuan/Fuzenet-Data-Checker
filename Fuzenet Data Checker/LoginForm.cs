using System;
using System.Diagnostics;
using System.Windows.Forms;
using Fuzenet_Data_Checker.Properties;

namespace Fuzenet_Data_Checker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            var doSavePassword = Convert.ToBoolean(Settings.Default["SavePassword"]);
            if (doSavePassword)
                savePwdCheckBox.Checked = true;

            usernameBox.Text = Settings.Default["UserName"].ToString();
            passwordBox.Text = Settings.Default["Password"].ToString();
        }

        private void resetPwdLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://fuzenet.symbill.com.au/customer_login");
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var username = usernameBox.Text;
            var password = passwordBox.Text;

            if (username == string.Empty || string.IsNullOrWhiteSpace(username) || password == string.Empty ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(@"Please enter all information needed", @"Warning!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                // It return non-empty string
                if (postData.canLogin(username, password) != "")
                {
                    // It takes me a long time to be here
                    MessageBox.Show("Login successfully!");

                    // Saving data
                    if (savePwdCheckBox.Checked)
                    {
                        Settings.Default["Password"] = password;
                        Settings.Default["SavePassword"] = true;
                    }
                    else
                    {
                        // Remove password
                        Settings.Default["Password"] = "";
                        Settings.Default["SavePassword"] = false;
                    }

                    // Setup is done and do not show this form when program launches
                    Settings.Default["FirstLaunch"] = false;
                    Settings.Default["UserName"] = username;
                    Settings.Default.Save();

                    // Dont have to open a new MainForm if it is not FirstLaunch
                    if (!Convert.ToBoolean(Settings.Default["FirstLaunch"]))
                    {
                        var newForm = new Fuzenet();
                        newForm.Show();
                        Hide();
                    }
                }
                else
                {
                    passwordBox.Text = "";
                    MessageBox.Show("Password or Username is not correct");
                }
            }
        }
    }
}