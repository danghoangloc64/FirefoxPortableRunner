using FirefoxPortableDatabase.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class TaiKhoan : AuditableEntity<Guid>
    {
        public string Key { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public bool Actived { get; set; }
        public string DiskSerial { get; set; }

        public virtual LinkDownloadProfile LinkDownloadProfile { get; set; }
    }
}
