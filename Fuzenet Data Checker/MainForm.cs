using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Fuzenet_Data_Checker.Properties;

namespace Fuzenet_Data_Checker
{
    public partial class Fuzenet : Form
    {
        static string percentageLocation = "style=\"width:";
        static int percetageLength = 4;

        static string dataUsedLocation = "data-percent=\"Used ";
        static int dataUsedLength = 7;

        static string dataTotalLocation = "B of ";
        static int dataTotalLength = 7;

        public Fuzenet()
        {
            InitializeComponent();

            // Get screen size
            Rectangle res = Screen.PrimaryScreen.Bounds;
            // Move it to Top-right
            this.Location = new Point(res.Width - Size.Width, 0);

            // Get it a legit colour
            increasedAmountLabel.ForeColor = Color.Green;

            string username = Settings.Default["UserName"].ToString();
            string password = Settings.Default["Password"].ToString();

            string webData = postData.canLogin(username, password);
            if (webData != "")
            {
                string dataUsed = retriveDataFromString(webData, dataUsedLocation, dataUsedLength, true);
                string dataTotal = retriveDataFromString(webData, dataTotalLocation, dataTotalLength, true);

                // If it is still 0
                int dataDifference = 0;
                if (Convert.ToInt32(Settings.Default["LastDataUsed"]) == 0)
                {
                    Settings.Default["LastDataUsed"] = Convert.ToInt32(dataUsed);
                }
                else
                {
                    dataDifference = Convert.ToInt32(dataUsed) - (int)Settings.Default["LastDataUsed"];
                    Settings.Default["LastDataUsed"] = Convert.ToInt32(dataUsed);
                }

                if (dataDifference < 0)
                {
                    // A new month starts, reset all data
                    dataDifference = 0;
                    Settings.Default["LastDataUsed"] = 0;
                }

                increasedAmountLabel.Text = "+ " + dataDifference.ToString() + " MB";
                dataLabel.Text = "Used " + dataUsed + " MB of " + dataTotal + " MB";

                double percentageUsed = Convert.ToDouble(retriveDataFromString(webData, percentageLocation, percetageLength, true));

                if (percentageUsed >= 75)
                {
                    MessageBox.Show("More than 75%", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (percentageUsed >= 100)
                {
                    MessageBox.Show("You have used up all your data!", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                internetUsageBar.Value = Convert.ToInt16(percentageUsed);
                percentageLabel.Text = percentageUsed.ToString() + "%";

                // Save data at the end
                Settings.Default.Save();
            }
            else
            {
                // Have to reset username and password if somehow they are wrong
                MessageBox.Show("Please reset your username and password", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Settings.Default.Reset();
                Application.Restart();
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            LoginForm newForm = new LoginForm();
            newForm.Show();
        }

        private string retriveDataFromString(string data, string location, int length, bool removeSpace)
        {
            string returnString = "";
            int dataIndex = data.IndexOf(location);
            returnString = data.Substring(dataIndex + location.Length, length);

            if (removeSpace) { returnString = returnString.Replace(" ", ""); }

            return returnString;
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            AboutForm newForm = new AboutForm();
            newForm.Show();
        }

        private void webBtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://fuzenet.symbill.com.au/customer/login/login_validation");
        }
    }
}
