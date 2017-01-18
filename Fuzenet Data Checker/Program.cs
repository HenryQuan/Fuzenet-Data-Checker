using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fuzenet_Data_Checker.Properties;

namespace Fuzenet_Data_Checker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Getting FirstLaunch from settings
            bool isFirstLaunch = Convert.ToBoolean(Settings.Default["FirstLaunch"]);
            string password = Settings.Default["Password"].ToString();

            if (isFirstLaunch || password == "")
            {
                // Launch this form when this app first launches
                // Or user decides to enter password every time
                Application.Run(new LoginForm());
            }
            else
            {
                Application.Run(new Fuzenet());
            }   
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
