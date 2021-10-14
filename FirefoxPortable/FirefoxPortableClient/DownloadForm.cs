using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefoxPortableClient
{
    public partial class DownloadForm : Form
    {
        string Link = "https://c2bda-my.sharepoint.com/:u:/g/personal/admin_c2bda_onmicrosoft_com/ERDWTWG8uotOolGWzZ3qgsYBdiwase-TnArYnSn36XQA3A?download=1";
        public DownloadForm()
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;

            InitializeComponent();
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
        }


        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }


        public void DownloadFile(string serverFilePath, string destPath)
        {
            try
            {
                //var url = string.Format("{0}/{1}", ServerURL, serverFilePath);
                Directory.CreateDirectory(Path.GetDirectoryName(destPath)); // this method creates your directory
                var request = System.Net.HttpWebRequest.Create(serverFilePath);
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                using (var sReader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    using (var sWriter = new StreamWriter(destPath))
                    {
                        sWriter.Write(sReader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DownloadFile(Link, @"c:\front_view\myfile.zip");


                //using (WebClient wc = new WebClient())
                //{
                //    //wc.DownloadFileAsync(
                //    //    // Param1 = Link of file
                //    //    new System.Uri("https://c2bda-my.sharepoint.com/:u:/g/personal/admin_c2bda_onmicrosoft_com/ERDWTWG8uotOolGWzZ3qgsYBdiwase-TnArYnSn36XQA3A?download=1"),
                //    //    // Param2 = Path to save
                //    //    @"C:\front_view"
                //    //);
                //    //wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36");

                //    wc.Headers.Add("User-Agent: Other");

                //    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                //    wc.DownloadDataCompleted += wc_DownloadDataCompleted;
                //     wc.DownloadDataAsync(new Uri(Link));


                //        //new Uri(""),
                //        //@"c:\front_view\myfile.zip");

                //}
            }
            catch (Exception ex)
            {

            }
        }

        private void wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            //    var a = e.Result;
        }
    }
}
