using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fuzenet_Data_Checker.Properties;
using Microsoft.Win32;

namespace Fuzenet_Data_Checker
{
    public partial class Fuzenet : Form
    {
        public Fuzenet()
        {
            InitializeComponent();

            #region Form Setup

            // Get screen size
            var res = Screen.PrimaryScreen.Bounds;
            // Move it to Top-right
            Location = new Point(res.Width - Size.Width, 0);

            // Get it a legit colour for process bar
            increasedAmountLabel.ForeColor = Color.Green;

            // Ask for user if want to start this program when Windows startup
            if (!Convert.ToBoolean(Settings.Default["WindowsStartup"]))
            {
                var answer =
                    MessageBox.Show(
                        "Do you want to add this application to Windows Starup?\nThis application will close automatically after 15 seconds.",
                        "Windows Startup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    makeApplicationStartWithWindows();
                    Settings.Default["WindowsStartup"] = true;
                }
            }

            #endregion

            // Timer starts
            closeApplicationTimer.Enabled = true;

            #region Getting Data String

            // Get username and password for quick login
            var username = Settings.Default["UserName"].ToString();
            var password = Settings.Default["Password"].ToString();

            try
            {
                var webString = postData.canLogin(username, password);

                var dataUsage = "";
                foreach (Match dataUsageMatch in dataUsageRegex.Matches(webString))
                {
                    // There should be only one match
                    dataUsage = dataUsageMatch.Value;
                    dataLabel.Text = dataUsage;
                }

                // In order to save it later
                var usedData = 0;

                var percentageUsed = 0.0;
                var matchCount = 0;
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
                        MessageBox.Show("More than 75%", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    internetUsageBar.Value = Convert.ToInt16(percentageUsed);
                }
                else
                {
                    MessageBox.Show("You have used up all your data!", "Reminder", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    internetUsageBar.Value = 100;
                }

                // Only show 2 - 3 decimal
                percentageLabel.Text = percentageUsed.ToString().Substring(0, 5) + "%";

                #endregion

                #region Data Saving

                // Setup LastestDate
                var latestDate = Settings.Default["LastestDate"].ToString();

                // Setup LastDataUsed
                var lastDataUsed = Convert.ToInt32(Settings.Default["LastDataUsed"]);
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
                        var dataDifference = usedData - lastDataUsed;
                        if (dataDifference < 0)
                            Settings.Default["DataDifference"] = 0;
                        else
                            Settings.Default["DataDifference"] = dataDifference;

                        // Set it to today
                        Settings.Default["LastestDate"] = DateTime.Today;
                    }
                }

                // Save data at the end
                Settings.Default.Save();

                increasedAmountLabel.Text = "+ " + Settings.Default["DataDifference"] + " MB";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            #endregion
        }

        private void makeApplicationStartWithWindows()
        {
            // Add this program to Windows registry
            var registryKey = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (registryKey != null)
            {
                // Check if there is already a entry there
                var stringValue = registryKey.GetValue("Fuzenet Data Checker");
                if (stringValue == null)
                    registryKey.SetValue("Fuzenet Data Checker", Application.ExecutablePath);
            }
        }

        private void closeApplicationTimer_Tick(object sender, EventArgs e)
        {
            // Close this Application
            Application.ExitThread();
        }

        #region Constant

        // Using regular express to get data string from website
        private const string dataUsageString = @"Used \d{1,} MB of \d{1,} MB";
        private const string numberInString = @"\d{1,}";
        private readonly Regex dataUsageRegex = new Regex(dataUsageString, RegexOptions.None);
        private readonly Regex numberInRegex = new Regex(numberInString, RegexOptions.None);

        private readonly string defaultDate = @"1/1/1990 12:00:00 AM";

        #endregion

        #region Button Click

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            var newForm = new LoginForm();
            newForm.Show();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            var newForm = new AboutForm();
            newForm.Show();
        }

        private void webBtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://fuzenet.symbill.com.au/customer/login/login_validation");
        }

        #endregion
    }
}