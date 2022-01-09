using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefoxPortableClient
{
    public partial class FirefoxProtable : Form
    {
        string[] MSG_CHECK = { "Key này không tồn tại. Vui lòng nhập key khác.", "SUCCESS", "Key đã hết hạn sử dụng. Vui lòng nhập key khác.", "Key này đã được sử dụng. Vui lòng nhập key khác.", "Bạn đã hết lượt download. Vui lòng quay lại vào ngày mai." };

        private string strKeyFile;
        private string m_strFolder;
        private string m_strFolderExtract;
        private string strRequestResult = string.Empty;
        private string strKey = string.Empty;
        private string strRequestCheckKeyFirst = Servers.SERVERURL + "/check.php?version=4.4.2&key={0}&first";
        private string strRequestCheckKey = Servers.SERVERURL + "/check.php?version=4.4.2&key={0}&";
        private string strRequestCheckUpdate = Servers.SERVERURL + "/r_update.php?key={0}";

        public FirefoxProtable()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                strKey = txtKey.Text;
                using (var wc = new CookieAwareWebClient())
                {
                    wc.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"94\", \"Google Chrome\";v=\"94\", \";Not A Brand\";v=\"99\"");
                    wc.Headers.Add("sec-ch-ua-mobile", "?0");
                    wc.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                    wc.Headers.Add("Upgrade-Insecure-Requests", "1");
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36");
                    wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    strRequestResult = wc.DownloadString(string.Format(strRequestCheckKeyFirst, strKey));
                }

                if (strRequestResult == "1")
                {
                    UpdateForm updateForm = new UpdateForm(strKey);
                    this.Hide();
                    updateForm.Show();
                }
                else
                {
                    labelStatus.Text = MSG_CHECK[int.Parse(strRequestResult)];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AfterLoading(object sender, EventArgs e)
        {
            try
            {
                this.Activated -= AfterLoading;
                m_strFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "WindowsNT", "Update System");
                m_strFolderExtract = Path.Combine(m_strFolder, "3abdab8dafdbed42e0252a3798707336");
                strKeyFile = Path.Combine(m_strFolder, "windows.dll");
                if (File.Exists(strKeyFile))
                {
                    strKey = File.ReadAllText(strKeyFile);

                    using (var wc = new CookieAwareWebClient())
                    {
                        wc.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"94\", \"Google Chrome\";v=\"94\", \";Not A Brand\";v=\"99\"");
                        wc.Headers.Add("sec-ch-ua-mobile", "?0");
                        wc.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                        wc.Headers.Add("Upgrade-Insecure-Requests", "1");
                        wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36");
                        wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                        // wc.Headers.Add("Cookie", "FedAuth=77u/PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz48U1A+VjExLDBoLmZ8bWVtYmVyc2hpcHx1cm4lM2FzcG8lM2Fhbm9uIzI4NGEwYjUzNWQwN2Q5OThhZjJlNDFmZTdhOWQ0Y2U3YTg5ODA2ZWEzNDhkNWRmZDhjYTYxYTYyMTA3ZGFmZDMsMCMuZnxtZW1iZXJzaGlwfHVybiUzYXNwbyUzYWFub24jMjg0YTBiNTM1ZDA3ZDk5OGFmMmU0MWZlN2E5ZDRjZTdhODk4MDZlYTM0OGQ1ZGZkOGNhNjFhNjIxMDdkYWZkMywxMzI3ODY5OTcxOTAwMDAwMDAsMCwxMzI3ODc4NTgxOTk3OTgxMTQsMC4wLjAuMCwyNTgsNjNlZmQyMzktNGRjMC00MzNjLWFiZmYtY2RlNjE5YWE1NjNhLCwsZmUxOWY5OWYtZTA4Yy0wMDAwLWNiNDAtYTk1MmE0ODMxZGQ0LGZlMTlmOTlmLWUwOGMtMDAwMC1jYjQwLWE5NTJhNDgzMWRkNCxrcGRzOE1KcUdFZUQ5RzkwaXUxb3lnLDAsMCwwLCwsLDI2NTA0Njc3NDM5OTk5OTk5OTksMCwsLCwsLCwwLGpWSndtV0FhbXBxSTNFaERPbERoRmd2RUJ6VmhsdTlhUi8wTm5TeUdlME9KWnpLdWR1WFlDVUlvRTd2eEorUldNZGxqdDN4TGlXWkpJS0ZiQzU5TUt0djBzbUpJSUVLMUpzcDIwR05QbmF1b2Y2bTdsamhOMGM3bjJKV0t1ZHd6TE1CaVJIbTJVTDlIcGg3aENoUWMrc0dKWkwrM0t1akt0RitHOVRha2pURjJaamlFK2V5ZUQvS0w3UTQ0WnZIVHFnQy80UGdGMXZzbHJ2ZWpJNDlHdXhCVEpXYlpQSW9QOWozbFp1S0hZTkk4a1JLbzA1aVRObTE5REdyL01vV0Q5U3U3Q2JXMEs5eWFZdWZiZ0JUdHhFQUNEbmIyeDJ4K0VOSnllQklvMmpsa2xKM1ozZ2RDcHdFWHlMWk42NjJ3MFFLbU1lREdZcWlNZXBYZy9wYnRadz09PC9TUD4=");
                        strRequestResult = wc.DownloadString(string.Format(strRequestCheckKey, strKey));

                        if (strRequestResult == "1")
                        {
                            string strUpdate = wc.DownloadString(string.Format(strRequestCheckUpdate, strKey));
                            if (strUpdate == "on")
                            {
                                UpdateForm updateForm = new UpdateForm(strKey);
                                this.Hide();
                                updateForm.Show();
                            }
                            else
                            {

                                string prefsPath = Path.Combine(m_strFolderExtract, "prefs.js");
                                string urlHomePage = string.Empty;
                                var lines = File.ReadAllLines(prefsPath);
                                for (int i = 0; i < lines.Length; i++)
                                {
                                    if (lines[i].Contains("user_pref(\"browser.startup.homepage\","))
                                    {
                                        urlHomePage = lines[i].Split(',')[1].Replace(");", "").Replace("\"","").Trim();
                                    }
                                }

                                if (Environment.Is64BitOperatingSystem)
                                {
                                    //Process p = new Process();
                                    //p.StartInfo.FileName = @"App\Firefox64\firefox.exe";
                                    //p.StartInfo.Arguments = $"/K about:newtab?key={strKey} -p -no-remote -profile \"{m_strFolderExtract}\"";

                                    Process.Start(@"App\Firefox64\firefox.exe", $"about:newtab?key={strKey}&transfer={urlHomePage} -p -no-remote -profile \"{m_strFolderExtract}\"");

                                    //p.Start();
                                }
                                else
                                {
                                    Process.Start(@"App\Firefox\firefox.exe", $"about:newtab?key={strKey}&transfer={urlHomePage} -p -no-remote -profile \"{m_strFolderExtract}\"");

                                }
                                Thread.Sleep(1000);
                                if (Application.MessageLoop)
                                {
                                    Application.Exit();
                                }
                                else
                                {
                                    Environment.Exit(1);
                                }
                            }
                        }
                        else
                        {
                            labelStatus.Text = MSG_CHECK[int.Parse(strRequestResult)];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Activated += AfterLoading;
        }
    }
}
