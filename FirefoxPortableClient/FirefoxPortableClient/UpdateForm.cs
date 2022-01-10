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
    public partial class UpdateForm : Form
    {
        private string strRequestResult = string.Empty;
        private string strRequestGetLinkProfile = Servers.SERVERURL + "/r_link_profile.php?key={0}";
        private string strRequestUpdateDownloaded = Servers.SERVERURL + "/w_update.php?key={0}";
        private string m_strFileDownload;
        private string m_strFolder;
        private string m_strFolderExtract;
        private string strKeyFile;
        private string strKey;
        public UpdateForm(string key)
        {
            InitializeComponent();
            strKey = key;
        }

        private void UpdateForm_Leave(object sender, EventArgs e)
        {

        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(m_strFileDownload, m_strFolderExtract);
                File.Delete(m_strFileDownload);

                using (var wc = new CookieAwareWebClient())
                {
                    wc.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"94\", \"Google Chrome\";v=\"94\", \";Not A Brand\";v=\"99\"");
                    wc.Headers.Add("sec-ch-ua-mobile", "?0");
                    wc.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                    wc.Headers.Add("Upgrade-Insecure-Requests", "1");
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36");
                    wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    wc.DownloadString(string.Format(strRequestUpdateDownloaded, strKey));
                }
                if (File.Exists(strKeyFile))
                {
                    File.Delete(strKeyFile);
                }
                File.WriteAllText(strKeyFile, strKey);

                string prefsPath = Path.Combine(m_strFolderExtract, "prefs.js");
                string urlHomePage = string.Empty;
                var lines = File.ReadAllLines(prefsPath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("user_pref(\"browser.startup.homepage\","))
                    {
                        urlHomePage = lines[i].Split(',')[1].Replace(");", "").Replace("\"", "").Trim();
                    }
                }

                if (Environment.Is64BitOperatingSystem)
                {
                    Process.Start(@"App\Firefox64\firefox.exe", $"about:newtab?key={strKey}&transfer={urlHomePage} - p -no-remote -profile \"{m_strFolderExtract}\"");
                    Thread.Sleep(10000);
                    foreach (var process in Process.GetProcessesByName("firefox"))
                    {
                        process.Kill();
                    }
                    Process.Start(@"App\Firefox64\firefox.exe", $"about:newtab?key={strKey}&transfer={urlHomePage} - p -no-remote -profile \"{m_strFolderExtract}\"");
                }
                else
                {
                    Process.Start(@"App\Firefox\firefox.exe", $"about:newtab?key={strKey}&transfer={urlHomePage} -p -no-remote -profile \"{m_strFolderExtract}\"");
                    Thread.Sleep(10000);
                    foreach (var process in Process.GetProcessesByName("firefox"))
                    {
                        process.Kill();
                    }
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
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateForm_Load(object sender, EventArgs e)
        {
            m_strFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "WindowsNT", "Update System");
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "WindowsNT")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "WindowsNT"));
            }
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "WindowsNT", "Update System")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "WindowsNT", "Update System"));
            }
            m_strFileDownload = Path.Combine(m_strFolder, "3abdab8dafdbed42e0252a3798707336.zip");
            m_strFolderExtract = Path.Combine(m_strFolder, "3abdab8dafdbed42e0252a3798707336");
            strKeyFile = Path.Combine(m_strFolder, "windows.dll");
            using (var wc = new CookieAwareWebClient())
            {
                wc.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"94\", \"Google Chrome\";v=\"94\", \";Not A Brand\";v=\"99\"");
                wc.Headers.Add("sec-ch-ua-mobile", "?0");
                wc.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                wc.Headers.Add("Upgrade-Insecure-Requests", "1");
                wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36");
                wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                strRequestResult = wc.DownloadString(string.Format(strRequestGetLinkProfile, strKey));
                try
                {
                    if (File.Exists(m_strFileDownload))
                    {
                        File.Delete(m_strFileDownload);
                    }
                    if (Directory.Exists(m_strFolderExtract))
                    {
                        Directory.Delete(m_strFolderExtract, true);
                    }
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(new Uri(strRequestResult), m_strFileDownload);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
