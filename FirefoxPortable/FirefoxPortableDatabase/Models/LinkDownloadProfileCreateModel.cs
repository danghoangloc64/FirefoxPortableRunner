using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class LinkDownloadProfileCreateModel
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Tên profile")]
        public string TenLinkDownloadProfile { get; set; }

        [DisplayName("Link profile")]
        public string LinkLinkDownloadProfile { get; set; }

        public bool CheckValid()
        {
            if (string.IsNullOrWhiteSpace(TenLinkDownloadProfile) || string.IsNullOrWhiteSpace(LinkLinkDownloadProfile))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
