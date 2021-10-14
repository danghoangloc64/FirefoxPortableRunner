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
                    var datas = context.TaiKhoan.Where(x => x.Deleted == false);
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



        public string Get()
        {
            using (var context = new FirefoxPortableDatabaseContext())
            {
                //var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false).Test;
                return "";
            }
        }
    }
}
