using FirefoxPortableDatabase.DAL;
using FirefoxPortableDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.BLL
{
    public class LinkDownloadProfileBLL
    {
        public List<LinkDownloadProfileViewModel> GetListLinkDownloadProfileViewModel()
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    List<LinkDownloadProfileViewModel> linkDownloadProfileViewModels = new List<LinkDownloadProfileViewModel>();
                    var datas = context.LinkDownloadProfile.Where(x => x.Deleted == false);
                    int iSTT = 1;
                    foreach (var data in datas)
                    {
                        linkDownloadProfileViewModels.Add(new LinkDownloadProfileViewModel(data, iSTT++));
                    }
                    return linkDownloadProfileViewModels;
                }
            }
            catch
            {
                return new List<LinkDownloadProfileViewModel>();
            }
        }

        public List<LinkDownloadProfileSearchModel> GetListSearchModel()
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    List<LinkDownloadProfileSearchModel> linkDownloadProfileSearchModels = new List<LinkDownloadProfileSearchModel>();
                    var datas = context.LinkDownloadProfile.Where(x => x.Deleted == false);
                    foreach (var data in datas)
                    {
                        linkDownloadProfileSearchModels.Add(new LinkDownloadProfileSearchModel(data));
                    }
                    return linkDownloadProfileSearchModels;
                }
            }
            catch
            {
                return new List<LinkDownloadProfileSearchModel>();
            }
        }

        public string Create(LinkDownloadProfileCreateModel linkDownloadProfileCreateModel)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var checkData = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false && x.TenLinkDownloadProfile == linkDownloadProfileCreateModel.TenLinkDownloadProfile);
                    if (checkData != null)
                    {
                        return "Tên profile đã tồn tại trong hệ thống. Vui lòng chọn tên khác.";
                    }

                    string strFolderName = ExtensionMethod.RandomString();
                    var checkFolderName = context.LinkDownloadProfile.FirstOrDefault(x => x.FolderName == strFolderName);
                    while (checkFolderName != null)
                    {
                        strFolderName = ExtensionMethod.RandomString();
                        checkFolderName = context.LinkDownloadProfile.FirstOrDefault(x => x.FolderName == strFolderName);
                    }

                    LinkDownloadProfile linkDownloadProfile = new LinkDownloadProfile()
                    {
                        TenLinkDownloadProfile = linkDownloadProfileCreateModel.TenLinkDownloadProfile,
                        LinkLinkDownloadProfile = linkDownloadProfileCreateModel.LinkLinkDownloadProfile,
                        FolderName = strFolderName
                    };
                    context.LinkDownloadProfile.Add(linkDownloadProfile);
                    context.SaveChanges();
                    return string.Empty;
                }
            }
            catch
            {
                return "Có lỗi xảy ra.\r\nVui lòng kiểm tra lại";
            }
        }

        public LinkDownloadProfileCreateModel GetLinkDownloadProfileCreateModelById(string strId)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var data = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false && x.Id.ToString() == strId);
                    if (data != null)
                    {
                        return new LinkDownloadProfileCreateModel()
                        {
                            Id = data.Id,
                            TenLinkDownloadProfile = data.TenLinkDownloadProfile,
                            LinkLinkDownloadProfile = data.LinkLinkDownloadProfile
                        };
                    }
                    else
                    {
                        return new LinkDownloadProfileCreateModel();
                    }
                }
            }
            catch
            {
                return new LinkDownloadProfileCreateModel();
            }
        }

        public string Edit(LinkDownloadProfileCreateModel linkDownloadProfileCreateModel)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var checkData = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false && x.Id != linkDownloadProfileCreateModel.Id && x.TenLinkDownloadProfile == linkDownloadProfileCreateModel.TenLinkDownloadProfile);
                    if (checkData != null)
                    {
                        return "Tên profile đã tồn tại trong hệ thống. Vui lòng chọn tên khác.";
                    }
                    var data = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false && x.Id == linkDownloadProfileCreateModel.Id);
                    if (data != null)
                    {
                        data.TenLinkDownloadProfile = linkDownloadProfileCreateModel.TenLinkDownloadProfile;
                        data.LinkLinkDownloadProfile = linkDownloadProfileCreateModel.LinkLinkDownloadProfile;
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

        public bool Delete(string strId)
        {
            using (var context = new FirefoxPortableDatabaseContext())
            {
                var data = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false && x.Id.ToString() == strId);
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
    }
}
