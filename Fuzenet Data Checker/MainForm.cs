using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Fuzenet_Data_Checker.Properties;
using System.Text.RegularExpressions;

namespace Fuzenet_Data_Checker
{
    public partial class Fuzenet : Form
    {
        #region Constant
        // Using regular express to get data string from website
        const string dataUsageString = @"Used \d{1,} MB of \d{1,} MB";
        const string numberInString = @"\d{1,}";
        Regex dataUsageRegex = new Regex(dataUsageString, RegexOptions.None);
        Regex numberInRegex = new Regex(numberInString, RegexOptions.None);

        string defaultDate = @"1/1/1990 12:00:00 AM";
        #endregion

        public Fuzenet()
        {
            InitializeComponent();

            #region Form Setup
            // Get screen size
            Rectangle res = Screen.PrimaryScreen.Bounds;
            // Move it to Top-right
            this.Location = new Point(res.Width - Size.Width, 0);

            // Get it a legit colour for process bar
            increasedAmountLabel.ForeColor = Color.Green;
            #endregion

            #region Getting Data String
            // Get username and password for quick login
            string username = Settings.Default["UserName"].ToString();
            string password = Settings.Default["Password"].ToString();

            try
            {
                string webString = postData.canLogin(username, password);

                string dataUsage = "";
                foreach (Match dataUsageMatch in dataUsageRegex.Matches(webString))
                {
                    // There should be only one match
                    dataUsage = dataUsageMatch.Value.ToString();
                    dataLabel.Text = dataUsage;
                }

                // In order to save it later
                int usedData = 0;

                double percentageUsed = 0.0;
                int matchCount = 0;
                foreach (Match numberMatch in numberInRegex.Matches(dataUsage))
                {
                    // There should be only two matches
                    matchCount++;
                    if (matchCount == 1)
                    {
                        percentageUsed = Convert.ToDouble(numberMatch.Value);
                        usedData = Convert.ToInt32(numberMatch.Value);
                    }
                    else if (matchCount == 2)
                    {
                        // Divide itself by total data used
                        percentageUsed /= Convert.ToDouble(numberMatch.Value);
                    }
                    Console.WriteLine(numberMatch);
                }

                // To make it a percentage
                percentageUsed *= 100;

                if (percentageUsed < 100)
                {
                    if (percentageUsed >= 75)
                    {
                        MessageBox.Show("More than 75%", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    internetUsageBar.Value = Convert.ToInt16(percentageUsed);
                }
                else
                {
                    MessageBox.Show("You have used up all your data!", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    internetUsageBar.Value = 100;
                }

                // Only show 2 - 3 decimal
                percentageLabel.Text = percentageUsed.ToString().Substring(0, 5) + "%";
                #endregion

                #region Data Saving
                // Setup LastestDate
                string latestDate = Settings.Default["LastestDate"].ToString();

                // Setup LastDataUsed
                int lastDataUsed = Convert.ToInt32(Settings.Default["LastDataUsed"]);
                Settings.Default["LastDataUsed"] = usedData;

                if (latestDate == defaultDate)
                {
                    Settings.Default["LastestDate"] = DateTime.Today;
                }
                else
                {
                    // Today is not the lastest day
                    if (latestDate != DateTime.Today.ToString())
                    {
                        // Calculate the data difference
                        int dataDifference = usedData - lastDataUsed;
                        if (dataDifference < 0)
                        {
                            // A new month starts
                            Settings.Default["DataDifference"] = 0;
                        }
                        else
                        {
                            Settings.Default["DataDifference"] = dataDifference;
                        }

                        // Set it to today
                        Settings.Default["LastestDate"] = DateTime.Today;
                    }
                }

                // Save data at the end
                Settings.Default.Save();

                increasedAmountLabel.Text = "+ " + Settings.Default["DataDifference"].ToString() + " MB";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            #endregion
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            LoginForm newForm = new LoginForm();
            newForm.Show();
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
