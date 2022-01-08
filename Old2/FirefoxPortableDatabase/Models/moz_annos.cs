using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPortableDatabase.Models
{
 public   class moz_annos
    {
        public int id { get; set; }
        public int place_id { get; set; }
        public int anno_attribute_id { get; set; }
        public string content { get; set; }
        public int flag { get; set; }
        public int expiration { get; set; }
        public int type { get; set; }
        public int dateAdded { get; set; }
        public int lastModified { get; set; }
    }
}
