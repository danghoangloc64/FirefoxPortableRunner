using FirefoxPortableDatabase;
using FirefoxPortableDatabase.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefoxPortableClient
{
    public partial class DownloadForm : Form
    {
        private string m_strFolder;
        private string m_strFileNameDownLoad;
        private string m_strFolderNameExtract;
        private ClientInformationModel m_objClientInformationModel;

        public DownloadForm(ClientInformationModel clientInformationModel)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;

            m_strFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Windows");
            m_strFileNameDownLoad = Path.Combine(m_strFolder, ExtensionMethod.RandomString() + ".zip");
            m_objClientInformationModel = clientInformationModel;
            m_strFolderNameExtract = Path.Combine(m_strFolder, clientInformationModel.FolderName);
            InitializeComponent();
        }


        private void DownloadForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(m_strFolderNameExtract))
                {
                    Run();
                }

                if (File.Exists(m_strFileNameDownLoad))
                {
                    File.Delete(m_strFileNameDownLoad);
                }

                foreach (var folderProfile in m_objClientInformationModel.OtherFolderName)
                {
                    if (Directory.Exists(folderProfile))
                    {
                        Directory.Delete(folderProfile, true);
                    }
                }

                using (var wc = new WebClient())
                {
                    wc.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"94\", \"Google Chrome\";v=\"94\", \";Not A Brand\";v=\"99\"");
                    wc.Headers.Add("sec-ch-ua-mobile", "?0");
                    wc.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                    wc.Headers.Add("Upgrade-Insecure-Requests", "1");
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36");
                    wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    wc.Headers.Add("Cookie", "FedAuth=77u/PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz48U1A+VjExLDBoLmZ8bWVtYmVyc2hpcHx1cm4lM2FzcG8lM2Fhbm9uIzI4NGEwYjUzNWQwN2Q5OThhZjJlNDFmZTdhOWQ0Y2U3YTg5ODA2ZWEzNDhkNWRmZDhjYTYxYTYyMTA3ZGFmZDMsMCMuZnxtZW1iZXJzaGlwfHVybiUzYXNwbyUzYWFub24jMjg0YTBiNTM1ZDA3ZDk5OGFmMmU0MWZlN2E5ZDRjZTdhODk4MDZlYTM0OGQ1ZGZkOGNhNjFhNjIxMDdkYWZkMywxMzI3ODY5OTcxOTAwMDAwMDAsMCwxMzI3ODc4NTgxOTk3OTgxMTQsMC4wLjAuMCwyNTgsNjNlZmQyMzktNGRjMC00MzNjLWFiZmYtY2RlNjE5YWE1NjNhLCwsZmUxOWY5OWYtZTA4Yy0wMDAwLWNiNDAtYTk1MmE0ODMxZGQ0LGZlMTlmOTlmLWUwOGMtMDAwMC1jYjQwLWE5NTJhNDgzMWRkNCxrcGRzOE1KcUdFZUQ5RzkwaXUxb3lnLDAsMCwwLCwsLDI2NTA0Njc3NDM5OTk5OTk5OTksMCwsLCwsLCwwLGpWSndtV0FhbXBxSTNFaERPbERoRmd2RUJ6VmhsdTlhUi8wTm5TeUdlME9KWnpLdWR1WFlDVUlvRTd2eEorUldNZGxqdDN4TGlXWkpJS0ZiQzU5TUt0djBzbUpJSUVLMUpzcDIwR05QbmF1b2Y2bTdsamhOMGM3bjJKV0t1ZHd6TE1CaVJIbTJVTDlIcGg3aENoUWMrc0dKWkwrM0t1akt0RitHOVRha2pURjJaamlFK2V5ZUQvS0w3UTQ0WnZIVHFnQy80UGdGMXZzbHJ2ZWpJNDlHdXhCVEpXYlpQSW9QOWozbFp1S0hZTkk4a1JLbzA1aVRObTE5REdyL01vV0Q5U3U3Q2JXMEs5eWFZdWZiZ0JUdHhFQUNEbmIyeDJ4K0VOSnllQklvMmpsa2xKM1ozZ2RDcHdFWHlMWk42NjJ3MFFLbU1lREdZcWlNZXBYZy9wYnRadz09PC9TUD4=");
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(new Uri(m_objClientInformationModel.LinkLinkDownloadProfile), m_strFileNameDownLoad);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void Run()
        {
            Process p = new Process();
            p.StartInfo.FileName = @"App\Firefox64\firefox.exe";
            p.StartInfo.Arguments = @"/K -profile " + m_strFolderNameExtract;
            p.Start();
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(m_strFileNameDownLoad, m_strFolderNameExtract);
                File.Delete(m_strFileNameDownLoad);
                Run();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
