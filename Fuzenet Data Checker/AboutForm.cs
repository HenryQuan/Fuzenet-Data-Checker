using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Fuzenet_Data_Checker
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void HenryQuanBox_Click(object sender, EventArgs e)
        {
            // Goes to my github page
            Process.Start("https://github.com/HenryQuan/Fuzenet-Data-Checker/");
        }

        private void emailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("natequan@hotmail.com");
            MessageBox.Show("Copied to Clipboard.");
        }
    }
}