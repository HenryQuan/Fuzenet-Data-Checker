using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Fuzenet_Data_Checker
{
    class postData
    {
        public static string canLogin(string username, string password)
        {
            string isAbleToLogin = "";
            try
            {
                // Making up postdata string and print it out for reference
                string postData = "rpth=customer/home&username=" + username + "&password=" + password + "&login_submit=Login";
                string postAddress = "https://fuzenet.symbill.com.au/customer/login/login_validation";

                // Posting data
                var cookieContainer = new CookieContainer();
                HttpWebRequest request = WebRequest.Create(postAddress) as HttpWebRequest;
                request.Method = "POST";

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                // THIS IS IMPORTANT OTHERWISES IT DOES NOT WORK
                request.CookieContainer = cookieContainer;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                if (responseFromServer.Contains("Logout"))
                {
                    isAbleToLogin = responseFromServer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return isAbleToLogin;
        }
    }
}