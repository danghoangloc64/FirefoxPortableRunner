using FirefoxPortableDatabase.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class LinkDownloadProfile : AuditableEntity<Guid>
    {
        public string TenLinkDownloadProfile { get; set; }
        public string LinkLinkDownloadProfile { get; set; }
        public string FolderName { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
