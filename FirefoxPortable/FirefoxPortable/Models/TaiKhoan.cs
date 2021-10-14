using FirefoxPortable.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortable.Models
{
    public class TaiKhoan : AuditableEntity<Guid>
    {
        public string Test { get; set; }
    }
}
