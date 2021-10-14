using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class ClientInformationModel
    {
        public Guid Id { get; set; }
        public string LinkLinkDownloadProfile { get; set; }
        public string FolderName { get; set; }
        public List<string> OtherFolderName { get; set; }
        public int GioiHanLuotDownload { get; set; }
        public DateTime? NgayKichHoat { get; set; }
    }
}
