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

        public void Create(LinkDownloadProfileCreateModel linkDownloadProfileCreateModel)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    LinkDownloadProfile linkDownloadProfile = new LinkDownloadProfile()
                    {
                        TenLinkDownloadProfile = linkDownloadProfileCreateModel.TenLinkDownloadProfile,
                        LinkLinkDownloadProfile = linkDownloadProfileCreateModel.LinkLinkDownloadProfile
                    };
                    context.LinkDownloadProfile.Add(linkDownloadProfile);
                    context.SaveChanges();
                }
            }
            catch
            {

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

        public void Edit(LinkDownloadProfileCreateModel linkDownloadProfileCreateModel)
        {
            try
            {
                using (var context = new FirefoxPortableDatabaseContext())
                {
                    var data = context.LinkDownloadProfile.FirstOrDefault(x => x.Deleted == false && x.Id == linkDownloadProfileCreateModel.Id);
                    if (data != null)
                    {
                        data.TenLinkDownloadProfile = linkDownloadProfileCreateModel.TenLinkDownloadProfile;
                        data.LinkLinkDownloadProfile = linkDownloadProfileCreateModel.LinkLinkDownloadProfile;
                        context.SaveChanges();
                    }
                }
            }
            catch
            {

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
