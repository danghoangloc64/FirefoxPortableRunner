using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class LinkDownloadProfileSearchModel
    {
        [DisplayName("Tên profile")]
        public string TenLinkDownloadProfile { get; set; }

        [DisplayName("Link profile")]
        public string LinkLinkDownloadProfile { get; set; }
    }
}
