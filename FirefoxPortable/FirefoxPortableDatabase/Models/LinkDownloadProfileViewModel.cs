using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class LinkDownloadProfileViewModel
    {
        public LinkDownloadProfileViewModel(LinkDownloadProfile data, int iSTT)
        {
            Id = data.Id;
            STT = iSTT;
            TenLinkDownloadProfile = data.TenLinkDownloadProfile;
            LinkLinkDownloadProfile = data.LinkLinkDownloadProfile;
        }

        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("STT")]
        public int STT { get; set; }

        [DisplayName("Tên profile")]
        public string TenLinkDownloadProfile { get; set; }

        [DisplayName("Link profile")]
        public string LinkLinkDownloadProfile { get; set; }
    }
}
