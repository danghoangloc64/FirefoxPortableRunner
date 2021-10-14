using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
    public class TaiKhoanViewModel
    {
        public TaiKhoanViewModel(TaiKhoan data, int iSTT)
        {
            Id = data.Id;
            STT = iSTT;
            Key = data.Key;
            NgayHetHan = data.NgayHetHan;
            Actived = data.Actived;
            DiskSerial = data.DiskSerial;
            TenLinkDownloadProfile = data.LinkDownloadProfile?.TenLinkDownloadProfile;
            LinkLinkDownloadProfile = data.LinkDownloadProfile?.LinkLinkDownloadProfile;
            NgayKichHoat = data.NgayKichHoat;
            SoLuotDaDownload = data.SoLuotDaDownload;
            GioiHanLuotDownload = data.GioiHanLuotDownload;
            CreatedDate = data.CreatedDate;
            UpdatedDate = data.UpdatedDate;
        }

        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("STT")]
        public int STT { get; set; }

        [DisplayName("Key")]
        public string Key { get; set; }

        [DisplayName("Ngày hết hạn")]
        public DateTime? NgayHetHan { get; set; }

        [DisplayName("Đã kích hoạt")]
        public bool Actived { get; set; }

        [DisplayName("Disk Serial")]
        public string DiskSerial { get; set; }

        [DisplayName("Tên profile")]
        public string TenLinkDownloadProfile { get; set; }

        [DisplayName("Link profile")]
        public string LinkLinkDownloadProfile { get; set; }

        [DisplayName("Ngày kích hoạt")]
        public DateTime? NgayKichHoat { get; set; }

        [DisplayName("Giới hạn lượt download")]
        public int GioiHanLuotDownload { get; set; }

        [DisplayName("Số lượt đã download")]
        public int SoLuotDaDownload { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Ngày sửa")]
        public DateTime UpdatedDate { get; set; }
    }
}
