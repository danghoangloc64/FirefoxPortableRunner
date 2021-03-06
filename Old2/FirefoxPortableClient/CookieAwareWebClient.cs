using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableClient
{
    class CookieAwareWebClient : WebClient
    {
        private CookieContainer cc = new CookieContainer();
        private string lastPage;

        protected override WebRequest GetWebRequest(System.Uri address)
        {
            WebRequest R = base.GetWebRequest(address);
            if (R is HttpWebRequest)
            {
                HttpWebRequest WR = (HttpWebRequest)R;
                WR.CookieContainer = cc;
                if (lastPage != null)
                {
                    WR.Referer = lastPage;
                }
            }
            lastPage = address.ToString();
            return R;
        }
    }
}
