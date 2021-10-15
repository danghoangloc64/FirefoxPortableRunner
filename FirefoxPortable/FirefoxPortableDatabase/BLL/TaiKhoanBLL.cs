using FirefoxPortableDatabase.DAL;
using FirefoxPortableDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.BLL
{
    public class TaiKhoanBLL
    {
        public void FirstLoadFirefoxPortableDatabaseContext()
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var data = context.TaiKhoan.First();
                }
            }
            catch
            {

            }
        }

        public List<TaiKhoanViewModel> GetListTaiKhoanViewModel()
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    List<TaiKhoanViewModel> taiKhoanViewModels = new List<TaiKhoanViewModel>();
                    var datas = context.TaiKhoan.Where(x => x.Deleted == false).ToList();
                    int iSTT = 1;
                    foreach (var data in datas)
                    {
                        taiKhoanViewModels.Add(new TaiKhoanViewModel(data, iSTT++));
                    }
                    return taiKhoanViewModels;
                }
            }
            catch
            {
                return new List<TaiKhoanViewModel>();
            }
        }

        public TaiKhoanCreateModel GetTaiKhoanCreateModelById(string strId)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Id.ToString() == strId);
                    if (data != null)
                    {
                        return new TaiKhoanCreateModel()
                        {
                            Id = data.Id,
                            TenLinkDownloadProfile = data.LinkDownloadProfile?.TenLinkDownloadProfile,
                            LinkLinkDownloadProfile = data.LinkDownloadProfile?.LinkLinkDownloadProfile,
                            GioiHanLuotDownload = data.GioiHanLuotDownload,
                            Actived = data.Actived,
                            Key = data.Key,
                            NgayHetHan = data.NgayHetHan,
                        };
                    }
                    else
                    {
                        return new TaiKhoanCreateModel();
                    }
                }
            }
            catch
            {
                return new TaiKhoanCreateModel();
            }
        }

        public ClientInformationModel GetClientInformationModelBySerialNo(string strDiskSerial)
        {
            using (var context = new FirefoxPortableDatabaseContext())
            {
                var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.DiskSerial == strDiskSerial && x.NgayHetHan > DateTime.Now && x.GioiHanLuotDownload >= x.SoLuotDaDownload);
                if (data != null)
                {
                    data.Actived = true;
                    context.SaveChanges();
                    ClientInformationModel clientInformationModel = new ClientInformationModel();
                    clientInformationModel.LinkLinkDownloadProfile = data.LinkDownloadProfile?.LinkLinkDownloadProfile;
                    clientInformationModel.FolderName = data.LinkDownloadProfile?.FolderName;
                    clientInformationModel.OtherFolderName = context.LinkDownloadProfile.Select(x => x.FolderName).ToList();
                    clientInformationModel.GioiHanLuotDownload = data.GioiHanLuotDownload;
                    clientInformationModel.NgayKichHoat = data.NgayKichHoat;
                    clientInformationModel.Id = data.Id;
                    if (!string.IsNullOrWhiteSpace(clientInformationModel.FolderName))
                    {
                        clientInformationModel.OtherFolderName.Remove(clientInformationModel.FolderName);
                    }
                    return clientInformationModel;
                }
                else
                {
                    return null;
                }
            }
        }

        public string Create(TaiKhoanCreateModel taiKhoanCreateModel)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var checkKey = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Key == taiKhoanCreateModel.Key);
                    if (checkKey != null)
                    {
                        return "Key đã tồn tại trong hệ thống, vui lòng nhập key khác.";
                    }
                    else
                    {
                        LinkDownloadProfile linkDownloadProfile = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false
                                                                    && x.TenLinkDownloadProfile == taiKhoanCreateModel.TenLinkDownloadProfile
                                                                    && x.LinkLinkDownloadProfile == taiKhoanCreateModel.LinkLinkDownloadProfile);
                        TaiKhoan taiKhoan = new TaiKhoan()
                        {
                            Actived = taiKhoanCreateModel.Actived,
                            Key = taiKhoanCreateModel.Key,
                            LinkDownloadProfile = linkDownloadProfile,
                            GioiHanLuotDownload = taiKhoanCreateModel.GioiHanLuotDownload,
                            NgayHetHan = taiKhoanCreateModel.NgayHetHan,
                        };
                        context.TaiKhoan.Add(taiKhoan);
                        context.SaveChanges();
                        return string.Empty;
                    }
                }
            }
            catch
            {
                return "Có lỗi xảy ra.\r\nVui lòng kiểm tra lại";
            }
        }

        public string Edit(TaiKhoanCreateModel tk)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var checkData = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Id != tk.Id && x.Key == tk.Key);
                    if (checkData != null)
                    {
                        return "Key đã tồn tại trong hệ thống. Vui lòng chọn key khác.";
                    }
                    var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Id == tk.Id);
                    if (data != null)
                    {
                        LinkDownloadProfile linkDownloadProfile = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false
                                                                   && x.TenLinkDownloadProfile == tk.TenLinkDownloadProfile
                                                                   && x.LinkLinkDownloadProfile == tk.LinkLinkDownloadProfile);
                        data.Actived = tk.Actived;
                        data.Key = tk.Key;
                        data.LinkDownloadProfile = linkDownloadProfile;
                        data.NgayHetHan = tk.NgayHetHan;
                        data.GioiHanLuotDownload = tk.GioiHanLuotDownload;
                        context.SaveChanges();
                        return string.Empty;
                    }
                    else
                    {
                        return "Có lỗi xảy ra.\r\nVui lòng kiểm tra lại";
                    }
                }
            }
            catch
            {
                return "Có lỗi xảy ra.\r\nVui lòng kiểm tra lại";
            }
        }

        public void UpdateActiveById(string strId, bool bActived)
        {
            using (var context = new FirefoxPortableDatabaseContext())
            {
                var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Id.ToString() == strId);
                if (data != null)
                {
                    data.Actived = bActived;
                    context.SaveChanges();
                }

            }
        }

        public void UpdateSoLuotDaDownload(int m_iDemLuotDownload, Guid id)
        {
            using (var context = new FirefoxPortableDatabaseContext())
            {
                var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Id == id);
                if (data != null)
                {
                    data.SoLuotDaDownload = m_iDemLuotDownload;
                    context.SaveChanges();
                }

            }
        }

        public int GetGioiHanLuotDownload(Guid id)
        {
            using (var context = new FirefoxPortableDatabaseContext())
            {
                var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Id == id);
                if (data != null)
                {
                    return data.GioiHanLuotDownload;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool Delete(string strId)
        {
            using (var context = new FirefoxPortableDatabaseContext())
            {
                var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Id.ToString() == strId);
                if (data != null)
                {
                    data.Deleted = true;
                    return context.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public ClientInformationModel GetClientInformationModel(string strKey, string strSerialNo)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false && x.Key == strKey && x.NgayHetHan > DateTime.Now && x.Actived == false && x.GioiHanLuotDownload >= x.SoLuotDaDownload);
                    if (data != null)
                    {
                        data.NgayKichHoat = DateTime.Today;
                        data.Actived = true;
                        data.DiskSerial = strSerialNo;
                        context.SaveChanges();
                        ClientInformationModel clientInformationModel = new ClientInformationModel();
                        clientInformationModel.LinkLinkDownloadProfile = data.LinkDownloadProfile?.LinkLinkDownloadProfile;
                        clientInformationModel.FolderName = data.LinkDownloadProfile?.FolderName;
                        clientInformationModel.OtherFolderName = context.LinkDownloadProfile.Select(x => x.FolderName).ToList();
                        clientInformationModel.GioiHanLuotDownload = data.GioiHanLuotDownload;
                        clientInformationModel.NgayKichHoat = data.NgayKichHoat;
                        clientInformationModel.Id = data.Id;
                        if (!string.IsNullOrWhiteSpace(clientInformationModel.FolderName))
                        {
                            clientInformationModel.OtherFolderName.Remove(clientInformationModel.FolderName);
                        }
                        return clientInformationModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
