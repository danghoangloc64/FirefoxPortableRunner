using FirefoxPortable.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortable.BLL
{
    public class TaiKhoanBLL
    {
       public string Get()
        {
            using (var context= new FirefoxPortableContext())
            {
                var data = context.TaiKhoan.FirstOrDefault(x => x.Deleted == false).Test;
                return data;
            }    
        }
    }
}
