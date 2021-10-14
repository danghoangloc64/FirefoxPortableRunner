using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class TaiKhoanCreateModel
    {
        public TaiKhoanCreateModel()
        {
            NgayHetHan = DateTime.Today;
        }

        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Key")]
        public string Key { get; set; }

        [DisplayName("Kích hoạt")]
        public bool Actived { get; set; }

        [DisplayName("Ngày hết hạn")]
        public DateTime? NgayHetHan { get; set; }

        [DisplayName("Tên profile")]
        public string TenLinkDownloadProfile { get; set; }

        [DisplayName("Link profile")]
        public string LinkLinkDownloadProfile { get; set; }
    }
}
